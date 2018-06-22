Public Class _7_Segment_Display
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Panel1.Update()
        _7_Segment.display(TextBox1.Text, Panel1.CreateGraphics)
        Panel1.Update()
    End Sub
End Class