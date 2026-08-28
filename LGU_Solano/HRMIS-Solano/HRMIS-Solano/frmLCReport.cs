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
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace HRMIS_Solano
{
    public partial class frmLCReport : Form
    {
        public frmLCReport()
        {
            InitializeComponent();
        }
        string SQL, path, pName, pPos, cName, cPos;
        Computer c = new Computer();
        Connection conn = new Connection();
        DataTable dt;
        MySqlDataAdapter da;
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.DisplayMember = "Middlename";
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = null;
                        MessageBox.Show("Employee does not exist.", "Leave Credits Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SQL = "select * from tblpi where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblpi.Clear();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                da.Fill(dsReports.tblpi);
                Connection.Conn.Close();
                if (dsReports.tblpi.Rows.Count != 0)
                {
                    LoadSet();
                    string DayService, Vearned, Searned, Vused, Sused, SLP, TardyUnder, Total;
                    SQL = "select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we  where EmpID=@EmpID group by EmpID";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblwe.Clear();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dsReports.tblwe);
                    Connection.Conn.Close();

                    SQL = "select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) asc,month(str_to_date(`From`,'%m/%d/%Y')) asc,day(str_to_date(`From`,'%m/%d/%Y')) asc)we  where EmpID=@EmpID group by EmpID";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        DayService = dr["From"].ToString();
                    }
                    else
                    {
                        DayService = string.Empty;
                    }

                    SQL = "select * from tblleavecredits where DateRec>=@DateFrom and DateRec<=@DateTo and EmpID=@EmpID order by year(DateRec) asc,month(DateRec) asc,day(DateRec) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblleavecredits.Clear();
                    da.SelectCommand.Parameters.Add("@DateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dsReports.tblleavecredits);
                    Connection.Conn.Close();

                    SQL = "select sum(Vearned)as Total from tblleavecredits where DateRec>=@DateFrom and DateRec<=@DateTo and EmpID=@EmpID group by EmpID order by year(DateRec) asc,month(DateRec) asc,day(DateRec) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@DateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Vearned = dr["Total"].ToString();
                    }
                    else
                    {
                        Vearned = string.Empty;
                    }


                    SQL = "select sum(Searned)as Total from tblleavecredits where DateRec>=@DateFrom and DateRec<=@DateTo and EmpID=@EmpID group by EmpID order by year(DateRec) asc,month(DateRec) asc,day(DateRec) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@DateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Searned = dr["Total"].ToString();
                    }
                    else
                    {
                        Searned = string.Empty;
                    }

                    SQL = "select sum(Vused)as Total from tblleavecredits where DateRec>=@DateFrom and DateRec<=@DateTo and EmpID=@EmpID group by EmpID order by year(DateRec) asc,month(DateRec) asc,day(DateRec) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@DateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Vused = dr["Total"].ToString();
                    }
                    else
                    {
                        Vused = string.Empty;
                    }

                    SQL = "select sum(Sused)as Total from tblleavecredits where DateRec>=@DateFrom and DateRec<=@DateTo and EmpID=@EmpID group by EmpID order by year(DateRec) asc,month(DateRec) asc,day(DateRec) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@DateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Sused = dr["Total"].ToString();
                    }
                    else
                    {
                        Sused = string.Empty;
                    }

                    SQL = "select sum(SLP)as Total from tblleavecredits where DateRec>=@DateFrom and DateRec<=@DateTo and EmpID=@EmpID group by EmpID order by year(DateRec) asc,month(DateRec) asc,day(DateRec) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@DateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        SLP = dr["Total"].ToString();
                    }
                    else
                    {
                        SLP = string.Empty;
                    }

                    SQL = "select sum(TardyUnder)as Total from tblleavecredits where DateRec>=@DateFrom and DateRec<=@DateTo and EmpID=@EmpID group by EmpID order by year(DateRec) asc,month(DateRec) asc,day(DateRec) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@DateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        TardyUnder = dr["Total"].ToString();
                    }
                    else
                    {
                        TardyUnder = string.Empty;
                    }

                    SQL = "select * from tblleavecredits where DateRec>=@DateFrom and DateRec<=@DateTo and EmpID=@EmpID order by LCIDNo desc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@DateFrom", MySqlDbType.Date).Value = dtpFrom.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", MySqlDbType.Date).Value = dtpTo.Value;
                    da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Total = dr["Total"].ToString();
                    }
                    else
                    {
                        Total = string.Empty;
                    }

                    ReportParameter FirstDay = new ReportParameter("DayService", DayService);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { FirstDay });
                    ReportParameter EV = new ReportParameter("EV", Vearned);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { EV });
                    ReportParameter ES = new ReportParameter("ES", Searned);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { ES });
                    ReportParameter UV = new ReportParameter("UV", Vused);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { UV });
                    ReportParameter US = new ReportParameter("US", Sused);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { US });
                    ReportParameter SLP1 = new ReportParameter("SLP", SLP);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { SLP1 });
                    ReportParameter TU = new ReportParameter("TU", TardyUnder);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { TU });
                    ReportParameter TotalL = new ReportParameter("TotalB", Total);
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { TotalL });
                    ReportParameter VYear = new ReportParameter("Vyear", dtpFrom.Value.Year.ToString());
                    rvDisplay.LocalReport.SetParameters(new ReportParameter[] { VYear });

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tblleavecredits.Count != 0)
            {
                frmLCrepAI ai = new frmLCrepAI();
                frmLCrepAI.rv = rvDisplay;
                ai.ShowDialog();
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
