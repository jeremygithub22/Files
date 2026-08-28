'Imports Libraries
Imports MySql.Data.MySqlClient
Public Class ctrPPAFundingInfo

    'Declare Variables, Connection and Functions

    Dim conn As Connection = New Connection
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim dr As DataRow
    Dim SQL As String

    Public Sub AddR(ByVal Mreg As mPPAFundingInfo)
        Try
            If MessageBox.Show("Are you sure, you want to add this record?", "PPA Funding Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If Mreg.getDateReceived <> "" And Mreg.getYear <> "" And Mreg.getBudget <> "" And Mreg.getAIPRC <> "" And Mreg.getPPA <> "" Then
                    conn.SetConstr()
                    conn.cnstr.Close()
                    SQL = "INSERT INTO tblppa(DateReceived,Year,Budget,AIPRF,PPA) VALUES(@DateReceived,@Year,@Budget,@AIPRF,@PPA)"
                    da = New MySqlDataAdapter
                    da.InsertCommand = New MySqlCommand(SQL, conn.cnstr)
                    da.InsertCommand.Parameters.Add("@DateReceived", MySqlDbType.VarChar).Value = Mreg.getDateReceived
                    da.InsertCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Mreg.getYear
                    da.InsertCommand.Parameters.Add("@Budget", MySqlDbType.VarChar).Value = Mreg.getBudget
                    da.InsertCommand.Parameters.Add("@AIPRF", MySqlDbType.VarChar).Value = Mreg.getAIPRC
                    da.InsertCommand.Parameters.Add("@PPA", MySqlDbType.VarChar).Value = Mreg.getPPA
                    conn.cnstr.Open()
                    da.InsertCommand.ExecuteNonQuery()
                    conn.cnstr.Close()
                    Mreg.setStatus(True)
                    MsgBox("Successfully add new record.", MsgBoxStyle.Information, "PPA Funding Information")
                Else
                    Mreg.setStatus(False)
                    MsgBox("Please fill-in all information.", MsgBoxStyle.Critical, "PPA Funding Information")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Sub UpdateR(ByVal Mreg As mPPAFundingInfo)
        Try
            If MessageBox.Show("Are you sure, you want to update this record?", "PPA Funding Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If Mreg.getNo <> "" Then
                    conn.SetConstr()
                    conn.cnstr.Close()
                    SQL = "UPDATE tblppa SET DateReceived=@DateReceived,Year=@Year,Budget=@Budget,AIPRF=@AIPRF,PPA=@PPA WHERE No=@No"
                    da = New MySqlDataAdapter
                    da.UpdateCommand = New MySqlCommand(SQL, conn.cnstr)
                    da.UpdateCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mreg.getNo
                    da.UpdateCommand.Parameters.Add("@DateReceived", MySqlDbType.VarChar).Value = Mreg.getDateReceived
                    da.UpdateCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Mreg.getYear
                    da.UpdateCommand.Parameters.Add("@Budget", MySqlDbType.VarChar).Value = Mreg.getBudget
                    da.UpdateCommand.Parameters.Add("@AIPRF", MySqlDbType.VarChar).Value = Mreg.getAIPRC
                    da.UpdateCommand.Parameters.Add("@PPA", MySqlDbType.VarChar).Value = Mreg.getPPA
                    conn.cnstr.Open()
                    da.UpdateCommand.ExecuteNonQuery()
                    conn.cnstr.Close()
                    Mreg.setStatus(True)
                    MsgBox("Successfully update record.", MsgBoxStyle.Information, "PPA Funding Information")
                Else
                    Mreg.setStatus(False)
                    MsgBox("Please provide the No. and Control No.", MsgBoxStyle.Critical, "PPA Funding Information")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Sub Search(ByVal Mreg As mPPAFundingInfo)
        Try
            conn.SetConstr()
            If Mreg.getPPA <> "" And Mreg.getYear <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa A WHERE PPA LIKE CONCAT('%',@PPA,'%') AND Year=@Year ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@PPA", MySqlDbType.VarChar).Value = Mreg.getPPA
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Mreg.getYear
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mreg.setData(dt)
                    Mreg.setStatus(True)
                Else
                    dt.Clear()
                    Mreg.setData(dt)
                    Mreg.setStatus(False)
                End If
            ElseIf Mreg.getYear <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa WHERE Year=@Year ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Mreg.getYear
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mreg.setData(dt)
                    Mreg.setStatus(True)
                Else
                    dt.Clear()
                    Mreg.setData(dt)
                    Mreg.setStatus(False)
                End If
            ElseIf Mreg.getDateReceived <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mreg.setData(dt)
                    Mreg.setStatus(True)
                Else
                    dt.Clear()
                    Mreg.setData(dt)
                    Mreg.setStatus(False)
                End If
            ElseIf Mreg.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa WHERE No=@No ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mreg.getNo
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Mreg.setData(dt)
                    Mreg.setStatus(True)
                Else
                    dt.Clear()
                    Mreg.setData(dt)
                    Mreg.setStatus(False)
                End If
            Else
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Sub Search(ByVal Mreg As mPPAFundingInfo, ByVal txtNo As TextBox)
        Try
            conn.SetConstr()
            If Mreg.getPPA <> "" And Mreg.getYear <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa A WHERE PPA LIKE CONCAT('%',@PPA,'%') AND Year=@Year ORDER BY (AIPRF+0)"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@PPA", MySqlDbType.VarChar).Value = Mreg.getPPA
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = Mreg.getYear
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    dr = dt.Rows(0)
                    txtNo.Text = dr("No").ToString
                Else
                    txtNo.Text = ""
                End If
            Else
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Sub Display(ByVal Mreg As mPPAFundingInfo)
        Try
            conn.SetConstr()
            If Mreg.getNo <> "" Then
                conn.cnstr.Close()
                SQL = "SELECT * FROM tblppa WHERE No=@No"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@No", MySqlDbType.VarChar).Value = Mreg.getNo
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then

                    dr = dt.Rows(0)

                    Mreg.setNo(dr("No").ToString())
                    Mreg.setDateReceived(dr("DateReceived").ToString())
                    Mreg.setYear(dr("Year").ToString())
                    Mreg.setBudget(dr("Budget").ToString())
                    Mreg.setAIPRC(dr("AIPRF").ToString())
                    Mreg.setPPA(dr("PPA").ToString())

                    'SQL = "SELECT * FROM tblppa WHERE PPAID=@PPAID"
                    'da = New MySqlDataAdapter(SQL, conn.cnstr)
                    'dt = New DataTable
                    'da.SelectCommand.Parameters.Add("@PPAID", MySqlDbType.VarChar).Value = Mreg.getPPAID
                    'da.Fill(dt)

                    'dr = dt.Rows(0)

                    'Mreg.setPPAID(dr("PPA").ToString())

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub
    Public Function Display(ByVal PPA As String)
        Try
            conn.SetConstr()
            conn.cnstr.Close()
            SQL = "SELECT * FROM tblppa WHERE PPAID=@PPAID"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dt = New DataTable
            da.SelectCommand.Parameters.Add("@PPAID", MySqlDbType.VarChar).Value = PPA
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                PPA = dr("PPA").ToString
            Else
                PPA = String.Empty
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
        Return PPA
    End Function
End Class
