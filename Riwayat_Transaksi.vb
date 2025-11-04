Public Class Riwayat_Transaksi

    Private Sub Riwayat_Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur format kolom agar angka mata uang terlihat rapi
        ' Untuk Grid Riwayat (atas)
        DgvRiwayat.Columns("ColTotal").DefaultCellStyle.Format = "Rp #,##0"
        DgvRiwayat.Columns("ColTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' Untuk Grid Detail (bawah)
        DgvDetail.Columns("ColHarga").DefaultCellStyle.Format = "Rp #,##0"
        DgvDetail.Columns("ColSubtotal").DefaultCellStyle.Format = "Rp #,##0"
        DgvDetail.Columns("ColHarga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvDetail.Columns("ColSubtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvDetail.Columns("ColJumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Panggil fungsi untuk memuat riwayat saat form dibuka
        LoadRiwayat(DateTimePicker1.Value)
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        ' Panggil fungsi untuk memuat riwayat berdasarkan tanggal yang dipilih
        LoadRiwayat(DateTimePicker1.Value)
    End Sub

    Private Sub LoadRiwayat(selectedDate As Date)
        ' Hapus data lama
        DgvRiwayat.Rows.Clear()
        DgvDetail.Rows.Clear()
        LblTotalHarian.Text = "Rp 0"

        ' --- TODO: GANTI BAGIAN INI DENGAN KODE DATABASE ANDA ---
        ' Lakukan query ke database untuk mengambil semua transaksi pada 'selectedDate'
        ' CONTOH: "SELECT ID_Transaksi, Waktu, Total, Nama_Kasir FROM Transaksi WHERE CAST(Waktu AS DATE) = @Tanggal"

        ' Ini adalah data dummy (contoh)
        Dim totalHarian As Decimal = 0

        ' Contoh Transaksi 1
        Dim id1 As String = "TRX-20251104-001"
        Dim waktu1 As String = "09:15:00"
        Dim total1 As Decimal = 65000
        Dim kasir1 As String = "Admin"
        DgvRiwayat.Rows.Add(id1, waktu1, total1, kasir1)
        totalHarian += total1

        ' Contoh Transaksi 2
        Dim id2 As String = "TRX-20251104-002"
        Dim waktu2 As String = "10:30:00"
        Dim total2 As Decimal = 20000
        Dim kasir2 As String = "Admin"
        DgvRiwayat.Rows.Add(id2, waktu2, total2, kasir2)
        totalHarian += total2
        ' --- AKHIR BAGIAN DATABASE ---

        ' Update total harian
        LblTotalHarian.Text = totalHarian.ToString("Rp #,##0")
    End Sub

    Private Sub DgvRiwayat_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRiwayat.SelectionChanged
        ' Event ini berjalan saat pengguna mengklik baris di grid riwayat (atas)

        ' Pastikan ada baris yang dipilih
        If DgvRiwayat.SelectedRows.Count = 0 Then
            DgvDetail.Rows.Clear() ' Kosongkan grid detail jika tidak ada yg dipilih
            Return
        End If

        ' Ambil ID Transaksi dari baris yang dipilih
        Dim selectedRow As DataGridViewRow = DgvRiwayat.SelectedRows(0)
        Dim idTransaksi As String = selectedRow.Cells("ColIDTransaksi").Value.ToString()

        ' Panggil fungsi untuk memuat detail item
        LoadDetailRiwayat(idTransaksi)
    End Sub

    Private Sub LoadDetailRiwayat(idTransaksi As String)
        ' Hapus data lama
        DgvDetail.Rows.Clear()

        ' --- TODO: GANTI BAGIAN INI DENGAN KODE DATABASE ANDA ---
        ' Lakukan query ke database untuk mengambil detail item berdasarkan 'idTransaksi'
        ' CONTOH: "SELECT Nama_Obat, Harga, Jumlah, Subtotal FROM Detail_Transaksi WHERE ID_Transaksi = @ID"

        ' Ini adalah data dummy (contoh)
        If idTransaksi = "TRX-20251104-001" Then
            ' Item untuk transaksi 1
            DgvDetail.Rows.Add("Paracetamol", 5000, 2, 10000)
            DgvDetail.Rows.Add("Amoxicillin", 15000, 1, 15000)
            DgvDetail.Rows.Add("Vitamin C", 40000, 1, 40000)
        ElseIf idTransaksi = "TRX-20251104-002" Then
            ' Item untuk transaksi 2
            DgvDetail.Rows.Add("Obat Batuk", 20000, 1, 20000)
        End If
        ' --- AKHIR BAGIAN DATABASE ---
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.Close()
    End Sub
End Class