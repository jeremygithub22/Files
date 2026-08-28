using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace HRMIS_Solano
{
    public partial class frmLSreport : Form
    {
        public frmLSreport()
        {
            InitializeComponent();
        }
        string SQL, pName, pPos, nName, nPos, cName, cPos, path;
        MySqlDataAdapter da;
        Computer c = new Computer();
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
                nName = sr.ReadLine();
                nPos = sr.ReadLine();
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
                        MessageBox.Show("Employee does not exist.", "Locator Slip Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Focus();
                    }
                }
                else if (cboSearchby.Text=="Surname")
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
                        MessageBox.Show("Employee does not exist.", "Locator Slip Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Locator Slip Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Locator Slip Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        void perDept()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))as Name,c.Department as Office,a.DepartureTime,a.ExpectedTime,a.ActualTime,a.MinUse,a.Reason,a.ApprovedAs,a.Destination from tblslip a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DepartureDate>=@DepartureDateFrom and a.DepartureDate<=@DepartureDateTo and c.Department=@Department order by concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblslip.Clear();
                da.SelectCommand.Parameters.Add("@DepartureDateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DepartureDateTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.SelectCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = txtSearch.Text;
                da.Fill(dsReports.tblslip);
                Connection.Conn.Close();
                if (dsReports.tblslip.Count != 0)
                {
                    LoadSet();
                    ReportParameter range = new ReportParameter("Daterange", dtpFrom.Value.ToShortDateString());
                    rvList.LocalReport.SetParameters(new ReportParameter[] { range });
                    ReportParameter range2 = new ReportParameter("Daterange2", dtpTo.Value.ToShortDateString());
                    rvList.LocalReport.SetParameters(new ReportParameter[] { range2 });

                    ReportParameter prepn = new ReportParameter("Pname", pName);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { prepn });
                    ReportParameter prepp = new ReportParameter("Ppos", pPos);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { prepp });

                    ReportParameter certn = new ReportParameter("Cname", cName);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { certn });
                    ReportParameter certp = new ReportParameter("Cpos", cPos);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { certp });

                    ReportParameter notedn = new ReportParameter("Nname", nName);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { notedn });
                    ReportParameter notedp = new ReportParameter("Npos", nPos);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { notedp });
                    
                    rvList.SetDisplayMode(DisplayMode.PrintLayout);
                    rvList.ZoomMode = ZoomMode.Percent;
                    rvList.ZoomPercent = 100;
                    rvList.RefreshReport();
                }
                else
                {
                    rvList.Clear();
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
                if (lstEmployee.DataSource != null)
                {
                    SQL = "select concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))as Name,c.Department as Office,a.DepartureTime,a.ExpectedTime,a.ActualTime,a.MinUse,a.Reason,a.ApprovedAs,a.Destination from tblslip a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DepartureDate>=@DepartureDateFrom and a.DepartureDate<=@DepartureDateTo and b.EmpID=@EmpID order by concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblslip.Clear();
                    da.SelectCommand.Parameters.Add("@DepartureDateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DepartureDateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dsReports.tblslip);
                    Connection.Conn.Close();
                    if (dsReports.tblslip.Count != 0)
                    {
                        LoadSet();
                        ReportParameter range = new ReportParameter("Daterange", dtpFrom.Value.ToShortDateString());
                        rvList.LocalReport.SetParameters(new ReportParameter[] { range });
                        ReportParameter range2 = new ReportParameter("Daterange2", dtpTo.Value.ToShortDateString());
                        rvList.LocalReport.SetParameters(new ReportParameter[] { range2 });

                        ReportParameter prepn = new ReportParameter("Pname", pName);
                        rvList.LocalReport.SetParameters(new ReportParameter[] { prepn });
                        ReportParameter prepp = new ReportParameter("Ppos", pPos);
                        rvList.LocalReport.SetParameters(new ReportParameter[] { prepp });

                        ReportParameter certn = new ReportParameter("Cname", cName);
                        rvList.LocalReport.SetParameters(new ReportParameter[] { certn });
                        ReportParameter certp = new ReportParameter("Cpos", cPos);
                        rvList.LocalReport.SetParameters(new ReportParameter[] { certp });

                        ReportParameter notedn = new ReportParameter("Nname", nName);
                        rvList.LocalReport.SetParameters(new ReportParameter[] { notedn });
                        ReportParameter notedp = new ReportParameter("Npos", nPos);
                        rvList.LocalReport.SetParameters(new ReportParameter[] { notedp });

                        rvList.SetDisplayMode(DisplayMode.PrintLayout);
                        rvList.ZoomMode = ZoomMode.Percent;
                        rvList.ZoomPercent = 100;
                        rvList.RefreshReport();
                    }
                    else
                    {
                        rvList.Clear();
                    }
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
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))as Name,c.Department as Office,a.DepartureTime,a.ExpectedTime,a.ActualTime,a.MinUse,a.Reason,a.ApprovedAs,a.Destination from tblslip a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DepartureDate>=@DepartureDateFrom and a.DepartureDate<=@DepartureDateTo order by concat(b.Surname,', ',b.Firstname,' ',concat(left(b.Middlename,1),'.'))";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblslip.Clear();
                da.SelectCommand.Parameters.Add("@DepartureDateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DepartureDateTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.Fill(dsReports.tblslip);
                Connection.Conn.Close();
                if (dsReports.tblslip.Count != 0)
                {
                    LoadSet();
                    ReportParameter range = new ReportParameter("Daterange", dtpFrom.Value.ToShortDateString());
                    rvList.LocalReport.SetParameters(new ReportParameter[] { range });
                    ReportParameter range2 = new ReportParameter("Daterange2", dtpTo.Value.ToShortDateString());
                    rvList.LocalReport.SetParameters(new ReportParameter[] { range2 });

                    ReportParameter prepn = new ReportParameter("Pname", pName);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { prepn });
                    ReportParameter prepp = new ReportParameter("Ppos", pPos);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { prepp });

                    ReportParameter certn = new ReportParameter("Cname", cName);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { certn });
                    ReportParameter certp = new ReportParameter("Cpos", cPos);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { certp });

                    ReportParameter notedn = new ReportParameter("Nname", nName);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { notedn });
                    ReportParameter notedp = new ReportParameter("Npos", nPos);
                    rvList.LocalReport.SetParameters(new ReportParameter[] { notedp });

                    rvList.SetDisplayMode(DisplayMode.PrintLayout);
                    rvList.ZoomMode = ZoomMode.Percent;
                    rvList.ZoomPercent = 100;
                    rvList.RefreshReport();
                }
                else
                {
                    rvList.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                perDisplay();
            }
                
        }

        private void cboSearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSearchby.Text != "All")
            {
                txtSearch.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tblslip.Count != 0)
            {
                frmAILSR lsr = new frmAILSR();
                frmAILSR.rv = rvList;
                lsr.ShowDialog();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
