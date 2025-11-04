<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lihat_Stok
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
        BtnRefresh = New Button()
        TxtCariObat = New TextBox()
        BtnKembali = New Button()
        DgvStokObat = New DataGridView()
        CType(DgvStokObat, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnRefresh
        ' 
        BtnRefresh.Location = New Point(363, 214)
        BtnRefresh.Name = "BtnRefresh"
        BtnRefresh.Size = New Size(75, 23)
        BtnRefresh.TabIndex = 3
        BtnRefresh.Text = "Refresh"
        BtnRefresh.UseVisualStyleBackColor = True
        ' 
        ' TxtCariObat
        ' 
        TxtCariObat.Location = New Point(209, 197)
        TxtCariObat.Name = "TxtCariObat"
        TxtCariObat.Size = New Size(100, 23)
        TxtCariObat.TabIndex = 4
        TxtCariObat.Text = "Cari Obat"
        ' 
        ' BtnKembali
        ' 
        BtnKembali.Location = New Point(363, 273)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(75, 23)
        BtnKembali.TabIndex = 5
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = True
        ' 
        ' DgvStokObat
        ' 
        DgvStokObat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvStokObat.Location = New Point(363, 32)
        DgvStokObat.Name = "DgvStokObat"
        DgvStokObat.Size = New Size(240, 150)
        DgvStokObat.TabIndex = 6
        ' 
        ' Lihat_Stok
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(DgvStokObat)
        Controls.Add(BtnKembali)
        Controls.Add(TxtCariObat)
        Controls.Add(BtnRefresh)
        Name = "Lihat_Stok"
        Text = "Lihat_Stok"
        CType(DgvStokObat, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnRefresh As Button
    Friend WithEvents TxtCariObat As TextBox
    Friend WithEvents BtnKembali As Button
    Friend WithEvents DgvStokObat As DataGridView
End Class
