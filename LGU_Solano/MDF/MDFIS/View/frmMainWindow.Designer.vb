<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainWindow
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainWindow))
        Me.btnPPAFundingInfo = New System.Windows.Forms.Button
        Me.btnSummaryReport = New System.Windows.Forms.Button
        Me.btnUserAccount = New System.Windows.Forms.Button
        Me.btnUserLog = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.llLogout = New System.Windows.Forms.LinkLabel
        Me.lblDT = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pbxIcon = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.pbxLogo = New System.Windows.Forms.PictureBox
        Me.tDT = New System.Windows.Forms.Timer(Me.components)
        Me.btnPPALedger = New System.Windows.Forms.Button
        Me.btnMaintenance = New System.Windows.Forms.Button
        Me.btnSAAOBreport = New System.Windows.Forms.Button
        Me.btnBudgetApproval = New System.Windows.Forms.Button
        Me.btnList = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.pbxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPPAFundingInfo
        '
        Me.btnPPAFundingInfo.Location = New System.Drawing.Point(12, 165)
        Me.btnPPAFundingInfo.Name = "btnPPAFundingInfo"
        Me.btnPPAFundingInfo.Size = New System.Drawing.Size(165, 23)
        Me.btnPPAFundingInfo.TabIndex = 2
        Me.btnPPAFundingInfo.Text = "PPA Funding Information"
        Me.btnPPAFundingInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPPAFundingInfo.UseVisualStyleBackColor = True
        '
        'btnSummaryReport
        '
        Me.btnSummaryReport.Location = New System.Drawing.Point(12, 252)
        Me.btnSummaryReport.Name = "btnSummaryReport"
        Me.btnSummaryReport.Size = New System.Drawing.Size(165, 23)
        Me.btnSummaryReport.TabIndex = 3
        Me.btnSummaryReport.Text = "Summary Report"
        Me.btnSummaryReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSummaryReport.UseVisualStyleBackColor = True
        '
        'btnUserAccount
        '
        Me.btnUserAccount.Location = New System.Drawing.Point(12, 339)
        Me.btnUserAccount.Name = "btnUserAccount"
        Me.btnUserAccount.Size = New System.Drawing.Size(165, 23)
        Me.btnUserAccount.TabIndex = 4
        Me.btnUserAccount.Text = "User Account"
        Me.btnUserAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUserAccount.UseVisualStyleBackColor = True
        '
        'btnUserLog
        '
        Me.btnUserLog.Location = New System.Drawing.Point(12, 368)
        Me.btnUserLog.Name = "btnUserLog"
        Me.btnUserLog.Size = New System.Drawing.Size(165, 23)
        Me.btnUserLog.TabIndex = 5
        Me.btnUserLog.Text = "User Log"
        Me.btnUserLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUserLog.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.llLogout)
        Me.Panel1.Controls.Add(Me.lblDT)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pbxIcon)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.pbxLogo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 141)
        Me.Panel1.TabIndex = 6
        '
        'llLogout
        '
        Me.llLogout.AutoSize = True
        Me.llLogout.Location = New System.Drawing.Point(936, 113)
        Me.llLogout.Name = "llLogout"
        Me.llLogout.Size = New System.Drawing.Size(60, 15)
        Me.llLogout.TabIndex = 7
        Me.llLogout.TabStop = True
        Me.llLogout.Text = "LOG OUT"
        '
        'lblDT
        '
        Me.lblDT.AutoSize = True
        Me.lblDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDT.Location = New System.Drawing.Point(437, 113)
        Me.lblDT.Name = "lblDT"
        Me.lblDT.Size = New System.Drawing.Size(34, 15)
        Me.lblDT.TabIndex = 6
        Me.lblDT.Text = "XXX"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(343, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Date and Time"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(154, 113)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(34, 15)
        Me.lblUser.TabIndex = 4
        Me.lblUser.Text = "XXX"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(89, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Welcome"
        '
        'pbxIcon
        '
        Me.pbxIcon.Image = CType(resources.GetObject("pbxIcon.Image"), System.Drawing.Image)
        Me.pbxIcon.Location = New System.Drawing.Point(17, 78)
        Me.pbxIcon.Name = "pbxIcon"
        Me.pbxIcon.Size = New System.Drawing.Size(66, 50)
        Me.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxIcon.TabIndex = 2
        Me.pbxIcon.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Goudy Stout", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 26)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(831, 37)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Municipal Development Fund"
        '
        'pbxLogo
        '
        Me.pbxLogo.Image = CType(resources.GetObject("pbxLogo.Image"), System.Drawing.Image)
        Me.pbxLogo.Location = New System.Drawing.Point(883, 12)
        Me.pbxLogo.Name = "pbxLogo"
        Me.pbxLogo.Size = New System.Drawing.Size(113, 86)
        Me.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxLogo.TabIndex = 0
        Me.pbxLogo.TabStop = False
        '
        'tDT
        '
        '
        'btnPPALedger
        '
        Me.btnPPALedger.Location = New System.Drawing.Point(12, 194)
        Me.btnPPALedger.Name = "btnPPALedger"
        Me.btnPPALedger.Size = New System.Drawing.Size(165, 23)
        Me.btnPPALedger.TabIndex = 7
        Me.btnPPALedger.Text = "PPA Ledger"
        Me.btnPPALedger.UseVisualStyleBackColor = True
        '
        'btnMaintenance
        '
        Me.btnMaintenance.Location = New System.Drawing.Point(12, 397)
        Me.btnMaintenance.Name = "btnMaintenance"
        Me.btnMaintenance.Size = New System.Drawing.Size(165, 23)
        Me.btnMaintenance.TabIndex = 8
        Me.btnMaintenance.Text = "Maintenance"
        Me.btnMaintenance.UseVisualStyleBackColor = True
        '
        'btnSAAOBreport
        '
        Me.btnSAAOBreport.Location = New System.Drawing.Point(12, 281)
        Me.btnSAAOBreport.Name = "btnSAAOBreport"
        Me.btnSAAOBreport.Size = New System.Drawing.Size(165, 23)
        Me.btnSAAOBreport.TabIndex = 9
        Me.btnSAAOBreport.Text = "SAAOB Report"
        Me.btnSAAOBreport.UseVisualStyleBackColor = True
        '
        'btnBudgetApproval
        '
        Me.btnBudgetApproval.Location = New System.Drawing.Point(12, 223)
        Me.btnBudgetApproval.Name = "btnBudgetApproval"
        Me.btnBudgetApproval.Size = New System.Drawing.Size(165, 23)
        Me.btnBudgetApproval.TabIndex = 10
        Me.btnBudgetApproval.Text = "Budget Approval"
        Me.btnBudgetApproval.UseVisualStyleBackColor = True
        '
        'btnList
        '
        Me.btnList.Location = New System.Drawing.Point(12, 310)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(165, 23)
        Me.btnList.TabIndex = 11
        Me.btnList.Text = "List of Transaction"
        Me.btnList.UseVisualStyleBackColor = True
        '
        'frmMainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1008, 507)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.btnBudgetApproval)
        Me.Controls.Add(Me.btnSAAOBreport)
        Me.Controls.Add(Me.btnMaintenance)
        Me.Controls.Add(Me.btnPPALedger)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnUserLog)
        Me.Controls.Add(Me.btnUserAccount)
        Me.Controls.Add(Me.btnSummaryReport)
        Me.Controls.Add(Me.btnPPAFundingInfo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "frmMainWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Municipal Development Fund Information System"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPPAFundingInfo As System.Windows.Forms.Button
    Friend WithEvents btnSummaryReport As System.Windows.Forms.Button
    Friend WithEvents btnUserAccount As System.Windows.Forms.Button
    Friend WithEvents btnUserLog As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pbxIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblDT As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents llLogout As System.Windows.Forms.LinkLabel
    Friend WithEvents tDT As System.Windows.Forms.Timer
    Friend WithEvents btnPPALedger As System.Windows.Forms.Button
    Friend WithEvents btnMaintenance As System.Windows.Forms.Button
    Friend WithEvents btnSAAOBreport As System.Windows.Forms.Button
    Friend WithEvents btnBudgetApproval As System.Windows.Forms.Button
    Friend WithEvents btnList As System.Windows.Forms.Button
End Class
