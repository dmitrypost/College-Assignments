Public Class Main
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim formType As Type = Type.GetType("System.Windows.Forms.Form")
        For Each t As Type In sender.GetType().Assembly.GetTypes()
            If UCase(t.BaseType.ToString) = "SYSTEM.WINDOWS.FORMS.FORM" Then
                If Not t.Name = Me.Name Then ' makes sure your not starting self...
                    ListBox1.Items.Add(t.Name)
                End If
            End If
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Not ListBox1.SelectedItem = Nothing Then
            Start()
        End If
    End Sub

    Sub Start()
        Me.Visible = False

        Dim t As Type = Type.GetType(" CINS137_Projects." & ListBox1.SelectedItem)
        Dim f As Form = Activator.CreateInstance(t)
        f.ShowDialog()
        Me.Visible = True
        ListBox1.SelectedItem = Nothing
        StatusLabel.Focus()
    End Sub

End Class