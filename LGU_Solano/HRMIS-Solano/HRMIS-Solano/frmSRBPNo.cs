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
    public partial class frmSRBPNo : Form
    {
        public frmSRBPNo()
        {
            InitializeComponent();
        }
        string SQL;
        DataTable dt;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        public static string EmpID;
        public Button btn;
        void Add()
        {
            try
            {
                conn.SetConstr();
                if (MessageBox.Show("Are you sure, you want to add this record", "BP No.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQL = "insert into tblsrno(EmpID,BPNo)values(@EmpID,@BPNo)";
                    da = new MySqlDataAdapter();
                    da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                    da.InsertCommand.Parameters.Add("@BPNo", MySqlDbType.VarChar).Value = txtNo.Text;
                    Connection.Conn.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully add record", "BP No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn.Text = txtNo.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Save()
        {
            try
            {
                conn.SetConstr();
                if (MessageBox.Show("Are you sure, you want to update this record", "BP No.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQL = "update tblsrno set BPNo=@BPNo where EmpID=@EmpID";
                    da = new MySqlDataAdapter();
                    da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                    da.UpdateCommand.Parameters.Add("@BPNo", MySqlDbType.VarChar).Value = txtNo.Text;
                    Connection.Conn.Open();
                    da.UpdateCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully update record", "BP No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn.Text = txtNo.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void CheckRec()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblsrno where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    Save();
                }
                else
                {
                    Add();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckRec();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNo.Clear();
        }
    }
}
