<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Craps
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
        Me.playButton = New System.Windows.Forms.Button()
        Me.pointGroupBox = New System.Windows.Forms.GroupBox()
        Me.pointDie1PictureBox = New System.Windows.Forms.PictureBox()
        Me.pointDie2PictureBox = New System.Windows.Forms.PictureBox()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.die1PictureBox = New System.Windows.Forms.PictureBox()
        Me.die2PictureBox = New System.Windows.Forms.PictureBox()
        Me.rollButton = New System.Windows.Forms.Button()
        Me.pointGroupBox.SuspendLayout()
        CType(Me.pointDie1PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pointDie2PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.die1PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.die2PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'playButton
        '
        Me.playButton.Location = New System.Drawing.Point(147, 12)
        Me.playButton.Name = "playButton"
        Me.playButton.Size = New System.Drawing.Size(75, 23)
        Me.playButton.TabIndex = 0
        Me.playButton.Text = "Play"
        Me.playButton.UseVisualStyleBackColor = True
        '
        'pointGroupBox
        '
        Me.pointGroupBox.Controls.Add(Me.pointDie1PictureBox)
        Me.pointGroupBox.Controls.Add(Me.pointDie2PictureBox)
        Me.pointGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.pointGroupBox.Name = "pointGroupBox"
        Me.pointGroupBox.Size = New System.Drawing.Size(129, 84)
        Me.pointGroupBox.TabIndex = 1
        Me.pointGroupBox.TabStop = False
        Me.pointGroupBox.Text = "Point"
        '
        'pointDie1PictureBox
        '
        Me.pointDie1PictureBox.Location = New System.Drawing.Point(6, 19)
        Me.pointDie1PictureBox.Name = "pointDie1PictureBox"
        Me.pointDie1PictureBox.Size = New System.Drawing.Size(50, 50)
        Me.pointDie1PictureBox.TabIndex = 3
        Me.pointDie1PictureBox.TabStop = False
        '
        'pointDie2PictureBox
        '
        Me.pointDie2PictureBox.Location = New System.Drawing.Point(62, 19)
        Me.pointDie2PictureBox.Name = "pointDie2PictureBox"
        Me.pointDie2PictureBox.Size = New System.Drawing.Size(50, 50)
        Me.pointDie2PictureBox.TabIndex = 2
        Me.pointDie2PictureBox.TabStop = False
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.statusLabel.Location = New System.Drawing.Point(0, 170)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(0, 13)
        Me.statusLabel.TabIndex = 0
        '
        'die1PictureBox
        '
        Me.die1PictureBox.Location = New System.Drawing.Point(18, 102)
        Me.die1PictureBox.Name = "die1PictureBox"
        Me.die1PictureBox.Size = New System.Drawing.Size(50, 50)
        Me.die1PictureBox.TabIndex = 5
        Me.die1PictureBox.TabStop = False
        '
        'die2PictureBox
        '
        Me.die2PictureBox.Location = New System.Drawing.Point(74, 102)
        Me.die2PictureBox.Name = "die2PictureBox"
        Me.die2PictureBox.Size = New System.Drawing.Size(50, 50)
        Me.die2PictureBox.TabIndex = 4
        Me.die2PictureBox.TabStop = False
        '
        'rollButton
        '
        Me.rollButton.Enabled = False
        Me.rollButton.Location = New System.Drawing.Point(147, 41)
        Me.rollButton.Name = "rollButton"
        Me.rollButton.Size = New System.Drawing.Size(75, 23)
        Me.rollButton.TabIndex = 6
        Me.rollButton.Text = "Roll"
        Me.rollButton.UseVisualStyleBackColor = True
        '
        'Craps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 183)
        Me.Controls.Add(Me.rollButton)
        Me.Controls.Add(Me.die1PictureBox)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.die2PictureBox)
        Me.Controls.Add(Me.pointGroupBox)
        Me.Controls.Add(Me.playButton)
        Me.Name = "Craps"
        Me.Text = "Craps"
        Me.pointGroupBox.ResumeLayout(False)
        CType(Me.pointDie1PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pointDie2PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.die1PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.die2PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents playButton As System.Windows.Forms.Button
    Friend WithEvents pointGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents statusLabel As System.Windows.Forms.Label
    Friend WithEvents pointDie1PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pointDie2PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents die1PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents die2PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents rollButton As System.Windows.Forms.Button
End Class
