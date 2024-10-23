Imports Oracle.ManagedDataAccess.Client

Public Class AddExpensesForm
    Dim ran = New Random
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim cmd As OracleCommand
    Dim ds As DataSet
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

    Private Sub NumberOnly(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCan.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ID, RN, M, P, CAP, EXP, EXPE, AQTY, u, a, d, t As String
        Dim NQTY As Double
        ID = InventoryForm.txtRawID.Text.Trim
        NQTY = UpdateForm.lblQTY.Text.Trim
        RN = InventoryForm.txtRaw.Text.Trim
        CAP = InventoryForm.txtCap.Text.Trim
        P = InventoryForm.txtPrice.Text.Trim
        EXPE = txtPrice.Text.Trim
        If InventoryForm.cbxEXP.Checked = True Then
            EXP = "No Expiration"
        Else
            EXP = InventoryForm.dtpExp.Value.ToString("MMMM-dd-yyyy").Trim
        End If
        AQTY = UpdateForm.txtUpdate.Text.Trim
        If InventoryForm.rbtnML.Checked = True Then
            M = "ML"
        ElseIf InventoryForm.rbtnGrams.Checked = True Then
            M = "Grams"
        ElseIf InventoryForm.rbtnPiece.Checked = True Then
            M = "Piece/s"
        End If
        u = mainForm.lblAccount.Text
        a = "Has updated a raw material"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        If txtPrice.Text = Nothing Then
            MessageBox.Show("Please input the price of the added quantity to the raw material", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim confirm As DialogResult = MessageBox.Show("Update raw material quantity?", "Confirmation",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If confirm = DialogResult.Cancel Then

            ElseIf confirm = DialogResult.OK Then
                Try
                    con1 = New OracleConnection
                    con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
                    con1.Open()
                    cmd = New OracleCommand("UPDATE RAW_MATERIALS SET QUANTITY= '" & NQTY & "' WHERE RAW_ID= '" & ID & "'", con1)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    Dim sqlExpe = "INSERT INTO EXPENSES (RAW_NAME, QUANTITY, MEASURE, TOTAL_EXPENSES, EXPENSES_DATE) VALUES ('" & RN & "','" & AQTY & "','" & M & "','" & EXPE & "','" & d & "')"
                    cmd = New OracleCommand(sqlExpe, con1)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    Dim sqlLogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                    cmd = New OracleCommand(sqlLogs, con1)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()

                    Dim sqlRawLogs = "INSERT INTO RAW_LOGS (ACCOUNT_USER, RAW_NAME, MODIFICATION,
                                    QUANTITY, CAPACITY, MEASURE, PRICE, EXPIRATION, LOG_DATE, LOG_TIME) VALUES 
                                    ('" & u & "','" & RN & "','" & a & "','" & NQTY & "','" & CAP & "',
                                    '" & M & "','" & P & "','" & EXP & "','" & d & "','" & t & "')"
                    cmd = New OracleCommand(sqlRawLogs, con1)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    con1.Close()
                    MessageBox.Show("Raw material quantity has been successfully updated!", "Raw material updated!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InventoryForm.Inventory()
                    InventoryForm.ClearAll()
                    mainForm.checkInv()
                    InventoryForm.ColorCode()
                    txtPrice.Clear()
                    LogsForm.LoadLogs()
                    Me.Close()
                    UpdateForm.Close()
                Catch ex As Exception
                    MessageBox.Show("Invalid Login")
                End Try
            End If
        End If
    End Sub
End Class