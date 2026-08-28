<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLedger
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
        Me.rvDisplay = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dsReport = New MDFIS.dsReport
        Me.tblLedgerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblLedgerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvDisplay
        '
        Me.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsReport_tblLedger"
        ReportDataSource1.Value = Me.tblLedgerBindingSource
        Me.rvDisplay.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvDisplay.LocalReport.ReportEmbeddedResource = "MDFIS.LedgerReport.rdlc"
        Me.rvDisplay.Location = New System.Drawing.Point(0, 0)
        Me.rvDisplay.Name = "rvDisplay"
        Me.rvDisplay.Size = New System.Drawing.Size(1008, 730)
        Me.rvDisplay.TabIndex = 0
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
        'frmLedger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.rvDisplay)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLedger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblLedgerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvDisplay As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblLedgerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsReport As MDFIS.dsReport
End Class
