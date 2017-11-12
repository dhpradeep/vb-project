Imports System.Net.Mail
Imports System.Data.OleDb
Public Class sendMail

    Private Sub sendMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        remail.Visible = False
        epassword.Visible = False
        Label4.Visible = False

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        Dim uname As String = loginform.usernamebox.Text
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
        Try
            Dim sql3 As String
            sql3 = "select mail from users where user_name='" & uname & "'"
            cmd = New OleDbCommand(sql3, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "users")
            remail.DataSource = datast.Tables(0)
            remail.ValueMember = "mail"
            remail.DisplayMember = "mail"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim sql3 As String
            sql3 = "select epassword from users where user_name='" & uname & "'"
            cmd = New OleDbCommand(sql3, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "users")
            epassword.DataSource = datast.Tables(0)
            epassword.ValueMember = "epassword"
            epassword.DisplayMember = "epassword"
            Label4.Text = Decrypt(epassword.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim email As New MailMessage
            email.Subject = Me.TextBox2.Text
            email.From = New MailAddress(remail.Text)
            email.To.Add(Me.TextBox1.Text)
            email.Body = (Me.TextBox3.Text)

            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential(remail.Text, Label4.Text)
            smtp.Port = "587"
            smtp.Send(email)
            MsgBox("Successfully send mail to: " + TextBox1.Text)
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        Catch ex As Exception
            MsgBox("Error on sending mail.")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End Try
    End Sub
End Class
