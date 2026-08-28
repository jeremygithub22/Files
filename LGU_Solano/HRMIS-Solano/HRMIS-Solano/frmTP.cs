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
    public partial class frmTP : Form
    {
        public frmTP()
        {
            InitializeComponent();
        }
        string SQL, Transaction, TPID, Title, From, To, NH, Conducted;
        public string EmpID;
        Connection conn = new Connection();
        DataTable dt;
        MySqlDataAdapter da;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Training Programs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tbltp(EmpID,Title,`From`,`To`,NH,Conducted)values(@EmpID,@Title,@From,@To,@NH,@Conducted)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@Title", MySqlDbType.VarChar).Value = txtSeminar.Text;
                        da.InsertCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.InsertCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.InsertCommand.Parameters.Add("@NH", MySqlDbType.VarChar).Value = txtHours.Text;
                        da.InsertCommand.Parameters.Add("@Conducted", MySqlDbType.VarChar).Value = txtConducted.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Training Programs", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtConducted.Clear();
                        txtFrom.Clear();
                        txtHours.Clear();
                        txtSeminar.Clear();
                        txtTo.Clear();

                        txtSeminar.Focus();

                        dgvList.Enabled = true;
                        Display();
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Training Programs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TPID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tbltp set Title=@Title,`From`=@From,`To`=@To,NH=@NH,Conducted=@Conducted where EmpID=@EmpID and TPID=@TPID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@Title", MySqlDbType.VarChar).Value = txtSeminar.Text;
                        da.UpdateCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.UpdateCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.UpdateCommand.Parameters.Add("@NH", MySqlDbType.VarChar).Value = txtHours.Text;
                        da.UpdateCommand.Parameters.Add("@Conducted", MySqlDbType.VarChar).Value = txtConducted.Text;
                        da.UpdateCommand.Parameters.Add("@TPID", MySqlDbType.VarChar).Value = TPID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Training Programs", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtSeminar.Focus();

                        dgvList.Enabled = true;
                        Display();
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
                SQL = "select * from tbltp where EmpID=@EmpID and Title=@Title and `From`=@From and `To`=@To and NH=@NH and Conducted=@Conducted";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Title", MySqlDbType.VarChar).Value = txtSeminar.Text;
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                da.SelectCommand.Parameters.Add("@NH", MySqlDbType.VarChar).Value = txtHours.Text;
                da.SelectCommand.Parameters.Add("@Conducted", MySqlDbType.VarChar).Value = txtConducted.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    TPID = dr["TPID"].ToString();
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
                SQL = "select * from tbltp where EmpID=@EmpID and Title=@Title and `From`=@From and `To`=@To and NH=@NH and Conducted=@Conducted";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Title", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Title of Seminar"].Value.ToString();
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["To"].Value.ToString();
                da.SelectCommand.Parameters.Add("@NH", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Number of Hours"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Conducted", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Conducted"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    TPID = dr["TPID"].ToString();
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
                if (TPID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tbltp where TPID=@TPID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@TPID", MySqlDbType.VarChar).Value = TPID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Training Programs", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SQL = "select Title as `Title of Seminar`,`From`,`To`,NH as `Number of Hours`,Conducted from tbltp where EmpID=@EmpID order by year(str_to_date(`From`,'%m/%d/%Y')) desc,month(str_to_date(`From`,'%m/%d/%Y')) desc,day(str_to_date(`From`,'%m/%d/%Y')) desc";
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            Transaction = "New";

            txtConducted.Clear();
            txtFrom.Clear();
            txtHours.Clear();
            txtSeminar.Clear();
            txtTo.Clear();

            txtSeminar.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                Transaction = "Edit";


                txtConducted.Text = dgvList.SelectedRows[0].Cells["Conducted"].Value.ToString();
                txtFrom.Text = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                txtHours.Text = dgvList.SelectedRows[0].Cells["Number of Hours"].Value.ToString();
                txtSeminar.Text = dgvList.SelectedRows[0].Cells["Title of Seminar"].Value.ToString();
                txtTo.Text = dgvList.SelectedRows[0].Cells["To"].Value.ToString();

                Conducted = txtConducted.Text;
                From = txtFrom.Text;
                NH = txtHours.Text;
                Title = txtSeminar.Text;
                To = txtTo.Text;

                txtSeminar.Focus();

                GetID();
                dgvList.Enabled = false;
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
                txtConducted.Clear();
                txtFrom.Clear();
                txtHours.Clear();
                txtSeminar.Clear();
                txtTo.Clear();

                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;

                dgvList.Enabled = true;
            }
            else if (Transaction == "Edit")
            {
                txtConducted.Text = Conducted;
                txtFrom.Text = From;
                txtHours.Text = NH;
                txtSeminar.Text = Title;
                txtTo.Text = To;

                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                dgvList.Enabled = false;
            }
            else
            {
            }
        }

        private void frmTP_Load(object sender, EventArgs e)
        {
            Display();
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
                if (MessageBox.Show("Are you sure, you want to delete this record", "Training Programs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    DelData();
                }
            }
        }
    }
}
