<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Computer_Assisted_Instruction
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
        Me.outputTextBox = New System.Windows.Forms.TextBox()
        Me.userInputTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'outputTextBox
        '
        Me.outputTextBox.Location = New System.Drawing.Point(12, 12)
        Me.outputTextBox.Multiline = True
        Me.outputTextBox.Name = "outputTextBox"
        Me.outputTextBox.ReadOnly = True
        Me.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.outputTextBox.Size = New System.Drawing.Size(214, 84)
        Me.outputTextBox.TabIndex = 1
        Me.outputTextBox.TabStop = False
        '
        'userInputTextBox
        '
        Me.userInputTextBox.Location = New System.Drawing.Point(61, 104)
        Me.userInputTextBox.Name = "userInputTextBox"
        Me.userInputTextBox.Size = New System.Drawing.Size(84, 20)
        Me.userInputTextBox.TabIndex = 2
        '
        'Computer_Assisted_Instruction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(238, 132)
        Me.Controls.Add(Me.userInputTextBox)
        Me.Controls.Add(Me.outputTextBox)
        Me.Name = "Computer_Assisted_Instruction"
        Me.Text = "Multiplication"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents outputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents userInputTextBox As System.Windows.Forms.TextBox
End Class
