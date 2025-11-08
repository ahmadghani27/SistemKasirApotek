<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Riwayat_Transaksi
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        DtpFilter = New DateTimePicker()
        DgvRiwayat = New DataGridView()
        ColIDTransaksi = New DataGridViewTextBoxColumn()
        ColWaktu = New DataGridViewTextBoxColumn()
        ColTotalH = New DataGridViewTextBoxColumn()
        BtnCari = New Button()
        LblTotalHarian = New Label()
        BtnKembali = New Button()
        GbFilter = New GroupBox()
        Label1 = New Label()
        LblTotalBulanan = New Label()
        LblLabelTotal = New Label()
        LblPilihTanggal = New Label()
        DgvDetail = New DataGridView()
        ColNamaObat = New DataGridViewTextBoxColumn()
        ColHarga = New DataGridViewTextBoxColumn()
        ColJumlah = New DataGridViewTextBoxColumn()
        ColSubtotal = New DataGridViewTextBoxColumn()
        LblDetail = New Label()
        GroupBox1 = New GroupBox()
        TxtFilter = New TextBox()
        Label2 = New Label()
        BtnCariObat = New Button()
        Label3 = New Label()
        CType(DgvRiwayat, ComponentModel.ISupportInitialize).BeginInit()
        GbFilter.SuspendLayout()
        CType(DgvDetail, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DtpFilter
        ' 
        DtpFilter.CustomFormat = "dd MMMM yyyy"
        DtpFilter.Format = DateTimePickerFormat.Custom
        DtpFilter.Location = New Point(100, 28)
        DtpFilter.Name = "DtpFilter"
        DtpFilter.Size = New Size(155, 23)
        DtpFilter.TabIndex = 0
        ' 
        ' DgvRiwayat
        ' 
        DgvRiwayat.AllowUserToAddRows = False
        DgvRiwayat.AllowUserToDeleteRows = False
        DgvRiwayat.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        DgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvRiwayat.Columns.AddRange(New DataGridViewColumn() {ColIDTransaksi, ColWaktu, ColTotalH})
        DgvRiwayat.Location = New Point(12, 136)
        DgvRiwayat.MultiSelect = False
        DgvRiwayat.Name = "DgvRiwayat"
        DgvRiwayat.ReadOnly = True
        DgvRiwayat.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvRiwayat.Size = New Size(776, 178)
        DgvRiwayat.TabIndex = 1
        ' 
        ' ColIDTransaksi
        ' 
        ColIDTransaksi.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        ColIDTransaksi.HeaderText = "ID Transaksi"
        ColIDTransaksi.MinimumWidth = 200
        ColIDTransaksi.Name = "ColIDTransaksi"
        ColIDTransaksi.ReadOnly = True
        ColIDTransaksi.Width = 200
        ' 
        ' ColWaktu
        ' 
        ColWaktu.HeaderText = "Waktu"
        ColWaktu.MinimumWidth = 240
        ColWaktu.Name = "ColWaktu"
        ColWaktu.ReadOnly = True
        ColWaktu.Width = 240
        ' 
        ' ColTotalH
        ' 
        ColTotalH.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ColTotalH.HeaderText = "Total"
        ColTotalH.Name = "ColTotalH"
        ColTotalH.ReadOnly = True
        ' 
        ' BtnCari
        ' 
        BtnCari.FlatStyle = FlatStyle.Flat
        BtnCari.Location = New Point(261, 27)
        BtnCari.Name = "BtnCari"
        BtnCari.Size = New Size(157, 25)
        BtnCari.TabIndex = 2
        BtnCari.Text = "Cari"
        BtnCari.UseVisualStyleBackColor = True
        ' 
        ' LblTotalHarian
        ' 
        LblTotalHarian.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblTotalHarian.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LblTotalHarian.Location = New Point(185, 74)
        LblTotalHarian.Name = "LblTotalHarian"
        LblTotalHarian.Size = New Size(188, 21)
        LblTotalHarian.TabIndex = 10
        LblTotalHarian.Text = "Rp 0"
        LblTotalHarian.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' BtnKembali
        ' 
        BtnKembali.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnKembali.FlatStyle = FlatStyle.Flat
        BtnKembali.Location = New Point(424, 26)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(167, 25)
        BtnKembali.TabIndex = 11
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = True
        ' 
        ' GbFilter
        ' 
        GbFilter.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GbFilter.Controls.Add(Label1)
        GbFilter.Controls.Add(LblTotalBulanan)
        GbFilter.Controls.Add(LblLabelTotal)
        GbFilter.Controls.Add(LblPilihTanggal)
        GbFilter.Controls.Add(DtpFilter)
        GbFilter.Controls.Add(BtnKembali)
        GbFilter.Controls.Add(BtnCari)
        GbFilter.Controls.Add(LblTotalHarian)
        GbFilter.Location = New Point(12, 12)
        GbFilter.Name = "GbFilter"
        GbFilter.Size = New Size(776, 116)
        GbFilter.TabIndex = 0
        GbFilter.TabStop = False
        GbFilter.Text = "Filter Riwayat"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        Label1.Location = New Point(407, 77)
        Label1.Name = "Label1"
        Label1.Size = New Size(62, 17)
        Label1.TabIndex = 15
        Label1.Text = "Bulanan:"
        ' 
        ' LblTotalBulanan
        ' 
        LblTotalBulanan.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblTotalBulanan.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LblTotalBulanan.Location = New Point(528, 74)
        LblTotalBulanan.Name = "LblTotalBulanan"
        LblTotalBulanan.Size = New Size(242, 21)
        LblTotalBulanan.TabIndex = 14
        LblTotalBulanan.Text = "Rp 0"
        LblTotalBulanan.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' LblLabelTotal
        ' 
        LblLabelTotal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblLabelTotal.AutoSize = True
        LblLabelTotal.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        LblLabelTotal.Location = New Point(14, 77)
        LblLabelTotal.Name = "LblLabelTotal"
        LblLabelTotal.Size = New Size(165, 17)
        LblLabelTotal.TabIndex = 13
        LblLabelTotal.Text = "Total Pendapatan Harian:"
        ' 
        ' LblPilihTanggal
        ' 
        LblPilihTanggal.AutoSize = True
        LblPilihTanggal.Location = New Point(15, 32)
        LblPilihTanggal.Name = "LblPilihTanggal"
        LblPilihTanggal.Size = New Size(78, 15)
        LblPilihTanggal.TabIndex = 12
        LblPilihTanggal.Text = "Pilih Tanggal:"
        ' 
        ' DgvDetail
        ' 
        DgvDetail.AllowUserToAddRows = False
        DgvDetail.AllowUserToDeleteRows = False
        DgvDetail.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDetail.Columns.AddRange(New DataGridViewColumn() {ColNamaObat, ColHarga, ColJumlah, ColSubtotal})
        DgvDetail.Location = New Point(12, 424)
        DgvDetail.Name = "DgvDetail"
        DgvDetail.ReadOnly = True
        DgvDetail.Size = New Size(776, 187)
        DgvDetail.TabIndex = 2
        ' 
        ' ColNamaObat
        ' 
        ColNamaObat.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ColNamaObat.HeaderText = "Nama Obat"
        ColNamaObat.Name = "ColNamaObat"
        ColNamaObat.ReadOnly = True
        ' 
        ' ColHarga
        ' 
        ColHarga.HeaderText = "Harga"
        ColHarga.Name = "ColHarga"
        ColHarga.ReadOnly = True
        ColHarga.Width = 120
        ' 
        ' ColJumlah
        ' 
        ColJumlah.HeaderText = "Jumlah"
        ColJumlah.Name = "ColJumlah"
        ColJumlah.ReadOnly = True
        ColJumlah.Width = 80
        ' 
        ' ColSubtotal
        ' 
        ColSubtotal.HeaderText = "Subtotal"
        ColSubtotal.Name = "ColSubtotal"
        ColSubtotal.ReadOnly = True
        ColSubtotal.Width = 130
        ' 
        ' LblDetail
        ' 
        LblDetail.AutoSize = True
        LblDetail.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LblDetail.Location = New Point(12, 325)
        LblDetail.Name = "LblDetail"
        LblDetail.Size = New Size(171, 15)
        LblDetail.TabIndex = 13
        LblDetail.Text = "Detail Item (klik baris di atas):"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox1.Controls.Add(TxtFilter)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(BtnCariObat)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(12, 345)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(776, 73)
        GroupBox1.TabIndex = 14
        GroupBox1.TabStop = False
        GroupBox1.Text = "Obat Terjual"
        ' 
        ' TxtFilter
        ' 
        TxtFilter.Location = New Point(79, 31)
        TxtFilter.Name = "TxtFilter"
        TxtFilter.Size = New Size(163, 23)
        TxtFilter.TabIndex = 14
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(11, 36)
        Label2.Name = "Label2"
        Label2.Size = New Size(62, 15)
        Label2.TabIndex = 12
        Label2.Text = "Filter Obat"
        ' 
        ' BtnCariObat
        ' 
        BtnCariObat.FlatStyle = FlatStyle.Flat
        BtnCariObat.Location = New Point(248, 31)
        BtnCariObat.Name = "BtnCariObat"
        BtnCariObat.Size = New Size(116, 25)
        BtnCariObat.TabIndex = 2
        BtnCariObat.Text = "Cari"
        BtnCariObat.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label3.Location = New Point(1158, 30)
        Label3.Name = "Label3"
        Label3.Size = New Size(188, 21)
        Label3.TabIndex = 10
        Label3.Text = "Rp 0"
        Label3.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Riwayat_Transaksi
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 623)
        Controls.Add(GroupBox1)
        Controls.Add(LblDetail)
        Controls.Add(DgvDetail)
        Controls.Add(GbFilter)
        Controls.Add(DgvRiwayat)
        MinimumSize = New Size(700, 500)
        Name = "Riwayat_Transaksi"
        Text = "Riwayat Transaksi"
        CType(DgvRiwayat, ComponentModel.ISupportInitialize).EndInit()
        GbFilter.ResumeLayout(False)
        GbFilter.PerformLayout()
        CType(DgvDetail, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents DtpFilter As DateTimePicker
    Friend WithEvents DgvRiwayat As DataGridView
    Friend WithEvents BtnCari As Button ' Diubah dari BtnLihatDetail
    Friend WithEvents LblTotalHarian As Label
    Friend WithEvents BtnKembali As Button
    Friend WithEvents GbFilter As GroupBox
    Friend WithEvents LblPilihTanggal As Label
    Friend WithEvents LblLabelTotal As Label
    Friend WithEvents DgvDetail As DataGridView ' Grid baru ditambahkan
    Friend WithEvents ColNamaObat As DataGridViewTextBoxColumn
    Friend WithEvents ColHarga As DataGridViewTextBoxColumn
    Friend WithEvents ColJumlah As DataGridViewTextBoxColumn
    Friend WithEvents ColSubtotal As DataGridViewTextBoxColumn
    Friend WithEvents LblDetail As Label
    Friend WithEvents ColIDTransaksi As DataGridViewTextBoxColumn
    Friend WithEvents ColWaktu As DataGridViewTextBoxColumn
    Friend WithEvents ColTotalH As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnCariObat As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtFilter As TextBox
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents LblTitle As Label
    Friend WithEvents PanelHeader As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LblTotalBulanan As Label
End Class