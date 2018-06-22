' Dmitry Post
' 10/18/2012
' Reads and writes text to a file of choice
Option Explicit On
Option Strict On
Public Class ReadWriteApplication
    Private Sub ReadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadToolStripMenuItem.Click
        Dim d As New OpenFileDialog With {.Filter = "Text files (*.txt)|*.txt"}
        If d.ShowDialog = DialogResult.OK Then
            TextBox1.Text = System.IO.File.ReadAllText(d.FileName)
            TextBox1.Text = TextBox1.Text.ToUpper()
        End If
        d.Dispose()
    End Sub
    Private Sub WriteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteToolStripMenuItem.Click
        Dim d As New SaveFileDialog With {.Filter = "Text files (*.txt)|*.txt"}
        If d.ShowDialog = DialogResult.OK Then
            System.IO.File.WriteAllText(d.FileName, TextBox1.Text)
        End If
        d.Dispose()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class