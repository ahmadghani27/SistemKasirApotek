Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Riwayat_Transaksi

    Private Sub Riwayat_Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur format kolom transaksi (atas)
        DgvRiwayat.Columns("ColTotalH").DefaultCellStyle.Format = "Rp #,##0"
        DgvRiwayat.Columns("ColTotalH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvRiwayat.Columns("ColWaktu").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"

        ' Untuk Grid Detail (bawah)
        DgvDetail.Columns("ColHarga").DefaultCellStyle.Format = "Rp #,##0"
        DgvDetail.Columns("ColSubtotal").DefaultCellStyle.Format = "Rp #,##0"
        DgvDetail.Columns("ColHarga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvDetail.Columns("ColSubtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvDetail.Columns("ColJumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        LblTotalBulanan.Text = "Rp 0"

        LoadRiwayat()
    End Sub

    'tombol cari berdasarkan tanggal
    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        LoadRiwayat(DtpFilter.Value)
    End Sub

    'tombol bersihkan filter dan assign ke hari ini
    Private Sub BtnClearFilter_Click(sender As Object, e As EventArgs) Handles BtnClearFilter.Click
        DtpFilter.Value = Date.Today
        TxtFilter.Clear()

        LoadRiwayat()
    End Sub

    'fungsi load riwayat transaksi
    Private Sub LoadRiwayat(Optional selectedDate As Date? = Nothing)
        ' Hapus data lama yang ditampilkan
        DgvRiwayat.Rows.Clear()
        DgvDetail.Rows.Clear()
        LblTotalHarian.Text = "Rp 0"
        LblTotalBulanan.Text = "Rp 0"

        Dim totalHasil As Decimal = 0
        Dim queryHarian As String = ""
        Dim cmd As New MySqlCommand()

        If selectedDate.HasValue Then
            ' menampilkan pendapatan harian sesuai tanggal yang dipilih
            queryHarian = "SELECT id_transaksi, tgl_transaksi, total_bayar FROM transaksi " &
                          "WHERE CAST(tgl_transaksi AS DATE) = @Tanggal " &
                          "ORDER BY tgl_transaksi"
            cmd.Parameters.AddWithValue("@Tanggal", selectedDate.Value.ToString("yyyy-MM-dd"))
        Else
            ' jika tidak ada filter tanggal, tampilkan semua riwayat
            queryHarian = "SELECT id_transaksi, tgl_transaksi, total_bayar FROM transaksi " &
                          "ORDER BY tgl_transaksi DESC" ' Tampilkan yg terbaru dulu
        End If

        cmd.CommandText = queryHarian
        cmd.Connection = Koneksi.conn

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        Try
            ' Isi parameter jika ada filter tanggal
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat riwayat harian: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        ' Loop data harian/semua
        For Each row As DataRow In dt.Rows
            Dim id As String = row.Item("id_transaksi").ToString()
            Dim waktu As Date = CDate(row.Item("tgl_transaksi"))
            Dim total As Decimal = CDec(row.Item("total_bayar"))

            DgvRiwayat.Rows.Add(id, waktu, total)
            totalHasil += total
        Next

        ' Label "Total Harian" sekarang menampilkan total dari hasil yg tampil di grid
        LblTotalHarian.Text = totalHasil.ToString("Rp #,##0")


        ' Menghitung total bulanan
        Dim dateForMonthlyCalc As Date = If(selectedDate.HasValue, selectedDate.Value, Date.Today)

        Dim queryBulan As String = "SELECT SUM(total_bayar) FROM transaksi " &
                                 "WHERE MONTH(tgl_transaksi) = @Bulan AND YEAR(tgl_transaksi) = @Tahun"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database untuk total bulanan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim cmdBulan As New MySqlCommand(queryBulan, Koneksi.conn)
        Dim totalBulanan As Decimal = 0

        Try
            cmdBulan.Parameters.AddWithValue("@Bulan", dateForMonthlyCalc.Month)
            cmdBulan.Parameters.AddWithValue("@Tahun", dateForMonthlyCalc.Year)

            Dim result As Object = cmdBulan.ExecuteScalar()

            If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                totalBulanan = Convert.ToDecimal(result)
            End If

            LblTotalBulanan.Text = totalBulanan.ToString("Rp #,##0")

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat total bulanan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LblTotalBulanan.Text = "N/A"
        Finally
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    ' memilih baris di dgv riwayat untuk menampilkan obat dibeli
    Private Sub DgvRiwayat_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRiwayat.SelectionChanged
        If DgvRiwayat.SelectedRows.Count = 0 Then
            DgvDetail.Rows.Clear()
            Return
        End If
        Dim selectedRow As DataGridViewRow = DgvRiwayat.SelectedRows(0)
        Dim idTransaksi As String = selectedRow.Cells("ColIDTransaksi").Value.ToString()
        LoadDetailRiwayat(idTransaksi)
    End Sub

    ' fungsi load detail riwayat berdasarkan id transaksi
    Private Sub LoadDetailRiwayat(idTransaksi As String)
        DgvDetail.Rows.Clear()
        Dim query As String = "SELECT o.nama, dt.harga_satuan, dt.jumlah_beli, dt.sub_total " &
                              "FROM detail_transaksi dt " &
                              "JOIN obat o ON dt.id_obat = o.id_obat " &
                              "WHERE dt.id_transaksi = @IDTransaksi"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        Try
            ' Isi parameter ID transaksi
            cmd.Parameters.AddWithValue("@IDTransaksi", idTransaksi)
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat detail riwayat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        ' Loop data detail transaksi
        For Each row As DataRow In dt.Rows
            Dim namaObat As String = row.Item("nama").ToString()
            Dim harga As Decimal = CDec(row.Item("harga_satuan"))
            Dim jumlah As Integer = CInt(row.Item("jumlah_beli"))
            Dim subtotal As Decimal = CDec(row.Item("sub_total"))
            DgvDetail.Rows.Add(namaObat, harga, jumlah, subtotal)
        Next
    End Sub

    ' Kembali ke form sebelumnya
    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Close()
    End Sub

    'tombol cari berdasarkan nama obat
    Private Sub BtnCariObat_Click(sender As Object, e As EventArgs) Handles BtnCariObat.Click
        ' Validasi input kosong
        Dim namaObat As String = TxtFilter.Text.Trim()
        If String.IsNullOrWhiteSpace(namaObat) Then
            MessageBox.Show("Masukkan nama obat yang ingin dicari.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadRiwayatByObat(namaObat)
    End Sub

    'fungsi load riwayat berdasarkan nama obat
    Private Sub LoadRiwayatByObat(obatName As String)
        DgvRiwayat.Rows.Clear()
        DgvDetail.Rows.Clear()
        LblTotalHarian.Text = "Rp 0"
        LblTotalBulanan.Text = "Rp 0"

        Dim listIDTransaksi As New List(Of String)
        Dim query As String = ""

        query = "SELECT DISTINCT dt.id_transaksi " &
                "FROM detail_transaksi dt " &
                "JOIN obat o ON dt.id_obat = o.id_obat " &
                "WHERE o.nama LIKE @NamaObat"
        If Not Koneksi.BukaKoneksi() Then Return
        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()
        Try
            ' Isi parameter nama obat
            cmd.Parameters.AddWithValue("@NamaObat", $"%{obatName}%")
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mencari ID transaksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try
        ' Jika tidak ada transaksi ditemukan
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Tidak ditemukan transaksi yang mengandung obat tersebut.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Loop untuk mengumpulkan ID transaksi
        For Each row As DataRow In dt.Rows
            listIDTransaksi.Add(row.Item("id_transaksi").ToString())
        Next

        Dim paramNames As New List(Of String)
        cmd = New MySqlCommand()
        ' Buat parameter dinamis untuk IN clause
        For i As Integer = 0 To listIDTransaksi.Count - 1
            Dim paramName As String = $"@id{i}"
            paramNames.Add(paramName)
            cmd.Parameters.AddWithValue(paramName, listIDTransaksi(i))
        Next

        ' Susun query untuk mengambil detail transaksi berdasarkan ID yang ditemukan
        Dim inClause As String = String.Join(",", paramNames)
        query = $"SELECT id_transaksi, tgl_transaksi, total_bayar " &
                $"FROM transaksi " &
                $"WHERE id_transaksi IN ({inClause}) " &
                $"ORDER BY tgl_transaksi DESC"
        If Not Koneksi.BukaKoneksi() Then Return
        cmd.Connection = Koneksi.conn
        cmd.CommandText = query
        da = New MySqlDataAdapter(cmd)
        dt = New DataTable()
        Dim totalDitemukan As Decimal = 0
        Try
            ' Isi parameter sudah dilakukan sebelumnya
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat riwayat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        ' Loop data transaksi yang ditemukan
        For Each row As DataRow In dt.Rows
            Dim id As String = row.Item("id_transaksi").ToString()
            Dim waktu As Date = CDate(row.Item("tgl_transaksi"))
            Dim total As Decimal = CDec(row.Item("total_bayar"))
            DgvRiwayat.Rows.Add(id, waktu, total)
            totalDitemukan += total
        Next
        LblTotalHarian.Text = totalDitemukan.ToString("Rp #,##0")
    End Sub

End Class