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
    public partial class frmVW : Form
    {
        public frmVW()
        {
            InitializeComponent();
        }
        string SQL, Transaction, VWID, Name, From, To, NH, Pos;
        public string EmpID;
        Connection conn = new Connection();
        MySqlDataAdapter da;
        DataTable dt;

        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Voluntary Work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblvw(EmpID,Name,`From`,`To`,NH,Pos)values(@EmpID,@Name,@From,@To,@NH,@Pos)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                        da.InsertCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.InsertCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.InsertCommand.Parameters.Add("@NH", MySqlDbType.VarChar).Value = txtHours.Text;
                        da.InsertCommand.Parameters.Add("@Pos", MySqlDbType.VarChar).Value = txtPosition.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Voluntary Work", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Display();
                        txtFrom.Clear();
                        txtHours.Clear();
                        txtName.Clear();
                        txtPosition.Clear();
                        txtTo.Clear();

                        dgvList.Enabled = true;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Voluntary Work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (VWID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblvw set Name=@Name,`From`=@From,`To`=@To,NH=@NH,Pos=@Pos where EmpID=@EmpID and VWID=@VWID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                        da.UpdateCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.UpdateCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.UpdateCommand.Parameters.Add("@NH", MySqlDbType.VarChar).Value = txtHours.Text;
                        da.UpdateCommand.Parameters.Add("@Pos", MySqlDbType.VarChar).Value = txtPosition.Text;
                        da.UpdateCommand.Parameters.Add("@VWID", MySqlDbType.VarChar).Value = VWID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Voluntary Work", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Display();
                        dgvList.Enabled = true;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
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
                SQL = "select * from tblvw where EmpID=@EmpID and Name=@Name and `From`=@From and `To`=@To and NH=@NH and Pos=@Pos";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                da.SelectCommand.Parameters.Add("@NH", MySqlDbType.VarChar).Value = txtHours.Text;
                da.SelectCommand.Parameters.Add("@Pos", MySqlDbType.VarChar).Value = txtPosition.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    VWID = dr["VWID"].ToString();
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
                SQL = "select * from tblvw where EmpID=@EmpID and Name=@Name and `From`=@From and `To`=@To and NH=@NH and Pos=@Pos";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["To"].Value.ToString();
                da.SelectCommand.Parameters.Add("@NH", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Number of Hours"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Pos", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Position"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    VWID = dr["VWID"].ToString();
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
                if (VWID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblvw where VWID=@VWID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@VWID", MySqlDbType.VarChar).Value = VWID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Voluntary Work", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SQL = "select Name,`From`,`To`,NH as `Number of Hours`,Pos as `Position` from tblvw where EmpID=@EmpID order by year(str_to_date(`From`,'%m/%d/%Y')) asc,month(str_to_date(`From`,'%m/%d/%Y')) asc,day(str_to_date(`From`,'%m/%d/%Y')) asc";
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

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            txtFrom.Text = dtpFrom.Value.ToShortDateString();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            txtTo.Text = dtpTo.Value.ToShortDateString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            Transaction = "New";

            txtFrom.Clear();
            txtHours.Clear();
            txtName.Clear();
            txtPosition.Clear();
            txtTo.Clear();

            txtName.Focus();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                Transaction = "Edit";

                txtFrom.Text = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                txtHours.Text = dgvList.SelectedRows[0].Cells["Number of Hours"].Value.ToString();
                txtName.Text = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
                txtPosition.Text = dgvList.SelectedRows[0].Cells["Position"].Value.ToString();
                txtTo.Text = dgvList.SelectedRows[0].Cells["To"].Value.ToString();

                txtName.Focus();

                From = txtFrom.Text;
                NH = txtHours.Text;
                Name = txtName.Text;
                Pos = txtPosition.Text;
                To = txtTo.Text;

                GetID();
                dgvList.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Transaction == "New")
            {
                txtFrom.Clear();
                txtHours.Clear();
                txtName.Clear();
                txtPosition.Clear();
                txtTo.Clear();

                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;

                txtName.Focus();
                dgvList.Enabled = true;

            }
            else if (Transaction == "Edit")
            {

                txtFrom.Text = From;
                txtHours.Text = NH;
                txtName.Text = Name;
                txtPosition.Text = Pos;
                txtTo.Text = To;

                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                txtName.Focus();
                dgvList.Enabled = false;
            }
            else
            {
            }
        }

        private void frmVW_Load(object sender, EventArgs e)
        {
            Display();
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
                if (MessageBox.Show("Are you sure, you want to delete this record", "Voluntary Work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    DelData();
                }
            }
        }
    }
}
