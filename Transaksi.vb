Public Class Transaksi
    ' Form logic untuk transaksi kasir apotek

    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- TAMBAHAN ---
        ' Atur format tampilan untuk kolom Harga dan Subtotal di DataGridView.
        ' Kode ini memberi tahu DGV untuk menampilkan angka sebagai mata uang
        ' tanpa harus menyimpan teks "Rp" di datanya.
        DgvListTransaksi.Columns("Harga").DefaultCellStyle.Format = "Rp #,##0"
        DgvListTransaksi.Columns("Subtotal").DefaultCellStyle.Format = "Rp #,##0"

        ' Atur perataan (opsional tapi membuat rapi)
        DgvListTransaksi.Columns("Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvListTransaksi.Columns("Subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvListTransaksi.Columns("Jumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' --- AKHIR TAMBAHAN ---

        UpdateTotalBayar()
    End Sub

    ' --- DIPERBAIKI ---
    ' Fungsi ini dibuat lebih kuat untuk menangani format angka Indonesia
    ' (misal: "10.000" atau "10.000,50")
    Private Function ParseDecimalSafe(text As String, ByRef value As Decimal) As Boolean
        If String.IsNullOrWhiteSpace(text) Then
            value = 0D
            Return False
        End If

        ' 1. Bersihkan dari simbol non-numerik (Rp, spasi)
        Dim cleaned = text.Replace("Rp", "").Trim()

        ' 2. Ganti separator ribuan (titik) dengan string kosong
        cleaned = cleaned.Replace(".", "")

        ' 3. Ganti separator desimal (koma) dengan titik (standar InvariantCulture)
        cleaned = cleaned.Replace(",", ".")

        ' 4. Coba parse dengan InvariantCulture (yang selalu pakai "." sebagai desimal)
        Return Decimal.TryParse(cleaned, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, value)
    End Function


    ' --- DIPERBAIKI ---
    ' Dibuat jauh lebih sederhana karena DGV sekarang menyimpan Angka, bukan Teks
    Private Sub UpdateTotalBayar()
        Dim total As Decimal = 0D
        For Each row As DataGridViewRow In DgvListTransaksi.Rows
            ' Lewati baris baru (baris paling bawah yang kosong)
            If row.IsNewRow Then Continue For

            ' Langsung ambil nilainya sebagai Decimal
            ' karena kita menyimpannya sebagai Decimal
            If row.Cells("Subtotal").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Subtotal").Value) Then
                total += Convert.ToDecimal(row.Cells("Subtotal").Value)
            End If
        Next

        ' Format "N2" untuk menampilkan 2 angka di belakang koma (jika ada)
        LblTotalBayar.Text = "Rp " & total.ToString("N2")
    End Sub

    Private Sub ClearInputs()
        TxtIDTransaksi.Clear()
        TxtNamaObat.Clear()
        TxtHarga.Clear()
        TxtJumlah.Clear()
        TxtIDTransaksi.Focus()
    End Sub

    ' --- DIPERBAIKI ---
    Private Sub BtnTambahList_Click(sender As Object, e As EventArgs) Handles BtnTambahList.Click
        ' Validasi input (Logika validasi Anda sudah bagus)
        If String.IsNullOrWhiteSpace(TxtIDTransaksi.Text) Then
            MessageBox.Show("Masukkan ID obat.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtIDTransaksi.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(TxtNamaObat.Text) Then
            MessageBox.Show("Masukkan nama obat.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNamaObat.Focus()
            Return
        End If

        Dim harga As Decimal
        If Not ParseDecimalSafe(TxtHarga.Text, harga) OrElse harga <= 0D Then
            MessageBox.Show("Masukkan harga yang valid (angka lebih besar dari 0).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtHarga.Focus()
            Return
        End If

        Dim jumlah As Decimal
        If Not ParseDecimalSafe(TxtJumlah.Text, jumlah) OrElse jumlah <= 0D Then
            MessageBox.Show("Masukkan jumlah yang valid (angka lebih besar dari 0).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtJumlah.Focus()
            Return
        End If

        Dim subtotal As Decimal = harga * jumlah

        ' !! INI BAGIAN UTAMA YANG DIUBAH !!
        ' Kita masukkan object Angka (Decimal), BUKAN Teks/String yang sudah diformat
        DgvListTransaksi.Rows.Add(TxtIDTransaksi.Text.Trim(),
                                   TxtNamaObat.Text.Trim(),
                                   harga,  ' <-- Disimpan sebagai angka
                                   jumlah, ' <-- Disimpan sebagai angka
                                   subtotal) ' <-- Disimpan sebagai angka

        UpdateTotalBayar()
        ClearInputs()
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        If DgvListTransaksi.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih item yang ingin dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Looping aman untuk menghapus multiple rows
        For i As Integer = DgvListTransaksi.SelectedRows.Count - 1 To 0 Step -1
            Dim row As DataGridViewRow = DgvListTransaksi.SelectedRows(i)
            If Not row.IsNewRow Then
                DgvListTransaksi.Rows.Remove(row)
            End If
        Next
        UpdateTotalBayar()
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        If MessageBox.Show("Batalkan transaksi dan kosongkan daftar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DgvListTransaksi.Rows.Clear()
            UpdateTotalBayar()
            ClearInputs()
        End If
    End Sub

    Private Sub BtnSimpanTransaksi_Click(sender As Object, e As EventArgs) Handles BtnSimpanTransaksi.Click
        ' Validasi: Periksa baris baru juga
        If DgvListTransaksi.Rows.Count = 0 Or (DgvListTransaksi.Rows.Count = 1 And DgvListTransaksi.Rows(0).IsNewRow) Then
            MessageBox.Show("Tidak ada item untuk disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Placeholder: simpan ke database atau file. Di sini hanya menampilkan ringkasan.
        Dim total As String = LblTotalBayar.Text
        ' Hitung item sebenarnya (tanpa baris baru)
        Dim itemCount As Integer = DgvListTransaksi.Rows.Count - 1
        If Not DgvListTransaksi.Rows(DgvListTransaksi.Rows.Count - 1).IsNewRow Then
            itemCount = DgvListTransaksi.Rows.Count ' jika tidak ada baris baru
        End If

        MessageBox.Show($"Transaksi tersimpan. Jumlah item: {itemCount}{Environment.NewLine}Total: {total}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Setelah simpan, kosongkan form
        DgvListTransaksi.Rows.Clear()
        UpdateTotalBayar()
        ClearInputs()
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
    End Sub

    ' Event handler di bawah ini bisa dihapus jika tidak dipakai,
    ' tapi tidak masalah jika dibiarkan kosong.
    Private Sub TxtHarga_TextChanged(sender As Object, e As EventArgs) Handles TxtHarga.TextChanged
    End Sub

    Private Sub TxtJumlah_TextChanged(sender As Object, e As EventArgs) Handles TxtJumlah.TextChanged
    End Sub

    Private Sub TxtIDTransaksi_TextChanged(sender As Object, e As EventArgs) Handles TxtIDTransaksi.TextChanged
    End Sub

    Private Sub TxtNamaObat_TextChanged(sender As Object, e As EventArgs) Handles TxtNamaObat.TextChanged
    End Sub

    Private Sub DgvListTransaksi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListTransaksi.CellContentClick
    End Sub
End Class