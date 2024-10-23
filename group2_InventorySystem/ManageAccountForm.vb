Imports System.Security.Cryptography
Imports Oracle.ManagedDataAccess.Client
Imports OracleInternal.Json

Public Class ManageAccountForm
    Dim ran = New Random
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim cmd As OracleCommand
    Dim dt As DataTable
    Dim ds1 As DataSet
    Dim count As Byte
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Panel1.MouseDown, Panel2.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Panel1.MouseUp, Panel2.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Panel1.MouseMove, Panel2.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()
            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub
    Private Sub MakeProperCase(sender As Object, e As EventArgs) Handles txtFName.TextChanged, txtLName.TextChanged
        Dim n As Integer = sender.SelectionStart
        sender.Text = StrConv(sender.Text, VbStrConv.ProperCase)
        sender.SelectionStart = n
    End Sub
    Private Sub Accounts()
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_ID, FIRST_NAME, LAST_NAME, USERNAME, USER_LEVEL FROM accounts", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvAccounts.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgvAccounts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAccounts.CellClick
        Dim current_row As Integer = dgvAccounts.CurrentRow.Index
        txtAccID.Text = dgvAccounts(0, current_row).Value.ToString
        txtFName.Text = dgvAccounts(1, current_row).Value.ToString
        txtLName.Text = dgvAccounts(2, current_row).Value.ToString
        txtUName.Text = dgvAccounts(3, current_row).Value.ToString
        If dgvAccounts(4, current_row).Value.ToString = "Owner" Then
            cbUserL.SelectedIndex = 0
        ElseIf dgvAccounts(4, current_row).Value.ToString = "Employee" Then
            cbUserL.SelectedIndex = 1
        End If
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        btnClear.Enabled = True
        btnUpdPass.Enabled = True
    End Sub
    Private Sub ManageAccountForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Accounts()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
    Private Sub ClearAll()
        txtAccID.Clear()
        txtFName.Clear()
        txtLName.Clear()
        txtUName.Clear()
        txtNPass.Clear()
        txtOPass.Clear()
        txtCPass.Clear()
        cbUserL.SelectedIndex = -1
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAccID.Clear()
        txtFName.Clear()
        txtLName.Clear()
        txtUName.Clear()
        txtNPass.Clear()
        txtOPass.Clear()
        txtCPass.Clear()
        cbUserL.SelectedIndex = -1
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim id, fn, ln, un, ul, u, a, d, t As String
        id = txtAccID.Text
        fn = txtFName.Text
        ln = txtLName.Text
        un = txtUName.Text
        If cbUserL.SelectedIndex = 0 Then
            ul = "Owner"
        ElseIf cbUserL.SelectedIndex = 1 Then
            ul = "Employee"
        End If
        u = mainForm.lblAccount.Text
        a = "Has updated an account"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If fn = Nothing Then
            MessageBox.Show("Please input a first name!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ln = Nothing Then
            MessageBox.Show("Please input a last name!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf un = Nothing Then
            MessageBox.Show("Please input a username!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ul = Nothing Then
            MessageBox.Show("Please select a user level", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Update account?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                Dim sqlUpdate = "UPDATE ACCOUNTS SET FIRST_NAME= '" & fn & "', LAST_NAME= '" & ln & "', USERNAME= '" & un & "', USER_LEVEL= '" & ul & "' WHERE ACCOUNT_ID='" & id & "' "
                cmd = New OracleCommand(sqlUpdate, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqllogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Account has been successfully updated!", "Updated successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LogsForm.LoadLogs()
                Accounts()
                ClearAll()
            End If
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim id, u, a, d, t As String
        id = txtAccID.Text
        u = mainForm.lblAccount.Text
        a = "Has deleted an account"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        Dim confirm As DialogResult = MessageBox.Show("Delete account?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If confirm = DialogResult.Cancel Then

        ElseIf confirm = DialogResult.OK Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqlUpdate = "DELETE FROM ACCOUNTS WHERE ACCOUNT_ID='" & id & "' "
            cmd = New OracleCommand(sqlUpdate, con1)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
            cmd = New OracleCommand(sqllogs, con1)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            con1.Close()
            MessageBox.Show("Account has been successfully deleted!", "Deleted successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LogsForm.LoadLogs()
            Accounts()
            ClearAll()
        End If
    End Sub
    Private Sub btnUpdPass_Click(sender As Object, e As EventArgs) Handles btnUpdPass.Click
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim id, oldpass, newpass, username, a, u, d, t As String
            id = txtAccID.Text
            newpass = txtNPass.Text
            username = txtUName.Text
            u = mainForm.lblAccount.Text
            a = "Has updated an account`s password"
            d = Date.Now.ToString("MMMM-dd-yyyy")
            t = Now.ToString("HH:mm:ss")
            Dim sqlChkAcc = "SELECT PASSWORD FROM accounts WHERE ACCOUNT_ID='" & id & "'"
            da1 = New OracleDataAdapter(sqlChkAcc, con1)
            cb1 = New OracleCommandBuilder(da1)
            dt = New DataTable
            da1.Fill(dt)
            oldpass = dt.Rows(0)(0).ToString.Trim
            If txtOPass.Text = Nothing Then
                MessageBox.Show("Please input old password!", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtOPass.Text <> oldpass Then
                MessageBox.Show("Old password is incorrect!", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtNPass.Text = Nothing Then
                MessageBox.Show("Please input new password!", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtCPass.Text = Nothing Then
                MessageBox.Show("Please confirm password!", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtNPass.Text <> txtCPass.Text Then
                MessageBox.Show("Password does not match!", "Wrong Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtNPass.Text = oldpass Then
                MessageBox.Show("New password is same as the old password!", "Old Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim confirm As DialogResult = MessageBox.Show("Change password?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If confirm = DialogResult.Cancel Then

                ElseIf confirm = DialogResult.OK Then
                    Dim sqlupdate = "UPDATE accounts SET password= '" & newpass & "' WHERE account_id='" & id & "' "
                    cmd = New OracleCommand(sqlupdate, con1)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                    cmd = New OracleCommand(sqllogs, con1)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Password Updated!", "Password Changed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    con1.Close()
                    ClearAll()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txtOPass_TextChanged(sender As Object, e As EventArgs) Handles txtOPass.TextChanged
        Dim NP As String
        NP = txtNPass.Text.Trim
        If txtCPass.Text = txtNPass.Text Then
            errorPass.Clear()
        Else
            errorPass.SetError(txtCPass, "Passwords do not match!")
        End If
    End Sub
    Private Sub txtCPass_TextChanged(sender As Object, e As EventArgs) Handles txtCPass.TextChanged
        Dim NP As String
        NP = txtNPass.Text.Trim
        If txtCPass.Text = txtNPass.Text Then
            errorPass.Clear()
        Else
            errorPass.SetError(txtCPass, "Passwords do not match!")
        End If
    End Sub
End Class