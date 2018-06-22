Public Class Craps
    Enum DiceNames
        SNAKE_EYES = 2
        TREY = 3
        LUCKY_SEVEN = 7
        CRAPS = 7
        YO_LEVEN = 11
        BOX_CARS = 12
    End Enum
    Dim myPoint, myDie1, myDie2 As Integer
    Dim randomObject As New Random()
    Private Sub playButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles playButton.Click
        myPoint = 0
        pointGroupBox.Text = "Point"
        statusLabel.Text = String.Empty
        pointDie1PictureBox.Image = Nothing
        pointDie2PictureBox.Image = Nothing
        Dim sum As Integer = RollDice()
        Select Case sum
            Case DiceNames.LUCKY_SEVEN, DiceNames.YO_LEVEN
                rollButton.Enabled = False
                statusLabel.Text = "You Win!!!"
            Case DiceNames.SNAKE_EYES, DiceNames.TREY, DiceNames.BOX_CARS
                rollButton.Enabled = False
                statusLabel.Text = "Sorry. You Lose."
            Case Else
                myPoint = sum
                pointGroupBox.Text = "Point is " & sum
                statusLabel.Text = "Roll again!"
                DisplayDie(pointDie1PictureBox, myDie1)
                DisplayDie(pointDie2PictureBox, myDie2)
                playButton.Enabled = False
                rollButton.Enabled = True
        End Select
    End Sub
    Private Sub rollButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rollButton.Click
        Dim sum As Integer = RollDice()
        If sum = myPoint Then
            statusLabel.Text = "You Win!!!"
            rollButton.Enabled = False
            playButton.Enabled = True
        ElseIf sum = DiceNames.CRAPS Then
            statusLabel.Text = "Sorry. You Lose."
            rollButton.Enabled = False
            playButton.Enabled = True
        End If
    End Sub
    Sub DisplayDie(ByVal diePicturebox As PictureBox, ByVal face As Integer)
        Dim pictureResource = My.Resources.ResourceManager.GetObject(String.Format("die{0}", face))
        diePicturebox.Image = CType(pictureResource, Image)
    End Sub
    Function RollDice() As Integer
        myDie1 = randomObject.Next(1, 7)
        myDie2 = randomObject.Next(1, 7)
        DisplayDie(die1PictureBox, myDie1)
        DisplayDie(die2PictureBox, myDie2)
        Return myDie1 + myDie2
    End Function
End Class