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
    public partial class frmRef : Form
    {
        public frmRef()
        {
            InitializeComponent();
        }

        string SQL, Transaction, Name, Address, Tel, REFID;
        public string EmpID;
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "References", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblref(EmpID,Name,`Add`,Tel)values(@EmpID,@Name,@Add,@Tel)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                        da.InsertCommand.Parameters.Add("@Add", MySqlDbType.VarChar).Value = txtAddress.Text;
                        da.InsertCommand.Parameters.Add("@Tel", MySqlDbType.VarChar).Value = txtTelno.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "References", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtAddress.Clear();
                        txtName.Clear();
                        txtTelno.Clear();

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtName.Focus();

                        dgvList.Enabled = true;
                        Display();
                    }
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "References", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (REFID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblref set Name=@Name,`Add`=@Add,Tel=@Tel where EmpID=@EmpID and REFID=@REFID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                        da.UpdateCommand.Parameters.Add("@Add", MySqlDbType.VarChar).Value = txtAddress.Text;
                        da.UpdateCommand.Parameters.Add("@Tel", MySqlDbType.VarChar).Value = txtTelno.Text;
                        da.UpdateCommand.Parameters.Add("@REFID", MySqlDbType.VarChar).Value = REFID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "References", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtName.Focus();

                        dgvList.Enabled = true;
                        Display();
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
                SQL = "select * from tblref where EmpID=@EmpID and Name=@Name and `Add`=@Add and Tel=@Tel";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                da.SelectCommand.Parameters.Add("@Add", MySqlDbType.VarChar).Value = txtAddress.Text;
                da.SelectCommand.Parameters.Add("@Tel", MySqlDbType.VarChar).Value = txtTelno.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    REFID = dr["REFID"].ToString();
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
                SQL = "select * from tblref where EmpID=@EmpID and Name=@Name and `Add`=@Add and Tel=@Tel";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Add", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Address"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Tel", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Telephone No."].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    REFID = dr["REFID"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Deldata()
        {
            try
            {
                if (REFID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblref where REFID=@REFID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@REFID", MySqlDbType.VarChar).Value = REFID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "References", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SQL = "select Name,`Add` as `Address`,Tel as `Telephone No.` from tblref where EmpID=@EmpID";
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
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            Transaction = "New";

            txtAddress.Clear();
            txtName.Clear();
            txtTelno.Clear();

            txtName.Focus();

            dgvList.Enabled = true;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                Transaction = "Edit";

                txtAddress.Text = dgvList.SelectedRows[0].Cells["Address"].Value.ToString();
                txtName.Text = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
                txtTelno.Text = dgvList.SelectedRows[0].Cells["Telephone No."].Value.ToString();

                Address = txtAddress.Text;
                Name = txtName.Text;
                Tel = txtTelno.Text;

                txtName.Focus();

                dgvList.Enabled = false;

                GetID();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (Transaction == "New")
            {
                txtAddress.Clear();
                txtName.Clear();
                txtTelno.Clear();

                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;

                txtName.Focus();

                dgvList.Enabled = true;
            }
            else if (Transaction == "Edit")
            {
                txtAddress.Text = Address;
                txtName.Text = Name;
                txtTelno.Text = Tel;

                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                txtName.Focus();

                dgvList.Enabled = false;
            }
            else
            {
            }
        }

        private void frmRef_Load(object sender, EventArgs e)
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
                if (MessageBox.Show("Are you sure, you want to delete this record", "References", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    Deldata();
                }
            }
        }
    }
}
