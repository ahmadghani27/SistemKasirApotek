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
        LblTitle = New Label()
        PanelHeader = New Panel()
        TxtNama = New TextBox()
        PanelFormCard = New Panel()
        LblID = New Label()
        LblNama = New Label()
        LblJenis = New Label()
        LblHarga = New Label()
        LblStok = New Label()
        LblCaptionUser = New Label()
        LblTotalUser = New Label()
        PanelCardUser = New Panel()
        Panel1 = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        BtnKeluar = New Button()
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
        TxtUsername.Size = New Size(473, 23)
        TxtUsername.TabIndex = 1
        ' 
        ' TxtPassword
        ' 
        TxtPassword.Location = New Point(121, 72)
        TxtPassword.Margin = New Padding(5)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.Size = New Size(473, 23)
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
        BtnHapusUser.Location = New Point(389, 104)
        BtnHapusUser.Name = "BtnHapusUser"
        BtnHapusUser.Size = New Size(86, 57)
        BtnHapusUser.TabIndex = 13
        BtnHapusUser.Text = "Hapus"
        BtnHapusUser.UseVisualStyleBackColor = True
        ' 
        ' BtnTambahUser
        ' 
        BtnTambahUser.Location = New Point(481, 103)
        BtnTambahUser.Name = "BtnTambahUser"
        BtnTambahUser.Size = New Size(113, 58)
        BtnTambahUser.TabIndex = 12
        BtnTambahUser.Text = "Tambah"
        BtnTambahUser.UseVisualStyleBackColor = True
        ' 
        ' DgvUser
        ' 
        DgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvUser.Location = New Point(12, 257)
        DgvUser.Name = "DgvUser"
        DgvUser.Size = New Size(776, 181)
        DgvUser.TabIndex = 11
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
        LblTitle.Location = New Point(12, 12)
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
        PanelHeader.Size = New Size(800, 64)
        PanelHeader.TabIndex = 15
        ' 
        ' TxtNama
        ' 
        TxtNama.Location = New Point(121, 6)
        TxtNama.Margin = New Padding(5)
        TxtNama.Name = "TxtNama"
        TxtNama.Size = New Size(473, 23)
        TxtNama.TabIndex = 16
        ' 
        ' PanelFormCard
        ' 
        PanelFormCard.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelFormCard.BorderStyle = BorderStyle.FixedSingle
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
        PanelFormCard.Location = New Point(12, 79)
        PanelFormCard.Name = "PanelFormCard"
        PanelFormCard.Size = New Size(613, 172)
        PanelFormCard.TabIndex = 6
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
        LblNama.Size = New Size(68, 15)
        LblNama.TabIndex = 1
        LblNama.Text = "Nama Obat"
        ' 
        ' LblJenis
        ' 
        LblJenis.AutoSize = True
        LblJenis.Font = New Font("Segoe UI", 9F)
        LblJenis.ForeColor = Color.DarkSlateGray
        LblJenis.Location = New Point(16, 75)
        LblJenis.Margin = New Padding(5)
        LblJenis.Name = "LblJenis"
        LblJenis.Size = New Size(32, 15)
        LblJenis.TabIndex = 2
        LblJenis.Text = "Jenis"
        ' 
        ' LblHarga
        ' 
        LblHarga.AutoSize = True
        LblHarga.Font = New Font("Segoe UI", 9F)
        LblHarga.ForeColor = Color.DarkSlateGray
        LblHarga.Location = New Point(16, 141)
        LblHarga.Margin = New Padding(5)
        LblHarga.Name = "LblHarga"
        LblHarga.Size = New Size(39, 15)
        LblHarga.TabIndex = 3
        LblHarga.Text = "Harga"
        ' 
        ' LblStok
        ' 
        LblStok.AutoSize = True
        LblStok.Font = New Font("Segoe UI", 9F)
        LblStok.ForeColor = Color.DarkSlateGray
        LblStok.Location = New Point(16, 108)
        LblStok.Margin = New Padding(5)
        LblStok.Name = "LblStok"
        LblStok.Size = New Size(30, 15)
        LblStok.TabIndex = 4
        LblStok.Text = "Stok"
        ' 
        ' LblCaptionUser
        ' 
        LblCaptionUser.AutoSize = True
        LblCaptionUser.Font = New Font("Segoe UI", 9F)
        LblCaptionUser.ForeColor = Color.DarkSlateGray
        LblCaptionUser.Location = New Point(12, 12)
        LblCaptionUser.Name = "LblCaptionUser"
        LblCaptionUser.Size = New Size(72, 15)
        LblCaptionUser.TabIndex = 0
        LblCaptionUser.Text = "Total Admin"
        ' 
        ' LblTotalUser
        ' 
        LblTotalUser.AutoSize = True
        LblTotalUser.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        LblTotalUser.ForeColor = Color.Black
        LblTotalUser.Location = New Point(12, 30)
        LblTotalUser.Name = "LblTotalUser"
        LblTotalUser.Size = New Size(33, 37)
        LblTotalUser.TabIndex = 1
        LblTotalUser.Text = "0"
        ' 
        ' PanelCardUser
        ' 
        PanelCardUser.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelCardUser.BorderStyle = BorderStyle.FixedSingle
        PanelCardUser.Controls.Add(LblCaptionUser)
        PanelCardUser.Controls.Add(LblTotalUser)
        PanelCardUser.Location = New Point(631, 79)
        PanelCardUser.Name = "PanelCardUser"
        PanelCardUser.Size = New Size(157, 84)
        PanelCardUser.TabIndex = 16
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(631, 169)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(157, 82)
        Panel1.TabIndex = 17
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F)
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(12, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(61, 15)
        Label1.TabIndex = 0
        Label1.Text = "Total Kasir"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(12, 30)
        Label2.Name = "Label2"
        Label2.Size = New Size(33, 37)
        Label2.TabIndex = 1
        Label2.Text = "0"
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.Location = New Point(720, 12)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(68, 40)
        BtnKeluar.TabIndex = 18
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = True
        ' 
        ' Kelola_User
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Panel1)
        Controls.Add(PanelCardUser)
        Controls.Add(PanelFormCard)
        Controls.Add(PanelHeader)
        Controls.Add(DgvUser)
        Name = "Kelola_User"
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
    Friend WithEvents LblTotalUser As Label
    Friend WithEvents PanelCardUser As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnKeluar As Button
End Class
