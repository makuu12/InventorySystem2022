Imports System.Net
Imports System.Security.Cryptography
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Oracle.ManagedDataAccess.Client

Public Class orderForm
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim da2 As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim cmd As OracleCommand
    Dim cmd1 As OracleCommand
    Dim dt As DataTable
    Dim dt1 As DataTable
    Dim ds As DataSet
    Dim rescount As Byte
    Dim n As String = Environment.NewLine

    Private Sub MakeProperCase(sender As Object, e As EventArgs) Handles _
         txtSearch.TextChanged
        Dim n As Integer = sender.SelectionStart
        sender.Text = StrConv(sender.Text, VbStrConv.ProperCase)
        sender.SelectionStart = n
        If txtSearch.Text = Nothing Or txtSearch.Text = "" Then
            Products()
        End If
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = Nothing Or txtSearch.Text = " " Then
            Products()
        Else
            dgvMenu.DataSource = Search1()
        End If
    End Sub
    Public Sub Products()
        If cbxDrink.Checked = True And cbxFoods.Checked = False Then
            Try
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                cmd = New OracleCommand("SELECT * FROM PRODUCTS WHERE CATEGORY='DRINK'", con1)
                con1.Open()
                da1 = New OracleDataAdapter()
                da1.SelectCommand = cmd
                dt = New DataTable
                da1.Fill(dt)
                dgvMenu.DataSource = dt
                With dgvMenu
                    .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                    .DefaultCellStyle.SelectionForeColor = Color.White
                    .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                    .DefaultCellStyle.ForeColor = Color.Black
                    .Columns(0).HeaderCell.Value = "Product ID"
                    .Columns(0).Width = 100
                    .Columns(1).HeaderCell.Value = "Product Name"
                    .Columns(1).Width = 200
                    .Columns(2).HeaderCell.Value = "Price"
                    .Columns(2).Width = 150
                    .Columns(3).HeaderCell.Value = "Category"
                    .Columns(3).Width = 150
                End With
            Catch ex As Exception

            End Try
        ElseIf cbxFoods.Checked = True And cbxDrink.Checked = False Then
            Try
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                cmd = New OracleCommand("SELECT * FROM PRODUCTS WHERE CATEGORY='FOOD'", con1)
                con1.Open()
                da1 = New OracleDataAdapter()
                da1.SelectCommand = cmd
                dt = New DataTable
                da1.Fill(dt)
                dgvMenu.DataSource = dt
                With dgvMenu
                    .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                    .DefaultCellStyle.SelectionForeColor = Color.White
                    .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                    .DefaultCellStyle.ForeColor = Color.Black
                    .Columns(0).HeaderCell.Value = "Product ID"
                    .Columns(0).Width = 100
                    .Columns(1).HeaderCell.Value = "Product Name"
                    .Columns(1).Width = 200
                    .Columns(2).HeaderCell.Value = "Price"
                    .Columns(2).Width = 150
                    .Columns(3).HeaderCell.Value = "Category"
                    .Columns(3).Width = 150
                End With
            Catch ex As Exception

            End Try
        ElseIf cbxFoods.Checked = True And cbxDrink.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT * FROM PRODUCTS", con1)
            con1.Open()
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvMenu.DataSource = dt
            With dgvMenu
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Product ID"
                .Columns(0).Width = 100
                .Columns(1).HeaderCell.Value = "Product Name"
                .Columns(1).Width = 200
                .Columns(2).HeaderCell.Value = "Price"
                .Columns(2).Width = 150
                .Columns(3).HeaderCell.Value = "Category"
                .Columns(3).Width = 150
            End With
        ElseIf cbxFoods.Checked = False And cbxDrink.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT * FROM PRODUCTS", con1)
            con1.Open()
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvMenu.DataSource = dt
            With dgvMenu
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Product ID"
                .Columns(0).Width = 100
                .Columns(1).HeaderCell.Value = "Product Name"
                .Columns(1).Width = 200
                .Columns(2).HeaderCell.Value = "Price"
                .Columns(2).Width = 150
                .Columns(3).HeaderCell.Value = "Category"
                .Columns(3).Width = 150
            End With
        End If
    End Sub

    Private Sub orderForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Products()
    End Sub

    Private Sub total()
        Dim tot As Double
        For i As Integer = 0 To dgvOrder.Rows.Count - 1
            tot += dgvOrder.Rows(i).Cells(3).Value
        Next
        lblTotal.Text = "TOTAL: ₱" + tot.ToString()
    End Sub

    Private Sub btnProc_Click(sender As Object, e As EventArgs) Handles btnProc.Click
        Dim available As Integer = 0
        Dim process As Integer = 0
        'Try
        If dgvOrder.RowCount = 0 Then
            MessageBox.Show("There are no items in the order list!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Process order?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                Dim OID As String
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                Dim sqlOID As String = "SELECT * FROM (SELECT * FROM TRANSACTIONS ORDER BY ORDER_ID DESC ) WHERE ROWNUM = 1"
                cmd = New OracleCommand(sqlOID, con1)
                cmd.CommandType = CommandType.Text
                da1 = New OracleDataAdapter
                da1.SelectCommand = cmd
                dt = New DataTable
                da1.Fill(dt)
                If dt.Rows.Count <> 0 Then
                    Dim NOID As Integer = 0
                    NOID = dt.Rows(0)(1).ToString
                    OID = CInt(NOID) + 1
                Else
                    OID = "1"
                End If
                Dim PID, RID, Day, Month, Year, P, u, a, d, t As String
                Dim NQTY, QTY, IQTY, NIQTY As Double
                Day = Date.Now.ToString("dd")
                Month = Date.Now.ToString("MMMM")
                Year = Date.Now.ToString("yyyy")
                u = mainForm.lblAccount.Text
                a = "Has processed an order"
                d = Date.Now.ToString("MMMM-dd-yyyy")
                t = Now.ToString("HH:mm:ss")
                For i As Integer = 0 To dgvOrder.Rows.Count - 1
                    PID = dgvOrder.Rows(i).Cells(0).Value.ToString
                    QTY = CType(dgvOrder.Rows(i).Cells(2).Value.ToString, Double)
                    P = dgvOrder.Rows(i).Cells(3).Value.ToString
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmd = New OracleCommand("SELECT product_ing.ingredient_id, products.product_id, raw_materials.raw_id, 
                                        raw_materials.raw_name, product_ing.quantity, raw_materials.quantity, raw_materials.measure FROM PRODUCT_ING
                                        INNER JOIN PRODUCTS ON product_ing.product_id=products.product_id
                                        INNER JOIN RAW_MATERIALS ON product_ing.raw_id=raw_materials.raw_id
                                        WHERE product_ing.product_id= '" & PID & "' ", con1)
                    da2 = New OracleDataAdapter()
                    da2.SelectCommand = cmd
                    dt1 = New DataTable
                    da2.Fill(dt1)
                    For j As Integer = 0 To dt1.Rows.Count - 1
                        RID = dt1.Rows(j)(2).ToString
                        NQTY = CType(dt1.Rows(j)(4).ToString, Double) * QTY
                        IQTY = CType(dt1.Rows(j)(5).ToString, Double)
                        NIQTY = IQTY - NQTY
                        If NIQTY > 0 Then
                            If NIQTY < IQTY Then
                                con1 = New OracleConnection
                                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                                con1.Open()
                                cmd1 = New OracleCommand("UPDATE RAW_MATERIALS SET QUANTITY= '" & NIQTY & "' WHERE RAW_ID= '" & RID & "' ", con1)
                                cmd1.CommandType = CommandType.Text
                                cmd1.ExecuteNonQuery()
                            ElseIf NIQTY > IQTY Then
                                available = available + 1
                            End If
                        ElseIf NIQTY < 0 Then
                            available = available + 1
                        End If
                    Next
                    If available = 0 Then
                        Dim sqlOrder = "INSERT INTO TRANSACTIONS (ORDER_ID, PRODUCT_ID, QUANTITY, PRICE, TRANSACTION_MONTH, TRANSACTION_DAY, TRANSACTION_YEAR, TRANSACTION_TIME) VALUES 
                                        ('" & OID & "','" & PID & "','" & QTY & "','" & P & "','" & Month & "','" & Day & "','" & Year & "','" & t & "')"
                        cmd = New OracleCommand(sqlOrder, con1)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                        ('" & u & "','" & a & "','" & d & "','" & t & "')"
                        cmd = New OracleCommand(sqllogs, con1)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                    ElseIf available > 0 Then
                        process = process + 1
                    End If
                Next
                If process = 0 Then
                    MessageBox.Show("Order has been successfully recorded!", "Transaction successful!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvOrder.Rows.Clear()
                    InventoryForm.Inventory()
                    mainForm.checkInv()
                    con1.Close()
                ElseIf process > 0 Then
                    MessageBox.Show("Insufficient raw materials, order did not process!", "Insufficient Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.StackTrace)
        'End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim row As ArrayList
        Dim qty, price, MQTY, IQTY, NIQTY As Double
        Dim row_total As Integer
        Dim current_row As Integer = dgvMenu.CurrentRow.Index
        Dim added As Boolean
        Dim PID As String
        PID = dgvMenu(0, current_row).Value
        Dim available As Integer = 0
        Dim avail As Integer = 0
        Dim add_order As Integer = 0
        For Each order As DataGridViewRow In dgvOrder.Rows
            If order.Cells(0).Value = dgvMenu(0, current_row).Value Then
                added = True
            End If
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT product_ing.ingredient_id, products.product_id, raw_materials.raw_id, 
                                        raw_materials.raw_name, product_ing.quantity, raw_materials.quantity, raw_materials.measure FROM PRODUCT_ING
                                        INNER JOIN PRODUCTS ON product_ing.product_id=products.product_id
                                        INNER JOIN RAW_MATERIALS ON product_ing.raw_id=raw_materials.raw_id
                                        WHERE product_ing.product_id= '" & PID & "' ", con1)
            da2 = New OracleDataAdapter()
            da2.SelectCommand = cmd
            dt1 = New DataTable
            da2.Fill(dt1)
            If added = True Then
                order.Cells(2).Value = CInt(order.Cells(2).Value) + 1
                qty = CInt(order.Cells(2).Value)
                For j As Integer = 0 To dt1.Rows.Count - 1
                    MQTY = CType(dt1.Rows(j)(4).ToString, Double) * qty
                    IQTY = CType(dt1.Rows(j)(5).ToString, Double)
                    NIQTY = IQTY - MQTY
                    If NIQTY > 0 Then
                        If NIQTY > IQTY Then
                            avail = avail + 1
                        End If
                    ElseIf NIQTY < 0 Then
                        avail = avail + 1
                    End If
                Next
                If avail = 0 Then
                    cmd = New OracleCommand("SELECT PRICE FROM PRODUCTS WHERE PRODUCT_ID='" & PID & "'", con1)
                    da1 = New OracleDataAdapter()
                    da1.SelectCommand = cmd
                    dt = New DataTable
                    da1.Fill(dt)
                    price = CInt(dt.Rows(0)(0).ToString)
                    row_total = qty * price
                    order.Cells(3).Value = row_total
                    total()
                    con1.Close()
                ElseIf avail > 0 Then
                    add_order = add_order + 1
                End If
                If add_order > 0 Then
                    MessageBox.Show("Insufficient raw materials, product is unavailable!", "Insufficient Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    order.Cells(2).Value = CInt(order.Cells(2).Value) - 1
                    total()
                End If
                Exit For
            End If
        Next
        If Not added Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT product_ing.ingredient_id, products.product_id, raw_materials.raw_id, 
                                        raw_materials.raw_name, product_ing.quantity, raw_materials.quantity, raw_materials.measure FROM PRODUCT_ING
                                        INNER JOIN PRODUCTS ON product_ing.product_id=products.product_id
                                        INNER JOIN RAW_MATERIALS ON product_ing.raw_id=raw_materials.raw_id
                                        WHERE product_ing.product_id= '" & PID & "' ", con1)
            da2 = New OracleDataAdapter()
            da2.SelectCommand = cmd
            dt1 = New DataTable
            da2.Fill(dt1)
            For j As Integer = 0 To dt1.Rows.Count - 1
                MQTY = CType(dt1.Rows(j)(4).ToString, Double)
                IQTY = CType(dt1.Rows(j)(5).ToString, Double)
                If MQTY > IQTY Then
                    available = available + 1
                End If
            Next
            If available = 0 Then
                row = New ArrayList
                row.Add(dgvMenu(0, current_row).Value)
                row.Add(dgvMenu(1, current_row).Value)
                row.Add(1)
                row.Add(dgvMenu(2, current_row).Value)
                dgvOrder.Rows.Add(row.ToArray())
                total()
            ElseIf available > 0 Then
                MessageBox.Show("Insufficient raw materials, product is unavailable!", "Insufficient Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        If dgvOrder.RowCount = 0 Then
            MessageBox.Show("There are no items in the order list!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim PID As String
            Dim current_row As Integer = dgvOrder.CurrentRow.Index
            Dim quantity, new_quantity, prod_id, row_total As Integer
            Dim qty, price, MQTY, IQTY, NIQTY As Double
            Dim avail As Integer = 0
            Dim add_order As Integer = 0
            quantity = CInt(dgvOrder(2, current_row).Value)
            new_quantity = quantity + 1
            PID = dgvOrder(0, current_row).Value
            con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                cmd = New OracleCommand("SELECT product_ing.ingredient_id, products.product_id, raw_materials.raw_id, 
                                        raw_materials.raw_name, product_ing.quantity, raw_materials.quantity, raw_materials.measure FROM PRODUCT_ING
                                        INNER JOIN PRODUCTS ON product_ing.product_id=products.product_id
                                        INNER JOIN RAW_MATERIALS ON product_ing.raw_id=raw_materials.raw_id
                                        WHERE product_ing.product_id= '" & PID & "' ", con1)
                da2 = New OracleDataAdapter()
                da2.SelectCommand = cmd
                dt1 = New DataTable
                da2.Fill(dt1)
            dgvOrder(2, current_row).Value = CInt(dgvOrder(2, current_row).Value) + 1
            qty = CInt(dgvOrder(2, current_row).Value)
            For j As Integer = 0 To dt1.Rows.Count - 1
                    MQTY = CType(dt1.Rows(j)(4).ToString, Double) * qty
                    IQTY = CType(dt1.Rows(j)(5).ToString, Double)
                    NIQTY = IQTY - MQTY
                    If NIQTY > 0 Then
                        If NIQTY > IQTY Then
                            avail = avail + 1
                        End If
                    ElseIf NIQTY < 0 Then
                        avail = avail + 1
                    End If
                Next
                If avail = 0 Then
                    cmd = New OracleCommand("SELECT PRICE FROM PRODUCTS WHERE PRODUCT_ID='" & PID & "'", con1)
                    da1 = New OracleDataAdapter()
                    da1.SelectCommand = cmd
                    dt = New DataTable
                    da1.Fill(dt)
                    price = CInt(dt.Rows(0)(0).ToString)
                    row_total = qty * price
                   dgvOrder(3, current_row).Value = row_total
                    total()
                    con1.Close()
                ElseIf avail > 0 Then
                    add_order = add_order + 1
                End If
            If add_order > 0 Then
                dgvOrder(2, current_row).Value = CInt(dgvOrder(2, current_row).Value) - 1
                total()
                MessageBox.Show("Insufficient raw materials, product is unavailable!", "Insufficient Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        If dgvOrder.RowCount = 0 Then
            MessageBox.Show("There are no items in the order list!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim current_row As Integer = dgvOrder.CurrentRow.Index
            Dim quantity, new_quantity, prod_id, new_price As Integer
            For Each order As DataGridViewRow In dgvOrder.Rows
                prod_id = CInt(dgvOrder(0, current_row).Value)
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                cmd = New OracleCommand("SELECT PRICE FROM PRODUCTS WHERE PRODUCT_ID='" & prod_id & "'", con1)
                da1 = New OracleDataAdapter()
                da1.SelectCommand = cmd
                dt = New DataTable
                da1.Fill(dt)
                new_price = CInt(dgvOrder(3, current_row).Value) - CInt(dt.Rows(0)(0).ToString)
                quantity = CInt(dgvOrder(2, current_row).Value)
                new_quantity = quantity - 1
                dgvOrder(2, current_row).Value = new_quantity
                dgvOrder(3, current_row).Value = new_price
                total()
                con1.Close()
                If dgvOrder(2, current_row).Value = 0 And dgvOrder(3, current_row).Value = 0 Then
                    dgvOrder.Rows.RemoveAt(dgvOrder.CurrentRow.Index)
                End If
                Exit For
            Next
        End If
    End Sub
    Private Sub btnCanAll_Click(sender As Object, e As EventArgs) Handles btnCanAll.Click
        Dim confirm As DialogResult = MessageBox.Show("Cancel transaction?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If confirm = DialogResult.Cancel Then

        ElseIf confirm = DialogResult.OK Then
            dgvOrder.Rows.Clear()
            total()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim confirm As DialogResult = MessageBox.Show("Cancel selected product?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If confirm = DialogResult.Cancel Then

        ElseIf confirm = DialogResult.OK Then
            If dgvOrder.RowCount = 0 Then
                MessageBox.Show("There are no items in the order list!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                dgvOrder.Rows.RemoveAt(dgvOrder.CurrentRow.Index)
                total()
            End If
        End If
    End Sub

    Public Function Search1() As DataTable
        If cbxDrink.Checked = True And cbxFoods.Checked = False Then
            Dim keyword As String
            keyword = txtSearch.Text.Trim
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT * FROM PRODUCTS WHERE CATEGORY='DRINK' AND PRODUCT_NAME LIKE '%" & keyword & "%'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            Return dt
        ElseIf cbxFoods.Checked = True And cbxDrink.Checked = False Then
            Dim keyword As String
            keyword = txtSearch.Text.Trim
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT * FROM PRODUCTS WHERE CATEGORY='FOOD' AND PRODUCT_NAME LIKE '%" & keyword & "%'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            Return dt
        ElseIf cbxFoods.Checked = True And cbxDrink.Checked = True Then
            Dim keyword As String
            keyword = txtSearch.Text.Trim
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_NAME LIKE '%" & keyword & "%'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            Return dt
        ElseIf cbxFoods.Checked = False And cbxDrink.Checked = False Then
            Dim keyword As String
            keyword = txtSearch.Text.Trim
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_NAME LIKE '%" & keyword & "%'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            Return dt
        End If
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        dgvMenu.DataSource = Search1()
    End Sub

    Private Sub cbxDrink_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDrink.CheckedChanged, cbxFoods.CheckedChanged
        If cbxDrink.Checked = True And cbxFoods.Checked = False Then
            Try
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                cmd = New OracleCommand("SELECT * FROM PRODUCTS WHERE CATEGORY='DRINK'", con1)
                con1.Open()
                da1 = New OracleDataAdapter()
                da1.SelectCommand = cmd
                dt = New DataTable
                da1.Fill(dt)
                dgvMenu.DataSource = dt
                With dgvMenu
                    .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                    .DefaultCellStyle.SelectionForeColor = Color.White
                    .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                    .DefaultCellStyle.ForeColor = Color.Black
                    .Columns(0).HeaderCell.Value = "Product ID"
                    .Columns(0).Width = 100
                    .Columns(1).HeaderCell.Value = "Product Name"
                    .Columns(1).Width = 200
                    .Columns(2).HeaderCell.Value = "Price"
                    .Columns(2).Width = 150
                    .Columns(3).HeaderCell.Value = "Category"
                    .Columns(3).Width = 150
                End With
            Catch ex As Exception

            End Try
        ElseIf cbxFoods.Checked = True And cbxDrink.Checked = False Then
            Try
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                cmd = New OracleCommand("SELECT * FROM PRODUCTS WHERE CATEGORY='FOOD'", con1)
                con1.Open()
                da1 = New OracleDataAdapter()
                da1.SelectCommand = cmd
                dt = New DataTable
                da1.Fill(dt)
                dgvMenu.DataSource = dt
                With dgvMenu
                    .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                    .DefaultCellStyle.SelectionForeColor = Color.White
                    .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                    .DefaultCellStyle.ForeColor = Color.Black
                    .Columns(0).HeaderCell.Value = "Product ID"
                    .Columns(0).Width = 100
                    .Columns(1).HeaderCell.Value = "Product Name"
                    .Columns(1).Width = 200
                    .Columns(2).HeaderCell.Value = "Price"
                    .Columns(2).Width = 150
                    .Columns(3).HeaderCell.Value = "Category"
                    .Columns(3).Width = 150
                End With
            Catch ex As Exception

            End Try
        ElseIf cbxFoods.Checked = True And cbxDrink.Checked = True Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT * FROM PRODUCTS", con1)
            con1.Open()
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvMenu.DataSource = dt
            With dgvMenu
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Product ID"
                .Columns(0).Width = 100
                .Columns(1).HeaderCell.Value = "Product Name"
                .Columns(1).Width = 200
                .Columns(2).HeaderCell.Value = "Price"
                .Columns(2).Width = 150
                .Columns(3).HeaderCell.Value = "Category"
                .Columns(3).Width = 150
            End With
        ElseIf cbxFoods.Checked = False And cbxDrink.Checked = False Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT * FROM PRODUCTS", con1)
            con1.Open()
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvMenu.DataSource = dt
            With dgvMenu
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Product ID"
                .Columns(0).Width = 100
                .Columns(1).HeaderCell.Value = "Product Name"
                .Columns(1).Width = 200
                .Columns(2).HeaderCell.Value = "Price"
                .Columns(2).Width = 150
                .Columns(3).HeaderCell.Value = "Category"
                .Columns(3).Width = 150
            End With
        End If
    End Sub
End Class