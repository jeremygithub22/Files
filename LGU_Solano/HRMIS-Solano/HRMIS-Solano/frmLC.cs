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
    public partial class frmLC : Form
    {
        public frmLC()
        {
            InitializeComponent();
        }
        string SQL, Transaction, LCIDNo;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;
        string ActionC = "Go";
        static double SBal;
        static double VBal;
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Leave Credits", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtEmpID.Text != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tblleavecredits(EmpID,DateRec,Vearned,Searned,Vused,Sused,SLP,TardyUnder,VBal,SBal,Total,Remarks)values(@EmpID,@DateRec,@Vearned,@Searned,@Vused,@Sused,@SLP,@TardyUnder,@VBal,@SBal,@Total,@Remarks)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.InsertCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                        da.InsertCommand.Parameters.Add("@Vearned", MySqlDbType.VarChar).Value = txtEv.Text;
                        da.InsertCommand.Parameters.Add("@Searned", MySqlDbType.VarChar).Value = txtEs.Text;
                        da.InsertCommand.Parameters.Add("@Vused", MySqlDbType.VarChar).Value = txtUv.Text;
                        da.InsertCommand.Parameters.Add("@Sused", MySqlDbType.VarChar).Value = txtUs.Text;
                        da.InsertCommand.Parameters.Add("@SLP", MySqlDbType.VarChar).Value = txtSLP.Text;
                        da.InsertCommand.Parameters.Add("@TardyUnder", MySqlDbType.VarChar).Value = txtTU.Text;
                        da.InsertCommand.Parameters.Add("@VBal", MySqlDbType.VarChar).Value = txtBv.Text;
                        da.InsertCommand.Parameters.Add("@SBal", MySqlDbType.VarChar).Value = txtBs.Text;
                        da.InsertCommand.Parameters.Add("@Total", MySqlDbType.VarChar).Value = txtTotal.Text;
                        da.InsertCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();

                        MessageBox.Show("Successfully add record", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtBs.Clear();
                        txtBv.Clear();
                        txtEs.Clear();
                        txtEv.Clear();
                        txtSLP.Clear();
                        txtTotal.Clear();
                        txtTU.Clear();
                        txtUs.Clear();
                        txtUv.Clear();
                        dtpDate.Value = DateTime.Now;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtEv.Focus();
                        GetBal();
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Leave Credits", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (LCIDNo != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblleavecredits set DateRec=@DateRec,Vearned=@Vearned,Searned=@Searned,Vused=@Vused,Sused=@Sused,SLP=@SLP,TardyUnder=@TardyUnder,VBal=@VBal,SBal=@SBal,Total=@Total,Remarks=@Remarks where EmpID=@EmpID and LCIDNo=@LCIDNo";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.UpdateCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                        da.UpdateCommand.Parameters.Add("@Vearned", MySqlDbType.VarChar).Value = txtEv.Text;
                        da.UpdateCommand.Parameters.Add("@Searned", MySqlDbType.VarChar).Value = txtEs.Text;
                        da.UpdateCommand.Parameters.Add("@Vused", MySqlDbType.VarChar).Value = txtUv.Text;
                        da.UpdateCommand.Parameters.Add("@Sused", MySqlDbType.VarChar).Value = txtUs.Text;
                        da.UpdateCommand.Parameters.Add("@SLP", MySqlDbType.VarChar).Value = txtSLP.Text;
                        da.UpdateCommand.Parameters.Add("@TardyUnder", MySqlDbType.VarChar).Value = txtTU.Text;
                        da.UpdateCommand.Parameters.Add("@VBal", MySqlDbType.VarChar).Value = txtBv.Text;
                        da.UpdateCommand.Parameters.Add("@SBal", MySqlDbType.VarChar).Value = txtBs.Text;
                        da.UpdateCommand.Parameters.Add("@Total", MySqlDbType.VarChar).Value = txtTotal.Text;
                        da.UpdateCommand.Parameters.Add("@LCIDNo", MySqlDbType.VarChar).Value = LCIDNo;
                        da.UpdateCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();

                        MessageBox.Show("Successfully update record", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;

                        txtEv.Focus();
                        dgvList.Enabled = true;
                        GetBal();
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
                SQL = "select * from tblleavecredits where EmpID=@EmpID and DateRec=@DateRec and Vearned=@Vearned and Searned=@Searned and Vused=@Vused and Sused=@Sused and SLP=@SLP and TardyUnder=@TardyUnder and VBal=@VBal and SBal=@SBal and Total=@Total and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDate.Value;
                da.SelectCommand.Parameters.Add("@Vearned", MySqlDbType.VarChar).Value = txtEv.Text;
                da.SelectCommand.Parameters.Add("@Searned", MySqlDbType.VarChar).Value = txtEs.Text;
                da.SelectCommand.Parameters.Add("@Vused", MySqlDbType.VarChar).Value = txtUv.Text;
                da.SelectCommand.Parameters.Add("@Sused", MySqlDbType.VarChar).Value = txtUs.Text;
                da.SelectCommand.Parameters.Add("@SLP", MySqlDbType.VarChar).Value = txtSLP.Text;
                da.SelectCommand.Parameters.Add("@TardyUnder", MySqlDbType.VarChar).Value = txtTU.Text;
                da.SelectCommand.Parameters.Add("@VBal", MySqlDbType.VarChar).Value = txtBv.Text;
                da.SelectCommand.Parameters.Add("@SBal", MySqlDbType.VarChar).Value = txtBs.Text;
                da.SelectCommand.Parameters.Add("@Total", MySqlDbType.VarChar).Value = txtTotal.Text;
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = txtRemarks.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    LCIDNo = dr["LCIDNo"].ToString();
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
                SQL = "select * from tblleavecredits where EmpID=@EmpID and DateRec=@DateRec and Vearned=@Vearned and Searned=@Searned and Vused=@Vused and Sused=@Sused and SLP=@SLP and TardyUnder=@TardyUnder and VBal=@VBal and SBal=@SBal and Total=@Total and Remarks=@Remarks";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dgvList.SelectedRows[0].Cells["Date of Record"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Vearned", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Vacation Earned"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Searned", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Sick Earned"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Vused", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Vacation Used"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Sused", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Sick Used"].Value.ToString();
                da.SelectCommand.Parameters.Add("@SLP", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["SLP"].Value.ToString();
                da.SelectCommand.Parameters.Add("@TardyUnder", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Tardy/Under"].Value.ToString();
                da.SelectCommand.Parameters.Add("@VBal", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Vacation Balance"].Value.ToString();
                da.SelectCommand.Parameters.Add("@SBal", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Sick Balance"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Total", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Total"].Value.ToString();
                da.SelectCommand.Parameters.Add("@Remarks", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    LCIDNo = dr["LCIDNo"].ToString();
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
                if (LCIDNo != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblleavecredits where LCIDNo=@LCIDNo";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@LCIDNo", MySqlDbType.VarChar).Value = LCIDNo;
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Display();
                    GetBal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstEmployee.DisplayMember = "Name";
                        lstEmployee.ValueMember = "EmpID";
                        lstEmployee.DataSource = dt;
                    }
                    else
                    {
                        lstEmployee.DataSource = null;
                        MessageBox.Show("Employee does not exist.", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Credits", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        void GetBal()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblleavecredits where EmpID=@EmpID order by LCIDNo desc";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtBv.Text = dr["VBal"].ToString();
                    txtBs.Text = dr["SBal"].ToString();
                    SBal = double.Parse(dr["SBal"].ToString());
                    VBal = double.Parse(dr["VBal"].ToString());
                    double Total = (double.Parse(txtBv.Text) * 1) + (double.Parse(txtBs.Text) * 1);
                    txtTotal.Text = Total.ToString();
                }
                else
                {
                    txtBv.Text = "0.000";
                    txtBs.Text = "0.000";
                    SBal = 0.000;
                    VBal = 0.000;
                    double Total = (double.Parse(txtBv.Text) * 1) + (double.Parse(txtBs.Text) * 1);
                    txtTotal.Text = Total.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Display()
        {
            try
            {
                txtEmpID.Text = lstEmployee.SelectedValue.ToString();
                txtName.Text = lstEmployee.Text;
                conn.SetConstr();
                SQL = "select DateRec as `Date of Record`,Vearned as `Vacation Earned`,Searned as `Sick Earned`,Vused as `Vacation Used`,Sused as `Sick Used`,SLP,TardyUnder as `Tardy/Under`,VBal as `Vacation Balance`,SBal as `Sick Balance`,Total,Remarks from tblleavecredits where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = lstEmployee.SelectedValue.ToString();
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
        void CEarnedV()
        {
            try
            {
                double vacation = double.Parse(txtEv.Text);
                double vbaln = (vacation * 1) + (VBal * 1);
                txtBv.Text = vbaln.ToString();
                double Total = (vbaln * 1) + (double.Parse(txtBs.Text) * 1);
                txtTotal.Text = Total.ToString();
            }
            catch
            {
            }
        }
        void CEarnedS()
        {
            try
            {
                double sick = double.Parse(txtEs.Text);
                double sbaln = (sick * 1) + (SBal * 1);
                txtBs.Text = sbaln.ToString();
                double Total = (double.Parse(txtBv.Text) * 1) + (sbaln * 1);
                txtTotal.Text = Total.ToString();
            }
            catch
            {
            }
        }
        void CULV()
        {
            try
            {
                double vacation = double.Parse(txtUv.Text);
                double tardiU = double.Parse(txtTU.Text);
                double vbaln = VBal - (vacation + tardiU);
                txtBv.Text = vbaln.ToString();
                double Total = (vbaln * 1) + (double.Parse(txtBs.Text) * 1);
                txtTotal.Text = Total.ToString();
            }
            catch
            {
            }
        }
        void CULS()
        {
            try
            {
                double sick = double.Parse(txtUs.Text);
                double sbaln = SBal - sick;
                txtBs.Text = sbaln.ToString();
                double Total = (double.Parse(txtBv.Text) * 1) + (sbaln * 1);
                txtTotal.Text = Total.ToString();
            }
            catch
            {
            }
        }
        void CTU()
        {
            try
            {
                double tardiU = double.Parse(txtTU.Text);
                double vbaln = VBal - tardiU;
                txtBv.Text = vbaln.ToString();
                double Total = (vbaln * 1) + (double.Parse(txtBs.Text) * 1);
                txtTotal.Text = Total.ToString();
            }
            catch
            {
            }
        }

        private void txtEv_TextChanged(object sender, EventArgs e)
        {
            if (ActionC == "Go")
            {
                CEarnedV();
            }
        }

        private void txtEs_TextChanged(object sender, EventArgs e)
        {
            if (ActionC == "Go")
            {
                CEarnedS();
            }
        }

        private void txtUv_TextChanged(object sender, EventArgs e)
        {
            if (ActionC == "Go")
            {
                CULV();
            }
        }

        private void txtUs_TextChanged(object sender, EventArgs e)
        {
            if (ActionC == "Go")
            {
                CULS();
            }
        }

        private void txtTU_TextChanged(object sender, EventArgs e)
        {
            if (ActionC == "Go")
            {
                CULV();
            }
        }

        private void cboSearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
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
                GetBal();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Transaction = "New";

            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txtEs.Clear();
            txtEv.Clear();
            txtSLP.Clear();
            txtTU.Clear();
            txtUs.Clear();
            txtUv.Clear();
            dtpDate.Value = DateTime.Now;

            txtEv.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                try
                {
                    Transaction = "Edit";
                    ActionC = "Stop";
                    btnNew.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;

                    txtEs.Text = dgvList.SelectedRows[0].Cells["Sick Earned"].Value.ToString();
                    txtEv.Text = dgvList.SelectedRows[0].Cells["Vacation Earned"].Value.ToString();
                    txtSLP.Text = dgvList.SelectedRows[0].Cells["SLP"].Value.ToString();
                    txtTU.Text = dgvList.SelectedRows[0].Cells["Tardy/Under"].Value.ToString();
                    txtUs.Text = dgvList.SelectedRows[0].Cells["Sick Used"].Value.ToString();
                    txtUv.Text = dgvList.SelectedRows[0].Cells["Vacation Used"].Value.ToString();
                    dtpDate.Text = dgvList.SelectedRows[0].Cells["Date of Record"].Value.ToString();
                    txtBs.Text = dgvList.SelectedRows[0].Cells["Sick Balance"].Value.ToString();
                    txtBv.Text = dgvList.SelectedRows[0].Cells["Vacation Balance"].Value.ToString();
                    txtTotal.Text = dgvList.SelectedRows[0].Cells["Total"].Value.ToString();
                    txtRemarks.Text = dgvList.SelectedRows[0].Cells["Remarks"].Value.ToString();

                    GetID();

                    dgvList.Enabled = false;

                    txtEv.Focus();
                    ActionC = "Go";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            txtBs.Clear();
            txtBv.Clear();
            txtEs.Clear();
            txtEmpID.Clear();
            txtEv.Clear();
            txtName.Clear();
            txtSLP.Clear();
            txtTotal.Clear();
            txtTU.Clear();
            txtUs.Clear();
            txtUv.Clear();
            dgvList.DataSource = null;
            dtpDate.Value = DateTime.Now;
            dgvList.Enabled = true;
            if (UserDetails.APLC == "1")
            {
                btnNew.Enabled = true;
            }
            btnEdit.Enabled = false;
            btnSave.Enabled = false;

        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (UserDetails.EPLC == "1")
                {
                    btnEdit.Enabled = true;
                }
                if (UserDetails.DPLC == "1")
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record", "Leave Credits", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetIDDel();
                    Deldata();
                }
            }
        }

        private void frmLC_Load(object sender, EventArgs e)
        {
            if (UserDetails.APLC == "1")
            {
                btnNew.Enabled = true;
            }
        }
    }
}
