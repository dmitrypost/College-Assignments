Public Class MinePlacer
    Inherits Control
    'property which determines if the control has been clicked or not
    Private _clicked As Boolean = False
    Public Property clicked As Boolean
        Get
            Return _clicked
        End Get
        Set(value As Boolean)
            _clicked = value
        End Set
    End Property
    'property that indicates if it is a bomb, nothing, or the number of bombs that are surrounding it.
    Dim _value As Integer = 0
    Public Property value As Integer
        Get
            Return _value
        End Get
        Set(value As Integer)
            _value = value
        End Set
    End Property

    Dim _flag As Boolean = False
    Public Property flag As Boolean
        Get
            Return _flag
        End Get
        Set(value As Boolean)
            _flag = value
        End Set
    End Property
   
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(Color.White)
        If _clicked = False Then
            'draw the control as if it hasn't been clicked
            If _flag Then
                g.FillRectangle(Brushes.White, New Rectangle(0, 0, 18, 18))
                g.DrawString("F", New Font("Times New Roman", 11), Brushes.Blue, 2, 1)
            Else
                g.FillRectangle(Brushes.Gray, New Rectangle(0, 0, 18, 18))
            End If
        Else
            'draw the control as if it has been clicked 
            g.DrawRectangle(Pens.Gray, New Rectangle(0, 0, 17, 17))
            'if the value is 9 then it is a bomb
            If _value = 9 Then
                g.DrawString("X", New Font("Times New Roman", 11), Brushes.Red, 2, 1)
            ElseIf _value = 0 Then
                'draw nothing in the area... and click all the ones around this placer...
                'this is handled by the game not by the placer itself
            Else
                g.DrawString(_value, New Font("Times New Roman", 11), Brushes.Black, 3, 1)
            End If
        End If
    End Sub

    Public Sub New()
        MyBase.Size = New Size(18, 18)


    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.OnMouseClick(e)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            If _flag = True Then 'toggles the flag 
                _flag = False
            Else
                _flag = True
            End If
        Else 'sets the property so drawing occus
            If _clicked = False Then
                Me._clicked = True
            End If
        End If
        Me.Refresh() 'forces the redrawing of the control
        Me.Update()
    End Sub

End Class
