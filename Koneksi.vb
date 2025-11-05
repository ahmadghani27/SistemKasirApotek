' Impor library MySQL
Imports MySql.Data.MySqlClient

Public Class Koneksi

    ' 1. String koneksi Anda
    Private Shared connectionString As String = "Server=localhost;Database=si_apotek;User=root;Password=;"

    ' 2. Objek koneksi yang dipakai bersama
    Public Shared conn As New MySqlConnection(connectionString)

    ' 3. Diubah menjadi FUNGSI yang mengembalikan nilai Boolean (True/False)
    Public Shared Function BukaKoneksi() As Boolean
        Try
            ' Hanya buka jika koneksi sedang tertutup
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            ' Jika berhasil (atau sudah terbuka), kembalikan True
            Return True
        Catch ex As Exception
            ' Jika ada error (XAMPP mati, DB salah), kembalikan False
            Return False
        End Try
    End Function


    ' 4. Fungsi untuk MENUTUP koneksi (tetap Sub)
    Public Shared Sub TutupKoneksi()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

End Class