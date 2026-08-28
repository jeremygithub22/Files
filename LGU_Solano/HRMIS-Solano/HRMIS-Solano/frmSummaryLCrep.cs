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
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace HRMIS_Solano
{
    public partial class frmSummaryLCrep : Form
    {
        public frmSummaryLCrep()
        {
            InitializeComponent();
        }
        string SQL, path, pName, pPos, cName, cPos, nName, nPos;
        Computer c = new Computer();
        MySqlDataAdapter da;
        Connection conn = new Connection();
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
                nName = sr.ReadLine();
                nPos = sr.ReadLine();
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
                conn.SetConstr();
                SQL = "select concat(a.Surname,', ',a.Firstname,' ',a.Middlename)as Name,c.Position,lc.Vbal,lc.SBal,lc.Total " + "from (SELECT * FROM tblleavecredits where DateRec>=@DFrom and DateRec<=@DTo order by LCIDNo desc) lc left join tblpi a on lc.EmpID=a.EmpID " + "left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc," + "month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where c.`To`='Present' " + "group by lc.EmpID " + "order by concat(a.Surname,', ',a.Firstname,' ',a.Middlename) asc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblSumLC.Clear();
                da.SelectCommand.Parameters.Add("@DFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.Fill(dsReports.tblSumLC);
                Connection.Conn.Close();
                if (dsReports.tblSumLC.Rows.Count != 0)
                {
                    LoadSet();
                    ReportParameter range = new ReportParameter("Daterange", dtpFrom.Value.ToShortDateString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range });
                    ReportParameter range2 = new ReportParameter("Daterange2", dtpTo.Value.ToShortDateString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range2 });

                    ReportParameter prepn = new ReportParameter("Pname", pName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                    ReportParameter prepp = new ReportParameter("Ppos", pPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                    ReportParameter certn = new ReportParameter("Cname", cName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                    ReportParameter certp = new ReportParameter("Cpos", cPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

                    ReportParameter notedn = new ReportParameter("Nname", nName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notedn });
                    ReportParameter notedp = new ReportParameter("Npos", nPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notedp });
                    
                    rvDisplay.SetDisplayMode(DisplayMode.PrintLayout);
                    rvDisplay.ZoomMode = ZoomMode.Percent;
                    rvDisplay.ZoomPercent = 100;
                    rvDisplay.RefreshReport();
                }
                else
                {
                    rvDisplay.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tblSumLC.Rows.Count != 0)
            {
                frmAddSumLC.rv = rvDisplay;
                frmAddSumLC aslc = new frmAddSumLC();
                aslc.ShowDialog();
            }
        }
    }
}
