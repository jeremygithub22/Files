<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBudgetApproval
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
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtCtrNo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.txtPayee = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCW = New System.Windows.Forms.TextBox
        Me.txtWD = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnApprove = New System.Windows.Forms.Button
        Me.txtRunningBal = New System.Windows.Forms.TextBox
        Me.txtParticulars = New System.Windows.Forms.TextBox
        Me.dtpDateReceived = New System.Windows.Forms.DateTimePicker
        Me.txtNo = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.txtPPA = New System.Windows.Forms.TextBox
        Me.txtRefCode = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstPPA = New System.Windows.Forms.ListBox
        Me.txtLNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbSearchbar = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSYear = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.cboSearchby = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.gbSearchbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(227, 247)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(68, 15)
        Me.Label20.TabIndex = 83
        Me.Label20.Text = "Control No."
        '
        'txtCtrNo
        '
        Me.txtCtrNo.BackColor = System.Drawing.Color.White
        Me.txtCtrNo.Location = New System.Drawing.Point(351, 243)
        Me.txtCtrNo.Name = "txtCtrNo"
        Me.txtCtrNo.ReadOnly = True
        Me.txtCtrNo.Size = New System.Drawing.Size(228, 21)
        Me.txtCtrNo.TabIndex = 53
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(594, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.Location = New System.Drawing.Point(715, 279)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ReadOnly = True
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRemarks.Size = New System.Drawing.Size(232, 55)
        Me.txtRemarks.TabIndex = 66
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.White
        Me.txtLocation.Location = New System.Drawing.Point(715, 137)
        Me.txtLocation.Multiline = True
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLocation.Size = New System.Drawing.Size(228, 47)
        Me.txtLocation.TabIndex = 60
        '
        'txtProjectName
        '
        Me.txtProjectName.BackColor = System.Drawing.Color.White
        Me.txtProjectName.Location = New System.Drawing.Point(715, 87)
        Me.txtProjectName.Multiline = True
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.ReadOnly = True
        Me.txtProjectName.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProjectName.Size = New System.Drawing.Size(228, 44)
        Me.txtProjectName.TabIndex = 59
        '
        'txtPayee
        '
        Me.txtPayee.BackColor = System.Drawing.Color.White
        Me.txtPayee.Location = New System.Drawing.Point(351, 297)
        Me.txtPayee.Name = "txtPayee"
        Me.txtPayee.ReadOnly = True
        Me.txtPayee.Size = New System.Drawing.Size(228, 21)
        Me.txtPayee.TabIndex = 57
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(594, 140)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 15)
        Me.Label17.TabIndex = 81
        Me.Label17.Text = "Location"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(594, 90)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 80
        Me.Label18.Text = "Project Name"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(227, 301)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 15)
        Me.Label19.TabIndex = 79
        Me.Label19.Text = "Payee"
        '
        'txtCW
        '
        Me.txtCW.BackColor = System.Drawing.Color.White
        Me.txtCW.Location = New System.Drawing.Point(715, 217)
        Me.txtCW.Name = "txtCW"
        Me.txtCW.ReadOnly = True
        Me.txtCW.Size = New System.Drawing.Size(228, 21)
        Me.txtCW.TabIndex = 63
        Me.txtCW.Text = "0"
        Me.txtCW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWD
        '
        Me.txtWD.BackColor = System.Drawing.Color.White
        Me.txtWD.Location = New System.Drawing.Point(715, 190)
        Me.txtWD.Name = "txtWD"
        Me.txtWD.ReadOnly = True
        Me.txtWD.Size = New System.Drawing.Size(228, 21)
        Me.txtWD.TabIndex = 61
        Me.txtWD.Text = "0"
        Me.txtWD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(594, 220)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 15)
        Me.Label14.TabIndex = 75
        Me.Label14.Text = "Credit"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(594, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 15)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "Debit"
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(830, 361)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(113, 23)
        Me.btnApprove.TabIndex = 67
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'txtRunningBal
        '
        Me.txtRunningBal.BackColor = System.Drawing.Color.White
        Me.txtRunningBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunningBal.Location = New System.Drawing.Point(715, 244)
        Me.txtRunningBal.Name = "txtRunningBal"
        Me.txtRunningBal.ReadOnly = True
        Me.txtRunningBal.Size = New System.Drawing.Size(228, 29)
        Me.txtRunningBal.TabIndex = 65
        Me.txtRunningBal.Text = "0.00"
        Me.txtRunningBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtParticulars
        '
        Me.txtParticulars.BackColor = System.Drawing.Color.White
        Me.txtParticulars.Location = New System.Drawing.Point(351, 324)
        Me.txtParticulars.Multiline = True
        Me.txtParticulars.Name = "txtParticulars"
        Me.txtParticulars.ReadOnly = True
        Me.txtParticulars.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtParticulars.Size = New System.Drawing.Size(228, 45)
        Me.txtParticulars.TabIndex = 58
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.Enabled = False
        Me.dtpDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateReceived.Location = New System.Drawing.Point(351, 270)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(228, 21)
        Me.dtpDateReceived.TabIndex = 55
        '
        'txtNo
        '
        Me.txtNo.BackColor = System.Drawing.Color.White
        Me.txtNo.Location = New System.Drawing.Point(351, 83)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.ReadOnly = True
        Me.txtNo.Size = New System.Drawing.Size(228, 21)
        Me.txtNo.TabIndex = 47
        '
        'txtYear
        '
        Me.txtYear.BackColor = System.Drawing.Color.White
        Me.txtYear.Location = New System.Drawing.Point(351, 216)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.ReadOnly = True
        Me.txtYear.Size = New System.Drawing.Size(228, 21)
        Me.txtYear.TabIndex = 52
        '
        'txtPPA
        '
        Me.txtPPA.BackColor = System.Drawing.Color.White
        Me.txtPPA.Location = New System.Drawing.Point(351, 137)
        Me.txtPPA.Multiline = True
        Me.txtPPA.Name = "txtPPA"
        Me.txtPPA.ReadOnly = True
        Me.txtPPA.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPPA.Size = New System.Drawing.Size(228, 46)
        Me.txtPPA.TabIndex = 50
        '
        'txtRefCode
        '
        Me.txtRefCode.BackColor = System.Drawing.Color.White
        Me.txtRefCode.Location = New System.Drawing.Point(351, 110)
        Me.txtRefCode.Name = "txtRefCode"
        Me.txtRefCode.ReadOnly = True
        Me.txtRefCode.Size = New System.Drawing.Size(228, 21)
        Me.txtRefCode.TabIndex = 49
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(227, 219)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 15)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Funding Year"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(592, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 15)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Running Balance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(227, 328)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Particulars"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(227, 275)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 15)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Date Received"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(227, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Reference No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(227, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 15)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "PPA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "AIP Ref. Code"
        '
        'lstPPA
        '
        Me.lstPPA.FormattingEnabled = True
        Me.lstPPA.ItemHeight = 15
        Me.lstPPA.Location = New System.Drawing.Point(12, 80)
        Me.lstPPA.Name = "lstPPA"
        Me.lstPPA.Size = New System.Drawing.Size(209, 304)
        Me.lstPPA.TabIndex = 74
        '
        'txtLNo
        '
        Me.txtLNo.BackColor = System.Drawing.Color.White
        Me.txtLNo.Location = New System.Drawing.Point(351, 189)
        Me.txtLNo.Name = "txtLNo"
        Me.txtLNo.ReadOnly = True
        Me.txtLNo.Size = New System.Drawing.Size(228, 21)
        Me.txtLNo.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(227, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Ledger No."
        '
        'gbSearchbar
        '
        Me.gbSearchbar.Controls.Add(Me.Label8)
        Me.gbSearchbar.Controls.Add(Me.txtSYear)
        Me.gbSearchbar.Controls.Add(Me.btnSearch)
        Me.gbSearchbar.Controls.Add(Me.txtSearch)
        Me.gbSearchbar.Controls.Add(Me.cboSearchby)
        Me.gbSearchbar.Controls.Add(Me.Label11)
        Me.gbSearchbar.Location = New System.Drawing.Point(12, 12)
        Me.gbSearchbar.Name = "gbSearchbar"
        Me.gbSearchbar.Size = New System.Drawing.Size(664, 61)
        Me.gbSearchbar.TabIndex = 87
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
        Me.cboSearchby.Items.AddRange(New Object() {"Control No. and Year", "All"})
        Me.cboSearchby.Location = New System.Drawing.Point(73, 27)
        Me.cboSearchby.Name = "cboSearchby"
        Me.cboSearchby.Size = New System.Drawing.Size(156, 23)
        Me.cboSearchby.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 15)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Search by"
        '
        'frmBudgetApproval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(960, 394)
        Me.Controls.Add(Me.gbSearchbar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLNo)
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
        Me.Controls.Add(Me.txtCW)
        Me.Controls.Add(Me.txtWD)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnApprove)
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
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBudgetApproval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Budget Approval"
        Me.gbSearchbar.ResumeLayout(False)
        Me.gbSearchbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCtrNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtPayee As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCW As System.Windows.Forms.TextBox
    Friend WithEvents txtWD As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents txtRunningBal As System.Windows.Forms.TextBox
    Friend WithEvents txtParticulars As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNo As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents txtPPA As System.Windows.Forms.TextBox
    Friend WithEvents txtRefCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstPPA As System.Windows.Forms.ListBox
    Friend WithEvents txtLNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbSearchbar As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSYear As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboSearchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
