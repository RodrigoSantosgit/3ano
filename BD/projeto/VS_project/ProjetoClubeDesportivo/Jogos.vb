Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Jogos

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim current As Integer = -1
    Dim query As String
    Dim locked As Integer = 0


    Private Sub Socios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT j.ID AS jID, e1.nome AS e1Nome, e1.ID AS e1ID, e2.nome AS e2Nome, e2.ID AS e2ID FROM ClubeDesportivo.jogo AS j JOIN ClubeDesportivo.equipa AS e1 ON j.equipa1 = e1.ID JOIN ClubeDesportivo.equipa AS e2 ON e2.ID = j.equipa2"
        GetTableContent()
    End Sub
    Private Sub TestDBConnection()
        Try
            CN.Open()
            If CN.State = ConnectionState.Open Then
                ''MsgBox("Successful connection to database " + CN.Database + " on the " + CN.DataSource + " server", MsgBoxStyle.OkOnly, "Connection Test")
            End If
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR" +
                                vbCrLf + ex.Message, MsgBoxStyle.Critical, "Connection Test")
        End Try
    End Sub

    Private Function GetTableContent() As String
        If CN.State = ConnectionState.Closed Then Return ""
        Dim str As String = ""
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            str = ""
            str += Convert.ToString(reader.Item("jID"))
            str += ControlChars.Tab + Convert.ToString(reader.Item("e1Nome")) + " " + Convert.ToString(reader.Item("e1ID"))
            str += ControlChars.Tab + Convert.ToString(reader.Item("e2Nome")) + " " + Convert.ToString(reader.Item("e2ID"))
            str += vbCrLf
            ListBox1.Items.Add(str)
        End While
        reader.Close()
        Return str
    End Function

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            current = ListBox1.SelectedIndex
            UpdateTextBox()
            LockControls()
        End If
    End Sub

    Sub UpdateTextBox()
        Dim Str = ListBox1.Items.Item(current).ToString
        Dim Str2 = ""
        For i As Integer = 0 To Str.Length - 1
            If Char.IsDigit(Str(i)) Then
                Str2 = Str2 + Str(i)
            Else
                Exit For
            End If
        Next
        ''primeiro_nome_tb.Text = Str2

        CMD = New SqlCommand("SELECT ID, data, local, resultado, equipa1, equipa2 FROM ClubeDesportivo.jogo AS j WHERE ID =" + Str2, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            id_tb.Text = Convert.ToString(reader.Item("ID"))
            date_tb.Text = Convert.ToString(reader.Item("data"))
            place_tb.Text = Convert.ToString(reader.Item("local"))
            score_tb.Text = Convert.ToString(reader.Item("resultado"))
            team1_tb.Text = Convert.ToString(reader.Item("equipa1"))
            team2_tb.Text = Convert.ToString(reader.Item("equipa2"))

        End While
        reader.Close()

        ''CMD = New SqlCommand("SELECT numero, primeiro_nome, ultimo_nome 
        ''FROM(ClubeDesportivo.pessoa As p JOIN (ClubeDesportivo.socio As s JOIN (ClubeDesportivo.jogador As j JOIN (ClubeDesportivo.joga As jga JOIN ClubeDesportivo.jogo As jgo On jgo.ID = jga.ID) On jga.jogador = j.num_socio) On s.numero = j.num_socio) On p.NIF = s.NIF) WHERE j.equipa = " + team1_tb.Text, CN)
        CMD = New SqlCommand("Select numero, primeiro_nome, ultimo_nome, equipa FROM ClubeDesportivo.ListMatchPlayers WHERE equipa = @equipa ;", CN)
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@equipa", team1_tb.Text)
        reader = CMD.ExecuteReader
        ListBox2.Items.Clear()
        While reader.Read
            Str = ""
            Str += Convert.ToString(reader.Item("numero"))
            Str += ControlChars.Tab + Convert.ToString(reader.Item("primeiro_nome")) + " " + Convert.ToString(reader.Item("ultimo_nome"))
            Str += vbCrLf
            ListBox2.Items.Add(Str)
        End While
        reader.Close()

        ''CMD = New SqlCommand("Select numero, primeiro_nome, ultimo_nome 
        ''FROM (ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.jogador AS j ON s.numero = j.num_socio) ON p.NIF = s.NIF) WHERE equipa = " + team2_tb.Text, CN)
        CMD = New SqlCommand("Select numero, primeiro_nome, ultimo_nome, equipa FROM ClubeDesportivo.ListMatchPlayers WHERE equipa = @equipa ;", CN)
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@equipa", team2_tb.Text)
        reader = CMD.ExecuteReader
        ListBox3.Items.Clear()
        While reader.Read
            Str = ""
            Str += Convert.ToString(reader.Item("numero"))
            Str += ControlChars.Tab + Convert.ToString(reader.Item("primeiro_nome")) + " " + Convert.ToString(reader.Item("ultimo_nome"))
            Str += vbCrLf
            ListBox3.Items.Add(Str)
        End While
        reader.Close()

    End Sub

    Private Sub bttnExit_Click(sender As Object, e As EventArgs) Handles bttnExit.Click
        CN.Close()
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub bttnBack_Click(sender As Object, e As EventArgs) Handles bttnBack.Click
        CN.Close()
        Form1.Show()
        Me.Close()
    End Sub

    Sub LockControls()
        team1_tb.ReadOnly = True
        id_tb.ReadOnly = True
        place_tb.ReadOnly = True
        score_tb.ReadOnly = True
        team2_tb.ReadOnly = True
        date_tb.ReadOnly = True
        locked = 1
    End Sub

    Sub ClearFields()
        team1_tb.Text = ""
        id_tb.Text = ""
        place_tb.Text = ""
        score_tb.Text = ""
        team2_tb.Text = ""
        date_tb.Text = ""
    End Sub

    Sub UnlockControls()
        team1_tb.ReadOnly = False
        id_tb.ReadOnly = False
        place_tb.ReadOnly = False
        score_tb.ReadOnly = False
        team2_tb.ReadOnly = False
        date_tb.ReadOnly = False
        locked = 0
    End Sub

    Sub ShowButtons()
        bttnCreate.Visible = True
        bttnDelete.Visible = True
        bttnSearch.Visible = True
        bttnUpdate.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Sub HideButtons()
        bttnCreate.Visible = False
        bttnDelete.Visible = False
        bttnSearch.Visible = False
        bttnUpdate.Visible = False
        bttnOK.Visible = True
        bttnCancel.Visible = True
    End Sub

    Private Sub bttnUpdate_Click(sender As Object, e As EventArgs) Handles bttnUpdate.Click
        If ListBox1.Items.Count = 0 Or current < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If

        query = "ClubeDesportivo.UpdateJogo"

        UnlockControls()
        id_tb.ReadOnly = True
        HideButtons()
    End Sub

    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        ShowButtons()
        ClearFields()
        UnlockControls()
        ListBox1.ClearSelected()
        current = -1
        query = ""
    End Sub

    Private Sub bttnDelete_Click(sender As Object, e As EventArgs) Handles bttnDelete.Click
        If ListBox1.Items.Count = 0 Or current < 0 Then
            MsgBox("ERROR: Please Select entry to Delete!")
            Exit Sub
        End If

        query = "ClubeDesportivo.DeleteJogo"

        HideButtons()
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        ClearFields()
        UnlockControls()
        HideButtons()
        id_tb.ReadOnly = True
        query = ""
        query = "ClubeDesportivo.CreateJogo"
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click

        Dim id As String
        Dim data As String
        Dim place As String
        Dim score As String
        Dim equipa1 As String
        Dim equipa2 As String
        Dim result As Integer

        If (id_tb.Text.Equals("")) Then
            id = 0
        Else
            id = id_tb.Text
        End If

        data = date_tb.Text
        place = place_tb.Text
        score = score_tb.Text
        equipa1 = team1_tb.Text
        equipa2 = team2_tb.Text

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@id", SqlDbType.Int).Value = id
            CMD2.Parameters.Add("@data", SqlDbType.Date).Value = data
            CMD2.Parameters.Add("@local", SqlDbType.VarChar).Value = place
            CMD2.Parameters.Add("@resultado", SqlDbType.VarChar).Value = score
            CMD2.Parameters.Add("@equipa1", SqlDbType.VarChar).Value = equipa1
            CMD2.Parameters.Add("@equipa2", SqlDbType.VarChar).Value = equipa2

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            result = ReturnValue.Value

            If result = 1 Then
                MsgBox("ERROR: There is already a Game with the id " + id.ToString() + "!")
            ElseIf result = 100 Then
                MsgBox("ERROR: There is no Game with the id " + id.ToString() + "!")
            ElseIf result = 10 Then
                If id <> "" Then
                    MsgBox("ERROR: There is no Game with the id " + id.ToString() + "!")
                Else
                    MsgBox("ERROR: Invalid name!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT j.ID AS jID, e1.nome AS e1Nome, e1.ID AS e1ID, e2.nome AS e2Nome, e2.ID AS e2ID FROM ClubeDesportivo.jogo AS j JOIN ClubeDesportivo.equipa AS e1 ON j.equipa1 = e1.ID JOIN ClubeDesportivo.equipa AS e2 ON e2.ID = j.equipa2"
        ClearFields()
        ListBox1.Items.Clear()
        GetTableContent()
        ShowButtons()
        UnlockControls()
    End Sub

    Private Sub bttnSearch_Click(sender As Object, e As EventArgs) Handles bttnSearch.Click
        If locked = 1 Then
            UnlockControls()
            ClearFields()
            Exit Sub
        End If
        query = ""
        query = "SELECT j.ID AS jID, e1.nome AS e1Nome, e1.ID AS e1ID, e2.nome AS e2Nome, e2.ID AS e2ID FROM ClubeDesportivo.jogo AS j JOIN ClubeDesportivo.equipa AS e1 ON j.equipa1 = e1.ID JOIN ClubeDesportivo.equipa AS e2 ON e2.ID = j.equipa2 WHERE "

        Dim id As String
        Dim score As String
        Dim data As String
        Dim place As String
        Dim team1 As String
        Dim team2 As String
        Dim entry As Integer
        Dim entry2 As Integer

        id = id_tb.Text
        data = date_tb.Text
        score = score_tb.Text
        place = place_tb.Text
        team1 = team1_tb.Text
        team2 = team2_tb.Text

        entry2 = 0
        entry = 0


        If id <> "" Then
            If entry2 > 0 Then
                query += " AND j.ID = " + id
            Else
                query += " j.ID = " + id
                entry2 += 1
            End If
        End If

        If score <> "" Then
            If entry2 > 0 Then
                query += " AND j.resultado = '" + score + "'"
            Else
                query += " j.resultado = '" + score + "'"
                entry2 += 1
            End If
        End If

        If place <> "" Then
            If entry2 > 0 Then
                query += " AND j.local = '" + place + "'"
            Else
                query += " j.local = '" + place + "'"
                entry2 += 1
            End If
        End If

        If data <> "" Then
            If entry2 > 0 Then
                query += " AND j.data = '" + data + "'"
            Else
                query += "j.data = '" + data + "'"
                entry2 += 1
            End If
        End If

        If team1 <> "" Then
            If entry2 > 0 Then
                query += " AND e1.ID = " + team1
            Else
                query += "e1.ID = " + team1
                entry2 += 1
            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If team2 <> "" Then
            If entry2 > 0 Then
                query += " AND e2.ID = " + team2
            Else
                query += "e2.ID = " + team2
                entry2 += 1
            End If
        End If

        If entry2 = 0 And entry = 0 Then
            query = "SELECT j.ID AS jID, e1.nome AS e1Nome, e1.ID AS e1ID, e2.nome AS e2Nome, e2.ID AS e2ID FROM ClubeDesportivo.jogo AS j JOIN ClubeDesportivo.equipa AS e1 ON j.equipa1 = e1.ID JOIN ClubeDesportivo.equipa AS e2 ON e2.ID = j.equipa2"

        Else
            If entry2 = 0 Then
                ''query += " p.NIF = s.NIF"
            Else
                ''query += " AND p.NIF = s.NIF"
            End If
        End If

        ListBox1.Items.Clear()
        GetTableContent()
    End Sub

End Class