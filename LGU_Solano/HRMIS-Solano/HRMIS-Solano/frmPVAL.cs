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
    public partial class frmPVAL : Form
    {
        public frmPVAL()
        {
            InitializeComponent();
        }
        public static string RecNo;
        string SQL, pName, pPos, cName, cPos, path;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        Computer c = new Computer();
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
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblleaverecord where RecNo=@RecNo";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblleaverecord.Clear();
                da.SelectCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = RecNo;
                da.Fill(dsReports.tblleaverecord);
                Connection.Conn.Close();
                if (dsReports.tblleaverecord.Rows.Count != 0)
                {
                    LoadSet();
                    DataRow dr = dsReports.tblleaverecord.Rows[0];
                    SQL = "select * from tblpi where EmpID=@EmpID";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblpi.Clear();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = dr["EmpID"].ToString();
                    da.Fill(dsReports.tblpi);
                    Connection.Conn.Close();
                    SQL = "select * from tblwe where EmpID=@EmpID";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblwe.Clear();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = dr["EmpID"].ToString();
                    da.Fill(dsReports.tblwe);
                    Connection.Conn.Close();
                    SQL = "select * from tblleavecredits where RecNo=@RecNo";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblleavecredits.Clear();
                    da.SelectCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = dr["RecNo"].ToString();
                    da.Fill(dsReports.tblleavecredits);
                    Connection.Conn.Close();

                    if (dr["SPL"].ToString() == "XXX")
                    {
                        ReportParameter SPL = new ReportParameter("SPL", dr["SPL"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { SPL });
                    }
                    else if (dr["Bday"].ToString() == "XXX")
                    {
                        ReportParameter Bday = new ReportParameter("SPL", dr["Bday"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Bday });
                    }
                    else if (dr["Enrollment"].ToString() == "XXX")
                    {
                        ReportParameter Enrollment = new ReportParameter("SPL", dr["Enrollment"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Enrollment });
                    }
                    else if (dr["Anniversary"].ToString() == "XXX")
                    {
                        ReportParameter Anniversary = new ReportParameter("SPL", dr["Anniversary"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Anniversary });
                    }
                    else if (dr["Mourning"].ToString() == "XXX")
                    {
                        ReportParameter Mourning = new ReportParameter("SPL", dr["Mourning"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Mourning });
                    }
                    else if (dr["Solo"].ToString() == "XXX")
                    {
                        ReportParameter Solo = new ReportParameter("SPL", dr["Solo"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Solo });
                    }
                    else
                    {
                        ReportParameter Nodata = new ReportParameter("SPL", "");
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Nodata });
                    }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmPVAL_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAOIL add = new frmAOIL();
            add.rv = rvDisplay;
            add.ShowDialog();
        }
    }
}
