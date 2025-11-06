Imports MySql.Data.MySqlClient

Public Class FormHasilPencarian

    ' --- BARU: Properti Publik untuk mengirim data KEMBALI ke Form Transaksi ---
    Public SelectedObatID As String = ""
    Public SelectedObatNama As String = ""
    Public SelectedObatHarga As Decimal = 0

    ' --- BARU: Fungsi untuk Menerima kata kunci & Mengisi DGV ---
    ' --- UBAH Sub Menjadi Function ---
    Public Function MuatData(kataKunci As String) As Boolean
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Gagal koneksi database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False ' <-- KEMBALIKAN FALSE
        End If

        Try
            DgvHasilPencarian.Rows.Clear()
            Dim query As String = "SELECT id_obat, nama, jenis, harga, stock FROM obat WHERE nama LIKE @nama"
            Using cmd As New MySqlCommand(query, Koneksi.conn)
                cmd.Parameters.AddWithValue("@nama", "%" & kataKunci & "%")

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If Not reader.HasRows Then
                        MessageBox.Show("Obat tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' --- JANGAN TUTUP FORM DI SINI ---
                        ' Me.DialogResult = DialogResult.Cancel  ' <-- HAPUS
                        ' Me.Close()                             ' <-- HAPUS
                        Return False ' <-- KEMBALIKAN FALSE
                    End If

                    While reader.Read()
                        ' Tambahkan baris ke DGV HANYA untuk kolom yang Anda punya
                        ' (Kita lewati 'jenis' karena tidak ada di DGV Anda)
                        DgvHasilPencarian.Rows.Add(
        reader.GetString("id_obat"),
        reader.GetString("nama"),
        reader.GetDecimal("harga"),
        reader.GetInt32("stock")    ' <-- Ini harusnya ColStok, bukan ColJumlah
    )
                    End While

                    Return True ' <-- KEMBALIKAN TRUE JIKA SUKSES
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saat memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False ' <-- KEMBALIKAN FALSE
        Finally
            Koneksi.TutupKoneksi()
        End Try
    End Function

    Private Sub FormHasilPencarian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Format tampilan menggunakan NAMA VARIABEL KOLOM

        ' Pastikan nama variabel kolom Anda di designer adalah ColHarga
        colHarga.DefaultCellStyle.Format = "Rp #,##0"
        colHarga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' Pastikan nama variabel kolom Anda di designer adalah ColStok
        colJumlah.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' --- DIPERBAIKI: Mengisi Properti Publik saat double click ---
    Private Sub DgvHasilPencarian_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvHasilPencarian.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' Ambil data dari baris yang di-klik
            Dim baris As DataGridViewRow = DgvHasilPencarian.Rows(e.RowIndex)
            SelectedObatID = baris.Cells(0).Value.ToString()    ' Kolom 0 adalah ID Obat
            SelectedObatNama = baris.Cells(1).Value.ToString()  ' Kolom 1 adalah Nama
            SelectedObatHarga = Convert.ToDecimal(baris.Cells(2).Value) ' Kolom 2 adalah Harga

            ' Kirim sinyal OK dan tutup
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    ' --- DIPERBAIKI: Mengisi Properti Publik saat klik Pilih ---
    Private Sub BtnPilih_Click(sender As Object, e As EventArgs) Handles BtnPilih.Click
        If DgvHasilPencarian.SelectedRows.Count > 0 Then
            ' Ambil data dari baris yang dipilih
            Dim baris As DataGridViewRow = DgvHasilPencarian.SelectedRows(0)
            SelectedObatID = baris.Cells(0).Value.ToString()    ' Kolom 0 adalah ID Obat
            SelectedObatNama = baris.Cells(1).Value.ToString()  ' Kolom 1 adalah Nama
            SelectedObatHarga = Convert.ToDecimal(baris.Cells(2).Value) ' Kolom 2 adalah Harga

            ' Kirim sinyal OK dan tutup
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Pilih obat terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Ganti nama BtnBatal ke BtnKeluar agar sesuai gambar
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnPilih.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class