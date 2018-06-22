<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArrayNames
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
        Me.nameInputTextBox = New System.Windows.Forms.TextBox()
        Me.namesTextBox = New System.Windows.Forms.TextBox()
        Me.AcceptButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.displayNamesButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'nameInputTextBox
        '
        Me.nameInputTextBox.Location = New System.Drawing.Point(58, 12)
        Me.nameInputTextBox.Name = "nameInputTextBox"
        Me.nameInputTextBox.Size = New System.Drawing.Size(159, 20)
        Me.nameInputTextBox.TabIndex = 0
        '
        'namesTextBox
        '
        Me.namesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.namesTextBox.Location = New System.Drawing.Point(12, 60)
        Me.namesTextBox.Multiline = True
        Me.namesTextBox.Name = "namesTextBox"
        Me.namesTextBox.ReadOnly = True
        Me.namesTextBox.Size = New System.Drawing.Size(260, 157)
        Me.namesTextBox.TabIndex = 1
        Me.namesTextBox.TabStop = False
        '
        'AcceptButton
        '
        Me.AcceptButton.Location = New System.Drawing.Point(223, 10)
        Me.AcceptButton.Name = "AcceptButton"
        Me.AcceptButton.Size = New System.Drawing.Size(49, 23)
        Me.AcceptButton.TabIndex = 2
        Me.AcceptButton.Text = "Accept"
        Me.AcceptButton.UseVisualStyleBackColor = True
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(12, 10)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(40, 23)
        Me.ClearButton.TabIndex = 3
        Me.ClearButton.TabStop = False
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'displayNamesButton
        '
        Me.displayNamesButton.Location = New System.Drawing.Point(11, 42)
        Me.displayNamesButton.Name = "displayNamesButton"
        Me.displayNamesButton.Size = New System.Drawing.Size(262, 23)
        Me.displayNamesButton.TabIndex = 4
        Me.displayNamesButton.Text = "Display Names"
        Me.displayNamesButton.UseVisualStyleBackColor = True
        '
        'ArrayNames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 225)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.AcceptButton)
        Me.Controls.Add(Me.namesTextBox)
        Me.Controls.Add(Me.nameInputTextBox)
        Me.Controls.Add(Me.displayNamesButton)
        Me.Name = "ArrayNames"
        Me.Text = "ArrayNames"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nameInputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents namesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AcceptButton As System.Windows.Forms.Button
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents displayNamesButton As System.Windows.Forms.Button
End Class
