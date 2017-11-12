Imports System.Data.OleDb
Public Class deleteRoom
    Private Sub deleteRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            sql = "select roomNo from rooms"
            cmd = New OleDbCommand(sql, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "rooms")
            ComboBox1.DataSource = datast.Tables(0)
            ComboBox1.ValueMember = "roomNo"
            ComboBox1.DisplayMember = "roomNo"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql1 As String
        sql1 = "DELETE FROM rooms WHERE roomNo = '" & ComboBox1.Text & "'"
        cmd = New OleDbCommand(sql1, connection)
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Delete room successfully.")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error to delete eoom, try again!")
        End Try
    End Sub
End Class