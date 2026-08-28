using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualBasic.Devices;

namespace HRMIS_Solano
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "tu89geji340t89u2";

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public static string Encrypt(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        void Save()
        {
            try
            {
                if (txtPassword.Text != "" && txtServer.Text != "" && txtUsername.Text != "")
                {
                    //Connection string settings
                    Computer c = new Computer();
                    string path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\ConfigurationHRMIS.exe";
                    StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create));
                    sw.Write(Encrypt("server=" + txtServer.Text + ";uid=" + txtUsername.Text + ";password=" + txtPassword.Text + ";database=dbhrmiss;", "H@CK3R"));
                    sw.Close();
                    //Backup Settings
                    path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\BRConfigurationHRMIS.exe";
                    sw = new StreamWriter(path);
                    sw.WriteLine(Encrypt(txtUsername.Text, "H@CK3R"));
                    sw.WriteLine(Encrypt(txtPassword.Text, "H@CK3R"));
                    sw.WriteLine(Encrypt(txtServer.Text, "H@CK3R"));
                    sw.WriteLine(Encrypt("dbhrmiss", "H@CK3R"));
                    sw.Close();
                    MessageBox.Show("Successfully set configuration", "Configuration Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please fill - up all information", "Configuration Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtServer.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtServer.Focus();
        }
    }
}
