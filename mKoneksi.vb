Imports MySql.Data.MySqlClient

Module KoneksiDB
    Public conn As MySqlConnection

    Public Sub Koneksi()
        Try
            Dim str As String
            str = "server=localhost;userid=root;password=;database=apotek"
            conn = New MySqlConnection(str)
            conn.Open()
            MessageBox.Show("Koneksi berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Koneksi gagal: " & ex.Message)
        End Try
    End Sub
End Module

