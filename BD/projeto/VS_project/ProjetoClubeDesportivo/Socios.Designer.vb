<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Socios
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
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.bttnCreate = New System.Windows.Forms.Button()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.bttnUpdate = New System.Windows.Forms.Button()
        Me.bttnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bttnExit = New System.Windows.Forms.Button()
        Me.bttnBack = New System.Windows.Forms.Button()
        Me.tipo_label = New System.Windows.Forms.Label()
        Me.data_fim_tb = New System.Windows.Forms.TextBox()
        Me.data_fim_label = New System.Windows.Forms.Label()
        Me.data_inicio_tb = New System.Windows.Forms.TextBox()
        Me.data_inicio_label = New System.Windows.Forms.Label()
        Me.numero_tb = New System.Windows.Forms.TextBox()
        Me.numero_label = New System.Windows.Forms.Label()
        Me.morada_tb = New System.Windows.Forms.TextBox()
        Me.morada_label = New System.Windows.Forms.Label()
        Me.data_nasc_tb = New System.Windows.Forms.TextBox()
        Me.data_nasc_label = New System.Windows.Forms.Label()
        Me.nif_tb = New System.Windows.Forms.TextBox()
        Me.nif_label = New System.Windows.Forms.Label()
        Me.primeiro_nome_tb = New System.Windows.Forms.TextBox()
        Me.primeiro_nome_label = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.last_name_tb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tipo_cb = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'bttnCancel
        '
        Me.bttnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCancel.Location = New System.Drawing.Point(362, 469)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(96, 36)
        Me.bttnCancel.TabIndex = 108
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = True
        Me.bttnCancel.Visible = False
        '
        'bttnOK
        '
        Me.bttnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnOK.Location = New System.Drawing.Point(564, 469)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(96, 36)
        Me.bttnOK.TabIndex = 107
        Me.bttnOK.Text = "OK"
        Me.bttnOK.UseVisualStyleBackColor = True
        Me.bttnOK.Visible = False
        '
        'bttnCreate
        '
        Me.bttnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCreate.Location = New System.Drawing.Point(517, 469)
        Me.bttnCreate.Name = "bttnCreate"
        Me.bttnCreate.Size = New System.Drawing.Size(96, 36)
        Me.bttnCreate.TabIndex = 106
        Me.bttnCreate.Text = "Create"
        Me.bttnCreate.UseVisualStyleBackColor = True
        '
        'bttnDelete
        '
        Me.bttnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnDelete.Location = New System.Drawing.Point(415, 469)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(96, 36)
        Me.bttnDelete.TabIndex = 105
        Me.bttnDelete.Text = "Delete"
        Me.bttnDelete.UseVisualStyleBackColor = True
        '
        'bttnUpdate
        '
        Me.bttnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnUpdate.Location = New System.Drawing.Point(313, 469)
        Me.bttnUpdate.Name = "bttnUpdate"
        Me.bttnUpdate.Size = New System.Drawing.Size(96, 36)
        Me.bttnUpdate.TabIndex = 104
        Me.bttnUpdate.Text = "Update"
        Me.bttnUpdate.UseVisualStyleBackColor = True
        '
        'bttnSearch
        '
        Me.bttnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnSearch.Location = New System.Drawing.Point(619, 469)
        Me.bttnSearch.Name = "bttnSearch"
        Me.bttnSearch.Size = New System.Drawing.Size(96, 36)
        Me.bttnSearch.TabIndex = 103
        Me.bttnSearch.Text = "Search"
        Me.bttnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(293, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 26)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Member"
        '
        'bttnExit
        '
        Me.bttnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnExit.Location = New System.Drawing.Point(651, 11)
        Me.bttnExit.Name = "bttnExit"
        Me.bttnExit.Size = New System.Drawing.Size(96, 36)
        Me.bttnExit.TabIndex = 100
        Me.bttnExit.Text = "Exit"
        Me.bttnExit.UseVisualStyleBackColor = True
        '
        'bttnBack
        '
        Me.bttnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnBack.Location = New System.Drawing.Point(296, 11)
        Me.bttnBack.Name = "bttnBack"
        Me.bttnBack.Size = New System.Drawing.Size(96, 36)
        Me.bttnBack.TabIndex = 99
        Me.bttnBack.Text = "Back"
        Me.bttnBack.UseVisualStyleBackColor = True
        '
        'tipo_label
        '
        Me.tipo_label.AutoSize = True
        Me.tipo_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_label.Location = New System.Drawing.Point(294, 389)
        Me.tipo_label.Name = "tipo_label"
        Me.tipo_label.Size = New System.Drawing.Size(43, 20)
        Me.tipo_label.TabIndex = 94
        Me.tipo_label.Text = "Type"
        '
        'data_fim_tb
        '
        Me.data_fim_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_fim_tb.Location = New System.Drawing.Point(439, 351)
        Me.data_fim_tb.Name = "data_fim_tb"
        Me.data_fim_tb.Size = New System.Drawing.Size(308, 26)
        Me.data_fim_tb.TabIndex = 93
        '
        'data_fim_label
        '
        Me.data_fim_label.AutoSize = True
        Me.data_fim_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_fim_label.Location = New System.Drawing.Point(294, 354)
        Me.data_fim_label.Name = "data_fim_label"
        Me.data_fim_label.Size = New System.Drawing.Size(98, 20)
        Me.data_fim_label.TabIndex = 92
        Me.data_fim_label.Text = "Ending Date"
        '
        'data_inicio_tb
        '
        Me.data_inicio_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_inicio_tb.Location = New System.Drawing.Point(439, 316)
        Me.data_inicio_tb.Name = "data_inicio_tb"
        Me.data_inicio_tb.Size = New System.Drawing.Size(308, 26)
        Me.data_inicio_tb.TabIndex = 91
        '
        'data_inicio_label
        '
        Me.data_inicio_label.AutoSize = True
        Me.data_inicio_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_inicio_label.Location = New System.Drawing.Point(294, 319)
        Me.data_inicio_label.Name = "data_inicio_label"
        Me.data_inicio_label.Size = New System.Drawing.Size(119, 20)
        Me.data_inicio_label.TabIndex = 90
        Me.data_inicio_label.Text = "Beginning Date"
        '
        'numero_tb
        '
        Me.numero_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numero_tb.Location = New System.Drawing.Point(439, 281)
        Me.numero_tb.Name = "numero_tb"
        Me.numero_tb.Size = New System.Drawing.Size(308, 26)
        Me.numero_tb.TabIndex = 89
        '
        'numero_label
        '
        Me.numero_label.AutoSize = True
        Me.numero_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numero_label.Location = New System.Drawing.Point(294, 284)
        Me.numero_label.Name = "numero_label"
        Me.numero_label.Size = New System.Drawing.Size(88, 20)
        Me.numero_label.TabIndex = 88
        Me.numero_label.Text = "Member ID"
        '
        'morada_tb
        '
        Me.morada_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.morada_tb.Location = New System.Drawing.Point(439, 246)
        Me.morada_tb.Name = "morada_tb"
        Me.morada_tb.Size = New System.Drawing.Size(308, 26)
        Me.morada_tb.TabIndex = 87
        '
        'morada_label
        '
        Me.morada_label.AutoSize = True
        Me.morada_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.morada_label.Location = New System.Drawing.Point(294, 249)
        Me.morada_label.Name = "morada_label"
        Me.morada_label.Size = New System.Drawing.Size(68, 20)
        Me.morada_label.TabIndex = 86
        Me.morada_label.Text = "Address"
        '
        'data_nasc_tb
        '
        Me.data_nasc_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_nasc_tb.Location = New System.Drawing.Point(439, 211)
        Me.data_nasc_tb.Name = "data_nasc_tb"
        Me.data_nasc_tb.Size = New System.Drawing.Size(308, 26)
        Me.data_nasc_tb.TabIndex = 85
        '
        'data_nasc_label
        '
        Me.data_nasc_label.AutoSize = True
        Me.data_nasc_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_nasc_label.Location = New System.Drawing.Point(294, 214)
        Me.data_nasc_label.Name = "data_nasc_label"
        Me.data_nasc_label.Size = New System.Drawing.Size(99, 20)
        Me.data_nasc_label.TabIndex = 84
        Me.data_nasc_label.Text = "Date of Birth"
        '
        'nif_tb
        '
        Me.nif_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nif_tb.Location = New System.Drawing.Point(439, 176)
        Me.nif_tb.Name = "nif_tb"
        Me.nif_tb.Size = New System.Drawing.Size(308, 26)
        Me.nif_tb.TabIndex = 83
        '
        'nif_label
        '
        Me.nif_label.AutoSize = True
        Me.nif_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nif_label.Location = New System.Drawing.Point(294, 179)
        Me.nif_label.Name = "nif_label"
        Me.nif_label.Size = New System.Drawing.Size(35, 20)
        Me.nif_label.TabIndex = 82
        Me.nif_label.Text = "NIF"
        '
        'primeiro_nome_tb
        '
        Me.primeiro_nome_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.primeiro_nome_tb.Location = New System.Drawing.Point(439, 111)
        Me.primeiro_nome_tb.Name = "primeiro_nome_tb"
        Me.primeiro_nome_tb.Size = New System.Drawing.Size(308, 26)
        Me.primeiro_nome_tb.TabIndex = 81
        '
        'primeiro_nome_label
        '
        Me.primeiro_nome_label.AutoSize = True
        Me.primeiro_nome_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.primeiro_nome_label.Location = New System.Drawing.Point(294, 114)
        Me.primeiro_nome_label.Name = "primeiro_nome_label"
        Me.primeiro_nome_label.Size = New System.Drawing.Size(86, 20)
        Me.primeiro_nome_label.TabIndex = 80
        Me.primeiro_nome_label.Text = "First Name"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(4, 6)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(259, 504)
        Me.ListBox1.TabIndex = 79
        '
        'last_name_tb
        '
        Me.last_name_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.last_name_tb.Location = New System.Drawing.Point(439, 144)
        Me.last_name_tb.Name = "last_name_tb"
        Me.last_name_tb.Size = New System.Drawing.Size(308, 26)
        Me.last_name_tb.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(294, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Last Name"
        '
        'tipo_cb
        '
        Me.tipo_cb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_cb.FormattingEnabled = True
        Me.tipo_cb.Items.AddRange(New Object() {"", "normal", "atleta", "efetivo"})
        Me.tipo_cb.Location = New System.Drawing.Point(439, 389)
        Me.tipo_cb.Name = "tipo_cb"
        Me.tipo_cb.Size = New System.Drawing.Size(308, 28)
        Me.tipo_cb.TabIndex = 111
        '
        'Socios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 517)
        Me.Controls.Add(Me.tipo_cb)
        Me.Controls.Add(Me.last_name_tb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.bttnCreate)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.bttnUpdate)
        Me.Controls.Add(Me.bttnSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bttnExit)
        Me.Controls.Add(Me.bttnBack)
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
        Me.Name = "Socios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Socios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bttnCancel As Button
    Friend WithEvents bttnOK As Button
    Friend WithEvents bttnCreate As Button
    Friend WithEvents bttnDelete As Button
    Friend WithEvents bttnUpdate As Button
    Friend WithEvents bttnSearch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bttnExit As Button
    Friend WithEvents bttnBack As Button
    Friend WithEvents tipo_label As Label
    Friend WithEvents data_fim_tb As TextBox
    Friend WithEvents data_fim_label As Label
    Friend WithEvents data_inicio_tb As TextBox
    Friend WithEvents data_inicio_label As Label
    Friend WithEvents numero_tb As TextBox
    Friend WithEvents numero_label As Label
    Friend WithEvents morada_tb As TextBox
    Friend WithEvents morada_label As Label
    Friend WithEvents data_nasc_tb As TextBox
    Friend WithEvents data_nasc_label As Label
    Friend WithEvents nif_tb As TextBox
    Friend WithEvents nif_label As Label
    Friend WithEvents primeiro_nome_tb As TextBox
    Friend WithEvents primeiro_nome_label As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents last_name_tb As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tipo_cb As ComboBox
End Class
