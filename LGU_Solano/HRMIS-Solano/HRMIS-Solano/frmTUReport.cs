using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace HRMIS_Solano
{
    public partial class frmTUReport : Form
    {
        public frmTUReport()
        {
            InitializeComponent();
        }
        string SQL, pName, pPos, cName, cPos, path, NoEx;
        Computer c = new Computer();
        MySqlDataAdapter da;
        Connection conn = new Connection();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        void LoadCS()
        {
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\CS";
                StreamReader sr = new StreamReader(path);
                NoEx = sr.ReadLine();
                sr.Close();
            }
            catch
            {
            }
        }
        void LoadSet()
        {
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\OIS";
                StreamReader sr = new StreamReader(path);
                pName = sr.ReadLine();
                pPos = sr.ReadLine();
                cName = sr.ReadLine();
                cPos = sr.ReadLine();
                sr.Close();
            }
            catch
            {
            }
        }
        void Search()
        {
            try
            {
                if (cboType.Text != "")
                {
                    conn.SetConstr();
                    SQL = "select concat(b.Surname,', ',b.Firstname,' ',b.Middlename)as Name,a.DateIncurred,a.Frequency,a.Mins,a.ConversionDays,a.Remarks from tbldeduct a left join tblpi b on a.EmpID=b.EmpID where a.DateIncurred>=@DateIncurredFrom and a.DateIncurred<=@DateIncurredTo and Type=@Type order by concat(b.Surname,', ',b.Firstname,' ',b.Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tbldeduct.Clear();
                    da.SelectCommand.Parameters.Add("@DateIncurredFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateIncurredTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@Type", MySqlDbType.VarChar).Value = cboType.Text;
                    da.Fill(dsReports.tbldeduct);
                    Connection.Conn.Close();
                    if (dsReports.tbldeduct.Count != 0)
                    {
                        LoadSet();
                        LoadCS();
                        ReportParameter range = new ReportParameter("Daterange", dtpFrom.Value.ToShortDateString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range });
                        ReportParameter range2 = new ReportParameter("Daterange2", dtpTo.Value.ToShortDateString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range2 });
                        ReportParameter type = new ReportParameter("Type", cboType.Text);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { type });

                        ReportParameter prepn = new ReportParameter("Pname", pName);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                        ReportParameter prepp = new ReportParameter("Ppos", pPos);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                        ReportParameter certn = new ReportParameter("Cname", cName);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                        ReportParameter certp = new ReportParameter("Cpos", cPos);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

                        ReportParameter NoL = new ReportParameter("Limit", NoEx);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { NoL });

                        rvDisplay.SetDisplayMode(DisplayMode.PrintLayout);
                        rvDisplay.ZoomMode = ZoomMode.Percent;
                        rvDisplay.ZoomPercent = 100;
                        rvDisplay.RefreshReport();
                    }
                }
                else
                {
                    MessageBox.Show("Please specify type of report", "Tardiness/Undertime Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tbldeduct.Count != 0)
            {
                frmAddDTU dtu = new frmAddDTU();
                frmAddDTU.rv = rvDisplay;
                dtu.ShowDialog();
            }
        }
    }
}
