Public Class Lihat_Stok

    Private Sub Lihat_Stok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur format kolom agar angka terlihat rapi
        ' Kolom Stok (rata tengah)
        DgvStokObat.Columns("ColStok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' Kolom Harga (rata kanan, format mata uang)
        DgvStokObat.Columns("ColHarga").DefaultCellStyle.Format = "Rp #,##0"
        DgvStokObat.Columns("ColHarga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' Panggil fungsi untuk memuat data stok
        LoadStok()
    End Sub

    Private Sub LoadStok()
        ' Hapus data lama
        DgvStokObat.Rows.Clear()

        ' --- TODO: GANTI BAGIAN INI DENGAN KODE DATABASE ANDA ---
        ' Lakukan query ke database untuk mengambil semua data obat
        ' CONTOH: "SELECT Kode_Obat, Nama_Obat, Kategori, Stok, Harga_Jual FROM Obat"

        ' Ini adalah data dummy (contoh)
        DgvStokObat.Rows.Add("P001", "Paracetamol 500mg", "Obat Bebas", 100, 5000)
        DgvStokObat.Rows.Add("A001", "Amoxicillin 250mg", "Obat Keras", 50, 15000)
        DgvStokObat.Rows.Add("V001", "Vitamin C IPI", "Vitamin", 200, 8000)
        DgvStokObat.Rows.Add("B001", "Obat Batuk Hitam", "Obat Bebas", 75, 20000)
        ' --- AKHIR BAGIAN DATABASE ---
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.Close()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ' Kosongkan kotak pencarian
        TxtCariObat.Clear()
        ' Muat ulang semua data
        LoadStok()
    End Sub

    Private Sub TxtCariObat_TextChanged(sender As Object, e As EventArgs) Handles TxtCariObat.TextChanged
        ' Fungsi LIVE SEARCH
        ' Ambil teks pencarian dan ubah ke huruf kecil agar tidak sensitif (case-insensitive)
        Dim filterTeks As String = TxtCariObat.Text.ToLower()

        ' Loop melalui setiap baris di DataGridView
        For Each row As DataGridViewRow In DgvStokObat.Rows
            ' Lewati baris baru (jika ada)
            If row.IsNewRow Then Continue For

            ' Ambil nilai dari kolom Nama Obat dan Kode Obat
            Dim namaObat As String = If(row.Cells("ColNamaObat").Value IsNot Nothing, row.Cells("ColNamaObat").Value.ToString().ToLower(), "")
            Dim kodeObat As String = If(row.Cells("ColKodeObat").Value IsNot Nothing, row.Cells("ColKodeObat").Value.ToString().ToLower(), "")

            ' Periksa apakah nama ATAU kode mengandung teks filter
            If namaObat.Contains(filterTeks) OrElse kodeObat.Contains(filterTeks) Then
                ' Jika cocok, tampilkan barisnya
                row.Visible = True
            Else
                ' Jika tidak cocok, sembunyikan barisnya
                row.Visible = False
            End If
        Next
    End Sub

End Class