using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace HRMIS_Solano
{
    public partial class frmALReport : Form
    {
        public frmALReport()
        {
            InitializeComponent();
        }
        string SQL, pName, pPos, cName, cPos, path;
        Computer c = new Computer();
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
        void LoadSet()
        {
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\OIS";
                StreamReader sr = new StreamReader(path);
                pName = sr.ReadLine();
                pPos = sr.ReadLine();
                cName = sr.ReadLine();
                cPos = sr.ReadLine();
                sr.Close();
            }
            catch
            {
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
                        MessageBox.Show("Employee does not exist.", "Application for Leave Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Application for Leave Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Firstname")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tblpi where Firstname=@Firstname order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("Firstname", MySqlDbType.VarChar).Value = txtSearch.Text;
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
                        MessageBox.Show("Employee does not exist.", "Application for Leave Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Application for Leave Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Application for Leave Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Application for Leave Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Record No.")
                {
                    SRecNo();
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
        void SRecNo()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblleaverecord where RecNo=@RecNo";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblleaverecord.Clear();
                da.SelectCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = txtSearch.Text;
                da.Fill(dsReports.tblleaverecord);
                Connection.Conn.Close();
                if (dsReports.tblleaverecord.Rows.Count != 0)
                {
                    LoadSet();
                    DataRow dr = dsReports.tblleaverecord.Rows[0];
                    SQL = "select * from tblpi where EmpID=@EmpID";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblpi.Clear();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = dr["EmpID"].ToString();
                    da.Fill(dsReports.tblpi);
                    Connection.Conn.Close();
                    SQL = "select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where EmpID=@EmpID group by EmpID";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblwe.Clear();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = dr["EmpID"].ToString();
                    da.Fill(dsReports.tblwe);
                    Connection.Conn.Close();
                    SQL = "select * from tblleavecredits where RecNo=@RecNo";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblleavecredits.Clear();
                    da.SelectCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = dr["RecNo"].ToString();
                    da.Fill(dsReports.tblleavecredits);
                    Connection.Conn.Close();

                    if (dr["SPL"].ToString() == "XXX")
                    {
                        ReportParameter SPL = new ReportParameter("SPL", dr["SPL"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { SPL });
                    }
                    else if (dr["Bday"].ToString() == "XXX")
                    {
                        ReportParameter Bday = new ReportParameter("SPL", dr["Bday"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Bday });
                    }
                    else if (dr["Enrollment"].ToString() == "XXX")
                    {
                        ReportParameter Enrollment = new ReportParameter("SPL", dr["Enrollment"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Enrollment });
                    }
                    else if (dr["Anniversary"].ToString() == "XXX")
                    {
                        ReportParameter Anniversary = new ReportParameter("SPL", dr["Anniversary"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Anniversary });
                    }
                    else if (dr["Mourning"].ToString() == "XXX")
                    {
                        ReportParameter Mourning = new ReportParameter("SPL", dr["Mourning"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Mourning });
                    }
                    else if (dr["Solo"].ToString() == "XXX")
                    {
                        ReportParameter Solo = new ReportParameter("SPL", dr["Solo"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Solo });
                    }
                    else
                    {
                        ReportParameter Nodata = new ReportParameter("SPL", "");
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Nodata });
                    }

                    ReportParameter prepn = new ReportParameter("Pname", pName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                    ReportParameter prepp = new ReportParameter("Ppos", pPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                    ReportParameter certn = new ReportParameter("Cname", cName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                    ReportParameter certp = new ReportParameter("Cpos", cPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

                    rvDisplay.SetDisplayMode(DisplayMode.PrintLayout);
                    rvDisplay.ZoomMode = ZoomMode.Percent;
                    rvDisplay.ZoomPercent = 100;
                    rvDisplay.RefreshReport();
                }
                else
                {
                    rvDisplay.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ListDates()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblleaverecord where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    lstDates.DisplayMember = "RecDate";
                    lstDates.ValueMember = "RecNo";
                    lstDates.DataSource = dt;
                }
                else
                {
                    lstDates.DataSource = null;
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
                SQL = "select * from tblleaverecord where RecNo=@RecNo";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblleaverecord.Clear();
                da.SelectCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = lstDates.SelectedValue.ToString();
                da.Fill(dsReports.tblleaverecord);
                Connection.Conn.Close();
                if (dsReports.tblleaverecord.Rows.Count!=0)
                {
                    LoadSet();
                    DataRow dr = dsReports.tblleaverecord.Rows[0];
                    SQL = "select * from tblpi where EmpID=@EmpID";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblpi.Clear();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = dr["EmpID"].ToString();
                    da.Fill(dsReports.tblpi);
                    Connection.Conn.Close();
                    SQL = "select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where EmpID=@EmpID group by EmpID";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblwe.Clear();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = dr["EmpID"].ToString();
                    da.Fill(dsReports.tblwe);
                    Connection.Conn.Close();
                    SQL = "select * from tblleavecredits where RecNo=@RecNo";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblleavecredits.Clear();
                    da.SelectCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = dr["RecNo"].ToString();
                    da.Fill(dsReports.tblleavecredits);
                    Connection.Conn.Close();

                    if (dr["SPL"].ToString() == "XXX")
                    {
                        ReportParameter SPL = new ReportParameter("SPL", dr["SPL"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { SPL });
                    }
                    else if (dr["Bday"].ToString() == "XXX")
                    {
                        ReportParameter Bday = new ReportParameter("SPL", dr["Bday"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Bday });
                    }
                    else if (dr["Enrollment"].ToString() == "XXX")
                    {
                        ReportParameter Enrollment = new ReportParameter("SPL", dr["Enrollment"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Enrollment });
                    }
                    else if (dr["Anniversary"].ToString() == "XXX")
                    {
                        ReportParameter Anniversary = new ReportParameter("SPL", dr["Anniversary"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Anniversary });
                    }
                    else if (dr["Mourning"].ToString() == "XXX")
                    {
                        ReportParameter Mourning = new ReportParameter("SPL", dr["Mourning"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Mourning });
                    }
                    else if (dr["Solo"].ToString() == "XXX")
                    {
                        ReportParameter Solo = new ReportParameter("SPL", dr["Solo"].ToString());
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Solo });
                    }
                    else
                    {
                        ReportParameter Nodata = new ReportParameter("SPL", "");
                        rvDisplay.LocalReport.SetParameters(new ReportParameter[] { Nodata });
                    }
                    ReportParameter prepn = new ReportParameter("Pname", pName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                    ReportParameter prepp = new ReportParameter("Ppos", pPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                    ReportParameter certn = new ReportParameter("Cname", cName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                    ReportParameter certp = new ReportParameter("Cpos", cPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

                    rvDisplay.SetDisplayMode(DisplayMode.PrintLayout);
                    rvDisplay.ZoomMode = ZoomMode.Percent;
                    rvDisplay.ZoomPercent = 100;
                    rvDisplay.RefreshReport();
                }
                else
                {
                    rvDisplay.Clear();
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
                ListDates();
            }
        }

        private void lstDates_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstDates.SelectedIndex != -1)
            {
                Display();
            }
            else
            {
                rvDisplay.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tblleaverecord.Count != 0)
            {
                frmAOIL add = new frmAOIL();
                add.rv = rvDisplay;
                add.ShowDialog();
            }
        }
    }
}
