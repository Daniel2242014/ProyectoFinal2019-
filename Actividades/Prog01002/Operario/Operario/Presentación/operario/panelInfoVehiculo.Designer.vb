﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelInfoVehiculo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PosicionLabel = New System.Windows.Forms.Label()
        Me.SubzonaLabel = New System.Windows.Forms.Label()
        Me.ZonaLabel = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LoteCombo = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TipoCombo = New System.Windows.Forms.ComboBox()
        Me.AñoBox = New System.Windows.Forms.TextBox()
        Me.ClienteBox = New System.Windows.Forms.TextBox()
        Me.ModeloBox = New System.Windows.Forms.TextBox()
        Me.MarcaBox = New System.Windows.Forms.TextBox()
        Me.VINBox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.QR = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.informes = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewLinkColumn1 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.traslados = New System.Windows.Forms.DataGridView()
        Me.zona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subZona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.posicion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trasPor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lugares = New System.Windows.Forms.DataGridView()
        Me.nomLugar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoLugar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fLlegada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fPartida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trasportadoPor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.QR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.informes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.traslados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.lugares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(880, 0)
        Me.Panel2.TabIndex = 85
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(880, 650)
        Me.TabControl1.TabIndex = 86
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PosicionLabel)
        Me.TabPage1.Controls.Add(Me.SubzonaLabel)
        Me.TabPage1.Controls.Add(Me.ZonaLabel)
        Me.TabPage1.Controls.Add(Me.LinkLabel2)
        Me.TabPage1.Controls.Add(Me.LoteCombo)
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.TipoCombo)
        Me.TabPage1.Controls.Add(Me.AñoBox)
        Me.TabPage1.Controls.Add(Me.ClienteBox)
        Me.TabPage1.Controls.Add(Me.ModeloBox)
        Me.TabPage1.Controls.Add(Me.MarcaBox)
        Me.TabPage1.Controls.Add(Me.VINBox)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.LinkLabel1)
        Me.TabPage1.Controls.Add(Me.QR)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 31)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(872, 615)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PosicionLabel
        '
        Me.PosicionLabel.AutoSize = True
        Me.PosicionLabel.Location = New System.Drawing.Point(108, 420)
        Me.PosicionLabel.Name = "PosicionLabel"
        Me.PosicionLabel.Size = New System.Drawing.Size(0, 24)
        Me.PosicionLabel.TabIndex = 134
        '
        'SubzonaLabel
        '
        Me.SubzonaLabel.AutoSize = True
        Me.SubzonaLabel.Location = New System.Drawing.Point(120, 378)
        Me.SubzonaLabel.Name = "SubzonaLabel"
        Me.SubzonaLabel.Size = New System.Drawing.Size(0, 24)
        Me.SubzonaLabel.TabIndex = 133
        '
        'ZonaLabel
        '
        Me.ZonaLabel.AutoSize = True
        Me.ZonaLabel.Location = New System.Drawing.Point(86, 338)
        Me.ZonaLabel.Name = "ZonaLabel"
        Me.ZonaLabel.Size = New System.Drawing.Size(0, 24)
        Me.ZonaLabel.TabIndex = 132
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(335, 537)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(100, 21)
        Me.LinkLabel2.TabIndex = 131
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Nuevo lote "
        '
        'LoteCombo
        '
        Me.LoteCombo.Enabled = False
        Me.LoteCombo.FormattingEnabled = True
        Me.LoteCombo.Location = New System.Drawing.Point(90, 531)
        Me.LoteCombo.Name = "LoteCombo"
        Me.LoteCombo.Size = New System.Drawing.Size(155, 32)
        Me.LoteCombo.TabIndex = 130
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button5.Enabled = False
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(549, 546)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(161, 66)
        Me.Button5.TabIndex = 126
        Me.Button5.Text = "Cancelar cambios"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button3.Enabled = False
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(716, 546)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(148, 66)
        Me.Button3.TabIndex = 125
        Me.Button3.Text = "Guardar cambios"
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'TipoCombo
        '
        Me.TipoCombo.BackColor = System.Drawing.Color.White
        Me.TipoCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TipoCombo.Enabled = False
        Me.TipoCombo.FormattingEnabled = True
        Me.TipoCombo.Location = New System.Drawing.Point(95, 231)
        Me.TipoCombo.Name = "TipoCombo"
        Me.TipoCombo.Size = New System.Drawing.Size(246, 32)
        Me.TipoCombo.TabIndex = 124
        '
        'AñoBox
        '
        Me.AñoBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AñoBox.Enabled = False
        Me.AñoBox.Location = New System.Drawing.Point(95, 181)
        Me.AñoBox.Name = "AñoBox"
        Me.AñoBox.Size = New System.Drawing.Size(492, 26)
        Me.AñoBox.TabIndex = 123
        '
        'ClienteBox
        '
        Me.ClienteBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ClienteBox.Enabled = False
        Me.ClienteBox.Location = New System.Drawing.Point(95, 134)
        Me.ClienteBox.Name = "ClienteBox"
        Me.ClienteBox.Size = New System.Drawing.Size(492, 26)
        Me.ClienteBox.TabIndex = 122
        '
        'ModeloBox
        '
        Me.ModeloBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ModeloBox.Enabled = False
        Me.ModeloBox.Location = New System.Drawing.Point(95, 83)
        Me.ModeloBox.Name = "ModeloBox"
        Me.ModeloBox.Size = New System.Drawing.Size(492, 26)
        Me.ModeloBox.TabIndex = 121
        '
        'MarcaBox
        '
        Me.MarcaBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MarcaBox.Enabled = False
        Me.MarcaBox.Location = New System.Drawing.Point(95, 39)
        Me.MarcaBox.Name = "MarcaBox"
        Me.MarcaBox.Size = New System.Drawing.Size(492, 26)
        Me.MarcaBox.TabIndex = 120
        '
        'VINBox
        '
        Me.VINBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.VINBox.Enabled = False
        Me.VINBox.Location = New System.Drawing.Point(95, 3)
        Me.VINBox.Name = "VINBox"
        Me.VINBox.Size = New System.Drawing.Size(492, 26)
        Me.VINBox.TabIndex = 119
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(549, 504)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(317, 36)
        Me.Button1.TabIndex = 108
        Me.Button1.Text = "Modificar informacion"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 24)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Tipo:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 24)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "VIN:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 24)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Año:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 420)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Posicion:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(251, 537)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(76, 21)
        Me.LinkLabel1.TabIndex = 106
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ver mas "
        '
        'QR
        '
        Me.QR.BackColor = System.Drawing.Color.DimGray
        Me.QR.Location = New System.Drawing.Point(666, 6)
        Me.QR.Name = "QR"
        Me.QR.Size = New System.Drawing.Size(200, 200)
        Me.QR.TabIndex = 105
        Me.QR.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 534)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 24)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "Lote:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 338)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 24)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Zona:"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(95, 290)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(154, 22)
        Me.Panel1.TabIndex = 103
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 24)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Color"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 24)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Modelo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 24)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "Marca:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 378)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 24)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Sub zona:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 24)
        Me.Label9.TabIndex = 96
        Me.Label9.Text = "Cliente:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.informes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 31)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(872, 615)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Informes de daños"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(567, 10)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(297, 32)
        Me.Button4.TabIndex = 110
        Me.Button4.Text = "Ingresar informe de daños"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'informes
        '
        Me.informes.AllowUserToAddRows = False
        Me.informes.AllowUserToDeleteRows = False
        Me.informes.AllowUserToOrderColumns = True
        Me.informes.AllowUserToResizeRows = False
        Me.informes.BackgroundColor = System.Drawing.Color.White
        Me.informes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.informes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.informes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.informes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.informes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.informes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewLinkColumn1})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(237, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.informes.DefaultCellStyle = DataGridViewCellStyle3
        Me.informes.EnableHeadersVisualStyles = False
        Me.informes.GridColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.informes.Location = New System.Drawing.Point(14, 48)
        Me.informes.MultiSelect = False
        Me.informes.Name = "informes"
        Me.informes.ReadOnly = True
        Me.informes.RowHeadersVisible = False
        Me.informes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.informes.Size = New System.Drawing.Size(850, 559)
        Me.informes.TabIndex = 86
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "Lugar"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "Autor"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fecha de realizacion"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "Numero de registros"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewLinkColumn1
        '
        Me.DataGridViewLinkColumn1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.DataGridViewLinkColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewLinkColumn1.HeaderText = "Acceso"
        Me.DataGridViewLinkColumn1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DataGridViewLinkColumn1.Name = "DataGridViewLinkColumn1"
        Me.DataGridViewLinkColumn1.ReadOnly = True
        Me.DataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLinkColumn1.Text = "Ver Mas "
        Me.DataGridViewLinkColumn1.UseColumnTextForLinkValue = True
        Me.DataGridViewLinkColumn1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.traslados)
        Me.TabPage3.Location = New System.Drawing.Point(4, 31)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(872, 615)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Traslados internos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(622, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(242, 32)
        Me.Button2.TabIndex = 109
        Me.Button2.Text = "Realizar un traslado interno "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'traslados
        '
        Me.traslados.AllowUserToAddRows = False
        Me.traslados.AllowUserToDeleteRows = False
        Me.traslados.AllowUserToResizeRows = False
        Me.traslados.BackgroundColor = System.Drawing.Color.White
        Me.traslados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.traslados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.traslados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.traslados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.traslados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.traslados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.zona, Me.subZona, Me.posicion, Me.desde, Me.hasta, Me.trasPor})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(237, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.traslados.DefaultCellStyle = DataGridViewCellStyle5
        Me.traslados.EnableHeadersVisualStyles = False
        Me.traslados.GridColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.traslados.Location = New System.Drawing.Point(14, 55)
        Me.traslados.Name = "traslados"
        Me.traslados.ReadOnly = True
        Me.traslados.RowHeadersVisible = False
        Me.traslados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.traslados.Size = New System.Drawing.Size(850, 552)
        Me.traslados.TabIndex = 87
        '
        'zona
        '
        Me.zona.Frozen = True
        Me.zona.HeaderText = "Zona"
        Me.zona.Name = "zona"
        Me.zona.ReadOnly = True
        '
        'subZona
        '
        Me.subZona.Frozen = True
        Me.subZona.HeaderText = "Sub-Zona"
        Me.subZona.Name = "subZona"
        Me.subZona.ReadOnly = True
        '
        'posicion
        '
        Me.posicion.Frozen = True
        Me.posicion.HeaderText = "Posicion de la sub-zona"
        Me.posicion.Name = "posicion"
        Me.posicion.ReadOnly = True
        '
        'desde
        '
        Me.desde.Frozen = True
        Me.desde.HeaderText = "Desde"
        Me.desde.Name = "desde"
        Me.desde.ReadOnly = True
        '
        'hasta
        '
        Me.hasta.Frozen = True
        Me.hasta.HeaderText = "Hasta"
        Me.hasta.Name = "hasta"
        Me.hasta.ReadOnly = True
        '
        'trasPor
        '
        Me.trasPor.Frozen = True
        Me.trasPor.HeaderText = "Trasladado por"
        Me.trasPor.Name = "trasPor"
        Me.trasPor.ReadOnly = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lugares)
        Me.TabPage4.Location = New System.Drawing.Point(4, 31)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(872, 615)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Lugares"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lugares
        '
        Me.lugares.AllowUserToAddRows = False
        Me.lugares.AllowUserToDeleteRows = False
        Me.lugares.AllowUserToOrderColumns = True
        Me.lugares.AllowUserToResizeRows = False
        Me.lugares.BackgroundColor = System.Drawing.Color.White
        Me.lugares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lugares.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.lugares.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lugares.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.lugares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lugares.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nomLugar, Me.tipoLugar, Me.fLlegada, Me.fPartida, Me.trasportadoPor})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(237, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lugares.DefaultCellStyle = DataGridViewCellStyle7
        Me.lugares.EnableHeadersVisualStyles = False
        Me.lugares.GridColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lugares.Location = New System.Drawing.Point(14, 15)
        Me.lugares.Name = "lugares"
        Me.lugares.ReadOnly = True
        Me.lugares.RowHeadersVisible = False
        Me.lugares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.lugares.Size = New System.Drawing.Size(850, 592)
        Me.lugares.TabIndex = 88
        '
        'nomLugar
        '
        Me.nomLugar.HeaderText = "Nombre del lugar "
        Me.nomLugar.Name = "nomLugar"
        Me.nomLugar.ReadOnly = True
        '
        'tipoLugar
        '
        Me.tipoLugar.HeaderText = "Tipo de lugar "
        Me.tipoLugar.Name = "tipoLugar"
        Me.tipoLugar.ReadOnly = True
        '
        'fLlegada
        '
        Me.fLlegada.HeaderText = "Fecha de llegada"
        Me.fLlegada.Name = "fLlegada"
        Me.fLlegada.ReadOnly = True
        '
        'fPartida
        '
        Me.fPartida.HeaderText = "fechaPartida"
        Me.fPartida.Name = "fPartida"
        Me.fPartida.ReadOnly = True
        '
        'trasportadoPor
        '
        Me.trasportadoPor.HeaderText = "Trasportado por"
        Me.trasportadoPor.Name = "trasportadoPor"
        Me.trasportadoPor.ReadOnly = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 31)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(872, 615)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Ubicacion"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(170, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(535, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "2º ENTREGA, Corespone a la Aplicacion del administrador"
        '
        'panelInfoVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "panelInfoVehiculo"
        Me.Text = "panelInfoUsuario"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.QR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.informes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.traslados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.lugares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents informes As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents QR As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents traslados As DataGridView
    Friend WithEvents zona As DataGridViewTextBoxColumn
    Friend WithEvents subZona As DataGridViewTextBoxColumn
    Friend WithEvents posicion As DataGridViewTextBoxColumn
    Friend WithEvents desde As DataGridViewTextBoxColumn
    Friend WithEvents hasta As DataGridViewTextBoxColumn
    Friend WithEvents trasPor As DataGridViewTextBoxColumn
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents lugares As DataGridView
    Friend WithEvents TipoCombo As ComboBox
    Friend WithEvents AñoBox As TextBox
    Friend WithEvents ClienteBox As TextBox
    Friend WithEvents ModeloBox As TextBox
    Friend WithEvents MarcaBox As TextBox
    Friend WithEvents VINBox As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewLinkColumn1 As DataGridViewLinkColumn
    Friend WithEvents nomLugar As DataGridViewTextBoxColumn
    Friend WithEvents tipoLugar As DataGridViewTextBoxColumn
    Friend WithEvents fLlegada As DataGridViewTextBoxColumn
    Friend WithEvents fPartida As DataGridViewTextBoxColumn
    Friend WithEvents trasportadoPor As DataGridViewTextBoxColumn
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LoteCombo As ComboBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents PosicionLabel As Label
    Friend WithEvents SubzonaLabel As Label
    Friend WithEvents ZonaLabel As Label
End Class
