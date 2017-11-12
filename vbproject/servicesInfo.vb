Imports System.Data.OleDb
Public Class servicesInfo

    Private Sub servicesInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "" OrElse ComboBox1.Text = "" OrElse TextBox2.Text = "") Then
            MsgBox("Please fillout all data", MsgBoxStyle.Exclamation, Title:="Error")
        ElseIf Not (IsNumeric(TextBox2.Text)) Then
            MsgBox("Please only provide numeric value in price field", MsgBoxStyle.Exclamation, Title:="Error")
        Else
            sql = "INSERT INTO services VALUES('" & TextBox1.Text & "', '" & ComboBox1.Text & "', '" & TextBox2.Text & "')"
            cmd = New OleDbCommand(sql, connection)
            'Dim result As Integer = cmd.ExecuteNonQuery()
            'If result = 1 Then
            '    MessageBox.Show("Data has been save in database.")
            '    connection.Close()
            'Else
            '    MessageBox.Show("Failed to save into database.")
            'End If
            Try
                Dim result = cmd.ExecuteNonQuery()
                If result = 1 Then
                    MessageBox.Show("Data has been save in database.")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    ComboBox1.Text = "MISC"

                Else
                    MessageBox.Show("Failed to save into database.")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub


End Class