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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DgvRiwayat = New System.Windows.Forms.DataGridView()
        Me.ColIDTransaksi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWaktu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKasir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnCari = New System.Windows.Forms.Button()
        Me.LblTotalHarian = New System.Windows.Forms.Label()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.GbFilter = New System.Windows.Forms.GroupBox()
        Me.LblLabelTotal = New System.Windows.Forms.Label()
        Me.LblPilihTanggal = New System.Windows.Forms.Label()
        Me.DgvDetail = New System.Windows.Forms.DataGridView()
        Me.ColNamaObat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJumlah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblDetail = New System.Windows.Forms.Label()
        CType(Me.DgvRiwayat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbFilter.SuspendLayout()
        CType(Me.DgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd MMMM yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(100, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(155, 23)
        Me.DateTimePicker1.TabIndex = 0
        '
        'DgvRiwayat
        '
        Me.DgvRiwayat.AllowUserToAddRows = False
        Me.DgvRiwayat.AllowUserToDeleteRows = False
        Me.DgvRiwayat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvRiwayat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRiwayat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIDTransaksi, Me.ColWaktu, Me.ColTotal, Me.ColKasir})
        Me.DgvRiwayat.Location = New System.Drawing.Point(12, 102)
        Me.DgvRiwayat.MultiSelect = False
        Me.DgvRiwayat.Name = "DgvRiwayat"
        Me.DgvRiwayat.ReadOnly = True
        Me.DgvRiwayat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRiwayat.Size = New System.Drawing.Size(776, 178)
        Me.DgvRiwayat.TabIndex = 1
        '
        'ColIDTransaksi
        '
        Me.ColIDTransaksi.HeaderText = "ID Transaksi"
        Me.ColIDTransaksi.Name = "IDTransaksi"
        Me.ColIDTransaksi.ReadOnly = True
        Me.ColIDTransaksi.Width = 150
        '
        'ColWaktu
        '
        Me.ColWaktu.HeaderText = "Waktu"
        Me.ColWaktu.Name = "Waktu"
        Me.ColWaktu.ReadOnly = True
        '
        'ColTotal
        '
        Me.ColTotal.HeaderText = "Total"
        Me.ColTotal.Name = "Total"
        Me.ColTotal.ReadOnly = True
        Me.ColTotal.Width = 120
        '
        'ColKasir
        '
        Me.ColKasir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColKasir.HeaderText = "Kasir"
        Me.ColKasir.Name = "Kasir"
        Me.ColKasir.ReadOnly = True
        '
        'BtnCari
        '
        Me.BtnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCari.Location = New System.Drawing.Point(261, 27)
        Me.BtnCari.Name = "BtnCari"
        Me.BtnCari.Size = New System.Drawing.Size(75, 25)
        Me.BtnCari.TabIndex = 2
        Me.BtnCari.Text = "Cari"
        Me.BtnCari.UseVisualStyleBackColor = True
        '
        'LblTotalHarian
        '
        Me.LblTotalHarian.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalHarian.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.LblTotalHarian.Location = New System.Drawing.Point(582, 30)
        Me.LblTotalHarian.Name = "LblTotalHarian"
        Me.LblTotalHarian.Size = New System.Drawing.Size(188, 21)
        Me.LblTotalHarian.TabIndex = 10
        Me.LblTotalHarian.Text = "Rp 0"
        Me.LblTotalHarian.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnKembali
        '
        Me.BtnKembali.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnKembali.Location = New System.Drawing.Point(342, 27)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(75, 25)
        Me.BtnKembali.TabIndex = 11
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'GbFilter
        '
        Me.GbFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbFilter.Controls.Add(Me.LblLabelTotal)
        Me.GbFilter.Controls.Add(Me.LblPilihTanggal)
        Me.GbFilter.Controls.Add(Me.DateTimePicker1)
        Me.GbFilter.Controls.Add(Me.BtnKembali)
        Me.GbFilter.Controls.Add(Me.BtnCari)
        Me.GbFilter.Controls.Add(Me.LblTotalHarian)
        Me.GbFilter.Location = New System.Drawing.Point(12, 12)
        Me.GbFilter.Name = "GbFilter"
        Me.GbFilter.Size = New System.Drawing.Size(776, 73)
        Me.GbFilter.TabIndex = 0
        Me.GbFilter.TabStop = False
        Me.GbFilter.Text = "Filter Riwayat"
        '
        'LblLabelTotal
        '
        Me.LblLabelTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLabelTotal.AutoSize = True
        Me.LblLabelTotal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.LblLabelTotal.Location = New System.Drawing.Point(461, 33)
        Me.LblLabelTotal.Name = "LblLabelTotal"
        Me.LblLabelTotal.Size = New System.Drawing.Size(115, 17)
        Me.LblLabelTotal.TabIndex = 13
        Me.LblLabelTotal.Text = "Total Pendapatan:"
        '
        'LblPilihTanggal
        '
        Me.LblPilihTanggal.AutoSize = True
        Me.LblPilihTanggal.Location = New System.Drawing.Point(15, 32)
        Me.LblPilihTanggal.Name = "LblPilihTanggal"
        Me.LblPilihTanggal.Size = New System.Drawing.Size(79, 15)
        Me.LblPilihTanggal.TabIndex = 12
        Me.LblPilihTanggal.Text = "Pilih Tanggal:"
        '
        'DgvDetail
        '
        Me.DgvDetail.AllowUserToAddRows = False
        Me.DgvDetail.AllowUserToDeleteRows = False
        Me.DgvDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNamaObat, Me.ColHarga, Me.ColJumlah, Me.ColSubtotal})
        Me.DgvDetail.Location = New System.Drawing.Point(12, 311)
        Me.DgvDetail.Name = "DgvDetail"
        Me.DgvDetail.ReadOnly = True
        Me.DgvDetail.Size = New System.Drawing.Size(776, 176)
        Me.DgvDetail.TabIndex = 2
        '
        'ColNamaObat
        '
        Me.ColNamaObat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNamaObat.HeaderText = "Nama Obat"
        Me.ColNamaObat.Name = "NamaObat"
        Me.ColNamaObat.ReadOnly = True
        '
        'ColHarga
        '
        Me.ColHarga.HeaderText = "Harga"
        Me.ColHarga.Name = "Harga"
        Me.ColHarga.ReadOnly = True
        Me.ColHarga.Width = 120
        '
        'ColJumlah
        '
        Me.ColJumlah.HeaderText = "Jumlah"
        Me.ColJumlah.Name = "Jumlah"
        Me.ColJumlah.ReadOnly = True
        Me.ColJumlah.Width = 80
        '
        'ColSubtotal
        '
        Me.ColSubtotal.HeaderText = "Subtotal"
        Me.ColSubtotal.Name = "Subtotal"
        Me.ColSubtotal.ReadOnly = True
        Me.ColSubtotal.Width = 130
        '
        'LblDetail
        '
        Me.LblDetail.AutoSize = True
        Me.LblDetail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.LblDetail.Location = New System.Drawing.Point(12, 290)
        Me.LblDetail.Name = "LblDetail"
        Me.LblDetail.Size = New System.Drawing.Size(184, 15)
        Me.LblDetail.TabIndex = 13
        Me.LblDetail.Text = "Detail Item (klik baris di atas):"
        '
        'Riwayat_Transaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 499)
        Me.Controls.Add(Me.LblDetail)
        Me.Controls.Add(Me.DgvDetail)
        Me.Controls.Add(Me.GbFilter)
        Me.Controls.Add(Me.DgvRiwayat)
        Me.MinimumSize = New System.Drawing.Size(700, 500)
        Me.Name = "Riwayat_Transaksi"
        Me.Text = "Riwayat Transaksi"
        CType(Me.DgvRiwayat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbFilter.ResumeLayout(False)
        Me.GbFilter.PerformLayout()
        CType(Me.DgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DgvRiwayat As DataGridView
    Friend WithEvents BtnCari As Button ' Diubah dari BtnLihatDetail
    Friend WithEvents LblTotalHarian As Label
    Friend WithEvents BtnKembali As Button
    Friend WithEvents GbFilter As GroupBox
    Friend WithEvents LblPilihTanggal As Label
    Friend WithEvents LblLabelTotal As Label
    Friend WithEvents DgvDetail As DataGridView ' Grid baru ditambahkan
    Friend WithEvents ColIDTransaksi As DataGridViewTextBoxColumn
    Friend WithEvents ColWaktu As DataGridViewTextBoxColumn
    Friend WithEvents ColTotal As DataGridViewTextBoxColumn
    Friend WithEvents ColKasir As DataGridViewTextBoxColumn
    Friend WithEvents ColNamaObat As DataGridViewTextBoxColumn
    Friend WithEvents ColHarga As DataGridViewTextBoxColumn
    Friend WithEvents ColJumlah As DataGridViewTextBoxColumn
    Friend WithEvents ColSubtotal As DataGridViewTextBoxColumn
    Friend WithEvents LblDetail As Label
End Class