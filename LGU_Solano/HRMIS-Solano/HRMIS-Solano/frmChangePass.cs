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
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }
        string SQL;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
        void Save()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tbluser where username=@username and password=md5(@password)";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = UserDetails.Username;
                da.SelectCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtCP.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    if (txtNP.Text == txtRNP.Text)
                    {
                        SQL = "update tbluser set password=md5(@password) where username=@username";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtRNP.Text;
                        da.UpdateCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = UserDetails.Username;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update password", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New password and re-type new  password does not match", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid current password", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, you want to change password?", "Change Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Save();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCP.Clear();
            txtNP.Clear();
            txtRNP.Clear();
            txtCP.Focus();
        }

        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtNP.Focus();
            }
        }

        private void txtNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtRNP.Focus();
            }
        }

        private void txtRNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnOK.PerformClick();
            }
        }
    }
}
