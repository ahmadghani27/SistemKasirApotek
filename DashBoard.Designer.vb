<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DashBoard
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
        BtnKeluar = New Button()
        LblTitle = New Label()
        PanelCardObat = New Panel()
        LblCaptionObat = New Label()
        LblTotalObat = New Label()
        PanelCardTransaksi = New Panel()
        LblCaptionTransaksi = New Label()
        LblTotalTransaksi = New Label()
        PanelCardUser = New Panel()
        LblCaptionUser = New Label()
        LblTotalPendapatan = New Label()
        GroupBoxActions = New GroupBox()
        BtnDetailRiwayat = New Button()
        BtnKelolaUser = New Button()
        BtnKelolaStok = New Button()
        DgvRiwayatTransaksi = New DataGridView()
        ColIDTransaksi = New DataGridViewTextBoxColumn()
        ColTotalbayar = New DataGridViewTextBoxColumn()
        ColTglTransaksi = New DataGridViewTextBoxColumn()
        Label1 = New Label()
        Panel1 = New Panel()
        Label2 = New Label()
        LblTotalTransaksiBulan = New Label()
        Panel2 = New Panel()
        Label4 = New Label()
        LblTotalPendapatanBulan = New Label()
        PanelHeader.SuspendLayout()
        PanelCardObat.SuspendLayout()
        PanelCardTransaksi.SuspendLayout()
        PanelCardUser.SuspendLayout()
        GroupBoxActions.SuspendLayout()
        CType(DgvRiwayatTransaksi, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
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
        PanelHeader.Size = New Size(800, 64)
        PanelHeader.TabIndex = 16
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.Location = New Point(720, 12)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(68, 40)
        BtnKeluar.TabIndex = 2
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = True
        ' 
        ' LblTitle
        ' 
        LblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        LblTitle.ForeColor = Color.White
        LblTitle.Location = New Point(12, 12)
        LblTitle.Name = "LblTitle"
        LblTitle.Size = New Size(400, 40)
        LblTitle.TabIndex = 0
        LblTitle.Text = "Dashboard"
        LblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PanelCardObat
        ' 
        PanelCardObat.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelCardObat.BorderStyle = BorderStyle.FixedSingle
        PanelCardObat.Controls.Add(LblCaptionObat)
        PanelCardObat.Controls.Add(LblTotalObat)
        PanelCardObat.Location = New Point(12, 84)
        PanelCardObat.Name = "PanelCardObat"
        PanelCardObat.Size = New Size(97, 90)
        PanelCardObat.TabIndex = 15
        ' 
        ' LblCaptionObat
        ' 
        LblCaptionObat.AutoSize = True
        LblCaptionObat.Font = New Font("Segoe UI", 9F)
        LblCaptionObat.ForeColor = Color.DarkSlateGray
        LblCaptionObat.Location = New Point(12, 12)
        LblCaptionObat.Name = "LblCaptionObat"
        LblCaptionObat.Size = New Size(62, 15)
        LblCaptionObat.TabIndex = 0
        LblCaptionObat.Text = "Total Obat"
        ' 
        ' LblTotalObat
        ' 
        LblTotalObat.AutoSize = True
        LblTotalObat.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        LblTotalObat.ForeColor = Color.Black
        LblTotalObat.Location = New Point(12, 30)
        LblTotalObat.Name = "LblTotalObat"
        LblTotalObat.Size = New Size(33, 37)
        LblTotalObat.TabIndex = 1
        LblTotalObat.Text = "0"
        ' 
        ' PanelCardTransaksi
        ' 
        PanelCardTransaksi.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelCardTransaksi.BorderStyle = BorderStyle.FixedSingle
        PanelCardTransaksi.Controls.Add(LblCaptionTransaksi)
        PanelCardTransaksi.Controls.Add(LblTotalTransaksi)
        PanelCardTransaksi.Location = New Point(115, 84)
        PanelCardTransaksi.Name = "PanelCardTransaksi"
        PanelCardTransaksi.Size = New Size(120, 90)
        PanelCardTransaksi.TabIndex = 14
        ' 
        ' LblCaptionTransaksi
        ' 
        LblCaptionTransaksi.AutoSize = True
        LblCaptionTransaksi.Font = New Font("Segoe UI", 9F)
        LblCaptionTransaksi.ForeColor = Color.DarkSlateGray
        LblCaptionTransaksi.Location = New Point(12, 12)
        LblCaptionTransaksi.Name = "LblCaptionTransaksi"
        LblCaptionTransaksi.Size = New Size(96, 15)
        LblCaptionTransaksi.TabIndex = 0
        LblCaptionTransaksi.Text = "Transaksi Hari Ini"
        ' 
        ' LblTotalTransaksi
        ' 
        LblTotalTransaksi.AutoSize = True
        LblTotalTransaksi.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        LblTotalTransaksi.ForeColor = Color.Black
        LblTotalTransaksi.Location = New Point(12, 30)
        LblTotalTransaksi.Name = "LblTotalTransaksi"
        LblTotalTransaksi.Size = New Size(33, 37)
        LblTotalTransaksi.TabIndex = 1
        LblTotalTransaksi.Text = "0"
        ' 
        ' PanelCardUser
        ' 
        PanelCardUser.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelCardUser.BorderStyle = BorderStyle.FixedSingle
        PanelCardUser.Controls.Add(LblCaptionUser)
        PanelCardUser.Controls.Add(LblTotalPendapatan)
        PanelCardUser.Location = New Point(367, 84)
        PanelCardUser.Name = "PanelCardUser"
        PanelCardUser.Size = New Size(192, 90)
        PanelCardUser.TabIndex = 13
        ' 
        ' LblCaptionUser
        ' 
        LblCaptionUser.AutoSize = True
        LblCaptionUser.Font = New Font("Segoe UI", 9F)
        LblCaptionUser.ForeColor = Color.DarkSlateGray
        LblCaptionUser.Location = New Point(12, 12)
        LblCaptionUser.Name = "LblCaptionUser"
        LblCaptionUser.Size = New Size(140, 15)
        LblCaptionUser.TabIndex = 0
        LblCaptionUser.Text = "Total Pendapatan Hari Ini"
        ' 
        ' LblTotalPendapatan
        ' 
        LblTotalPendapatan.AutoSize = True
        LblTotalPendapatan.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        LblTotalPendapatan.ForeColor = Color.Black
        LblTotalPendapatan.Location = New Point(12, 30)
        LblTotalPendapatan.Name = "LblTotalPendapatan"
        LblTotalPendapatan.Size = New Size(33, 37)
        LblTotalPendapatan.TabIndex = 1
        LblTotalPendapatan.Text = "0"
        ' 
        ' GroupBoxActions
        ' 
        GroupBoxActions.Controls.Add(BtnDetailRiwayat)
        GroupBoxActions.Controls.Add(BtnKelolaUser)
        GroupBoxActions.Controls.Add(BtnKelolaStok)
        GroupBoxActions.Location = New Point(536, 190)
        GroupBoxActions.Name = "GroupBoxActions"
        GroupBoxActions.Size = New Size(252, 248)
        GroupBoxActions.TabIndex = 12
        GroupBoxActions.TabStop = False
        GroupBoxActions.Text = "Aksi"
        ' 
        ' BtnDetailRiwayat
        ' 
        BtnDetailRiwayat.Location = New Point(6, 174)
        BtnDetailRiwayat.Name = "BtnDetailRiwayat"
        BtnDetailRiwayat.Size = New Size(240, 68)
        BtnDetailRiwayat.TabIndex = 2
        BtnDetailRiwayat.Text = "Detail Riwayat"
        BtnDetailRiwayat.UseVisualStyleBackColor = True
        ' 
        ' BtnKelolaUser
        ' 
        BtnKelolaUser.Location = New Point(6, 99)
        BtnKelolaUser.Name = "BtnKelolaUser"
        BtnKelolaUser.Size = New Size(240, 69)
        BtnKelolaUser.TabIndex = 1
        BtnKelolaUser.Text = "Kelola Pengguna"
        BtnKelolaUser.UseVisualStyleBackColor = True
        ' 
        ' BtnKelolaStok
        ' 
        BtnKelolaStok.Location = New Point(6, 22)
        BtnKelolaStok.Name = "BtnKelolaStok"
        BtnKelolaStok.Size = New Size(240, 71)
        BtnKelolaStok.TabIndex = 0
        BtnKelolaStok.Text = "Kelola Stok"
        BtnKelolaStok.UseVisualStyleBackColor = True
        ' 
        ' DgvRiwayatTransaksi
        ' 
        DgvRiwayatTransaksi.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvRiwayatTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvRiwayatTransaksi.Columns.AddRange(New DataGridViewColumn() {ColIDTransaksi, ColTotalbayar, ColTglTransaksi})
        DgvRiwayatTransaksi.Location = New Point(12, 212)
        DgvRiwayatTransaksi.Name = "DgvRiwayatTransaksi"
        DgvRiwayatTransaksi.Size = New Size(518, 226)
        DgvRiwayatTransaksi.TabIndex = 10
        ' 
        ' ColIDTransaksi
        ' 
        ColIDTransaksi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ColIDTransaksi.HeaderText = "Id Transaksi"
        ColIDTransaksi.MinimumWidth = 130
        ColIDTransaksi.Name = "ColIDTransaksi"
        ' 
        ' ColTotalbayar
        ' 
        ColTotalbayar.HeaderText = "Total Bayar"
        ColTotalbayar.MinimumWidth = 120
        ColTotalbayar.Name = "ColTotalbayar"
        ColTotalbayar.Width = 120
        ' 
        ' ColTglTransaksi
        ' 
        ColTglTransaksi.HeaderText = "Tanggal"
        ColTglTransaksi.MinimumWidth = 120
        ColTglTransaksi.Name = "ColTglTransaksi"
        ColTglTransaksi.Width = 120
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F)
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(12, 194)
        Label1.Name = "Label1"
        Label1.Size = New Size(97, 15)
        Label1.TabIndex = 2
        Label1.Text = "Riwayat transaksi"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(LblTotalTransaksiBulan)
        Panel1.Location = New Point(241, 84)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(120, 90)
        Panel1.TabIndex = 15
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F)
        Label2.ForeColor = Color.DarkSlateGray
        Label2.Location = New Point(12, 12)
        Label2.Name = "Label2"
        Label2.Size = New Size(101, 15)
        Label2.TabIndex = 0
        Label2.Text = "Transaksi Bulanan"
        ' 
        ' LblTotalTransaksiBulan
        ' 
        LblTotalTransaksiBulan.AutoSize = True
        LblTotalTransaksiBulan.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        LblTotalTransaksiBulan.ForeColor = Color.Black
        LblTotalTransaksiBulan.Location = New Point(12, 30)
        LblTotalTransaksiBulan.Name = "LblTotalTransaksiBulan"
        LblTotalTransaksiBulan.Size = New Size(33, 37)
        LblTotalTransaksiBulan.TabIndex = 1
        LblTotalTransaksiBulan.Text = "0"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(LblTotalPendapatanBulan)
        Panel2.Location = New Point(565, 84)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(223, 90)
        Panel2.TabIndex = 14
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9F)
        Label4.ForeColor = Color.DarkSlateGray
        Label4.Location = New Point(12, 12)
        Label4.Name = "Label4"
        Label4.Size = New Size(145, 15)
        Label4.TabIndex = 0
        Label4.Text = "Total Pendapatan Bulanan"
        ' 
        ' LblTotalPendapatanBulan
        ' 
        LblTotalPendapatanBulan.AutoSize = True
        LblTotalPendapatanBulan.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        LblTotalPendapatanBulan.ForeColor = Color.Black
        LblTotalPendapatanBulan.Location = New Point(12, 30)
        LblTotalPendapatanBulan.Name = "LblTotalPendapatanBulan"
        LblTotalPendapatanBulan.Size = New Size(33, 37)
        LblTotalPendapatanBulan.TabIndex = 1
        LblTotalPendapatanBulan.Text = "0"
        ' 
        ' DashBoard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Controls.Add(DgvRiwayatTransaksi)
        Controls.Add(GroupBoxActions)
        Controls.Add(PanelCardUser)
        Controls.Add(PanelCardTransaksi)
        Controls.Add(PanelCardObat)
        Controls.Add(PanelHeader)
        Name = "DashBoard"
        Text = "DashBoard"
        PanelHeader.ResumeLayout(False)
        PanelCardObat.ResumeLayout(False)
        PanelCardObat.PerformLayout()
        PanelCardTransaksi.ResumeLayout(False)
        PanelCardTransaksi.PerformLayout()
        PanelCardUser.ResumeLayout(False)
        PanelCardUser.PerformLayout()
        GroupBoxActions.ResumeLayout(False)
        CType(DgvRiwayatTransaksi, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
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
    Friend WithEvents LblTotalPendapatan As Label
    Friend WithEvents GroupBoxActions As GroupBox
    Friend WithEvents BtnKelolaStok As Button
    Friend WithEvents BtnKelolaUser As Button
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents DgvRiwayatTransaksi As DataGridView
    Friend WithEvents ColIDTransaksi As DataGridViewTextBoxColumn
    Friend WithEvents ColTotalbayar As DataGridViewTextBoxColumn
    Friend WithEvents ColTglTransaksi As DataGridViewTextBoxColumn
    Friend WithEvents BtnDetailRiwayat As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents LblTotalTransaksiBulan As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents LblTotalPendapatanBulan As Label
End Class