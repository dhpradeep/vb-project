Imports System.Data.OleDb
Public Class deleteUsers
    Private Sub deleteUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            sql = "select user_name from users"
            cmd = New OleDbCommand(sql, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "users")
            ComboBox1.DataSource = datast.Tables(0)
            ComboBox1.ValueMember = "user_name"
            ComboBox1.DisplayMember = "user_name"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql1 As String
        sql1 = "DELETE FROM users WHERE user_name = '" & ComboBox1.Text & "'"
        cmd = New OleDbCommand(sql1, connection)
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Delete user successfully.")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error to delete users, try again!")
        End Try
    End Sub
End Class