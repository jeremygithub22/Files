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
    public partial class frmFB : Form
    {
        public frmFB()
        {
            InitializeComponent();
        }
        string SQL, Transaction, SpSurname, SpFirstname, SpMiddlename, Occupation, Employer, BusAdd, Telno, FSurname;
        string Ffirstname, FMiddlename, MSurname, MFirstname, Mmiddlename;
        Connection conn = new Connection();
        MySqlDataAdapter da;
        public string EmpID;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Family Background", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblfb(EmpID,SpSurname,SpFirstname,SpMiddlename,Occupation,Employer,BusAdd,Telno,FSurname,Ffirstname,FMiddlename,MSurname,MFirstname,Mmiddlename)values(@EmpID,@SpSurname,@SpFirstname,@SpMiddlename,@Occupation,@Employer,@BusAdd,@Telno,@FSurname,@Ffirstname,@FMiddlename,@MSurname,@MFirstname,@Mmiddlename)";
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
                        da.InsertCommand.Parameters.Add("@FSurname", MySqlDbType.VarChar).Value = txtFSurname.Text;
                        da.InsertCommand.Parameters.Add("@Ffirstname", MySqlDbType.VarChar).Value = txtFfirstname.Text;
                        da.InsertCommand.Parameters.Add("@FMiddlename", MySqlDbType.VarChar).Value = txtFMiddlename.Text;
                        da.InsertCommand.Parameters.Add("@MSurname", MySqlDbType.VarChar).Value = txtMSurname.Text;
                        da.InsertCommand.Parameters.Add("@MFirstname", MySqlDbType.VarChar).Value = txtMFirstname.Text;
                        da.InsertCommand.Parameters.Add("@Mmiddlename", MySqlDbType.VarChar).Value = txtMmiddlename.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtSSurname.Clear();
                        txtSFirstname.Clear();
                        txtSMiddlename.Clear();
                        txtOccupation.Clear();
                        txtEmployer.Clear();
                        txtBusAdd.Clear();
                        txtTelno.Clear();
                        txtFSurname.Clear();
                        txtFfirstname.Clear();
                        txtFMiddlename.Clear();
                        txtMSurname.Clear();
                        txtMFirstname.Clear();
                        txtMmiddlename.Clear();

                        txtSSurname.Enabled = true;
                        txtSFirstname.Enabled = true;
                        txtSMiddlename.Enabled = true;
                        txtOccupation.Enabled = true;
                        txtEmployer.Enabled = true;
                        txtBusAdd.Enabled = true;
                        txtTelno.Enabled = true;
                        txtFSurname.Enabled = true;
                        txtFfirstname.Enabled = true;
                        txtFMiddlename.Enabled = true;
                        txtMSurname.Enabled = true;
                        txtMFirstname.Enabled = true;
                        txtMmiddlename.Enabled = true;

                        MessageBox.Show("Successfully Add family background", "Family Background", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Family Background", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblfb set SpSurname=@SpSurname,SpFirstname=@SpFirstname,SpMiddlename=@SpMiddlename,Occupation=@Occupation,Employer=@Employer,BusAdd=@BusAdd,Telno=@Telno,FSurname=@FSurname,Ffirstname=@Ffirstname,FMiddlename=@FMiddlename,MSurname=@MSurname,MFirstname=@MFirstname,Mmiddlename=@Mmiddlename where EmpID=@EmpID";
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
                        da.UpdateCommand.Parameters.Add("@FSurname", MySqlDbType.VarChar).Value = txtFSurname.Text;
                        da.UpdateCommand.Parameters.Add("@Ffirstname", MySqlDbType.VarChar).Value = txtFfirstname.Text;
                        da.UpdateCommand.Parameters.Add("@FMiddlename", MySqlDbType.VarChar).Value = txtFMiddlename.Text;
                        da.UpdateCommand.Parameters.Add("@MSurname", MySqlDbType.VarChar).Value = txtMSurname.Text;
                        da.UpdateCommand.Parameters.Add("@MFirstname", MySqlDbType.VarChar).Value = txtMFirstname.Text;
                        da.UpdateCommand.Parameters.Add("@Mmiddlename", MySqlDbType.VarChar).Value = txtMmiddlename.Text;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();

                        btnNew.Enabled = false;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;

                        txtSSurname.Enabled = false;
                        txtSFirstname.Enabled = false;
                        txtSMiddlename.Enabled = false;
                        txtOccupation.Enabled = false;
                        txtEmployer.Enabled = false;
                        txtBusAdd.Enabled = false;
                        txtTelno.Enabled = false;
                        txtFSurname.Enabled = false;
                        txtFfirstname.Enabled = false;
                        txtFMiddlename.Enabled = false;
                        txtMSurname.Enabled = false;
                        txtMFirstname.Enabled = false;
                        txtMmiddlename.Enabled = false;

                        MessageBox.Show("Successfully update family background", "Family Background", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

            txtSSurname.Clear();
            txtSFirstname.Clear();
            txtSMiddlename.Clear();
            txtOccupation.Clear();
            txtEmployer.Clear();
            txtBusAdd.Clear();
            txtTelno.Clear();
            txtFSurname.Clear();
            txtFfirstname.Clear();
            txtFMiddlename.Clear();
            txtMSurname.Clear();
            txtMFirstname.Clear();
            txtMmiddlename.Clear();

            txtSSurname.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txtSSurname.Enabled = true;
            txtSFirstname.Enabled = true;
            txtSMiddlename.Enabled = true;
            txtOccupation.Enabled = true;
            txtEmployer.Enabled = true;
            txtBusAdd.Enabled = true;
            txtTelno.Enabled = true;
            txtFSurname.Enabled = true;
            txtFfirstname.Enabled = true;
            txtFMiddlename.Enabled = true;
            txtMSurname.Enabled = true;
            txtMFirstname.Enabled = true;
            txtMmiddlename.Enabled = true;

            SpSurname = txtSSurname.Text;
            SpFirstname = txtSFirstname.Text;
            SpMiddlename = txtSMiddlename.Text;
            Occupation = txtOccupation.Text;
            Employer = txtEmployer.Text;
            BusAdd = txtBusAdd.Text;
            Telno = txtTelno.Text;
            FSurname = txtFSurname.Text;
            Ffirstname = txtFfirstname.Text;
            FMiddlename = txtFMiddlename.Text;
            MSurname = txtMSurname.Text;
            MFirstname = txtMFirstname.Text;
            Mmiddlename = txtMmiddlename.Text;

            txtSSurname.Focus();
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
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblfb where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                DataTable dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    if (UserDetails.EPPI == "1")
                    {
                        btnEdit.Enabled = true;
                    }
                    btnNew.Enabled = false;
                    btnSave.Enabled = false;

                    Transaction = "Edit";
                    DataRow dr = dt.Rows[0];
                    txtSSurname.Text = dr["SpSurname"].ToString();
                    txtSFirstname.Text = dr["SpFirstname"].ToString();
                    txtSMiddlename.Text = dr["SpMiddlename"].ToString();
                    txtOccupation.Text = dr["Occupation"].ToString();
                    txtEmployer.Text = dr["Employer"].ToString();
                    txtBusAdd.Text = dr["BusAdd"].ToString();
                    txtTelno.Text = dr["Telno"].ToString();
                    txtFSurname.Text = dr["FSurname"].ToString();
                    txtFfirstname.Text = dr["Ffirstname"].ToString();
                    txtFMiddlename.Text = dr["FMiddlename"].ToString();
                    txtMSurname.Text = dr["MSurname"].ToString();
                    txtMFirstname.Text = dr["MFirstname"].ToString();
                    txtMmiddlename.Text = dr["Mmiddlename"].ToString();

                    txtSSurname.Enabled = false;
                    txtSFirstname.Enabled = false;
                    txtSMiddlename.Enabled = false;
                    txtOccupation.Enabled = false;
                    txtEmployer.Enabled = false;
                    txtBusAdd.Enabled = false;
                    txtTelno.Enabled = false;
                    txtFSurname.Enabled = false;
                    txtFfirstname.Enabled = false;
                    txtFMiddlename.Enabled = false;
                    txtMSurname.Enabled = false;
                    txtMFirstname.Enabled = false;
                    txtMmiddlename.Enabled = false;
                }
                else
                {
                    Transaction = "New";
                    if (UserDetails.APPI == "1")
                    {
                        btnNew.Enabled = true;
                    }
                    txtSSurname.Clear();
                    txtSFirstname.Clear();
                    txtSMiddlename.Clear();
                    txtOccupation.Clear();
                    txtEmployer.Clear();
                    txtBusAdd.Clear();
                    txtTelno.Clear();
                    txtFSurname.Clear();
                    txtFfirstname.Clear();
                    txtFMiddlename.Clear();
                    txtMSurname.Clear();
                    txtMFirstname.Clear();
                    txtMmiddlename.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFB_Load(object sender, EventArgs e)
        {
            Display();
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

                txtSSurname.Enabled = true;
                txtSFirstname.Enabled = true;
                txtSMiddlename.Enabled = true;
                txtOccupation.Enabled = true;
                txtEmployer.Enabled = true;
                txtBusAdd.Enabled = true;
                txtTelno.Enabled = true;
                txtFSurname.Enabled = true;
                txtFfirstname.Enabled = true;
                txtFMiddlename.Enabled = true;
                txtMSurname.Enabled = true;
                txtMFirstname.Enabled = true;
                txtMmiddlename.Enabled = true;

                txtSSurname.Clear();
                txtSFirstname.Clear();
                txtSMiddlename.Clear();
                txtOccupation.Clear();
                txtEmployer.Clear();
                txtBusAdd.Clear();
                txtTelno.Clear();
                txtFSurname.Clear();
                txtFfirstname.Clear();
                txtFMiddlename.Clear();
                txtMSurname.Clear();
                txtMFirstname.Clear();
                txtMmiddlename.Clear();
            }
            else if (Transaction == "Edit")
            {
                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                txtSSurname.Enabled = false;
                txtSFirstname.Enabled = false;
                txtSMiddlename.Enabled = false;
                txtOccupation.Enabled = false;
                txtEmployer.Enabled = false;
                txtBusAdd.Enabled = false;
                txtTelno.Enabled = false;
                txtFSurname.Enabled = false;
                txtFfirstname.Enabled = false;
                txtFMiddlename.Enabled = false;
                txtMSurname.Enabled = false;
                txtMFirstname.Enabled = false;
                txtMmiddlename.Enabled = false;

                txtSSurname.Text = SpSurname;
                txtSFirstname.Text = SpFirstname;
                txtSMiddlename.Text = SpMiddlename;
                txtOccupation.Text = Occupation;
                txtEmployer.Text = Employer;
                txtBusAdd.Text = BusAdd;
                txtTelno.Text = Telno;
                txtFSurname.Text = FSurname;
                txtFfirstname.Text = Ffirstname;
                txtFMiddlename.Text = FMiddlename;
                txtMSurname.Text = MSurname;
                txtMFirstname.Text = MFirstname;
                txtMmiddlename.Text = Mmiddlename;
            }
            else
            {
            }
        }

        private void btnSpouse_Click(object sender, EventArgs e)
        {
            frmSpouse spouse = new frmSpouse();
            spouse.EmpID = EmpID;
            spouse.ShowDialog();
        }

        private void btnSiblings_Click(object sender, EventArgs e)
        {
            frmSiblings sib = new frmSiblings();
            sib.EmpID = EmpID;
            sib.ShowDialog();
        }
    }
}
