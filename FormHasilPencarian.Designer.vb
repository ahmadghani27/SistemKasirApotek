<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHasilPencarian
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
        DgvHasilPencarian = New DataGridView()
        colID = New DataGridViewTextBoxColumn()
        colNama = New DataGridViewTextBoxColumn()
        colHarga = New DataGridViewTextBoxColumn()
        colJumlah = New DataGridViewTextBoxColumn()
        BtnKeluar = New Button()
        LblLabelJumlah = New Label()
        CType(DgvHasilPencarian, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvHasilPencarian
        ' 
        DgvHasilPencarian.AllowUserToAddRows = False
        DgvHasilPencarian.AllowUserToDeleteRows = False
        DgvHasilPencarian.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvHasilPencarian.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvHasilPencarian.Columns.AddRange(New DataGridViewColumn() {colID, colNama, colHarga, colJumlah})
        DgvHasilPencarian.Location = New Point(12, 12)
        DgvHasilPencarian.Name = "DgvHasilPencarian"
        DgvHasilPencarian.ReadOnly = True
        DgvHasilPencarian.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvHasilPencarian.Size = New Size(776, 219)
        DgvHasilPencarian.TabIndex = 11
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
        ' BtnKeluar
        ' 
        BtnKeluar.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        BtnKeluar.Cursor = Cursors.Hand
        BtnKeluar.FlatStyle = FlatStyle.Popup
        BtnKeluar.Location = New Point(588, 237)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(200, 27)
        BtnKeluar.TabIndex = 13
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = False
        ' 
        ' LblLabelJumlah
        ' 
        LblLabelJumlah.AutoSize = True
        LblLabelJumlah.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        LblLabelJumlah.Location = New Point(12, 243)
        LblLabelJumlah.Name = "LblLabelJumlah"
        LblLabelJumlah.Size = New Size(144, 15)
        LblLabelJumlah.TabIndex = 14
        LblLabelJumlah.Text = "! Klik 2 Kali untuk memilih"
        ' 
        ' FormHasilPencarian
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 274)
        Controls.Add(LblLabelJumlah)
        Controls.Add(BtnKeluar)
        Controls.Add(DgvHasilPencarian)
        Name = "FormHasilPencarian"
        StartPosition = FormStartPosition.CenterParent
        Text = "ujicoba"
        CType(DgvHasilPencarian, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvHasilPencarian As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colNama As DataGridViewTextBoxColumn
    Friend WithEvents colHarga As DataGridViewTextBoxColumn
    Friend WithEvents colJumlah As DataGridViewTextBoxColumn
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents LblLabelJumlah As Label
End Class
