using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRMIS_Solano
{
    public partial class frmSummaryAL : Form
    {
        public frmSummaryAL()
        {
            InitializeComponent();
        }
        string SQL;
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();

        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "SELECT CAST(MONTHNAME(recdate) as CHAR) as Month,SUM(CASE WHEN Vacation='XXX' THEN 1 ELSE 0 END) AS VL,SUM(CASE WHEN Sick='XXX' THEN 1 ELSE 0 END) AS SL,SUM(CASE WHEN Paternity='XXX' THEN 1 ELSE 0 END) AS Paternity,SUM(CASE WHEN Maternity='XXX' THEN 1 ELSE 0 END) AS Maternity,SUM(CASE WHEN Bday='XXX' THEN 1 ELSE 0 END) AS Birthday,SUM(CASE WHEN Enrollment='XXX' THEN 1 ELSE 0 END) AS Enrollment,SUM(CASE WHEN Anniversary='XXX' THEN 1 ELSE 0 END) AS Anniversary,SUM(CASE WHEN Mourning='XXX' THEN 1 ELSE 0 END) AS Mourning,SUM(CASE WHEN Solo='XXX' THEN 1 ELSE 0 END) AS Solo,SUM(CASE WHEN SPL='XXX' THEN 1 ELSE 0 END) AS Others,(SUM(CASE WHEN Vacation='XXX' THEN 1 ELSE 0 END)+SUM(CASE WHEN Sick='XXX' THEN 1 ELSE 0 END)+SUM(CASE WHEN Paternity='XXX' THEN 1 ELSE 0 END)+SUM(CASE WHEN Maternity='XXX' THEN 1 ELSE 0 END)+ SUM(CASE WHEN Bday='XXX' THEN 1 ELSE 0 END) + SUM(CASE WHEN Enrollment='XXX' THEN 1 ELSE 0 END) + SUM(CASE WHEN Anniversary='XXX' THEN 1 ELSE 0 END) + SUM(CASE WHEN Mourning='XXX' THEN 1 ELSE 0 END) + SUM(CASE WHEN Solo='XXX' THEN 1 ELSE 0 END) + SUM(CASE WHEN SPL='XXX' THEN 1 ELSE 0 END)) as Total  FROM tblleaverecord where year(recdate)=@year group by month(recdate) order by year(recdate) asc,month(recdate)";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                da.SelectCommand.Parameters.Add("@year", MySqlDbType.VarChar).Value = txtYear.Text;
                dt = new DataTable();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    dgvList.DataSource = dt;
                    int sum = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        sum = sum + Convert.ToInt32(dr["Total"].ToString());
                    }
                    txtGtotal.Text = sum.ToString();
                }
                else
                {
                    dgvList.DataSource = null;
                    txtGtotal.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
