<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Present_Value_Calculator_Application
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
        Me.futureValueTextBox = New System.Windows.Forms.TextBox()
        Me.interestRateTextBox = New System.Windows.Forms.TextBox()
        Me.calculateButton = New System.Windows.Forms.Button()
        Me.resultsListBox = New System.Windows.Forms.TextBox()
        Me.yearUpDown = New System.Windows.Forms.DomainUpDown()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 91)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Future value:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Interest rate:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Yeats" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Required investment:"
        '
        'futureValueTextBox
        '
        Me.futureValueTextBox.Location = New System.Drawing.Point(88, 7)
        Me.futureValueTextBox.Name = "futureValueTextBox"
        Me.futureValueTextBox.Size = New System.Drawing.Size(100, 20)
        Me.futureValueTextBox.TabIndex = 1
        '
        'interestRateTextBox
        '
        Me.interestRateTextBox.Location = New System.Drawing.Point(88, 31)
        Me.interestRateTextBox.Name = "interestRateTextBox"
        Me.interestRateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.interestRateTextBox.TabIndex = 2
        '
        'calculateButton
        '
        Me.calculateButton.Location = New System.Drawing.Point(194, 4)
        Me.calculateButton.Name = "calculateButton"
        Me.calculateButton.Size = New System.Drawing.Size(75, 23)
        Me.calculateButton.TabIndex = 4
        Me.calculateButton.Text = "Calculate"
        Me.calculateButton.UseVisualStyleBackColor = True
        '
        'resultsListBox
        '
        Me.resultsListBox.Location = New System.Drawing.Point(12, 103)
        Me.resultsListBox.Multiline = True
        Me.resultsListBox.Name = "resultsListBox"
        Me.resultsListBox.Size = New System.Drawing.Size(256, 106)
        Me.resultsListBox.TabIndex = 5
        '
        'yearUpDown
        '
        Me.yearUpDown.Items.Add("30")
        Me.yearUpDown.Items.Add("25")
        Me.yearUpDown.Items.Add("20")
        Me.yearUpDown.Items.Add("15")
        Me.yearUpDown.Items.Add("10")
        Me.yearUpDown.Items.Add("5")
        Me.yearUpDown.Location = New System.Drawing.Point(88, 57)
        Me.yearUpDown.Name = "yearUpDown"
        Me.yearUpDown.ReadOnly = True
        Me.yearUpDown.Size = New System.Drawing.Size(100, 20)
        Me.yearUpDown.TabIndex = 6
        Me.yearUpDown.Text = "20"
        '
        'Present_Value_Calculator_Application
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 221)
        Me.Controls.Add(Me.yearUpDown)
        Me.Controls.Add(Me.resultsListBox)
        Me.Controls.Add(Me.calculateButton)
        Me.Controls.Add(Me.interestRateTextBox)
        Me.Controls.Add(Me.futureValueTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Present_Value_Calculator_Application"
        Me.Text = "Present Value Calculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents futureValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents interestRateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents calculateButton As System.Windows.Forms.Button
    Friend WithEvents resultsListBox As System.Windows.Forms.TextBox
    Friend WithEvents yearUpDown As System.Windows.Forms.DomainUpDown
End Class
