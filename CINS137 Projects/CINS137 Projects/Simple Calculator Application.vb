Option Explicit On
Option Strict On
Public Class Simple_Calculator_Application
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox3.Text = CStr(CInt(TextBox1.Text) + CInt(TextBox2.Text))
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox3.Text = CStr(CInt(TextBox1.Text) - CInt(TextBox2.Text))
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox3.Text = CStr(CInt(TextBox1.Text) * CInt(TextBox2.Text))
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox3.Text = CStr(CInt(TextBox1.Text) / CInt(TextBox2.Text))
    End Sub
End Class