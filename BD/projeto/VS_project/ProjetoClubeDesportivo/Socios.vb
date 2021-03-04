Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Socios

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim current As Integer = -1
    Dim query As String
    Dim locked As Integer = 0


    Private Sub Socios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT numero, primeiro_nome, ultimo_nome FROM ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.socio AS s ON p.NIF = s.NIF"
        GetTableContent()
        tipo_cb.DropDownStyle = ComboBoxStyle.DropDownList
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
            str += Convert.ToString(reader.Item("numero"))
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

        CMD = New SqlCommand("SELECT numero, primeiro_nome, ultimo_nome, data_nasc, morada, data_inicio, data_fim, tipo, p.NIF FROM ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.socio AS s ON p.NIF = s.NIF WHERE s.numero =" + Str2, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            numero_tb.Text = Convert.ToString(reader.Item("numero"))
            primeiro_nome_tb.Text = Convert.ToString(reader.Item("primeiro_nome"))
            last_name_tb.Text = Convert.ToString(reader.Item("ultimo_nome"))
            data_nasc_tb.Text = Convert.ToString(reader.Item("data_nasc"))
            morada_tb.Text = Convert.ToString(reader.Item("morada"))
            data_inicio_tb.Text = Convert.ToString(reader.Item("data_inicio"))
            data_fim_tb.Text = Convert.ToString(reader.Item("data_fim"))
            ''tipo_tb.Text = Convert.ToString(reader.Item("tipo"))
            nif_tb.Text = Convert.ToString(reader.Item("NIF"))
            tipo_cb.SelectedItem = Convert.ToString(reader.Item("tipo"))

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
        last_name_tb.ReadOnly = True
        data_nasc_tb.ReadOnly = True
        morada_tb.ReadOnly = True
        data_inicio_tb.ReadOnly = True
        data_fim_tb.ReadOnly = True
        ''tipo_tb.ReadOnly = True
        nif_tb.ReadOnly = True
        ''tipo_cb.Enabled = False
        locked = 1
    End Sub

    Sub ClearFields()
        numero_tb.Text = ""
        primeiro_nome_tb.Text = ""
        last_name_tb.Text = ""
        data_nasc_tb.Text = ""
        morada_tb.Text = ""
        data_inicio_tb.Text = ""
        data_fim_tb.Text = ""
        ''tipo_tb.Text = ""
        nif_tb.Text = ""
        tipo_cb.SelectedItem = ""
    End Sub

    Sub UnlockControls()
        numero_tb.ReadOnly = False
        primeiro_nome_tb.ReadOnly = False
        last_name_tb.ReadOnly = False
        data_nasc_tb.ReadOnly = False
        morada_tb.ReadOnly = False
        data_inicio_tb.ReadOnly = False
        data_fim_tb.ReadOnly = False
        ''tipo_tb.ReadOnly = False
        nif_tb.ReadOnly = False
        ''tipo_cb.Enabled = True
        tipo_cb.DropDownStyle = ComboBoxStyle.DropDown
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
        query = "SELECT numero, primeiro_nome, ultimo_nome FROM ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.socio AS s ON "

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
        Dim ln As String

        nome = primeiro_nome_tb.Text
        ln = last_name_tb.Text
        NIF = nif_tb.Text
        address = morada_tb.Text
        birth = data_nasc_tb.Text
        n_s = numero_tb.Text
        beg_date = data_inicio_tb.Text
        end_date = data_fim_tb.Text
        ''type = tipo_tb.Text
        type = tipo_cb.SelectedItem

        entry2 = 0
        entry = 0


        If n_s <> "" Then
            If entry2 > 0 Then
                query += " AND s.numero = " + n_s
            Else
                query += " s.numero = " + n_s
                entry2 += 1
            End If
        End If

        If type <> "" Then
            If entry2 > 0 Then
                query += " AND s.tipo = '" + type + "'"
            Else
                query += " s.tipo = '" + type + "'"
                entry2 += 1
            End If
        End If

        If beg_date <> "" Then
            If entry2 > 0 Then
                query += " AND s.data_inicio = '" + beg_date + "'"
            Else
                query += "s.data_inicio = '" + beg_date + "'"
                entry2 += 1
            End If
        End If

        If end_date <> "" Then
            If entry2 > 0 Then
                query += " AND s.data_fim = '" + end_date + "'"
            Else
                query += "s.data_fim = '" + end_date + "'"
                entry2 += 1
            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If nome <> "" Then
            If entry2 > 0 Then
                query += " AND p.primeiro_nome = '" + nome + "'"
            Else
                query += "p.primeiro_nome = '" + nome + "'"
                entry2 += 1
            End If
        End If

        If ln <> "" Then
            If entry2 > 0 Then
                query += " AND p.ultimo_nome = '" + ln + "'"
            Else
                query += "p.ultimo_nome = '" + ln + "'"
                entry2 += 1
            End If
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
            query = "SELECT numero, primeiro_nome, ultimo_nome FROM (ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.socio AS s ON p.NIF = s.NIF)"

        Else
            If entry2 = 0 Then
                query += " p.NIF = s.NIF"
            Else
                query += " AND p.NIF = s.NIF"
            End If
        End If

        ListBox1.Items.Clear()
        GetTableContent()
    End Sub

    Private Sub bttnUpdate_Click(sender As Object, e As EventArgs) Handles bttnUpdate.Click
        If ListBox1.Items.Count = 0 Or current < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If

        query = "ClubeDesportivo.UpdateSocio"

        UnlockControls()
        nif_tb.ReadOnly = True
        numero_tb.ReadOnly = True
        HideButtons()
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        ClearFields()
        UnlockControls()
        HideButtons()
        numero_tb.ReadOnly = True
        query = ""
        query = "ClubeDesportivo.CreateSocio"
    End Sub

    Private Sub bttnDelete_Click(sender As Object, e As EventArgs) Handles bttnDelete.Click
        If ListBox1.Items.Count = 0 Or current < 0 Then
            MsgBox("ERROR: Please Select entry to Delete!")
            Exit Sub
        End If

        query = "ClubeDesportivo.DeleteSocio"

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

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click
        Dim nif As String
        Dim nome As String
        Dim ln As String
        Dim n_s As String
        Dim result As String
        Dim db As String
        Dim msd As String
        Dim med As String
        Dim type As String
        Dim address As String

        nif = nif_tb.Text
        nome = primeiro_nome_tb.Text
        ln = last_name_tb.Text
        db = data_nasc_tb.Text
        n_s = numero_tb.Text
        msd = data_inicio_tb.Text
        med = data_fim_tb.Text
        address = morada_tb.Text
        ''type = tipo_tb.Text
        type = tipo_cb.SelectedItem

        If (numero_tb.Text.Equals("")) Then
            n_s = 0
        Else
            n_s = numero_tb.Text
        End If

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@NIF", SqlDbType.Int).Value = nif
            CMD2.Parameters.Add("@pnome", SqlDbType.VarChar).Value = nome
            CMD2.Parameters.Add("@lnome", SqlDbType.VarChar).Value = ln
            CMD2.Parameters.Add("@numero", SqlDbType.Int).Value = n_s
            CMD2.Parameters.Add("@db", SqlDbType.Date).Value = db
            CMD2.Parameters.Add("@msd", SqlDbType.Date).Value = msd
            CMD2.Parameters.Add("@med", SqlDbType.Date).Value = med
            CMD2.Parameters.Add("@address", SqlDbType.VarChar).Value = address
            CMD2.Parameters.Add("@type", SqlDbType.VarChar).Value = type

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            result = ReturnValue.Value

            If result = 1 Then
                MsgBox("ERROR: There is already a Member with the Member ID " + n_s.ToString() + "!")
            ElseIf result = 100 Then
                MsgBox("ERROR: There is no Member with the Member ID " + n_s.ToString() + "!")
            ElseIf result = 10 Then
                If nome <> "" And ln <> "" Then
                    MsgBox("ERROR: There is no Person with the code " + nif.ToString() + "!")
                Else
                    MsgBox("ERROR: Invalid name!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT numero, primeiro_nome, ultimo_nome FROM ClubeDesportivo.pessoa AS p JOIN ClubeDesportivo.socio AS s ON p.NIF = s.NIF"
        ClearFields()
        ListBox1.Items.Clear()
        GetTableContent()
        ShowButtons()
        UnlockControls()
        current = -1
    End Sub
End Class