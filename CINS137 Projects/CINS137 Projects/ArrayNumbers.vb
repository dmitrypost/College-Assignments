Option Explicit On
Option Strict On
' Dmitry post
' p. unknown (chapter 7 array assignment)
' 10/7/12
' display each number and the difference from the average
Public Class ArrayNumbers
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rand As New System.Random
        Dim array1() As Integer = {rand.Next(1, 1000), rand.Next(1, 1000), rand.Next(1, 1000), rand.Next(1, 1000), rand.Next(1, 1000)}
        Dim average As Integer
        For i = 0 To array1.GetUpperBound(0)
            average += array1(i)
        Next
        average = CInt(average / 5)
        Dim array2(array1.GetUpperBound(0)) As Integer
        For i = 0 To array1.GetUpperBound(0)
            array2(i) = Math.Abs(array1(i) - average)
        Next
        TextBox1.Text = "Numbers" & vbTab & vbTab & "difference from average(" & average & ")"
        For i = 0 To array1.GetUpperBound(0)
            TextBox1.AppendText(vbNewLine & array1(i) & vbTab & vbTab & array2(i))
        Next
    End Sub
End Class