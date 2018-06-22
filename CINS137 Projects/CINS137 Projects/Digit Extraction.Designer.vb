<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Digit_Extraction
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
        Me.inputTextBox = New System.Windows.Forms.TextBox()
        Me.extractButton = New System.Windows.Forms.Button()
        Me.firstDigitLabel = New System.Windows.Forms.Label()
        Me.secondDigitLabel = New System.Windows.Forms.Label()
        Me.thirdDigitLabel = New System.Windows.Forms.Label()
        Me.fourthDigitLabel = New System.Windows.Forms.Label()
        Me.fithDigitLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter a 5-digit integer:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Extracted digits:"
        '
        'inputTextBox
        '
        Me.inputTextBox.Location = New System.Drawing.Point(123, 8)
        Me.inputTextBox.Name = "inputTextBox"
        Me.inputTextBox.Size = New System.Drawing.Size(86, 20)
        Me.inputTextBox.TabIndex = 1
        Me.inputTextBox.Text = "12345"
        '
        'extractButton
        '
        Me.extractButton.Location = New System.Drawing.Point(215, 6)
        Me.extractButton.Name = "extractButton"
        Me.extractButton.Size = New System.Drawing.Size(80, 23)
        Me.extractButton.TabIndex = 2
        Me.extractButton.Text = "Extract Digits"
        Me.extractButton.UseVisualStyleBackColor = True
        '
        'firstDigitLabel
        '
        Me.firstDigitLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firstDigitLabel.Location = New System.Drawing.Point(104, 37)
        Me.firstDigitLabel.Name = "firstDigitLabel"
        Me.firstDigitLabel.Size = New System.Drawing.Size(20, 15)
        Me.firstDigitLabel.TabIndex = 3
        Me.firstDigitLabel.Text = "W"
        '
        'secondDigitLabel
        '
        Me.secondDigitLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.secondDigitLabel.Location = New System.Drawing.Point(128, 37)
        Me.secondDigitLabel.Name = "secondDigitLabel"
        Me.secondDigitLabel.Size = New System.Drawing.Size(20, 15)
        Me.secondDigitLabel.TabIndex = 4
        Me.secondDigitLabel.Text = "W"
        '
        'thirdDigitLabel
        '
        Me.thirdDigitLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.thirdDigitLabel.Location = New System.Drawing.Point(152, 37)
        Me.thirdDigitLabel.Name = "thirdDigitLabel"
        Me.thirdDigitLabel.Size = New System.Drawing.Size(20, 15)
        Me.thirdDigitLabel.TabIndex = 5
        Me.thirdDigitLabel.Text = "W"
        '
        'fourthDigitLabel
        '
        Me.fourthDigitLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fourthDigitLabel.Location = New System.Drawing.Point(176, 37)
        Me.fourthDigitLabel.Name = "fourthDigitLabel"
        Me.fourthDigitLabel.Size = New System.Drawing.Size(20, 15)
        Me.fourthDigitLabel.TabIndex = 6
        Me.fourthDigitLabel.Text = "W"
        '
        'fithDigitLabel
        '
        Me.fithDigitLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fithDigitLabel.Location = New System.Drawing.Point(200, 37)
        Me.fithDigitLabel.Name = "fithDigitLabel"
        Me.fithDigitLabel.Size = New System.Drawing.Size(20, 15)
        Me.fithDigitLabel.TabIndex = 7
        Me.fithDigitLabel.Text = "W"
        '
        'Digit_Extraction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 61)
        Me.Controls.Add(Me.fithDigitLabel)
        Me.Controls.Add(Me.fourthDigitLabel)
        Me.Controls.Add(Me.thirdDigitLabel)
        Me.Controls.Add(Me.secondDigitLabel)
        Me.Controls.Add(Me.firstDigitLabel)
        Me.Controls.Add(Me.extractButton)
        Me.Controls.Add(Me.inputTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Digit_Extraction"
        Me.Text = "Digit_Extraction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents inputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents extractButton As System.Windows.Forms.Button
    Friend WithEvents firstDigitLabel As System.Windows.Forms.Label
    Friend WithEvents secondDigitLabel As System.Windows.Forms.Label
    Friend WithEvents thirdDigitLabel As System.Windows.Forms.Label
    Friend WithEvents fourthDigitLabel As System.Windows.Forms.Label
    Friend WithEvents fithDigitLabel As System.Windows.Forms.Label
End Class
