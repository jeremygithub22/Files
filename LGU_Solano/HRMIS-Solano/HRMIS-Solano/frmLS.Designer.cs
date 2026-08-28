namespace HRMIS_Solano
{
    partial class frmLS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLS));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearchby = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnArrival = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbApprovedas = new System.Windows.Forms.GroupBox();
            this.cbOfficial = new System.Windows.Forms.CheckBox();
            this.cbPersonal = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLocNo = new System.Windows.Forms.TextBox();
            this.dtpDtime = new System.Windows.Forms.DateTimePicker();
            this.dtpDdate = new System.Windows.Forms.DateTimePicker();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtReasons = new System.Windows.Forms.TextBox();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.txtMinUsed = new System.Windows.Forms.TextBox();
            this.txtEquivalent = new System.Windows.Forms.TextBox();
            this.lstEmployee = new System.Windows.Forms.ListBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpActualTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.gbApprovedas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.cboSearchby);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(494, 13);
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
            this.txtSearch.Location = new System.Drawing.Point(256, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(232, 21);
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
            "Locator No."});
            this.cboSearchby.Location = new System.Drawing.Point(73, 23);
            this.cboSearchby.Name = "cboSearchby";
            this.cboSearchby.Size = new System.Drawing.Size(177, 23);
            this.cboSearchby.TabIndex = 1;
            this.cboSearchby.SelectedIndexChanged += new System.EventHandler(this.cboSearchby_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search by";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(291, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 39);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 39);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(105, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 39);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(198, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 39);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(384, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 39);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnArrival
            // 
            this.btnArrival.Image = ((System.Drawing.Image)(resources.GetObject("btnArrival.Image")));
            this.btnArrival.Location = new System.Drawing.Point(477, 12);
            this.btnArrival.Name = "btnArrival";
            this.btnArrival.Size = new System.Drawing.Size(87, 39);
            this.btnArrival.TabIndex = 5;
            this.btnArrival.Text = "Arrival";
            this.btnArrival.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArrival.UseVisualStyleBackColor = true;
            this.btnArrival.Click += new System.EventHandler(this.btnArrival_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Locator No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Employee ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Employee Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Departure Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Departure Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Destination";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Reason/s";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(629, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Expected Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(629, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Expected Date";
            // 
            // gbApprovedas
            // 
            this.gbApprovedas.Controls.Add(this.cbOfficial);
            this.gbApprovedas.Controls.Add(this.cbPersonal);
            this.gbApprovedas.Location = new System.Drawing.Point(803, 180);
            this.gbApprovedas.Name = "gbApprovedas";
            this.gbApprovedas.Size = new System.Drawing.Size(115, 73);
            this.gbApprovedas.TabIndex = 16;
            this.gbApprovedas.TabStop = false;
            this.gbApprovedas.Text = "Approved As:";
            // 
            // cbOfficial
            // 
            this.cbOfficial.AutoSize = true;
            this.cbOfficial.Location = new System.Drawing.Point(14, 45);
            this.cbOfficial.Name = "cbOfficial";
            this.cbOfficial.Size = new System.Drawing.Size(63, 19);
            this.cbOfficial.TabIndex = 1;
            this.cbOfficial.Text = "Official";
            this.cbOfficial.UseVisualStyleBackColor = true;
            // 
            // cbPersonal
            // 
            this.cbPersonal.AutoSize = true;
            this.cbPersonal.Location = new System.Drawing.Point(14, 20);
            this.cbPersonal.Name = "cbPersonal";
            this.cbPersonal.Size = new System.Drawing.Size(75, 19);
            this.cbPersonal.TabIndex = 0;
            this.cbPersonal.Text = "Personal";
            this.cbPersonal.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(632, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "Number of Minutes Used";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(633, 313);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 15);
            this.label14.TabIndex = 20;
            this.label14.Text = "Equivalent";
            // 
            // txtEmpID
            // 
            this.txtEmpID.BackColor = System.Drawing.Color.White;
            this.txtEmpID.Location = new System.Drawing.Point(433, 128);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.ReadOnly = true;
            this.txtEmpID.Size = new System.Drawing.Size(182, 21);
            this.txtEmpID.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(433, 159);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(182, 21);
            this.txtName.TabIndex = 22;
            // 
            // txtLocNo
            // 
            this.txtLocNo.Location = new System.Drawing.Point(433, 187);
            this.txtLocNo.Name = "txtLocNo";
            this.txtLocNo.Size = new System.Drawing.Size(182, 21);
            this.txtLocNo.TabIndex = 23;
            // 
            // dtpDtime
            // 
            this.dtpDtime.CustomFormat = "  hh:mm tt";
            this.dtpDtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDtime.Location = new System.Drawing.Point(433, 216);
            this.dtpDtime.Name = "dtpDtime";
            this.dtpDtime.ShowUpDown = true;
            this.dtpDtime.Size = new System.Drawing.Size(182, 21);
            this.dtpDtime.TabIndex = 24;
            // 
            // dtpDdate
            // 
            this.dtpDdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDdate.Location = new System.Drawing.Point(433, 242);
            this.dtpDdate.Name = "dtpDdate";
            this.dtpDdate.Size = new System.Drawing.Size(182, 21);
            this.dtpDdate.TabIndex = 25;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(433, 269);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(182, 21);
            this.txtDestination.TabIndex = 26;
            // 
            // txtReasons
            // 
            this.txtReasons.Location = new System.Drawing.Point(433, 296);
            this.txtReasons.Multiline = true;
            this.txtReasons.Name = "txtReasons";
            this.txtReasons.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReasons.Size = new System.Drawing.Size(182, 86);
            this.txtReasons.TabIndex = 27;
            // 
            // dtpEtime
            // 
            this.dtpEtime.CustomFormat = "  hh:mm tt";
            this.dtpEtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEtime.Location = new System.Drawing.Point(803, 126);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.ShowUpDown = true;
            this.dtpEtime.Size = new System.Drawing.Size(203, 21);
            this.dtpEtime.TabIndex = 28;
            // 
            // dtpEdate
            // 
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEdate.Location = new System.Drawing.Point(803, 153);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(200, 21);
            this.dtpEdate.TabIndex = 29;
            // 
            // txtMinUsed
            // 
            this.txtMinUsed.Location = new System.Drawing.Point(803, 288);
            this.txtMinUsed.Name = "txtMinUsed";
            this.txtMinUsed.Size = new System.Drawing.Size(200, 21);
            this.txtMinUsed.TabIndex = 30;
            // 
            // txtEquivalent
            // 
            this.txtEquivalent.Location = new System.Drawing.Point(803, 315);
            this.txtEquivalent.Name = "txtEquivalent";
            this.txtEquivalent.Size = new System.Drawing.Size(200, 21);
            this.txtEquivalent.TabIndex = 33;
            // 
            // lstEmployee
            // 
            this.lstEmployee.FormattingEnabled = true;
            this.lstEmployee.ItemHeight = 15;
            this.lstEmployee.Location = new System.Drawing.Point(12, 121);
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(301, 259);
            this.lstEmployee.TabIndex = 34;
            this.lstEmployee.SelectedValueChanged += new System.EventHandler(this.lstEmployee_SelectedValueChanged);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 401);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(994, 209);
            this.dgvList.TabIndex = 35;
            this.dgvList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(632, 261);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 15);
            this.label15.TabIndex = 36;
            this.label15.Text = "Actual Time";
            // 
            // dtpActualTime
            // 
            this.dtpActualTime.CustomFormat = "  hh:mm tt";
            this.dtpActualTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActualTime.Location = new System.Drawing.Point(803, 261);
            this.dtpActualTime.Name = "dtpActualTime";
            this.dtpActualTime.ShowUpDown = true;
            this.dtpActualTime.Size = new System.Drawing.Size(200, 21);
            this.dtpActualTime.TabIndex = 37;
            this.dtpActualTime.ValueChanged += new System.EventHandler(this.dtpActualTime_ValueChanged);
            // 
            // frmLS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(1018, 619);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dtpActualTime);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.lstEmployee);
            this.Controls.Add(this.txtEquivalent);
            this.Controls.Add(this.txtMinUsed);
            this.Controls.Add(this.dtpEdate);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.txtReasons);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.dtpDdate);
            this.Controls.Add(this.dtpDtime);
            this.Controls.Add(this.txtLocNo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gbApprovedas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnArrival);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locator Slip";
            this.Load += new System.EventHandler(this.frmLS_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLS_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbApprovedas.ResumeLayout(false);
            this.gbApprovedas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnArrival;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSearchby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbApprovedas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLocNo;
        private System.Windows.Forms.DateTimePicker dtpDtime;
        private System.Windows.Forms.DateTimePicker dtpDdate;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtReasons;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.TextBox txtMinUsed;
        private System.Windows.Forms.TextBox txtEquivalent;
        private System.Windows.Forms.ListBox lstEmployee;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpActualTime;
        private System.Windows.Forms.CheckBox cbOfficial;
        private System.Windows.Forms.CheckBox cbPersonal;
        private System.Windows.Forms.Button btnDelete;
    }
}