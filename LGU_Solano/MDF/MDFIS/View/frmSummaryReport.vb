Public Class frmSummaryReport

    'Instantiate object class and Declare variable
    Dim objCsum As ctrSummary = New ctrSummary
    Dim objCul As ctrUserLog = New ctrUserLog
    Dim objMul As mUserLog = New mUserLog
    Public UID As String

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'Record to User Log
        objMul.setUID(UID)
        objMul.setActivity("Searched from Summary Report module")
        objMul.setDateandTime(DateTime.Now)
        objCul.Add(objMul)

        If cboSearchby.Text = "Year" Then
            objCsum.GenReport(dsReport, txtYear.Text, Me)
        ElseIf cboSearchby.Text = "Year and PPA" Then
            objCsum.GenReport(dsReport, txtYear.Text, txtPPA.Text, Me)
        Else
        End If
    End Sub

    Private Sub txtYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub cboSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchby.SelectedIndexChanged
        If cboSearchby.Text = "Year" Then
            txtYear.Focus()
        ElseIf cboSearchby.Text = "Year and PPA" Then
            txtPPA.Focus()
        End If
    End Sub

    Private Sub txtPPA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPPA.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If dsReport.tblsummary.Rows.Count <> 0 Then
            Dim aoi As frmAOI = New frmAOI
            aoi.rv = rvDisplay
            aoi.Rtype = "Summary Report"
            aoi.ShowDialog()
        End If
    End Sub
End Class