Imports System.Collections.Concurrent
Imports System.Numerics
Imports System.Runtime.InteropServices
Imports System.Security.Policy
Imports System.Timers
Imports System.Windows.Forms.AxHost
Imports Oracle.ManagedDataAccess.Client

Public Class LoginPage
    Dim ran = New Random
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim ds1 As DataSet
    Dim cmd As OracleCommand
    Dim dt As DataTable
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
    Private Sub LoginPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
        Catch ex As Exception
            MessageBox.Show("Invalid Login")
        End Try
    End Sub
    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click
        Application.Exit()
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        con1.Open()
        Dim user1, pass1, u, a, d, t As String
        user1 = txtUName.Text.Trim()
        pass1 = txtPass.Text.Trim()
        u = txtUName.Text
        a = "Has logged in"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        Dim sqllogin = "SELECT * FROM ACCOUNTS WHERE username='" & user1 &
            "' and password='" & pass1 & "' "
        da1 = New OracleDataAdapter(sqllogin, con1)
        cb1 = New OracleCommandBuilder(da1)
        ds1 = New DataSet
        da1.Fill(ds1, "ACCOUNTS")
        count = ds1.Tables(0).Rows.Count
        If count > 0 Then
            da1 = New OracleDataAdapter(sqllogin, con1)
            cb1 = New OracleCommandBuilder(da1)
            dt = New DataTable
            da1.Fill(dt)
            If dt.Rows(0)(3).ToString = "Owner" Then
                MessageBox.Show("Welcome " & user1 & "!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqllogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                mainForm.lblAccount.Text = user1
                SettingsForm.pnlCPass.Enabled = True
                mainForm.Show()
                txtUName.Clear()
                txtPass.Clear()
                Me.Close()
            ElseIf dt.Rows(0)(3).ToString = "Employee" Then
                MessageBox.Show("Welcome " & user1 & "!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqllogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                mainForm.lblAccount.Text = user1
                mainForm.Show()
                txtUName.Clear()
                txtPass.Clear()
                Me.Close()
            Else
                MessageBox.Show("Invalid Login", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                con1.Close()
            End If
        Else
            MessageBox.Show("Invalid Login", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            con1.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        txtUName.Text = "Owner"
        txtPass.Text = 12345
    End Sub
    Private Sub Window_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ResetTimer()
    End Sub

    Private Sub ResetTimer()
        Timer1.Stop()
        Timer1.Start()
    End Sub

    Private Sub Window_PreviewKeyDown() Handles Me.PreviewKeyDown
        ResetTimer()
    End Sub

    Private Shared Sub Timer_Elapsed(sender As Object, e As EventArgs) Handles Timer1.Tick
        Application.Exit()
    End Sub

End Class