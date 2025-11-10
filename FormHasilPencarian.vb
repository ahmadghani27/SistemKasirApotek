Imports MySql.Data.MySqlClient

Public Class FormHasilPencarian
    ' untuk menyimpan data obat yang dipilih
    Public SelectedObatID As String = ""
    Public SelectedObatNama As String = ""
    Public SelectedObatHarga As Decimal = 0
    Public Function MuatData(kataKunci As String) As Boolean
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Gagal koneksi database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False ' jika koneksi gagal, kembalikan False
        End If

        Try
            ' Kosongkan DataGridView sebelum memuat data baru
            DgvHasilPencarian.Rows.Clear()
            Dim query As String = "SELECT id_obat, nama, jenis, harga, stock FROM obat WHERE nama LIKE @nama"
            Using cmd As New MySqlCommand(query, Koneksi.conn)
                cmd.Parameters.AddWithValue("@nama", "%" & kataKunci & "%")

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If Not reader.HasRows Then
                        MessageBox.Show("Obat tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    'jika ada data, masukkan ke DGV

                    While reader.Read()
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

    ' mengatur format tampilan kolom saat form dimuat
    Private Sub FormHasilPencarian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        colHarga.DefaultCellStyle.Format = "Rp #,##0"
        colHarga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colJumlah.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' menangani event double click pada baris DataGridView untuk memilih obat
    Private Sub DgvHasilPencarian_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvHasilPencarian.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim baris As DataGridViewRow = DgvHasilPencarian.Rows(e.RowIndex)

            'langsung mengisi properti dengan data dari baris yang dipilih
            SelectedObatID = baris.Cells(0).Value.ToString()
            SelectedObatNama = baris.Cells(1).Value.ToString()
            SelectedObatHarga = Convert.ToDecimal(baris.Cells(2).Value)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    ' keluar dari form dan kembali ke form sebelumnya
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class