<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Discount_Calcuator
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
        Me.amountLabel = New System.Windows.Forms.Label()
        Me.amountTextBox = New System.Windows.Forms.TextBox()
        Me.viewDiscountButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'amountLabel
        '
        Me.amountLabel.AutoSize = True
        Me.amountLabel.Location = New System.Drawing.Point(12, 17)
        Me.amountLabel.Name = "amountLabel"
        Me.amountLabel.Size = New System.Drawing.Size(73, 13)
        Me.amountLabel.TabIndex = 0
        Me.amountLabel.Text = "Enter amount:"
        '
        'amountTextBox
        '
        Me.amountTextBox.Location = New System.Drawing.Point(91, 15)
        Me.amountTextBox.Name = "amountTextBox"
        Me.amountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.amountTextBox.TabIndex = 1
        '
        'viewDiscountButton
        '
        Me.viewDiscountButton.Location = New System.Drawing.Point(195, 12)
        Me.viewDiscountButton.Name = "viewDiscountButton"
        Me.viewDiscountButton.Size = New System.Drawing.Size(85, 23)
        Me.viewDiscountButton.TabIndex = 2
        Me.viewDiscountButton.Text = "View Discount"
        Me.viewDiscountButton.UseVisualStyleBackColor = True
        '
        'Discount_Calcuator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 45)
        Me.Controls.Add(Me.viewDiscountButton)
        Me.Controls.Add(Me.amountTextBox)
        Me.Controls.Add(Me.amountLabel)
        Me.Name = "Discount_Calcuator"
        Me.Text = "Discount_Calcuator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents amountLabel As System.Windows.Forms.Label
    Friend WithEvents amountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents viewDiscountButton As System.Windows.Forms.Button
End Class
