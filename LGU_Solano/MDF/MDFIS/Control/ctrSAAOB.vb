'Imports Libraries
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class ctrSAAOB
    'Declare Variables, Connection and Functions

    Dim conn As Connection = New Connection
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim dr As DataRow
    Dim SQL As String
    Public Sub AddSum(ByVal mSum As mSAAOB)
        Try
            conn.SetConstr()
            If mSum.getAppropriation <> "" And mSum.getObligation <> "" And mSum.getUnobligatedAllotment <> "" And mSum.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "INSERT INTO tblsaaob(Appropriation,Obligation,UnobligatedAllotment,No) VALUES(@Appropriation,@Obligation,@UnobligatedAllotment,@No)"
                da = New MySqlDataAdapter
                da.InsertCommand = New MySqlCommand(SQL, conn.cnstr)
                da.InsertCommand.Parameters.Add("@Appropriation", MySqlDbType.Double).Value = mSum.getAppropriation
                da.InsertCommand.Parameters.Add("@Obligation", MySqlDbType.Double).Value = mSum.getObligation
                da.InsertCommand.Parameters.Add("@UnobligatedAllotment", MySqlDbType.Double).Value = mSum.getUnobligatedAllotment
                da.InsertCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = mSum.getNo
                conn.cnstr.Open()
                da.InsertCommand.ExecuteNonQuery()
                conn.cnstr.Close()
                MsgBox("Successfully add new record.", MsgBoxStyle.Information, "SAAOB")
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Sub UpdateSum(ByVal mSum As mSAAOB)
        Try
            conn.SetConstr()
            If mSum.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "UPDATE tblsaaob SET Appropriation=@Appropriation,Obligation=@Obligation,UnobligatedAllotment=@UnobligatedAllotment WHERE No=@No"
                da = New MySqlDataAdapter
                da.UpdateCommand = New MySqlCommand(SQL, conn.cnstr)
                da.UpdateCommand.Parameters.Add("@Appropriation", MySqlDbType.Double).Value = mSum.getAppropriation
                da.UpdateCommand.Parameters.Add("@Obligation", MySqlDbType.Double).Value = mSum.getObligation
                da.UpdateCommand.Parameters.Add("@UnobligatedAllotment", MySqlDbType.Double).Value = mSum.getUnobligatedAllotment
                da.UpdateCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = mSum.getNo
                conn.cnstr.Open()
                da.UpdateCommand.ExecuteNonQuery()
                conn.cnstr.Close()
                MsgBox("Successfully update record.", MsgBoxStyle.Information, "SAAOB")
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub
    'SAAOB Report (Year)
    Public Sub GenReport(ByVal dsRep As dsReport, ByVal Year As String, ByVal frmR As frmSAAOB)
        Try
            conn.SetConstr()
            SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',A.Appropriation AS 'Amount',A.Obligation AS 'Expenditure',A.UnobligatedAllotment AS 'Balance',B.Year FROM tblsaaob A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year ORDER BY (B.AIPRF +0)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dsRep.tblsummary.Clear()
            da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
            da.Fill(dsRep.tblsummary)
            If dsRep.tblsummary.Rows.Count <> 0 Then

                'Total
                SQL = "SELECT SUM(A.Appropriation) AS 'Appropriation',SUM(A.Appropriation) AS 'Allotment',SUM(A.Obligation) AS 'Obligation',SUM(A.UnobligatedAllotment) AS 'Unobligated' FROM tblsaaob A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year GROUP BY B.YEAR"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dsRep.tblTotal.Clear()
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.Fill(dsRep.tblTotal)

                Dim CY As ReportParameter = New ReportParameter("Year", Year)
                frmR.rvDisplay.LocalReport.SetParameters(New ReportParameter() {CY})
                frmR.rvDisplay.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                frmR.rvDisplay.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
                frmR.rvDisplay.ZoomPercent = 100
                frmR.rvDisplay.RefreshReport()
            Else
                frmR.rvDisplay.Clear()
                MsgBox("Record not found.", MsgBoxStyle.Critical, "Summary Report")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    'SAAOB report (PPA and Year)
    Public Sub GenReport(ByVal dsRep As dsReport, ByVal Year As String, ByVal PPA As String, ByVal frmR As frmSAAOB)
        Try
            conn.SetConstr()
            SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',A.Appropriation AS 'Amount',A.Obligation AS 'Expenditure',A.UnobligatedAllotment AS 'Balance',B.Year FROM tblsaaob A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year AND B.PPA LIKE CONCAT('%',@PPADesc,'%')  ORDER BY (B.AIPRF +0)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dsRep.tblsummary.Clear()
            da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
            da.SelectCommand.Parameters.Add("@PPADesc", MySqlDbType.VarChar).Value = PPA
            da.Fill(dsRep.tblsummary)
            If dsRep.tblsummary.Rows.Count <> 0 Then

                'Total
                SQL = "SELECT SUM(A.Appropriation) AS 'Appropriation',SUM(A.Appropriation) AS 'Allotment',SUM(A.Obligation) AS 'Obligation',SUM(A.UnobligatedAllotment) AS 'Unobligated' FROM tblsaaob A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year AND B.PPA LIKE CONCAT('%',@PPADesc,'%') GROUP BY B.Year ORDER BY (B.AIPRF +0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dsRep.tblTotal.Clear()
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.SelectCommand.Parameters.Add("@PPADesc", MySqlDbType.VarChar).Value = PPA
                da.Fill(dsRep.tblTotal)

                Dim CY As ReportParameter = New ReportParameter("Year", Year)
                frmR.rvDisplay.LocalReport.SetParameters(New ReportParameter() {CY})
                frmR.rvDisplay.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                frmR.rvDisplay.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
                frmR.rvDisplay.ZoomPercent = 100
                frmR.rvDisplay.RefreshReport()
            Else
                frmR.rvDisplay.Clear()
                MsgBox("Record not found.", MsgBoxStyle.Critical, "Summary Report")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Sub Getbal(ByVal mSum As mSAAOB)
        Try
            conn.SetConstr()
            conn.cnstr.Close()
            SQL = "SELECT * FROM tblsaaob WHERE No=@No"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dt = New DataTable
            da.SelectCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = mSum.getNo
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                mSum.setUnobligatedAllotment(dr("UnobligatedAllotment").ToString())
                mSum.setObligation(dr("Obligation").ToString())
                mSum.setAppropriation(dr("Appropriation").ToString())
            Else
                mSum.setUnobligatedAllotment(String.Empty)
                mSum.setObligation(String.Empty)
                mSum.setAppropriation(String.Empty)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
