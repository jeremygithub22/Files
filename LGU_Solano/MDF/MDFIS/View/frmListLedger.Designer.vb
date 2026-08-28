<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListLedger
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
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.gbSearchbar = New System.Windows.Forms.GroupBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.cboSearchby = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.rvDisplay = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dsReport = New MDFIS.dsReport
        Me.tblLedgerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlTop.SuspendLayout()
        Me.gbSearchbar.SuspendLayout()
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblLedgerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.gbSearchbar.Controls.Add(Me.dtpDate)
        Me.gbSearchbar.Controls.Add(Me.cboSearchby)
        Me.gbSearchbar.Controls.Add(Me.Label3)
        Me.gbSearchbar.Controls.Add(Me.btnSearch)
        Me.gbSearchbar.Controls.Add(Me.Label1)
        Me.gbSearchbar.Location = New System.Drawing.Point(12, 12)
        Me.gbSearchbar.Name = "gbSearchbar"
        Me.gbSearchbar.Size = New System.Drawing.Size(538, 60)
        Me.gbSearchbar.TabIndex = 0
        Me.gbSearchbar.TabStop = False
        Me.gbSearchbar.Text = "Search"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(252, 25)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(200, 21)
        Me.dtpDate.TabIndex = 7
        '
        'cboSearchby
        '
        Me.cboSearchby.FormattingEnabled = True
        Me.cboSearchby.Items.AddRange(New Object() {"Date", "Month"})
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
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(458, 23)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(210, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date:"
        '
        'rvDisplay
        '
        Me.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsReport_tblLedger"
        ReportDataSource1.Value = Me.tblLedgerBindingSource
        Me.rvDisplay.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvDisplay.LocalReport.ReportEmbeddedResource = "MDFIS.LedgerList.rdlc"
        Me.rvDisplay.Location = New System.Drawing.Point(0, 94)
        Me.rvDisplay.Name = "rvDisplay"
        Me.rvDisplay.Size = New System.Drawing.Size(1008, 636)
        Me.rvDisplay.TabIndex = 2
        '
        'dsReport
        '
        Me.dsReport.DataSetName = "dsReport"
        Me.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tblLedgerBindingSource
        '
        Me.tblLedgerBindingSource.DataMember = "tblLedger"
        Me.tblLedgerBindingSource.DataSource = Me.dsReport
        '
        'frmListLedger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.rvDisplay)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmListLedger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List of Transaction"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTop.ResumeLayout(False)
        Me.gbSearchbar.ResumeLayout(False)
        Me.gbSearchbar.PerformLayout()
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblLedgerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents gbSearchbar As System.Windows.Forms.GroupBox
    Friend WithEvents cboSearchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents rvDisplay As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblLedgerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsReport As MDFIS.dsReport
End Class
