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
        BtnPilih = New Button()
        Button1 = New Button()
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
        ' BtnPilih
        ' 
        BtnPilih.FlatStyle = FlatStyle.Flat
        BtnPilih.Location = New Point(704, 237)
        BtnPilih.Name = "BtnPilih"
        BtnPilih.Size = New Size(84, 27)
        BtnPilih.TabIndex = 12
        BtnPilih.Text = "Pilih"
        BtnPilih.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(614, 237)
        Button1.Name = "Button1"
        Button1.Size = New Size(84, 27)
        Button1.TabIndex = 13
        Button1.Text = "Keluar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' FormHasilPencarian
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(BtnPilih)
        Controls.Add(DgvHasilPencarian)
        Name = "FormHasilPencarian"
        Text = "ujicoba"
        CType(DgvHasilPencarian, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DgvHasilPencarian As DataGridView
    Friend WithEvents BtnPilih As Button
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colNama As DataGridViewTextBoxColumn
    Friend WithEvents colHarga As DataGridViewTextBoxColumn
    Friend WithEvents colJumlah As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
End Class
