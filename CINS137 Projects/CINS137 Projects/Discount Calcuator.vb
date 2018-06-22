Option Explicit On
Option Strict On
Public Class Discount_Calcuator
    Private Sub viewDiscountButton_Click(sender As Object, e As EventArgs) Handles viewDiscountButton.Click
        Select Case CDbl(amountTextBox.Text)
            Case Is >= 200
                MsgBox("Your discount is: 15%")
            Case Is >= 150
                MsgBox("Your discount is: 10%")
            Case Is >= 100
                MsgBox("Your discount is: 5%")
            Case Is >= 50
                MsgBox("Your discount is: 2%")
            Case Is < 50
                MsgBox("Sorry no discount!")
        End Select
    End Sub
End Class