<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Transaksi
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
        TxtIDObat = New TextBox()
        TxtNamaObat = New TextBox()
        TxtJumlah = New TextBox()
        BtnTambah = New Button()
        BtnSimpan = New Button()
        BtnBatal = New Button()
        BtnHapusItem = New Button()
        BtnKeluar = New Button()
        LblTotalBayar = New Label()
        DgvListTransaksi = New DataGridView()
        colID = New DataGridViewTextBoxColumn()
        colNama = New DataGridViewTextBoxColumn()
        colHarga = New DataGridViewTextBoxColumn()
        colJumlah = New DataGridViewTextBoxColumn()
        colSubtotal = New DataGridViewTextBoxColumn()
        GbInputObat = New GroupBox()
        Label1 = New Label()
        TxtHarga = New TextBox()
        BtnCari = New Button()
        LblLabelNamaObat = New Label()
        LblLabelIDObat = New Label()
        LblLabelJumlah = New Label()
        GbAksi = New GroupBox()
        GbKeranjang = New GroupBox()
        LblLabelTotal = New Label()
        GroupBox1 = New GroupBox()
        BtnLihatStok = New Button()
        BtnRiwayat = New Button()
        CType(DgvListTransaksi, ComponentModel.ISupportInitialize).BeginInit()
        GbInputObat.SuspendLayout()
        GbAksi.SuspendLayout()
        GbKeranjang.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TxtIDObat
        ' 
        TxtIDObat.Location = New Point(74, 30)
        TxtIDObat.Name = "TxtIDObat"
        TxtIDObat.Size = New Size(158, 23)
        TxtIDObat.TabIndex = 0
        ' 
        ' TxtNamaObat
        ' 
        TxtNamaObat.Location = New Point(316, 32)
        TxtNamaObat.Name = "TxtNamaObat"
        TxtNamaObat.Size = New Size(163, 23)
        TxtNamaObat.TabIndex = 1
        ' 
        ' TxtJumlah
        ' 
        TxtJumlah.Location = New Point(205, 24)
        TxtJumlah.Name = "TxtJumlah"
        TxtJumlah.Size = New Size(85, 23)
        TxtJumlah.TabIndex = 3
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnTambah.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        BtnTambah.Cursor = Cursors.Hand
        BtnTambah.FlatStyle = FlatStyle.Popup
        BtnTambah.Location = New Point(310, 22)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(75, 27)
        BtnTambah.TabIndex = 4
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = False
        ' 
        ' BtnSimpan
        ' 
        BtnSimpan.BackColor = Color.LightSkyBlue
        BtnSimpan.Cursor = Cursors.Hand
        BtnSimpan.FlatStyle = FlatStyle.Popup
        BtnSimpan.Location = New Point(15, 22)
        BtnSimpan.Name = "BtnSimpan"
        BtnSimpan.Size = New Size(84, 27)
        BtnSimpan.TabIndex = 5
        BtnSimpan.Text = "Simpan"
        BtnSimpan.UseVisualStyleBackColor = False
        ' 
        ' BtnBatal
        ' 
        BtnBatal.Cursor = Cursors.Hand
        BtnBatal.FlatStyle = FlatStyle.Popup
        BtnBatal.Location = New Point(105, 22)
        BtnBatal.Name = "BtnBatal"
        BtnBatal.Size = New Size(84, 27)
        BtnBatal.TabIndex = 6
        BtnBatal.Text = "Batal"
        BtnBatal.UseVisualStyleBackColor = True
        ' 
        ' BtnHapusItem
        ' 
        BtnHapusItem.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        BtnHapusItem.Cursor = Cursors.Hand
        BtnHapusItem.FlatStyle = FlatStyle.Popup
        BtnHapusItem.Location = New Point(195, 22)
        BtnHapusItem.Name = "BtnHapusItem"
        BtnHapusItem.Size = New Size(84, 27)
        BtnHapusItem.TabIndex = 7
        BtnHapusItem.Text = "Hapus Item"
        BtnHapusItem.UseVisualStyleBackColor = False
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        BtnKeluar.Cursor = Cursors.Hand
        BtnKeluar.FlatStyle = FlatStyle.Popup
        BtnKeluar.Location = New Point(302, 22)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(84, 27)
        BtnKeluar.TabIndex = 8
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = False
        ' 
        ' LblTotalBayar
        ' 
        LblTotalBayar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        LblTotalBayar.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold)
        LblTotalBayar.ForeColor = Color.Maroon
        LblTotalBayar.Location = New Point(544, 451)
        LblTotalBayar.Name = "LblTotalBayar"
        LblTotalBayar.Size = New Size(244, 37)
        LblTotalBayar.TabIndex = 9
        LblTotalBayar.Text = "Rp 0"
        LblTotalBayar.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' DgvListTransaksi
        ' 
        DgvListTransaksi.AllowUserToAddRows = False
        DgvListTransaksi.AllowUserToDeleteRows = False
        DgvListTransaksi.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvListTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvListTransaksi.Columns.AddRange(New DataGridViewColumn() {colID, colNama, colHarga, colJumlah, colSubtotal})
        DgvListTransaksi.Location = New Point(15, 28)
        DgvListTransaksi.Name = "DgvListTransaksi"
        DgvListTransaksi.ReadOnly = True
        DgvListTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvListTransaksi.Size = New Size(787, 256)
        DgvListTransaksi.TabIndex = 10
        ' 
        ' colID
        ' 
        colID.HeaderText = "ID Obat"
        colID.Name = "colID"
        colID.ReadOnly = True
        colID.Width = 90
        ' 
        ' colNama
        ' 
        colNama.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colNama.HeaderText = "Nama Obat"
        colNama.Name = "colNama"
        colNama.ReadOnly = True
        ' 
        ' colHarga
        ' 
        colHarga.HeaderText = "Harga"
        colHarga.Name = "colHarga"
        colHarga.ReadOnly = True
        colHarga.Width = 120
        ' 
        ' colJumlah
        ' 
        colJumlah.HeaderText = "Jumlah"
        colJumlah.Name = "colJumlah"
        colJumlah.ReadOnly = True
        colJumlah.Width = 80
        ' 
        ' colSubtotal
        ' 
        colSubtotal.HeaderText = "Subtotal"
        colSubtotal.Name = "colSubtotal"
        colSubtotal.ReadOnly = True
        colSubtotal.Width = 130
        ' 
        ' GbInputObat
        ' 
        GbInputObat.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GbInputObat.BackColor = Color.AliceBlue
        GbInputObat.Controls.Add(Label1)
        GbInputObat.Controls.Add(TxtHarga)
        GbInputObat.Controls.Add(BtnCari)
        GbInputObat.Controls.Add(LblLabelNamaObat)
        GbInputObat.Controls.Add(LblLabelIDObat)
        GbInputObat.Controls.Add(TxtIDObat)
        GbInputObat.Controls.Add(TxtNamaObat)
        GbInputObat.Location = New Point(12, 12)
        GbInputObat.Name = "GbInputObat"
        GbInputObat.Size = New Size(818, 73)
        GbInputObat.TabIndex = 0
        GbInputObat.TabStop = False
        GbInputObat.Text = "Input Obat"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(569, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(42, 15)
        Label1.TabIndex = 11
        Label1.Text = "Harga:"
        ' 
        ' TxtHarga
        ' 
        TxtHarga.Location = New Point(622, 31)
        TxtHarga.Name = "TxtHarga"
        TxtHarga.Size = New Size(180, 23)
        TxtHarga.TabIndex = 10
        ' 
        ' BtnCari
        ' 
        BtnCari.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnCari.BackColor = Color.LightSkyBlue
        BtnCari.FlatStyle = FlatStyle.Flat
        BtnCari.Location = New Point(485, 30)
        BtnCari.Name = "BtnCari"
        BtnCari.Size = New Size(54, 27)
        BtnCari.TabIndex = 9
        BtnCari.Text = "Cari"
        BtnCari.UseVisualStyleBackColor = False
        ' 
        ' LblLabelNamaObat
        ' 
        LblLabelNamaObat.AutoSize = True
        LblLabelNamaObat.Location = New Point(242, 36)
        LblLabelNamaObat.Name = "LblLabelNamaObat"
        LblLabelNamaObat.Size = New Size(71, 15)
        LblLabelNamaObat.TabIndex = 6
        LblLabelNamaObat.Text = "Nama Obat:"
        ' 
        ' LblLabelIDObat
        ' 
        LblLabelIDObat.AutoSize = True
        LblLabelIDObat.Location = New Point(15, 34)
        LblLabelIDObat.Name = "LblLabelIDObat"
        LblLabelIDObat.Size = New Size(50, 15)
        LblLabelIDObat.TabIndex = 5
        LblLabelIDObat.Text = "ID Obat:"
        ' 
        ' LblLabelJumlah
        ' 
        LblLabelJumlah.AutoSize = True
        LblLabelJumlah.Location = New Point(146, 28)
        LblLabelJumlah.Name = "LblLabelJumlah"
        LblLabelJumlah.Size = New Size(48, 15)
        LblLabelJumlah.TabIndex = 8
        LblLabelJumlah.Text = "Jumlah:"
        ' 
        ' GbAksi
        ' 
        GbAksi.BackColor = Color.White
        GbAksi.Controls.Add(BtnSimpan)
        GbAksi.Controls.Add(BtnBatal)
        GbAksi.Controls.Add(BtnHapusItem)
        GbAksi.Controls.Add(BtnKeluar)
        GbAksi.Location = New Point(12, 75)
        GbAksi.Name = "GbAksi"
        GbAksi.Size = New Size(421, 62)
        GbAksi.TabIndex = 1
        GbAksi.TabStop = False
        GbAksi.Text = "Aksi Transaksi"
        ' 
        ' GbKeranjang
        ' 
        GbKeranjang.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GbKeranjang.Controls.Add(DgvListTransaksi)
        GbKeranjang.Location = New Point(12, 143)
        GbKeranjang.Name = "GbKeranjang"
        GbKeranjang.Size = New Size(818, 298)
        GbKeranjang.TabIndex = 2
        GbKeranjang.TabStop = False
        GbKeranjang.Text = "Keranjang Belanja"
        ' 
        ' LblLabelTotal
        ' 
        LblLabelTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        LblLabelTotal.AutoSize = True
        LblLabelTotal.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LblLabelTotal.Location = New Point(413, 461)
        LblLabelTotal.Name = "LblLabelTotal"
        LblLabelTotal.Size = New Size(114, 21)
        LblLabelTotal.TabIndex = 11
        LblLabelTotal.Text = "TOTAL BAYAR:"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.AliceBlue
        GroupBox1.Controls.Add(LblLabelJumlah)
        GroupBox1.Controls.Add(BtnTambah)
        GroupBox1.Controls.Add(TxtJumlah)
        GroupBox1.Location = New Point(429, 75)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(401, 62)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        ' 
        ' BtnLihatStok
        ' 
        BtnLihatStok.BackColor = Color.AliceBlue
        BtnLihatStok.Cursor = Cursors.Hand
        BtnLihatStok.FlatStyle = FlatStyle.Popup
        BtnLihatStok.Font = New Font("Segoe UI", 12F)
        BtnLihatStok.Location = New Point(27, 450)
        BtnLihatStok.Name = "BtnLihatStok"
        BtnLihatStok.Size = New Size(127, 35)
        BtnLihatStok.TabIndex = 12
        BtnLihatStok.Text = "Lihat Stok"
        BtnLihatStok.UseVisualStyleBackColor = False
        ' 
        ' BtnRiwayat
        ' 
        BtnRiwayat.BackColor = Color.PaleGoldenrod
        BtnRiwayat.Cursor = Cursors.Hand
        BtnRiwayat.FlatStyle = FlatStyle.Popup
        BtnRiwayat.Font = New Font("Segoe UI", 12F)
        BtnRiwayat.Location = New Point(160, 450)
        BtnRiwayat.Name = "BtnRiwayat"
        BtnRiwayat.Size = New Size(131, 35)
        BtnRiwayat.TabIndex = 13
        BtnRiwayat.Text = "Riwayat"
        BtnRiwayat.UseVisualStyleBackColor = False
        ' 
        ' Transaksi
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(842, 497)
        Controls.Add(BtnRiwayat)
        Controls.Add(BtnLihatStok)
        Controls.Add(GroupBox1)
        Controls.Add(LblLabelTotal)
        Controls.Add(GbKeranjang)
        Controls.Add(GbAksi)
        Controls.Add(GbInputObat)
        Controls.Add(LblTotalBayar)
        MaximizeBox = False
        MinimumSize = New Size(820, 535)
        Name = "Transaksi"
        StartPosition = FormStartPosition.CenterParent
        Text = "Transaksi - Kasir Apotek"
        CType(DgvListTransaksi, ComponentModel.ISupportInitialize).EndInit()
        GbInputObat.ResumeLayout(False)
        GbInputObat.PerformLayout()
        GbAksi.ResumeLayout(False)
        GbKeranjang.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents TxtIDObat As TextBox
    Friend WithEvents TxtNamaObat As TextBox
    Friend WithEvents TxtJumlah As TextBox
    Friend WithEvents BtnTambah As Button
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents BtnBatal As Button
    Friend WithEvents BtnHapusItem As Button
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents LblTotalBayar As Label
    Friend WithEvents DgvListTransaksi As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colNama As DataGridViewTextBoxColumn
    Friend WithEvents colHarga As DataGridViewTextBoxColumn
    Friend WithEvents colJumlah As DataGridViewTextBoxColumn
    Friend WithEvents colSubtotal As DataGridViewTextBoxColumn
    Friend WithEvents GbInputObat As GroupBox
    Friend WithEvents LblLabelJumlah As Label
    Friend WithEvents LblLabelNamaObat As Label
    Friend WithEvents LblLabelIDObat As Label
    Friend WithEvents GbAksi As GroupBox
    Friend WithEvents GbKeranjang As GroupBox
    Friend WithEvents LblLabelTotal As Label
    Friend WithEvents BtnCari As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtHarga As TextBox
    Friend WithEvents BtnLihatStok As Button
    Friend WithEvents BtnRiwayat As Button
End Class