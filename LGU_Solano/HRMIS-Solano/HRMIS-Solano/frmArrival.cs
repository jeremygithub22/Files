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
    public partial class frmArrival : Form
    {
        public frmArrival()
        {
            InitializeComponent();
        }
        string SQL;
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select concat(b.Surname,', ',b.Firstname,' ',b.Middlename)as Name,a.DepartureTime as `Time Departure`,a.ExpectedTime as `Expected Time`,a.ActualTime as `Actual Time`,a.ApprovedAs as `Approved as`,a.Destination from tblslip a left join tblpi b on a.EmpID=b.EmpID where Date(a.DepartureDate)=Date(@DepartureDate) order by concat(b.Surname,', ',b.Firstname,' ',b.Middlename) asc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@DepartureDate", MySqlDbType.Date).Value = DateTime.Now;
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
        void UpdateLS()
        {
            try
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
                    DataRow dr = dt.Rows[0];
                    DateTime ActualTime = DateTime.Now;
                    DateTime DepartureTime = DateTime.Parse(dr["DepartureTime"].ToString());
                    DateTime ArrivalTime = DateTime.Parse(dr["ExpectedTime"].ToString());
                    double minused = Math.Truncate((ActualTime - DepartureTime).TotalMinutes);
                    double equivalent = minused / 480;

                    if (dr["ActualTime"].ToString() == "")
                    {
                        dtpArrived.Text = ActualTime.ToShortTimeString();
                        SQL = "update tblslip set ActualTime=@ActualTime,MinUse=@MinUse,Equivalent=@Equivalent where LocNo=@LocNo";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@ActualTime", MySqlDbType.VarChar).Value = ActualTime.ToShortTimeString();
                        da.UpdateCommand.Parameters.Add("@MinUse", MySqlDbType.Double).Value = minused;
                        da.UpdateCommand.Parameters.Add("@Equivalent", MySqlDbType.Double).Value = equivalent;
                        da.UpdateCommand.Parameters.Add("@LocNo", MySqlDbType.VarChar).Value = txtLocNo.Text;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        Display();
                        txtLocNo.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("Personnel arrived.", "Arrival", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Display();
                        txtLocNo.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Locator no. does not yet issued to any personnel", "Arrival", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLocNo.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmArrival_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void txtLocNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                UpdateLS();
            }
        }
    }
}
