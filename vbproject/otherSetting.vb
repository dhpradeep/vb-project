Imports System.Data.OleDb
Public Class otherSetting
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        changepassword.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        showUsers.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        updateUsers.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        deleteUsers.ShowDialog()
    End Sub

    Private Sub otherSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Hide()
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
            sql = "SELECT role FROM users where user_name='" & loginform.usernamebox.Text & "'"
            cmd = New OleDbCommand(sql, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "users")
            ComboBox1.DataSource = datast.Tables(0)
            ComboBox1.ValueMember = "role"
            ComboBox1.DisplayMember = "role"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ComboBox1.Text = "1" Then
            GroupBox1.Visible = True
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        updateRform.ShowDialog()
    End Sub
End Class