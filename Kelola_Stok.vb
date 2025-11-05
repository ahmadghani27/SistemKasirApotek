Imports System.Data

Public Class Kelola_Stok

    ' In-memory table used as example data source.
    ' Replace with real DB code as needed (see comments below).
    Private dtObat As DataTable

    Private Sub Kelola_Stok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitTable()
        BindGrid()
        InitCombo()
        WireEvents()
    End Sub

    Private Sub InitTable()
        dtObat = New DataTable()
        dtObat.Columns.Add("IDObat", GetType(String))
        dtObat.Columns.Add("NamaObat", GetType(String))
        dtObat.Columns.Add("Jenis", GetType(String))
        dtObat.Columns.Add("Harga", GetType(Decimal))
        dtObat.Columns.Add("Stok", GetType(Integer))
        dtObat.Columns.Add("Kadaluarsa", GetType(Date))

        ' Example seed (optional)
        dtObat.Rows.Add("OBT001", "Paracetamol", "Tablet", 1500D, 50, New Date(2026, 6, 30))
        dtObat.Rows.Add("OBT002", "Sirup Anak", "Sirup", 25000D, 20, New Date(2025, 12, 31))
    End Sub

    Private Sub BindGrid()
        DgvObat.DataSource = dtObat
    End Sub

    Private Sub InitCombo()
        CmbJenis.Items.Clear()
        CmbJenis.Items.AddRange(New String() {"Tablet", "Sirup", "Salep", "Kapsul", "Injeksi", "Lainnya"})
        If CmbJenis.Items.Count > 0 Then CmbJenis.SelectedIndex = 0
    End Sub

    Private Sub WireEvents()
        AddHandler BtnTambah.Click, AddressOf BtnTambah_Click
        AddHandler BtnUbah.Click, AddressOf BtnUbah_Click
        AddHandler BtnHapus.Click, AddressOf BtnHapus_Click
        AddHandler BtnBersih.Click, AddressOf BtnBersih_Click
        AddHandler DgvObat.SelectionChanged, AddressOf DgvObat_SelectionChanged
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs)
        ' Validate
        Dim id = TxtIDObat.Text.Trim()
        If id = "" Then
            MessageBox.Show("ID Obat wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtIDObat.Focus()
            Return
        End If

        If dtObat.Select($"IDObat = '{id.Replace("'", "''")}'").Length > 0 Then
            MessageBox.Show("ID Obat sudah ada. Gunakan ID unik.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtIDObat.Focus()
            Return
        End If

        Dim nama = TxtNamaObat.Text.Trim()
        If nama = "" Then
            MessageBox.Show("Nama Obat wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNamaObat.Focus()
            Return
        End If

        Dim hargaDecimal As Decimal
        If Not Decimal.TryParse(TxtHarga.Text.Trim(), hargaDecimal) OrElse hargaDecimal < 0D Then
            MessageBox.Show("Harga harus angka positif.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtHarga.Focus()
            Return
        End If

        Dim stokInt As Integer
        If Not Integer.TryParse(TxtStok.Text.Trim(), stokInt) OrElse stokInt < 0 Then
            MessageBox.Show("Stok harus bilangan bulat >= 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtStok.Focus()
            Return
        End If

        Dim jenis = If(CmbJenis.SelectedItem IsNot Nothing, CmbJenis.SelectedItem.ToString(), "")
        Dim kadaluarsa = DtpKadaluarsa.Value.Date

        dtObat.Rows.Add(id, nama, jenis, hargaDecimal, stokInt, kadaluarsa)

        ' TODO: Insert into database here (use parameterized queries)
        ' Example: INSERT INTO obat (IDObat, NamaObat, Jenis, Harga, Stok, Kadaluarsa) VALUES (...)

        ClearInputs()
    End Sub

    Private Sub BtnUbah_Click(sender As Object, e As EventArgs)
        If DgvObat.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih baris data untuk diubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row As DataRow = CType(DgvObat.SelectedRows(0).DataBoundItem.Row, DataRow)
        If row Is Nothing Then Return

        ' Validate similar to tambah
        Dim nama = TxtNamaObat.Text.Trim()
        If nama = "" Then
            MessageBox.Show("Nama Obat wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNamaObat.Focus()
            Return
        End If

        Dim hargaDecimal As Decimal
        If Not Decimal.TryParse(TxtHarga.Text.Trim(), hargaDecimal) OrElse hargaDecimal < 0D Then
            MessageBox.Show("Harga harus angka positif.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtHarga.Focus()
            Return
        End If

        Dim stokInt As Integer
        If Not Integer.TryParse(TxtStok.Text.Trim(), stokInt) OrElse stokInt < 0 Then
            MessageBox.Show("Stok harus bilangan bulat >= 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtStok.Focus()
            Return
        End If

        row("NamaObat") = nama
        row("Jenis") = If(CmbJenis.SelectedItem IsNot Nothing, CmbJenis.SelectedItem.ToString(), "")
        row("Harga") = hargaDecimal
        row("Stok") = stokInt
        row("Kadaluarsa") = DtpKadaluarsa.Value.Date

        ' TODO: Update database here (use parameterized queries)
        ' Example: UPDATE obat SET NamaObat = ..., WHERE IDObat = ...

        ' Refresh grid
        DgvObat.Refresh()
        ClearInputs()
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        If DgvObat.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih baris data untuk dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show("Yakin ingin menghapus data obat yang dipilih?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim row As DataRow = CType(DgvObat.SelectedRows(0).DataBoundItem.Row, DataRow)
        If row Is Nothing Then Return

        Dim id = row("IDObat").ToString()
        row.Delete()

        ' TODO: Delete from database here (use parameterized queries)
        ' Example: DELETE FROM obat WHERE IDObat = @id

        ClearInputs()
    End Sub

    Private Sub BtnBersih_Click(sender As Object, e As EventArgs)
        ClearInputs()
    End Sub

    Private Sub ClearInputs()
        TxtIDObat.Clear()
        TxtNamaObat.Clear()
        If CmbJenis.Items.Count > 0 Then CmbJenis.SelectedIndex = 0
        TxtHarga.Clear()
        TxtStok.Clear()
        DtpKadaluarsa.Value = Date.Today
        DgvObat.ClearSelection()
    End Sub

    Private Sub DgvObat_SelectionChanged(sender As Object, e As EventArgs)
        If DgvObat.SelectedRows.Count = 0 Then
            Return
        End If

        Dim row As DataRow = CType(DgvObat.SelectedRows(0).DataBoundItem.Row, DataRow)
        If row Is Nothing Then Return

        TxtIDObat.Text = row("IDObat").ToString()
        TxtNamaObat.Text = row("NamaObat").ToString()
        Dim jenis = row("Jenis").ToString()
        If CmbJenis.Items.Contains(jenis) Then
            CmbJenis.SelectedItem = jenis
        Else
            ' If jenis not in list, add temporarily
            If jenis <> "" Then
                CmbJenis.Items.Add(jenis)
                CmbJenis.SelectedItem = jenis
            End If
        End If
        TxtHarga.Text = Convert.ToDecimal(row("Harga")).ToString("0.##")
        TxtStok.Text = row("Stok").ToString()
        DtpKadaluarsa.Value = Convert.ToDateTime(row("Kadaluarsa"))
    End Sub

    Private Sub LblJenis_Click(sender As Object, e As EventArgs) Handles LblJenis.Click

    End Sub
End Class