namespace HRMIS_Solano
{
    partial class frmUserAcct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserAcct));
            this.gbSearchbar = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearchby = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbPriviledges = new System.Windows.Forms.GroupBox();
            this.cbwlsDel = new System.Windows.Forms.CheckBox();
            this.cbwlsEdit = new System.Windows.Forms.CheckBox();
            this.cbwlsAdd = new System.Windows.Forms.CheckBox();
            this.cbfrDel = new System.Windows.Forms.CheckBox();
            this.cbfrEdit = new System.Windows.Forms.CheckBox();
            this.cbfrAdd = new System.Windows.Forms.CheckBox();
            this.cbfcDel = new System.Windows.Forms.CheckBox();
            this.cbfcEdit = new System.Windows.Forms.CheckBox();
            this.cbfcAdd = new System.Windows.Forms.CheckBox();
            this.cblcDel = new System.Windows.Forms.CheckBox();
            this.cblcEdit = new System.Windows.Forms.CheckBox();
            this.cblcAdd = new System.Windows.Forms.CheckBox();
            this.cblrDel = new System.Windows.Forms.CheckBox();
            this.cblrEdit = new System.Windows.Forms.CheckBox();
            this.cblrAdd = new System.Windows.Forms.CheckBox();
            this.cbR = new System.Windows.Forms.CheckBox();
            this.cbsrDel = new System.Windows.Forms.CheckBox();
            this.cbsrEdit = new System.Windows.Forms.CheckBox();
            this.cbsrAdd = new System.Windows.Forms.CheckBox();
            this.cblsDel = new System.Windows.Forms.CheckBox();
            this.cblsEdit = new System.Windows.Forms.CheckBox();
            this.cblsAdd = new System.Windows.Forms.CheckBox();
            this.cbtuDel = new System.Windows.Forms.CheckBox();
            this.cbtuEdit = new System.Windows.Forms.CheckBox();
            this.cbtuAdd = new System.Windows.Forms.CheckBox();
            this.cbpiDel = new System.Windows.Forms.CheckBox();
            this.cbpiEdit = new System.Windows.Forms.CheckBox();
            this.cbpiAdd = new System.Windows.Forms.CheckBox();
            this.cbWLS = new System.Windows.Forms.CheckBox();
            this.cbFR = new System.Windows.Forms.CheckBox();
            this.cbFC = new System.Windows.Forms.CheckBox();
            this.cbLC = new System.Windows.Forms.CheckBox();
            this.cbTU = new System.Windows.Forms.CheckBox();
            this.cbLR = new System.Windows.Forms.CheckBox();
            this.cbSR = new System.Windows.Forms.CheckBox();
            this.cbLS = new System.Windows.Forms.CheckBox();
            this.cbPI = new System.Windows.Forms.CheckBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtMiddlename = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUsertype = new System.Windows.Forms.ComboBox();
            this.gbSearchbar.SuspendLayout();
            this.gbPriviledges.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearchbar
            // 
            this.gbSearchbar.Controls.Add(this.btnSearch);
            this.gbSearchbar.Controls.Add(this.txtSearch);
            this.gbSearchbar.Controls.Add(this.cboSearchby);
            this.gbSearchbar.Controls.Add(this.label1);
            this.gbSearchbar.Location = new System.Drawing.Point(12, 56);
            this.gbSearchbar.Name = "gbSearchbar";
            this.gbSearchbar.Size = new System.Drawing.Size(528, 65);
            this.gbSearchbar.TabIndex = 0;
            this.gbSearchbar.TabStop = false;
            this.gbSearchbar.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(432, 17);
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
            this.txtSearch.Location = new System.Drawing.Point(219, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(207, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cboSearchby
            // 
            this.cboSearchby.FormattingEnabled = true;
            this.cboSearchby.Items.AddRange(new object[] {
            "Username",
            "Surname",
            "Fistname",
            "Middlename",
            "All"});
            this.cboSearchby.Location = new System.Drawing.Point(73, 26);
            this.cboSearchby.Name = "cboSearchby";
            this.cboSearchby.Size = new System.Drawing.Size(140, 23);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Firstname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Middlename";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Surname";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Password";
            // 
            // gbPriviledges
            // 
            this.gbPriviledges.Controls.Add(this.cbwlsDel);
            this.gbPriviledges.Controls.Add(this.cbwlsEdit);
            this.gbPriviledges.Controls.Add(this.cbwlsAdd);
            this.gbPriviledges.Controls.Add(this.cbfrDel);
            this.gbPriviledges.Controls.Add(this.cbfrEdit);
            this.gbPriviledges.Controls.Add(this.cbfrAdd);
            this.gbPriviledges.Controls.Add(this.cbfcDel);
            this.gbPriviledges.Controls.Add(this.cbfcEdit);
            this.gbPriviledges.Controls.Add(this.cbfcAdd);
            this.gbPriviledges.Controls.Add(this.cblcDel);
            this.gbPriviledges.Controls.Add(this.cblcEdit);
            this.gbPriviledges.Controls.Add(this.cblcAdd);
            this.gbPriviledges.Controls.Add(this.cblrDel);
            this.gbPriviledges.Controls.Add(this.cblrEdit);
            this.gbPriviledges.Controls.Add(this.cblrAdd);
            this.gbPriviledges.Controls.Add(this.cbR);
            this.gbPriviledges.Controls.Add(this.cbsrDel);
            this.gbPriviledges.Controls.Add(this.cbsrEdit);
            this.gbPriviledges.Controls.Add(this.cbsrAdd);
            this.gbPriviledges.Controls.Add(this.cblsDel);
            this.gbPriviledges.Controls.Add(this.cblsEdit);
            this.gbPriviledges.Controls.Add(this.cblsAdd);
            this.gbPriviledges.Controls.Add(this.cbtuDel);
            this.gbPriviledges.Controls.Add(this.cbtuEdit);
            this.gbPriviledges.Controls.Add(this.cbtuAdd);
            this.gbPriviledges.Controls.Add(this.cbpiDel);
            this.gbPriviledges.Controls.Add(this.cbpiEdit);
            this.gbPriviledges.Controls.Add(this.cbpiAdd);
            this.gbPriviledges.Controls.Add(this.cbWLS);
            this.gbPriviledges.Controls.Add(this.cbFR);
            this.gbPriviledges.Controls.Add(this.cbFC);
            this.gbPriviledges.Controls.Add(this.cbLC);
            this.gbPriviledges.Controls.Add(this.cbTU);
            this.gbPriviledges.Controls.Add(this.cbLR);
            this.gbPriviledges.Controls.Add(this.cbSR);
            this.gbPriviledges.Controls.Add(this.cbLS);
            this.gbPriviledges.Controls.Add(this.cbPI);
            this.gbPriviledges.Location = new System.Drawing.Point(282, 319);
            this.gbPriviledges.Name = "gbPriviledges";
            this.gbPriviledges.Size = new System.Drawing.Size(692, 261);
            this.gbPriviledges.TabIndex = 6;
            this.gbPriviledges.TabStop = false;
            this.gbPriviledges.Text = "Privileges";
            // 
            // cbwlsDel
            // 
            this.cbwlsDel.AutoSize = true;
            this.cbwlsDel.Location = new System.Drawing.Point(562, 102);
            this.cbwlsDel.Name = "cbwlsDel";
            this.cbwlsDel.Size = new System.Drawing.Size(62, 19);
            this.cbwlsDel.TabIndex = 55;
            this.cbwlsDel.Text = "Delete";
            this.cbwlsDel.UseVisualStyleBackColor = true;
            this.cbwlsDel.CheckedChanged += new System.EventHandler(this.cbwlsDel_CheckedChanged);
            // 
            // cbwlsEdit
            // 
            this.cbwlsEdit.AutoSize = true;
            this.cbwlsEdit.Location = new System.Drawing.Point(562, 77);
            this.cbwlsEdit.Name = "cbwlsEdit";
            this.cbwlsEdit.Size = new System.Drawing.Size(47, 19);
            this.cbwlsEdit.TabIndex = 54;
            this.cbwlsEdit.Text = "Edit";
            this.cbwlsEdit.UseVisualStyleBackColor = true;
            this.cbwlsEdit.CheckedChanged += new System.EventHandler(this.cbwlsEdit_CheckedChanged);
            // 
            // cbwlsAdd
            // 
            this.cbwlsAdd.AutoSize = true;
            this.cbwlsAdd.Location = new System.Drawing.Point(562, 54);
            this.cbwlsAdd.Name = "cbwlsAdd";
            this.cbwlsAdd.Size = new System.Drawing.Size(47, 19);
            this.cbwlsAdd.TabIndex = 53;
            this.cbwlsAdd.Text = "Add";
            this.cbwlsAdd.UseVisualStyleBackColor = true;
            this.cbwlsAdd.CheckedChanged += new System.EventHandler(this.cbwlsAdd_CheckedChanged);
            // 
            // cbfrDel
            // 
            this.cbfrDel.AutoSize = true;
            this.cbfrDel.Location = new System.Drawing.Point(449, 202);
            this.cbfrDel.Name = "cbfrDel";
            this.cbfrDel.Size = new System.Drawing.Size(62, 19);
            this.cbfrDel.TabIndex = 52;
            this.cbfrDel.Text = "Delete";
            this.cbfrDel.UseVisualStyleBackColor = true;
            this.cbfrDel.CheckedChanged += new System.EventHandler(this.cbfrDel_CheckedChanged);
            // 
            // cbfrEdit
            // 
            this.cbfrEdit.AutoSize = true;
            this.cbfrEdit.Location = new System.Drawing.Point(449, 177);
            this.cbfrEdit.Name = "cbfrEdit";
            this.cbfrEdit.Size = new System.Drawing.Size(47, 19);
            this.cbfrEdit.TabIndex = 51;
            this.cbfrEdit.Text = "Edit";
            this.cbfrEdit.UseVisualStyleBackColor = true;
            this.cbfrEdit.CheckedChanged += new System.EventHandler(this.cbfrEdit_CheckedChanged);
            // 
            // cbfrAdd
            // 
            this.cbfrAdd.AutoSize = true;
            this.cbfrAdd.Location = new System.Drawing.Point(449, 154);
            this.cbfrAdd.Name = "cbfrAdd";
            this.cbfrAdd.Size = new System.Drawing.Size(47, 19);
            this.cbfrAdd.TabIndex = 50;
            this.cbfrAdd.Text = "Add";
            this.cbfrAdd.UseVisualStyleBackColor = true;
            this.cbfrAdd.CheckedChanged += new System.EventHandler(this.cbfrAdd_CheckedChanged);
            // 
            // cbfcDel
            // 
            this.cbfcDel.AutoSize = true;
            this.cbfcDel.Location = new System.Drawing.Point(334, 202);
            this.cbfcDel.Name = "cbfcDel";
            this.cbfcDel.Size = new System.Drawing.Size(62, 19);
            this.cbfcDel.TabIndex = 46;
            this.cbfcDel.Text = "Delete";
            this.cbfcDel.UseVisualStyleBackColor = true;
            this.cbfcDel.CheckedChanged += new System.EventHandler(this.cbfcDel_CheckedChanged);
            // 
            // cbfcEdit
            // 
            this.cbfcEdit.AutoSize = true;
            this.cbfcEdit.Location = new System.Drawing.Point(334, 177);
            this.cbfcEdit.Name = "cbfcEdit";
            this.cbfcEdit.Size = new System.Drawing.Size(47, 19);
            this.cbfcEdit.TabIndex = 45;
            this.cbfcEdit.Text = "Edit";
            this.cbfcEdit.UseVisualStyleBackColor = true;
            this.cbfcEdit.CheckedChanged += new System.EventHandler(this.cbfcEdit_CheckedChanged);
            // 
            // cbfcAdd
            // 
            this.cbfcAdd.AutoSize = true;
            this.cbfcAdd.Location = new System.Drawing.Point(334, 152);
            this.cbfcAdd.Name = "cbfcAdd";
            this.cbfcAdd.Size = new System.Drawing.Size(47, 19);
            this.cbfcAdd.TabIndex = 44;
            this.cbfcAdd.Text = "Add";
            this.cbfcAdd.UseVisualStyleBackColor = true;
            this.cbfcAdd.CheckedChanged += new System.EventHandler(this.cbfcAdd_CheckedChanged);
            // 
            // cblcDel
            // 
            this.cblcDel.AutoSize = true;
            this.cblcDel.Location = new System.Drawing.Point(184, 204);
            this.cblcDel.Name = "cblcDel";
            this.cblcDel.Size = new System.Drawing.Size(62, 19);
            this.cblcDel.TabIndex = 43;
            this.cblcDel.Text = "Delete";
            this.cblcDel.UseVisualStyleBackColor = true;
            this.cblcDel.CheckedChanged += new System.EventHandler(this.cblcDel_CheckedChanged);
            // 
            // cblcEdit
            // 
            this.cblcEdit.AutoSize = true;
            this.cblcEdit.Location = new System.Drawing.Point(184, 179);
            this.cblcEdit.Name = "cblcEdit";
            this.cblcEdit.Size = new System.Drawing.Size(47, 19);
            this.cblcEdit.TabIndex = 42;
            this.cblcEdit.Text = "Edit";
            this.cblcEdit.UseVisualStyleBackColor = true;
            this.cblcEdit.CheckedChanged += new System.EventHandler(this.cblcEdit_CheckedChanged);
            // 
            // cblcAdd
            // 
            this.cblcAdd.AutoSize = true;
            this.cblcAdd.Location = new System.Drawing.Point(184, 154);
            this.cblcAdd.Name = "cblcAdd";
            this.cblcAdd.Size = new System.Drawing.Size(47, 19);
            this.cblcAdd.TabIndex = 41;
            this.cblcAdd.Text = "Add";
            this.cblcAdd.UseVisualStyleBackColor = true;
            this.cblcAdd.CheckedChanged += new System.EventHandler(this.cblcAdd_CheckedChanged);
            // 
            // cblrDel
            // 
            this.cblrDel.AutoSize = true;
            this.cblrDel.Location = new System.Drawing.Point(41, 204);
            this.cblrDel.Name = "cblrDel";
            this.cblrDel.Size = new System.Drawing.Size(62, 19);
            this.cblrDel.TabIndex = 37;
            this.cblrDel.Text = "Delete";
            this.cblrDel.UseVisualStyleBackColor = true;
            this.cblrDel.CheckedChanged += new System.EventHandler(this.cblrDel_CheckedChanged);
            // 
            // cblrEdit
            // 
            this.cblrEdit.AutoSize = true;
            this.cblrEdit.Location = new System.Drawing.Point(41, 179);
            this.cblrEdit.Name = "cblrEdit";
            this.cblrEdit.Size = new System.Drawing.Size(47, 19);
            this.cblrEdit.TabIndex = 36;
            this.cblrEdit.Text = "Edit";
            this.cblrEdit.UseVisualStyleBackColor = true;
            this.cblrEdit.CheckedChanged += new System.EventHandler(this.cblrEdit_CheckedChanged);
            // 
            // cblrAdd
            // 
            this.cblrAdd.AutoSize = true;
            this.cblrAdd.Location = new System.Drawing.Point(41, 154);
            this.cblrAdd.Name = "cblrAdd";
            this.cblrAdd.Size = new System.Drawing.Size(47, 19);
            this.cblrAdd.TabIndex = 35;
            this.cblrAdd.Text = "Add";
            this.cblrAdd.UseVisualStyleBackColor = true;
            this.cblrAdd.CheckedChanged += new System.EventHandler(this.cblrAdd_CheckedChanged);
            // 
            // cbR
            // 
            this.cbR.AutoSize = true;
            this.cbR.Location = new System.Drawing.Point(546, 129);
            this.cbR.Name = "cbR";
            this.cbR.Size = new System.Drawing.Size(69, 19);
            this.cbR.TabIndex = 5;
            this.cbR.Text = "Reports";
            this.cbR.UseVisualStyleBackColor = true;
            this.cbR.CheckedChanged += new System.EventHandler(this.cbR_CheckedChanged);
            // 
            // cbsrDel
            // 
            this.cbsrDel.AutoSize = true;
            this.cbsrDel.Location = new System.Drawing.Point(447, 104);
            this.cbsrDel.Name = "cbsrDel";
            this.cbsrDel.Size = new System.Drawing.Size(62, 19);
            this.cbsrDel.TabIndex = 28;
            this.cbsrDel.Text = "Delete";
            this.cbsrDel.UseVisualStyleBackColor = true;
            this.cbsrDel.CheckedChanged += new System.EventHandler(this.cbsrDel_CheckedChanged);
            // 
            // cbsrEdit
            // 
            this.cbsrEdit.AutoSize = true;
            this.cbsrEdit.Location = new System.Drawing.Point(447, 79);
            this.cbsrEdit.Name = "cbsrEdit";
            this.cbsrEdit.Size = new System.Drawing.Size(47, 19);
            this.cbsrEdit.TabIndex = 27;
            this.cbsrEdit.Text = "Edit";
            this.cbsrEdit.UseVisualStyleBackColor = true;
            this.cbsrEdit.CheckedChanged += new System.EventHandler(this.cbsrEdit_CheckedChanged);
            // 
            // cbsrAdd
            // 
            this.cbsrAdd.AutoSize = true;
            this.cbsrAdd.Location = new System.Drawing.Point(447, 54);
            this.cbsrAdd.Name = "cbsrAdd";
            this.cbsrAdd.Size = new System.Drawing.Size(47, 19);
            this.cbsrAdd.TabIndex = 26;
            this.cbsrAdd.Text = "Add";
            this.cbsrAdd.UseVisualStyleBackColor = true;
            this.cbsrAdd.CheckedChanged += new System.EventHandler(this.cbsrAdd_CheckedChanged);
            // 
            // cblsDel
            // 
            this.cblsDel.AutoSize = true;
            this.cblsDel.Location = new System.Drawing.Point(334, 104);
            this.cblsDel.Name = "cblsDel";
            this.cblsDel.Size = new System.Drawing.Size(62, 19);
            this.cblsDel.TabIndex = 25;
            this.cblsDel.Text = "Delete";
            this.cblsDel.UseVisualStyleBackColor = true;
            this.cblsDel.CheckedChanged += new System.EventHandler(this.cblsDel_CheckedChanged);
            // 
            // cblsEdit
            // 
            this.cblsEdit.AutoSize = true;
            this.cblsEdit.Location = new System.Drawing.Point(334, 79);
            this.cblsEdit.Name = "cblsEdit";
            this.cblsEdit.Size = new System.Drawing.Size(47, 19);
            this.cblsEdit.TabIndex = 24;
            this.cblsEdit.Text = "Edit";
            this.cblsEdit.UseVisualStyleBackColor = true;
            this.cblsEdit.CheckedChanged += new System.EventHandler(this.cblsEdit_CheckedChanged);
            // 
            // cblsAdd
            // 
            this.cblsAdd.AutoSize = true;
            this.cblsAdd.Location = new System.Drawing.Point(334, 54);
            this.cblsAdd.Name = "cblsAdd";
            this.cblsAdd.Size = new System.Drawing.Size(47, 19);
            this.cblsAdd.TabIndex = 23;
            this.cblsAdd.Text = "Add";
            this.cblsAdd.UseVisualStyleBackColor = true;
            this.cblsAdd.CheckedChanged += new System.EventHandler(this.cblsAdd_CheckedChanged);
            // 
            // cbtuDel
            // 
            this.cbtuDel.AutoSize = true;
            this.cbtuDel.Location = new System.Drawing.Point(187, 104);
            this.cbtuDel.Name = "cbtuDel";
            this.cbtuDel.Size = new System.Drawing.Size(62, 19);
            this.cbtuDel.TabIndex = 22;
            this.cbtuDel.Text = "Delete";
            this.cbtuDel.UseVisualStyleBackColor = true;
            this.cbtuDel.CheckedChanged += new System.EventHandler(this.cbtuDel_CheckedChanged);
            // 
            // cbtuEdit
            // 
            this.cbtuEdit.AutoSize = true;
            this.cbtuEdit.Location = new System.Drawing.Point(187, 79);
            this.cbtuEdit.Name = "cbtuEdit";
            this.cbtuEdit.Size = new System.Drawing.Size(47, 19);
            this.cbtuEdit.TabIndex = 21;
            this.cbtuEdit.Text = "Edit";
            this.cbtuEdit.UseVisualStyleBackColor = true;
            this.cbtuEdit.CheckedChanged += new System.EventHandler(this.cbtuEdit_CheckedChanged);
            // 
            // cbtuAdd
            // 
            this.cbtuAdd.AutoSize = true;
            this.cbtuAdd.Location = new System.Drawing.Point(187, 54);
            this.cbtuAdd.Name = "cbtuAdd";
            this.cbtuAdd.Size = new System.Drawing.Size(47, 19);
            this.cbtuAdd.TabIndex = 20;
            this.cbtuAdd.Text = "Add";
            this.cbtuAdd.UseVisualStyleBackColor = true;
            this.cbtuAdd.CheckedChanged += new System.EventHandler(this.cbtuAdd_CheckedChanged);
            // 
            // cbpiDel
            // 
            this.cbpiDel.AutoSize = true;
            this.cbpiDel.Location = new System.Drawing.Point(40, 104);
            this.cbpiDel.Name = "cbpiDel";
            this.cbpiDel.Size = new System.Drawing.Size(62, 19);
            this.cbpiDel.TabIndex = 16;
            this.cbpiDel.Text = "Delete";
            this.cbpiDel.UseVisualStyleBackColor = true;
            this.cbpiDel.CheckedChanged += new System.EventHandler(this.cbpiDel_CheckedChanged);
            // 
            // cbpiEdit
            // 
            this.cbpiEdit.AutoSize = true;
            this.cbpiEdit.Location = new System.Drawing.Point(40, 79);
            this.cbpiEdit.Name = "cbpiEdit";
            this.cbpiEdit.Size = new System.Drawing.Size(47, 19);
            this.cbpiEdit.TabIndex = 15;
            this.cbpiEdit.Text = "Edit";
            this.cbpiEdit.UseVisualStyleBackColor = true;
            this.cbpiEdit.CheckedChanged += new System.EventHandler(this.cbpiEdit_CheckedChanged);
            // 
            // cbpiAdd
            // 
            this.cbpiAdd.AutoSize = true;
            this.cbpiAdd.Location = new System.Drawing.Point(40, 54);
            this.cbpiAdd.Name = "cbpiAdd";
            this.cbpiAdd.Size = new System.Drawing.Size(47, 19);
            this.cbpiAdd.TabIndex = 14;
            this.cbpiAdd.Text = "Add";
            this.cbpiAdd.UseVisualStyleBackColor = true;
            this.cbpiAdd.CheckedChanged += new System.EventHandler(this.cbpiAdd_CheckedChanged);
            // 
            // cbWLS
            // 
            this.cbWLS.AutoSize = true;
            this.cbWLS.Location = new System.Drawing.Point(546, 29);
            this.cbWLS.Name = "cbWLS";
            this.cbWLS.Size = new System.Drawing.Size(135, 19);
            this.cbWLS.TabIndex = 13;
            this.cbWLS.Text = "Without Locator Slip";
            this.cbWLS.UseVisualStyleBackColor = true;
            this.cbWLS.CheckedChanged += new System.EventHandler(this.cbWLS_CheckedChanged);
            // 
            // cbFR
            // 
            this.cbFR.AutoSize = true;
            this.cbFR.Location = new System.Drawing.Point(431, 129);
            this.cbFR.Name = "cbFR";
            this.cbFR.Size = new System.Drawing.Size(93, 19);
            this.cbFR.TabIndex = 12;
            this.cbFR.Text = "Flag Retreat";
            this.cbFR.UseVisualStyleBackColor = true;
            this.cbFR.CheckedChanged += new System.EventHandler(this.cbFR_CheckedChanged);
            // 
            // cbFC
            // 
            this.cbFC.AutoSize = true;
            this.cbFC.Location = new System.Drawing.Point(316, 129);
            this.cbFC.Name = "cbFC";
            this.cbFC.Size = new System.Drawing.Size(109, 19);
            this.cbFC.TabIndex = 11;
            this.cbFC.Text = "Flag Ceremony";
            this.cbFC.UseVisualStyleBackColor = true;
            this.cbFC.CheckedChanged += new System.EventHandler(this.cbFC_CheckedChanged);
            // 
            // cbLC
            // 
            this.cbLC.AutoSize = true;
            this.cbLC.Location = new System.Drawing.Point(168, 129);
            this.cbLC.Name = "cbLC";
            this.cbLC.Size = new System.Drawing.Size(100, 19);
            this.cbLC.TabIndex = 9;
            this.cbLC.Text = "Leave Credits";
            this.cbLC.UseVisualStyleBackColor = true;
            this.cbLC.CheckedChanged += new System.EventHandler(this.cbLC_CheckedChanged);
            // 
            // cbTU
            // 
            this.cbTU.AutoSize = true;
            this.cbTU.Location = new System.Drawing.Point(168, 29);
            this.cbTU.Name = "cbTU";
            this.cbTU.Size = new System.Drawing.Size(141, 19);
            this.cbTU.TabIndex = 8;
            this.cbTU.Text = "Tardiness/Undertime";
            this.cbTU.UseVisualStyleBackColor = true;
            this.cbTU.CheckedChanged += new System.EventHandler(this.cbTU_CheckedChanged);
            // 
            // cbLR
            // 
            this.cbLR.AutoSize = true;
            this.cbLR.Location = new System.Drawing.Point(22, 129);
            this.cbLR.Name = "cbLR";
            this.cbLR.Size = new System.Drawing.Size(102, 19);
            this.cbLR.TabIndex = 7;
            this.cbLR.Text = "Leave Record";
            this.cbLR.UseVisualStyleBackColor = true;
            this.cbLR.CheckedChanged += new System.EventHandler(this.cbLR_CheckedChanged);
            // 
            // cbSR
            // 
            this.cbSR.AutoSize = true;
            this.cbSR.Location = new System.Drawing.Point(431, 29);
            this.cbSR.Name = "cbSR";
            this.cbSR.Size = new System.Drawing.Size(109, 19);
            this.cbSR.TabIndex = 6;
            this.cbSR.Text = "Service Record";
            this.cbSR.UseVisualStyleBackColor = true;
            this.cbSR.CheckedChanged += new System.EventHandler(this.cbSR_CheckedChanged);
            // 
            // cbLS
            // 
            this.cbLS.AutoSize = true;
            this.cbLS.Location = new System.Drawing.Point(316, 29);
            this.cbLS.Name = "cbLS";
            this.cbLS.Size = new System.Drawing.Size(91, 19);
            this.cbLS.TabIndex = 3;
            this.cbLS.Text = "Locator Slip";
            this.cbLS.UseVisualStyleBackColor = true;
            this.cbLS.CheckedChanged += new System.EventHandler(this.cbLS_CheckedChanged);
            // 
            // cbPI
            // 
            this.cbPI.AutoSize = true;
            this.cbPI.Location = new System.Drawing.Point(22, 29);
            this.cbPI.Name = "cbPI";
            this.cbPI.Size = new System.Drawing.Size(140, 19);
            this.cbPI.TabIndex = 0;
            this.cbPI.Text = "Personal Information";
            this.cbPI.UseVisualStyleBackColor = true;
            this.cbPI.CheckedChanged += new System.EventHandler(this.cbPI_CheckedChanged);
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(386, 147);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(239, 21);
            this.txtFirstname.TabIndex = 7;
            // 
            // txtMiddlename
            // 
            this.txtMiddlename.Location = new System.Drawing.Point(386, 174);
            this.txtMiddlename.Name = "txtMiddlename";
            this.txtMiddlename.Size = new System.Drawing.Size(239, 21);
            this.txtMiddlename.TabIndex = 8;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(386, 201);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(239, 21);
            this.txtSurname.TabIndex = 9;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(386, 228);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(239, 21);
            this.txtUsername.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(386, 257);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(239, 21);
            this.txtPassword.TabIndex = 11;
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 39);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(105, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 39);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(198, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 39);
            this.btnSave.TabIndex = 14;
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
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstUser
            // 
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 15;
            this.lstUser.Location = new System.Drawing.Point(12, 127);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(237, 439);
            this.lstUser.TabIndex = 16;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            this.lstUser.SelectedValueChanged += new System.EventHandler(this.lstUser_SelectedValueChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(291, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 39);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "User type";
            // 
            // cboUsertype
            // 
            this.cboUsertype.FormattingEnabled = true;
            this.cboUsertype.Items.AddRange(new object[] {
            "Administrator",
            "User"});
            this.cboUsertype.Location = new System.Drawing.Point(386, 284);
            this.cboUsertype.Name = "cboUsertype";
            this.cboUsertype.Size = new System.Drawing.Size(239, 23);
            this.cboUsertype.TabIndex = 19;
            // 
            // frmUserAcct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(998, 592);
            this.Controls.Add(this.cboUsertype);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtMiddlename);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.gbPriviledges);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbSearchbar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserAcct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Accounts";
            this.gbSearchbar.ResumeLayout(false);
            this.gbSearchbar.PerformLayout();
            this.gbPriviledges.ResumeLayout(false);
            this.gbPriviledges.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchbar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSearchby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbPriviledges;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtMiddlename;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox cbPI;
        private System.Windows.Forms.CheckBox cbLS;
        private System.Windows.Forms.CheckBox cbR;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.CheckBox cbLC;
        private System.Windows.Forms.CheckBox cbTU;
        private System.Windows.Forms.CheckBox cbLR;
        private System.Windows.Forms.CheckBox cbSR;
        private System.Windows.Forms.CheckBox cbWLS;
        private System.Windows.Forms.CheckBox cbFR;
        private System.Windows.Forms.CheckBox cbFC;
        private System.Windows.Forms.CheckBox cbtuDel;
        private System.Windows.Forms.CheckBox cbtuEdit;
        private System.Windows.Forms.CheckBox cbtuAdd;
        private System.Windows.Forms.CheckBox cbpiDel;
        private System.Windows.Forms.CheckBox cbpiEdit;
        private System.Windows.Forms.CheckBox cbpiAdd;
        private System.Windows.Forms.CheckBox cblcAdd;
        private System.Windows.Forms.CheckBox cblrDel;
        private System.Windows.Forms.CheckBox cblrEdit;
        private System.Windows.Forms.CheckBox cblrAdd;
        private System.Windows.Forms.CheckBox cbsrDel;
        private System.Windows.Forms.CheckBox cbsrEdit;
        private System.Windows.Forms.CheckBox cbsrAdd;
        private System.Windows.Forms.CheckBox cblsDel;
        private System.Windows.Forms.CheckBox cblsEdit;
        private System.Windows.Forms.CheckBox cblsAdd;
        private System.Windows.Forms.CheckBox cbwlsDel;
        private System.Windows.Forms.CheckBox cbwlsEdit;
        private System.Windows.Forms.CheckBox cbwlsAdd;
        private System.Windows.Forms.CheckBox cbfrDel;
        private System.Windows.Forms.CheckBox cbfrEdit;
        private System.Windows.Forms.CheckBox cbfrAdd;
        private System.Windows.Forms.CheckBox cbfcDel;
        private System.Windows.Forms.CheckBox cbfcEdit;
        private System.Windows.Forms.CheckBox cbfcAdd;
        private System.Windows.Forms.CheckBox cblcDel;
        private System.Windows.Forms.CheckBox cblcEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboUsertype;
    }
}