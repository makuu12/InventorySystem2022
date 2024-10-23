Imports System.Security.Cryptography
Imports Oracle.ManagedDataAccess.Client
Imports OracleInternal.Json

Public Class RegistrationForm
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

    Private Sub MakeProperCase(sender As Object, e As EventArgs)
        Dim n As Integer = sender.SelectionStart
        sender.Text = StrConv(sender.Text, VbStrConv.ProperCase)
        sender.SelectionStart = n
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Try
            If txtFName.Text = Nothing Then
                MessageBox.Show("First Name is empty", "No entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtLName.Text = Nothing Then
                MessageBox.Show("Last Name is empty", "No entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtUName.Text = Nothing Then
                MessageBox.Show("Username is empty", "No entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtPass.Text = Nothing Then
                MessageBox.Show("Password is empty", "No entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtCPass.Text = Nothing Then
                MessageBox.Show("Please confirm password", "No entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtPass.Text <> txtCPass.Text Then
                MessageBox.Show("Passwords do not match", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim fn, ln, un, pass, ul, u, a, d, t As String
                fn = txtFName.Text
                ln = txtLName.Text
                un = txtUName.Text
                pass = txtPass.Text
                If cbUserL.SelectedIndex = 0 Then
                    ul = "Owner"
                ElseIf cbUserL.SelectedIndex = 1 Then
                    ul = "Employee"
                End If
                u = mainForm.lblAccount.Text
                a = "Has registered an account"
                d = Date.Now.ToString("MMMM-dd-yyyy")
                t = Now.ToString("HH:mm:ss")
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                Dim sqlChkAcc = "SELECT * FROM accounts WHERE username='" & un & "'"
                da1 = New OracleDataAdapter(sqlChkAcc, con1)
                cb1 = New OracleCommandBuilder(da1)
                ds1 = New DataSet
                da1.Fill(ds1, "accounts")
                count = ds1.Tables(0).Rows.Count
                If count > 0 Then
                    MessageBox.Show("Username is already taken", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim confirm As DialogResult = MessageBox.Show("Register?", "Confirmation",
                                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    If confirm = DialogResult.Cancel Then

                    ElseIf confirm = DialogResult.OK Then
                        Dim sqladd = "INSERT INTO accounts (first_name, last_name, username, password, user_level) VALUES 
                        ('" & fn & "','" & ln & "','" & un & "','" & pass & "','" & ul & "')"
                        cmd = New OracleCommand(sqladd, con1)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Successfully Registered!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                        cmd = New OracleCommand(sqllogs, con1)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        con1.Close()
                        LogsForm.LoadLogs()
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click
        Me.Close()
    End Sub
    Private Sub txtCPass_TextChanged(sender As Object, e As EventArgs) Handles txtCPass.TextChanged
        Dim NP As String
        NP = txtPass.Text.Trim
        If txtCPass.Text = txtPass.Text Then
            errorPass.Clear()
        Else
            errorPass.SetError(txtCPass, "Passwords do not match!")
        End If
    End Sub
End Class