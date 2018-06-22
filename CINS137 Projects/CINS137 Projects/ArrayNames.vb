Option Explicit On
Option Strict On
' Dmitry Post
' p. unknown (chapter 7 array names assignment)
' 10/7/12
' Array names: Add name to array, display array, clear array, display if duplicate attempted
Public Class ArrayNames
    Dim arrayNames(9) As String
    Private Sub AcceptButton_Click(sender As Object, e As EventArgs) Handles AcceptButton.Click
        For i = 0 To 9
            If nameInputTextBox.Text = arrayNames(i) Then
                MsgBox("Name already exists!")
                Exit For
            End If
            If i = 9 Then 'if no match...
                For j = 0 To 9 'cycle through array
                    If arrayNames(j) = Nothing Then 'find first empty array spot
                        arrayNames(j) = nameInputTextBox.Text 'add name to empty spot
                        If (j = 9) And Not (arrayNames(j) = Nothing) Then
                            AcceptButton.Enabled = False 'disable add if no spaces available
                        End If
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        For i = 0 To 9
            arrayNames(i) = Nothing
        Next
        AcceptButton.Enabled = True
    End Sub
    Private Sub Display_Click(sender As Object, e As EventArgs) Handles displayNamesButton.Click
        namesTextBox.Text = String.Empty
        For i = 0 To 9
            namesTextBox.AppendText(arrayNames(i) & vbNewLine)
        Next
    End Sub
End Class