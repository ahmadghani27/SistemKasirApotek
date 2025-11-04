<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Lihat_Stok
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
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.TxtCariObat = New System.Windows.Forms.TextBox()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.DgvStokObat = New System.Windows.Forms.DataGridView()
        Me.GbFilter = New System.Windows.Forms.GroupBox()
        Me.LblCari = New System.Windows.Forms.Label()
        Me.ColKodeObat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNamaObat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKategori = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStok = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKadaluarsa = New System.Windows.Forms.DataGridViewTextBoxColumn() ' <-- TAMBAHAN
        Me.ColHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvStokObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefresh.Location = New System.Drawing.Point(595, 26)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(84, 27)
        Me.BtnRefresh.TabIndex = 2
        Me.BtnRefresh.Text = "Refresh"
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'TxtCariObat
        '
        Me.TxtCariObat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCariObat.Location = New System.Drawing.Point(84, 29)
        Me.TxtCariObat.Name = "TxtCariObat"
        Me.TxtCariObat.PlaceholderText = "Ketik nama atau kode obat..."
        Me.TxtCariObat.Size = New System.Drawing.Size(505, 23)
        Me.TxtCariObat.TabIndex = 1
        '
        'BtnKembali
        '
        Me.BtnKembali.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnKembali.Location = New System.Drawing.Point(685, 26)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(84, 27)
        Me.BtnKembali.TabIndex = 3
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'DgvStokObat
        '
        Me.DgvStokObat.AllowUserToAddRows = False
        Me.DgvStokObat.AllowUserToDeleteRows = False
        Me.DgvStokObat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvStokObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvStokObat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColKodeObat, Me.ColNamaObat, Me.ColKategori, Me.ColStok, Me.ColKadaluarsa, Me.ColHarga}) ' <-- TAMBAHAN DISINI
        Me.DgvStokObat.Location = New System.Drawing.Point(12, 91)
        Me.DgvStokObat.Name = "DgvStokObat"
        Me.DgvStokObat.ReadOnly = True
        Me.DgvStokObat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvStokObat.Size = New System.Drawing.Size(776, 347)
        Me.DgvStokObat.TabIndex = 1
        '
        'GbFilter
        '
        Me.GbFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbFilter.Controls.Add(Me.LblCari)
        Me.GbFilter.Controls.Add(Me.TxtCariObat)
        Me.GbFilter.Controls.Add(Me.BtnRefresh)
        Me.GbFilter.Controls.Add(Me.BtnKembali)
        Me.GbFilter.Location = New System.Drawing.Point(12, 12)
        Me.GbFilter.Name = "GbFilter"
        Me.GbFilter.Size = New System.Drawing.Size(776, 73)
        Me.GbFilter.TabIndex = 0
        Me.GbFilter.TabStop = False
        Me.GbFilter.Text = "Pencarian"
        '
        'LblCari
        '
        Me.LblCari.AutoSize = True
        Me.LblCari.Location = New System.Drawing.Point(15, 33)
        Me.LblCari.Name = "LblCari"
        Me.LblCari.Size = New System.Drawing.Size(63, 15)
        Me.LblCari.TabIndex = 0
        Me.LblCari.Text = "Cari Obat:"
        '
        'ColKodeObat
        '
        Me.ColKodeObat.HeaderText = "Kode Obat"
        Me.ColKodeObat.Name = "ColKodeObat"
        Me.ColKodeObat.ReadOnly = True
        Me.ColKodeObat.Width = 120
        '
        'ColNamaObat
        '
        Me.ColNamaObat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNamaObat.HeaderText = "Nama Obat"
        Me.ColNamaObat.Name = "ColNamaObat"
        Me.ColNamaObat.ReadOnly = True
        '
        'ColKategori
        '
        Me.ColKategori.HeaderText = "Kategori"
        Me.ColKategori.Name = "ColKategori"
        Me.ColKategori.ReadOnly = True
        Me.ColKategori.Width = 150
        '
        'ColStok
        '
        Me.ColStok.HeaderText = "Stok"
        Me.ColStok.Name = "ColStok"
        Me.ColStok.ReadOnly = True
        Me.ColStok.Width = 80
        '
        'ColKadaluarsa
        '
        Me.ColKadaluarsa.HeaderText = "Kadaluarsa"
        Me.ColKadaluarsa.Name = "ColKadaluarsa"
        Me.ColKadaluarsa.ReadOnly = True
        Me.ColKadaluarsa.Width = 110
        '
        'ColHarga
        '
        Me.ColHarga.HeaderText = "Harga"
        Me.ColHarga.Name = "ColHarga"
        Me.ColHarga.ReadOnly = True
        Me.ColHarga.Width = 120
        '
        'Lihat_Stok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GbFilter)
        Me.Controls.Add(Me.DgvStokObat)
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "Lihat_Stok"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lihat Stok Obat"
        CType(Me.DgvStokObat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbFilter.ResumeLayout(False)
        Me.GbFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnRefresh As Button
    Friend WithEvents TxtCariObat As TextBox
    Friend WithEvents BtnKembali As Button
    Friend WithEvents DgvStokObat As DataGridView
    Friend WithEvents GbFilter As GroupBox
    Friend WithEvents LblCari As Label
    Friend WithEvents ColKodeObat As DataGridViewTextBoxColumn
    Friend WithEvents ColNamaObat As DataGridViewTextBoxColumn
    Friend WithEvents ColKategori As DataGridViewTextBoxColumn
    Friend WithEvents ColStok As DataGridViewTextBoxColumn
    Friend WithEvents ColHarga As DataGridViewTextBoxColumn
    Friend WithEvents ColKadaluarsa As DataGridViewTextBoxColumn ' <-- TAMBAHAN
End Class