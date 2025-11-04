Public Class Lihat_Stok

    Private Sub Lihat_Stok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur format kolom agar angka terlihat rapi
        ' Kolom Stok (rata tengah)
        DgvStokObat.Columns("ColStok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' --- TAMBAHAN ---
        ' Kolom Kadaluarsa (rata tengah, format tanggal)
        DgvStokObat.Columns("ColKadaluarsa").DefaultCellStyle.Format = "dd MMM yyyy"
        DgvStokObat.Columns("ColKadaluarsa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' --- AKHIR TAMBAHAN ---

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
        ' CONTOH: "SELECT Kode_Obat, Nama_Obat, Kategori, Stok, Tgl_Kadaluarsa, Harga_Jual FROM Obat"

        ' Ini adalah data dummy (contoh)
        ' Saya tambahkan tanggal kadaluarsa (sebagai object Date)
        DgvStokObat.Rows.Add("P001", "Paracetamol 500mg", "Obat Bebas", 100, New Date(2026, 12, 31), 5000)
        DgvStokObat.Rows.Add("A001", "Amoxicillin 250mg", "Obat Keras", 50, New Date(2025, 11, 30), 15000) ' <-- SEGERA HABIS (KUNING)
        DgvStokObat.Rows.Add("V001", "Vitamin C IPI", "Vitamin", 200, New Date(2025, 10, 1), 8000)     ' <-- SUDAH HABIS (MERAH)
        DgvStokObat.Rows.Add("B001", "Obat Batuk Hitam", "Obat Bebas", 75, New Date(2027, 5, 1), 20000)
        ' --- AKHIR BAGIAN DATABASE ---

        ' --- TAMBAHAN ---
        ' Panggil fungsi untuk memberi warna pada baris
        HighlightKadaluarsa()
        ' --- AKHIR TAMBAHAN ---
    End Sub

    ' --- FUNGSI BARU UNTUK MEMBERI WARNA ---
    Private Sub HighlightKadaluarsa()
        Dim hariIni As Date = Date.Today
        Dim batasWajar As Integer = 30 ' Peringatan kuning jika sisa 30 hari

        For Each row As DataGridViewRow In DgvStokObat.Rows
            If row.IsNewRow Then Continue For

            ' Ambil tanggal dari sel (pastikan tidak null)
            If row.Cells("ColKadaluarsa").Value IsNot Nothing Then
                Dim tglKadaluarsa As Date = CDate(row.Cells("ColKadaluarsa").Value)

                ' Atur warna default dulu (menghilangkan warna lama saat refresh)
                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Black

                ' Cek kondisi
                If tglKadaluarsa < hariIni Then
                    ' SUDAH KADALUARSA
                    row.DefaultCellStyle.BackColor = Color.LightCoral
                    row.DefaultCellStyle.ForeColor = Color.DarkRed
                ElseIf tglKadaluarsa < hariIni.AddDays(batasWajar) Then
                    ' SEGERA KADALUARSA
                    row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                End If
            End If
        Next
    End Sub
    ' --- AKHIR FUNGSI BARU ---

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
        Dim filterTeks As String = TxtCariObat.Text.ToLower()

        ' Simpan CurrencyManager untuk menghindari error saat baris disembunyikan
        Dim cm As CurrencyManager = CType(BindingContext(DgvStokObat.DataSource), CurrencyManager)
        If cm IsNot Nothing Then cm.SuspendBinding()

        For Each row As DataGridViewRow In DgvStokObat.Rows
            If row.IsNewRow Then Continue For

            Dim namaObat As String = If(row.Cells("ColNamaObat").Value IsNot Nothing, row.Cells("ColNamaObat").Value.ToString().ToLower(), "")
            Dim kodeObat As String = If(row.Cells("ColKodeObat").Value IsNot Nothing, row.Cells("ColKodeObat").Value.ToString().ToLower(), "")

            If namaObat.Contains(filterTeks) OrElse kodeObat.Contains(filterTeks) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next

        If cm IsNot Nothing Then cm.ResumeBinding()
    End Sub

End Class