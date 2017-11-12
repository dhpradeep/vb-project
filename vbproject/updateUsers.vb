Option Explicit On
Option Strict On
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Public Class updateUsers
    Private Sub updateUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text = "" Then
                'Test if the textbox is null, then reset the grid.
                sql = "SELECT * from users"
                cmd = New OleDbCommand(sql, connection)
                datast = New DataSet
                adapter = New OleDbDataAdapter
                adapter.Fill(datast, "users")
                Me.ListBox1.DataSource = datast.Tables("users")
                Me.ListBox1.DisplayMember = "user_name"
            Else
                adapter = New OleDbDataAdapter("SELECT * from users where user_name like '%" & TextBox1.Text & "%'", connection)
                datast = New DataSet
                adapter.Fill(datast, "users")
                Me.ListBox1.DataSource = datast.Tables("users")
                Me.ListBox1.DisplayMember = "user_name"
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" OrElse TextBox3.Text = "" OrElse TextBox2.Text = "" Then
            MsgBox("Please enter some data first.")
            TextBox1.Text = ""
            TextBox3.Text = ""
            TextBox3.Text = ""
        ElseIf (TextBox3.Text.Length <= 8)
            MsgBox("Password must be greater than 8 character")
            TextBox3.Text = ""
        ElseIf Not (ComboBox1.Text = "1" OrElse ComboBox1.Text = "2")
            MsgBox("You can only choose two role. (1 or 2)")
        Else
            Try
                Dim sql1 As String
                sql1 = "UPDATE users SET pass_word = '" & Encrypt(TextBox3.Text) & "', mail= '" _
                    & TextBox2.Text & "', role=" & ComboBox1.Text & " WHERE user_name = '" & TextBox1.Text & "'"
                cmd = New OleDbCommand(sql1, connection)
                Dim result = cmd.ExecuteNonQuery()
                If result = 1 Then
                    MessageBox.Show("Your profile update successfully")
                    TextBox1.Text = ""
                    TextBox3.Text = ""
                    TextBox3.Text = ""
                Else
                    MessageBox.Show("sorry wrong username choosen")
                    TextBox1.Text = ""
                    TextBox3.Text = ""
                    TextBox3.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox3.PasswordChar = ControlChars.NullChar
        Else
            TextBox3.PasswordChar = "*"c
        End If
    End Sub
End Class