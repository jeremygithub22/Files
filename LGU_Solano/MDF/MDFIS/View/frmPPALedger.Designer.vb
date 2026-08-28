<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPPALedger
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbSearchbar = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSYear = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.cboSearchby = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstPPA = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtRefCode = New System.Windows.Forms.TextBox
        Me.txtPPA = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.txtNo = New System.Windows.Forms.TextBox
        Me.dtpDateReceived = New System.Windows.Forms.DateTimePicker
        Me.txtParticulars = New System.Windows.Forms.TextBox
        Me.txtRunningBal = New System.Windows.Forms.TextBox
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtWD = New System.Windows.Forms.TextBox
        Me.txtCW = New System.Windows.Forms.TextBox
        Me.mtxtDD = New System.Windows.Forms.MaskedTextBox
        Me.mtxtCD = New System.Windows.Forms.MaskedTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.txtPayee = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCtrNo = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboGSO = New System.Windows.Forms.ComboBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.gbSearchbar.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbSearchbar
        '
        Me.gbSearchbar.Controls.Add(Me.Label8)
        Me.gbSearchbar.Controls.Add(Me.txtSYear)
        Me.gbSearchbar.Controls.Add(Me.btnSearch)
        Me.gbSearchbar.Controls.Add(Me.txtSearch)
        Me.gbSearchbar.Controls.Add(Me.cboSearchby)
        Me.gbSearchbar.Controls.Add(Me.Label1)
        Me.gbSearchbar.Location = New System.Drawing.Point(12, 12)
        Me.gbSearchbar.Name = "gbSearchbar"
        Me.gbSearchbar.Size = New System.Drawing.Size(664, 61)
        Me.gbSearchbar.TabIndex = 0
        Me.gbSearchbar.TabStop = False
        Me.gbSearchbar.Text = "Search"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(436, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 15)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Year"
        '
        'txtSYear
        '
        Me.txtSYear.Location = New System.Drawing.Point(474, 27)
        Me.txtSYear.Name = "txtSYear"
        Me.txtSYear.Size = New System.Drawing.Size(100, 21)
        Me.txtSYear.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(580, 27)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(235, 27)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(195, 21)
        Me.txtSearch.TabIndex = 0
        '
        'cboSearchby
        '
        Me.cboSearchby.FormattingEnabled = True
        Me.cboSearchby.Items.AddRange(New Object() {"Reference No.", "PPA and Year", "Control No. and Year", "Payee and Year", "Project and Year", "Location and Year", "Year", "All"})
        Me.cboSearchby.Location = New System.Drawing.Point(73, 27)
        Me.cboSearchby.Name = "cboSearchby"
        Me.cboSearchby.Size = New System.Drawing.Size(156, 23)
        Me.cboSearchby.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search by"
        '
        'lstPPA
        '
        Me.lstPPA.FormattingEnabled = True
        Me.lstPPA.ItemHeight = 15
        Me.lstPPA.Location = New System.Drawing.Point(12, 79)
        Me.lstPPA.Name = "lstPPA"
        Me.lstPPA.Size = New System.Drawing.Size(209, 304)
        Me.lstPPA.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "AIP Ref. Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(227, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PPA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(227, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Reference No."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(227, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Date Received"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(227, 299)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Particulars"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(594, 287)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Running Balance"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(227, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 15)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Funding Year"
        '
        'txtRefCode
        '
        Me.txtRefCode.BackColor = System.Drawing.Color.White
        Me.txtRefCode.Location = New System.Drawing.Point(351, 109)
        Me.txtRefCode.Name = "txtRefCode"
        Me.txtRefCode.ReadOnly = True
        Me.txtRefCode.Size = New System.Drawing.Size(228, 21)
        Me.txtRefCode.TabIndex = 5
        '
        'txtPPA
        '
        Me.txtPPA.BackColor = System.Drawing.Color.White
        Me.txtPPA.Location = New System.Drawing.Point(351, 136)
        Me.txtPPA.Multiline = True
        Me.txtPPA.Name = "txtPPA"
        Me.txtPPA.ReadOnly = True
        Me.txtPPA.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPPA.Size = New System.Drawing.Size(228, 46)
        Me.txtPPA.TabIndex = 6
        '
        'txtYear
        '
        Me.txtYear.BackColor = System.Drawing.Color.White
        Me.txtYear.Location = New System.Drawing.Point(351, 188)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.ReadOnly = True
        Me.txtYear.Size = New System.Drawing.Size(228, 21)
        Me.txtYear.TabIndex = 7
        '
        'txtNo
        '
        Me.txtNo.BackColor = System.Drawing.Color.White
        Me.txtNo.Location = New System.Drawing.Point(351, 82)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.ReadOnly = True
        Me.txtNo.Size = New System.Drawing.Size(228, 21)
        Me.txtNo.TabIndex = 4
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateReceived.Location = New System.Drawing.Point(351, 242)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(228, 21)
        Me.dtpDateReceived.TabIndex = 9
        '
        'txtParticulars
        '
        Me.txtParticulars.Location = New System.Drawing.Point(351, 296)
        Me.txtParticulars.Multiline = True
        Me.txtParticulars.Name = "txtParticulars"
        Me.txtParticulars.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtParticulars.Size = New System.Drawing.Size(228, 45)
        Me.txtParticulars.TabIndex = 11
        '
        'txtRunningBal
        '
        Me.txtRunningBal.BackColor = System.Drawing.Color.White
        Me.txtRunningBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunningBal.Location = New System.Drawing.Point(715, 278)
        Me.txtRunningBal.Name = "txtRunningBal"
        Me.txtRunningBal.ReadOnly = True
        Me.txtRunningBal.Size = New System.Drawing.Size(228, 29)
        Me.txtRunningBal.TabIndex = 18
        Me.txtRunningBal.Text = "0.00"
        Me.txtRunningBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeColumns = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Location = New System.Drawing.Point(12, 403)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(984, 164)
        Me.dgvList.TabIndex = 24
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(721, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 20
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(883, 42)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(883, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(594, 162)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 15)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Whole Number"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(594, 186)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 15)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Decimal Amount"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(594, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 15)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Debit"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(594, 208)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 15)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Credit"
        '
        'txtWD
        '
        Me.txtWD.Location = New System.Drawing.Point(715, 156)
        Me.txtWD.Name = "txtWD"
        Me.txtWD.Size = New System.Drawing.Size(228, 21)
        Me.txtWD.TabIndex = 14
        Me.txtWD.Text = "0"
        Me.txtWD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCW
        '
        Me.txtCW.Location = New System.Drawing.Point(715, 224)
        Me.txtCW.Name = "txtCW"
        Me.txtCW.Size = New System.Drawing.Size(228, 21)
        Me.txtCW.TabIndex = 16
        Me.txtCW.Text = "0"
        Me.txtCW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mtxtDD
        '
        Me.mtxtDD.Location = New System.Drawing.Point(715, 183)
        Me.mtxtDD.Mask = ".00"
        Me.mtxtDD.Name = "mtxtDD"
        Me.mtxtDD.Size = New System.Drawing.Size(228, 21)
        Me.mtxtDD.TabIndex = 15
        Me.mtxtDD.Text = "00"
        Me.mtxtDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mtxtCD
        '
        Me.mtxtCD.Location = New System.Drawing.Point(715, 251)
        Me.mtxtCD.Mask = ".00"
        Me.mtxtCD.Name = "mtxtCD"
        Me.mtxtCD.Size = New System.Drawing.Size(228, 21)
        Me.mtxtCD.TabIndex = 17
        Me.mtxtCD.Text = "00"
        Me.mtxtCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(594, 254)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 15)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Decimal Amount"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(594, 227)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 15)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Whole Number"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(715, 83)
        Me.txtLocation.Multiline = True
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLocation.Size = New System.Drawing.Size(228, 47)
        Me.txtLocation.TabIndex = 13
        '
        'txtProjectName
        '
        Me.txtProjectName.Location = New System.Drawing.Point(351, 347)
        Me.txtProjectName.Multiline = True
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProjectName.Size = New System.Drawing.Size(228, 44)
        Me.txtProjectName.TabIndex = 12
        '
        'txtPayee
        '
        Me.txtPayee.Location = New System.Drawing.Point(351, 269)
        Me.txtPayee.Name = "txtPayee"
        Me.txtPayee.Size = New System.Drawing.Size(228, 21)
        Me.txtPayee.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(594, 86)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 15)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Location"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(227, 350)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Project Name"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(227, 272)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 15)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "Payee"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(715, 313)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRemarks.Size = New System.Drawing.Size(232, 55)
        Me.txtRemarks.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(594, 316)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Remarks"
        '
        'txtCtrNo
        '
        Me.txtCtrNo.Location = New System.Drawing.Point(351, 215)
        Me.txtCtrNo.Name = "txtCtrNo"
        Me.txtCtrNo.Size = New System.Drawing.Size(228, 21)
        Me.txtCtrNo.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(227, 218)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(68, 15)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "Control No."
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(802, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 21
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(594, 377)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 15)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "GSO"
        '
        'cboGSO
        '
        Me.cboGSO.FormattingEnabled = True
        Me.cboGSO.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboGSO.Location = New System.Drawing.Point(715, 374)
        Me.cboGSO.Name = "cboGSO"
        Me.cboGSO.Size = New System.Drawing.Size(232, 23)
        Me.cboGSO.TabIndex = 42
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(802, 42)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 43
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'frmPPALedger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1008, 576)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cboGSO)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtCtrNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.txtProjectName)
        Me.Controls.Add(Me.txtPayee)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.mtxtCD)
        Me.Controls.Add(Me.mtxtDD)
        Me.Controls.Add(Me.txtCW)
        Me.Controls.Add(Me.txtWD)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.txtRunningBal)
        Me.Controls.Add(Me.txtParticulars)
        Me.Controls.Add(Me.dtpDateReceived)
        Me.Controls.Add(Me.txtNo)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.txtPPA)
        Me.Controls.Add(Me.txtRefCode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lstPPA)
        Me.Controls.Add(Me.gbSearchbar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPPALedger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PPA Ledger"
        Me.gbSearchbar.ResumeLayout(False)
        Me.gbSearchbar.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbSearchbar As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboSearchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstPPA As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRefCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPPA As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents txtNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtParticulars As System.Windows.Forms.TextBox
    Friend WithEvents txtRunningBal As System.Windows.Forms.TextBox
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtWD As System.Windows.Forms.TextBox
    Friend WithEvents txtCW As System.Windows.Forms.TextBox
    Friend WithEvents mtxtDD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtCD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtPayee As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSYear As System.Windows.Forms.TextBox
    Friend WithEvents txtCtrNo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboGSO As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
