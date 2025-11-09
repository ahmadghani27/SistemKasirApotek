' Impor library MySQL dan System.Data
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Riwayat_Transaksi

    Private Sub Riwayat_Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur format kolom
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

        ' --- MODIFIKASI ---
        ' Panggil LoadRiwayat() tanpa parameter untuk menampilkan semua transaksi
        LoadRiwayat()
        ' --- AKHIR MODIFIKASI ---
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        ' Panggil fungsi untuk memuat riwayat berdasarkan tanggal yang dipilih
        LoadRiwayat(DtpFilter.Value)
    End Sub

    ' --- FUNGSI BARU ---
    ''' <summary>
    ''' Membersihkan semua filter dan menampilkan semua riwayat
    ''' </summary>
    Private Sub BtnClearFilter_Click(sender As Object, e As EventArgs) Handles BtnClearFilter.Click
        DtpFilter.Value = Date.Today
        TxtFilter.Clear()

        ' Panggil LoadRiwayat tanpa parameter untuk menampilkan semua
        LoadRiwayat()
    End Sub
    ' --- AKHIR FUNGSI BARU ---


    ''' <summary>
    ''' DIPERBARUI: Parameter selectedDate sekarang Opsional.
    ''' Jika ada, filter berdasarkan tanggal. Jika tidak (Nothing), tampilkan semua.
    ''' </summary>
    Private Sub LoadRiwayat(Optional selectedDate As Date? = Nothing)
        ' Hapus data lama
        DgvRiwayat.Rows.Clear()
        DgvDetail.Rows.Clear()
        LblTotalHarian.Text = "Rp 0"
        LblTotalBulanan.Text = "Rp 0"

        Dim totalHasil As Decimal = 0
        Dim queryHarian As String = ""
        Dim cmd As New MySqlCommand()

        ' --- MODIFIKASI QUERY HARIAN ---
        If selectedDate.HasValue Then
            ' 1. Mode Filter Harian (jika tanggal diberikan)
            queryHarian = "SELECT id_transaksi, tgl_transaksi, total_bayar FROM transaksi " &
                          "WHERE CAST(tgl_transaksi AS DATE) = @Tanggal " &
                          "ORDER BY tgl_transaksi"
            cmd.Parameters.AddWithValue("@Tanggal", selectedDate.Value.ToString("yyyy-MM-dd"))
        Else
            ' 2. Mode Tampil Semua (jika tidak ada tanggal)
            queryHarian = "SELECT id_transaksi, tgl_transaksi, total_bayar FROM transaksi " &
                          "ORDER BY tgl_transaksi DESC" ' Tampilkan yg terbaru dulu
            ' Tidak ada parameter
        End If
        ' --- AKHIR MODIFIKASI ---

        cmd.CommandText = queryHarian
        cmd.Connection = Koneksi.conn

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        Try
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat riwayat harian: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi() ' Tutup koneksi setelah query 1
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


        ' --- MODIFIKASI: KUERI BULANAN ---
        ' Tentukan tanggal mana yang akan digunakan untuk kalkulasi bulanan
        ' Jika filter tanggal aktif, gunakan bulan dari filter
        ' Jika tidak, gunakan bulan HARI INI
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
            Koneksi.TutupKoneksi() ' Tutup koneksi setelah query 2
        End Try
        ' --- AKHIR MODIFIKASI ---
    End Sub


    Private Sub DgvRiwayat_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRiwayat.SelectionChanged
        ' (Tidak ada perubahan di sini)
        If DgvRiwayat.SelectedRows.Count = 0 Then
            DgvDetail.Rows.Clear()
            Return
        End If
        Dim selectedRow As DataGridViewRow = DgvRiwayat.SelectedRows(0)
        Dim idTransaksi As String = selectedRow.Cells("ColIDTransaksi").Value.ToString()
        LoadDetailRiwayat(idTransaksi)
    End Sub

    Private Sub LoadDetailRiwayat(idTransaksi As String)
        ' (Tidak ada perubahan di sini)
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
            cmd.Parameters.AddWithValue("@IDTransaksi", idTransaksi)
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat detail riwayat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

        For Each row As DataRow In dt.Rows
            Dim namaObat As String = row.Item("nama").ToString()
            Dim harga As Decimal = CDec(row.Item("harga_satuan"))
            Dim jumlah As Integer = CInt(row.Item("jumlah_beli"))
            Dim subtotal As Decimal = CDec(row.Item("sub_total"))
            DgvDetail.Rows.Add(namaObat, harga, jumlah, subtotal)
        Next
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Close()
    End Sub

    Private Sub BtnCariObat_Click(sender As Object, e As EventArgs) Handles BtnCariObat.Click
        ' (Tidak ada perubahan di sini)
        Dim namaObat As String = TxtFilter.Text.Trim()
        If String.IsNullOrWhiteSpace(namaObat) Then
            MessageBox.Show("Masukkan nama obat yang ingin dicari.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadRiwayatByObat(namaObat)
    End Sub

    Private Sub LoadRiwayatByObat(obatName As String)
        ' (Tidak ada perubahan di sini)
        DgvRiwayat.Rows.Clear()
        DgvDetail.Rows.Clear()
        LblTotalHarian.Text = "Rp 0"
        LblTotalBulanan.Text = "Rp 0"

        Dim listIDTransaksi As New List(Of String)
        Dim query As String = ""

        ' --- TAHAP 1 ---
        query = "SELECT DISTINCT dt.id_transaksi " &
                "FROM detail_transaksi dt " &
                "JOIN obat o ON dt.id_obat = o.id_obat " &
                "WHERE o.nama LIKE @NamaObat"
        If Not Koneksi.BukaKoneksi() Then Return
        Dim cmd As New MySqlCommand(query, Koneksi.conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()
        Try
            cmd.Parameters.AddWithValue("@NamaObat", $"%{obatName}%")
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mencari ID transaksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Tidak ditemukan transaksi yang mengandung obat tersebut.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        For Each row As DataRow In dt.Rows
            listIDTransaksi.Add(row.Item("id_transaksi").ToString())
        Next

        ' --- TAHAP 2 ---
        Dim paramNames As New List(Of String)
        cmd = New MySqlCommand()
        For i As Integer = 0 To listIDTransaksi.Count - 1
            Dim paramName As String = $"@id{i}"
            paramNames.Add(paramName)
            cmd.Parameters.AddWithValue(paramName, listIDTransaksi(i))
        Next
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
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat riwayat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try

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