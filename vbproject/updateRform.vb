Imports System.Data.OleDb
Public Class updateRform
    Private Sub updateRform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tt As New ToolTip()
        tt.SetToolTip(LinkLabel1, "This email and password in user
for sending mail and in forget password class. 
Don't worry its encrypt by using different algorithm.
'You have to provide your real email and password in here.")
        tt.SetToolTip(LinkLabel2, "IF you doesnot provide password of
your email address than some features are
not available (like send mail etc..)")
        TextBox6.Focus()
        SetWatermark(TextBox6, "email")
        SetWatermark(TextBox5, "password")

        'public connection setup
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
        'end of public connection setup

        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox6.Text = "") Then
            sql = "UPDATE users SET epassword = '" & Encrypt(TextBox5.Text) & "' WHERE user_name='" &
            loginform.usernamebox.Text & "'"
            cmd = New OleDbCommand(sql, connection)
            Dim result = cmd.ExecuteNonQuery()
            If result = 1 Then
                MsgBox("Your password update successfully")
                Me.Close()
            Else
                MsgBox("Error on updating.")
                TextBox5.Text = ""
                TextBox6.Text = ""
            End If
        ElseIf (TextBox5.Text = "") Then
            sql = "UPDATE users SET mail = '" & TextBox6.Text & "' WHERE user_name='" &
            loginform.usernamebox.Text & "'"
            cmd = New OleDbCommand(sql, connection)
            Dim result = cmd.ExecuteNonQuery()
            If result = 1 Then
                MsgBox("Your email update successfully")
                Me.Close()
            Else
                MsgBox("Error on updating.")
                TextBox5.Text = ""
                TextBox6.Text = ""
            End If
        Else
            sql = "UPDATE users SET epassword = '" & Encrypt(TextBox5.Text) & "', mail='" &
            TextBox6.Text & "' WHERE user_name='" &
            loginform.usernamebox.Text & "'"
        cmd = New OleDbCommand(sql, connection)
        Dim result = cmd.ExecuteNonQuery()
        If result = 1 Then
            MsgBox("Your email & password update successfully")
            Me.Close()
        Else
            MsgBox("Error on updating.")
            TextBox5.Text = ""
            TextBox6.Text = ""
        End If
        End If
    End Sub
End Class