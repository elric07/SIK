Imports System.Data.SqlClient

Public Class frmDataMakanan

    Private Sub frmDataBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call bukaDB()
        Call isiGrid()
        Call isiCombo()
        Call isiCombo2()
        Call Otomatis()
        Call EnabledKomponen()
    End Sub

    Sub isiGrid()
        modConnection.bukaDB()
        da = New SqlDataAdapter("SELECT * from tbmasakan", conn)
        ds = New DataSet
        da.Fill(ds, "tbmasakan")
        DataGridView1.DataSource = ds.Tables("tbmasakan")
        DataGridView1.ReadOnly = True
    End Sub


    Sub EnabledKomponen()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False

        Button3.Enabled = False
        Button4.Enabled = False
    End Sub


    Sub Bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        TextBox1.Focus()
        Button1.Text = "Tambah"
    End Sub

    Sub isiCombo()
        Call bukaDB()
        cmd = New SqlCommand("SELECT kodemasakan From tbmasakan", conn)
        rd = cmd.ExecuteReader
        ComboBox1.Enabled = True
        ComboBox1.Items.Clear()
        Do While rd.Read
            ComboBox1.Items.Add(rd.Item(0))
        Loop
        cmd.Dispose()
        rd.Close()
        conn.Close()
    End Sub

    Sub isiCombo2()
        Call bukaDB()
        cmd = New SqlCommand("SELECT jenismasakan From tbjenismasakan", conn)
        rd = cmd.ExecuteReader
        ComboBox2.Enabled = True
        ComboBox2.Items.Clear()
        Do While rd.Read
            ComboBox2.Items.Add(rd.Item(0))
        Loop
        cmd.Dispose()
        rd.Close()
        conn.Close()
    End Sub

    Sub Otomatis()
        modConnection.bukaDB()
        cmd = New SqlCommand("SELECT MAX(kodemasakan) FROM tbmasakan", conn)
        Dim urutan As String
        Dim hitung As Integer
        rd = cmd.ExecuteReader()
        rd.Read()
        If Not rd.IsDBNull(0) Then
            Dim kodeMasakan As String = rd.GetString(0)
            Dim angka As String = kodeMasakan.Substring(1) ' Mengambil angka dari kode masakan
            If Integer.TryParse(angka, hitung) Then
                hitung += 1
                urutan = "M" + hitung.ToString("D3") ' Menggunakan format "D3" untuk memastikan tiga digit angka
                TextBox1.Text = urutan
            Else
                ' Tindakan yang diambil jika angka tidak dapat di-parse
                MessageBox.Show("Format angka tidak valid.")
            End If
        Else
            ' Tindakan yang diambil jika tidak ada data dalam tabel tbmasakan
            hitung = 1
            urutan = "M" + hitung.ToString("D3") ' Menggunakan format "D3" untuk memastikan tiga digit angka
            TextBox1.Text = urutan
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            Otomatis()

            TextBox2.Enabled = True
            TextBox3.Enabled = True

            ComboBox2.Enabled = True

            Button1.Text = "Sim pan"
            TextBox2.Focus()
        Else
            Try
                Call bukaDB()
                cmd = New SqlCommand("SELECT kodemasakan from tbmasakan WHERE kodemasakan = '" & TextBox1.Text & "'", conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    MsgBox("Maaf, Masakan dengan kode tersebut telah ada", MsgBoxStyle.Exclamation, "Peringatan")
                ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                    MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call bukaDB()
                    simpan = "INSERT INTO tbmasakan (kodemasakan,namamasakan,jenismasakan,harga) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox2.Text & "','" & TextBox3.Text & "')"
                    cmd = New SqlCommand(simpan, conn)
                    cmd.ExecuteNonQuery()
                    Call isiGrid()
                    Call Bersih()
                    Call isiCombo()
                    Call EnabledKomponen()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call bukaDB()
        cmd = New SqlCommand("SELECT kodemasakan,namamasakan,jenismasakan,harga FROM tbmasakan WHERE kodemasakan = '" & ComboBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TextBox1.Text = rd.Item(0)
            TextBox2.Text = rd.Item(1)
            TextBox3.Text = rd.Item(3)
            ComboBox2.Text = rd.Item(2)
            TextBox1.Enabled = False
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Call bukaDB()
            hapus = "DELETE FROM tbmasakan WHERE kodemasakan='" & TextBox1.Text & "'"
            cmd = New SqlCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            Call Bersih()
            Call isiGrid()
            Call isiCombo()
            Call EnabledKomponen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Call bukaDB()
            ubah = "UPDATE tbmasakan SET namamasakan='" & TextBox2.Text & "',harga='" & TextBox3.Text & "' WHERE kodemasakan = '" & TextBox1.Text & "'"
            cmd = New SqlCommand(ubah, conn)
            cmd.ExecuteNonQuery()
            Call Bersih()
            Call isiGrid()
            Call isiCombo()
            Call EnabledKomponen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        If e.ColumnIndex = 0 Then

            TextBox2.Enabled = True
            TextBox3.Enabled = True

            ComboBox1.Enabled = True
            ComboBox2.Enabled = True

            Button3.Enabled = True
            Button4.Enabled = True
            'DataGridView1.Rows(e.RowIndex).Cells(0).Value = UCase(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
            Call bukaDB()
            cmd = New SqlCommand("SELECT * from tbmasakan WHERE kodemasakan = '" & DataGridView1.Rows(e.RowIndex).Cells(0).Value & "'", conn)
            rd = cmd.ExecuteReader
            If rd.Read Then
                TextBox1.Text = rd.Item("kodemasakan")
                TextBox2.Text = rd.Item("namamasakan")
                TextBox3.Text = rd.Item("harga")
                ComboBox1.Text = rd.Item("kodemasakan")
                ComboBox2.Text = rd.Item("jenismasakan")
            Else
                MsgBox("Maaf, Data tidak Ditemukan", MsgBoxStyle.Exclamation, "Peringatan")
                DataGridView1.Focus()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class