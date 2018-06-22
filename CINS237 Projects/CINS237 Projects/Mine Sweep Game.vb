Public Class Mine_Sweep_Game
    Public mines As New List(Of MinePlacer)
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'gets rid of all existing mines on the feild
        MineFeild.Controls.Clear()
        'clears list of mines
        mines.Clear()
        For x As Integer = 5 To MineFeild.Width Step 20
            For y As Integer = 5 To MineFeild.Height Step 20
                'prevents from a mine placer placed at the end of the edge and being partially cut off.
                If Not (((x + 20) > MineFeild.Width) Or ((y + 20) > MineFeild.Height)) Then
                    'creates the mine placer and sets its location and parent
                    Dim box As New MinePlacer
                    With box
                        box.Location = New Point(x, y)
                        box.Parent = MineFeild
                    End With
                    mines.Add(box)
                End If
            Next 'y
        Next 'x
        'populate the mines in the mine feild by random
        Dim r As New Random
        For i As Integer = 0 To mines.Count Step 4
            Dim mineNumber As Integer = r.Next(mines.Count - 1)
            mines.Item(mineNumber).value = 9 'makes this mine a bomb
            Dim bomb As MinePlacer = mines.Item(mineNumber)
        Next
        'sets the number for the mine placers without a mine
        For Each mine As MinePlacer In mines
            If Not mine.value = 9 Then
                mine.value = getSuroundingBombCound(mine)
            End If
        Next
    End Sub

#Region "check number of bombs around me"
    Function getSuroundingBombCound(ByVal placer As MinePlacer) As Integer
        Dim mineNumber As Integer = 0
        'mine to the right
        Dim c As MinePlacer = MineFeild.GetChildAtPoint(New Point((placer.Location.X + 20), (placer.Location.Y)))
        mineNumber = incMineNumber(c, mineNumber)
        'mine to the left
        c = MineFeild.GetChildAtPoint(New Point((placer.Location.X - 20), (placer.Location.Y)))
        mineNumber = incMineNumber(c, mineNumber)

        'mine to the top left
        c = MineFeild.GetChildAtPoint(New Point((placer.Location.X - 20), (placer.Location.Y - 20)))
        mineNumber = incMineNumber(c, mineNumber)

        'mine to the top middle
        c = MineFeild.GetChildAtPoint(New Point((placer.Location.X), (placer.Location.Y - 20)))
        mineNumber = incMineNumber(c, mineNumber)

        'mine to the top right
        c = MineFeild.GetChildAtPoint(New Point((placer.Location.X + 20), (placer.Location.Y - 20)))
        mineNumber = incMineNumber(c, mineNumber)

        'mine to the bottom left
        c = MineFeild.GetChildAtPoint(New Point((placer.Location.X - 20), (placer.Location.Y + 20)))
        mineNumber = incMineNumber(c, mineNumber)

        'mine to the bottom middle
        c = MineFeild.GetChildAtPoint(New Point((placer.Location.X), (placer.Location.Y + 20)))
        mineNumber = incMineNumber(c, mineNumber)

        'mine to the bottom right
        c = MineFeild.GetChildAtPoint(New Point((placer.Location.X + 20), (placer.Location.Y + 20)))
        mineNumber = incMineNumber(c, mineNumber)


        Return mineNumber
    End Function

    Function incMineNumber(ByVal c As MinePlacer, v As Integer) As Integer
        If Not c Is Nothing Then
            If c.value = 9 Then
                v += 1
            End If
        End If
        Return v
    End Function
#End Region
End Class