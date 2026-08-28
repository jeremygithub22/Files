Public Class mPPALedger

    'Declare Attributes

    Private LPPAID As String
    Private No As String
    Private DateReceived As String
    Private Particulars As String
    Private Debit As String
    Private Credit As String
    Private RunningBal As String
    Private Payee As String
    Private ProjectName As String
    Private Location As String
    Private Remarks As String
    Private dt As DataTable
    Private Status As Boolean
    Private CtrNo As String
    Private GSO As String
    Private BStatus As String

    'Set Data

    Public Sub setGSO(ByVal lGSO As String)
        GSO = lGSO
    End Sub
    Public Sub setBStatus(ByVal lBStatus As String)
        BStatus = lBStatus
    End Sub
    Public Sub setCtrNo(ByVal lCtrNo As String)
        CtrNo = lCtrNo
    End Sub
    Public Sub setStatus(ByVal lStatus As Boolean)
        Status = lStatus
    End Sub
    Public Sub setLPPAID(ByVal lLPPAID As String)
        LPPAID = lLPPAID
    End Sub
    Public Sub setNo(ByVal lNo As String)
        No = lNo
    End Sub
    Public Sub setDateReceived(ByVal lDateReceived As String)
        DateReceived = lDateReceived
    End Sub
    Public Sub setParticulars(ByVal lParticulars As String)
        Particulars = lParticulars
    End Sub
    Public Sub setDebit(ByVal lDebit As String)
        Debit = lDebit
    End Sub
    Public Sub setCredit(ByVal lCredit As String)
        Credit = lCredit
    End Sub
    Public Sub setRunningBal(ByVal lRunningBal As String)
        RunningBal = lRunningBal
    End Sub
    Public Sub setData(ByVal dtAll As DataTable)
        dt = dtAll
    End Sub
    Public Sub setPayee(ByVal lPayee As String)
        Payee = lPayee
    End Sub
    Public Sub setProjectName(ByVal lProjectName As String)
        ProjectName = lProjectName
    End Sub
    Public Sub setLocation(ByVal lLocation As String)
        Location = lLocation
    End Sub
    Public Sub setRemarks(ByVal lRemarks As String)
        Remarks = lRemarks
    End Sub

    'Get Data

    Public Function getLPPAID()
        Return LPPAID
    End Function
    Public Function getNo()
        Return No
    End Function
    Public Function getDateReceived()
        Return DateReceived
    End Function
    Public Function getParticulars()
        Return Particulars
    End Function
    Public Function getDebit()
        Return Debit
    End Function
    Public Function getCredit()
        Return Credit
    End Function
    Public Function getRunningBal()
        Return RunningBal
    End Function
    Public Function getData()
        Return dt
    End Function
    Public Function getPayee()
        Return Payee
    End Function
    Public Function getProjectName()
        Return ProjectName
    End Function
    Public Function getLocation()
        Return Location
    End Function
    Public Function getRemarks()
        Return Remarks
    End Function
    Public Function getStatus()
        Return Status
    End Function
    Public Function getCtrNo()
        Return CtrNo
    End Function
    Public Function getGSO()
        Return GSO
    End Function
    Public Function getBStatus()
        Return BStatus
    End Function
End Class
