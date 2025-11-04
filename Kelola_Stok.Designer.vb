<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kelola_Stok
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
        TxtIDObat = New TextBox()
        TxtNamaObat = New TextBox()
        CmbJenis = New ComboBox()
        TxtHarga = New TextBox()
        TxtStok = New TextBox()
        DtpKadaluarsa = New DateTimePicker()
        DgvObat = New DataGridView()
        BtnTambah = New Button()
        BtnUbah = New Button()
        BtnHapus = New Button()
        BtnBersih = New Button()
        CType(DgvObat, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TxtIDObat
        ' 
        TxtIDObat.Location = New Point(36, 23)
        TxtIDObat.Name = "TxtIDObat"
        TxtIDObat.Size = New Size(100, 23)
        TxtIDObat.TabIndex = 0
        ' 
        ' TxtNamaObat
        ' 
        TxtNamaObat.Location = New Point(36, 52)
        TxtNamaObat.Name = "TxtNamaObat"
        TxtNamaObat.Size = New Size(100, 23)
        TxtNamaObat.TabIndex = 1
        ' 
        ' CmbJenis
        ' 
        CmbJenis.FormattingEnabled = True
        CmbJenis.Location = New Point(36, 81)
        CmbJenis.Name = "CmbJenis"
        CmbJenis.Size = New Size(121, 23)
        CmbJenis.TabIndex = 2
        ' 
        ' TxtHarga
        ' 
        TxtHarga.Location = New Point(36, 110)
        TxtHarga.Name = "TxtHarga"
        TxtHarga.Size = New Size(100, 23)
        TxtHarga.TabIndex = 3
        ' 
        ' TxtStok
        ' 
        TxtStok.Location = New Point(36, 139)
        TxtStok.Name = "TxtStok"
        TxtStok.Size = New Size(100, 23)
        TxtStok.TabIndex = 4
        ' 
        ' DtpKadaluarsa
        ' 
        DtpKadaluarsa.CustomFormat = "dd MMM yyyy"
        DtpKadaluarsa.Format = DateTimePickerFormat.Custom
        DtpKadaluarsa.Location = New Point(36, 168)
        DtpKadaluarsa.Name = "DtpKadaluarsa"
        DtpKadaluarsa.Size = New Size(200, 23)
        DtpKadaluarsa.TabIndex = 5
        ' 
        ' DgvObat
        ' 
        DgvObat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvObat.Location = New Point(78, 228)
        DgvObat.Name = "DgvObat"
        DgvObat.Size = New Size(240, 150)
        DgvObat.TabIndex = 6
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Location = New Point(364, 29)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(75, 23)
        BtnTambah.TabIndex = 7
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = True
        ' 
        ' BtnUbah
        ' 
        BtnUbah.Location = New Point(364, 58)
        BtnUbah.Name = "BtnUbah"
        BtnUbah.Size = New Size(75, 23)
        BtnUbah.TabIndex = 8
        BtnUbah.Text = "Ubah"
        BtnUbah.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Location = New Point(364, 87)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(75, 23)
        BtnHapus.TabIndex = 9
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' BtnBersih
        ' 
        BtnBersih.Location = New Point(364, 116)
        BtnBersih.Name = "BtnBersih"
        BtnBersih.Size = New Size(75, 23)
        BtnBersih.TabIndex = 10
        BtnBersih.Text = "Bersihkan"
        BtnBersih.UseVisualStyleBackColor = True
        ' 
        ' Kelola_Stok
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(BtnBersih)
        Controls.Add(BtnHapus)
        Controls.Add(BtnUbah)
        Controls.Add(BtnTambah)
        Controls.Add(DgvObat)
        Controls.Add(DtpKadaluarsa)
        Controls.Add(TxtStok)
        Controls.Add(TxtHarga)
        Controls.Add(CmbJenis)
        Controls.Add(TxtNamaObat)
        Controls.Add(TxtIDObat)
        Name = "Kelola_Stok"
        Text = "Kelola_Stok"
        CType(DgvObat, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtIDObat As TextBox
    Friend WithEvents TxtNamaObat As TextBox
    Friend WithEvents CmbJenis As ComboBox
    Friend WithEvents TxtHarga As TextBox
    Friend WithEvents TxtStok As TextBox
    Friend WithEvents DtpKadaluarsa As DateTimePicker
    Friend WithEvents DgvObat As DataGridView
    Friend WithEvents BtnTambah As Button
    Friend WithEvents BtnUbah As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnBersih As Button
End Class
