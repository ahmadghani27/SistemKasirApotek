Option Strict On
Option Explicit On

Imports System.Data
Imports MySql.Data.MySqlClient

Public Class DashBoard

    ' Update this connection string to your environment (__Server__, __Database__, credentials)
    ' Example MySQL connection string:
    ' Private ReadOnly ConnectionString As String = "Server=localhost;Database=YourDatabase;Uid=root;Pwd=yourpassword;SslMode=Preferred;"
    Private ReadOnly ConnectionString As String = "Server=localhost;Database=YourDatabase;Uid=root;Pwd=yourpassword;SslMode=Preferred;"

    ' Adjust table/column names to match your schema
    Private Const TableTransaksi As String = "Transaksi"
    Private Const TableObat As String = "Obat"
    Private Const TableUser As String = "Users"
    Private Const ColTransaksiTanggal As String = "Tanggal"
    Private Const ColTransaksiKasir As String = "NamaKasir" ' column in Transaksi for kasir name or join field
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
        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                ' Total Obat
                Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableObat}", cn)
                    Dim totalObat = Convert.ToInt32(cmd.ExecuteScalar())
                    LblTotalObat.Text = totalObat.ToString("N0")
                End Using

                ' Total Transaksi hari ini (MySQL DATE() and CURDATE())
                Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableTransaksi} WHERE DATE({ColTransaksiTanggal}) = CURDATE()", cn)
                    Dim totalToday = Convert.ToInt32(cmd.ExecuteScalar())
                    LblTotalTransaksi.Text = totalToday.ToString("N0")
                End Using

                ' Total User (kasir)
                Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableUser}", cn)
                    Dim totalUser = Convert.ToInt32(cmd.ExecuteScalar())
                    LblTotalUser.Text = totalUser.ToString("N0")
                End Using
            End Using
        Catch ex As Exception
            LblTotalObat.Text = "N/A"
            LblTotalTransaksi.Text = "N/A"
            LblTotalUser.Text = "N/A"
            MessageBox.Show($"Gagal memuat total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadTransactions(Optional sql As String = "", Optional params As MySqlParameter() = Nothing)
        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()
                Dim query As String = sql
                If String.IsNullOrWhiteSpace(query) Then
                    ' Use LIMIT for MySQL instead of TOP
                    query = $"SELECT t.* FROM {TableTransaksi} t ORDER BY {ColTransaksiTanggal} DESC LIMIT 100"
                End If

                Using cmd As New MySqlCommand(query, cn)
                    If params IsNot Nothing Then
                        cmd.Parameters.AddRange(params)
                    End If
                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        DgvRiwayatTransaksi.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Gagal memuat riwayat transaksi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                sql = $"SELECT t.* FROM {TableTransaksi} t WHERE t.{ColTransaksiKasir} LIKE @kw ORDER BY {ColTransaksiTanggal} DESC"
                prm = New MySqlParameter() {New MySqlParameter("@kw", MySqlDbType.VarChar) With {.Value = $"%{keyword}%"}}
            Case "Jenis Obat"
                ' Assume Transaksi has column JenisObat or join with Obat table
                sql = $"SELECT t.* FROM {TableTransaksi} t WHERE t.{ColObatJenis} LIKE @kw OR EXISTS (SELECT 1 FROM {TableObat} o WHERE o.{ColTransaksiIdObat} = t.{ColTransaksiIdObat} AND o.{ColObatJenis} LIKE @kw) ORDER BY {ColTransaksiTanggal} DESC"
                prm = New MySqlParameter() {New MySqlParameter("@kw", MySqlDbType.VarChar) With {.Value = $"%{keyword}%"}}
            Case "Nama Obat"
                sql = $"SELECT t.* FROM {TableTransaksi} t WHERE t.{ColObatNama} LIKE @kw OR EXISTS (SELECT 1 FROM {TableObat} o WHERE o.{ColTransaksiIdObat} = t.{ColTransaksiIdObat} AND o.{ColObatNama} LIKE @kw) ORDER BY {ColTransaksiTanggal} DESC"
                prm = New MySqlParameter() {New MySqlParameter("@kw", MySqlDbType.VarChar) With {.Value = $"%{keyword}%"}}
            Case "ID Obat"
                sql = $"SELECT t.* FROM {TableTransaksi} t WHERE t.{ColTransaksiIdObat} = @kw ORDER BY {ColTransaksiTanggal} DESC"
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
            ' Adjust form class name if different
            Dim f As New Kelola_Stok()
            f.ShowDialog()
            LoadTotals()
            LoadTransactions()
        Catch ex As Exception
            MessageBox.Show($"Gagal membuka form Kelola Stok: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnKelolaUser_Click(sender As Object, e As EventArgs) Handles BtnKelolaUser.Click
        Try
            ' Adjust form class name if different
            Dim f As New Kelola_User()
            f.ShowDialog()
            LoadTotals()
            LoadTransactions()
        Catch ex As Exception
            MessageBox.Show($"Gagal membuka form Kelola User: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Try
            ' Adjust login form class name if different
            Dim f As New Login()
            f.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Gagal logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class