using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace HRMIS_Solano
{
    public partial class frmAddFC : Form
    {
        public frmAddFC()
        {
            InitializeComponent();
        }
        string path;
        Computer c = new Computer();
        public static ReportViewer rv;

        void LoadSet()
        {
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\OIS";
                StreamReader sr = new StreamReader(path);
                txtPname.Text = sr.ReadLine();
                txtPpos.Text = sr.ReadLine();
                txtCname.Text = sr.ReadLine();
                txtCpos.Text = sr.ReadLine();
                txtNname.Text = sr.ReadLine();
                txtNpos.Text = sr.ReadLine();
                sr.Close();
            }
            catch
            {
            }
        }
        void RefreshD()
        {
            try
            {
                ReportParameter Pname = new ReportParameter("Pname", txtPname.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Pname });
                ReportParameter Ppos = new ReportParameter("Ppos", txtPpos.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Ppos });
                ReportParameter Cname = new ReportParameter("Cname", txtCname.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Cname });
                ReportParameter Cpos = new ReportParameter("Cpos", txtCpos.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Cpos });
                ReportParameter Nname = new ReportParameter("Nname", txtNname.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Nname });
                ReportParameter Npos = new ReportParameter("Npos", txtNpos.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Npos });
                rv.SetDisplayMode(DisplayMode.PrintLayout);
                rv.ZoomMode = ZoomMode.Percent;
                rv.ZoomPercent = 100;
                rv.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            RefreshD();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPname.Clear();
            txtPpos.Clear();
            txtCname.Clear();
            txtCpos.Clear();
            txtNname.Clear();
            txtNpos.Clear();
            txtPname.Focus();
        }

        private void frmAddFC_Load(object sender, EventArgs e)
        {
            LoadSet();
        }
    }
}
