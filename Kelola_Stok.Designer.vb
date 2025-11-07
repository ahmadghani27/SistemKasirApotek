<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Kelola_Stok
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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

    ' NOTE: The following procedure is required by the Windows Form Designer
    ' It can be modified using the Windows Form Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PanelHeader = New Panel()
        LblTitle = New Label()
        PanelFormCard = New Panel()
        LblID = New Label()
        TxtIDObat = New TextBox()
        LblNama = New Label()
        TxtNamaObat = New TextBox()
        LblJenis = New Label()
        CmbJenis = New ComboBox()
        LblHarga = New Label()
        TxtHarga = New TextBox()
        LblStok = New Label()
        TxtStok = New TextBox()
        LblKadaluarsa = New Label()
        DtpKadaluarsa = New DateTimePicker()
        PanelActions = New Panel()
        BtnTambah = New Button()
        BtnUbah = New Button()
        BtnHapus = New Button()
        BtnBersih = New Button()
        DgvObat = New DataGridView()
        BtnKeluar = New Button()
        PanelHeader.SuspendLayout()
        PanelFormCard.SuspendLayout()
        PanelActions.SuspendLayout()
        CType(DgvObat, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PanelHeader
        ' 
        PanelHeader.BackColor = Color.FromArgb(CByte(37), CByte(99), CByte(235))
        PanelHeader.Controls.Add(BtnKeluar)
        PanelHeader.Controls.Add(LblTitle)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Location = New Point(0, 0)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Size = New Size(804, 64)
        PanelHeader.TabIndex = 13
        ' 
        ' LblTitle
        ' 
        LblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        LblTitle.ForeColor = Color.White
        LblTitle.Location = New Point(12, 12)
        LblTitle.Name = "LblTitle"
        LblTitle.Size = New Size(400, 40)
        LblTitle.TabIndex = 0
        LblTitle.Text = "Kelola Stok Obat"
        LblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PanelFormCard
        ' 
        PanelFormCard.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelFormCard.BorderStyle = BorderStyle.FixedSingle
        PanelFormCard.Controls.Add(LblID)
        PanelFormCard.Controls.Add(TxtIDObat)
        PanelFormCard.Controls.Add(LblNama)
        PanelFormCard.Controls.Add(TxtNamaObat)
        PanelFormCard.Controls.Add(LblJenis)
        PanelFormCard.Controls.Add(CmbJenis)
        PanelFormCard.Controls.Add(LblHarga)
        PanelFormCard.Controls.Add(TxtHarga)
        PanelFormCard.Controls.Add(LblStok)
        PanelFormCard.Controls.Add(TxtStok)
        PanelFormCard.Controls.Add(LblKadaluarsa)
        PanelFormCard.Controls.Add(DtpKadaluarsa)
        PanelFormCard.Location = New Point(12, 84)
        PanelFormCard.Name = "PanelFormCard"
        PanelFormCard.Size = New Size(588, 280)
        PanelFormCard.TabIndex = 12
        ' 
        ' LblID
        ' 
        LblID.AutoSize = True
        LblID.Font = New Font("Segoe UI", 9F)
        LblID.ForeColor = Color.DarkSlateGray
        LblID.Location = New Point(16, 16)
        LblID.Name = "LblID"
        LblID.Size = New Size(47, 15)
        LblID.TabIndex = 0
        LblID.Text = "ID Obat"
        ' 
        ' TxtIDObat
        ' 
        TxtIDObat.Location = New Point(16, 36)
        TxtIDObat.Name = "TxtIDObat"
        TxtIDObat.Size = New Size(532, 23)
        TxtIDObat.TabIndex = 0
        ' 
        ' LblNama
        ' 
        LblNama.AutoSize = True
        LblNama.Font = New Font("Segoe UI", 9F)
        LblNama.ForeColor = Color.DarkSlateGray
        LblNama.Location = New Point(16, 72)
        LblNama.Name = "LblNama"
        LblNama.Size = New Size(68, 15)
        LblNama.TabIndex = 1
        LblNama.Text = "Nama Obat"
        ' 
        ' TxtNamaObat
        ' 
        TxtNamaObat.Location = New Point(16, 92)
        TxtNamaObat.Name = "TxtNamaObat"
        TxtNamaObat.Size = New Size(532, 23)
        TxtNamaObat.TabIndex = 1
        ' 
        ' LblJenis
        ' 
        LblJenis.AutoSize = True
        LblJenis.Font = New Font("Segoe UI", 9F)
        LblJenis.ForeColor = Color.DarkSlateGray
        LblJenis.Location = New Point(16, 128)
        LblJenis.Name = "LblJenis"
        LblJenis.Size = New Size(32, 15)
        LblJenis.TabIndex = 2
        LblJenis.Text = "Jenis"
        ' 
        ' CmbJenis
        ' 
        CmbJenis.DropDownStyle = ComboBoxStyle.DropDownList
        CmbJenis.FormattingEnabled = True
        CmbJenis.Location = New Point(16, 148)
        CmbJenis.Name = "CmbJenis"
        CmbJenis.Size = New Size(180, 23)
        CmbJenis.TabIndex = 2
        ' 
        ' LblHarga
        ' 
        LblHarga.AutoSize = True
        LblHarga.Font = New Font("Segoe UI", 9F)
        LblHarga.ForeColor = Color.DarkSlateGray
        LblHarga.Location = New Point(212, 128)
        LblHarga.Name = "LblHarga"
        LblHarga.Size = New Size(39, 15)
        LblHarga.TabIndex = 3
        LblHarga.Text = "Harga"
        ' 
        ' TxtHarga
        ' 
        TxtHarga.Location = New Point(212, 148)
        TxtHarga.Name = "TxtHarga"
        TxtHarga.Size = New Size(184, 23)
        TxtHarga.TabIndex = 3
        ' 
        ' LblStok
        ' 
        LblStok.AutoSize = True
        LblStok.Font = New Font("Segoe UI", 9F)
        LblStok.ForeColor = Color.DarkSlateGray
        LblStok.Location = New Point(16, 184)
        LblStok.Name = "LblStok"
        LblStok.Size = New Size(30, 15)
        LblStok.TabIndex = 4
        LblStok.Text = "Stok"
        ' 
        ' TxtStok
        ' 
        TxtStok.Location = New Point(16, 204)
        TxtStok.Name = "TxtStok"
        TxtStok.Size = New Size(180, 23)
        TxtStok.TabIndex = 4
        ' 
        ' LblKadaluarsa
        ' 
        LblKadaluarsa.AutoSize = True
        LblKadaluarsa.Font = New Font("Segoe UI", 9F)
        LblKadaluarsa.ForeColor = Color.DarkSlateGray
        LblKadaluarsa.Location = New Point(212, 184)
        LblKadaluarsa.Name = "LblKadaluarsa"
        LblKadaluarsa.Size = New Size(64, 15)
        LblKadaluarsa.TabIndex = 5
        LblKadaluarsa.Text = "Kadaluarsa"
        ' 
        ' DtpKadaluarsa
        ' 
        DtpKadaluarsa.Format = DateTimePickerFormat.Short
        DtpKadaluarsa.Location = New Point(212, 204)
        DtpKadaluarsa.Name = "DtpKadaluarsa"
        DtpKadaluarsa.Size = New Size(184, 23)
        DtpKadaluarsa.TabIndex = 5
        ' 
        ' PanelActions
        ' 
        PanelActions.Controls.Add(BtnTambah)
        PanelActions.Controls.Add(BtnUbah)
        PanelActions.Controls.Add(BtnHapus)
        PanelActions.Controls.Add(BtnBersih)
        PanelActions.Location = New Point(630, 84)
        PanelActions.Name = "PanelActions"
        PanelActions.Size = New Size(158, 280)
        PanelActions.TabIndex = 11
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Location = New Point(16, 16)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(124, 36)
        BtnTambah.TabIndex = 6
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = True
        ' 
        ' BtnUbah
        ' 
        BtnUbah.Location = New Point(16, 64)
        BtnUbah.Name = "BtnUbah"
        BtnUbah.Size = New Size(124, 36)
        BtnUbah.TabIndex = 7
        BtnUbah.Text = "Ubah"
        BtnUbah.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Location = New Point(16, 112)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(124, 36)
        BtnHapus.TabIndex = 8
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' BtnBersih
        ' 
        BtnBersih.Location = New Point(16, 160)
        BtnBersih.Name = "BtnBersih"
        BtnBersih.Size = New Size(124, 36)
        BtnBersih.TabIndex = 9
        BtnBersih.Text = "Bersih"
        BtnBersih.UseVisualStyleBackColor = True
        ' 
        ' DgvObat
        ' 
        DgvObat.AllowUserToAddRows = False
        DgvObat.AllowUserToDeleteRows = False
        DgvObat.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvObat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgvObat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvObat.Location = New Point(12, 380)
        DgvObat.MultiSelect = False
        DgvObat.Name = "DgvObat"
        DgvObat.ReadOnly = True
        DgvObat.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvObat.Size = New Size(776, 240)
        DgvObat.TabIndex = 10
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.Location = New Point(724, 12)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(68, 40)
        BtnKeluar.TabIndex = 3
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = True
        ' 
        ' Kelola_Stok
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(804, 640)
        Controls.Add(DgvObat)
        Controls.Add(PanelActions)
        Controls.Add(PanelFormCard)
        Controls.Add(PanelHeader)
        MinimumSize = New Size(820, 520)
        Name = "Kelola_Stok"
        StartPosition = FormStartPosition.CenterParent
        Text = "Kelola Stok Obat"
        PanelHeader.ResumeLayout(False)
        PanelFormCard.ResumeLayout(False)
        PanelFormCard.PerformLayout()
        PanelActions.ResumeLayout(False)
        CType(DgvObat, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents LblTitle As Label
    Friend WithEvents PanelFormCard As Panel
    Friend WithEvents LblID As Label
    Friend WithEvents TxtIDObat As TextBox
    Friend WithEvents LblNama As Label
    Friend WithEvents TxtNamaObat As TextBox
    Friend WithEvents LblJenis As Label
    Friend WithEvents CmbJenis As ComboBox
    Friend WithEvents LblHarga As Label
    Friend WithEvents TxtHarga As TextBox
    Friend WithEvents LblStok As Label
    Friend WithEvents TxtStok As TextBox
    Friend WithEvents LblKadaluarsa As Label
    Friend WithEvents DtpKadaluarsa As DateTimePicker
    Friend WithEvents PanelActions As Panel
    Friend WithEvents BtnTambah As Button
    Friend WithEvents BtnUbah As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnBersih As Button
    Friend WithEvents DgvObat As DataGridView
    Friend WithEvents BtnKeluar As Button
End Class