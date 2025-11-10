Imports MySql.Data.MySqlClient

Public Class Login
    'Tombol Masuk
    Private Sub BtnMasuk_Click(sender As Object, e As EventArgs) Handles BtnMasuk.Click

        ' 1. Validasi Input Kosong
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

        ' Varibel input
        Dim loginBerhasil As Boolean = False
        Dim userRole As String = ""
        Dim namaPengguna As String = ""
        Dim idPenggunaLogin As Integer = 0 'Menyimpan Id pengguna yang login

        ' 2. Coba Buka Koneksi
        If Koneksi.BukaKoneksi() = False Then
            MessageBox.Show("Koneksi ke Database Gagal." & vbCrLf &
                            "Pastikan XAMPP sudah berjalan dan nama database benar.",
                            "Koneksi Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 3. Proses Login
        Try
            ' Ambil ID, Role, dan Nama
            Dim query As String = "SELECT id_pengguna, role, nama FROM pengguna WHERE username = @user AND pass = @pass"

            Using cmd As New MySqlCommand(query, Koneksi.conn)
                cmd.Parameters.AddWithValue("@user", TxtUsername.Text)
                cmd.Parameters.AddWithValue("@pass", TxtPassword.Text)

                Using reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.HasRows Then
                        reader.Read()
                        ' 3.1 Simpan hasilnya ke variabel
                        loginBerhasil = True
                        userRole = reader.GetString("role")
                        namaPengguna = reader.GetString("nama")
                        idPenggunaLogin = reader.GetInt32("id_pengguna") 'Simpan ID Pengguna
                    Else
                        ' 3.2 Jika username atau password salah
                        MessageBox.Show("Username atau Password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        TxtPassword.Clear()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' 3.3 Jika terjadi error saat menjalankan query
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' 3.4 Selalu tutup koneksi
            Koneksi.TutupKoneksi()
        End Try


        ' 4. Setelah login berhasil dan role sudah didapatkan
        If loginBerhasil Then
            MessageBox.Show($"Selamat datang, {namaPengguna}!", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' 4.1 Sembunyikan Form Login DULU
            Me.Hide()

            If userRole = "Admin" Then
                Dim frmDashboard As New DashBoard()
                frmDashboard.ShowDialog() ' Buka form Dashboard
            ElseIf userRole = "Kasir" Then
                Dim frmTransaksi As New Transaksi()
                frmTransaksi.IDPenggunaLogin = idPenggunaLogin  'KIRIM ID ke Form Transaksi
                frmTransaksi.ShowDialog() ' Buka Form Transaksi
            Else
                MessageBox.Show("Role Anda tidak dikenali.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            '5 Kosongkan password agar siap untuk login berikutnya
            TxtPassword.Clear()
            TxtUsername.Focus()

            '6 Tampilkan kembali Form Login
            Me.Show()
        End If

    End Sub

    'Tombol Keluar
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Dim result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit() 'Tinggal tutup aplikasi
        End If
    End Sub


    'Tombol Lupa Password / Mengganti password
    Private Sub BtnLupaPwd_Click(sender As Object, e As EventArgs) Handles BtnLupaPwd.Click
        ' 1. Ambil username dari TxtUsername di form login
        Dim usernameYgAkanDireset As String = TxtUsername.Text

        ' 2. Buat instance (objek) dari form ResetPassword dan buka formnya
        Dim frmReset As New ResetPassword()

        ' 3. Kirim username ke form ResetPassword
        frmReset.UsernameDariLogin = usernameYgAkanDireset

        ' 4. Tampilkan form ResetPassword
        frmReset.ShowDialog()
    End Sub

End Class