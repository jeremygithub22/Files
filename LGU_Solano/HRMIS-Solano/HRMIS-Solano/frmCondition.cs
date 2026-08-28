using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace HRMIS_Solano
{
    public partial class frmCondition : Form
    {
        public frmCondition()
        {
            InitializeComponent();
        }
        Computer c = new Computer();
        static string Time;
        static string No;
        static string path;
        void Save()
        {
            try
            {
                //Settings
                path = string.Empty;
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\CS";
                StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create));
                sw.Write(txtNo.Text + "\n" + dtpTime.Value.ToShortTimeString());
                sw.Close();
                MessageBox.Show("Successfully set condition settings", "Condition Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }
        void LoadCS()
        {
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\CS";
                StreamReader sr = new StreamReader(path);
                No = sr.ReadLine();
                Time = sr.ReadLine();
                sr.Close();
                //Display
                txtNo.Text = No;
                dtpTime.Text = Time;
            }
            catch
            {
                txtNo.Clear();
                dtpTime.Value = DateTime.Now;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmCondition_Load(object sender, EventArgs e)
        {
            LoadCS();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNo.Clear();
            dtpTime.Value = DateTime.Now;
        }
    }
}
