Public Class mUserAccount

    'Declare Attributes
    Private UID As String
    Private Lastname As String
    Private Firstname As String
    Private Middlename As String
    Private Username As String
    Private Password As String
    Private Type As String
    Private Office As String
    Private dt As DataTable

    'Set Data
    Public Sub setOffice(ByVal uOffice As String)
        Office = uOffice
    End Sub
    Public Sub setUID(ByVal ID As String)
        UID = ID
    End Sub

    Public Sub setLastname(ByVal LN As String)
        Lastname = LN
    End Sub

    Public Sub setFirstname(ByVal FN As String)
        Firstname = FN
    End Sub

    Public Sub setMiddlename(ByVal MN As String)
        Middlename = MN
    End Sub

    Public Sub setUsername(ByVal User As String)
        Username = User
    End Sub

    Public Sub setPassword(ByVal Pass As String)
        Password = Pass
    End Sub

    Public Sub setType(ByVal Utype As String)
        Type = Utype
    End Sub

    Public Sub setData(ByVal dtAll As DataTable)
        dt = dtAll
    End Sub


    'Get Data
    Public Function getUID()
        Return UID
    End Function

    Public Function getLastname()
        Return Lastname
    End Function

    Public Function getFirstname()
        Return Firstname
    End Function

    Public Function getMiddlename()
        Return Middlename
    End Function

    Public Function getUsername()
        Return Username
    End Function

    Public Function getPassword()
        Return Password
    End Function

    Public Function getUType()
        Return Type
    End Function

    Public Function getData()
        Return dt
    End Function
    Public Function getOffice()
        Return Office
    End Function
End Class
