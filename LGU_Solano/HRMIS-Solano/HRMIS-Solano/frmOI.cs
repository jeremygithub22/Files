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
    public partial class frmOI : Form
    {
        public frmOI()
        {
            InitializeComponent();
        }
        string SQL, Transaction, OIN, Skill, NonAcad, Membership;
        public string EmpID;
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Other Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tbloi(EmpID,Skill,NonAcad,Membership)values(@EmpID,@Skill,@NonAcad,@Membership)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@Skill", MySqlDbType.VarChar).Value = txtSkills.Text;
                        da.InsertCommand.Parameters.Add("@NonAcad", MySqlDbType.VarChar).Value = txtRecognition.Text;
                        da.InsertCommand.Parameters.Add("@Membership", MySqlDbType.VarChar).Value = txtMembership.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Other Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtMembership.Clear();
                        txtRecognition.Clear();
                        txtSkills.Clear();
                        txtSkills.Focus();

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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Other Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (OIN != "")
                    {
                        conn.SetConstr();
                        SQL = "update tbloi set Skill=@Skill,NonAcad=@NonAcad,Membership=@Membership where EmpID=@EmpID and OIN=@OIN";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@Skill", MySqlDbType.VarChar).Value = txtSkills.Text;
                        da.UpdateCommand.Parameters.Add("@NonAcad", MySqlDbType.VarChar).Value = txtRecognition.Text;
                        da.UpdateCommand.Parameters.Add("@Membership", MySqlDbType.VarChar).Value = txtMembership.Text;
                        da.UpdateCommand.Parameters.Add("@OIN", MySqlDbType.VarChar).Value = OIN;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Other Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        void GetID()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tbloi where EmpID=@EmpID and Skill=@Skill and NonAcad=@NonAcad and Membership=@Membership";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Skill", MySqlDbType.VarChar).Value = txtSkills.Text;
                da.SelectCommand.Parameters.Add("@NonAcad", MySqlDbType.VarChar).Value = txtRecognition.Text;
                da.SelectCommand.Parameters.Add("@Membership", MySqlDbType.VarChar).Value = txtMembership.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    OIN = dr["OIN"].ToString();
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
                SQL = "select * from tbloi where EmpID=@EmpID and Skill=@Skill and NonAcad=@NonAcad and Membership=@Membership";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Skill", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Skill"].Value.ToString();
                da.SelectCommand.Parameters.Add("@NonAcad", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Non-Academic Distinctions"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Membership", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Membership in Association"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    OIN = dr["OIN"].ToString();
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
                if (OIN != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tbloi where OIN=@OIN";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@OIN", MySqlDbType.VarChar).Value = OIN;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Other Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SQL = "select Skill,NonAcad as `Non-Academic Distinctions`,Membership as `Membership in Association` from tbloi where EmpID=@EmpID";
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

            txtMembership.Clear();
            txtRecognition.Clear();
            txtSkills.Clear();

            txtSkills.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                Transaction = "Edit";
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                txtMembership.Text = dgvList.SelectedRows[0].Cells["Membership in Association"].Value.ToString();
                txtRecognition.Text = dgvList.SelectedRows[0].Cells["Non-Academic Distinctions"].Value.ToString();
                txtSkills.Text = dgvList.SelectedRows[0].Cells["Skill"].Value.ToString();

                Membership = txtMembership.Text;
                NonAcad = txtRecognition.Text;
                Skill = txtSkills.Text;

                txtSkills.Focus();

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
                txtMembership.Clear();
                txtRecognition.Clear();
                txtSkills.Clear();

                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;

                dgvList.Enabled = true;

                txtSkills.Focus();
            }
            else if (Transaction == "Edit")
            {
                txtMembership.Text = Membership;
                txtRecognition.Text = NonAcad;
                txtSkills.Text = Skill;

                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                dgvList.Enabled = false;

                txtSkills.Focus();
            }
            else
            {
            }
        }

        private void frmOI_Load(object sender, EventArgs e)
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
                if (MessageBox.Show("Are you sure, you want to delete this record", "Other Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    DelData();
                }
            }
        }
    }
}
