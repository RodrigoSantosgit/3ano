Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Public Class Clube
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim Clube As Integer = -1
    Dim query As String
    Dim locked As Integer = 0

    Private Sub Equipas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT * FROM ClubeDesportivo.clube_desportivo"
        GetTableContent()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            Clube = ListBox1.SelectedIndex
            If ListBox1.Items.Count = 0 Or Clube < 0 Then Exit Sub
            Dim id = Split(ListBox1.Items.Item(Clube), " ")(0).ToString()
            query = "SELECT * FROM ClubeDesportivo.clube_desportivo"

            ClearFields()
            ShowClube()
            LockControls()
        End If
    End Sub

    Private Sub ShowClube()
        If ListBox1.Items.Count = 0 Or Clube < 0 Then Exit Sub
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            txtName.Text = Convert.ToString(reader.Item("nome"))
            txtSite.Text = Convert.ToString(reader.Item("web_site"))
            txtClube.Text = Convert.ToString(reader.Item("sede"))
            txtNIF.Text = Convert.ToString(reader.Item("NIF"))
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
            str += " - " + Convert.ToString(reader.Item("nome"))
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
        txtNIF.ReadOnly = True
        txtSite.ReadOnly = True
        txtClube.ReadOnly = True
        locked = 1
    End Sub

    Sub ClearFields()
        txtName.Text = ""
        txtNIF.Text = ""
        txtSite.Text = ""
        txtClube.Text = ""
    End Sub

    Sub UnlockControls()
        txtNIF.ReadOnly = True
        txtName.ReadOnly = False
        txtSite.ReadOnly = False
        txtClube.ReadOnly = False
        locked = 0
    End Sub

    Sub ShowButtons()
        bttnSearch.Visible = True
        bttnUpdate.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Sub HideButtons()
        bttnSearch.Visible = False
        bttnUpdate.Visible = False
        bttnOK.Visible = True
        bttnCancel.Visible = True
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
        If ListBox1.Items.Count = 0 Or Clube < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If

        query = "ClubeDesportivo.UpdateClube"

        UnlockControls()
        txtNIF.ReadOnly = True
        HideButtons()
    End Sub

    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        ShowButtons()
        ClearFields()
        UnlockControls()
        ListBox1.ClearSelected()
        Clube = -1
        query = ""
    End Sub

    Private Sub bttnDelete_Click(sender As Object, e As EventArgs)
        ClearFields()
        UnlockControls()
        HideButtons()
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs)
        ClearFields()
        UnlockControls()
        HideButtons()
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click
        Dim nif As Integer
        Dim nome As String
        Dim web_site As String
        Dim sede As String
        Dim result As Integer

        nif = txtNIF.Text
        nome = txtName.Text
        sede = txtClube.Text
        web_site = txtSite.Text

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@NIF", SqlDbType.Int).Value = nif
            CMD2.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome
            CMD2.Parameters.Add("@sede", SqlDbType.VarChar).Value = sede
            CMD2.Parameters.Add("@web_site", SqlDbType.VarChar).Value = web_site

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            result = ReturnValue.Value

            If result = 100 Then
                MsgBox("ERROR: There is no Clube Desportivo with the NIF " + nif.ToString() + "!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT * FROM ClubeDesportivo.clube_desportivo "
        ClearFields()
        ListBox1.Items.Clear()
        GetTableContent()
        ShowButtons()
        UnlockControls()
        Clube = -1
    End Sub

    Private Sub bttnSearch_Click(sender As Object, e As EventArgs) Handles bttnSearch.Click
        If locked = 1 Then
            UnlockControls()
            ClearFields()
            Exit Sub
        End If
        query = "SELECT * FROM ClubeDesportivo.clube_desportivo"

        ListBox1.Items.Clear()
        GetTableContent()

    End Sub
End Class