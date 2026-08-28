Public Class mSAAOB
    'Declare Attributes

    Private CtrNo As String
    Private Appropriation As String
    Private Obligation As String
    Private UnobligatedAllotment As String
    Private dt As DataTable
    Private No As String

    'Set Data
    Public Sub setNo(ByVal SNo As String)
        No = SNo
    End Sub
    Public Sub setData(ByVal dtAll As DataTable)
        dt = dtAll
    End Sub
    Public Sub setCtrNo(ByVal SCtrNo As String)
        CtrNo = SCtrNo
    End Sub
    Public Sub setAppropriation(ByVal SAppropriation As String)
        Appropriation = SAppropriation
    End Sub
    Public Sub setObligation(ByVal SObligation As String)
        Obligation = SObligation
    End Sub
    Public Sub setUnobligatedAllotment(ByVal SUnobligatedAllotment As String)
        UnobligatedAllotment = SUnobligatedAllotment
    End Sub

    'Get Data
    Public Function getCtrNo()
        Return CtrNo
    End Function
    Public Function getAppropriation()
        Return Appropriation
    End Function
    Public Function getObligation()
        Return Obligation
    End Function
    Public Function getUnobligatedAllotment()
        Return UnobligatedAllotment
    End Function
    Public Function getData()
        Return dt
    End Function
    Public Function getNo()
        Return No
    End Function
End Class
