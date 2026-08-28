Public Class frmPPAFundingInfo

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
    Dim objCS As ctrSAAOB = New ctrSAAOB
    Dim objMS As mSAAOB = New mSAAOB
    Dim dt As DataTable = New DataTable
    Public UID As String
    Public Username As String


    Private Sub cboSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchby.SelectedIndexChanged
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            'Record to User Log
            objMul.setUID(UID)
            objMul.setActivity("Searched from PPA Funding Information module")
            objMul.setDateandTime(DateTime.Now)
            objCul.Add(objMul)

            If cboSearchby.Text = "PPA and Year" Then

                If txtSearch.Text <> "" And txtYear.Text <> "" Then
                    'Clear All
                    objMr.setNo(String.Empty)
                    objMr.setDateReceived(String.Empty)
                    objMr.setYear(String.Empty)
                    objMr.setBudget(String.Empty)
                    objMr.setAIPRC(String.Empty)
                    objMr.setPPA(String.Empty)

                    objMr.setPPA(txtSearch.Text)
                    objMr.setYear(txtYear.Text)

                    objCR.Search(objMr)
                    If objMr.getStatus <> False Then
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMr.getData
                    End If
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        Enable()
                        btnNew.Enabled = True
                        btnEdit.Enabled = False
                        btnSave.Enabled = False
                        txtNo.Focus()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Funding Information")
                    End If
                Else
                    ClearAll()
                    Enable()
                    dt = New DataTable
                    dt.Clear()
                    lstPPA.DataSource = dt
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    txtNo.Focus()
                    dt.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Funding Information")
                End If
            ElseIf cboSearchby.Text = "Year" Then

                If txtYear.Text <> "" Then
                    'Clear All
                    objMr.setNo(String.Empty)
                    objMr.setDateReceived(String.Empty)
                    objMr.setYear(String.Empty)
                    objMr.setBudget(String.Empty)
                    objMr.setAIPRC(String.Empty)
                    objMr.setPPA(String.Empty)

                    objMr.setYear(txtYear.Text)

                    objCR.Search(objMr)
                    If objMr.getStatus <> False Then
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMr.getData
                    End If
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        Enable()
                        btnNew.Enabled = True
                        btnEdit.Enabled = False
                        btnSave.Enabled = False
                        txtNo.Focus()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Funding Information")
                    End If
                Else
                    ClearAll()
                    Enable()
                    dt = New DataTable
                    dt.Clear()
                    lstPPA.DataSource = dt
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    txtNo.Focus()
                    dt.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Funding Information")
                End If
            ElseIf cboSearchby.Text = "Reference No." Then

                If txtSearch.Text <> "" Then
                    'Clear All
                    objMr.setNo(String.Empty)
                    objMr.setDateReceived(String.Empty)
                    objMr.setYear(String.Empty)
                    objMr.setBudget(String.Empty)
                    objMr.setAIPRC(String.Empty)
                    objMr.setPPA(String.Empty)

                    objMr.setNo(txtSearch.Text)

                    objCR.Search(objMr)
                    If objMr.getStatus <> False Then
                        lstPPA.DisplayMember = "AIPRF"
                        lstPPA.ValueMember = "No"
                        lstPPA.DataSource = objMr.getData
                    End If
                    If lstPPA.Items.Count = 0 Then
                        ClearAll()
                        Enable()
                        btnNew.Enabled = True
                        btnEdit.Enabled = False
                        btnSave.Enabled = False
                        txtNo.Focus()
                        MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Funding Information")
                    End If
                Else
                    ClearAll()
                    Enable()
                    dt = New DataTable
                    dt.Clear()
                    lstPPA.DataSource = dt
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    txtNo.Focus()
                    dt.Clear()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Funding Information")
                End If
                ElseIf cboSearchby.Text = "All" Then

                    'Clear All
                    objMr.setNo(String.Empty)
                    objMr.setDateReceived(String.Empty)
                    objMr.setYear(String.Empty)
                    objMr.setBudget(String.Empty)
                    objMr.setAIPRC(String.Empty)
                    objMr.setPPA(String.Empty)

                    objMr.setDateReceived("All")

                objCR.Search(objMr)
                If objMr.getStatus <> False Then
                    lstPPA.DisplayMember = "AIPRF"
                    lstPPA.ValueMember = "No"
                    lstPPA.DataSource = objMr.getData
                End If
                If lstPPA.Items.Count = 0 Then
                    ClearAll()
                    Enable()
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    txtNo.Focus()
                    MsgBox("Record not found.", MsgBoxStyle.Critical, "PPA Funding Information")
                End If
                Else
                End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Public Sub ClearAll()
        txtNo.Clear()
        dtpDateReceived.Value = DateTime.Now
        txtRefCode.Clear()
        txtPPA.Clear()
        txtFunding.Clear()
        txtWhole.Clear()
        mtxtDecimal.Clear()
        txtObligatedFund.Clear()
    End Sub

    Public Sub Enable()
        txtNo.Enabled = True
        dtpDateReceived.Enabled = True
        txtRefCode.Enabled = True
        txtPPA.Enabled = True
        txtFunding.Enabled = True
        txtWhole.Enabled = True
        mtxtDecimal.Enabled = True
        txtObligatedFund.Enabled = True
    End Sub

    Public Sub Disable()
        txtNo.Enabled = False
        dtpDateReceived.Enabled = False
        txtRefCode.Enabled = False
        txtPPA.Enabled = False
        txtFunding.Enabled = False
        txtWhole.Enabled = False
        mtxtDecimal.Enabled = False
        txtObligatedFund.Enabled = False
    End Sub

    Private Sub lstRegistry_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPPA.SelectedValueChanged
        If lstPPA.Items.Count <> 0 Then
            If lstPPA.SelectedIndex <> -1 Then
                'Display All Data
                objMr.setNo(lstPPA.SelectedValue.ToString)
                objCR.Display(objMr)

                txtNo.Text = objMr.getNo()
                dtpDateReceived.Text = objMr.getDateReceived()
                txtRefCode.Text = objMr.getAIPRC
                txtPPA.Text = objMr.getPPA
                txtFunding.Text = objMr.getYear
                txtObligatedFund.Text = objMr.getBudget
                
                Disable()

                'Get ID of User
                objMUA.setUsername(Username)
                objCUA.Display(objMUA)
                If objMUA.getUType = "Administrator" Or objMUA.getOffice = "MPDO" Then
                    btnEdit.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Transaction = "New"
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True

        ClearAll()
        Enable()

        txtNo.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Transaction = "Edit"
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True

        Enable()
        txtNo.Enabled = False
        dtpDateReceived.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearAll()
        Enable()
        btnNew.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        Transaction = ""
        txtNo.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Transaction = "New" Then

            'Add to PPA table
            objMr.setNo(txtNo.Text)
            objMr.setDateReceived(dtpDateReceived.Value.ToShortDateString)
            objMr.setYear(txtFunding.Text)
            objMr.setBudget(txtObligatedFund.Text)
            objMr.setAIPRC(txtRefCode.Text)
            objMr.setPPA(txtPPA.Text)

            objCR.AddR(objMr)

            If objMr.getStatus = True Then

                objCR.Search(objMr, txtNo)
                'Record to User Log
                objMul.setUID(UID)
                objMul.setActivity("Added Reference No. " + txtNo.Text + " from PPA Funding Information module")
                objMul.setDateandTime(DateTime.Now)
                objCul.Add(objMul)

                objMul.setUID(UID)
                objMul.setActivity("Added Reference No. " + txtNo.Text + " to PPA Ledger")
                objMul.setDateandTime(DateTime.Now)
                objCul.Add(objMul)

                objMul.setUID(UID)
                objMul.setActivity("Added Reference No. " + txtNo.Text + " to SAAOB")
                objMul.setDateandTime(DateTime.Now)
                objCul.Add(objMul)

                objMul.setUID(UID)
                objMul.setActivity("Added Reference No. " + txtNo.Text + " to Summary")
                objMul.setDateandTime(DateTime.Now)
                objCul.Add(objMul)


                'Add record to ledger
                objMppal.setDateReceived(dtpDateReceived.Value.ToShortDateString)
                objMppal.setCredit("-")
                objMppal.setDebit(txtObligatedFund.Text)
                objMppal.setParticulars("Beginning Balance")
                objMppal.setNo(txtNo.Text)
                objMppal.setRunningBal(txtObligatedFund.Text)

                If objCppal.AddL(objMppal, False) = True Then

                    'Add record to Summary
                    objMsum.setNo(txtNo.Text)
                    objMsum.setAmount(txtObligatedFund.Text)
                    objMsum.setExpenditure("0")
                    objMsum.setBalance(txtObligatedFund.Text)

                    objCsum.AddSum(objMsum)

                    'Add record to SAAOB
                    objMS.setNo(txtNo.Text)
                    objMS.setAppropriation(txtObligatedFund.Text)
                    objMS.setObligation("0")
                    objMS.setUnobligatedAllotment(txtObligatedFund.Text)

                    objCS.AddSum(objMS)

                    ClearAll()
                    Enable()
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                End If
            End If
        ElseIf Transaction = "Edit" Then

            'Update to PPA table
            objMr.setNo(txtNo.Text)
            objMr.setDateReceived(dtpDateReceived.Value.ToShortDateString)
            objMr.setYear(txtFunding.Text)
            objMr.setBudget(txtObligatedFund.Text)
            objMr.setAIPRC(txtRefCode.Text)
            objMr.setPPA(txtPPA.Text)

            objCR.UpdateR(objMr)

            If objMr.getStatus = True Then

                'Record to User Log
                objMul.setUID(UID)
                objMul.setActivity("Updated Reference No. " + txtNo.Text + " from PPA Funding Information module")
                objMul.setDateandTime(DateTime.Now)
                objCul.Add(objMul)

                Enable()
                btnNew.Enabled = True
                btnEdit.Enabled = False
                btnSave.Enabled = False
            End If
        Else
        End If
    End Sub

    Private Sub txtWhole_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWhole.TextChanged
        Dim num As Decimal
        If Decimal.TryParse(txtWhole.Text, num) Then
            Dim Text As String = String.Format("{0:N0}", num)
            txtWhole.Text = Text

            txtWhole.Select(txtWhole.TextLength, txtWhole.TextLength)
        End If
        txtObligatedFund.Text = txtWhole.Text + mtxtDecimal.Text

    End Sub

    Private Sub mtxtDecimal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtDecimal.TextChanged
        txtObligatedFund.Text = txtWhole.Text + mtxtDecimal.Text
    End Sub

    Private Sub txtYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class