'Imports library
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic.Devices

Public Class frmConfigurationSettings

    Private DES As New TripleDESCryptoServiceProvider
    Private MD5 As New MD5CryptoServiceProvider

    Public Function MD5Hash(ByVal value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function

    Public Function Encrypt(ByVal stringToEncrypt As String, ByVal key As String) As String

        DES.Key = MD5Hash(key)
        DES.Mode = CipherMode.ECB
        Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
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

    Private Sub Save()
        Try

            If txtServerName.Text <> "" And txtUsername.Text <> "" And txtPassword.Text <> "" Then
                'Connection string settings
                Dim c As Computer = New Computer
                Dim path As String = c.FileSystem.SpecialDirectories.ProgramFiles + "\MDFIS Config\ConfigurationMDFIS.exe"
                Dim sw As StreamWriter = New StreamWriter(New FileStream(path, FileMode.Create))
                sw.Write(Encrypt("server=" + txtServerName.Text + ";uid=" + txtUsername.Text + ";password=" + txtPassword.Text + ";database=dbmdf;", "H@CK1Ng"))
                sw.Close()
                'Backup Settings
                path = c.FileSystem.SpecialDirectories.ProgramFiles + "\MDFIS Config\BRConfigurationMDFIS.exe"
                sw = New StreamWriter(path)
                sw.WriteLine(Encrypt(txtUsername.Text, "H@CK1Ng"))
                sw.WriteLine(Encrypt(txtPassword.Text, "H@CK1Ng"))
                sw.WriteLine(Encrypt(txtServerName.Text, "H@CK1Ng"))
                sw.WriteLine(Encrypt("dbhrmiss", "H@CK1Ng"))
                sw.Close()
                MsgBox("Successfully set configuration", MsgBoxStyle.Information, "Configuration Settings")
                Me.Hide()
            Else
                MsgBox("Please fill - up all information", MsgBoxStyle.Critical, "Configuration Settings")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Save()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtServerName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtServerName.Focus()
    End Sub

    Private Sub frmConfigurationSettings_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Hide()
    End Sub
End Class