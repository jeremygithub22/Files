Public Class frmBudgetApproval

    'Declare variables and Instantiate object class
    Dim objCR As ctrPPAFundingInfo = New ctrPPAFundingInfo
    Dim objMr As mPPAFundingInfo = New mPPAFundingInfo
    Dim objCul As ctrUserLog = New ctrUserLog
    Dim objMul As mUserLog = New mUserLog
    Dim objMppal As mPPALedger = New mPPALedger
    Dim objCppal As ctrPPALedger = New ctrPPALedger
    Dim objCUA As ctrUserAccount = New ctrUserAccount
    Dim objMUA As mUserAccount = New mUserAccount
    Dim objCsum As ctrSAAOB = New ctrSAAOB
    Dim objMsum As mSAAOB = New mSAAOB
    Dim LPPAID As String
    Dim Appropriation, Obligation, UnobligatedAllotment, TAppropriation, TObligation, TUnobligatedAllotment As Double
    Public UID As String
    Public Username As String
    Dim dt As DataTable
    Dim dr As DataRow

    Private Sub ClearAll()
        dtpDateReceived.Value = DateTime.Now
        txtCW.Text = "0"
        txtLocation.Clear()
        txtParticulars.Clear()
        txtPayee.Clear()
        txtProjectName.Clear()
        txtRemarks.Clear()
        txtWD.Text = "0"
        txtRunningBal.Text = "0.00"
        txtCtrNo.Clear()
        txtNo.Clear()
        txtPPA.Clear()
        txtLNo.Clear()
        txtRefCode.Clear()
        txtYear.Clear()
    End Sub

    Private Sub lstPPA_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPPA.SelectedValueChanged
        If lstPPA.SelectedIndex <> -1 Then

            objMppal.setLPPAID(lstPPA.SelectedValue.ToString())
            objCppal.DisplayPending(objMppal)

            'Display Details
            txtCW.Text = objMppal.getCredit()
            txtCtrNo.Text = objMppal.getCtrNo()
            dtpDateReceived.Text = objMppal.getDateReceived()
            txtWD.Text = objMppal.getDebit()
            txtLocation.Text = objMppal.getLocation()
            txtParticulars.Text = objMppal.getParticulars()
            txtPayee.Text = objMppal.getPayee()
            txtProjectName.Text = objMppal.getProjectName()
            txtRemarks.Text = objMppal.getRemarks()
            txtRunningBal.Text = objMppal.getRunningBal()
            txtLNo.Text = objMppal.getLPPAID

            'Display No.
            txtNo.Text = objMppal.getNo

            'Display PPA and Ref. Code and Funding Year
            objMr.setNo(txtNo.Text)
            objCR.Display(objMr)

            txtPPA.Text = objMr.getPPA
            txtYear.Text = objMr.getYear
            txtRefCode.Text = lstPPA.Text            

            'Display All Transacation
            objMppal.setDateReceived(String.Empty)
            objMppal.setCredit(String.Empty)
            objMppal.setDebit(String.Empty)
            objMppal.setParticulars(String.Empty)
            objMppal.setNo(String.Empty)
            objMppal.setRunningBal(String.Empty)

            objMppal.setNo(txtNo.Text)

            If objCppal.Display(objMppal, False) = True Then
                'dgvList.DataSource = objMppal.getData
            End If
        End If
    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If txtNo.Text <> "" Then
            If MessageBox.Show("Are you sure, you want to approve this transaction?", "Budget Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objMppal.setLPPAID(txtLNo.Text)
                If objCppal.Approve(objMppal, False) = True Then

                    'Get Balance
                    Try
                        objMsum.setNo(txtNo.Text)
                        objCsum.Getbal(objMsum)
                        Appropriation = Double.Parse(objMsum.getAppropriation)
                        Obligation = Double.Parse(objMsum.getObligation)
                        UnobligatedAllotment = Double.Parse(objMsum.getUnobligatedAllotment)
                    Catch
                    End Try

                    Try

                        'Debit Computation
                        If txtWD.Text <> "-" Then
                            TAppropriation = (Appropriation * 1) + (Double.Parse(txtWD.Text) * 1)
                            TObligation = (Obligation * 1) + 0
                        End If

                        'Credit Computation
                        If txtCW.Text <> "-" Then
                            TObligation = (Obligation * 1) + (Double.Parse(txtCW.Text) * 1)
                            TAppropriation = (Appropriation * 1) + 0
                        End If
                    Catch
                    End Try

                    'Update to SAAOB
                    objMsum.setNo(txtNo.Text)
                    objMsum.setAppropriation(TAppropriation.ToString())
                    objMsum.setObligation(TObligation.ToString())
                    objMsum.setUnobligatedAllotment(txtRunningBal.Text)

                    objCsum.UpdateSum(objMsum)

                    'Record to User Log
                    objMul.setUID(UID)
                    objMul.setActivity("Approved transaction to Reference No. " + txtNo.Text + " from Budget Approval module")
                    objMul.setDateandTime(DateTime.Now)
                    objCul.Add(objMul)

                    objMul.setUID(UID)
                    objMul.setActivity("Updated Reference No. " + txtNo.Text + " from SAAOB")
                    objMul.setDateandTime(DateTime.Now)
                    objCul.Add(objMul)
                End If
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If cboSearchby.Text = "Control No. and Year" Then

            objMppal.setCtrNo(String.Empty)
            objMppal.setCtrNo(txtSearch.Text)

            If objCppal.DisplayPending(objMppal, False, txtSYear.Text) = True Then

                lstPPA.DisplayMember = "AIPRF"
                lstPPA.ValueMember = "LPPAID"
                lstPPA.DataSource = objMppal.getData

            Else
                dt = New DataTable
                lstPPA.DataSource = dt
                ClearAll()
                MsgBox("Record not found", MsgBoxStyle.Critical, "Budget Approval")
            End If

        ElseIf cboSearchby.Text = "All" Then

            objMppal.setBStatus(String.Empty)
            objMppal.setBStatus("All")

            If objCppal.DisplayPending(objMppal, False, "") = True Then

                lstPPA.DisplayMember = "AIPRF"
                lstPPA.ValueMember = "LPPAID"
                lstPPA.DataSource = objMppal.getData

            Else
                dt = New DataTable
                lstPPA.DataSource = dt
                ClearAll()
                MsgBox("Record not found", MsgBoxStyle.Critical, "Budget Approval")
            End If

        Else
        End If
    End Sub

    Private Sub cboSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchby.SelectedIndexChanged
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtSYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class