namespace HRMIS_Solano
{
    partial class frmArrival
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArrival));
            this.gbEntryNo = new System.Windows.Forms.GroupBox();
            this.txtLocNo = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpArrived = new System.Windows.Forms.DateTimePicker();
            this.gbEntryNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEntryNo
            // 
            this.gbEntryNo.Controls.Add(this.txtLocNo);
            this.gbEntryNo.Location = new System.Drawing.Point(12, 12);
            this.gbEntryNo.Name = "gbEntryNo";
            this.gbEntryNo.Size = new System.Drawing.Size(182, 58);
            this.gbEntryNo.TabIndex = 0;
            this.gbEntryNo.TabStop = false;
            this.gbEntryNo.Text = "Enter Locator No.";
            // 
            // txtLocNo
            // 
            this.txtLocNo.Location = new System.Drawing.Point(7, 25);
            this.txtLocNo.Name = "txtLocNo";
            this.txtLocNo.Size = new System.Drawing.Size(165, 21);
            this.txtLocNo.TabIndex = 0;
            this.txtLocNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocNo_KeyPress);
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
            this.dgvList.Location = new System.Drawing.Point(12, 76);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(758, 472);
            this.dgvList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(629, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time Arrived";
            // 
            // dtpArrived
            // 
            this.dtpArrived.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpArrived.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpArrived.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.dtpArrived.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpArrived.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpArrived.CustomFormat = "  hh:mm tt";
            this.dtpArrived.Enabled = false;
            this.dtpArrived.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArrived.Location = new System.Drawing.Point(632, 49);
            this.dtpArrived.Name = "dtpArrived";
            this.dtpArrived.ShowUpDown = true;
            this.dtpArrived.Size = new System.Drawing.Size(138, 21);
            this.dtpArrived.TabIndex = 3;
            // 
            // frmArrival
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(782, 560);
            this.Controls.Add(this.dtpArrived);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.gbEntryNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmArrival";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arrival";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmArrival_FormClosed);
            this.gbEntryNo.ResumeLayout(false);
            this.gbEntryNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEntryNo;
        private System.Windows.Forms.TextBox txtLocNo;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpArrived;
    }
}