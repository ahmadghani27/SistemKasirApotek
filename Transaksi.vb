' Impor library MySQL yang diperlukan
Imports MySql.Data.MySqlClient

Public Class Transaksi

    ' --- 1. CETAKAN DATA (Structure) ---
    ' Ini adalah "cetakan" untuk setiap item di keranjang
    Private Class TransaksiItem
        Public Property IDObat As String
        Public Property NamaObat As String
        Public Property Harga As Decimal
        Public Property Jumlah As Integer
        Public Property Subtotal As Decimal
    End Class

    ' --- 2. "ARRAY" KLASIK (UBAHAN) ---
    ' Ini adalah "keranjang belanja", menggunakan array
    Private keranjang() As TransaksiItem ' Deklarasi array
    Private jumlahItemDiKeranjang As Integer = 0 ' Pelacak jumlah item
    Private Const UKURAN_AWAL_KERANJANG As Integer = 10 ' Kapasitas awal

    ' --- 3. VARIABEL BANTU ---
    ' Untuk menyimpan ID dan Nama dari hasil pencarian
    Private _selectedObatID As String = ""
    Private _selectedObatNama As String = ""
    Private _selectedObatHarga As Decimal = 0

    ' Variabel ini akan diisi oleh Form Login
    Public IDPenggunaLogin As Integer

    ' --- 4. FORM LOAD (DIPERBAIKI + UBAHAN) ---
    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- UBAHAN: Inisialisasi Array Klasik ---
        ' Kita harus memberi ukuran awal pada array kita
        ReDim keranjang(UKURAN_AWAL_KERANJANG - 1)
        jumlahItemDiKeranjang = 0
        ' --- AKHIR UBAHAN ---

        ' Panggil Sub baru untuk mengatur DGV
        SetupDataGridView()

        ' Aktifkan input obat
        TxtIDObat.Enabled = True
        TxtNamaObat.Enabled = True
        TxtJumlah.Enabled = True

        ' Kunci input harga (HARUS dari DB)
        TxtHarga.ReadOnly = True

        ' Atur format label total
        UpdateTotalBayar()
        ' Bersihkan input obat
        ClearInputsObat()
    End Sub

    ' --- 5. SETUP DATAGRIDVIEW (BARU) ---
    ' Mengatur DGV untuk Data Binding
    Private Sub SetupDataGridView()
        ' Penting: Matikan auto-generate kolom
        DgvListTransaksi.AutoGenerateColumns = False

        ' Atur format tampilan (kode Anda sebelumnya, sudah bagus)
        colHarga.DefaultCellStyle.Format = "Rp #,##0"
        colSubtotal.DefaultCellStyle.Format = "Rp #,##0"
        colHarga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colJumlah.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' --- 6. ALUR PENCARIAN (BARU) ---
    ' Ini adalah logika untuk tombol 'Cari'
    ' (Logika ini TIDAK BERUBAH karena tidak menyentuh keranjang)
    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Dim kataKunci As String = TxtNamaObat.Text.Trim()
        ' (Validasi kataKunci...)

        Using frmCari As New FormHasilPencarian()
            ' 1. Panggil fungsi MuatData DAN simpan hasilnya (True/False)
            Dim dataDitemukan As Boolean = frmCari.MuatData(kataKunci)

            ' 2. HANYA tampilkan pop-up jika data ditemukan
            If dataDitemukan Then

                ' 3. Jika data ada, baru panggil ShowDialog()
                If frmCari.ShowDialog() = DialogResult.OK Then
                    ' (Kode Anda untuk menyalin data sudah benar)
                    _selectedObatID = frmCari.SelectedObatID
                    _selectedObatNama = frmCari.SelectedObatNama
                    _selectedObatHarga = frmCari.SelectedObatHarga

                    TxtIDObat.Text = _selectedObatID
                    TxtNamaObat.Text = _selectedObatNama
                    TxtHarga.Text = _selectedObatHarga.ToString("N0")

                    TxtJumlah.Focus()
                End If

            Else
                ' 4. Jika dataTIDAKditemukan, jangan lakukan apa-apa.
                TxtNamaObat.Focus()
                TxtNamaObat.SelectAll()
            End If
        End Using
    End Sub

    ' --- 7. BTN TAMBAH (UBAHAN TOTAL) ---
    ' Menggunakan data hasil pencarian dan Array Klasik
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        ' Validasi 1: Pastikan obat sudah dipilih
        If String.IsNullOrWhiteSpace(_selectedObatID) Then
            MessageBox.Show("Cari dan pilih obat terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BtnCari.Focus()
            Return
        End If

        ' Validasi 2: Cek Jumlah
        Dim jumlah As Integer
        If Not Integer.TryParse(TxtJumlah.Text, jumlah) OrElse jumlah <= 0 Then
            MessageBox.Show("Masukkan jumlah yang valid (angka bulat > 0).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtJumlah.Focus()
            Return
        End If

        ' --- PERUBAHAN: Cek duplikat dan UPDATE ---
        ' Loop melalui keranjang untuk mencari item yang sama
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            If keranjang(i) IsNot Nothing AndAlso keranjang(i).IDObat = _selectedObatID Then

                ' DUPLIKAT DITEMUKAN! Lakukan update, bukan blokir.

                ' 1. Tambahkan jumlah baru ke jumlah yang ada
                keranjang(i).Jumlah += jumlah

                ' 2. Hitung ulang subtotal berdasarkan jumlah baru
                keranjang(i).Subtotal = keranjang(i).Harga * keranjang(i).Jumlah

                ' 3. Segarkan Grid, Total, dan bersihkan input
                RefreshGrid()
                UpdateTotalBayar()
                ClearInputsObat()

                ' 4. Selesai. Keluar dari Sub agar tidak menambah item baru.
                Return
            End If
        Next
        ' --- AKHIR PERUBAHAN ---

        ' Jika kode sampai di sini, berarti BUKAN duplikat.
        ' Lanjutkan logika untuk menambah item baru ke array.

        ' Buat item baru
        Dim itemBaru As New TransaksiItem With {
            .IDObat = _selectedObatID,
            .NamaObat = _selectedObatNama,
            .Harga = _selectedObatHarga,
            .Jumlah = jumlah, ' Jumlah baru dari textbox
            .Subtotal = _selectedObatHarga * jumlah
        }

        ' Tambahkan ke Array Klasik (Cek apakah array penuh)
        If jumlahItemDiKeranjang = keranjang.Length Then
            ' Jika penuh, gandakan ukuran array.
            ReDim Preserve keranjang((keranjang.Length * 2) - 1)
        End If

        ' Tambahkan item baru ke slot berikutnya yang tersedia
        keranjang(jumlahItemDiKeranjang) = itemBaru
        ' Tambah pelacak jumlah item
        jumlahItemDiKeranjang += 1

        ' Perbarui DGV, Total, dan bersihkan input
        RefreshGrid()
        UpdateTotalBayar()
        ClearInputsObat()
    End Sub

    ' --- 8. BTN HAPUS (UBAHAN TOTAL) ---
    ' Memperbaiki Bug Sinkronisasi
    Private Sub BtnHapusItem_Click(sender As Object, e As EventArgs) Handles BtnHapusItem.Click
        If DgvListTransaksi.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih item di keranjang yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Dapatkan index baris yang dipilih
        Dim selectedIndex = DgvListTransaksi.SelectedRows(0).Index

        ' --- UBAHAN: Hapus dari Array Klasik ---
        ' Kita harus "menggeser" semua item setelahnya ke kiri.
        For i = selectedIndex To jumlahItemDiKeranjang - 2
            ' Timpa item saat ini dengan item berikutnya
            keranjang(i) = keranjang(i + 1)
        Next

        ' Kosongkan slot terakhir (yang sekarang duplikat)
        If jumlahItemDiKeranjang > 0 Then
            keranjang(jumlahItemDiKeranjang - 1) = Nothing
        End If

        ' Kurangi pelacak jumlah item
        jumlahItemDiKeranjang -= 1
        ' --- AKHIR UBAHAN ---

        ' Perbarui DGV, Total
        RefreshGrid()
        UpdateTotalBayar()
    End Sub

    ' --- 9. BTN BATAL (UBAHAN) ---
    ' Menggunakan Array Klasik
    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        ' --- UBAHAN: Cek jumlah item manual ---
        If jumlahItemDiKeranjang = 0 Then Return
        ' --- AKHIR UBAHAN ---

        If MessageBox.Show("Batalkan transaksi dan kosongkan keranjang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' --- UBAHAN: Mengosongkan Array Klasik ---
            jumlahItemDiKeranjang = 0
            Array.Clear(keranjang, 0, keranjang.Length)
            ' --- AKHIR UBAHAN ---

            RefreshGrid()
            UpdateTotalBayar()
            ClearInputsObat()
        End If
    End Sub

    ' --- 10. BTN SIMPAN (UBAHAN TOTAL) ---
    ' Menggunakan Array Klasik dan Transaksi Database
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        ' --- UBAHAN: Cek jumlah item manual ---
        If jumlahItemDiKeranjang = 0 Then
            MessageBox.Show("Keranjang belanja masih kosong.", "Gagal Simpan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' --- AKHIR UBAHAN ---

        If MessageBox.Show("Simpan transaksi ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Koneksi ke Database Gagal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim dbTransaction As MySqlTransaction = Koneksi.conn.BeginTransaction()
        Dim cmd As New MySqlCommand()
        cmd.Connection = Koneksi.conn
        cmd.Transaction = dbTransaction

        Try
            ' 1. Hasilkan ID Transaksi SEKARANG
            Dim idTransaksi As String = "TRX-" & DateTime.Now.ToString("yyyyMMddHHmm")

            ' --- UBAHAN: Hitung Total Bayar manual ---
            Dim totalBayar As Decimal = 0
            For i As Integer = 0 To jumlahItemDiKeranjang - 1
                totalBayar += keranjang(i).Subtotal
            Next
            ' --- AKHIR UBAHAN ---

            ' 3. Simpan ke Tabel Master `transaksi`
            cmd.CommandText = "INSERT INTO transaksi (id_transaksi, id_pengguna, total_bayar, tgl_transaksi) VALUES (@id, @idPengguna, @total, NOW())"
            cmd.Parameters.AddWithValue("@id", idTransaksi)
            cmd.Parameters.AddWithValue("@idPengguna", IDPenggunaLogin)
            cmd.Parameters.AddWithValue("@total", totalBayar)
            cmd.ExecuteNonQuery()

            ' --- UBAHAN: Loop Array Klasik ---
            For i As Integer = 0 To jumlahItemDiKeranjang - 1
                Dim item As TransaksiItem = keranjang(i)

                ' 4a. Simpan ke detail_transaksi
                cmd.Parameters.Clear()
                cmd.CommandText = "INSERT INTO detail_transaksi (id_transaksi, id_obat, jumlah_beli, harga_satuan, sub_total) VALUES (@idTrx, @idObat, @jml, @harga, @sub)"
                cmd.Parameters.AddWithValue("@idTrx", idTransaksi)
                cmd.Parameters.AddWithValue("@idObat", item.IDObat)
                cmd.Parameters.AddWithValue("@jml", item.Jumlah)
                cmd.Parameters.AddWithValue("@harga", item.Harga)
                cmd.Parameters.AddWithValue("@sub", item.Subtotal)
                cmd.ExecuteNonQuery()

                ' 4b. Kurangi stok
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE obat SET stock = stock - @jmlBeli WHERE id_obat = @idObat"
                cmd.Parameters.AddWithValue("@jmlBeli", item.Jumlah)
                cmd.Parameters.AddWithValue("@idObat", item.IDObat)
                cmd.ExecuteNonQuery()
            Next
            ' --- AKHIR UBAHAN ---

            ' 5. Commit transaksi
            dbTransaction.Commit()

            MessageBox.Show($"Transaksi {idTransaksi} berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 6. Bersihkan form
            ' --- UBAHAN: Mengosongkan Array Klasik ---
            jumlahItemDiKeranjang = 0
            Array.Clear(keranjang, 0, keranjang.Length)
            ' --- AKHIR UBAHAN ---

            RefreshGrid()
            UpdateTotalBayar()
            ClearInputsObat()

        Catch ex As Exception
            dbTransaction.Rollback()
            MessageBox.Show("Terjadi kesalahan saat menyimpan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        ' --- UBAHAN: Cek jumlah item manual ---
        If jumlahItemDiKeranjang > 0 Then
            If MessageBox.Show("Ada item di keranjang. Yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Return
            End If
        End If
        ' --- AKHIR UBAHAN ---
        Close()
    End Sub

    ' --- 11. FUNGSI BANTU (UBAHAN) ---

    ' Fungsi ParseDecimalSafe (Tidak Berubah)
    Private Function ParseDecimalSafe(text As String, ByRef value As Decimal) As Boolean
        If String.IsNullOrWhiteSpace(text) Then
            value = 0D
            Return False
        End If
        Dim cleaned = text.Replace("Rp", "").Trim().Replace(".", "").Replace(",", ".")
        Return Decimal.TryParse(cleaned, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, value)
    End Function

    ' Memperbarui DGV dari Array Klasik (MODE MANUAL / UNBOUND)
    Private Sub RefreshGrid()
        ' 1. Kosongkan semua baris yang ada di DGV
        DgvListTransaksi.Rows.Clear()

        ' --- UBAHAN: Loop Array Klasik ---
        ' 2. Loop Array keranjang Anda
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            Dim item As TransaksiItem = keranjang(i)

            ' 3. Tambahkan satu per satu baris ke DGV
            DgvListTransaksi.Rows.Add(
                item.IDObat,
                item.NamaObat,
                item.Harga,
                item.Jumlah,
                item.Subtotal
            )
        Next
        ' --- AKHIR UBAHAN ---
    End Sub

    ' Memperbarui Total dari Array Klasik
    Private Sub UpdateTotalBayar()
        ' --- UBAHAN: Hitung Total Bayar manual ---
        Dim total As Decimal = 0
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            total += keranjang(i).Subtotal
        Next
        LblTotalBayar.Text = "Rp " & total.ToString("N0")
        ' --- AKHIR UBAHAN ---
    End Sub

    ' Membersihkan input obat (Tidak Berubah)
    Private Sub ClearInputsObat()
        TxtIDObat.Clear() ' TxtCariObat
        TxtNamaObat.Clear()
        TxtHarga.Clear()
        TxtJumlah.Clear()
        _selectedObatID = "" ' Reset ID
        _selectedObatNama = ""
        _selectedObatHarga = 0
        TxtIDObat.Focus() ' Fokus ke pencarian
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        ' (Kosong)
    End Sub

    Private Sub BtnRiwayat_Click(sender As Object, e As EventArgs) Handles BtnRiwayat.Click
        ' Membuat objek form riwayat
        Dim frmRiwayat As New Riwayat_Transaksi()
        ' Menampilkan form riwayat
        frmRiwayat.Show()
    End Sub

    Private Sub BtnLihatStok_Click(sender As Object, e As EventArgs) Handles BtnLihatStok.Click
        ' Membuat objek form lihat stok
        Dim frmStok As New Lihat_Stok()
        ' Menampilkan form lihat stok
        frmStok.Show()
    End Sub
End Class