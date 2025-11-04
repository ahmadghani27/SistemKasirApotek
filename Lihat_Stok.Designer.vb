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
        BtnRefresh = New Button()
        TxtCariObat = New TextBox()
        BtnKembali = New Button()
        DgvStokObat = New DataGridView()
        ColKodeObat = New DataGridViewTextBoxColumn()
        ColNamaObat = New DataGridViewTextBoxColumn()
        ColKategori = New DataGridViewTextBoxColumn()
        ColStok = New DataGridViewTextBoxColumn()
        ColHarga = New DataGridViewTextBoxColumn()
        GbFilter = New GroupBox()
        LblCari = New Label()
        CType(DgvStokObat, ComponentModel.ISupportInitialize).BeginInit()
        GbFilter.SuspendLayout()
        SuspendLayout()
        ' 
        ' BtnRefresh
        ' 
        BtnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnRefresh.FlatStyle = FlatStyle.Flat
        BtnRefresh.Location = New Point(595, 26)
        BtnRefresh.Name = "BtnRefresh"
        BtnRefresh.Size = New Size(84, 27)
        BtnRefresh.TabIndex = 2
        BtnRefresh.Text = "Refresh"
        BtnRefresh.UseVisualStyleBackColor = True
        ' 
        ' TxtCariObat
        ' 
        TxtCariObat.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtCariObat.Location = New Point(84, 29)
        TxtCariObat.Name = "TxtCariObat"
        TxtCariObat.PlaceholderText = "Ketik nama atau kode obat..."
        TxtCariObat.Size = New Size(505, 23)
        TxtCariObat.TabIndex = 1
        ' 
        ' BtnKembali
        ' 
        BtnKembali.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnKembali.FlatStyle = FlatStyle.Flat
        BtnKembali.Location = New Point(685, 26)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(84, 27)
        BtnKembali.TabIndex = 3
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = True
        ' 
        ' DgvStokObat
        ' 
        DgvStokObat.AllowUserToAddRows = False
        DgvStokObat.AllowUserToDeleteRows = False
        DgvStokObat.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvStokObat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvStokObat.Columns.AddRange(New DataGridViewColumn() {ColKodeObat, ColNamaObat, ColKategori, ColStok, ColHarga})
        DgvStokObat.Location = New Point(12, 91)
        DgvStokObat.Name = "DgvStokObat"
        DgvStokObat.ReadOnly = True
        DgvStokObat.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvStokObat.Size = New Size(776, 347)
        DgvStokObat.TabIndex = 1
        ' 
        ' ColKodeObat
        ' 
        ColKodeObat.HeaderText = "Kode Obat"
        ColKodeObat.Name = "ColKodeObat"
        ColKodeObat.ReadOnly = True
        ColKodeObat.Width = 120
        ' 
        ' ColNamaObat
        ' 
        ColNamaObat.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ColNamaObat.HeaderText = "Nama Obat"
        ColNamaObat.Name = "ColNamaObat"
        ColNamaObat.ReadOnly = True
        ' 
        ' ColKategori
        ' 
        ColKategori.HeaderText = "Kategori"
        ColKategori.Name = "ColKategori"
        ColKategori.ReadOnly = True
        ColKategori.Width = 150
        ' 
        ' ColStok
        ' 
        ColStok.HeaderText = "Stok"
        ColStok.Name = "ColStok"
        ColStok.ReadOnly = True
        ColStok.Width = 80
        ' 
        ' ColHarga
        ' 
        ColHarga.HeaderText = "Harga"
        ColHarga.Name = "ColHarga"
        ColHarga.ReadOnly = True
        ColHarga.Width = 120
        ' 
        ' GbFilter
        ' 
        GbFilter.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GbFilter.Controls.Add(LblCari)
        GbFilter.Controls.Add(TxtCariObat)
        GbFilter.Controls.Add(BtnRefresh)
        GbFilter.Controls.Add(BtnKembali)
        GbFilter.Location = New Point(12, 12)
        GbFilter.Name = "GbFilter"
        GbFilter.Size = New Size(776, 73)
        GbFilter.TabIndex = 0
        GbFilter.TabStop = False
        GbFilter.Text = "Pencarian"
        ' 
        ' LblCari
        ' 
        LblCari.AutoSize = True
        LblCari.Location = New Point(15, 33)
        LblCari.Name = "LblCari"
        LblCari.Size = New Size(60, 15)
        LblCari.TabIndex = 0
        LblCari.Text = "Cari Obat:"
        ' 
        ' Lihat_Stok
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(GbFilter)
        Controls.Add(DgvStokObat)
        MinimumSize = New Size(600, 400)
        Name = "Lihat_Stok"
        StartPosition = FormStartPosition.CenterParent
        Text = "Lihat Stok Obat"
        CType(DgvStokObat, ComponentModel.ISupportInitialize).EndInit()
        GbFilter.ResumeLayout(False)
        GbFilter.PerformLayout()
        ResumeLayout(False)

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