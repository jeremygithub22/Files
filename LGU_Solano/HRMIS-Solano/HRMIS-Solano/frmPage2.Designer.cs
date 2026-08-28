namespace HRMIS_Solano
{
    partial class frmPage2
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
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsReports = new HRMIS_Solano.dsReports();
            this.tblweBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblcseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblweBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvDisplay
            // 
            this.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsReports_tblwe";
            reportDataSource1.Value = this.tblweBindingSource;
            reportDataSource2.Name = "dsReports_tblcse";
            reportDataSource2.Value = this.tblcseBindingSource;
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource2);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "HRMIS_Solano.Page2.rdlc";
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
            // tblweBindingSource
            // 
            this.tblweBindingSource.DataMember = "tblwe";
            this.tblweBindingSource.DataSource = this.dsReports;
            // 
            // tblcseBindingSource
            // 
            this.tblcseBindingSource.DataMember = "tblcse";
            this.tblcseBindingSource.DataSource = this.dsReports;
            // 
            // frmPage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(331, 302);
            this.Controls.Add(this.rvDisplay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPage2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Page2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPage2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblweBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
        private System.Windows.Forms.BindingSource tblweBindingSource;
        private dsReports dsReports;
        private System.Windows.Forms.BindingSource tblcseBindingSource;
    }
}