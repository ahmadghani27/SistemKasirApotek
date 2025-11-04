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
        DateTimePicker1 = New DateTimePicker()
        DgvRiwayat = New DataGridView()
        BtnLihatDetail = New Button()
        LblTotalHarian = New Label()
        BtnKembali = New Button()
        CType(DgvRiwayat, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CustomFormat = "dd MMM yyyy"
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.Location = New Point(64, 45)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(200, 23)
        DateTimePicker1.TabIndex = 0
        ' 
        ' DgvRiwayat
        ' 
        DgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvRiwayat.Location = New Point(83, 112)
        DgvRiwayat.Name = "DgvRiwayat"
        DgvRiwayat.Size = New Size(240, 150)
        DgvRiwayat.TabIndex = 1
        ' 
        ' BtnLihatDetail
        ' 
        BtnLihatDetail.Location = New Point(147, 320)
        BtnLihatDetail.Name = "BtnLihatDetail"
        BtnLihatDetail.Size = New Size(75, 23)
        BtnLihatDetail.TabIndex = 2
        BtnLihatDetail.Text = "Tampilkan"
        BtnLihatDetail.UseVisualStyleBackColor = True
        ' 
        ' LblTotalHarian
        ' 
        LblTotalHarian.AutoSize = True
        LblTotalHarian.Location = New Point(373, 218)
        LblTotalHarian.Name = "LblTotalHarian"
        LblTotalHarian.Size = New Size(55, 15)
        LblTotalHarian.TabIndex = 10
        LblTotalHarian.Text = "Rp. xx.xxx"
        ' 
        ' BtnKembali
        ' 
        BtnKembali.Location = New Point(341, 291)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(75, 23)
        BtnKembali.TabIndex = 11
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = True
        ' 
        ' Lihat_Stok
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(BtnKembali)
        Controls.Add(LblTotalHarian)
        Controls.Add(BtnLihatDetail)
        Controls.Add(DgvRiwayat)
        Controls.Add(DateTimePicker1)
        Name = "Lihat_Stok"
        Text = "Lihat_Stok"
        CType(DgvRiwayat, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DgvRiwayat As DataGridView
    Friend WithEvents BtnLihatDetail As Button
    Friend WithEvents LblTotalHarian As Label
    Friend WithEvents BtnKembali As Button
End Class
