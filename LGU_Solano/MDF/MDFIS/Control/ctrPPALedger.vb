'Imports Libraries
Imports MySql.Data.MySqlClient
Public Class ctrPPALedger

    'Declare Variables, Connection and Functions

    Dim conn As Connection = New Connection
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim dr As DataRow
    Dim SQL As String

    Public Sub AddL(ByVal Mppal As mPPALedger)
        Try
            conn.SetConstr()
            If Mppal.getCredit <> "" And Mppal.getDateReceived <> "" And Mppal.getDebit <> "" And Mppal.getNo <> "" And Mppal.getParticulars <> "" And Mppal.getRunningBal <> "" And Mppal.getPayee <> "" And Mppal.getProjectName <> "" And Mppal.getLocation <> "" And Mppal.getRemarks <> "" And Mppal.getCtrNo <> "" Then
                conn.cnstr.Close()
                SQL = "INSERT INTO tblppaledger(No,DateReceived,Particulars,Debit,Credit,RunningBal,Payee,ProjectName,Location,Remarks,CtrNo)VALUES(@No,@DateReceived,@Particulars,@Debit,@Credit,@RunningBal,@FundingYear,@Payee,@ProjectName,@Location,@Remarks,@CtrNo)"
                da = New MySqlDataAdapter
                da.InsertCommand = New MySqlCommand(SQL, conn.cnstr)
                da.InsertCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mppal.getNo
                da.InsertCommand.Parameters.Add("@DateReceived", MySqlDbType.VarChar).Value = Mppal.getDateReceived
                da.InsertCommand.Parameters.Add("@Particulars", MySqlDbType.VarChar).Value = Mppal.getParticulars
                da.InsertCommand.Parameters.Add("@Debit", MySqlDbType.VarChar).Value = Mppal.getDebit
                da.InsertCommand.Parameters.Add("@Credit", MySqlDbType.VarChar).Value = Mppal.getCredit
                da.InsertCommand.Parameters.Add("@RunningBal", MySqlDbType.VarChar).Value = Mppal.getRunningBal
                da.InsertCommand.Parameters.Add("@Payee", MySqlDbType.VarChar).Value = Mppal.getPayee
                da.InsertCommand.Parameters.Add("@ProjectName", MySqlDbType.VarChar).Value = Mppal.getProjectName
                da.InsertCommand.Parameters.Add("@Location", MySqlDbType.VarChar).Value = Mppal.getLocation
                da.InsertCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = Mppal.getRemarks
                da.InsertCommand.Parameters.Add("@CtrNo", MySqlDbType.VarChar).Value = Mppal.getCtrNo

                conn.cnstr.Open()
                da.InsertCommand.ExecuteNonQuery()
                conn.cnstr.Close()
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message (PPA Ledger)")
        End Try
    End Sub

    Public Function AddL(ByVal Mppal As mPPALedger, ByVal S As Boolean)
        Try
            conn.SetConstr()
            If S <> True And Mppal.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "INSERT INTO tblppaledger(No,DateReceived,Particulars,Debit,Credit,RunningBal,Payee,ProjectName,Location,Remarks,CtrNo,GSO,Status)VALUES(@No,@DateReceived,@Particulars,@Debit,@Credit,@RunningBal,@Payee,@ProjectName,@Location,@Remarks,@CtrNo,@GSO,@Status)"
                da = New MySqlDataAdapter
                da.InsertCommand = New MySqlCommand(SQL, conn.cnstr)
                da.InsertCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mppal.getNo
                da.InsertCommand.Parameters.Add("@DateReceived", MySqlDbType.VarChar).Value = Mppal.getDateReceived
                da.InsertCommand.Parameters.Add("@Particulars", MySqlDbType.VarChar).Value = Mppal.getParticulars
                da.InsertCommand.Parameters.Add("@Debit", MySqlDbType.VarChar).Value = Mppal.getDebit
                da.InsertCommand.Parameters.Add("@Credit", MySqlDbType.VarChar).Value = Mppal.getCredit
                da.InsertCommand.Parameters.Add("@RunningBal", MySqlDbType.VarChar).Value = Mppal.getRunningBal
                da.InsertCommand.Parameters.Add("@Payee", MySqlDbType.VarChar).Value = Mppal.getPayee
                da.InsertCommand.Parameters.Add("@ProjectName", MySqlDbType.VarChar).Value = Mppal.getProjectName
                da.InsertCommand.Parameters.Add("@Location", MySqlDbType.VarChar).Value = Mppal.getLocation
                da.InsertCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = Mppal.getRemarks
                da.InsertCommand.Parameters.Add("@CtrNo", MySqlDbType.VarChar).Value = Mppal.getCtrNo
                da.InsertCommand.Parameters.Add("@GSO", MySqlDbType.VarChar).Value = Mppal.getGSO
                da.InsertCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = Mppal.getBStatus

                conn.cnstr.Open()
                da.InsertCommand.ExecuteNonQuery()
                conn.cnstr.Close()
                MsgBox("Successfully Add transaction.", MsgBoxStyle.Information, "PPA Ledger")
                S = True
            Else
                S = False
                MsgBox("Nothing to transact.", MsgBoxStyle.Critical, "PPA Ledger")
            End If
        Catch ex As Exception
            S = False
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message (PPA Ledger)")
        End Try
        Return S
    End Function

    Public Function UpdateL(ByVal Mppal As mPPALedger, ByVal S As Boolean)
        Try
            conn.SetConstr()
            If Mppal.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "UPDATE tblppaledger set No=@No,DateReceived=@DateReceived,Particulars=@Particulars,Payee=@Payee,ProjectName=@ProjectName,Location=@Location,Remarks=@Remarks,CtrNo=@CtrNo WHERE LPPAID=@LPPAID"
                da = New MySqlDataAdapter
                da.UpdateCommand = New MySqlCommand(SQL, conn.cnstr)
                da.UpdateCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mppal.getNo
                da.UpdateCommand.Parameters.Add("@DateReceived", MySqlDbType.VarChar).Value = Mppal.getDateReceived
                da.UpdateCommand.Parameters.Add("@Particulars", MySqlDbType.VarChar).Value = Mppal.getParticulars
                da.UpdateCommand.Parameters.Add("@Payee", MySqlDbType.VarChar).Value = Mppal.getPayee
                da.UpdateCommand.Parameters.Add("@ProjectName", MySqlDbType.VarChar).Value = Mppal.getProjectName
                da.UpdateCommand.Parameters.Add("@Location", MySqlDbType.VarChar).Value = Mppal.getLocation
                da.UpdateCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = Mppal.getRemarks
                da.UpdateCommand.Parameters.Add("@CtrNo", MySqlDbType.VarChar).Value = Mppal.getCtrNo
                da.UpdateCommand.Parameters.Add("@LPPAID", MySqlDbType.VarChar).Value = Mppal.getLPPAID

                conn.cnstr.Open()
                da.UpdateCommand.ExecuteNonQuery()
                conn.cnstr.Close()

                MsgBox("Successfully Update transaction.", MsgBoxStyle.Information, "PPA Ledger")
                S = True
            Else
                S = False
                MsgBox("Nothing to update.", MsgBoxStyle.Critical, "PPA Ledger")
            End If
        Catch ex As Exception
            S = False
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message (PPA Ledger)")
        End Try
        Return S
    End Function

    Public Sub Search(ByVal Mppanew As mPPAFundingInfo)
        Try
            conn.SetConstr()
            If Mppanew.getPPA <> "" And Mppanew.getYear <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa WHERE PPA LIKE CONCAT('%',@PPA,'%') AND Year=@Year ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@PPA", MySqlDbType.VarChar).Value = Mppanew.getPPA
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Mppanew.getYear
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mppanew.setData(dt)
                    Mppanew.setStatus(True)
                Else
                    dt.Clear()
                    Mppanew.setData(dt)
                    Mppanew.setStatus(False)
                End If
            ElseIf Mppanew.getYear <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa WHERE Year=@Year ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Mppanew.getYear
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mppanew.setData(dt)
                    Mppanew.setStatus(True)
                Else
                    dt.Clear()
                    Mppanew.setData(dt)
                    Mppanew.setStatus(False)
                End If
            ElseIf Mppanew.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa WHERE No=@No ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mppanew.getNo
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mppanew.setData(dt)
                    Mppanew.setStatus(True)
                Else
                    dt.Clear()
                    Mppanew.setData(dt)
                    Mppanew.setStatus(False)
                End If
            ElseIf Mppanew.getDateReceived <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mppanew.setData(dt)
                    Mppanew.setStatus(True)
                Else
                    dt.Clear()
                    Mppanew.setData(dt)
                    Mppanew.setStatus(False)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub
    Public Sub Search(ByVal Ledger As mPPALedger, ByVal Year As String)
        Try
            conn.SetConstr()
            If Ledger.getCtrNo <> "" And Year <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT A.* FROM tblppa A LEFT JOIN tblppaledger B ON A.No=B.No WHERE B.CtrNo=@CtrNo AND YEAR(STR_TO_DATE(B.DateReceived,'%m/%d/%Y'))=@Year ORDER BY (A.AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@CtrNo", MySqlDbType.VarChar).Value = Ledger.getCtrNo
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Ledger.setData(dt)
                Else
                    dt.Clear()
                    Ledger.setData(dt)
                End If
            ElseIf Ledger.getPayee <> "" And Year <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT A.* FROM tblppa A LEFT JOIN tblppaledger B ON A.No=B.No WHERE B.Payee LIKE CONCAT('%',@Payee,'%') AND YEAR(STR_TO_DATE(B.DateReceived,'%m/%d/%Y'))=@Year ORDER BY (A.AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@Payee", MySqlDbType.VarChar).Value = Ledger.getPayee
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Ledger.setData(dt)
                Else
                    dt.Clear()
                    Ledger.setData(dt)
                End If
            ElseIf Ledger.getProjectName <> "" And Year <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT A.* FROM tblppa A LEFT JOIN tblppaledger B ON A.No=B.No WHERE B.ProjectName LIKE CONCAT('%',@ProjectName,'%') AND YEAR(STR_TO_DATE(B.DateReceived,'%m/%d/%Y'))=@Year ORDER BY (A.AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@ProjectName", MySqlDbType.VarChar).Value = Ledger.getProjectName
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Ledger.setData(dt)
                Else
                    dt.Clear()
                    Ledger.setData(dt)
                End If
            ElseIf Ledger.getLocation <> "" And Year <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT A.* FROM tblppa A LEFT JOIN tblppaledger B ON A.No=B.No WHERE B.Location LIKE CONCAT('%',@Location,'%') AND YEAR(STR_TO_DATE(B.DateReceived,'%m/%d/%Y'))=@Year ORDER BY (A.AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@Location", MySqlDbType.VarChar).Value = Ledger.getLocation
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Ledger.setData(dt)
                Else
                    dt.Clear()
                    Ledger.setData(dt)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Function Display(ByVal Mppal As mPPALedger, ByVal S As Boolean)
        Try
            conn.SetConstr()
            conn.cnstr.Close()
            SQL = "SELECT LPPAID AS 'No.',DateReceived AS 'Date Received',CtrNo AS 'Control No.',Payee,Particulars,ProjectName AS 'Project Name',Location,Debit,Credit,RunningBal AS 'Running Balance',Remarks FROM tblppaledger WHERE No=@No"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dt = New DataTable
            da.SelectCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mppal.getNo
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then

                Mppal.setData(dt)
                S = True
            Else
                dt.Clear()
                Mppal.setData(dt)
                S = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
        Return S
    End Function

    Public Sub GetBal(ByVal Mppal As mPPALedger)
        Try
            conn.SetConstr()
            conn.cnstr.Close()
            SQL = "SELECT * FROM tblsummary WHERE No=@No"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dt = New DataTable
            da.SelectCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mppal.getNo
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then

                dr = dt.Rows(0)

                Mppal.setRunningBal(dr("Balance").ToString)

            Else
                Mppal.setRunningBal(String.Empty)
                Mppal.setDebit(String.Empty)
                Mppal.setCredit(String.Empty)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function DisplayPending(ByVal Mppal As mPPALedger, ByVal S As Boolean, ByVal Year As String)
        Try
            conn.SetConstr()

            If Mppal.getCtrNo <> "" And Year <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT A.AIPRF,B.* FROM tblppa A LEFT JOIN tblppaledger B ON A.No=B.No WHERE B.CtrNo=@CtrNo AND YEAR(STR_TO_DATE(A.Year,'%m/%d/%Y'))=@Year AND B.Status='Pending' ORDER BY (A.AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@CtrNo", MySqlDbType.VarChar).Value = Mppal.getCtrNo
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Year
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mppal.setData(dt)
                    S = True
                Else
                    dt.Clear()
                    Mppal.setData(dt)
                    S = False
                End If
            ElseIf Mppal.getBStatus = "All" Then
                conn.cnstr.Close()
                SQL = "SELECT A.*,B.AIPRF FROM tblppaledger A LEFT JOIN tblppa B ON A.No=B.No WHERE A.Status='Pending' ORDER BY (B.AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mppal.setData(dt)
                    S = True
                Else
                    dt.Clear()
                    Mppal.setData(dt)
                    S = False
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
            S = False
        End Try
        Return S
    End Function
    Public Sub DisplayPending(ByVal Mppal As mPPALedger)
        Try
            conn.SetConstr()
            conn.cnstr.Close()
            SQL = "SELECT A.*,B.AIPRF FROM tblppaledger A LEFT JOIN tblppa B ON A.No=B.No WHERE A.LPPAID=@LPPAID ORDER BY (B.AIPRF+0)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            da.SelectCommand.Parameters.Add("@LPPAID", MySqlDbType.VarChar).Value = Mppal.getLPPAID
            dt = New DataTable
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                Mppal.setNo(dr("No").ToString())
                Mppal.setCredit(dr("Credit").ToString())
                Mppal.setCtrNo(dr("CtrNo").ToString())
                Mppal.setDateReceived(dr("DateReceived").ToString())
                Mppal.setDebit(dr("Debit").ToString())
                Mppal.setLocation(dr("Location").ToString())
                Mppal.setParticulars(dr("Particulars").ToString())
                Mppal.setPayee(dr("Payee").ToString())
                Mppal.setProjectName(dr("ProjectName").ToString())
                Mppal.setRemarks(dr("Remarks").ToString())
                Mppal.setRunningBal(dr("RunningBal").ToString())
                Mppal.setLPPAID(dr("LPPAID").ToString())
            Else
                Mppal.setNo(String.Empty)
                Mppal.setCredit(String.Empty)
                Mppal.setCtrNo(String.Empty)
                Mppal.setDateReceived(String.Empty)
                Mppal.setDebit(String.Empty)
                Mppal.setLocation(String.Empty)
                Mppal.setParticulars(String.Empty)
                Mppal.setPayee(String.Empty)
                Mppal.setProjectName(String.Empty)
                Mppal.setRemarks(String.Empty)
                Mppal.setRunningBal(String.Empty)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub
    Public Function Approve(ByVal Mppal As mPPALedger, ByVal S As Boolean)
        Try
            conn.SetConstr()
            If Mppal.getLPPAID <> "" Then
                conn.cnstr.Close()
                SQL = "UPDATE tblppaledger set Status='Approved' WHERE LPPAID=@LPPAID"
                da = New MySqlDataAdapter
                da.UpdateCommand = New MySqlCommand(SQL, conn.cnstr)
                da.UpdateCommand.Parameters.Add("@LPPAID", MySqlDbType.VarChar).Value = Mppal.getLPPAID

                conn.cnstr.Open()
                da.UpdateCommand.ExecuteNonQuery()
                conn.cnstr.Close()

                MsgBox("Successfully Approved transaction.", MsgBoxStyle.Information, "Budget Approval")
                S = True
            Else
                S = False
                MsgBox("Nothing to approve.", MsgBoxStyle.Critical, "Budget Approval")
            End If
        Catch ex As Exception
            S = False
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
        Return S
    End Function

    'Ledger report
    Public Sub GenReport(ByVal dsRep As dsReport, ByVal No As String, ByVal frmR As frmLedger)
        Try
            conn.SetConstr()
            SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',B.Year,A.* FROM tblppaledger A LEFT JOIN tblppa B ON A.No=B.NO  WHERE A.No=@No  ORDER BY (B.AIPRF +0)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dsRep.tblLedger.Clear()
            da.SelectCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = No
            da.Fill(dsRep.tblLedger)
            If dsRep.tblLedger.Rows.Count <> 0 Then

                frmR.rvDisplay.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                frmR.rvDisplay.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
                frmR.rvDisplay.ZoomPercent = 100
                frmR.rvDisplay.RefreshReport()
            Else
                frmR.rvDisplay.Clear()
                MsgBox("Record not found.", MsgBoxStyle.Critical, "Ledger Report")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    'List of Ledger report
    Public Sub GenReport(ByVal dsRep As dsReport, ByVal dtpDate As String, ByVal frmR As frmListLedger, ByVal Transaction As String)
        Try
            conn.SetConstr()
            If Transaction = "Date" Then
                SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',B.Year,A.* FROM tblppaledger A LEFT JOIN tblppa B ON A.No=B.NO  WHERE A.DateReceived=@DateReceived  ORDER BY A.DateReceived"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dsRep.tblLedger.Clear()
                da.SelectCommand.Parameters.Add("@DateReceived", MySqlDbType.VarChar).Value = dtpDate
                da.Fill(dsRep.tblLedger)
            ElseIf Transaction = "Month" Then
                SQL = "SELECT B.AIPRF AS 'AIPRefCod',B.PPA AS 'PPADesc',B.Year,A.* FROM tblppaledger A LEFT JOIN tblppa B ON A.No=B.NO  WHERE MONTH(STR_TO_DATE(A.DateReceived,'%m/%d/%Y'))=MONTH(STR_TO_DATE(@DateReceived,'%m/%d/%Y')) AND YEAR(STR_TO_DATE(A.DateReceived,'%m/%d/%Y'))=YEAR(STR_TO_DATE(@DateReceived,'%m/%d/%Y')) ORDER BY A.DateReceived"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dsRep.tblLedger.Clear()
                da.SelectCommand.Parameters.Add("@DateReceived", MySqlDbType.VarChar).Value = dtpDate
                da.Fill(dsRep.tblLedger)
            Else
            End If

            If dsRep.tblLedger.Rows.Count <> 0 Then

                frmR.rvDisplay.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                frmR.rvDisplay.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
                frmR.rvDisplay.ZoomPercent = 100
                frmR.rvDisplay.RefreshReport()
            Else
                frmR.rvDisplay.Clear()
                MsgBox("Record not found.", MsgBoxStyle.Critical, "Ledger Report")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try

    End Sub
End Class
