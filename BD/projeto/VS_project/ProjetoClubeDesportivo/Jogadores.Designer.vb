<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Jogadores
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bttnBack = New System.Windows.Forms.Button()
        Me.bttnExit = New System.Windows.Forms.Button()
        Me.Nome = New System.Windows.Forms.Label()
        Me.NIF = New System.Windows.Forms.Label()
        Me.Address = New System.Windows.Forms.Label()
        Me.Birth = New System.Windows.Forms.Label()
        Me.numSocio = New System.Windows.Forms.Label()
        Me.Equipa = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtNIF = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtBirth = New System.Windows.Forms.TextBox()
        Me.txtSocio = New System.Windows.Forms.TextBox()
        Me.txtEquipa = New System.Windows.Forms.TextBox()
        Me.bttnSearch = New System.Windows.Forms.Button()
        Me.bttnUpdate = New System.Windows.Forms.Button()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.txtSalario = New System.Windows.Forms.TextBox()
        Me.Salario = New System.Windows.Forms.Label()
        Me.bttnCreate = New System.Windows.Forms.Button()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tipo_tb = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.data_fim_tb = New System.Windows.Forms.TextBox()
        Me.data_fim_label = New System.Windows.Forms.Label()
        Me.data_inicio_tb = New System.Windows.Forms.TextBox()
        Me.data_inicio_label = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(1, 1)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(262, 604)
        Me.ListBox1.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(270, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 26)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Staff - Jogadores"
        '
        'bttnBack
        '
        Me.bttnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnBack.Location = New System.Drawing.Point(275, 12)
        Me.bttnBack.Name = "bttnBack"
        Me.bttnBack.Size = New System.Drawing.Size(96, 36)
        Me.bttnBack.TabIndex = 26
        Me.bttnBack.Text = "Back"
        Me.bttnBack.UseVisualStyleBackColor = True
        '
        'bttnExit
        '
        Me.bttnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnExit.Location = New System.Drawing.Point(611, 12)
        Me.bttnExit.Name = "bttnExit"
        Me.bttnExit.Size = New System.Drawing.Size(96, 36)
        Me.bttnExit.TabIndex = 28
        Me.bttnExit.Text = "Exit"
        Me.bttnExit.UseVisualStyleBackColor = True
        '
        'Nome
        '
        Me.Nome.AutoSize = True
        Me.Nome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nome.Location = New System.Drawing.Point(285, 120)
        Me.Nome.Name = "Nome"
        Me.Nome.Size = New System.Drawing.Size(86, 20)
        Me.Nome.TabIndex = 29
        Me.Nome.Text = "First Name"
        '
        'NIF
        '
        Me.NIF.AutoSize = True
        Me.NIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NIF.Location = New System.Drawing.Point(286, 184)
        Me.NIF.Name = "NIF"
        Me.NIF.Size = New System.Drawing.Size(35, 20)
        Me.NIF.TabIndex = 30
        Me.NIF.Text = "NIF"
        '
        'Address
        '
        Me.Address.AutoSize = True
        Me.Address.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address.Location = New System.Drawing.Point(286, 216)
        Me.Address.Name = "Address"
        Me.Address.Size = New System.Drawing.Size(68, 20)
        Me.Address.TabIndex = 31
        Me.Address.Text = "Address"
        '
        'Birth
        '
        Me.Birth.AutoSize = True
        Me.Birth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Birth.Location = New System.Drawing.Point(286, 248)
        Me.Birth.Name = "Birth"
        Me.Birth.Size = New System.Drawing.Size(99, 20)
        Me.Birth.TabIndex = 32
        Me.Birth.Text = "Date of Birth"
        '
        'numSocio
        '
        Me.numSocio.AutoSize = True
        Me.numSocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSocio.Location = New System.Drawing.Point(287, 280)
        Me.numSocio.Name = "numSocio"
        Me.numSocio.Size = New System.Drawing.Size(88, 20)
        Me.numSocio.TabIndex = 33
        Me.numSocio.Text = "Member ID"
        '
        'Equipa
        '
        Me.Equipa.AutoSize = True
        Me.Equipa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Equipa.Location = New System.Drawing.Point(287, 411)
        Me.Equipa.Name = "Equipa"
        Me.Equipa.Size = New System.Drawing.Size(49, 20)
        Me.Equipa.TabIndex = 34
        Me.Equipa.Text = "Team"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(391, 117)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(314, 26)
        Me.txtName.TabIndex = 35
        '
        'txtNIF
        '
        Me.txtNIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIF.Location = New System.Drawing.Point(392, 181)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.Size = New System.Drawing.Size(314, 26)
        Me.txtNIF.TabIndex = 36
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(392, 213)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(314, 26)
        Me.txtAddress.TabIndex = 37
        '
        'txtBirth
        '
        Me.txtBirth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBirth.Location = New System.Drawing.Point(392, 245)
        Me.txtBirth.Name = "txtBirth"
        Me.txtBirth.Size = New System.Drawing.Size(314, 26)
        Me.txtBirth.TabIndex = 38
        '
        'txtSocio
        '
        Me.txtSocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSocio.Location = New System.Drawing.Point(393, 277)
        Me.txtSocio.Name = "txtSocio"
        Me.txtSocio.Size = New System.Drawing.Size(314, 26)
        Me.txtSocio.TabIndex = 39
        '
        'txtEquipa
        '
        Me.txtEquipa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEquipa.Location = New System.Drawing.Point(393, 408)
        Me.txtEquipa.Name = "txtEquipa"
        Me.txtEquipa.Size = New System.Drawing.Size(314, 26)
        Me.txtEquipa.TabIndex = 40
        '
        'bttnSearch
        '
        Me.bttnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnSearch.Location = New System.Drawing.Point(596, 558)
        Me.bttnSearch.Name = "bttnSearch"
        Me.bttnSearch.Size = New System.Drawing.Size(96, 36)
        Me.bttnSearch.TabIndex = 41
        Me.bttnSearch.Text = "Search"
        Me.bttnSearch.UseVisualStyleBackColor = True
        '
        'bttnUpdate
        '
        Me.bttnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnUpdate.Location = New System.Drawing.Point(290, 558)
        Me.bttnUpdate.Name = "bttnUpdate"
        Me.bttnUpdate.Size = New System.Drawing.Size(96, 36)
        Me.bttnUpdate.TabIndex = 42
        Me.bttnUpdate.Text = "Update"
        Me.bttnUpdate.UseVisualStyleBackColor = True
        '
        'bttnDelete
        '
        Me.bttnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnDelete.Location = New System.Drawing.Point(392, 558)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(96, 36)
        Me.bttnDelete.TabIndex = 43
        Me.bttnDelete.Text = "Delete"
        Me.bttnDelete.UseVisualStyleBackColor = True
        '
        'txtSalario
        '
        Me.txtSalario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalario.Location = New System.Drawing.Point(393, 440)
        Me.txtSalario.Name = "txtSalario"
        Me.txtSalario.Size = New System.Drawing.Size(314, 26)
        Me.txtSalario.TabIndex = 45
        '
        'Salario
        '
        Me.Salario.AutoSize = True
        Me.Salario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Salario.Location = New System.Drawing.Point(287, 443)
        Me.Salario.Name = "Salario"
        Me.Salario.Size = New System.Drawing.Size(53, 20)
        Me.Salario.TabIndex = 44
        Me.Salario.Text = "Salary"
        '
        'bttnCreate
        '
        Me.bttnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCreate.Location = New System.Drawing.Point(494, 558)
        Me.bttnCreate.Name = "bttnCreate"
        Me.bttnCreate.Size = New System.Drawing.Size(96, 36)
        Me.bttnCreate.TabIndex = 46
        Me.bttnCreate.Text = "Create"
        Me.bttnCreate.UseVisualStyleBackColor = True
        '
        'bttnCancel
        '
        Me.bttnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCancel.Location = New System.Drawing.Point(339, 558)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(96, 36)
        Me.bttnCancel.TabIndex = 72
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = True
        Me.bttnCancel.Visible = False
        '
        'bttnOK
        '
        Me.bttnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnOK.Location = New System.Drawing.Point(541, 558)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(96, 36)
        Me.bttnOK.TabIndex = 71
        Me.bttnOK.Text = "OK"
        Me.bttnOK.UseVisualStyleBackColor = True
        Me.bttnOK.Visible = False
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(391, 149)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(314, 26)
        Me.txtLastName.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(285, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Last Name"
        '
        'tipo_tb
        '
        Me.tipo_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_tb.Location = New System.Drawing.Point(393, 376)
        Me.tipo_tb.Name = "tipo_tb"
        Me.tipo_tb.Size = New System.Drawing.Size(314, 26)
        Me.tipo_tb.TabIndex = 76
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(287, 379)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 20)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Type"
        '
        'data_fim_tb
        '
        Me.data_fim_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_fim_tb.Location = New System.Drawing.Point(393, 344)
        Me.data_fim_tb.Name = "data_fim_tb"
        Me.data_fim_tb.Size = New System.Drawing.Size(314, 26)
        Me.data_fim_tb.TabIndex = 80
        '
        'data_fim_label
        '
        Me.data_fim_label.AutoSize = True
        Me.data_fim_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_fim_label.Location = New System.Drawing.Point(285, 347)
        Me.data_fim_label.Name = "data_fim_label"
        Me.data_fim_label.Size = New System.Drawing.Size(77, 20)
        Me.data_fim_label.TabIndex = 79
        Me.data_fim_label.Text = "End Date"
        '
        'data_inicio_tb
        '
        Me.data_inicio_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_inicio_tb.Location = New System.Drawing.Point(393, 309)
        Me.data_inicio_tb.Name = "data_inicio_tb"
        Me.data_inicio_tb.Size = New System.Drawing.Size(314, 26)
        Me.data_inicio_tb.TabIndex = 78
        '
        'data_inicio_label
        '
        Me.data_inicio_label.AutoSize = True
        Me.data_inicio_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_inicio_label.Location = New System.Drawing.Point(285, 312)
        Me.data_inicio_label.Name = "data_inicio_label"
        Me.data_inicio_label.Size = New System.Drawing.Size(83, 20)
        Me.data_inicio_label.TabIndex = 77
        Me.data_inicio_label.Text = "Start Date"
        '
        'Jogadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 606)
        Me.Controls.Add(Me.data_fim_tb)
        Me.Controls.Add(Me.data_fim_label)
        Me.Controls.Add(Me.data_inicio_tb)
        Me.Controls.Add(Me.data_inicio_label)
        Me.Controls.Add(Me.tipo_tb)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.bttnCreate)
        Me.Controls.Add(Me.txtSalario)
        Me.Controls.Add(Me.Salario)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.bttnUpdate)
        Me.Controls.Add(Me.bttnSearch)
        Me.Controls.Add(Me.txtEquipa)
        Me.Controls.Add(Me.txtSocio)
        Me.Controls.Add(Me.txtBirth)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtNIF)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Equipa)
        Me.Controls.Add(Me.numSocio)
        Me.Controls.Add(Me.Birth)
        Me.Controls.Add(Me.Address)
        Me.Controls.Add(Me.NIF)
        Me.Controls.Add(Me.Nome)
        Me.Controls.Add(Me.bttnExit)
        Me.Controls.Add(Me.bttnBack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Jogadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jogadores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bttnBack As Button
    Friend WithEvents bttnExit As Button
    Friend WithEvents Nome As Label
    Friend WithEvents NIF As Label
    Friend WithEvents Address As Label
    Friend WithEvents Birth As Label
    Friend WithEvents numSocio As Label
    Friend WithEvents Equipa As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtNIF As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtBirth As TextBox
    Friend WithEvents txtSocio As TextBox
    Friend WithEvents txtEquipa As TextBox
    Friend WithEvents bttnSearch As Button
    Friend WithEvents bttnUpdate As Button
    Friend WithEvents bttnDelete As Button
    Friend WithEvents txtSalario As TextBox
    Friend WithEvents Salario As Label
    Friend WithEvents bttnCreate As Button
    Friend WithEvents bttnCancel As Button
    Friend WithEvents bttnOK As Button
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tipo_tb As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents data_fim_tb As TextBox
    Friend WithEvents data_fim_label As Label
    Friend WithEvents data_inicio_tb As TextBox
    Friend WithEvents data_inicio_label As Label
End Class
