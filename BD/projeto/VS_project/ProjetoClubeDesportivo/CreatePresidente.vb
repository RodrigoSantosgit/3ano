Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class CreatePresidente
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim query As String
    Dim n_p As Integer = 0
    Private Sub CreatePresidentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()
    End Sub
    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        Presidentes.Show()
        Me.Close()
        CN.Close()
    End Sub

    Private Sub TestDBConnection()
        Try
            CN.Open()
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR" +
                                vbCrLf + ex.Message, MsgBoxStyle.Critical, "Connection Test")
        End Try
    End Sub

    Private Sub bttnOK_Click(sender As Object, e As EventArgs) Handles bttnOK.Click
        Dim sd As String
        Dim n_s As Integer = 0
        Dim salary As String
        Dim ed As String
        Dim psd As String
        Dim ped As String
        Dim nif As String
        Dim pn As String = ""
        Dim ln As String = ""
        Dim bd As String = "1/1/1990"
        Dim add As String = ""

        Dim Result As Integer

        sd = MSD.Text
        salary = txtSalario.Text
        ed = txtMED.Text
        psd = txtSD.Text
        ped = txtED.Text
        nif = txtNIF.Text
        If n_p = 0 Then
            n_s = txtSocio.Text
        End If
        If n_p = 1 Then
            pn = txtName.Text
            ln = txtLN.Text
            bd = txtBD.Text
            add = txtAddress.Text
        End If

        query = "ClubeDesportivo.CreatePresidente"

        Try
            Dim CMD2 = New SqlCommand(query, CN)
            CMD2.CommandType = CommandType.StoredProcedure

            CMD2.Parameters.Add("@m_id", SqlDbType.Int).Value = n_s
            CMD2.Parameters.Add("@nif", SqlDbType.Int).Value = nif
            CMD2.Parameters.Add("@med", SqlDbType.Date).Value = ed
            CMD2.Parameters.Add("@msd", SqlDbType.Date).Value = sd
            CMD2.Parameters.Add("@psd", SqlDbType.Date).Value = psd
            CMD2.Parameters.Add("@ped", SqlDbType.Date).Value = ped
            CMD2.Parameters.Add("@address", SqlDbType.VarChar).Value = add
            CMD2.Parameters.Add("@pn", SqlDbType.VarChar).Value = pn
            CMD2.Parameters.Add("@ln", SqlDbType.VarChar).Value = ln
            CMD2.Parameters.Add("@sal", SqlDbType.Decimal).Value = salary
            CMD2.Parameters.Add("@bd", SqlDbType.Date).Value = bd
            CMD2.Parameters.Add("@type", SqlDbType.VarChar).Value = "efetivo"

            Dim ReturnValue As New SqlParameter("@res", SqlDbType.Int)
            ReturnValue.Direction = ParameterDirection.Output
            CMD2.Parameters.Add(ReturnValue)

            CMD2.ExecuteNonQuery()
            Result = ReturnValue.Value

            If Result = 10 Then
                MsgBox("ERROR: Unexpected Error!")
            ElseIf Result = 1 Then
                MsgBox("ERROR: There is no President with the member ID " + n_s.ToString() + "!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ClearFields()
    End Sub

    Sub ClearFields()
        txtName.Text = ""
        txtSocio.Text = ""
        txtSD.Text = ""
        txtED.Text = ""
        txtSalario.Text = ""
        txtNIF.Text = ""
        txtAddress.Text = ""
        txtBD.Text = ""
        txtLN.Text = ""
        txtMED.Text = ""
        MSD.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtName.Visible = True
        txtLN.Visible = True
        txtAddress.Visible = True
        txtBD.Visible = True

        Nome.Visible = True
        LN.Visible = True
        BD.Visible = True
        Address.Visible = True
        txtSocio.ReadOnly = True

        Button1.Visible = False

        n_p = 1

    End Sub
End Class