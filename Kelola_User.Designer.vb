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
        ColId = New DataGridViewTextBoxColumn()
        ColNama = New DataGridViewTextBoxColumn()
        ColTelp = New DataGridViewTextBoxColumn()
        ColRole = New DataGridViewTextBoxColumn()
        ColUsername = New DataGridViewTextBoxColumn()
        TxtTelepon = New TextBox()
        LblTitle = New Label()
        PanelHeader = New Panel()
        BtnKeluar = New Button()
        TxtNama = New TextBox()
        PanelFormCard = New Panel()
        BtnClear = New Button()
        LblID = New Label()
        LblNama = New Label()
        LblJenis = New Label()
        LblHarga = New Label()
        LblStok = New Label()
        LblCaptionUser = New Label()
        LblTotalAdmin = New Label()
        PanelCardUser = New Panel()
        Panel1 = New Panel()
        Label1 = New Label()
        LblTotalKasir = New Label()
        CType(DgvUser, ComponentModel.ISupportInitialize).BeginInit()
        PanelHeader.SuspendLayout()
        PanelFormCard.SuspendLayout()
        PanelCardUser.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Location = New Point(121, 39)
        TxtUsername.Margin = New Padding(5)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(497, 23)
        TxtUsername.TabIndex = 1
        ' 
        ' TxtPassword
        ' 
        TxtPassword.Location = New Point(121, 72)
        TxtPassword.Margin = New Padding(5)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.PasswordChar = "*"c
        TxtPassword.Size = New Size(497, 23)
        TxtPassword.TabIndex = 2
        ' 
        ' CmbRole
        ' 
        CmbRole.FormattingEnabled = True
        CmbRole.Location = New Point(121, 105)
        CmbRole.Margin = New Padding(5)
        CmbRole.Name = "CmbRole"
        CmbRole.Size = New Size(210, 23)
        CmbRole.TabIndex = 3
        ' 
        ' BtnHapusUser
        ' 
        BtnHapusUser.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        BtnHapusUser.Cursor = Cursors.Hand
        BtnHapusUser.FlatStyle = FlatStyle.Popup
        BtnHapusUser.Font = New Font("Segoe UI", 12F)
        BtnHapusUser.Location = New Point(432, 101)
        BtnHapusUser.Name = "BtnHapusUser"
        BtnHapusUser.Size = New Size(86, 60)
        BtnHapusUser.TabIndex = 13
        BtnHapusUser.Text = "Hapus"
        BtnHapusUser.UseVisualStyleBackColor = False
        ' 
        ' BtnTambahUser
        ' 
        BtnTambahUser.BackColor = Color.LightSkyBlue
        BtnTambahUser.Cursor = Cursors.Hand
        BtnTambahUser.FlatStyle = FlatStyle.Popup
        BtnTambahUser.Font = New Font("Segoe UI", 12F)
        BtnTambahUser.Location = New Point(339, 101)
        BtnTambahUser.Name = "BtnTambahUser"
        BtnTambahUser.Size = New Size(87, 60)
        BtnTambahUser.TabIndex = 12
        BtnTambahUser.Text = "Tambah"
        BtnTambahUser.UseVisualStyleBackColor = False
        ' 
        ' DgvUser
        ' 
        DgvUser.AllowUserToAddRows = False
        DgvUser.AllowUserToDeleteRows = False
        DgvUser.AllowUserToResizeColumns = False
        DgvUser.AllowUserToResizeRows = False
        DgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvUser.Columns.AddRange(New DataGridViewColumn() {ColId, ColNama, ColTelp, ColRole, ColUsername})
        DgvUser.Location = New Point(12, 223)
        DgvUser.Name = "DgvUser"
        DgvUser.ReadOnly = True
        DgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvUser.Size = New Size(776, 261)
        DgvUser.TabIndex = 11
        ' 
        ' ColId
        ' 
        ColId.HeaderText = "Id"
        ColId.MinimumWidth = 60
        ColId.Name = "ColId"
        ColId.ReadOnly = True
        ColId.Width = 60
        ' 
        ' ColNama
        ' 
        ColNama.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ColNama.HeaderText = "Nama Lengkap"
        ColNama.Name = "ColNama"
        ColNama.ReadOnly = True
        ' 
        ' ColTelp
        ' 
        ColTelp.HeaderText = "Telepon"
        ColTelp.MinimumWidth = 100
        ColTelp.Name = "ColTelp"
        ColTelp.ReadOnly = True
        ' 
        ' ColRole
        ' 
        ColRole.HeaderText = "Peran"
        ColRole.MinimumWidth = 80
        ColRole.Name = "ColRole"
        ColRole.ReadOnly = True
        ColRole.Width = 80
        ' 
        ' ColUsername
        ' 
        ColUsername.HeaderText = "Username"
        ColUsername.MinimumWidth = 130
        ColUsername.Name = "ColUsername"
        ColUsername.ReadOnly = True
        ColUsername.Width = 130
        ' 
        ' TxtTelepon
        ' 
        TxtTelepon.Location = New Point(121, 138)
        TxtTelepon.Margin = New Padding(5)
        TxtTelepon.Name = "TxtTelepon"
        TxtTelepon.Size = New Size(210, 23)
        TxtTelepon.TabIndex = 14
        ' 
        ' LblTitle
        ' 
        LblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        LblTitle.ForeColor = Color.White
        LblTitle.Location = New Point(3, -1)
        LblTitle.Name = "LblTitle"
        LblTitle.Size = New Size(400, 40)
        LblTitle.TabIndex = 0
        LblTitle.Text = "Kelola User"
        LblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PanelHeader
        ' 
        PanelHeader.BackColor = Color.FromArgb(CByte(37), CByte(99), CByte(235))
        PanelHeader.Controls.Add(BtnKeluar)
        PanelHeader.Controls.Add(LblTitle)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Location = New Point(0, 0)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Size = New Size(804, 39)
        PanelHeader.TabIndex = 15
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        BtnKeluar.Cursor = Cursors.Hand
        BtnKeluar.FlatStyle = FlatStyle.Popup
        BtnKeluar.Font = New Font("Segoe UI", 12F)
        BtnKeluar.Location = New Point(664, 3)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(137, 33)
        BtnKeluar.TabIndex = 18
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = False
        ' 
        ' TxtNama
        ' 
        TxtNama.Location = New Point(121, 6)
        TxtNama.Margin = New Padding(5)
        TxtNama.Name = "TxtNama"
        TxtNama.Size = New Size(497, 23)
        TxtNama.TabIndex = 16
        ' 
        ' PanelFormCard
        ' 
        PanelFormCard.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelFormCard.BorderStyle = BorderStyle.FixedSingle
        PanelFormCard.Controls.Add(BtnClear)
        PanelFormCard.Controls.Add(LblID)
        PanelFormCard.Controls.Add(TxtNama)
        PanelFormCard.Controls.Add(BtnHapusUser)
        PanelFormCard.Controls.Add(LblNama)
        PanelFormCard.Controls.Add(BtnTambahUser)
        PanelFormCard.Controls.Add(LblJenis)
        PanelFormCard.Controls.Add(TxtTelepon)
        PanelFormCard.Controls.Add(LblHarga)
        PanelFormCard.Controls.Add(LblStok)
        PanelFormCard.Controls.Add(CmbRole)
        PanelFormCard.Controls.Add(TxtPassword)
        PanelFormCard.Controls.Add(TxtUsername)
        PanelFormCard.Location = New Point(12, 45)
        PanelFormCard.Name = "PanelFormCard"
        PanelFormCard.Size = New Size(637, 172)
        PanelFormCard.TabIndex = 6
        ' 
        ' BtnClear
        ' 
        BtnClear.BackColor = Color.White
        BtnClear.Cursor = Cursors.Hand
        BtnClear.FlatStyle = FlatStyle.Popup
        BtnClear.Font = New Font("Segoe UI", 12F)
        BtnClear.Location = New Point(524, 101)
        BtnClear.Name = "BtnClear"
        BtnClear.Size = New Size(94, 60)
        BtnClear.TabIndex = 17
        BtnClear.Text = "Bersihkan"
        BtnClear.UseVisualStyleBackColor = False
        ' 
        ' LblID
        ' 
        LblID.AutoSize = True
        LblID.Font = New Font("Segoe UI", 9F)
        LblID.ForeColor = Color.DarkSlateGray
        LblID.Location = New Point(16, 9)
        LblID.Margin = New Padding(5)
        LblID.Name = "LblID"
        LblID.Size = New Size(87, 15)
        LblID.TabIndex = 0
        LblID.Text = "Nama Lengkap"
        ' 
        ' LblNama
        ' 
        LblNama.AutoSize = True
        LblNama.Font = New Font("Segoe UI", 9F)
        LblNama.ForeColor = Color.DarkSlateGray
        LblNama.Location = New Point(16, 42)
        LblNama.Margin = New Padding(5)
        LblNama.Name = "LblNama"
        LblNama.Size = New Size(60, 15)
        LblNama.TabIndex = 1
        LblNama.Text = "Username"
        ' 
        ' LblJenis
        ' 
        LblJenis.AutoSize = True
        LblJenis.Font = New Font("Segoe UI", 9F)
        LblJenis.ForeColor = Color.DarkSlateGray
        LblJenis.Location = New Point(16, 75)
        LblJenis.Margin = New Padding(5)
        LblJenis.Name = "LblJenis"
        LblJenis.Size = New Size(57, 15)
        LblJenis.TabIndex = 2
        LblJenis.Text = "Password"
        ' 
        ' LblHarga
        ' 
        LblHarga.AutoSize = True
        LblHarga.Font = New Font("Segoe UI", 9F)
        LblHarga.ForeColor = Color.DarkSlateGray
        LblHarga.Location = New Point(16, 141)
        LblHarga.Margin = New Padding(5)
        LblHarga.Name = "LblHarga"
        LblHarga.Size = New Size(49, 15)
        LblHarga.TabIndex = 3
        LblHarga.Text = "Telepon"
        ' 
        ' LblStok
        ' 
        LblStok.AutoSize = True
        LblStok.Font = New Font("Segoe UI", 9F)
        LblStok.ForeColor = Color.DarkSlateGray
        LblStok.Location = New Point(16, 108)
        LblStok.Margin = New Padding(5)
        LblStok.Name = "LblStok"
        LblStok.Size = New Size(37, 15)
        LblStok.TabIndex = 4
        LblStok.Text = "Peran"
        ' 
        ' LblCaptionUser
        ' 
        LblCaptionUser.AutoSize = True
        LblCaptionUser.Font = New Font("Segoe UI", 12F)
        LblCaptionUser.ForeColor = Color.DarkSlateGray
        LblCaptionUser.Location = New Point(4, 4)
        LblCaptionUser.Name = "LblCaptionUser"
        LblCaptionUser.Size = New Size(92, 21)
        LblCaptionUser.TabIndex = 0
        LblCaptionUser.Text = "Total Admin"
        ' 
        ' LblTotalAdmin
        ' 
        LblTotalAdmin.AutoSize = True
        LblTotalAdmin.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        LblTotalAdmin.ForeColor = Color.Maroon
        LblTotalAdmin.Location = New Point(8, 33)
        LblTotalAdmin.Name = "LblTotalAdmin"
        LblTotalAdmin.Size = New Size(33, 37)
        LblTotalAdmin.TabIndex = 1
        LblTotalAdmin.Text = "0"
        ' 
        ' PanelCardUser
        ' 
        PanelCardUser.BackColor = Color.MintCream
        PanelCardUser.BorderStyle = BorderStyle.FixedSingle
        PanelCardUser.Controls.Add(LblCaptionUser)
        PanelCardUser.Controls.Add(LblTotalAdmin)
        PanelCardUser.Location = New Point(655, 45)
        PanelCardUser.Name = "PanelCardUser"
        PanelCardUser.Size = New Size(133, 84)
        PanelCardUser.TabIndex = 16
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(LblTotalKasir)
        Panel1.Location = New Point(655, 135)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(133, 82)
        Panel1.TabIndex = 17
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(5, 5)
        Label1.Name = "Label1"
        Label1.Size = New Size(80, 21)
        Label1.TabIndex = 0
        Label1.Text = "Total Kasir"
        ' 
        ' LblTotalKasir
        ' 
        LblTotalKasir.AutoSize = True
        LblTotalKasir.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        LblTotalKasir.ForeColor = Color.Green
        LblTotalKasir.Location = New Point(8, 33)
        LblTotalKasir.Name = "LblTotalKasir"
        LblTotalKasir.Size = New Size(33, 37)
        LblTotalKasir.TabIndex = 1
        LblTotalKasir.Text = "0"
        ' 
        ' Kelola_User
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(804, 496)
        Controls.Add(Panel1)
        Controls.Add(PanelCardUser)
        Controls.Add(PanelFormCard)
        Controls.Add(PanelHeader)
        Controls.Add(DgvUser)
        Name = "Kelola_User"
        StartPosition = FormStartPosition.CenterParent
        Text = "Kelola_User"
        CType(DgvUser, ComponentModel.ISupportInitialize).EndInit()
        PanelHeader.ResumeLayout(False)
        PanelFormCard.ResumeLayout(False)
        PanelFormCard.PerformLayout()
        PanelCardUser.ResumeLayout(False)
        PanelCardUser.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents CmbRole As ComboBox
    Friend WithEvents BtnHapusUser As Button
    Friend WithEvents BtnTambahUser As Button
    Friend WithEvents DgvUser As DataGridView
    Friend WithEvents TxtTelepon As TextBox
    Friend WithEvents LblTitle As Label
    Friend WithEvents PanelHeader As Panel
    Friend WithEvents TxtNama As TextBox
    Friend WithEvents PanelFormCard As Panel
    Friend WithEvents LblID As Label
    Friend WithEvents LblNama As Label
    Friend WithEvents LblJenis As Label
    Friend WithEvents LblHarga As Label
    Friend WithEvents LblStok As Label
    Friend WithEvents LblCaptionUser As Label
    Friend WithEvents LblTotalAdmin As Label
    Friend WithEvents PanelCardUser As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LblTotalKasir As Label
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents ColId As DataGridViewTextBoxColumn
    Friend WithEvents ColNama As DataGridViewTextBoxColumn
    Friend WithEvents ColTelp As DataGridViewTextBoxColumn
    Friend WithEvents ColRole As DataGridViewTextBoxColumn
    Friend WithEvents ColUsername As DataGridViewTextBoxColumn
    Friend WithEvents BtnClear As Button
End Class
