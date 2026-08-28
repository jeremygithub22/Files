'Imports Library
Imports System.IO
Imports Microsoft.VisualBasic.Devices
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmMaintenance

    'Declare variables and Functions
    Dim c As Computer = New Computer()
    Dim path As String
    Dim sr As StreamReader
    Dim Server As String
    Dim Db As String
    Dim paswd As String
    Dim user As String
    Private DES As New TripleDESCryptoServiceProvider
    Private MD5 As New MD5CryptoServiceProvider

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

    Private Sub Backup()
        If sfdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim conn As MySqlConnection = New MySqlConnection("server=" + Server + ";uid=" + user + ";password=" + paswd + ";database=" + Db + ";")
                conn.Open()
                Try

                    Dim DateF As String = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + _
                       "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString()
                    Dim file As StreamWriter = New StreamWriter(sfdBackup.FileName + " " + DateF + ".sql")

                    pBR.StartInfo.FileName = String.Format("C:\Program Files\MySQL\MySQL Server 5.0\bin\mysqldump.exe")
                    pBR.StartInfo.RedirectStandardInput = False
                    pBR.StartInfo.RedirectStandardOutput = True
                    pBR.StartInfo.Arguments = String.Format("-u{0} -p{1} -h{2} {3}", _
                       user, paswd, Server, Db)
                    pBR.StartInfo.UseShellExecute = False
                    pBR.StartInfo.CreateNoWindow = True
                    pBR.Start()
                    Dim output As String = "CREATE DATABASE IF NOT EXISTS dbmdf; USE dbmdf;" + pBR.StandardOutput.ReadToEnd()
                    file.WriteLine(output)
                    pBR.WaitForExit()
                    file.Close()
                    pBR.Close()

                    MsgBox("Successfully backup database!", MsgBoxStyle.Information, "Maintenance")
                Catch
                    MsgBox("Error , unable to backup!", MsgBoxStyle.Critical, "Maintenance")
                End Try
            Catch
                MsgBox("Error , unable to backup!", MsgBoxStyle.Critical, "Maintenance")
            End Try
        End If
    End Sub


    Private Sub Restore()
        Try
            Dim conn As MySqlConnection = New MySqlConnection("server=" + Server + ";uid=" + user + ";password=" + paswd + ";")
            conn.Open()
            Try
                'Read file from path
                Dim file As StreamReader = New StreamReader(ofdRestore.FileName)
                Dim input As String = file.ReadToEnd()
                file.Close()

                ' restore tables
                pBR.StartInfo.FileName = String.Format("C:\Program Files\MySQL\MySQL Server 5.0\bin\mysql.exe")
                pBR.StartInfo.RedirectStandardInput = True
                pBR.StartInfo.RedirectStandardOutput = False
                pBR.StartInfo.Arguments = String.Format("-u{0} -p{1} -h{2}", _
                     user, paswd, Server)
                pBR.StartInfo.UseShellExecute = False
                pBR.StartInfo.CreateNoWindow = True
                pBR.Start()
                pBR.StandardInput.WriteLine(input)
                pBR.StandardInput.Close()
                pBR.WaitForExit()
                pBR.Close()

                MsgBox("Successfully restore database!", MsgBoxStyle.Information, "Maintenance")
                btnRestore.Enabled = False
                btnBrowse.Enabled = True
            Catch

                MsgBox("Error , unable to Restore!", MsgBoxStyle.Critical, "Maintenance")
            End Try
        Catch
            MsgBox("Server not found", MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub
    Private Sub frmMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            path = c.FileSystem.SpecialDirectories.ProgramFiles + "\MDFIS Config\BRConfigurationMDFIS.exe"
            sr = New StreamReader(path)
            user = Decrypt(sr.ReadLine(), "H@CK1Ng")
            paswd = Decrypt(sr.ReadLine(), "H@CK1Ng")
            Server = Decrypt(sr.ReadLine(), "H@CK1Ng")
            Db = Decrypt(sr.ReadLine(), "H@CK1Ng")

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
        Backup()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If ofdRestore.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPath.Text = ofdRestore.FileName
            btnBrowse.Enabled = False
            btnRestore.Enabled = True
        End If
    End Sub

    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        Restore()
    End Sub
End Class