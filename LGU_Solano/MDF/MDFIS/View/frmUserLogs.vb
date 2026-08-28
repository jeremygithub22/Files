Public Class frmUserLogs

    'Instantiate object class
    Dim objMul As mUserLog = New mUserLog
    Dim objCul As ctrUserLog = New ctrUserLog
    Public UID As String
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'Record to User Log
        objMul.setUID(UID)
        objMul.setActivity("Searched from User Log module")
        objMul.setDateandTime(DateTime.Now)
        objCul.Add(objMul)

        objMul.setDateandTime(dtpDate.Value)
        objCul.Search(objMul)
        dgvList.DataSource = objMul.getData
    End Sub
End Class