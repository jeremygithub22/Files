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
    public partial class frmMasterlistR : Form
    {
        public frmMasterlistR()
        {
            InitializeComponent();
        }
        string SQL, pName, pPos, cName, cPos, path;
        Computer c = new Computer();
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
        DataRow dr;
        string[] Sgrade;
        int g;

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
        void LoadData()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))as Name,b.Position,b.Department,b.Status from tblpi a inner join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where we.`To`='Present' group by EmpID) b on a.EmpID=b.EmpID  order by concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dsReports.tblmlist.Clear();
                da.Fill(dsReports.tblmlist);
                Connection.Conn.Close();
                if (dsReports.tblmlist.Rows.Count != 0)
                {
                    LoadSet();

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
                MessageBox.Show(ex.ToString(),"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
                
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dsReports.tblmlist.Rows.Count != 0)
            {
                frmAddME.rv = rvDisplay;
                frmAddME me = new frmAddME();
                me.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        void Search()
        {
            try
            {
                conn.SetConstr();
                if (cboSearchby.Text == "Status of Appointment")
                {
                    SQL = "select concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))as Name,b.Position,b.Department,b.Status from tblpi a inner join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where we.`To`='Present' group by EmpID) b on a.EmpID=b.EmpID where b.Status=@Status order by concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblmlist.Clear();
                    da.SelectCommand.Parameters.Add("Status", MySqlDbType.VarChar).Value = txtStatus.Text;
                    da.Fill(dsReports.tblmlist);
                    Connection.Conn.Close();
                    if (dsReports.tblmlist.Rows.Count != 0)
                    {
                        LoadSet();

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
                else if (cboSearchby.Text == "Department")
                {
                    SQL = "select concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))as Name,b.Position,b.Department,b.Status from tblpi a inner join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where we.`To`='Present' group by EmpID) b on a.EmpID=b.EmpID where b.Department=@Department  order by concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblmlist.Clear();
                    da.SelectCommand.Parameters.Add("@Department", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dsReports.tblmlist);
                    Connection.Conn.Close();
                    if (dsReports.tblmlist.Rows.Count != 0)
                    {
                        LoadSet();

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
                else if (cboSearchby.Text == "Position")
                {
                    SQL = "select concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))as Name,b.Position,b.Department,b.Status from tblpi a inner join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where we.`To`='Present' group by EmpID) b on a.EmpID=b.EmpID where b.Position=@Position  order by concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblmlist.Clear();
                    da.SelectCommand.Parameters.Add("@Position", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dsReports.tblmlist);
                    Connection.Conn.Close();
                    if (dsReports.tblmlist.Rows.Count != 0)
                    {
                        LoadSet();

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
                else if (cboSearchby.Text == "Gender")
                {
                    SQL = "select concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))as Name,b.Position,b.Department,b.Status from tblpi a inner join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where we.`To`='Present' group by EmpID) b on a.EmpID=b.EmpID where a.Sex=@Sex and b.Status=@Status order by concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dsReports.tblmlist.Clear();
                    da.SelectCommand.Parameters.Add("@Sex", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.SelectCommand.Parameters.Add("@Status", MySqlDbType.VarChar).Value = txtStatus.Text;
                    da.Fill(dsReports.tblmlist);
                    Connection.Conn.Close();
                    if (dsReports.tblmlist.Rows.Count != 0)
                    {
                        LoadSet();

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
                else if (cboSearchby.Text == "Level")
                {
                    SQL = "select concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))as Name,b.Position,b.Department,b.Status,b.SG from tblpi a inner join (select * from (select * from tblwe order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc)we where we.`To`='Present' group by EmpID) b on a.EmpID=b.EmpID where b.Status='Permanent'  order by concat(a.Surname,', ',a.Firstname,' ',concat(left(a.Middlename,1),'.'))";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    dt.Clear();
                    dsReports.tblmlist.Clear();
                    da.Fill(dt);
                    Connection.Conn.Close();

                    //1st level
                    if (txtSearch.Text == "1")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dr = dt.Rows[i];

                            //Get Salaray Grade Level
                            Sgrade = dr["SG"].ToString().Split('-');

                            //Convert to int
                            if (int.TryParse(Sgrade[0], out g))
                            {
                                //Check if meet the condition for 1st Level position (1-9)
                                if (g <= 9)
                                {
                                    //Add to list
                                    dsReports.tblmlist.Rows.Add(dr["Name"].ToString(), dr["Position"].ToString(), dr["Department"].ToString(), dr["Status"].ToString());
                                }
                            }
                        }
                    }

                    //2nd Level
                    else if (txtSearch.Text == "2")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dr = dt.Rows[i];

                            //Get Salaray Grade Level
                            Sgrade = dr["SG"].ToString().Split('-');

                            //Convert to int
                            if (int.TryParse(Sgrade[0], out g))
                            {
                                //Check if meet the condition for 2nd Level position (10-24)
                                if (g > 9 && g <= 24)
                                {
                                    //Add to list
                                    dsReports.tblmlist.Rows.Add(dr["Name"].ToString(), dr["Position"].ToString(), dr["Department"].ToString(), dr["Status"].ToString());
                                }
                            }
                        }
                    }

                    //3rd Level
                    else if (txtSearch.Text == "3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dr = dt.Rows[i];

                            //Get Salaray Grade Level
                            Sgrade = dr["SG"].ToString().Split('-');

                            //Convert to int
                            if (int.TryParse(Sgrade[0], out g))
                            {
                                //Check if meet the condition for 3rd Level position (25 up)
                                if (g > 24)
                                {
                                    //Add to list
                                    dsReports.tblmlist.Rows.Add(dr["Name"].ToString(), dr["Position"].ToString(), dr["Department"].ToString(), dr["Status"].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                    }

                    //Load Report
                    if (dsReports.tblmlist.Rows.Count != 0)
                    {
                        LoadSet();

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
                else if (cboSearchby.Text == "All")
                {
                    LoadData();
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void cboSearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSearchby.Text != "All" || cboSearchby.Text != "")
            {
                txtSearch.Focus();
            }
        }
    }
}
