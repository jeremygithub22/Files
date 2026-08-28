Public Class frmUserAccount

    'Instantiate Object Class and Declare Variable/s
    Dim objCUA As ctrUserAccount = New ctrUserAccount
    Dim objMUA As mUserAccount = New mUserAccount
    Dim Transaction As String
    Dim objCul As ctrUserLog = New ctrUserLog
    Dim objMul As mUserLog = New mUserLog
    Public UID As String

    Private Sub cboSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchby.SelectedIndexChanged
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'Record to User Log
        objMul.setUID(UID)
        objMul.setActivity("Searched from User Account module")
        objMul.setDateandTime(DateTime.Now)
        objCul.Add(objMul)

        Try
            If cboSearchby.Text = "Username" Then
                If txtSearch.Text <> "" Then

                    'Clear All
                    objMUA.setFirstname(String.Empty)
                    objMUA.setMiddlename(String.Empty)
                    objMUA.setLastname(String.Empty)
                    objMUA.setUsername(String.Empty)
                    objMUA.setPassword(String.Empty)
                    objMUA.setType(String.Empty)

                    objMUA.setUsername(txtSearch.Text)
                    objCUA.Search(objMUA)
                    lstUser.DisplayMember = "Name"
                    lstUser.ValueMember = "Username"
                    lstUser.DataSource = objMUA.getData
                    If lstUser.Items.Count = 0 Then
                        ClearAll()
                        Enable()
                        btnNew.Enabled = True
                        btnEdit.Enabled = False
                        btnSave.Enabled = False
                        btnDelete.Enabled = False
                    End If
                Else
                    ClearAll()
                    Enable()
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    btnDelete.Enabled = False
                    lstUser.Items.Clear()
                End If

            ElseIf cboSearchby.Text = "First Name" Then
                If txtSearch.Text <> "" Then

                    'Clear All
                    objMUA.setFirstname(String.Empty)
                    objMUA.setMiddlename(String.Empty)
                    objMUA.setLastname(String.Empty)
                    objMUA.setUsername(String.Empty)
                    objMUA.setPassword(String.Empty)
                    objMUA.setType(String.Empty)

                    objMUA.setFirstname(txtSearch.Text)
                    objCUA.Search(objMUA)
                    lstUser.DisplayMember = "Name"
                    lstUser.ValueMember = "Username"
                    lstUser.DataSource = objMUA.getData
                    If lstUser.Items.Count = 0 Then
                        ClearAll()
                        Enable()
                        btnNew.Enabled = True
                        btnEdit.Enabled = False
                        btnSave.Enabled = False
                        btnDelete.Enabled = False
                    End If
                Else
                    ClearAll()
                    Enable()
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    btnDelete.Enabled = False
                    lstUser.Items.Clear()
                End If
            ElseIf cboSearchby.Text = "Last Name" Then
                If txtSearch.Text <> "" Then

                    'Clear All
                    objMUA.setFirstname(String.Empty)
                    objMUA.setMiddlename(String.Empty)
                    objMUA.setLastname(String.Empty)
                    objMUA.setUsername(String.Empty)
                    objMUA.setPassword(String.Empty)
                    objMUA.setType(String.Empty)

                    objMUA.setLastname(txtSearch.Text)
                    objCUA.Search(objMUA)
                    lstUser.DisplayMember = "Name"
                    lstUser.ValueMember = "Username"
                    lstUser.DataSource = objMUA.getData
                    If lstUser.Items.Count = 0 Then
                        ClearAll()
                        Enable()
                        btnNew.Enabled = True
                        btnEdit.Enabled = False
                        btnSave.Enabled = False
                        btnDelete.Enabled = False
                    End If
                Else
                    ClearAll()
                    Enable()
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    btnDelete.Enabled = False
                    lstUser.Items.Clear()
                End If
            ElseIf cboSearchby.Text = "All" Then
                If txtSearch.Text = "" Then

                    'Clear All
                    objMUA.setFirstname(String.Empty)
                    objMUA.setMiddlename(String.Empty)
                    objMUA.setLastname(String.Empty)
                    objMUA.setUsername(String.Empty)
                    objMUA.setPassword(String.Empty)
                    objMUA.setType(String.Empty)

                    objMUA.setType("All")
                    objCUA.Search(objMUA)
                    lstUser.DisplayMember = "Name"
                    lstUser.ValueMember = "Username"
                    lstUser.DataSource = objMUA.getData
                    If lstUser.Items.Count = 0 Then
                        ClearAll()
                        Enable()
                        btnNew.Enabled = True
                        btnEdit.Enabled = False
                        btnSave.Enabled = False
                        btnDelete.Enabled = False
                    End If
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error Message")
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Transaction = "New"
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        ClearAll()
        Enable()
        txtFirstname.Focus()
    End Sub

    Public Sub Enable()
        txtFirstname.Enabled = True
        txtMiddlename.Enabled = True
        txtLastname.Enabled = True
        txtUsername.Enabled = True
        txtPassword.Enabled = True
        cboType.Enabled = True
        cboOffice.Enabled = True
    End Sub

    Public Sub Disable()
        txtFirstname.Enabled = False
        txtMiddlename.Enabled = False
        txtLastname.Enabled = False
        txtUsername.Enabled = False
        txtPassword.Enabled = False
        cboType.Enabled = False
        cboOffice.Enabled = False
    End Sub
    Public Sub ClearAll()
        txtFirstname.Clear()
        txtMiddlename.Clear()
        txtLastname.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        cboType.ResetText()
        cboOffice.ResetText()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Transaction = "Edit"
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        Enable()
        txtUsername.Enabled = False
        txtFirstname.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Transaction = "New" Then
            If MessageBox.Show("Are you sure, you want to add this user account?", "User Accounts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objMUA.setFirstname(txtFirstname.Text)
                objMUA.setMiddlename(txtMiddlename.Text)
                objMUA.setLastname(txtLastname.Text)
                objMUA.setUsername(txtUsername.Text)
                objMUA.setPassword(txtPassword.Text)
                objMUA.setType(cboType.Text)
                objMUA.setOffice(cboOffice.Text)

                If objCUA.AddUA(objMUA, False) = True Then

                    'Record to User Log
                    objMul.setUID(UID)
                    objMul.setActivity("Added Username " + txtUsername.Text + " from User Account module")
                    objMul.setDateandTime(DateTime.Now)
                    objCul.Add(objMul)

                    ClearAll()
                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    btnDelete.Enabled = False
                End If
            End If
        ElseIf Transaction = "Edit" Then
            If MessageBox.Show("Are you sure, you want to update this user account?", "User Accounts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objMUA.setFirstname(txtFirstname.Text)
                objMUA.setMiddlename(txtMiddlename.Text)
                objMUA.setLastname(txtLastname.Text)
                objMUA.setUsername(txtUsername.Text)
                objMUA.setPassword(txtPassword.Text)
                objMUA.setType(cboType.Text)
                objMUA.setOffice(cboOffice.Text)

                If objCUA.UpdateUA(objMUA, False) = True Then

                    'Record to User Log
                    objMul.setUID(UID)
                    objMul.setActivity("Updated Username " + txtUsername.Text + " from User Account module")
                    objMul.setDateandTime(DateTime.Now)
                    objCul.Add(objMul)

                    btnNew.Enabled = True
                    btnEdit.Enabled = False
                    btnSave.Enabled = False
                    btnDelete.Enabled = False
                End If
            End If
            Else
            End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure, you want to delete this user account?", "User Accounts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If lstUser.Items.Count <> 0 Then
                objMUA.setUsername(lstUser.SelectedValue.ToString)
                If objCUA.DeleteUA(objMUA, False) = True Then

                    'Record to User Log
                    objMul.setUID(UID)
                    objMul.setActivity("Deleted Username " + txtUsername.Text + " from User Account module")
                    objMul.setDateandTime(DateTime.Now)
                    objCul.Add(objMul)

                    btnSearch.PerformClick()
                    ClearAll()
                    Enable()
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearAll()
        Enable()
        Transaction = ""
        btnNew.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub lstUser_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUser.SelectedValueChanged

        If lstUser.SelectedIndex <> -1 Then

            objMUA.setUsername(lstUser.SelectedValue.ToString)
            objCUA.Display(objMUA)
            Disable()
            txtFirstname.Text = objMUA.getFirstname
            txtMiddlename.Text = objMUA.getMiddlename
            txtLastname.Text = objMUA.getLastname
            txtUsername.Text = objMUA.getUsername
            txtPassword.Text = objMUA.getPassword
            cboType.Text = objMUA.getUType
            cboOffice.Text = objMUA.getOffice
            btnEdit.Enabled = True
            btnDelete.Enabled = True

        End If
    End Sub
End Class