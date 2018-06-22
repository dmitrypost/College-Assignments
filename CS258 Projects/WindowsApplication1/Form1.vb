Imports System.Threading
Imports System.Reflection
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1
   

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function AllocConsole() As Boolean
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function FreeConsole() As Boolean
    End Function
    Private Sub bobConsole()
        Dim file As Byte() = My.Resources.ConsoleApplication
        Dim target As System.Reflection.Assembly = [Assembly].Load(file)
        Dim entryPoint As MethodInfo = target.EntryPoint
        Dim bobo As Object = Nothing
        If Not entryPoint Is Nothing Then
            Try
                
                AllocConsole()
                ' reopen stdout
                Dim writer As TextWriter = New StreamWriter(Console.OpenStandardOutput()) With {.AutoFlush = True}
                Console.SetOut(writer)
                Dim reader As TextReader = New StreamReader(Console.OpenStandardInput())
                Console.SetIn(reader)
                Dim errWriter As TextWriter = New StreamWriter(Console.OpenStandardError()) With {.AutoFlush = True}
                Console.SetError(errWriter)

                entryPoint.Invoke(Nothing, Nothing)

                'after the code is run... clean the console up...
                Console.SetIn(TextReader.Null)
                Console.SetOut(TextWriter.Null)
                Console.SetError(TextWriter.Null)


                'Disposes the console...
                FreeConsole()
            Catch AME As AmbiguousMatchException 'main function takes arguements
                'arguements for the program to be run...
                Dim argss As String() = New String() {"", ""}

                
                AllocConsole()
                ' reopen stdout
                Dim writer As TextWriter = New StreamWriter(Console.OpenStandardOutput()) With {.AutoFlush = True}
                Console.SetOut(writer)
                Dim reader As TextReader = New StreamReader(Console.OpenStandardInput())
                Console.SetIn(reader)
                Dim errWriter As TextWriter = New StreamWriter(Console.OpenStandardError()) With {.AutoFlush = True}
                Console.SetError(errWriter)
                entryPoint.Invoke(Nothing, New Object() {argss})

                'after the code is run... clean the console up...
                Console.SetIn(TextReader.Null)
                Console.SetOut(TextWriter.Null)
                Console.SetError(TextWriter.Null)


                'Disposes the console...
                FreeConsole()
            Catch ex As Exception



            End Try

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim b = New Thread(New ThreadStart(AddressOf Me.bobConsole))
        b.Start()
    End Sub
End Class
