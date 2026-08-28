'Imports Library
Imports Microsoft.Reporting.WinForms
Public Class frmAOI
    Public rv As ReportViewer
    Public Rtype As String

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If Rtype = "SAAOB" Then
                Dim pname As ReportParameter = New ReportParameter("Pname", txtPname.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {pname})
                Dim ppos As ReportParameter = New ReportParameter("Ppos", txtPpos.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {ppos})
                Dim Cname As ReportParameter = New ReportParameter("Cname", txtCname.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {Cname})
                Dim Cpos As ReportParameter = New ReportParameter("Cpos", txtCpos.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {Cpos})
            ElseIf Rtype = "Summary Report" Then
                Dim IRA As ReportParameter = New ReportParameter("IRA", txtIRA.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {IRA})
                Dim MDF As ReportParameter = New ReportParameter("MDF", txtMDF.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {MDF})
                Dim Percent As ReportParameter = New ReportParameter("Percent", txtPercent.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {Percent})
                Dim pname As ReportParameter = New ReportParameter("Pname", txtPname.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {pname})
                Dim ppos As ReportParameter = New ReportParameter("Ppos", txtPpos.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {ppos})
                Dim Cname As ReportParameter = New ReportParameter("Cname", txtCname.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {Cname})
                Dim Cpos As ReportParameter = New ReportParameter("Cpos", txtCpos.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {Cpos})
                Dim Nname As ReportParameter = New ReportParameter("Nname", txtNname.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {Nname})
                Dim Npos As ReportParameter = New ReportParameter("Npos", txtNpos.Text)
                rv.LocalReport.SetParameters(New ReportParameter() {Npos})
            Else
            End If
            rv.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            rv.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
            rv.ZoomPercent = 100
            rv.RefreshReport()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtPname.Clear()
        txtPpos.Clear()
        txtCname.Clear()
        txtCpos.Clear()
        txtNname.Clear()
        txtNpos.Clear()
        txtPname.Focus()
    End Sub
End Class