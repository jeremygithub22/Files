'Import Libraries

Imports MySql.Data.MySqlClient
Public Class ctrUserAccount

    'Declare Variables, Connection and Functions

    Dim conn As Connection = New Connection
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim dr As DataRow
    Dim SQL As String


    Public Function AddUA(ByVal mUA As mUserAccount, ByVal S As Boolean)
        Try
            conn.SetConstr()
            If mUA.getLastname <> "" And mUA.getFirstname <> "" And mUA.getMiddlename <> "" And mUA.getUsername <> "" And mUA.getPassword <> "" And mUA.getUType <> "" Then

                SQL = "SELECT * FROM tbluser WHERE Username=@Username"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = mUA.getUsername
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    SQL = "INSERT INTO tbluser(Lastname,Firstname,Middlename,Username,Password,Type,Office) VALUES(@Lastname,@Firstname,@Middlename,@Username,MD5(@Password),@Type,@Office)"
                    da = New MySqlDataAdapter()
                    da.InsertCommand = New MySqlCommand(SQL, conn.cnstr)
                    da.InsertCommand.Parameters.Add("@Lastname", MySqlDbType.VarChar).Value = mUA.getLastname
                    da.InsertCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = mUA.getFirstname
                    da.InsertCommand.Parameters.Add("@Middlename", MySqlDbType.VarChar).Value = mUA.getMiddlename
                    da.InsertCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = mUA.getUsername
                    da.InsertCommand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = mUA.getPassword
                    da.InsertCommand.Parameters.Add("@Type", MySqlDbType.VarChar).Value = mUA.getUType
                    da.InsertCommand.Parameters.Add("@Office", MySqlDbType.VarChar).Value = mUA.getOffice
                    conn.cnstr.Open()
                    da.InsertCommand.ExecuteNonQuery()
                    conn.cnstr.Close()
                    MsgBox("Successfully add user account.", MsgBoxStyle.Information, "User Accounts")
                    S = True
                Else
                    S = False
                    MsgBox("Please choose another user name. User name Exist!", MsgBoxStyle.Critical, "User Accounts")
                End If
            Else
                S = False
                MsgBox("Please fill - in all fields.", MsgBoxStyle.Critical, "User Accounts")
            End If
        Catch ex As Exception
            S = False
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Error Message")

        End Try

        Return S

    End Function

    Public Function UpdateUA(ByVal mUA As mUserAccount, ByVal S As Boolean)
        Try
            conn.SetConstr()
            If mUA.getUsername <> "" Then
                SQL = "UPDATE tbluser SET Lastname=@Lastname,Firstname=@Firstname,Middlename=@Middlename,Password=MD5(@Password),Type=@Type,Office=@Office WHERE Username=@Username"
                da = New MySqlDataAdapter()
                da.UpdateCommand = New MySqlCommand(SQL, conn.cnstr)
                da.UpdateCommand.Parameters.Add("@Lastname", MySqlDbType.VarChar).Value = mUA.getLastname
                da.UpdateCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = mUA.getFirstname
                da.UpdateCommand.Parameters.Add("@Middlename", MySqlDbType.VarChar).Value = mUA.getMiddlename
                da.UpdateCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = mUA.getUsername
                da.UpdateCommand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = mUA.getPassword
                da.UpdateCommand.Parameters.Add("@Type", MySqlDbType.VarChar).Value = mUA.getUType
                da.UpdateCommand.Parameters.Add("@Office", MySqlDbType.VarChar).Value = mUA.getOffice
                conn.cnstr.Open()
                da.UpdateCommand.ExecuteNonQuery()
                conn.cnstr.Close()
                MsgBox("Successfully update user account.", MsgBoxStyle.Information, "User Accounts")
                S = True
            Else
                S = False
                MsgBox("Nothing to update. Please provide username.", MsgBoxStyle.Critical, "User Accounts")
            End If
        Catch ex As Exception
            S = False
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Error Message")

        End Try

        Return S

    End Function

    Public Function DeleteUA(ByVal mUA As mUserAccount, ByVal S As Boolean)
        Try
            conn.SetConstr()
            If mUA.getUsername <> "" Then
                SQL = "DELETE FROM tbluser WHERE Username=@Username"
                da = New MySqlDataAdapter
                da.DeleteCommand = New MySqlCommand(SQL, conn.cnstr)
                da.DeleteCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = mUA.getUsername
                conn.cnstr.Open()
                da.DeleteCommand.ExecuteNonQuery()
                conn.cnstr.Close()
                MsgBox("Successfully delete user account.", MsgBoxStyle.Information, "User Accounts")
                S = True
            Else
                S = False
                MsgBox("Nothing to delete. Please provide user name.", MsgBoxStyle.Critical, "User Accounts")
            End If
        Catch ex As Exception
            S = False
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Error Message")

        End Try

        Return S

    End Function

    Public Sub Search(ByVal mUA As mUserAccount)
        Try
            conn.SetConstr()
            If mUA.getUsername <> String.Empty Then

                SQL = "SELECT *,CONCAT(Lastname,', ',Firstname,' ',Middlename)as Name FROM tbluser WHERE Username=@Username"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = mUA.getUsername
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    mUA.setData(dt)
                Else
                    MsgBox("User does not exist.", MsgBoxStyle.Critical, "User Accounts")
                    dt.Clear()
                    mUA.setData(dt)
                End If
            End If
            If mUA.getFirstname <> String.Empty Then

                SQL = "SELECT *,CONCAT(Lastname,', ',Firstname,' ',Middlename)as Name FROM tbluser WHERE Firstname=@Firstname"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = mUA.getFirstname
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    mUA.setData(dt)
                Else
                    MsgBox("User does not exist.", MsgBoxStyle.Critical, "User Accounts")
                    dt.Clear()
                    mUA.setData(dt)
                End If
            End If
            If mUA.getLastname <> String.Empty Then

                SQL = "SELECT *,CONCAT(Lastname,', ',Firstname,' ',Middlename)as Name FROM tbluser WHERE Lastname=@Lastname"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("Lastname", MySqlDbType.VarChar).Value = mUA.getLastname
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    mUA.setData(dt)
                Else
                    MsgBox("User does not exist.", MsgBoxStyle.Critical, "User Accounts")
                    dt.Clear()
                    mUA.setData(dt)
                End If
            End If
            If mUA.getUType = "All" Then
                SQL = "SELECT *,CONCAT(Lastname,', ',Firstname,' ',Middlename)as Name FROM tbluser"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    mUA.setData(dt)
                Else
                    MsgBox("User does not exist.", MsgBoxStyle.Critical, "User Accounts")
                    dt.Clear()
                    mUA.setData(dt)
                End If
            End If

        Catch ex As Exception

            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Error Message")

        End Try
    End Sub

    Public Function Login(ByVal mUA As mUserAccount, ByVal R As Boolean)
        Try
            conn.SetConstr()
            SQL = "SELECT * FROM tbluser WHERE Username=@Username AND Password=MD5(@Password)"
            da = New MySqlDataAdapter(SQL, conn.cnstr)
            dt = New DataTable
            da.SelectCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = mUA.getUsername
            da.SelectCommand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = mUA.getPassword
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                R = True
                mUA.setUsername(dr("Username").ToString)
                mUA.setUID(dr("UID").ToString())
            Else
                R = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
        Return R
    End Function
    Public Sub Display(ByVal mUA As mUserAccount)
        Try
            conn.SetConstr()
            If mUA.getUsername <> "" Then

                SQL = "SELECT * FROM tbluser WHERE Username=@Searchfor"
                da = New MySqlDataAdapter(SQL, conn.cnstr)
                dt = New DataTable
                da.SelectCommand.Parameters.Add("@Searchfor", MySqlDbType.VarChar).Value = mUA.getUsername
                da.Fill(dt)
                If dt.Rows.Count <> 0 Then

                    dr = dt.Rows(0)

                    mUA.setFirstname(dr("Firstname").ToString())
                    mUA.setLastname(dr("Lastname").ToString())
                    mUA.setMiddlename(dr("Middlename").ToString())
                    mUA.setPassword(dr("Password").ToString())
                    mUA.setType(dr("Type").ToString())
                    mUA.setUsername(dr("Username").ToString())
                    mUA.setUID(dr("UID").ToString())
                    mUA.setOffice(dr("Office").ToString())
                Else

                    mUA.setFirstname(String.Empty)
                    mUA.setLastname(String.Empty)
                    mUA.setMiddlename(String.Empty)
                    mUA.setPassword(String.Empty)
                    mUA.setType(String.Empty)
                    mUA.setUsername(String.Empty)
                    mUA.setUID(String.Empty)
                    mUA.setOffice(String.Empty)
                End If

            End If

        Catch ex As Exception

            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Error Message")

        End Try
    End Sub
End Class
