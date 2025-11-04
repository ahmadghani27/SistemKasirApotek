<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kelola_User
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
        TxtUsername = New TextBox()
        TxtPassword = New TextBox()
        CmbRole = New ComboBox()
        BtnHapusUser = New Button()
        BtnTambahUser = New Button()
        DgvUser = New DataGridView()
        TxtTelepon = New TextBox()
        CType(DgvUser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Location = New Point(36, 29)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(100, 23)
        TxtUsername.TabIndex = 1
        ' 
        ' TxtPassword
        ' 
        TxtPassword.Location = New Point(36, 58)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.Size = New Size(100, 23)
        TxtPassword.TabIndex = 2
        ' 
        ' CmbRole
        ' 
        CmbRole.FormattingEnabled = True
        CmbRole.Location = New Point(26, 164)
        CmbRole.Name = "CmbRole"
        CmbRole.Size = New Size(121, 23)
        CmbRole.TabIndex = 3
        ' 
        ' BtnHapusUser
        ' 
        BtnHapusUser.Location = New Point(506, 109)
        BtnHapusUser.Name = "BtnHapusUser"
        BtnHapusUser.Size = New Size(75, 23)
        BtnHapusUser.TabIndex = 13
        BtnHapusUser.Text = "Hapus"
        BtnHapusUser.UseVisualStyleBackColor = True
        ' 
        ' BtnTambahUser
        ' 
        BtnTambahUser.Location = New Point(506, 80)
        BtnTambahUser.Name = "BtnTambahUser"
        BtnTambahUser.Size = New Size(75, 23)
        BtnTambahUser.TabIndex = 12
        BtnTambahUser.Text = "Tambah"
        BtnTambahUser.UseVisualStyleBackColor = True
        ' 
        ' DgvUser
        ' 
        DgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvUser.Location = New Point(220, 221)
        DgvUser.Name = "DgvUser"
        DgvUser.Size = New Size(240, 150)
        DgvUser.TabIndex = 11
        ' 
        ' TxtTelepon
        ' 
        TxtTelepon.Location = New Point(36, 87)
        TxtTelepon.Name = "TxtTelepon"
        TxtTelepon.Size = New Size(100, 23)
        TxtTelepon.TabIndex = 14
        ' 
        ' Kelola_User
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TxtTelepon)
        Controls.Add(BtnHapusUser)
        Controls.Add(BtnTambahUser)
        Controls.Add(DgvUser)
        Controls.Add(CmbRole)
        Controls.Add(TxtPassword)
        Controls.Add(TxtUsername)
        Name = "Kelola_User"
        Text = "Kelola_User"
        CType(DgvUser, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents CmbRole As ComboBox
    Friend WithEvents BtnHapusUser As Button
    Friend WithEvents BtnTambahUser As Button
    Friend WithEvents DgvUser As DataGridView
    Friend WithEvents TxtTelepon As TextBox
End Class
