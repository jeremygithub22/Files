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
    public partial class frmSpouse : Form
    {
        public frmSpouse()
        {
            InitializeComponent();
        }
        string SQL, SpSurname, SpFirstname, SpMiddlename, Occupation, Employer, BusAdd, Telno, Transaction, SPID;
        Connection conn = new Connection();
        MySqlDataAdapter da;
        DataTable dt;
        public string EmpID;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Spouse Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblspouse (EmpID,SpSurname,SpFirstname,SpMiddlename,Occupation,Employer,BusAdd,Telno)values(@EmpID,@SpSurname,@SpFirstname,@SpMiddlename,@Occupation,@Employer,@BusAdd,@Telno)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@SpSurname", MySqlDbType.VarChar).Value = txtSSurname.Text;
                        da.InsertCommand.Parameters.Add("@SpFirstname", MySqlDbType.VarChar).Value = txtSFirstname.Text;
                        da.InsertCommand.Parameters.Add("@SpMiddlename", MySqlDbType.VarChar).Value = txtSMiddlename.Text;
                        da.InsertCommand.Parameters.Add("@Occupation", MySqlDbType.VarChar).Value = txtOccupation.Text;
                        da.InsertCommand.Parameters.Add("@Employer", MySqlDbType.VarChar).Value = txtEmployer.Text;
                        da.InsertCommand.Parameters.Add("@BusAdd", MySqlDbType.VarChar).Value = txtBusAdd.Text;
                        da.InsertCommand.Parameters.Add("@Telno", MySqlDbType.VarChar).Value = txtTelno.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully Add new Spouse record", "Spouse Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtBusAdd.Clear();
                        txtEmployer.Clear();
                        txtOccupation.Clear();
                        txtSFirstname.Clear();
                        txtSMiddlename.Clear();
                        txtSSurname.Clear();
                        txtTelno.Clear();
                        txtSSurname.Focus();

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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Spouse Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SPID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblspouse set SpSurname=@SpSurname,SpFirstname=@SpFirstname,SpMiddlename=@SpMiddlename,Occupation=@Occupation,Employer=@Employer,BusAdd=@BusAdd,Telno=@Telno where EmpID=@EmpID and SPID=@SPID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@SpSurname", MySqlDbType.VarChar).Value = txtSSurname.Text;
                        da.UpdateCommand.Parameters.Add("@SpFirstname", MySqlDbType.VarChar).Value = txtSFirstname.Text;
                        da.UpdateCommand.Parameters.Add("@SpMiddlename", MySqlDbType.VarChar).Value = txtSMiddlename.Text;
                        da.UpdateCommand.Parameters.Add("@Occupation", MySqlDbType.VarChar).Value = txtOccupation.Text;
                        da.UpdateCommand.Parameters.Add("@Employer", MySqlDbType.VarChar).Value = txtEmployer.Text;
                        da.UpdateCommand.Parameters.Add("@BusAdd", MySqlDbType.VarChar).Value = txtBusAdd.Text;
                        da.UpdateCommand.Parameters.Add("@Telno", MySqlDbType.VarChar).Value = txtTelno.Text;
                        da.UpdateCommand.Parameters.Add("@SPID", MySqlDbType.VarChar).Value = SPID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update Spouse record", "Spouse Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select SpSurname as `Spouse's Surname`,SpFirstname as `Spouse's Firstname`,SpMiddlename as `Spouse's Middlename`,Occupation,Employer,BusAdd as `Business Address`,Telno as `Telephone No.` from tblspouse where EmpID=@EmpID";
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
            Transaction = "New";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            txtSSurname.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                Transaction = "Edit";
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                txtBusAdd.Text = dgvList.SelectedRows[0].Cells["Business Address"].Value.ToString();
                txtEmployer.Text = dgvList.SelectedRows[0].Cells["Employer"].Value.ToString();
                txtOccupation.Text = dgvList.SelectedRows[0].Cells["Occupation"].Value.ToString();
                txtSFirstname.Text = dgvList.SelectedRows[0].Cells["Spouse's Firstname"].Value.ToString();
                txtSMiddlename.Text = dgvList.SelectedRows[0].Cells["Spouse's Middlename"].Value.ToString();
                txtSSurname.Text = dgvList.SelectedRows[0].Cells["Spouse's Surname"].Value.ToString();
                txtTelno.Text = dgvList.SelectedRows[0].Cells["Telephone No."].Value.ToString();

                SpSurname = txtSSurname.Text;
                SpMiddlename = txtSMiddlename.Text;
                SpFirstname = txtSFirstname.Text;
                Occupation = txtOccupation.Text;
                Employer = txtEmployer.Text;
                BusAdd = txtBusAdd.Text;
                Telno = txtTelno.Text;

                dgvList.Enabled = false;
                txtSSurname.Focus();
                GetID();
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
                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;

                txtBusAdd.Clear();
                txtEmployer.Clear();
                txtOccupation.Clear();
                txtSFirstname.Clear();
                txtSMiddlename.Clear();
                txtSSurname.Clear();
                txtTelno.Clear();
                txtSSurname.Focus();

                dgvList.Enabled = true;
                Display();
            }
            else if (Transaction == "Edit")
            {
                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                txtSSurname.Text = SpSurname;
                txtSMiddlename.Text = SpMiddlename;
                txtSFirstname.Text = SpFirstname;
                txtOccupation.Text = Occupation;
                txtEmployer.Text = Employer;
                txtBusAdd.Text = BusAdd;
                txtTelno.Text = Telno;

                txtSSurname.Focus();

                Display();
            }
            else
            {
            }
        }

        private void frmSpouse_Load(object sender, EventArgs e)
        {
            Display();
        }
        void GetID()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblspouse where EmpID=@EmpID and SpSurname=@SpSurname and SpFirstname=@SpFirstname and SpMiddlename=@SpMiddlename and Occupation=@Occupation and Employer=@Employer and BusAdd=@BusAdd and Telno=@Telno";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@SpSurname", MySqlDbType.VarChar).Value = txtSSurname.Text;
                da.SelectCommand.Parameters.Add("@SpFirstname", MySqlDbType.VarChar).Value = txtSFirstname.Text;
                da.SelectCommand.Parameters.Add("@SpMiddlename", MySqlDbType.VarChar).Value = txtSMiddlename.Text;
                da.SelectCommand.Parameters.Add("@Occupation", MySqlDbType.VarChar).Value = txtOccupation.Text;
                da.SelectCommand.Parameters.Add("@Employer", MySqlDbType.VarChar).Value = txtEmployer.Text;
                da.SelectCommand.Parameters.Add("@BusAdd", MySqlDbType.VarChar).Value = txtBusAdd.Text;
                da.SelectCommand.Parameters.Add("@Telno", MySqlDbType.VarChar).Value = txtTelno.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    SPID = dr["SPID"].ToString();
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
                SQL = "select * from tblspouse where EmpID=@EmpID and SpSurname=@SpSurname and SpFirstname=@SpFirstname and SpMiddlename=@SpMiddlename and Occupation=@Occupation and Employer=@Employer and BusAdd=@BusAdd and Telno=@Telno";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@SpSurname", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Spouse's Surname"].Value.ToString();
                da.SelectCommand.Parameters.Add("@SpFirstname", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Spouse's Firstname"].Value.ToString();
                da.SelectCommand.Parameters.Add("@SpMiddlename", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Spouse's Middlename"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Occupation", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Occupation"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Employer", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Employer"].Value.ToString();
                da.SelectCommand.Parameters.Add("@BusAdd", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Business Address"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Telno", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Telephone No."].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    SPID = dr["SPID"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Deldata()
        {
            try
            {
                if (SPID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblspouse where SPID=@SPID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@SPID", MySqlDbType.VarChar).Value = SPID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully delete record", "Spouse Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Display();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (MessageBox.Show("Are you sure, you want to delete this record", "Spouse Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    Deldata();
                }
            }
        }
    }
}
