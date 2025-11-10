Imports MySql.Data.MySqlClient

Public Class ResetPassword
    Public Property UsernameDariLogin As String = "" 'Nanti diisi dari form Login jika dipanggil dari sana
    ' Load event form
    Private Sub ResetPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtUsername.Text = Me.UsernameDariLogin

        'Jika tidak ada username yang dikirim, biarkan TextBox bisa diisi
        If Not String.IsNullOrWhiteSpace(TxtUsername.Text) Then
            TxtUsername.ReadOnly = True
        End If
    End Sub

    ' Tombol Reset Password
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        ' 1. Ambil semua nilai dari TextBox
        Dim username As String = TxtUsername.Text
        Dim passBaru As String = TxtPasswordBaru.Text
        Dim konfirmasiPass As String = TxtKonfirmasiPassword.Text

        ' 2. Validasi Input Kosong
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
            ' Query UPDATE data pengguna
            Dim query As String = "UPDATE pengguna SET pass = @passBaru WHERE username = @userLama"

            Using cmd As New MySqlCommand(query, Koneksi.conn)
                cmd.Parameters.AddWithValue("@passBaru", passBaru)
                cmd.Parameters.AddWithValue("@userLama", username)

                ' ExecuteNonQuery() digunakan untuk UPDATE
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Password berhasil direset! Silakan login dengan password baru Anda.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close() ' Jika sukses, langsung tutup form ResetPassword ini
                Else
                    ' Jika tidak ada baris yang terpengaruh, kemungkinan username tidak ditemukan
                    MessageBox.Show($"Username '{username}' tidak ditemukan di database.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat update: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    ' Tombol Kembali Ke Login
    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.Close()
    End Sub

End Class