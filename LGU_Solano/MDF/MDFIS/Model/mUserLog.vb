Public Class mUserLog

    'Declare Attributes

    Private ULID As String
    Private UID As String
    Private Activity As String
    Private DateandTime As DateTime
    Private dt As DataTable

    'Set Data

    Public Sub setULID(ByVal uULID As String)
        ULID = uULID
    End Sub
    Public Sub setUID(ByVal uUID As String)
        UID = uUID
    End Sub
    Public Sub setActivity(ByVal uActivity As String)
        Activity = uActivity
    End Sub
    Public Sub setDateandTime(ByVal uDateandTime As DateTime)
        DateandTime = uDateandTime
    End Sub
    Public Sub setData(ByVal dtAll As DataTable)
        dt = dtAll
    End Sub


    'Get Data

    Public Function getULID()
        Return ULID
    End Function
    Public Function getUID()
        Return UID
    End Function
    Public Function getActivity()
        Return Activity
    End Function
    Public Function getDateandTime()
        Return DateandTime
    End Function
    Public Function getData()
        Return dt
    End Function

End Class
