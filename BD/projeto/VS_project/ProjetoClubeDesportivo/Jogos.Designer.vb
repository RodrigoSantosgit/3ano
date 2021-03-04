<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Jogos
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
        Me.place_tb = New System.Windows.Forms.TextBox()
        Me.place_label = New System.Windows.Forms.Label()
        Me.date_tb = New System.Windows.Forms.TextBox()
        Me.date_label = New System.Windows.Forms.Label()
        Me.id_tb = New System.Windows.Forms.TextBox()
        Me.id_label = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.score_label = New System.Windows.Forms.Label()
        Me.team2_tb = New System.Windows.Forms.TextBox()
        Me.team1_label = New System.Windows.Forms.Label()
        Me.team1_tb = New System.Windows.Forms.TextBox()
        Me.team2_label = New System.Windows.Forms.Label()
        Me.score_tb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'bttnCancel
        '
        Me.bttnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCancel.Location = New System.Drawing.Point(365, 497)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(96, 36)
        Me.bttnCancel.TabIndex = 134
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = True
        Me.bttnCancel.Visible = False
        '
        'bttnOK
        '
        Me.bttnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnOK.Location = New System.Drawing.Point(567, 497)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(96, 36)
        Me.bttnOK.TabIndex = 133
        Me.bttnOK.Text = "OK"
        Me.bttnOK.UseVisualStyleBackColor = True
        Me.bttnOK.Visible = False
        '
        'bttnCreate
        '
        Me.bttnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCreate.Location = New System.Drawing.Point(520, 497)
        Me.bttnCreate.Name = "bttnCreate"
        Me.bttnCreate.Size = New System.Drawing.Size(96, 36)
        Me.bttnCreate.TabIndex = 132
        Me.bttnCreate.Text = "Create"
        Me.bttnCreate.UseVisualStyleBackColor = True
        '
        'bttnDelete
        '
        Me.bttnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnDelete.Location = New System.Drawing.Point(418, 497)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(96, 36)
        Me.bttnDelete.TabIndex = 131
        Me.bttnDelete.Text = "Delete"
        Me.bttnDelete.UseVisualStyleBackColor = True
        '
        'bttnUpdate
        '
        Me.bttnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnUpdate.Location = New System.Drawing.Point(316, 497)
        Me.bttnUpdate.Name = "bttnUpdate"
        Me.bttnUpdate.Size = New System.Drawing.Size(96, 36)
        Me.bttnUpdate.TabIndex = 130
        Me.bttnUpdate.Text = "Update"
        Me.bttnUpdate.UseVisualStyleBackColor = True
        '
        'bttnSearch
        '
        Me.bttnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnSearch.Location = New System.Drawing.Point(622, 497)
        Me.bttnSearch.Name = "bttnSearch"
        Me.bttnSearch.Size = New System.Drawing.Size(96, 36)
        Me.bttnSearch.TabIndex = 129
        Me.bttnSearch.Text = "Search"
        Me.bttnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(290, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 26)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Game"
        '
        'bttnExit
        '
        Me.bttnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnExit.Location = New System.Drawing.Point(648, 12)
        Me.bttnExit.Name = "bttnExit"
        Me.bttnExit.Size = New System.Drawing.Size(96, 36)
        Me.bttnExit.TabIndex = 127
        Me.bttnExit.Text = "Exit"
        Me.bttnExit.UseVisualStyleBackColor = True
        '
        'bttnBack
        '
        Me.bttnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnBack.Location = New System.Drawing.Point(293, 12)
        Me.bttnBack.Name = "bttnBack"
        Me.bttnBack.Size = New System.Drawing.Size(96, 36)
        Me.bttnBack.TabIndex = 126
        Me.bttnBack.Text = "Back"
        Me.bttnBack.UseVisualStyleBackColor = True
        '
        'place_tb
        '
        Me.place_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.place_tb.Location = New System.Drawing.Point(436, 182)
        Me.place_tb.Name = "place_tb"
        Me.place_tb.Size = New System.Drawing.Size(308, 26)
        Me.place_tb.TabIndex = 115
        '
        'place_label
        '
        Me.place_label.AutoSize = True
        Me.place_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.place_label.Location = New System.Drawing.Point(291, 185)
        Me.place_label.Name = "place_label"
        Me.place_label.Size = New System.Drawing.Size(48, 20)
        Me.place_label.TabIndex = 114
        Me.place_label.Text = "Place"
        '
        'date_tb
        '
        Me.date_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tb.Location = New System.Drawing.Point(436, 147)
        Me.date_tb.Name = "date_tb"
        Me.date_tb.Size = New System.Drawing.Size(308, 26)
        Me.date_tb.TabIndex = 113
        '
        'date_label
        '
        Me.date_label.AutoSize = True
        Me.date_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_label.Location = New System.Drawing.Point(291, 150)
        Me.date_label.Name = "date_label"
        Me.date_label.Size = New System.Drawing.Size(44, 20)
        Me.date_label.TabIndex = 112
        Me.date_label.Text = "Date"
        '
        'id_tb
        '
        Me.id_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id_tb.Location = New System.Drawing.Point(436, 112)
        Me.id_tb.Name = "id_tb"
        Me.id_tb.Size = New System.Drawing.Size(308, 26)
        Me.id_tb.TabIndex = 111
        '
        'id_label
        '
        Me.id_label.AutoSize = True
        Me.id_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id_label.Location = New System.Drawing.Point(291, 115)
        Me.id_label.Name = "id_label"
        Me.id_label.Size = New System.Drawing.Size(26, 20)
        Me.id_label.TabIndex = 110
        Me.id_label.Text = "ID"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(9, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(259, 524)
        Me.ListBox1.TabIndex = 109
        '
        'score_label
        '
        Me.score_label.AutoSize = True
        Me.score_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.score_label.Location = New System.Drawing.Point(291, 220)
        Me.score_label.Name = "score_label"
        Me.score_label.Size = New System.Drawing.Size(51, 20)
        Me.score_label.TabIndex = 116
        Me.score_label.Text = "Score"
        '
        'team2_tb
        '
        Me.team2_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.team2_tb.Location = New System.Drawing.Point(436, 287)
        Me.team2_tb.Name = "team2_tb"
        Me.team2_tb.Size = New System.Drawing.Size(308, 26)
        Me.team2_tb.TabIndex = 121
        '
        'team1_label
        '
        Me.team1_label.AutoSize = True
        Me.team1_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.team1_label.Location = New System.Drawing.Point(291, 255)
        Me.team1_label.Name = "team1_label"
        Me.team1_label.Size = New System.Drawing.Size(83, 20)
        Me.team1_label.TabIndex = 118
        Me.team1_label.Text = "Team 1 ID"
        '
        'team1_tb
        '
        Me.team1_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.team1_tb.Location = New System.Drawing.Point(436, 252)
        Me.team1_tb.Name = "team1_tb"
        Me.team1_tb.Size = New System.Drawing.Size(308, 26)
        Me.team1_tb.TabIndex = 119
        '
        'team2_label
        '
        Me.team2_label.AutoSize = True
        Me.team2_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.team2_label.Location = New System.Drawing.Point(291, 290)
        Me.team2_label.Name = "team2_label"
        Me.team2_label.Size = New System.Drawing.Size(83, 20)
        Me.team2_label.TabIndex = 120
        Me.team2_label.Text = "Team 2 ID"
        '
        'score_tb
        '
        Me.score_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.score_tb.Location = New System.Drawing.Point(436, 217)
        Me.score_tb.Name = "score_tb"
        Me.score_tb.Size = New System.Drawing.Size(308, 26)
        Me.score_tb.TabIndex = 117
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(291, 329)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 20)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Team 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(516, 329)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 20)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "Team 2"
        '
        'ListBox2
        '
        Me.ListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 20
        Me.ListBox2.Location = New System.Drawing.Point(295, 352)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(219, 124)
        Me.ListBox2.TabIndex = 137
        '
        'ListBox3
        '
        Me.ListBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.ItemHeight = 20
        Me.ListBox3.Location = New System.Drawing.Point(520, 352)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(224, 124)
        Me.ListBox3.TabIndex = 138
        '
        'Jogos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 545)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label3)
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
        Me.Controls.Add(Me.team2_tb)
        Me.Controls.Add(Me.team2_label)
        Me.Controls.Add(Me.team1_tb)
        Me.Controls.Add(Me.team1_label)
        Me.Controls.Add(Me.score_tb)
        Me.Controls.Add(Me.score_label)
        Me.Controls.Add(Me.place_tb)
        Me.Controls.Add(Me.place_label)
        Me.Controls.Add(Me.date_tb)
        Me.Controls.Add(Me.date_label)
        Me.Controls.Add(Me.id_tb)
        Me.Controls.Add(Me.id_label)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Jogos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jogos"
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
    Friend WithEvents place_tb As TextBox
    Friend WithEvents place_label As Label
    Friend WithEvents date_tb As TextBox
    Friend WithEvents date_label As Label
    Friend WithEvents id_tb As TextBox
    Friend WithEvents id_label As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents score_label As Label
    Friend WithEvents team2_tb As TextBox
    Friend WithEvents team1_label As Label
    Friend WithEvents team1_tb As TextBox
    Friend WithEvents team2_label As Label
    Friend WithEvents score_tb As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ListBox3 As ListBox
End Class
