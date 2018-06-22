'website to process the integer given and outputs the number of inclosed areas of the integer
Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If CInt(TextBox1.Text) Then
                'processes the numbers
                Dim kinderGardenNumber As Integer = 0
                For i As Integer = 0 To TextBox1.Text.Length - 1
                    Select Case CInt(TextBox1.Text.Substring(i, 1))
                        Case 1, 2, 3, 5, 7
                            'no digit added to the number
                        Case 0, 4, 6, 9
                            kinderGardenNumber += 1
                        Case 8
                            kinderGardenNumber += 2
                    End Select
                Next
                Label1.Text = "Output: " & kinderGardenNumber
            End If
        Catch ex As InvalidCastException
            Label1.Text = "Please enter a whole number"
        End Try
    End Sub
End Class