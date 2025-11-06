' Impor library MySQL yang diperlukan
Imports MySql.Data.MySqlClient

Public Class ResetPassword

    ' Properti ini akan diisi oleh Form Login
    Public Property UsernameDariLogin As String = ""

    Private Sub ResetPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Saat form ini dibuka, isi TxtUsername
        ' dengan data yang dikirim dari Form Login
        TxtUsername.Text = Me.UsernameDariLogin

        ' Opsional: Kunci textbox username jika sudah diisi dari login
        If Not String.IsNullOrWhiteSpace(TxtUsername.Text) Then
            TxtUsername.ReadOnly = True
        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        ' 1. Ambil semua nilai dari TextBox
        Dim username As String = TxtUsername.Text
        Dim passBaru As String = TxtPasswordBaru.Text
        Dim konfirmasiPass As String = TxtKonfirmasiPassword.Text

        ' 2. Validasi Input
        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Username tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(passBaru) Then
            MessageBox.Show("Password baru tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtPasswordBaru.Focus()
            Return
        End If

        ' 3. Validasi PENTING: Cek apakah password baru & konfirmasi sama
        If passBaru <> konfirmasiPass Then
            MessageBox.Show("Password Baru dan Konfirmasi Password tidak sama.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtKonfirmasiPassword.Focus()
            TxtKonfirmasiPassword.SelectAll()
            Return
        End If

        ' 4. Konfirmasi terakhir sebelum eksekusi
        Dim konfirmasi = MessageBox.Show($"Apakah Anda yakin ingin mengganti password untuk '{username}'?", "Konfirmasi Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If konfirmasi = DialogResult.No Then
            Return
        End If

        ' 5. Buka Koneksi dan jalankan query UPDATE
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Koneksi ke Database Gagal.", "Koneksi Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Pastikan nama tabel adalah 'pengguna' (sesuai skema database Anda)
            Dim query As String = "UPDATE pengguna SET pass = @passBaru WHERE username = @userLama"

            Using cmd As New MySqlCommand(query, Koneksi.conn)
                ' Tambahkan parameter
                cmd.Parameters.AddWithValue("@passBaru", passBaru)
                cmd.Parameters.AddWithValue("@userLama", username)

                ' ExecuteNonQuery() digunakan untuk UPDATE
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Password berhasil direset! Silakan login dengan password baru Anda.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Jika sukses, tutup form ResetPassword ini
                    Me.Close()
                Else
                    MessageBox.Show($"Username '{username}' tidak ditemukan di database.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat update: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        ' Cukup tutup form ini, maka akan kembali ke Form Login
        ' (karena Form Login dibuka menggunakan .ShowDialog())
        Me.Close()
    End Sub

End Class