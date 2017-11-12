'Option Explicit On
'Option Strict On
'Imports System.IO
'Imports System.Data
Imports System.Data.OleDb
Public Class loginform

    Private Sub loginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'to set watermark in username & password field
        SetWatermark(usernamebox, "username")
        SetWatermark(passwordbox, "password")
        'end of watermark

        usernamebox.Text = ""
        passwordbox.Text = ""

        'to start connection of ms-access
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
        'end of main connection
    End Sub

    Private Sub remember_CheckedChanged(sender As Object, e As EventArgs) Handles changePassChar.CheckedChanged
        If changePassChar.Checked Then
            passwordbox.PasswordChar = ControlChars.NullChar
        Else
            passwordbox.PasswordChar = "*"c
        End If
    End Sub

    Private Sub forgetpassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles forgetpassword.LinkClicked
        forgetform.Show()
        Me.Hide()
    End Sub

    'login user function
    'Private Sub loginUser()
    '    Try
    '        If Not IsDataComplete() Then
    '            Exit Sub
    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        Try
            ' Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\mydatabase.mdb;Jet OLEDB:Database Password=login1234")
            sql = "SELECT * FROM users WHERE STRCOMP(user_name,'" & usernamebox.Text & "',0)=0 AND STRCOMP(Pass_word,'" & Encrypt(passwordbox.Text) & "',0)=0"
            cmd = New OleDbCommand(sql, connection)
            'If Not connection.State = Data.ConnectionState.Open Then
            '    connection.Open()
            'End If

            reader = cmd.ExecuteReader()
            'Dim sdr As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read = True Then
                MsgBox("Logged in", MsgBoxStyle.Information, Title:="Welcome")
                Me.Hide()
                homepage.Show()

            Else
                MsgBox("Please enter correct data", MsgBoxStyle.Exclamation, Title:="Bye")
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.ToString())
        End Try

    End Sub

End Class