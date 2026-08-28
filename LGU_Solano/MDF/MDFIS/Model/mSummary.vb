Public Class mSummary

    'Declare Attributes

    Private CtrNo As String
    Private Amount As String
    Private Expenditure As String
    Private Balance As String
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
    Public Sub setAmount(ByVal SAmount As String)
        Amount = SAmount
    End Sub
    Public Sub setExpenditure(ByVal SExpenditure As String)
        Expenditure = SExpenditure
    End Sub
    Public Sub setBalance(ByVal SBalance As String)
        Balance = SBalance
    End Sub

    'Get Data
    Public Function getCtrNo()
        Return CtrNo
    End Function
    Public Function getAmount()
        Return Amount
    End Function
    Public Function getExpenditure()
        Return Expenditure
    End Function
    Public Function getBalance()
        Return Balance
    End Function
    Public Function getData()
        Return dt
    End Function
    Public Function getNo()
        Return No
    End Function
End Class
