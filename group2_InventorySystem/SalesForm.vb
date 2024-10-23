Imports Microsoft.VisualBasic.Devices
Imports Oracle.ManagedDataAccess.Client
Imports Microsoft.Reporting.WinForms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class SalesForm
    Dim con1 As OracleConnection
    Dim da1, daS, daE, daLD As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim cmd, cmdS, cmdE, cmdLD As OracleCommand
    Dim dt, dtS, dtE, dtLD As DataTable
    Dim n As String = Environment.NewLine

    Private Sub MakeProperCase(sender As Object, e As EventArgs) Handles _
         txtSearch.TextChanged
        Dim n As Integer = sender.SelectionStart
        sender.Text = StrConv(sender.Text, VbStrConv.ProperCase)
        sender.SelectionStart = n
    End Sub
    Private Sub NumberOnly(sender As Object, e As KeyPressEventArgs) Handles txtDay.KeyPress, txtPeriod.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
            End If
        End If
    End Sub

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        TransactionHistory()
    End Sub
    Public Sub TransactionHistory()

        con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT TRANSACTIONS.ORDER_ID, PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, 
                                        TRANSACTIONS.QUANTITY, TRANSACTIONS.PRICE, TRANSACTIONS.TRANSACTION_MONTH,
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR,
                                        TRANSACTIONS.TRANSACTION_TIME FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        ORDER BY ORDER_ID DESC", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvTH.DataSource = dt
        With dgvTH
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
            .DefaultCellStyle.ForeColor = Color.Black
            .Columns(0).HeaderCell.Value = "Order ID"
            .Columns(0).Width = 50
            .Columns(1).HeaderCell.Value = "Product ID"
            .Columns(1).Width = 50
            .Columns(2).HeaderCell.Value = "Product Name"
            .Columns(2).Width = 150
            .Columns(3).HeaderCell.Value = "Quantity"
            .Columns(3).Width = 50
            .Columns(4).HeaderCell.Value = "Price"
            .Columns(4).Width = 50
            .Columns(5).HeaderCell.Value = "Month"
            .Columns(5).Width = 50
            .Columns(6).HeaderCell.Value = "Day"
            .Columns(6).Width = 50
            .Columns(7).HeaderCell.Value = "Year"
            .Columns(7).Width = 50
            .Columns(8).HeaderCell.Value = "Transaction Time"
            .Columns(8).Width = 90
        End With
    End Sub

    Public Sub Sales()
        Dim Period, Daily, Day, Monthly, Year As String
        Year = txtPeriod.Text.Trim
        Monthly = cbMonth.Text.Trim
        Day = txtDay.Text.Trim
        Daily = Monthly & "-" & Day
        If cbPeriod.SelectedIndex = 0 Then
            Period = Daily + "-" + Year
            'Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, 
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_MONTH='" & Monthly & "' AND TRANSACTIONS.TRANSACTION_DAY='" & Day & "' 
                                        AND TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, 
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvStats.DataSource = Nothing
            dgvStats.DataSource = dt
            With dgvStats
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Product ID"
                .Columns(0).Width = 70
                .Columns(1).HeaderCell.Value = "Product Name"
                .Columns(1).Width = 160
                .Columns(2).HeaderCell.Value = "Month"
                .Columns(2).Width = 75
                .Columns(3).HeaderCell.Value = "Day"
                .Columns(3).Width = 70
                .Columns(4).HeaderCell.Value = "Year"
                .Columns(4).Width = 70
                .Columns(5).HeaderCell.Value = "Total Sales"
                .Columns(5).Width = 90
                .Columns(6).HeaderCell.Value = "Amount Sold"
                .Columns(6).Width = 90
            End With
            'Catch ex As Exception
            '    MessageBox.Show(ex.StackTrace)
            'End Try
        ElseIf cbPeriod.SelectedIndex = 1 Then
            Period = Monthly & "%" & Year
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_MONTH='" & Monthly & "' AND TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvStats.DataSource = Nothing
            dgvStats.DataSource = dt
            With dgvStats
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Product ID"
                .Columns(0).Width = 70
                .Columns(1).HeaderCell.Value = "Product Name"
                .Columns(1).Width = 230
                .Columns(2).HeaderCell.Value = "Month"
                .Columns(2).Width = 75
                .Columns(3).HeaderCell.Value = "Year"
                .Columns(3).Width = 70
                .Columns(4).HeaderCell.Value = "Total Sales"
                .Columns(4).Width = 90
                .Columns(5).HeaderCell.Value = "Amount Sold"
                .Columns(5).Width = 90
            End With
        ElseIf cbPeriod.SelectedIndex = 2 Then
            Period = "%" & Year
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvStats.DataSource = Nothing
            dgvStats.DataSource = dt
            With dgvStats
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Product ID"
                .Columns(0).Width = 70
                .Columns(1).HeaderCell.Value = "Product Name"
                .Columns(1).Width = 288
                .Columns(2).HeaderCell.Value = "Year"
                .Columns(2).Width = 70
                .Columns(3).HeaderCell.Value = "Total Sales"
                .Columns(3).Width = 90
                .Columns(4).HeaderCell.Value = "Amount Sold"
                .Columns(4).Width = 90
            End With
        End If
    End Sub

    Public Sub Expenses()
        Dim Period, Daily, Day, Monthly, Year As String
        Year = txtPeriod.Text.Trim
        Monthly = cbMonth.Text.Trim
        Day = txtDay.Text.Trim
        Daily = Monthly & "-" & Day
        If cbPeriod.SelectedIndex = 0 Then
            Period = Daily & "-" & Year
            'Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE='" & Period & "'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvStats.DataSource = dt
            With dgvStats
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Expenses ID"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(1).Width = 125
                .Columns(2).HeaderCell.Value = "Quantity"
                .Columns(3).HeaderCell.Value = "Measure"
                .Columns(4).HeaderCell.Value = "Total Expenses"
                .Columns(5).HeaderCell.Value = "Expenses Date"
                .Columns(5).Width = 90
            End With
            'Catch ex As Exception
            '    MessageBox.Show(ex.StackTrace)
            'End Try
        ElseIf cbPeriod.SelectedIndex = 1 Then
            Period = Monthly & "%" & Year
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE LIKE '" & Period & "'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvStats.DataSource = dt
            With dgvStats
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Expenses ID"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(1).Width = 125
                .Columns(2).HeaderCell.Value = "Quantity"
                .Columns(3).HeaderCell.Value = "Measure"
                .Columns(4).HeaderCell.Value = "Total Expenses"
                .Columns(5).HeaderCell.Value = "Expenses Date"
                .Columns(5).Width = 90
            End With
        ElseIf cbPeriod.SelectedIndex = 2 Then
            Period = "%" & Year
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE LIKE '" & Period & "'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvStats.DataSource = dt
            With dgvStats
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Expenses ID"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(1).Width = 125
                .Columns(2).HeaderCell.Value = "Quantity"
                .Columns(3).HeaderCell.Value = "Measure"
                .Columns(4).HeaderCell.Value = "Total Expenses"
                .Columns(5).HeaderCell.Value = "Expenses Date"
                .Columns(5).Width = 90
            End With
        End If
    End Sub

    Public Sub LossDamage()
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT * FROM RAW_LOSS_DAMAGE", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvStats.DataSource = dt
            With dgvStats
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Loss/Damaged ID"
                .Columns(1).HeaderCell.Value = "Raw Name"
                .Columns(2).HeaderCell.Value = "Quantity"
                .Columns(3).HeaderCell.Value = "Measure"
                .Columns(4).HeaderCell.Value = "Price"
                .Columns(5).HeaderCell.Value = "Status"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try
    End Sub

    Public Function Search1() As DataTable
        Dim keyword As String
        keyword = txtSearch.Text
        con1 = New OracleConnection
        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
        con1.Open()
        cmd = New OracleCommand("SELECT TRANSACTIONS.ORDER_ID, PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, 
                                        TRANSACTIONS.QUANTITY, TRANSACTIONS.PRICE, TRANSACTIONS.TRANSACTION_MONTH,
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR,
                                        TRANSACTIONS.TRANSACTION_TIME FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                    WHERE PRODUCT_NAME LIKE '%" & keyword & "%'", con1)
        da1 = New OracleDataAdapter()
        da1.SelectCommand = cmd
        dt = New DataTable
        da1.Fill(dt)
        Return dt
    End Function

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim Period, Daily, Day, Monthly, Year As String
        Year = txtPeriod.Text.Trim
        Monthly = cbMonth.Text.Trim
        Day = txtDay.Text.Trim
        Daily = Monthly & "-" & Day
        Dim totS, totE, totLD, totI As Double
        If cbPeriod.SelectedIndex = 0 Then
            If txtDay.Text = Nothing Then
                MessageBox.Show("Please input day!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf cbMonth.SelectedIndex = -1 Then
                MessageBox.Show("Please select month!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtPeriod.Text = Nothing Then
                MessageBox.Show("Please input year!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim confirm As DialogResult = MessageBox.Show("Generate pie chart?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If confirm = DialogResult.Cancel Then

                ElseIf confirm = DialogResult.OK Then
                    Period = Daily + "-" + Year
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdS = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, 
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_MONTH='" & Monthly & "' AND TRANSACTIONS.TRANSACTION_DAY='" & Day & "' 
                                        AND TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, 
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
                    daS = New OracleDataAdapter()
                    daS.SelectCommand = cmdS
                    dtS = New DataTable
                    daS.Fill(dtS)
                    For i As Integer = 0 To dtS.Rows.Count - 1
                        totS += CType(dtS.Rows(i)(5).ToString, Double)
                    Next
                    'Try
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdE = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE='" & Period & "'", con1)
                    daE = New OracleDataAdapter()
                    daE.SelectCommand = cmdE
                    dtE = New DataTable
                    daE.Fill(dtE)
                    For i As Integer = 0 To dtE.Rows.Count - 1
                        totE += CType(dtE.Rows(i)(4).ToString, Double)
                    Next
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdLD = New OracleCommand("SELECT * FROM RAW_LOSS_DAMAGE WHERE LOSSDMG_DATE='" & Period & "'", con1)
                    daLD = New OracleDataAdapter()
                    daLD.SelectCommand = cmdLD
                    dtLD = New DataTable
                    daLD.Fill(dtLD)
                    For i As Integer = 0 To dtLD.Rows.Count - 1
                        totLD += CType(dtLD.Rows(i)(4).ToString, Double)
                    Next
                    totI = totS - totE
                    chrInc.Series("Stats").Points.Clear()
                    chrInc.Series("Stats").Points.AddXY("Sales" & " " & "#PERCENT", totS)
                    chrInc.Series("Stats").Points.AddXY("Expenses" & " " & "#PERCENT", totE)
                    'chrInc.Series("Stats").Label = "#VAL" & Environment.NewLine & "#PERCENT"
                End If
            End If
        ElseIf cbPeriod.SelectedIndex = 1 Then
            If cbMonth.SelectedIndex = -1 Then
                MessageBox.Show("Please select month!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtPeriod.Text = Nothing Then
                MessageBox.Show("Please input year!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim confirm As DialogResult = MessageBox.Show("Generate report?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If confirm = DialogResult.Cancel Then

                ElseIf confirm = DialogResult.OK Then
                    Period = Monthly & "%" & Year
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdS = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_MONTH='" & Monthly & "' AND TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
                    daS = New OracleDataAdapter()
                    daS.SelectCommand = cmdS
                    dtS = New DataTable
                    daS.Fill(dtS)
                    For i As Integer = 0 To dtS.Rows.Count - 1
                        totS += CType(dtS.Rows(i)(3).ToString, Double)
                    Next
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdE = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE LIKE '" & Period & "'", con1)
                    daE = New OracleDataAdapter()
                    daE.SelectCommand = cmdE
                    dtE = New DataTable
                    daE.Fill(dtE)
                    For i As Integer = 0 To dtE.Rows.Count - 1
                        totE += CType(dtE.Rows(i)(4).ToString, Double)
                    Next
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdLD = New OracleCommand("SELECT * FROM RAW_LOSS_DAMAGE WHERE LOSSDMG_DATE LIKE '" & Period & "'", con1)
                    daLD = New OracleDataAdapter()
                    daLD.SelectCommand = cmdLD
                    dtLD = New DataTable
                    daLD.Fill(dtLD)
                    For i As Integer = 0 To dtLD.Rows.Count - 1
                        totLD += CType(dtLD.Rows(i)(4).ToString, Double)
                    Next
                    totI = totS - totE
                    chrInc.Series("Stats").Points.Clear()
                    chrInc.Series("Stats").Points.AddXY("Sales" & " " & "#PERCENT", totS)
                    chrInc.Series("Stats").Points.AddXY("Expenses" & " " & "#PERCENT", totE)
                End If
            End If
        ElseIf cbPeriod.SelectedIndex = 2 Then
            If txtPeriod.Text = Nothing Then
                MessageBox.Show("Please input year!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim confirm As DialogResult = MessageBox.Show("Generate report?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If confirm = DialogResult.Cancel Then

                ElseIf confirm = DialogResult.OK Then
                    Period = "%" & Year
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdS = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
                    daS = New OracleDataAdapter()
                    daS.SelectCommand = cmdS
                    dtS = New DataTable
                    daS.Fill(dtS)
                    For i As Integer = 0 To dtS.Rows.Count - 1
                        totS += CType(dtS.Rows(i)(3).ToString, Double)
                    Next
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdE = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE LIKE '" & Period & "'", con1)
                    daE = New OracleDataAdapter()
                    daE.SelectCommand = cmdE
                    dtE = New DataTable
                    daE.Fill(dtE)
                    For i As Integer = 0 To dtE.Rows.Count - 1
                        totE += CType(dtE.Rows(i)(4).ToString, Double)
                    Next
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmdLD = New OracleCommand("SELECT * FROM RAW_LOSS_DAMAGE WHERE LOSSDMG_DATE LIKE '" & Period & "'", con1)
                    daLD = New OracleDataAdapter()
                    daLD.SelectCommand = cmdLD
                    dtLD = New DataTable
                    daLD.Fill(dtLD)
                    For i As Integer = 0 To dtLD.Rows.Count - 1
                        totLD += CType(dtLD.Rows(i)(4).ToString, Double)
                    Next
                    totI = totS - totE
                    chrInc.Series("Stats").Points.Clear()
                    chrInc.Series("Stats").Points.AddXY("Sales" & " " & "#PERCENT", totS)
                    chrInc.Series("Stats").Points.AddXY("Expenses" & " " & "#PERCENT", totE)
                End If
            End If
        End If
    End Sub

    Private Sub txtDay_TextChanged(sender As Object, e As EventArgs) Handles txtDay.TextChanged
        If cbSIELD.SelectedIndex = 0 Then
            Sales()
        ElseIf cbSIELD.SelectedIndex = 1 Then
            Expenses()
        ElseIf cbSIELD.SelectedIndex = 2 Then
            LossDamage()
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGen.Click
        Try
            Dim Period, Daily, Day, Monthly, Year, BS1, BS2, BS3 As String
            Year = txtPeriod.Text.Trim
            Monthly = cbMonth.Text.Trim
            Day = txtDay.Text.Trim
            Daily = Monthly & "-" & Day
            Dim totS, totE, totLD, totI As Double
            If cbPeriod.SelectedIndex = 0 Then
                If txtDay.Text = Nothing Then
                    MessageBox.Show("Please input day!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf cbMonth.SelectedIndex = -1 Then
                    MessageBox.Show("Please select month!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf txtPeriod.Text = Nothing Then
                    MessageBox.Show("Please input year!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim confirm As DialogResult = MessageBox.Show("Generate report?", "Confirmation",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    If confirm = DialogResult.Cancel Then

                    ElseIf confirm = DialogResult.OK Then
                        Period = Daily + "-" + Year
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdS = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, 
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_MONTH='" & Monthly & "' AND TRANSACTIONS.TRANSACTION_DAY='" & Day & "' 
                                        AND TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, 
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
                        daS = New OracleDataAdapter()
                        daS.SelectCommand = cmdS
                        dtS = New DataTable
                        daS.Fill(dtS)
                        For i As Integer = 0 To dtS.Rows.Count - 1
                            totS += CType(dtS.Rows(i)(5).ToString, Double)
                        Next
                        'Try
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdE = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE='" & Period & "'", con1)
                        daE = New OracleDataAdapter()
                        daE.SelectCommand = cmdE
                        dtE = New DataTable
                        daE.Fill(dtE)
                        For i As Integer = 0 To dtE.Rows.Count - 1
                            totE += CType(dtE.Rows(i)(4).ToString, Double)
                        Next
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdLD = New OracleCommand("SELECT * FROM RAW_LOSS_DAMAGE WHERE LOSSDMG_DATE='" & Period & "'", con1)
                        daLD = New OracleDataAdapter()
                        daLD.SelectCommand = cmdLD
                        dtLD = New DataTable
                        daLD.Fill(dtLD)
                        For i As Integer = 0 To dtLD.Rows.Count - 1
                            totLD += CType(dtLD.Rows(i)(4).ToString, Double)
                        Next
                        totI = totS - totE
                        If dtS.Rows.Count = 0 Then
                            BS1 = "No product"
                            BS2 = "No product"
                            BS3 = "No product"
                        ElseIf dtS.Rows.Count = 1 Then
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(6).ToString
                            BS2 = "No product"
                            BS3 = "No product"
                        ElseIf dtS.Rows.Count = 2 Then
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(6).ToString
                            BS2 = dtS.Rows(1)(1).ToString & " = " & dtS.Rows(1)(6).ToString
                            BS3 = "No product"
                        Else
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(6).ToString
                            BS2 = dtS.Rows(1)(1).ToString & " = " & dtS.Rows(1)(6).ToString
                            BS3 = dtS.Rows(2)(1).ToString & " = " & dtS.Rows(2)(6).ToString
                        End If
                        Dim srdate As New ReportParameter("srdate", Period)
                        Dim sales As New ReportParameter("sales", totS)
                        Dim expenses As New ReportParameter("expenses", totE)
                        Dim income As New ReportParameter("income", totI)
                        Dim lossdamage As New ReportParameter("lossdamage", totLD)
                        Dim bestproduct1 As New ReportParameter("bestproduct1", BS1)
                        Dim bestproduct2 As New ReportParameter("bestproduct2", BS2)
                        Dim bestproduct3 As New ReportParameter("bestproduct3", BS3)


                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {srdate})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {sales})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {expenses})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {income})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {lossdamage})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct1})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct2})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct3})

                        IncomeReportForm.ReportViewer1.ShowParameterPrompts = True
                        IncomeReportForm.ReportViewer1.PrinterSettings.DefaultPageSettings.Landscape = False
                        IncomeReportForm.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                        IncomeReportForm.ReportViewer1.RefreshReport()
                        IncomeReportForm.Show()
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        Dim u, a, d, t As String
                        u = mainForm.lblAccount.Text
                        a = "Has generated sales report"
                        d = Date.Now.ToString("MMMM-dd-yyyy")
                        t = Now.ToString("HH:mm:ss")
                        Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                        cmd = New OracleCommand(sqllogs, con1)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        con1.Close()
                    End If
                End If
            ElseIf cbPeriod.SelectedIndex = 1 Then
                If cbMonth.SelectedIndex = -1 Then
                    MessageBox.Show("Please select month!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf txtPeriod.Text = Nothing Then
                    MessageBox.Show("Please input year!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim confirm As DialogResult = MessageBox.Show("Generate report?", "Confirmation",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    If confirm = DialogResult.Cancel Then

                    ElseIf confirm = DialogResult.OK Then
                        Period = Monthly & "%" & Year
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdS = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_MONTH='" & Monthly & "' AND TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_MONTH, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
                        daS = New OracleDataAdapter()
                        daS.SelectCommand = cmdS
                        dtS = New DataTable
                        daS.Fill(dtS)
                        For i As Integer = 0 To dtS.Rows.Count - 1
                            totS += CType(dtS.Rows(i)(3).ToString, Double)
                        Next
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdE = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE LIKE '" & Period & "'", con1)
                        daE = New OracleDataAdapter()
                        daE.SelectCommand = cmdE
                        dtE = New DataTable
                        daE.Fill(dtE)
                        For i As Integer = 0 To dtE.Rows.Count - 1
                            totE += CType(dtE.Rows(i)(4).ToString, Double)
                        Next
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdLD = New OracleCommand("SELECT * FROM RAW_LOSS_DAMAGE WHERE LOSSDMG_DATE LIKE '" & Period & "'", con1)
                        daLD = New OracleDataAdapter()
                        daLD.SelectCommand = cmdLD
                        dtLD = New DataTable
                        daLD.Fill(dtLD)
                        For i As Integer = 0 To dtLD.Rows.Count - 1
                            totLD += CType(dtLD.Rows(i)(4).ToString, Double)
                        Next
                        totI = totS - totE
                        If dtS.Rows.Count = 0 Then
                            BS1 = "No product"
                            BS2 = "No product"
                            BS3 = "No product"
                        ElseIf dtS.Rows.Count = 1 Then
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(5).ToString
                            BS2 = "No product"
                            BS3 = "No product"
                        ElseIf dtS.Rows.Count = 2 Then
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(5).ToString
                            BS2 = dtS.Rows(1)(1).ToString & " = " & dtS.Rows(1)(5).ToString
                            BS3 = "No product"
                        Else
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(5).ToString
                            BS2 = dtS.Rows(1)(1).ToString & " = " & dtS.Rows(1)(5).ToString
                            BS3 = dtS.Rows(2)(1).ToString & " = " & dtS.Rows(2)(5).ToString
                        End If
                        Dim srdate As New ReportParameter("srdate", Monthly & " " & Year)
                        Dim sales As New ReportParameter("sales", totS)
                        Dim expenses As New ReportParameter("expenses", totE)
                        Dim income As New ReportParameter("income", totI)
                        Dim lossdamage As New ReportParameter("lossdamage", totLD)
                        Dim bestproduct1 As New ReportParameter("bestproduct1", BS1)
                        Dim bestproduct2 As New ReportParameter("bestproduct2", BS2)
                        Dim bestproduct3 As New ReportParameter("bestproduct3", BS3)


                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {srdate})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {sales})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {expenses})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {income})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {lossdamage})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct1})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct2})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct3})

                        IncomeReportForm.ReportViewer1.ShowParameterPrompts = True
                        IncomeReportForm.ReportViewer1.PrinterSettings.DefaultPageSettings.Landscape = False
                        IncomeReportForm.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                        IncomeReportForm.ReportViewer1.RefreshReport()
                        IncomeReportForm.Show()
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        Dim u, a, d, t As String
                        u = mainForm.lblAccount.Text
                        a = "Has generated sales report"
                        d = Date.Now.ToString("MMMM-dd-yyyy")
                        t = Now.ToString("HH:mm:ss")
                        Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                        cmd = New OracleCommand(sqllogs, con1)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        con1.Close()
                    End If
                End If
            ElseIf cbPeriod.SelectedIndex = 2 Then
                If txtPeriod.Text = Nothing Then
                    MessageBox.Show("Please input year!", "Incomplete input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim confirm As DialogResult = MessageBox.Show("Generate report?", "Confirmation",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    If confirm = DialogResult.Cancel Then

                    ElseIf confirm = DialogResult.OK Then
                        Period = "%" & Year
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdS = New OracleCommand("SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_YEAR,
                                        SUM(TRANSACTIONS.PRICE),
                                        SUM(TRANSACTIONS.QUANTITY)
                                        FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                        WHERE TRANSACTIONS.TRANSACTION_YEAR='" & Year & "'
                                        GROUP BY PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, TRANSACTIONS.TRANSACTION_YEAR
                                        ORDER BY SUM(TRANSACTIONS.QUANTITY) DESC", con1)
                        daS = New OracleDataAdapter()
                        daS.SelectCommand = cmdS
                        dtS = New DataTable
                        daS.Fill(dtS)
                        For i As Integer = 0 To dtS.Rows.Count - 1
                            totS += CType(dtS.Rows(i)(3).ToString, Double)
                        Next
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdE = New OracleCommand("SELECT * FROM EXPENSES WHERE EXPENSES_DATE LIKE '" & Period & "'", con1)
                        daE = New OracleDataAdapter()
                        daE.SelectCommand = cmdE
                        dtE = New DataTable
                        daE.Fill(dtE)
                        For i As Integer = 0 To dtE.Rows.Count - 1
                            totE += CType(dtE.Rows(i)(4).ToString, Double)
                        Next
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        cmdLD = New OracleCommand("SELECT * FROM RAW_LOSS_DAMAGE WHERE LOSSDMG_DATE LIKE '" & Period & "'", con1)
                        daLD = New OracleDataAdapter()
                        daLD.SelectCommand = cmdLD
                        dtLD = New DataTable
                        daLD.Fill(dtLD)
                        For i As Integer = 0 To dtLD.Rows.Count - 1
                            totLD += CType(dtLD.Rows(i)(4).ToString, Double)
                        Next
                        totI = totS - totE
                        If dtS.Rows.Count = 0 Then
                            BS1 = "No product"
                            BS2 = "No product"
                            BS3 = "No product"
                        ElseIf dtS.Rows.Count = 1 Then
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(4).ToString
                            BS2 = "No product"
                            BS3 = "No product"
                        ElseIf dtS.Rows.Count = 2 Then
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(4).ToString
                            BS2 = dtS.Rows(1)(1).ToString & " = " & dtS.Rows(1)(4).ToString
                            BS3 = "No product"
                        Else
                            BS1 = dtS.Rows(0)(1).ToString & " = " & dtS.Rows(0)(4).ToString
                            BS2 = dtS.Rows(1)(1).ToString & " = " & dtS.Rows(1)(4).ToString
                            BS3 = dtS.Rows(2)(1).ToString & " = " & dtS.Rows(2)(4).ToString
                        End If
                        Dim srdate As New ReportParameter("srdate", Year)
                        Dim sales As New ReportParameter("sales", totS)
                        Dim expenses As New ReportParameter("expenses", totE)
                        Dim income As New ReportParameter("income", totI)
                        Dim lossdamage As New ReportParameter("lossdamage", totLD)
                        Dim bestproduct1 As New ReportParameter("bestproduct1", BS1)
                        Dim bestproduct2 As New ReportParameter("bestproduct2", BS2)
                        Dim bestproduct3 As New ReportParameter("bestproduct3", BS3)


                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {srdate})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {sales})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {expenses})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {income})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {lossdamage})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct1})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct2})
                        IncomeReportForm.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {bestproduct3})

                        IncomeReportForm.ReportViewer1.ShowParameterPrompts = True
                        IncomeReportForm.ReportViewer1.PrinterSettings.DefaultPageSettings.Landscape = False
                        IncomeReportForm.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                        IncomeReportForm.ReportViewer1.RefreshReport()
                        IncomeReportForm.Show()
                        con1 = New OracleConnection
                        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                        con1.Open()
                        Dim u, a, d, t As String
                        u = mainForm.lblAccount.Text
                        a = "Has generated sales report"
                        d = Date.Now.ToString("MMMM-dd-yyyy")
                        t = Now.ToString("HH:mm:ss")
                        Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                        cmd = New OracleCommand(sqllogs, con1)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        con1.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Insufficient information to generate report!", "Insufficient error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        dgvTH.DataSource = Search1()
    End Sub

    Private Sub btnSearchID_Click(sender As Object, e As EventArgs) Handles btnSearchID.Click
        Dim ID As String
        ID = txtSearch.Text
        con1 = New OracleConnection
        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
        con1.Open()
        cmd = New OracleCommand("SELECT TRANSACTIONS.ORDER_ID, PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, 
                                        TRANSACTIONS.QUANTITY, TRANSACTIONS.PRICE, TRANSACTIONS.TRANSACTION_MONTH,
                                        TRANSACTIONS.TRANSACTION_DAY, TRANSACTIONS.TRANSACTION_YEAR,
                                        TRANSACTIONS.TRANSACTION_TIME FROM TRANSACTIONS
                                        INNER JOIN PRODUCTS ON TRANSACTIONS.PRODUCT_ID=PRODUCTS.PRODUCT_ID
                                    WHERE ORDER_ID= '" & ID & "'", con1)
        da1 = New OracleDataAdapter()
        da1.SelectCommand = cmd
        dt = New DataTable
        da1.Fill(dt)
        dgvTH.DataSource = dt
    End Sub

    Private Sub cbSIELD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSIELD.SelectedIndexChanged
        If cbSIELD.SelectedIndex = 0 Then
            Sales()
        ElseIf cbSIELD.SelectedIndex = 1 Then
            Expenses()
        ElseIf cbSIELD.SelectedIndex = 2 Then
            LossDamage()
        End If
    End Sub

    Public Sub GenerateSales()

    End Sub

    Private Sub cbPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriod.SelectedIndexChanged
        If cbPeriod.SelectedIndex = -1 Then
            cbSIELD.Enabled = True
            cbMonth.Enabled = False
            txtPeriod.Enabled = False
            txtDay.Enabled = False
        ElseIf cbPeriod.SelectedIndex = 0 Then
            cbSIELD.Enabled = True
            cbMonth.Enabled = True
            txtPeriod.Enabled = True
            btnGen.Enabled = True
            txtDay.Enabled = True
        ElseIf cbPeriod.SelectedIndex = 1 Then
            cbSIELD.Enabled = True
            cbMonth.Enabled = True
            txtPeriod.Enabled = True
            txtDay.Enabled = False
            txtDay.Clear()
        ElseIf cbPeriod.SelectedIndex = 2 Then
            cbSIELD.Enabled = True
            cbMonth.Enabled = False
            txtPeriod.Enabled = True
            txtDay.Enabled = False
            txtDay.Clear()
            cbMonth.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtPeriod_TextChanged(sender As Object, e As EventArgs) Handles txtPeriod.TextChanged
        If cbSIELD.SelectedIndex = 0 Then
            Sales()
        ElseIf cbSIELD.SelectedIndex = 1 Then
            Expenses()
        ElseIf cbSIELD.SelectedIndex = 2 Then
            LossDamage()
        End If
    End Sub

    Private Sub cbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMonth.SelectedIndexChanged
        If cbSIELD.SelectedIndex = 0 Then
            Sales()
        ElseIf cbSIELD.SelectedIndex = 1 Then
            Expenses()
        ElseIf cbSIELD.SelectedIndex = 2 Then
            LossDamage()
        End If
    End Sub

    Private Sub txtDay_MouseHover(sender As Object, e As EventArgs) Handles txtDay.MouseHover
        ToolTip1.Show("Day", txtDay)
    End Sub

    Private Sub txtPeriod_MouseHover(sender As Object, e As EventArgs) Handles txtPeriod.MouseHover
        ToolTip1.Show("Year", txtPeriod)
    End Sub

    Private Sub cbMonth_MouseHover(sender As Object, e As EventArgs) Handles cbMonth.MouseHover
        ToolTip1.Show("Month", cbMonth)
    End Sub
End Class