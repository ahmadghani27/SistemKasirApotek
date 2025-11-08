' Impor library MySQL dan System.Data
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Riwayat_Transaksi

    Private Sub Riwayat_Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur format kolom
        ' (Pastikan nama "ColTotalH" sudah benar di desainer DgvRiwayat)
        DgvRiwayat.Columns("ColTotalH").DefaultCellStyle.Format = "Rp #,##0"
        DgvRiwayat.Columns("ColTotalH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' (Pastikan nama "ColWaktu" sudah benar di desainer DgvRiwayat)
        DgvRiwayat.Columns("ColWaktu").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"

        ' Untuk Grid Detail (bawah)
        DgvDetail.Columns("ColHarga").DefaultCellStyle.Format = "Rp #,##0"
        DgvDetail.Columns("ColSubtotal").DefaultCellStyle.Format = "Rp #,##0"
        DgvDetail.Columns("ColHarga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvDetail.Columns("ColSubtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvDetail.Columns("ColJumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Panggil fungsi untuk memuat riwayat saat form dibuka
        LoadRiwayat(DtpFilter.Value)
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        ' Panggil fungsi untuk memuat riwayat berdasarkan tanggal yang dipilih
        LoadRiwayat(DtpFilter.Value)
    End Sub

    ''' <summary>
    ''' Mengambil data header transaksi dari database berdasarkan tanggal
    ''' </summary>
    Private Sub LoadRiwayat(selectedDate As Date)
        ' Hapus data lama
        DgvRiwayat.Rows.Clear()
        DgvDetail.Rows.Clear()
        LblTotalHarian.Text = "Rp 0"

        Dim totalHarian As Decimal = 0
        Dim query As String = ""

        ' --- KODE DATABASE DIMULAI ---
        query = "SELECT t.id_transaksi, t.tgl_transaksi, SUM(dt.sub_total) AS TotalTransaksi " &
                "FROM transaksi t " &
                "JOIN detail_transaksi dt ON t.id_transaksi = dt.id_transaksi " &
                "WHERE CAST(t.tgl_transaksi AS DATE) = @Tanggal " &
                "GROUP BY t.id_transaksi, t.tgl_transaksi " &
                "ORDER BY t.tgl_transaksi"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        ' --- PERUBAHAN UTAMA ---
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        Try
            cmd.Parameters.AddWithValue("@Tanggal", selectedDate.ToString("yyyy-MM-dd"))

            ' 1. Ambil semua data ke DataTable
            da.Fill(dt)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat riwayat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' 2. Tutup koneksi SEGERA setelah data diambil
            ' DataReader tidak lagi terbuka
            Koneksi.TutupKoneksi()
        End Try

        ' 3. Loop data dari DataTable (bukan DataReader)
        ' Koneksi sudah ditutup, jadi aman untuk memicu event SelectionChanged
        For Each row As DataRow In dt.Rows
            Dim id As String = row.Item("id_transaksi").ToString()
            Dim waktu As Date = CDate(row.Item("tgl_transaksi"))
            Dim total As Decimal = CDec(row.Item("TotalTransaksi"))

            ' Tambahkan ke grid
            DgvRiwayat.Rows.Add(id, waktu, total)

            totalHarian += total
        Next
        ' --- KODE DATABASE SELESAI ---

        ' Update total harian
        LblTotalHarian.Text = totalHarian.ToString("Rp #,##0")
    End Sub

    Private Sub DgvRiwayat_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRiwayat.SelectionChanged
        ' ... (Tidak ada perubahan di sini, kode Anda sudah benar) ...
        If DgvRiwayat.SelectedRows.Count = 0 Then
            DgvDetail.Rows.Clear()
            Return
        End If

        Dim selectedRow As DataGridViewRow = DgvRiwayat.SelectedRows(0)
        Dim idTransaksi As String = selectedRow.Cells("ColIDTransaksi").Value.ToString()

        LoadDetailRiwayat(idTransaksi)
    End Sub

    ''' <summary>
    ''' Mengambil data detail item dari database berdasarkan ID Transaksi
    ''' (Diperbaiki menggunakan DataTable)
    ''' </summary>
    Private Sub LoadDetailRiwayat(idTransaksi As String)
        ' Hapus data lama
        DgvDetail.Rows.Clear()

        ' --- KODE DATABASE DIMULAI ---
        Dim query As String = "SELECT o.nama, dt.harga_satuan, dt.jumlah_beli, dt.sub_total " &
                              "FROM detail_transaksi dt " &
                              "JOIN obat o ON dt.id_obat = o.id_obat " &
                              "WHERE dt.id_transaksi = @IDTransaksi"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        ' --- PERUBAHAN UTAMA ---
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        Try
            cmd.Parameters.AddWithValue("@IDTransaksi", idTransaksi)

            ' 1. Ambil semua data ke DataTable
            da.Fill(dt)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat detail riwayat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' 2. Tutup koneksi SEGERA
            Koneksi.TutupKoneksi()
        End Try

        ' 3. Loop data dari DataTable
        For Each row As DataRow In dt.Rows
            Dim namaObat As String = row.Item("nama").ToString()
            Dim harga As Decimal = CDec(row.Item("harga_satuan"))
            Dim jumlah As Integer = CInt(row.Item("jumlah_beli"))
            Dim subtotal As Decimal = CDec(row.Item("sub_total"))

            ' Tambahkan ke grid detail
            DgvDetail.Rows.Add(namaObat, harga, jumlah, subtotal)
        Next
        ' --- KODE DATABASE SELESAI ---
    End Sub
    ''' <summary>
    ''' Mengambil data detail item dari database berdasarkan ID Transaksi
    ''' </summary>


    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.Close()
    End Sub

End Class