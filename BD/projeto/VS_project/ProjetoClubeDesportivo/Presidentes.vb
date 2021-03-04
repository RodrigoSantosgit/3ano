Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Public Class Presidentes
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim CMD2 As SqlCommand
    Dim Presidente As Integer = -1
    Dim query As String
    Dim locked As Integer = 0

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
        If ListBox1.Items.Count = 0 Or Presidente < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If

        UnlockControls()
        txtNIF.ReadOnly = True
        txtSocio.ReadOnly = True
        txtName.ReadOnly = True
        txtAddress.ReadOnly = True
        HideButtons()
    End Sub

    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        ShowButtons()
        ClearFields()
        UnlockControls()
        ListBox1.ClearSelected()
        Presidente = -1
        query = ""
    End Sub

    Private Sub bttnDelete_Click(sender As Object, e As EventArgs) Handles bttnDelete.Click
        If ListBox1.Items.Count = 0 Or Presidente < 0 Then
            MsgBox("ERROR: Please Select entry to Delete!")
            Exit Sub
        End If

        Dim n_s As Integer
        Dim NIF As Integer
        Dim Result As Integer

        n_s = txtSocio.Text
        NIF = txtNIF.Text

        query = "ClubeDesportivo.DeletePresidente"

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@id", SqlDbType.Int).Value = n_s
            CMD2.Parameters.Add("@nif", SqlDbType.Int).Value = NIF

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            Result = ReturnValue.Value

            If Result = 1 Then
                MsgBox("ERROR: There is already a Member with the code " + n_s.ToString() + "!")
            ElseIf Result = 100 Then
                MsgBox("ERROR: There is no President with the member ID " + n_s.ToString() + "!")
            ElseIf Result = 10 Then
                MsgBox("ERROR: There is already a Person with the code " + NIF.ToString() + "!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        query = "SELECT * FROM ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.presidente AS pr ON s.numero = pr.num_socio) ON p.NIF = s.NIF"
        ClearFields()
        ListBox1.Items.Clear()
        GetTableContent()
        ShowButtons()
        UnlockControls()
        Presidente = -1
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        CreatePresidente.Show()
        Me.Close()
        CN.Close()
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click

        Try

            Dim sd As String
            Dim n_s As String
            Dim salary As String
            Dim ed As String

            sd = txtSD.Text
            n_s = txtSocio.Text
            salary = txtSalario.Text
            ed = txtED.Text

            If ed = "" Then
                query = "UPDATE ClubeDesportivo.presidente 
                SET data_inicio_pres = @sd, date_fim_pres = null, salario = @salary" +
                " WHERE num_socio = " + n_s

                CMD2 = CN.CreateCommand()
                CMD2.CommandText = query
                CMD2.Parameters.Add("@sd", SqlDbType.Date).Value = sd
                CMD2.Parameters.Add("@salary", SqlDbType.Decimal).Value = salary

            Else
                query = "UPDATE ClubeDesportivo.presidente 
                SET data_inicio_pres = @sd, date_fim_pres = @ed, salario = @salary" +
                " WHERE num_socio = " + n_s

                CMD2 = CN.CreateCommand()
                CMD2.CommandText = query
                CMD2.Parameters.Add("@sd", SqlDbType.Date).Value = sd
                CMD2.Parameters.Add("@ed", SqlDbType.Date).Value = ed
                CMD2.Parameters.Add("@salary", SqlDbType.Decimal).Value = salary
            End If

            Dim reader As SqlDataReader
            reader = CMD2.ExecuteReader
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT * FROM ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.presidente AS pr ON s.numero = pr.num_socio) ON p.NIF = s.NIF"
        ClearFields()
        ListBox1.Items.Clear()
        GetTableContent()
        ShowButtons()
        UnlockControls()
        Presidente = -1
    End Sub

    Private Sub bttnSearch_Click(sender As Object, e As EventArgs) Handles bttnSearch.Click
        If locked = 1 Then
            UnlockControls()
            ClearFields()
            Exit Sub
        End If
        query = ""
        query = "SELECT * FROM ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.presidente AS pr JOIN ClubeDesportivo.socio AS s ON "

        Dim nome As String
        Dim address As String
        Dim NIF As String
        Dim sd As String
        Dim n_s As String
        Dim salary As String
        Dim ed As String
        Dim entry As Integer
        Dim entry2 As Integer

        nome = txtName.Text
        NIF = txtNIF.Text
        address = txtAddress.Text
        sd = txtSD.Text
        n_s = txtSocio.Text
        salary = txtSalario.Text
        ed = txtED.Text
        entry2 = 0
        entry = 0

        If ed = "null" Then
            query += "pr.date_fim_pres IS NULL"
            entry += 1
        Else
            If ed <> "" Then
                query += "pr.date_fim_pres = " + ed
                entry += 1
            End If
        End If

        If sd <> "" Then
            If entry > 0 Then
                query += " AND pr.data_inicio_pres = '" + sd + "'"
            Else
                query += "pr.data_inicio_pres = '" + sd + "'"
                entry += 1
            End If
        End If

        If n_s <> "" Then
            If entry > 0 Then
                query += "AND pr.num_socio = " + n_s + " AND s.numero = " + n_s
            Else
                query += "pr.num_socio = " + n_s + " AND s.numero = " + n_s
                entry += 1
            End If
        End If

        If entry = 0 Then
            query += "pr.num_socio = s.numero) ON "
        Else
            query += " AND pr.num_socio = s.numero) ON "
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

        If entry2 = 0 And entry = 0 Then
            query = "SELECT * FROM ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.presidente AS pr JOIN ClubeDesportivo.socio AS s ON pr.num_socio = s.numero) ON p.NIF = s.NIF"
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

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            Presidente = ListBox1.SelectedIndex
            If ListBox1.Items.Count = 0 Or Presidente < 0 Then Exit Sub
            Dim ns = Split(ListBox1.Items.Item(Presidente), " ")(0).ToString()
            query = "SELECT *
                     FROM (ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.presidente AS pr ON s.numero = " + ns + " AND pr.num_socio = " + ns + ") ON p.NIF = s.NIF)"

            ShowPresidente()
            LockControls()
        End If
    End Sub

    Private Sub ShowPresidente()
        If ListBox1.Items.Count = 0 Or Presidente < 0 Then Exit Sub
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            txtName.Text = Convert.ToString(reader.Item("primeiro_nome")) + " " + Convert.ToString(reader.Item("ultimo_nome"))
            txtNIF.Text = Convert.ToString(reader.Item("NIF"))
            txtAddress.Text = Convert.ToString(reader.Item("morada"))
            txtSD.Text = Split(Convert.ToString(reader.Item("data_inicio_pres")), " ")(0).ToString()
            txtSalario.Text = Convert.ToString(reader.Item("salario"))
            If Convert.ToString(reader.Item("date_fim_pres")) = "null" Then
                txtED.Text = "null"
            Else
                txtED.Text = Split(Convert.ToString(reader.Item("date_fim_pres")), " ")(0).ToString()
            End If
            txtSocio.Text = Convert.ToString(reader.Item("numero"))
        End While
        reader.Close()
    End Sub

    Private Sub Presidentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT * FROM ClubeDesportivo.pessoa AS p JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.presidente AS pr ON s.numero = pr.num_socio) ON p.NIF = s.NIF"
        GetTableContent()
    End Sub

    Private Sub GetTableContent()
        If CN.State = ConnectionState.Closed Then Exit Sub
        Dim str As String = ""
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            str = ""
            str += Convert.ToString(reader.Item("numero"))
            str += " - " + Convert.ToString(reader.Item("primeiro_nome")) + " " + Convert.ToString(reader.Item("ultimo_nome"))
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
        txtSocio.ReadOnly = True
        txtSD.ReadOnly = True
        txtED.ReadOnly = True
        txtSalario.ReadOnly = True
        txtNIF.ReadOnly = True
        txtAddress.ReadOnly = True
        locked = 1
    End Sub

    Sub ClearFields()
        txtName.Text = ""
        txtSocio.Text = ""
        txtSD.Text = ""
        txtED.Text = ""
        txtSalario.Text = ""
        txtNIF.Text = ""
        txtAddress.Text = ""
    End Sub

    Sub UnlockControls()
        txtSocio.ReadOnly = False
        txtName.ReadOnly = False
        txtSD.ReadOnly = False
        txtED.ReadOnly = False
        txtSalario.ReadOnly = False
        txtNIF.ReadOnly = False
        txtAddress.ReadOnly = False
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

End Class