' Impor library MySQL yang diperlukan
Imports MySql.Data.MySqlClient

Public Class Transaksi

    ' --- 1. CETAKAN DATA (Structure) ---
    ' Ini adalah "cetakan" untuk setiap item di keranjang
    Private Class TransaksiItem
        Public Property IDObat As String
        Public Property NamaObat As String
        Public Property Harga As Decimal
        Public Property Jumlah As Integer ' Jumlah adalah bilangan bulat
        Public Property Subtotal As Decimal
    End Class

    ' --- 2. "ARRAY" MODERN (List) ---
    ' Ini adalah "keranjang belanja" Anda, menggantikan array 2D
    Private keranjang As New List(Of TransaksiItem)

    ' --- 3. VARIABEL BANTU ---
    ' Untuk menyimpan ID dan Nama dari hasil pencarian
    Private _selectedObatID As String = ""
    Private _selectedObatNama As String = ""
    Private _selectedObatHarga As Decimal = 0

    ' Ganti '1' dengan ID pengguna yang login
    Public IDPenggunaLogin As Integer = 1

    ' --- 4. FORM LOAD (DIPERBAIKI) ---
    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Panggil Sub baru untuk mengatur DGV
        SetupDataGridView()

        ' --- DIHAPUS ---
        ' TxtIDTransaksi.Text = "TRX-" & DateTime.Now.ToString("yyyyMMddHHmmss")
        ' TxtIDTransaksi.ReadOnly = True
        ' --- AKHIR HAPUS ---

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
    ' (Di dalam Transaksi.vb)

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Dim kataKunci As String = TxtNamaObat.Text.Trim()
        ' (Validasi kataKunci...)

        Using frmCari As New FormHasilPencarian()

            ' --- PERBAIKAN DI SINI ---
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
                '    MessageBox "Obat tidak ditemukan" sudah ditampilkan oleh MuatData.
                TxtNamaObat.Focus()
                TxtNamaObat.SelectAll()
            End If
            ' --- AKHIR PERBAIKAN ---

        End Using
    End Sub

    ' --- 7. BTN TAMBAH (DIPERBAIKI TOTAL) ---
    ' Menggunakan data hasil pencarian dan 'List'
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

        ' Validasi 3: Cek duplikat di keranjang
        If keranjang.Any(Function(item) item.IDObat = _selectedObatID) Then
            MessageBox.Show("Obat ini sudah ada di keranjang.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearInputsObat() ' Bersihkan input obat
            Return
        End If

        ' Buat item baru
        Dim itemBaru As New TransaksiItem With {
            .IDObat = _selectedObatID,
            .NamaObat = _selectedObatNama,
            .Harga = _selectedObatHarga,
            .Jumlah = jumlah,
            .Subtotal = _selectedObatHarga * jumlah
        }

        ' Tambahkan ke "array" List
        keranjang.Add(itemBaru)

        ' Perbarui DGV, Total, dan bersihkan input
        RefreshGrid()
        UpdateTotalBayar()
        ClearInputsObat()
    End Sub

    ' --- 8. BTN HAPUS (DIPERBAIKI TOTAL) ---
    ' Memperbaiki Bug Sinkronisasi
    Private Sub BtnHapusItem_Click(sender As Object, e As EventArgs) Handles BtnHapusItem.Click
        If DgvListTransaksi.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih item di keranjang yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Dapatkan index baris yang dipilih
        Dim selectedIndex As Integer = DgvListTransaksi.SelectedRows(0).Index

        ' HAPUS DARI 'List' (Sumber Data)
        ' Ini adalah perbaikan bug yang kritis
        keranjang.RemoveAt(selectedIndex)

        ' Perbarui DGV, Total
        RefreshGrid()
        UpdateTotalBayar()
    End Sub

    ' --- 9. BTN BATAL (DIPERBAIKI) ---
    ' Menggunakan 'List'
    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        If keranjang.Count = 0 Then Return

        If MessageBox.Show("Batalkan transaksi dan kosongkan keranjang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            keranjang.Clear()
            RefreshGrid()
            UpdateTotalBayar()
            ClearInputsObat()
        End If
    End Sub

    ' --- 10. BTN SIMPAN (DIPERBAIKI TOTAL) ---
    ' Menggunakan 'List' dan Transaksi Database
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If keranjang.Count = 0 Then
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
            ' --- PERUBAHAN UTAMA DI SINI ---
            ' 1. Hasilkan ID Transaksi SEKARANG (saat mau simpan)
            '    Formatnya bisa Anda ubah, misal: "TRT-"
            Dim idTransaksi As String = "TRX-" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
            ' --- AKHIR PERUBAHAN ---

            ' 2. Hitung Total Bayar dari 'List'
            Dim totalBayar As Decimal = keranjang.Sum(Function(item) item.Subtotal)

            ' 3. Simpan ke Tabel Master `transaksi`
            cmd.CommandText = "INSERT INTO transaksi (id_transaksi, id_pengguna, total_bayar, tgl_transaksi) VALUES (@id, @idPengguna, @total, NOW())"
            cmd.Parameters.AddWithValue("@id", idTransaksi) ' <-- Pakai ID yang baru dibuat
            cmd.Parameters.AddWithValue("@idPengguna", IDPenggunaLogin)
            cmd.Parameters.AddWithValue("@total", totalBayar)
            cmd.ExecuteNonQuery()

            ' 4. Loop 'List' (keranjang) dan simpan ke detail & update stok
            For Each item As TransaksiItem In keranjang
                ' 4a. Simpan ke detail_transaksi
                cmd.Parameters.Clear()
                cmd.CommandText = "INSERT INTO detail_transaksi (id_transaksi, id_obat, jumlah_beli, harga_satuan, sub_total) VALUES (@idTrx, @idObat, @jml, @harga, @sub)"
                cmd.Parameters.AddWithValue("@idTrx", idTransaksi) ' <-- Pakai ID yang sama
                cmd.Parameters.AddWithValue("@idObat", item.IDObat)
                cmd.Parameters.AddWithValue("@jml", item.Jumlah)
                cmd.Parameters.AddWithValue("@harga", item.Harga)
                cmd.Parameters.AddWithValue("@sub", item.Subtotal)
                cmd.ExecuteNonQuery()

                ' 4b. Kurangi stok (logika tetap sama)
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE obat SET stock = stock - @jmlBeli WHERE id_obat = @idObat"
                cmd.Parameters.AddWithValue("@jmlBeli", item.Jumlah)
                cmd.Parameters.AddWithValue("@idObat", item.IDObat)
                cmd.ExecuteNonQuery()
            Next

            ' 5. Commit transaksi
            dbTransaction.Commit()

            ' Tampilkan ID yang baru dibuat di pesan sukses
            MessageBox.Show($"Transaksi {idTransaksi} berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 6. Bersihkan form untuk transaksi berikutnya
            keranjang.Clear()
            RefreshGrid()
            UpdateTotalBayar()
            ClearInputsObat()
            ' Tidak perlu buat ID baru lagi

        Catch ex As Exception
            dbTransaction.Rollback()
            MessageBox.Show("Terjadi kesalahan saat menyimpan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If keranjang.Count > 0 Then
            If MessageBox.Show("Ada item di keranjang. Yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Return
            End If
        End If
        Close()
    End Sub

    ' --- 11. FUNGSI BANTU (DIPERBAIKI) ---

    ' Fungsi ParseDecimalSafe (Kode Anda sudah bagus)
    Private Function ParseDecimalSafe(text As String, ByRef value As Decimal) As Boolean
        If String.IsNullOrWhiteSpace(text) Then
            value = 0D
            Return False
        End If
        Dim cleaned = text.Replace("Rp", "").Trim().Replace(".", "").Replace(",", ".")
        Return Decimal.TryParse(cleaned, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, value)
    End Function

    ' Memperbarui DGV dari 'List'
    ' Memperbarui DGV dari 'List' (MODE MANUAL / UNBOUND)
    Private Sub RefreshGrid()
        ' 1. Kosongkan semua baris yang ada di DGV
        DgvListTransaksi.Rows.Clear()

        ' 2. Loop 'List' keranjang Anda
        For Each item As TransaksiItem In keranjang
            ' 3. Tambahkan satu per satu baris ke DGV
            DgvListTransaksi.Rows.Add(
            item.IDObat,
            item.NamaObat,
            item.Harga,
            item.Jumlah,
            item.Subtotal
        )
        Next
    End Sub

    ' Memperbarui Total dari 'List'
    Private Sub UpdateTotalBayar()
        Dim total As Decimal = keranjang.Sum(Function(item) item.Subtotal)
        LblTotalBayar.Text = "Rp " & total.ToString("N0")
    End Sub

    ' Membersihkan input obat
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

    End Sub
End Class