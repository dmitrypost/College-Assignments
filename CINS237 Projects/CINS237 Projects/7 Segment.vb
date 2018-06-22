Module _7_Segment
    Sub display(ByVal display As String, ByVal g As Graphics)
        g.Clear(Color.White)
        For i As Integer = 0 To display.Length - 1
            Select Case display.Substring(i, 1)
                Case "0"
                    top(g, i + 1)
                    topRight(g, i + 1)
                    topLeft(g, i + 1)
                    bottom(g, i + 1)
                    bottomRight(g, i + 1)
                    bottomLeft(g, i + 1)
                Case "1"
                    topRight(g, i + 1)
                    bottomRight(g, i + 1)
                Case "2"
                    top(g, i + 1)
                    topRight(g, i + 1)
                    middle(g, i + 1)
                    bottomLeft(g, i + 1)
                    bottom(g, i + 1)
                Case "3"
                    top(g, i + 1)
                    topRight(g, i + 1)
                    middle(g, i + 1)
                    bottomRight(g, i + 1)
                    bottom(g, i + 1)
                Case "4"
                    topLeft(g, i + 1)
                    topRight(g, i + 1)
                    middle(g, i + 1)
                    bottomRight(g, i + 1)
                Case "5"
                    top(g, i + 1)
                    topLeft(g, i + 1)
                    middle(g, i + 1)
                    bottomRight(g, i + 1)
                    bottom(g, i + 1)
                Case "6"
                    top(g, i + 1)
                    topLeft(g, i + 1)
                    middle(g, i + 1)
                    bottomRight(g, i + 1)
                    bottom(g, i + 1)
                    bottomLeft(g, i + 1)
                Case "7"
                    top(g, i + 1)
                    topRight(g, i + 1)
                    bottomRight(g, i + 1)
                Case "8"
                    top(g, i + 1)
                    topRight(g, i + 1)
                    topLeft(g, i + 1)
                    bottom(g, i + 1)
                    bottomRight(g, i + 1)
                    bottomLeft(g, i + 1)
                    middle(g, i + 1)
                Case "9"
                    top(g, i + 1)
                    topRight(g, i + 1)
                    topLeft(g, i + 1)
                    bottom(g, i + 1)
                    bottomRight(g, i + 1)
                    middle(g, i + 1)
            End Select
        Next
    End Sub
    ' each segment contains the points that are part of a polygon and form the crystal shape that represents that segment
    ' placement is used to determine which digit it is to draw at.
    Private Sub top(ByVal g As Graphics, ByVal placement As Integer)
        Dim point1 As Point = New Point((placement * 44) - 37, 7)
        Dim point2 As Point = New Point((placement * 44) - 32, 2)
        Dim point3 As Point = New Point((placement * 44) - 12, 2)
        Dim point4 As Point = New Point((placement * 44) - 7, 7)
        Dim point5 As Point = New Point((placement * 44) - 12, 12)
        Dim point6 As Point = New Point((placement * 44) - 32, 12)
        Dim allPoints() As Point = {point1, point2, point3, point4, point5, point6}
        Dim path As New Drawing2D.GraphicsPath
        path.AddPolygon(allPoints)
        g.FillPath(Brushes.Red, path)
    End Sub
    Private Sub topLeft(ByVal g As Graphics, ByVal placement As Integer)
        Dim point1 As Point = New Point((placement * 44) - 37, 8)
        Dim point2 As Point = New Point((placement * 44) - 42, 13)
        Dim point3 As Point = New Point((placement * 44) - 42, 33)
        Dim point4 As Point = New Point((placement * 44) - 37, 38)
        Dim point5 As Point = New Point((placement * 44) - 32, 33)
        Dim point6 As Point = New Point((placement * 44) - 32, 13)
        Dim allPoints() As Point = {point1, point2, point3, point4, point5, point6}
        Dim path As New Drawing2D.GraphicsPath
        path.AddPolygon(allPoints)
        g.FillPath(Brushes.Red, path)
    End Sub
    Private Sub topRight(ByVal g As Graphics, ByVal placement As Integer)
        Dim point1 As Point = New Point((placement * 44) - 7, 8)
        Dim point2 As Point = New Point((placement * 44) - 12, 13)
        Dim point3 As Point = New Point((placement * 44) - 12, 33)
        Dim point4 As Point = New Point((placement * 44) - 7, 38)
        Dim point5 As Point = New Point((placement * 44) - 2, 33)
        Dim point6 As Point = New Point((placement * 44) - 2, 13)
        Dim allPoints() As Point = {point1, point2, point3, point4, point5, point6}
        Dim path As New Drawing2D.GraphicsPath
        path.AddPolygon(allPoints)
        g.FillPath(Brushes.Red, path)
    End Sub
    Private Sub middle(ByVal g As Graphics, ByVal placement As Integer)
        Dim point1 As Point = New Point((placement * 44) - 12, 34)
        Dim point2 As Point = New Point((placement * 44) - 32, 34)
        Dim point3 As Point = New Point((placement * 44) - 37, 39)
        Dim point4 As Point = New Point((placement * 44) - 32, 44)
        Dim point5 As Point = New Point((placement * 44) - 12, 44)
        Dim point6 As Point = New Point((placement * 44) - 7, 39)
        Dim allPoints() As Point = {point1, point2, point3, point4, point5, point6}
        Dim path As New Drawing2D.GraphicsPath
        path.AddPolygon(allPoints)
        g.FillPath(Brushes.Red, path)
    End Sub
    Private Sub bottomLeft(ByVal g As Graphics, ByVal placement As Integer)
        Dim point1 As Point = New Point((placement * 44) - 37, 40)
        Dim point2 As Point = New Point((placement * 44) - 42, 45)
        Dim point3 As Point = New Point((placement * 44) - 42, 65)
        Dim point4 As Point = New Point((placement * 44) - 37, 70)
        Dim point5 As Point = New Point((placement * 44) - 32, 65)
        Dim point6 As Point = New Point((placement * 44) - 32, 45)
        Dim allPoints() As Point = {point1, point2, point3, point4, point5, point6}
        Dim path As New Drawing2D.GraphicsPath
        path.AddPolygon(allPoints)
        g.FillPath(Brushes.Red, path)
    End Sub
    Private Sub bottomRight(ByVal g As Graphics, ByVal placement As Integer)
        Dim point1 As Point = New Point((placement * 44) - 7, 40)
        Dim point2 As Point = New Point((placement * 44) - 12, 45)
        Dim point3 As Point = New Point((placement * 44) - 12, 65)
        Dim point4 As Point = New Point((placement * 44) - 7, 70)
        Dim point5 As Point = New Point((placement * 44) - 2, 65)
        Dim point6 As Point = New Point((placement * 44) - 2, 45)
        Dim allPoints() As Point = {point1, point2, point3, point4, point5, point6}
        Dim path As New Drawing2D.GraphicsPath
        path.AddPolygon(allPoints)
        g.FillPath(Brushes.Red, path)
    End Sub
    Private Sub bottom(ByVal g As Graphics, ByVal placement As Integer)
        Dim point1 As Point = New Point((placement * 44) - 12, 66)
        Dim point2 As Point = New Point((placement * 44) - 32, 66)
        Dim point3 As Point = New Point((placement * 44) - 37, 71)
        Dim point4 As Point = New Point((placement * 44) - 32, 76)
        Dim point5 As Point = New Point((placement * 44) - 12, 76)
        Dim point6 As Point = New Point((placement * 44) - 7, 71)
        Dim allPoints() As Point = {point1, point2, point3, point4, point5, point6}
        Dim path As New Drawing2D.GraphicsPath
        path.AddPolygon(allPoints)
        g.FillPath(Brushes.Red, path)
    End Sub
End Module
