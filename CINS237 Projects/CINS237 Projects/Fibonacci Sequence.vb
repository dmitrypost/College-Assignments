Option Strict On
Option Explicit On
Public Class Fibonacci_Sequence
    Private numbers(100) As UInteger
    Dim StartTime As DateTime

    Function timedGenerate() As String
        Dim ElapsedTime As TimeSpan
        Dim timeFormat As String = "#.00000000"
        StartTime = Now
        ''------------code to be timed-----------------------
        Dim lastNum As Integer = 1
        Dim thisNum As Integer = 2
        Dim n(100) As UInteger
        For i As Integer = 0 To 99
            Try
                Dim nextNum As Integer = lastNum + thisNum
                lastNum = thisNum
                thisNum = nextNum
                n(i) = CUInt(thisNum)
            Catch ex As Exception
                Exit For
            End Try
        Next
        Dim number As UInteger = n(CInt(NumericUpDown2.Value))
        '---------------------------------------------
        ElapsedTime = Now.Subtract(StartTime)
        Return (ElapsedTime.TotalSeconds.ToString(timeFormat))
    End Function

    Function getNumbersOfLength(ByVal length As UInteger) As String
        If length > numbers.Length Then   ' makes the numbers array larger if the requested position is not within the initial array
            numbers = CType(generate(length), UInteger())
        End If
        Dim ret As String = String.Empty
        For i As Integer = 0 To CInt(length - 1)
            'ret = ret & numbers(i) & " , "
            If (numbers(i) = 0) And (Not i = 0) Then

                ret = ret & "Overflow error , "
            Else
                'process normally
                ret = ret & numbers(i) & " , "
            End If
        Next
        ret = ret.Substring(0, ret.Length - 3)
        Return ret
    End Function

    Function getNumAtPos(ByVal position As UInteger) As String
        If position > numbers.Length Then  ' makes the numbers array larger if the requested position is not within the initial array
            numbers = CType(generate(position), UInteger())   '
        End If
        If numbers(CInt(position - 1)) = 0 Then
            Return "Overflow error"
        End If
        Return CStr(numbers(CInt(position - 1)))
    End Function

    Function generate(ByVal amountOfNumbers As UInteger) As Array
        Dim array(CInt(amountOfNumbers)) As UInteger 'makes an array of the length requested
        array(0) = 0 'sets the first two numbers for the sequence to be operable
        array(1) = 1
        For i As Integer = 2 To CInt(amountOfNumbers) 'loops through to set the rest of the numbers
            Try
                If (Not array(i) = 1) And (array(i - 1) = 0) Then
                    ' occurs when there is a overflow with the previous value
                    array(i) = 0 ' 0 is the value defined as the overflow value
                Else
                    'process normally
                    array(i) = array(i - 2) + array(i - 1)
                End If
            Catch ex As OverflowException
                array(i) = 0 ' 0 is the value defined as the overflow value
            End Try
        Next
        Return array
    End Function

    Private Function findGoldenRatioInfo(ByVal places As Integer) As String
        Dim lastNum As Integer = 1
        Dim thisNum As Integer = 2
        Dim lastRatio As String
        Dim thisRatio As String = (0).ToString("F" & places.ToString)
        ' creates the ratio in string format; with only 'places' past the decimal
        Do
            Dim nextNum As Integer = lastNum + thisNum
            lastNum = thisNum
            thisNum = nextNum
            lastRatio = thisRatio
            Try
                thisRatio = (thisNum / lastNum).ToString("F" & places.ToString)
            Catch ex As OverflowException
                Return CStr(0)
            End Try
        Loop Until thisRatio = lastRatio ' if the two ratio's are same than it's accurate to the amount of places...
        'returns the number that is accurate to the places and the two number that create it...
        Return "The Golden Ratio: " & thisNum / lastNum & " is accurate to " & places & " decimal places" & vbNewLine & "using the #'s: " & thisNum & " and " & lastNum
    End Function

    Private Sub Fibonacci_Sequence_Load(sender As Object, e As EventArgs) Handles Me.Load
        'code for initial startup...
        numbers = CType(generate(47), UInteger()) 'pregenerates numbers
        NumericUpDown1.Value = 49 'sets the initial values for the forms... 
        NumericUpDown2.Value = 48
        GoldenRatioLabel.Text = findGoldenRatioInfo(6)
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If Not NumericUpDown1.Value > 0 Then
            NumericUpDown1.Value = 1
        End If
        TextBox1.Text = getNumbersOfLength(CUInt(NumericUpDown1.Value))
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If Not NumericUpDown2.Value > 0 Then
            NumericUpDown2.Value = 1
        End If
        'check performed to make sure in case there is an overflow than it will process it... ; overflow value is assigned 0
        If NumericUpDown2.Value = 1 Then
            ' processes the change as if the position is the first number... 
            Label1.Text = "The number at position                      is: 0"
        Else 'process normally
            Label1.Text = "The number at position                      is: " & getNumAtPos(CUInt(NumericUpDown2.Value))

            Label2.Text = "It took " & timedGenerate() & " to find the number at the postion " & NumericUpDown2.Value
        End If

    End Sub

End Class