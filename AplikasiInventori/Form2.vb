Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Reporting

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form5.Label3.Text = ComboBoxBulan.SelectedItem
        Form5.Label4.Text = ComboBoxTahun.SelectedItem
        Dim bulan As Integer = Convert.ToInt32(ComboBoxBulan.SelectedItem)
        Dim tahun As Integer = Convert.ToInt32(ComboBoxTahun.SelectedItem)

        ' Koneksi ke database
        Dim connectionString As String = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Membuka koneksi ke database
            connection.Open()

            ' Query untuk mengambil data berdasarkan bulan dan tahun
            Dim query As String = "SELECT * FROM tbpenjualan WHERE MONTH(tanggalpembelian) = @bulan AND YEAR(tanggalpembelian) = @tahun"
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

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Mendapatkan tahun saat ini
        Dim currentYear As Integer = DateTime.Now.Year

        ' Menambahkan item ke ComboBox dari tahun saat ini hingga 10 tahun ke belakang
        For i As Integer = currentYear To currentYear - 10 Step -1
            ComboBoxTahun.Items.Add(i)
        Next

        ' Mengatur tahun saat ini sebagai item terpilih pada ComboBox
        ComboBoxTahun.SelectedItem = currentYear
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tahun1 As Integer = Convert.ToInt32(ComboBoxTahun.SelectedItem)
        Form3.Label3.Text = ComboBoxTahun.SelectedItem

        ' Koneksi ke database
        Dim connectionString As String = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Membuka koneksi ke database
            connection.Open()

            ' Query untuk mengambil data jumlah penjualan per bulan
            Dim query As String = "SELECT MONTH(tanggalpembelian) AS Bulan, COUNT(*) AS JumlahPenjualan FROM tbpenjualan WHERE YEAR(tanggalpembelian) = @tahun1 GROUP BY MONTH(tanggalpembelian)"
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Label3.Text = ComboBoxBulan.SelectedItem
        Form4.Label4.Text = ComboBoxTahun.SelectedItem
        Dim bulan1 As Integer = Convert.ToInt32(ComboBoxBulan.SelectedItem)
        Dim tahun1 As Integer = Convert.ToInt32(ComboBoxTahun.SelectedItem)
        ' Koneksi ke database
        Dim connectionString As String = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Membuka koneksi ke database
            connection.Open()

            ' Query untuk mengambil data jumlah penjualan per bulan
            Dim query As String = "SELECT namamasakan, SUM(jumlah) AS Jumlah FROM jmlmasakan WHERE MONTH(tanggal) = @bulan1 and YEAR(tanggal) = @tahun1 GROUP BY namamasakan"
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
                Dim bulan = (reader("namamasakan"))
                Dim jumlahPenjualan As Integer = Convert.ToInt32(reader("jumlah"))
                series.Points.AddXY(bulan, jumlahPenjualan)
            End While

            ' Menambahkan ChartArea jika belum ada
            If chart.ChartAreas.Count = 0 Then
                chart.ChartAreas.Add(New ChartArea())
            End If

            ' Memberikan label pada sumbu x dan y
            chart.ChartAreas(0).AxisX.Title = "namamasakan"
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form4.Label3.Visible = False
        Form4.Label6.Visible = False
        Form4.Label4.Text = ComboBoxTahun.SelectedItem
        Dim tahun1 As Integer = Convert.ToInt32(ComboBoxTahun.SelectedItem)
        ' Koneksi ke database
        Dim connectionString As String = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Membuka koneksi ke database
            connection.Open()

            ' Query untuk mengambil data jumlah penjualan per bulan
            Dim query As String = "SELECT namamasakan, SUM(jumlah) AS Jumlah FROM jmlmasakan WHERE YEAR(tanggal) = @tahun1 GROUP BY namamasakan"
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
                Dim bulan = (reader("namamasakan"))
                Dim jumlahPenjualan As Integer = Convert.ToInt32(reader("jumlah"))
                series.Points.AddXY(bulan, jumlahPenjualan)
            End While

            ' Menambahkan ChartArea jika belum ada
            If chart.ChartAreas.Count = 0 Then
                chart.ChartAreas.Add(New ChartArea())
            End If

            ' Memberikan label pada sumbu x dan y
            chart.ChartAreas(0).AxisX.Title = "nama masakan"
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



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBulan.SelectedIndexChanged

    End Sub
End Class
