

Imports System.Linq
Imports System.IO


Public Class Telegram

    '    Public Class WebSessionStore
    '        Implements ISessionStore
    '        Dim file = HttpContext.Current.Server.MapPath("/App_Data/{0}.dat")
    '        Public Sub Save(session As Session) Implements ISessionStore.Save


    '            Using fileStream As New FileStream(String.Format(file, CType(session.SessionUserId, Object)), FileMode.OpenOrCreate)
    '                Dim bytes As Byte() = session.ToBytes()
    '                fileStream.Write(bytes, 0, bytes.Length)
    '            End Using
    '        End Sub

    '        Public Function Load(sessionUserId As String) As Session Implements ISessionStore.Load
    '            'Dim file = HttpContext.Current.Server.MapPath("/App_Data/{0}.dat")
    '            Dim path As String = String.Format(file, CType(sessionUserId, Object))

    '            If Not System.IO.File.Exists(path) Then
    '                Return CType(Nothing, Session)
    '            End If

    '            Dim buffer As Object = System.IO.File.ReadAllBytes(path)
    '            Return Session.FromBytes(buffer, Me, sessionUserId)
    '        End Function
    '    End Class
    '#Region "Telegram Api"

    '    Public Async Sub AddContactTelegram(_phone As String(), _Suffix As String, FullName As String)

    '        Try


    '        Dim client = New TelegramClient(AppId, HashCode, New WebSessionStore)

    '        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High

    '        Await client.ConnectAsync()

    '        If client.IsUserAuthorized() Then
    '            Dim ContactList As TLContacts = Await client.GetContactsAsync()
    '            Dim contacts = New List(Of TLInputPhoneContact)()

    '            For Each phone As String In _phone
    '                Dim phoneContact = New TLInputPhoneContact() With {.phone = phone, .first_name = _Suffix, .last_name = FullName}
    '                contacts.Add(phoneContact)
    '            Next

    '            If contacts.Count > 0 Then
    '                Dim req = New TLRequestImportContacts() With {.contacts = New TLVector(Of TLInputPhoneContact)() With {.lists = contacts}}
    '                Dim rrr As TLImportedContacts = Await client.SendRequestAsync(Of TLImportedContacts)(req)
    '            End If

    '        End If

    '        Catch ex As Exception
    '            result = "1"
    '        End Try
    '    End Sub


    '    Public Async Sub SendPhotoMessageTelegram(_PathImage As String, _PhoneNumber As String(), _Matn As String)
    '        Try


    '            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High

    '            Dim _StandarPhoneNumber As New List(Of String)
    '            For index = 0 To _PhoneNumber.Length - 1
    '                If _PhoneNumber(index).StartsWith("0") Then

    '                    Dim str = "98" & _PhoneNumber(index).Remove(0, 1)
    '                    _StandarPhoneNumber.Add(str)
    '                Else
    '                    _StandarPhoneNumber.Add(_PhoneNumber(index))
    '                End If
    '            Next


    '            Dim client = New TelegramClient(AppId, HashCode, New WebSessionStore())

    '            Await client.ConnectAsync()
    '            If client.IsUserAuthorized Then
    '                Dim fileResult4 = CType(Await client.UploadFile(Path.GetFileName(_PathImage), New StreamReader(_PathImage)), TLInputFile)
    '                Dim ContactsAcc = Await client.GetContactsAsync()
    '                Dim user As IEnumerable(Of TLUser) = From x In (From x In ContactsAcc.users.lists Where x.GetType() = GetType(TLUser)).Cast(Of TLUser)() Where _StandarPhoneNumber.Contains(x.phone) Select x
    '                For Each u As TLUser In user
    '                    Await client.SendUploadedPhoto(New TLInputPeerUser() With {.user_id = u.id}, fileResult4, _Matn & vbNewLine & AdvUserIDTelegram)

    '                Next

    '            End If

    '        Catch ex As Exception
    '            result = "1"
    '        End Try

    '    End Sub

    '    Public Async Sub SendTextMessageTelegram(_Message As String, _PhoneNumber As String())

    '        Try
    '            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High


    '            Dim _StandarPhoneNumber As New List(Of String)
    '            For index = 0 To _PhoneNumber.Length - 1
    '                If _PhoneNumber(index).StartsWith("0") Then

    '                    Dim str = "98" & _PhoneNumber(index).Remove(0, 1)
    '                    _StandarPhoneNumber.Add(str)
    '                Else
    '                    _StandarPhoneNumber.Add(_PhoneNumber(index))
    '                End If
    '            Next

    '            Dim client = New TelegramClient(AppId, HashCode, New WebSessionStore())

    '            Await client.ConnectAsync()
    '            If client.IsUserAuthorized Then
    '                Dim ContactsAcc = Await client.GetContactsAsync()
    '                Dim user As IEnumerable(Of TLUser) = From x In (From x In ContactsAcc.users.lists Where x.GetType() = GetType(TLUser)).Cast(Of TLUser)() Where _StandarPhoneNumber.Contains(x.phone) Select x
    '                For Each u As TLUser In user
    '                    Await client.SendMessageAsync(New TLInputPeerUser() With {.user_id = u.id}, _Message)
    '                Next

    '            End If
    '        Catch ex As Exception
    '            result = "1"
    '        End Try
    '    End Sub


    '#End Region

End Class
