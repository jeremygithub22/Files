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
    public partial class frmCSE : Form
    {
        public frmCSE()
        {
            InitializeComponent();
        }
        string SQL, Transaction, CSEID, Career, Rating, Date, Place, LN, LD;
        Connection conn = new Connection();
        DataTable dt;
        MySqlDataAdapter da;
        public string EmpID;

        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Civil Service Eligibility", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblcse(EmpID,Career,Rating,Date,Place,LN,LD)values(@EmpID,@Career,@Rating,@Date,@Place,@LN,@LD)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@Career", MySqlDbType.VarChar).Value = txtCareer.Text;
                        da.InsertCommand.Parameters.Add("@Rating", MySqlDbType.VarChar).Value = txtRating.Text;
                        da.InsertCommand.Parameters.Add("@Date", MySqlDbType.VarChar).Value = txtDateExam.Text;
                        da.InsertCommand.Parameters.Add("@Place", MySqlDbType.VarChar).Value = txtPlace.Text;
                        da.InsertCommand.Parameters.Add("@LN", MySqlDbType.VarChar).Value = txtNumber.Text;
                        da.InsertCommand.Parameters.Add("@LD", MySqlDbType.VarChar).Value = txtDateRel.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add new record", "Civil Service Eligibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCareer.Clear();
                        txtDateExam.Clear();
                        txtDateRel.Clear();
                        txtNumber.Clear();
                        txtPlace.Clear();
                        txtRating.Clear();
                        txtCareer.Focus();
                        dgvList.Enabled = true;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Civil Service Eligibility", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CSEID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblcse set Career=@Career,Rating=@Rating,Date=@Date,Place=@Place,LN=@LN,LD=@LD where EmpID=@EmpID and CSEID=@CSEID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@Career", MySqlDbType.VarChar).Value = txtCareer.Text;
                        da.UpdateCommand.Parameters.Add("@Rating", MySqlDbType.VarChar).Value = txtRating.Text;
                        da.UpdateCommand.Parameters.Add("@Date", MySqlDbType.VarChar).Value = txtDateExam.Text;
                        da.UpdateCommand.Parameters.Add("@Place", MySqlDbType.VarChar).Value = txtPlace.Text;
                        da.UpdateCommand.Parameters.Add("@LN", MySqlDbType.VarChar).Value = txtNumber.Text;
                        da.UpdateCommand.Parameters.Add("@LD", MySqlDbType.VarChar).Value = txtDateRel.Text;
                        da.UpdateCommand.Parameters.Add("@CSEID", MySqlDbType.VarChar).Value = CSEID;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Civil Service Eligibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvList.Enabled = true;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
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
                SQL = "select * from tblcse where EmpID=@EmpID and Career=@Career and Rating=@Rating and `Date`=@Date and Place=@Place and LN=@LN and LD=@LD";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Career", MySqlDbType.VarChar).Value = txtCareer.Text;
                da.SelectCommand.Parameters.Add("@Rating", MySqlDbType.VarChar).Value = txtRating.Text;
                da.SelectCommand.Parameters.Add("@Date", MySqlDbType.VarChar).Value = txtDateExam.Text;
                da.SelectCommand.Parameters.Add("@Place", MySqlDbType.VarChar).Value = txtPlace.Text;
                da.SelectCommand.Parameters.Add("@LN", MySqlDbType.VarChar).Value = txtNumber.Text;
                da.SelectCommand.Parameters.Add("@LD", MySqlDbType.VarChar).Value = txtDateRel.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    CSEID = dr["CSEID"].ToString();
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
                SQL = "select * from tblcse where EmpID=@EmpID and Career=@Career and Rating=@Rating and `Date`=@Date and Place=@Place and LN=@LN and LD=@LD";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.SelectCommand.Parameters.Add("@Career", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Career"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Rating", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Rating"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Date", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Date"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Place", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Place"].Value.ToString();
                da.SelectCommand.Parameters.Add("@LN", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["License No."].Value.ToString();
                da.SelectCommand.Parameters.Add("@LD", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Date of Released"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    CSEID = dr["CSEID"].ToString();
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
                if (CSEID != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblcse where CSEID=@CSEID";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@CSEID", MySqlDbType.VarChar).Value = CSEID;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Civil Service Eligibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SQL = "select Career,Rating,Date,Place,LN as `License No.`,LD as `Date of Released` from tblcse where EmpID=@EmpID";
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

        private void frmCSE_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Transaction = "New";

            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txtCareer.Clear();
            txtDateExam.Clear();
            txtDateRel.Clear();
            txtNumber.Clear();
            txtPlace.Clear();
            txtRating.Clear();

            txtCareer.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                Transaction = "Edit";

                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                txtCareer.Text = dgvList.SelectedRows[0].Cells["Career"].Value.ToString();
                txtDateExam.Text = dgvList.SelectedRows[0].Cells["Date"].Value.ToString();
                txtDateRel.Text = dgvList.SelectedRows[0].Cells["Date of Released"].Value.ToString();
                txtNumber.Text = dgvList.SelectedRows[0].Cells["License No."].Value.ToString();
                txtPlace.Text = dgvList.SelectedRows[0].Cells["Place"].Value.ToString();
                txtRating.Text = dgvList.SelectedRows[0].Cells["Rating"].Value.ToString();
                txtCareer.Focus();

                Career = txtCareer.Text;
                Date = txtDateExam.Text;
                LD = txtDateRel.Text;
                LN = txtNumber.Text;
                Place = txtPlace.Text;
                Rating = txtRating.Text;
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
                txtCareer.Clear();
                txtDateExam.Clear();
                txtDateRel.Clear();
                txtNumber.Clear();
                txtPlace.Clear();
                txtRating.Clear();

                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                txtCareer.Focus();
                dgvList.Enabled = true;
            }
            else if (Transaction == "Edit")
            {
                txtCareer.Text = Career;
                txtDateExam.Text = Date;
                txtDateRel.Text = LD;
                txtNumber.Text = LN;
                txtPlace.Text = Place;
                txtRating.Text = Rating;

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

        private void dtpDateExam_ValueChanged(object sender, EventArgs e)
        {
            txtDateExam.Text = dtpDateExam.Value.ToShortDateString();
        }

        private void dtpDateRel_ValueChanged(object sender, EventArgs e)
        {
            txtDateRel.Text = dtpDateRel.Value.ToShortDateString();
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
                if (MessageBox.Show("Are you sure, you want to delete this record", "Civil Service Eligibility", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    Deldata();
                }
            }
        }

    }
}
