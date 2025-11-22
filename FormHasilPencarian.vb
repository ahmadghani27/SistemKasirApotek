Imports MySql.Data.MySqlClient

Public Class FormHasilPencarian

    ' --- VARIABEL PUBLIK (Untuk diakses oleh Form Transaksi) ---
    Public SelectedObatID As String = ""
    Public SelectedObatNama As String = ""
    Public SelectedObatHarga As Decimal = 0

    ' [BARU] Tambahkan variabel ini agar Form Transaksi bisa baca stok
    Public SelectedObatStok As Integer = 0

    ' --- FUNGSI MUAT DATA ---
    Public Function MuatData(kataKunci As String) As Boolean
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Gagal koneksi database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Try
            ' Kosongkan DataGridView sebelum memuat data baru
            DgvHasilPencarian.Rows.Clear()

            ' Query mengambil ID, Nama, Jenis, Harga, dan Stock
            Dim query As String = "SELECT id_obat, nama, jenis, harga, stock FROM obat WHERE nama LIKE @nama"

            Using cmd As New MySqlCommand(query, Koneksi.conn)
                cmd.Parameters.AddWithValue("@nama", "%" & kataKunci & "%")

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If Not reader.HasRows Then
                        MessageBox.Show("Obat tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    ' Loop data
                    While reader.Read()
                        ' Pastikan urutan Add sesuai dengan urutan kolom di Desain DGV Anda
                        ' Index 0: ID
                        ' Index 1: Nama
                        ' Index 2: Harga
                        ' Index 3: Stok (Penting untuk kode di bawah)
                        DgvHasilPencarian.Rows.Add(
                            reader.GetString("id_obat"),
                            reader.GetString("nama"),
                            reader.GetDecimal("harga"),
                            reader.GetInt32("stock")
                        )
                    End While

                    Return True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saat memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Koneksi.TutupKoneksi()
        End Try
    End Function

    ' --- FORM LOAD ---
    Private Sub FormHasilPencarian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Pastikan nama kolom desain (Name) di properti DGV Anda sesuai (misal: colHarga, colStock)
        ' Jika error, hapus baris pengaturan format ini dan atur lewat Designer saja.
        Try
            colHarga.DefaultCellStyle.Format = "Rp #,##0"
            colHarga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Asumsi colJumlah adalah kolom untuk stok
            colJumlah.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch
            ' Abaikan error format jika nama kolom belum diset
        End Try
    End Sub

    ' --- PILIH DATA (DOUBLE CLICK) ---
    Private Sub DgvHasilPencarian_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvHasilPencarian.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim baris As DataGridViewRow = DgvHasilPencarian.Rows(e.RowIndex)

            ' Simpan data ke variabel Publik
            ' Pastikan urutan index cells sesuai dengan urutan Rows.Add di atas
            SelectedObatID = baris.Cells(0).Value.ToString()      ' Index 0 = ID
            SelectedObatNama = baris.Cells(1).Value.ToString()    ' Index 1 = Nama
            SelectedObatHarga = Convert.ToDecimal(baris.Cells(2).Value) ' Index 2 = Harga

            ' [BARU] Ambil data Stok dari kolom ke-4 (Index 3)
            SelectedObatStok = Convert.ToInt32(baris.Cells(3).Value)

            ' Tutup form dengan status OK
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    ' --- TOMBOL KELUAR ---
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class