Imports Oracle.ManagedDataAccess.Client

Public Class MaterialsUsedForm
    Dim ran = New Random
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim cmd As OracleCommand
    Dim dt As DataTable
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
    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Inventory()
        ColorCode()
        MaterialsUsed()
    End Sub

    Private Sub MakeProperCase(sender As Object, e As EventArgs) Handles _
         txtSearch.TextChanged
        Dim n As Integer = sender.SelectionStart
        sender.Text = StrConv(sender.Text, VbStrConv.ProperCase)
        sender.SelectionStart = n
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
            dgvInv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
            dgvInv.DefaultCellStyle.SelectionForeColor = Color.White
            dgvInv.DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
            dgvInv.DefaultCellStyle.ForeColor = Color.Black
            ColorCode()
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

    Public Sub MaterialsUsed()
        Dim ID As String
        ID = SettingsForm.txtProductID.Text
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT product_ing.ingredient_id, products.product_id, raw_materials.raw_id, 
                                        raw_materials.raw_name, product_ing.quantity, raw_materials.quantity, raw_materials.measure FROM PRODUCT_ING
                                        INNER JOIN PRODUCTS ON product_ing.product_id=products.product_id
                                        INNER JOIN RAW_MATERIALS ON product_ing.raw_id=raw_materials.raw_id
                                        WHERE product_ing.product_id= '" & ID & "' ", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            dgvIng.DataSource = dt
            With dgvIng
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 85, 67)
                .DefaultCellStyle.SelectionForeColor = Color.White
                .DefaultCellStyle.BackColor = Color.FromArgb(179, 156, 127)
                .DefaultCellStyle.ForeColor = Color.Black
                .Columns(0).HeaderCell.Value = "Ingredient ID"
                .Columns(1).HeaderCell.Value = "Product ID"
                .Columns(2).HeaderCell.Value = "Raw ID"
                .Columns(3).HeaderCell.Value = "Raw Name"
                .Columns(4).HeaderCell.Value = "Quantity"
                .Columns(5).HeaderCell.Value = "Inventory Quantity"
                .Columns(6).HeaderCell.Value = "Measure"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try
    End Sub

    Public Sub ClearAll()
        txtRawID.Clear()
        txtRaw.Clear()
        txtQty.Clear()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dgvInv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInv.CellClick
        Dim current_row As Integer = dgvInv.CurrentRow.Index
        txtRawID.Text = dgvInv(0, current_row).Value.ToString
        txtRaw.Text = dgvInv(1, current_row).Value.ToString
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim PID, RID, QTY, u, a, d, t As String
        PID = SettingsForm.txtProductID.Text
        RID = txtRawID.Text.Trim
        QTY = txtQty.Text.Trim
        u = mainForm.lblAccount.Text
        a = "Has added a raw material as an ingredient"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If QTY = Nothing Then
            MessageBox.Show("Please enter the quantity of the raw material that will be used!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Add as an ingredient to product?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                Dim sqlAddIng = "INSERT INTO PRODUCT_ING (PRODUCT_ID, RAW_ID, QUANTITY) VALUES ('" & PID & "','" & RID & "','" & QTY & "')"
                cmd = New OracleCommand(sqlAddIng, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqlLogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqlLogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Ingredient has been successfully added!", "Added successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MaterialsUsed()
                ClearAll()
                LogsForm.LoadLogs()
                SettingsForm.MaterialsUsed()
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ID, QTY, u, a, d, t As String
        Dim current_row As Integer = dgvIng.CurrentRow.Index
        ID = dgvIng(0, current_row).Value.ToString
        QTY = txtQty.Text.Trim
        u = mainForm.lblAccount.Text
        a = "Has updated the quantity of an ingredient"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If QTY = Nothing Then
            MessageBox.Show("Please input the quantity of the ingredient that will be used!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Update the quantity of the ingredient to be used?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                Dim sqlUpdIng = "UPDATE PRODUCT_ING SET QUANTITY='" & QTY & "' WHERE INGREDIENT_ID='" & ID & "' "
                cmd = New OracleCommand(sqlUpdIng, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqllogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Ingredient has been successfully updated!", "Updated successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MaterialsUsed()
                ClearAll()
                LogsForm.LoadLogs()
                SettingsForm.MaterialsUsed()
            End If
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim ID, u, a, d, t As String
        Dim current_row As Integer = dgvIng.CurrentRow.Index
        ID = dgvIng(0, current_row).Value.ToString
        u = mainForm.lblAccount.Text
        a = "Has deleted an ingredient"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        Dim confirm As DialogResult = MessageBox.Show("Delete raw material as an ingredient of the product?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If confirm = DialogResult.Cancel Then

        ElseIf confirm = DialogResult.OK Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqlUpdIng = "DELETE FROM PRODUCT_ING WHERE INGREDIENT_ID='" & ID & "' "
            cmd = New OracleCommand(sqlUpdIng, con1)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
            cmd = New OracleCommand(sqllogs, con1)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            con1.Close()
            MessageBox.Show("Ingredient has been successfully deleted!", "Deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MaterialsUsed()
            ClearAll()
            LogsForm.LoadLogs()
            SettingsForm.MaterialsUsed()
        End If
    End Sub

    Private Sub dgvInv_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvInv.ColumnHeaderMouseClick
        ColorCode()
    End Sub

    Private Sub txtRawID_TextChanged(sender As Object, e As EventArgs) Handles txtRawID.TextChanged
        If txtRawID.Text = Nothing Then
            btnAdd.Enabled = False
            btnUpdate.Enabled = False
            btnDel.Enabled = False
            txtQty.Enabled = False
        Else
            btnAdd.Enabled = True
            btnUpdate.Enabled = True
            btnDel.Enabled = True
            txtQty.Enabled = True
        End If
    End Sub

    Private Sub dgvIng_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIng.CellClick
        Dim current_row As Integer = dgvIng.CurrentRow.Index
        txtRawID.Text = dgvIng(2, current_row).Value.ToString
        txtRaw.Text = dgvIng(3, current_row).Value.ToString
        txtQty.Text = dgvIng(4, current_row).Value.ToString
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