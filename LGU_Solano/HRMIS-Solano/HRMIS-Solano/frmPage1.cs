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

namespace HRMIS_Solano
{
    public partial class frmPage1 : Form
    {
        public frmPage1()
        {
            InitializeComponent();
        }
        public string EmpID;
        Connection conn = new Connection();
        string SQL;
        MySqlDataAdapter da;
        void LoadData()
        {
            try
            {
                conn.SetConstr();

                //Personal Information
                SQL = "select * from tblpi where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblpi.Clear();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dsReports.tblpi);

                DataRow dr = dsReports.tblpi.Rows[0];

                //Gender
                if (dr["Sex"].ToString() == "Male")
                {
                    ReportParameter SM = new ReportParameter("Male", "√");
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { SM });
                }
                if (dr["Sex"].ToString() == "Female")
                {
                    ReportParameter SF = new ReportParameter("Female", "√");
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { SF });
                }

                //Civil Status
                if (dr["Civilstatus"].ToString() == "Single")
                {
                    ReportParameter Single = new ReportParameter("Single", "√");
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Single });
                }
                else if (dr["Civilstatus"].ToString() == "Married")
                {
                    ReportParameter Married = new ReportParameter("Married", "√");
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Married });
                }
                else if (dr["Civilstatus"].ToString() == "Annulled")
                {
                    ReportParameter Annulled = new ReportParameter("Annulled", "√");
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Annulled });
                }
                else if (dr["Civilstatus"].ToString() == "Widowed")
                {
                    ReportParameter Widowed = new ReportParameter("Widowed", "√");
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Widowed });
                }
                else if (dr["Civilstatus"].ToString() == "Separated")
                {
                    ReportParameter Separated = new ReportParameter("Separated", "√");
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Separated });
                }
                else if (dr["Civilstatus"].ToString() == "Others")
                {
                    ReportParameter Others = new ReportParameter("Others", "√");
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Others });
                    ReportParameter OS = new ReportParameter("OS", dr["Civilstatus"].ToString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { OS });
                }
                else
                {
                }

                //Family Background
                SQL = "select * from tblfb where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblfb.Clear();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dsReports.tblfb);

                //Child Info
                SQL = "select * from tblchild where EmpID=@EmpID limit 2";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblchild.Clear();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dsReports.tblchild);

                //EB
                SQL = "select * from tbleb where EmpID=@EmpID limit 3";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tbleb.Clear();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dsReports.tbleb);

                Connection.Conn.Close();
                rvDisplay.SetDisplayMode(DisplayMode.PrintLayout);
                rvDisplay.ZoomMode = ZoomMode.Percent;
                rvDisplay.ZoomPercent = 100;
                rvDisplay.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmPage1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
