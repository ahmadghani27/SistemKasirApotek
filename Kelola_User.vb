
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Kelola_User

    Private Sub Kelola_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvUser.AllowUserToAddRows = False
        SetupComboBox()
        LoadData()
        ClearForm()
    End Sub
    Private Sub SetupComboBox()
        Dim roles() As String = {"Admin", "Kasir"}
        CmbRole.DataSource = roles
        CmbRole.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub ClearForm()
        TxtNama.Clear()
        TxtUsername.Clear()
        TxtPassword.Clear()
        TxtTelepon.Clear()
        CmbRole.SelectedIndex = -1
        DgvUser.ClearSelection()
        TxtNama.Focus()
    End Sub

    Private Sub LoadData()
        DgvUser.Rows.Clear()

        Dim totalAdmin As Integer = 0
        Dim totalKasir As Integer = 0

        ' Jangan ambil password, tidak aman untuk ditampilkan
        Dim query As String = "SELECT id_pengguna, nama, telp, role, username FROM pengguna ORDER BY nama"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim da As New MySqlDataAdapter(query, Koneksi.conn)
        Dim dt As New DataTable()

        Try
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat data pengguna: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        ' Isi DGV dan hitung total
        For Each row As DataRow In dt.Rows
            Dim id As Integer = CInt(row.Item("id_pengguna"))
            Dim nama As String = row.Item("nama").ToString()
            Dim telp As String = row.Item("telp").ToString()
            Dim peran As String = row.Item("role").ToString()
            Dim username As String = row.Item("username").ToString()

            ' Tambahkan ke grid (sesuai urutan di gambar/petunjuk)
            DgvUser.Rows.Add(id, nama, telp, peran, username)

            ' Hitung total
            If peran = "Admin" Then
                totalAdmin += 1
            ElseIf peran = "Kasir" Then
                totalKasir += 1
            End If
        Next

        ' Update label KPI
        LblTotalAdmin.Text = totalAdmin.ToString()
        LblTotalKasir.Text = totalKasir.ToString()
    End Sub

    Private Sub BtnTambahUser_Click(sender As Object, e As EventArgs) Handles BtnTambahUser.Click
        If String.IsNullOrWhiteSpace(TxtNama.Text) OrElse
           String.IsNullOrWhiteSpace(TxtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(TxtPassword.Text) OrElse
           String.IsNullOrWhiteSpace(TxtTelepon.Text) Then
            MessageBox.Show("Semua kolom (Nama, Username, Pass, Telepon) harus diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If CmbRole.SelectedIndex = -1 Then
            MessageBox.Show("Silakan pilih Peran (Admin/Kasir).", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query As String = "INSERT INTO pengguna (nama, username, pass, telp, role) " &
                              "VALUES (@nama, @user, @pass, @telp, @role)"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        Try
            cmd.Parameters.AddWithValue("@nama", TxtNama.Text)
            cmd.Parameters.AddWithValue("@user", TxtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", TxtPassword.Text)
            cmd.Parameters.AddWithValue("@telp", TxtTelepon.Text)
            cmd.Parameters.AddWithValue("@role", CmbRole.SelectedItem.ToString())

            cmd.ExecuteNonQuery()
            MessageBox.Show("Pengguna baru berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MySqlException
            ' Tangani error jika username sudah ada (Unique Key)
            If ex.Number = 1062 Then
                MessageBox.Show("Username '" & TxtUsername.Text & "' sudah digunakan. Silakan ganti.", "Username Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Terjadi kesalahan saat menambah pengguna: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        ' Muat ulang data dan bersihkan form
        LoadData()
        ClearForm()
    End Sub

    Private Sub BtnHapusUser_Click(sender As Object, e As EventArgs) Handles BtnHapusUser.Click
        If DgvUser.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih pengguna di tabel yang ingin dihapus.", "Pilih Baris", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim peranDipilih As String = DgvUser.SelectedRows(0).Cells("ColRole").Value.ToString()
        Dim totalAdmin As Integer = 0
        ' Ambil nilai total admin dari label (pastikan konversi aman)
        Integer.TryParse(LblTotalAdmin.Text, totalAdmin)

        ' Cek 2: Apakah ini Admin terakhir?
        If peranDipilih = "Admin" AndAlso totalAdmin = 1 Then
            MessageBox.Show("Gagal Menghapus! Anda tidak boleh menghapus Admin terakhir." & vbCrLf &
                            "Sistem harus memiliki minimal satu Admin.", "Logika Bisnis", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Cek 3: Konfirmasi Hapus (Hanya jika lolos cek 1 & 2)
        Dim nama As String = DgvUser.SelectedRows(0).Cells("ColNama").Value.ToString()
        If MessageBox.Show($"Yakin ingin menghapus pengguna '{nama}'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
            Return
        End If

        ' Ambil ID dari baris yang dipilih
        Dim idPengguna As String = DgvUser.SelectedRows(0).Cells("ColId").Value.ToString()

        Dim query As String = "DELETE FROM pengguna WHERE id_pengguna = @id"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        Try
            cmd.Parameters.AddWithValue("@id", idPengguna)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Pengguna berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menghapus: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        ' Muat ulang data dan bersihkan form
        LoadData()
        ClearForm()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
    End Sub

    Private Sub DgvUser_SelectionChanged(sender As Object, e As EventArgs) Handles DgvUser.SelectionChanged
        If DgvUser.SelectedRows.Count = 0 Then
            Return ' Jangan lakukan apa-apa jika tidak ada baris
        End If

        Dim selectedRow As DataGridViewRow = DgvUser.SelectedRows(0)

        TxtNama.Text = selectedRow.Cells("ColNama").Value.ToString()
        TxtUsername.Text = selectedRow.Cells("ColUsername").Value.ToString()
        TxtTelepon.Text = selectedRow.Cells("ColTelp").Value.ToString()
        CmbRole.SelectedItem = selectedRow.Cells("ColRole").Value.ToString()

        TxtPassword.Clear()
    End Sub

End Class