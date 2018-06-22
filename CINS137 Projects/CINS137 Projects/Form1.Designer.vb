<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.milesdrivenlabel = New System.Windows.Forms.Label()
        Me.gallonsusedlabel = New System.Windows.Forms.Label()
        Me.mileslabel = New System.Windows.Forms.Label()
        Me.mpglabel = New System.Windows.Forms.Label()
        Me.gallonslabel = New System.Windows.Forms.Label()
        Me.totalslabel = New System.Windows.Forms.Label()
        Me.milesdriventextsbox = New System.Windows.Forms.TextBox()
        Me.gallonsusedtextbox = New System.Windows.Forms.TextBox()
        Me.mileslistbox = New System.Windows.Forms.TextBox()
        Me.totalresultslabel = New System.Windows.Forms.Label()
        Me.gallonslistbox = New System.Windows.Forms.TextBox()
        Me.mpglistbox = New System.Windows.Forms.TextBox()
        Me.calculatempgbutton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'milesdrivenlabel
        '
        Me.milesdrivenlabel.AutoSize = True
        Me.milesdrivenlabel.Location = New System.Drawing.Point(21, 10)
        Me.milesdrivenlabel.Name = "milesdrivenlabel"
        Me.milesdrivenlabel.Size = New System.Drawing.Size(93, 13)
        Me.milesdrivenlabel.TabIndex = 0
        Me.milesdrivenlabel.Text = "Enter miles driven:"
        '
        'gallonsusedlabel
        '
        Me.gallonsusedlabel.AutoSize = True
        Me.gallonsusedlabel.Location = New System.Drawing.Point(21, 50)
        Me.gallonsusedlabel.Name = "gallonsusedlabel"
        Me.gallonsusedlabel.Size = New System.Drawing.Size(97, 13)
        Me.gallonsusedlabel.TabIndex = 1
        Me.gallonsusedlabel.Text = "Enter gallons used:"
        '
        'mileslabel
        '
        Me.mileslabel.AutoSize = True
        Me.mileslabel.Location = New System.Drawing.Point(35, 99)
        Me.mileslabel.Name = "mileslabel"
        Me.mileslabel.Size = New System.Drawing.Size(34, 13)
        Me.mileslabel.TabIndex = 2
        Me.mileslabel.Text = "Miles:"
        '
        'mpglabel
        '
        Me.mpglabel.AutoSize = True
        Me.mpglabel.Location = New System.Drawing.Point(198, 99)
        Me.mpglabel.Name = "mpglabel"
        Me.mpglabel.Size = New System.Drawing.Size(34, 13)
        Me.mpglabel.TabIndex = 3
        Me.mpglabel.Text = "MPG:"
        '
        'gallonslabel
        '
        Me.gallonslabel.AutoSize = True
        Me.gallonslabel.Location = New System.Drawing.Point(117, 99)
        Me.gallonslabel.Name = "gallonslabel"
        Me.gallonslabel.Size = New System.Drawing.Size(45, 13)
        Me.gallonslabel.TabIndex = 4
        Me.gallonslabel.Text = "Gallons:"
        '
        'totalslabel
        '
        Me.totalslabel.AutoSize = True
        Me.totalslabel.Location = New System.Drawing.Point(21, 226)
        Me.totalslabel.Name = "totalslabel"
        Me.totalslabel.Size = New System.Drawing.Size(39, 13)
        Me.totalslabel.TabIndex = 5
        Me.totalslabel.Text = "Totals:"
        '
        'milesdriventextsbox
        '
        Me.milesdriventextsbox.Location = New System.Drawing.Point(120, 7)
        Me.milesdriventextsbox.Name = "milesdriventextsbox"
        Me.milesdriventextsbox.Size = New System.Drawing.Size(100, 20)
        Me.milesdriventextsbox.TabIndex = 6
        '
        'gallonsusedtextbox
        '
        Me.gallonsusedtextbox.Location = New System.Drawing.Point(120, 47)
        Me.gallonsusedtextbox.Name = "gallonsusedtextbox"
        Me.gallonsusedtextbox.Size = New System.Drawing.Size(100, 20)
        Me.gallonsusedtextbox.TabIndex = 7
        '
        'mileslistbox
        '
        Me.mileslistbox.Location = New System.Drawing.Point(12, 115)
        Me.mileslistbox.Multiline = True
        Me.mileslistbox.Name = "mileslistbox"
        Me.mileslistbox.ReadOnly = True
        Me.mileslistbox.Size = New System.Drawing.Size(74, 109)
        Me.mileslistbox.TabIndex = 8
        '
        'totalresultslabel
        '
        Me.totalresultslabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.totalresultslabel.Location = New System.Drawing.Point(12, 248)
        Me.totalresultslabel.Name = "totalresultslabel"
        Me.totalresultslabel.Size = New System.Drawing.Size(234, 110)
        Me.totalresultslabel.TabIndex = 11
        Me.totalresultslabel.Text = "Label7"
        '
        'gallonslistbox
        '
        Me.gallonslistbox.Location = New System.Drawing.Point(92, 115)
        Me.gallonslistbox.Multiline = True
        Me.gallonslistbox.Name = "gallonslistbox"
        Me.gallonslistbox.ReadOnly = True
        Me.gallonslistbox.Size = New System.Drawing.Size(74, 109)
        Me.gallonslistbox.TabIndex = 12
        '
        'mpglistbox
        '
        Me.mpglistbox.Location = New System.Drawing.Point(172, 115)
        Me.mpglistbox.Multiline = True
        Me.mpglistbox.Name = "mpglistbox"
        Me.mpglistbox.ReadOnly = True
        Me.mpglistbox.Size = New System.Drawing.Size(74, 109)
        Me.mpglistbox.TabIndex = 13
        '
        'calculatempgbutton
        '
        Me.calculatempgbutton.Location = New System.Drawing.Point(12, 73)
        Me.calculatempgbutton.Name = "calculatempgbutton"
        Me.calculatempgbutton.Size = New System.Drawing.Size(231, 23)
        Me.calculatempgbutton.TabIndex = 14
        Me.calculatempgbutton.Text = "Calculate MPG"
        Me.calculatempgbutton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(255, 366)
        Me.Controls.Add(Me.calculatempgbutton)
        Me.Controls.Add(Me.mpglistbox)
        Me.Controls.Add(Me.gallonslistbox)
        Me.Controls.Add(Me.totalresultslabel)
        Me.Controls.Add(Me.mileslistbox)
        Me.Controls.Add(Me.gallonsusedtextbox)
        Me.Controls.Add(Me.milesdriventextsbox)
        Me.Controls.Add(Me.totalslabel)
        Me.Controls.Add(Me.gallonslabel)
        Me.Controls.Add(Me.mpglabel)
        Me.Controls.Add(Me.mileslabel)
        Me.Controls.Add(Me.gallonsusedlabel)
        Me.Controls.Add(Me.milesdrivenlabel)
        Me.Name = "Form1"
        Me.Text = "miles per gallon"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents milesdrivenlabel As System.Windows.Forms.Label
    Friend WithEvents gallonsusedlabel As System.Windows.Forms.Label
    Friend WithEvents mileslabel As System.Windows.Forms.Label
    Friend WithEvents mpglabel As System.Windows.Forms.Label
    Friend WithEvents gallonslabel As System.Windows.Forms.Label
    Friend WithEvents totalslabel As System.Windows.Forms.Label
    Friend WithEvents milesdriventextsbox As System.Windows.Forms.TextBox
    Friend WithEvents gallonsusedtextbox As System.Windows.Forms.TextBox
    Friend WithEvents mileslistbox As System.Windows.Forms.TextBox
    Friend WithEvents totalresultslabel As System.Windows.Forms.Label
    Friend WithEvents gallonslistbox As System.Windows.Forms.TextBox
    Friend WithEvents mpglistbox As System.Windows.Forms.TextBox
    Friend WithEvents calculatempgbutton As System.Windows.Forms.Button

End Class
