using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace HRMIS_Solano
{
    public partial class frmOIAdmin : Form
    {
        public frmOIAdmin()
        {
            InitializeComponent();
        }
        Computer c = new Computer();
        static string PName;
        static string PPos;
        static string CName;
        static string CPos;
        static string NName;
        static string NPos;
        static string path;
        void Save()
        {
            try
            {
                //Settings
                path = string.Empty;
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\OIS";
                StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create));
                sw.Write(txtPname.Text + "\n" + txtPpos.Text + "\n" + txtCname.Text + "\n" + txtCpos.Text + "\n" + txtNname.Text + "\n" + txtNpos.Text);
                sw.Close();
                MessageBox.Show("Successfully set other information settings", "Other Information Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }
        void LoadSet()
        {
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\OIS";
                StreamReader sr = new StreamReader(path);
                PName = sr.ReadLine();
                PPos = sr.ReadLine();
                CName = sr.ReadLine();
                CPos = sr.ReadLine();
                NName = sr.ReadLine();
                NPos = sr.ReadLine();
                sr.Close();
                //Display
                txtPname.Text = PName;
                txtPpos.Text = PPos;
                txtCname.Text = CName;
                txtCpos.Text = CPos;
                txtNname.Text = NName;
                txtNpos.Text = NPos;
            }
            catch
            {
                txtPname.Clear();
                txtPpos.Clear();
                txtNname.Clear();
                txtNpos.Clear();
                txtCname.Clear();
                txtCpos.Clear();
                txtPname.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPname.Clear();
            txtPpos.Clear();
            txtNname.Clear();
            txtNpos.Clear();
            txtCname.Clear();
            txtCpos.Clear();
            txtPname.Focus();
        }

        private void frmOIAdmin_Load(object sender, EventArgs e)
        {
            LoadSet();
        }
    }
}
