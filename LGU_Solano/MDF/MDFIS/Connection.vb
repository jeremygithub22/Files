'Import Libraries
Imports System.IO
Imports Microsoft.VisualBasic.Devices
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Public Class Connection

    'Declare Connection
    Private DES As New TripleDESCryptoServiceProvider
    Private MD5 As New MD5CryptoServiceProvider
    Public cnstr As MySqlConnection

    Public Sub SetConstr()
        Dim c As Computer = New Computer()
        Dim path As String = c.FileSystem.SpecialDirectories.ProgramFiles + "\MDFIS Config\ConfigurationMDFIS.exe"
        Dim sr As StreamReader = New StreamReader(path)
        Dim constr As String = sr.ReadLine()
        sr.Close()
        constr = Decrypt(constr, "H@CK1Ng")
        cnstr = New MySqlConnection(constr)
    End Sub
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

End Class
