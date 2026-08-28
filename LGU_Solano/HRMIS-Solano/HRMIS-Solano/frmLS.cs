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
    public partial class frmLS : Form
    {
        public frmLS()
        {
            InitializeComponent();
        }
        string SQL, Transaction, ApprovedAs;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
        frmArrival Arriv = new frmArrival();

        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Locator Slip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cbPersonal.Checked == true || cbOfficial.Checked == true && txtLocNo.Text != "")
                    {
                        conn.SetConstr();
                        SQL = "select * from tblslip where LocNo=@LocNo";
                        da = new MySqlDataAdapter(SQL, Connection.Conn);
                        dt = new DataTable();
                        da.SelectCommand.Parameters.Add("@LocNo", MySqlDbType.VarChar).Value = txtLocNo.Text;
                        da.Fill(dt);
                        Connection.Conn.Close();
                        if (dt.Rows.Count != 0)
                        {
                            MessageBox.Show("Locator no. exist, please choose another", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (cbPersonal.Checked == true)
                            {
                                ApprovedAs = "Personal";
                            }
                            if (cbOfficial.Checked == true)
                            {
                                ApprovedAs = "Official";
                            }
                            if (cbPersonal.Checked == true && cbOfficial.Checked == true)
                            {
                                ApprovedAs = "Personal/Official";
                            }
                            else
                            {
                            }
                            SQL = "insert into tblslip(LocNo,EmpID,DepartureTime,DepartureDate,Destination,Reason,ExpectedTime,ExpectedDate,ApprovedAs)values(@LocNo,@EmpID,@DepartureTime,@DepartureDate,@Destination,@Reason,@ExpectedTime,@ExpectedDate,@ApprovedAs)";
                            da = new MySqlDataAdapter();
                            da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                            da.InsertCommand.Parameters.Add("@LocNo", MySqlDbType.VarChar).Value = txtLocNo.Text;
                            da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                            da.InsertCommand.Parameters.Add("@DepartureTime", MySqlDbType.VarChar).Value = dtpDtime.Value.ToShortTimeString();
                            da.InsertCommand.Parameters.Add("@DepartureDate", MySqlDbType.Date).Value = dtpDtime.Value;
                            da.InsertCommand.Parameters.Add("@Destination", MySqlDbType.VarChar).Value = txtDestination.Text;
                            da.InsertCommand.Parameters.Add("@Reason", MySqlDbType.VarChar).Value = txtReasons.Text;
                            da.InsertCommand.Parameters.Add("@ExpectedTime", MySqlDbType.VarChar).Value = dtpEtime.Value.ToShortTimeString(); ;
                            da.InsertCommand.Parameters.Add("@ExpectedDate", MySqlDbType.Date).Value = dtpEdate.Value;
                            da.InsertCommand.Parameters.Add("@ApprovedAs", MySqlDbType.VarChar).Value = ApprovedAs;
                            Connection.Conn.Open();
                            da.InsertCommand.ExecuteNonQuery();
                            Connection.Conn.Close();
                            MessageBox.Show("Successfully add record", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDestination.Clear();
                            txtEquivalent.Clear();
                            txtLocNo.Clear();
                            txtMinUsed.Clear();
                            txtReasons.Clear();
                            dtpDdate.Value = DateTime.Now;
                            dtpDtime.Value = DateTime.Now;
                            dtpEdate.Value = DateTime.Now;
                            dtpEtime.Value = DateTime.Now;
                            cbOfficial.Checked = false;
                            cbPersonal.Checked = false;
                            btnNew.Enabled = true;
                            btnEdit.Enabled = false;
                            btnSave.Enabled = false;
                            Display();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please set Approved as/Locator no.", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Locator Slip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cbPersonal.Checked == true || cbOfficial.Checked == true && txtLocNo.Text != "")
                    {
                        conn.SetConstr();
                        if (cbPersonal.Checked == true)
                        {
                            ApprovedAs = "Personal";
                        }
                        if (cbOfficial.Checked == true)
                        {
                            ApprovedAs = "Official";
                        }
                        if (cbPersonal.Checked == true && cbOfficial.Checked == true)
                        {
                            ApprovedAs = "Personal/Official";
                        }
                        else
                        {
                        }
                        SQL = "update tblslip set DepartureTime=@DepartureTime,DepartureDate=@DepartureDate,Destination=@Destination,Reason=@Reason,ExpectedTime=@ExpectedTime,ActualTime=@ActualTime,ExpectedDate=@ExpectedDate,ApprovedAs=@ApprovedAs,MinUse=@MinUse,Equivalent=@Equivalent where LocNo=@LocNo";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@LocNo", MySqlDbType.VarChar).Value = txtLocNo.Text;
                        da.UpdateCommand.Parameters.Add("@DepartureTime", MySqlDbType.VarChar).Value = dtpDtime.Value.ToShortTimeString();
                        da.UpdateCommand.Parameters.Add("@DepartureDate", MySqlDbType.Date).Value = dtpDdate.Value;
                        da.UpdateCommand.Parameters.Add("@Destination", MySqlDbType.VarChar).Value = txtDestination.Text;
                        da.UpdateCommand.Parameters.Add("@Reason", MySqlDbType.VarChar).Value = txtReasons.Text;
                        da.UpdateCommand.Parameters.Add("@ExpectedTime", MySqlDbType.VarChar).Value = dtpEtime.Value.ToShortTimeString();
                        da.UpdateCommand.Parameters.Add("@ExpectedDate", MySqlDbType.Date).Value = dtpEdate.Value;
                        da.UpdateCommand.Parameters.Add("@ApprovedAs", MySqlDbType.VarChar).Value = ApprovedAs;
                        da.UpdateCommand.Parameters.Add("@MinUse", MySqlDbType.VarChar).Value = txtMinUsed.Text;
                        da.UpdateCommand.Parameters.Add("@Equivalent", MySqlDbType.VarChar).Value = txtEquivalent.Text;
                        da.UpdateCommand.Parameters.Add("@ActualTime", MySqlDbType.VarChar).Value = dtpActualTime.Value.ToShortTimeString();
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvList.Enabled = true;
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        if (lstEmployee.DataSource != null)
                        {
                            Display();
                        }
                        else
                        {
                            LocDisplay();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please set Approved as/Locator no.", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LocDisplay()
        {
            try
            {
                conn.SetConstr();
                SQL = "select LocNo as `No.`,DepartureTime as `Departure Time`,DepartureDate as `Departure Date`,Destination,Reason,ExpectedTime as `Expected Time`,ExpectedDate as `Expected Date`,ActualTime as `Actual Time`,ApprovedAs as `Approved as`,MinUse as `Minutes Used`,Equivalent from tblslip where LocNo=@LocNo";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@LocNo", MySqlDbType.VarChar).Value = txtLocNo.Text;
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
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select LocNo as `No.`,DepartureTime as `Departure Time`,DepartureDate as `Departure Date`,Destination,Reason,ExpectedTime as `Expected Time`,ExpectedDate as `Expected Date`,ActualTime as `Actual Time`,ApprovedAs as `Approved as`,MinUse as `Minutes Used`,Equivalent from tblslip where EmpID=@EmpID";
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
        void SearchEmp()
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
                        txtDestination.Clear();
                        txtEmpID.Clear();
                        txtEquivalent.Clear();
                        txtLocNo.Clear();
                        txtMinUsed.Clear();
                        txtName.Clear();
                        txtReasons.Clear();

                        dtpDdate.Value = DateTime.Now;
                        dtpDtime.Value = DateTime.Now;
                        dtpEdate.Value = DateTime.Now;
                        dtpEtime.Value = DateTime.Now;

                        cbOfficial.Checked = false;
                        cbPersonal.Checked = false;
                        txtSearch.Focus();

                        MessageBox.Show("Employee does not exist.", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        txtDestination.Clear();
                        txtEmpID.Clear();
                        txtEquivalent.Clear();
                        txtLocNo.Clear();
                        txtMinUsed.Clear();
                        txtName.Clear();
                        txtReasons.Clear();

                        dtpDdate.Value = DateTime.Now;
                        dtpDtime.Value = DateTime.Now;
                        dtpEdate.Value = DateTime.Now;
                        dtpEtime.Value = DateTime.Now;

                        cbOfficial.Checked = false;
                        cbPersonal.Checked = false;
                        txtSearch.Focus();

                        MessageBox.Show("Employee does not exist.", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        txtDestination.Clear();
                        txtEmpID.Clear();
                        txtEquivalent.Clear();
                        txtLocNo.Clear();
                        txtMinUsed.Clear();
                        txtName.Clear();
                        txtReasons.Clear();

                        dtpDdate.Value = DateTime.Now;
                        dtpDtime.Value = DateTime.Now;
                        dtpEdate.Value = DateTime.Now;
                        dtpEtime.Value = DateTime.Now;

                        cbOfficial.Checked = false;
                        cbPersonal.Checked = false;
                        txtSearch.Focus();

                        MessageBox.Show("Employee does not exist.", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        txtDestination.Clear();
                        txtEmpID.Clear();
                        txtEquivalent.Clear();
                        txtLocNo.Clear();
                        txtMinUsed.Clear();
                        txtName.Clear();
                        txtReasons.Clear();

                        dtpDdate.Value = DateTime.Now;
                        dtpDtime.Value = DateTime.Now;
                        dtpEdate.Value = DateTime.Now;
                        dtpEtime.Value = DateTime.Now;

                        cbOfficial.Checked = false;
                        cbPersonal.Checked = false;
                        txtSearch.Focus();

                        MessageBox.Show("Employee does not exist.", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        txtDestination.Clear();
                        txtEmpID.Clear();
                        txtEquivalent.Clear();
                        txtLocNo.Clear();
                        txtMinUsed.Clear();
                        txtName.Clear();
                        txtReasons.Clear();

                        dtpDdate.Value = DateTime.Now;
                        dtpDtime.Value = DateTime.Now;
                        dtpEdate.Value = DateTime.Now;
                        dtpEtime.Value = DateTime.Now;

                        cbOfficial.Checked = false;
                        cbPersonal.Checked = false;
                        txtSearch.Focus();

                        MessageBox.Show("Employee does not exist.", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        txtDestination.Clear();
                        txtEmpID.Clear();
                        txtEquivalent.Clear();
                        txtLocNo.Clear();
                        txtMinUsed.Clear();
                        txtName.Clear();
                        txtReasons.Clear();

                        dtpDdate.Value = DateTime.Now;
                        dtpDtime.Value = DateTime.Now;
                        dtpEdate.Value = DateTime.Now;
                        dtpEtime.Value = DateTime.Now;

                        cbOfficial.Checked = false;
                        cbPersonal.Checked = false;
                        txtSearch.Focus();

                        MessageBox.Show("Employee does not exist.", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Locator No.")
                {

                    SearchLocNo();
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
            SearchEmp();
        }

        private void lstEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedIndex != -1)
            {
                txtEmpID.Text = lstEmployee.SelectedValue.ToString();
                txtName.Text = lstEmployee.Text;
                Display();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text != "")
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                Transaction = "New";
                txtDestination.Clear();
                txtEquivalent.Clear();
                txtLocNo.Clear();
                txtMinUsed.Clear();
                txtReasons.Clear();
                dtpDdate.Value = DateTime.Now;
                dtpDtime.Value = DateTime.Now;
                dtpEdate.Value = DateTime.Now;
                dtpEtime.Value = DateTime.Now;
                cbOfficial.Checked = false;
                cbPersonal.Checked = false;
                txtLocNo.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                Transaction = "Edit";

                dgvList.Enabled = false;

                txtDestination.Text = dgvList.SelectedRows[0].Cells["Destination"].Value.ToString();
                txtEquivalent.Text = dgvList.SelectedRows[0].Cells["Equivalent"].Value.ToString();
                txtLocNo.Text = dgvList.SelectedRows[0].Cells["No."].Value.ToString();
                txtMinUsed.Text = dgvList.SelectedRows[0].Cells["Minutes Used"].Value.ToString();
                txtReasons.Text = dgvList.SelectedRows[0].Cells["Reason"].Value.ToString();
                dtpDdate.Text = dgvList.SelectedRows[0].Cells["Departure Date"].Value.ToString();
                dtpDtime.Text = dgvList.SelectedRows[0].Cells["Departure Time"].Value.ToString();
                dtpEdate.Text = dgvList.SelectedRows[0].Cells["Expected Date"].Value.ToString();
                dtpEtime.Text = dgvList.SelectedRows[0].Cells["Expected Time"].Value.ToString();

                if (dgvList.SelectedRows[0].Cells["Approved as"].Value.ToString() == "Personal/Official")
                {
                    cbPersonal.Checked = true;
                    cbOfficial.Checked = true;
                }
                else if (dgvList.SelectedRows[0].Cells["Approved as"].Value.ToString() == "Personal")
                {
                    cbPersonal.Checked = true;
                }
                else if (dgvList.SelectedRows[0].Cells["Approved as"].Value.ToString() == "Official")
                {
                    cbOfficial.Checked = true;
                }
                else
                {
                    cbOfficial.Checked = false;
                    cbPersonal.Checked = false;
                }
                txtLocNo.Enabled = false;
                dtpDtime.Focus();
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

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (UserDetails.EPLS == "1")
                {
                    btnEdit.Enabled = true;
                }
                if (UserDetails.DPLS == "1")
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnArrival_Click(object sender, EventArgs e)
        {
            if (Arriv.Visible == false)
            {
                if (UserDetails.EPLS == "1")
                {
                    Arriv = new frmArrival();
                    Arriv.Show();
                }
            }
        }

        private void frmLS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Arriv.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Transaction == "New" || Transaction == "Edit")
            {
                txtDestination.Clear();
                txtEquivalent.Clear();
                txtLocNo.Clear();
                txtMinUsed.Clear();
                txtReasons.Clear();
                dtpActualTime.Value = DateTime.Now;
                dtpDdate.Value = DateTime.Now;
                dtpDtime.Value = DateTime.Now;
                dtpEdate.Value = DateTime.Now;
                dtpEtime.Value = DateTime.Now;
                cbOfficial.Checked = false;
                cbPersonal.Checked = false;
                txtLocNo.Enabled = true;
                dgvList.Enabled = true;
                if (UserDetails.APLS == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                txtDestination.Clear();
                txtEquivalent.Clear();
                txtLocNo.Clear();
                txtMinUsed.Clear();
                txtReasons.Clear();
                txtLocNo.Enabled = true;
                dtpActualTime.Value = DateTime.Now;
                dtpDdate.Value = DateTime.Now;
                dtpDtime.Value = DateTime.Now;
                dtpEdate.Value = DateTime.Now;
                dtpEtime.Value = DateTime.Now;
                cbOfficial.Checked = false;
                cbPersonal.Checked = false;
                dgvList.Enabled = true;
                txtName.Clear();
                txtEmpID.Clear();
                lstEmployee.DataSource = null;
                dgvList.DataSource = null;
                txtSearch.Focus();
                if (UserDetails.APLS == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void dtpActualTime_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbPersonal.Checked == true)
                {
                    DateTime ActualTime = dtpActualTime.Value;
                    DateTime DepartureTime = dtpDtime.Value;
                    DateTime ArrivalTime = dtpEtime.Value;
                    double minused = Math.Truncate((ActualTime - DepartureTime).TotalMinutes);
                    double equivalent = minused / 480;
                    txtMinUsed.Text = minused.ToString();
                    txtEquivalent.Text = equivalent.ToString();
                }
                else if (cbOfficial.Checked == true)
                {
                    DateTime ActualTime = dtpActualTime.Value;
                    DateTime DepartureTime = dtpDtime.Value;
                    DateTime ArrivalTime = dtpEtime.Value;
                    double minused = Math.Truncate((ActualTime - DepartureTime).TotalMinutes);
                    txtMinUsed.Text = minused.ToString();
                    txtEquivalent.Text = "0";
                }
                else
                {
                    txtEquivalent.Text = "0";
                }
            }
            catch
            {
            }
        }
        void SearchLocNo()
        {
            try
            {
                string EmpID = "";
                conn.SetConstr();
                SQL = "select LocNo as `No.`,DepartureTime as `Departure Time`,DepartureDate as `Departure Date`,Destination,Reason,ExpectedTime as `Expected Time`,ExpectedDate as `Expected Date`,ActualTime as `Actual Time`,ApprovedAs as `Approved as`,MinUse as `Minutes Used`,Equivalent from tblslip where LocNo=@LocNo";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@LocNo", MySqlDbType.VarChar).Value = txtSearch.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    dgvList.DataSource = dt;
                    DataRow dr = dt.Rows[0];
                    SQL = "select * from tblslip where LocNo=@LocNo";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@LocNo", MySqlDbType.VarChar).Value = dr["No."].ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow drE = dt.Rows[0];
                        EmpID = drE["EmpID"].ToString();
                    }
                }
                else
                {
                    dgvList.DataSource = null;
                    EmpID = "";
                    MessageBox.Show("Locator no. does not yet issued to any personnel", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tblpi where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtEmpID.Text = dr["EmpID"].ToString();
                    txtName.Text = dr["Name"].ToString();
                }
                else
                {
                    txtEmpID.Clear();
                    txtName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void DeleteD()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Locator Slip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvList.Rows.Count != 0)
                    {
                        conn.SetConstr();
                        SQL = "delete from tblslip where LocNo=@LocNo";
                        da = new MySqlDataAdapter();
                        da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.DeleteCommand.Parameters.Add("@LocNo", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["No."].Value.ToString();
                        Connection.Conn.Open();
                        da.DeleteCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Succesfully deleted record", "Locator Slip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (lstEmployee.DataSource != null)
                        {
                            Display();
                        }
                        else
                        {
                            LocDisplay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                DeleteD();
            }
        }

        private void frmLS_Load(object sender, EventArgs e)
        {
            if (UserDetails.APLS == "1")
            {
                btnNew.Enabled = true;
            }
        }
    }
}
