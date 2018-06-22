Option Explicit On
Option Strict On
' Dmitry Post
' p. unknown Chapter 7 ascending numbers? & Extra Credit
' 10/7/12
' determines if numbers are in order from smallest to largest, and then displays the average of them
Public Class Array_assending_order
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim array1(9) As Integer
        For i = 0 To TextBox1.Lines.Length - 1
            array1(i) = CInt(TextBox1.Lines(i))
        Next
        Dim inOrder As Boolean = Nothing
        For i = 0 To 8
            If array1(i) > array1(i + 1) Then
                inOrder = False
                Exit For
            Else
                inOrder = True
            End If
        Next
        If inOrder Then
            MsgBox("in order")
        Else
            MsgBox("not in order")
        End If
        MsgBox(Module1.getAverage(array1))
    End Sub
End Class