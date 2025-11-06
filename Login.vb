' Impor library MySQL yang diperlukan
Imports MySql.Data.MySqlClient

Public Class Login

    Private Sub BtnMasuk_Click(sender As Object, e As EventArgs) Handles BtnMasuk.Click

        ' 1. Validasi Input
        If String.IsNullOrWhiteSpace(TxtUsername.Text) Then
            MessageBox.Show("Username tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtUsername.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(TxtPassword.Text) Then
            MessageBox.Show("Password tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtPassword.Focus()
            Return
        End If

        ' --- Variabel untuk menyimpan hasil login ---
        Dim loginBerhasil As Boolean = False
        Dim userRole As String = ""
        Dim namaPengguna As String = ""
        ' ------------------------------------------

        ' 2. Coba Buka Koneksi
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Koneksi ke Database Gagal." & vbCrLf &
                  "Pastikan XAMPP sudah berjalan dan nama database benar.",
                  "Koneksi Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 3. Proses Login
        Try
            Dim query As String = "SELECT role, nama FROM pengguna WHERE username = @user AND pass = @pass"
            Using cmd As New MySqlCommand(query, Koneksi.conn)
                cmd.Parameters.AddWithValue("@user", TxtUsername.Text)
                cmd.Parameters.AddWithValue("@pass", TxtPassword.Text)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        ' 4. Simpan hasilnya ke variabel, JANGAN buka form dulu
                        loginBerhasil = True
                        userRole = reader.GetString("role")
                        namaPengguna = reader.GetString("nama")
                    Else
                        ' 7. Jika username atau password salah
                        MessageBox.Show("Username atau Password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using ' <-- DataReader (reader) DITUTUP di sini
            End Using ' <-- Command di-dispose di sini
        Catch ex As Exception
            ' 8. Jika terjadi error saat menjalankan query
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
              )
        Finally
            ' 9. Selalu tutup koneksi
            Koneksi.TutupKoneksi() ' <-- Koneksi DITUTUP di sini
        End Try


        ' 10. SETELAH KONEKSI & READER DITUTUP, baru kita buka form baru
        If loginBerhasil Then
            MessageBox.Show($"Selamat datang, {namaPengguna}!", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If userRole = "Admin" Then
                Dim frmDashboard As New DashBoard()
                frmDashboard.Show()
            ElseIf userRole = "Kasir" Then
                Dim frmTransaksi As New Transaksi() ' Pastikan nama Form-nya "Transaksi"
                frmTransaksi.Show()
            Else
                MessageBox.Show("Role Anda tidak dikenali.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ' Sembunyikan Form Login ini
            Me.Hide()
        End If

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
    Private Sub BtnLupaPwd_Click(sender As Object, e As EventArgs) Handles BtnLupaPwd.Click
        ' 1. Ambil username dari TxtUsername di form login
        Dim usernameYgAkanDireset As String = TxtUsername.Text

        ' 2. Buat instance (objek) dari form ResetPassword 
        Dim frmReset As New ResetPassword()

        ' 3. Kirim username ke form ResetPassword
        '    (Kita akan buat properti publik di ResetPassword.vb)
        frmReset.UsernameDariLogin = usernameYgAkanDireset

        ' 4. Tampilkan form ResetPassword
        '    Gunakan ShowDialog() agar form Login "terjeda"
        '    menunggu form ResetPassword ditutup.
        frmReset.ShowDialog()

        ' 5. Logika UPDATE database sudah TIDAK ADA di sini lagi.
        '    Semua pindah ke Form ResetPassword.
    End Sub



End Class
