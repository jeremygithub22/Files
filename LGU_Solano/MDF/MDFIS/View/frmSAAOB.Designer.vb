<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSAAOB
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.tblsummaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsReport = New MDFIS.dsReport
        Me.tblTotalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.gbSearchbar = New System.Windows.Forms.GroupBox
        Me.cboSearchby = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPPA = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rvDisplay = New Microsoft.Reporting.WinForms.ReportViewer
        Me.btnAdd = New System.Windows.Forms.Button
        CType(Me.tblsummaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblTotalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        Me.gbSearchbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblsummaryBindingSource
        '
        Me.tblsummaryBindingSource.DataMember = "tblsummary"
        Me.tblsummaryBindingSource.DataSource = Me.dsReport
        '
        'dsReport
        '
        Me.dsReport.DataSetName = "dsReport"
        Me.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tblTotalBindingSource
        '
        Me.tblTotalBindingSource.DataMember = "tblTotal"
        Me.tblTotalBindingSource.DataSource = Me.dsReport
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.gbSearchbar)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1008, 94)
        Me.pnlTop.TabIndex = 1
        '
        'gbSearchbar
        '
        Me.gbSearchbar.Controls.Add(Me.btnAdd)
        Me.gbSearchbar.Controls.Add(Me.cboSearchby)
        Me.gbSearchbar.Controls.Add(Me.Label3)
        Me.gbSearchbar.Controls.Add(Me.txtPPA)
        Me.gbSearchbar.Controls.Add(Me.Label2)
        Me.gbSearchbar.Controls.Add(Me.btnSearch)
        Me.gbSearchbar.Controls.Add(Me.txtYear)
        Me.gbSearchbar.Controls.Add(Me.Label1)
        Me.gbSearchbar.Location = New System.Drawing.Point(12, 12)
        Me.gbSearchbar.Name = "gbSearchbar"
        Me.gbSearchbar.Size = New System.Drawing.Size(851, 60)
        Me.gbSearchbar.TabIndex = 0
        Me.gbSearchbar.TabStop = False
        Me.gbSearchbar.Text = "Search"
        '
        'cboSearchby
        '
        Me.cboSearchby.FormattingEnabled = True
        Me.cboSearchby.Items.AddRange(New Object() {"Year", "Year and PPA"})
        Me.cboSearchby.Location = New System.Drawing.Point(73, 24)
        Me.cboSearchby.Name = "cboSearchby"
        Me.cboSearchby.Size = New System.Drawing.Size(131, 23)
        Me.cboSearchby.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Search by"
        '
        'txtPPA
        '
        Me.txtPPA.Location = New System.Drawing.Point(448, 24)
        Me.txtPPA.Name = "txtPPA"
        Me.txtPPA.Size = New System.Drawing.Size(199, 21)
        Me.txtPPA.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(377, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Enter PPA:"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(653, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(283, 24)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(88, 21)
        Me.txtYear.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(210, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Year:"
        '
        'rvDisplay
        '
        Me.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsReport_tblsummary"
        ReportDataSource1.Value = Me.tblsummaryBindingSource
        ReportDataSource2.Name = "dsReport_tblTotal"
        ReportDataSource2.Value = Me.tblTotalBindingSource
        Me.rvDisplay.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvDisplay.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvDisplay.LocalReport.ReportEmbeddedResource = "MDFIS.SAAOB.rdlc"
        Me.rvDisplay.Location = New System.Drawing.Point(0, 94)
        Me.rvDisplay.Name = "rvDisplay"
        Me.rvDisplay.Size = New System.Drawing.Size(1008, 636)
        Me.rvDisplay.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(734, 24)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(105, 23)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add Other Info."
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'frmSAAOB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.rvDisplay)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSAAOB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Status of Appropriations, Allotments and Obligations Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tblsummaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblTotalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.gbSearchbar.ResumeLayout(False)
        Me.gbSearchbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents gbSearchbar As System.Windows.Forms.GroupBox
    Friend WithEvents cboSearchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPPA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rvDisplay As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblsummaryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsReport As MDFIS.dsReport
    Friend WithEvents tblTotalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
