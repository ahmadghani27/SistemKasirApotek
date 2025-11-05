Option Strict On
Option Explicit On

Imports System.Data
Imports MySql.Data.MySqlClient

Public Class DashBoard

    ' HAPUS SEMUA VARIABEL "ConnectionString" DARI SINI
    ' Kita akan menggunakan Koneksi.vb

    ' Sesuaikan nama tabel/kolom ini jika diperlukan
    Private Const TableTransaksi As String = "transaksi" ' Pastikan nama tabel benar
    Private Const TableObat As String = "obat"          ' Pastikan nama tabel benar
    ' Diubah agar KONSISTEN dengan form Login Anda
    Private Const TableUser As String = "pengguna"
    Private Const ColTransaksiTanggal As String = "Tanggal" ' Ganti jika nama kolom beda
    Private Const ColTransaksiKasir As String = "NamaKasir"
    Private Const ColTransaksiIdObat As String = "IdObat"
    Private Const ColObatNama As String = "NamaObat"
    Private Const ColObatJenis As String = "JenisObat"

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate filter categories
        CmbFilterKategori.Items.Clear()
        CmbFilterKategori.Items.Add("Kasir")
        CmbFilterKategori.Items.Add("Jenis Obat")
        CmbFilterKategori.Items.Add("Nama Obat")
        CmbFilterKategori.Items.Add("ID Obat")
        CmbFilterKategori.SelectedIndex = 0

        ' Load initial data
        LoadTotals()
        LoadTransactions()
    End Sub

    Private Sub LoadTotals()
        ' Diubah agar menggunakan Koneksi.vb
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Gagal terhubung ke DB saat memuat total.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Total Obat
            Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableObat}", Koneksi.conn)
                Dim totalObat = Convert.ToInt32(cmd.ExecuteScalar())
                LblTotalObat.Text = totalObat.ToString("N0")
            End Using

            ' Total Transaksi hari ini (MySQL DATE() and CURDATE())
            Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableTransaksi} WHERE DATE({ColTransaksiTanggal}) = CURDATE()", Koneksi.conn)
                Dim totalToday = Convert.ToInt32(cmd.ExecuteScalar())
                LblTotalTransaksi.Text = totalToday.ToString("N0")
            End Using

            ' Total User (kasir)
            Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableUser}", Koneksi.conn)
                Dim totalUser = Convert.ToInt32(cmd.ExecuteScalar())
                LblTotalUser.Text = totalUser.ToString("N0")
            End Using

        Catch ex As Exception
            LblTotalObat.Text = "N/A"
            LblTotalTransaksi.Text = "N/A"
            LblTotalUser.Text = "N/A"
            ' Ini adalah pesan error yang Anda lihat
            MessageBox.Show($"Gagal memuat total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Selalu tutup koneksi
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    Private Sub LoadTransactions(Optional sql As String = "", Optional params As MySqlParameter() = Nothing)
        ' Diubah agar menggunakan Koneksi.vb
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Gagal terhubung ke DB saat memuat transaksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim query As String = sql
            If String.IsNullOrWhiteSpace(query) Then
                ' Gunakan LIMIT untuk MySQL
                query = $"SELECT * FROM {TableTransaksi} ORDER BY {ColTransaksiTanggal} DESC LIMIT 100"
            End If

            Using cmd As New MySqlCommand(query, Koneksi.conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    DgvRiwayatTransaksi.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Gagal memuat riwayat transaksi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Selalu tutup koneksi
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim kategori = If(CmbFilterKategori.SelectedItem?.ToString(), String.Empty)
        Dim keyword = TxtFilterKataKunci.Text.Trim()

        If String.IsNullOrEmpty(kategori) OrElse String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Pilih kategori dan masukkan kata kunci.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim sql As String = ""
        Dim prm As MySqlParameter() = Nothing

        Select Case kategori
            Case "Kasir"
                sql = $"SELECT * FROM {TableTransaksi} WHERE {ColTransaksiKasir} LIKE @kw ORDER BY {ColTransaksiTanggal} DESC"
                prm = New MySqlParameter() {New MySqlParameter("@kw", MySqlDbType.VarChar) With {.Value = $"%{keyword}%"}}
            Case "Jenis Obat"
                ' Asumsi Anda perlu JOIN ke tabel Obat
                sql = $"SELECT t.* FROM {TableTransaksi} t JOIN {TableObat} o ON t.{ColTransaksiIdObat} = o.IdObat WHERE o.{ColObatJenis} LIKE @kw ORDER BY t.{ColTransaksiTanggal} DESC"
                prm = New MySqlParameter() {New MySqlParameter("@kw", MySqlDbType.VarChar) With {.Value = $"%{keyword}%"}}
            Case "Nama Obat"
                ' Asumsi Anda perlu JOIN ke tabel Obat
                sql = $"SELECT t.* FROM {TableTransaksi} t JOIN {TableObat} o ON t.{ColTransaksiIdObat} = o.IdObat WHERE o.{ColObatNama} LIKE @kw ORDER BY t.{ColTransaksiTanggal} DESC"
                prm = New MySqlParameter() {New MySqlParameter("@kw", MySqlDbType.VarChar) With {.Value = $"%{keyword}%"}}
            Case "ID Obat"
                sql = $"SELECT * FROM {TableTransaksi} WHERE {ColTransaksiIdObat} = @kw ORDER BY {ColTransaksiTanggal} DESC"
                prm = New MySqlParameter() {New MySqlParameter("@kw", MySqlDbType.VarChar) With {.Value = keyword}}
            Case Else
                MessageBox.Show("Kategori tidak dikenali.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
        End Select

        LoadTransactions(sql, prm)
    End Sub

    Private Sub BtnTampilSemua_Click(sender As Object, e As EventArgs) Handles BtnTampilSemua.Click
        TxtFilterKataKunci.Clear()
        CmbFilterKategori.SelectedIndex = 0
        LoadTransactions()
    End Sub

    Private Sub BtnKelolaStok_Click(sender As Object, e As EventArgs) Handles BtnKelolaStok.Click
        Try
            ' Ganti "Kelola_Stok" dengan nama Form Anda
            Dim f As New Kelola_Stok()
            f.ShowDialog()
            ' Muat ulang data setelah form ditutup
            LoadTotals()
            LoadTransactions()
        Catch ex As Exception
            MessageBox.Show($"Gagal membuka form Kelola Stok: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnKelolaUser_Click(sender As Object, e As EventArgs) Handles BtnKelolaUser.Click
        Try
            ' Ganti "Kelola_User" dengan nama Form Anda
            Dim f As New Kelola_User()
            f.ShowDialog()
            ' Muat ulang data setelah form ditutup
            LoadTotals()
            LoadTransactions()
        Catch ex As Exception
            MessageBox.Show($"Gagal membuka form Kelola User: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Try
            ' Ganti "Login" dengan nama Form Login Anda
            Dim f As New Login()
            f.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Gagal logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class