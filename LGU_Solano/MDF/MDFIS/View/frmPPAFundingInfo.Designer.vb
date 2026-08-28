<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPPAFundingInfo
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
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.cboSearchby = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstPPA = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtNo = New System.Windows.Forms.TextBox
        Me.dtpDateReceived = New System.Windows.Forms.DateTimePicker
        Me.txtFunding = New System.Windows.Forms.TextBox
        Me.txtObligatedFund = New System.Windows.Forms.TextBox
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtWhole = New System.Windows.Forms.TextBox
        Me.mtxtDecimal = New System.Windows.Forms.MaskedTextBox
        Me.txtRefCode = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPPA = New System.Windows.Forms.TextBox
        Me.gbSearchbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSearchbar
        '
        Me.gbSearchbar.Controls.Add(Me.txtYear)
        Me.gbSearchbar.Controls.Add(Me.Label4)
        Me.gbSearchbar.Controls.Add(Me.btnSearch)
        Me.gbSearchbar.Controls.Add(Me.txtSearch)
        Me.gbSearchbar.Controls.Add(Me.cboSearchby)
        Me.gbSearchbar.Controls.Add(Me.Label1)
        Me.gbSearchbar.Location = New System.Drawing.Point(12, 12)
        Me.gbSearchbar.Name = "gbSearchbar"
        Me.gbSearchbar.Size = New System.Drawing.Size(692, 59)
        Me.gbSearchbar.TabIndex = 0
        Me.gbSearchbar.TabStop = False
        Me.gbSearchbar.Text = "Search"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(502, 25)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(100, 21)
        Me.txtYear.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(464, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Year"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(608, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(238, 25)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(220, 21)
        Me.txtSearch.TabIndex = 0
        '
        'cboSearchby
        '
        Me.cboSearchby.FormattingEnabled = True
        Me.cboSearchby.Items.AddRange(New Object() {"Reference No.", "PPA and Year", "Year", "All"})
        Me.cboSearchby.Location = New System.Drawing.Point(73, 23)
        Me.cboSearchby.Name = "cboSearchby"
        Me.cboSearchby.Size = New System.Drawing.Size(159, 23)
        Me.cboSearchby.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search by"
        '
        'lstPPA
        '
        Me.lstPPA.FormattingEnabled = True
        Me.lstPPA.ItemHeight = 15
        Me.lstPPA.Location = New System.Drawing.Point(12, 77)
        Me.lstPPA.Name = "lstPPA"
        Me.lstPPA.Size = New System.Drawing.Size(208, 319)
        Me.lstPPA.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(231, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Reference No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Date Received"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(231, 242)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 15)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Funding Year"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(231, 323)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 15)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Budget"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(231, 147)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "AIP Ref. Code"
        '
        'txtNo
        '
        Me.txtNo.Location = New System.Drawing.Point(345, 90)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Size = New System.Drawing.Size(219, 21)
        Me.txtNo.TabIndex = 4
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateReceived.Location = New System.Drawing.Point(345, 117)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(219, 21)
        Me.dtpDateReceived.TabIndex = 5
        '
        'txtFunding
        '
        Me.txtFunding.Location = New System.Drawing.Point(345, 239)
        Me.txtFunding.Name = "txtFunding"
        Me.txtFunding.Size = New System.Drawing.Size(220, 21)
        Me.txtFunding.TabIndex = 8
        '
        'txtObligatedFund
        '
        Me.txtObligatedFund.BackColor = System.Drawing.Color.White
        Me.txtObligatedFund.Location = New System.Drawing.Point(345, 320)
        Me.txtObligatedFund.Name = "txtObligatedFund"
        Me.txtObligatedFund.ReadOnly = True
        Me.txtObligatedFund.Size = New System.Drawing.Size(220, 21)
        Me.txtObligatedFund.TabIndex = 11
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(626, 93)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(626, 122)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(626, 151)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(626, 180)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(231, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 15)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Whole Amount"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(231, 296)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 15)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Decimal Amount"
        '
        'txtWhole
        '
        Me.txtWhole.Location = New System.Drawing.Point(345, 266)
        Me.txtWhole.Name = "txtWhole"
        Me.txtWhole.Size = New System.Drawing.Size(220, 21)
        Me.txtWhole.TabIndex = 9
        '
        'mtxtDecimal
        '
        Me.mtxtDecimal.Location = New System.Drawing.Point(346, 293)
        Me.mtxtDecimal.Mask = ".00"
        Me.mtxtDecimal.Name = "mtxtDecimal"
        Me.mtxtDecimal.Size = New System.Drawing.Size(219, 21)
        Me.mtxtDecimal.TabIndex = 10
        Me.mtxtDecimal.Text = "00"
        '
        'txtRefCode
        '
        Me.txtRefCode.Location = New System.Drawing.Point(345, 144)
        Me.txtRefCode.Name = "txtRefCode"
        Me.txtRefCode.Size = New System.Drawing.Size(219, 21)
        Me.txtRefCode.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(231, 174)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 15)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "PPA"
        '
        'txtPPA
        '
        Me.txtPPA.Location = New System.Drawing.Point(345, 171)
        Me.txtPPA.Multiline = True
        Me.txtPPA.Name = "txtPPA"
        Me.txtPPA.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPPA.Size = New System.Drawing.Size(219, 62)
        Me.txtPPA.TabIndex = 7
        '
        'frmPPAFundingInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(715, 407)
        Me.Controls.Add(Me.txtPPA)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.mtxtDecimal)
        Me.Controls.Add(Me.txtWhole)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtRefCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.txtObligatedFund)
        Me.Controls.Add(Me.txtFunding)
        Me.Controls.Add(Me.dtpDateReceived)
        Me.Controls.Add(Me.txtNo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lstPPA)
        Me.Controls.Add(Me.gbSearchbar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPPAFundingInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PPA Funding Information"
        Me.gbSearchbar.ResumeLayout(False)
        Me.gbSearchbar.PerformLayout()
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
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFunding As System.Windows.Forms.TextBox
    Friend WithEvents txtObligatedFund As System.Windows.Forms.TextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtWhole As System.Windows.Forms.TextBox
    Friend WithEvents mtxtDecimal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtRefCode As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPPA As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
