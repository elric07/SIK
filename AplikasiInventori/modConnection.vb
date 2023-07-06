Imports System.Data.SqlClient
Module modConnection
    Public conn As SqlConnection
    Public rd As SqlDataReader
    Public da As SqlDataAdapter
    Public ds As DataSet
    Public cmd As SqlCommand
    Public str As String
    Public amehkirim As String
    Public amehkirim2 As String
    Public simpan, simpan2, ubah, hapus As String

    Public Sub bukaDB()
        str = "Data Source=localhost;Integrated Security=True;database = warunk_kopi"
        conn = New SqlConnection(str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub


End Module
