<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ComboBoxBulan = New System.Windows.Forms.ComboBox()
        Me.ComboBoxTahun = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.8!)
        Me.Label1.Location = New System.Drawing.Point(43, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Bulan"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(326, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 97)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Tabel penjualan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.8!)
        Me.Label3.Location = New System.Drawing.Point(43, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 29)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tahun"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.Label2.Location = New System.Drawing.Point(146, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Contoh : 0-12"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.Label4.Location = New System.Drawing.Point(146, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Contoh : 2023"
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Location = New System.Drawing.Point(498, 33)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(139, 97)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Penjualan Dalam Setahun"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button3.Location = New System.Drawing.Point(326, 148)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(139, 97)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Diagram Banyak Menu Dijual Dalam Sebulan"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button4.Location = New System.Drawing.Point(498, 148)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(139, 97)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "Diagram Banyak Menu Dijual Dalam Setahun"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ComboBoxBulan
        '
        Me.ComboBoxBulan.FormattingEnabled = True
        Me.ComboBoxBulan.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.ComboBoxBulan.Location = New System.Drawing.Point(140, 46)
        Me.ComboBoxBulan.Name = "ComboBoxBulan"
        Me.ComboBoxBulan.Size = New System.Drawing.Size(121, 24)
        Me.ComboBoxBulan.TabIndex = 15
        '
        'ComboBoxTahun
        '
        Me.ComboBoxTahun.FormattingEnabled = True
        Me.ComboBoxTahun.Location = New System.Drawing.Point(140, 121)
        Me.ComboBoxTahun.Name = "ComboBoxTahun"
        Me.ComboBoxTahun.Size = New System.Drawing.Size(121, 24)
        Me.ComboBoxTahun.TabIndex = 16
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 280)
        Me.Controls.Add(Me.ComboBoxTahun)
        Me.Controls.Add(Me.ComboBoxBulan)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form2"
        Me.Text = "Laporan Penjualan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ComboBoxBulan As ComboBox
    Friend WithEvents ComboBoxTahun As ComboBox
End Class
