Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Reporting

Public Class Form2beli
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form5.Label7.Text = "pembelian"
        Form5.Label3.Text = CBB.SelectedItem
        Form5.Label4.Text = CBT.SelectedItem

        Dim bulan As Integer = Convert.ToInt32(CBB.SelectedItem)
        Dim tahun As Integer = Convert.ToInt32(CBT.SelectedItem)

        ' Koneksi ke database
        Dim connectionString As String = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Membuka koneksi ke database
            connection.Open()

            ' Query untuk mengambil data berdasarkan bulan dan tahun
            Dim query As String = "SELECT * FROM tbpembelian WHERE MONTH(tanggalpembelian) = @bulan AND YEAR(tanggalpembelian) = @tahun"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@bulan", bulan)
            command.Parameters.AddWithValue("@tahun", tahun)

            ' Membaca data dari database
            Dim adapter As New SqlDataAdapter(command)
            Dim dataset As New DataSet()
            adapter.Fill(dataset)

            ' Menampilkan data pada DataGridView
            Form5.DataGridView1.DataSource = dataset.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        Finally
            ' Menutup koneksi database
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
        Form5.MdiParent = Form1
        Form5.Show()

    End Sub

    Private Sub Form2beli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Mendapatkan tahun saat ini
        Dim currentYear As Integer = DateTime.Now.Year

        ' Menambahkan item ke ComboBox dari tahun saat ini hingga 10 tahun ke belakang
        For i As Integer = currentYear To currentYear - 10 Step -1
            CBT.Items.Add(i)
        Next

        ' Mengatur tahun saat ini sebagai item terpilih pada ComboBox
        CBT.SelectedItem = currentYear
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub




    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim tahun1 As Integer = Convert.ToInt32(CBT.SelectedItem)
        Form3.Label4.Text = "pembelian"
        Form3.Label3.Text = CBT.SelectedItem

        ' Koneksi ke database
        Dim connectionString As String = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Membuka koneksi ke database
            connection.Open()

            ' Query untuk mengambil data jumlah penjualan per bulan
            Dim query As String = "SELECT MONTH(tanggalpembelian) AS Bulan, COUNT(*) AS JumlahPenjualan FROM tbpembelian WHERE YEAR(tanggalpembelian) = @tahun1 GROUP BY MONTH(tanggalpembelian)"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@tahun1", tahun1)



            ' Membaca data dari database
            Dim reader As SqlDataReader = command.ExecuteReader()

            ' ...

            ' Membuat objek Chart
            Dim chart As New Chart()
            chart.Dock = DockStyle.Fill
            Form3.Chart1.Controls.Add(chart)

            ' Menambahkan series ke Chart
            Dim series As New Series()
            series.ChartType = SeriesChartType.Column
            chart.Series.Add(series)

            ' Menampilkan data pada Chart
            While reader.Read()
                Dim bulan As Integer = Convert.ToInt32(reader("Bulan"))
                Dim jumlahPenjualan As Integer = Convert.ToInt32(reader("JumlahPenjualan"))
                series.Points.AddXY(bulan, jumlahPenjualan)
            End While

            ' Menambahkan ChartArea jika belum ada
            If chart.ChartAreas.Count = 0 Then
                chart.ChartAreas.Add(New ChartArea())
            End If

            ' Memberikan label pada sumbu x dan y
            chart.ChartAreas(0).AxisX.Title = "Bulan"
            chart.ChartAreas(0).AxisY.Title = "Jumlah Penjualan"

            ' ...


        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        Finally
            ' Menutup koneksi database
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
        Form3.MdiParent = Form1

        Form3.Show()
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        Form4.Label1.Text = "Laporan Pembelian"
        Form4.Label3.Text = CBB.SelectedItem
        Form4.Label4.Text = CBT.SelectedItem
        Dim bulan1 As Integer = Convert.ToInt32(CBB.SelectedItem)
        Dim tahun1 As Integer = Convert.ToInt32(CBT.SelectedItem)
        ' Koneksi ke database
        Dim connectionString As String = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Membuka koneksi ke database
            connection.Open()

            ' Query untuk mengambil data jumlah penjualan per bulan
            Dim query As String = "SELECT namabahan, SUM(jumlah) AS Jumlah FROM jmlpembelian WHERE MONTH(tanggal) = @bulan1 and YEAR(tanggal) = @tahun1 GROUP BY namabahan"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@bulan1", bulan1)
            command.Parameters.AddWithValue("@tahun1", tahun1)

            ' Membaca data dari database
            Dim reader As SqlDataReader = command.ExecuteReader()

            ' ...

            ' Membuat objek Chart
            Dim chart As New Chart()
            chart.Dock = DockStyle.Fill
            Form4.Chart1.Controls.Add(chart)

            ' Menambahkan series ke Chart
            Dim series As New Series()
            series.ChartType = SeriesChartType.Column
            chart.Series.Add(series)

            ' Menampilkan data pada Chart
            While reader.Read()
                Dim bulan = (reader("namabahan"))
                Dim jumlahPenjualan As Integer = Convert.ToInt32(reader("jumlah"))
                series.Points.AddXY(bulan, jumlahPenjualan)
            End While

            ' Menambahkan ChartArea jika belum ada
            If chart.ChartAreas.Count = 0 Then
                chart.ChartAreas.Add(New ChartArea())
            End If

            ' Memberikan label pada sumbu x dan y
            chart.ChartAreas(0).AxisX.Title = "nama bahan"
            chart.ChartAreas(0).AxisY.Title = "jumlah"

            ' ...


        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        Finally
            ' Menutup koneksi database
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
        Form4.MdiParent = Form1

        Form4.Show()
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        Form4.Label1.Text = "Laporan Pembelian"
        Form4.Label3.Visible = False
        Form4.Label6.Visible = False
        Form4.Label4.Text = CBT.SelectedItem
        Dim tahun1 As Integer = Convert.ToInt32(CBT.SelectedItem)
        ' Koneksi ke database
        Dim connectionString As String = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Membuka koneksi ke database
            connection.Open()

            ' Query untuk mengambil data jumlah penjualan per bulan
            Dim query As String = "SELECT namabahan, SUM(jumlah) AS Jumlah FROM jmlpembelian WHERE YEAR(tanggal) = @tahun1 GROUP BY namabahan"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@tahun1", tahun1)

            ' Membaca data dari database
            Dim reader As SqlDataReader = command.ExecuteReader()

            ' ...

            ' Membuat objek Chart
            Dim chart As New Chart()
            chart.Dock = DockStyle.Fill
            Form4.Chart1.Controls.Add(chart)

            ' Menambahkan series ke Chart
            Dim series As New Series()
            series.ChartType = SeriesChartType.Column
            chart.Series.Add(series)

            ' Menampilkan data pada Chart
            While reader.Read()
                Dim bulan = (reader("namabahan"))
                Dim jumlahPenjualan As Integer = Convert.ToInt32(reader("jumlah"))
                series.Points.AddXY(bulan, jumlahPenjualan)
            End While

            ' Menambahkan ChartArea jika belum ada
            If chart.ChartAreas.Count = 0 Then
                chart.ChartAreas.Add(New ChartArea())
            End If

            ' Memberikan label pada sumbu x dan y
            chart.ChartAreas(0).AxisX.Title = "nama bahan"
            chart.ChartAreas(0).AxisY.Title = "jumlah"

            ' ...


        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        Finally
            ' Menutup koneksi database
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
        Form4.MdiParent = Form1

        Form4.Show()
    End Sub
End Class
