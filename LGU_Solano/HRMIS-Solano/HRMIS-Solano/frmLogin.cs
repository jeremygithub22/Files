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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "tu89geji340t89u2";

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;
        string SQL;
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();
        Computer c = new Computer();
        frmConfiguration config = new frmConfiguration();
        static string path;
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
        void Check()
        {
            //Check Configuration if exist
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\BRConfigurationHRMIS.exe";
                sr = new StreamReader(path);
                user = Decrypt(sr.ReadLine(), "H@CK3R");
                paswd = Decrypt(sr.ReadLine(), "H@CK3R");
                Server = Decrypt(sr.ReadLine(), "H@CK3R");
                Db = Decrypt(sr.ReadLine(), "H@CK3R");
                sr.Close();
                //check Server
                try
                {
                    MySqlConnection sqlconn = new MySqlConnection("server=" + Server + ";uid=" + user + ";password=" + paswd + ";");
                    sqlconn.Open();
                    sqlconn.Close();

                    //check database
                    try
                    {
                        sqlconn = new MySqlConnection("server=" + Server + ";uid=" + user + ";password=" + paswd + ";database=" + Db + ";");
                        sqlconn.Open();
                        sqlconn.Close();

                        Login();
                    }
                    catch
                    {
                        try
                        {
                            StreamReader file = new StreamReader(@"C:\Program Files\HRMIS Config\DBHRMISS.sql");
                            string input = file.ReadToEnd();
                            file.Close();

                            //restore tables
                            pRestore.StartInfo.FileName = string.Format(@"C:\Program Files\MySQL\MySQL Server 5.0\bin\mysql.exe");
                            pRestore.StartInfo.RedirectStandardInput = true;
                            pRestore.StartInfo.RedirectStandardOutput = false;
                            pRestore.StartInfo.Arguments = string.Format(@"-u{0} -p{1} -h{2}",
                                user, paswd, Server);
                            pRestore.StartInfo.UseShellExecute = false;
                            pRestore.StartInfo.CreateNoWindow = true;
                            pRestore.Start();
                            pRestore.StandardInput.WriteLine(input);
                            pRestore.StandardInput.Close();
                            pRestore.WaitForExit();
                            pRestore.Close();

                            Login();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Server not found", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    config.Show();
                }
            }
            catch
            {
                MessageBox.Show("Configuration Settings not set", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                config.Show();
            }
        }
        void Login()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tbluser where username=@username and password=md5(@password)";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUsername.Text;
                da.SelectCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtPassword.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    frmMain main = new frmMain();
                    DataRow dr = dt.Rows[0];
                    UserDetails.UID = dr["UID"].ToString();
                    UserDetails.Username = dr["Username"].ToString();
                    UserDetails.Firstname = dr["Firstname"].ToString();

                    //Privilege

                    if (dr["PI"].ToString() == "Allow")
                    {
                        main.personalInformationToolStripMenuItem.Visible = true;
                    }
                    if (dr["LS"].ToString() == "Allow")
                    {
                        main.locatorSlipToolStripMenuItem.Visible = true;
                    }
                    if (dr["LR"].ToString() == "Allow")
                    {
                        main.leaveRecordToolStripMenuItem.Visible = true;
                    }
                    if (dr["LC"].ToString() == "Allow")
                    {
                        main.leaveCreditsToolStripMenuItem.Visible = true;
                    }
                    if (dr["TU"].ToString() == "Allow")
                    {
                        main.tardinessUndertimeToolStripMenuItem.Visible = true;
                    }
                    if (dr["SR"].ToString() == "Allow")
                    {
                        main.serviceRecordToolStripMenuItem.Visible = true;
                    }
                    if (dr["FC"].ToString() == "Allow")
                    {
                        main.flagCeremonyToolStripMenuItem.Visible = true;
                    }
                    if (dr["FR"].ToString() == "Allow")
                    {
                        main.flagRetreatToolStripMenuItem.Visible = true;
                    }
                    if (dr["WLS"].ToString() == "Allow")
                    {
                        main.withoutLocatorSlipToolStripMenuItem.Visible = true;
                    }
                    if (dr["R"].ToString() == "Allow")
                    {
                        main.reportsToolStripMenuItem.Visible = true;
                    }
                    if (dr["Usertype"].ToString() == "Administrator")
                    {
                        main.administrationToolStripMenuItem.Visible = true;
                    }

                    //Actions per privilege
                    UserDetails.APPI = dr["APPI"].ToString();
                    UserDetails.EPPI = dr["EPPI"].ToString(); 
                    UserDetails.DPPI = dr["DPPI"].ToString(); 
                    UserDetails.APLS = dr["APLS"].ToString(); 
                    UserDetails.EPLS = dr["EPLS"].ToString(); 
                    UserDetails.DPLS = dr["DPLS"].ToString(); 
                    UserDetails.APLC = dr["APLC"].ToString(); 
                    UserDetails.EPLC = dr["EPLC"].ToString(); 
                    UserDetails.DPLC = dr["DPLC"].ToString(); 
                    UserDetails.APLR = dr["APLR"].ToString(); 
                    UserDetails.EPLR = dr["EPLR"].ToString(); 
                    UserDetails.DPLR = dr["DPLR"].ToString(); 
                    UserDetails.APSR = dr["APSR"].ToString();
                    UserDetails.EPSR = dr["EPSR"].ToString(); 
                    UserDetails.DPSR = dr["DPSR"].ToString(); 
                    UserDetails.APTU = dr["APTU"].ToString(); 
                    UserDetails.EPTU = dr["EPTU"].ToString(); 
                    UserDetails.DPTU = dr["DPTU"].ToString(); 
                    UserDetails.APFC = dr["APFC"].ToString(); 
                    UserDetails.EPFC = dr["EPFC"].ToString(); 
                    UserDetails.DPFC = dr["DPFC"].ToString(); 
                    UserDetails.APFR = dr["APFR"].ToString();
                    UserDetails.EPFR = dr["EPFR"].ToString(); 
                    UserDetails.DPFR = dr["DPFR"].ToString(); 
                    UserDetails.APWLS = dr["APWLS"].ToString();
                    UserDetails.EPWLS = dr["EPWLS"].ToString(); 
                    UserDetails.DPWLS = dr["DPWLS"].ToString();
                    
                    frmUserLogs ul = new frmUserLogs();
                    ul.Record(UserDetails.UID, "Successfully Login", DateTime.Now);
                    main.lblFN.Text = UserDetails.Firstname;
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username/password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
