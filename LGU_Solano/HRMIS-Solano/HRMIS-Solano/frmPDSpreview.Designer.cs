namespace HRMIS_Solano
{
    partial class frmPDSpreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource11 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsReports = new HRMIS_Solano.dsReports();
            this.tblpiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblchildBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblfbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblebBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblcseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblweBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblvwBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbltpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbloiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbloicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblrefBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblchildBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblfbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblebBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblweBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblvwBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloicBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblrefBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvDisplay
            // 
            this.rvDisplay.AutoScroll = true;
            this.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsReports_tblpi";
            reportDataSource1.Value = this.tblpiBindingSource;
            reportDataSource2.Name = "dsReports_tblchild";
            reportDataSource2.Value = this.tblchildBindingSource;
            reportDataSource3.Name = "dsReports_tblfb";
            reportDataSource3.Value = this.tblfbBindingSource;
            reportDataSource4.Name = "dsReports_tbleb";
            reportDataSource4.Value = this.tblebBindingSource;
            reportDataSource5.Name = "dsReports_tblcse";
            reportDataSource5.Value = this.tblcseBindingSource;
            reportDataSource6.Name = "dsReports_tblwe";
            reportDataSource6.Value = this.tblweBindingSource;
            reportDataSource7.Name = "dsReports_tblvw";
            reportDataSource7.Value = this.tblvwBindingSource;
            reportDataSource8.Name = "dsReports_tbltp";
            reportDataSource8.Value = this.tbltpBindingSource;
            reportDataSource9.Name = "dsReports_tbloi";
            reportDataSource9.Value = this.tbloiBindingSource;
            reportDataSource10.Name = "dsReports_tbloic";
            reportDataSource10.Value = this.tbloicBindingSource;
            reportDataSource11.Name = "dsReports_tblref";
            reportDataSource11.Value = this.tblrefBindingSource;
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource2);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource3);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource4);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource5);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource6);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource7);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource8);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource9);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource10);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource11);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "HRMIS_Solano.PDSfull.rdlc";
            this.rvDisplay.Location = new System.Drawing.Point(0, 0);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.Size = new System.Drawing.Size(663, 409);
            this.rvDisplay.TabIndex = 0;
            // 
            // dsReports
            // 
            this.dsReports.DataSetName = "dsReports";
            this.dsReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblpiBindingSource
            // 
            this.tblpiBindingSource.DataMember = "tblpi";
            this.tblpiBindingSource.DataSource = this.dsReports;
            // 
            // tblchildBindingSource
            // 
            this.tblchildBindingSource.DataMember = "tblchild";
            this.tblchildBindingSource.DataSource = this.dsReports;
            // 
            // tblfbBindingSource
            // 
            this.tblfbBindingSource.DataMember = "tblfb";
            this.tblfbBindingSource.DataSource = this.dsReports;
            // 
            // tblebBindingSource
            // 
            this.tblebBindingSource.DataMember = "tbleb";
            this.tblebBindingSource.DataSource = this.dsReports;
            // 
            // tblcseBindingSource
            // 
            this.tblcseBindingSource.DataMember = "tblcse";
            this.tblcseBindingSource.DataSource = this.dsReports;
            // 
            // tblweBindingSource
            // 
            this.tblweBindingSource.DataMember = "tblwe";
            this.tblweBindingSource.DataSource = this.dsReports;
            // 
            // tblvwBindingSource
            // 
            this.tblvwBindingSource.DataMember = "tblvw";
            this.tblvwBindingSource.DataSource = this.dsReports;
            // 
            // tbltpBindingSource
            // 
            this.tbltpBindingSource.DataMember = "tbltp";
            this.tbltpBindingSource.DataSource = this.dsReports;
            // 
            // tbloiBindingSource
            // 
            this.tbloiBindingSource.DataMember = "tbloi";
            this.tbloiBindingSource.DataSource = this.dsReports;
            // 
            // tbloicBindingSource
            // 
            this.tbloicBindingSource.DataMember = "tbloic";
            this.tbloicBindingSource.DataSource = this.dsReports;
            // 
            // tblrefBindingSource
            // 
            this.tblrefBindingSource.DataMember = "tblref";
            this.tblrefBindingSource.DataSource = this.dsReports;
            // 
            // frmPDSpreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(663, 409);
            this.Controls.Add(this.rvDisplay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPDSpreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal Data Sheet preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPDSpreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblchildBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblfbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblebBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblweBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblvwBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloicBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblrefBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
        private System.Windows.Forms.BindingSource tblpiBindingSource;
        private dsReports dsReports;
        private System.Windows.Forms.BindingSource tblchildBindingSource;
        private System.Windows.Forms.BindingSource tblfbBindingSource;
        private System.Windows.Forms.BindingSource tblebBindingSource;
        private System.Windows.Forms.BindingSource tblcseBindingSource;
        private System.Windows.Forms.BindingSource tblweBindingSource;
        private System.Windows.Forms.BindingSource tblvwBindingSource;
        private System.Windows.Forms.BindingSource tbltpBindingSource;
        private System.Windows.Forms.BindingSource tbloiBindingSource;
        private System.Windows.Forms.BindingSource tbloicBindingSource;
        private System.Windows.Forms.BindingSource tblrefBindingSource;
    }
}