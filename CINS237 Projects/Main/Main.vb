Module Main
    Sub main()
        Dim sender As Object = My.Application
        For Each t As Type In sender.GetType().Assembly.GetTypes()
            If UCase(t.BaseType.ToString) = "SYSTEM.WINDOWS.FORMS.FORM" Then

            Else
                If t.ToString.Contains("Main.My.") Then
                Else
                    System.Console.WriteLine(t.ToString.Remove(0, 5))

                End If

            End If
        Next
        System.Console.ReadLine()
    End Sub
End Module
