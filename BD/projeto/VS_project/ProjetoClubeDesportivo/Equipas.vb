Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Equipas

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim Equipa As Integer = -1
    Dim query As String
    Dim queryType As String
    Dim locked As Integer = 0

    Private Sub Equipas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT e.nome as equipa, e.local_treino, e.ID, e.codigo_modal, e.clube as clubeID, m.nome as modalidade, c.nome as clube 
                FROM (ClubeDesportivo.modalidade AS m JOIN (ClubeDesportivo.equipa AS e JOIN ClubeDesportivo.clube_desportivo AS c ON e.clube = c.NIF) ON m.codigo = e.codigo_modal)"
        GetTableContent()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            Equipa = ListBox1.SelectedIndex
            If ListBox1.Items.Count = 0 Or Equipa < 0 Then Exit Sub
            Dim id = Split(ListBox1.Items.Item(Equipa), " ")(0).ToString()
            query = "SELECT e.nome as equipa, e.local_treino, e.ID, e.codigo_modal, e.clube as clubeID, m.nome as modalidade, c.nome as clube 
                    FROM (ClubeDesportivo.modalidade AS m JOIN (ClubeDesportivo.equipa AS e JOIN ClubeDesportivo.clube_desportivo AS c ON e.clube = c.NIF AND e.ID = " + id + ") ON m.codigo = e.codigo_modal)"

            ClearFields()
            ShowEquipa()
            LockControls()
        End If
    End Sub

    Private Sub ShowEquipa()
        If ListBox1.Items.Count = 0 Or Equipa < 0 Then Exit Sub
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            txtName.Text = Convert.ToString(reader.Item("equipa"))
            txtModalidade.Text = Convert.ToString(reader.Item("modalidade"))
            txtClube.Text = Convert.ToString(reader.Item("clube"))
            txtTP.Text = Convert.ToString(reader.Item("local_treino"))
            txtID.Text = Convert.ToString(reader.Item("ID"))
        End While
        reader.Close()
    End Sub

    Private Sub GetTableContent()
        If CN.State = ConnectionState.Closed Then Exit Sub
        Dim str As String = ""
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            str = ""
            str += Convert.ToString(reader.Item("ID"))
            str += " - " + Convert.ToString(reader.Item("equipa"))
            ListBox1.Items.Add(str)
        End While
        reader.Close()
    End Sub

    Private Sub TestDBConnection()
        Try
            CN.Open()
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR" +
                                vbCrLf + ex.Message, MsgBoxStyle.Critical, "Connection Test")
        End Try
    End Sub

    Sub LockControls()
        txtName.ReadOnly = True
        txtID.ReadOnly = True
        txtModalidade.ReadOnly = True
        txtTP.ReadOnly = True
        txtClube.ReadOnly = True
        locked = 1
        bttnListPlayers.Visible = True
    End Sub

    Sub ClearFields()
        txtName.Text = ""
        txtID.Text = ""
        txtModalidade.Text = ""
        txtTP.Text = ""
        ListBox2.Text = ""
        bttnListPlayers.Visible = False
    End Sub

    Sub UnlockControls()
        txtName.ReadOnly = False
        txtModalidade.ReadOnly = False
        txtID.ReadOnly = False
        txtTP.ReadOnly = False
        ListBox2.Visible = False
        locked = 0
    End Sub

    Sub ShowButtons()
        bttnCreate.Visible = True
        bttnDelete.Visible = True
        bttnSearch.Visible = True
        bttnUpdate.Visible = True
        bttnListPlayers.Visible = False
        bttnOK.Visible = False
        bttnCancel.Visible = False
        CodeModal.Visible = False
        Modalidade.Visible = True
    End Sub

    Sub HideButtons()
        bttnCreate.Visible = False
        bttnDelete.Visible = False
        bttnSearch.Visible = False
        bttnUpdate.Visible = False
        bttnListPlayers.Visible = False
        bttnOK.Visible = True
        bttnCancel.Visible = True
        ListBox2.Visible = False
        CodeModal.Visible = True
        Modalidade.Visible = False
    End Sub

    Private Sub bttnBack_Click(sender As Object, e As EventArgs) Handles bttnBack.Click
        CN.Close()
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub bttnExit_Click(sender As Object, e As EventArgs) Handles bttnExit.Click
        CN.Close()
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub bttnUpdate_Click(sender As Object, e As EventArgs) Handles bttnUpdate.Click
        If ListBox1.Items.Count = 0 Or Equipa < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If

        query = "ClubeDesportivo.UpdateEquipa"
        queryType = "U"
        UnlockControls()
        txtID.ReadOnly = True
        txtClube.ReadOnly = True
        HideButtons()
    End Sub

    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        ShowButtons()
        ClearFields()
        UnlockControls()
        ListBox1.ClearSelected()
        Equipa = -1
        query = ""
        queryType = ""
    End Sub

    Private Sub bttnDelete_Click(sender As Object, e As EventArgs) Handles bttnDelete.Click
        If ListBox1.Items.Count = 0 Or Equipa < 0 Then
            MsgBox("ERROR: Please Select entry to Delete!")
            Exit Sub
        End If

        query = "ClubeDesportivo.DeleteEquipa"
        queryType = "D"
        HideButtons()
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        txtName.Text = ""
        txtID.Text = ""
        txtModalidade.Text = ""
        txtTP.Text = ""
        UnlockControls()
        HideButtons()
        txtID.ReadOnly = True
        txtClube.ReadOnly = True
        query = ""
        query = "ClubeDesportivo.CreateEquipa"
        queryType = "C"
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click
        Dim id As Integer = 0
        Dim nome As String
        Dim clube As Integer = 999
        Dim local As String
        Dim modalidade As Integer = 0
        Dim result As Integer

        If txtID.Text <> "" Then
            id = txtID.Text
        End If
        nome = txtName.Text
        If queryType <> "D" Then
            Try
                modalidade = txtModalidade.Text
            Catch ex As Exception
                MsgBox("ERROR: Please insert the Modality ID!")
            End Try
        End If
        local = txtTP.Text


            Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@id", SqlDbType.Int).Value = id
            CMD2.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome
            CMD2.Parameters.Add("@clube", SqlDbType.Int).Value = clube
            CMD2.Parameters.Add("@local", SqlDbType.VarChar).Value = local
            CMD2.Parameters.Add("@code_modal", SqlDbType.Int).Value = modalidade

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            result = ReturnValue.Value

            If result = 1 Then
                MsgBox("ERROR: There is already a Team with the code " + id.ToString() + "!")
            ElseIf result = 100 Then
                MsgBox("ERROR: There is no Team with the code " + id.ToString() + "!")
            ElseIf result = 10 Then
                If nome <> "" Then
                    MsgBox("ERROR: There is no Team with the code " + id.ToString() + "!")
                Else
                    MsgBox("ERROR: Invalid name!")
                End If
            ElseIf result = 1000 Then
                MsgBox("ERROR: There is no Modality with the code " + modalidade.ToString() + "!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT e.nome as equipa, e.local_treino, e.ID, e.codigo_modal, e.clube as clubeID, m.nome as modalidade, c.nome as clube 
                FROM (ClubeDesportivo.modalidade AS m JOIN (ClubeDesportivo.equipa AS e JOIN ClubeDesportivo.clube_desportivo AS c ON e.clube = c.NIF) ON m.codigo = e.codigo_modal)"
        ClearFields()
        ListBox1.Items.Clear()
        GetTableContent()
        ShowButtons()
        UnlockControls()
        Equipa = -1
        queryType = ""
    End Sub

    Private Sub bttnSearch_Click(sender As Object, e As EventArgs) Handles bttnSearch.Click
        If locked = 1 Then
            UnlockControls()
            ClearFields()
            queryType = ""
            Exit Sub
        End If

        query = ""
        query = "SELECT e.nome as equipa, e.local_treino, e.ID, e.codigo_modal, e.clube as clubeID, m.nome as modalidade, c.nome as clube 
                FROM (ClubeDesportivo.modalidade AS m JOIN (ClubeDesportivo.equipa AS e JOIN ClubeDesportivo.clube_desportivo AS c ON e.clube = c.NIF) ON m.codigo = e.codigo_modal) WHERE "

        Dim nome As String
        Dim clube As String
        Dim id As String
        Dim modal As String
        Dim TP As String
        Dim entry As Integer

        nome = txtName.Text
        id = txtID.Text
        clube = txtClube.Text
        modal = txtModalidade.Text
        TP = txtTP.Text
        entry = 0


        If nome <> "" Then
            If entry > 0 Then
                query += " AND e.nome = '" + nome + "'"
            Else
                query += "e.nome = '" + nome + "'"
                entry += 1
            End If
        End If

        If clube <> "" Then
            If entry > 0 Then
                query += " AND c.nome = '" + clube + "'"
            Else
                query += "c.nome = '" + clube + "'"
                entry += 1
            End If
        End If

        If id <> "" Then
            If entry > 0 Then
                query += " AND e.ID = " + id
            Else
                query += "e.ID = " + id
                entry += 1
            End If
        End If

        If TP <> "" Then
            If entry > 0 Then
                query += " AND e.local_treino = '" + TP + "'"
            Else
                query += "e.local_treino = '" + TP + "'"
                entry += 1
            End If
        End If

        If modal <> "" Then
            If entry > 0 Then
                query += " AND e.codigo_modal = " + modal
            Else
                query += "e.codigo_modal = " + modal
                entry += 1
            End If
        End If

        If entry = 0 Then
            query = "SELECT e.nome as equipa, e.local_treino, e.ID, e.codigo_modal, e.clube as clubeID, m.nome as modalidade, c.nome as clube 
                FROM (ClubeDesportivo.modalidade AS m JOIN (ClubeDesportivo.equipa AS e JOIN ClubeDesportivo.clube_desportivo AS c ON e.clube = c.NIF) ON m.codigo = e.codigo_modal)"
        Else
            query += ";"
        End If

        ListBox1.Items.Clear()
        GetTableContent()
        Equipa = -1
    End Sub

    Private Sub bttnListPlayers_Click(sender As Object, e As EventArgs) Handles bttnListPlayers.Click

        If CN.State = ConnectionState.Closed Then Exit Sub

        bttnListPlayers.Visible = False
        ListBox2.Items.Clear()
        ListBox2.Visible = True

        Dim id As String
        id = txtID.Text

        query = ""
        query = "SELECT * FROM ClubeDesportivo.ListTeamPlayers WHERE equipa = @id ;"

        Dim str As String = ""
        CMD = New SqlCommand(query, CN)
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@id", id)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            str = ""
            str += Convert.ToString(reader.Item("num_socio")) + " - " + Convert.ToString(reader.Item("primeiro_nome")) + " " + Convert.ToString(reader.Item("ultimo_nome"))
            ListBox2.Items.Add(str)
        End While
        reader.Close()

    End Sub
End Class