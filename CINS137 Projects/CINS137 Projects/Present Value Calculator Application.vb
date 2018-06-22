Option Explicit On
Option Strict On
Public Class Present_Value_Calculator_Application
    Private Sub calculateButton_Click(sender As Object, e As EventArgs) Handles calculateButton.Click
        Dim p, a, r, n As Double
        resultsListBox.Text = "Year" & vbTab & "Investment needed" & vbNewLine
        Dim year As Integer = 5
        Do Until year > CDbl(yearUpDown.Text)
            a = CDbl(futureValueTextBox.Text)
            r = CDbl(interestRateTextBox.Text) / 100
            n = year
            p = a / (Math.Pow((1 + r), n))
            resultsListBox.Text = resultsListBox.Text & year & vbTab & "$" & Math.Round(p, 2) & vbNewLine
            year += 5
        Loop
    End Sub
End Class