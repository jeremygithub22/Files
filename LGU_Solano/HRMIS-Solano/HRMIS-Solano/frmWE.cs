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
    public partial class frmWE : Form
    {
        public frmWE()
        {
            InitializeComponent();
        }
        string SQL, Transaction, WEID, From, To, Position, Department, MonthlySalary, SG, Status, Gov;
        public string EmpID;
        Connection conn = new Connection();
        DataTable dt;
        MySqlDataAdapter da;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Work Experience", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblwe(EmpID,`From`,`To`,Position,Department,MonthlySalary,SG,Status,Gov)values(@EmpID,@From,@To,@Position,@Department,@MonthlySalary,@SG,@Status,@Gov)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.InsertCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.InsertCommand.Parameters.Add("@Position", MySqlDbType.VarChar).Value = txtPosition.Text;
                        da.InsertCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = txtDepartment.Text;
                        da.InsertCommand.Parameters.Add("@MonthlySalary", MySqlDbType.VarChar).Value = txtMonthlySalary.Text;
                        da.InsertCommand.Parameters.Add("@SG", MySqlDbType.VarChar).Value = txtSalaryGrade.Text;
                        da.InsertCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = cboStatus.Text;
                        da.InsertCommand.Parameters.Add("@Gov", MySqlDbType.VarChar).Value = cboGovtServ.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Work Experience", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtDepartment.Clear();
                        txtFrom.Clear();
                        txtMonthlySalary.Clear();
                        txtPosition.Clear();
                        txtSalaryGrade.Clear();
                        txtTo.Clear();
                        cboGovtServ.ResetText();
                        cboStatus.ResetText();

                        Display();
                        dgvList.Enabled = true;
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Work Experience", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (WEID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblwe set `From`=@From,`To`=@To,Position=@Position,Department=@Department,MonthlySalary=@MonthlySalary,SG=@SG,Status=@Status,Gov=@Gov where EmpID=@EmpID and WEID=@WEID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.UpdateCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.UpdateCommand.Parameters.Add("@Position", MySqlDbType.VarChar).Value = txtPosition.Text;
                        da.UpdateCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = txtDepartment.Text;
                        da.UpdateCommand.Parameters.Add("@MonthlySalary", MySqlDbType.VarChar).Value = txtMonthlySalary.Text;
                        da.UpdateCommand.Parameters.Add("@SG", MySqlDbType.VarChar).Value = txtSalaryGrade.Text;
                        da.UpdateCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = cboStatus.Text;
                        da.UpdateCommand.Parameters.Add("@Gov", MySqlDbType.VarChar).Value = cboGovtServ.Text;
                        da.UpdateCommand.Parameters.Add("@WEID", MySqlDbType.VarChar).Value = WEID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Work Experience", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        Display();
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
                SQL = "select * from tblwe where EmpID=@EmpID and `From`=@From and `To`=@To and Position=@Position and Department=@Department and MonthlySalary=@MonthlySalary and SG=@SG and Status=@Status and Gov=@Gov";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                da.SelectCommand.Parameters.Add("@Position", MySqlDbType.VarChar).Value = txtPosition.Text;
                da.SelectCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = txtDepartment.Text;
                da.SelectCommand.Parameters.Add("@MonthlySalary", MySqlDbType.VarChar).Value = txtMonthlySalary.Text;
                da.SelectCommand.Parameters.Add("@SG", MySqlDbType.VarChar).Value = txtSalaryGrade.Text;
                da.SelectCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = cboStatus.Text;
                da.SelectCommand.Parameters.Add("@Gov", MySqlDbType.VarChar).Value = cboGovtServ.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    WEID = dr["WEID"].ToString();
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
                SQL = "select * from tblwe where EmpID=@EmpID and `From`=@From and `To`=@To and Position=@Position and Department=@Department and MonthlySalary=@MonthlySalary and SG=@SG and Status=@Status and Gov=@Gov";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["To"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Position", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Position"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Department"].Value.ToString();
                da.SelectCommand.Parameters.Add("@MonthlySalary", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Monthly Salary"].Value.ToString();
                da.SelectCommand.Parameters.Add("@SG", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Salary Grade"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Status"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Gov", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Gov"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    WEID = dr["WEID"].ToString();
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
                if (WEID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblwe where WEID=@WEID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@WEID", MySqlDbType.VarChar).Value = WEID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Work Experience", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SQL = "select `From`,`To`,Position,Department,MonthlySalary as `Monthly Salary`,SG as `Salary Grade`,Status,Gov from tblwe where EmpID=@EmpID order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc";
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

        private void frmWE_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            Transaction = "New";

            txtDepartment.Clear();
            txtFrom.Clear();
            txtMonthlySalary.Clear();
            txtPosition.Clear();
            txtSalaryGrade.Clear();
            cboGovtServ.ResetText();
            cboStatus.ResetText();
            txtFrom.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                Transaction = "Edit";

                txtDepartment.Text = dgvList.SelectedRows[0].Cells["Department"].Value.ToString();
                txtFrom.Text = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                txtMonthlySalary.Text = dgvList.SelectedRows[0].Cells["Monthly Salary"].Value.ToString();
                txtPosition.Text = dgvList.SelectedRows[0].Cells["Position"].Value.ToString();
                txtSalaryGrade.Text = dgvList.SelectedRows[0].Cells["Salary Grade"].Value.ToString();
                txtTo.Text = dgvList.SelectedRows[0].Cells["To"].Value.ToString();
                cboGovtServ.Text = dgvList.SelectedRows[0].Cells["Gov"].Value.ToString();
                cboStatus.Text = dgvList.SelectedRows[0].Cells["Status"].Value.ToString();

                Department = txtDepartment.Text;
                From = txtFrom.Text;
                MonthlySalary = txtMonthlySalary.Text;
                Position = txtPosition.Text;
                SG = txtSalaryGrade.Text;
                To = txtTo.Text;
                Gov = cboGovtServ.Text;
                Status = cboStatus.Text;

                GetID();

                dgvList.Enabled = false;
                txtFrom.Focus();
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
                txtDepartment.Clear();
                txtFrom.Clear();
                txtMonthlySalary.Clear();
                txtPosition.Clear();
                txtSalaryGrade.Clear();
                txtTo.Clear();
                cboGovtServ.ResetText();
                cboStatus.ResetText();

                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;

                txtFrom.Focus();
                dgvList.Enabled = true;
            }
            else if (Transaction == "Edit")
            {
                txtDepartment.Text = Department;
                txtFrom.Text = From;
                txtMonthlySalary.Text = MonthlySalary;
                txtPosition.Text = Position;
                txtSalaryGrade.Text = SG;
                txtTo.Text = To;
                cboGovtServ.Text = Gov;
                cboStatus.Text = Status;

                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                txtFrom.Focus();
                dgvList.Enabled = false;
            }
            else
            {
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
                if (MessageBox.Show("Are you sure, you want to delete this record", "Work Experience", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    DelData();
                }
            }
        }
    }
}
