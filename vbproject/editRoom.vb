Option Explicit On
Option Strict On
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Public Class editRoom

    Private Sub editRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                sql = "SELECT * from rooms"
                cmd = New OleDbCommand(sql, connection)
                datast = New DataSet
                adapter = New OleDbDataAdapter
                adapter.Fill(datast, "rooms")
                Me.ListBox1.DataSource = datast.Tables("rooms")
                Me.ListBox1.DisplayMember = "roomNo"
            Else
                adapter = New OleDbDataAdapter("SELECT * from rooms where roomNo like '%" & TextBox1.Text & "%'", connection)
                datast = New DataSet
                adapter.Fill(datast, "rooms")
                Me.ListBox1.DataSource = datast.Tables("rooms")
                Me.ListBox1.DisplayMember = "roomNo"
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" OrElse TextBox2.Text = "" OrElse ComboBox1.Text = "" Then
            MsgBox("Please enter some data first.")
            TextBox1.Text = ""
            TextBox2.Text = ""
            ComboBox1.Text = "SINGLE"
        Else
            Try
                Dim sql1 As String
                sql1 = "UPDATE rooms SET roomType = '" & ComboBox1.Text & "', roomPrice= '" _
                    & TextBox2.Text & "' WHERE roomNo = '" & TextBox1.Text & "'"
                cmd = New OleDbCommand(sql1, connection)
                Dim result = cmd.ExecuteNonQuery()
                If result = 1 Then
                    MessageBox.Show("Update room successfully")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    ComboBox1.Text = "SINGLE"
                Else
                    MessageBox.Show("sorry update failed")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    ComboBox1.Text = "SINGLE"
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
End Class