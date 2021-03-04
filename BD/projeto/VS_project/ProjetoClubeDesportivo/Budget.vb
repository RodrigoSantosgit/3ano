Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Budget

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim query As String

    Private Sub Budget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101; initial catalog=p1g8; uid=p1g8; password=rodrigorui-99")
        TestDBConnection()

        TOTAL.Text = "0,00 €"
    End Sub

    Private Sub pr_CheckedChanged(sender As Object, e As EventArgs) Handles pr.CheckedChanged
        query = "SELECT ClubeDesportivo.MonthlySalaryBudget("
        CMD = New SqlCommand(query, CN)
        CMD.Parameters.Clear()

        If jgd.Checked Then
            query += "1,"
        Else
            query += "0,"
        End If

        If pr.Checked Then
            query += "1,"
        Else
            query += "0,"
        End If

        If tr.Checked Then
            query += "1)"
        Else
            query += "0)"
        End If

        GetContent()
    End Sub

    Private Sub tr_CheckedChanged(sender As Object, e As EventArgs) Handles tr.CheckedChanged
        query = "SELECT ClubeDesportivo.MonthlySalaryBudget("
        CMD = New SqlCommand(query, CN)
        CMD.Parameters.Clear()

        If jgd.Checked Then
            query += "1,"
        Else
            query += "0,"
        End If

        If pr.Checked Then
            query += "1,"
        Else
            query += "0,"
        End If

        If tr.Checked Then
            query += "1)"
        Else
            query += "0)"
        End If

        GetContent()
    End Sub

    Private Sub jgd_CheckedChanged(sender As Object, e As EventArgs) Handles jgd.CheckedChanged
        query = "SELECT ClubeDesportivo.MonthlySalaryBudget("
        CMD = New SqlCommand(query, CN)
        CMD.Parameters.Clear()

        If jgd.Checked Then
            query += "1,"
        Else
            query += "0,"
        End If

        If pr.Checked Then
            query += "1,"
        Else
            query += "0,"
        End If

        If tr.Checked Then
            query += "1)"
        Else
            query += "0)"
        End If

        GetContent()
    End Sub

    Private Sub TestDBConnection()
        Try
            CN.Open()
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR" +
                                vbCrLf + ex.Message, MsgBoxStyle.Critical, "Connection Test")
        End Try
    End Sub

    Private Sub GetContent()
        Dim t As String = ""
        CMD = New SqlCommand(query, CN)
        Dim reader As SqlDataReader
        reader = CMD.ExecuteReader
        While reader.Read
            t = ""
            t += Convert.ToString(reader.Item(""))
        End While
        reader.Close()
        TOTAL.Text = t + " €"
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
End Class