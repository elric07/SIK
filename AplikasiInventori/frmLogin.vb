
Imports System.Data.SqlClient


Public Class frmLogin

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then TextBox2.Focus()
    End Sub


    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then Button1.Focus()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call bukaDB()
        cmd = New SqlCommand("select * from tbadmin where username ='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", conn)
        rd = cmd.ExecuteReader()
        rd.Read()
        If Not rd.HasRows Then
            Call bukaDB()
            MsgBox("Login Gagal, Username/Password Salah")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
        Else
            MsgBox("Halo " & rd.Item("nama") & ", Anda masuk sebagai " & rd.Item("level"), MsgBoxStyle.Exclamation, "Peringatan")
            Me.Visible = False
            Form1.Show()
            Form1.Label3.Text = rd.Item("nama")
            Form1.Label1.Text = rd.Item("level")
            'Form1.Label6.Text = 4
            Form1.Label9.Text = 8
            Form1.Label11.Text = 147000

            If Form1.Label1.Text = "Kasir" Then

                Form1.Button5.Enabled = False
                Form1.Button7.Enabled = False
                Form1.Button8.Enabled = False
                Form1.Button9.Enabled = False
            ElseIf Form1.Label1.Text = "staff gudang" Then
                Form1.Button5.Enabled = False
                Form1.Button2.Enabled = False
                Form1.Button4.Enabled = False
                Form1.Button6.Enabled = False
            Else

            End If
            modConnection.bukaDB()
            cmd = New SqlCommand("SELECT COUNT(kodemasakan) From tbmasakan", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            Form1.Label6.Text = rd.Item(0)

            modConnection.bukaDB()
            cmd = New SqlCommand("SELECT COUNT(kodepelanggan) From tbpelanggan", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            Form1.Label9.Text = rd.Item(0)

            modConnection.bukaDB()
            cmd = New SqlCommand("SELECT SUM(totalharga) From tbpenjualan", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            Form1.Label11.Text = rd.Item(0)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class