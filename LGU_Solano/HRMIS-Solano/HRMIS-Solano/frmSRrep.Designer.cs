namespace HRMIS_Solano
{
    partial class frmSRrep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSRrep));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tblpiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsReports = new HRMIS_Solano.dsReports();
            this.tblsrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblsrnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lstEmployee = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearchby = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblsrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblsrnoBindingSource)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblpiBindingSource
            // 
            this.tblpiBindingSource.DataMember = "tblpi";
            this.tblpiBindingSource.DataSource = this.dsReports;
            // 
            // dsReports
            // 
            this.dsReports.DataSetName = "dsReports";
            this.dsReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblsrBindingSource
            // 
            this.tblsrBindingSource.DataMember = "tblsr";
            this.tblsrBindingSource.DataSource = this.dsReports;
            // 
            // tblsrnoBindingSource
            // 
            this.tblsrnoBindingSource.DataMember = "tblsrno";
            this.tblsrnoBindingSource.DataSource = this.dsReports;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lstEmployee);
            this.pnlTop.Controls.Add(this.groupBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(749, 197);
            this.pnlTop.TabIndex = 0;
            // 
            // lstEmployee
            // 
            this.lstEmployee.FormattingEnabled = true;
            this.lstEmployee.ItemHeight = 15;
            this.lstEmployee.Location = new System.Drawing.Point(12, 80);
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(221, 109);
            this.lstEmployee.TabIndex = 2;
            this.lstEmployee.SelectedValueChanged += new System.EventHandler(this.lstEmployee_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.cboSearchby);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(448, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 39);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(541, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 39);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Other Information";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(220, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(222, 21);
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
            "All"});
            this.cboSearchby.Location = new System.Drawing.Point(73, 24);
            this.cboSearchby.Name = "cboSearchby";
            this.cboSearchby.Size = new System.Drawing.Size(141, 23);
            this.cboSearchby.TabIndex = 1;
            this.cboSearchby.SelectedIndexChanged += new System.EventHandler(this.cboSearchby_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search by";
            // 
            // rvDisplay
            // 
            this.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsReports_tblpi";
            reportDataSource1.Value = this.tblpiBindingSource;
            reportDataSource2.Name = "dsReports_tblsr";
            reportDataSource2.Value = this.tblsrBindingSource;
            reportDataSource3.Name = "dsReports_tblsrno";
            reportDataSource3.Value = this.tblsrnoBindingSource;
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource2);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource3);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "HRMIS_Solano.SRrep.rdlc";
            this.rvDisplay.Location = new System.Drawing.Point(0, 197);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.Size = new System.Drawing.Size(749, 213);
            this.rvDisplay.TabIndex = 1;
            // 
            // frmSRrep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(749, 410);
            this.Controls.Add(this.rvDisplay);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSRrep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Record Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tblpiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblsrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblsrnoBindingSource)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSearchby;
        private System.Windows.Forms.ListBox lstEmployee;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.BindingSource tblpiBindingSource;
        private dsReports dsReports;
        private System.Windows.Forms.BindingSource tblsrBindingSource;
        private System.Windows.Forms.BindingSource tblsrnoBindingSource;
    }
}