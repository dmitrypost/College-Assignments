Option Explicit On
Option Strict On
Public Class Computer_Assisted_Instruction
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
                outputTextBox.Text = newProblem() & vbNewLine & "Very good!" & vbNewLine & outputTextBox.Text
            Else 'if answer is incorrect gives a new try
                outputTextBox.Text = "No. Please try again." & vbNewLine & outputTextBox.Text
            End If
            userInputTextBox.Text = String.Empty
        End If
    End Sub
End Class