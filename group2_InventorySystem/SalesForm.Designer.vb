<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesForm
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chrInc = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.txtDay = New System.Windows.Forms.TextBox()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.cbSIELD = New System.Windows.Forms.ComboBox()
        Me.btnSearchID = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnGen = New System.Windows.Forms.Button()
        Me.dgvTH = New System.Windows.Forms.DataGridView()
        Me.cbPeriod = New System.Windows.Forms.ComboBox()
        Me.dgvStats = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.chrInc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.chrInc)
        Me.Panel1.Controls.Add(Me.btnLoad)
        Me.Panel1.Controls.Add(Me.txtDay)
        Me.Panel1.Controls.Add(Me.txtPeriod)
        Me.Panel1.Controls.Add(Me.cbMonth)
        Me.Panel1.Controls.Add(Me.cbSIELD)
        Me.Panel1.Controls.Add(Me.btnSearchID)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.btnGen)
        Me.Panel1.Controls.Add(Me.dgvTH)
        Me.Panel1.Controls.Add(Me.cbPeriod)
        Me.Panel1.Controls.Add(Me.dgvStats)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1090, 943)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(641, 430)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(235, 31)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Transaction History"
        '
        'chrInc
        '
        ChartArea1.Name = "ChartArea1"
        Me.chrInc.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chrInc.Legends.Add(Legend1)
        Me.chrInc.Location = New System.Drawing.Point(678, 73)
        Me.chrInc.Name = "chrInc"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Font = New System.Drawing.Font("NSimSun", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.Legend = "Legend1"
        Series1.Name = "Stats"
        Me.chrInc.Series.Add(Series1)
        Me.chrInc.Size = New System.Drawing.Size(374, 239)
        Me.chrInc.TabIndex = 49
        Me.chrInc.Text = "Chart1"
        '
        'btnLoad
        '
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("NSimSun", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(816, 318)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(112, 29)
        Me.btnLoad.TabIndex = 48
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'txtDay
        '
        Me.txtDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDay.Enabled = False
        Me.txtDay.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDay.Location = New System.Drawing.Point(450, 73)
        Me.txtDay.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDay.MaxLength = 2
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(86, 28)
        Me.txtDay.TabIndex = 47
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPeriod.Enabled = False
        Me.txtPeriod.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod.Location = New System.Drawing.Point(545, 73)
        Me.txtPeriod.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPeriod.MaxLength = 4
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(86, 28)
        Me.txtPeriod.TabIndex = 46
        '
        'cbMonth
        '
        Me.cbMonth.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.Enabled = False
        Me.cbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbMonth.Font = New System.Drawing.Font("Microsoft YaHei", 10.0!)
        Me.cbMonth.ForeColor = System.Drawing.Color.White
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cbMonth.Location = New System.Drawing.Point(333, 73)
        Me.cbMonth.Margin = New System.Windows.Forms.Padding(2)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(109, 27)
        Me.cbMonth.TabIndex = 45
        '
        'cbSIELD
        '
        Me.cbSIELD.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.cbSIELD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSIELD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSIELD.Font = New System.Drawing.Font("Microsoft YaHei", 10.0!)
        Me.cbSIELD.ForeColor = System.Drawing.Color.White
        Me.cbSIELD.FormattingEnabled = True
        Me.cbSIELD.Items.AddRange(New Object() {"Sales", "Expenses", "Loss/Damage"})
        Me.cbSIELD.Location = New System.Drawing.Point(152, 73)
        Me.cbSIELD.Margin = New System.Windows.Forms.Padding(2)
        Me.cbSIELD.Name = "cbSIELD"
        Me.cbSIELD.Size = New System.Drawing.Size(177, 27)
        Me.cbSIELD.TabIndex = 44
        '
        'btnSearchID
        '
        Me.btnSearchID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchID.Font = New System.Drawing.Font("NSimSun", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchID.Location = New System.Drawing.Point(391, 435)
        Me.btnSearchID.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearchID.Name = "btnSearchID"
        Me.btnSearchID.Size = New System.Drawing.Size(120, 29)
        Me.btnSearchID.TabIndex = 43
        Me.btnSearchID.Text = "SEARCH ID"
        Me.btnSearchID.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("NSimSun", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(275, 435)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(112, 29)
        Me.btnSearch.TabIndex = 42
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(44, 439)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(227, 22)
        Me.txtSearch.TabIndex = 40
        '
        'btnGen
        '
        Me.btnGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGen.Font = New System.Drawing.Font("NSimSun", 20.0!)
        Me.btnGen.Location = New System.Drawing.Point(759, 355)
        Me.btnGen.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGen.Name = "btnGen"
        Me.btnGen.Size = New System.Drawing.Size(229, 42)
        Me.btnGen.TabIndex = 39
        Me.btnGen.Text = "GENERATE REPORT"
        Me.btnGen.UseVisualStyleBackColor = True
        '
        'dgvTH
        '
        Me.dgvTH.AllowUserToAddRows = False
        Me.dgvTH.AllowUserToResizeRows = False
        Me.dgvTH.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTH.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.dgvTH.CausesValidation = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTH.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTH.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTH.GridColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.dgvTH.Location = New System.Drawing.Point(44, 468)
        Me.dgvTH.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvTH.Name = "dgvTH"
        Me.dgvTH.ReadOnly = True
        Me.dgvTH.RowHeadersVisible = False
        Me.dgvTH.RowHeadersWidth = 62
        Me.dgvTH.RowTemplate.Height = 28
        Me.dgvTH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTH.Size = New System.Drawing.Size(1008, 256)
        Me.dgvTH.TabIndex = 38
        '
        'cbPeriod
        '
        Me.cbPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPeriod.Font = New System.Drawing.Font("Microsoft YaHei", 10.0!)
        Me.cbPeriod.ForeColor = System.Drawing.Color.White
        Me.cbPeriod.FormattingEnabled = True
        Me.cbPeriod.Items.AddRange(New Object() {"Daily", "Monthly", "Anually"})
        Me.cbPeriod.Location = New System.Drawing.Point(31, 73)
        Me.cbPeriod.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.Size = New System.Drawing.Size(117, 27)
        Me.cbPeriod.TabIndex = 37
        '
        'dgvStats
        '
        Me.dgvStats.AllowUserToAddRows = False
        Me.dgvStats.AllowUserToResizeRows = False
        Me.dgvStats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStats.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.dgvStats.CausesValidation = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStats.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStats.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvStats.GridColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.dgvStats.Location = New System.Drawing.Point(31, 107)
        Me.dgvStats.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvStats.Name = "dgvStats"
        Me.dgvStats.ReadOnly = True
        Me.dgvStats.RowHeadersVisible = False
        Me.dgvStats.RowHeadersWidth = 62
        Me.dgvStats.RowTemplate.Height = 28
        Me.dgvStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStats.Size = New System.Drawing.Size(629, 287)
        Me.dgvStats.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(509, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 46)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "SALES"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 406)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1090, 13)
        Me.Panel2.TabIndex = 24
        '
        'SalesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 788)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SalesForm"
        Me.Text = "SalesForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.chrInc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvStats As DataGridView
    Friend WithEvents cbPeriod As ComboBox
    Friend WithEvents dgvTH As DataGridView
    Friend WithEvents btnGen As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSearchID As Button
    Friend WithEvents cbSIELD As ComboBox
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents txtPeriod As TextBox
    Friend WithEvents txtDay As TextBox
    Friend WithEvents btnLoad As Button
    Friend WithEvents chrInc As DataVisualization.Charting.Chart
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label2 As Label
End Class
