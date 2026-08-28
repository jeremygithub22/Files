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
    public partial class frmFC : Form
    {
        public frmFC()
        {
            InitializeComponent();
        }
        string SQL, Transaction, FLID;
        Connection conn = new Connection();
        DataTable dt;
        MySqlDataAdapter da;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtEmpID.Text != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblflag(EmpID,DateRec,TimeArriv,Remarks)values(@EmpID,@DateRec,@TimeArriv,@Remarks)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.InsertCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                        da.InsertCommand.Parameters.Add("@TimeArriv", MySqlDbType.VarChar).Value = dtpTime.Value.ToShortTimeString();
                        da.InsertCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        txtRemarks.Clear();
                        cbNT.Checked = false;
                        dtpDate.Value = DateTime.Now;
                        dtpTime.Value = DateTime.Now;
                        dtpDate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void AddNT()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtEmpID.Text != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblflag(EmpID,DateRec,Remarks)values(@EmpID,@DateRec,@Remarks)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.InsertCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                        da.InsertCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        txtRemarks.Clear();
                        cbNT.Checked = false;
                        dtpDate.Value = DateTime.Now;
                        dtpTime.Value = DateTime.Now;
                        cbNT.Checked = false;
                        dtpDate.Focus();
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
                if (MessageBox.Show("Are you sure, you want to update this record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (FLID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblflag set DateRec=@DateRec,TimeArriv=@TimeArriv,Remarks=@Remarks where EmpID=@EmpID and FLID=@FLID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.UpdateCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                        da.UpdateCommand.Parameters.Add("@TimeArriv", MySqlDbType.VarChar).Value = dtpTime.Value.ToShortTimeString();
                        da.UpdateCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        da.UpdateCommand.Parameters.Add("@FLID", MySqlDbType.VarChar).Value = FLID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully updated record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        dtpDate.Focus();
                        dgvList.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void SaveNT()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to update this record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (FLID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblflag set DateRec=@DateRec,TimeArriv='',Remarks=@Remarks where EmpID=@EmpID and FLID=@FLID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.UpdateCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                        da.UpdateCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        da.UpdateCommand.Parameters.Add("@FLID", MySqlDbType.VarChar).Value = FLID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully updated record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        dtpDate.Focus();
                        dgvList.Enabled = true;
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
                        MessageBox.Show("Employee does not exist.", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SQL = "select DateRec as `Date Recorded`,TimeArriv as `Time Arrived`,Remarks from tblflag where EmpID=@EmpID";
                da = new MySqlDataAdapter (SQL, Connection.Conn);
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
                SQL = "select * from tblflag where EmpID=@EmpID and DateRec=@DateRec and TimeArriv=@TimeArriv and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                da.SelectCommand.Parameters.Add("@TimeArriv", MySqlDbType.VarChar).Value = dtpTime.Value.ToShortTimeString();
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    FLID = dr["FLID"].ToString();
                }
                else
                {
                    FLID = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetIDNT()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblflag where EmpID=@EmpID and DateRec=@DateRec and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    FLID = dr["FLID"].ToString();
                }
                else
                {
                    FLID = string.Empty;
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
                SQL = "select * from tblflag where EmpID=@EmpID and DateRec=@DateRec and TimeArriv=@TimeArriv and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dgvList.SelectedRows[0].Cells["Date Recorded"].Value.ToString();
                da.SelectCommand.Parameters.Add("@TimeArriv", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Time Arrived"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    FLID = dr["FLID"].ToString();
                }
                else
                {
                    FLID = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetIDDelNT()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblflag where EmpID=@EmpID and DateRec=@DateRec and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dgvList.SelectedRows[0].Cells["Date Recorded"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    FLID = dr["FLID"].ToString();
                }
                else
                {
                    FLID = string.Empty;
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
                if (FLID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblflag where FLID=@FLID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@FLID", MySqlDbType.VarChar).Value = FLID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (UserDetails.EPFC == "1")
                {
                    btnEdit.Enabled = true;
                }
                if (UserDetails.DPFC == "1")
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record", "Attendance for Flag Raising Ceremony", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvList.SelectedRows[0].Cells["Time Arrived"].Value.ToString() == "")
                    {
                        
                        GetIDDelNT();
                    }
                    else
                    {
                        GetIDDel();
                    }
                    DelData();
                    Display();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            Transaction = "New";
            txtRemarks.Clear();
            cbNT.Checked = false;
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
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
                txtRemarks.Text = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();
                dtpDate.Text = dgvList.SelectedRows[0].Cells["Date Recorded"].Value.ToString();
                if (dgvList.SelectedRows[0].Cells["Time Arrived"].Value.ToString() == "")
                {
                    cbNT.Checked = true;
                    GetIDNT();
                }
                else
                {
                    dtpTime.Text = dgvList.SelectedRows[0].Cells["Time Arrived"].Value.ToString();
                    cbNT.Checked = false;
                    GetID();
                }
                dtpDate.Focus();
                dgvList.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Transaction == "New")
            {
                if (cbNT.Checked == true)
                {
                    AddNT();
                }
                else
                {
                    Add();
                }
            }
            else if (Transaction == "Edit")
            {
                if (cbNT.Checked == true)
                {
                    SaveNT();
                }
                else
                {
                    Save();
                }
            }
            else
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmpID.Clear();
            txtName.Clear();
            txtRemarks.Clear();
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
            dgvList.DataSource = null;
            cbNT.Checked = false;
            if (UserDetails.APFC == "1")
            {
                btnNew.Enabled = true;
            }
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            dgvList.Enabled = true;
            dtpDate.Focus();
        }

        private void frmFC_Load(object sender, EventArgs e)
        {
            if (UserDetails.APFC == "1")
            {
                btnNew.Enabled = true;
            }
        }
    }
}
