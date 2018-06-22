Public Class Microwave_Oven_Simulator
    'adds the seconds that was pressed based on which button was pressed.
    Private Sub Digits0through9_click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, _
        Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button0.Click
        appendSeconds(sender.name.ToString.Substring(6, 1))
    End Sub
    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        formatDisplay(0) 'sets the display to 0
    End Sub
    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        Timer1.Start() 'starts the countdown
        currentState = 2 'sets the currentState to running
        Panel2.Refresh()
    End Sub
    'retrieves the current seconds
    Function getSeconds() As Integer
        Dim i As Integer
        i = TextBox1.Text.Replace(":", "")
        Return i
    End Function
    'adds the digit to the end of the current digits
    Sub appendSeconds(ByVal digitToAppend As Integer)
        Dim i As Integer = getSeconds() 'get seconds
        i = (i.ToString & digitToAppend).ToString 'append digit
        If i.ToString.Length >= 7 Then 'doesn't allow for longer than 99:99:99
            flashDisplay() 'indicator to prevent too long of a time
        Else : formatDisplay(i) 'rewrite display
        End If
    End Sub
    'makes the display look like it is in time format
    Sub formatDisplay(ByVal seconds As Integer)
        Dim s As String = seconds 'formatted string of the seconds...
        Select Case s.Length
            Case 1 : s = s.Insert(0, "0:0")
            Case 2 : s = s.Insert(0, "0:")
            Case 3 : s = s.Insert(1, ":")
            Case 4 : s = s.Insert(2, ":")
            Case 5
                s = s.Insert(3, ":")
                s = s.Insert(1, ":")
            Case 6
                s = s.Insert(4, ":")
                s = s.Insert(2, ":")
        End Select
        TextBox1.Text = s
    End Sub
    'flash display is to indicate that you can't make the timer be longer than 99:99:99
    Sub flashDisplay()
        Dim s As String = TextBox1.Text
        TextBox1.Text = ""
        TextBox1.Refresh()
        System.Threading.Thread.Sleep(300)
        TextBox1.Text = s
    End Sub
    Dim fCount As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim i As Integer = getSeconds()
        If i > 0 Then
            formatDisplay(i - 1) 'subtracts a second off the clock
        Else
            If fCount = 3 Then 'flashes the display 3 times to indicate done
                Timer1.Stop()
                fCount = 0
            Else
                currentState = 0 'closed
                Panel2.Refresh()
                flashDisplay()
                fCount += 1
            End If
        End If
    End Sub
    Dim currentState As Integer = 0
    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        Select Case currentState
            Case 0 ' closed
                currentState = 1 'open 
            Case 1 ' open
                currentState = 0 'close
            Case 2 ' running
                Timer1.Stop() 'stop timer
                currentState = 1 'open
        End Select
        Panel2.Refresh()
    End Sub
    Private Sub MicrowaveFront_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Dim g As Graphics = e.Graphics
        If currentState = 0 Then 'closed
            g.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.Black)), New Rectangle(0, 0, sender.width, sender.height))
            doorHandle(g)
        ElseIf currentState = 1 Then 'open
            light(g)
        ElseIf currentState = 2 Then 'running
            light(g)
            g.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.Black)), New Rectangle(0, 0, sender.width, sender.height))
            doorHandle(g)
        End If
        g.DrawRectangle(Pens.Black, 0, 0, sender.width - 3, sender.height - 3)
    End Sub
    Private Sub light(ByVal g As Graphics)
        For i As Integer = 0 To 7
            g.DrawLine(Pens.Yellow, Panel2.Width - 2, -10, 0 + (i * 40), Panel2.Height)
        Next
    End Sub
    Private Sub doorHandle(ByVal g As Graphics)
        g.DrawRectangle(Pens.Black, New Rectangle(300, 50, 20, 100))
    End Sub
End Class