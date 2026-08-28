Public Class mPPAFundingInfo

    'Declare Attributes

    Private No As String
    Private DateReceived As String
    Private Year As String
    Private Budget As String
    Private AIPRC As String
    Private PPA As String
    Private dt As DataTable
    Private Status As Boolean
    'Set Data

    Public Sub setStatus(ByVal PStatus As Boolean)
        Status = PStatus
    End Sub
    Public Sub setNo(ByVal PNo As String)
        No = PNo
    End Sub
    Public Sub setDateReceived(ByVal PDateReceived As String)
        DateReceived = PDateReceived
    End Sub
    Public Sub setYear(ByVal PYear As String)
        Year = PYear
    End Sub
    Public Sub setBudget(ByVal PBudget As String)
        Budget = PBudget
    End Sub
    Public Sub setAIPRC(ByVal PAIPPRC As String)
        AIPRC = PAIPPRC
    End Sub
    Public Sub setPPA(ByVal PPPA As String)
        PPA = PPPA
    End Sub
    Public Sub setData(ByVal dtall As DataTable)
        dt = dtall
    End Sub

    'Get Data

    Public Function getStatus()
        Return Status
    End Function
    Public Function getNo()
        Return No
    End Function
    Public Function getDateReceived()
        Return DateReceived
    End Function
    Public Function getYear()
        Return Year
    End Function
    Public Function getBudget()
        Return Budget
    End Function
    Public Function getAIPRC()
        Return AIPRC
    End Function
    Public Function getPPA()
        Return PPA
    End Function
    Public Function getData()
        Return dt
    End Function
End Class
