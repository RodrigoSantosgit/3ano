Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Public Class Jogadores
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim Jogador As Integer = -1
    Dim query As String
    Dim locked As Integer = 0

    Private Sub Jogadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT numero, primeiro_nome, ultimo_nome 
                     FROM (ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.jogador AS j ON s.numero = j.num_socio) ON p.NIF = s.NIF)"
        GetTableContent()
    End Sub
    Private Sub TestDBConnection()
        Try
            CN.Open()
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
            str += " - " + Convert.ToString(reader.Item("primeiro_nome")) + " " + Convert.ToString(reader.Item("ultimo_nome"))
            str += vbCrLf
            ListBox1.Items.Add(str)
        End While
        reader.Close()
        Return str
    End Function

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

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            Jogador = ListBox1.SelectedIndex
            Dim ns = Split(ListBox1.Items.Item(Jogador), " ")(0).ToString()
            query = "SELECT primeiro_nome, ultimo_nome, morada, data_nasc, tipo, s.data_inicio, s.data_fim, j.salario, j.equipa, numero, p.NIF 
                     FROM (ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.jogador AS j ON s.numero = " + ns + " AND j.num_socio = " + ns + ") ON p.NIF = s.NIF)"
            ShowPlayer()
            LockControls()
        End If
    End Sub

    Private Sub ShowPlayer()
        If ListBox1.Items.Count = 0 Or Jogador < 0 Then Exit Sub
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            txtName.Text = Convert.ToString(reader.Item("primeiro_nome"))
            txtLastName.Text = Convert.ToString(reader.Item("ultimo_nome"))
            txtNIF.Text = Convert.ToString(reader.Item("NIF"))
            txtAddress.Text = Convert.ToString(reader.Item("morada"))
            txtBirth.Text = Split(Convert.ToString(reader.Item("data_nasc")), " ")(0).ToString()
            txtSalario.Text = Convert.ToString(reader.Item("salario"))
            txtEquipa.Text = Convert.ToString(reader.Item("equipa"))
            txtSocio.Text = Convert.ToString(reader.Item("numero"))
            tipo_tb.Text = Convert.ToString(reader.Item("tipo"))
            data_inicio_tb.Text = Convert.ToString(reader.Item("data_inicio"))
            data_fim_tb.Text = Convert.ToString(reader.Item("data_fim"))
        End While
        reader.Close()
    End Sub

    Sub LockControls()
        txtAddress.ReadOnly = True
        txtName.ReadOnly = True
        txtNIF.ReadOnly = True
        txtSalario.ReadOnly = True
        txtSocio.ReadOnly = True
        txtEquipa.ReadOnly = True
        txtBirth.ReadOnly = True
        txtLastName.ReadOnly = True
        tipo_tb.ReadOnly = True
        data_inicio_tb.ReadOnly = True
        data_fim_tb.ReadOnly = True
        locked = 1
    End Sub

    Sub ClearFields()
        txtName.Text = ""
        txtNIF.Text = ""
        txtAddress.Text = ""
        txtSalario.Text = ""
        txtSocio.Text = ""
        txtEquipa.Text = ""
        txtBirth.Text = ""
        txtLastName.Text = ""
        tipo_tb.Text = ""
        data_inicio_tb.Text = ""
        data_fim_tb.Text = ""
    End Sub

    Sub UnlockControls()
        txtAddress.ReadOnly = False
        txtName.ReadOnly = False
        txtNIF.ReadOnly = False
        txtSalario.ReadOnly = False
        txtSocio.ReadOnly = False
        txtEquipa.ReadOnly = False
        txtBirth.ReadOnly = False
        txtLastName.ReadOnly = False
        tipo_tb.ReadOnly = False
        data_inicio_tb.ReadOnly = False
        data_fim_tb.ReadOnly = False
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
        If ListBox1.Items.Count = 0 Or Jogador < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If
        query = "ClubeDesportivo.UpdateJogador"

        UnlockControls()
        LockControls()
        locked = 0
        txtSalario.ReadOnly = False
        txtEquipa.ReadOnly = False
        HideButtons()
    End Sub

    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        ShowButtons()
        ClearFields()
        UnlockControls()
        ListBox1.ClearSelected()
        Jogador = -1
        query = ""
    End Sub

    Private Sub bttnDelete_Click(sender As Object, e As EventArgs) Handles bttnDelete.Click
        If ListBox1.Items.Count = 0 Or Jogador < 0 Then
            MsgBox("ERROR: Please Select entry to Delete!")
            Exit Sub
        End If

        query = "ClubeDesportivo.DeleteJogador"

        HideButtons()
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        ClearFields()
        UnlockControls()
        tipo_tb.ReadOnly = True
        txtSocio.ReadOnly = True
        HideButtons()
        query = ""
        query = "ClubeDesportivo.CreateJogador"
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click

        Dim nome As String
        Dim ultimo_nome As String
        Dim address As String
        Dim NIF As Integer
        Dim birth As Date
        Dim n_s As Integer
        Dim salary As Integer
        Dim team As Integer
        Dim result As Integer
        Dim beg_date As Date
        Dim end_date As Date

        nome = txtName.Text
        ultimo_nome = txtLastName.Text
        NIF = txtNIF.Text
        address = txtAddress.Text
        birth = txtBirth.Text
        n_s = txtSocio.Text
        salary = txtSalario.Text
        team = txtEquipa.Text
        beg_date = data_inicio_tb.Text
        end_date = data_fim_tb.Text

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@m_id", SqlDbType.Int).Value = n_s
            CMD2.Parameters.Add("@nif", SqlDbType.Int).Value = NIF
            CMD2.Parameters.Add("@med", SqlDbType.Date).Value = end_date
            CMD2.Parameters.Add("@msd", SqlDbType.Date).Value = beg_date
            CMD2.Parameters.Add("@address", SqlDbType.VarChar).Value = address
            CMD2.Parameters.Add("@pn", SqlDbType.VarChar).Value = nome
            CMD2.Parameters.Add("@ln", SqlDbType.VarChar).Value = ultimo_nome
            CMD2.Parameters.Add("@equipa", SqlDbType.Int).Value = team
            CMD2.Parameters.Add("@sal", SqlDbType.Decimal).Value = salary
            CMD2.Parameters.Add("@bd", SqlDbType.Date).Value = birth

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            Result = ReturnValue.Value

            If Result = 1 Then
                MsgBox("ERROR: There is already a Player with the member ID " + n_s.ToString() + "!")
            ElseIf Result = 100 Then
                MsgBox("ERROR: There is no Player with the member ID " + n_s.ToString() + "!")
            ElseIf Result = 10 Then
                If salary <> "" Then
                    MsgBox("ERROR: There is no Player with the member ID " + n_s.ToString() + "!")
                Else
                    MsgBox("ERROR: Invalid salary!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT numero, primeiro_nome, ultimo_nome 
                     FROM (ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.jogador AS j ON s.numero = j.num_socio) ON p.NIF = s.NIF)"
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
        query = "SELECT * FROM ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.jogador AS j JOIN ClubeDesportivo.socio AS s ON "

        Dim nome As String
        Dim address As String
        Dim NIF As String
        Dim birth As String
        Dim n_s As String
        Dim salary As String
        Dim team As String
        Dim beg_date As String
        Dim end_date As String
        Dim entry As Integer
        Dim entry2 As Integer

        nome = txtName.Text
        NIF = txtNIF.Text
        address = txtAddress.Text
        birth = txtBirth.Text
        n_s = txtSocio.Text
        salary = txtSalario.Text
        team = txtEquipa.Text
        beg_date = data_inicio_tb.Text
        end_date = data_fim_tb.Text
        entry2 = 0
        entry = 0

        If team <> "" Then
            query += "j.equipa = " + team
            entry += 1
        End If

        If n_s <> "" Then
            If entry > 0 Then
                query += " AND j.num_socio = " + n_s + " AND s.numero = " + n_s
            Else
                query += "j.num_socio = " + n_s + " AND s.numero = " + n_s
                entry += 1
            End If
        End If

        If beg_date <> "" Then
            If entry > 0 Then
                query += " AND s.data_inicio = '" + beg_date + "'"
            Else
                query += "s.data_inicio = '" + beg_date + "'"
                entry += 1
            End If
        End If

        If end_date <> "" Then
            If entry > 0 Then
                query += " AND s.data_fim = '" + end_date + "'"
            Else
                query += "s.data_fim = '" + end_date + "'"
                entry += 1
            End If
        End If

        If entry = 0 Then
            query += "j.num_socio = s.numero) ON "
        Else
            query += " AND j.num_socio = s.numero) ON "
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If nome <> "" Then
            query += "p.primeiro_nome = '" + nome + "'"
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
            query = "SELECT * FROM ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.jogador AS j JOIN ClubeDesportivo.socio AS s ON j.num_socio = s.numero) ON p.NIF = s.NIF"
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

    Private Sub data_inicio_label_Click(sender As Object, e As EventArgs) Handles data_inicio_label.Click

    End Sub
End Class