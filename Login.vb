' Impor library MySQL yang diperlukan
Imports MySql.Data.MySqlClient

Public Class Login

    Private Sub BtnMasuk_Click(sender As Object, e As EventArgs) Handles BtnMasuk.Click

        ' 1. Validasi Input Sederhana
        If String.IsNullOrWhiteSpace(TxtUsername.Text) Then
            MessageBox.Show("Username tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtUsername.Focus()
            Return ' Hentikan eksekusi
        End If

        If String.IsNullOrWhiteSpace(TxtPassword.Text) Then
            MessageBox.Show("Password tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtPassword.Focus()
            Return ' Hentikan eksekusi
        End If

        ' 2. Coba Buka Koneksi ke Database
        ' (Ini menggunakan Koneksi.vb versi Function)
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Koneksi ke Database Gagal." & vbCrLf &
                            "Pastikan XAMPP sudah berjalan dan nama database benar.",
                            "Koneksi Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ' Hentikan eksekusi jika koneksi gagal
        End If

        ' 3. Proses Login jika Koneksi Berhasil
        Try
            ' GANTI "pengguna" jika nama tabel Anda berbeda
            Dim query As String = "SELECT role, nama FROM pengguna WHERE username = @user AND pass = @pass"

            ' Menggunakan "Using" agar koneksi & command tertutup otomatis
            Using cmd As New MySqlCommand(query, Koneksi.conn)

                ' 4. Tambahkan Parameter (Sangat PENTING untuk keamanan)
                cmd.Parameters.AddWithValue("@user", TxtUsername.Text)
                cmd.Parameters.AddWithValue("@pass", TxtPassword.Text) ' CATATAN: Menyimpan password sbg teks biasa tidak aman

                Using reader As MySqlDataReader = cmd.ExecuteReader()

                    ' 5. Cek apakah data user ditemukan
                    If reader.HasRows Then
                        reader.Read() ' Baca datanya

                        ' Ambil role dan nama dari database
                        Dim userRole As String = reader.GetString("role")
                        Dim namaPengguna As String = reader.GetString("nama")

                        MessageBox.Show($"Selamat datang, {namaPengguna}!", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' 6. Logika Pindah Form berdasarkan Role
                        If userRole = "Admin" Then
                            ' Buka Form Dashboard
                            Dim frmDashboard As New DashBoard() ' Pastikan nama Form-nya "Dashboard"
                            frmDashboard.Show()
                        ElseIf userRole = "Kasir" Then
                            ' Buka Form Transaksi
                            Dim frmTransaksi As New Transaksi() ' Pastikan nama Form-nya "FormTransaksi"
                            frmTransaksi.Show()
                        Else
                            MessageBox.Show("Role Anda tidak dikenali.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                        ' Sembunyikan Form Login ini
                        Me.Hide()

                    Else
                        ' 7. Jika username atau password salah
                        MessageBox.Show("Username atau Password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using ' Reader ditutup
            End Using ' Command di-dispose

        Catch ex As Exception
            ' 8. Jika terjadi error saat menjalankan query
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                            )
        Finally
            ' 9. Selalu tutup koneksi setelah selesai
            Koneksi.TutupKoneksi()
        End Try
    End Sub

    ' Anda bisa tambahkan kode untuk BtnKeluar di sini
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        ' Tampilkan konfirmasi sebelum keluar
        Dim result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    ' Kode untuk BtnLupaPwd bisa ditambahkan nanti
    ' Private Sub BtnLupaPwd_Click(sender As Object, e As EventArgs) Handles BtnLupaPwd.Click
    '    ' Logika untuk buka form reset password
    ' End Sub

End Class