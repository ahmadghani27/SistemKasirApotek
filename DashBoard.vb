Option Strict On
Option Explicit On

Imports System.Data
Imports MySql.Data.MySqlClient

Public Class DashBoard

    ' --- Konstanta yang Diperlukan ---
    Private Const TableTransaksi As String = "transaksi"
    Private Const TableObat As String = "obat"
    Private Const ColTransaksiTanggal As String = "tgl_transaksi"

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- Atur format DGV ---
        Try
            DgvRiwayatTransaksi.Columns("ColTotalbayar").DefaultCellStyle.Format = "Rp #,##0"
            DgvRiwayatTransaksi.Columns("ColTotalbayar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgvRiwayatTransaksi.Columns("ColTglTransaksi").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            DgvRiwayatTransaksi.Columns("ColTglTransaksi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MessageBox.Show("Nama kolom di DGV designer (ColTotalbayar/ColTglTransaksi) mungkin salah." & vbCrLf & ex.Message, "Error Desain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Muat data awal
        LoadTotals()
        LoadTransactions()
    End Sub

    ''' <summary>
    ''' DIPERBARUI: Menambahkan kalkulasi bulanan
    ''' </summary>
    Private Sub LoadTotals()
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Gagal terhubung ke DB saat memuat total.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' 1. Total Obat (Total obat terdaftar)
            Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableObat}", Koneksi.conn)
                Dim totalObat = Convert.ToInt32(cmd.ExecuteScalar())
                LblTotalObat.Text = totalObat.ToString("N0")
            End Using

            ' 2. Total Transaksi hari ini
            Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableTransaksi} WHERE DATE({ColTransaksiTanggal}) = CURDATE()", Koneksi.conn)
                Dim totalToday = Convert.ToInt32(cmd.ExecuteScalar())
                LblTotalTransaksi.Text = totalToday.ToString("N0")
            End Using

            ' 3. Total Pendapatan hari ini
            Using cmd As New MySqlCommand($"SELECT SUM(total_bayar) FROM {TableTransaksi} WHERE DATE({ColTransaksiTanggal}) = CURDATE()", Koneksi.conn)
                Dim totalRevenue As Object = cmd.ExecuteScalar()
                Dim totalPendapatan As Decimal = 0
                If totalRevenue IsNot DBNull.Value AndAlso totalRevenue IsNot Nothing Then
                    totalPendapatan = Convert.ToDecimal(totalRevenue)
                End If
                LblTotalPendapatan.Text = totalPendapatan.ToString("Rp #,##0")
            End Using

            ' --- TAMBAHAN BARU: STATISTIK BULANAN ---

            ' 4. Total Transaksi Bulan Ini
            ' (Query MySQL: Cek Bulan DAN Tahun saat ini)
            Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {TableTransaksi} WHERE MONTH({ColTransaksiTanggal}) = MONTH(CURDATE()) AND YEAR({ColTransaksiTanggal}) = YEAR(CURDATE())", Koneksi.conn)
                Dim totalMonthCount = Convert.ToInt32(cmd.ExecuteScalar())
                LblTotalTransaksiBulan.Text = totalMonthCount.ToString("N0")
            End Using

            ' 5. Total Pendapatan Bulan Ini
            Using cmd As New MySqlCommand($"SELECT SUM(total_bayar) FROM {TableTransaksi} WHERE MONTH({ColTransaksiTanggal}) = MONTH(CURDATE()) AND YEAR({ColTransaksiTanggal}) = YEAR(CURDATE())", Koneksi.conn)
                Dim totalMonthRevenue As Object = cmd.ExecuteScalar()
                Dim totalPendapatanBulan As Decimal = 0
                If totalMonthRevenue IsNot DBNull.Value AndAlso totalMonthRevenue IsNot Nothing Then
                    totalPendapatanBulan = Convert.ToDecimal(totalMonthRevenue)
                End If
                LblTotalPendapatanBulan.Text = totalPendapatanBulan.ToString("Rp #,##0")
            End Using
            ' --- AKHIR TAMBAHAN ---

        Catch ex As Exception
            LblTotalObat.Text = "N/A"
            LblTotalTransaksi.Text = "N/A"
            LblTotalPendapatan.Text = "N/A"
            ' Tambahkan label baru ke error handler
            LblTotalTransaksiBulan.Text = "N/A"
            LblTotalPendapatanBulan.Text = "N/A"
            MessageBox.Show($"Gagal memuat total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    ''' <summary>
    ''' Menggunakan Rows.Add() manual, bukan DataSource
    ''' </summary>
    Private Sub LoadTransactions()
        DgvRiwayatTransaksi.Rows.Clear()

        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Gagal terhubung ke DB saat memuat riwayat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim query As String = $"SELECT id_transaksi, total_bayar, {ColTransaksiTanggal} FROM {TableTransaksi} " &
                              $"ORDER BY {ColTransaksiTanggal} DESC LIMIT 10"

        Dim da As New MySqlDataAdapter(query, Koneksi.conn)
        Dim dt As New DataTable()

        Try
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show($"Gagal memuat riwayat transaksi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        Try
            For Each row As DataRow In dt.Rows
                Dim id As String = row.Item("id_transaksi").ToString()
                Dim total As Decimal = CDec(row.Item("total_bayar"))
                Dim tgl As Date = CDate(row.Item(ColTransaksiTanggal))

                Dim n As Integer = DgvRiwayatTransaksi.Rows.Add()
                DgvRiwayatTransaksi.Rows(n).Cells("ColIDTransaksi").Value = id
                DgvRiwayatTransaksi.Rows(n).Cells("ColTotalbayar").Value = total
                DgvRiwayatTransaksi.Rows(n).Cells("ColTglTransaksi").Value = tgl
            Next
        Catch ex As Exception
            MessageBox.Show("Nama kolom di DGV designer (ColIDTransaksi/ColTotalbayar/ColTglTransaksi) mungkin salah." & vbCrLf & ex.Message, "Error Desain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- Tombol Navigasi ---

    Private Sub BtnKelolaStok_Click(sender As Object, e As EventArgs) Handles BtnKelolaStok.Click
        Try
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
            Dim f As New Kelola_User
            f.ShowDialog()
            LoadTotals()
            LoadTransactions()
        Catch ex As Exception
            MessageBox.Show($"Gagal membuka form Kelola User: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnDetailRiwayat.Click
        Try
            Dim f As New Riwayat_Transaksi()
            f.ShowDialog()
            LoadTotals()
            LoadTransactions()
        Catch ex As Exception
            MessageBox.Show($"Gagal membuka form Riwayat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Try
            Dim f As New Login()
            f.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Gagal logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- Event Handler Kosong (biarkan saja) ---
    Private Sub LblCaptionUser_Click(sender As Object, e As EventArgs) Handles LblCaptionUser.Click
    End Sub
    Private Sub PanelCardTransaksi_Paint(sender As Object, e As PaintEventArgs) Handles PanelCardTransaksi.Paint
    End Sub
End Class