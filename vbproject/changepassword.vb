Imports System.Data.OleDb
Public Class changepassword
    Private Sub changepassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        username.Enabled = False
        Me.Show()
        If (loginform.usernamebox.Text = "") Then
            MsgBox("You should provide username in login panel. Try again!")
            Me.Hide()
            loginform.Show()
        Else
            username.Text = loginform.usernamebox.Text
        End If
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            newpassword.PasswordChar = ControlChars.NullChar
            confirmpassword.PasswordChar = ControlChars.NullChar
        Else
            newpassword.PasswordChar = "*"c
            confirmpassword.PasswordChar = "*"c
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If username.Text = "" OrElse newpassword.Text = "" OrElse confirmpassword.Text = "" Then
            MsgBox("Please enter some data first.")
            newpassword.Text = ""
            confirmpassword.Text = ""
        ElseIf newpassword.Text <> confirmpassword.Text Then
            MsgBox("password & confirm password do not match, Try again")
            newpassword.Clear()
            confirmpassword.Clear()
        ElseIf (newpassword.Text.Length <= 8)
            MsgBox("Password must be greater than 8 character")
            newpassword.Text = ""
            confirmpassword.Text = ""
        Else
            ' update password to database code here....
            Try
                sql = "UPDATE users SET pass_word = '" & Encrypt(newpassword.Text) & "' WHERE user_name= '" & username.Text & "'"
                cmd = New OleDbCommand(sql, connection)
                Dim result = cmd.ExecuteNonQuery()
                If result = 1 Then
                    MessageBox.Show("Your username and password change successfully")
                    newpassword.Text = ""
                    confirmpassword.Text = ""
                    Me.Hide()
                    loginform.Show()

                Else
                    MessageBox.Show("your provided username is wrong")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
End Class