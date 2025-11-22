Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Kelola_Stok
    ' DataTable untuk menyimpan data obat
    Private dtObat As DataTable
    ' Inisialisasi form dan muat data saat load
    Private Sub Kelola_Stok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitTable()
        LoadDataFromDatabase()
        BindGrid()
        InitCombo()
        WireEvents()
        ClearInputs()
    End Sub

    ' Muat data obat dari database ke DataTable
    Private Sub LoadDataFromDatabase()
        dtObat.Rows.Clear()

        Dim query As String = "SELECT id_obat, nama, jenis, harga, stock, tgl_expired FROM obat"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Gunakan DataAdapter untuk mengisi DataTable sementara
        Dim da As New MySqlDataAdapter(query, Koneksi.conn)
        Dim dbDataTable As New DataTable()

        Try
            ' Ambil semua data obat ke DataTable sementara
            da.Fill(dbDataTable)
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data obat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        ' Loop data dari DataTable sementara dan masukkan ke dtObat
        For Each row As DataRow In dbDataTable.Rows
            Try
                dtObat.Rows.Add(
                    row("id_obat"),
                    row("nama"),
                    row("jenis"),
                    row("harga"),
                    row("stock"),
                    row("tgl_expired")
                )
            Catch ex As Exception
                ' Tangani error konversi data jika ada
                MessageBox.Show("Gagal memproses data obat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub

    ' Inisialisasi struktur DataTable
    Private Sub InitTable()
        dtObat = New DataTable()
        dtObat.Columns.Add("IDObat", GetType(String))
        dtObat.Columns.Add("NamaObat", GetType(String))
        dtObat.Columns.Add("Jenis", GetType(String))
        dtObat.Columns.Add("Harga", GetType(Decimal))
        dtObat.Columns.Add("Stok", GetType(Integer))
        dtObat.Columns.Add("Kadaluarsa", GetType(Date))
    End Sub

    ' Bind DataTable ke DataGridView
    Private Sub BindGrid()
        DgvObat.DataSource = dtObat
    End Sub

    ' Inisialisasi ComboBox Jenis Obat
    Private Sub InitCombo()
        CmbJenis.Items.Clear()
        CmbJenis.Items.AddRange(New String() {"Tablet", "Sirup", "Salep", "Kapsul", "Injeksi", "Lainnya"})
        If CmbJenis.Items.Count > 0 Then CmbJenis.SelectedIndex = 0
    End Sub

    ' Pasang event handler untuk tombol dan DGV
    Private Sub WireEvents()
        AddHandler BtnTambah.Click, AddressOf BtnTambah_Click
        AddHandler BtnUbah.Click, AddressOf BtnUbah_Click
        AddHandler BtnHapus.Click, AddressOf BtnHapus_Click
        AddHandler BtnBersih.Click, AddressOf BtnBersih_Click
        AddHandler DgvObat.SelectionChanged, AddressOf DgvObat_SelectionChanged
    End Sub

    ' Tambah data obat baru
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs)
        Dim id = TxtIDObat.Text.Trim()
        ' jika id kosong
        If id = "" Then
            MessageBox.Show("ID Obat wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtIDObat.Focus()
            Return
        End If
        ' cek duplikat di DataTable lokal
        If dtObat.Select($"IDObat = '{id.Replace("'", "''")}'").Length > 0 Then
            MessageBox.Show("ID Obat sudah ada. Gunakan ID unik.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtIDObat.Focus()
            Return
        End If

        ' Validasi input lainnya
        Dim nama = TxtNamaObat.Text.Trim()
        If nama = "" Then
            MessageBox.Show("Nama Obat wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNamaObat.Focus()
            Return
        End If

        ' Validasi harga
        Dim hargaDecimal As Decimal
        If Not Decimal.TryParse(TxtHarga.Text.Trim(), hargaDecimal) OrElse hargaDecimal < 0D Then
            MessageBox.Show("Harga harus angka positif.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtHarga.Focus()
            Return
        End If

        ' Validasi stok
        Dim stokInt As Integer
        If Not Integer.TryParse(TxtStok.Text.Trim(), stokInt) OrElse stokInt < 0 Then
            MessageBox.Show("Stok harus bilangan bulat >= 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtStok.Focus()
            Return
        End If

        ' Ambil jenis dan kadaluarsa
        Dim jenis = If(CmbJenis.SelectedItem IsNot Nothing, CmbJenis.SelectedItem.ToString(), "")
        Dim kadaluarsa = DtpKadaluarsa.Value.Date

        Dim query As String = "INSERT INTO obat (id_obat, nama, jenis, harga, stock, tgl_expired) " &
                              "VALUES (@id, @nama, @jenis, @harga, @stok, @tgl)"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Eksekusi perintah INSERT
        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        Try
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@nama", nama)
            cmd.Parameters.AddWithValue("@jenis", jenis)
            cmd.Parameters.AddWithValue("@harga", hargaDecimal)
            cmd.Parameters.AddWithValue("@stok", stokInt)
            cmd.Parameters.AddWithValue("@tgl", kadaluarsa)

            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("ID Obat '" & id & "' sudah ada di database.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Gagal menambah data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Koneksi.TutupKoneksi()
            Return
        Catch ex As Exception
            MessageBox.Show("Gagal menambah data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Koneksi.TutupKoneksi()
            Return
        Finally
            If Koneksi.conn.State = ConnectionState.Open Then
                Koneksi.TutupKoneksi()
            End If
        End Try

        ' Jika sukses, baru tambahkan ke DataTable lokal
        dtObat.Rows.Add(id, nama, jenis, hargaDecimal, stokInt, kadaluarsa)
        ClearInputs()
    End Sub

    ' tombol ubah data obat
    Private Sub BtnUbah_Click(sender As Object, e As EventArgs)
        ' jika tidak ada baris yang dipilih
        If DgvObat.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih baris data untuk diubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' jika ada baris yang dipilih
        Dim row As DataRow = CType(CType(DgvObat.SelectedRows(0).DataBoundItem, DataRowView).Row, DataRow)
        If row Is Nothing Then Return

        Dim id As String = row("IDObat").ToString()

        ' Validasi input
        Dim nama = TxtNamaObat.Text.Trim()
        If nama = "" Then
            Return
        End If

        Dim hargaDecimal As Decimal
        If Not Decimal.TryParse(TxtHarga.Text.Trim(), hargaDecimal) OrElse hargaDecimal < 0D Then
            Return
        End If

        Dim stokInt As Integer
        If Not Integer.TryParse(TxtStok.Text.Trim(), stokInt) OrElse stokInt < 0 Then
            Return
        End If

        ' Ambil jenis dan kadaluarsa
        Dim jenis = If(CmbJenis.SelectedItem IsNot Nothing, CmbJenis.SelectedItem.ToString(), "")
        Dim kadaluarsa = DtpKadaluarsa.Value.Date

        ' Perintah UPDATE
        Dim query As String = "UPDATE obat SET nama = @nama, jenis = @jenis, harga = @harga, " &
                              "stock = @stok, tgl_expired = @tgl WHERE id_obat = @id"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Eksekusi perintah UPDATE
        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        Try
            cmd.Parameters.AddWithValue("@nama", nama)
            cmd.Parameters.AddWithValue("@jenis", jenis)
            cmd.Parameters.AddWithValue("@harga", hargaDecimal)
            cmd.Parameters.AddWithValue("@stok", stokInt)
            cmd.Parameters.AddWithValue("@tgl", kadaluarsa)
            cmd.Parameters.AddWithValue("@id", id)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Koneksi.TutupKoneksi()
            Return
        Finally
            If Koneksi.conn.State = ConnectionState.Open Then
                Koneksi.TutupKoneksi()
            End If
        End Try

        ' Jika sukses, baru update DataTable lokal
        row("NamaObat") = nama
        row("Jenis") = jenis
        row("Harga") = hargaDecimal
        row("Stok") = stokInt
        row("Kadaluarsa") = kadaluarsa

        DgvObat.Refresh()
        ClearInputs()
    End Sub

    ' tombol hapus data obat
    Private Sub BtnHapus_Click(sender As Object, e As EventArgs)
        If DgvObat.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih baris data untuk dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show("Yakin ingin menghapus data obat yang dipilih?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim row As DataRow = CType(CType(DgvObat.SelectedRows(0).DataBoundItem, DataRowView).Row, DataRow)
        ' Validasi tambahan jika row null (jarang terjadi tapi aman)
        If row Is Nothing Then Return

        Dim id = row("IDObat").ToString()
        Dim query As String = "DELETE FROM obat WHERE id_obat = @id"
        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim cmd As New MySqlCommand(query, Koneksi.conn)

        Try
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()

            row.Delete()
            ClearInputs()
            MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MySqlException
            ' Handle Error Constraint (Data terpakai)
            If ex.Number = 1451 Then
                MessageBox.Show("Gagal menghapus! Obat ini sudah pernah digunakan dalam transaksi/resep.", "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Terjadi kesalahan database: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Tutup koneksi
            Koneksi.TutupKoneksi()
        End Try
    End Sub
    ' tombol bersihkan input
    Private Sub BtnBersih_Click(sender As Object, e As EventArgs)
        ClearInputs()
    End Sub

    ' Bersihkan semua input form
    Private Sub ClearInputs()
        TxtIDObat.Clear()
        TxtNamaObat.Clear()
        If CmbJenis.Items.Count > 0 Then CmbJenis.SelectedIndex = 0
        TxtHarga.Clear()
        TxtStok.Clear()
        DtpKadaluarsa.Value = Date.Today
        DgvObat.ClearSelection()
        TxtIDObat.Enabled = True
    End Sub

    ' Event handler saat pemilihan baris di DGV berubah
    Private Sub DgvObat_SelectionChanged(sender As Object, e As EventArgs)
        ' jika tidak ada baris yang dipilih
        If DgvObat.SelectedRows.Count = 0 Then
            Return
        End If
        ' Ambil DataRow dengan cara yang benar dari DataRowView
        Dim row As DataRow
        Try
            row = CType(CType(DgvObat.SelectedRows(0).DataBoundItem, DataRowView).Row, DataRow)
            If row Is Nothing Then Return
        Catch ex As Exception
            Return
        End Try

        ' ambil data dari DataRow dan tampilkan di input form
        TxtIDObat.Text = row("IDObat").ToString()
        TxtNamaObat.Text = row("NamaObat").ToString()

        ' Atur ComboBox Jenis
        Dim jenis = row("Jenis").ToString()
        ' jika jenis tidak ada di daftar, tambahkan
        If CmbJenis.Items.Contains(jenis) Then
            CmbJenis.SelectedItem = jenis
        Else
            ' jika tidak kosong, tambahkan ke daftar
            If jenis <> "" Then
                CmbJenis.Items.Add(jenis)
                CmbJenis.SelectedItem = jenis
            End If
        End If

        ' Atur nilai lainnya
        TxtHarga.Text = Convert.ToDecimal(row("Harga")).ToString("0.##")
        TxtStok.Text = row("Stok").ToString()
        DtpKadaluarsa.Value = Convert.ToDateTime(row("Kadaluarsa"))

        ' Jangan biarkan pengguna mengubah ID
        TxtIDObat.Enabled = False
    End Sub

    ' tombol keluar
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
    End Sub
End Class