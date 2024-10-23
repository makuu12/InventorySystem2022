<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblAccount = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblOver = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblOut = New System.Windows.Forms.Label()
        Me.btnLogs = New System.Windows.Forms.Button()
        Me.btnSett = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblMin = New System.Windows.Forms.Label()
        Me.btnSales = New System.Windows.Forms.Button()
        Me.btnInv = New System.Windows.Forms.Button()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'Timer3
        '
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblClose)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1412, 36)
        Me.Panel2.TabIndex = 0
        '
        'lblClose
        '
        Me.lblClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblClose.AutoSize = True
        Me.lblClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.ForeColor = System.Drawing.Color.DimGray
        Me.lblClose.Location = New System.Drawing.Point(1346, 0)
        Me.lblClose.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(24, 29)
        Me.lblClose.TabIndex = 1
        Me.lblClose.Text = "x"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(1383, 1)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 29)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "x"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblAccount)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Controls.Add(Me.btnLogs)
        Me.Panel3.Controls.Add(Me.btnSett)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.btnSales)
        Me.Panel3.Controls.Add(Me.btnInv)
        Me.Panel3.Controls.Add(Me.btnMenu)
        Me.Panel3.Controls.Add(Me.btnHome)
        Me.Panel3.Location = New System.Drawing.Point(1, 36)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(277, 885)
        Me.Panel3.TabIndex = 1
        '
        'lblAccount
        '
        Me.lblAccount.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblAccount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount.Location = New System.Drawing.Point(40, 177)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(199, 31)
        Me.lblAccount.TabIndex = 11
        Me.lblAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel8
        '
        Me.Panel8.Location = New System.Drawing.Point(277, 5)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1098, 724)
        Me.Panel8.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblOver)
        Me.Panel6.Location = New System.Drawing.Point(2, 556)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(275, 50)
        Me.Panel6.TabIndex = 10
        '
        'lblOver
        '
        Me.lblOver.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOver.AutoSize = True
        Me.lblOver.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOver.Location = New System.Drawing.Point(5, 7)
        Me.lblOver.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblOver.Name = "lblOver"
        Me.lblOver.Size = New System.Drawing.Size(0, 37)
        Me.lblOver.TabIndex = 3
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lblOut)
        Me.Panel7.Location = New System.Drawing.Point(2, 664)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(275, 50)
        Me.Panel7.TabIndex = 9
        '
        'lblOut
        '
        Me.lblOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOut.AutoSize = True
        Me.lblOut.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOut.Location = New System.Drawing.Point(5, 7)
        Me.lblOut.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblOut.Name = "lblOut"
        Me.lblOut.Size = New System.Drawing.Size(0, 37)
        Me.lblOut.TabIndex = 3
        '
        'btnLogs
        '
        Me.btnLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogs.Font = New System.Drawing.Font("Yu Gothic UI Semilight", 20.0!)
        Me.btnLogs.Location = New System.Drawing.Point(0, 487)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(277, 52)
        Me.btnLogs.TabIndex = 7
        Me.btnLogs.Text = "LOGS"
        Me.btnLogs.UseVisualStyleBackColor = False
        '
        'btnSett
        '
        Me.btnSett.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnSett.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSett.Font = New System.Drawing.Font("Yu Gothic UI Semilight", 20.0!)
        Me.btnSett.Location = New System.Drawing.Point(0, 439)
        Me.btnSett.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSett.Name = "btnSett"
        Me.btnSett.Size = New System.Drawing.Size(277, 52)
        Me.btnSett.TabIndex = 6
        Me.btnSett.Text = "SETTINGS"
        Me.btnSett.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblMin)
        Me.Panel4.Location = New System.Drawing.Point(2, 610)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(275, 50)
        Me.Panel4.TabIndex = 3
        '
        'lblMin
        '
        Me.lblMin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMin.AutoSize = True
        Me.lblMin.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMin.Location = New System.Drawing.Point(5, 7)
        Me.lblMin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(0, 37)
        Me.lblMin.TabIndex = 3
        '
        'btnSales
        '
        Me.btnSales.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSales.Font = New System.Drawing.Font("Yu Gothic UI Semilight", 20.0!)
        Me.btnSales.Location = New System.Drawing.Point(0, 387)
        Me.btnSales.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSales.Name = "btnSales"
        Me.btnSales.Size = New System.Drawing.Size(277, 52)
        Me.btnSales.TabIndex = 3
        Me.btnSales.Text = "SALES"
        Me.btnSales.UseVisualStyleBackColor = False
        '
        'btnInv
        '
        Me.btnInv.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInv.Font = New System.Drawing.Font("Yu Gothic UI Semilight", 20.0!)
        Me.btnInv.Location = New System.Drawing.Point(0, 335)
        Me.btnInv.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInv.Name = "btnInv"
        Me.btnInv.Size = New System.Drawing.Size(277, 52)
        Me.btnInv.TabIndex = 2
        Me.btnInv.Text = "INVENTORY"
        Me.btnInv.UseVisualStyleBackColor = False
        '
        'btnMenu
        '
        Me.btnMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu.Font = New System.Drawing.Font("Yu Gothic UI Semilight", 20.0!)
        Me.btnMenu.Location = New System.Drawing.Point(0, 283)
        Me.btnMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(277, 52)
        Me.btnMenu.TabIndex = 1
        Me.btnMenu.Text = "PRODUCTS"
        Me.btnMenu.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Yu Gothic UI Semilight", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.Location = New System.Drawing.Point(0, 231)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(2)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(277, 52)
        Me.btnHome.TabIndex = 0
        Me.btnHome.Text = "HOME"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1412, 922)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.AutoSize = True
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel5.Location = New System.Drawing.Point(278, 38)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1101, 943)
        Me.Panel5.TabIndex = 2
        '
        'Timer4
        '
        Me.Timer4.Enabled = True
        Me.Timer4.Interval = 600000
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1376, 768)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "mainForm"
        Me.Text = "mainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblClose As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblOver As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblOut As Label
    Friend WithEvents btnLogs As Button
    Friend WithEvents btnSett As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblMin As Label
    Friend WithEvents btnSales As Button
    Friend WithEvents btnInv As Button
    Friend WithEvents btnMenu As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblAccount As TextBox
    Friend WithEvents Timer4 As Timer
End Class
