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
    public partial class frmSiblings : Form
    {
        public frmSiblings()
        {
            InitializeComponent();
        }
        string SQL, Transaction, CID, Name, DateofBirth;
        public string EmpID;
        Connection conn = new Connection();
        DataTable dt;
        MySqlDataAdapter da;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Siblings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblchild(EmpID,Name,DateofBirth)values(@EmpID,@Name,@DateofBirth)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                        da.InsertCommand.Parameters.Add("@DateofBirth", MySqlDbType.VarChar).Value = dtpBdate.Value.ToShortDateString();
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Siblings", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Display();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        txtName.Clear();
                        dtpBdate.Value = DateTime.Now;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Save()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to update this record?", "Siblings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblchild set Name=@Name,DateofBirth=@DateofBirth where EmpID=@EmpID and CID=@CID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                        da.UpdateCommand.Parameters.Add("@DateofBirth", MySqlDbType.VarChar).Value = dtpBdate.Value.ToShortDateString();
                        da.UpdateCommand.Parameters.Add("@CID", MySqlDbType.VarChar).Value = CID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Siblings", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Display();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        dgvList.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetID()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblchild where EmpID=@EmpID and Name=@Name and DateofBirth=@DateofBirth";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                da.SelectCommand.Parameters.Add("@DateofBirth", MySqlDbType.VarChar).Value = dtpBdate.Value.ToShortDateString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    CID = dr["CID"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetIDDel()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblchild where EmpID=@EmpID and Name=@Name and DateofBirth=@DateofBirth";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
                da.SelectCommand.Parameters.Add("@DateofBirth", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Date of Birth"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    CID = dr["CID"].ToString();
                }
                else
                {
                    CID = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void DelData()
        {
            try
            {
                if (CID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblchild where CID=@CID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@CID", MySqlDbType.VarChar).Value = CID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Siblings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Display();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select Name,DateofBirth as 'Date of Birth' from tblchild where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    if (UserDetails.APPI == "1")
                    {
                        btnNew.Enabled = true;
                    }
                    dgvList.DataSource = dt;
                }
                else
                {
                    if (UserDetails.APPI == "1")
                    {
                        btnNew.Enabled = true;
                    }
                    dgvList.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Transaction = "New";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            txtName.Clear();
            dtpBdate.Value = DateTime.Now;
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                Transaction = "Edit";
                 btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                txtName.Text = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
                dtpBdate.Text = dgvList.SelectedRows[0].Cells["Date of Birth"].Value.ToString();

                Name = txtName.Text;
                DateofBirth = dtpBdate.Value.ToShortDateString();
                txtName.Focus();
                dgvList.Enabled = false;
                GetID();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Transaction == "New")
            {
                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                txtName.Clear();
                dtpBdate.Value = DateTime.Now;

                dgvList.Enabled = true;

            }
            else if (Transaction == "Edit")
            {
                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;
                txtName.Text=Name;
                dtpBdate.Text = DateofBirth;
                dgvList.Enabled = false;
            }
            else
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Transaction == "New")
            {
                Add();
            }
            else if (Transaction == "Edit")
            {
                Save();
            }
            else
            {
            }
        }

        private void frmSiblings_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                if (UserDetails.DPPI == "1")
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record", "Siblings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    DelData();
                }
            }
        }
    }
}
