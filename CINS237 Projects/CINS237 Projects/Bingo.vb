Public Class Bingo
    Private Sub NewCard(sender As Object, e As EventArgs) Handles Button1.Click
        'gets a new set of numbers
        randomizeNumbers()
        'redraw image with the new numbers
        PictureBox1.Invalidate()
    End Sub

    Dim numbers(23) As Integer
    Dim WithEvents doc As System.Drawing.Printing.PrintDocument

    Private Sub AddImageToDocumentAtPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles doc.PrintPage
        ' the drawing of the image to the document.
        e.Graphics.DrawImage(PictureBox1.Image, e.MarginBounds.Left, e.MarginBounds.Top)
    End Sub

    Sub randomizeNumbers(Optional ByVal StartRange As Integer = 1, Optional ByVal EndRange As Integer = 100)
        Dim rand As New Random
        For i As Integer = 0 To 23
            Dim randomNumber As Integer = rand.Next(StartRange, EndRange)
            'makes sure that the random number that is generated is not in the other slots already
            'if so it will randomly generate a new number...
            While checkIfNumberExists(randomNumber) = True
                randomNumber = rand.Next(StartRange, EndRange)
            End While
            'assigns the random number to the slot
            numbers(i) = randomNumber
        Next
    End Sub

    'function to assist from duplicate numbers being on the same bingo card.
    Function checkIfNumberExists(ByVal number As Integer) As Boolean
        For j As Integer = 0 To 23
            If number = numbers(j) Then
                Return True ' number does exist already
            End If
        Next
        Return False 'number does not exist
    End Function

    Private Sub AppClose() Handles Button2.Click
        Me.Close()
    End Sub

    Sub drawCard(g As Graphics)
        g.Clear(Color.White)
        Dim titleFont As Font = New Font("Times New Roman", 45)
        Dim numbersFont As Font = New Font("Tahoma", 35)
        'title
        g.DrawString("Bingo", titleFont, Brushes.Black, New Point(140, 40))
        'grid
        Dim sX As Integer = 100
        For i As Integer = 1 To 6
            'horizontal lines
            g.DrawLine(Pens.LimeGreen, sX, (100 + (120 * i)), sX + 600, (100 + (120 * i)))
            'vertical lines
            g.DrawLine(Pens.DodgerBlue, sX + ((i - 1) * 120), 220, sX + ((i - 1) * 120), 820)
        Next
        'numbers
        For i As Integer = 0 To 4
            'first row of numbers
            g.DrawString(numbers(i), numbersFont, Brushes.Aqua, sX + 20 + (i * 120), 250)
            'second row of numbers
            g.DrawString(numbers(5 + i), numbersFont, Brushes.Aqua, sX + 20 + (i * 120), 370)
        Next
        g.DrawString(numbers(10), numbersFont, Brushes.Aqua, sX + 20, 490)
        g.DrawString(numbers(11), numbersFont, Brushes.Aqua, sX + 140, 490)
        '-------------free space-------------
        g.DrawString("Free", New Font("Tahoma", 21), Brushes.Aqua, 360, 490)
        g.DrawString("Space", New Font("Tahoma", 22), Brushes.Aqua, 360, 520)
        '-----------------------------------
        g.DrawString(numbers(12), numbersFont, Brushes.Aqua, sX + 380, 490)
        g.DrawString(numbers(13), numbersFont, Brushes.Aqua, sX + 500, 490)
        For i As Integer = 0 To 4
            'fourth row of numbers
            g.DrawString(numbers(i + 14), numbersFont, Brushes.Aqua, sX + 20 + (i * 120), 620)
            'fifth  row of numbers
            g.DrawString(numbers(i + 19), numbersFont, Brushes.Aqua, sX + 20 + (i * 120), 730)
        Next
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        drawCard(e.Graphics)
    End Sub
    Private Sub GraphicPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        drawCard(e.Graphics)
    End Sub

    Private Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        Dim doc As New Printing.PrintDocument
        Dim pDialog As New Windows.Forms.PrintDialog
        If pDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                AddHandler doc.PrintPage, AddressOf GraphicPrint
                doc.Print()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class