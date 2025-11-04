<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transaksi
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
        TxtIDTransaksi = New TextBox()
        TxtNamaObat = New TextBox()
        TxtHarga = New TextBox()
        TxtJumlah = New TextBox()
        BtnTambahList = New Button()
        BtnSimpanTransaksi = New Button()
        BtnBatal = New Button()
        BtnHapus = New Button()
        BtnKeluar = New Button()
        LblTotalBayar = New Label()
        DgvListTransaksi = New DataGridView()
        CType(DgvListTransaksi, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TxtIDTransaksi
        ' 
        TxtIDTransaksi.Location = New Point(39, 30)
        TxtIDTransaksi.Name = "TxtIDTransaksi"
        TxtIDTransaksi.Size = New Size(100, 23)
        TxtIDTransaksi.TabIndex = 0
        ' 
        ' TxtNamaObat
        ' 
        TxtNamaObat.Location = New Point(160, 30)
        TxtNamaObat.Name = "TxtNamaObat"
        TxtNamaObat.Size = New Size(100, 23)
        TxtNamaObat.TabIndex = 1
        ' 
        ' TxtHarga
        ' 
        TxtHarga.Location = New Point(276, 30)
        TxtHarga.Name = "TxtHarga"
        TxtHarga.Size = New Size(100, 23)
        TxtHarga.TabIndex = 2
        ' 
        ' TxtJumlah
        ' 
        TxtJumlah.Location = New Point(382, 30)
        TxtJumlah.Name = "TxtJumlah"
        TxtJumlah.Size = New Size(100, 23)
        TxtJumlah.TabIndex = 3
        ' 
        ' BtnTambahList
        ' 
        BtnTambahList.Location = New Point(498, 30)
        BtnTambahList.Name = "BtnTambahList"
        BtnTambahList.Size = New Size(75, 23)
        BtnTambahList.TabIndex = 4
        BtnTambahList.Text = "Tambah"
        BtnTambahList.UseVisualStyleBackColor = True
        ' 
        ' BtnSimpanTransaksi
        ' 
        BtnSimpanTransaksi.Location = New Point(39, 76)
        BtnSimpanTransaksi.Name = "BtnSimpanTransaksi"
        BtnSimpanTransaksi.Size = New Size(75, 23)
        BtnSimpanTransaksi.TabIndex = 5
        BtnSimpanTransaksi.Text = "Simpan"
        BtnSimpanTransaksi.UseVisualStyleBackColor = True
        ' 
        ' BtnBatal
        ' 
        BtnBatal.Location = New Point(120, 76)
        BtnBatal.Name = "BtnBatal"
        BtnBatal.Size = New Size(75, 23)
        BtnBatal.TabIndex = 6
        BtnBatal.Text = "Batal"
        BtnBatal.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Location = New Point(201, 76)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(75, 23)
        BtnHapus.TabIndex = 7
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.Location = New Point(291, 76)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(75, 23)
        BtnKeluar.TabIndex = 8
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = True
        ' 
        ' LblTotalBayar
        ' 
        LblTotalBayar.AutoSize = True
        LblTotalBayar.Location = New Point(253, 195)
        LblTotalBayar.Name = "LblTotalBayar"
        LblTotalBayar.Size = New Size(55, 15)
        LblTotalBayar.TabIndex = 9
        LblTotalBayar.Text = "Rp. xx.xxx"
        ' 
        ' DgvListTransaksi
        ' 
        DgvListTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvListTransaksi.Location = New Point(190, 234)
        DgvListTransaksi.Name = "DgvListTransaksi"
        DgvListTransaksi.Size = New Size(240, 150)
        DgvListTransaksi.TabIndex = 10
        ' 
        ' Transaksi
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(DgvListTransaksi)
        Controls.Add(LblTotalBayar)
        Controls.Add(BtnKeluar)
        Controls.Add(BtnHapus)
        Controls.Add(BtnBatal)
        Controls.Add(BtnSimpanTransaksi)
        Controls.Add(BtnTambahList)
        Controls.Add(TxtJumlah)
        Controls.Add(TxtHarga)
        Controls.Add(TxtNamaObat)
        Controls.Add(TxtIDTransaksi)
        Name = "Transaksi"
        Text = "Transaksi"
        CType(DgvListTransaksi, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
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
End Class
