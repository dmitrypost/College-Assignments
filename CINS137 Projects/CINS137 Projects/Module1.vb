Module Module1
    Function getAverage(ByVal array As Array)
        Dim average As Double
        For i = 0 To array.GetUpperBound(0)
            average += array(i)
        Next
        average = (average / array.GetLength(0))
        Return "Average is: " & average
    End Function
End Module
