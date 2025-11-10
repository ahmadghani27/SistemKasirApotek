Imports MySql.Data.MySqlClient

Public Class Transaksi
    ' List objek Transaksi Form yang digunakan pada array klasik
    Private Class TransaksiItem
        Public Property IDObat As String
        Public Property NamaObat As String
        Public Property Harga As Decimal
        Public Property Jumlah As Integer
        Public Property Subtotal As Decimal
    End Class

    ' array klasik untuk menyimpan item transaksi
    Private keranjang() As TransaksiItem ' Deklarasi array dengan objek TransaksiItem
    Private jumlahItemDiKeranjang As Integer = 0
    Private Const UKURAN_AWAL_KERANJANG As Integer = 10 ' ukuran awal array

    ' variabel untuk menyimpan data obat yang dipilih dari Form Hasil Pencarian
    Private _selectedObatID As String = ""
    Private _selectedObatNama As String = ""
    Private _selectedObatHarga As Decimal = 0

    ' Variabel ini akan diisi oleh Form Login
    Public IDPenggunaLogin As Integer

    '1. Memuatkan data saat form load
    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Memberikan ukuran awal pada array klasik menggunakan ReDim
        ReDim keranjang(UKURAN_AWAL_KERANJANG - 1)
        jumlahItemDiKeranjang = 0 'Mulai dengan 0 item di keranjang

        ' Panggil Sub baru untuk mengatur DGV
        SetupDataGridView()

        ' Aktifkan input obat
        TxtIDObat.Enabled = True
        TxtNamaObat.Enabled = True
        TxtJumlah.Enabled = True

        ' Kunci input harga otomatis diisi dari tabel obat DB
        TxtHarga.ReadOnly = True

        ' Atur format label total
        UpdateTotalBayar()
        ClearInputsObat()
    End Sub

    'Mengatur format DataGridView
    Private Sub SetupDataGridView()
        DgvListTransaksi.AutoGenerateColumns = False

        ' Atur format tampilan menggunakan nama desain kolom
        colHarga.DefaultCellStyle.Format = "Rp #,##0"
        colSubtotal.DefaultCellStyle.Format = "Rp #,##0"
        colHarga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colJumlah.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    'tombol cari obat, nanti menampilkan form Hasil Pencarian
    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Dim kataKunci As String = TxtNamaObat.Text.Trim()

        Using frmCari As New FormHasilPencarian()
            ' 1. Panggil fungsi MuatData DAN simpan hasilnya (True/False)
            Dim dataDitemukan As Boolean = frmCari.MuatData(kataKunci)

            ' 2. hanya tampilkan pop-up jika data ditemukan
            If dataDitemukan Then

                ' 3. Jika data ada, baru panggil ShowDialog()
                If frmCari.ShowDialog() = DialogResult.OK Then
                    _selectedObatID = frmCari.SelectedObatID
                    _selectedObatNama = frmCari.SelectedObatNama
                    _selectedObatHarga = frmCari.SelectedObatHarga

                    TxtIDObat.Text = _selectedObatID
                    TxtNamaObat.Text = _selectedObatNama
                    TxtHarga.Text = _selectedObatHarga.ToString("N0")

                    TxtJumlah.Focus()
                End If

            Else
                ' 4. Jika data tidak ditemukan, jangan lakukan apa-apa.
                TxtNamaObat.Focus()
                TxtNamaObat.SelectAll()
            End If
        End Using
    End Sub

    'tombol tambah obat ke keranjang
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

        ' cek duplikat berdasarkan ID Obat, jika ada, update jumlah dan subtotal saja
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            If keranjang(i) IsNot Nothing AndAlso keranjang(i).IDObat = _selectedObatID Then

                ' 1. Tambahkan jumlah baru ke jumlah yang ada
                keranjang(i).Jumlah += jumlah

                ' 2. Hitung ulang subtotal berdasarkan jumlah baru
                keranjang(i).Subtotal = keranjang(i).Harga * keranjang(i).Jumlah
                RefreshGrid()
                UpdateTotalBayar()
                ClearInputsObat()

                Return
            End If
        Next

        ' Jika tidak duplikat, buat item baru
        Dim itemBaru As New TransaksiItem With {
            .IDObat = _selectedObatID,
            .NamaObat = _selectedObatNama,
            .Harga = _selectedObatHarga,
            .Jumlah = jumlah,
            .Subtotal = _selectedObatHarga * jumlah
        }

        ' Tambahkan ke Array
        If jumlahItemDiKeranjang = keranjang.Length Then
            ' Jika penuh, gandakan ukuran array.
            ReDim Preserve keranjang((keranjang.Length * 2) - 1)
        End If

        ' Tambahkan item baru ke slot berikutnya yang tersedia
        keranjang(jumlahItemDiKeranjang) = itemBaru
        jumlahItemDiKeranjang += 1

        RefreshGrid()
        UpdateTotalBayar()
        ClearInputsObat()
    End Sub

    ' tombol hapus item dari keranjang
    Private Sub BtnHapusItem_Click(sender As Object, e As EventArgs) Handles BtnHapusItem.Click
        If DgvListTransaksi.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih item di keranjang yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Dapatkan index baris yang dipilih
        Dim selectedIndex = DgvListTransaksi.SelectedRows(0).Index

        'menggerakkan item di array untuk menghapus item yang dipilih
        For i = selectedIndex To jumlahItemDiKeranjang - 2
            ' Timpa item saat ini dengan item berikutnya
            keranjang(i) = keranjang(i + 1)
        Next

        ' Kosongkan slot terakhir yang sudah digeser
        If jumlahItemDiKeranjang > 0 Then
            keranjang(jumlahItemDiKeranjang - 1) = Nothing
        End If

        ' Kurangi jumlah item
        jumlahItemDiKeranjang -= 1

        RefreshGrid()
        UpdateTotalBayar()
    End Sub

    ' tombol batal transaksi
    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        If jumlahItemDiKeranjang = 0 Then Return

        'konfirmasi pembatalan
        If MessageBox.Show("Batalkan transaksi dan kosongkan keranjang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            jumlahItemDiKeranjang = 0
            Array.Clear(keranjang, 0, keranjang.Length)

            RefreshGrid()
            UpdateTotalBayar()
            ClearInputsObat()
        End If
    End Sub

    ' tombol simpan transaksi ke database
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        ' cek kosong keranjang sebelum simpan
        If jumlahItemDiKeranjang = 0 Then
            MessageBox.Show("Keranjang belanja masih kosong.", "Gagal Simpan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' konfirmasi simpan
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
            ' membuat ID Transaksi unik
            Dim idTransaksi As String = "Apt" & DateTime.Now.ToString("yyyyMMddHHmm")

            ' menghiutng total bayar dari array klasik
            Dim totalBayar As Decimal = 0
            For i As Integer = 0 To jumlahItemDiKeranjang - 1
                totalBayar += keranjang(i).Subtotal
            Next

            ' Simpan ke Tabel Master `transaksi`
            cmd.CommandText = "INSERT INTO transaksi (id_transaksi, id_pengguna, total_bayar, tgl_transaksi) VALUES (@id, @idPengguna, @total, NOW())"
            cmd.Parameters.AddWithValue("@id", idTransaksi)
            cmd.Parameters.AddWithValue("@idPengguna", IDPenggunaLogin)
            cmd.Parameters.AddWithValue("@total", totalBayar)
            cmd.ExecuteNonQuery()

            ' loop utnuk simpan detail transaksi dan update stok
            For i As Integer = 0 To jumlahItemDiKeranjang - 1
                Dim item As TransaksiItem = keranjang(i)

                ' Simpan ke detail_transaksi
                cmd.Parameters.Clear()
                cmd.CommandText = "INSERT INTO detail_transaksi (id_transaksi, id_obat, jumlah_beli, harga_satuan, sub_total) VALUES (@idTrx, @idObat, @jml, @harga, @sub)"
                cmd.Parameters.AddWithValue("@idTrx", idTransaksi)
                cmd.Parameters.AddWithValue("@idObat", item.IDObat)
                cmd.Parameters.AddWithValue("@jml", item.Jumlah)
                cmd.Parameters.AddWithValue("@harga", item.Harga)
                cmd.Parameters.AddWithValue("@sub", item.Subtotal)
                cmd.ExecuteNonQuery()

                ' Kurangi stok
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE obat SET stock = stock - @jmlBeli WHERE id_obat = @idObat"
                cmd.Parameters.AddWithValue("@jmlBeli", item.Jumlah)
                cmd.Parameters.AddWithValue("@idObat", item.IDObat)
                cmd.ExecuteNonQuery()
            Next

            ' Commit transaksi
            dbTransaction.Commit()

            MessageBox.Show($"Transaksi {idTransaksi} berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'bereskan keranjang setelah simpan
            jumlahItemDiKeranjang = 0
            Array.Clear(keranjang, 0, keranjang.Length)

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

    'tombol keluar dari form transaksi
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        ' cek apakah masih ada item di keranjang
        If jumlahItemDiKeranjang > 0 Then
            If MessageBox.Show("Ada item di keranjang. Yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Return
            End If
        End If
        Close()
    End Sub

    ' mengambil nilai angka decimal dari string dengan aman
    Private Function ParseDecimalSafe(text As String, ByRef value As Decimal) As Boolean
        If String.IsNullOrWhiteSpace(text) Then
            value = 0D
            Return False
        End If
        Dim cleaned = text.Replace("Rp", "").Trim().Replace(".", "").Replace(",", ".")
        Return Decimal.TryParse(cleaned, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, value)
    End Function

    ' Memperbarui DGV 
    Private Sub RefreshGrid()
        ' Kosongkan semua baris yang ada di DGV
        DgvListTransaksi.Rows.Clear()

        ' Loop Array keranjang Anda
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            Dim item As TransaksiItem = keranjang(i)

            ' Tambahkan satu per satu baris ke DGV
            DgvListTransaksi.Rows.Add(
                item.IDObat,
                item.NamaObat,
                item.Harga,
                item.Jumlah,
                item.Subtotal
            )
        Next
    End Sub

    ' Memperbarui Total dari Array Klasik
    Private Sub UpdateTotalBayar()
        ' hitung total bayar dari array keranjang
        Dim total As Decimal = 0
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            total += keranjang(i).Subtotal
        Next
        LblTotalBayar.Text = "Rp " & total.ToString("N0")
    End Sub

    Private Sub ClearInputsObat()
        TxtIDObat.Clear()
        TxtNamaObat.Clear()
        TxtHarga.Clear()
        TxtJumlah.Clear()
        _selectedObatID = ""
        _selectedObatNama = ""
        _selectedObatHarga = 0
        TxtIDObat.Focus() ' Fokus ke pencarian
    End Sub

    'tombol riwayat transaksi
    Private Sub BtnRiwayat_Click(sender As Object, e As EventArgs) Handles BtnRiwayat.Click
        Dim frmRiwayat As New Riwayat_Transaksi()
        ' Menampilkan form riwayat
        frmRiwayat.Show()
    End Sub

    'tombol lihat stok obat
    Private Sub BtnLihatStok_Click(sender As Object, e As EventArgs) Handles BtnLihatStok.Click
        Dim frmStok As New Lihat_Stok()
        ' Menampilkan form lihat stok
        frmStok.Show()
    End Sub
End Class