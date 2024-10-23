Imports Microsoft.ReportingServices.Interfaces
Imports Oracle.ManagedDataAccess.Client

Public Class LogsForm
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim cmd As OracleCommand
    Dim dt As DataTable
    Private Sub orderForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Logs()
        InventoryLogs()
    End Sub
    Public Sub Logs()
        con1 = New OracleConnection
        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
        con1.Open()
        Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
        cmd = New OracleCommand(sqllogs, con1)
        da1 = New OracleDataAdapter()
        da1.SelectCommand = cmd
        dt = New DataTable
        da1.Fill(dt)
        dgvLogs.DataSource = dt
        With dgvLogs
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
            .DefaultCellStyle.ForeColor = Color.Black
            .Columns(0).HeaderCell.Value = "Account User"
            .Columns(1).HeaderCell.Value = "Action"
            .Columns(2).HeaderCell.Value = "Log Date"
            .Columns(3).HeaderCell.Value = "Log Time"
        End With
    End Sub

    Public Sub InventoryLogs()
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadLogs()
        If cbOwn.Checked = True And cbEmp.Checked = False And cbOwner.Checked = False And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Owner'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = True And cbOwner.Checked = False And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = True And cbOwner.Checked = True And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Owner'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = True And cbOwner.Checked = True And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = False And cbOwner.Checked = False And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = True And cbOwner.Checked = False And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Employee'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = False And cbOwner.Checked = True And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Owner'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = False And cbOwner.Checked = True And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = False And cbOwner.Checked = False And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Employee'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = False And cbOwner.Checked = True And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Owner'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = True And cbOwner.Checked = False And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Employee'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = True And cbOwner.Checked = True And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Employee'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = False And cbOwner.Checked = False And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Owner'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Employee'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = True And cbOwner.Checked = True And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Employee'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Owner'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = False And cbOwner.Checked = True And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Owner'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Owner'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = True And cbOwner.Checked = False And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Employee'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Employee'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        End If
    End Sub

    Private Sub cbOwn_CheckedChanged(sender As Object, e As EventArgs) Handles cbOwn.CheckedChanged, cbOwner.CheckedChanged, cbEmp.CheckedChanged, cbEmployee.CheckedChanged
        If cbOwn.Checked = True And cbEmp.Checked = False And cbOwner.Checked = False And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Owner'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = True And cbOwner.Checked = False And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = True And cbOwner.Checked = True And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Owner'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = True And cbOwner.Checked = True And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = False And cbOwner.Checked = False And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = True And cbOwner.Checked = False And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Employee'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = False And cbOwner.Checked = True And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Owner'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = False And cbOwner.Checked = True And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = False And cbOwner.Checked = False And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Employee'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = False And cbOwner.Checked = True And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Owner'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = True And cbOwner.Checked = False And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Employee'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = True And cbOwner.Checked = True And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Employee'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = False And cbOwner.Checked = False And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Owner'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Employee'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = True And cbOwner.Checked = True And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Employee'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Owner'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = True And cbEmp.Checked = False And cbOwner.Checked = True And cbEmployee.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Owner'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Owner'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        ElseIf cbOwn.Checked = False And cbEmp.Checked = True And cbOwner.Checked = False And cbEmployee.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs As String = "SELECT ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME FROM LOGS WHERE ACCOUNT_USER='Employee'"
            cmd = New OracleCommand(sqllogs, con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvLogs.DataSource = dt
            With dgvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Action"
                .Columns(2).HeaderCell.Value = "Log Date"
                .Columns(3).HeaderCell.Value = "Log Time"
            End With

            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT ACCOUNT_USER, RAW_NAME, MODIFICATION, QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME FROM RAW_LOGS WHERE ACCOUNT_USER='Employee'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInvLogs.DataSource = dt
            With dgvInvLogs
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Account User"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Modification"
                .Columns(3).HeaderCell.Value = "Quantity"
                .Columns(4).HeaderCell.Value = "Capacity"
                .Columns(5).HeaderCell.Value = "Measure"
                .Columns(6).HeaderCell.Value = "Price"
                .Columns(7).HeaderCell.Value = "Expiration"
                .Columns(8).HeaderCell.Value = "Log Date"
                .Columns(9).HeaderCell.Value = "Log Time"
            End With
        End If
    End Sub
End Class