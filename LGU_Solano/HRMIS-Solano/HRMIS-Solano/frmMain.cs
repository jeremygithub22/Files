using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HRMIS_Solano
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        frmUserLogs ul = new frmUserLogs();
        private void tTimeToday_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tTimeToday.Enabled = true;   
        }

        private void pbxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
            ul.Record(UserDetails.UID, "Successfully Log out", DateTime.Now);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ul.Record(UserDetails.UID, "Exit application", DateTime.Now);
            Application.Exit();
        }

        private void personalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Personal Information Module", DateTime.Now);
            frmPI pi = new frmPI();
            pi.ShowDialog();
        }

        private void userAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed User Accounts Module", DateTime.Now);
            frmUserAcct ua = new frmUserAcct();
            ua.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Change Password Module", DateTime.Now);
            frmChangePass cp = new frmChangePass();
            cp.ShowDialog();
        }

        private void userLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed User Logs Module", DateTime.Now);
            frmUserLogs ulog = new frmUserLogs();
            ulog.ShowDialog();
        }

        private void maintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Maintenance Module", DateTime.Now);
            frmBR br = new frmBR();
            br.ShowDialog();
        }

        private void locatorSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Locator Slip Module", DateTime.Now);
            frmLS ls = new frmLS();
            ls.ShowDialog();
        }

        private void personalDataSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Under Construction, this module will be available later.", "HRMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //ul.Record(UserDetails.UID, "Accessed Personal Data Sheet Module", DateTime.Now);
            frmPDSmainreport pds = new frmPDSmainreport();
            pds.ShowDialog();
        }

        private void locatorSlipReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed New Locator Slip Report", DateTime.Now);
            frmLSreport lsr = new frmLSreport();
            lsr.ShowDialog();
        }

        private void tardinessUndertimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Tardiness/Undertime", DateTime.Now);
            frmTU tu = new frmTU();
            tu.ShowDialog();
        }

        private void tardinessUndertimeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Tardiness/Undertime report", DateTime.Now);
            frmTUReport tur = new frmTUReport();
            tur.ShowDialog();
        }

        private void leaveCreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Leave Credits", DateTime.Now);
            frmLC lc = new frmLC();
            lc.ShowDialog();
        }

        private void leaveRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Leave Record", DateTime.Now);
            frmLR lr = new frmLR();
            lr.ShowDialog();
        }

        private void serviceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Service Record", DateTime.Now);
            frmSR sr = new frmSR();
            sr.ShowDialog();
        }

        private void applicationForLeaveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Application for Leave report", DateTime.Now);
            frmALReport al = new frmALReport();
            al.ShowDialog();
        }

        private void leaveCreditsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Leave Credits Report", DateTime.Now);
            frmLCReport lcre = new frmLCReport();
            lcre.ShowDialog();
        }

        private void certificationForLeaveCreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Certification for Leave Credits Report", DateTime.Now);
            frmCLC clc = new frmCLC();
            clc.ShowDialog();
        }

        private void serviceRecordReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Service Record Report", DateTime.Now);
            frmSRrep srrep = new frmSRrep();
            srrep.ShowDialog();
        }

        private void withoutLocatorSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Without Locator Slip", DateTime.Now);
            frmWLS wls = new frmWLS();
            wls.ShowDialog();
        }

        private void withoutLocatorSlipReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Without Locator Slip Report", DateTime.Now);
            frmLWLSrep lwls = new frmLWLSrep();
            lwls.ShowDialog();
        }

        private void flagCeremonyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Flag Ceremony Record", DateTime.Now);
            frmFC fc = new frmFC();
            fc.ShowDialog();
        }

        private void flagRetreatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Flag Retreat Record", DateTime.Now);
            frmFR fr = new frmFR();
            fr.ShowDialog();
        }

        private void attendanceForFlagRetreatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Attendance for Flag Retreat", DateTime.Now);
            frmFRreport frr = new frmFRreport();
            frr.ShowDialog();
        }

        private void attendanceForFlagCeremonyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Attendance for Flag Ceremony", DateTime.Now);
            frmFCreport fcr = new frmFCreport();
            fcr.ShowDialog();
        }

        private void listOfSummaryLeaveCreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed List of Summary Leave Credits", DateTime.Now);
            frmSummaryLCrep slc = new frmSummaryLCrep();
            slc.ShowDialog();
        }

        private void otherInformationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Other Information Settings", DateTime.Now);
            frmOIAdmin oia = new frmOIAdmin();
            oia.ShowDialog();
        }

        private void conditionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Condition Settings", DateTime.Now);
            frmCondition con = new frmCondition();
            con.ShowDialog();
        }

        private void masterlistOfEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Masterlist of Employees", DateTime.Now);
            frmMasterlistR mlr = new frmMasterlistR();
            mlr.ShowDialog();
        }

        private void personalLocatorSlipMinutesUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Personal Locator - Minutes Used", DateTime.Now);
            frmMinUsed mu = new frmMinUsed();
            mu.ShowDialog();
        }

        private void summaryOfApplicationForLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Summary of Application for Leave", DateTime.Now);
            frmSummaryAL sumal = new frmSummaryAL();
            sumal.ShowDialog();
        }

        private void personalLocatorSlipReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Personal Locator Slip Report", DateTime.Now);
            frmPersonalLocatorSlip pls = new frmPersonalLocatorSlip();
            pls.ShowDialog();
        }

        private void birthdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ul.Record(UserDetails.UID, "Accessed Birthday Report", DateTime.Now);
            frmBirthdayReport br = new frmBirthdayReport();
            br.ShowDialog();
        }
    }
}
