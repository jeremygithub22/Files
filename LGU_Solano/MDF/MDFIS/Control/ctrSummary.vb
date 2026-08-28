'Imports Libraries
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class ctrSummary

    'Declare Variables, Connection and Functions

    Dim conn As Connection = New Connection
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim dr As DataRow
    Dim SQL As String
    Public Sub AddSum(ByVal mSum As mSummary)
        Try
            conn.SetConstr()
            If mSum.getAmount <> "" And mSum.getBalance <> "" And mSum.getExpenditure <> "" And mSum.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "INSERT INTO tblsummary(Amount,Expenditure,Balance,No) VALUES(@Amount,@Expenditure,@Balance,@No)"
                da = New MySqlDataAdapter
                da.InsertCommand = New MySqlCommand(SQL, conn.cnstr)
                da.InsertCommand.Parameters.Add("@Amount", MySqlDbType.Double).Value = mSum.getAmount
                da.InsertCommand.Parameters.Add("@Expenditure", MySqlDbType.Double).Value = mSum.getExpenditure
                da.InsertCommand.Parameters.Add("@Balance", MySqlDbType.Double).Value = mSum.getBalance
                da.InsertCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = mSum.getNo
                conn.cnstr.Open()
                da.InsertCommand.ExecuteNonQuery()
                conn.cnstr.Close()
                MsgBox("Successfully add new record.", MsgBoxStyle.Information, "Summary")
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Sub UpdateSum(ByVal mSum As mSummary)
        Try
            conn.SetConstr()
            If mSum.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "UPDATE tblsummary SET Amount=@Amount,Expenditure=@Expenditure,Balance=@Balance WHERE No=@No"
                da = New MySqlDataAdapter
                da.UpdateCommand = New MySqlCommand(SQL, conn.cnstr)
                da.UpdateCommand.Parameters.Add("@Amount", MySqlDbType.Double).Value = mSum.getAmount
                da.UpdateCommand.Parameters.Add("@Expenditure", MySqlDbType.Double).Value = mSum.getExpenditure
                da.UpdateCommand.Parameters.Add("@Balance", MySqlDbType.Double).Value = mSum.getBalance
                da.UpdateCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = mSum.getNo
                conn.cnstr.Open()
                da.UpdateCommand.ExecuteNonQuery()
                conn.cnstr.Close()
                MsgBox("Successfully update record.", MsgBoxStyle.Information, "Summary")
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub
    'Summary Report (Year)
    Public Sub GenReport(ByVal dsRep As dsReport, ByVal Year As String, ByVal frmR As frmSummaryReport)
        Try
            conn.SetConstr()
            SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',A.Amount,A.Expenditure,A.Balance,B.Year FROM tblsummary A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year ORDER BY (B.AIPRF +0)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dsRep.tblsummary.Clear()
            da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
            da.Fill(dsRep.tblsummary)
            If dsRep.tblsummary.Rows.Count <> 0 Then

                'Total
                SQL = "SELECT SUM(A.Amount) AS 'Appropriation',SUM(A.Amount) AS 'Allotment',SUM(A.Expenditure) AS 'Obligation',SUM(A.Balance) AS 'Unobligated' FROM tblsummary A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year GROUP BY B.YEAR"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dsRep.tblTotal.Clear()
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.Fill(dsRep.tblTotal)

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
    'SAAOB Report (Year)
    Public Sub GenReport(ByVal dsRep As dsReport, ByVal Year As String, ByVal frmR As frmSAAOB)
        Try
            conn.SetConstr()
            SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',A.Amount,A.Expenditure,A.Balance,B.Year FROM tblsummary A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year ORDER BY (B.AIPRF +0)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dsRep.tblsummary.Clear()
            da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
            da.Fill(dsRep.tblsummary)
            If dsRep.tblsummary.Rows.Count <> 0 Then

                'Total
                SQL = "SELECT SUM(A.Amount) AS 'Appropriation',SUM(A.Amount) AS 'Allotment',SUM(A.Expenditure) AS 'Obligation',SUM(A.Balance) AS 'Unobligated' FROM tblsummary A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year GROUP BY B.YEAR"
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

    'Summary Report (PPA and Year)
    Public Sub GenReport(ByVal dsRep As dsReport, ByVal Year As String, ByVal PPA As String, ByVal frmR As frmSummaryReport)
        Try
            conn.SetConstr()
            SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',A.Amount,A.Expenditure,A.Balance,B.Year FROM tblsummary A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year AND B.PPA LIKE CONCAT('%',@PPADesc,'%')  ORDER BY (B.AIPRF +0)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dsRep.tblsummary.Clear()
            da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
            da.SelectCommand.Parameters.Add("@PPADesc", MySqlDbType.VarChar).Value = PPA
            da.Fill(dsRep.tblsummary)
            If dsRep.tblsummary.Rows.Count <> 0 Then

                'Total
                SQL = "SELECT SUM(A.Amount) AS 'Appropriation',SUM(A.Amount) AS 'Allotment',SUM(A.Expenditure) AS 'Obligation',SUM(A.Balance) AS 'Unobligated' FROM tblsummary A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year AND B.PPA LIKE CONCAT('%',@PPADesc,'%') GROUP BY B.Year ORDER BY (B.AIPRF +0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dsRep.tblTotal.Clear()
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.SelectCommand.Parameters.Add("@PPADesc", MySqlDbType.VarChar).Value = PPA
                da.Fill(dsRep.tblTotal)

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
            SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',A.Amount,A.Expenditure,A.Balance,B.Year FROM tblsummary A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year AND B.PPA LIKE CONCAT('%',@PPADesc,'%')  ORDER BY (B.AIPRF +0)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dsRep.tblsummary.Clear()
            da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
            da.SelectCommand.Parameters.Add("@PPADesc", MySqlDbType.VarChar).Value = PPA
            da.Fill(dsRep.tblsummary)
            If dsRep.tblsummary.Rows.Count <> 0 Then

                'Total
                SQL = "SELECT SUM(A.Amount) AS 'Appropriation',SUM(A.Amount) AS 'Allotment',SUM(A.Expenditure) AS 'Obligation',SUM(A.Balance) AS 'Unobligated' FROM tblsummary A LEFT JOIN tblppa B ON A.No=B.NO  WHERE B.Year=@Year AND B.PPA LIKE CONCAT('%',@PPADesc,'%') GROUP BY B.Year ORDER BY (B.AIPRF +0)"
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

    Public Sub Getbal(ByVal mSum As mSummary)
        Try
            conn.SetConstr()
            conn.cnstr.Close()
            SQL = "SELECT * FROM tblsummary WHERE No=@No"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dt = New DataTable
            da.SelectCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = mSum.getNo
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                mSum.setBalance(dr("Balance").ToString())
                mSum.setExpenditure(dr("Expenditure").ToString())
                mSum.setAmount(dr("Amount").ToString())
            Else
                mSum.setBalance(String.Empty)
                mSum.setExpenditure(String.Empty)
                mSum.setAmount(String.Empty)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
