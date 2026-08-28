namespace HRMIS_Solano
{
    partial class frmPage1
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
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsReports = new HRMIS_Solano.dsReports();
            this.tblchildBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblpiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblebBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblfbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblchildBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblebBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblfbBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvDisplay
            // 
            this.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsReports_tblchild";
            reportDataSource1.Value = this.tblchildBindingSource;
            reportDataSource2.Name = "dsReports_tblpi";
            reportDataSource2.Value = this.tblpiBindingSource;
            reportDataSource3.Name = "dsReports_tbleb";
            reportDataSource3.Value = this.tblebBindingSource;
            reportDataSource4.Name = "dsReports_tblfb";
            reportDataSource4.Value = this.tblfbBindingSource;
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource2);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource3);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource4);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "HRMIS_Solano.Page1.rdlc";
            this.rvDisplay.Location = new System.Drawing.Point(0, 0);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.Size = new System.Drawing.Size(331, 302);
            this.rvDisplay.TabIndex = 0;
            // 
            // dsReports
            // 
            this.dsReports.DataSetName = "dsReports";
            this.dsReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblchildBindingSource
            // 
            this.tblchildBindingSource.DataMember = "tblchild";
            this.tblchildBindingSource.DataSource = this.dsReports;
            // 
            // tblpiBindingSource
            // 
            this.tblpiBindingSource.DataMember = "tblpi";
            this.tblpiBindingSource.DataSource = this.dsReports;
            // 
            // tblebBindingSource
            // 
            this.tblebBindingSource.DataMember = "tbleb";
            this.tblebBindingSource.DataSource = this.dsReports;
            // 
            // tblfbBindingSource
            // 
            this.tblfbBindingSource.DataMember = "tblfb";
            this.tblfbBindingSource.DataSource = this.dsReports;
            // 
            // frmPage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(331, 302);
            this.Controls.Add(this.rvDisplay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPage1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Page1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPage1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblchildBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblebBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblfbBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
        private System.Windows.Forms.BindingSource tblchildBindingSource;
        private dsReports dsReports;
        private System.Windows.Forms.BindingSource tblpiBindingSource;
        private System.Windows.Forms.BindingSource tblebBindingSource;
        private System.Windows.Forms.BindingSource tblfbBindingSource;
    }
}