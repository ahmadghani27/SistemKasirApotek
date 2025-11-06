' Impor library MySQL yang diperlukan
Imports MySql.Data.MySqlClient

Public Class Login

    ' ... (Kode BtnMasuk_Click dan BtnKeluar_Click tetap sama) ...
    ' ... (Saya tidak salin ulang agar tidak terlalu panjang) ...

    ' ====================================================================
    ' PERUBAHAN DI SINI
    ' ====================================================================

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