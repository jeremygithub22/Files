namespace HRMIS_Solano
{
    partial class frmALReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmALReport));
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
            this.lstDates = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstEmployee = new System.Windows.Forms.ListBox();
            this.gbSearchbar = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearchby = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.tblleavecreditsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblweBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblleaverecordBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbSearchbar.SuspendLayout();
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
            this.panel1.Controls.Add(this.lstDates);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lstEmployee);
            this.panel1.Controls.Add(this.gbSearchbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 209);
            this.panel1.TabIndex = 0;
            // 
            // lstDates
            // 
            this.lstDates.FormattingEnabled = true;
            this.lstDates.ItemHeight = 15;
            this.lstDates.Location = new System.Drawing.Point(368, 94);
            this.lstDates.Name = "lstDates";
            this.lstDates.Size = new System.Drawing.Size(139, 109);
            this.lstDates.TabIndex = 7;
            this.lstDates.SelectedValueChanged += new System.EventHandler(this.lstDates_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date of Filled";
            // 
            // lstEmployee
            // 
            this.lstEmployee.FormattingEnabled = true;
            this.lstEmployee.ItemHeight = 15;
            this.lstEmployee.Location = new System.Drawing.Point(12, 94);
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(220, 109);
            this.lstEmployee.TabIndex = 5;
            this.lstEmployee.SelectedValueChanged += new System.EventHandler(this.lstEmployee_SelectedValueChanged);
            // 
            // gbSearchbar
            // 
            this.gbSearchbar.Controls.Add(this.btnAdd);
            this.gbSearchbar.Controls.Add(this.btnSearch);
            this.gbSearchbar.Controls.Add(this.txtSearch);
            this.gbSearchbar.Controls.Add(this.cboSearchby);
            this.gbSearchbar.Controls.Add(this.label2);
            this.gbSearchbar.Location = new System.Drawing.Point(12, 12);
            this.gbSearchbar.Name = "gbSearchbar";
            this.gbSearchbar.Size = new System.Drawing.Size(690, 60);
            this.gbSearchbar.TabIndex = 4;
            this.gbSearchbar.TabStop = false;
            this.gbSearchbar.Text = "Search";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(581, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 39);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Other Information";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(488, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 39);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(249, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(233, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cboSearchby
            // 
            this.cboSearchby.FormattingEnabled = true;
            this.cboSearchby.Items.AddRange(new object[] {
            "Employee ID",
            "Surname",
            "Firstname",
            "Middlename",
            "Department",
            "All",
            "Record No."});
            this.cboSearchby.Location = new System.Drawing.Point(73, 23);
            this.cboSearchby.Name = "cboSearchby";
            this.cboSearchby.Size = new System.Drawing.Size(170, 23);
            this.cboSearchby.TabIndex = 1;
            this.cboSearchby.SelectedIndexChanged += new System.EventHandler(this.cboSearchby_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search by";
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
            this.rvDisplay.Location = new System.Drawing.Point(0, 209);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.Size = new System.Drawing.Size(806, 326);
            this.rvDisplay.TabIndex = 1;
            // 
            // frmALReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(806, 535);
            this.Controls.Add(this.rvDisplay);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmALReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application for Leave Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tblleavecreditsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblweBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblleaverecordBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbSearchbar.ResumeLayout(false);
            this.gbSearchbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstDates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstEmployee;
        private System.Windows.Forms.GroupBox gbSearchbar;
        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSearchby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource tblleavecreditsBindingSource;
        private dsReports dsReports;
        private System.Windows.Forms.BindingSource tblpiBindingSource;
        private System.Windows.Forms.BindingSource tblweBindingSource;
        private System.Windows.Forms.BindingSource tblleaverecordBindingSource;
        private System.Windows.Forms.Button btnAdd;

    }
}