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
    public partial class frmEB : Form
    {
        public frmEB()
        {
            InitializeComponent();
        }
        string SQL, Transaction, EBID, Level, Name, Degree, Year, HighestGrade, From, To, Scholarship;
        MySqlDataAdapter da;
        DataTable dt;
        public string EmpID;
        Connection conn = new Connection();
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Educational Background", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tbleb(EmpID,Level,Name,Degree,Year,HighestGrade,`From`,`To`,Scholarship)values(@EmpID,@Level,@Name,@Degree,@Year,@HighestGrade,@From,@To,@Scholarship)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@Level", MySqlDbType.VarChar).Value = cboLevel.Text;
                        da.InsertCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtNameofSchool.Text;
                        da.InsertCommand.Parameters.Add("@Degree", MySqlDbType.VarChar).Value = txtDegree.Text;
                        da.InsertCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = txtYear.Text;
                        da.InsertCommand.Parameters.Add("@HighestGrade", MySqlDbType.VarChar).Value = txtHighestGrade.Text;
                        da.InsertCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.InsertCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.InsertCommand.Parameters.Add("@Scholarship", MySqlDbType.VarChar).Value = txtScholarship.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Educational Background", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        cboLevel.ResetText();
                        txtDegree.Clear();
                        txtFrom.Clear();
                        txtHighestGrade.Clear();
                        txtNameofSchool.Clear();
                        txtScholarship.Clear();
                        txtTo.Clear();
                        txtYear.Clear();
                        dtpFrom.Value = DateTime.Now;
                        dtpTo.Value = DateTime.Now;

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
                SQL = "select * from tbleb where EmpID=@EmpID and Level=@Level and Name=@Name and Degree=@Degree and Year=@Year and HighestGrade=@HighestGrade and `From`=@From and `To`=@To and Scholarship=@Scholarship";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Level", MySqlDbType.VarChar).Value = cboLevel.Text;
                da.SelectCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtNameofSchool.Text;
                da.SelectCommand.Parameters.Add("@Degree", MySqlDbType.VarChar).Value = txtDegree.Text;
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = txtYear.Text;
                da.SelectCommand.Parameters.Add("@HighestGrade", MySqlDbType.VarChar).Value = txtHighestGrade.Text;
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                da.SelectCommand.Parameters.Add("@Scholarship", MySqlDbType.VarChar).Value = txtScholarship.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    EBID = dr["EBID"].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetIDDel()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tbleb where EmpID=@EmpID and Level=@Level and Name=@Name and Degree=@Degree and Year=@Year and HighestGrade=@HighestGrade and `From`=@From and `To`=@To and Scholarship=@Scholarship";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Level", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Level"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Degree", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Degree"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Year"].Value.ToString();
                da.SelectCommand.Parameters.Add("@HighestGrade", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Highest Grade"].Value.ToString();
                da.SelectCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                da.SelectCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["To"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Scholarship", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Scholarship"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    EBID = dr["EBID"].ToString();
                }
                else
                {
                    EBID = string.Empty;
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
                if (EBID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tbleb where EBID=@EBID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@EBID", MySqlDbType.VarChar).Value = EBID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Educational Background", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SQL = "select Level,Name,Degree,Year,HighestGrade as `Highest Grade`,`From`,`To`,Scholarship from tbleb where EmpID=@EmpID";
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
        void Save()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to update this record?", "Educational Background", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EBID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tbleb set Level=@Level,Name=@Name,Degree=@Degree,Year=@Year,HighestGrade=@HighestGrade,`From`=@From,`To`=@To,Scholarship=@Scholarship where EmpID=@EmpID and EBID=@EBID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@Level", MySqlDbType.VarChar).Value = cboLevel.Text;
                        da.UpdateCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtNameofSchool.Text;
                        da.UpdateCommand.Parameters.Add("@Degree", MySqlDbType.VarChar).Value = txtDegree.Text;
                        da.UpdateCommand.Parameters.Add("@Year", MySqlDbType.VarChar).Value = txtYear.Text;
                        da.UpdateCommand.Parameters.Add("@HighestGrade", MySqlDbType.VarChar).Value = txtHighestGrade.Text;
                        da.UpdateCommand.Parameters.Add("@From", MySqlDbType.VarChar).Value = txtFrom.Text;
                        da.UpdateCommand.Parameters.Add("@To", MySqlDbType.VarChar).Value = txtTo.Text;
                        da.UpdateCommand.Parameters.Add("@Scholarship", MySqlDbType.VarChar).Value = txtScholarship.Text;
                        da.UpdateCommand.Parameters.Add("@EBID", MySqlDbType.VarChar).Value = EBID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Educational Background", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

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
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            txtFrom.Text = dtpFrom.Value.ToShortDateString();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            txtTo.Text = dtpTo.Value.ToShortDateString();
        }

        private void frmEB_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Transaction = "New";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txtDegree.Clear();
            txtFrom.Clear();
            txtHighestGrade.Clear();
            txtNameofSchool.Clear();
            txtScholarship.Clear();
            txtTo.Clear();
            txtYear.Clear();
            cboLevel.ResetText();

            cboLevel.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                Transaction = "Edit";
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                txtDegree.Text = dgvList.SelectedRows[0].Cells["Degree"].Value.ToString();
                txtFrom.Text = dgvList.SelectedRows[0].Cells["From"].Value.ToString();
                txtHighestGrade.Text = dgvList.SelectedRows[0].Cells["Highest Grade"].Value.ToString();
                txtNameofSchool.Text = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
                txtScholarship.Text = dgvList.SelectedRows[0].Cells["Scholarship"].Value.ToString();
                txtTo.Text = dgvList.SelectedRows[0].Cells["To"].Value.ToString();
                txtYear.Text = dgvList.SelectedRows[0].Cells["Year"].Value.ToString();
                cboLevel.Text = dgvList.SelectedRows[0].Cells["Level"].Value.ToString();

                Degree = txtDegree.Text;
                From = txtFrom.Text;
                HighestGrade = txtHighestGrade.Text;
                Name = txtNameofSchool.Text;
                Scholarship = txtScholarship.Text;
                To = txtTo.Text;
                HighestGrade = txtHighestGrade.Text;
                Year = txtYear.Text;
                Level = cboLevel.Text;
                cboLevel.Focus();

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
                txtDegree.Clear();
                txtFrom.Clear();
                txtHighestGrade.Clear();
                txtNameofSchool.Clear();
                txtScholarship.Clear();
                txtTo.Clear();
                txtYear.Clear();
                dtpFrom.Value = DateTime.Now;
                dtpTo.Value = DateTime.Now;

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
                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                txtDegree.Text = Degree;
                txtFrom.Text = From;
                txtHighestGrade.Text = HighestGrade;
                txtNameofSchool.Text = Name;
                txtScholarship.Text = Scholarship;
                txtTo.Text = To;
                txtHighestGrade.Text = HighestGrade;
                txtYear.Text = Year;
                cboLevel.Text = Level;

                dgvList.Enabled = false;
            }
            else
            {
            }
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
                if (MessageBox.Show("Are you sure, you want to delete this record", "Educational Background", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    DelData();
                }
            }
        }
    }
}
