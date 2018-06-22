Module Paths_Directories_and_Files
    Sub main()
        Dim oText As String = ""
        'path to some place
        Dim thePath As String = "c:\colors\Orange\Demo\Demo1\"
        'if the path exists delte it
        If System.IO.Directory.Exists(thePath) Then
            System.IO.Directory.Delete(thePath, True)
        End If
        'if it don't exist create it
        If Not System.IO.Directory.Exists(thePath) Then
            System.IO.Directory.CreateDirectory(thePath)
        End If
        'if it exists get its directory
        If Not IO.Directory.Exists(thePath) Then
            thePath = IO.Directory.GetCurrentDirectory
        End If
        'if the specified path exists create the directory that is retrieved above
        If Not System.IO.Directory.Exists("C:\demo\") Then
            System.IO.Directory.CreateDirectory(thePath)
        End If
        'if it exists move the sepecified directory into the directory
        If Not IO.Directory.Exists(thePath) Then
            IO.Directory.Move("C:\demo\", thePath)
        End If
        'gets the created date
        Dim myDate As Date = IO.Directory.GetCreationTime("c:\colors")
        'formats it into a string
        oText &= myDate.ToLongDateString
        'gets the parent directory
        Dim myParentDir As String = IO.Directory.GetParent(thePath).ToString
        'lists all the folders and items in the C drive
        For Each myDirItem As String In IO.Directory.GetDirectories("c:\")
            oText &= myDirItem & vbNewLine
        Next
        oText &= "Logical Drives are:"
        'writes the drive letter of each item
        For Each myDirItem As String In IO.Directory.GetLogicalDrives
            oText &= myDirItem & vbNewLine
        Next

        If Not System.IO.Directory.Exists("C:\demo\") Then
            System.IO.Directory.CreateDirectory(thePath)
        End If
        Dim newPathFile As String = "C:\demo\Testing.txt"
        Dim myFA As IO.FileAttributes
        'If IO.File.Exists(newPathFile) Then
        '    IO.File.Delete(newPathFile)
        'End If
        'IO.File.CreateText(newPathFile)
        myFA = IO.File.GetAttributes(newPathFile)
        Dim myReadOnlyFA As IO.FileAttributes = IO.FileAttributes.ReadOnly
        IO.File.SetAttributes(newPathFile, myFA Or myReadOnlyFA Or IO.FileAttributes.Hidden)
        'IO.File.SetAttributes(newPathFile, myFA)
        myFA = IO.File.GetAttributes(newPathFile)
        oText &= newPathFile & vbNewLine
        If CBool(myFA And IO.FileAttributes.ReadOnly) Then oText &= "ReadOnly " '1
        If CBool(myFA And IO.FileAttributes.Hidden) Then oText &= "Hidden " '2
        If CBool(myFA And IO.FileAttributes.System) Then oText &= "System " '4
        If CBool(myFA And IO.FileAttributes.Directory) Then oText &= "Directory " '16
        If CBool(myFA And IO.FileAttributes.Archive) Then oText &= "archive " '32
        If CBool(myFA And IO.FileAttributes.Device) Then oText &= "Device " '64
        If CBool(myFA And IO.FileAttributes.Normal) Then oText &= "Normal " '128
        If CBool(myFA And IO.FileAttributes.Temporary) Then oText &= "Temporary " '256
        If CBool(myFA And IO.FileAttributes.SparseFile) Then oText &= "SparseFile" '512
        If CBool(myFA And IO.FileAttributes.ReparsePoint) Then oText &= "ReparsePoint" '1024
        If CBool(myFA And IO.FileAttributes.Compressed) Then oText &= "Compressed" '2048
        If CBool(myFA And IO.FileAttributes.Offline) Then oText &= "Offline" '4096
        If CBool(myFA And IO.FileAttributes.NotContentIndexed) Then oText &= "archive" '8192
        If CBool(myFA And IO.FileAttributes.Encrypted) Then oText &= "Encrypted" '16384
        If Convert.ToBoolean(myFA And IO.FileAttributes.Normal) Then
            oText &= "File is normal" & vbNewLine
        End If
        Console.Write(oText)
        Console.Read()
    End Sub
End Module
