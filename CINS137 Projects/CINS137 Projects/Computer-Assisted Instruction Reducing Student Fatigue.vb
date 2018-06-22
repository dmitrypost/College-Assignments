Option Explicit On
Option Strict On
Public Class Computer_Assisted_Instruction_Reducing_Student_Fatigue
    Dim i, j As Integer 'numbers that will be used to multiply
    Dim rand As New System.Random 'used for random number generation
    Function newProblem() As String 'created new problem and returns it.
        i = rand.Next(12)
        j = rand.Next(12)
        Return "How much is " & i & " times " & j & "?"
    End Function
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        outputTextBox.Text = newProblem()
    End Sub
    Private Sub CheckAnswer(sender As Object, e As KeyPressEventArgs) Handles userInputTextBox.KeyPress
        If e.KeyChar.GetHashCode.ToString = "851981" Then 'checks if enter is pressed
            If userInputTextBox.Text = CStr(i * j) Then 'evaluate with correct answer
                outputTextBox.Text = newProblem() & vbNewLine & response(True) & vbNewLine & outputTextBox.Text
            Else 'if answer is incorrect gives a new try
                outputTextBox.Text = response(False) & vbNewLine & outputTextBox.Text
            End If
            userInputTextBox.Text = String.Empty
        End If
    End Sub
    Function response(ByVal right As Boolean) As String
        Dim randomOutput As Integer = rand.Next(1, 5)
        If right Then 'outputs if the answer given is correct
            Select Case randomOutput
                Case 1
                    Return "Very good!"
                Case 2
                    Return "Exellent!"
                Case 3
                    Return "Nice work!"
                Case 4
                    Return "Keep up the good work!"
            End Select
        Else 'outputs if the answer given is incorrect
            Select Case randomOutput
                Case 1
                    Return "No. Please try again."
                Case 2
                    Return "Wrong. Try once more."
                Case 3
                    Return "Don't give up!"
                Case 4
                    Return "No. Keep trying."
            End Select
        End If
    End Function
End Class