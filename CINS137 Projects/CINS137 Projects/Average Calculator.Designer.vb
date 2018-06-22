<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Average_Calculator
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
        Me.LabelAveResult = New System.Windows.Forms.Label()
        Me.firstNum = New System.Windows.Forms.TextBox()
        Me.secondNum = New System.Windows.Forms.TextBox()
        Me.thirdNum = New System.Windows.Forms.TextBox()
        Me.calculateButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 91)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter first integer:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enter second interger:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enter third integer:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Average" & _
    " is:"
        '
        'LabelAveResult
        '
        Me.LabelAveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelAveResult.Location = New System.Drawing.Point(129, 87)
        Me.LabelAveResult.Name = "LabelAveResult"
        Me.LabelAveResult.Size = New System.Drawing.Size(100, 18)
        Me.LabelAveResult.TabIndex = 1
        '
        'firstNum
        '
        Me.firstNum.Location = New System.Drawing.Point(129, 6)
        Me.firstNum.Name = "firstNum"
        Me.firstNum.Size = New System.Drawing.Size(100, 20)
        Me.firstNum.TabIndex = 2
        '
        'secondNum
        '
        Me.secondNum.Location = New System.Drawing.Point(129, 32)
        Me.secondNum.Name = "secondNum"
        Me.secondNum.Size = New System.Drawing.Size(100, 20)
        Me.secondNum.TabIndex = 3
        '
        'thirdNum
        '
        Me.thirdNum.Location = New System.Drawing.Point(129, 58)
        Me.thirdNum.Name = "thirdNum"
        Me.thirdNum.Size = New System.Drawing.Size(100, 20)
        Me.thirdNum.TabIndex = 4
        '
        'calculateButton
        '
        Me.calculateButton.Location = New System.Drawing.Point(235, 79)
        Me.calculateButton.Name = "calculateButton"
        Me.calculateButton.Size = New System.Drawing.Size(75, 23)
        Me.calculateButton.TabIndex = 5
        Me.calculateButton.Text = "Calculate"
        Me.calculateButton.UseVisualStyleBackColor = True
        '
        'Average_Calculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 114)
        Me.Controls.Add(Me.calculateButton)
        Me.Controls.Add(Me.thirdNum)
        Me.Controls.Add(Me.secondNum)
        Me.Controls.Add(Me.firstNum)
        Me.Controls.Add(Me.LabelAveResult)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Average_Calculator"
        Me.Text = "Average_Calculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelAveResult As System.Windows.Forms.Label
    Friend WithEvents firstNum As System.Windows.Forms.TextBox
    Friend WithEvents secondNum As System.Windows.Forms.TextBox
    Friend WithEvents thirdNum As System.Windows.Forms.TextBox
    Friend WithEvents calculateButton As System.Windows.Forms.Button
End Class
