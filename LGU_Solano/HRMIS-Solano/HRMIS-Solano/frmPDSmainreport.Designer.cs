namespace HRMIS_Solano
{
    partial class frmPDSmainreport
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
            this.gbSearchbar = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSearchby = new System.Windows.Forms.ComboBox();
            this.gbSeparateSheet = new System.Windows.Forms.GroupBox();
            this.btnOI = new System.Windows.Forms.Button();
            this.btnTP = new System.Windows.Forms.Button();
            this.btnVW = new System.Windows.Forms.Button();
            this.btnWE = new System.Windows.Forms.Button();
            this.btnCSE = new System.Windows.Forms.Button();
            this.btnEB = new System.Windows.Forms.Button();
            this.btnCI = new System.Windows.Forms.Button();
            this.btnSI = new System.Windows.Forms.Button();
            this.lstEmployee = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnpage4 = new System.Windows.Forms.Button();
            this.btnpage3 = new System.Windows.Forms.Button();
            this.btnpage2 = new System.Windows.Forms.Button();
            this.btnpage1 = new System.Windows.Forms.Button();
            this.gbSearchbar.SuspendLayout();
            this.gbSeparateSheet.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearchbar
            // 
            this.gbSearchbar.Controls.Add(this.btnSearch);
            this.gbSearchbar.Controls.Add(this.txtSearch);
            this.gbSearchbar.Controls.Add(this.label1);
            this.gbSearchbar.Controls.Add(this.cboSearchby);
            this.gbSearchbar.Location = new System.Drawing.Point(14, 14);
            this.gbSearchbar.Name = "gbSearchbar";
            this.gbSearchbar.Size = new System.Drawing.Size(695, 73);
            this.gbSearchbar.TabIndex = 0;
            this.gbSearchbar.TabStop = false;
            this.gbSearchbar.Text = "Search bar";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(597, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(256, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(333, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search by";
            // 
            // cboSearchby
            // 
            this.cboSearchby.FormattingEnabled = true;
            this.cboSearchby.Items.AddRange(new object[] {
            "Employee ID",
            "Surname",
            "Firstname",
            "Middlename",
            "All"});
            this.cboSearchby.Location = new System.Drawing.Point(78, 31);
            this.cboSearchby.Name = "cboSearchby";
            this.cboSearchby.Size = new System.Drawing.Size(172, 23);
            this.cboSearchby.TabIndex = 0;
            this.cboSearchby.SelectedIndexChanged += new System.EventHandler(this.cboSearchby_SelectedIndexChanged);
            // 
            // gbSeparateSheet
            // 
            this.gbSeparateSheet.Controls.Add(this.btnOI);
            this.gbSeparateSheet.Controls.Add(this.btnTP);
            this.gbSeparateSheet.Controls.Add(this.btnVW);
            this.gbSeparateSheet.Controls.Add(this.btnWE);
            this.gbSeparateSheet.Controls.Add(this.btnCSE);
            this.gbSeparateSheet.Controls.Add(this.btnEB);
            this.gbSeparateSheet.Controls.Add(this.btnCI);
            this.gbSeparateSheet.Controls.Add(this.btnSI);
            this.gbSeparateSheet.Location = new System.Drawing.Point(513, 93);
            this.gbSeparateSheet.Name = "gbSeparateSheet";
            this.gbSeparateSheet.Size = new System.Drawing.Size(196, 263);
            this.gbSeparateSheet.TabIndex = 3;
            this.gbSeparateSheet.TabStop = false;
            this.gbSeparateSheet.Text = "Separate Sheet";
            // 
            // btnOI
            // 
            this.btnOI.Location = new System.Drawing.Point(18, 223);
            this.btnOI.Name = "btnOI";
            this.btnOI.Size = new System.Drawing.Size(157, 23);
            this.btnOI.TabIndex = 7;
            this.btnOI.Text = "Other Information";
            this.btnOI.UseVisualStyleBackColor = true;
            // 
            // btnTP
            // 
            this.btnTP.Location = new System.Drawing.Point(18, 194);
            this.btnTP.Name = "btnTP";
            this.btnTP.Size = new System.Drawing.Size(157, 23);
            this.btnTP.TabIndex = 6;
            this.btnTP.Text = "Training Programs";
            this.btnTP.UseVisualStyleBackColor = true;
            // 
            // btnVW
            // 
            this.btnVW.Location = new System.Drawing.Point(18, 165);
            this.btnVW.Name = "btnVW";
            this.btnVW.Size = new System.Drawing.Size(157, 23);
            this.btnVW.TabIndex = 5;
            this.btnVW.Text = "Voluntary Work";
            this.btnVW.UseVisualStyleBackColor = true;
            // 
            // btnWE
            // 
            this.btnWE.Location = new System.Drawing.Point(18, 136);
            this.btnWE.Name = "btnWE";
            this.btnWE.Size = new System.Drawing.Size(157, 23);
            this.btnWE.TabIndex = 4;
            this.btnWE.Text = "Work Experience";
            this.btnWE.UseVisualStyleBackColor = true;
            // 
            // btnCSE
            // 
            this.btnCSE.Location = new System.Drawing.Point(18, 107);
            this.btnCSE.Name = "btnCSE";
            this.btnCSE.Size = new System.Drawing.Size(157, 23);
            this.btnCSE.TabIndex = 3;
            this.btnCSE.Text = "Civil Service Eligibility";
            this.btnCSE.UseVisualStyleBackColor = true;
            // 
            // btnEB
            // 
            this.btnEB.Location = new System.Drawing.Point(18, 78);
            this.btnEB.Name = "btnEB";
            this.btnEB.Size = new System.Drawing.Size(157, 23);
            this.btnEB.TabIndex = 2;
            this.btnEB.Text = "Educational Background";
            this.btnEB.UseVisualStyleBackColor = true;
            // 
            // btnCI
            // 
            this.btnCI.Location = new System.Drawing.Point(18, 49);
            this.btnCI.Name = "btnCI";
            this.btnCI.Size = new System.Drawing.Size(157, 23);
            this.btnCI.TabIndex = 1;
            this.btnCI.Text = "Child Information";
            this.btnCI.UseVisualStyleBackColor = true;
            // 
            // btnSI
            // 
            this.btnSI.Location = new System.Drawing.Point(18, 20);
            this.btnSI.Name = "btnSI";
            this.btnSI.Size = new System.Drawing.Size(157, 23);
            this.btnSI.TabIndex = 0;
            this.btnSI.Text = "Spouse Information";
            this.btnSI.UseVisualStyleBackColor = true;
            // 
            // lstEmployee
            // 
            this.lstEmployee.FormattingEnabled = true;
            this.lstEmployee.ItemHeight = 15;
            this.lstEmployee.Location = new System.Drawing.Point(14, 93);
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(250, 394);
            this.lstEmployee.TabIndex = 5;
            this.lstEmployee.DoubleClick += new System.EventHandler(this.lstEmployee_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnpage4);
            this.groupBox1.Controls.Add(this.btnpage3);
            this.groupBox1.Controls.Add(this.btnpage2);
            this.groupBox1.Controls.Add(this.btnpage1);
            this.groupBox1.Location = new System.Drawing.Point(311, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 143);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pages";
            // 
            // btnpage4
            // 
            this.btnpage4.Location = new System.Drawing.Point(18, 107);
            this.btnpage4.Name = "btnpage4";
            this.btnpage4.Size = new System.Drawing.Size(157, 23);
            this.btnpage4.TabIndex = 3;
            this.btnpage4.Text = "Page 4";
            this.btnpage4.UseVisualStyleBackColor = true;
            // 
            // btnpage3
            // 
            this.btnpage3.Location = new System.Drawing.Point(18, 78);
            this.btnpage3.Name = "btnpage3";
            this.btnpage3.Size = new System.Drawing.Size(157, 23);
            this.btnpage3.TabIndex = 2;
            this.btnpage3.Text = "Page 3";
            this.btnpage3.UseVisualStyleBackColor = true;
            // 
            // btnpage2
            // 
            this.btnpage2.Location = new System.Drawing.Point(18, 49);
            this.btnpage2.Name = "btnpage2";
            this.btnpage2.Size = new System.Drawing.Size(157, 23);
            this.btnpage2.TabIndex = 1;
            this.btnpage2.Text = "Page 2";
            this.btnpage2.UseVisualStyleBackColor = true;
            this.btnpage2.Click += new System.EventHandler(this.btnpage2_Click);
            // 
            // btnpage1
            // 
            this.btnpage1.Location = new System.Drawing.Point(18, 20);
            this.btnpage1.Name = "btnpage1";
            this.btnpage1.Size = new System.Drawing.Size(157, 23);
            this.btnpage1.TabIndex = 0;
            this.btnpage1.Text = "Page 1";
            this.btnpage1.UseVisualStyleBackColor = true;
            this.btnpage1.Click += new System.EventHandler(this.btnpage1_Click);
            // 
            // frmPDSmainreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 522);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstEmployee);
            this.Controls.Add(this.gbSearchbar);
            this.Controls.Add(this.gbSeparateSheet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPDSmainreport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal Data Sheet";
            this.gbSearchbar.ResumeLayout(false);
            this.gbSearchbar.PerformLayout();
            this.gbSeparateSheet.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchbar;
        private System.Windows.Forms.ComboBox cboSearchby;
        private System.Windows.Forms.GroupBox gbSeparateSheet;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCSE;
        private System.Windows.Forms.Button btnEB;
        private System.Windows.Forms.Button btnCI;
        private System.Windows.Forms.Button btnSI;
        private System.Windows.Forms.ListBox lstEmployee;
        private System.Windows.Forms.Button btnOI;
        private System.Windows.Forms.Button btnTP;
        private System.Windows.Forms.Button btnVW;
        private System.Windows.Forms.Button btnWE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnpage4;
        private System.Windows.Forms.Button btnpage3;
        private System.Windows.Forms.Button btnpage2;
        private System.Windows.Forms.Button btnpage1;

    }
}