using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace HRMIS_Solano
{
    public partial class frmLCrepAI : Form
    {
        public frmLCrepAI()
        {
            InitializeComponent();
        }
        public static ReportViewer rv;
        Computer c = new Computer();
        string path;
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
                sr.Close();
            }
            catch
            {
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
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
                this.Hide();
                rv.SetDisplayMode(DisplayMode.PrintLayout);
                rv.ZoomMode = ZoomMode.Percent;
                rv.ZoomPercent = 100;
                rv.RefreshReport();
            }
            catch
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCname.Clear();
            txtCpos.Clear();
            txtPname.Clear();
            txtPpos.Clear();
            txtPname.Focus();
        }

        private void frmLCrepAI_Load(object sender, EventArgs e)
        {
            LoadSet();
        }

    }
}
