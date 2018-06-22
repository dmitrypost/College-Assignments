Module Character_Sequence_Challenge
    Sub main()
        System.Console.WriteLine(getMode("abcdefghgggijklaaaaayurr"))
    End Sub

    Public Function getMode(ByVal input As String) As Integer
        Dim previousChar As Char = Nothing
        Dim occurances As Integer = 0
        Dim V As Integer = 0
        For i As Integer = 0 To input.Length - 1
            'checks if the current char is the last char analyzed
            If input.Substring(i, 1) = previousChar Then
                occurances += 1
            Else
                'this character is different than the last character
                ' sets the new character to chount
                previousChar = input.Substring(i, 1)
                'sets the largest occured char as the occurances of that char
                If occurances > V Then
                    V = occurances
                End If
                'reset the number of chars to 1, to analyze the next char
                occurances = 1
            End If
        Next
        Return V
    End Function
End Module
