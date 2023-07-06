<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2beli
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.Button41 = New System.Windows.Forms.Button()
        Me.CBB = New System.Windows.Forms.ComboBox()
        Me.CBT = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.8!)
        Me.Label11.Location = New System.Drawing.Point(43, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 29)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Bulan"
        '
        'Button11
        '
        Me.Button11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button11.Location = New System.Drawing.Point(326, 33)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(139, 97)
        Me.Button11.TabIndex = 2
        Me.Button11.Text = "Tabel penjualan"
        Me.Button11.UseVisualStyleBackColor = True
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
        'Button21
        '
        Me.Button21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button21.Location = New System.Drawing.Point(498, 33)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(139, 97)
        Me.Button21.TabIndex = 12
        Me.Button21.Text = "Penjualan Dalam Setahun"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button31
        '
        Me.Button31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button31.Location = New System.Drawing.Point(326, 148)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(139, 97)
        Me.Button31.TabIndex = 13
        Me.Button31.Text = "Diagram Banyak Menu Dijual Dalam Sebulan"
        Me.Button31.UseVisualStyleBackColor = True
        '
        'Button41
        '
        Me.Button41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button41.Location = New System.Drawing.Point(498, 148)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(139, 97)
        Me.Button41.TabIndex = 14
        Me.Button41.Text = "Diagram Banyak Menu Dijual Dalam Setahun"
        Me.Button41.UseVisualStyleBackColor = True
        '
        'CBB
        '
        Me.CBB.FormattingEnabled = True
        Me.CBB.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.CBB.Location = New System.Drawing.Point(149, 46)
        Me.CBB.Name = "CBB"
        Me.CBB.Size = New System.Drawing.Size(121, 24)
        Me.CBB.TabIndex = 15
        '
        'CBT
        '
        Me.CBT.FormattingEnabled = True
        Me.CBT.Location = New System.Drawing.Point(149, 121)
        Me.CBT.Name = "CBT"
        Me.CBT.Size = New System.Drawing.Size(121, 24)
        Me.CBT.TabIndex = 16
        '
        'Form2beli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 280)
        Me.Controls.Add(Me.CBT)
        Me.Controls.Add(Me.CBB)
        Me.Controls.Add(Me.Button41)
        Me.Controls.Add(Me.Button31)
        Me.Controls.Add(Me.Button21)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Label11)
        Me.Name = "Form2beli"
        Me.Text = "Laporan Pembelian"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As Label
    Friend WithEvents Button11 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button21 As Button
    Friend WithEvents Button31 As Button
    Friend WithEvents Button41 As Button
    Friend WithEvents CBB As ComboBox
    Friend WithEvents CBT As ComboBox
End Class
