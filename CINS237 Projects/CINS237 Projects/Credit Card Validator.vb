Public Class Credit_Card_Validator
    Dim previousString As New System.Text.StringBuilder
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Select Case TextBox1.Text.Substring(TextBox1.Text.Length - 1, 1)
            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-"
            Case Else
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1)
                TextBox1.SelectionStart = TextBox1.Text.Length
        End Select
        Select Case TextBox1.Text.Length
            Case 4, 9, 14 'insertion and deletion of the - when needed.
                If Not previousString.ToString.Substring(previousString.ToString.Length - 1, 1) = "-" Then
                    TextBox1.Text &= "-"
                    TextBox1.SelectionStart = TextBox1.Text.Length
                End If
            Case 19
                'if valid print valid and card type
                Debug.WriteLine("Checking started...")
                If valid(TextBox1.Text.Replace("-", "")) Then
                    Label1.Text = "Credit Card is VALID"
                    Label1.Text &= vbNewLine & "Major Industry Identifier: " & MII(TextBox1.Text.Substring(0, 1))
                    Label1.Text &= vbNewLine & "Card Type: " & CardType(TextBox1.Text.Substring(0, 4))
                Else
                    Label1.Text = "Credit Card is INVALID"
                End If
        End Select
        previousString.Clear()
        previousString.Append(TextBox1.Text)
    End Sub
    Function valid(ByVal ccNumbers As String) As Boolean
        Dim numbers(15, 2) As Integer
        'places the numbers into the first row of the array
        For i As Integer = 0 To 15
            numbers(i, 0) = ccNumbers.Substring(i, 1)
        Next
        'multiplies every other number into the second row of the array
        For i As Integer = 0 To 15 Step 2
            numbers(i, 1) = numbers(i, 0) * 2
        Next
        For i As Integer = 0 To 15 Step 2
            'if two digits long then add first digit to second digit
            If numbers(i, 1).ToString.Length = 2 Then
                numbers(i, 2) = CInt(numbers(i, 1).ToString.Substring(0, 1)) + CInt(numbers(i, 1).ToString.Substring(1, 1))
            End If
        Next
        'add all the digits up that are relative to determaning valitity
        Dim sum As Integer = 0
        For i As Integer = 0 To 15
            If Not numbers(i, 2) = 0 Then
                sum += numbers(i, 2)
            Else
                If Not numbers(i, 1) = 0 Then
                    sum += numbers(i, 1)
                Else
                    sum += numbers(i, 0)
                End If
            End If
        Next
        'if the farright digit is NOT 0 then the card is invalid
        If sum.ToString.Substring(sum.ToString.Length - 1, 1) = 0 Then
            Return True
        End If
        Debug.WriteLine(sum)
        Return False
    End Function
    Function MII(ByVal firstNumber As Integer) As String
        Select Case firstNumber
            Case 0
                Return "ISO/TC 68 and other future industry assignments"
            Case 1
                Return "Airlines"
            Case 2
                Return "Airlines and other future industry assignments"
            Case 3
                Return "Travel, entertainment, and banking/financial"
            Case 4
                Return "Banking/financial"
            Case 5, 6
                Return "Merchandising and banking/financial"
            Case 7
                Return "Petroleum and other future industry assignments"
            Case 8
                Return "Healthcare, telecommunications, and other future industry assignments"
            Case 9
                Return "National assignment"
            Case Else
                Return ""
        End Select
    End Function
    Function CardType(ByVal INN As String) As String
        If INN = 5610 Then
            Return "Bankcard"
        ElseIf INN = 6011 Or INN.Substring(0, 2) = 65 Then
            Return "Discover"
        ElseIf 3528 <= INN And INN <= 3589 Then
            Return "JBC"
        ElseIf INN = 6304 Or INN = 6706 Or INN = 6771 Or INN = 6709 Then
            Return "Laser"
        ElseIf INN = 5018 Or INN = 5020 Or INN = 5038 Or INN = 5893 Or _
            INN = 6304 Or INN = 6759 Or INN = 6761 Or INN = 6762 Or _
            INN = 6763 Or INN = 604 Then
            Return "Maestro"
        ElseIf INN = 6334 Or INN = 6767 Then
            Return "Solo"
        ElseIf INN = 4903 Or INN = 4905 Or INN = 4911 Or INN = 4936 Or INN = 6333 Or INN = 6759 Then
            Return "Switch"
        ElseIf INN = 4026 Or INN = 4405 Or INN = 4508 Or INN = 4844 Or INN = 4913 Or INN = 4917 Then
            Return "Visa Electron"
        ElseIf INN.Substring(0, 2) = 62 Then
            Return "China UnionPay"
        ElseIf INN.Substring(0, 2) = 54 Or INN.Substring(0, 2) = 55 Then
            Return "Diners Club *United States & Canada"
        ElseIf 51 <= INN.Substring(0, 2) And INN.Substring(0, 2) <= 55 Then
            Return "MasterCard"
        ElseIf INN.Substring(0, 1) = 4 Then
            Return "Visa"
        Else
            Return "Unknown"
        End If
    End Function
End Class