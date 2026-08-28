'Imports Libraries
Imports MySql.Data.MySqlClient
Public Class ctrUserLog

    'Declare Variables, Connection and Functions

    Dim conn As Connection = New Connection
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim dr As DataRow
    Dim SQL As String

    Public Sub Add(ByVal Mul As mUserLog)
        Try
            conn.SetConstr()
            If Mul.getUID <> "" And Mul.getActivity <> "" Then
                conn.cnstr.Close()
                SQL = "INSERT INTO tbluserlogs(UID,Activity,DateandTime)VALUES(@UID,@Activity,@DateandTime)"
                da = New MySqlDataAdapter
                da.InsertCommand = New MySqlCommand(SQL, conn.cnstr)
                da.InsertCommand.Parameters.Add("@UID", MySqlDbType.VarChar).Value = Mul.getUID
                da.InsertCommand.Parameters.Add("@Activity", MySqlDbType.VarChar).Value = Mul.getActivity
                da.InsertCommand.Parameters.Add("@DateandTime", MySqlDbType.DateTime).Value = Mul.getDateandTime
                conn.cnstr.Open()
                da.InsertCommand.ExecuteNonQuery()
                conn.cnstr.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Search(ByVal Mul As mUserLog)
        Try
            conn.SetConstr()
            conn.cnstr.Close()
            SQL = "SELECT CONCAT(B.Lastname,', ',B.Firstname,' ',B.Middlename)AS NAME,A.Activity AS 'ACTIVITY',A.DateandTime AS 'DATE AND TIME'  FROM tbluserlogs A INNER JOIN tbluser B ON A.UID=B.UID WHERE DATE(A.DateandTime)=DATE(@DATE)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dt = New DataTable
            da.SelectCommand.Parameters.Add("@DATE", MySqlDbType.Date).Value = Mul.getDateandTime
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                Mul.setData(dt)
            Else
                MsgBox("No system transaction found.", MsgBoxStyle.Critical, "User Logs")
                dt.Clear()
                Mul.setData(dt)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
