Imports System.Windows.Forms.AxHost
Imports Oracle.ManagedDataAccess.Client

Public Class InventoryForm
    Dim ran = New Random
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim da2 As OracleDataAdapter
    Dim da3 As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim cmd As OracleCommand
    Dim cmd1 As OracleCommand
    Dim cmd2 As OracleCommand
    Dim dt As DataTable
    Dim dt1 As DataTable
    Dim n As String = Environment.NewLine

    Private Sub MakeProperCase(sender As Object, e As EventArgs) Handles _
         txtSearch.TextChanged, txtRaw.TextChanged
        Dim n As Integer = sender.SelectionStart
        sender.Text = StrConv(sender.Text, VbStrConv.ProperCase)
        sender.SelectionStart = n
    End Sub
    Private Sub NumberOnly(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress, txtCap.KeyPress, txtPrice.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
            End If
        End If
    End Sub
    Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Inventory()
        ColorCode()
        dtpExp.Format = DateTimePickerFormat.Custom
        dtpExp.CustomFormat = "MMMM-dd-yyyy"
        dtpExp.Value = Today
    End Sub
    Public Sub Inventory()
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT * FROM RAW_MATERIALS", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvInv.DataSource = dt
            With dgvInv
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Raw ID"
                '.Columns(0).Width = 100
                .Columns(1).HeaderCell.Value = "Raw Name"
                '.Columns(1).Width = 200
                .Columns(2).HeaderCell.Value = "Quantity"
                '.Columns(2).Width = 150
                .Columns(3).HeaderCell.Value = "Capacity"
                '.Columns(3).Width = 150
                .Columns(4).HeaderCell.Value = "Measure"
                .Columns(5).HeaderCell.Value = "Price"
                .Columns(6).HeaderCell.Value = "Expiration"
            End With
            ColorCode()
            Dim expdate, tdate, RN, QTY, M, P, LD, d As String
            For i As Integer = 0 To dgvInv.Rows.Count - 1
                expdate = dgvInv.Rows(i).Cells(6).Value.ToString
                tdate = Today.ToString("MMMM-dd-yyyy")
                If expdate = tdate Then
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmd2 = New OracleCommand("SELECT * FROM RAW_MATERIALS WHERE EXPIRATION= '" & tdate & "'", con1)
                    da3 = New OracleDataAdapter()
                    da3.SelectCommand = cmd2
                    dt1 = New DataTable
                    da3.Fill(dt1)
                    RN = dt1.Rows(0)(1).ToString.Trim
                    QTY = dt1.Rows(0)(2).ToString.Trim
                    M = dt1.Rows(0)(4).ToString.Trim
                    P = dt1.Rows(0)(5).ToString.Trim
                    LD = "Expired"
                    d = tdate
                    Dim sqlLD = "INSERT INTO RAW_LOSS_DAMAGE (RAW_NAME, QUANTITY, MEASURE, PRICE, STATUS, LOSSDMG_DATE) VALUES 
                                ('" & RN & "','" & QTY & "','" & M & "','" & P & "','" & LD & "','" & d & "')"
                    cmd = New OracleCommand(sqlLD, con1)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    Dim sqlRawDel = "DELETE FROM RAW_MATERIALS WHERE EXPIRATION= '" & tdate & "' "
                    cmd = New OracleCommand(sqlRawDel, con1)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("A raw material has expired", "Raw material expired!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ColorCode()
        Dim qty, cap, min As Double
        For i As Integer = 0 To dgvInv.RowCount - 1
            qty = CType(dgvInv.Rows(i).Cells(2).Value, Double)
            cap = CType(dgvInv.Rows(i).Cells(3).Value, Double)
            min = CType(dgvInv.Rows(i).Cells(3).Value, Double) * 0.1
            If qty = 0 Then
                dgvInv.Rows(i).Cells(2).Style.BackColor = Color.Red
                'inv.Cells(2).Style.ForeColor = Color.Black
                dgvInv.Rows(i).Cells(2).Style.SelectionBackColor = Color.Red
                'inv.Cells(2).Style.SelectionForeColor = Color.Black
                dgvInv.Rows(i).Cells(2).Style.SelectionForeColor = Color.Black
            ElseIf qty <= min Then
                dgvInv.Rows(i).Cells(2).Style.BackColor = Color.Orange
                dgvInv.Rows(i).Cells(2).Style.SelectionBackColor = Color.Orange
                dgvInv.Rows(i).Cells(2).Style.SelectionForeColor = Color.Black
            ElseIf qty > min And qty < cap Then
                dgvInv.Rows(i).Cells(2).Style.BackColor = Color.Yellow
                dgvInv.Rows(i).Cells(2).Style.SelectionBackColor = Color.Yellow
                dgvInv.Rows(i).Cells(2).Style.SelectionForeColor = Color.Black
            ElseIf qty = cap Then
                dgvInv.Rows(i).Cells(2).Style.BackColor = Color.YellowGreen
                dgvInv.Rows(i).Cells(2).Style.SelectionBackColor = Color.YellowGreen
                dgvInv.Rows(i).Cells(2).Style.SelectionForeColor = Color.Black
            ElseIf qty > cap Then
                dgvInv.Rows(i).Cells(2).Style.BackColor = Color.Green
                dgvInv.Rows(i).Cells(2).Style.SelectionBackColor = Color.Green
                dgvInv.Rows(i).Cells(2).Style.SelectionForeColor = Color.Black
            End If
        Next
    End Sub
    Public Sub ClearAll()
        txtRawID.Clear()
        txtRaw.Clear()
        txtQuantity.Clear()
        txtCap.Clear()
        txtPrice.Clear()
        dtpExp.CustomFormat = "MMMM-dd-yyyy"
        dtpExp.Value = Today
        rbtnML.Checked = False
        rbtnGrams.Checked = False
        rbtnPiece.Checked = False
        cbxEXP.Checked = False
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim RID, RN, M, P, QTY, CAP, EXP, TEXPE, u, a, d, t As String
        RN = txtRaw.Text.Trim
        QTY = txtQuantity.Text.Trim
        CAP = txtCap.Text.Trim
        P = txtPrice.Text.Trim
        If cbxEXP.Checked = True Then
            EXP = "No Expiration"
        ElseIf cbxEXP.Checked = False Then
            EXP = dtpExp.Value.ToString("MMMM-dd-yyyy")
        End If
        u = mainForm.lblAccount.Text
        a = "Has added raw material/s"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If rbtnML.Checked = True Then
            M = "ML"
        ElseIf rbtnGrams.Checked = True Then
            M = "Grams"
        ElseIf rbtnPiece.Checked = True Then
            M = "Piece/s"
        End If
        If RN = Nothing Then
            MessageBox.Show("Please input a raw material!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf QTY = Nothing Then
            MessageBox.Show("Please input the quantity of the raw material!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf CAP = Nothing Then
            MessageBox.Show("Please input the capacity of the raw material!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf M = Nothing Then
            MessageBox.Show("Please select a quantity measurement!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf P = Nothing Then
            MessageBox.Show("Please input the price of the raw material!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf EXP = Nothing Then
            MessageBox.Show("Please input the expiration date of the raw material!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf EXP = Today.ToString("MMMM-dd-yyyy") Then
            MessageBox.Show("The raw material expires today!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf EXP < Today.ToString("MMMM-dd-yyyy") Then
            MessageBox.Show("The raw material has already expired!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Insert raw material?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                con1.Open()
                Dim sqlRawAdd = "INSERT INTO RAW_MATERIALS (RAW_NAME, QUANTITY, CAPACITY,
                                    MEASURE, PRICE, EXPIRATION) VALUES ('" & RN & "','" & QTY & "','" & CAP & "','" & M & "','" & P & "','" & EXP & "')"
                cmd = New OracleCommand(sqlRawAdd, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqlRID = "SELECT * FROM (SELECT * FROM RAW_MATERIALS ORDER BY RAW_ID DESC ) WHERE ROWNUM = 1"
                cmd1 = New OracleCommand(sqlRID, con1)
                cmd1.CommandType = CommandType.Text
                da2 = New OracleDataAdapter
                da2.SelectCommand = cmd1
                dt = New DataTable
                da2.Fill(dt)
                RID = dt.Rows(0)(0).ToString
                Dim sqlRawLogs = "INSERT INTO RAW_LOGS (ACCOUNT_USER, RAW_NAME, MODIFICATION,
                                    QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME) VALUES 
                                    ('" & u & "','" & RN & "','" & a & "','" & QTY & "','" & CAP & "',
                                    '" & M & "','" & P & "','" & EXP & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqlRawLogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqlExpe = "INSERT INTO EXPENSES (RAW_NAME, QUANTITY, MEASURE, TOTAL_EXPENSES, EXPENSES_DATE) VALUES ('" & RN & "','" & QTY & "','" & M & "','" & P & "','" & d & "')"
                cmd = New OracleCommand(sqlExpe, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqlLogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqlLogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Raw material has been successfully added!", "Raw material added!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Inventory()
                ColorCode()
                ClearAll()
                LogsForm.LoadLogs()
                'mainForm.checkInv()
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateForm.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        txtRaw.Enabled = True
        txtCap.Enabled = True
        txtPrice.Enabled = True
        dtpExp.Enabled = True
        rbtnML.Enabled = True
        rbtnGrams.Enabled = True
        rbtnPiece.Enabled = True
        cbxEXP.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        con1.Open()
        Dim ID, RN, M, P, EXP, u, a, d, t As String
        Dim QTY, CAP As Double
        ID = txtRawID.Text.Trim
        RN = txtRaw.Text.Trim
        QTY = CType(txtQuantity.Text.Trim, Double)
        CAP = CType(txtCap.Text.Trim, Double)
        P = txtPrice.Text.Trim
        If cbxEXP.Checked = True Then
            EXP = "No Expiration"
        Else
            EXP = dtpExp.Value.ToString("MMMM-dd-yyyy").Trim
        End If
        u = mainForm.lblAccount.Text
        a = "Has deleted a raw material/s"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If rbtnML.Checked = True Then
            M = "ML"
        ElseIf rbtnGrams.Checked = True Then
            M = "Grams"
        ElseIf rbtnPiece.Checked = True Then
            M = "Piece/s"
        End If
        If QTY > 0 Then
            MessageBox.Show("Quantity must be empty to delete!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Delete raw material?", "Confirmation",
                                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                Dim sqlRawDel = "DELETE FROM RAW_MATERIALS WHERE RAW_ID= '" & ID & "' "
                cmd = New OracleCommand(sqlRawDel, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqlRawLogs = "INSERT INTO RAW_LOGS (ACCOUNT_USER, RAW_NAME, MODIFICATION,
                                    QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME) VALUES 
                                    ('" & u & "','" & RN & "','" & a & "','" & QTY & "','" & CAP & "',
                                    '" & M & "','" & P & "','" & EXP & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqlRawLogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqllogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Raw material has been successfully deleted!", "Deleted successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                mainForm.checkInv()
                ClearAll()
                Inventory()
                ColorCode()
                LogsForm.LoadLogs()
            End If
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        txtRaw.Text = "Milk" + Convert.ToString(ran.Next(1, 10))
        txtQuantity.Text = (ran.Next(200, 1000))
        txtPrice.Text = (ran.Next(200, 1000))
        txtCap.Text = (ran.Next(200, 1000))
        rbtnML.Checked = True
    End Sub
    Private Sub dgvInv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInv.CellClick
        Dim current_row As Integer = dgvInv.CurrentRow.Index
        txtRawID.Text = dgvInv(0, current_row).Value.ToString
        txtRaw.Text = dgvInv(1, current_row).Value.ToString
        txtQuantity.Text = dgvInv(2, current_row).Value.ToString
        txtCap.Text = dgvInv(3, current_row).Value.ToString
        txtPrice.Text = dgvInv(5, current_row).Value.ToString
        If dgvInv(4, current_row).Value.ToString = "ML" Then
            rbtnML.Checked = True
        ElseIf dgvInv(4, current_row).Value.ToString = "Grams" Then
            rbtnGrams.Checked = True
        ElseIf dgvInv(4, current_row).Value.ToString = "Piece/s" Then
            rbtnPiece.Checked = True
        End If

        If dgvInv(6, current_row).Value.ToString = "No Expiration" Then
            cbxEXP.Checked = True
        Else
            cbxEXP.Checked = False
            dtpExp.Value = dgvInv(6, current_row).Value
        End If
        txtRaw.Enabled = False
        txtQuantity.Enabled = False
        txtCap.Enabled = False
        txtPrice.Enabled = False
        dtpExp.Enabled = False
        rbtnML.Enabled = False
        rbtnGrams.Enabled = False
        rbtnPiece.Enabled = False
        cbxEXP.Enabled = False
        btnAdd.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        btnClear.Enabled = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAll()
    End Sub
    Private Sub txtRawID_TextChanged(sender As Object, e As EventArgs) Handles txtRawID.TextChanged
        If txtRawID.Text = Nothing Then
            txtRaw.Enabled = True
            txtQuantity.Enabled = True
            txtCap.Enabled = True
            txtPrice.Enabled = True
            dtpExp.Enabled = True
            rbtnML.Enabled = True
            rbtnGrams.Enabled = True
            rbtnPiece.Enabled = True
            cbxEXP.Enabled = True
            btnAdd.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub
    Private Sub dgvInv_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvInv.ColumnHeaderMouseClick
        ColorCode()
    End Sub

    Private Sub cbxEXP_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEXP.CheckedChanged
        If cbxEXP.Checked = True Then
            dtpExp.CustomFormat = " "
            dtpExp.Enabled = False
        ElseIf cbxEXP.Checked = False Then
            dtpExp.CustomFormat = "MMMM-dd-yyyy"
            dtpExp.Value = Today.ToString("MMMM-dd-yyyy").Trim()
            dtpExp.Enabled = True
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        dgvInv.DataSource = Search1()
        dgvInv.DataSource = dt
        dgvInv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
        dgvInv.DefaultCellStyle.SelectionForeColor = Color.White
        dgvInv.DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
        dgvInv.DefaultCellStyle.ForeColor = Color.Black
        ColorCode()
    End Sub
    Public Function Search1() As DataTable
        Dim keyword As String
        keyword = txtSearch.Text.Trim
        con1 = New OracleConnection
        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
        con1.Open()
        cmd = New OracleCommand("SELECT * FROM RAW_MATERIALS WHERE RAW_NAME LIKE '%" & keyword & "%'", con1)
        da1 = New OracleDataAdapter()
        da1.SelectCommand = cmd
        dt = New DataTable
        da1.Fill(dt)
        Return dt
    End Function

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = Nothing Or txtSearch.Text = " " Then
            Inventory()
            ColorCode()
        Else
            dgvInv.DataSource = Search1()
            ColorCode()
        End If
    End Sub
End Class