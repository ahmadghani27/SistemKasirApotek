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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        LblTotalObat = New Label()
        LblTotalTransaksi = New Label()
        LblTotalUser = New Label()
        BtnKelolaStok = New Button()
        BtnKelolaUser = New Button()
        BtnKeluar = New Button()
        CmbFilterKategori = New ComboBox()
        TxtFilterKataKunci = New TextBox()
        BtnFilter = New Button()
        BtnTampilSemua = New Button()
        DgvRiwayatTransaksi = New DataGridView()
        CType(DgvRiwayatTransaksi, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblTotalObat
        ' 
        LblTotalObat.AutoSize = True
        LblTotalObat.Location = New Point(116, 56)
        LblTotalObat.Name = "LblTotalObat"
        LblTotalObat.Size = New Size(62, 15)
        LblTotalObat.TabIndex = 0
        LblTotalObat.Text = "Total Obat"
        ' 
        ' LblTotalTransaksi
        ' 
        LblTotalTransaksi.AutoSize = True
        LblTotalTransaksi.Location = New Point(116, 71)
        LblTotalTransaksi.Name = "LblTotalTransaksi"
        LblTotalTransaksi.Size = New Size(84, 15)
        LblTotalTransaksi.TabIndex = 1
        LblTotalTransaksi.Text = "Total Transaksi"
        ' 
        ' LblTotalUser
        ' 
        LblTotalUser.AutoSize = True
        LblTotalUser.Location = New Point(116, 86)
        LblTotalUser.Name = "LblTotalUser"
        LblTotalUser.Size = New Size(59, 15)
        LblTotalUser.TabIndex = 2
        LblTotalUser.Text = "Total User"
        ' 
        ' BtnKelolaStok
        ' 
        BtnKelolaStok.Location = New Point(242, 62)
        BtnKelolaStok.Name = "BtnKelolaStok"
        BtnKelolaStok.Size = New Size(75, 23)
        BtnKelolaStok.TabIndex = 3
        BtnKelolaStok.Text = "Kelola Stok"
        BtnKelolaStok.UseVisualStyleBackColor = True
        ' 
        ' BtnKelolaUser
        ' 
        BtnKelolaUser.Location = New Point(242, 91)
        BtnKelolaUser.Name = "BtnKelolaUser"
        BtnKelolaUser.Size = New Size(75, 23)
        BtnKelolaUser.TabIndex = 4
        BtnKelolaUser.Text = "Kelola User"
        BtnKelolaUser.UseVisualStyleBackColor = True
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.Location = New Point(242, 120)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(75, 23)
        BtnKeluar.TabIndex = 5
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = True
        ' 
        ' CmbFilterKategori
        ' 
        CmbFilterKategori.FormattingEnabled = True
        CmbFilterKategori.Location = New Point(253, 161)
        CmbFilterKategori.Name = "CmbFilterKategori"
        CmbFilterKategori.Size = New Size(121, 23)
        CmbFilterKategori.TabIndex = 6
        ' 
        ' TxtFilterKataKunci
        ' 
        TxtFilterKataKunci.Location = New Point(376, 68)
        TxtFilterKataKunci.Name = "TxtFilterKataKunci"
        TxtFilterKataKunci.Size = New Size(100, 23)
        TxtFilterKataKunci.TabIndex = 7
        ' 
        ' BtnFilter
        ' 
        BtnFilter.Location = New Point(426, 130)
        BtnFilter.Name = "BtnFilter"
        BtnFilter.Size = New Size(75, 23)
        BtnFilter.TabIndex = 8
        BtnFilter.Text = "Filter"
        BtnFilter.UseVisualStyleBackColor = True
        ' 
        ' BtnTampilSemua
        ' 
        BtnTampilSemua.Location = New Point(426, 160)
        BtnTampilSemua.Name = "BtnTampilSemua"
        BtnTampilSemua.Size = New Size(75, 23)
        BtnTampilSemua.TabIndex = 9
        BtnTampilSemua.Text = "Tampilkan"
        BtnTampilSemua.UseVisualStyleBackColor = True
        ' 
        ' DgvRiwayatTransaksi
        ' 
        DgvRiwayatTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvRiwayatTransaksi.Location = New Point(221, 245)
        DgvRiwayatTransaksi.Name = "DgvRiwayatTransaksi"
        DgvRiwayatTransaksi.Size = New Size(240, 150)
        DgvRiwayatTransaksi.TabIndex = 10
        ' 
        ' DashBoard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(DgvRiwayatTransaksi)
        Controls.Add(BtnTampilSemua)
        Controls.Add(BtnFilter)
        Controls.Add(TxtFilterKataKunci)
        Controls.Add(CmbFilterKategori)
        Controls.Add(BtnKeluar)
        Controls.Add(BtnKelolaUser)
        Controls.Add(BtnKelolaStok)
        Controls.Add(LblTotalUser)
        Controls.Add(LblTotalTransaksi)
        Controls.Add(LblTotalObat)
        Name = "DashBoard"
        Text = "DashBoard"
        CType(DgvRiwayatTransaksi, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblTotalObat As Label
    Friend WithEvents LblTotalTransaksi As Label
    Friend WithEvents LblTotalUser As Label
    Friend WithEvents BtnKelolaStok As Button
    Friend WithEvents BtnKelolaUser As Button
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents CmbFilterKategori As ComboBox
    Friend WithEvents TxtFilterKataKunci As TextBox
    Friend WithEvents BtnFilter As Button
    Friend WithEvents BtnTampilSemua As Button
    Friend WithEvents DgvRiwayatTransaksi As DataGridView
End Class
