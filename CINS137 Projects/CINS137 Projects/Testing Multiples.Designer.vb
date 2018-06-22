<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Testing_Multiples
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.firstNum = New System.Windows.Forms.TextBox()
        Me.secondNum = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter first number:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enter second number:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(217, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Multiple?"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'firstNum
        '
        Me.firstNum.Location = New System.Drawing.Point(129, 6)
        Me.firstNum.Name = "firstNum"
        Me.firstNum.Size = New System.Drawing.Size(100, 20)
        Me.firstNum.TabIndex = 2
        Me.firstNum.Text = "1000"
        '
        'secondNum
        '
        Me.secondNum.Location = New System.Drawing.Point(129, 28)
        Me.secondNum.Name = "secondNum"
        Me.secondNum.Size = New System.Drawing.Size(100, 20)
        Me.secondNum.TabIndex = 3
        Me.secondNum.Text = "50"
        '
        'Label2
        '
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Location = New System.Drawing.Point(12, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 21)
        Me.Label2.TabIndex = 4
        '
        'Testing_Multiples
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 110)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.secondNum)
        Me.Controls.Add(Me.firstNum)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Testing_Multiples"
        Me.Text = "Testing_Multiples"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents firstNum As System.Windows.Forms.TextBox
    Friend WithEvents secondNum As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
