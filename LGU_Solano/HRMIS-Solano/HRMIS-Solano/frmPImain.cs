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
    public partial class frmPImain : Form
    {
        public frmPImain()
        {
            InitializeComponent();
        }
        string SQL;
        MySqlDataAdapter da;
        Connection conn = new Connection();
        DataTable dt;

        private void btnPI_Click(object sender, EventArgs e)
        {
            try
            {
                conn.SetConstr();
                SQL = "select * from tblpi where EmpID=@EmpID";
                da = new MySqlDataAdapter(SQL, Connection.Conn);
                dt = new DataTable();
                da.SelectCommand.Parameters.Add("@EmpID", MySqlDbType.VarChar).Value = txtEmpID.Text;
                da.Fill(dt);
                Connection.Conn.Close();
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    frmPI2 pi2 = new frmPI2();

                    pi2.Transaction = "Update";

                    pi2.txtAEN.Text = dr["AEN"].ToString();
                    pi2.txtCellno.Text = dr["CN"].ToString();
                    pi2.txtCitizenship.Text = dr["Citizenship"].ToString();
                    pi2.txtEmail.Text = dr["Eadd"].ToString();
                    pi2.txtEmpID.Text = dr["EmpID"].ToString();
                    pi2.txtFirstname.Text = dr["Firstname"].ToString();
                    pi2.txtGSIS.Text = dr["GSIS"].ToString();
                    pi2.txtHeight.Text = dr["Height"].ToString();
                    pi2.txtMiddlename.Text = dr["Middlename"].ToString();
                    pi2.txtNE.Text = dr["Ne"].ToString();
                    pi2.txtPagIBIG.Text = dr["PAGIBIG"].ToString();
                    pi2.txtPerAdd.Text = dr["PerAdd"].ToString();
                    pi2.txtPerTel.Text = dr["Pertel"].ToString();
                    pi2.txtPerZC.Text = dr["PerZC"].ToString();
                    pi2.txtPhilHealth.Text = dr["PHILHEALTH"].ToString();
                    pi2.txtPlaceofBirth.Text = dr["Pbirth"].ToString();
                    pi2.txtResAdd.Text = dr["ResAdd"].ToString();
                    pi2.txtResTel.Text = dr["Restel"].ToString();
                    pi2.txtResZC.Text = dr["ResZC"].ToString();
                    pi2.txtSSS.Text = dr["SSS"].ToString();
                    pi2.txtSurname.Text = dr["Surname"].ToString();
                    pi2.txtTin.Text = dr["Tin"].ToString();
                    pi2.txtWeight.Text = dr["Weight"].ToString();
                    pi2.dtpDate.Text = dr["Dbirth"].ToString();
                    pi2.cboBloodtype.Text = dr["Bloodtype"].ToString();
                    pi2.cboCivilStat.Text = dr["Civilstatus"].ToString();
                    //pi2
                    if (dr["Sex"].ToString() == "Male")
                    {
                        pi2.rbMale.Checked = true;
                    }
                    if (dr["Sex"].ToString() == "Female")
                    {
                        pi2.rbFemale.Checked = true;
                    }

                    try
                    {
                        byte[] image1 = (byte[])dr["Picture"];
                        MemoryStream ms1 = new MemoryStream(image1);
                        pi2.pbxImage.Image = Image.FromStream(ms1);
                        pi2.BlobValue = image1;
                    }
                    catch
                    {
                    }
                    pi2.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFB_Click(object sender, EventArgs e)
        {
            frmFB fb = new frmFB();
            fb.EmpID = txtEmpID.Text;
            fb.ShowDialog();
        }

        private void btnEB_Click(object sender, EventArgs e)
        {
            frmEB eb = new frmEB();
            eb.EmpID = txtEmpID.Text;
            eb.ShowDialog();
        }

        private void btnCSE_Click(object sender, EventArgs e)
        {
            frmCSE cse = new frmCSE();
            cse.EmpID = txtEmpID.Text;
            cse.ShowDialog();
        }

        private void btnWE_Click(object sender, EventArgs e)
        {
            frmWE we = new frmWE();
            we.EmpID = txtEmpID.Text;
            we.ShowDialog();
        }

        private void btnVW_Click(object sender, EventArgs e)
        {
            frmVW vw = new frmVW();
            vw.EmpID = txtEmpID.Text;
            vw.ShowDialog();
        }

        private void btnTP_Click(object sender, EventArgs e)
        {
            frmTP tp = new frmTP();
            tp.EmpID = txtEmpID.Text;
            tp.ShowDialog();
        }

        private void btnOI_Click(object sender, EventArgs e)
        {
            frmOI oi = new frmOI();
            oi.EmpID = txtEmpID.Text;
            oi.ShowDialog();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            frmRef R = new frmRef();
            R.EmpID = txtEmpID.Text;
            R.ShowDialog();
        }

        private void btnOIC_Click(object sender, EventArgs e)
        {
            frmOIC oic = new frmOIC();
            oic.EmpID = txtEmpID.Text;
            oic.ShowDialog();
        }
    }
}
