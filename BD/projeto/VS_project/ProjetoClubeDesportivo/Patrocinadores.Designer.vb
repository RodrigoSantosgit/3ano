<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Patrocinadores
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
        Me.bttnCreate = New System.Windows.Forms.Button()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.bttnUpdate = New System.Windows.Forms.Button()
        Me.bttnSearch = New System.Windows.Forms.Button()
        Me.txtSpCond = New System.Windows.Forms.TextBox()
        Me.txtSC = New System.Windows.Forms.TextBox()
        Me.txtNIF = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.spCond = New System.Windows.Forms.Label()
        Me.spLvl = New System.Windows.Forms.Label()
        Me.clube = New System.Windows.Forms.Label()
        Me.NIF = New System.Windows.Forms.Label()
        Me.Nome = New System.Windows.Forms.Label()
        Me.bttnExit = New System.Windows.Forms.Button()
        Me.bttnBack = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.txtSpLvl = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'bttnCreate
        '
        Me.bttnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCreate.Location = New System.Drawing.Point(479, 558)
        Me.bttnCreate.Name = "bttnCreate"
        Me.bttnCreate.Size = New System.Drawing.Size(96, 36)
        Me.bttnCreate.TabIndex = 68
        Me.bttnCreate.Text = "Create"
        Me.bttnCreate.UseVisualStyleBackColor = True
        '
        'bttnDelete
        '
        Me.bttnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnDelete.Location = New System.Drawing.Point(377, 558)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(96, 36)
        Me.bttnDelete.TabIndex = 65
        Me.bttnDelete.Text = "Delete"
        Me.bttnDelete.UseVisualStyleBackColor = True
        '
        'bttnUpdate
        '
        Me.bttnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnUpdate.Location = New System.Drawing.Point(275, 558)
        Me.bttnUpdate.Name = "bttnUpdate"
        Me.bttnUpdate.Size = New System.Drawing.Size(96, 36)
        Me.bttnUpdate.TabIndex = 64
        Me.bttnUpdate.Text = "Update"
        Me.bttnUpdate.UseVisualStyleBackColor = True
        '
        'bttnSearch
        '
        Me.bttnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnSearch.Location = New System.Drawing.Point(581, 558)
        Me.bttnSearch.Name = "bttnSearch"
        Me.bttnSearch.Size = New System.Drawing.Size(96, 36)
        Me.bttnSearch.TabIndex = 63
        Me.bttnSearch.Text = "Search"
        Me.bttnSearch.UseVisualStyleBackColor = True
        '
        'txtSpCond
        '
        Me.txtSpCond.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpCond.Location = New System.Drawing.Point(275, 375)
        Me.txtSpCond.Multiline = True
        Me.txtSpCond.Name = "txtSpCond"
        Me.txtSpCond.ReadOnly = True
        Me.txtSpCond.Size = New System.Drawing.Size(402, 177)
        Me.txtSpCond.TabIndex = 61
        '
        'txtSC
        '
        Me.txtSC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSC.Location = New System.Drawing.Point(365, 241)
        Me.txtSC.Name = "txtSC"
        Me.txtSC.Size = New System.Drawing.Size(314, 26)
        Me.txtSC.TabIndex = 59
        '
        'txtNIF
        '
        Me.txtNIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIF.Location = New System.Drawing.Point(365, 177)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.Size = New System.Drawing.Size(314, 26)
        Me.txtNIF.TabIndex = 58
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(365, 117)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(314, 26)
        Me.txtName.TabIndex = 57
        '
        'spCond
        '
        Me.spCond.AutoSize = True
        Me.spCond.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spCond.Location = New System.Drawing.Point(384, 352)
        Me.spCond.Name = "spCond"
        Me.spCond.Size = New System.Drawing.Size(177, 20)
        Me.spCond.TabIndex = 55
        Me.spCond.Text = "Sponsorship Conditions"
        '
        'spLvl
        '
        Me.spLvl.AutoSize = True
        Me.spLvl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spLvl.Location = New System.Drawing.Point(269, 310)
        Me.spLvl.Name = "spLvl"
        Me.spLvl.Size = New System.Drawing.Size(139, 20)
        Me.spLvl.TabIndex = 54
        Me.spLvl.Text = "Sponsorship Level"
        '
        'clube
        '
        Me.clube.AutoSize = True
        Me.clube.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clube.Location = New System.Drawing.Point(269, 244)
        Me.clube.Name = "clube"
        Me.clube.Size = New System.Drawing.Size(92, 20)
        Me.clube.TabIndex = 53
        Me.clube.Text = "Sports Club"
        '
        'NIF
        '
        Me.NIF.AutoSize = True
        Me.NIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NIF.Location = New System.Drawing.Point(269, 180)
        Me.NIF.Name = "NIF"
        Me.NIF.Size = New System.Drawing.Size(35, 20)
        Me.NIF.TabIndex = 52
        Me.NIF.Text = "NIF"
        '
        'Nome
        '
        Me.Nome.AutoSize = True
        Me.Nome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nome.Location = New System.Drawing.Point(269, 120)
        Me.Nome.Name = "Nome"
        Me.Nome.Size = New System.Drawing.Size(51, 20)
        Me.Nome.TabIndex = 51
        Me.Nome.Text = "Name"
        '
        'bttnExit
        '
        Me.bttnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnExit.Location = New System.Drawing.Point(581, 12)
        Me.bttnExit.Name = "bttnExit"
        Me.bttnExit.Size = New System.Drawing.Size(96, 36)
        Me.bttnExit.TabIndex = 50
        Me.bttnExit.Text = "Exit"
        Me.bttnExit.UseVisualStyleBackColor = True
        '
        'bttnBack
        '
        Me.bttnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnBack.Location = New System.Drawing.Point(275, 12)
        Me.bttnBack.Name = "bttnBack"
        Me.bttnBack.Size = New System.Drawing.Size(96, 36)
        Me.bttnBack.TabIndex = 49
        Me.bttnBack.Text = "Back"
        Me.bttnBack.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(270, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 26)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Business - Sponsors"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(1, 1)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(262, 604)
        Me.ListBox1.TabIndex = 47
        '
        'bttnOK
        '
        Me.bttnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnOK.Location = New System.Drawing.Point(531, 558)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(96, 36)
        Me.bttnOK.TabIndex = 69
        Me.bttnOK.Text = "OK"
        Me.bttnOK.UseVisualStyleBackColor = True
        Me.bttnOK.Visible = False
        '
        'bttnCancel
        '
        Me.bttnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCancel.Location = New System.Drawing.Point(329, 558)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(96, 36)
        Me.bttnCancel.TabIndex = 70
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = True
        Me.bttnCancel.Visible = False
        '
        'txtSpLvl
        '
        Me.txtSpLvl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpLvl.FormattingEnabled = True
        Me.txtSpLvl.Items.AddRange(New Object() {"", "1", "2", "3"})
        Me.txtSpLvl.Location = New System.Drawing.Point(414, 307)
        Me.txtSpLvl.Name = "txtSpLvl"
        Me.txtSpLvl.Size = New System.Drawing.Size(265, 28)
        Me.txtSpLvl.TabIndex = 112
        '
        'Patrocinadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 606)
        Me.Controls.Add(Me.txtSpLvl)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.bttnCreate)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.bttnUpdate)
        Me.Controls.Add(Me.bttnSearch)
        Me.Controls.Add(Me.txtSpCond)
        Me.Controls.Add(Me.txtSC)
        Me.Controls.Add(Me.txtNIF)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.spCond)
        Me.Controls.Add(Me.spLvl)
        Me.Controls.Add(Me.clube)
        Me.Controls.Add(Me.NIF)
        Me.Controls.Add(Me.Nome)
        Me.Controls.Add(Me.bttnExit)
        Me.Controls.Add(Me.bttnBack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Patrocinadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patrocinadores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bttnCreate As Button
    Friend WithEvents bttnDelete As Button
    Friend WithEvents bttnUpdate As Button
    Friend WithEvents bttnSearch As Button
    Friend WithEvents txtSpCond As TextBox
    Friend WithEvents txtSC As TextBox
    Friend WithEvents txtNIF As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents spCond As Label
    Friend WithEvents spLvl As Label
    Friend WithEvents clube As Label
    Friend WithEvents NIF As Label
    Friend WithEvents Nome As Label
    Friend WithEvents bttnExit As Button
    Friend WithEvents bttnBack As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents bttnOK As Button
    Friend WithEvents bttnCancel As Button
    Friend WithEvents txtSpLvl As ComboBox
End Class
