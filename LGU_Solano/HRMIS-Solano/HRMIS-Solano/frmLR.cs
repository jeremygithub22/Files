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
    public partial class frmLR : Form
    {
        public frmLR()
        {
            InitializeComponent();
        }
        string SQL, Transaction, RecNo, V = "0", S = "0", SPL = "0", Maternity = "0", Paternity = "0", Commutable = "0", NonComm = "0";
        string B = "0", E = "0", A = "0", M = "0", Sol = "0";
        double TSPL;
        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();
        void Add()
        {
            try
            {
                conn.SetConstr();
                if (MessageBox.Show("Are you sure, you want to add this record?", "Leave Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtTotal.Text != "")
                    {
                        if (txtEmpID.Text != "")
                        {
                            //Leave Record
                            SQL = "insert into tblleaverecord(EmpID,RecDate,Vacation,Vbal,Sick,Sbal,SPL,SPbal,Maternity,Mbal,Paternity,Pbal,Incldates,NoWorkdays,Commutable,NonCommutable,Bday,Bval,Enrollment,Eval,Anniversary,Aval,Mourning,Mval,Solo,Solval)values(@EmpID,@RecDate,@Vacation,@Vbal,@Sick,@Sbal,@SPL,@SPbal,@Maternity,@Mbal,@Paternity,@Pbal,@Incldates,@NoWorkdays,@Commutable,@NonCommutable,@Bday,@Bval,@Enrollment,@Eval,@Anniversary,@Aval,@Mourning,@Mval,@Solo,@Solval)";
                            da = new MySqlDataAdapter();
                            da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                            da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                            da.InsertCommand.Parameters.Add("@RecDate", MySqlDbType.Date).Value = dtpDateRec.Value;
                            da.InsertCommand.Parameters.Add("@Vacation", MySqlDbType.VarChar).Value = txtTV.Text;
                            da.InsertCommand.Parameters.Add("@Vbal", MySqlDbType.VarChar).Value = txtNV.Text;
                            da.InsertCommand.Parameters.Add("@Sick", MySqlDbType.VarChar).Value = txtTS.Text;
                            da.InsertCommand.Parameters.Add("@Sbal", MySqlDbType.VarChar).Value = txtNS.Text;
                            da.InsertCommand.Parameters.Add("@SPL", MySqlDbType.VarChar).Value = txtTSP.Text;
                            da.InsertCommand.Parameters.Add("@SPbal", MySqlDbType.VarChar).Value = txtNSP.Text;
                            da.InsertCommand.Parameters.Add("@Maternity", MySqlDbType.VarChar).Value = txtTM.Text;
                            da.InsertCommand.Parameters.Add("@Mbal", MySqlDbType.VarChar).Value = txtNM.Text;
                            da.InsertCommand.Parameters.Add("@Paternity", MySqlDbType.VarChar).Value = txtTP.Text;
                            da.InsertCommand.Parameters.Add("@Pbal", MySqlDbType.VarChar).Value = txtNP.Text;
                            da.InsertCommand.Parameters.Add("@Incldates", MySqlDbType.VarChar).Value = txtDateofL.Text;
                            da.InsertCommand.Parameters.Add("@NoWorkdays", MySqlDbType.VarChar).Value = txtNWorkTotal.Text;
                            da.InsertCommand.Parameters.Add("@Commutable", MySqlDbType.VarChar).Value = txtComm.Text;
                            da.InsertCommand.Parameters.Add("@NonCommutable", MySqlDbType.VarChar).Value = txtNComm.Text;
                            da.InsertCommand.Parameters.Add("@Bday", MySqlDbType.VarChar).Value = txtTB.Text;
                            da.InsertCommand.Parameters.Add("@Bval", MySqlDbType.VarChar).Value = txtNB.Text;
                            da.InsertCommand.Parameters.Add("@Enrollment", MySqlDbType.VarChar).Value = txtTE.Text;
                            da.InsertCommand.Parameters.Add("@Eval", MySqlDbType.VarChar).Value = txtNE.Text;
                            da.InsertCommand.Parameters.Add("@Anniversary", MySqlDbType.VarChar).Value = txtTA.Text;
                            da.InsertCommand.Parameters.Add("@Aval", MySqlDbType.VarChar).Value = txtNA.Text;
                            da.InsertCommand.Parameters.Add("@Mourning", MySqlDbType.VarChar).Value = txtTMourn.Text;
                            da.InsertCommand.Parameters.Add("@Mval", MySqlDbType.VarChar).Value = txtNMourn.Text;
                            da.InsertCommand.Parameters.Add("@Solo", MySqlDbType.VarChar).Value = txtTSol.Text;
                            da.InsertCommand.Parameters.Add("@Solval", MySqlDbType.VarChar).Value = txtNSol.Text;
                            Connection.Conn.Open();
                            da.InsertCommand.ExecuteNonQuery();
                            Connection.Conn.Close();
                            //Leave Credits

                            //Compute

                            //Vacation & Sick

                            double Vval = double.Parse(txtNV.Text);
                            double NewV = double.Parse(txtVacation.Text) - Vval;

                            double Sval = double.Parse(txtNS.Text);
                            double NewS = double.Parse(txtSick.Text) - Sval;

                            //Total

                            double GTotal = (NewV * 1) + (NewS * 1);

                            GetNo();
                            txtRecNo.Text = RecNo;
                            GetSPL();
                            SQL = "insert into tblleavecredits(EmpID,DateRec,Vused,Sused,SLP,Vbal,Sbal,Total,RecNo,Remarks)values(@EmpID,@DateRec,@Vused,@Sused,@SLP,@Vbal,@Sbal,@Total,@RecNo,'Applied Leave')";
                            da = new MySqlDataAdapter();
                            da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                            da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                            da.InsertCommand.Parameters.Add("@DateRec", MySqlDbType.Date).Value = dtpDateRec.Value;
                            da.InsertCommand.Parameters.Add("@Vused", MySqlDbType.VarChar).Value = txtNV.Text;
                            da.InsertCommand.Parameters.Add("@Sused", MySqlDbType.VarChar).Value = txtNS.Text;
                            da.InsertCommand.Parameters.Add("@SLP", MySqlDbType.VarChar).Value = TSPL.ToString();
                            da.InsertCommand.Parameters.Add("@Vbal", MySqlDbType.VarChar).Value = NewV.ToString();
                            da.InsertCommand.Parameters.Add("@Sbal", MySqlDbType.VarChar).Value = NewS.ToString();
                            da.InsertCommand.Parameters.Add("@Total", MySqlDbType.VarChar).Value = GTotal.ToString();
                            da.InsertCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = RecNo;
                            Connection.Conn.Open();
                            da.InsertCommand.ExecuteNonQuery();
                            Connection.Conn.Close();

                            MessageBox.Show("Successfully add record", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Display();
                            GetBal();
                            btnNew.Enabled = true;
                            btnEdit.Enabled = false;
                            btnSave.Enabled = false;
                            frmPVAL pval = new frmPVAL();
                            frmPVAL.RecNo = txtRecNo.Text;
                            pval.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No leave balance set, please set first before continue this transacion", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                conn.SetConstr();
                if (MessageBox.Show("Are you sure, you want to update this record?", "Leave Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (RecNo != "")
                    {
                        SQL = "update tblleaverecord set RecDate=@RecDate,Vacation=@Vacation,Vbal=@Vbal,Sick=@Sick,Sbal=@Sbal,SPL=@SPL,SPbal=@SPbal,Maternity=@Maternity,Mbal=@Mbal,Paternity=@Paternity,Pbal=@Pbal,Incldates=@Incldates,NoWorkdays=@NoWorkdays,Commutable=@Commutable,NonCommutable=@NonCommutable,Bday=@Bday,Bval=@Bval,Enrollment=@Enrollment,Eval=@Eval,Anniversary=@Anniversary,Aval=@Aval,Mourning=@Mourning,Mval=@Mval,Solo=@Solo,Solval=@Solval where RecNo=@RecNo and EmpID=@EmpID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = txtRecNo.Text;
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.UpdateCommand.Parameters.Add("@RecDate", MySqlDbType.Date).Value = dtpDateRec.Value;
                        da.UpdateCommand.Parameters.Add("@Vacation", MySqlDbType.VarChar).Value = txtTV.Text;
                        da.UpdateCommand.Parameters.Add("@Vbal", MySqlDbType.VarChar).Value = txtNV.Text;
                        da.UpdateCommand.Parameters.Add("@Sick", MySqlDbType.VarChar).Value = txtTS.Text;
                        da.UpdateCommand.Parameters.Add("@Sbal", MySqlDbType.VarChar).Value = txtNS.Text;
                        da.UpdateCommand.Parameters.Add("@SPL", MySqlDbType.VarChar).Value = txtTSP.Text;
                        da.UpdateCommand.Parameters.Add("@SPbal", MySqlDbType.VarChar).Value = txtNSP.Text;
                        da.UpdateCommand.Parameters.Add("@Maternity", MySqlDbType.VarChar).Value = txtTM.Text;
                        da.UpdateCommand.Parameters.Add("@Mbal", MySqlDbType.VarChar).Value = txtNM.Text;
                        da.UpdateCommand.Parameters.Add("@Paternity", MySqlDbType.VarChar).Value = txtTP.Text;
                        da.UpdateCommand.Parameters.Add("@Pbal", MySqlDbType.VarChar).Value = txtNP.Text;
                        da.UpdateCommand.Parameters.Add("@Incldates", MySqlDbType.VarChar).Value = txtDateofL.Text;
                        da.UpdateCommand.Parameters.Add("@NoWorkdays", MySqlDbType.VarChar).Value = txtNWorkTotal.Text;
                        da.UpdateCommand.Parameters.Add("@Commutable", MySqlDbType.VarChar).Value = txtComm.Text;
                        da.UpdateCommand.Parameters.Add("@NonCommutable", MySqlDbType.VarChar).Value = txtNComm.Text;
                        da.UpdateCommand.Parameters.Add("@Bday", MySqlDbType.VarChar).Value = txtTB.Text;
                        da.UpdateCommand.Parameters.Add("@Bval", MySqlDbType.VarChar).Value = txtNB.Text;
                        da.UpdateCommand.Parameters.Add("@Enrollment", MySqlDbType.VarChar).Value = txtTE.Text;
                        da.UpdateCommand.Parameters.Add("@Eval", MySqlDbType.VarChar).Value = txtNE.Text;
                        da.UpdateCommand.Parameters.Add("@Anniversary", MySqlDbType.VarChar).Value = txtTA.Text;
                        da.UpdateCommand.Parameters.Add("@Aval", MySqlDbType.VarChar).Value = txtNA.Text;
                        da.UpdateCommand.Parameters.Add("@Mourning", MySqlDbType.VarChar).Value = txtTMourn.Text;
                        da.UpdateCommand.Parameters.Add("@Mval", MySqlDbType.VarChar).Value = txtNMourn.Text;
                        da.UpdateCommand.Parameters.Add("@Solo", MySqlDbType.VarChar).Value = txtTSol.Text;
                        da.UpdateCommand.Parameters.Add("@Solval", MySqlDbType.VarChar).Value = txtNSol.Text;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();
                        MessageBox.Show("Successfully add record", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                        btnNew.Enabled = true;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        dgvList.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetSPL()
        {
            try
            {
                TSPL = (double.Parse(txtNSP.Text) * 1) + (double.Parse(txtNP.Text) * 1) + (double.Parse(txtNM.Text) * 1) + (double.Parse(txtNB.Text) * 1) + (double.Parse(txtNE.Text) * 1) + (double.Parse(txtNA.Text) * 1) + (double.Parse(txtNMourn.Text) * 1) + (double.Parse(txtNSol.Text) * 1);
            }
            catch
            {
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
                        MessageBox.Show("Employee does not exist.", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Employee does not exist.", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cboSearchby.Text == "Record No.")
                {
                    SQL = "select * from tblleaverecord where RecNo=@RecNo";
                    da = new MySqlDataAdapter(SQL, Connection.Conn);
                    dt = new DataTable();
                    da.SelectCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = txtSearch.Text;
                    da.Fill(dt);
                    Connection.Conn.Close();
                    if (dt.Rows.Count != 0)
                    {
                        dgvList.DataSource = dt;
                        DataRow dr = dt.Rows[0];
                        SQL = "select *,concat(Surname,', ',Firstname,' ',Middlename)as Name from tblpi where EmpID=@EmpID";
                        da = new MySqlDataAdapter(SQL, Connection.Conn);
                        dt = new DataTable();
                        da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = dr["EmpID"];
                        da.Fill(dt);
                        Connection.Conn.Close();
                        if (dt.Rows.Count != 0)
                        {
                            DataRow drN = dt.Rows[0];
                            txtEmpID.Text = drN["EmpID"].ToString();
                            txtName.Text = drN["Name"].ToString();
                            GetBal();
                        }
                        else
                        {
                            txtEmpID.Clear();
                            txtName.Clear();
                            MessageBox.Show("Record not found.", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        dgvList.DataSource = null;
                        MessageBox.Show("Record not found.", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        void Display()
        {
            try
            {
                conn.SetConstr();
                SQL = "select RecNo as `Record No.`,RecDate as `Date of Record`,Vacation,Vbal as `No. of Vacation Applied`,Sick,Sbal as `No. of Sick Applied`,SPL as `Other SPL`,SPbal as `No. of Other SPL Applied`,Maternity,Mbal as `No. of Maternity Applied`,Paternity,Pbal as `No. of Paternity Applied`,Bday as `Birthday`,Bval as `No. of Birthday Applied`,Enrollment,Eval as `No. of Enrollment Applied`,Anniversary,Aval as `No. of Anniversary Applied`,Mourning,Mval as `No. of Mourning Applied`,Solo,Solval as `No. of Solo Applied`,Incldates as `Inclusive Dates`,NoWorkdays as `No. of Working Days`,Commutable,NonCommutable as `Non-Commutable` from tblleaverecord where EmpID=@EmpID";
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
        void GetNo()
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblleaverecord where EmpID=@EmpID and RecDate=@RecDate and Vacation=@Vacation and Vbal=@Vbal and Sick=@Sick and Sbal=@Sbal and SPL=@SPL and SPbal=@SPbal and Maternity=@Maternity and Mbal=@Mbal and Paternity=@Paternity and Pbal=@Pbal and Incldates=@Incldates and NoWorkdays=@NoWorkdays and Bday=@Bday and Bval=@Bval and Enrollment=@Enrollment and Eval=@Eval and Anniversary=@Anniversary and Aval=@Aval and Mourning=@Mourning and Mval=@Mval and Solo=@Solo and Solval=@Solval";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.SelectCommand.Parameters.Add("@RecDate", MySqlDbType.Date).Value = dtpDateRec.Value;
                da.SelectCommand.Parameters.Add("@Vacation", MySqlDbType.VarChar).Value = txtTV.Text;
                da.SelectCommand.Parameters.Add("@Vbal", MySqlDbType.VarChar).Value = txtNV.Text;
                da.SelectCommand.Parameters.Add("@Sick", MySqlDbType.VarChar).Value = txtTS.Text;
                da.SelectCommand.Parameters.Add("@Sbal", MySqlDbType.VarChar).Value = txtNS.Text;
                da.SelectCommand.Parameters.Add("@SPL", MySqlDbType.VarChar).Value = txtTSP.Text;
                da.SelectCommand.Parameters.Add("@SPbal", MySqlDbType.VarChar).Value = txtNSP.Text;
                da.SelectCommand.Parameters.Add("@Maternity", MySqlDbType.VarChar).Value = txtTM.Text;
                da.SelectCommand.Parameters.Add("@Mbal", MySqlDbType.VarChar).Value = txtNM.Text;
                da.SelectCommand.Parameters.Add("@Paternity", MySqlDbType.VarChar).Value = txtTP.Text;
                da.SelectCommand.Parameters.Add("@Pbal", MySqlDbType.VarChar).Value = txtNP.Text;
                da.SelectCommand.Parameters.Add("@Incldates", MySqlDbType.VarChar).Value = txtDateofL.Text;
                da.SelectCommand.Parameters.Add("@NoWorkdays", MySqlDbType.VarChar).Value = txtNWorkTotal.Text;
                da.SelectCommand.Parameters.Add("@Bday", MySqlDbType.VarChar).Value = txtTB.Text;
                da.SelectCommand.Parameters.Add("@Bval", MySqlDbType.VarChar).Value = txtNB.Text;
                da.SelectCommand.Parameters.Add("@Enrollment", MySqlDbType.VarChar).Value = txtTE.Text;
                da.SelectCommand.Parameters.Add("@Eval", MySqlDbType.VarChar).Value = txtNE.Text;
                da.SelectCommand.Parameters.Add("@Anniversary", MySqlDbType.VarChar).Value = txtTA.Text;
                da.SelectCommand.Parameters.Add("@Aval", MySqlDbType.VarChar).Value = txtNA.Text;
                da.SelectCommand.Parameters.Add("@Mourning", MySqlDbType.VarChar).Value = txtTMourn.Text;
                da.SelectCommand.Parameters.Add("@Mval", MySqlDbType.VarChar).Value = txtNMourn.Text;
                da.SelectCommand.Parameters.Add("@Solo", MySqlDbType.VarChar).Value = txtTSol.Text;
                da.SelectCommand.Parameters.Add("@Solval", MySqlDbType.VarChar).Value = txtNSol.Text;
                dt = new DataTable();
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    RecNo = dr["RecNo"].ToString();
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
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtVacation.Text = dr["Vbal"].ToString();
                    txtSick.Text = dr["Sbal"].ToString();
                    txtTotal.Text = dr["Total"].ToString();
                }
                else
                {
                    txtVacation.Clear();
                    txtSick.Clear();
                    txtTotal.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetTotal()
        {
            try
            {
                double Total = (double.Parse(txtNM.Text) * 1) + (double.Parse(txtNP.Text) * 1) + (double.Parse(txtNS.Text) * 1) + (double.Parse(txtNSP.Text) * 1) + (double.Parse(txtNV.Text) * 1) + (double.Parse(txtNB.Text) * 1) + (double.Parse(txtNE.Text) * 1) + (double.Parse(txtNA.Text) * 1) + (double.Parse(txtNMourn.Text) * 1) + (double.Parse(txtNSol.Text) * 1);
                txtNWorkTotal.Text = Total.ToString();
            }
            catch 
            {
            }
        }

        private void txtNV_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNS_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNSP_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNM_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNP_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Transaction = "New";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txtComm.Clear();
            txtDateofL.Clear();
            txtNComm.Clear();
            txtNM.Text = "0";
            txtNP.Text = "0";
            txtNS.Text = "0";
            txtNSP.Text = "0";
            txtNV.Text = "0";
            txtNB.Text = "0";
            txtNE.Text = "0";
            txtNA.Text = "0";
            txtNMourn.Text = "0";
            txtNSol.Text = "0";
            txtNWorkTotal.Text = "0";
            txtTM.Clear();
            txtTP.Clear();
            txtTS.Clear();
            txtTSP.Clear();
            txtTV.Clear();
            txtTB.Clear();
            txtTE.Clear();
            txtTA.Clear();
            txtTMourn.Clear();
            txtTSol.Clear();
            dtpDateRec.Value = DateTime.Now;
        }
        void Deldata()
        {
            try
            {
                if (RecNo != "")
                {
                    conn.SetConstr();
                    SQL = "delete from tblleaverecord where RecNo=@RecNo";
                    da = new MySqlDataAdapter();
                    da.DeleteCommand = new MySqlCommand(SQL, Connection.Conn);
                    da.DeleteCommand.Parameters.Add("@RecNo", MySqlDbType.VarChar).Value = dgvList.SelectedRows[0].Cells["Record No."].Value.ToString();
                    Connection.Conn.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    Connection.Conn.Close();
                    MessageBox.Show("Successfully deleted record", "Leave Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Display();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                Transaction = "Edit";
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;

                txtRecNo.Text = dgvList.SelectedRows[0].Cells["Record No."].Value.ToString();
                txtComm.Text = dgvList.SelectedRows[0].Cells["Commutable"].Value.ToString();
                txtDateofL.Text = dgvList.SelectedRows[0].Cells["Inclusive Dates"].Value.ToString();
                txtNComm.Text = dgvList.SelectedRows[0].Cells["Non-Commutable"].Value.ToString();
                txtNM.Text = dgvList.SelectedRows[0].Cells["No. of Maternity Applied"].Value.ToString();
                txtNP.Text = dgvList.SelectedRows[0].Cells["No. of Paternity Applied"].Value.ToString();
                txtNS.Text = dgvList.SelectedRows[0].Cells["No. of Sick Applied"].Value.ToString();
                txtNSP.Text = dgvList.SelectedRows[0].Cells["No. of Other SPL Applied"].Value.ToString();
                txtNV.Text = dgvList.SelectedRows[0].Cells["No. of Vacation Applied"].Value.ToString();
                txtNB.Text = dgvList.SelectedRows[0].Cells["No. of Birthday Applied"].Value.ToString();
                txtNE.Text = dgvList.SelectedRows[0].Cells["No. of Enrollment Applied"].Value.ToString();
                txtNA.Text = dgvList.SelectedRows[0].Cells["No. of Anniversary Applied"].Value.ToString();
                txtNMourn.Text = dgvList.SelectedRows[0].Cells["No. of Mourning Applied"].Value.ToString();
                txtNSol.Text = dgvList.SelectedRows[0].Cells["No. of Solo Applied"].Value.ToString();
                txtNWorkTotal.Text = dgvList.SelectedRows[0].Cells["No. of Working Days"].Value.ToString();
                txtTM.Text = dgvList.SelectedRows[0].Cells["Maternity"].Value.ToString();
                txtTP.Text = dgvList.SelectedRows[0].Cells["Paternity"].Value.ToString();
                txtTS.Text = dgvList.SelectedRows[0].Cells["Sick"].Value.ToString();
                txtTSP.Text = dgvList.SelectedRows[0].Cells["Other SPL"].Value.ToString();
                txtTV.Text = dgvList.SelectedRows[0].Cells["Vacation"].Value.ToString();
                txtTB.Text = dgvList.SelectedRows[0].Cells["Birthday"].Value.ToString();
                txtTE.Text = dgvList.SelectedRows[0].Cells["Enrollment"].Value.ToString();
                txtTA.Text = dgvList.SelectedRows[0].Cells["Anniversary"].Value.ToString();
                txtTMourn.Text = dgvList.SelectedRows[0].Cells["Mourning"].Value.ToString();
                txtTSol.Text = dgvList.SelectedRows[0].Cells["Solo"].Value.ToString();
                dtpDateRec.Text = dgvList.SelectedRows[0].Cells["Date of Record"].Value.ToString();
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
            if (UserDetails.APLR == "1")
            {
                btnNew.Enabled = true;
            }
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            dgvList.Enabled = true;
            dgvList.DataSource = null;

            txtRecNo.Clear();
            txtComm.Clear();
            txtDateofL.Clear();
            txtNComm.Clear();
            txtNM.Text = "0";
            txtNP.Text = "0";
            txtNS.Text = "0";
            txtNSP.Text = "0";
            txtNV.Text = "0";
            txtNB.Text = "0"; 
            txtNE.Text = "0";
            txtNA.Text = "0";
            txtNMourn.Text = "0";
            txtNSol.Text = "0";
            txtNWorkTotal.Text = "0";
            txtTM.Clear();
            txtTP.Clear();
            txtTS.Clear();
            txtTSP.Clear();
            txtTV.Clear();
            txtTB.Clear();
            txtTE.Clear();
            txtTA.Clear();
            txtTMourn.Clear();
            txtTSol.Clear();
            dtpDateRec.Value = DateTime.Now;
            
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

        private void txtTV_Click(object sender, EventArgs e)
        {
            if (V == "0")
            {
                txtTV.Text = "XXX";
                V = "1";
            }
            else
            {
                txtTV.Text = "";
                V = "0";
            }
        }

        private void txtTS_Click(object sender, EventArgs e)
        {
            if (S == "0")
            {
                txtTS.Text = "XXX";
                S = "1";
            }
            else
            {
                txtTS.Text = "";
                S = "0";
            }
        }

        private void txtTSP_Click(object sender, EventArgs e)
        {
            if (SPL == "0")
            {
                txtTSP.Text = "XXX";
                SPL = "1";
            }
            else
            {
                txtTSP.Text = "";
                SPL = "0";
            }
        }

        private void txtTM_Click(object sender, EventArgs e)
        {
            if (Maternity == "0")
            {
                txtTM.Text = "XXX";
                Maternity = "1";
            }
            else
            {
                txtTM.Text = "";
                Maternity = "0";
            }
        }

        private void txtTP_Click(object sender, EventArgs e)
        {
            if (Paternity == "0")
            {
                txtTP.Text = "XXX";
                Paternity = "1";
            }
            else
            {
                txtTP.Text = "";
                Paternity = "0";
            }
        }

        private void txtComm_Click(object sender, EventArgs e)
        {
            if (Commutable == "0")
            {
                txtComm.Text = "XXX";
                Commutable = "1";
            }
            else
            {
                txtComm.Text = "";
                Commutable = "0";
            }
        }

        private void txtNComm_Click(object sender, EventArgs e)
        {
            if (NonComm == "0")
            {
                txtNComm.Text = "XXX";
                NonComm = "1";
            }
            else
            {
                txtNComm.Text = "";
                NonComm = "0";
            }
        }

        private void lstEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedIndex != -1)
            {
                txtEmpID.Text = lstEmployee.SelectedValue.ToString();
                txtName.Text = lstEmployee.Text;
                Display();
                GetBal();
            }
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (UserDetails.EPLR == "1")
                {
                    btnEdit.Enabled = true;
                }
                if (UserDetails.DPLR == "1")
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record", "Leave Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Deldata();
                }
            }
        }

        private void frmLR_Load(object sender, EventArgs e)
        {
            if (UserDetails.APLR == "1")
            {
                btnNew.Enabled = true;
            }
        }

        private void txtTB_Click(object sender, EventArgs e)
        {
            if (B == "0")
            {
                txtTB.Text = "XXX";
                B = "1";
            }
            else
            {
                txtTB.Text = "";
                B = "0";
            }
        }

        private void txtTE_Click(object sender, EventArgs e)
        {
            if (E == "0")
            {
                txtTE.Text = "XXX";
                E = "1";
            }
            else
            {
                txtTE.Text = "";
                E = "0";
            }
        }

        private void txtTA_Click(object sender, EventArgs e)
        {
            if (A == "0")
            {
                txtTA.Text = "XXX";
                A = "1";
            }
            else
            {
                txtTA.Text = "";
                A = "0";
            }
        }

        private void txtTMourn_Click(object sender, EventArgs e)
        {
            if (M == "0")
            {
                txtTMourn.Text = "XXX";
                M = "1";
            }
            else
            {
                txtTMourn.Text = "";
                M = "0";
            }
        }

        private void txtTSol_Click(object sender, EventArgs e)
        {
            if (Sol == "0")
            {
                txtTSol.Text = "XXX";
                Sol = "1";
            }
            else
            {
                txtTSol.Text = "";
                Sol = "0";
            }
        }

        private void txtNB_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNE_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNA_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNMourn_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNSol_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }
    }
}
