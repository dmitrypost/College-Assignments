Option Strict On
Option Explicit On
Public Class Digit_Extraction
    Private Sub extractButton_Click(sender As Object, e As EventArgs) Handles extractButton.Click
        firstDigitLabel.Text = inputTextBox.Text.Substring(0, 1)
        secondDigitLabel.Text = inputTextBox.Text.Substring(1, 1)
        thirdDigitLabel.Text = inputTextBox.Text.Substring(2, 1)
        fourthDigitLabel.Text = inputTextBox.Text.Substring(3, 1)
        fithDigitLabel.Text = inputTextBox.Text.Substring(4, 1)
    End Sub
End Class