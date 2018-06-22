Public Class Bouncing_Ball
    Dim round As New BouncingBall
    Dim WithEvents timer1 As New Timer With {.Enabled = True, .Interval = 40}
    Private Sub Bouncing_Ball_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        timer1.Enabled = False
        Me.Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'passes the graphics of the form to the ball class
        round.Graphics = Me.CreateGraphics
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles timer1.Tick
        'moves the ball : -1 added due to the rectangle inside bounds are one less pixel
        round.Move(12, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
    End Sub
    Private Sub Bouncing_Ball_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        round.Graphics = Me.CreateGraphics
    End Sub
End Class
Class BouncingBall
    Private x As Integer = 20
    Private y As Integer = 20
    Private d As Integer = 40
    Private ReverseFlagX As Integer = 1
    Private ReverseFlagY As Integer = 1
    Private g As Graphics
    Public Property Xcoord() As Integer
        Get
            Return x
        End Get
        Set(ByVal Value As Integer)
            x = Value
        End Set
    End Property
    Public Property Ycoord() As Integer
        Get
            Return y
        End Get
        Set(ByVal Value As Integer)
            y = Value
        End Set
    End Property
    Public Property Diameter() As Integer
        Get
            Return d
        End Get
        Set(ByVal Value As Integer)
            d = Value
        End Set
    End Property
    'used to draw the ball
    Public Property Graphics() As Graphics
        Get
            Return g
        End Get
        Set(value As Graphics)
            g = value
        End Set
    End Property
    Sub Move(ByVal distance As Integer, ByVal w As Integer, ByVal h As Integer)
        'thus this will show each detail of the movement
        For i As Integer = 1 To distance
            x += 1 * ReverseFlagX 'movement along the x axis
            If ((x + d) >= w) Or x <= 0 Then 'right or left
                ReverseFlagX *= -1
            End If
            y += 1 * ReverseFlagY 'movement along the y axis
            If ((y + d) >= h) Or y <= 0 Then 'bottom or top
                ReverseFlagY *= -1
            End If
            'gets rid of the trailing
            g.Clear(Color.White)
            'draws the circle after it's moved
            g.DrawEllipse(Pens.Black, x, y, d, d)
        Next
    End Sub
End Class