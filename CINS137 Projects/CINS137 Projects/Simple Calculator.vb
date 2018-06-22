Option Explicit On
Option Strict On
Public Class Simple_Calculator
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label2.Text = "The sum is: " & CStr(CInt(TextBox1.Text) + CInt(TextBox2.Text))
    End Sub
End Class