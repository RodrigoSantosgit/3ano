Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Form1

    Dim CN As SqlConnection
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''CN = New SqlConnection("data source=RUISANTOS8DF3;integrated security=true;initial catalog=ClubeDesportivo;uid = RUISANTOS8DF3\Utilizador;")
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
    End Sub
    Private Sub TestDBConnection()
        Try
            CN.Open()
            If CN.State = ConnectionState.Open Then
                MsgBox("Successful connection to database " + CN.Database + " on the " +
                       CN.DataSource + " server", MsgBoxStyle.OkOnly, "Connection Test")
            End If
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR" +
                                vbCrLf + ex.Message, MsgBoxStyle.Critical, "Connection Test")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bttnTestConnect.Click
        TestDBConnection()
    End Sub

    Private Sub Jogadores_Click(sender As Object, e As EventArgs) Handles bttnJogadores.Click
        Jogadores.Show()
        Me.Hide()
        CN.Close()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles bttnExit.Click
        CN.Close()
        Me.Close()
    End Sub

    Private Sub Patrocinadores_Click(sender As Object, e As EventArgs) Handles bttnPatrocinadores.Click
        Patrocinadores.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub Modalidades_Click(sender As Object, e As EventArgs) Handles bttnModalidades.Click
        Modalidades.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub bttnPresidentes_Click(sender As Object, e As EventArgs) Handles bttnPresidentes.Click
        Presidentes.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub bttnSocio_Click(sender As Object, e As EventArgs) Handles bttnSocio.Click
        Socios.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub bttnEquipas_Click(sender As Object, e As EventArgs) Handles bttnEquipas.Click
        Equipas.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub bttnTreinadores_Click(sender As Object, e As EventArgs) Handles bttnTreinadores.Click
        treinadores_form.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub bttnMedicos_Click(sender As Object, e As EventArgs) Handles bttnMedicos.Click
        Medicos.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub bttnClube_Click(sender As Object, e As EventArgs) Handles bttnClube.Click
        Clube.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub bttnBudget_Click(sender As Object, e As EventArgs) Handles bttnBudget.Click
        Budget.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Jogos.Show()
        Me.Hide()
        CN.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Treinos.Show()
        Me.Hide()
        CN.Close()
    End Sub
End Class
