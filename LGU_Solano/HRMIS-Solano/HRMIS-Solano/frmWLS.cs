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
    public partial class frmWLS : Form
    {
        public frmWLS()
        {
            InitializeComponent();
        }
        string SQL, Transaction, WLSID;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record", "Without Locator Slip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtEmpID.Text != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblwls(EmpID,DateRec,TimeDep,TimeArriv,Remarks)values(@EmpID,@DateRec,@TimeDep,@TimeArriv,@Remarks)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.InsertCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                        da.InsertCommand.Parameters.Add("@TimeDep", MySqlDbType.VarChar).Value = txtDep.Text;
                        da.InsertCommand.Parameters.Add("@TimeArriv", MySqlDbType.VarChar).Value = txtArriv.Text;
                        da.InsertCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                        txtRemarks.Clear();
                        txtArriv.Clear();
                        txtDep.Clear();
                        dtpDate.Value = DateTime.Now;
                        dtpDate.Focus();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
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
                if (MessageBox.Show("Are you sure, you want to update this record", "Without Locator Slip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (WLSID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblwls set DateRec=@DateRec,TimeDep=@TimeDep,TimeArriv=@TimeArriv,Remarks=@Remarks where EmpID=@EmpID and WLSID=@WLSID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.UpdateCommand.Parameters.Add("@WLSID", MySqlDbType.VarChar).Value = WLSID;
                        da.UpdateCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                        da.UpdateCommand.Parameters.Add("@TimeDep", MySqlDbType.VarChar).Value = txtDep.Text;
                        da.UpdateCommand.Parameters.Add("@TimeArriv", MySqlDbType.VarChar).Value = txtArriv.Text;
                        da.UpdateCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                        dgvList.Enabled = true;
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
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
                if (cboSearchby.Text == "Employee ID")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tblpi where EmpID=@EmpID order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = dt;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Surname")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tblpi where Surname=@Surname order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = dt;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Firstname")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tblpi where Firstname=@Firstname order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = dt;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Middlename")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tblpi where Middlename=@Middlename order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@Middlename", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = dt;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Department")
                {
                    SQL = "select a.*,concat(a.Surname,', ',a.Firstname,' ',a.Middlename)as Name from tblpi a left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) b on a.EmpID=b.EmpID where b.Department=@Department order by concat(a.Surname,', ',a.Firstname,' ',a.Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = dt;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "All")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tblpi order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = dt;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select DateRec as `Date of Record`,TimeDep as `Time Departure`,TimeArriv as `Time Arrival`,Remarks from tblwls where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
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
        void GetID()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblwls where EmpID=@EmpID and DateRec=@DateRec and TimeDep=@TimeDep and TimeArriv=@TimeArriv and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                da.SelectCommand.Parameters.Add("@TimeDep", MySqlDbType.VarChar).Value = txtDep.Text;
                da.SelectCommand.Parameters.Add("@TimeArriv", MySqlDbType.VarChar).Value = txtArriv.Text;
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    WLSID = dr["WLSID"].ToString();
                }
                else
                {
                    WLSID = string.Empty;
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
                SQL = "select * from tblwls where EmpID=@EmpID and DateRec=@DateRec and TimeDep=@TimeDep and TimeArriv=@TimeArriv and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dgvList.SelectedRows[0].Cells["Date of Record"].Value.ToString();
                da.SelectCommand.Parameters.Add("@TimeDep", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Time Departure"].Value.ToString();
                da.SelectCommand.Parameters.Add("@TimeArriv", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Time Arrival"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    WLSID = dr["WLSID"].ToString();
                }
                else
                {
                    WLSID = string.Empty;
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
                if (WLSID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblwls where WLSID=@WLSID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@WLSID", MySqlDbType.VarChar).Value = WLSID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted", "Without Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Display();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void lstEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedIndex != -1)
            {
                Display();
                txtEmpID.Text = lstEmployee.SelectedValue.ToString();
                txtName.Text = lstEmployee.Text;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            Transaction = "New";
            txtArriv.Clear();
            txtDep.Clear();
            txtRemarks.Clear();
            dtpDate.Value = DateTime.Now;
            dtpDate.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                Transaction = "Edit";
                txtArriv.Text = dgvList.SelectedRows[0].Cells["Time Arrival"].Value.ToString();
                txtDep.Text = dgvList.SelectedRows[0].Cells["Time Departure"].Value.ToString();
                txtRemarks.Text = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();
                dtpDate.Text = dgvList.SelectedRows[0].Cells["Date of Record"].Value.ToString();
                GetID();
                dgvList.Enabled = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record", "Without Locator Slip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    DelData();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtArriv.Clear();
            txtDep.Clear();
            txtEmpID.Clear();
            txtName.Clear();
            txtRemarks.Clear();
            dtpDate.Value = DateTime.Now;
            dtpDate.Focus();
            dgvList.Enabled = true;
            dgvList.DataSource = null;
            if (UserDetails.APWLS == "1")
            {
                btnNew.Enabled = true;
            }
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (UserDetails.EPWLS == "1")
                {
                    btnEdit.Enabled = true;
                }
                if (UserDetails.DPWLS == "1")
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private void frmWLS_Load(object sender, EventArgs e)
        {
            if (UserDetails.APWLS == "1")
            {
                btnNew.Enabled = true;
            }
        }
    }
}
