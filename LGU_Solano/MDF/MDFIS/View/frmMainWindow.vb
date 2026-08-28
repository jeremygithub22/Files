Public Class frmMainWindow

    'Declare object class

    Dim objCUA As ctrUserAccount = New ctrUserAccount
    Dim objMUA As mUserAccount = New mUserAccount
    Dim objCul As ctrUserLog = New ctrUserLog
    Dim objMul As mUserLog = New mUserLog

    Private Sub frmMainWindow_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'Record to User Log
        objMul.setUID(objMUA.getUID)
        objMul.setActivity("Exit Application")
        objMul.setDateandTime(DateTime.Now)
        objCul.Add(objMul)

        End

    End Sub

    Private Sub tDT_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tDT.Tick
        lblDT.Text = DateTime.Now.ToString
    End Sub

    Private Sub frmMainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tDT.Enabled = True
    End Sub

    Private Sub btnUserAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserAccount.Click

        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'Administrator Privilege
        If objMUA.getUType <> "" And objMUA.getUType = "Administrator" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed User Account module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim UA As frmUserAccount = New frmUserAccount
            UA.UID = objMUA.getUID
            UA.ShowDialog()
        Else
            MsgBox("You have no right to use this module.", MsgBoxStyle.Critical, "MDFIS")
        End If
    End Sub

    Private Sub llLogout_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLogout.LinkClicked
        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'Record to User Log
        objMul.setUID(objMUA.getUID)
        objMul.setActivity("Successfully Log out")
        objMul.setDateandTime(DateTime.Now)
        objCul.Add(objMul)

        Me.Hide()
        Dim Log As frmLogin = New frmLogin
        Log.ShowDialog()
    End Sub


    Private Sub btnSummaryReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSummaryReport.Click

        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'MPDO and Administrator privilege
        If objMUA.getOffice = "MPDO" Or objMUA.getUType = "Administrator" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed Summary Report module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim SR As frmSummaryReport = New frmSummaryReport
            SR.UID = objMUA.getUID
            SR.ShowDialog()
        Else
            MsgBox("You have no right to use this module.", MsgBoxStyle.Critical, "MDFIS")
        End If
    End Sub

    Private Sub btnUserLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserLog.Click

        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'MPDO and Administrator Privilege
        If objMUA.getOffice = "MPDO" Or objMUA.getUType = "Administrator" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed User Log module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim ul As frmUserLogs = New frmUserLogs
            ul.UID = objMUA.getUID
            ul.ShowDialog()
        Else
            MsgBox("You have no right to use this module.", MsgBoxStyle.Critical, "MDFIS")
        End If
    End Sub

    Private Sub btnPPALedger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPPALedger.Click
        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'MPDO and Administrator privilege
        If objMUA.getOffice = "MPDO" Or objMUA.getUType = "Administrator" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed PPA Ledger module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim ledger As frmPPALedger = New frmPPALedger
            ledger.UID = objMUA.getUID
            ledger.Username = objMUA.getUsername
            ledger.ShowDialog()

            'MBO 
        ElseIf objMUA.getOffice = "MBO" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed PPA Ledger module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim ledger As frmPPALedger = New frmPPALedger
            ledger.UID = objMUA.getUID
            ledger.Username = objMUA.getUsername
            ledger.btnNew.Enabled = False
            ledger.btnEdit.Enabled = False
            ledger.btnSave.Enabled = False
            ledger.btnCancel.Enabled = False
            ledger.ShowDialog()
        Else
        End If
    End Sub

    Private Sub btnPPAFundingInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPPAFundingInfo.Click

        'Get Info of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'MPDO and Administrator Privilege
        If objMUA.getOffice = "MPDO" Or objMUA.getUType = "Administrator" Then

            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed PPA Funding Information module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim PPAFund As frmPPAFundingInfo = New frmPPAFundingInfo
            PPAFund.UID = objMUA.getUID
            PPAFund.Username = objMUA.getUsername
            PPAFund.ShowDialog()

            'MBO
        ElseIf objMUA.getOffice = "MBO" Then

            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed PPA Funding Information module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim PPAFund As frmPPAFundingInfo = New frmPPAFundingInfo
            PPAFund.UID = objMUA.getUID
            PPAFund.Username = objMUA.getUsername
            PPAFund.btnNew.Enabled = False
            PPAFund.btnEdit.Enabled = False
            PPAFund.btnSave.Enabled = False
            PPAFund.btnCancel.Enabled = False
            PPAFund.ShowDialog()
        Else
        End If
    End Sub

    Private Sub btnMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaintenance.Click
        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'Administrator Privilege
        If objMUA.getUType <> "" And objMUA.getUType = "Administrator" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed Maintenance module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim m As frmMaintenance = New frmMaintenance
            m.ShowDialog()
        Else
            MsgBox("You have no right to use this module.", MsgBoxStyle.Critical, "MDFIS")
        End If
    End Sub

    Private Sub btnSAAOBreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSAAOBreport.Click
        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'MBO and Administrator privilege
        If objMUA.getOffice = "MBO" Or objMUA.getUType = "Administrator" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed Status of Appropriations, Allotments and Obligations Report module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim SAAOB As frmSAAOB = New frmSAAOB
            SAAOB.UID = objMUA.getUID
            SAAOB.ShowDialog()
        Else
            MsgBox("You have no right to use this module.", MsgBoxStyle.Critical, "MDFIS")
        End If
    End Sub

    Private Sub btnBudgetApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBudgetApproval.Click
        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'MBO and Administrator privilege 
        If objMUA.getOffice = "MBO" Or objMUA.getUType = "Administrator" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed Budget Approval module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim budget As frmBudgetApproval = New frmBudgetApproval
            budget.ShowDialog()
        Else
            MsgBox("You have no right to use this module.", MsgBoxStyle.Critical, "MDFIS")
        End If
    End Sub

    Private Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
        'Get ID of User
        objMUA.setUsername(lblUser.Text)
        objCUA.Display(objMUA)

        'MPDO and Administrator privilege
        If objMUA.getOffice = "MPDO" Or objMUA.getUType = "Administrator" Then
            'Record to User Log
            objMul.setUID(objMUA.getUID)
            objMul.setActivity("Accessed List of Transaction module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            Dim list As frmListLedger = New frmListLedger
            list.UID = objMUA.getUID
            list.ShowDialog()
        Else
            MsgBox("You have no right to use this module.", MsgBoxStyle.Critical, "MDFIS")
        End If
    End Sub
End Class