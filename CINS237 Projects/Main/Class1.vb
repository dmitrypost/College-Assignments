
Imports Microsoft.Win32
Imports System
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text

Namespace Infralution.Licensing
    Public Class EvaluationMonitor
        'Implements IDisposable

        Private Const classUsageKey As String = "TypeLib"

        Private Const classFirstUseKey As String = "InprocServer32"

        Private Const classLastUseKey As String = "Control"

        Private Const userUsageKey As String = "Software\Microsoft\WAB\WAB4"

        Private Const userFirstUseKey As String = "Software\Microsoft\WAB\WAB Sort State"

        Private Const userLastUseKey As String = "Software\Microsoft\WAB\WAB4\LastFind"

        Private _productData As Byte()

        Private _usageCount As Integer = 1

        Private _firstUseDate As DateTime = DateTime.MinValue

        Private _lastUseDate As DateTime = DateTime.MinValue

        Private _invalid As Boolean

        Private _countUsageOncePerDay As Boolean

        Private _rootKey As RegistryKey

        Private _baseKey As RegistryKey

        Private _usageKeyName As String

        Private _firstUseKeyName As String

        Private _lastUseKeyName As String

        Private Shared _desKey As Byte() = New Byte() {18, 117, 168, 241, 50, 237, 19, 242}

        Private Shared _desIV As Byte() = New Byte() {163, 239, 214, 33, 55, 128, 204, 177}

        Public Property CountUsageOncePerDay() As Boolean
            Get
                Return Me._countUsageOncePerDay
            End Get
            Set(value As Boolean)
                Me._countUsageOncePerDay = value
            End Set
        End Property

        Public ReadOnly Property UsageCount() As Integer
            Get
                Return Me._usageCount
            End Get
        End Property

        Public ReadOnly Property FirstUseDate() As DateTime
            Get
                Return Me._firstUseDate
            End Get
        End Property

        Public ReadOnly Property LastUseDate() As DateTime
            Get
                Return Me._lastUseDate
            End Get
        End Property

        Public ReadOnly Property DaysInUse() As Integer
            Get
                Return DateTime.UtcNow.Subtract(Me._firstUseDate).Days + 1
            End Get
        End Property

        Public ReadOnly Property Invalid() As Boolean
            Get
                Return Me._invalid
            End Get
        End Property

        Public Sub New(password As String, countUsageOncePerDay As Boolean)
            Me._countUsageOncePerDay = countUsageOncePerDay
            Me._productData = Me.Encrypt(password)
            Try
                Dim classesRootParentKey As RegistryKey = Me.GetClassesRootParentKey(password)
                Me.CreateOrUpdateData(classesRootParentKey)
            Catch ex_4B As Exception
                Try
                    Dim currentUserParentKey As RegistryKey = Me.GetCurrentUserParentKey()
                    Me.CreateOrUpdateData(currentUserParentKey)
                Catch ex_5F As Exception
                    Me._invalid = True
                End Try
            End Try
        End Sub

        Private Function GetClassesRootParentKey(password As String) As RegistryKey
            Using Registry.ClassesRoot.CreateSubKey(password)
                Registry.ClassesRoot.DeleteSubKey(password, False)
            End Using
            Me._rootKey = Registry.ClassesRoot
            Dim result As RegistryKey = Me._rootKey.OpenSubKey("CLSID", True)
            Me._usageKeyName = "TypeLib"
            Me._firstUseKeyName = "InprocServer32"
            Me._lastUseKeyName = "Control"
            Return result
        End Function

        Private Function GetCurrentUserParentKey() As RegistryKey
            Me._rootKey = Registry.CurrentUser
            Dim registryKey As RegistryKey = Me._rootKey.OpenSubKey("Identities", True)
            If registryKey Is Nothing Then
                registryKey = Me._rootKey.CreateSubKey("Identities")
            End If
            Me._usageKeyName = "Software\Microsoft\WAB\WAB4"
            Me._firstUseKeyName = "Software\Microsoft\WAB\WAB Sort State"
            Me._lastUseKeyName = "Software\Microsoft\WAB\WAB4\LastFind"
            Return registryKey
        End Function

        Private Sub CreateOrUpdateData(parentKey As RegistryKey)
            Me._baseKey = Me.FindBaseKey(parentKey)
            If Me._baseKey Is Nothing Then
                Me._usageCount = 1
                Me._firstUseDate = DateTime.UtcNow
                Me._lastUseDate = DateTime.UtcNow
                Me.CreateBaseKey(parentKey)
            Else
                Me.UpdateData()
            End If
            parentKey.Close()
        End Sub

        'Public Sub New(password As String)
        '    Me.[New](password, False)
        'End Sub

        'Sub Finalize()
        '    Me.Dispose()
        'End Sub

        Private Function FindBaseKey(parent As RegistryKey) As RegistryKey
            Dim subKeyNames As String() = parent.GetSubKeyNames()
            Dim array As String() = subKeyNames
            For i As Integer = 0 To array.Length - 1
                Dim name As String = array(i)
                Try
                    Dim registryKey As RegistryKey = parent.OpenSubKey(name)
                    Dim value As Object = registryKey.GetValue(Nothing)
                    If TypeOf value Is Byte() AndAlso Me.Equals_rned(TryCast(value, Byte()), Me._productData) Then
                        Return registryKey
                    End If
                    registryKey.Close()
                Catch ex_64 As System.Exception
                End Try
            Next
            Return Nothing
        End Function

        Private Sub CreateBaseKey(parent As RegistryKey)
            Dim text As String = Guid.NewGuid().ToString().ToUpper()
            text = "0" + text.Substring(1)
            Dim subkey As String = String.Format("{{{0}}}", text)
            Me._baseKey = parent.CreateSubKey(subkey)
            Me._baseKey.SetValue(Nothing, Me._productData)
            Dim registryKey As RegistryKey = Me._baseKey.CreateSubKey(Me._firstUseKeyName)
            registryKey.SetValue(Nothing, Me.EncryptDate(Me._firstUseDate))
            registryKey.Close()
            Dim registryKey2 As RegistryKey = Me._baseKey.CreateSubKey(Me._usageKeyName)
            registryKey2.SetValue(Nothing, Me.Encrypt(Me._usageCount.ToString(CultureInfo.InvariantCulture)))
            registryKey2.Close()
            Dim registryKey3 As RegistryKey = Me._baseKey.CreateSubKey(Me._lastUseKeyName)
            registryKey3.SetValue(Nothing, Me.EncryptDate(Me._lastUseDate))
            registryKey3.Close()
        End Sub

        Private Sub UpdateData()
            Dim registryKey As RegistryKey = Me._baseKey.OpenSubKey(Me._firstUseKeyName, True)
            Me._firstUseDate = Me.DecryptDate(CType(registryKey.GetValue(Nothing), Byte()))
            Dim registryKey2 As RegistryKey = Me._baseKey.OpenSubKey(Me._lastUseKeyName, True)
            Me._lastUseDate = Me.DecryptDate(CType(registryKey2.GetValue(Nothing), Byte()))
            Dim totalHours As Double = DateTime.UtcNow.Subtract(Me._lastUseDate).TotalHours
            Dim flag As Boolean = Not Me._countUsageOncePerDay OrElse totalHours > 24.0
            If totalHours < -6.0 Then
                Me._invalid = True
            Else
                If flag Then
                    registryKey.SetValue(Nothing, Me.EncryptDate(Me._firstUseDate))
                    registryKey2.SetValue(Nothing, Me.EncryptDate(DateTime.UtcNow))
                End If
            End If
            Dim registryKey3 As RegistryKey = Me._baseKey.OpenSubKey(Me._usageKeyName, True)
            Dim s As String = Me.Decrypt(CType(registryKey3.GetValue(Nothing), Byte()))
            Me._usageCount = Integer.Parse(s, CultureInfo.InvariantCulture)
            If flag Then
                Me._usageCount += 1
                registryKey3.SetValue(Nothing, Me.Encrypt(Me._usageCount.ToString(CultureInfo.InvariantCulture)))
            End If
            registryKey3.Close()
            registryKey2.Close()
            registryKey.Close()
        End Sub

        Private Function Encrypt(text As String) As Byte()
            Dim dESCryptoServiceProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider()
            dESCryptoServiceProvider.Key = EvaluationMonitor._desKey
            dESCryptoServiceProvider.IV = EvaluationMonitor._desIV
            Dim bytes As Byte() = Encoding.ASCII.GetBytes(text)
            Return dESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length)
        End Function

        Private Function Decrypt(data As Byte()) As String
            Dim bytes As Byte() = New DESCryptoServiceProvider() With {.Key = EvaluationMonitor._desKey, .IV = EvaluationMonitor._desIV}.CreateDecryptor().TransformFinalBlock(data, 0, data.Length)
            Return Encoding.ASCII.GetString(bytes)
        End Function

        Private Function EncryptDate([date] As DateTime) As Byte()
            Dim text As String = "I" + [date].ToString(CultureInfo.InvariantCulture)
            Return Me.Encrypt(text)
        End Function

        Private Function DecryptDate(data As Byte()) As DateTime
            Dim text As String = Me.Decrypt(data)
            Dim provider As CultureInfo = CultureInfo.CurrentCulture
            If text(0) = "I" Then
                text = text.Substring(1)
                provider = CultureInfo.InvariantCulture
            End If
            Return DateTime.Parse(text, provider)
        End Function

        Private Function Equals_rned(a1 As Byte(), a2 As Byte()) As Boolean
            If a1 = a2 Then
                Return True
            End If
            If a1 Is Nothing OrElse a2 Is Nothing Then
                Return False
            End If
            If a1.Length <> a2.Length Then
                Return False
            End If
            For i As Integer = 0 To a1.Length - 1
                If a1(i) <> a2(i) Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Sub Dispose()
            If Me._baseKey IsNot Nothing Then
                Me._baseKey.Close()
                Me._baseKey = Nothing
            End If
            If Me._rootKey IsNot Nothing Then
                Me._rootKey.Close()
                Me._rootKey = Nothing
            End If
            GC.SuppressFinalize(Me)
        End Sub
    End Class
End Namespace