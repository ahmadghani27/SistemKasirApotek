<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashBoard
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

    ' NOTE: The following procedure is required by the Windows Form Designer
    ' It can be modified using the Windows Form Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PanelHeader = New Panel()
        LblTitle = New Label()
        PanelCardObat = New Panel()
        LblCaptionObat = New Label()
        LblTotalObat = New Label()
        PanelCardTransaksi = New Panel()
        LblCaptionTransaksi = New Label()
        LblTotalTransaksi = New Label()
        PanelCardUser = New Panel()
        LblCaptionUser = New Label()
        LblTotalUser = New Label()
        GroupBoxActions = New GroupBox()
        BtnKelolaStok = New Button()
        BtnKelolaUser = New Button()
        BtnKeluar = New Button()
        GroupBoxFilter = New GroupBox()
        CmbFilterKategori = New ComboBox()
        TxtFilterKataKunci = New TextBox()
        BtnFilter = New Button()
        BtnTampilSemua = New Button()
        DgvRiwayatTransaksi = New DataGridView()
        CType(DgvRiwayatTransaksi, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PanelHeader
        ' 
        PanelHeader.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Height = 64
        PanelHeader.Controls.Add(LblTitle)
        ' 
        ' LblTitle
        ' 
        LblTitle.ForeColor = System.Drawing.Color.White
        LblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold, GraphicsUnit.Point)
        LblTitle.Location = New Point(12, 12)
        LblTitle.Name = "LblTitle"
        LblTitle.Size = New Size(400, 40)
        LblTitle.Text = "Dashboard"
        LblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PanelCardObat
        ' 
        PanelCardObat.BackColor = System.Drawing.Color.FromArgb(249, 250, 251)
        PanelCardObat.BorderStyle = BorderStyle.FixedSingle
        PanelCardObat.Location = New Point(12, 84)
        PanelCardObat.Name = "PanelCardObat"
        PanelCardObat.Size = New Size(220, 90)
        PanelCardObat.Controls.Add(LblCaptionObat)
        PanelCardObat.Controls.Add(LblTotalObat)
        ' 
        ' LblCaptionObat
        ' 
        LblCaptionObat.AutoSize = True
        LblCaptionObat.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
        LblCaptionObat.ForeColor = System.Drawing.Color.DarkSlateGray
        LblCaptionObat.Location = New Point(12, 12)
        LblCaptionObat.Name = "LblCaptionObat"
        LblCaptionObat.Size = New Size(62, 15)
        LblCaptionObat.Text = "Total Obat"
        ' 
        ' LblTotalObat
        ' 
        LblTotalObat.AutoSize = True
        LblTotalObat.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold, GraphicsUnit.Point)
        LblTotalObat.ForeColor = System.Drawing.Color.Black
        LblTotalObat.Location = New Point(12, 30)
        LblTotalObat.Name = "LblTotalObat"
        LblTotalObat.Size = New Size(60, 37)
        LblTotalObat.Text = "0"
        ' 
        ' PanelCardTransaksi
        ' 
        PanelCardTransaksi.BackColor = System.Drawing.Color.FromArgb(249, 250, 251)
        PanelCardTransaksi.BorderStyle = BorderStyle.FixedSingle
        PanelCardTransaksi.Location = New Point(248, 84)
        PanelCardTransaksi.Name = "PanelCardTransaksi"
        PanelCardTransaksi.Size = New Size(220, 90)
        PanelCardTransaksi.Controls.Add(LblCaptionTransaksi)
        PanelCardTransaksi.Controls.Add(LblTotalTransaksi)
        ' 
        ' LblCaptionTransaksi
        ' 
        LblCaptionTransaksi.AutoSize = True
        LblCaptionTransaksi.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
        LblCaptionTransaksi.ForeColor = System.Drawing.Color.DarkSlateGray
        LblCaptionTransaksi.Location = New Point(12, 12)
        LblCaptionTransaksi.Name = "LblCaptionTransaksi"
        LblCaptionTransaksi.Size = New Size(99, 15)
        LblCaptionTransaksi.Text = "Transaksi Hari Ini"
        ' 
        ' LblTotalTransaksi
        ' 
        LblTotalTransaksi.AutoSize = True
        LblTotalTransaksi.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold, GraphicsUnit.Point)
        LblTotalTransaksi.ForeColor = System.Drawing.Color.Black
        LblTotalTransaksi.Location = New Point(12, 30)
        LblTotalTransaksi.Name = "LblTotalTransaksi"
        LblTotalTransaksi.Size = New Size(60, 37)
        LblTotalTransaksi.Text = "0"
        ' 
        ' PanelCardUser
        ' 
        PanelCardUser.BackColor = System.Drawing.Color.FromArgb(249, 250, 251)
        PanelCardUser.BorderStyle = BorderStyle.FixedSingle
        PanelCardUser.Location = New Point(484, 84)
        PanelCardUser.Name = "PanelCardUser"
        PanelCardUser.Size = New Size(220, 90)
        PanelCardUser.Controls.Add(LblCaptionUser)
        PanelCardUser.Controls.Add(LblTotalUser)
        ' 
        ' LblCaptionUser
        ' 
        LblCaptionUser.AutoSize = True
        LblCaptionUser.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
        LblCaptionUser.ForeColor = System.Drawing.Color.DarkSlateGray
        LblCaptionUser.Location = New Point(12, 12)
        LblCaptionUser.Name = "LblCaptionUser"
        LblCaptionUser.Size = New Size(71, 15)
        LblCaptionUser.Text = "Total Kasir"
        ' 
        ' LblTotalUser
        ' 
        LblTotalUser.AutoSize = True
        LblTotalUser.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold, GraphicsUnit.Point)
        LblTotalUser.ForeColor = System.Drawing.Color.Black
        LblTotalUser.Location = New Point(12, 30)
        LblTotalUser.Name = "LblTotalUser"
        LblTotalUser.Size = New Size(60, 37)
        LblTotalUser.Text = "0"
        ' 
        ' GroupBoxActions
        ' 
        GroupBoxActions.Location = New Point(720, 84)
        GroupBoxActions.Name = "GroupBoxActions"
        GroupBoxActions.Size = New Size(68, 190)
        GroupBoxActions.Text = "Aksi"
        GroupBoxActions.Controls.Add(BtnKeluar)
        GroupBoxActions.Controls.Add(BtnKelolaUser)
        GroupBoxActions.Controls.Add(BtnKelolaStok)
        ' 
        ' BtnKelolaStok
        ' 
        BtnKelolaStok.Location = New Point(6, 22)
        BtnKelolaStok.Name = "BtnKelolaStok"
        BtnKelolaStok.Size = New Size(56, 28)
        BtnKelolaStok.TabIndex = 0
        BtnKelolaStok.Text = "Stok"
        BtnKelolaStok.UseVisualStyleBackColor = True
        ' 
        ' BtnKelolaUser
        ' 
        BtnKelolaUser.Location = New Point(6, 56)
        BtnKelolaUser.Name = "BtnKelolaUser"
        BtnKelolaUser.Size = New Size(56, 28)
        BtnKelolaUser.TabIndex = 1
        BtnKelolaUser.Text = "User"
        BtnKelolaUser.UseVisualStyleBackColor = True
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.Location = New Point(6, 90)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(56, 28)
        BtnKeluar.TabIndex = 2
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxFilter
        ' 
        GroupBoxFilter.Location = New Point(12, 190)
        GroupBoxFilter.Name = "GroupBoxFilter"
        GroupBoxFilter.Size = New Size(692, 68)
        GroupBoxFilter.Text = "Filter Riwayat Transaksi"
        GroupBoxFilter.Controls.Add(CmbFilterKategori)
        GroupBoxFilter.Controls.Add(TxtFilterKataKunci)
        GroupBoxFilter.Controls.Add(BtnFilter)
        GroupBoxFilter.Controls.Add(BtnTampilSemua)
        ' 
        ' CmbFilterKategori
        ' 
        CmbFilterKategori.FormattingEnabled = True
        CmbFilterKategori.Location = New Point(12, 28)
        CmbFilterKategori.Name = "CmbFilterKategori"
        CmbFilterKategori.Size = New Size(160, 23)
        CmbFilterKategori.TabIndex = 0
        ' 
        ' TxtFilterKataKunci
        ' 
        TxtFilterKataKunci.Location = New Point(188, 28)
        TxtFilterKataKunci.Name = "TxtFilterKataKunci"
        TxtFilterKataKunci.Size = New Size(260, 23)
        TxtFilterKataKunci.TabIndex = 1
        ' 
        ' BtnFilter
        ' 
        BtnFilter.Location = New Point(464, 26)
        BtnFilter.Name = "BtnFilter"
        BtnFilter.Size = New Size(100, 26)
        BtnFilter.TabIndex = 2
        BtnFilter.Text = "Filter"
        BtnFilter.UseVisualStyleBackColor = True
        ' 
        ' BtnTampilSemua
        ' 
        BtnTampilSemua.Location = New Point(570, 26)
        BtnTampilSemua.Name = "BtnTampilSemua"
        BtnTampilSemua.Size = New Size(100, 26)
        BtnTampilSemua.TabIndex = 3
        BtnTampilSemua.Text = "Tampilkan Semua"
        BtnTampilSemua.UseVisualStyleBackColor = True
        ' 
        ' DgvRiwayatTransaksi
        ' 
        DgvRiwayatTransaksi.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvRiwayatTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvRiwayatTransaksi.Location = New Point(12, 270)
        DgvRiwayatTransaksi.Name = "DgvRiwayatTransaksi"
        DgvRiwayatTransaksi.Size = New Size(776, 168)
        DgvRiwayatTransaksi.TabIndex = 10
        ' 
        ' DashBoard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(DgvRiwayatTransaksi)
        Controls.Add(GroupBoxFilter)
        Controls.Add(GroupBoxActions)
        Controls.Add(PanelCardUser)
        Controls.Add(PanelCardTransaksi)
        Controls.Add(PanelCardObat)
        Controls.Add(PanelHeader)
        Name = "DashBoard"
        Text = "DashBoard"
        CType(DgvRiwayatTransaksi, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents LblTitle As Label
    Friend WithEvents PanelCardObat As Panel
    Friend WithEvents PanelCardTransaksi As Panel
    Friend WithEvents PanelCardUser As Panel
    Friend WithEvents LblCaptionObat As Label
    Friend WithEvents LblCaptionTransaksi As Label
    Friend WithEvents LblCaptionUser As Label
    Friend WithEvents LblTotalObat As Label
    Friend WithEvents LblTotalTransaksi As Label
    Friend WithEvents LblTotalUser As Label
    Friend WithEvents GroupBoxActions As GroupBox
    Friend WithEvents BtnKelolaStok As Button
    Friend WithEvents BtnKelolaUser As Button
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents GroupBoxFilter As GroupBox
    Friend WithEvents CmbFilterKategori As ComboBox
    Friend WithEvents TxtFilterKataKunci As TextBox
    Friend WithEvents BtnFilter As Button
    Friend WithEvents BtnTampilSemua As Button
    Friend WithEvents DgvRiwayatTransaksi As DataGridView
End Class
