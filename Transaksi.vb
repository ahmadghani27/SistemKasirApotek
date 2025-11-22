Imports MySql.Data.MySqlClient

Public Class Transaksi

    ' --- 1. DEFINISI STRUKTUR DATA ---
    Private Class TransaksiItem
        Public Property IDObat As String
        Public Property NamaObat As String
        Public Property Harga As Decimal
        Public Property Jumlah As Integer
        Public Property Subtotal As Decimal
    End Class

    ' Array klasik untuk menyimpan item transaksi
    Private keranjang() As TransaksiItem
    Private jumlahItemDiKeranjang As Integer = 0
    Private Const UKURAN_AWAL_KERANJANG As Integer = 10

    ' --- 2. VARIABEL GLOBAL ---
    Private _selectedObatID As String = ""
    Private _selectedObatNama As String = ""
    Private _selectedObatHarga As Decimal = 0

    ' [PERBAIKAN 1] Deklarasi variabel Stok
    Private _selectedObatStok As Integer = 0

    ' Variabel ini akan diisi oleh Form Login
    Public IDPenggunaLogin As Integer

    ' --- 3. FORM LOAD & SETUP ---
    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReDim keranjang(UKURAN_AWAL_KERANJANG - 1)
        jumlahItemDiKeranjang = 0
        SetupDataGridView()

        TxtIDObat.Enabled = True
        TxtNamaObat.Enabled = True
        TxtJumlah.Enabled = True
        TxtHarga.ReadOnly = True

        UpdateTotalBayar()
        ClearInputsObat()
    End Sub

    Private Sub SetupDataGridView()
        DgvListTransaksi.AutoGenerateColumns = False
        colHarga.DefaultCellStyle.Format = "Rp #,##0"
        colSubtotal.DefaultCellStyle.Format = "Rp #,##0"
        colHarga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colJumlah.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' --- 4. LOGIKA PENCARIAN (BTN CARI) ---
    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Dim kataKunci As String = TxtNamaObat.Text.Trim()

        Using frmCari As New FormHasilPencarian()
            Dim dataDitemukan As Boolean = frmCari.MuatData(kataKunci)

            If dataDitemukan Then
                If frmCari.ShowDialog() = DialogResult.OK Then
                    ' Ambil data dari Form Pencarian
                    _selectedObatID = frmCari.SelectedObatID
                    _selectedObatNama = frmCari.SelectedObatNama
                    _selectedObatHarga = frmCari.SelectedObatHarga

                    ' [PERBAIKAN 2] Pastikan FormHasilPencarian punya properti SelectedObatStok
                    ' Jika error di sini, cek kode FormHasilPencarian Anda
                    _selectedObatStok = frmCari.SelectedObatStok

                    ' Tampilkan ke Textbox
                    TxtIDObat.Text = _selectedObatID
                    TxtNamaObat.Text = _selectedObatNama
                    TxtHarga.Text = _selectedObatHarga.ToString("N0")

                    TxtJumlah.Focus()
                End If
            Else
                TxtNamaObat.Focus()
                TxtNamaObat.SelectAll()
            End If
        End Using
    End Sub

    ' --- 5. LOGIKA TAMBAH KE KERANJANG (BTN TAMBAH) ---
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        ' Validasi 1: Pastikan obat sudah dipilih
        If String.IsNullOrWhiteSpace(_selectedObatID) Then
            MessageBox.Show("Cari dan pilih obat terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BtnCari.Focus()
            Return
        End If

        ' Validasi 2: Cek Stok Kosong
        If _selectedObatStok <= 0 Then
            MessageBox.Show("Obat ini sedang HABIS (Stok 0).", "Stok Kosong", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validasi 3: Cek Input Jumlah
        Dim jumlahInput As Integer
        If Not Integer.TryParse(TxtJumlah.Text, jumlahInput) OrElse jumlahInput <= 0 Then
            MessageBox.Show("Masukkan jumlah yang valid (angka bulat > 0).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtJumlah.Focus()
            Return
        End If

        ' Validasi 4: Cek Total Permintaan vs Stok Tersedia
        Dim jumlahSudahDiKeranjang As Integer = 0
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            If keranjang(i) IsNot Nothing AndAlso keranjang(i).IDObat = _selectedObatID Then
                jumlahSudahDiKeranjang = keranjang(i).Jumlah
                Exit For
            End If
        Next

        If (jumlahInput + jumlahSudahDiKeranjang) > _selectedObatStok Then
            Dim sisaBolehBeli As Integer = _selectedObatStok - jumlahSudahDiKeranjang
            MessageBox.Show("Stok tidak cukup! Sisa stok: " & _selectedObatStok & vbCrLf &
                            "Maksimal yang bisa ditambah: " & sisaBolehBeli, "Stok Kurang", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtJumlah.Focus()
            Return
        End If

        ' --- PROSES MASUK KERANJANG ---

        ' Cek jika sudah ada (Update)
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            If keranjang(i) IsNot Nothing AndAlso keranjang(i).IDObat = _selectedObatID Then
                keranjang(i).Jumlah += jumlahInput
                keranjang(i).Subtotal = keranjang(i).Harga * keranjang(i).Jumlah

                RefreshGrid()
                UpdateTotalBayar()
                ClearInputsObat()
                Return
            End If
        Next

        ' Jika belum ada (Insert Baru)
        Dim itemBaru As New TransaksiItem With {
            .IDObat = _selectedObatID,
            .NamaObat = _selectedObatNama,
            .Harga = _selectedObatHarga,
            .Jumlah = jumlahInput,
            .Subtotal = _selectedObatHarga * jumlahInput
        }

        If jumlahItemDiKeranjang = keranjang.Length Then
            ReDim Preserve keranjang((keranjang.Length * 2) - 1)
        End If

        keranjang(jumlahItemDiKeranjang) = itemBaru
        jumlahItemDiKeranjang += 1

        RefreshGrid()
        UpdateTotalBayar()
        ClearInputsObat()
    End Sub

    ' --- 6. HAPUS ITEM ---
    Private Sub BtnHapusItem_Click(sender As Object, e As EventArgs) Handles BtnHapusItem.Click
        If DgvListTransaksi.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih item di keranjang yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show("Hapus item ini dari keranjang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim selectedIndex = DgvListTransaksi.SelectedRows(0).Index

        ' Geser array
        For i = selectedIndex To jumlahItemDiKeranjang - 2
            keranjang(i) = keranjang(i + 1)
        Next

        If jumlahItemDiKeranjang > 0 Then
            keranjang(jumlahItemDiKeranjang - 1) = Nothing
        End If

        jumlahItemDiKeranjang -= 1

        RefreshGrid()
        UpdateTotalBayar()
    End Sub

    ' --- 7. BATAL TRANSAKSI ---
    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        If jumlahItemDiKeranjang = 0 Then Return

        If MessageBox.Show("Batalkan transaksi dan kosongkan keranjang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            jumlahItemDiKeranjang = 0
            Array.Clear(keranjang, 0, keranjang.Length)

            RefreshGrid()
            UpdateTotalBayar()
            ClearInputsObat()
        End If
    End Sub

    ' --- 8. SIMPAN KE DATABASE ---
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If jumlahItemDiKeranjang = 0 Then
            MessageBox.Show("Keranjang belanja masih kosong.", "Gagal Simpan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

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
            Dim idTransaksi As String = "Apt" & DateTime.Now.ToString("yyyyMMddHHmm")

            Dim totalBayar As Decimal = 0
            For i As Integer = 0 To jumlahItemDiKeranjang - 1
                totalBayar += keranjang(i).Subtotal
            Next

            ' Insert Header Transaksi
            cmd.CommandText = "INSERT INTO transaksi (id_transaksi, id_pengguna, total_bayar, tgl_transaksi) VALUES (@id, @idPengguna, @total, NOW())"
            cmd.Parameters.AddWithValue("@id", idTransaksi)
            cmd.Parameters.AddWithValue("@idPengguna", IDPenggunaLogin)
            cmd.Parameters.AddWithValue("@total", totalBayar)
            cmd.ExecuteNonQuery()

            ' Insert Detail & Update Stok
            For i As Integer = 0 To jumlahItemDiKeranjang - 1
                Dim item As TransaksiItem = keranjang(i)

                cmd.Parameters.Clear()
                cmd.CommandText = "INSERT INTO detail_transaksi (id_transaksi, id_obat, jumlah_beli, harga_satuan, sub_total) VALUES (@idTrx, @idObat, @jml, @harga, @sub)"
                cmd.Parameters.AddWithValue("@idTrx", idTransaksi)
                cmd.Parameters.AddWithValue("@idObat", item.IDObat)
                cmd.Parameters.AddWithValue("@jml", item.Jumlah)
                cmd.Parameters.AddWithValue("@harga", item.Harga)
                cmd.Parameters.AddWithValue("@sub", item.Subtotal)
                cmd.ExecuteNonQuery()

                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE obat SET stock = stock - @jmlBeli WHERE id_obat = @idObat"
                cmd.Parameters.AddWithValue("@jmlBeli", item.Jumlah)
                cmd.Parameters.AddWithValue("@idObat", item.IDObat)
                cmd.ExecuteNonQuery()
            Next

            dbTransaction.Commit()

            MessageBox.Show($"Transaksi {idTransaksi} berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reset Form
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

    ' --- 9. HELPER FUNCTIONS ---
    Private Sub RefreshGrid()
        DgvListTransaksi.Rows.Clear()
        For i As Integer = 0 To jumlahItemDiKeranjang - 1
            Dim item As TransaksiItem = keranjang(i)
            DgvListTransaksi.Rows.Add(item.IDObat, item.NamaObat, item.Harga, item.Jumlah, item.Subtotal)
        Next
    End Sub

    Private Sub UpdateTotalBayar()
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

        ' [PERBAIKAN 3] Reset stok juga
        _selectedObatStok = 0

        TxtIDObat.Focus()
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If jumlahItemDiKeranjang > 0 Then
            If MessageBox.Show("Ada item di keranjang. Yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Return
            End If
        End If
        Close()
    End Sub

    Private Sub BtnRiwayat_Click(sender As Object, e As EventArgs) Handles BtnRiwayat.Click
        Dim frmRiwayat As New Riwayat_Transaksi()
        frmRiwayat.Show()
    End Sub

    Private Sub BtnLihatStok_Click(sender As Object, e As EventArgs) Handles BtnLihatStok.Click
        Dim frmStok As New Lihat_Stok()
        frmStok.Show()
    End Sub

End Class