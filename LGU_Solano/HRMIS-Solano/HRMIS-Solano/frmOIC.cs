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
    public partial class frmOIC : Form
    {
        public frmOIC()
        {
            InitializeComponent();
        }
        string SQL, Transaction, a36, b36, a37, b37, a38, a39, a40, a41, b41, c41, ad36, bd36, ad37, bd37, ad38, ad39, ad40, ad41, bd41, cd41, CertNo, DateAcc, Issueon, Issuedat;
        public string EmpID;
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();

        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tbloic where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    txt36ad.Text = dr["36ad"].ToString();
                    txt36bd.Text = dr["36bd"].ToString();
                    txt37ad.Text = dr["37ad"].ToString();
                    txt37bd.Text = dr["37bd"].ToString();
                    txt38d.Text = dr["38ad"].ToString();
                    txt39d.Text = dr["39ad"].ToString();
                    txt40d.Text = dr["40ad"].ToString();
                    txt41ad.Text = dr["41ad"].ToString();
                    txt41bd.Text = dr["41bd"].ToString();
                    txt41cd.Text = dr["41cd"].ToString();
                    txtCertno.Text = dr["Ctaxn"].ToString();
                    txtDateAcc.Text = dr["DateAccomplished"].ToString();
                    txtIssuedat.Text = dr["Issuedat"].ToString();
                    txtIssuedon.Text = dr["Issedon"].ToString();

                    if (dr["36a"].ToString() == "Yes")
                    {
                        rb36aYes.Checked = true;
                    }
                    else if (dr["36a"].ToString() == "No")
                    {
                        rb36aNo.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["36b"].ToString() == "Yes")
                    {
                        rb36bYes.Checked = true;
                    }
                    else if (dr["36b"].ToString() == "No")
                    {
                        rb36bNo.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["37a"].ToString() == "Yes")
                    {
                        rb37aYes.Checked = true;
                    }
                    else if (dr["37a"].ToString() == "No")
                    {
                        rb37aNo.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["37b"].ToString() == "Yes")
                    {
                        rb37bYes.Checked = true;
                    }
                    else if (dr["37b"].ToString() == "No")
                    {
                        rb37bNo.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["38a"].ToString() == "Yes")
                    {
                        rb38Yes.Checked = true;
                    }
                    else if (dr["38a"].ToString() == "No")
                    {
                        rb38No.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["39a"].ToString() == "Yes")
                    {
                        rb39Yes.Checked = true;
                    }
                    else if (dr["39a"].ToString() == "No")
                    {
                        rb39No.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["40a"].ToString() == "Yes")
                    {
                        rb40Yes.Checked = true;
                    }
                    else if (dr["40a"].ToString() == "No")
                    {
                        rb40No.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["41a"].ToString() == "Yes")
                    {
                        rb41aYes.Checked = true;
                    }
                    else if (dr["41a"].ToString() == "No")
                    {
                        rb41aNo.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["41b"].ToString() == "Yes")
                    {
                        rb41bYes.Checked = true;
                    }
                    else if (dr["41b"].ToString() == "No")
                    {
                        rb41bNo.Checked = true;
                    }
                    else
                    {
                    }

                    if (dr["41c"].ToString() == "Yes")
                    {
                        rb41cYes.Checked = true;
                    }
                    else if (dr["41c"].ToString() == "No")
                    {
                        rb41cNo.Checked = true;
                    }
                    else
                    {
                    }

                    txt36ad.Enabled = false;
                    txt36bd.Enabled = false;
                    txt37ad.Enabled = false;
                    txt37bd.Enabled = false;
                    txt38d.Enabled = false;
                    txt39d.Enabled = false;
                    txt40d.Enabled = false;
                    txt41ad.Enabled = false;
                    txt41bd.Enabled = false;
                    txt41cd.Enabled = false;
                    txtCertno.Enabled = false;
                    txtDateAcc.Enabled = false;
                    txtIssuedat.Enabled = false;
                    txtIssuedon.Enabled = false;

                    rb36aNo.Enabled = false;
                    rb36aYes.Enabled = false;
                    rb36bNo.Enabled = false;
                    rb36bYes.Enabled = false;
                    rb37aNo.Enabled = false;
                    rb37aYes.Enabled = false;
                    rb37bNo.Enabled = false;
                    rb37bYes.Enabled = false;
                    rb38No.Enabled = false;
                    rb38Yes.Enabled = false;
                    rb39No.Enabled = false;
                    rb39Yes.Enabled = false;
                    rb40No.Enabled = false;
                    rb40Yes.Enabled = false;
                    rb41aNo.Enabled = false;
                    rb41aYes.Enabled = false;
                    rb41bNo.Enabled = false;
                    rb41bYes.Enabled = false;
                    rb41cNo.Enabled = false;
                    rb41cYes.Enabled = false;

                    btnNew.Enabled = false;
                    if (UserDetails.EPPI == "1")
                    {
                        btnEdit.Enabled = true;
                    }
                    btnSave.Enabled = false;

                    dtpDateAcc.Enabled = false;
                    dtpIssuedon.Enabled = false;

                }
                else
                {
                    if (UserDetails.APPI == "1")
                    {
                        btnNew.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Other Information (Cont.)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "insert into tbloic (EmpID,36a,36ad,36b,36bd,37a,37ad,37b,37bd,38a,38ad,39a,39ad,40a,40ad,41a,41ad,41b,41bd,41c,41cd,Ctaxn,Issuedat,Issedon,DateAccomplished)values(@EmpID,@36a,@36ad,@36b,@36bd,@37a,@37ad,@37b,@37bd,@38a,@38ad,@39a,@39ad,@40a,@40ad,@41a,@41ad,@41b,@41bd,@41c,@41cd,@Ctaxn,@Issuedat,@Issedon,@DateAccomplished)";
                        da = new MySqlDataAdapter();
                        da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.InsertCommand.Parameters.Add("@36a", MySqlDbType.VarChar).Value = a36;
                        da.InsertCommand.Parameters.Add("@36ad", MySqlDbType.VarChar).Value = txt36ad.Text;
                        da.InsertCommand.Parameters.Add("@36b", MySqlDbType.VarChar).Value = b36;
                        da.InsertCommand.Parameters.Add("@36bd", MySqlDbType.VarChar).Value = txt36bd.Text;
                        da.InsertCommand.Parameters.Add("@37a", MySqlDbType.VarChar).Value = a37;
                        da.InsertCommand.Parameters.Add("@37ad", MySqlDbType.VarChar).Value = txt37ad.Text;
                        da.InsertCommand.Parameters.Add("@37b", MySqlDbType.VarChar).Value = b37;
                        da.InsertCommand.Parameters.Add("@37bd", MySqlDbType.VarChar).Value = txt37bd.Text;
                        da.InsertCommand.Parameters.Add("@38a", MySqlDbType.VarChar).Value = a38;
                        da.InsertCommand.Parameters.Add("@38ad", MySqlDbType.VarChar).Value = txt38d.Text;
                        da.InsertCommand.Parameters.Add("@39a", MySqlDbType.VarChar).Value = a39;
                        da.InsertCommand.Parameters.Add("@39ad", MySqlDbType.VarChar).Value = txt39d.Text;
                        da.InsertCommand.Parameters.Add("@40a", MySqlDbType.VarChar).Value = a40;
                        da.InsertCommand.Parameters.Add("@40ad", MySqlDbType.VarChar).Value = txt40d.Text;
                        da.InsertCommand.Parameters.Add("@41a", MySqlDbType.VarChar).Value = a41;
                        da.InsertCommand.Parameters.Add("@41ad", MySqlDbType.VarChar).Value = txt41ad.Text;
                        da.InsertCommand.Parameters.Add("@41b", MySqlDbType.VarChar).Value = b41;
                        da.InsertCommand.Parameters.Add("@41bd", MySqlDbType.VarChar).Value = txt41bd.Text;
                        da.InsertCommand.Parameters.Add("@41c", MySqlDbType.VarChar).Value = c41;
                        da.InsertCommand.Parameters.Add("@41cd", MySqlDbType.VarChar).Value = txt41cd.Text;
                        da.InsertCommand.Parameters.Add("@Ctaxn", MySqlDbType.VarChar).Value = txtCertno.Text;
                        da.InsertCommand.Parameters.Add("@Issuedat", MySqlDbType.VarChar).Value = txtIssuedat.Text;
                        da.InsertCommand.Parameters.Add("@Issedon", MySqlDbType.VarChar).Value = txtIssuedon.Text;
                        da.InsertCommand.Parameters.Add("@DateAccomplished", MySqlDbType.VarChar).Value = txtDateAcc.Text;
                        Connection.Conn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Other Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt36ad.Enabled = false;
                        txt36bd.Enabled = false;
                        txt37ad.Enabled = false;
                        txt37bd.Enabled = false;
                        txt38d.Enabled = false;
                        txt39d.Enabled = false;
                        txt40d.Enabled = false;
                        txt41ad.Enabled = false;
                        txt41bd.Enabled = false;
                        txt41cd.Enabled = false;
                        txtCertno.Enabled = false;
                        txtDateAcc.Enabled = false;
                        txtIssuedat.Enabled = false;
                        txtIssuedon.Enabled = false;

                        rb36aNo.Enabled = false;
                        rb36aYes.Enabled = false;
                        rb36bNo.Enabled = false;
                        rb36bYes.Enabled = false;
                        rb37aNo.Enabled = false;
                        rb37aYes.Enabled = false;
                        rb37bNo.Enabled = false;
                        rb37bYes.Enabled = false;
                        rb38No.Enabled = false;
                        rb38Yes.Enabled = false;
                        rb39No.Enabled = false;
                        rb39Yes.Enabled = false;
                        rb40No.Enabled = false;
                        rb40Yes.Enabled = false;
                        rb41aNo.Enabled = false;
                        rb41aYes.Enabled = false;
                        rb41bNo.Enabled = false;
                        rb41bYes.Enabled = false;
                        rb41cNo.Enabled = false;
                        rb41cYes.Enabled = false;

                        btnNew.Enabled = false;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;

                        dtpDateAcc.Enabled = false;
                        dtpIssuedon.Enabled = false;
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Other Information (Cont.)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EmpID != "")
                    {
                        conn.SetConstr();
                        SQL = "update tbloic set 36a=@36a,36ad=@36ad,36b=@36b,36bd=@36bd,37a=@37a,37ad=@37ad,37b=@37b,37bd=@37bd,38a=@38a,38ad=@38ad,39a=@39a,39ad=@39ad,40a=@40a,40ad=@40ad,41a=@41a,41ad=@41ad,41b=@41b,41bd=@41bd,41c=@41c,41cd=@41cd,Ctaxn=@Ctaxn,Issuedat=@Issuedat,Issedon=@Issedon,DateAccomplished=@DateAccomplished where EmpID=@EmpID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = EmpID;
                        da.UpdateCommand.Parameters.Add("@36a", MySqlDbType.VarChar).Value = a36;
                        da.UpdateCommand.Parameters.Add("@36ad", MySqlDbType.VarChar).Value = txt36ad.Text;
                        da.UpdateCommand.Parameters.Add("@36b", MySqlDbType.VarChar).Value = b36;
                        da.UpdateCommand.Parameters.Add("@36bd", MySqlDbType.VarChar).Value = txt36bd.Text;
                        da.UpdateCommand.Parameters.Add("@37a", MySqlDbType.VarChar).Value = a37;
                        da.UpdateCommand.Parameters.Add("@37ad", MySqlDbType.VarChar).Value = txt37ad.Text;
                        da.UpdateCommand.Parameters.Add("@37b", MySqlDbType.VarChar).Value = b37;
                        da.UpdateCommand.Parameters.Add("@37bd", MySqlDbType.VarChar).Value = txt37bd.Text;
                        da.UpdateCommand.Parameters.Add("@38a", MySqlDbType.VarChar).Value = a38;
                        da.UpdateCommand.Parameters.Add("@38ad", MySqlDbType.VarChar).Value = txt38d.Text;
                        da.UpdateCommand.Parameters.Add("@39a", MySqlDbType.VarChar).Value = a39;
                        da.UpdateCommand.Parameters.Add("@39ad", MySqlDbType.VarChar).Value = txt39d.Text;
                        da.UpdateCommand.Parameters.Add("@40a", MySqlDbType.VarChar).Value = a40;
                        da.UpdateCommand.Parameters.Add("@40ad", MySqlDbType.VarChar).Value = txt40d.Text;
                        da.UpdateCommand.Parameters.Add("@41a", MySqlDbType.VarChar).Value = a41;
                        da.UpdateCommand.Parameters.Add("@41ad", MySqlDbType.VarChar).Value = txt41ad.Text;
                        da.UpdateCommand.Parameters.Add("@41b", MySqlDbType.VarChar).Value = b41;
                        da.UpdateCommand.Parameters.Add("@41bd", MySqlDbType.VarChar).Value = txt41bd.Text;
                        da.UpdateCommand.Parameters.Add("@41c", MySqlDbType.VarChar).Value = c41;
                        da.UpdateCommand.Parameters.Add("@41cd", MySqlDbType.VarChar).Value = txt41cd.Text;
                        da.UpdateCommand.Parameters.Add("@Ctaxn", MySqlDbType.VarChar).Value = txtCertno.Text;
                        da.UpdateCommand.Parameters.Add("@Issuedat", MySqlDbType.VarChar).Value = txtIssuedat.Text;
                        da.UpdateCommand.Parameters.Add("@Issedon", MySqlDbType.VarChar).Value = txtIssuedon.Text;
                        da.UpdateCommand.Parameters.Add("@DateAccomplished", MySqlDbType.VarChar).Value = txtDateAcc.Text;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully update record", "Other Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt36ad.Enabled = false;
                        txt36bd.Enabled = false;
                        txt37ad.Enabled = false;
                        txt37bd.Enabled = false;
                        txt38d.Enabled = false;
                        txt39d.Enabled = false;
                        txt40d.Enabled = false;
                        txt41ad.Enabled = false;
                        txt41bd.Enabled = false;
                        txt41cd.Enabled = false;
                        txtCertno.Enabled = false;
                        txtDateAcc.Enabled = false;
                        txtIssuedat.Enabled = false;
                        txtIssuedon.Enabled = false;

                        rb36aNo.Enabled = false;
                        rb36aYes.Enabled = false;
                        rb36bNo.Enabled = false;
                        rb36bYes.Enabled = false;
                        rb37aNo.Enabled = false;
                        rb37aYes.Enabled = false;
                        rb37bNo.Enabled = false;
                        rb37bYes.Enabled = false;
                        rb38No.Enabled = false;
                        rb38Yes.Enabled = false;
                        rb39No.Enabled = false;
                        rb39Yes.Enabled = false;
                        rb40No.Enabled = false;
                        rb40Yes.Enabled = false;
                        rb41aNo.Enabled = false;
                        rb41aYes.Enabled = false;
                        rb41bNo.Enabled = false;
                        rb41bYes.Enabled = false;
                        rb41cNo.Enabled = false;
                        rb41cYes.Enabled = false;

                        btnNew.Enabled = false;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;

                        dtpDateAcc.Enabled = false;
                        dtpIssuedon.Enabled = false;
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
            Transaction = "New";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txt36ad.Clear();
            txt36bd.Clear();
            txt37ad.Clear();
            txt37bd.Clear();
            txt38d.Clear();
            txt39d.Clear();
            txt40d.Clear();
            txt41ad.Clear();
            txt41bd.Clear();
            txt41cd.Clear();
            txtCertno.Clear();
            txtDateAcc.Clear();
            txtIssuedat.Clear();
            txtIssuedon.Clear();

            dtpDateAcc.Value = DateTime.Now;
            dtpIssuedon.Value = DateTime.Now;

            rb36aNo.Checked = false;
            rb36aYes.Checked = false;
            rb36bNo.Checked = false;
            rb36bYes.Checked = false;
            rb37aNo.Checked = false;
            rb37aYes.Checked = false;
            rb37bNo.Checked = false;
            rb37bYes.Checked = false;
            rb38No.Checked = false;
            rb38Yes.Checked = false;
            rb39No.Checked = false;
            rb39Yes.Checked = false;
            rb40No.Checked = false;
            rb40Yes.Checked = false;
            rb41aNo.Checked = false;
            rb41aYes.Checked = false;
            rb41bNo.Checked = false;
            rb41bYes.Checked = false;
            rb41cNo.Checked = false;
            rb41cYes.Checked = false;


            txt36ad.Enabled = false;
            txt36bd.Enabled = false;
            txt37ad.Enabled = false;
            txt37bd.Enabled = false;
            txt38d.Enabled = false;
            txt39d.Enabled = false;
            txt40d.Enabled = false;
            txt41ad.Enabled = false;
            txt41bd.Enabled = false;
            txt41cd.Enabled = false;
            txtCertno.Enabled = true;
            txtDateAcc.Enabled = true;
            txtIssuedat.Enabled = true;
            txtIssuedon.Enabled = true;

            dtpDateAcc.Enabled = true;
            dtpIssuedon.Enabled = true;

            rb36aNo.Enabled = true;
            rb36aYes.Enabled = true;
            rb36bNo.Enabled = true;
            rb36bYes.Enabled = true;
            rb37aNo.Enabled = true;
            rb37aYes.Enabled = true;
            rb37bNo.Enabled = true;
            rb37bYes.Enabled = true;
            rb38No.Enabled = true;
            rb38Yes.Enabled = true;
            rb39No.Enabled = true;
            rb39Yes.Enabled = true;
            rb40No.Enabled = true;
            rb40Yes.Enabled = true;
            rb41aNo.Enabled = true;
            rb41aYes.Enabled = true;
            rb41bNo.Enabled = true;
            rb41bYes.Enabled = true;
            rb41cNo.Enabled = true;
            rb41cYes.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Transaction = "Edit";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txt36ad.Enabled = true;
            ad36 = txt36ad.Text;
            txt36bd.Enabled = true;
            bd36 = txt36bd.Text;
            txt37ad.Enabled = true;
            ad37 = txt37ad.Text;
            txt37bd.Enabled = true;
            bd37 = txt37bd.Text;
            txt38d.Enabled = true;
            ad38 = txt38d.Text;
            txt39d.Enabled = true;
            ad39 = txt39d.Text;
            txt40d.Enabled = true;
            ad40 = txt40d.Text;
            txt41ad.Enabled = true;
            ad41 = txt41ad.Text;
            txt41bd.Enabled = true;
            bd41 = txt41bd.Text;
            txt41cd.Enabled = true;
            cd41 = txt41cd.Text;
            txtCertno.Enabled = true;
            CertNo = txtCertno.Text;
            txtDateAcc.Enabled = true;
            DateAcc = txtDateAcc.Text;
            txtIssuedat.Enabled = true;
            Issuedat = txtIssuedat.Text;
            txtIssuedon.Enabled = true;
            Issueon = txtIssuedon.Text;

            dtpDateAcc.Enabled = true;
            dtpIssuedon.Enabled = true;

            rb36aNo.Enabled = true;
            rb36aYes.Enabled = true;
            rb36bNo.Enabled = true;
            rb36bYes.Enabled = true;
            rb37aNo.Enabled = true;
            rb37aYes.Enabled = true;
            rb37bNo.Enabled = true;
            rb37bYes.Enabled = true;
            rb38No.Enabled = true;
            rb38Yes.Enabled = true;
            rb39No.Enabled = true;
            rb39Yes.Enabled = true;
            rb40No.Enabled = true;
            rb40Yes.Enabled = true;
            rb41aNo.Enabled = true;
            rb41aYes.Enabled = true;
            rb41bNo.Enabled = true;
            rb41bYes.Enabled = true;
            rb41cNo.Enabled = true;
            rb41cYes.Enabled = true;
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
                Transaction = "New";
                
                if (UserDetails.APPI == "1")
                {
                    btnNew.Enabled = true;
                }
                btnEdit.Enabled = false;
                btnSave.Enabled = false;

                txt36ad.Clear();
                txt36bd.Clear();
                txt37ad.Clear();
                txt37bd.Clear();
                txt38d.Clear();
                txt39d.Clear();
                txt40d.Clear();
                txt41ad.Clear();
                txt41bd.Clear();
                txt41cd.Clear();
                txtCertno.Clear();
                txtDateAcc.Clear();
                txtIssuedat.Clear();
                txtIssuedon.Clear();

                dtpDateAcc.Value = DateTime.Now;
                dtpIssuedon.Value = DateTime.Now;

                rb36aNo.Checked = false;
                rb36aYes.Checked = false;
                rb36bNo.Checked = false;
                rb36bYes.Checked = false;
                rb37aNo.Checked = false;
                rb37aYes.Checked = false;
                rb37bNo.Checked = false;
                rb37bYes.Checked = false;
                rb38No.Checked = false;
                rb38Yes.Checked = false;
                rb39No.Checked = false;
                rb39Yes.Checked = false;
                rb40No.Checked = false;
                rb40Yes.Checked = false;
                rb41aNo.Checked = false;
                rb41aYes.Checked = false;
                rb41bNo.Checked = false;
                rb41bYes.Checked = false;
                rb41cNo.Checked = false;
                rb41cYes.Checked = false;


                txt36ad.Enabled = true;
                txt36bd.Enabled = true;
                txt37ad.Enabled = true;
                txt37bd.Enabled = true;
                txt38d.Enabled = true;
                txt39d.Enabled = true;
                txt40d.Enabled = true;
                txt41ad.Enabled = true;
                txt41bd.Enabled = true;
                txt41cd.Enabled = true;
                txtCertno.Enabled = true;
                txtDateAcc.Enabled = true;
                txtIssuedat.Enabled = true;
                txtIssuedon.Enabled = true;

                dtpDateAcc.Enabled = true;
                dtpIssuedon.Enabled = true;

                rb36aNo.Enabled = true;
                rb36aYes.Enabled = true;
                rb36bNo.Enabled = true;
                rb36bYes.Enabled = true;
                rb37aNo.Enabled = true;
                rb37aYes.Enabled = true;
                rb37bNo.Enabled = true;
                rb37bYes.Enabled = true;
                rb38No.Enabled = true;
                rb38Yes.Enabled = true;
                rb39No.Enabled = true;
                rb39Yes.Enabled = true;
                rb40No.Enabled = true;
                rb40Yes.Enabled = true;
                rb41aNo.Enabled = true;
                rb41aYes.Enabled = true;
                rb41bNo.Enabled = true;
                rb41bYes.Enabled = true;
                rb41cNo.Enabled = true;
                rb41cYes.Enabled = true;
            }
            else if (Transaction == "Edit")
            {
                Transaction = "Edit";
                btnNew.Enabled = false;
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Enabled = true;
                }
                btnSave.Enabled = false;

                txt36ad.Enabled = false;
                txt36ad.Text = ad36;
                txt36bd.Enabled = false;
                txt36bd.Text = bd36;
                txt37ad.Enabled = false;
                txt37ad.Text = ad37;
                txt37bd.Enabled =false;
                txt37bd.Text = bd37;
                txt38d.Enabled = false;
                txt38d.Text = ad38;
                txt39d.Enabled = false;
                txt39d.Text = ad39;
                txt40d.Enabled = false;
                txt40d.Text = ad40;
                txt41ad.Enabled = false;
                txt41ad.Text = ad41;
                txt41bd.Enabled = false;
                txt41bd.Text = bd41;
                txt41cd.Enabled = false;
                txt41cd.Text = cd41;
                txtCertno.Enabled = false;
                txtCertno.Text = CertNo;
                txtDateAcc.Enabled = false;
                txtDateAcc.Text = DateAcc;
                txtIssuedat.Enabled = false;
                txtIssuedat.Text = Issuedat;
                txtIssuedon.Enabled = false;
                txtIssuedon.Text = Issueon;

                dtpDateAcc.Enabled = false;
                dtpIssuedon.Enabled = false;

                if (a36 == "No")
                {
                    rb36aNo.Checked = true;
                    rb36aNo.Enabled = false;
                }

                if (a36 == "Yes")
                {
                    rb36aYes.Checked = true;
                    rb36aYes.Enabled = false;
                }

                if (b36 == "No")
                {
                    rb36bNo.Checked = true;
                    rb36bNo.Enabled = false;
                }

                if (b36 == "Yes")
                {
                    rb36bYes.Checked = true;
                    rb36bYes.Enabled = false;
                }

                if (a37 == "No")
                {
                    rb37aNo.Checked = true;
                    rb37aNo.Enabled = false;
                }

                if (a37 == "Yes")
                {
                    rb37aYes.Checked = true;
                    rb37aYes.Enabled = false;
                }

                if (b37 == "No")
                {
                    rb37bNo.Checked = true;
                    rb37bNo.Enabled = false;
                }

                if (b37 == "Yes")
                {
                    rb37bYes.Checked = true;
                    rb37bYes.Enabled = false;
                }

                if (a38 == "No")
                {
                    rb38No.Checked = true;
                    rb38No.Enabled = false;
                }

                if (a38 == "Yes")
                {
                    rb38Yes.Checked = true;
                    rb38Yes.Enabled = false;
                }

                if (a39 == "No")
                {
                    rb39No.Checked = true;
                    rb39No.Enabled = false;
                }

                if (a39 == "Yes")
                {
                    rb39Yes.Checked = true;
                    rb39Yes.Enabled = false;
                }

                if (a40 == "No")
                {
                    rb40No.Checked = true;
                    rb40No.Enabled = false;
                }

                if (a40 == "Yes")
                {
                    rb40Yes.Checked = true;
                    rb40Yes.Enabled = false;
                }

                if (a41 == "No")
                {
                    rb41aNo.Checked = true;
                    rb41aNo.Enabled = false;
                }

                if (a41 == "Yes")
                {
                    rb41aYes.Checked = true;
                    rb41aYes.Enabled = false;
                }

                if (b41 == "No")
                {
                    rb41bNo.Checked = true;
                    rb41bNo.Enabled = false;
                }

                if (b41 == "Yes")
                {
                    rb41bYes.Checked = true;
                    rb41bYes.Enabled = false;
                }

                if (c41 == "No")
                {
                    rb41cNo.Checked = true;
                    rb41cNo.Enabled = false;
                }

                if (c41 == "Yes")
                {
                    rb41cYes.Checked = true;
                    rb41cYes.Enabled = false;
                }
            }
            else
            {
            }
        }

        private void rb36aYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb36aYes.Checked == true)
            {
                a36 = "Yes";
                txt36ad.Enabled = true;
            }
        }

        private void rb36aNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb36bNo.Checked == true)
            {
                a36 = "No";
                txt36ad.Enabled = false;
            }
        }

        private void rb36bYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb36bYes.Checked == true)
            {
                b36 = "Yes";
                txt36bd.Enabled = true;
            }
        }

        private void rb36bNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb36bNo.Checked == true)
            {
                b36 = "No";
                txt36bd.Enabled = false;
            }
        }

        private void rb37aYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb37aYes.Checked == true)
            {
                a37 = "Yes";
                txt37ad.Enabled = true;
            }
        }

        private void rb37aNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb37aNo.Checked == true)
            {
                a37 = "No";
                txt37ad.Enabled = false;
            }
        }

        private void rb37bYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb37bYes.Checked == true)
            {
                b37 = "Yes";
                txt37bd.Enabled = true;
            }
        }

        private void rb37bNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb37bNo.Checked == true)
            {
                b37 = "No";
                txt37bd.Enabled = false;
            }
        }

        private void rb38Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb38Yes.Checked == true)
            {
                a38 = "Yes";
                txt38d.Enabled = true;
            }
        }

        private void rb38No_CheckedChanged(object sender, EventArgs e)
        {
            if (rb38No.Checked == true)
            {
                a38 = "No";
                txt38d.Enabled = false;
            }
        }

        private void rb39Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb39Yes.Checked == true)
            {
                a39 = "Yes";
                txt39d.Enabled = true;
            }
        }

        private void rb39No_CheckedChanged(object sender, EventArgs e)
        {
            if (rb39No.Checked == true)
            {
                a39 = "No";
                txt39d.Enabled = false;
            }
        }

        private void rb40Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb40Yes.Checked == true)
            {
                a40 = "Yes";
                txt40d.Enabled = true;
            }
        }

        private void rb40No_CheckedChanged(object sender, EventArgs e)
        {
            if (rb40No.Checked == true)
            {
                a40 = "No";
                txt40d.Enabled = false;
            }
        }

        private void rb41aYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb41aYes.Checked == true)
            {
                a41 = "Yes";
                txt41ad.Enabled = true;
            }
        }

        private void rb41aNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb41aNo.Checked == true)
            {
                a41 = "No";
                txt41ad.Enabled = false;
            }
        }

        private void rb41bYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb41bYes.Checked == true)
            {
                b41 = "Yes";
                txt41bd.Enabled = true;
            }
        }

        private void rb41bNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb41bNo.Checked == true)
            {
                b41 = "No";
                txt41bd.Enabled = false;
            }
        }

        private void rb41cYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rb41cYes.Checked == true)
            {
                c41 = "Yes";
                txt41cd.Enabled = true;
            }
        }

        private void rb41cNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb41cNo.Checked == true)
            {
                c41 = "No";
                txt41cd.Enabled = false;
            }
        }

        private void dtpIssuedon_ValueChanged(object sender, EventArgs e)
        {
            txtIssuedon.Text = dtpIssuedon.Value.ToShortDateString();
        }

        private void dtpDateAcc_ValueChanged(object sender, EventArgs e)
        {
            txtDateAcc.Text = dtpDateAcc.Value.ToShortDateString();
        }

        private void frmOIC_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void rb36aNo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rb36aNo.Checked == true)
            {
                a36 = "No";
                txt36ad.Enabled = false;
            }
        }

    }
}
