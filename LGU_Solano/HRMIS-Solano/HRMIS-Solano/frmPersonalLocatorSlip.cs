using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.VisualBasic.Devices;
using Microsoft.Reporting.WinForms;

namespace HRMIS_Solano
{
    public partial class frmPersonalLocatorSlip : Form
    {
        public frmPersonalLocatorSlip()
        {
            InitializeComponent();
        }
        string SQL, pName, pPos, cName, cPos, nName, nPos, path;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        Computer c = new Computer();
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
                nName = sr.ReadLine();
                nPos = sr.ReadLine();
                sr.Close();
            }
            catch
            {
            }
        }
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))as Name,c.Department as `Office`,a.MinUse as TotalMU from tblslip a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DepartureDate>=@DepartureDateFrom and a.DepartureDate<=@DepartureDateTo and a.ApprovedAs='Personal' order by concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.')) asc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblpls.Clear();
                da.SelectCommand.Parameters.Add("@DepartureDateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DepartureDateTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.Fill(dsReports.tblpls);
                Connection.Conn.Close();
                if (dsReports.tblpls.Rows.Count != 0)
                {
                    LoadSet();
                    ReportParameter range = new ReportParameter("Daterange", dtpFrom.Value.ToShortDateString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range });
                    ReportParameter range2 = new ReportParameter("Daterange2", dtpTo.Value.ToShortDateString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range2 });

                    ReportParameter prepn = new ReportParameter("Pname", pName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                    ReportParameter prepp = new ReportParameter("Ppos", pPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                    ReportParameter certn = new ReportParameter("Cname", cName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                    ReportParameter certp = new ReportParameter("Cpos", cPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

                    ReportParameter noteb = new ReportParameter("Nname", nName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { noteb });
                    ReportParameter notep = new ReportParameter("Npos", nPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notep });

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
        void perDisplay()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))as Name,c.Department as `Office`,a.MinUse as TotalMU from tblslip a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DepartureDate>=@DepartureDateFrom and a.DepartureDate<=@DepartureDateTo and a.ApprovedAs='Personal' and b.EmpID=@EmpID order by concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.')) asc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblpls.Clear();
                da.SelectCommand.Parameters.Add("@DepartureDateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DepartureDateTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                da.Fill(dsReports.tblpls);
                Connection.Conn.Close();
                if (dsReports.tblpls.Rows.Count != 0)
                {
                    LoadSet();
                    ReportParameter range = new ReportParameter("Daterange", dtpFrom.Value.ToShortDateString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range });
                    ReportParameter range2 = new ReportParameter("Daterange2", dtpTo.Value.ToShortDateString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range2 });

                    ReportParameter prepn = new ReportParameter("Pname", pName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                    ReportParameter prepp = new ReportParameter("Ppos", pPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                    ReportParameter certn = new ReportParameter("Cname", cName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                    ReportParameter certp = new ReportParameter("Cpos", cPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

                    ReportParameter noteb = new ReportParameter("Nname", nName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { noteb });
                    ReportParameter notep = new ReportParameter("Npos", nPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notep });

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
        void perDept()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))as Name,c.Department as `Office`,a.MinUse as TotalMU from tblslip a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DepartureDate>=@DepartureDateFrom and a.DepartureDate<=@DepartureDateTo and a.ApprovedAs='Personal' and c.Department=@Department order by concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.')) asc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblpls.Clear();
                da.SelectCommand.Parameters.Add("@DepartureDateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DepartureDateTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.SelectCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = txtSearch.Text;
                da.Fill(dsReports.tblpls);
                Connection.Conn.Close();
                if (dsReports.tblpls.Rows.Count != 0)
                {
                    LoadSet();
                    ReportParameter range = new ReportParameter("Daterange", dtpFrom.Value.ToShortDateString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range });
                    ReportParameter range2 = new ReportParameter("Daterange2", dtpTo.Value.ToShortDateString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { range2 });

                    ReportParameter prepn = new ReportParameter("Pname", pName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepn });
                    ReportParameter prepp = new ReportParameter("Ppos", pPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { prepp });

                    ReportParameter certn = new ReportParameter("Cname", cName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certn });
                    ReportParameter certp = new ReportParameter("Cpos", cPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { certp });

                    ReportParameter noteb = new ReportParameter("Nname", nName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { noteb });
                    ReportParameter notep = new ReportParameter("Npos", nPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notep });

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
                        MessageBox.Show("Employee does not exist.", "Personal Locator Slip Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator Slip Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator Slip Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Personal Locator Slip Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Focus();
                    }
                }
                else if (cboSearchby.Text == "All")
                {
                    lstEmployee.DataSource = null;
                    Display();
                }
                else if (cboSearchby.Text == "Department")
                {
                    perDept();
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
            if (cboSearchby.Text != "All")
            {
                txtSearch.Focus();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tblpls.Rows.Count != 0)
            {
                frmAddFC fc = new frmAddFC();
                frmAddFC.rv = rvDisplay;
                fc.ShowDialog();
            }
        }

        private void lstEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedIndex != -1)
            {
                perDisplay();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
