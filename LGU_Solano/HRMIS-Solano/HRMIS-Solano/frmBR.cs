using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.VisualBasic.Devices;
using System.Security.Cryptography;

namespace HRMIS_Solano
{
    public partial class frmBR : Form
    {
        public frmBR()
        {
            InitializeComponent();
        }
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "tu89geji340t89u2";

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;
        Computer c = new Computer();
        string path;
        StreamReader sr;
        static string Server;
        static string Db;
        static string paswd;
        static string user;
        public static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
        void Backup()
        {
            if (sfdBackup.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection("server=" + Server + ";uid=" + user + ";password=" + paswd + ";database=" + Db + ";");
                    conn.Open();
                    try
                    {
                        string date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() +
                            "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
                        StreamWriter file = new StreamWriter(sfdBackup.FileName + " " + date + ".sql");
                        pBR.StartInfo.FileName = string.Format(@"C:\Program Files\MySQL\MySQL Server 5.0\bin\mysqldump.exe");
                        pBR.StartInfo.RedirectStandardInput = false;
                        pBR.StartInfo.RedirectStandardOutput = true;
                        pBR.StartInfo.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                            user, paswd, Server, Db);
                        pBR.StartInfo.UseShellExecute = false;
                        pBR.StartInfo.CreateNoWindow = true;
                        pBR.Start();
                        string output = "CREATE DATABASE IF NOT EXISTS dbhrmiss; USE dbhrmiss;" + pBR.StandardOutput.ReadToEnd();
                        file.WriteLine(output);
                        pBR.WaitForExit();
                        file.Close();
                        pBR.Close();
                        MessageBox.Show("Successfully backup database!", "Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error , unable to backup!", "Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Error , unable to backup!", "Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void Restore()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=" + Server + ";uid=" + user + ";password=" + paswd + ";");
                conn.Open();
                try
                {
                    //Read file from path
                    StreamReader file = new StreamReader(ofdRestore.FileName);
                    string input = file.ReadToEnd();
                    file.Close();

                    //restore tables
                    pBR.StartInfo.FileName = string.Format(@"C:\Program Files\MySQL\MySQL Server 5.0\bin\mysql.exe");
                    pBR.StartInfo.RedirectStandardInput = true;
                    pBR.StartInfo.RedirectStandardOutput = false;
                    pBR.StartInfo.Arguments = string.Format(@"-u{0} -p{1} -h{2}",
                        user, paswd, Server);
                    pBR.StartInfo.UseShellExecute = false;
                    pBR.StartInfo.CreateNoWindow = true;
                    pBR.Start();
                    pBR.StandardInput.WriteLine(input);
                    pBR.StandardInput.Close();
                    pBR.WaitForExit();
                    pBR.Close();
                    MessageBox.Show("Successfully restore database!", "Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRestore.Enabled = false;
                    btnBrowse.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Error , unable to Restore!", "Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Server not found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBR_Load(object sender, EventArgs e)
        {
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\BRConfigurationHRMIS.exe";
                sr = new StreamReader(path);
                user = Decrypt(sr.ReadLine(), "H@CK3R");
                paswd = Decrypt(sr.ReadLine(), "H@CK3R");
                Server = Decrypt(sr.ReadLine(), "H@CK3R");
                Db = Decrypt(sr.ReadLine(), "H@CK3R");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdRestore.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdRestore.FileName;
                btnBrowse.Enabled = false;
                btnRestore.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Restore();
        }

    }
}
