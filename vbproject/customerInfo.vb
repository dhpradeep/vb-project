Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Text
Imports System.Net.Mail
Public Class customerInfo

    Private Sub customerInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
        Try
            Dim sql3 As String
            sql3 = "select roomNo from rooms where roomType='TRIPLE'"
            cmd = New OleDbCommand(sql3, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "rooms")
            ComboBox3.DataSource = datast.Tables(0)
            ComboBox3.ValueMember = "roomNo"
            ComboBox3.DisplayMember = "roomNo"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    'Public Function ValidateEmail(ByVal strCheck As String) As Boolean
    '    Try
    '        Dim vEmailAddress As New System.Net.Mail.MailAddress(strCheck)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    '    Return True
    'End Function

    'Function IsValidEmailFormat(ByVal s As String) As Boolean
    '    Return Regex.IsMatch(s, " ^ ([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    'End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "" OrElse TextBox2.Text = "" OrElse TextBox5.Text = "" _
        OrElse ComboBox1.Text = "" OrElse ComboBox2.Text = "" OrElse ComboBox3.Text = "" OrElse ComboBox4.Text = "") Then
            MsgBox("Please fillout all data", MsgBoxStyle.Exclamation, Title:="Error")
        ElseIf Not (IsNumeric(TextBox2.Text)) Then
            MsgBox("Please only provide numeric value in phone or room no. or no.of person field", MsgBoxStyle.Exclamation, Title:="Error")
        ElseIf TextBox2.Text.Length <> 10 Then
            MsgBox("Please enter only 10 digit of numbers.", MsgBoxStyle.Exclamation, Title:="Error")
        Else
            'Dim a = IsValidEmailFormat(TextBox3.Text)
            'If (a = True) Then
            'write all code here.....
            Dim dd1 As Date, dd2 As Date
            Dim diff As Integer
            dd1 = DateTimePicker1.Value
            dd2 = DateTimePicker2.Value
            diff = DateDiff("d", dd1, dd2)

            diff = diff + 1
            sql = "INSERT INTO customers VALUES('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" _
                    & TextBox3.Text & "', '" & ComboBox1.Text & "', '" & ComboBox3.Text & "', '" _
                    & ComboBox2.Text & "', '" & TextBox5.Text & "', '" & DateTimePicker1.Text _
                    & "', '" & DateTimePicker2.Text & "', '" & diff & "', '" & ComboBox4.Text & "')"
            cmd = New OleDbCommand(sql, connection)
            Try
                Dim result = cmd.ExecuteNonQuery()
                If result = 1 Then
                    MessageBox.Show("Data has been save in database.")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox5.Text = ""
                    ComboBox1.Text = "SINGLE"
                    ComboBox2.Text = "Staying"
                    ComboBox4.Text = ""
                Else
                    MessageBox.Show("Failed to save into database. Try again")
                End If
            Catch ex As Exception
                MsgBox("This room is booked already. Try new room...")
            End Try
            Try
                Dim email As New MailMessage
                email.Subject = "Thanks for registering..."
                email.From = New MailAddress("eversoft.nepal@gmail.com")
                email.To.Add(Me.TextBox3.Text)
                email.Body = ("Thanks for registering into our hotel. Welcome to hell.


Eversoft Team")
                Dim smtp As New SmtpClient("smtp.gmail.com")
                smtp.EnableSsl = True
                smtp.Credentials = New System.Net.NetworkCredential("eversoft.nepal@gmail.com", "EVERsoftsource2016")
                smtp.Port = "587"
                smtp.Send(email)
            Catch ex As Exception
            End Try
            'Else
            '    MsgBox("Email address not valid")
            'End If

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql4 As String
            sql4 = "select roomNo from rooms where roomType='" & ComboBox1.Text & "'"
            cmd = New OleDbCommand(sql4, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "rooms")
            ComboBox3.DataSource = datast.Tables(0)
            ComboBox3.ValueMember = "roomNo"
            ComboBox3.DisplayMember = "roomNo"

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try
            Dim sql5 As String
            sql5 = "select roomPrice from rooms where roomNo='" & ComboBox3.Text & "' "
            cmd = New OleDbCommand(sql5, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "rooms")
            ComboBox4.DataSource = datast.Tables(0)
            ComboBox4.ValueMember = "roomPrice"
            ComboBox4.DisplayMember = "roomPrice"
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

End Class