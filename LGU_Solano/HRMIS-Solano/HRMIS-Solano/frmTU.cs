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
    public partial class frmTU : Form
    {
        public frmTU()
        {
            InitializeComponent();
        }
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
        string SQL, Type, Transaction, RecNo;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Tardiness/Undertime", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtEmpID.Text != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tbldeduct(EmpID,DateIncurred,Type,Frequency,Mins,ConversionDays,Remarks)values(@EmpID,@DateIncurred,@Type,@Frequency,@Mins,@ConversionDays,@Remarks)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.InsertCommand.Parameters.Add("@DateIncurred", MySqlDbType.Date).Value = dtpDateIncurred.Value;
                        da.InsertCommand.Parameters.Add("@Type", MySqlDbType.VarChar).Value = Type;
                        da.InsertCommand.Parameters.Add("@Frequency", MySqlDbType.Double).Value = txtFreq.Text;
                        da.InsertCommand.Parameters.Add("@Mins", MySqlDbType.Double).Value = txtMin.Text;
                        da.InsertCommand.Parameters.Add("@ConversionDays", MySqlDbType.Double).Value = txtConvDays.Text;
                        da.InsertCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtConvDays.Clear();
                        txtFreq.Clear();
                        txtMin.Clear();
                        txtRemarks.Clear();
                        dtpDateIncurred.Value = DateTime.Now;
                        rbTardiness.Checked = false;
                        rbUndertime.Checked = false;
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Tardiness/Undertime", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (RecNo != "")
                    {
                        conn.SetConstr();
                        SQL = "update tbldeduct set DateIncurred=@DateIncurred,Type=@Type,Frequency=@Frequency,Mins=@Mins,ConversionDays=@ConversionDays,Remarks=@Remarks where EmpID=@EmpID and RecNo=@RecNo";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.UpdateCommand.Parameters.Add("@DateIncurred", MySqlDbType.Date).Value = dtpDateIncurred.Value;
                        da.UpdateCommand.Parameters.Add("@Type", MySqlDbType.VarChar).Value = Type;
                        da.UpdateCommand.Parameters.Add("@Frequency", MySqlDbType.Double).Value = txtFreq.Text;
                        da.UpdateCommand.Parameters.Add("@Mins", MySqlDbType.Double).Value = txtMin.Text;
                        da.UpdateCommand.Parameters.Add("@ConversionDays", MySqlDbType.Double).Value = txtConvDays.Text;
                        da.UpdateCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        da.UpdateCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = RecNo;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
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
                SQL = "select * from tbldeduct where EmpID=@EmpID and DateIncurred=@DateIncurred and Type=@Type and Frequency=@Frequency and Mins=@Mins and ConversionDays=@ConversionDays and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value =txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateIncurred", MySqlDbType.Date).Value = dtpDateIncurred.Value;
                da.SelectCommand.Parameters.Add("@Type", MySqlDbType.VarChar).Value = Type;
                da.SelectCommand.Parameters.Add("@Frequency", MySqlDbType.Double).Value = txtFreq.Text;
                da.SelectCommand.Parameters.Add("@Mins", MySqlDbType.Double).Value = txtMin.Text;
                da.SelectCommand.Parameters.Add("@ConversionDays", MySqlDbType.Double).Value = txtConvDays.Text;
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                dt = new DataTable();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    RecNo = dr["RecNo"].ToString();
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
                SQL = "select * from tbldeduct where EmpID=@EmpID and DateIncurred=@DateIncurred and Type=@Type and Frequency=@Frequency and Mins=@Mins and ConversionDays=@ConversionDays and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateIncurred", MySqlDbType.Date).Value = dgvList.SelectedRows[0].Cells["Date Incurred"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Type", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Type"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Frequency", MySqlDbType.Double).Value = dgvList.SelectedRows[0].Cells["Frequency"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Mins", MySqlDbType.Double).Value = dgvList.SelectedRows[0].Cells["Minutes"].Value.ToString();
                da.SelectCommand.Parameters.Add("@ConversionDays", MySqlDbType.Double).Value = dgvList.SelectedRows[0].Cells["Conversion Days"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();
                dt = new DataTable();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    RecNo = dr["RecNo"].ToString();
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
                if (RecNo != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tbldeduct where RecNo=@RecNo";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = RecNo;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Display();
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
                        lstEmployee.DataSource = null;
                        MessageBox.Show("Employee does not exist.", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.DataSource = null;
                        MessageBox.Show("Employee does not exist.", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.DataSource = null;
                        MessageBox.Show("Employee does not exist.", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.DataSource = null;
                        MessageBox.Show("Employee does not exist.", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.DataSource = null;
                        MessageBox.Show("Employee does not exist.", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.DataSource = null;
                        MessageBox.Show("Employee does not exist.", "Tardiness/Undertime", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtEmpID.Text = lstEmployee.SelectedValue.ToString();
                txtName.Text = lstEmployee.Text;

                conn.SetConstr();
                SQL = "select DateIncurred as `Date Incurred`,Type,Frequency,Mins as Minutes,ConversionDays as `Conversion Days`,Remarks from tbldeduct where EmpID=@EmpID";
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
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Transaction = "New";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txtConvDays.Clear();
            txtFreq.Clear();
            txtMin.Clear();
            txtRemarks.Clear();
            dtpDateIncurred.Value = DateTime.Now;
            rbTardiness.Checked = false;
            rbUndertime.Checked = false;
            txtFreq.Focus();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                Transaction = "Edit";
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                dgvList.Enabled = false;

                txtConvDays.Text = dgvList.SelectedRows[0].Cells["Conversion Days"].Value.ToString();
                txtFreq.Text = dgvList.SelectedRows[0].Cells["Frequency"].Value.ToString();
                txtMin.Text = dgvList.SelectedRows[0].Cells["Minutes"].Value.ToString();
                txtRemarks.Text = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();
                dtpDateIncurred.Text = dgvList.SelectedRows[0].Cells["Date Incurred"].Value.ToString();

                if (dgvList.SelectedRows[0].Cells["Type"].Value.ToString() == "Tardiness")
                {
                    rbTardiness.Checked = true;
                }
                else
                {
                    rbTardiness.Checked = false;
                }

                if (dgvList.SelectedRows[0].Cells["Type"].Value.ToString() == "Undertime")
                {
                    rbUndertime.Checked = true;
                }
                else
                {
                    rbUndertime.Checked = false;
                }   
                txtFreq.Focus();
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

        private void rbTardiness_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTardiness.Checked == true)
            {
                Type = "Tardiness";
            }
        }

        private void rbUndertime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUndertime.Checked == true)
            {
                Type = "Undertime";
            }
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double value = double.Parse(txtMin.Text);
                double equivalent = value / 480;
                txtConvDays.Text = equivalent.ToString();
            }
            catch
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtConvDays.Clear();
            txtEmpID.Clear();
            txtFreq.Clear();
            txtMin.Clear();
            txtName.Clear();
            txtRemarks.Clear();
            dtpDateIncurred.Value = DateTime.Now;
            rbTardiness.Checked = false;
            rbUndertime.Checked = false;
            if (UserDetails.APTU == "1")
            {
                btnNew.Enabled = true;
            }
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            dgvList.Enabled = true;
            dgvList.DataSource = null;
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (UserDetails.EPTU == "1")
                {
                    btnEdit.Enabled = true;
                }
                if (UserDetails.DPTU == "1")
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record", "Tardiness/Undertime", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    Deldata();
                }
            }
        }

        private void frmTU_Load(object sender, EventArgs e)
        {
            if (UserDetails.APTU == "1")
            {
                btnNew.Enabled = true;
            }
        }
    }
}
