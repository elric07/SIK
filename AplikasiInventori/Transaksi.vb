Imports CrystalDecisions.CrystalReports.Engine

Public Class Transaksi

    Private Sub Transaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim report As New ReportDocument()
        report.Load("C:\Users\erik2\Downloads\Compressed\Aplikasi-Kasir-Restaurant-VB-2010-master\Aplikasi\AplikasiInventori\LaporanTransaksi.rpt") ' Ganti dengan path file laporan Anda

        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.Refresh()
    End Sub


    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class