<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResetPassword
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
        BtnKembali = New Button()
        BtnReset = New Button()
        TxtPasswordBaru = New TextBox()
        TxtUsername = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TxtKonfirmasiPassword = New TextBox()
        Label5 = New Label()
        SuspendLayout()
        ' 
        ' BtnKembali
        ' 
        BtnKembali.Font = New Font("Segoe UI", 12F)
        BtnKembali.Location = New Point(211, 236)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(213, 38)
        BtnKembali.TabIndex = 20
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Segoe UI", 12F)
        BtnReset.Location = New Point(430, 236)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(218, 38)
        BtnReset.TabIndex = 19
        BtnReset.Text = "Reset"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' TxtPasswordBaru
        ' 
        TxtPasswordBaru.Font = New Font("Segoe UI", 12F)
        TxtPasswordBaru.Location = New Point(315, 141)
        TxtPasswordBaru.Name = "TxtPasswordBaru"
        TxtPasswordBaru.Size = New Size(333, 29)
        TxtPasswordBaru.TabIndex = 14
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Font = New Font("Segoe UI", 12F)
        TxtUsername.Location = New Point(315, 109)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(333, 29)
        TxtUsername.TabIndex = 13
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(134, 144)
        Label4.Name = "Label4"
        Label4.Size = New Size(76, 21)
        Label4.TabIndex = 12
        Label4.Text = "Password"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(134, 112)
        Label3.Name = "Label3"
        Label3.Size = New Size(81, 21)
        Label3.TabIndex = 11
        Label3.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(348, 67)
        Label2.Name = "Label2"
        Label2.Size = New Size(114, 21)
        Label2.TabIndex = 10
        Label2.Text = "Lupa Password"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(202, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(408, 30)
        Label1.TabIndex = 9
        Label1.Text = "Sistem Administrasi Apotek Obat-Obatan"
        ' 
        ' TxtKonfirmasiPassword
        ' 
        TxtKonfirmasiPassword.Font = New Font("Segoe UI", 12F)
        TxtKonfirmasiPassword.Location = New Point(315, 176)
        TxtKonfirmasiPassword.Name = "TxtKonfirmasiPassword"
        TxtKonfirmasiPassword.Size = New Size(333, 29)
        TxtKonfirmasiPassword.TabIndex = 18
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(134, 179)
        Label5.Name = "Label5"
        Label5.Size = New Size(155, 21)
        Label5.TabIndex = 17
        Label5.Text = "Konfirmasi Password"
        ' 
        ' ResetPassword
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TxtKonfirmasiPassword)
        Controls.Add(Label5)
        Controls.Add(BtnKembali)
        Controls.Add(BtnReset)
        Controls.Add(TxtPasswordBaru)
        Controls.Add(TxtUsername)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "ResetPassword"
        Text = "Register"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents BtnKembali As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents TxtPasswordBaru As TextBox
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtKonfirmasiPassword As TextBox
    Friend WithEvents Label5 As Label
End Class
