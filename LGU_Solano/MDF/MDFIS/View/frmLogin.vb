'Imports Library
Imports System.IO
Imports Microsoft.VisualBasic.Devices
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmLogin

    'Declare object class and variables

    Private DES As New TripleDESCryptoServiceProvider
    Private MD5 As New MD5CryptoServiceProvider
    Dim objCUA As ctrUserAccount = New ctrUserAccount
    Dim objMUA As mUserAccount = New mUserAccount
    Dim objCul As ctrUserLog = New ctrUserLog
    Dim objMul As mUserLog = New mUserLog
    Dim SQL As String
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim conn As Connection = New Connection
    Dim c As Computer = New Computer
    Dim config As frmConfigurationSettings = New frmConfigurationSettings
    Dim path As String
    Dim sr As StreamReader
    Dim Server As String
    Dim Db As String
    Dim paswd As String
    Dim user As String
    Dim cond As Boolean

    Public Function MD5Hash(ByVal value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function

    Public Function Decrypt(ByVal encryptedString As String, ByVal key As String) As String
        Dim value As String = ""
        Try

            DES.Key = MD5Hash(key)
            DES.Mode = CipherMode.ECB
            Dim Buffer As Byte() = Convert.FromBase64String(encryptedString)
            value = ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            MessageBox.Show("Invalid Key", "Decryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return value
    End Function

    Private Sub Check()
        'Check Configuration if exist
        Try

            path = c.FileSystem.SpecialDirectories.ProgramFiles + "\MDFIS Config\BRConfigurationMDFIS.exe"
            sr = New StreamReader(path)
            user = Decrypt(sr.ReadLine(), "H@CK1Ng")
            paswd = Decrypt(sr.ReadLine(), "H@CK1Ng")
            Server = Decrypt(sr.ReadLine(), "H@CK1Ng")
            Db = Decrypt(sr.ReadLine(), "H@CK1Ng")
            sr.Close()
            'check Server
            Try
                Dim sqlconn As MySqlConnection = New MySqlConnection("server=" + Server + ";uid=" + user + ";password=" + paswd + ";")
                sqlconn.Open()
                sqlconn.Close()
                'check database
                Try
                    conn.SetConstr()
                    conn.cnstr.Open()
                    conn.cnstr.Close()
                    Login()
                Catch
                    Try
                        Dim file As StreamReader = New StreamReader("C:\Program Files\MDFIS Config\DBMDF.sql")
                        Dim input As String = file.ReadToEnd
                        file.Close()
                        'restore tables
                        pRestore.StartInfo.FileName = String.Format("C:\Program Files\MySQL\MySQL Server 5.0\bin\mysql.exe")
                        pRestore.StartInfo.RedirectStandardInput = True
                        pRestore.StartInfo.RedirectStandardOutput = False
                        pRestore.StartInfo.Arguments = String.Format("-u{0} -p{1} -h{2}", _
                        user, paswd, Server)
                        pRestore.StartInfo.UseShellExecute = False
                        pRestore.StartInfo.CreateNoWindow = True
                        pRestore.Start()
                        pRestore.StandardInput.WriteLine(input)
                        pRestore.StandardInput.Close()
                        pRestore.WaitForExit()
                        pRestore.Close()
                        Login()
                    Catch ex As Exception
                        MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Error Message")
                        End
                    End Try
                End Try
            Catch
                MsgBox("Server not found", MsgBoxStyle.Critical, "Login")
                config.Show()
            End Try
        Catch
            MsgBox("Configuration Settings not set", MsgBoxStyle.Critical, "Login")
            config.Show()
        End Try
    End Sub

    Private Sub Login()
        Try
            objMUA.setUsername(txtUsername.Text)
            objMUA.setPassword(txtPassword.Text)
            If objCUA.Login(objMUA, False) = True Then

                'Record to User Log
                objMul.setUID(objMUA.getUID())
                objMul.setActivity("Successfully Log in")
                objMul.setDateandTime(DateTime.Now)
                objCul.Add(objMul)

                Dim main As frmMainWindow = New frmMainWindow
                main.lblUser.Text = objMUA.getUsername
                Me.Hide()
                main.ShowDialog()
            Else
                MsgBox("Invalid Username/Password", MsgBoxStyle.Critical, "Login")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Check()
    End Sub

    Private Sub txtUsername_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub frmLogin_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class
