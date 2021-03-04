Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Treinos

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim current As Integer = -1
    Dim currentTeam As Integer = 0
    Dim currentDate As Date = Nothing
    Dim query As String
    Dim locked As Integer = 0


    Private Sub Socios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT data, equipa, nome FROM ClubeDesportivo.treino AS t JOIN ClubeDesportivo.equipa AS e ON t.equipa = e.ID"
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
            str += Convert.ToString(reader.Item("equipa")) + " " + Convert.ToString(reader.Item("nome"))
            If (Convert.ToUInt32(reader.Item("equipa")) >= 0) Then
                str += "   " + Convert.ToString(reader.Item("data"))
            Else
                str += ControlChars.Tab + Convert.ToString(reader.Item("data"))
            End If
            str += " AM"
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
        Dim Str1 = Str.Split("   ")(0)
        Dim Str4 = Str.Split("   ")(1)
        Dim Str2 = Str.Split("   ")(4) + " " + Str.Split("   ")(5) + " " + Str.Split("   ")(6)
        Dim Str3 = ""
        For i As Integer = 0 To Str1.Length - 1
            If Char.IsDigit(Str1(i)) Then
                Str3 = Str3 + Str1(i)
            Else
                Exit For
            End If
        Next
        team_name_tb.Text = Str4
        team_tb.Text = Str3
        currentTeam = Str3
        date_tb.Text = Str2
        currentDate = Str2
        CMD = New SqlCommand("SELECT local_treino FROM ClubeDesportivo.equipa WHERE ID =" + Str3, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            place_tb.Text = Convert.ToString(reader.Item("local_treino"))
        End While
        reader.Close()
    End Sub

    Private Sub bttnUpdate_Click(sender As Object, e As EventArgs) Handles bttnUpdate.Click
        If ListBox1.Items.Count = 0 Or current < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If

        query = "ClubeDesportivo.UpdateTreino"

        UnlockControls()
        team_name_tb.ReadOnly = True
        place_tb.ReadOnly = True
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

        query = "ClubeDesportivo.DeleteTreino"

        HideButtons()
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        ClearFields()
        UnlockControls()
        HideButtons()
        team_name_tb.ReadOnly = True
        place_tb.ReadOnly = True
        query = ""
        query = "ClubeDesportivo.CreateTreino"
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click

        Dim equipa As Integer
        Dim data As Date
        Dim result As Integer

        Try
            equipa = team_tb.Text
            data = date_tb.Text
        Catch ex As Exception
            MsgBox("ERROR: Invalid input!")
            Exit Sub
        End Try

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@equipa", SqlDbType.Int).Value = currentTeam
            CMD2.Parameters.Add("@data", SqlDbType.Date).Value = currentDate
            CMD2.Parameters.Add("@equipa2", SqlDbType.Int).Value = equipa
            CMD2.Parameters.Add("@data2", SqlDbType.Date).Value = data


            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            result = ReturnValue.Value

            If result = 1 Then
                MsgBox("ERROR: There is already a Training of the team " + equipa.ToString() + " on " + data + "!")
            ElseIf result = 100 Then
                MsgBox("ERROR: There is no Training of the team " + equipa.ToString() + " on " + data + "!")
            ElseIf result = 10 Then
                If equipa <> "" Then
                    MsgBox("ERROR: There is no training with the team " + equipa.ToString() + " on " + data + "!")
                Else
                    MsgBox("ERROR: Invalid team!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT data, equipa, nome FROM ClubeDesportivo.treino AS t JOIN ClubeDesportivo.equipa AS e ON t.equipa = e.ID"
        ClearFields()
        ListBox1.Items.Clear()
        GetTableContent()
        ShowButtons()
        UnlockControls()
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
        team_tb.ReadOnly = True
        place_tb.ReadOnly = True
        date_tb.ReadOnly = True
        team_name_tb.ReadOnly = True
        locked = 1
    End Sub

    Sub ClearFields()
        team_tb.Text = ""
        place_tb.Text = ""
        date_tb.Text = ""
        team_name_tb.Text = ""
    End Sub

    Sub UnlockControls()
        team_tb.ReadOnly = False
        place_tb.ReadOnly = False
        date_tb.ReadOnly = False
        team_name_tb.ReadOnly = False
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

    Private Sub bttnSearch_Click(sender As Object, e As EventArgs) Handles bttnSearch.Click
        If locked = 1 Then
            UnlockControls()
            ClearFields()
            Exit Sub
        End If
        query = ""
        query = "SELECT data, equipa, nome FROM ClubeDesportivo.treino AS t JOIN ClubeDesportivo.equipa AS e ON t.equipa = e.ID WHERE "

        Dim data As String
        Dim place As String
        Dim team As String
        Dim team_name As String
        Dim entry As Integer
        Dim entry2 As Integer

        data = date_tb.Text
        place = place_tb.Text
        team = team_tb.Text
        team_name = team_name_tb.Text

        entry2 = 0
        entry = 0


        If place <> "" Then
            If entry2 > 0 Then
                query += " AND e.local_treino = '" + place + "'"
            Else
                query += " e.local_treino = '" + place + "'"
                entry2 += 1
            End If
        End If

        If data <> "" Then
            If entry2 > 0 Then
                query += " AND t.data = '" + data + "'"
            Else
                query += "t.data = '" + data + "'"
                entry2 += 1
            End If
        End If

        If team <> "" Then
            If entry2 > 0 Then
                query += " AND t.equipa = " + team
            Else
                query += "t.equipa = " + team
                entry2 += 1
            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If team_name <> "" Then
            If entry2 > 0 Then
                query += " AND e.nome = '" + team_name + "'"
            Else
                query += "e.nome = '" + team_name + "'"
                entry2 += 1
            End If
        End If

        If entry2 = 0 And entry = 0 Then
            query = "SELECT data, equipa, nome FROM ClubeDesportivo.treino AS t JOIN ClubeDesportivo.equipa AS e ON t.equipa = e.ID"
        End If

        ListBox1.Items.Clear()
        GetTableContent()
    End Sub

End Class