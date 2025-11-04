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
        Me.TxtIDTransaksi = New System.Windows.Forms.TextBox()
        Me.TxtNamaObat = New System.Windows.Forms.TextBox()
        Me.TxtHarga = New System.Windows.Forms.TextBox()
        Me.TxtJumlah = New System.Windows.Forms.TextBox()
        Me.BtnTambahList = New System.Windows.Forms.Button()
        Me.BtnSimpanTransaksi = New System.Windows.Forms.Button()
        Me.BtnBatal = New System.Windows.Forms.Button()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.BtnKeluar = New System.Windows.Forms.Button()
        Me.LblTotalBayar = New System.Windows.Forms.Label()
        Me.DgvListTransaksi = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colJumlah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GbInputObat = New System.Windows.Forms.GroupBox()
        Me.LblLabelJumlah = New System.Windows.Forms.Label()
        Me.LblLabelHarga = New System.Windows.Forms.Label()
        Me.LblLabelNamaObat = New System.Windows.Forms.Label()
        Me.LblLabelIDObat = New System.Windows.Forms.Label()
        Me.GbAksi = New System.Windows.Forms.GroupBox()
        Me.GbKeranjang = New System.Windows.Forms.GroupBox()
        Me.LblLabelTotal = New System.Windows.Forms.Label()
        CType(Me.DgvListTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbInputObat.SuspendLayout()
        Me.GbAksi.SuspendLayout()
        Me.GbKeranjang.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtIDTransaksi
        '
        Me.TxtIDTransaksi.Location = New System.Drawing.Point(74, 30)
        Me.TxtIDTransaksi.Name = "TxtIDTransaksi"
        Me.TxtIDTransaksi.Size = New System.Drawing.Size(113, 23)
        Me.TxtIDTransaksi.TabIndex = 0
        '
        'TxtNamaObat
        '
        Me.TxtNamaObat.Location = New System.Drawing.Point(267, 30)
        Me.TxtNamaObat.Name = "TxtNamaObat"
        Me.TxtNamaObat.Size = New System.Drawing.Size(161, 23)
        Me.TxtNamaObat.TabIndex = 1
        '
        'TxtHarga
        '
        Me.TxtHarga.Location = New System.Drawing.Point(489, 30)
        Me.TxtHarga.Name = "TxtHarga"
        Me.TxtHarga.Size = New System.Drawing.Size(111, 23)
        Me.TxtHarga.TabIndex = 2
        '
        'TxtJumlah
        '
        Me.TxtJumlah.Location = New System.Drawing.Point(659, 30)
        Me.TxtJumlah.Name = "TxtJumlah"
        Me.TxtJumlah.Size = New System.Drawing.Size(51, 23)
        Me.TxtJumlah.TabIndex = 3
        '
        'BtnTambahList
        '
        Me.BtnTambahList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTambahList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTambahList.Location = New System.Drawing.Point(727, 28)
        Me.BtnTambahList.Name = "BtnTambahList"
        Me.BtnTambahList.Size = New System.Drawing.Size(75, 27)
        Me.BtnTambahList.TabIndex = 4
        Me.BtnTambahList.Text = "Tambah"
        Me.BtnTambahList.UseVisualStyleBackColor = True
        '
        'BtnSimpanTransaksi
        '
        Me.BtnSimpanTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSimpanTransaksi.Location = New System.Drawing.Point(15, 28)
        Me.BtnSimpanTransaksi.Name = "BtnSimpanTransaksi"
        Me.BtnSimpanTransaksi.Size = New System.Drawing.Size(84, 27)
        Me.BtnSimpanTransaksi.TabIndex = 5
        Me.BtnSimpanTransaksi.Text = "Simpan"
        Me.BtnSimpanTransaksi.UseVisualStyleBackColor = True
        '
        'BtnBatal
        '
        Me.BtnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBatal.Location = New System.Drawing.Point(111, 28)
        Me.BtnBatal.Name = "BtnBatal"
        Me.BtnBatal.Size = New System.Drawing.Size(84, 27)
        Me.BtnBatal.TabIndex = 6
        Me.BtnBatal.Text = "Batal"
        Me.BtnBatal.UseVisualStyleBackColor = True
        '
        'BtnHapus
        '
        Me.BtnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHapus.Location = New System.Drawing.Point(207, 28)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(84, 27)
        Me.BtnHapus.TabIndex = 7
        Me.BtnHapus.Text = "Hapus Item"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'BtnKeluar
        '
        Me.BtnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnKeluar.Location = New System.Drawing.Point(303, 28)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.Size = New System.Drawing.Size(84, 27)
        Me.BtnKeluar.TabIndex = 8
        Me.BtnKeluar.Text = "Keluar"
        Me.BtnKeluar.UseVisualStyleBackColor = True
        '
        'LblTotalBayar
        '
        Me.LblTotalBayar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalBayar.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.LblTotalBayar.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalBayar.Location = New System.Drawing.Point(544, 451)
        Me.LblTotalBayar.Name = "LblTotalBayar"
        Me.LblTotalBayar.Size = New System.Drawing.Size(244, 37)
        Me.LblTotalBayar.TabIndex = 9
        Me.LblTotalBayar.Text = "Rp 0"
        Me.LblTotalBayar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgvListTransaksi
        '
        Me.DgvListTransaksi.AllowUserToAddRows = False
        Me.DgvListTransaksi.AllowUserToDeleteRows = False
        Me.DgvListTransaksi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvListTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvListTransaksi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colNama, Me.colHarga, Me.colJumlah, Me.colSubtotal})
        Me.DgvListTransaksi.Location = New System.Drawing.Point(15, 28)
        Me.DgvListTransaksi.Name = "DgvListTransaksi"
        Me.DgvListTransaksi.ReadOnly = True
        Me.DgvListTransaksi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvListTransaksi.Size = New System.Drawing.Size(787, 219)
        Me.DgvListTransaksi.TabIndex = 10
        '
        'colID
        '
        Me.colID.HeaderText = "ID Obat"
        Me.colID.Name = "IDObat"
        Me.colID.ReadOnly = True
        Me.colID.Width = 90
        '
        'colNama
        '
        Me.colNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNama.HeaderText = "Nama Obat"
        Me.colNama.Name = "NamaObat"
        Me.colNama.ReadOnly = True
        '
        'colHarga
        '
        Me.colHarga.HeaderText = "Harga"
        Me.colHarga.Name = "Harga"
        Me.colHarga.ReadOnly = True
        Me.colHarga.Width = 120
        '
        'colJumlah
        '
        Me.colJumlah.HeaderText = "Jumlah"
        Me.colJumlah.Name = "Jumlah"
        Me.colJumlah.ReadOnly = True
        Me.colJumlah.Width = 80
        '
        'colSubtotal
        '
        Me.colSubtotal.HeaderText = "Subtotal"
        Me.colSubtotal.Name = "Subtotal"
        Me.colSubtotal.ReadOnly = True
        Me.colSubtotal.Width = 130
        '
        'GbInputObat
        '
        Me.GbInputObat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbInputObat.Controls.Add(Me.LblLabelJumlah)
        Me.GbInputObat.Controls.Add(Me.LblLabelHarga)
        Me.GbInputObat.Controls.Add(Me.LblLabelNamaObat)
        Me.GbInputObat.Controls.Add(Me.LblLabelIDObat)
        Me.GbInputObat.Controls.Add(Me.TxtIDTransaksi)
        Me.GbInputObat.Controls.Add(Me.TxtNamaObat)
        Me.GbInputObat.Controls.Add(Me.TxtHarga)
        Me.GbInputObat.Controls.Add(Me.TxtJumlah)
        Me.GbInputObat.Controls.Add(Me.BtnTambahList)
        Me.GbInputObat.Location = New System.Drawing.Point(12, 12)
        Me.GbInputObat.Name = "GbInputObat"
        Me.GbInputObat.Size = New System.Drawing.Size(818, 73)
        Me.GbInputObat.TabIndex = 0
        Me.GbInputObat.TabStop = False
        Me.GbInputObat.Text = "Input Obat"
        '
        'LblLabelJumlah
        '
        Me.LblLabelJumlah.AutoSize = True
        Me.LblLabelJumlah.Location = New System.Drawing.Point(606, 34)
        Me.LblLabelJumlah.Name = "LblLabelJumlah"
        Me.LblLabelJumlah.Size = New System.Drawing.Size(48, 15)
        Me.LblLabelJumlah.TabIndex = 8
        Me.LblLabelJumlah.Text = "Jumlah:"
        '
        'LblLabelHarga
        '
        Me.LblLabelHarga.AutoSize = True
        Me.LblLabelHarga.Location = New System.Drawing.Point(443, 34)
        Me.LblLabelHarga.Name = "LblLabelHarga"
        Me.LblLabelHarga.Size = New System.Drawing.Size(42, 15)
        Me.LblLabelHarga.TabIndex = 7
        Me.LblLabelHarga.Text = "Harga:"
        '
        'LblLabelNamaObat
        '
        Me.LblLabelNamaObat.AutoSize = True
        Me.LblLabelNamaObat.Location = New System.Drawing.Point(193, 34)
        Me.LblLabelNamaObat.Name = "LblLabelNamaObat"
        Me.LblLabelNamaObat.Size = New System.Drawing.Size(71, 15)
        Me.LblLabelNamaObat.TabIndex = 6
        Me.LblLabelNamaObat.Text = "Nama Obat:"
        '
        'LblLabelIDObat
        '
        Me.LblLabelIDObat.AutoSize = True
        Me.LblLabelIDObat.Location = New System.Drawing.Point(15, 34)
        Me.LblLabelIDObat.Name = "LblLabelIDObat"
        Me.LblLabelIDObat.Size = New System.Drawing.Size(53, 15)
        Me.LblLabelIDObat.TabIndex = 5
        Me.LblLabelIDObat.Text = "ID Obat:"
        '
        'GbAksi
        '
        Me.GbAksi.Controls.Add(Me.BtnSimpanTransaksi)
        Me.GbAksi.Controls.Add(Me.BtnBatal)
        Me.GbAksi.Controls.Add(Me.BtnHapus)
        Me.GbAksi.Controls.Add(Me.BtnKeluar)
        Me.GbAksi.Location = New System.Drawing.Point(12, 91)
        Me.GbAksi.Name = "GbAksi"
        Me.GbAksi.Size = New System.Drawing.Size(401, 71)
        Me.GbAksi.TabIndex = 1
        Me.GbAksi.TabStop = False
        Me.GbAksi.Text = "Aksi Transaksi"
        '
        'GbKeranjang
        '
        Me.GbKeranjang.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbKeranjang.Controls.Add(Me.DgvListTransaksi)
        Me.GbKeranjang.Location = New System.Drawing.Point(12, 180)
        Me.GbKeranjang.Name = "GbKeranjang"
        Me.GbKeranjang.Size = New System.Drawing.Size(818, 261)
        Me.GbKeranjang.TabIndex = 2
        Me.GbKeranjang.TabStop = False
        Me.GbKeranjang.Text = "Keranjang Belanja"
        '
        'LblLabelTotal
        '
        Me.LblLabelTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLabelTotal.AutoSize = True
        Me.LblLabelTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.LblLabelTotal.Location = New System.Drawing.Point(413, 461)
        Me.LblLabelTotal.Name = "LblLabelTotal"
        Me.LblLabelTotal.Size = New System.Drawing.Size(125, 21)
        Me.LblLabelTotal.TabIndex = 11
        Me.LblLabelTotal.Text = "TOTAL BAYAR:"
        '
        'Transaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 497)
        Me.Controls.Add(Me.LblLabelTotal)
        Me.Controls.Add(Me.GbKeranjang)
        Me.Controls.Add(Me.GbAksi)
        Me.Controls.Add(Me.GbInputObat)
        Me.Controls.Add(Me.LblTotalBayar)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(858, 536)
        Me.Name = "Transaksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Transaksi - Kasir Apotek"
        CType(Me.DgvListTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbInputObat.ResumeLayout(False)
        Me.GbInputObat.PerformLayout()
        Me.GbAksi.ResumeLayout(False)
        Me.GbKeranjang.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtIDTransaksi As TextBox
    Friend WithEvents TxtNamaObat As TextBox
    Friend WithEvents TxtHarga As TextBox
    Friend WithEvents TxtJumlah As TextBox
    Friend WithEvents BtnTambahList As Button
    Friend WithEvents BtnSimpanTransaksi As Button
    Friend WithEvents BtnBatal As Button
    Friend WithEvents BtnHapus As Button
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
    Friend WithEvents LblLabelHarga As Label
    Friend WithEvents LblLabelNamaObat As Label
    Friend WithEvents LblLabelIDObat As Label
    Friend WithEvents GbAksi As GroupBox
    Friend WithEvents GbKeranjang As GroupBox
    Friend WithEvents LblLabelTotal As Label
End Class