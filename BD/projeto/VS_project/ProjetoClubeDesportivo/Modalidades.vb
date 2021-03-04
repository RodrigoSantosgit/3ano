Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Public Class Modalidades

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim Modalidade As Integer = -1
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
        If ListBox1.Items.Count = 0 Or Modalidade < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If

        query = "ClubeDesportivo.UpdateModalidade"

        UnlockControls()
        txtCode.ReadOnly = True
        HideButtons()
    End Sub

    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        ShowButtons()
        ClearFields()
        UnlockControls()
        ListBox1.ClearSelected()
        Modalidade = -1
        query = ""
    End Sub

    Private Sub bttnDelete_Click(sender As Object, e As EventArgs) Handles bttnDelete.Click
        If ListBox1.Items.Count = 0 Or Modalidade < 0 Then
            MsgBox("ERROR: Please Select entry to Delete!")
            Exit Sub
        End If

        query = "ClubeDesportivo.DeleteModalidade"

        HideButtons()
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        ClearFields()
        UnlockControls()
        HideButtons()
        query = ""
        query = "ClubeDesportivo.CreateModalidade"
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click

        Dim code As Integer
        Dim nome As String
        Dim result As Integer

        code = txtCode.Text
        nome = txtName.Text

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@id", SqlDbType.Int).Value = code
            CMD2.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            result = ReturnValue.Value

            If result = 1 Then
                MsgBox("ERROR: There is already a Modality with the code " + code.ToString() + "!")
            ElseIf result = 100 Then
                MsgBox("ERROR: There is no Modality with the code " + code.ToString() + "!")
            ElseIf result = 10 Then
                If nome <> "" Then
                    MsgBox("ERROR: There is no Modality with the code " + code.ToString() + "!")
                Else
                    MsgBox("ERROR: Invalid name!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT * FROM ClubeDesportivo.modalidade"
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
        query = "SELECT * FROM ClubeDesportivo.modalidade AS m WHERE "

        Dim nome As String
        Dim code As String
        Dim entry As Integer

        nome = txtName.Text
        code = txtCode.Text

        entry = 0

        If nome <> "" Then
            query += "m.nome = '" + nome + "'"
            entry += 1
        End If

        If code <> "" Then
            If entry > 0 Then
                query += "AND m.codigo = " + code
            Else
                query += "m.codigo = " + code
                entry += 1
            End If
        End If

        If entry > 0 Then
            query += ";"
        Else
            query = "SELECT * FROM ClubeDesportivo.modalidade"
        End If

        ListBox1.Items.Clear()
        GetTableContent()

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            Modalidade = ListBox1.SelectedIndex
            If ListBox1.Items.Count = 0 Or Modalidade < 0 Then Exit Sub
            Dim nome = ListBox1.Items.Item(Modalidade).ToString()
            query = "SELECT * FROM ClubeDesportivo.modalidade AS m WHERE m.nome = '" + nome + "';"
            ShowModalidade()
            LockControls()
        End If
    End Sub

    Private Sub ShowModalidade()
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            txtName.Text = Convert.ToString(reader.Item("nome"))
            txtCode.Text = Convert.ToString(reader.Item("codigo"))
        End While
        reader.Close()
    End Sub

    Private Sub Modalidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT * FROM ClubeDesportivo.modalidade"
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
            str += Convert.ToString(reader.Item("nome"))
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
        txtCode.ReadOnly = True
        locked = 1
    End Sub

    Sub ClearFields()
        txtName.Text = ""
        txtCode.Text = ""
    End Sub

    Sub UnlockControls()
        txtCode.ReadOnly = False
        txtName.ReadOnly = False
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