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
    public partial class frmAOIL : Form
    {
        public frmAOIL()
        {
            InitializeComponent();
        }
        Computer c = new Computer();
        string path;
        public ReportViewer rv;
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
        void LoadData()
        {
            try
            {
                ReportParameter Asof = new ReportParameter("Asof", txtAsof.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Asof });
                ReportParameter Pname = new ReportParameter("Pname", txtPname.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Pname });
                ReportParameter Ppos = new ReportParameter("Ppos", txtPpos.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Ppos });
                ReportParameter Cname = new ReportParameter("Cname", txtCname.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Cname });
                ReportParameter Cpos = new ReportParameter("Cpos", txtCpos.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Cpos });
                ReportParameter Approved = new ReportParameter("Approved", txtApproved.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Approved });
                ReportParameter Disapproved = new ReportParameter("Disapprov", txtDisapproved.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Disapproved });

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPname.Clear();
            txtPpos.Clear();
            txtCname.Clear();
            txtCpos.Clear();
            txtApproved.Clear();
            txtDisapproved.Clear();
            txtPname.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
            LoadData();
        }

        private void frmAOIL_Load(object sender, EventArgs e)
        {
            LoadSet();
        }
    }
}
