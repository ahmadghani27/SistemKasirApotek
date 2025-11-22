
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Kelola_User
    ' Muat desain DGV dan data awal saat form load
    Private Sub Kelola_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvUser.AllowUserToAddRows = False
        SetupComboBox()
        LoadData()
        ClearForm()
    End Sub
    ' Set up ComboBox dengan pilihan role
    Private Sub SetupComboBox()
        Dim roles() As String = {"Admin", "Kasir"}
        CmbRole.DataSource = roles
        CmbRole.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    ' Bersihkan form input
    Private Sub ClearForm()
        TxtNama.Clear()
        TxtUsername.Clear()
        TxtPassword.Clear()
        TxtTelepon.Clear()
        CmbRole.SelectedIndex = -1
        DgvUser.ClearSelection()
        TxtNama.Focus()
    End Sub
    ' Muat data pengguna dari database ke DataGridView
    Private Sub LoadData()
        DgvUser.Rows.Clear()

        Dim totalAdmin As Integer = 0
        Dim totalKasir As Integer = 0

        ' Menambahkan "WHERE isActive = true" untuk menyaring pengguna yang aktif
        Dim query As String = "SELECT id_pengguna, nama, telp, role, username FROM pengguna " &
                              "WHERE isActive = true ORDER BY nama"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim da As New MySqlDataAdapter(query, Koneksi.conn)
        Dim dt As New DataTable()

        Try
            ' Ambil semua data pengguna ke DataTable
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat data pengguna: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        ' Isi DGV dan hitung total (sekarang hanya total yang aktif)
        For Each row As DataRow In dt.Rows
            Dim id As Integer = CInt(row.Item("id_pengguna"))
            Dim nama As String = row.Item("nama").ToString()
            Dim telp As String = row.Item("telp").ToString()
            Dim peran As String = row.Item("role").ToString()
            Dim username As String = row.Item("username").ToString()

            DgvUser.Rows.Add(id, nama, telp, peran, username)

            ' Hitung total
            If peran = "Admin" Then
                totalAdmin += 1
            ElseIf peran = "Kasir" Then
                totalKasir += 1
            End If
        Next

        ' update label total admin & kasir
        LblTotalAdmin.Text = totalAdmin.ToString()
        LblTotalKasir.Text = totalKasir.ToString()
    End Sub

    ' tombol tambah user
    Private Sub BtnTambahUser_Click(sender As Object, e As EventArgs) Handles BtnTambahUser.Click
        ' validasi input
        If String.IsNullOrWhiteSpace(TxtNama.Text) OrElse
           String.IsNullOrWhiteSpace(TxtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(TxtPassword.Text) OrElse
           String.IsNullOrWhiteSpace(TxtTelepon.Text) Then
            MessageBox.Show("Semua kolom (Nama, Username, Pass, Telepon) harus diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' validasi role dipilih
        If CmbRole.SelectedIndex = -1 Then
            MessageBox.Show("Silakan pilih Peran (Admin/Kasir).", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' validasi telepon
        Dim telp As String = TxtTelepon.Text.Trim()
        Dim isValidNumber As Boolean = False
        Dim numericPart As String = ""

        If telp.StartsWith("08") Then
            isValidNumber = Long.TryParse(telp, Nothing)
        ElseIf telp.StartsWith("+628") Then
            ' Jika diawali "+628", sisa string (setelah '+') harus berupa angka
            numericPart = telp.Substring(1) ' Ambil "628..."
            isValidNumber = Long.TryParse(numericPart, Nothing)
        End If

        ' Jika salah satu cek di atas gagal (isValidNumber masih False)
        If Not isValidNumber Then
            MessageBox.Show("Nomor Telepon tidak valid." & vbCrLf & vbCrLf &
                            "1. Harus diawali '08' (cth: 0812...)" & vbCrLf &
                            "2. Atau diawali '+628' (cth: +62812...)" & vbCrLf &
                            "3. Hanya boleh berisi angka (setelah prefix).",
                            "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtTelepon.Focus()
            TxtTelepon.SelectAll()
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
            ' Tambahkan parameter untuk mencegah SQL Injection
            cmd.Parameters.AddWithValue("@nama", TxtNama.Text)
            cmd.Parameters.AddWithValue("@user", TxtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", TxtPassword.Text)
            cmd.Parameters.AddWithValue("@telp", TxtTelepon.Text) ' Simpan nomor telepon yang sudah divalidasi
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

    ' tombol hapus user
    Private Sub BtnHapusUser_Click(sender As Object, e As EventArgs) Handles BtnHapusUser.Click
        ' Cek 1: Apakah ada baris yang dipilih?
        If DgvUser.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih pengguna di tabel yang ingin dihapus.", "Pilih Baris", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim peranDipilih As String = DgvUser.SelectedRows(0).Cells("ColRole").Value.ToString()
        Dim totalAdmin As Integer = 0
        Integer.TryParse(LblTotalAdmin.Text, totalAdmin)

        ' Cek 2: Apakah ini Admin terakhir? (Logika ini tetap penting)
        If peranDipilih = "Admin" AndAlso totalAdmin = 1 Then
            MessageBox.Show("Gagal Menonaktifkan! Anda tidak boleh menonaktifkan Admin terakhir." & vbCrLf &
                            "Sistem harus memiliki minimal satu Admin aktif.", "Logika Bisnis", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Cek 3: Konfirmasi Nonaktifkan
        Dim nama As String = DgvUser.SelectedRows(0).Cells("ColNama").Value.ToString()
        If MessageBox.Show($"Yakin ingin menonaktifkan pengguna '{nama}'?" & vbCrLf &
                           "Pengguna ini tidak akan bisa login lagi.",
                           "Konfirmasi Nonaktifkan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
            Return
        End If

        ' Ambil ID dari baris yang dipilih
        Dim idPengguna As String = DgvUser.SelectedRows(0).Cells("ColId").Value.ToString()

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Cek apakah pengguna sudah pernah melakukan transaksi
            Dim queryCek As String = "SELECT COUNT(*) FROM transaksi WHERE id_pengguna = @id"
            Dim cmdCek As New MySqlCommand(queryCek, Koneksi.conn)
            cmdCek.Parameters.AddWithValue("@id", idPengguna)
            Dim jumlahTransaksi As Integer = Convert.ToInt32(cmdCek.ExecuteScalar())

            If jumlahTransaksi = 0 Then
                ' Jika belum ada transaksi, HAPUS pengguna
                Dim queryDel As String = "DELETE FROM pengguna WHERE id_pengguna = @id"
                Dim cmdDel As New MySqlCommand(queryDel, Koneksi.conn)
                cmdDel.Parameters.AddWithValue("@id", idPengguna)
                cmdDel.ExecuteNonQuery()
                MessageBox.Show("Pengguna berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Jika sudah ada transaksi, NONAKTIFKAN pengguna
                Dim queryUpdate As String = "UPDATE pengguna SET isActive = false WHERE id_pengguna = @id"
                Dim cmdUpdate As New MySqlCommand(queryUpdate, Koneksi.conn)
                cmdUpdate.Parameters.AddWithValue("@id", idPengguna)
                cmdUpdate.ExecuteNonQuery()
                MessageBox.Show("Pengguna berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    ' tombol bersihkan form
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub

    'tombol keluar
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
    End Sub

    ' Saat pemilihan baris di DGV berubah, tampilkan data di form input
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