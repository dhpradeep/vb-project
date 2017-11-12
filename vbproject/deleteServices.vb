Imports System.Data.OleDb
Public Class deleteServices
    Private Sub deleteServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'public connection setup
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
        'end of public connection setup

        Try
            sql = "select name from services"
            cmd = New OleDbCommand(sql, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "services")
            ComboBox1.DataSource = datast.Tables(0)
            ComboBox1.ValueMember = "name"
            ComboBox1.DisplayMember = "name"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql1 As String
        sql1 = "DELETE FROM services WHERE name = '" & ComboBox1.Text & "'"
        cmd = New OleDbCommand(sql1, connection)
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Delete services successfully.")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error to delete services, try again!")
        End Try
    End Sub
End Class