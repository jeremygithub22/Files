using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace HRMIS_Solano
{
    public partial class frmPI2 : Form
    {
        public frmPI2()
        {
            InitializeComponent();
        }
        public string Transaction;
        string SQL, Gender, Sex, EmpID, Surname, Firstname, Middlename, NE, DB, PB, CS, C, H, W, BT, GIN, PIN, PN, SSSN, RA, RAZ, RATN;
        string PA, PAZ, PATN, email, CN, AEN, Tin;
        public byte[] BlobValue;
        byte[] tempBlobValue;

        MySqlDataAdapter da;
        DataTable dt;
        Connection conn = new Connection();

        void Add()
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to add this record?", "Personal Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.SetConstr();
                    if (txtEmpID.Text != "")
                    {
                        SQL = "select * from tblpi where EmpID=@EmpID";
                        da = new MySqlDataAdapter(SQL, Connection.Conn);
                        dt = new DataTable();
                        da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.Fill(dt);
                        Connection.Conn.Close();
                        if (dt.Rows.Count == 0)
                        {
                            SQL = "insert into tblpi(EmpID,Surname,Firstname,Middlename,Ne,Dbirth,Pbirth,Sex,Civilstatus,Citizenship,Height,Weight,Bloodtype,GSIS,PAGIBIG,PHILHEALTH,SSS,ResAdd,ResZC,Restel,PerAdd,PerZC,Pertel,Eadd,CN,AEN,Tin)values(@EmpID,@Surname,@Firstname,@Middlename,@Ne,@Dbirth,@Pbirth,@Sex,@Civilstatus,@Citizenship,@Height,@Weight,@Bloodtype,@GSIS,@PAGIBIG,@PHILHEALTH,@SSS,@ResAdd,@ResZC,@Restel,@PerAdd,@PerZC,@Pertel,@Eadd,@CN,@AEN,@Tin)";
                            da = new MySqlDataAdapter();
                            da.InsertCommand = new MySqlCommand(SQL, Connection.Conn);
                            da.InsertCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                            da.InsertCommand.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = txtSurname.Text;
                            da.InsertCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtFirstname.Text;
                            da.InsertCommand.Parameters.Add("@Middlename", MySqlDbType.VarChar).Value = txtMiddlename.Text;
                            da.InsertCommand.Parameters.Add("@Ne", MySqlDbType.VarChar).Value = txtNE.Text;
                            da.InsertCommand.Parameters.Add("@Dbirth", MySqlDbType.DateTime).Value = dtpDate.Value;
                            da.InsertCommand.Parameters.Add("@Pbirth", MySqlDbType.VarChar).Value = txtPlaceofBirth.Text;
                            da.InsertCommand.Parameters.Add("@Sex", MySqlDbType.VarChar).Value = Gender;
                            da.InsertCommand.Parameters.Add("@Civilstatus", MySqlDbType.VarChar).Value = cboCivilStat.Text;
                            da.InsertCommand.Parameters.Add("@Citizenship", MySqlDbType.VarChar).Value = txtCitizenship.Text;
                            da.InsertCommand.Parameters.Add("@Height", MySqlDbType.VarChar).Value = txtHeight.Text;
                            da.InsertCommand.Parameters.Add("@Weight", MySqlDbType.VarChar).Value = txtWeight.Text;
                            da.InsertCommand.Parameters.Add("@Bloodtype", MySqlDbType.VarChar).Value = cboBloodtype.Text;
                            da.InsertCommand.Parameters.Add("@GSIS", MySqlDbType.VarChar).Value = txtGSIS.Text;
                            da.InsertCommand.Parameters.Add("@PAGIBIG", MySqlDbType.VarChar).Value = txtPagIBIG.Text;
                            da.InsertCommand.Parameters.Add("@PHILHEALTH", MySqlDbType.VarChar).Value = txtPhilHealth.Text;
                            da.InsertCommand.Parameters.Add("@SSS", MySqlDbType.VarChar).Value = txtSSS.Text;
                            da.InsertCommand.Parameters.Add("@ResAdd", MySqlDbType.VarChar).Value = txtResAdd.Text;
                            da.InsertCommand.Parameters.Add("@ResZC", MySqlDbType.VarChar).Value = txtResZC.Text;
                            da.InsertCommand.Parameters.Add("@Restel", MySqlDbType.VarChar).Value = txtResTel.Text;
                            da.InsertCommand.Parameters.Add("@PerAdd", MySqlDbType.VarChar).Value = txtPerAdd.Text;
                            da.InsertCommand.Parameters.Add("@PerZC", MySqlDbType.VarChar).Value = txtPerZC.Text;
                            da.InsertCommand.Parameters.Add("@Pertel", MySqlDbType.VarChar).Value = txtPerTel.Text;
                            da.InsertCommand.Parameters.Add("@Eadd", MySqlDbType.VarChar).Value = txtEmail.Text;
                            da.InsertCommand.Parameters.Add("@CN", MySqlDbType.VarChar).Value = txtCellno.Text;
                            da.InsertCommand.Parameters.Add("@AEN", MySqlDbType.VarChar).Value = txtAEN.Text;
                            da.InsertCommand.Parameters.Add("@Tin", MySqlDbType.VarChar).Value = txtTin.Text;
                            Connection.Conn.Open();
                            da.InsertCommand.ExecuteNonQuery();
                            Connection.Conn.Close();

                            try
                            {
                                if (ofdImage.FileName != "")
                                {
                                    FileStream fs = new FileStream(ofdImage.FileName, FileMode.Open, FileAccess.Read);
                                    BinaryReader reader = new BinaryReader(fs);
                                    BlobValue = reader.ReadBytes((int)fs.Length);

                                    SQL = "update tblpi set Picture=@Picture where EmpID=@EmpID";
                                    da = new MySqlDataAdapter();
                                    da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                                    da.UpdateCommand.Parameters.Add("@Picture", MySqlDbType.LongBlob).Value = BlobValue;
                                    da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                                    Connection.Conn.Open();
                                    da.UpdateCommand.ExecuteNonQuery();
                                    Connection.Conn.Close();
                                }
                            }
                            catch
                            {
                            }
                            MessageBox.Show("Successfully Add new Record", "Personal Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Employee ID exist, please choose another ID", "Personal Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please specify Employee ID", "Personal Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (MessageBox.Show("Are you sure, you want to update this record?", "Personal Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtEmpID.Text != "")
                    {
                        conn.SetConstr();
                        SQL = "update tblpi set Surname=@Surname,Firstname=@Firstname,Middlename=@Middlename,Ne=@Ne,Dbirth=@Dbirth,Pbirth=@Pbirth,Sex=@Sex,Civilstatus=@Civilstatus,Citizenship=@Citizenship,Height=@Height,Weight=@Weight,Bloodtype=@Bloodtype,GSIS=@GSIS,PAGIBIG=@PAGIBIG,PHILHEALTH=@PHILHEALTH,SSS=@SSS,ResAdd=@ResAdd,ResZC=@ResZC,Restel=@Restel,PerAdd=@PerAdd,PerZC=@PerZC,Pertel=@Pertel,Eadd=@Eadd,CN=@CN,AEN=@AEN,Tin=@Tin where EmpID=@EmpID";
                        da = new MySqlDataAdapter();
                        da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                        da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                        da.UpdateCommand.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = txtSurname.Text;
                        da.UpdateCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtFirstname.Text;
                        da.UpdateCommand.Parameters.Add("@Middlename", MySqlDbType.VarChar).Value = txtMiddlename.Text;
                        da.UpdateCommand.Parameters.Add("@Ne", MySqlDbType.VarChar).Value = txtNE.Text;
                        da.UpdateCommand.Parameters.Add("@Dbirth", MySqlDbType.DateTime).Value = dtpDate.Value;
                        da.UpdateCommand.Parameters.Add("@Pbirth", MySqlDbType.VarChar).Value = txtPlaceofBirth.Text;
                        da.UpdateCommand.Parameters.Add("@Sex", MySqlDbType.VarChar).Value = Gender;
                        da.UpdateCommand.Parameters.Add("@Civilstatus", MySqlDbType.VarChar).Value = cboCivilStat.Text;
                        da.UpdateCommand.Parameters.Add("@Citizenship", MySqlDbType.VarChar).Value = txtCitizenship.Text;
                        da.UpdateCommand.Parameters.Add("@Height", MySqlDbType.VarChar).Value = txtHeight.Text;
                        da.UpdateCommand.Parameters.Add("@Weight", MySqlDbType.VarChar).Value = txtWeight.Text;
                        da.UpdateCommand.Parameters.Add("@Bloodtype", MySqlDbType.VarChar).Value = cboBloodtype.Text;
                        da.UpdateCommand.Parameters.Add("@GSIS", MySqlDbType.VarChar).Value = txtGSIS.Text;
                        da.UpdateCommand.Parameters.Add("@PAGIBIG", MySqlDbType.VarChar).Value = txtPagIBIG.Text;
                        da.UpdateCommand.Parameters.Add("@PHILHEALTH", MySqlDbType.VarChar).Value = txtPhilHealth.Text;
                        da.UpdateCommand.Parameters.Add("@SSS", MySqlDbType.VarChar).Value = txtSSS.Text;
                        da.UpdateCommand.Parameters.Add("@ResAdd", MySqlDbType.VarChar).Value = txtResAdd.Text;
                        da.UpdateCommand.Parameters.Add("@ResZC", MySqlDbType.VarChar).Value = txtResZC.Text;
                        da.UpdateCommand.Parameters.Add("@Restel", MySqlDbType.VarChar).Value = txtResTel.Text;
                        da.UpdateCommand.Parameters.Add("@PerAdd", MySqlDbType.VarChar).Value = txtPerAdd.Text;
                        da.UpdateCommand.Parameters.Add("@PerZC", MySqlDbType.VarChar).Value = txtPerZC.Text;
                        da.UpdateCommand.Parameters.Add("@Pertel", MySqlDbType.VarChar).Value = txtPerTel.Text;
                        da.UpdateCommand.Parameters.Add("@Eadd", MySqlDbType.VarChar).Value = txtEmail.Text;
                        da.UpdateCommand.Parameters.Add("@CN", MySqlDbType.VarChar).Value = txtCellno.Text;
                        da.UpdateCommand.Parameters.Add("@AEN", MySqlDbType.VarChar).Value = txtAEN.Text;
                        da.UpdateCommand.Parameters.Add("@Tin", MySqlDbType.VarChar).Value = txtTin.Text;
                        Connection.Conn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        Connection.Conn.Close();

                        try
                        {
                            if (ofdImage.FileName != "")
                            {
                                FileStream fs = new FileStream(ofdImage.FileName, FileMode.Open, FileAccess.Read);
                                BinaryReader reader = new BinaryReader(fs);
                                BlobValue = reader.ReadBytes((int)fs.Length);

                                SQL = "update tblpi set Picture=@Picture where EmpID=@EmpID";
                                da = new MySqlDataAdapter();
                                da.UpdateCommand = new MySqlCommand(SQL, Connection.Conn);
                                da.UpdateCommand.Parameters.Add("@Picture", MySqlDbType.LongBlob).Value = BlobValue;
                                da.UpdateCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                                Connection.Conn.Open();
                                da.UpdateCommand.ExecuteNonQuery();
                                Connection.Conn.Close();
                            }
                        }
                        catch
                        {
                        }

                        txtAEN.Enabled = false;
                        txtCellno.Enabled = false;
                        txtCitizenship.Enabled = false;
                        txtEmail.Enabled = false;
                        txtEmpID.Enabled = false;
                        txtFirstname.Enabled = false;
                        txtGSIS.Enabled = false;
                        txtHeight.Enabled = false;
                        txtMiddlename.Enabled = false;
                        txtNE.Enabled = false;
                        txtPagIBIG.Enabled = false;
                        txtPerAdd.Enabled = false;
                        txtPerTel.Enabled = false;
                        txtPerZC.Enabled = false;
                        txtPhilHealth.Enabled = false;
                        txtPlaceofBirth.Enabled = false;
                        txtResAdd.Enabled = false;
                        txtResTel.Enabled = false;
                        txtResZC.Enabled = false;
                        txtSSS.Enabled = false;
                        txtSurname.Enabled = false;
                        txtTin.Enabled = false;
                        txtWeight.Enabled = false;
                        dtpDate.Enabled = false;
                        cboBloodtype.Enabled = false;
                        cboCivilStat.Enabled = false;
                        rbFemale.Enabled = false;
                        rbMale.Enabled = false;

                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnBrowse.Enabled = false;
                        MessageBox.Show("Successfully update Record", "Personal Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot update record. Please provide employee i.d.", "Personal Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Transaction == "New")
            {
                Add();
            }
            else if (Transaction == "Update")
            {
                Save();
            }
            else
            {
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnBrowse.Enabled = true;

            txtAEN.Enabled = true;
            txtCellno.Enabled = true;
            txtCitizenship.Enabled = true;
            txtEmail.Enabled = true;
            txtFirstname.Enabled = true;
            txtGSIS.Enabled = true;
            txtHeight.Enabled = true;
            txtMiddlename.Enabled = true;
            txtNE.Enabled = true;
            txtPagIBIG.Enabled = true;
            txtPerAdd.Enabled = true;
            txtPerTel.Enabled = true;
            txtPerZC.Enabled = true;
            txtPhilHealth.Enabled = true;
            txtPlaceofBirth.Enabled = true;
            txtResAdd.Enabled = true;
            txtResTel.Enabled = true;
            txtResZC.Enabled = true;
            txtSSS.Enabled = true;
            txtSurname.Enabled = true;
            txtTin.Enabled = true;
            txtWeight.Enabled = true;
            dtpDate.Enabled = true;
            cboBloodtype.Enabled = true;
            cboCivilStat.Enabled = true;
            rbFemale.Enabled = true;
            rbMale.Enabled = true;

            tempBlobValue = BlobValue;
            Sex = Gender;
            txtAEN.Text = AEN;
            txtCellno.Text = CN;
            txtCitizenship.Text = C;
            txtEmail.Text = email;
            txtEmpID.Text = EmpID;
            txtFirstname.Text = Firstname;
            txtGSIS.Text = GIN;
            txtHeight.Text = H;
            txtMiddlename.Text = Middlename;
            txtNE.Text = NE;
            txtPagIBIG.Text = PIN;
            txtPerAdd.Text = PA;
            txtPerTel.Text = PATN;
            txtPerZC.Text = PAZ;
            txtPhilHealth.Text = PN;
            txtPlaceofBirth.Text = PB;
            txtResAdd.Text = RA;
            txtResTel.Text = RATN;
            txtResZC.Text = RAZ;
            txtSSS.Text = SSSN;
            txtSurname.Text = Surname;
            txtTin.Text = Tin;
            txtWeight.Text = W;
            dtpDate.Text = DB;
            cboBloodtype.Text = BT;
            cboCivilStat.Text = CS;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Transaction == "New")
            {
                txtAEN.Clear();
                txtCellno.Clear();
                txtCitizenship.Clear();
                txtEmail.Clear();
                txtEmpID.Clear();
                txtFirstname.Clear();
                txtGSIS.Clear();
                txtHeight.Clear();
                txtMiddlename.Clear();
                txtNE.Clear();
                txtPagIBIG.Clear();
                txtPerAdd.Clear();
                txtPerTel.Clear();
                txtPerZC.Clear();
                txtPhilHealth.Clear();
                txtPlaceofBirth.Clear();
                txtResAdd.Clear();
                txtResTel.Clear();
                txtResZC.Clear();
                txtSSS.Clear();
                txtSurname.Clear();
                txtTin.Clear();
                txtWeight.Clear();
                dtpDate.Value = DateTime.Now;
                cboBloodtype.ResetText();
                cboCivilStat.ResetText();
                rbFemale.Checked = false;
                rbMale.Checked = false;

                txtAEN.Enabled = true;
                txtCellno.Enabled = true;
                txtCitizenship.Enabled = true;
                txtEmail.Enabled = true;
                txtEmpID.Enabled = true;
                txtFirstname.Enabled = true;
                txtGSIS.Enabled = true;
                txtHeight.Enabled = true;
                txtMiddlename.Enabled = true;
                txtNE.Enabled = true;
                txtPagIBIG.Enabled = true;
                txtPerAdd.Enabled = true;
                txtPerTel.Enabled = true;
                txtPerZC.Enabled = true;
                txtPhilHealth.Enabled = true;
                txtPlaceofBirth.Enabled = true;
                txtResAdd.Enabled = true;
                txtResTel.Enabled = true;
                txtResZC.Enabled = true;
                txtSSS.Enabled = true;
                txtSurname.Enabled = true;
                txtTin.Enabled = true;
                txtWeight.Enabled = true;
                dtpDate.Enabled = true;
                cboBloodtype.Enabled = true;
                cboCivilStat.Enabled = true;
                rbFemale.Enabled = true;
                rbMale.Enabled = true;

                txtEmpID.Focus();
            }
            else if (Transaction == "Update")
            {
                btnEdit.Enabled = true;
                btnSave.Enabled = false;

                txtAEN.Text = AEN;
                txtCellno.Text = CN;
                txtCitizenship.Text = C;
                txtEmail.Text = email;
                txtEmpID.Text = EmpID;
                txtFirstname.Text = Firstname;
                txtGSIS.Text = GIN;
                txtHeight.Text = H;
                txtMiddlename.Text = Middlename;
                txtNE.Text = NE;
                txtPagIBIG.Text = PIN;
                txtPerAdd.Text = PA;
                txtPerTel.Text = PATN;
                txtPerZC.Text = PAZ;
                txtPhilHealth.Text = PN;
                txtPlaceofBirth.Text = PB;
                txtResAdd.Text = RA;
                txtResTel.Text = RATN;
                txtResZC.Text = RAZ;
                txtSSS.Text = SSSN;
                txtSurname.Text = Surname;
                txtTin.Text = Tin;
                txtWeight.Text = W;
                dtpDate.Text = DB;
                cboBloodtype.Text = BT;
                cboCivilStat.Text = CS;
                if (Sex == "Male")
                {
                    rbMale.Checked = true;
                }
                if (Sex == "Female")
                {
                    rbFemale.Checked = true;
                }
                try
                {
                    MemoryStream ms1 = new MemoryStream(tempBlobValue);
                    pbxImage.Image = Image.FromStream(ms1);
                }
                catch
                {
                }

                txtAEN.Enabled = false;
                txtCellno.Enabled = false;
                txtCitizenship.Enabled = false;
                txtEmail.Enabled = false;
                txtEmpID.Enabled = false;
                txtFirstname.Enabled = false;
                txtGSIS.Enabled = false;
                txtHeight.Enabled = false;
                txtMiddlename.Enabled = false;
                txtNE.Enabled = false;
                txtPagIBIG.Enabled = false;
                txtPerAdd.Enabled = false;
                txtPerTel.Enabled = false;
                txtPerZC.Enabled = false;
                txtPhilHealth.Enabled = false;
                txtPlaceofBirth.Enabled = false;
                txtResAdd.Enabled = false;
                txtResTel.Enabled = false;
                txtResZC.Enabled = false;
                txtSSS.Enabled = false;
                txtSurname.Enabled = false;
                txtTin.Enabled = false;
                txtWeight.Enabled = false;
                dtpDate.Enabled = false;
                cboBloodtype.Enabled = false;
                cboCivilStat.Enabled = false;
                rbFemale.Enabled = false;
                rbMale.Enabled = false;

                txtEmpID.Focus();
            }
            else
            {
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked == true)
            {
                Gender = "Male";
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked == true)
            {
                Gender = "Female";
            }
        }

        private void frmPI2_Load(object sender, EventArgs e)
        {
            if (Transaction == "New")
            {
                btnSave.Enabled = true;
                btnBrowse.Enabled = true;
            }
            else if (Transaction == "Update")
            {
                if (UserDetails.EPPI == "1")
                {
                    btnEdit.Visible = true;
                    btnBrowse.Enabled = true;
                    btnCancel.Enabled = true;
                }
                else
                {
                    btnCancel.Enabled = false;
                }
            }
            else
            {
            }
            AEN = txtAEN.Text;
            CN = txtCellno.Text;
            C = txtCitizenship.Text;
            email = txtEmail.Text;
            EmpID = txtEmpID.Text;
            Firstname = txtFirstname.Text;
            GIN = txtGSIS.Text;
            H = txtHeight.Text;
            Middlename = txtMiddlename.Text;
            NE = txtNE.Text;
            PIN = txtPagIBIG.Text;
            PA = txtPerAdd.Text;
            PATN = txtPerTel.Text;
            PAZ = txtPerZC.Text;
            PN = txtPhilHealth.Text;
            PB = txtPlaceofBirth.Text;
            RA = txtResAdd.Text;
            RATN = txtResTel.Text;
            RAZ = txtResZC.Text;
            SSSN = txtSSS.Text;
            Surname = txtSurname.Text;
            Tin = txtTin.Text;
            W = txtWeight.Text;
            DB = dtpDate.Text;
            BT = cboBloodtype.Text;
            CS = cboCivilStat.Text;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(ofdImage.FileName);
                double length = f.Length;
                if (length >= 1048576)
                {
                    MessageBox.Show("Image File is too large, please compress Image", "Personal Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    pbxImage.Image = new Bitmap(ofdImage.FileName);
                }
            }
        }
    }
}
