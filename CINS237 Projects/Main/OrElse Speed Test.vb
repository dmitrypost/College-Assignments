Module OrElse_Speed_Test

    Sub Main()

        'Dim s As String = "Hello there."
        'For p As Integer = s.Length - 1 To 0 Step -1
        '    Console.Write(s(p))

        'Next

        'Console.WriteLine(s.Substring(0, s.Length - 1))

        'Example program to prove that OrElse is faster than Or
        ' (and AndAlso is faster and)
        'Lonnie Clifton 1/13/09

        'To compare times for the or and orelse 

        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        Dim tf As Boolean
        Dim a As Integer = 2
        Dim b As Integer = 1
        Console.WriteLine("Or Test ""no shortcut""")
        start_time = Now
        For i As Long = 1 To 100000000
            tf = a < b Or b < a Or b < a Or b < a Or b < a
            tf = b < a And a < b And a < b And a < b And a < b
        Next
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)

        Console.WriteLine()
        Console.Write("Total time in loop is: ")
        Console.Write(elapsed_time.TotalSeconds.ToString("#.000000"))
        Console.WriteLine(" Seconds")

        Console.WriteLine()
        Console.WriteLine()

        Console.WriteLine("OrElse Test ""shortcut""")
        start_time = Now
        For i As Long = 1 To 100000000
            tf = a < b OrElse b < a OrElse b < a OrElse b < a OrElse b < a
            tf = b < a AndAlso a < b AndAlso a < b AndAlso a < b AndAlso a < b
        Next
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)

        Console.WriteLine()
        Console.Write("Total time in loop is: ")
        Console.Write(elapsed_time.TotalSeconds.ToString("#.000000"))
        Console.WriteLine(" Seconds")
        Console.WriteLine()
        Console.ReadLine()
        Console.ReadLine()
    End Sub

End Module
