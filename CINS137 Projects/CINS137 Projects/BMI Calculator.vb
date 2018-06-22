Option Explicit On
Option Strict On
Public Class BMI_Calculator
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim BMI As Double = (CDbl(TextBox1.Text) * 703) / (CDbl(TextBox2.Text) * CDbl(TextBox2.Text))
        TextBox3.Text = CStr(BMI)
    End Sub
End Class