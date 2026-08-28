using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql .Data.MySqlClient;

namespace HRMIS_Solano
{
    public partial class frmMinUsed : Form
    {
        public frmMinUsed()
        {
            InitializeComponent();
        }
        string SQL;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator - Minutes Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Focus();
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator - Minutes Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Focus();
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator - Minutes Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Focus();
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator - Minutes Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Focus();
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator - Minutes Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Focus();
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator - Minutes Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Focus();
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
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))as Name,c.Department as Office,a.DepartureTime as `Departure Time`,a.ExpectedTime as `Expected Time`,a.ActualTime as `Actual Time`,a.MinUse as `Minutes Used`,a.Equivalent,a.ApprovedAs as `Approved As`,a.Destination from tblslip a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DepartureDate>=@DepartureDateFrom and a.DepartureDate<=@DepartureDateTo and a.EmpID=@EmpID and a.ApprovedAs='Personal' order by concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@DepartureDateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DepartureDateTo", MySqlDbType.Date).Value = dtpTo.Value;
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
        void GetTotal()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))as Name,c.Department as Office,a.DepartureTime,a.ExpectedTime,a.ActualTime,sum(a.MinUse)as Total,a.Equivalent,a.ApprovedAs,a.Destination from tblslip a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DepartureDate>=@DepartureDateFrom and a.DepartureDate<=@DepartureDateTo and a.EmpID=@EmpID and a.ApprovedAs='Personal'  group by a.EmpID order by concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@DepartureDateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DepartureDateTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtMinused.Text = dr["Total"].ToString();
                }
                else
                {
                    txtMinused.Clear();
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
                txtEmpID.Text = lstEmployee.SelectedValue.ToString();
                txtName.Text = lstEmployee.Text;
                Display();
                GetTotal();
            }
        }
    }
}
