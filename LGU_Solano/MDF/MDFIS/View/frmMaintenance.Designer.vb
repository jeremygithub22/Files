<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintenance))
        Me.ofdRestore = New System.Windows.Forms.OpenFileDialog
        Me.sfdBackup = New System.Windows.Forms.SaveFileDialog
        Me.pBR = New System.Diagnostics.Process
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.btnRestore = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.pbxImage = New System.Windows.Forms.PictureBox
        Me.btnBackup = New System.Windows.Forms.Button
        Me.groupBox1.SuspendLayout()
        CType(Me.pbxImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofdRestore
        '
        Me.ofdRestore.Filter = "SQL Files|*.sql"
        '
        'sfdBackup
        '
        Me.sfdBackup.Filter = "All Files|*.*"
        '
        'pBR
        '
        Me.pBR.StartInfo.Domain = ""
        Me.pBR.StartInfo.LoadUserProfile = False
        Me.pBR.StartInfo.Password = Nothing
        Me.pBR.StartInfo.StandardErrorEncoding = Nothing
        Me.pBR.StartInfo.StandardOutputEncoding = Nothing
        Me.pBR.StartInfo.UserName = ""
        Me.pBR.SynchronizingObject = Me
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.txtPath)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.btnRestore)
        Me.groupBox1.Controls.Add(Me.btnBrowse)
        Me.groupBox1.Location = New System.Drawing.Point(12, 84)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(425, 122)
        Me.groupBox1.TabIndex = 5
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Restore"
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(9, 49)
        Me.txtPath.Multiline = True
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPath.Size = New System.Drawing.Size(306, 47)
        Me.txtPath.TabIndex = 3
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 31)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(82, 15)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Location Path"
        '
        'btnRestore
        '
        Me.btnRestore.Image = CType(resources.GetObject("btnRestore.Image"), System.Drawing.Image)
        Me.btnRestore.Location = New System.Drawing.Point(332, 77)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(87, 39)
        Me.btnRestore.TabIndex = 1
        Me.btnRestore.Text = "Restore"
        Me.btnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(332, 32)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(87, 39)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'pbxImage
        '
        Me.pbxImage.Image = CType(resources.GetObject("pbxImage.Image"), System.Drawing.Image)
        Me.pbxImage.Location = New System.Drawing.Point(12, 12)
        Me.pbxImage.Name = "pbxImage"
        Me.pbxImage.Size = New System.Drawing.Size(64, 57)
        Me.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxImage.TabIndex = 4
        Me.pbxImage.TabStop = False
        '
        'btnBackup
        '
        Me.btnBackup.Image = CType(resources.GetObject("btnBackup.Image"), System.Drawing.Image)
        Me.btnBackup.Location = New System.Drawing.Point(344, 12)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(87, 39)
        Me.btnBackup.TabIndex = 3
        Me.btnBackup.Text = "Backup"
        Me.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'frmMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(449, 218)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.pbxImage)
        Me.Controls.Add(Me.btnBackup)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintenance"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.pbxImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ofdRestore As System.Windows.Forms.OpenFileDialog
    Private WithEvents sfdBackup As System.Windows.Forms.SaveFileDialog
    Private WithEvents pBR As System.Diagnostics.Process
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtPath As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnRestore As System.Windows.Forms.Button
    Private WithEvents btnBrowse As System.Windows.Forms.Button
    Private WithEvents pbxImage As System.Windows.Forms.PictureBox
    Private WithEvents btnBackup As System.Windows.Forms.Button
End Class
