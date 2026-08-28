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
    public partial class frmPage2 : Form
    {
        public frmPage2()
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
                //CSE
                SQL = "select * from tblcse where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblcse.Clear();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dsReports.tblcse);
                
                //WE
                SQL = "select * from tblwe where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblwe.Clear();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dsReports.tblwe);

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
        private void frmPage2_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
