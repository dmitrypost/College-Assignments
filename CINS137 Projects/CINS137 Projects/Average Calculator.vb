Option Explicit On
Option Strict On
Public Class Average_Calculator
    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles calculateButton.Click
        LabelAveResult.Text = CStr(CDbl(CDbl(firstNum.Text) + CDbl(secondNum.Text) + CDbl(thirdNum.Text)) / 3)
    End Sub
    Private Sub TextBoxes_TextChanged(sender As Object, e As EventArgs) Handles firstNum.TextChanged, secondNum.TextChanged, thirdNum.TextChanged
        LabelAveResult.Text = String.Empty
    End Sub
End Class