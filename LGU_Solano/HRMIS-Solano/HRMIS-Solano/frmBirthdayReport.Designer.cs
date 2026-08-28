namespace HRMIS_Solano
{
    partial class frmBirthdayReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBirthdayReport));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tblBirthdayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsReports = new HRMIS_Solano.dsReports();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.gbSearchbar = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cboSearchby = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.tblBirthdayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.gbSearchbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblBirthdayBindingSource
            // 
            this.tblBirthdayBindingSource.DataMember = "tblBirthday";
            this.tblBirthdayBindingSource.DataSource = this.dsReports;
            // 
            // dsReports
            // 
            this.dsReports.DataSetName = "dsReports";
            this.dsReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.gbSearchbar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1008, 98);
            this.pnlTop.TabIndex = 0;
            // 
            // gbSearchbar
            // 
            this.gbSearchbar.Controls.Add(this.btnAdd);
            this.gbSearchbar.Controls.Add(this.btnSearch);
            this.gbSearchbar.Controls.Add(this.dtpDate);
            this.gbSearchbar.Controls.Add(this.cboSearchby);
            this.gbSearchbar.Controls.Add(this.label1);
            this.gbSearchbar.Location = new System.Drawing.Point(12, 12);
            this.gbSearchbar.Name = "gbSearchbar";
            this.gbSearchbar.Size = new System.Drawing.Size(608, 65);
            this.gbSearchbar.TabIndex = 0;
            this.gbSearchbar.TabStop = false;
            this.gbSearchbar.Text = "Search";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(500, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 39);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add Other Information";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(407, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 39);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(200, 27);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 21);
            this.dtpDate.TabIndex = 2;
            // 
            // cboSearchby
            // 
            this.cboSearchby.FormattingEnabled = true;
            this.cboSearchby.Items.AddRange(new object[] {
            "Date",
            "Month"});
            this.cboSearchby.Location = new System.Drawing.Point(73, 26);
            this.cboSearchby.Name = "cboSearchby";
            this.cboSearchby.Size = new System.Drawing.Size(121, 23);
            this.cboSearchby.TabIndex = 1;
            this.cboSearchby.SelectedIndexChanged += new System.EventHandler(this.cboSearchby_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search by";
            // 
            // rvDisplay
            // 
            this.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dsReports_tblBirthday";
            reportDataSource2.Value = this.tblBirthdayBindingSource;
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource2);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "HRMIS_Solano.BirthdayReport.rdlc";
            this.rvDisplay.Location = new System.Drawing.Point(0, 98);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.Size = new System.Drawing.Size(1008, 632);
            this.rvDisplay.TabIndex = 1;
            // 
            // frmBirthdayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.rvDisplay);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBirthdayReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Birthday Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tblBirthdayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.gbSearchbar.ResumeLayout(false);
            this.gbSearchbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
        private System.Windows.Forms.GroupBox gbSearchbar;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cboSearchby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource tblBirthdayBindingSource;
        private dsReports dsReports;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
    }
}