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
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace HRMIS_Solano
{
    public partial class frmFCreport : Form
    {
        public frmFCreport()
        {
            InitializeComponent();
        }
        string SQL, path, pName, pPos, cName, cPos, nName, nPos, Time;
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
                nName = sr.ReadLine();
                nPos = sr.ReadLine();
                sr.Close();
            }
            catch
            {
            }
        }
        void LoadCS()
        {
            try
            {
                path = c.FileSystem.SpecialDirectories.ProgramFiles + @"\HRMIS Config\CS";
                StreamReader sr = new StreamReader(path);
                Time = sr.ReadLine();
                Time = sr.ReadLine();
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
                        MessageBox.Show("Employee does not exist.", "Flag Ceremony Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Flag Ceremony Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Flag Ceremony Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Flag Ceremony Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "All")
                {
                    DisplayAll();
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
            txtSearch.Focus();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }
        void perDisplay()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',b.Middlename)as Name,c.Department as Office,a.DateRec,a.TimeArriv,a.Remarks from tblflag a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.EmpID=@EmpID and a.DateRec>=@DFrom and a.DateRec<=@DTo order by a.DateRec asc,concat(b.Surname,', ',b.Firstname,' ',b.Middlename) asc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblflag.Clear();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                da.SelectCommand.Parameters.Add("@DFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.Fill(dsReports.tblflag);
                Connection.Conn.Close();
                if (dsReports.tblflag.Count != 0)
                {
                    LoadSet();
                    LoadCS();
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

                    ReportParameter notedn = new ReportParameter("Nname", nName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notedn });
                    ReportParameter notedp = new ReportParameter("Npos", nPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notedp });

                    ReportParameter TE = new ReportParameter("TE", Time);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { TE });

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
        void perDept()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',b.Middlename)as Name,c.Department as Office,a.DateRec,a.TimeArriv,a.Remarks from tblflag a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where c.Department=@Department and a.DateRec>=@DFrom and a.DateRec<=@DTo order by a.DateRec asc,concat(b.Surname,', ',b.Firstname,' ',b.Middlename) asc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblflag.Clear();
                da.SelectCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = txtSearch.Text;
                da.SelectCommand.Parameters.Add("@DFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.Fill(dsReports.tblflag);
                Connection.Conn.Close();
                if (dsReports.tblflag.Count != 0)
                {
                    LoadSet();
                    LoadCS();
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

                    ReportParameter notedn = new ReportParameter("Nname", nName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notedn });
                    ReportParameter notedp = new ReportParameter("Npos", nPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notedp });

                    ReportParameter TE = new ReportParameter("TE", Time);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { TE });

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
        void DisplayAll()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',b.Middlename)as Name,c.Department as Office,a.DateRec,a.TimeArriv,a.Remarks from tblflag a left join tblpi b on a.EmpID=b.EmpID left join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we group by EmpID) c on a.EmpID=c.EmpID where a.DateRec>=@DFrom and a.DateRec<=@DTo order by a.DateRec asc,concat(b.Surname,', ',b.Firstname,' ',b.Middlename) asc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblflag.Clear();
                da.SelectCommand.Parameters.Add("@DFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                da.SelectCommand.Parameters.Add("@DTo", MySqlDbType.Date).Value = dtpTo.Value;
                da.Fill(dsReports.tblflag);
                Connection.Conn.Close();
                if (dsReports.tblflag.Count != 0)
                {
                    LoadSet();
                    LoadCS();
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

                    ReportParameter notedn = new ReportParameter("Nname", nName);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notedn });
                    ReportParameter notedp = new ReportParameter("Npos", nPos);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { notedp });

                    ReportParameter TE = new ReportParameter("TE", Time);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { TE });
                    
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tblflag.Rows.Count != 0)
            {
                frmAddFC.rv = rvDisplay;
                frmAddFC fc = new frmAddFC();
                fc.ShowDialog();
            }
        }
    }
}
