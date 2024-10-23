Imports Oracle.ManagedDataAccess.Client

Public Class UpdateForm
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
    Private Sub Quantity()
        Dim ID As String
        ID = InventoryForm.txtRawID.Text
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            cmd = New OracleCommand("SELECT RAW_NAME, QUANTITY FROM RAW_MATERIALS WHERE RAW_ID= '" & ID & "'", con1)
            da1 = New OracleDataAdapter()
            da1.SelectCommand = cmd
            dt = New DataTable
            da1.Fill(dt)
            lblRN.Text = dt.Rows(0)(0).ToString
            lblQTY.Text = dt.Rows(0)(1).ToString
            con1.Close()
        Catch ex As Exception
            MessageBox.Show("Invalid Login")
        End Try
    End Sub

    Private Sub UpdateForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Quantity()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim quantity, addend, new_quantity As Double
        quantity = CType(lblQTY.Text, Double)
        addend = CType(txtUpdate.Text, Double)
        new_quantity = quantity + addend
        lblQTY.Text = new_quantity
        AddExpensesForm.ShowDialog()
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        Dim quantity, addend, new_quantity As Double
        quantity = CType(lblQTY.Text, Double)
        addend = CType(txtUpdate.Text, Double)
        new_quantity = quantity - addend
        If new_quantity < 0 Then
            MessageBox.Show("Quantity must not be negative!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            lblQTY.Text = new_quantity
            LossDamageForm.ShowDialog()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim ID, RN, M, P, CAP, u, a, d, t As String
        Dim NQTY As Double
        ID = InventoryForm.txtRawID.Text
        NQTY = lblQTY.Text
        RN = InventoryForm.txtRaw.Text.Trim
        CAP = InventoryForm.txtCap.Text.Trim
        P = InventoryForm.txtPrice.Text.Trim
        If InventoryForm.rbtnML.Checked = True Then
            M = "ML"
        ElseIf InventoryForm.rbtnGrams.Checked = True Then
            M = "Grams"
        ElseIf InventoryForm.rbtnPiece.Checked = True Then
            M = "Piece/s"
        End If
        u = mainForm.lblAccount.Text
        a = "Has updated a raw material/s"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
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
                Dim sqlLogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
                cmd = New OracleCommand(sqlLogs, con1)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                con1.Close()
                MessageBox.Show("Raw material quantity has been successfully updated!")
                InventoryForm.Inventory()
                InventoryForm.ClearAll()
                'mainForm.checkInv()
                InventoryForm.ColorCode()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Invalid Login")
            End Try
        End If
    End Sub
End Class