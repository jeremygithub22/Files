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
    public partial class frmUserAcct : Form
    {
        public frmUserAcct()
        {
            InitializeComponent();
        }
        string SQL, PI = "Not Allow", R = "Not Allow", LS = "Not Allow", LR = "Not Allow", LC = "Not Allow", TU = "Not Allow", SR = "Not Allow", Transaction, FC = "Not Allow", FR = "Not Allow", WLS = "Not Allow";
        string piAdd = "0", piEdit = "0", piDel = "0", lsAdd = "0", lsEdit = "0", lsDel = "0", lcAdd = "0", lcEdit = "0", lcDel = "0", lrAdd = "0", lrEdit = "0", lrDel = "0", srAdd = "0", srEdit = "0", srDel = "0", tuAdd = "0", tuEdit = "0", tuDel = "0", fcAdd = "0", fcEdit = "0", fcDel = "0", frAdd = "0", frEdit = "0", frDel = "0", wlsAdd = "0", wlsEdit = "0", wlsDel = "0";
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();
        void DelAcct()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to delete this account?", "User Accounts", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    conn.SetConstr();
                    SQL = "select * from tbluser where username=@username";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = lstUser.SelectedValue.ToString();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        SQL = "delete from tbluser where UID=@UID";
                        da = new MySqlDataAdapter();
                        da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.DeleteCommand.Parameters.Add("@UID", MySqlDbType.VarChar).Value = dr["UID"].ToString();
                        Connection.Conn.Open();
                        da.DeleteCommand.ExecuteNonQuery();
                        Connection.Conn.Close();

                        SQL = "delete from tbllogs where UID=@UID";
                        da = new MySqlDataAdapter();
                        da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.DeleteCommand.Parameters.Add("@UID", MySqlDbType.VarChar).Value = dr["UID"].ToString();
                        Connection.Conn.Open();
                        da.DeleteCommand.ExecuteNonQuery();
                        Connection.Conn.Close();

                        MessageBox.Show("Successfully delete user account", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnCancel.PerformClick();
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
                conn.SetConstr();
                SQL = "select * from tbluser where username=@username";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUsername.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count == 0)
                {
                    SQL = "insert into tbluser(Firstname,Middlename,Surname,Username,Password,PI,R,LS,LC,LR,TU,SR,FC,FR,WLS,APPI,EPPI,DPPI,APLS,EPLS,DPLS,APLC,EPLC,DPLC,APLR,EPLR,DPLR,APSR,EPSR,DPSR,APTU,EPTU,DPTU,APFC,EPFC,DPFC,APFR,EPFR,DPFR,APWLS,EPWLS,DPWLS,Usertype)values(@Firstname,@Middlename,@Surname,@Username,md5(@Password),@PI,@R,@LS,@LC,@LR,@TU,@SR,@FC,@FR,@WLS,@APPI,@EPPI,@DPPI,@APLS,@EPLS,@DPLS,@APLC,@EPLC,@DPLC,@APLR,@EPLR,@DPLR,@APSR,@EPSR,@DPSR,@APTU,@EPTU,@DPTU,@APFC,@EPFC,@DPFC,@APFR,@EPFR,@DPFR,@APWLS,@EPWLS,@DPWLS,@Usertype)";
                    da = new MySqlDataAdapter();
                    da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.InsertCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtFirstname.Text;
                    da.InsertCommand.Parameters.Add("@Middlename", MySqlDbType.VarChar).Value = txtMiddlename.Text;
                    da.InsertCommand.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = txtSurname.Text;
                    da.InsertCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = txtUsername.Text;
                    da.InsertCommand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = txtPassword.Text;
                    da.InsertCommand.Parameters.Add("@PI", MySqlDbType.VarChar).Value = PI;
                    da.InsertCommand.Parameters.Add("@R", MySqlDbType.VarChar).Value = R;
                    da.InsertCommand.Parameters.Add("@LS", MySqlDbType.VarChar).Value = LS;
                    da.InsertCommand.Parameters.Add("@LC", MySqlDbType.VarChar).Value = LC;
                    da.InsertCommand.Parameters.Add("@LR", MySqlDbType.VarChar).Value = LR;
                    da.InsertCommand.Parameters.Add("@TU", MySqlDbType.VarChar).Value = TU;
                    da.InsertCommand.Parameters.Add("@SR", MySqlDbType.VarChar).Value = SR;
                    da.InsertCommand.Parameters.Add("@FC", MySqlDbType.VarChar).Value = FC;
                    da.InsertCommand.Parameters.Add("@FR", MySqlDbType.VarChar).Value = FR;
                    da.InsertCommand.Parameters.Add("@WLS", MySqlDbType.VarChar).Value = WLS;
                    da.InsertCommand.Parameters.Add("@APPI", MySqlDbType.VarChar).Value = piAdd;
                    da.InsertCommand.Parameters.Add("@EPPI", MySqlDbType.VarChar).Value = piEdit;
                    da.InsertCommand.Parameters.Add("@DPPI", MySqlDbType.VarChar).Value = piDel;
                    da.InsertCommand.Parameters.Add("@APLS", MySqlDbType.VarChar).Value = lsAdd;
                    da.InsertCommand.Parameters.Add("@EPLS", MySqlDbType.VarChar).Value = lsEdit;
                    da.InsertCommand.Parameters.Add("@DPLS", MySqlDbType.VarChar).Value = lsDel;
                    da.InsertCommand.Parameters.Add("@APLC", MySqlDbType.VarChar).Value = lcAdd;
                    da.InsertCommand.Parameters.Add("@EPLC", MySqlDbType.VarChar).Value = lcEdit;
                    da.InsertCommand.Parameters.Add("@DPLC", MySqlDbType.VarChar).Value = lcDel;
                    da.InsertCommand.Parameters.Add("@APLR", MySqlDbType.VarChar).Value = lrAdd;
                    da.InsertCommand.Parameters.Add("@EPLR", MySqlDbType.VarChar).Value = lrEdit;
                    da.InsertCommand.Parameters.Add("@DPLR", MySqlDbType.VarChar).Value = lrDel;
                    da.InsertCommand.Parameters.Add("@APSR", MySqlDbType.VarChar).Value = srAdd;
                    da.InsertCommand.Parameters.Add("@EPSR", MySqlDbType.VarChar).Value = srEdit;
                    da.InsertCommand.Parameters.Add("@DPSR", MySqlDbType.VarChar).Value = srDel;
                    da.InsertCommand.Parameters.Add("@APTU", MySqlDbType.VarChar).Value = tuAdd;
                    da.InsertCommand.Parameters.Add("@EPTU", MySqlDbType.VarChar).Value = tuEdit;
                    da.InsertCommand.Parameters.Add("@DPTU", MySqlDbType.VarChar).Value = tuDel;
                    da.InsertCommand.Parameters.Add("@APFC", MySqlDbType.VarChar).Value = fcAdd;
                    da.InsertCommand.Parameters.Add("@EPFC", MySqlDbType.VarChar).Value = fcEdit;
                    da.InsertCommand.Parameters.Add("@DPFC", MySqlDbType.VarChar).Value = fcDel;
                    da.InsertCommand.Parameters.Add("@APFR", MySqlDbType.VarChar).Value = frAdd;
                    da.InsertCommand.Parameters.Add("@EPFR", MySqlDbType.VarChar).Value = frEdit;
                    da.InsertCommand.Parameters.Add("@DPFR", MySqlDbType.VarChar).Value = frDel;
                    da.InsertCommand.Parameters.Add("@APWLS", MySqlDbType.VarChar).Value = wlsAdd;
                    da.InsertCommand.Parameters.Add("@EPWLS", MySqlDbType.VarChar).Value = wlsEdit;
                    da.InsertCommand.Parameters.Add("@DPWLS", MySqlDbType.VarChar).Value = wlsDel;
                    da.InsertCommand.Parameters.Add("@Usertype", MySqlDbType.VarChar).Value = cboUsertype.Text;
                    
                    Connection.Conn.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    Connection.Conn.Close();

                    MessageBox.Show("Successfully add user account", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtFirstname.Clear();
                    txtMiddlename.Clear();
                    txtPassword.Clear();
                    txtSurname.Clear();
                    txtUsername.Clear();
                    cboUsertype.ResetText();

                    cbLS.Checked = false;
                    cblsAdd.Checked = false;
                    cblsEdit.Checked = false;
                    cblsDel.Checked = false;
                
                    cbPI.Checked = false;
                    cbpiAdd.Checked = false;
                    cbpiEdit.Checked = false;
                    cbpiDel.Checked = false;

                    cbR.Checked = false;
                    
                    cbSR.Checked = false;
                    cbsrAdd.Checked = false;
                    cbsrEdit.Checked = false;
                    cbsrDel.Checked = false;

                    cbTU.Checked = false;
                    cbtuAdd.Checked = false;
                    cbtuEdit.Checked = false;
                    cbtuDel.Checked = false;

                    cbLC.Checked = false;
                    cblcAdd.Checked = false;
                    cblcEdit.Checked = false;
                    cblcDel.Checked = false;

                    cbLR.Checked = false;
                    cblrAdd.Checked = false;
                    cblrEdit.Checked = false;
                    cblrDel.Checked = false;
                    
                    cbFC.Checked = false;
                    cbfcAdd.Checked = false;
                    cbfcEdit.Checked = false;
                    cbfcDel.Checked = false;

                    cbFR.Checked = false;
                    cbfrAdd.Checked = false;
                    cbfrEdit.Checked = false;
                    cbfrDel.Checked = false;

                    cbWLS.Checked = false;
                    cbwlsAdd.Checked = false;
                    cbwlsEdit.Checked = false;
                    cbwlsDel.Checked = false;

                    txtFirstname.Focus();

                    btnNew.Enabled = true;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Username exist, please choose another username", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                conn.SetConstr();
                SQL = "update tbluser set Firstname=@Firstname,Middlename=@Middlename,Surname=@Surname,Password=md5(@Password),PI=@PI,R=@R,LS=@LS,LC=@LC,LR=@LR,TU=@TU,SR=@SR,FC=@FC,FR=@FR,WLS=@WLS,APPI=@APPI,EPPI=@EPPI,DPPI=@DPPI,APLS=@APLS,EPLS=@EPLS,DPLS=@DPLS,APLC=@APLC,EPLC=@EPLC,DPLC=@DPLC,APLR=@APLR,EPLR=@EPLR,DPLR=@DPLR,APSR=@APSR,EPSR=@EPSR,DPSR=@DPSR,APTU=@APTU,EPTU=@EPTU,DPTU=@DPTU,APFC=@APFC,EPFC=@EPFC,DPFC=@DPFC,APFR=@APFR,EPFR=@EPFR,DPFR=@DPFR,APWLS=@APWLS,EPWLS=@EPWLS,DPWLS=@DPWLS,Usertype=@Usertype where Username=@Username";
                da = new MySqlDataAdapter();
                da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                da.UpdateCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtFirstname.Text;
                da.UpdateCommand.Parameters.Add("@Middlename", MySqlDbType.VarChar).Value = txtMiddlename.Text;
                da.UpdateCommand.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = txtSurname.Text;
                da.UpdateCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = txtUsername.Text;
                da.UpdateCommand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = txtPassword.Text;
                da.UpdateCommand.Parameters.Add("@PI", MySqlDbType.VarChar).Value = PI;
                da.UpdateCommand.Parameters.Add("@R", MySqlDbType.VarChar).Value = R;
                da.UpdateCommand.Parameters.Add("@LS", MySqlDbType.VarChar).Value = LS;
                da.UpdateCommand.Parameters.Add("@LC", MySqlDbType.VarChar).Value = LC;
                da.UpdateCommand.Parameters.Add("@LR", MySqlDbType.VarChar).Value = LR;
                da.UpdateCommand.Parameters.Add("@TU", MySqlDbType.VarChar).Value = TU;
                da.UpdateCommand.Parameters.Add("@SR", MySqlDbType.VarChar).Value = SR;
                da.UpdateCommand.Parameters.Add("@FC", MySqlDbType.VarChar).Value = FC;
                da.UpdateCommand.Parameters.Add("@FR", MySqlDbType.VarChar).Value = FR;
                da.UpdateCommand.Parameters.Add("@WLS", MySqlDbType.VarChar).Value = WLS;
                da.UpdateCommand.Parameters.Add("@APPI", MySqlDbType.VarChar).Value = piAdd;
                da.UpdateCommand.Parameters.Add("@EPPI", MySqlDbType.VarChar).Value = piEdit;
                da.UpdateCommand.Parameters.Add("@DPPI", MySqlDbType.VarChar).Value = piDel;
                da.UpdateCommand.Parameters.Add("@APLS", MySqlDbType.VarChar).Value = lsAdd;
                da.UpdateCommand.Parameters.Add("@EPLS", MySqlDbType.VarChar).Value = lsEdit;
                da.UpdateCommand.Parameters.Add("@DPLS", MySqlDbType.VarChar).Value = lsDel;
                da.UpdateCommand.Parameters.Add("@APLC", MySqlDbType.VarChar).Value = lcAdd;
                da.UpdateCommand.Parameters.Add("@EPLC", MySqlDbType.VarChar).Value = lcEdit;
                da.UpdateCommand.Parameters.Add("@DPLC", MySqlDbType.VarChar).Value = lcDel;
                da.UpdateCommand.Parameters.Add("@APLR", MySqlDbType.VarChar).Value = lrAdd;
                da.UpdateCommand.Parameters.Add("@EPLR", MySqlDbType.VarChar).Value = lrEdit;
                da.UpdateCommand.Parameters.Add("@DPLR", MySqlDbType.VarChar).Value = lrDel;
                da.UpdateCommand.Parameters.Add("@APSR", MySqlDbType.VarChar).Value = srAdd;
                da.UpdateCommand.Parameters.Add("@EPSR", MySqlDbType.VarChar).Value = srEdit;
                da.UpdateCommand.Parameters.Add("@DPSR", MySqlDbType.VarChar).Value = srDel;
                da.UpdateCommand.Parameters.Add("@APTU", MySqlDbType.VarChar).Value = tuAdd;
                da.UpdateCommand.Parameters.Add("@EPTU", MySqlDbType.VarChar).Value = tuEdit;
                da.UpdateCommand.Parameters.Add("@DPTU", MySqlDbType.VarChar).Value = tuDel;
                da.UpdateCommand.Parameters.Add("@APFC", MySqlDbType.VarChar).Value = fcAdd;
                da.UpdateCommand.Parameters.Add("@EPFC", MySqlDbType.VarChar).Value = fcEdit;
                da.UpdateCommand.Parameters.Add("@DPFC", MySqlDbType.VarChar).Value = fcDel;
                da.UpdateCommand.Parameters.Add("@APFR", MySqlDbType.VarChar).Value = frAdd;
                da.UpdateCommand.Parameters.Add("@EPFR", MySqlDbType.VarChar).Value = frEdit;
                da.UpdateCommand.Parameters.Add("@DPFR", MySqlDbType.VarChar).Value = frDel;
                da.UpdateCommand.Parameters.Add("@APWLS", MySqlDbType.VarChar).Value = wlsAdd;
                da.UpdateCommand.Parameters.Add("@EPWLS", MySqlDbType.VarChar).Value = wlsEdit;
                da.UpdateCommand.Parameters.Add("@DPWLS", MySqlDbType.VarChar).Value = wlsDel;
                da.UpdateCommand.Parameters.Add("@Usertype", MySqlDbType.VarChar).Value = cboUsertype.Text;
                Connection.Conn.Open();
                da.UpdateCommand.ExecuteNonQuery();
                Connection.Conn.Close();

                MessageBox.Show("Successfully update user account", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFirstname.Enabled = false;
                txtMiddlename.Enabled = false;
                txtPassword.Enabled = false;
                txtSurname.Enabled = false;
                txtUsername.Enabled = false;
                cboUsertype.Enabled = false;
                
                cbLS.Enabled = false;
                cblsAdd.Enabled = false;
                cblsEdit.Enabled = false;
                cblsDel.Enabled = false;
               
                cbPI.Enabled = false;
                cbpiAdd.Enabled = false;
                cbpiEdit.Enabled = false;
                cbpiDel.Enabled = false;

                cbR.Enabled = false;
                
                cbLC.Enabled = false;
                cblcAdd.Enabled = false;
                cblcEdit.Enabled = false;
                cblcDel.Enabled = false;

                cbLR.Enabled = false;
                cblrAdd.Enabled = false;
                cblrEdit.Enabled = false;
                cblrDel.Enabled = false;

                cbTU.Enabled = false;
                cbtuAdd.Enabled = false;
                cbtuEdit.Enabled = false;
                cbtuDel.Enabled = false;

                cbSR.Enabled = false;
                cbsrAdd.Enabled = false;
                cbsrEdit.Enabled = false;
                cbsrDel.Enabled = false;
                
                cbFC.Enabled = false;
                cbfcAdd.Enabled = false;
                cbfcEdit.Enabled = false;
                cbfcDel.Enabled = false;

                cbFR.Enabled = false;
                cbfrAdd.Enabled = false;
                cbfrEdit.Enabled = false;
                cbfrDel.Enabled = false;

                cbWLS.Enabled = false;
                cbwlsAdd.Enabled = false;
                cbwlsEdit.Enabled = false;
                cbwlsDel.Enabled = false;

                txtFirstname.Focus();

                btnNew.Enabled = false;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
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
                if (cboSearchby.Text == "Username")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tbluser where Username=@Username order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstUser.DisplayMember = "Name";
                        lstUser.ValueMember = "Username";
                        lstUser.DataSource = dt;
                    }
                    else
                    {
                        txtFirstname.Clear();
                        txtMiddlename.Clear();
                        txtPassword.Clear();
                        txtSurname.Clear();
                        txtUsername.Clear();
                        cboUsertype.ResetText();

                        cbLS.Checked = false;
                        cblsAdd.Checked = false;
                        cblsEdit.Checked = false;
                        cblsDel.Checked = false;
                        
                        cbPI.Checked = false;
                        cbpiAdd.Checked = false;
                        cbpiEdit.Checked = false;
                        cbpiDel.Checked = false;

                        cbR.Checked = false;
                        
                        cbSR.Checked = false;
                        cbsrAdd.Checked = false;
                        cbsrEdit.Checked = false;
                        cbsrDel.Checked = false;

                        cbTU.Checked = false;
                        cbtuAdd.Checked = false;
                        cbtuEdit.Checked = false;
                        cbtuDel.Checked = false;

                        cbLC.Checked = false;
                        cblcAdd.Checked = false;
                        cblcEdit.Checked = false;
                        cblcDel.Checked = false;

                        cbLR.Checked = false;
                        cblrAdd.Checked = false;
                        cblrEdit.Checked = false;
                        cblrDel.Checked = false;
                        
                        cbFC.Checked = false;
                        cbfcAdd.Checked = false;
                        cbfcEdit.Checked = false;
                        cbfcDel.Checked = false;

                        cbFR.Checked = false;
                        cbfrAdd.Checked = false;
                        cbfrEdit.Checked = false;
                        cbfrDel.Checked = false;

                        cbWLS.Checked = false;
                        cbwlsAdd.Checked = false;
                        cbwlsEdit.Checked = false;
                        cbwlsDel.Checked = false;
                        
                        txtFirstname.Enabled = true;
                        txtMiddlename.Enabled = true;
                        txtPassword.Enabled = true;
                        txtSurname.Enabled = true;
                        txtUsername.Enabled = true;
                        cboUsertype.Enabled = true;

                        cbLS.Enabled = true;
                        cblsAdd.Enabled = true;
                        cblsEdit.Enabled = true;
                        cblsDel.Enabled = true;
                        
                        cbPI.Enabled = true;
                        cbpiAdd.Enabled = true;
                        cbpiEdit.Enabled = true;
                        cbpiDel.Enabled = true;

                        cbR.Enabled = true;
                        
                        cbSR.Enabled = true;
                        cbsrAdd.Enabled = true;
                        cbsrEdit.Enabled = true;
                        cbsrDel.Enabled = true;

                        cbTU.Enabled = true;
                        cbtuAdd.Enabled = true;
                        cbtuEdit.Enabled = true;
                        cbtuDel.Enabled = true;

                        cbLC.Enabled = true;
                        cblcAdd.Enabled = true;
                        cblcEdit.Enabled = true;
                        cblcDel.Enabled = true;

                        cbLR.Enabled = true;
                        cblrAdd.Enabled = true;
                        cblrEdit.Enabled = true;
                        cblrDel.Enabled = true;
                        
                        cbFR.Enabled = true;
                        cbfrAdd.Enabled = true;
                        cbfrEdit.Enabled = true;
                        cbfrDel.Enabled = true;

                        cbFC.Enabled = true;
                        cbfcAdd.Enabled = true;
                        cbfcEdit.Enabled = true;
                        cbfcDel.Enabled = true;

                        cbWLS.Enabled = true;
                        cbwlsAdd.Enabled = true;
                        cbwlsEdit.Enabled = true;
                        cbwlsDel.Enabled = true;

                        lstUser.DataSource = null;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        MessageBox.Show("User does not exist", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Surname")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tbluser where Surname=@Surname order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstUser.DisplayMember = "Name";
                        lstUser.ValueMember = "Username";
                        lstUser.DataSource = dt;
                    }
                    else
                    {
                        txtFirstname.Clear();
                        txtMiddlename.Clear();
                        txtPassword.Clear();
                        txtSurname.Clear();
                        txtUsername.Clear();
                        cboUsertype.ResetText();

                        cbLS.Checked = false;
                        cblsAdd.Checked = false;
                        cblsEdit.Checked = false;
                        cblsDel.Checked = false;

                        cbPI.Checked = false;
                        cbpiAdd.Checked = false;
                        cbpiEdit.Checked = false;
                        cbpiDel.Checked = false;

                        cbR.Checked = false;

                        cbSR.Checked = false;
                        cbsrAdd.Checked = false;
                        cbsrEdit.Checked = false;
                        cbsrDel.Checked = false;

                        cbTU.Checked = false;
                        cbtuAdd.Checked = false;
                        cbtuEdit.Checked = false;
                        cbtuDel.Checked = false;

                        cbLC.Checked = false;
                        cblcAdd.Checked = false;
                        cblcEdit.Checked = false;
                        cblcDel.Checked = false;

                        cbLR.Checked = false;
                        cblrAdd.Checked = false;
                        cblrEdit.Checked = false;
                        cblrDel.Checked = false;

                        cbFC.Checked = false;
                        cbfcAdd.Checked = false;
                        cbfcEdit.Checked = false;
                        cbfcDel.Checked = false;

                        cbFR.Checked = false;
                        cbfrAdd.Checked = false;
                        cbfrEdit.Checked = false;
                        cbfrDel.Checked = false;

                        cbWLS.Checked = false;
                        cbwlsAdd.Checked = false;
                        cbwlsEdit.Checked = false;
                        cbwlsDel.Checked = false;

                        txtFirstname.Enabled = true;
                        txtMiddlename.Enabled = true;
                        txtPassword.Enabled = true;
                        txtSurname.Enabled = true;
                        txtUsername.Enabled = true;
                        cboUsertype.Enabled = true;

                        cbLS.Enabled = true;
                        cblsAdd.Enabled = true;
                        cblsEdit.Enabled = true;
                        cblsDel.Enabled = true;

                        cbPI.Enabled = true;
                        cbpiAdd.Enabled = true;
                        cbpiEdit.Enabled = true;
                        cbpiDel.Enabled = true;

                        cbR.Enabled = true;

                        cbSR.Enabled = true;
                        cbsrAdd.Enabled = true;
                        cbsrEdit.Enabled = true;
                        cbsrDel.Enabled = true;

                        cbTU.Enabled = true;
                        cbtuAdd.Enabled = true;
                        cbtuEdit.Enabled = true;
                        cbtuDel.Enabled = true;

                        cbLC.Enabled = true;
                        cblcAdd.Enabled = true;
                        cblcEdit.Enabled = true;
                        cblcDel.Enabled = true;

                        cbLR.Enabled = true;
                        cblrAdd.Enabled = true;
                        cblrEdit.Enabled = true;
                        cblrDel.Enabled = true;

                        cbFR.Enabled = true;
                        cbfrAdd.Enabled = true;
                        cbfrEdit.Enabled = true;
                        cbfrDel.Enabled = true;

                        cbFC.Enabled = true;
                        cbfcAdd.Enabled = true;
                        cbfcEdit.Enabled = true;
                        cbfcDel.Enabled = true;

                        cbWLS.Enabled = true;
                        cbwlsAdd.Enabled = true;
                        cbwlsEdit.Enabled = true;
                        cbwlsDel.Enabled = true;

                        lstUser.DataSource = null;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        MessageBox.Show("User does not exist", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Fistname")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tbluser where Firstname=@Firstname order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstUser.DisplayMember = "Name";
                        lstUser.ValueMember = "Username";
                        lstUser.DataSource = dt;
                    }
                    else
                    {
                        txtFirstname.Clear();
                        txtMiddlename.Clear();
                        txtPassword.Clear();
                        txtSurname.Clear();
                        txtUsername.Clear();
                        cboUsertype.ResetText();

                        cbLS.Checked = false;
                        cblsAdd.Checked = false;
                        cblsEdit.Checked = false;
                        cblsDel.Checked = false;

                        cbPI.Checked = false;
                        cbpiAdd.Checked = false;
                        cbpiEdit.Checked = false;
                        cbpiDel.Checked = false;

                        cbR.Checked = false;

                        cbSR.Checked = false;
                        cbsrAdd.Checked = false;
                        cbsrEdit.Checked = false;
                        cbsrDel.Checked = false;

                        cbTU.Checked = false;
                        cbtuAdd.Checked = false;
                        cbtuEdit.Checked = false;
                        cbtuDel.Checked = false;

                        cbLC.Checked = false;
                        cblcAdd.Checked = false;
                        cblcEdit.Checked = false;
                        cblcDel.Checked = false;

                        cbLR.Checked = false;
                        cblrAdd.Checked = false;
                        cblrEdit.Checked = false;
                        cblrDel.Checked = false;

                        cbFC.Checked = false;
                        cbfcAdd.Checked = false;
                        cbfcEdit.Checked = false;
                        cbfcDel.Checked = false;

                        cbFR.Checked = false;
                        cbfrAdd.Checked = false;
                        cbfrEdit.Checked = false;
                        cbfrDel.Checked = false;

                        cbWLS.Checked = false;
                        cbwlsAdd.Checked = false;
                        cbwlsEdit.Checked = false;
                        cbwlsDel.Checked = false;

                        txtFirstname.Enabled = true;
                        txtMiddlename.Enabled = true;
                        txtPassword.Enabled = true;
                        txtSurname.Enabled = true;
                        txtUsername.Enabled = true;
                        cboUsertype.Enabled = true;

                        cbLS.Enabled = true;
                        cblsAdd.Enabled = true;
                        cblsEdit.Enabled = true;
                        cblsDel.Enabled = true;

                        cbPI.Enabled = true;
                        cbpiAdd.Enabled = true;
                        cbpiEdit.Enabled = true;
                        cbpiDel.Enabled = true;

                        cbR.Enabled = true;

                        cbSR.Enabled = true;
                        cbsrAdd.Enabled = true;
                        cbsrEdit.Enabled = true;
                        cbsrDel.Enabled = true;

                        cbTU.Enabled = true;
                        cbtuAdd.Enabled = true;
                        cbtuEdit.Enabled = true;
                        cbtuDel.Enabled = true;

                        cbLC.Enabled = true;
                        cblcAdd.Enabled = true;
                        cblcEdit.Enabled = true;
                        cblcDel.Enabled = true;

                        cbLR.Enabled = true;
                        cblrAdd.Enabled = true;
                        cblrEdit.Enabled = true;
                        cblrDel.Enabled = true;

                        cbFR.Enabled = true;
                        cbfrAdd.Enabled = true;
                        cbfrEdit.Enabled = true;
                        cbfrDel.Enabled = true;

                        cbFC.Enabled = true;
                        cbfcAdd.Enabled = true;
                        cbfcEdit.Enabled = true;
                        cbfcDel.Enabled = true;

                        cbWLS.Enabled = true;
                        cbwlsAdd.Enabled = true;
                        cbwlsEdit.Enabled = true;
                        cbwlsDel.Enabled = true;

                        lstUser.DataSource = null;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        MessageBox.Show("User does not exist", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Middlename")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tbluser where Middlename=@Middlename order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@Middlename", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstUser.DisplayMember = "Name";
                        lstUser.ValueMember = "Username";
                        lstUser.DataSource = dt;
                    }
                    else
                    {
                        txtFirstname.Clear();
                        txtMiddlename.Clear();
                        txtPassword.Clear();
                        txtSurname.Clear();
                        txtUsername.Clear();
                        cboUsertype.ResetText();

                        cbLS.Checked = false;
                        cblsAdd.Checked = false;
                        cblsEdit.Checked = false;
                        cblsDel.Checked = false;

                        cbPI.Checked = false;
                        cbpiAdd.Checked = false;
                        cbpiEdit.Checked = false;
                        cbpiDel.Checked = false;

                        cbR.Checked = false;

                        cbSR.Checked = false;
                        cbsrAdd.Checked = false;
                        cbsrEdit.Checked = false;
                        cbsrDel.Checked = false;

                        cbTU.Checked = false;
                        cbtuAdd.Checked = false;
                        cbtuEdit.Checked = false;
                        cbtuDel.Checked = false;

                        cbLC.Checked = false;
                        cblcAdd.Checked = false;
                        cblcEdit.Checked = false;
                        cblcDel.Checked = false;

                        cbLR.Checked = false;
                        cblrAdd.Checked = false;
                        cblrEdit.Checked = false;
                        cblrDel.Checked = false;

                        cbFC.Checked = false;
                        cbfcAdd.Checked = false;
                        cbfcEdit.Checked = false;
                        cbfcDel.Checked = false;

                        cbFR.Checked = false;
                        cbfrAdd.Checked = false;
                        cbfrEdit.Checked = false;
                        cbfrDel.Checked = false;

                        cbWLS.Checked = false;
                        cbwlsAdd.Checked = false;
                        cbwlsEdit.Checked = false;
                        cbwlsDel.Checked = false;

                        txtFirstname.Enabled = true;
                        txtMiddlename.Enabled = true;
                        txtPassword.Enabled = true;
                        txtSurname.Enabled = true;
                        txtUsername.Enabled = true;
                        cboUsertype.Enabled = true;

                        cbLS.Enabled = true;
                        cblsAdd.Enabled = true;
                        cblsEdit.Enabled = true;
                        cblsDel.Enabled = true;

                        cbPI.Enabled = true;
                        cbpiAdd.Enabled = true;
                        cbpiEdit.Enabled = true;
                        cbpiDel.Enabled = true;

                        cbR.Enabled = true;

                        cbSR.Enabled = true;
                        cbsrAdd.Enabled = true;
                        cbsrEdit.Enabled = true;
                        cbsrDel.Enabled = true;

                        cbTU.Enabled = true;
                        cbtuAdd.Enabled = true;
                        cbtuEdit.Enabled = true;
                        cbtuDel.Enabled = true;

                        cbLC.Enabled = true;
                        cblcAdd.Enabled = true;
                        cblcEdit.Enabled = true;
                        cblcDel.Enabled = true;

                        cbLR.Enabled = true;
                        cblrAdd.Enabled = true;
                        cblrEdit.Enabled = true;
                        cblrDel.Enabled = true;

                        cbFR.Enabled = true;
                        cbfrAdd.Enabled = true;
                        cbfrEdit.Enabled = true;
                        cbfrDel.Enabled = true;

                        cbFC.Enabled = true;
                        cbfcAdd.Enabled = true;
                        cbfcEdit.Enabled = true;
                        cbfcDel.Enabled = true;

                        cbWLS.Enabled = true;
                        cbwlsAdd.Enabled = true;
                        cbwlsEdit.Enabled = true;
                        cbwlsDel.Enabled = true;

                        lstUser.DataSource = null;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        MessageBox.Show("User does not exist", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "All")
                {
                    SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tbluser order by concat(Surname,', ',Firstname,' ',Middlename) asc";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        lstUser.DisplayMember = "Name";
                        lstUser.ValueMember = "Username";
                        lstUser.DataSource = dt;
                    }
                    else
                    {
                        txtFirstname.Clear();
                        txtMiddlename.Clear();
                        txtPassword.Clear();
                        txtSurname.Clear();
                        txtUsername.Clear();
                        cboUsertype.ResetText();

                        cbLS.Checked = false;
                        cblsAdd.Checked = false;
                        cblsEdit.Checked = false;
                        cblsDel.Checked = false;

                        cbPI.Checked = false;
                        cbpiAdd.Checked = false;
                        cbpiEdit.Checked = false;
                        cbpiDel.Checked = false;

                        cbR.Checked = false;

                        cbSR.Checked = false;
                        cbsrAdd.Checked = false;
                        cbsrEdit.Checked = false;
                        cbsrDel.Checked = false;

                        cbTU.Checked = false;
                        cbtuAdd.Checked = false;
                        cbtuEdit.Checked = false;
                        cbtuDel.Checked = false;

                        cbLC.Checked = false;
                        cblcAdd.Checked = false;
                        cblcEdit.Checked = false;
                        cblcDel.Checked = false;

                        cbLR.Checked = false;
                        cblrAdd.Checked = false;
                        cblrEdit.Checked = false;
                        cblrDel.Checked = false;

                        cbFC.Checked = false;
                        cbfcAdd.Checked = false;
                        cbfcEdit.Checked = false;
                        cbfcDel.Checked = false;

                        cbFR.Checked = false;
                        cbfrAdd.Checked = false;
                        cbfrEdit.Checked = false;
                        cbfrDel.Checked = false;

                        cbWLS.Checked = false;
                        cbwlsAdd.Checked = false;
                        cbwlsEdit.Checked = false;
                        cbwlsDel.Checked = false;

                        txtFirstname.Enabled = true;
                        txtMiddlename.Enabled = true;
                        txtPassword.Enabled = true;
                        txtSurname.Enabled = true;
                        txtUsername.Enabled = true;
                        cboUsertype.Enabled = true;

                        cbLS.Enabled = true;
                        cblsAdd.Enabled = true;
                        cblsEdit.Enabled = true;
                        cblsDel.Enabled = true;

                        cbPI.Enabled = true;
                        cbpiAdd.Enabled = true;
                        cbpiEdit.Enabled = true;
                        cbpiDel.Enabled = true;

                        cbR.Enabled = true;

                        cbSR.Enabled = true;
                        cbsrAdd.Enabled = true;
                        cbsrEdit.Enabled = true;
                        cbsrDel.Enabled = true;

                        cbTU.Enabled = true;
                        cbtuAdd.Enabled = true;
                        cbtuEdit.Enabled = true;
                        cbtuDel.Enabled = true;

                        cbLC.Enabled = true;
                        cblcAdd.Enabled = true;
                        cblcEdit.Enabled = true;
                        cblcDel.Enabled = true;

                        cbLR.Enabled = true;
                        cblrAdd.Enabled = true;
                        cblrEdit.Enabled = true;
                        cblrDel.Enabled = true;

                        cbFR.Enabled = true;
                        cbfrAdd.Enabled = true;
                        cbfrEdit.Enabled = true;
                        cbfrDel.Enabled = true;

                        cbFC.Enabled = true;
                        cbfcAdd.Enabled = true;
                        cbfcEdit.Enabled = true;
                        cbfcDel.Enabled = true;

                        cbWLS.Enabled = true;
                        cbwlsAdd.Enabled = true;
                        cbwlsEdit.Enabled = true;
                        cbwlsDel.Enabled = true;

                        lstUser.DataSource = null;

                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        MessageBox.Show("User does not exist", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        void display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tbluser where Username=@Username";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = lstUser.SelectedValue.ToString();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtFirstname.Text = dr["Firstname"].ToString();
                    txtMiddlename.Text = dr["Middlename"].ToString();
                    txtPassword.Text = dr["Password"].ToString();
                    txtSurname.Text = dr["Surname"].ToString();
                    txtUsername.Text = dr["Username"].ToString();
                    cboUsertype.Text = dr["Usertype"].ToString();

                    cbLS.Checked = false;
                    cblsAdd.Checked = false;
                    cblsEdit.Checked = false;
                    cblsDel.Checked = false;

                    cbPI.Checked = false;
                    cbpiAdd.Checked = false;
                    cbpiEdit.Checked = false;
                    cbpiDel.Checked = false;

                    cbR.Checked = false;

                    cbSR.Checked = false;
                    cbsrAdd.Checked = false;
                    cbsrEdit.Checked = false;
                    cbsrDel.Checked = false;

                    cbTU.Checked = false;
                    cbtuAdd.Checked = false;
                    cbtuEdit.Checked = false;
                    cbtuDel.Checked = false;

                    cbLC.Checked = false;
                    cblcAdd.Checked = false;
                    cblcEdit.Checked = false;
                    cblcDel.Checked = false;

                    cbLR.Checked = false;
                    cblrAdd.Checked = false;
                    cblrEdit.Checked = false;
                    cblrDel.Checked = false;

                    cbFR.Checked = false;
                    cbfrAdd.Checked = false;
                    cbfrEdit.Checked = false;
                    cbfrDel.Checked = false;

                    cbFC.Checked = false;
                    cbfcAdd.Checked = false;
                    cbfcEdit.Checked = false;
                    cbfcDel.Checked = false;

                    cbWLS.Checked = false;
                    cbwlsAdd.Checked = false;
                    cbwlsEdit.Checked = false;
                    cbwlsDel.Checked = false;

                    if (dr["PI"].ToString() == "Allow")
                    {
                        cbPI.Checked = true;
                    }
                    if (dr["R"].ToString() == "Allow")
                    {
                        cbR.Checked = true;
                    }
                    if (dr["LS"].ToString() == "Allow")
                    {
                        cbLS.Checked = true;
                    }
                    if (dr["LC"].ToString() == "Allow")
                    {
                        cbLC.Checked = true;
                    }
                    if (dr["LR"].ToString() == "Allow")
                    {
                        cbLR.Checked = true;
                    }
                    if (dr["SR"].ToString() == "Allow")
                    {
                        cbSR.Checked = true;
                    }
                    if (dr["TU"].ToString() == "Allow")
                    {
                        cbTU.Checked = true;
                    }


                    if (dr["FC"].ToString() == "Allow")
                    {
                        cbFC.Checked = true;
                    }
                    if (dr["FR"].ToString() == "Allow")
                    {
                        cbFR.Checked = true;
                    }
                    if (dr["WLS"].ToString() == "Allow")
                    {
                        cbWLS.Checked = true;
                    }


                    //PI
                    if (dr["APPI"].ToString() == "1")
                    {
                        cbpiAdd.Checked = true;
                    }
                    if (dr["EPPI"].ToString() == "1")
                    {
                        cbpiEdit.Checked = true;
                    }
                    if (dr["DPPI"].ToString() == "1")
                    {
                        cbpiDel.Checked = true;
                    }
                    //LS
                    if (dr["APLS"].ToString() == "1")
                    {
                        cblsAdd.Checked = true;
                    }
                    if (dr["EPLS"].ToString() == "1")
                    {
                        cblsEdit.Checked = true;
                    }
                    if (dr["DPLS"].ToString() == "1")
                    {
                        cblsDel.Checked = true;
                    }
                    //LC
                    if (dr["APLC"].ToString() == "1")
                    {
                        cblcAdd.Checked = true;
                    }
                    if (dr["EPLC"].ToString() == "1")
                    {
                        cblcEdit.Checked = true;
                    }
                    if (dr["DPLC"].ToString() == "1")
                    {
                        cblcDel.Checked = true;
                    }
                    //LR
                    if (dr["APLR"].ToString() == "1")
                    {
                        cblrAdd.Checked = true;
                    }
                    if (dr["EPLR"].ToString() == "1")
                    {
                        cblrEdit.Checked = true;
                    }
                    if (dr["DPLR"].ToString() == "1")
                    {
                        cblrDel.Checked = true;
                    }
                    //SR
                    if (dr["APSR"].ToString() == "1")
                    {
                        cbsrAdd.Checked = true;
                    }
                    if (dr["EPSR"].ToString() == "1")
                    {
                        cbsrEdit.Checked = true;
                    }
                    if (dr["DPSR"].ToString() == "1")
                    {
                        cbsrDel.Checked = true;
                    }
                    //TU
                    if (dr["APTU"].ToString() == "1")
                    {
                        cbtuAdd.Checked = true;
                    }
                    if (dr["EPTU"].ToString() == "1")
                    {
                        cbtuEdit.Checked = true;
                    }
                    if (dr["DPTU"].ToString() == "1")
                    {
                        cbtuDel.Checked = true;
                    }
                    //FC
                    if (dr["APFC"].ToString() == "1")
                    {
                        cbfcAdd.Checked = true;
                    }
                    if (dr["EPFC"].ToString() == "1")
                    {
                        cbfcEdit.Checked = true;
                    }
                    if (dr["DPFC"].ToString() == "1")
                    {
                        cbfcDel.Checked = true;
                    }
                    //FR
                    if (dr["APFR"].ToString() == "1")
                    {
                        cbfrAdd.Checked = true;
                    }
                    if (dr["EPFR"].ToString() == "1")
                    {
                        cbfrEdit.Checked = true;
                    }
                    if (dr["DPFR"].ToString() == "1")
                    {
                        cbfrDel.Checked = true;
                    }
                    //WLS
                    if (dr["APWLS"].ToString() == "1")
                    {
                        cbwlsAdd.Checked = true;
                    }
                    if (dr["EPWLS"].ToString() == "1")
                    {
                        cbwlsEdit.Checked = true;
                    }
                    if (dr["DPWLS"].ToString() == "1")
                    {
                        cbwlsDel.Checked = true;
                    }

                    //disable controls
                    txtFirstname.Enabled = false;
                    txtMiddlename.Enabled = false;
                    txtPassword.Enabled = false;
                    txtSurname.Enabled = false;
                    txtUsername.Enabled = false;
                    cboUsertype.Enabled = false;

                    cbPI.Enabled = false;
                    cbpiAdd.Enabled = false;
                    cbpiEdit.Enabled = false;
                    cbpiDel.Enabled = false;
                    
                    cbR.Enabled = false;

                    cbLS.Enabled = false;
                    cblsAdd.Enabled = false;
                    cblsEdit.Enabled = false;
                    cblsDel.Enabled = false;
                    
                    cbLR.Enabled = false;
                    cblrAdd.Enabled = false;
                    cblrEdit.Enabled = false;
                    cblrDel.Enabled = false;

                    cbLC.Enabled = false;
                    cblcAdd.Enabled = false;
                    cblcEdit.Enabled = false;
                    cblcDel.Enabled = false;
                    
                    cbTU.Enabled = false;
                    cbtuAdd.Enabled = false;
                    cbtuEdit.Enabled = false;
                    cbtuDel.Enabled = false;

                    cbSR.Enabled = false;
                    cbsrAdd.Enabled = false;
                    cbsrEdit.Enabled = false;
                    cbsrDel.Enabled = false;
                    
                    cbFR.Enabled = false;
                    cbfrAdd.Enabled = false;
                    cbfrEdit.Enabled = false;
                    cbfrDel.Enabled = false;

                    cbFC.Enabled = false;
                    cbfcAdd.Enabled = false;
                    cbfcEdit.Enabled = false;
                    cbfcDel.Enabled = false;

                    cbWLS.Enabled = false;
                    cbwlsAdd.Enabled = false;
                    cbwlsEdit.Enabled = false;
                    cbwlsDel.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void lstUser_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstUser.SelectedIndex != -1)
            {
                display();
                btnEdit.Enabled = true;
                btnNew.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtPassword.Clear();
            txtSurname.Clear();
            txtUsername.Clear();
            cboUsertype.ResetText();

            cbLS.Checked = false;
            cblsAdd.Checked = false;
            cblsEdit.Checked = false;
            cblsDel.Checked = false;
            
            cbPI.Checked = false;
            cbpiAdd.Checked = false;
            cbpiEdit.Checked = false;
            cbpiDel.Checked = false;

            cbR.Checked = false;

            cbSR.Checked = false;
            cbsrAdd.Checked = false;
            cbsrEdit.Checked = false;
            cbsrDel.Checked = false;

            cbTU.Checked = false;
            cbtuAdd.Checked = false;
            cbtuEdit.Checked = false;
            cbtuDel.Checked = false;

            cbLC.Checked = false;
            cblcAdd.Checked = false;
            cblcEdit.Checked = false;
            cblcDel.Checked = false;

            cbLR.Checked = false;
            cblrAdd.Checked = false;
            cblrEdit.Checked = false;
            cblrDel.Checked = false;
            
            cbFR.Checked = false;
            cbfrAdd.Checked = false;
            cbfrEdit.Checked = false;
            cbfrDel.Checked = false;

            cbFC.Checked = false;
            cbfcAdd.Checked = false;
            cbfcEdit.Checked = false;
            cbfcDel.Checked = false;

            cbWLS.Checked = false;
            cbwlsAdd.Checked = false;
            cbwlsEdit.Checked = false;
            cbwlsDel.Checked = false;

            txtFirstname.Enabled = true;
            txtMiddlename.Enabled = true;
            txtPassword.Enabled = true;
            txtSurname.Enabled = true;
            txtUsername.Enabled = true;
            cboUsertype.Enabled = true;

            cbLS.Enabled = true;
            cblsAdd.Enabled = true;
            cblsEdit.Enabled = true;
            cblsDel.Enabled = true;
            
            cbPI.Enabled = true;
            cbpiAdd.Enabled = true;
            cbpiEdit.Enabled = true;
            cbpiDel.Enabled = true;

            cbR.Enabled = true;
            
            cbSR.Enabled = true;
            cbsrAdd.Enabled = true;
            cbsrEdit.Enabled = true;
            cbsrDel.Enabled = true;

            cbTU.Enabled = true;
            cbtuAdd.Enabled = true;
            cbtuEdit.Enabled = true;
            cbtuDel.Enabled = true;

            cbLC.Enabled = true;
            cblcAdd.Enabled = true;
            cblcEdit.Enabled = true;
            cblcDel.Enabled = true;

            cbLR.Enabled = true;
            cblrAdd.Enabled = true;
            cblrEdit.Enabled = true;
            cblrDel.Enabled = true;
            
            cbFC.Enabled = true;
            cbfcAdd.Enabled = true;
            cbfcEdit.Enabled = true;
            cbfcDel.Enabled = true;

            cbFR.Enabled = true;
            cbfrAdd.Enabled = true;
            cbfrEdit.Enabled = true;
            cbfrDel.Enabled = true;

            cbWLS.Enabled = true;
            cbwlsAdd.Enabled = true;
            cbwlsEdit.Enabled = true;
            cbwlsDel.Enabled = true;

            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            lstUser.DataSource = null;
            txtSearch.Focus();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            Transaction = "New";

            txtFirstname.Focus();
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtPassword.Clear();
            txtSurname.Clear();
            txtUsername.Clear();
            cboUsertype.ResetText();

            cbLS.Checked = false;
            cblsAdd.Checked = false;
            cblsEdit.Checked = false;
            cblsDel.Checked = false;

            cbPI.Checked = false;
            cbpiAdd.Checked = false;
            cbpiEdit.Checked = false;
            cbpiDel.Checked = false;

            cbR.Checked = false;

            cbSR.Checked = false;
            cbsrAdd.Checked = false;
            cbsrEdit.Checked = false;
            cbsrDel.Checked = false;

            cbTU.Checked = false;
            cbtuAdd.Checked = false;
            cbtuEdit.Checked = false;
            cbtuDel.Checked = false;

            cbLC.Checked = false;
            cblcAdd.Checked = false;
            cblcEdit.Checked = false;
            cblcDel.Checked = false;

            cbLR.Checked = false;
            cblrAdd.Checked = false;
            cblrEdit.Checked = false;
            cblrDel.Checked = false;

            cbFC.Checked = false;
            cbfcAdd.Checked = false;
            cbfcEdit.Checked = false;
            cbfcDel.Checked = false;

            cbFR.Checked = false;
            cbfrAdd.Checked = false;
            cbfrEdit.Checked = false;
            cbfrDel.Checked = false;

            cbWLS.Checked = false;
            cbwlsAdd.Checked = false;
            cbwlsEdit.Checked = false;
            cbwlsDel.Checked = false;

            txtFirstname.Enabled = true;
            txtMiddlename.Enabled = true;
            txtPassword.Enabled = true;
            txtSurname.Enabled = true;
            txtUsername.Enabled = true;
            cboUsertype.Enabled = true;

            cbLS.Enabled = true;
            cblsAdd.Enabled = true;
            cblsEdit.Enabled = true;
            cblsDel.Enabled = true;

            cbPI.Enabled = true;
            cbpiAdd.Enabled = true;
            cbpiEdit.Enabled = true;
            cbpiDel.Enabled = true;

            cbR.Enabled = true;

            cbSR.Enabled = true;
            cbsrAdd.Enabled = true;
            cbsrEdit.Enabled = true;
            cbsrDel.Enabled = true;

            cbTU.Enabled = true;
            cbtuAdd.Enabled = true;
            cbtuEdit.Enabled = true;
            cbtuDel.Enabled = true;

            cbLC.Enabled = true;
            cblcAdd.Enabled = true;
            cblcEdit.Enabled = true;
            cblcDel.Enabled = true;

            cbLR.Enabled = true;
            cblrAdd.Enabled = true;
            cblrEdit.Enabled = true;
            cblrDel.Enabled = true;

            cbFC.Enabled = true;
            cbfcAdd.Enabled = true;
            cbfcEdit.Enabled = true;
            cbfcDel.Enabled = true;

            cbFR.Enabled = true;
            cbfrAdd.Enabled = true;
            cbfrEdit.Enabled = true;
            cbfrDel.Enabled = true;

            cbWLS.Enabled = true;
            cbwlsAdd.Enabled = true;
            cbwlsEdit.Enabled = true;
            cbwlsDel.Enabled = true;
        }

        private void cbPI_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPI.Checked == true)
            {
                PI = "Allow";
            }
            else
            {
                PI = "Not Allow";
            }
        }

        private void cbR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbR.Checked == true)
            {
                R = "Allow";
            }
            else
            {
                R = "Not Allow";
            }
        }

        private void cbLS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLS.Checked == true)
            {
                LS = "Allow";
            }
            else
            {
                LS = "Not Allow";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            Transaction = "Edit";

            txtFirstname.Enabled = true;
            txtMiddlename.Enabled = true;
            txtPassword.Enabled = true;
            txtSurname.Enabled = true;
            txtUsername.Enabled = true;
            cboUsertype.Enabled = true;

            cbLS.Enabled = true;
            cblsAdd.Enabled = true;
            cblsEdit.Enabled = true;
            cblsDel.Enabled = true;
            
            cbPI.Enabled = true;
            cbpiAdd.Enabled = true;
            cbpiEdit.Enabled = true;
            cbpiDel.Enabled = true;

            cbR.Enabled = true;

            cbLC.Enabled = true;
            cblcAdd.Enabled = true;
            cblcEdit.Enabled = true;
            cblcDel.Enabled = true;

            cbLR.Enabled = true;
            cblrAdd.Enabled = true;
            cblrEdit.Enabled = true;
            cblrDel.Enabled = true;

            cbTU.Enabled = true;
            cbtuAdd.Enabled = true;
            cbtuEdit.Enabled = true;
            cbtuDel.Enabled = true;

            cbSR.Enabled = true;
            cbsrAdd.Enabled = true;
            cbsrEdit.Enabled = true;
            cbsrDel.Enabled = true;
            
            cbFC.Enabled = true;
            cbfcAdd.Enabled = true;
            cbfcEdit.Enabled = true;
            cbfcDel.Enabled = true;

            cbFR.Enabled = true;
            cbfrAdd.Enabled = true;
            cbfrEdit.Enabled = true;
            cbfrDel.Enabled = true;

            cbWLS.Enabled = true;
            cbwlsAdd.Enabled = true;
            cbwlsEdit.Enabled = true;
            cbwlsDel.Enabled = true;
        }

        private void cbTU_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTU.Checked == true)
            {
                TU = "Allow";
            }
            else
            {
                TU = "Not Allow";
            }
        }

        private void cbSR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSR.Checked == true)
            {
                SR = "Allow";
            }
            else
            {
                SR = "Not Allow";
            }
        }

        private void cbLR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLR.Checked == true)
            {
                LR = "Allow";
            }
            else
            {
                LR = "Not Allow";
            }
        }

        private void cbLC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLC.Checked == true)
            {
                LC = "Allow";
            }
            else
            {
                LC = "Not Allow";
            }
        }

        private void cbFC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFC.Checked == true)
            {
                FC = "Allow";
            }
            else
            {
                FC = "Not Allow";
            }
        }

        private void cbFR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFR.Checked == true)
            {
                FR = "Allow";
            }
            else
            {
                FR = "Not Allow";
            }
        }

        private void cbWLS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWLS.Checked == true)
            {
                WLS = "Allow";
            }
            else
            {
                WLS = "Not Allow";
            }
        }

        private void cbpiAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpiAdd.Checked == true)
            {
                piAdd = "1";
            }
            else
            {
                piAdd = "0";
            }
        }

        private void cbpiEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpiEdit.Checked == true)
            {
                piEdit = "1";
            }
            else
            {
                piEdit = "0";
            }
        }

        private void cbpiDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpiDel.Checked == true)
            {
                piDel = "1";
            }
            else
            {
                piDel = "0";
            }
        }

        private void cbtuAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtuAdd.Checked == true)
            {
                tuAdd = "1";
            }
            else
            {
                tuAdd = "0";
            }
        }

        private void cbtuEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtuEdit.Checked == true)
            {
                tuEdit = "1";
            }
            else
            {
                tuEdit = "0";
            }
        }

        private void cbtuDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtuDel.Checked == true)
            {
                tuDel = "1";
            }
            else
            {
                tuDel = "0";
            }
        }

        private void cblsAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cblsAdd.Checked == true)
            {
                lsAdd = "1";
            }
            else
            {
                lsAdd = "0";
            }
        }

        private void cblsEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cblsEdit.Checked == true)
            {
                lsEdit = "1";
            }
            else
            {
                lsEdit = "0";
            }
        }

        private void cblsDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cblsDel.Checked == true)
            {
                lsDel = "1";
            }
            else
            {
                lsDel = "0";
            }
        }

        private void cbsrAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsrAdd.Checked == true)
            {
                srAdd = "1";
            }
            else
            {
                srAdd = "0";
            }
        }

        private void cbsrEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsrEdit.Checked == true)
            {
                srEdit = "1";
            }
            else
            {
                srEdit = "0";
            }
        }

        private void cbsrDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsrDel.Checked == true)
            {
                srDel = "1";
            }
            else
            {
                srDel = "0";
            }
        }

        private void cblrAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cblrAdd.Checked == true)
            {
                lrAdd = "1";
            }
            else
            {
                lrAdd = "0";
            }
        }

        private void cblrEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cblrEdit.Checked == true)
            {
                lrEdit = "1";
            }
            else
            {
                lrEdit = "0";
            }
        }

        private void cblrDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cblrDel.Checked == true)
            {
                lrDel = "1";
            }
            else
            {
                lrDel = "0";
            }
        }

        private void cblcAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cblcAdd.Checked == true)
            {
                lcAdd = "1";
            }
            else
            {
                lcAdd = "0";
            }
        }

        private void cblcEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cblcEdit.Checked == true)
            {
                lcEdit = "1";
            }
            else
            {
                lcEdit = "0";
            }
        }

        private void cblcDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cblcDel.Checked == true)
            {
                lcDel = "1";
            }
            else
            {
                lcDel = "0";
            }
        }

        private void cbfcAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfcAdd.Checked == true)
            {
                fcAdd = "1";
            }
            else
            {
                fcAdd = "0";
            }
        }

        private void cbfcEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfcEdit.Checked == true)
            {
                fcEdit = "1";
            }
            else
            {
                fcEdit = "0";
            }
        }

        private void cbfcDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfcDel.Checked == true)
            {
                fcDel = "1";
            }
            else
            {
                fcDel = "0";
            }
        }

        private void cbfrAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfrAdd.Checked == true)
            {
                frAdd = "1";
            }
            else
            {
                frAdd = "0";
            }
        }

        private void cbfrEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfrEdit.Checked == true)
            {
                frEdit = "1";
            }
            else
            {
                frEdit = "0";
            }
        }

        private void cbfrDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfrDel.Checked == true)
            {
                frDel = "1";
            }
            else
            {
                frDel = "0";
            }
        }

        private void cbwlsAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbwlsAdd.Checked == true)
            {
                wlsAdd = "1";
            }
            else
            {
                wlsAdd = "0";
            }
        }

        private void cbwlsEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbwlsEdit.Checked == true)
            {
                wlsEdit = "1";
            }
            else
            {
                wlsEdit = "0";
            }
        }

        private void cbwlsDel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbwlsDel.Checked == true)
            {
                wlsDel = "1";
            }
            else
            {
                wlsDel = "0";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstUser.SelectedIndex != -1)
            {
                DelAcct();
            }
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUser.SelectedIndex != -1)
            {
                btnDelete.Enabled = true;
            }
        }
    }
}
