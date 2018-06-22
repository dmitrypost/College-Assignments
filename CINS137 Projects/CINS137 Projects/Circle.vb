' Dmitry Post
' p. unknown
' 10/23/2012
' week 10; Circle program
Option Strict On
Option Explicit On
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim c As New Circle
        c.radius = CDbl(TextBox1.Text)
        Label1.Text = c.ToString
    End Sub
End Class
Public Class Circle
    Private radius_ As Double
    Property radius() As Double
        Get
            Return radius_
        End Get
        Set(ByVal Value As Double)
            radius_ = Value
        End Set
    End Property
    Public Function getDiameter() As Double
        Return radius_ * 2
    End Function
    Public Function getArea() As Double
        Return (2 * Math.PI * radius_)
    End Function
    Public Overrides Function ToString() As String
        Return "Area: " & getArea() & vbNewLine & "Diameter: " & getDiameter() & vbNewLine & "Radius: " & radius_
    End Function
End Class
