Option Explicit On
Option Strict On
Public Class Form1
    Dim totalmilesdriven As Double = 0
    Dim totalgallonsused As Double = 0
    Private Sub calculatempgbutton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles calculatempgbutton.Click
        If CDbl(milesdriventextsbox.Text) > 0 Then 'makes sure user inputs a number larger than 0; avoiding deviding by 0
            If (mileslistbox.Text) = Nothing Then
                mileslistbox.Text = CStr(Math.Round(CDbl(milesdriventextsbox.Text), 2))
                gallonslistbox.Text = CStr(Math.Round(CDbl(gallonsusedtextbox.Text), 2))
                mpglistbox.Text = CStr(CDbl(Math.Round(CDbl(milesdriventextsbox.Text) / CDbl(gallonsusedtextbox.Text), 2)))
                totalmilesdriven = CDbl(milesdriventextsbox.Text)
                totalgallonsused = CDbl(gallonsusedtextbox.Text)
            Else
                mileslistbox.Text = mileslistbox.Text & vbNewLine & CStr(Math.Round(CDbl(milesdriventextsbox.Text), 2))
                gallonslistbox.Text = gallonslistbox.Text & vbNewLine & CStr(Math.Round(CDbl(gallonsusedtextbox.Text), 2))
                mpglistbox.Text = mpglistbox.Text & vbNewLine & CStr(CDbl(Math.Round(CDbl(milesdriventextsbox.Text) / CDbl(gallonsusedtextbox.Text), 2)))
                totalmilesdriven += CDbl(milesdriventextsbox.Text)
                totalgallonsused += CDbl(gallonsusedtextbox.Text)
            End If
            totalresultslabel.Text = "Total miles driven: " & totalmilesdriven & vbNewLine _
                & "Total gallons used: " & totalgallonsused & vbNewLine _
                & "Total MPG: " & Math.Round((totalmilesdriven / totalgallonsused), 2)
        End If
    End Sub
End Class
