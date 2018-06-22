Public Class Sudoku_Solver

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics = e.Graphics
        g.Clear(Color.White)
        'draws horizontal lines
        g.DrawLine(Pens.Black, 0, 30, 280, 30)
        g.DrawLine(Pens.Black, 0, 61, 280, 61)
        g.DrawRectangle(Pens.Black, New Rectangle(0, 92, 280, 1))
        g.DrawLine(Pens.Black, 0, 124, 280, 124)
        g.DrawLine(Pens.Black, 0, 155, 280, 155)
        g.DrawRectangle(Pens.Black, New Rectangle(0, 186, 280, 1))
        g.DrawLine(Pens.Black, 0, 218, 280, 218)
        g.DrawLine(Pens.Black, 0, 249, 280, 249)
        'draws vertical lines
        g.DrawLine(Pens.Black, 30, 0, 30, 280)
        g.DrawLine(Pens.Black, 61, 0, 61, 280)
        g.DrawRectangle(Pens.Black, New Rectangle(92, 0, 1, 280))
        g.DrawLine(Pens.Black, 124, 0, 124, 280)
        g.DrawLine(Pens.Black, 155, 0, 155, 280)
        g.DrawRectangle(Pens.Black, New Rectangle(186, 0, 1, 280))
        g.DrawLine(Pens.Black, 218, 0, 218, 280)
        g.DrawLine(Pens.Black, 249, 0, 249, 280)

    End Sub
End Class