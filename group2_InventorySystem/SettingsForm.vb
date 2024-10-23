Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports Oracle.ManagedDataAccess.Client

Public Class SettingsForm
    Dim ran = New Random
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim cmd As OracleCommand
    Dim dt As DataTable
    Dim dt1 As DataTable
    Dim ds1 As DataSet
    Dim count As Byte

    Private Sub MakeProperCase(sender As Object, e As EventArgs) Handles _
         txtSearch.TextChanged, txtProduct.TextChanged
        Dim n As Integer = sender.SelectionStart
        sender.Text = StrConv(sender.Text, VbStrConv.ProperCase)
        sender.SelectionStart = n
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = Nothing Or txtSearch.Text = " " Then
            Products()
        Else
            dgvMenu.DataSource = Search1()
        End If
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Products()
    End Sub

    Private Sub Products()
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            cmd = New OracleCommand("SELECT PRODUCT_ID, PRODUCT_NAME, PRICE, CATEGORY FROM PRODUCTS", con1)
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
                .Columns(1).HeaderCell.Value = "Product Name"
                .Columns(1).Width = 175
                .Columns(2).HeaderCell.Value = "Price"
                .Columns(3).HeaderCell.Value = "Category"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try
    End Sub

    Public Sub MaterialsUsed()
        Dim ID As String
        ID = txtProductID.Text
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
            dt1 = New DataTable
            da1.Fill(dt1)
            dgvIng.DataSource = dt1
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
        txtProductID.Clear()
        txtProduct.Clear()
        txtPrice.Clear()
        cbCategory.SelectedIndex = -1
        dgvIng.DataSource = Nothing
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim PN, P, C, u, a, d, t As String
        PN = txtProduct.Text.Trim
        P = txtPrice.Text.Trim
        C = cbCategory.Text.Trim
        u = mainForm.lblAccount.Text
        a = "Has added a product"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If PN = Nothing Then
            MessageBox.Show("Please input a product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf P = Nothing Then
            MessageBox.Show("Please input the price of the product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf C = Nothing Then
            MessageBox.Show("Please select the category of the product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Add product?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                Dim sqlAdd = "INSERT INTO PRODUCTS (PRODUCT_NAME, PRICE, CATEGORY) VALUES ('" & PN & "','" & P & "','" & C & "')"
                cmd = New OracleCommand(sqlAdd, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqllogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Product has been succesfully added!", "Added successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Products()
                ClearAll()
                LogsForm.LoadLogs()
            End If
        End If
    End Sub
    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ID, PN, P, C, u, a, d, t As String
        ID = txtProductID.Text.Trim
        PN = txtProduct.Text.Trim
        P = txtPrice.Text.Trim
        C = cbCategory.Text.Trim
        u = mainForm.lblAccount.Text
        a = "Has updated a product"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If PN = Nothing Then
            MessageBox.Show("Please input a product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf P = Nothing Then
            MessageBox.Show("Please input the price of the product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf C = Nothing Then
            MessageBox.Show("Please select the category of the product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Update product?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                Dim sqlUpdate = "UPDATE PRODUCTS SET PRODUCT_NAME= '" & PN & "', PRICE= '" & P & "', CATEGORY= '" & C & "' WHERE PRODUCT_ID='" & ID & "' "
                cmd = New OracleCommand(sqlUpdate, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqllogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Product has been successfully updated!", "Updated successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Products()
                ClearAll()
                LogsForm.LoadLogs()
            End If
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim ID, PN, P, C, u, a, d, t As String
        ID = txtProductID.Text.Trim
        PN = txtProduct.Text.Trim
        P = txtPrice.Text.Trim
        C = cbCategory.Text.Trim
        u = mainForm.lblAccount.Text
        a = "Has deleted a product"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If PN = Nothing Then
            MessageBox.Show("Please input a product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf P = Nothing Then
            MessageBox.Show("Please input the price of the product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf C = Nothing Then
            MessageBox.Show("Please select the category of the product!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Delete product?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                con1 = New OracleConnection
                con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                con1.Open()
                Dim sqlDel1 = "DELETE FROM PRODUCT_ING WHERE PRODUCT_ID='" & ID & "' "
                cmd = New OracleCommand(sqlDel1, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqlDel = "DELETE FROM PRODUCTS WHERE PRODUCT_ID='" & ID & "' "
                cmd = New OracleCommand(sqlDel, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqllogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Product has been successfully deleted!", "Deleted successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Products()
                ClearAll()
                LogsForm.LoadLogs()
            End If
        End If
    End Sub

    'Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    '    ClearAll()
    'End Sub

    'Private Sub btnUpd1_Click(sender As Object, e As EventArgs) Handles btnUpd1.Click
    '    Try
    '        con1 = New OracleConnection
    '        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
    '        con1.Open()
    '        Dim UL, Pass, u, a, d, t As String
    '        UL = cbPos.Text.Trim
    '        Pass = txtNPass.Text.Trim
    '        u = mainForm.lblAccount.Text
    '        a = "Has updated password"
    '        d = Date.Now.ToString("MMMM-dd-yyyy")
    '        t = Now.ToString("HH:mm:ss")
    '        Dim confirm As DialogResult = MessageBox.Show("Update password?", "Confirmation",
    '                                              MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
    '        If confirm = DialogResult.Cancel Then

    '        ElseIf confirm = DialogResult.OK Then
    '            Dim sqlUPass = "UPDATE ACCOUNTS SET PASSWORD='" & Pass & "' WHERE USER_LEVEL='" & UL & "'"
    '            cmd = New OracleCommand(sqlUPass, con1)
    '            cmd.CommandType = CommandType.Text
    '            cmd.ExecuteNonQuery()
    '            Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
    '                            ('" & u & "','" & a & "','" & d & "','" & t & "')"
    '            cmd = New OracleCommand(sqllogs, con1)
    '            cmd.CommandType = CommandType.Text
    '            cmd.ExecuteNonQuery()
    '            con1.Close()
    '            ClearChangePass()
    '            LogsForm.LoadLogs()
    '            MessageBox.Show("Password has been successfully updated!", "Password Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim confirm As DialogResult = MessageBox.Show("Logout?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If confirm = DialogResult.Cancel Then

        ElseIf confirm = DialogResult.OK Then
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim u, a, d, t As String
            u = mainForm.lblAccount.Text
            a = "Has logged out"
            d = Date.Now.ToString("MMMM-dd-yyyy")
            t = Now.ToString("HH:mm:ss")
            Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
            cmd = New OracleCommand(sqllogs, con1)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            con1.Close()
            mainForm.Close()
            LoginPage.Show()
        End If
    End Sub

    Private Sub btnIng_Click(sender As Object, e As EventArgs) Handles btnIng.Click
        MaterialsUsedForm.Show()
    End Sub

    Private Sub dgvMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellClick
        Dim current_row As Integer = dgvMenu.CurrentRow.Index
        Dim category As String
        txtProductID.Text = dgvMenu(0, current_row).Value.ToString
        txtProduct.Text = dgvMenu(1, current_row).Value.ToString
        txtPrice.Text = dgvMenu(2, current_row).Value.ToString
        category = dgvMenu(3, current_row).Value.ToString
        If category = "DRINK" Then
            cbCategory.SelectedIndex = 0
        Else
            cbCategory.SelectedIndex = 1
        End If
        MaterialsUsed()
    End Sub

    Private Sub txtProductID_TextChanged(sender As Object, e As EventArgs) Handles txtProductID.TextChanged
        If txtProductID.Text = Nothing Then
            btnAdd.Enabled = True
            btnUpdate.Enabled = False
            btnDel.Enabled = False
            btnIng.Enabled = False
        Else
            btnAdd.Enabled = False
            btnUpdate.Enabled = True
            btnDel.Enabled = True
            btnIng.Enabled = True
        End If
    End Sub

    'Private Sub txtMPass_TextChanged(sender As Object, e As EventArgs)
    '    Dim Pass As String
    '    Try
    '        con1 = New OracleConnection
    '        con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
    '        con1.Open()
    '        Dim sqlCheck = "SELECT PASSWORD FROM ACCOUNTS WHERE USER_LEVEL='Owner' "
    '        da1 = New OracleDataAdapter(sqlCheck, con1)
    '        cb1 = New OracleCommandBuilder(da1)
    '        dt = New DataTable
    '        da1.Fill(dt)
    '        Pass = dt.Rows(0)(0).ToString
    '        If Pass = txtOPass.Text Then
    '            txtNPass.Enabled = True
    '            errorPass.Clear()
    '        Else
    '            txtNPass.Enabled = False
    '            errorPass.SetError(txtOPass, "Incorrect password!")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Invalid Login")
    '    End Try
    'End Sub

    'Private Sub cbPos_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If cbPos.SelectedIndex = 0 Or cbPos.SelectedIndex = 1 Then
    '        txtOPass.Enabled = True
    '    Else
    '        txtOPass.Enabled = False
    '        errorPass.Clear()
    '    End If
    'End Sub
    'Private Sub txtNPass_TextChanged(sender As Object, e As EventArgs)
    '    Dim UL, Pass As String
    '    UL = cbPos.Text
    '    con1 = New OracleConnection
    '    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
    '    con1.Open()
    '    Dim sqlCheck = "SELECT PASSWORD FROM ACCOUNTS WHERE USER_LEVEL='" & UL & "' "
    '    da1 = New OracleDataAdapter(sqlCheck, con1)
    '    cb1 = New OracleCommandBuilder(da1)
    '    dt = New DataTable
    '    da1.Fill(dt)
    '    Pass = dt.Rows(0)(0).ToString
    '    If Pass <> txtNPass.Text Then
    '        txtCNPass.Enabled = True
    '        errorPass.Clear()
    '    Else
    '        txtCNPass.Enabled = False
    '        errorPass.SetError(txtNPass, "New password is same as old password!")
    '    End If
    'End Sub
    'Private Sub txtCNPass_TextChanged(sender As Object, e As EventArgs)
    '    Dim NP As String
    '    NP = txtNPass.Text.Trim
    '    If txtCNPass.Text = txtNPass.Text Then
    '        btnUpd1.Enabled = True
    '        errorPass.Clear()
    '    Else
    '        btnUpd1.Enabled = False
    '        errorPass.SetError(txtCNPass, "Passwords do not match!")
    '    End If
    'End Sub
    'Private Sub btnCancel1_Click(sender As Object, e As EventArgs)
    '    ClearChangePass()
    'End Sub
    Public Function Search1() As DataTable
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
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        dgvMenu.DataSource = Search1()
    End Sub
    Private Sub btnMute_Click_1(sender As Object, e As EventArgs) Handles btnMute.Click
        If btnMute.Text = "MUTE" Then
            btnMute.Text = "UNMUTE"
        ElseIf btnMute.Text = "UNMUTE" Then
            btnMute.Text = "MUTE"
        End If
    End Sub
    Private Sub btnAddAcc_Click(sender As Object, e As EventArgs) Handles btnAddAcc.Click
        RegistrationForm.Show()
    End Sub

    Private Sub btnMngAcc_Click(sender As Object, e As EventArgs) Handles btnMngAcc.Click
        ManageAccountForm.Show()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtProductID.Clear()
        txtProduct.Clear()
        txtPrice.Clear()
    End Sub
End Class