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
    public partial class frmUserLogs : Form
    {
        public frmUserLogs()
        {
            InitializeComponent();
        }
        string SQL;
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();

        public void Record(string UID, string Activity, DateTime DateAccess)
        {
            try
            {
                conn.SetConstr();
                SQL = "insert into tbllogs(UID,Activity,DateAccess)values(@UID,@Activity,@DateAccess)";
                da = new MySqlDataAdapter();
                da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                da.InsertCommand.Parameters.Add("@UID", MySqlDbType.VarChar).Value = UID;
                da.InsertCommand.Parameters.Add("@Activity", MySqlDbType.VarChar).Value = Activity;
                da.InsertCommand.Parameters.Add("@DateAccess", MySqlDbType.DateTime).Value = DateAccess;
                Connection.Conn.Open();
                da.InsertCommand.ExecuteNonQuery();
                Connection.Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Search()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',b.Middlename)as Name,a.Activity,a.DateAccess as `Date Access` from tbllogs a left join tbluser b on a.UID=b.UID where Date(a.DateAccess)=Date(@DateAccess)";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@DateAccess", MySqlDbType.DateTime).Value = dtpDate.Value;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    dgvList.DataSource = dt;
                }
                else
                {
                    dgvList.DataSource = null;
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
    }
}
