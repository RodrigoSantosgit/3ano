Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Medicos

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim current As Integer = -1
    Dim query As String
    Dim locked As Integer = 0


    Private Sub Medicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT num_ordem_medicos, primeiro_nome, ultimo_nome FROM (ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.medico AS m ON p.NIF = m.NIF)"
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
            str += Convert.ToString(reader.Item("num_ordem_medicos"))
            str += ControlChars.Tab + Convert.ToString(reader.Item("primeiro_nome"))
            str += " " + Convert.ToString(reader.Item("ultimo_nome"))
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

        ListBox2.Items.Clear()
        GetTreatments()
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

        CMD = New SqlCommand("SELECT num_ordem_medicos, primeiro_nome, ultimo_nome, data_nasc, morada, data_inicio, data_fim, especialidade, p.NIF FROM (ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.medico AS m ON p.NIF = m.NIF) WHERE m.num_ordem_medicos =" + Str2, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            numero_tb.Text = Convert.ToString(reader.Item("num_ordem_medicos"))
            primeiro_nome_tb.Text = Convert.ToString(reader.Item("primeiro_nome"))
            ultimo_nome_tb.Text = Convert.ToString(reader.Item("ultimo_nome"))
            data_nasc_tb.Text = Convert.ToString(reader.Item("data_nasc"))
            morada_tb.Text = Convert.ToString(reader.Item("morada"))
            data_inicio_tb.Text = Convert.ToString(reader.Item("data_inicio"))
            data_fim_tb.Text = Convert.ToString(reader.Item("data_fim"))
            tipo_tb.Text = Convert.ToString(reader.Item("especialidade"))
            nif_tb.Text = Convert.ToString(reader.Item("NIF"))

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
        numero_tb.ReadOnly = True
        primeiro_nome_tb.ReadOnly = True
        ultimo_nome_tb.ReadOnly = True
        data_nasc_tb.ReadOnly = True
        morada_tb.ReadOnly = True
        data_inicio_tb.ReadOnly = True
        data_fim_tb.ReadOnly = True
        tipo_tb.ReadOnly = True
        nif_tb.ReadOnly = True
        locked = 1
    End Sub

    Sub ClearFields()
        numero_tb.Text = ""
        primeiro_nome_tb.Text = ""
        ultimo_nome_tb.Text = ""
        data_nasc_tb.Text = ""
        morada_tb.Text = ""
        data_inicio_tb.Text = ""
        data_fim_tb.Text = ""
        tipo_tb.Text = ""
        nif_tb.Text = ""
    End Sub

    Sub UnlockControls()
        numero_tb.ReadOnly = False
        primeiro_nome_tb.ReadOnly = False
        ultimo_nome_tb.ReadOnly = False
        data_nasc_tb.ReadOnly = False
        morada_tb.ReadOnly = False
        data_inicio_tb.ReadOnly = False
        data_fim_tb.ReadOnly = False
        tipo_tb.ReadOnly = False
        nif_tb.ReadOnly = False
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

        query = "ClubeDesportivo.UpdateMedico"

        UnlockControls()
        nif_tb.ReadOnly = True
        numero_tb.ReadOnly = True
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

        query = "ClubeDesportivo.DeleteMedico"

        HideButtons()
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        ClearFields()
        UnlockControls()
        HideButtons()
        query = ""
        query = "ClubeDesportivo.CreateMedico"
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click

        Dim nif As Integer
        Dim num As Integer
        Dim pn As String
        Dim ln As String
        Dim sd As Date
        Dim ed As Date
        Dim bd As Date
        Dim add As String
        Dim sp As String
        Dim Result As Integer

        nif = nif_tb.Text
        num = numero_tb.Text
        pn = primeiro_nome_tb.Text
        ln = ultimo_nome_tb.Text
        sd = data_inicio_tb.Text
        ed = data_fim_tb.Text
        bd = data_nasc_tb.Text
        add = morada_tb.Text
        sp = tipo_tb.Text

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@nif", SqlDbType.Int).Value = nif
            CMD2.Parameters.Add("@num", SqlDbType.Int).Value = num
            CMD2.Parameters.Add("@primeiro_nome", SqlDbType.VarChar).Value = pn
            CMD2.Parameters.Add("@ultimo_nome", SqlDbType.VarChar).Value = ln
            CMD2.Parameters.Add("@data_inicio", SqlDbType.Date).Value = sd
            CMD2.Parameters.Add("@data_fim", SqlDbType.Date).Value = ed
            CMD2.Parameters.Add("@data_nasc", SqlDbType.Date).Value = bd
            CMD2.Parameters.Add("@morada", SqlDbType.VarChar).Value = add
            CMD2.Parameters.Add("@especialidade", SqlDbType.VarChar).Value = sp

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            Result = ReturnValue.Value

            If Result = 1 Then
                MsgBox("ERROR: There is already a Doctor with the number " + num.ToString() + "!")
            ElseIf Result = 2 Then
                MsgBox("ERROR: There is already a Person with the nif " + nif.ToString() + "!")
            ElseIf Result = 100 Then
                MsgBox("ERROR: There is no Doctor with the number " + num.ToString() + "!")
            ElseIf Result = 10 Then
                If num <> "" Then
                    MsgBox("ERROR: There is no Doctor with the number " + num.ToString() + "!")
                Else
                    MsgBox("ERROR: Invalid name!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT num_ordem_medicos, primeiro_nome, ultimo_nome FROM (ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.medico AS m ON p.NIF = m.NIF)"
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
        query = "SELECT num_ordem_medicos, primeiro_nome, ultimo_nome FROM ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.medico AS m ON "

        Dim nome As String
        Dim address As String
        Dim NIF As String
        Dim birth As String
        Dim n_s As String
        Dim type As String
        Dim beg_date As String
        Dim end_date As String
        Dim entry As Integer
        Dim entry2 As Integer

        nome = primeiro_nome_tb.Text
        NIF = nif_tb.Text
        address = morada_tb.Text
        birth = data_nasc_tb.Text
        n_s = numero_tb.Text
        beg_date = data_inicio_tb.Text
        end_date = data_fim_tb.Text
        type = tipo_tb.Text

        entry2 = 0
        entry = 0


        If n_s <> "" Then
            If entry2 > 0 Then
                query += "AND m.num_ordem_medicos = " + n_s
            Else
                query += "m.num_ordem_medicos = " + n_s
                entry2 += 1
            End If
        End If

        If type <> "" Then
            If entry2 > 0 Then
                query += " AND m.especialidade = '" + type + "'"
            Else
                query += "m.especialidade = '" + type + "'"
                entry2 += 1
            End If
        End If

        If beg_date <> "" Then
            If entry2 > 0 Then
                query += " AND m.data_inicio = '" + beg_date + "'"
            Else
                query += "m.data_inicio = '" + beg_date + "'"
                entry2 += 1
            End If
        End If

        If end_date <> "" Then
            If entry2 > 0 Then
                query += " AND m.data_fim = '" + end_date + "'"
            Else
                query += "m.data_fim = '" + end_date + "'"
                entry2 += 1
            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If nome <> "" Then
            Dim str() As String = nome.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
            If str.Length > 1 Then
                query += "p.primeiro_nome = '" + str(0) + "' AND p.ultimo_nome = '" + str(1) + "'"
            Else
                query += "p.primeiro_nome = '" + str(0) + "'"
            End If
            entry2 += 1
        End If

        If NIF <> "" Then
            If entry2 > 0 Then
                query += " AND p.NIF = " + NIF
            Else
                query += "p.NIF = " + NIF
                entry2 += 1
            End If
        End If

        If address <> "" Then
            If entry2 > 0 Then
                query += " AND p.morada = '" + address + "'"
            Else
                query += "p.morada = '" + address + "'"
                entry2 += 1
            End If
        End If

        If birth <> "" Then
            If entry2 > 0 Then
                query += " AND p.data_nasc = '" + birth + "'"
            Else
                query += "p.data_nasc = '" + birth + "'"
                entry2 += 1
            End If
        End If

        If entry2 = 0 And entry = 0 Then
            query = "SELECT num_ordem_medicos, primeiro_nome, ultimo_nome FROM ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.medico AS m ON p.NIF = m.NIF"

        Else
            If entry2 = 0 Then
                query += " p.NIF = m.NIF"
            Else
                query += " AND p.NIF = m.NIF"
            End If
        End If

        ListBox1.Items.Clear()
        GetTableContent()
    End Sub

    Sub GetTreatments()
        query = ""
        query = "SELECT * FROM ClubeDesportivo.ListPlayerTreatments WHERE medico = @id ;"

        Dim id As String
        id = numero_tb.Text

        Dim str As String = ""
        CMD = New SqlCommand(query, CN)
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@id", id)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            str = ""
            str += "Treatment to " + Convert.ToString(reader.Item("primeiro_nome")) + " " + Convert.ToString(reader.Item("ultimo_nome"))
            ListBox2.Items.Add(str)
        End While
        reader.Close()
    End Sub

End Class