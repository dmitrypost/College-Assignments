Public Class Statistics
    'a way to pass the array of integers to the class
    Private _numbers() As Integer
    Public Property numbers() As Array
        Get
            Return _numbers
        End Get
        Set(value As Array)
            _numbers = value
        End Set
    End Property

    Public Function mode() As Integer
        'makes sure there is numbers in the array
        If _numbers Is Nothing Then
            Return Nothing
        End If
        Dim mostOccuredNumber As Integer
        Dim i As Integer
        Dim occurances As Integer
        For Each number As Integer In _numbers
            For x As Integer = 0 To _numbers.Length - 1
                If number = _numbers(x) Then
                    'increment since that number exists!
                    i += 1
                End If
            Next
            ' sets the new number of occurances of the new number
            If i > occurances Then
                occurances = i
                mostOccuredNumber = number
            End If
            i = 0 'reset so you calculate the next number!
        Next
        Return mostOccuredNumber
    End Function

    Public Function minimum() As Integer
        'maskes sure there is numbers in the array
        If _numbers Is Nothing Then
            Return Nothing
        End If

        Dim lowestNumber As Integer = _numbers(0)
        For i As Integer = 0 To _numbers.Length - 1
            If lowestNumber > _numbers(i) Then
                lowestNumber = _numbers(i)
            End If
        Next
        Return lowestNumber
    End Function

    Public Function maximum() As Integer
        'maskes sure there is numbers in the array
        If _numbers Is Nothing Then
            Return Nothing
        End If

        Dim largestNumber As Integer = _numbers(0)
        For i As Integer = 0 To _numbers.Length - 1
            If largestNumber < _numbers(i) Then
                largestNumber = _numbers(i)
            End If
        Next
        Return largestNumber
    End Function

    Public Function average() As Double
        'maskes sure there is numbers in the array
        If _numbers Is Nothing Then
            Return Nothing
        End If

        Dim sum As Integer = 0
        For Each number As Integer In _numbers
            sum += number
        Next
        Return sum / _numbers.Length
    End Function

    Public Function median() As Double
        'maskes sure there is numbers in the array
        If _numbers Is Nothing Then
            Return Nothing
        End If

        Dim a As Array = _numbers
        Array.Sort(a)
        If a.Length Mod 2 = 0 Then
            ' even
            Return ((a(a.Length / 2 - 1) + a(a.Length / 2)) / 2)
        Else
            ' odd
            Dim i As Integer = a.Length / 2
            Return (a(i))
        End If
    End Function

    Private Function varience() As Double
        Dim mean As Double = average()
        Dim v As Double = 0 'Varience

        For i As Integer = 0 To _numbers.Length - 1
            Dim n As Integer = Math.Pow((Math.Abs(_numbers(i) - mean)), 2)
            v += n
        Next
        v = v / _numbers.Length
        Return v
    End Function

    Public Function StandardDeviation() As Double
        Return Math.Sqrt(Varience)
    End Function

    Public Function histogram(Optional ByVal countSymbol As Char = "*", Optional ByVal valuePerCountSymbol As Integer = 1) As System.Text.StringBuilder
        'get the array into order
        Dim numSet As Array = _numbers
        Array.Sort(numSet)
        Array.Reverse(numSet)
        'figure out the intervals 
        '   reset the value if attempts to set to 0... 
        If valuePerCountSymbol = 0 Then
            valuePerCountSymbol = 1
        End If
        'write to the stringbuilder
        Dim output As New System.Text.StringBuilder
        output.AppendLine(vbTab & "Scale: " & countSymbol & " = " & valuePerCountSymbol)
        Dim lastNum As Integer = Nothing
        For Each number As Integer In numSet
            If number = lastNum Then
                'add another place char mark
                If processIncrement(valuePerCountSymbol) = True Then
                    output.Append(countSymbol)
                End If
            Else
                'start a new line with one place mark
                inc = 0 'reset the increment var
                If processIncrement(valuePerCountSymbol) = True Then
                    output.Append(vbNewLine & vbTab & writeNumber(number) & "|" & countSymbol)
                Else
                    output.Append(vbNewLine & vbTab & writeNumber(number) & "|")
                End If
            End If
            lastNum = number
        Next
        'add the base line
        output.Append(vbNewLine & vbTab & "    +---------+---------+---------+---------+---------+---------+")
        output.Append(vbNewLine & vbTab & "    0        " & _
                      (10 * valuePerCountSymbol) & "        " & (20 * valuePerCountSymbol) & "        " & _
                      (30 * valuePerCountSymbol) & "        " & (40 * valuePerCountSymbol) & "        " & _
                      (50 * valuePerCountSymbol) & "        " & (60 * valuePerCountSymbol) & vbNewLine)
        'output the histogram
        Return output
    End Function
    ' helps out with the scaling process of the histogram
    Private inc As Integer = 0
    Private Function processIncrement(ByVal valueToIncAt As Integer)
        inc += 1
        If inc = valueToIncAt Then
            inc = 0
            Return True
        Else
            Return False
        End If
    End Function
    ' helps out with the spacing of the number in the histogram
    Private Function writeNumber(ByVal number As Integer) As String
        Select Case number.ToString.Length
            Case 4
                Return number
            Case 3
                Return " " & number
            Case 2
                Return "  " & number
            Case 1
                Return "   " & number
            Case Else
                Return number
        End Select
    End Function

End Class
