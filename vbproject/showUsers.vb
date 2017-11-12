Imports System.Data.OleDb
Imports System.Drawing
Public Class showUsers
    Private Sub manageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox6.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = "1"
        CheckBox1.Checked = False
        SetWatermark(TextBox3, "password for login")
        Dim tt As New ToolTip()
        tt.SetToolTip(LinkLabel1, "This email and password in user
for sending mail and in forget password class. 
Don't worry its encrypt by using different algorithm.
'You have to provide your real email and password in here.")
        tt.SetToolTip(LinkLabel2, "IF you doesnot provide password of
your email address than some features are
not available (like send mail etc..)")
        TextBox1.Focus()
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

        ' customer panel
        sql = "SELECT user_name,mail FROM users WHERE role = 1"
        cmd = New OleDbCommand(sql, connection)
        adapter = New OleDbDataAdapter(cmd)
        datast = New DataSet()
        adapter.Fill(datast, "users")
        datast.Tables(0).DefaultView.Sort = "user_name"
        bindingsrc = New BindingSource()

        With DataGridView1
            .DataSource = datast.Tables("users")
        End With
        'end of customer panel
        ' customer panel
        Dim sql1 As String
        sql1 = "SELECT user_name,mail FROM users WHERE role = 2"
        cmd = New OleDbCommand(sql1, connection)
        adapter = New OleDbDataAdapter(cmd)
        datast = New DataSet()
        adapter.Fill(datast, "users")
        datast.Tables(0).DefaultView.Sort = "user_name"
        bindingsrc = New BindingSource()

        With DataGridView2
            .DataSource = datast.Tables("users")
        End With
        'end of customer panel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" OrElse TextBox6.Text = "" OrElse TextBox3.Text = "" OrElse
                TextBox4.Text = "" OrElse ComboBox1.Text = "" Then
            MsgBox("Please fillout all data", MsgBoxStyle.Exclamation, Title:="Error")
        ElseIf TextBox3.Text <> TextBox4.Text Then
            MsgBox("password & confirm password do not match, Try again", MsgBoxStyle.Exclamation, Title:="Error")
            TextBox3.Text = ""
            TextBox4.Text = ""
        ElseIf (TextBox3.Text.Length <= 8) Then
            MsgBox("Password must be greater than 8 character", MsgBoxStyle.Exclamation, Title:="Error")
            TextBox3.Text = ""
            TextBox4.Text = ""
        ElseIf Not (ComboBox1.Text = "1" OrElse ComboBox1.Text = "2") Then
            MsgBox("there is only 2 role choose one of them", MsgBoxStyle.Exclamation, Title:="Error")
        Else
            Try
                Dim sql4 As String
                sql4 = "SELECT user_name FROM users WHERE user_name='" & TextBox1.Text & "'"
                cmd = New OleDbCommand(sql4, connection)
                adapter = New OleDbDataAdapter(cmd)
                ' Dim execute = cmd.ExecuteNonQuery()
                Dim mytable As New DataTable
                adapter.Fill(mytable)
                If mytable.Rows.Count > 0 Then
                    'user already exist
                    MsgBox("username already exist, insert new one", MsgBoxStyle.Exclamation, Title:="Error")
                Else
                    If (TextBox5.Text = "") Then
                        Dim sql6 As String
                        sql6 = "INSERT INTO users (user_name,pass_word,mail,role) VALUES('" & TextBox1.Text _
                            & "','" & Encrypt(TextBox3.Text) & "','" & TextBox6.Text & "','" & ComboBox1.Text & "')"
                        cmd = New OleDbCommand(sql6, connection)
                        Dim result = cmd.ExecuteNonQuery()
                        If result = 1 Then
                            MsgBox("New users added successfully")
                            TextBox1.Text = ""
                            TextBox6.Text = ""
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            TextBox5.Text = ""
                            ComboBox1.Text = "1"
                        Else
                            MsgBox("Problem on inseting into database.")
                            TextBox1.Text = ""
                            TextBox6.Text = ""
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            ComboBox1.Text = "1"
                            TextBox5.Text = ""
                        End If
                    Else
                        Dim sql5 As String
                        sql5 = "INSERT INTO users VALUES ('" & TextBox1.Text & "','" & Encrypt(TextBox3.Text) _
                            & "','" & TextBox6.Text & "','" & ComboBox1.Text & "','" & Encrypt(TextBox5.Text) & "')"
                        cmd = New OleDbCommand(sql5, connection)
                        Dim result = cmd.ExecuteNonQuery()
                        If result = 1 Then
                            MsgBox("New users added successfully")
                            TextBox1.Text = ""
                            TextBox6.Text = ""
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            TextBox5.Text = ""
                            ComboBox1.Text = "1"
                        Else
                            MsgBox("Problem on inseting into database.")
                            TextBox1.Text = ""
                            TextBox6.Text = ""
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            ComboBox1.Text = "1"
                            TextBox5.Text = ""
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox3.PasswordChar = ControlChars.NullChar
            TextBox4.PasswordChar = ControlChars.NullChar
        Else
            TextBox3.PasswordChar = "*"c
            TextBox4.PasswordChar = "*"c
        End If
    End Sub
End Class