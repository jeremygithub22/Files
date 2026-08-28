namespace HRMIS_Solano
{
    partial class frmPVAL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPVAL));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tblleavecreditsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsReports = new HRMIS_Solano.dsReports();
            this.tblpiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblweBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblleaverecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.tblleavecreditsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblweBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblleaverecordBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblleavecreditsBindingSource
            // 
            this.tblleavecreditsBindingSource.DataMember = "tblleavecredits";
            this.tblleavecreditsBindingSource.DataSource = this.dsReports;
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
            // tblweBindingSource
            // 
            this.tblweBindingSource.DataMember = "tblwe";
            this.tblweBindingSource.DataSource = this.dsReports;
            // 
            // tblleaverecordBindingSource
            // 
            this.tblleaverecordBindingSource.DataMember = "tblleaverecord";
            this.tblleaverecordBindingSource.DataSource = this.dsReports;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 62);
            this.panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 39);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Other Information";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rvDisplay
            // 
            this.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsReports_tblleavecredits";
            reportDataSource1.Value = this.tblleavecreditsBindingSource;
            reportDataSource2.Name = "dsReports_tblpi";
            reportDataSource2.Value = this.tblpiBindingSource;
            reportDataSource3.Name = "dsReports_tblwe";
            reportDataSource3.Value = this.tblweBindingSource;
            reportDataSource4.Name = "dsReports_tblleaverecord";
            reportDataSource4.Value = this.tblleaverecordBindingSource;
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource2);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource3);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource4);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "HRMIS_Solano.ApplicationLeaveRep.rdlc";
            this.rvDisplay.Location = new System.Drawing.Point(0, 62);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.Size = new System.Drawing.Size(331, 240);
            this.rvDisplay.TabIndex = 1;
            // 
            // frmPVAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(331, 302);
            this.Controls.Add(this.rvDisplay);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPVAL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application for Leave Repport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPVAL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblleavecreditsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblweBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblleaverecordBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
        private System.Windows.Forms.BindingSource tblleavecreditsBindingSource;
        private dsReports dsReports;
        private System.Windows.Forms.BindingSource tblpiBindingSource;
        private System.Windows.Forms.BindingSource tblweBindingSource;
        private System.Windows.Forms.BindingSource tblleaverecordBindingSource;
        private System.Windows.Forms.Button btnAdd;

    }
}