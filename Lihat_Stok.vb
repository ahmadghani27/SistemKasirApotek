' Impor library MySQL
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Lihat_Stok

    Private Sub Lihat_Stok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur format kolom agar angka terlihat rapi
        ' (Pastikan nama kolom ini sudah benar di desainer)
        DgvStokObat.Columns("ColStok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgvStokObat.Columns("ColKadaluarsa").DefaultCellStyle.Format = "dd MMM yyyy"
        DgvStokObat.Columns("ColKadaluarsa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgvStokObat.Columns("ColHarga").DefaultCellStyle.Format = "Rp #,##0"
        DgvStokObat.Columns("ColHarga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' Panggil fungsi untuk memuat data stok
        LoadStok()
    End Sub

    ''' <summary>
    ''' Mengambil data dari tabel 'obat' dan menampilkannya di grid
    ''' (DIUBAH UNTUK KONEKSI DATABASE)
    ''' </summary>
    Private Sub LoadStok()
        ' Hapus data lama
        DgvStokObat.Rows.Clear()

        ' --- KODE DATABASE DIMULAI ---
        Dim query As String = "SELECT id_obat, nama, jenis, stock, tgl_expired, harga FROM obat ORDER BY nama"

        If Not Koneksi.BukaKoneksi() Then
            MessageBox.Show("Gagal terhubung ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim da As New MySqlDataAdapter(query, Koneksi.conn)
        Dim dt As New DataTable()

        Try
            ' 1. Ambil semua data obat ke DataTable
            da.Fill(dt)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat data obat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' 2. Selalu tutup koneksi setelah data diambil
            Koneksi.TutupKoneksi()
        End Try

        ' 3. Loop data dari DataTable dan masukkan ke DGV secara manual
        For Each row As DataRow In dt.Rows
            Dim idObat As String = row.Item("id_obat").ToString()
            Dim nama As String = row.Item("nama").ToString()
            Dim jenis As String = row.Item("jenis").ToString()
            Dim stok As Integer = CInt(row.Item("stock"))
            Dim tglExpired As Date = CDate(row.Item("tgl_expired"))
            Dim harga As Decimal = CDec(row.Item("harga"))

            ' Tambahkan ke grid (6 kolom sesuai urutan di Petunjuk)
            DgvStokObat.Rows.Add(idObat, nama, jenis, stok, tglExpired, harga)
        Next
        ' --- KODE DATABASE SELESAI ---

        ' Panggil fungsi untuk memberi warna pada baris
        HighlightKadaluarsa()
    End Sub

    ' --- FUNGSI BARU UNTUK MEMBERI WARNA ---
    ' (Tidak ada perubahan, kode ini sudah benar)
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

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.Close()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ' Kosongkan kotak pencarian
        TxtCariObat.Clear()
        ' Muat ulang semua data
        LoadStok()
    End Sub

    ''' <summary>
    ''' Fungsi LIVE SEARCH
    ''' (DIPERBAIKI: Menghapus CurrencyManager yang tidak perlu)
    ''' </summary>
    Private Sub TxtCariObat_TextChanged(sender As Object, e As EventArgs) Handles TxtCariObat.TextChanged
        Dim filterTeks As String = TxtCariObat.Text.ToLower()

        ' --- PERBAIKAN ---
        ' Kode CurrencyManager dihapus karena kita menggunakan grid Unbound (Rows.Add)
        ' Menyembunyikan baris secara manual sudah cukup.

        For Each row As DataGridViewRow In DgvStokObat.Rows
            If row.IsNewRow Then Continue For

            ' Ambil data dari sel dengan aman (null-check)
            Dim namaObat As String = If(row.Cells("ColNamaObat").Value IsNot Nothing, row.Cells("ColNamaObat").Value.ToString().ToLower(), "")
            Dim kodeObat As String = If(row.Cells("ColKodeObat").Value IsNot Nothing, row.Cells("ColKodeObat").Value.ToString().ToLower(), "")

            ' Logika filter
            If namaObat.Contains(filterTeks) OrElse kodeObat.Contains(filterTeks) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next

        ' --- PERBAIKAN ---
        ' Kode ResumeBinding() dihapus
    End Sub

End Class