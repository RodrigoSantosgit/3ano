<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class treinadores_form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.primeiro_nome_label = New System.Windows.Forms.Label()
        Me.primeiro_nome_tb = New System.Windows.Forms.TextBox()
        Me.nif_tb = New System.Windows.Forms.TextBox()
        Me.nif_label = New System.Windows.Forms.Label()
        Me.data_nasc_tb = New System.Windows.Forms.TextBox()
        Me.data_nasc_label = New System.Windows.Forms.Label()
        Me.morada_tb = New System.Windows.Forms.TextBox()
        Me.morada_label = New System.Windows.Forms.Label()
        Me.numero_tb = New System.Windows.Forms.TextBox()
        Me.numero_label = New System.Windows.Forms.Label()
        Me.data_inicio_tb = New System.Windows.Forms.TextBox()
        Me.data_inicio_label = New System.Windows.Forms.Label()
        Me.data_fim_tb = New System.Windows.Forms.TextBox()
        Me.data_fim_label = New System.Windows.Forms.Label()
        Me.tipo_tb = New System.Windows.Forms.TextBox()
        Me.tipo_label = New System.Windows.Forms.Label()
        Me.salario_tb = New System.Windows.Forms.TextBox()
        Me.salario_label = New System.Windows.Forms.Label()
        Me.equipa_label = New System.Windows.Forms.Label()
        Me.bttnExit = New System.Windows.Forms.Button()
        Me.bttnBack = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.bttnCreate = New System.Windows.Forms.Button()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.bttnUpdate = New System.Windows.Forms.Button()
        Me.bttnSearch = New System.Windows.Forms.Button()
        Me.ultimo_nome_tb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(259, 624)
        Me.ListBox1.TabIndex = 23
        '
        'primeiro_nome_label
        '
        Me.primeiro_nome_label.AutoSize = True
        Me.primeiro_nome_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.primeiro_nome_label.Location = New System.Drawing.Point(294, 115)
        Me.primeiro_nome_label.Name = "primeiro_nome_label"
        Me.primeiro_nome_label.Size = New System.Drawing.Size(86, 20)
        Me.primeiro_nome_label.TabIndex = 24
        Me.primeiro_nome_label.Text = "First Name"
        '
        'primeiro_nome_tb
        '
        Me.primeiro_nome_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.primeiro_nome_tb.Location = New System.Drawing.Point(439, 112)
        Me.primeiro_nome_tb.Name = "primeiro_nome_tb"
        Me.primeiro_nome_tb.Size = New System.Drawing.Size(308, 26)
        Me.primeiro_nome_tb.TabIndex = 26
        '
        'nif_tb
        '
        Me.nif_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nif_tb.Location = New System.Drawing.Point(439, 176)
        Me.nif_tb.Name = "nif_tb"
        Me.nif_tb.Size = New System.Drawing.Size(308, 26)
        Me.nif_tb.TabIndex = 29
        '
        'nif_label
        '
        Me.nif_label.AutoSize = True
        Me.nif_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nif_label.Location = New System.Drawing.Point(294, 179)
        Me.nif_label.Name = "nif_label"
        Me.nif_label.Size = New System.Drawing.Size(35, 20)
        Me.nif_label.TabIndex = 28
        Me.nif_label.Text = "NIF"
        '
        'data_nasc_tb
        '
        Me.data_nasc_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_nasc_tb.Location = New System.Drawing.Point(439, 211)
        Me.data_nasc_tb.Name = "data_nasc_tb"
        Me.data_nasc_tb.Size = New System.Drawing.Size(308, 26)
        Me.data_nasc_tb.TabIndex = 31
        '
        'data_nasc_label
        '
        Me.data_nasc_label.AutoSize = True
        Me.data_nasc_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_nasc_label.Location = New System.Drawing.Point(294, 214)
        Me.data_nasc_label.Name = "data_nasc_label"
        Me.data_nasc_label.Size = New System.Drawing.Size(99, 20)
        Me.data_nasc_label.TabIndex = 30
        Me.data_nasc_label.Text = "Date of Birth"
        '
        'morada_tb
        '
        Me.morada_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.morada_tb.Location = New System.Drawing.Point(439, 246)
        Me.morada_tb.Name = "morada_tb"
        Me.morada_tb.Size = New System.Drawing.Size(308, 26)
        Me.morada_tb.TabIndex = 33
        '
        'morada_label
        '
        Me.morada_label.AutoSize = True
        Me.morada_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.morada_label.Location = New System.Drawing.Point(294, 249)
        Me.morada_label.Name = "morada_label"
        Me.morada_label.Size = New System.Drawing.Size(68, 20)
        Me.morada_label.TabIndex = 32
        Me.morada_label.Text = "Address"
        '
        'numero_tb
        '
        Me.numero_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numero_tb.Location = New System.Drawing.Point(439, 281)
        Me.numero_tb.Name = "numero_tb"
        Me.numero_tb.Size = New System.Drawing.Size(308, 26)
        Me.numero_tb.TabIndex = 35
        '
        'numero_label
        '
        Me.numero_label.AutoSize = True
        Me.numero_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numero_label.Location = New System.Drawing.Point(294, 284)
        Me.numero_label.Name = "numero_label"
        Me.numero_label.Size = New System.Drawing.Size(88, 20)
        Me.numero_label.TabIndex = 34
        Me.numero_label.Text = "Member ID"
        '
        'data_inicio_tb
        '
        Me.data_inicio_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_inicio_tb.Location = New System.Drawing.Point(439, 316)
        Me.data_inicio_tb.Name = "data_inicio_tb"
        Me.data_inicio_tb.Size = New System.Drawing.Size(308, 26)
        Me.data_inicio_tb.TabIndex = 37
        '
        'data_inicio_label
        '
        Me.data_inicio_label.AutoSize = True
        Me.data_inicio_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_inicio_label.Location = New System.Drawing.Point(294, 319)
        Me.data_inicio_label.Name = "data_inicio_label"
        Me.data_inicio_label.Size = New System.Drawing.Size(83, 20)
        Me.data_inicio_label.TabIndex = 36
        Me.data_inicio_label.Text = "Start Date"
        '
        'data_fim_tb
        '
        Me.data_fim_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_fim_tb.Location = New System.Drawing.Point(439, 351)
        Me.data_fim_tb.Name = "data_fim_tb"
        Me.data_fim_tb.Size = New System.Drawing.Size(308, 26)
        Me.data_fim_tb.TabIndex = 39
        '
        'data_fim_label
        '
        Me.data_fim_label.AutoSize = True
        Me.data_fim_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_fim_label.Location = New System.Drawing.Point(294, 354)
        Me.data_fim_label.Name = "data_fim_label"
        Me.data_fim_label.Size = New System.Drawing.Size(77, 20)
        Me.data_fim_label.TabIndex = 38
        Me.data_fim_label.Text = "End Date"
        '
        'tipo_tb
        '
        Me.tipo_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_tb.Location = New System.Drawing.Point(439, 386)
        Me.tipo_tb.Name = "tipo_tb"
        Me.tipo_tb.Size = New System.Drawing.Size(308, 26)
        Me.tipo_tb.TabIndex = 41
        '
        'tipo_label
        '
        Me.tipo_label.AutoSize = True
        Me.tipo_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_label.Location = New System.Drawing.Point(294, 389)
        Me.tipo_label.Name = "tipo_label"
        Me.tipo_label.Size = New System.Drawing.Size(43, 20)
        Me.tipo_label.TabIndex = 40
        Me.tipo_label.Text = "Type"
        '
        'salario_tb
        '
        Me.salario_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salario_tb.Location = New System.Drawing.Point(439, 421)
        Me.salario_tb.Name = "salario_tb"
        Me.salario_tb.Size = New System.Drawing.Size(308, 26)
        Me.salario_tb.TabIndex = 43
        '
        'salario_label
        '
        Me.salario_label.AutoSize = True
        Me.salario_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salario_label.Location = New System.Drawing.Point(294, 424)
        Me.salario_label.Name = "salario_label"
        Me.salario_label.Size = New System.Drawing.Size(53, 20)
        Me.salario_label.TabIndex = 42
        Me.salario_label.Text = "Salary"
        '
        'equipa_label
        '
        Me.equipa_label.AutoSize = True
        Me.equipa_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.equipa_label.Location = New System.Drawing.Point(294, 463)
        Me.equipa_label.Name = "equipa_label"
        Me.equipa_label.Size = New System.Drawing.Size(57, 20)
        Me.equipa_label.TabIndex = 44
        Me.equipa_label.Text = "Teams"
        '
        'bttnExit
        '
        Me.bttnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnExit.Location = New System.Drawing.Point(651, 12)
        Me.bttnExit.Name = "bttnExit"
        Me.bttnExit.Size = New System.Drawing.Size(96, 36)
        Me.bttnExit.TabIndex = 47
        Me.bttnExit.Text = "Exit"
        Me.bttnExit.UseVisualStyleBackColor = True
        '
        'bttnBack
        '
        Me.bttnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnBack.Location = New System.Drawing.Point(296, 12)
        Me.bttnBack.Name = "bttnBack"
        Me.bttnBack.Size = New System.Drawing.Size(96, 36)
        Me.bttnBack.TabIndex = 46
        Me.bttnBack.Text = "Back"
        Me.bttnBack.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 20
        Me.ListBox2.Location = New System.Drawing.Point(439, 463)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(308, 104)
        Me.ListBox2.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(293, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 26)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Coach"
        '
        'bttnCancel
        '
        Me.bttnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCancel.Location = New System.Drawing.Point(363, 600)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(96, 36)
        Me.bttnCancel.TabIndex = 78
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = True
        Me.bttnCancel.Visible = False
        '
        'bttnOK
        '
        Me.bttnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnOK.Location = New System.Drawing.Point(565, 600)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(96, 36)
        Me.bttnOK.TabIndex = 77
        Me.bttnOK.Text = "OK"
        Me.bttnOK.UseVisualStyleBackColor = True
        Me.bttnOK.Visible = False
        '
        'bttnCreate
        '
        Me.bttnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCreate.Location = New System.Drawing.Point(518, 600)
        Me.bttnCreate.Name = "bttnCreate"
        Me.bttnCreate.Size = New System.Drawing.Size(96, 36)
        Me.bttnCreate.TabIndex = 76
        Me.bttnCreate.Text = "Create"
        Me.bttnCreate.UseVisualStyleBackColor = True
        '
        'bttnDelete
        '
        Me.bttnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnDelete.Location = New System.Drawing.Point(416, 600)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(96, 36)
        Me.bttnDelete.TabIndex = 75
        Me.bttnDelete.Text = "Delete"
        Me.bttnDelete.UseVisualStyleBackColor = True
        '
        'bttnUpdate
        '
        Me.bttnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnUpdate.Location = New System.Drawing.Point(314, 600)
        Me.bttnUpdate.Name = "bttnUpdate"
        Me.bttnUpdate.Size = New System.Drawing.Size(96, 36)
        Me.bttnUpdate.TabIndex = 74
        Me.bttnUpdate.Text = "Update"
        Me.bttnUpdate.UseVisualStyleBackColor = True
        '
        'bttnSearch
        '
        Me.bttnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnSearch.Location = New System.Drawing.Point(620, 600)
        Me.bttnSearch.Name = "bttnSearch"
        Me.bttnSearch.Size = New System.Drawing.Size(96, 36)
        Me.bttnSearch.TabIndex = 73
        Me.bttnSearch.Text = "Search"
        Me.bttnSearch.UseVisualStyleBackColor = True
        '
        'ultimo_nome_tb
        '
        Me.ultimo_nome_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ultimo_nome_tb.Location = New System.Drawing.Point(439, 144)
        Me.ultimo_nome_tb.Name = "ultimo_nome_tb"
        Me.ultimo_nome_tb.Size = New System.Drawing.Size(308, 26)
        Me.ultimo_nome_tb.TabIndex = 80
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(294, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Last Name"
        '
        'treinadores_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 644)
        Me.Controls.Add(Me.ultimo_nome_tb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.bttnCreate)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.bttnUpdate)
        Me.Controls.Add(Me.bttnSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.bttnExit)
        Me.Controls.Add(Me.bttnBack)
        Me.Controls.Add(Me.equipa_label)
        Me.Controls.Add(Me.salario_tb)
        Me.Controls.Add(Me.salario_label)
        Me.Controls.Add(Me.tipo_tb)
        Me.Controls.Add(Me.tipo_label)
        Me.Controls.Add(Me.data_fim_tb)
        Me.Controls.Add(Me.data_fim_label)
        Me.Controls.Add(Me.data_inicio_tb)
        Me.Controls.Add(Me.data_inicio_label)
        Me.Controls.Add(Me.numero_tb)
        Me.Controls.Add(Me.numero_label)
        Me.Controls.Add(Me.morada_tb)
        Me.Controls.Add(Me.morada_label)
        Me.Controls.Add(Me.data_nasc_tb)
        Me.Controls.Add(Me.data_nasc_label)
        Me.Controls.Add(Me.nif_tb)
        Me.Controls.Add(Me.nif_label)
        Me.Controls.Add(Me.primeiro_nome_tb)
        Me.Controls.Add(Me.primeiro_nome_label)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "treinadores_form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Treinadores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents primeiro_nome_label As Label
    Friend WithEvents primeiro_nome_tb As TextBox
    Friend WithEvents nif_tb As TextBox
    Friend WithEvents nif_label As Label
    Friend WithEvents data_nasc_tb As TextBox
    Friend WithEvents data_nasc_label As Label
    Friend WithEvents morada_tb As TextBox
    Friend WithEvents morada_label As Label
    Friend WithEvents numero_tb As TextBox
    Friend WithEvents numero_label As Label
    Friend WithEvents data_inicio_tb As TextBox
    Friend WithEvents data_inicio_label As Label
    Friend WithEvents data_fim_tb As TextBox
    Friend WithEvents data_fim_label As Label
    Friend WithEvents tipo_tb As TextBox
    Friend WithEvents tipo_label As Label
    Friend WithEvents salario_tb As TextBox
    Friend WithEvents salario_label As Label
    Friend WithEvents equipa_label As Label
    Friend WithEvents bttnExit As Button
    Friend WithEvents bttnBack As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bttnCancel As Button
    Friend WithEvents bttnOK As Button
    Friend WithEvents bttnCreate As Button
    Friend WithEvents bttnDelete As Button
    Friend WithEvents bttnUpdate As Button
    Friend WithEvents bttnSearch As Button
    Friend WithEvents ultimo_nome_tb As TextBox
    Friend WithEvents Label2 As Label
End Class
