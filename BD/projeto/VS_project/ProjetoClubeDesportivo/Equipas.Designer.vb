<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Equipas
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
        Me.txtTP = New System.Windows.Forms.TextBox()
        Me.TP = New System.Windows.Forms.Label()
        Me.txtModalidade = New System.Windows.Forms.TextBox()
        Me.Modalidade = New System.Windows.Forms.Label()
        Me.txtClube = New System.Windows.Forms.TextBox()
        Me.Type = New System.Windows.Forms.Label()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.bttnCreate = New System.Windows.Forms.Button()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.bttnUpdate = New System.Windows.Forms.Button()
        Me.bttnSearch = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.id = New System.Windows.Forms.Label()
        Me.Nome = New System.Windows.Forms.Label()
        Me.bttnExit = New System.Windows.Forms.Button()
        Me.bttnBack = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.bttnListPlayers = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.CodeModal = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtTP
        '
        Me.txtTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTP.Location = New System.Drawing.Point(370, 375)
        Me.txtTP.Name = "txtTP"
        Me.txtTP.Size = New System.Drawing.Size(314, 26)
        Me.txtTP.TabIndex = 158
        '
        'TP
        '
        Me.TP.AutoSize = True
        Me.TP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TP.Location = New System.Drawing.Point(265, 378)
        Me.TP.Name = "TP"
        Me.TP.Size = New System.Drawing.Size(108, 20)
        Me.TP.TabIndex = 157
        Me.TP.Text = "Training Place"
        '
        'txtModalidade
        '
        Me.txtModalidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModalidade.Location = New System.Drawing.Point(370, 311)
        Me.txtModalidade.Name = "txtModalidade"
        Me.txtModalidade.Size = New System.Drawing.Size(314, 26)
        Me.txtModalidade.TabIndex = 156
        '
        'Modalidade
        '
        Me.Modalidade.AutoSize = True
        Me.Modalidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Modalidade.Location = New System.Drawing.Point(265, 314)
        Me.Modalidade.Name = "Modalidade"
        Me.Modalidade.Size = New System.Drawing.Size(67, 20)
        Me.Modalidade.TabIndex = 155
        Me.Modalidade.Text = "Modality"
        '
        'txtClube
        '
        Me.txtClube.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClube.Location = New System.Drawing.Point(370, 251)
        Me.txtClube.Name = "txtClube"
        Me.txtClube.Size = New System.Drawing.Size(314, 26)
        Me.txtClube.TabIndex = 154
        '
        'Type
        '
        Me.Type.AutoSize = True
        Me.Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Type.Location = New System.Drawing.Point(265, 254)
        Me.Type.Name = "Type"
        Me.Type.Size = New System.Drawing.Size(50, 20)
        Me.Type.TabIndex = 153
        Me.Type.Text = "Clube"
        '
        'bttnCancel
        '
        Me.bttnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCancel.Location = New System.Drawing.Point(329, 558)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(96, 36)
        Me.bttnCancel.TabIndex = 152
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = True
        Me.bttnCancel.Visible = False
        '
        'bttnOK
        '
        Me.bttnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnOK.Location = New System.Drawing.Point(531, 558)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(96, 36)
        Me.bttnOK.TabIndex = 151
        Me.bttnOK.Text = "OK"
        Me.bttnOK.UseVisualStyleBackColor = True
        Me.bttnOK.Visible = False
        '
        'bttnCreate
        '
        Me.bttnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCreate.Location = New System.Drawing.Point(479, 558)
        Me.bttnCreate.Name = "bttnCreate"
        Me.bttnCreate.Size = New System.Drawing.Size(96, 36)
        Me.bttnCreate.TabIndex = 150
        Me.bttnCreate.Text = "Create"
        Me.bttnCreate.UseVisualStyleBackColor = True
        '
        'bttnDelete
        '
        Me.bttnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnDelete.Location = New System.Drawing.Point(377, 558)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(96, 36)
        Me.bttnDelete.TabIndex = 149
        Me.bttnDelete.Text = "Delete"
        Me.bttnDelete.UseVisualStyleBackColor = True
        '
        'bttnUpdate
        '
        Me.bttnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnUpdate.Location = New System.Drawing.Point(275, 558)
        Me.bttnUpdate.Name = "bttnUpdate"
        Me.bttnUpdate.Size = New System.Drawing.Size(96, 36)
        Me.bttnUpdate.TabIndex = 148
        Me.bttnUpdate.Text = "Update"
        Me.bttnUpdate.UseVisualStyleBackColor = True
        '
        'bttnSearch
        '
        Me.bttnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnSearch.Location = New System.Drawing.Point(581, 558)
        Me.bttnSearch.Name = "bttnSearch"
        Me.bttnSearch.Size = New System.Drawing.Size(96, 36)
        Me.bttnSearch.TabIndex = 147
        Me.bttnSearch.Text = "Search"
        Me.bttnSearch.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(370, 190)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(314, 26)
        Me.txtID.TabIndex = 146
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(370, 130)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(314, 26)
        Me.txtName.TabIndex = 145
        '
        'id
        '
        Me.id.AutoSize = True
        Me.id.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.Location = New System.Drawing.Point(265, 193)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(26, 20)
        Me.id.TabIndex = 144
        Me.id.Text = "ID"
        '
        'Nome
        '
        Me.Nome.AutoSize = True
        Me.Nome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nome.Location = New System.Drawing.Point(265, 133)
        Me.Nome.Name = "Nome"
        Me.Nome.Size = New System.Drawing.Size(51, 20)
        Me.Nome.TabIndex = 143
        Me.Nome.Text = "Name"
        '
        'bttnExit
        '
        Me.bttnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnExit.Location = New System.Drawing.Point(581, 12)
        Me.bttnExit.Name = "bttnExit"
        Me.bttnExit.Size = New System.Drawing.Size(96, 36)
        Me.bttnExit.TabIndex = 142
        Me.bttnExit.Text = "Exit"
        Me.bttnExit.UseVisualStyleBackColor = True
        '
        'bttnBack
        '
        Me.bttnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnBack.Location = New System.Drawing.Point(275, 12)
        Me.bttnBack.Name = "bttnBack"
        Me.bttnBack.Size = New System.Drawing.Size(96, 36)
        Me.bttnBack.TabIndex = 141
        Me.bttnBack.Text = "Back"
        Me.bttnBack.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(270, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 26)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Competitve - Equipas"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(1, 1)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(262, 604)
        Me.ListBox1.TabIndex = 139
        '
        'bttnListPlayers
        '
        Me.bttnListPlayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnListPlayers.Location = New System.Drawing.Point(426, 465)
        Me.bttnListPlayers.Name = "bttnListPlayers"
        Me.bttnListPlayers.Size = New System.Drawing.Size(96, 36)
        Me.bttnListPlayers.TabIndex = 159
        Me.bttnListPlayers.Text = "List Players"
        Me.bttnListPlayers.UseVisualStyleBackColor = True
        Me.bttnListPlayers.Visible = False
        '
        'ListBox2
        '
        Me.ListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 20
        Me.ListBox2.Location = New System.Drawing.Point(269, 421)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(415, 124)
        Me.ListBox2.TabIndex = 160
        Me.ListBox2.Visible = False
        '
        'CodeModal
        '
        Me.CodeModal.AutoSize = True
        Me.CodeModal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodeModal.Location = New System.Drawing.Point(265, 314)
        Me.CodeModal.Name = "CodeModal"
        Me.CodeModal.Size = New System.Drawing.Size(88, 20)
        Me.CodeModal.TabIndex = 161
        Me.CodeModal.Text = "Modality ID"
        Me.CodeModal.Visible = False
        '
        'Equipas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 606)
        Me.Controls.Add(Me.CodeModal)
        Me.Controls.Add(Me.bttnListPlayers)
        Me.Controls.Add(Me.txtTP)
        Me.Controls.Add(Me.TP)
        Me.Controls.Add(Me.txtModalidade)
        Me.Controls.Add(Me.Modalidade)
        Me.Controls.Add(Me.txtClube)
        Me.Controls.Add(Me.Type)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.bttnCreate)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.bttnUpdate)
        Me.Controls.Add(Me.bttnSearch)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.Nome)
        Me.Controls.Add(Me.bttnExit)
        Me.Controls.Add(Me.bttnBack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ListBox2)
        Me.Name = "Equipas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equipas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTP As TextBox
    Friend WithEvents TP As Label
    Friend WithEvents txtModalidade As TextBox
    Friend WithEvents Modalidade As Label
    Friend WithEvents txtClube As TextBox
    Friend WithEvents Type As Label
    Friend WithEvents bttnCancel As Button
    Friend WithEvents bttnOK As Button
    Friend WithEvents bttnCreate As Button
    Friend WithEvents bttnDelete As Button
    Friend WithEvents bttnUpdate As Button
    Friend WithEvents bttnSearch As Button
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents id As Label
    Friend WithEvents Nome As Label
    Friend WithEvents bttnExit As Button
    Friend WithEvents bttnBack As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents bttnListPlayers As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents CodeModal As Label
End Class
