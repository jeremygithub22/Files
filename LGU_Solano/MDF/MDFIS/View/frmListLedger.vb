Public Class frmListLedger
    'Instantiate object class and Declare variable
    Dim objCpledger As ctrPPALedger = New ctrPPALedger
    Dim objCul As ctrUserLog = New ctrUserLog
    Dim objMul As mUserLog = New mUserLog
    Public UID As String

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        objCpledger.GenReport(dsReport, dtpDate.Value.ToShortDateString, Me, cboSearchby.Text)
    End Sub

    Private Sub frmListLedger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class