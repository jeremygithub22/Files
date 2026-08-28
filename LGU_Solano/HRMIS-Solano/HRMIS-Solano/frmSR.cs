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
    public partial class frmSR : Form
    {
        public frmSR()
        {
            InitializeComponent();
        }
        string SQL, Transaction, SRID;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Service Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtEmpID.Text != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblsr(EmpID,`From`,`To`,Designation,Status,Salary,Station,Branch,LVABS,DateS,Cause)values(@EmpID,@From,@To,@Designation,@Status,@Salary,@Station,@Branch,@LVABS,@DateS,@Cause)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.InsertCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.InsertCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.InsertCommand.Parameters.Add("@Designation", MySqlDbType.VarChar).Value = txtDesignation.Text;
                        da.InsertCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = cboStatus.Text;
                        da.InsertCommand.Parameters.Add("@Salary", MySqlDbType.VarChar).Value = txtSalary.Text;
                        da.InsertCommand.Parameters.Add("@Station", MySqlDbType.VarChar).Value = txtStation.Text;
                        da.InsertCommand.Parameters.Add("@Branch", MySqlDbType.VarChar).Value = txtBranch.Text;
                        da.InsertCommand.Parameters.Add("@LVABS", MySqlDbType.VarChar).Value = txtLVABS.Text;
                        da.InsertCommand.Parameters.Add("@DateS", MySqlDbType.VarChar).Value = txtDate.Text;
                        da.InsertCommand.Parameters.Add("@Cause", MySqlDbType.VarChar).Value = txtCause.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Service Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtBranch.Clear();
                        txtCause.Clear();
                        txtDate.Clear();
                        txtDesignation.Clear();
                        txtFrom.Clear();
                        txtLVABS.Clear();
                        txtSalary.Clear();
                        txtStation.Clear();
                        txtTo.Clear();
                        cboStatus.ResetText();
                        dtpDate.Value = DateTime.Now;
                        dtpFrom.Value = DateTime.Now;
                        dtpTo.Value = DateTime.Now;

                        txtFrom.Focus();
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Service Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SRID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblsr set `From`=@From,`To`=@To,Designation=@Designation,Status=@Status,Salary=@Salary,Station=@Station,Branch=@Branch,LVABS=@LVABS,DateS=@DateS,Cause=@Cause where EmpID=@EmpID and SRID=@SRID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.UpdateCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.UpdateCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.UpdateCommand.Parameters.Add("@Designation", MySqlDbType.VarChar).Value = txtDesignation.Text;
                        da.UpdateCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = cboStatus.Text;
                        da.UpdateCommand.Parameters.Add("@Salary", MySqlDbType.VarChar).Value = txtSalary.Text;
                        da.UpdateCommand.Parameters.Add("@Station", MySqlDbType.VarChar).Value = txtStation.Text;
                        da.UpdateCommand.Parameters.Add("@Branch", MySqlDbType.VarChar).Value = txtBranch.Text;
                        da.UpdateCommand.Parameters.Add("@LVABS", MySqlDbType.VarChar).Value = txtLVABS.Text;
                        da.UpdateCommand.Parameters.Add("@DateS", MySqlDbType.VarChar).Value = txtDate.Text;
                        da.UpdateCommand.Parameters.Add("@Cause", MySqlDbType.VarChar).Value = txtCause.Text;
                        da.UpdateCommand.Parameters.Add("@SRID", MySqlDbType.VarChar).Value = SRID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Service Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        dgvList.Enabled = true;
                        txtFrom.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void DisplayBPNo()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblsrno where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    btnBPNo.Text = dr["BPNo"].ToString();
                }
                else
                {
                    btnBPNo.Text = "";
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
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = null;
                        dgvList.DataSource = null;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Service record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = null;
                        dgvList.DataSource = null;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Service record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = null;
                        dgvList.DataSource = null;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Service record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = null;
                        dgvList.DataSource = null;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Service record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = null;
                        dgvList.DataSource = null;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Service record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = null;
                        dgvList.DataSource = null;
                        txtEmpID.Clear();
                        txtName.Clear();
                        MessageBox.Show("Employee does not exist.", "Service record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SQL = "select `From`,`To`,Designation,Status,Salary,Station,Branch,LVABS as `LV ABS W/OP`,DateS as `Separation Date`,Cause as `Separation Cause` from tblsr where EmpID=@EmpID order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
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
                SQL = "select * from tblsr where EmpID=@EmpID and `From`=@From and `To`=@To and Designation=@Designation and Status=@Status and Salary=@Salary and Station=@Station and Branch=@Branch and LVABS=@LVABS and DateS=@DateS and Cause=@Cause";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                da.SelectCommand.Parameters.Add("@Designation", MySqlDbType.VarChar).Value = txtDesignation.Text;
                da.SelectCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = cboStatus.Text;
                da.SelectCommand.Parameters.Add("@Salary", MySqlDbType.VarChar).Value = txtSalary.Text;
                da.SelectCommand.Parameters.Add("@Station", MySqlDbType.VarChar).Value = txtStation.Text;
                da.SelectCommand.Parameters.Add("@Branch", MySqlDbType.VarChar).Value = txtBranch.Text;
                da.SelectCommand.Parameters.Add("@LVABS", MySqlDbType.VarChar).Value = txtLVABS.Text;
                da.SelectCommand.Parameters.Add("@DateS", MySqlDbType.VarChar).Value = txtDate.Text;
                da.SelectCommand.Parameters.Add("@Cause", MySqlDbType.VarChar).Value = txtCause.Text;
                dt = new DataTable();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    SRID = dr["SRID"].ToString();
                }
                else
                {
                    SRID = "";
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
                SQL = "select * from tblsr where EmpID=@EmpID and `From`=@From and `To`=@To and Designation=@Designation and Status=@Status and Salary=@Salary and Station=@Station and Branch=@Branch and LVABS=@LVABS and DateS=@DateS and Cause=@Cause";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["To"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Designation", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Designation"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Status"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Salary", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Salary"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Station", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Station"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Branch", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Branch"].Value.ToString();
                da.SelectCommand.Parameters.Add("@LVABS", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["LV ABS W/OP"].Value.ToString();
                da.SelectCommand.Parameters.Add("@DateS", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Separation Date"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Cause", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Separation Cause"].Value.ToString();
                dt = new DataTable();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    SRID = dr["SRID"].ToString();
                }
                else
                {
                    SRID = "";
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
                if (SRID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblsr where SRID=@SRID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@SRID", MySqlDbType.VarChar).Value = SRID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Service Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Display();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            txtFrom.Text = dtpFrom.Value.ToShortDateString();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            txtTo.Text = dtpTo.Value.ToShortDateString();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            txtDate.Text = dtpDate.Value.ToShortDateString();
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
                txtEmpID.Text = lstEmployee.SelectedValue.ToString();
                txtName.Text = lstEmployee.Text;
                Display();
                DisplayBPNo();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Transaction = "New";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txtBranch.Clear();
            txtCause.Clear();
            txtDate.Clear();
            txtDesignation.Clear();
            txtFrom.Clear();
            txtLVABS.Clear();
            txtSalary.Clear();
            txtStation.Clear();
            txtTo.Clear();
            cboStatus.ResetText();
            dtpDate.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;

            txtFrom.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                Transaction = "Edit";
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                txtBranch.Text = dgvList.SelectedRows[0].Cells["Branch"].Value.ToString();
                txtCause.Text = dgvList.SelectedRows[0].Cells["Separation Cause"].Value.ToString();
                txtDate.Text = dgvList.SelectedRows[0].Cells["Separation Date"].Value.ToString();
                txtDesignation.Text = dgvList.SelectedRows[0].Cells["Designation"].Value.ToString();
                txtFrom.Text = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                txtLVABS.Text = dgvList.SelectedRows[0].Cells["LV ABS W/OP"].Value.ToString();
                txtSalary.Text = dgvList.SelectedRows[0].Cells["Salary"].Value.ToString();
                txtStation.Text = dgvList.SelectedRows[0].Cells["Station"].Value.ToString();
                txtTo.Text = dgvList.SelectedRows[0].Cells["To"].Value.ToString();
                cboStatus.Text = dgvList.SelectedRows[0].Cells["Status"].Value.ToString();

                txtFrom.Focus();
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
            if (UserDetails.APSR == "1")
            {
                btnNew.Enabled = true;
            }
            btnEdit.Enabled = false;
            btnSave.Enabled = false;

            txtBranch.Clear();
            txtCause.Clear();
            txtDate.Clear();
            txtDesignation.Clear();
            txtFrom.Clear();
            txtLVABS.Clear();
            txtSalary.Clear();
            txtStation.Clear();
            txtTo.Clear();
            cboStatus.ResetText();
            dtpDate.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;

            txtFrom.Focus();
            dgvList.Enabled = true;
            dgvList.DataSource = null;
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (UserDetails.EPSR == "1")
                {
                    btnEdit.Enabled = true;
                }
                if (UserDetails.DPSR == "1")
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnBPNo_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text != "")
            {
                if (UserDetails.EPSR == "1")
                {
                    frmSRBPNo snno = new frmSRBPNo();
                    frmSRBPNo.EmpID = txtEmpID.Text;
                    snno.btn = btnBPNo;
                    snno.txtNo.Text = btnBPNo.Text;
                    snno.ShowDialog();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record", "Service Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    Deldata();
                }
            }
        }

        private void frmSR_Load(object sender, EventArgs e)
        {
            if (UserDetails.APSR == "1")
            {
                btnNew.Enabled = true;
            }
        }
    }
}
