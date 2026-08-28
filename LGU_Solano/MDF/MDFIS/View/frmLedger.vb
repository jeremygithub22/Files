Public Class frmLedger
    'Instantiate object class and Declare variable
    Dim objCledger As ctrPPALedger = New ctrPPALedger
    Public No As String
    Private Sub frmLedger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            objCledger.GenReport(dsReport, No, Me)
        Catch
        End Try
    End Sub
End Class