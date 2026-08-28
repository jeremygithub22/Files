Public Class frmPPALedger

    'Declare variables and Instantiate object class
    Dim Transaction As String
    Dim objCR As ctrPPAFundingInfo = New ctrPPAFundingInfo
    Dim objMr As mPPAFundingInfo = New mPPAFundingInfo
    Dim objCsum As ctrSummary = New ctrSummary
    Dim objMsum As mSummary = New mSummary
    Dim objCul As ctrUserLog = New ctrUserLog
    Dim objMul As mUserLog = New mUserLog
    Dim objMppal As mPPALedger = New mPPALedger
    Dim objCppal As ctrPPALedger = New ctrPPALedger
    Dim objCUA As ctrUserAccount = New ctrUserAccount
    Dim objMUA As mUserAccount = New mUserAccount
    Public UID As String
    Public Username As String
    Dim dt As DataTable
    Dim Bal, Cr, Dr, TBal, TCr, TDr As String

    Private Sub cboSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchby.SelectedIndexChanged
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub ClearAll()
        dtpDateReceived.Value = DateTime.Now
        txtCW.Text = "0"
        txtLocation.Clear()
        txtParticulars.Clear()
        txtPayee.Clear()
        txtProjectName.Clear()
        txtRemarks.Clear()
        txtWD.Text = "0"
        mtxtCD.Text = "."
        mtxtDD.Text = "."
        txtRunningBal.Text = "0.00"
        txtCtrNo.Clear()
        cboGSO.ResetText()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Transaction = "New"
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        ClearAll()
        txtCtrNo.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Transaction = "New" Then

            If MessageBox.Show("Are you sure, you want to add this transaction?", "PPA Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                'Debit Transaction
                If txtWD.Text <> "" And mtxtDD.Text <> "." Then
                    objMppal.setCredit("-")
                    objMppal.setDateReceived(dtpDateReceived.Value.ToShortDateString)
                    objMppal.setDebit(txtWD.Text + mtxtDD.Text)
                    objMppal.setParticulars(txtParticulars.Text)
                    objMppal.setNo(txtNo.Text)
                    objMppal.setRunningBal(txtRunningBal.Text)
                    objMppal.setLocation(txtLocation.Text)
                    objMppal.setPayee(txtPayee.Text)
                    objMppal.setProjectName(txtProjectName.Text)
                    objMppal.setRemarks(txtRemarks.Text)
                    objMppal.setCtrNo(txtCtrNo.Text)
                    objMppal.setGSO(cboGSO.Text)
                    objMppal.setBStatus("Pending")

                    'Credit Transaction
                ElseIf txtCW.Text <> "" And mtxtCD.Text <> "." Then
                    objMppal.setCredit(txtCW.Text + mtxtCD.Text)
                    objMppal.setDateReceived(dtpDateReceived.Value.ToShortDateString)
                    objMppal.setDebit("-")
                    objMppal.setParticulars(txtParticulars.Text)
                    objMppal.setNo(txtNo.Text)
                    objMppal.setRunningBal(txtRunningBal.Text)
                    objMppal.setLocation(txtLocation.Text)
                    objMppal.setPayee(txtPayee.Text)
                    objMppal.setProjectName(txtProjectName.Text)
                    objMppal.setRemarks(txtRemarks.Text)
                    objMppal.setCtrNo(txtCtrNo.Text)
                    objMppal.setGSO(cboGSO.Text)
                    objMppal.setBStatus("Pending")
                Else
                End If

                If objCppal.AddL(objMppal, False) = True Then

                    Bal = TBal
                    Dr = TDr
                    Cr = TCr

                    'Record to User Log
                    objMul.setUID(UID)
                    objMul.setActivity("Added new transaction to Reference No. " + txtNo.Text + " from PPA Ledger module")
                    objMul.setDateandTime(DateTime.Now)
                    objCul.Add(objMul)

                    objMul.setUID(UID)
                    objMul.setActivity("Updated Reference No. " + txtNo.Text + " from Summary")
                    objMul.setDateandTime(DateTime.Now)
                    objCul.Add(objMul)

                    'Update Summary
                    objMsum.setNo(txtNo.Text)
                    objMsum.setAmount(Dr)
                    objMsum.setExpenditure(Cr)
                    objMsum.setBalance(Bal)

                    objCsum.UpdateSum(objMsum)

                    'Dispaly All
                    objMppal.setNo(txtNo.Text)
                    If objCppal.Display(objMppal, False) = True Then
                        dgvList.DataSource = objMppal.getData
                    End If

                    'Clear All
                    ClearAll()

                    btnNew.Enabled = True
                    btnSave.Enabled = False
                    btnEdit.Enabled = False
                    dgvList.Enabled = True
                End If
            Else
            End If
        ElseIf Transaction = "Edit" Then
            Try
                If MessageBox.Show("Are you sure, you want to update this transaction?", "PPA Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    objMppal.setDateReceived(dtpDateReceived.Value.ToShortDateString)
                    objMppal.setParticulars(txtParticulars.Text)
                    objMppal.setNo(txtNo.Text)
                    objMppal.setLocation(txtLocation.Text)
                    objMppal.setPayee(txtPayee.Text)
                    objMppal.setProjectName(txtProjectName.Text)
                    objMppal.setRemarks(txtRemarks.Text)
                    objMppal.setCtrNo(txtCtrNo.Text)
                    objMppal.setLPPAID(dgvList.SelectedRows(0).Cells("No.").Value.ToString)

                    If objCppal.UpdateL(objMppal, False) = True Then

                        'Record to User Log
                        objMul.setUID(UID)
                        objMul.setActivity("Updated transaction to Reference No. " + txtNo.Text + " from PPA Ledger module")
                        objMul.setDateandTime(DateTime.Now)
                        objCul.Add(objMul)

                        'Dispaly All
                        objMppal.setNo(txtNo.Text)
                        If objCppal.Display(objMppal, False) = True Then
                            dgvList.DataSource = objMppal.getData
                        End If

                        btnNew.Enabled = True
                        btnSave.Enabled = False
                        btnEdit.Enabled = False
                        dgvList.Enabled = True
                    End If
                End If
            Catch
            End Try
        Else
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try
            If cboSearchby.Text = "PPA and Year" Then

                If txtSearch.Text <> "" And txtSYear.Text <> "" Then
                    objMr.setNo(String.Empty)
                    objMr.setDateReceived(String.Empty)
                    objMr.setAIPRC(String.Empty)
                    objMr.setPPA(String.Empty)
                    objMr.setYear(String.Empty)
                    objMr.setBudget(String.Empty)

                    objMr.setPPA(txtSearch.Text)
                    objMr.setYear(txtSYear.Text)

                    objCppal.Search(objMr)

                    If objMr.getStatus <> False Then
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMr.getData
                    End If
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        dt = New DataTable
                        dt.Clear()
                        dgvList.DataSource = dt
                        txtNo.Clear()
                        txtRefCode.Clear()
                        txtYear.Clear()
                        txtPPA.Clear()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                    End If
                Else
                    ClearAll()
                    dt = New DataTable
                    dt.Clear()
                    dgvList.DataSource = dt
                    lstPPA.DataSource = dt
                    txtNo.Clear()
                    txtRefCode.Clear()
                    txtYear.Clear()
                    txtPPA.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                End If
            ElseIf cboSearchby.Text = "Year" Then

                If txtSYear.Text <> "" Then
                    objMr.setNo(String.Empty)
                    objMr.setDateReceived(String.Empty)
                    objMr.setAIPRC(String.Empty)
                    objMr.setPPA(String.Empty)
                    objMr.setYear(String.Empty)
                    objMr.setBudget(String.Empty)

                    objMr.setYear(txtSYear.Text)

                    objCppal.Search(objMr)
                    If objMr.getStatus <> False Then
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMr.getData
                    End If
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        dt = New DataTable
                        dt.Clear()
                        dgvList.DataSource = dt
                        txtNo.Clear()
                        txtRefCode.Clear()
                        txtYear.Clear()
                        txtPPA.Clear()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                    End If
                Else
                    ClearAll()
                    dt = New DataTable
                    dt.Clear()
                    dgvList.DataSource = dt
                    lstPPA.DataSource = dt
                    txtNo.Clear()
                    txtRefCode.Clear()
                    txtYear.Clear()
                    txtPPA.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                End If
            ElseIf cboSearchby.Text = "Reference No." Then

                If txtSearch.Text <> "" Then
                    objMr.setNo(String.Empty)
                    objMr.setDateReceived(String.Empty)
                    objMr.setAIPRC(String.Empty)
                    objMr.setPPA(String.Empty)
                    objMr.setYear(String.Empty)
                    objMr.setBudget(String.Empty)

                    objMr.setNo(txtSearch.Text)

                    objCppal.Search(objMr)
                    If objMr.getStatus <> False Then
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMr.getData
                    End If
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        dt = New DataTable
                        dt.Clear()
                        dgvList.DataSource = dt
                        txtNo.Clear()
                        txtRefCode.Clear()
                        txtYear.Clear()
                        txtPPA.Clear()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                    End If
                Else
                    ClearAll()
                    dt = New DataTable
                    dt.Clear()
                    dgvList.DataSource = dt
                    lstPPA.DataSource = dt
                    txtNo.Clear()
                    txtRefCode.Clear()
                    txtYear.Clear()
                    txtPPA.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                End If
            ElseIf cboSearchby.Text = "Control No. and Year" Then

                If txtSearch.Text <> "" Then
                    objMppal.setBStatus(String.Empty)
                    objMppal.setCredit(String.Empty)
                    objMppal.setCtrNo(String.Empty)
                    objMppal.setDateReceived(String.Empty)
                    objMppal.setDebit(String.Empty)
                    objMppal.setGSO(String.Empty)
                    objMppal.setLocation(String.Empty)
                    objMppal.setLPPAID(String.Empty)
                    objMppal.setNo(String.Empty)
                    objMppal.setParticulars(String.Empty)
                    objMppal.setPayee(String.Empty)
                    objMppal.setProjectName(String.Empty)
                    objMppal.setRemarks(String.Empty)
                    objMppal.setRunningBal(String.Empty)

                    objMppal.setCtrNo(txtSearch.Text)
                    objCppal.Search(objMppal, txtSYear.Text)

                    Try
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMppal.getData
                    Catch
                    End Try
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        dt = New DataTable
                        dt.Clear()
                        dgvList.DataSource = dt
                        txtNo.Clear()
                        txtRefCode.Clear()
                        txtYear.Clear()
                        txtPPA.Clear()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                    End If
                Else
                    ClearAll()
                    dt = New DataTable
                    dt.Clear()
                    dgvList.DataSource = dt
                    lstPPA.DataSource = dt
                    txtNo.Clear()
                    txtRefCode.Clear()
                    txtYear.Clear()
                    txtPPA.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                End If

            ElseIf cboSearchby.Text = "Payee and Year" Then

                If txtSearch.Text <> "" Then
                    objMppal.setBStatus(String.Empty)
                    objMppal.setCredit(String.Empty)
                    objMppal.setCtrNo(String.Empty)
                    objMppal.setDateReceived(String.Empty)
                    objMppal.setDebit(String.Empty)
                    objMppal.setGSO(String.Empty)
                    objMppal.setLocation(String.Empty)
                    objMppal.setLPPAID(String.Empty)
                    objMppal.setNo(String.Empty)
                    objMppal.setParticulars(String.Empty)
                    objMppal.setPayee(String.Empty)
                    objMppal.setProjectName(String.Empty)
                    objMppal.setRemarks(String.Empty)
                    objMppal.setRunningBal(String.Empty)

                    objMppal.setPayee(txtSearch.Text)

                    objCppal.Search(objMppal, txtSYear.Text)

                    Try
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMppal.getData
                    Catch
                    End Try
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        dt = New DataTable
                        dt.Clear()
                        dgvList.DataSource = dt
                        txtNo.Clear()
                        txtRefCode.Clear()
                        txtYear.Clear()
                        txtPPA.Clear()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                    End If
                Else
                    ClearAll()
                    dt = New DataTable
                    dt.Clear()
                    dgvList.DataSource = dt
                    lstPPA.DataSource = dt
                    txtNo.Clear()
                    txtRefCode.Clear()
                    txtYear.Clear()
                    txtPPA.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                End If

            ElseIf cboSearchby.Text = "Project and Year" Then

                If txtSearch.Text <> "" Then
                    objMppal.setBStatus(String.Empty)
                    objMppal.setCredit(String.Empty)
                    objMppal.setCtrNo(String.Empty)
                    objMppal.setDateReceived(String.Empty)
                    objMppal.setDebit(String.Empty)
                    objMppal.setGSO(String.Empty)
                    objMppal.setLocation(String.Empty)
                    objMppal.setLPPAID(String.Empty)
                    objMppal.setNo(String.Empty)
                    objMppal.setParticulars(String.Empty)
                    objMppal.setPayee(String.Empty)
                    objMppal.setProjectName(String.Empty)
                    objMppal.setRemarks(String.Empty)
                    objMppal.setRunningBal(String.Empty)

                    objMppal.setProjectName(txtSearch.Text)

                    objCppal.Search(objMppal, txtSYear.Text)

                    Try
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMppal.getData
                    Catch
                    End Try
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        dt = New DataTable
                        dt.Clear()
                        dgvList.DataSource = dt
                        txtNo.Clear()
                        txtRefCode.Clear()
                        txtYear.Clear()
                        txtPPA.Clear()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                    End If
                Else
                    ClearAll()
                    dt = New DataTable
                    dt.Clear()
                    dgvList.DataSource = dt
                    lstPPA.DataSource = dt
                    txtNo.Clear()
                    txtRefCode.Clear()
                    txtYear.Clear()
                    txtPPA.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                End If

            ElseIf cboSearchby.Text = "Location and Year" Then

                If txtSearch.Text <> "" Then
                    objMppal.setBStatus(String.Empty)
                    objMppal.setCredit(String.Empty)
                    objMppal.setCtrNo(String.Empty)
                    objMppal.setDateReceived(String.Empty)
                    objMppal.setDebit(String.Empty)
                    objMppal.setGSO(String.Empty)
                    objMppal.setLocation(String.Empty)
                    objMppal.setLPPAID(String.Empty)
                    objMppal.setNo(String.Empty)
                    objMppal.setParticulars(String.Empty)
                    objMppal.setPayee(String.Empty)
                    objMppal.setProjectName(String.Empty)
                    objMppal.setRemarks(String.Empty)
                    objMppal.setRunningBal(String.Empty)

                    objMppal.setLocation(txtSearch.Text)

                    objCppal.Search(objMppal, txtSYear.Text)

                    Try
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMppal.getData
                    Catch
                    End Try
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        dt = New DataTable
                        dt.Clear()
                        dgvList.DataSource = dt
                        txtNo.Clear()
                        txtRefCode.Clear()
                        txtYear.Clear()
                        txtPPA.Clear()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                    End If
                Else
                    ClearAll()
                    dt = New DataTable
                    dt.Clear()
                    dgvList.DataSource = dt
                    lstPPA.DataSource = dt
                    txtNo.Clear()
                    txtRefCode.Clear()
                    txtYear.Clear()
                    txtPPA.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                End If

            ElseIf cboSearchby.Text = "All" Then

                objMr.setNo(String.Empty)
                objMr.setDateReceived(String.Empty)
                objMr.setAIPRC(String.Empty)
                objMr.setPPA(String.Empty)
                objMr.setYear(String.Empty)
                objMr.setBudget(String.Empty)

                objMr.setDateReceived("All")

                objCppal.Search(objMr)
                If objMr.getStatus <> False Then
                    lstPPA.DisplayMember = "AIPRF"
                    lstPPA.ValueMember = "No"
                    lstPPA.DataSource = objMr.getData
                End If
                If lstPPA.Items.Count = 0 Then
                    ClearAll()
                    dt = New DataTable
                    dt.Clear()
                    dgvList.DataSource = dt
                    txtNo.Clear()
                    txtRefCode.Clear()
                    txtYear.Clear()
                    txtPPA.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Ledger")
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Private Sub lstPPA_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPPA.SelectedValueChanged
        If lstPPA.SelectedIndex <> -1 Then

            'Display PPA and Ref. Code and Funding Year
            objMr.setNo(lstPPA.SelectedValue.ToString)
            objCR.Display(objMr)
            txtPPA.Text = objMr.getPPA
            txtYear.Text = objMr.getYear
            txtRefCode.Text = lstPPA.Text

            'Display No.
            txtNo.Text = lstPPA.SelectedValue.ToString

            'Display All Transacation
            objMppal.setDateReceived(String.Empty)
            objMppal.setCredit(String.Empty)
            objMppal.setDebit(String.Empty)
            objMppal.setParticulars(String.Empty)
            objMppal.setNo(String.Empty)
            objMppal.setRunningBal(String.Empty)

            objMppal.setNo(lstPPA.SelectedValue.ToString)

            If objCppal.Display(objMppal, False) = True Then
                dgvList.DataSource = objMppal.getData
                'Get Privilege of User
                objMUA.setUsername(Username)
                objCUA.Display(objMUA)
                If objMUA.getOffice = "MPDO" Or objMUA.getUType = "Administrator" Then
                    btnEdit.Enabled = True
                End If
            Else
                btnEdit.Enabled = False
            End If
            'Get balance

            objMsum.setNo(lstPPA.SelectedValue.ToString)
            objCsum.Getbal(objMsum)
            Bal = objMsum.getBalance

            'Debit

            Dr = objMsum.getAmount

            'Credit

            Cr = objMsum.getExpenditure

        End If
    End Sub

    Public Sub Computation()
        Try
            'Debit Computation
            If txtWD.Text <> "" And mtxtDD.Text <> "." Then
                TBal = (Bal + (Double.Parse(txtWD.Text + mtxtDD.Text) * 1)).ToString
                TDr = ((Double.Parse(Dr) * 1) + (Double.Parse(txtWD.Text + mtxtDD.Text) * 1)).ToString
                TCr = ((Cr * 1) + (0)).ToString
                txtRunningBal.Text = TBal
            End If
            'Credit Computation
            If txtCW.Text <> "" And mtxtCD.Text <> "." Then
                TBal = (Bal - (Double.Parse(txtCW.Text + mtxtCD.Text) * 1)).ToString()
                TCr = ((Double.Parse(Cr) * 1) + (Double.Parse(txtCW.Text + mtxtCD.Text) * 1)).ToString
                TDr = ((Dr * 1) + (0)).ToString
                txtRunningBal.Text = TBal
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        btnNew.Enabled = True
        btnSave.Enabled = False
        ClearAll()
        dtpDateReceived.Focus()
        dgvList.Enabled = True
    End Sub

    Private Sub txtWD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWD.TextChanged
        Dim num As Decimal
        If Decimal.TryParse(txtWD.Text, num) Then
            Dim Text As String = String.Format("{0:N0}", num)
            txtWD.Text = Text
            txtWD.Select(txtWD.TextLength, txtWD.TextLength)
        End If
        Computation()
    End Sub

    Private Sub txtCW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCW.TextChanged
        Dim num As Decimal
        If Decimal.TryParse(txtCW.Text, num) Then
            Dim Text As String = String.Format("{0:N0}", num)
            txtCW.Text = Text
            txtCW.Select(txtCW.TextLength, txtCW.TextLength)
        End If
        Computation()
    End Sub

    Private Sub txtRunningBal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRunningBal.TextChanged
        Dim num As Decimal
        If Decimal.TryParse(txtRunningBal.Text, num) Then
            Dim Text As String = String.Format("{0:c}", num)
            txtRunningBal.Text = Text.Substring(1)
            txtRunningBal.Select(txtRunningBal.TextLength, txtRunningBal.TextLength)
        End If
    End Sub

    Private Sub txtSYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub mtxtDD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtDD.TextChanged
        Computation()
    End Sub

    Private Sub mtxtCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtCD.TextChanged
        Computation()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Transaction = "Edit"
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True

        dtpDateReceived.Text = dgvList.SelectedRows(0).Cells("Date Received").Value.ToString
        txtLocation.Text = dgvList.SelectedRows(0).Cells("Location").Value.ToString
        txtParticulars.Text = dgvList.SelectedRows(0).Cells("Particulars").Value.ToString
        txtPayee.Text = dgvList.SelectedRows(0).Cells("Payee").Value.ToString
        txtProjectName.Text = dgvList.SelectedRows(0).Cells("Project Name").Value.ToString
        txtRemarks.Text = dgvList.SelectedRows(0).Cells("Remarks").Value.ToString
        txtCtrNo.Text = dgvList.SelectedRows(0).Cells("Control No.").Value.ToString

        dgvList.Enabled = False
        txtCtrNo.Focus()
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If dgvList.SelectedRows.Count <> 0 Then
            'Get Privilege of User
            objMUA.setUsername(Username)
            objCUA.Display(objMUA)
            If objMUA.getOffice = "MPDO" Or objMUA.getUType = "Administrator" Then
                btnEdit.Enabled = True
            End If
        Else
            btnEdit.Enabled = False
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If dgvList.SelectedRows.Count <> 0 Then
            Dim objRep As frmLedger = New frmLedger
            objRep.No = txtNo.Text
            objRep.ShowDialog()
        End If
    End Sub
End Class