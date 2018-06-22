Imports System
Imports System.IO
Imports System.Security.AccessControl
Public Class ACL_Proof_Of_Concept
    'selects a file for processing it's ACL
    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        Dim dialog As New OpenFileDialog With {.Title = "Select file", .Multiselect = False}
        If DialogResult.OK = dialog.ShowDialog Then
            TextBox1.Text = dialog.FileName
        End If
    End Sub

    Private Shared Sub SetRule(ByVal filePath As String, ByVal account As String, ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)
        'makes sure the file exists
        If Not File.Exists(filePath) Then Exit Sub
        ' Get a FileSecurity object that represents the
        ' current security settings.
        Dim fSecurity As FileSecurity = File.GetAccessControl(filePath)
        ' Update the FileSystemAccessRule with the new
        ' security settings.
        fSecurity.ResetAccessRule(New FileSystemAccessRule(account, rights, controlType))
        ' Set the new access settings.
        File.SetAccessControl(filePath, fSecurity)
    End Sub
    ' READ
    Private Sub Read_Deny(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        SetRule(TextBox1.Text, "Everyone", FileSystemRights.Read, AccessControlType.Deny)
    End Sub
    Private Sub Read_Allow(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        SetRule(TextBox1.Text, "Everyone", FileSystemRights.Read, AccessControlType.Allow)
    End Sub
    ' WRITE
    Private Sub Write_Allow(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        SetRule(TextBox1.Text, "Everyone", FileSystemRights.Write, AccessControlType.Allow)
    End Sub
    Private Sub Write_Deny(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        SetRule(TextBox1.Text, "Everyone", FileSystemRights.Write, AccessControlType.Deny)
    End Sub

End Class