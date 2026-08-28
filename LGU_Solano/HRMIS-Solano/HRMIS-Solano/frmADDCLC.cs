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
    public partial class frmADDCLC : Form
    {
        public frmADDCLC()
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
                txtPname.Text = sr.ReadLine();
                txtPpos.Text = sr.ReadLine();
                txtNname.Text = sr.ReadLine();
                txtNpos.Text = sr.ReadLine();
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
                ReportParameter Suffix = new ReportParameter("Suffix", txtSuffix.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Suffix });
                ReportParameter Pname = new ReportParameter("Pname", txtPname.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Pname });
                ReportParameter Ppos = new ReportParameter("Ppos", txtPpos.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Ppos });
                ReportParameter Nname = new ReportParameter("Nname", txtNname.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Nname });
                ReportParameter Npos = new ReportParameter("Npos", txtNpos.Text);
                rv.LocalReport.SetParameters(new ReportParameter[] { Npos });

                rv.SetDisplayMode(DisplayMode.PrintLayout);
                rv.ZoomMode = ZoomMode.Percent;
                rv.ZoomPercent = 100;
                rv.RefreshReport();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAsof.Clear();
            txtNname.Clear();
            txtNpos.Clear();
            txtPname.Clear();
            txtPpos.Clear();
            txtSuffix.Clear();
            txtAsof.Focus();
        }

        private void frmADDCLC_Load(object sender, EventArgs e)
        {
            LoadSet();
        }
    }
}
