Imports System.Net
Imports System.Text
Imports System.Net.Mail
Imports System.Data.OleDb
Public Class forgetform
    Public generatedPass As String
    ' to generate random text and number
    Sub stringGenerator()
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        Dim cypherText As String
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next
        cypherText = (sb.ToString())
        generatedPass = cypherText
    End Sub
    'end of generate random text and number

    Private Sub forgetform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetWatermark(forgetformbox, "enter your mail here...")
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
        ComboBox1.Visible = False
        ComboBox2.Visible = False
        Label1.Visible = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        loginform.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (forgetformbox.Text = "") Then
            MsgBox("Please enter your email address.")
        Else
            Try
                'combobox1, combobox2, label1
                Dim sql3 As String
                sql3 = "select mail from users where user_name='admin'"
                cmd = New OleDbCommand(sql3, connection)
                adapter = New OleDbDataAdapter(cmd)
                datast = New DataSet()
                adapter.Fill(datast, "users")
                ComboBox1.DataSource = datast.Tables(0)
                ComboBox1.ValueMember = "mail"
                ComboBox1.DisplayMember = "mail"
            Catch ex As Exception
                MsgBox("once you add email and password in admin account then this features is available.")
            End Try
            Try
                Dim sql3 As String
                sql3 = "select epassword from users where user_name='admin'"
                cmd = New OleDbCommand(sql3, connection)
                adapter = New OleDbDataAdapter(cmd)
                datast = New DataSet()
                adapter.Fill(datast, "users")
                ComboBox2.DataSource = datast.Tables(0)
                ComboBox2.ValueMember = "epassword"
                ComboBox2.DisplayMember = "epassword"
                Label1.Text = Decrypt(ComboBox2.Text)
            Catch ex As Exception
                MsgBox("once you add email and password in admin account then this features is available.")
            End Try

            Try
                Dim sql4 As String
                sql4 = "SELECT mail FROM users WHERE mail='" & forgetformbox.Text & "'"
                cmd = New OleDbCommand(sql4, connection)
                adapter = New OleDbDataAdapter(cmd)
                ' Dim execute = cmd.ExecuteNonQuery()
                Dim mytable As New DataTable
                adapter.Fill(mytable)
                If mytable.Rows.Count > 0 Then
                    'user already exist
                    Dim email As New MailMessage
                    stringGenerator()
                    email.Subject = "Your reset code here. send from : vb.net"
                    email.From = New MailAddress(ComboBox1.Text)
                    email.To.Add(Me.forgetformbox.Text)
                    email.Body = ("Your reset code is: " + generatedPass)
                    Dim smtp As New SmtpClient("smtp.gmail.com")
                    smtp.EnableSsl = True
                    smtp.Credentials = New System.Net.NetworkCredential(ComboBox1.Text, Label1.Text)
                    smtp.Port = "587"
                    smtp.Send(email)
                    MsgBox("sending mail successful")
                    'send generated password to next form
                    'Dim obb As New forgetformcode
                    'obb.val = generatedPass
                    forgetformbox.Text = ""
                    forgetformcode.Show()
                    forgetformcode.Label2.Text = generatedPass
                    Me.Hide()
                Else
                    MsgBox("There is no such email register in databaase", MsgBoxStyle.Exclamation, Title:="Error")
                End If
            Catch ex As Exception
                MsgBox("once you add email and password in admin account then this features is available.")
            End Try
        End If
    End Sub
End Class