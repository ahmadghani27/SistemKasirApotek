<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TxtUsername = New TextBox()
        TxtPassword = New TextBox()
        BtnKeluar = New Button()
        BtnMasuk = New Button()
        BtnLupaPwd = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(41, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(408, 30)
        Label1.TabIndex = 0
        Label1.Text = "Sistem Administrasi Apotek Obat-Obatan"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(21, 71)
        Label3.Name = "Label3"
        Label3.Size = New Size(81, 21)
        Label3.TabIndex = 2
        Label3.Text = "Username"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(21, 103)
        Label4.Name = "Label4"
        Label4.Size = New Size(76, 21)
        Label4.TabIndex = 3
        Label4.Text = "Password"
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Font = New Font("Segoe UI", 12F)
        TxtUsername.Location = New Point(139, 68)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(333, 29)
        TxtUsername.TabIndex = 4
        ' 
        ' TxtPassword
        ' 
        TxtPassword.Font = New Font("Segoe UI", 12F)
        TxtPassword.Location = New Point(139, 100)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.PasswordChar = "*"c
        TxtPassword.Size = New Size(263, 29)
        TxtPassword.TabIndex = 5
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        BtnKeluar.Cursor = Cursors.Hand
        BtnKeluar.FlatStyle = FlatStyle.Popup
        BtnKeluar.Font = New Font("Segoe UI", 12F)
        BtnKeluar.Location = New Point(21, 170)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(218, 38)
        BtnKeluar.TabIndex = 6
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = False
        ' 
        ' BtnMasuk
        ' 
        BtnMasuk.BackColor = Color.LightSkyBlue
        BtnMasuk.Cursor = Cursors.Hand
        BtnMasuk.FlatStyle = FlatStyle.Popup
        BtnMasuk.Font = New Font("Segoe UI", 12F)
        BtnMasuk.Location = New Point(259, 170)
        BtnMasuk.Name = "BtnMasuk"
        BtnMasuk.Size = New Size(213, 38)
        BtnMasuk.TabIndex = 7
        BtnMasuk.Text = "Masuk"
        BtnMasuk.UseVisualStyleBackColor = False
        ' 
        ' BtnLupaPwd
        ' 
        BtnLupaPwd.BackColor = Color.WhiteSmoke
        BtnLupaPwd.BackgroundImageLayout = ImageLayout.Center
        BtnLupaPwd.Cursor = Cursors.Hand
        BtnLupaPwd.FlatStyle = FlatStyle.Popup
        BtnLupaPwd.Font = New Font("Segoe UI", 9F)
        BtnLupaPwd.Location = New Point(408, 103)
        BtnLupaPwd.Name = "BtnLupaPwd"
        BtnLupaPwd.Size = New Size(64, 26)
        BtnLupaPwd.TabIndex = 8
        BtnLupaPwd.Text = "lupa?"
        BtnLupaPwd.UseVisualStyleBackColor = False
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(493, 231)
        Controls.Add(BtnLupaPwd)
        Controls.Add(BtnMasuk)
        Controls.Add(BtnKeluar)
        Controls.Add(TxtPassword)
        Controls.Add(TxtUsername)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents BtnMasuk As Button
    Friend WithEvents BtnLupaPwd As Button
End Class
