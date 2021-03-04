Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Public Class Patrocinadores

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim Patrocinador As Integer = -1
    Dim query As String
    Dim locked As Integer = 0

    Private Sub Patrocinadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
        query = "SELECT p.nome as pnome, p.NIF, c.nome as clube, cond_patrocinio FROM ClubeDesportivo.patrocionador AS p JOIN ClubeDesportivo.clube_desportivo AS c ON p.clube = c.NIF"
        GetTableContent()
        txtSpLvl.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub TestDBConnection()
        Try
            CN.Open()
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR" +
                                vbCrLf + ex.Message, MsgBoxStyle.Critical, "Connection Test")
        End Try
    End Sub

    Private Sub GetTableContent()
        If CN.State = ConnectionState.Closed Then Exit Sub
        Dim str As String = ""
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            str = ""
            str += Convert.ToString(reader.Item("pnome"))
            ListBox1.Items.Add(str)
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

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            Patrocinador = ListBox1.SelectedIndex
            If ListBox1.Items.Count = 0 Or Patrocinador < 0 Then Exit Sub
            Dim nome = ListBox1.Items.Item(Patrocinador).ToString()
            query = "SELECT p.nome as pnome, p.NIF, c.nome as clube, cond_patrocinio FROM ClubeDesportivo.patrocionador AS p JOIN ClubeDesportivo.clube_desportivo AS c ON p.clube = c.NIF AND p.nome = '" + nome + "';"
            ShowPatrocinador()
            LockControls()
        End If
    End Sub

    Private Sub ShowPatrocinador()
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            txtName.Text = Convert.ToString(reader.Item("pnome"))
            txtNIF.Text = Convert.ToString(reader.Item("NIF"))
            txtSC.Text = Convert.ToString(reader.Item("clube"))
            txtSpLvl.Text = Convert.ToString(reader.Item("cond_patrocinio"))
            If txtSpLvl.Text = "3" Then
                txtSpCond.Text = ""
                txtSpCond.Text = "Nome e Logótipo no equipamento"
                txtSpCond.Text += vbCrLf
                txtSpCond.Text += "Nome e Logótipo em vídeos promocionais"
                txtSpCond.Text += vbCrLf
                txtSpCond.Text += "Nome e Logótipo em paineis de publicidade"
            ElseIf txtSpLvl.Text = "2" Then
                txtSpCond.Text = ""
                txtSpCond.Text += "Nome e Logótipo em vídeos promocionais"
                txtSpCond.Text += vbCrLf
                txtSpCond.Text += "Nome e Logótipo em paineis de publicidade"
            ElseIf txtSpLvl.Text = "1" Then
                txtSpCond.Text = ""
                txtSpCond.Text += "Nome e Logótipo em paineis de publicidade"
            Else
                txtSpLvl.Text = "TBD"
            End If
        End While
        reader.Close()
    End Sub

    Sub LockControls()
        txtSC.ReadOnly = True
        txtName.ReadOnly = True
        txtNIF.ReadOnly = True
        ''txtSpLvl.ReadOnly = True
        txtSpCond.ReadOnly = True
        locked = 1
    End Sub

    Sub ClearFields()
        txtName.Text = ""
        txtNIF.Text = ""
        txtSpLvl.Text = ""
        txtSpCond.Text = ""
    End Sub

    Sub UnlockControls()
        txtName.ReadOnly = False
        txtNIF.ReadOnly = False
        ''txtSpLvl.ReadOnly = False
        txtSpCond.ReadOnly = False
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
        query = "SELECT p.nome as pnome, p.NIF, c.nome as clube, cond_patrocinio FROM ClubeDesportivo.patrocionador AS p JOIN ClubeDesportivo.clube_desportivo AS c ON p.clube = c.NIF AND "

        Dim nome As String
        Dim NIF As String
        Dim SpLvl As String
        Dim entry As Integer

        nome = txtName.Text
        NIF = txtNIF.Text
        SpLvl = txtSpLvl.Text
        entry = 0

        If nome <> "" Then
            query += "p.nome = '" + nome + "'"
            entry += 1
        End If

        If NIF <> "" Then
            If entry > 0 Then
                query += "AND p.NIF = " + NIF
            Else
                query += "p.NIF = " + NIF
                entry += 1
            End If
        End If

        If SpLvl <> "" Then
            If entry > 0 Then
                query += "AND p.cond_patrocinio = " + SpLvl
            Else
                query += "p.cond_patrocinio = " + SpLvl
                entry += 1
            End If
        End If

        If entry > 0 Then
            query += ";"
        Else
            query = "SELECT p.nome as pnome, p.NIF, c.nome as clube, cond_patrocinio FROM ClubeDesportivo.patrocionador AS p JOIN ClubeDesportivo.clube_desportivo AS c ON p.clube = c.NIF"
        End If

        ListBox1.Items.Clear()
        GetTableContent()
        Patrocinador = -1
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click
        Dim nif As Integer
        Dim nome As String
        Dim clube As Integer = 999
        Dim result As Integer
        Dim sp As String

        nif = txtNIF.Text
        nome = txtName.Text
        sp = txtSpLvl.Text

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@NIF", SqlDbType.Int).Value = nif
            CMD2.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome
            CMD2.Parameters.Add("@clube", SqlDbType.Int).Value = clube
            CMD2.Parameters.Add("@spLvl", SqlDbType.Int).Value = sp

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            result = ReturnValue.Value

            If result = 1 Then
                MsgBox("ERROR: There is already a Sponsor with the code " + nif.ToString() + "!")
            ElseIf result = 100 Then
                MsgBox("ERROR: There is no Sponsor with the code " + nif.ToString() + "!")
            ElseIf result = 10 Then
                If nome <> "" Then
                    MsgBox("ERROR: There is no Sponsor with the code " + nif.ToString() + "!")
                Else
                    MsgBox("ERROR: Invalid name!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        query = "SELECT p.nome as pnome, p.NIF, c.nome as clube, cond_patrocinio FROM ClubeDesportivo.patrocionador AS p JOIN ClubeDesportivo.clube_desportivo AS c ON p.clube = c.NIF"
        ClearFields()
        ListBox1.Items.Clear()
        GetTableContent()
        ShowButtons()
        UnlockControls()
        Patrocinador = -1
    End Sub

    Private Sub bttnCreate_Click(sender As Object, e As EventArgs) Handles bttnCreate.Click
        ClearFields()
        UnlockControls()
        HideButtons()
        txtSC.ReadOnly = True
        txtSpCond.ReadOnly = True
        query = ""
        query = "ClubeDesportivo.CreatePatrocinador"
    End Sub

    Private Sub bttnDelete_Click(sender As Object, e As EventArgs) Handles bttnDelete.Click
        If ListBox1.Items.Count = 0 Or Patrocinador < 0 Then
            MsgBox("ERROR: Please Select entry to Delete!")
            Exit Sub
        End If

        query = "ClubeDesportivo.DeletePatrocinador"

        HideButtons()
    End Sub

    Private Sub bttnUpdate_Click(sender As Object, e As EventArgs) Handles bttnUpdate.Click
        If ListBox1.Items.Count = 0 Or Patrocinador < 0 Then
            MsgBox("ERROR: Please Select entry to Update!")
            Exit Sub
        End If

        query = "ClubeDesportivo.UpdatePatrocinador"

        UnlockControls()
        txtNIF.ReadOnly = True
        txtSC.ReadOnly = True
        HideButtons()
    End Sub

    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        ShowButtons()
        ClearFields()
        UnlockControls()
        ListBox1.ClearSelected()
        Patrocinador = -1
        query = ""
    End Sub

End Class