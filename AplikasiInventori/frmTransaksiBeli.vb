Imports System.Data.SqlClient

Public Class frmTransaksiBeli

    Sub bersih1()
        Label3.Text = ""
        Label9.Text = ""
        Label10.Text = ""

    End Sub

    Sub hitungItem1()
        Dim cari As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cari = cari + DataGridView1.Rows(i).Cells(0).Value
            Label9.Text = cari
        Next
    End Sub

    Sub hitungTotal1()
        Dim cari As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cari = cari + DataGridView1.Rows(i).Cells(1).Value
            Label10.Text = cari
        Next
    End Sub






    Sub AturKolom1()
        'DataGridView1.Columns(0).Width = 60
        'DataGridView1.Columns(1).Width = 180
        'DataGridView1.Columns(2).Width = 110
        'DataGridView1.Columns(3).Width = 75
        'DataGridView1.Columns(4).Width = 120
    End Sub


    Sub BuatKolomDGV1()
        'DataGridView1.Columns.Add("kodemasakan", "Kode")
        'DataGridView1.Columns.Add("namamasakan", "Makanan")
        'DataGridView1.Columns.Add("harga", "Harga")
        DataGridView1.Columns.Add("jumlah", "Jumlah")
        DataGridView1.Columns.Add("total", "Total")
        AturKolom1()
    End Sub



    Private Sub frmTransaksiJual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call bukaDB()
        Call BuatKolomDGV1()
        'AturKolom()
        Call isiGrid1()
        Call bersih1()
        Label3.Text = Format(Now, "dd MMM yyyy")

    End Sub

    Sub TotalItem1()
        Dim HitungItem As Integer = 0
        For I As Integer = 0 To DataGridView1.Rows.Count - 1
            HitungItem = HitungItem + Val(DataGridView1.Rows(I).Cells(7).Value)
            'TxtJumlah.Text = HitungItem
        Next
    End Sub

    Sub isiGrid1()
        modConnection.bukaDB()
        da = New SqlDataAdapter("SELECT namabahan, harga from tbbahan", conn)
        ds = New DataSet
        da.Fill(ds, "tbbahan")
        DataGridView1.DataSource = ds.Tables("tbbahan")
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        DataGridView1.Rows(e.RowIndex).Cells(1).Value = DataGridView1.Rows(e.RowIndex).Cells(3).Value * DataGridView1.Rows(e.RowIndex).Cells(0).Value

        Call hitungTotal1()
        Call hitungItem1()
        'Call ngirimmasak()

        amehkirim = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        amehkirim2 = DataGridView1.Rows(e.RowIndex).Cells(0).Value

    End Sub
    Private Sub ubahkirim1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Call ngirimmasak1()
    End Sub

    Public Sub ngirimmasak1()
        Call bukaDB()
        simpan2 = "insert into  jmlpembelian (namabahan,jumlah,tanggal) values " & "('" & amehkirim & "','" & amehkirim2 & "', CURRENT_TIMESTAMP) "
        cmd = New SqlCommand(simpan2, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        cmd.Dispose()

    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        Call bukaDB()
        simpan = "INSERT INTO tbpembelian (totalpesanan,totalharga) VALUES " &
            "('" & Label9.Text & "','" & Label10.Text & "')"
        'simpan2 = "insert into  jmlmasakan (id,namamasakan,jumlah) values " & "('3','" & amehkirim & "',22222) "
        cmd = New SqlCommand(simpan, conn)
        'cmd = New SqlCommand(simpan2, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        cmd.Dispose()
        MsgBox("Data Transaksi Berhasil Disimpan", vbOK, "Transaksi Berhasil")

        bersih1()

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class