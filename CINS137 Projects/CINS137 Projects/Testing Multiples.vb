Option Explicit On
Option Strict On
Public Class Testing_Multiples
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As Integer = Nothing
        Math.DivRem(CInt(firstNum.Text), CInt(secondNum.Text), r)
        If r = Nothing Then
            Label2.Text = "First number is  a multiple of the second number"
        Else
            Label2.Text = "First number is NOT a multiple of second number"
        End If
    End Sub
End Class