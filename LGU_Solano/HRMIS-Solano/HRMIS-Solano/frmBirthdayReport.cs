using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace HRMIS_Solano
{
    public partial class frmBirthdayReport : Form
    {
        public frmBirthdayReport()
        {
            InitializeComponent();
        }
        string SQL, pName, pPos, cName, cPos, path;
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
                if (cboSearchby.Text == "Date")
                {
                    SQL = "select concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))as Name,b.Position,b.Department,Day(a.Dbirth) as 'Day' from tblpi a inner join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where we.`To`='Present' group by EmpID) b on a.EmpID=b.EmpID where Month(a.Dbirth)=Month(@Dbirth) and Day(a.Dbirth)=Day(@Dbirth)  order by Day(a.Dbirth),concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblBirthday.Clear();
                    da.SelectCommand.Parameters.Add("@Dbirth", MySqlDbType.DateTime).Value = dtpDate.Value;
                    da.Fill(dsReports.tblBirthday);
                    Connection.Conn.Close();
                    if (dsReports.tblBirthday.Rows.Count != 0)
                    {
                        LoadSet();

                        ReportParameter DM = new ReportParameter("Asof", dtpDate.Value.Month.ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { DM });

                        ReportParameter prepn = new ReportParameter("Pname", pName);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                        ReportParameter prepp = new ReportParameter("Ppos", pPos);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                        ReportParameter certn = new ReportParameter("Cname", cName);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                        ReportParameter certp = new ReportParameter("Cpos", cPos);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

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
                else if (cboSearchby.Text == "Month")
                {
                    SQL = "select concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))as Name,b.Position,b.Department,Day(a.Dbirth) as 'Day' from tblpi a inner join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where we.`To`='Present' group by EmpID) b on a.EmpID=b.EmpID where Month(a.Dbirth)=Month(@Dbirth) order by Day(a.Dbirth),concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblBirthday.Clear();
                    da.SelectCommand.Parameters.Add("@Dbirth", MySqlDbType.DateTime).Value = dtpDate.Value;
                    da.Fill(dsReports.tblBirthday);
                    Connection.Conn.Close();
                    if (dsReports.tblBirthday.Rows.Count != 0)
                    {
                        LoadSet();

                        ReportParameter DM = new ReportParameter("Asof", dtpDate.Value.Month.ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { DM });

                        ReportParameter prepn = new ReportParameter("Pname", pName);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                        ReportParameter prepp = new ReportParameter("Ppos", pPos);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                        ReportParameter certn = new ReportParameter("Cname", cName);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                        ReportParameter certp = new ReportParameter("Cpos", cPos);
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

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
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpDate.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tblBirthday.Rows.Count != 0)
            {
                frmAddME.rv = rvDisplay;
                frmAddME me = new frmAddME();
                me.ShowDialog();
            }
        }
    }
}
