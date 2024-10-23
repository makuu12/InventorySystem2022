Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Oracle.ManagedDataAccess.Client
Imports System.Timers.ElapsedEventArgs
Imports System.Timers

Public Class mainForm
    Dim con1 As OracleConnection
    Dim da1 As OracleDataAdapter
    Dim cb1 As OracleCommandBuilder
    Dim cmd As OracleCommand
    Dim ds As DataSet
    Dim dt As DataTable
    Dim rescount As Byte
    Sub switchPanel(ByVal panel As Form)
        Panel5.Controls.Clear()
        panel.TopLevel = False
        Panel5.Controls.Add(panel)
        panel.Show()
    End Sub

    Public Sub checkInv()
        Dim check As Integer = 0
        Dim check1 As Integer = 0
        Dim check2 As Integer = 0
        Dim qty, cap, percent As Double
        InventoryForm.Inventory()
        For Each inv As DataGridViewRow In InventoryForm.dgvInv.Rows
            cap = inv.Cells(3).Value
            percent = cap * 0.1
            qty = inv.Cells(2).Value
            If qty > cap Then
                Timer1.Enabled = True
                lblOver.Text = "Over Stock"
                check = check + 1
            End If
            If qty <= percent And qty > 0 Then
                Timer2.Enabled = True
                lblMin.Text = "Minimum Stock"
                check1 = check1 + 1
            End If
            If qty = 0 Then
                Timer3.Enabled = True
                lblOut.Text = "Out of Stock"
                check2 = check2 + 1
            End If
        Next
        If check = 0 Then
            lblOver.Text = Nothing
            Timer1.Enabled = False
        End If
        If check1 = 0 Then
            lblMin.Text = Nothing
            Timer2.Enabled = False
        End If
        If check2 = 0 Then
            lblOut.Text = Nothing
            Timer3.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If lblOver.Left = -175 Then
            lblOver.Left = 300
            If SettingsForm.btnMute.Text = "MUTE" Then
                My.Computer.Audio.Play("D:\School\SIA102\group2_InventorySystem\group2_InventorySystem\Resources\OverStock.wav", AudioPlayMode.Background)
            ElseIf SettingsForm.btnMute.Text = "UNMUTE" Then
                My.Computer.Audio.Stop()
            End If
        Else
            lblOver.Left -= 5
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If lblMin.Left = -175 Then
            lblMin.Left = 300
            If SettingsForm.btnMute.Text = "MUTE" Then
                My.Computer.Audio.Play("D:\School\SIA102\group2_InventorySystem\group2_InventorySystem\Resources\MinimumStock.wav", AudioPlayMode.Background)
            ElseIf SettingsForm.btnMute.Text = "UNMUTE" Then
                My.Computer.Audio.Stop()
            End If
        Else
            lblMin.Left -= 5
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If lblOut.Left = -175 Then
            lblOut.Left = 300
            If SettingsForm.btnMute.Text = "MUTE" Then
                My.Computer.Audio.Play("D:\School\SIA102\group2_InventorySystem\group2_InventorySystem\Resources\OutOfStock.wav", AudioPlayMode.Background)
            ElseIf SettingsForm.btnMute.Text = "UNMUTE" Then
                My.Computer.Audio.Stop()
            End If
        Else
            lblOut.Left -= 5
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Application.Exit()
    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        checkInv()
        InventoryForm.Inventory()
        InventoryForm.ColorCode()
        Panel5.BackColor = Color.FromArgb(215, 186, 152)
        switchPanel(HomeForm)
        btnHome.BackColor = Color.FromArgb(96, 85, 67)
        btnMenu.BackColor = Color.FromArgb(179, 156, 127)
        btnInv.BackColor = Color.FromArgb(179, 156, 127)
        btnSales.BackColor = Color.FromArgb(179, 156, 127)
        btnSett.BackColor = Color.FromArgb(179, 156, 127)
        btnLogs.BackColor = Color.FromArgb(179, 156, 127)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        switchPanel(HomeForm)
        btnHome.BackColor = Color.FromArgb(96, 85, 67)
        btnMenu.BackColor = Color.FromArgb(179, 156, 127)
        btnInv.BackColor = Color.FromArgb(179, 156, 127)
        btnSales.BackColor = Color.FromArgb(179, 156, 127)
        btnSett.BackColor = Color.FromArgb(179, 156, 127)
        btnLogs.BackColor = Color.FromArgb(179, 156, 127)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        switchPanel(orderForm)
        orderForm.Products()
        btnHome.BackColor = Color.FromArgb(179, 156, 127)
        btnMenu.BackColor = Color.FromArgb(96, 85, 67)
        btnInv.BackColor = Color.FromArgb(179, 156, 127)
        btnSales.BackColor = Color.FromArgb(179, 156, 127)
        btnSett.BackColor = Color.FromArgb(179, 156, 127)
        btnLogs.BackColor = Color.FromArgb(179, 156, 127)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnInv.Click
        Panel5.BackColor = Color.FromArgb(215, 186, 152)
        switchPanel(InventoryForm)
        btnHome.BackColor = Color.FromArgb(179, 156, 127)
        btnMenu.BackColor = Color.FromArgb(179, 156, 127)
        btnInv.BackColor = Color.FromArgb(96, 85, 67)
        btnSales.BackColor = Color.FromArgb(179, 156, 127)
        btnSett.BackColor = Color.FromArgb(179, 156, 127)
        btnLogs.BackColor = Color.FromArgb(179, 156, 127)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        Panel5.BackColor = Color.FromArgb(215, 186, 152)
        switchPanel(SalesForm)
        btnHome.BackColor = Color.FromArgb(179, 156, 127)
        btnMenu.BackColor = Color.FromArgb(179, 156, 127)
        btnInv.BackColor = Color.FromArgb(179, 156, 127)
        btnSales.BackColor = Color.FromArgb(96, 85, 67)
        btnSett.BackColor = Color.FromArgb(179, 156, 127)
        btnLogs.BackColor = Color.FromArgb(179, 156, 127)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnSett.Click
        Panel5.BackColor = Color.FromArgb(215, 186, 152)
        switchPanel(SettingsForm)
        btnHome.BackColor = Color.FromArgb(179, 156, 127)
        btnMenu.BackColor = Color.FromArgb(179, 156, 127)
        btnInv.BackColor = Color.FromArgb(179, 156, 127)
        btnSales.BackColor = Color.FromArgb(179, 156, 127)
        btnSett.BackColor = Color.FromArgb(96, 85, 67)
        btnLogs.BackColor = Color.FromArgb(179, 156, 127)
    End Sub
    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click
        Dim u, a, d, t As String
        u = lblAccount.Text
        a = "Has logged out"
        d = Date.Now.ToString("MMMM-dd-yyyy")
        t = Now.ToString("HH:mm:ss")
        Try
            con1 = New OracleConnection
            con1.ConnectionString = "Data Source=localhost;User ID=KAPEKWENTO;Password=1234;Pooling=False"
            con1.Open()
            Dim sqllogs = "INSERT INTO LOGS (ACCOUNT_USER, ACTION, LOG_DATE, LOG_TIME) VALUES 
                                ('" & u & "','" & a & "','" & d & "','" & t & "')"
            cmd = New OracleCommand(sqllogs, con1)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            con1.Close()

        Catch ex As Exception

        End Try
        Application.Exit()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnLogs.Click
        Panel5.BackColor = Color.FromArgb(215, 186, 152)
        switchPanel(LogsForm)
        btnHome.BackColor = Color.FromArgb(179, 156, 127)
        btnMenu.BackColor = Color.FromArgb(179, 156, 127)
        btnInv.BackColor = Color.FromArgb(179, 156, 127)
        btnSales.BackColor = Color.FromArgb(179, 156, 127)
        btnSett.BackColor = Color.FromArgb(179, 156, 127)
        btnLogs.BackColor = Color.FromArgb(96, 85, 67)
    End Sub

    Private Sub Window_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ResetTimer()
    End Sub

    Private Sub ResetTimer()
        Timer4.Stop()
        Timer4.Start()
    End Sub

    Private Sub Window_PreviewKeyDown() Handles Me.PreviewKeyDown
        ResetTimer()
    End Sub

    Private Shared Sub Timer_Elapsed(sender As Object, e As EventArgs) Handles Timer4.Tick
        Application.Exit()
    End Sub

End Class