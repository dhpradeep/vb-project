Imports System.Drawing.Printing
Imports System.Data.OleDb
Imports System.Drawing
Public Class homepage
    Private Sub homepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox3.Visible = False
        ComboBox4.Visible = False
        'for checking user or admin
        Try
            Dim sql3 As String
            sql3 = "select role from users where user_name='" & loginform.usernamebox.Text & "'"
            cmd = New OleDbCommand(sql3, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "users")
            ComboBox3.DataSource = datast.Tables(0)
            ComboBox3.ValueMember = "role"
            ComboBox3.DisplayMember = "role"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        If ComboBox3.Text = "1" Then
            Button10.Enabled = True
        Else
            Button10.Enabled = False
            Button10.BackColor = Color.Gray
            Me.Show()
            MsgBox("Please login through admin by enable email feature.", MsgBoxStyle.Information, Title:="Error")
        End If
        'end of checking
        'checking the given admin provide email password or not
        Try
            Dim sql4 As String
            sql4 = "select epassword from users where user_name='" & loginform.usernamebox.Text & "'"
            cmd = New OleDbCommand(sql4, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "users")
            ComboBox4.DataSource = datast.Tables(0)
            ComboBox4.ValueMember = "epassword"
            ComboBox4.DisplayMember = "epassword"
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        If ComboBox4.Text = "" Then
            Button10.Enabled = False
            Button10.BackColor = Color.Gray
            Me.Show()
            MsgBox("You doesnot provide your mail password so email feature
is not available for you. if you want to enable this feature than goto
1. setting > update email and password
2. update 
3. restart (or log out and log in) ", MsgBoxStyle.Information, Title:="Error")
        Else
            Button10.Enabled = True

        End If
        'end of checking

        Label17.Text = Chr(169)
        ComboBox1.Enabled = False
        ComboBox11.Enabled = False
        ComboBox2.Enabled = False
        Timer1.Enabled = True
        Dim regDate As Date = Date.Today()
        Label6.Text = regDate
        'panel control
        'servicespanel2.Hide()
        'customerpanel3.Hide()
        'roompanel4.Hide()
        'billingpanel5.Hide()
        With homepanel_back
            .Width = 859
            .Height = 563
        End With
        servicepanelsep.Hide()
        custompanelsep.Hide()
        roompanelsep.Hide()
        billingpanelsep.Hide()
        homepanelsep.Show()
        'end of panel control

        'public connection setup
        connection = New OleDbConnection
        With connection
            If .State = ConnectionState.Closed Then
                .ConnectionString = strCon
                .Open()
            End If
        End With
        'end of public connection setup

        'sidebar note

        'end of sidebar note

        ' customer panel
        sql = "SELECT * FROM customers"
        cmd = New OleDbCommand(sql, connection)
        adapter = New OleDbDataAdapter(cmd)
        datast = New DataSet()
        adapter.Fill(datast, "customers")
        datast.Tables(0).DefaultView.Sort = "name"
        bindingsrc = New BindingSource()

        With customerView
            .DataSource = datast.Tables("customers")
        End With
        'end of customer panel
        ' service panel
        Dim sql1 As String
        sql1 = "SELECT * FROM services"
        cmd = New OleDbCommand(sql1, connection)
        adapter = New OleDbDataAdapter(cmd)
        datast = New DataSet()
        adapter.Fill(datast, "services")
        datast.Tables(0).DefaultView.Sort = "name"
        bindingsrc = New BindingSource()

        With serviceView
            .DataSource = datast.Tables("services")
        End With
        'end of service panel

        ' rooms panel
        Dim sql10 As String
        sql10 = "SELECT * FROM rooms"
        cmd = New OleDbCommand(sql10, connection)
        adapter = New OleDbDataAdapter(cmd)
        datast = New DataSet()
        adapter.Fill(datast, "rooms")
        datast.Tables(0).DefaultView.Sort = "roomNo"
        bindingsrc = New BindingSource()

        With roomview
            .DataSource = datast.Tables("rooms")
        End With
        'end of rooms panel

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        currTime.Text = Date.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub homeMenu_MouseHover(sender As Object, e As EventArgs) Handles homeMenu.MouseHover
        With homeMenu
            .BackgroundImage = My.Resources.home_hover
        End With
    End Sub

    Private Sub homeMenu_MouseLeave(sender As Object, e As EventArgs) Handles homeMenu.MouseLeave
        With homeMenu
            .BackgroundImage = My.Resources.home
        End With
    End Sub




    Private Sub servicesMenu_MouseHover(sender As Object, e As EventArgs) Handles servicesMenu.MouseHover
        With servicesMenu
            .BackgroundImage = My.Resources.services_hover
        End With
    End Sub

    Private Sub servicesMenu_MouseLeave(sender As Object, e As EventArgs) Handles servicesMenu.MouseLeave
        With servicesMenu
            .BackgroundImage = My.Resources.services
        End With
    End Sub

    Private Sub customerMenu_MouseHover(sender As Object, e As EventArgs) Handles customerMenu.MouseHover
        With customerMenu
            .BackgroundImage = My.Resources.customer_hover
        End With
    End Sub

    Private Sub customerMenu_MouseLeave(sender As Object, e As EventArgs) Handles customerMenu.MouseLeave
        With customerMenu
            .BackgroundImage = My.Resources.customer
        End With
    End Sub

    Private Sub roomMenu_MouseHover(sender As Object, e As EventArgs) Handles roomMenu.MouseHover
        With roomMenu
            .BackgroundImage = My.Resources.rooms_hover
        End With
    End Sub

    Private Sub roomMenu_MouseLeave(sender As Object, e As EventArgs) Handles roomMenu.MouseLeave
        With roomMenu
            .BackgroundImage = My.Resources.rooms
        End With
    End Sub

    Private Sub billingMenu_MouseHover(sender As Object, e As EventArgs) Handles billingMenu.MouseHover
        With billingMenu
            .BackgroundImage = My.Resources.billing_hover
        End With
    End Sub

    Private Sub billingMenu_MouseLeave(sender As Object, e As EventArgs) Handles billingMenu.MouseLeave
        With billingMenu
            .BackgroundImage = My.Resources.billing
        End With
    End Sub

    Private Sub aboutMenu_MouseHover(sender As Object, e As EventArgs) Handles aboutMenu.MouseHover
        With aboutMenu
            .BackgroundImage = My.Resources.aboutus_hover
        End With
    End Sub

    Private Sub aboutMenu_MouseLeave(sender As Object, e As EventArgs) Handles aboutMenu.MouseLeave
        With aboutMenu
            .BackgroundImage = My.Resources.aboutus
        End With
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        sidebarnote.Font = FontDialog1.Font
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        sidebarnote.Text = ""
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        SaveFileDialog1.ShowDialog()
        If (SaveFileDialog1.FileName = "") Then
            Exit Sub
        End If

        ' this file save the file
        FileSystem.FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
        FileSystem.Print(1, sidebarnote.Text)
        FileSystem.FileClose(1)
    End Sub


    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then
            Exit Sub
        End If
        ' this part loads the file
        Dim Tmp As String
        Tmp = ""
        FileSystem.FileOpen(1, OpenFileDialog1.FileName, OpenMode.Input)
        Do While Not FileSystem.EOF(1)
            Tmp = Tmp & FileSystem.LineInput(1)
            If Not FileSystem.EOF(1) Then
                Tmp = Tmp & Chr(13) & Chr(10)
            End If
        Loop
        FileSystem.FileClose(1)
        sidebarnote.Text = Tmp
    End Sub

    Private Sub SignOutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SignOutToolStripMenuItem1.Click

    End Sub

    Private Sub RedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedToolStripMenuItem.Click
        sidebarnote.ForeColor = Color.Black
    End Sub

    Private Sub BlueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlueToolStripMenuItem.Click
        sidebarnote.ForeColor = Color.Blue
    End Sub

    Private Sub GreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GreenToolStripMenuItem.Click
        sidebarnote.ForeColor = Color.Green
    End Sub

    Private Sub YellowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YellowToolStripMenuItem.Click
        sidebarnote.ForeColor = Color.Yellow
    End Sub

    Private Sub RedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RedToolStripMenuItem1.Click
        sidebarnote.ForeColor = Color.Red
    End Sub

    Private Sub CustomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        sidebarnote.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        aboutUs.ShowDialog()
    End Sub

    Private Sub aboutMenu_Click(sender As Object, e As EventArgs) Handles aboutMenu.Click
        aboutUs.ShowDialog()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        help.ShowDialog()
    End Sub

    Private Sub homeMenu_Click(sender As Object, e As EventArgs) Handles homeMenu.Click
        'panel control
        With servicespanel2
            .Width = 0
            .Height = 0
        End With
        With customerpanel3
            .Width = 0
            .Height = 0
        End With
        With roompanel4
            .Width = 0
            .Height = 0
        End With
        With billingpanel5
            .Width = 0
            .Height = 0
        End With
        With homepanel_back
            .Height = 563
            .Width = 859
        End With
        servicepanelsep.Hide()
        custompanelsep.Hide()
        roompanelsep.Hide()
        billingpanelsep.Hide()
        homepanelsep.Show()
        'end of panel control
    End Sub

    Private Sub servicesMenu_Click(sender As Object, e As EventArgs) Handles servicesMenu.Click

        'panel control
        With customerpanel3
            .Width = 0
            .Height = 0
        End With
        With roompanel4
            .Width = 0
            .Height = 0
        End With
        With billingpanel5
            .Width = 0
            .Height = 0
        End With
        With homepanel_back
            .Width = 0
            .Height = 0
        End With
        With servicespanel2
            .Width = 859
            .Height = 563
        End With
        servicepanelsep.Show()
        custompanelsep.Hide()
        roompanelsep.Hide()
        billingpanelsep.Hide()
        homepanelsep.Hide()
        'end of panel control
    End Sub

    Private Sub customerMenu_Click(sender As Object, e As EventArgs) Handles customerMenu.Click
        'panel control
        With servicespanel2
            .Width = 0
            .Height = 0
        End With
        With roompanel4
            .Width = 0
            .Height = 0
        End With
        With billingpanel5
            .Width = 0
            .Height = 0
        End With
        With homepanel_back
            .Width = 0
            .Height = 0
        End With
        With customerpanel3
            .Width = 859
            .Height = 563
        End With
        servicepanelsep.Hide()
        custompanelsep.Show()
        roompanelsep.Hide()
        billingpanelsep.Hide()
        homepanelsep.Hide()
        'end of panel control
    End Sub

    Private Sub roomMenu_Click(sender As Object, e As EventArgs) Handles roomMenu.Click
        'panel control
        With servicespanel2
            .Width = 0
            .Height = 0
        End With
        With customerpanel3
            .Width = 0
            .Height = 0
        End With
        With billingpanel5
            .Width = 0
            .Height = 0
        End With
        With homepanel_back
            .Width = 0
            .Height = 0
        End With
        With roompanel4
            .Width = 859
            .Height = 563
        End With
        servicepanelsep.Hide()
        custompanelsep.Hide()
        roompanelsep.Show()
        billingpanelsep.Hide()
        homepanelsep.Hide()
        'end of panel control
    End Sub

    Private Sub billingMenu_Click(sender As Object, e As EventArgs) Handles billingMenu.Click
        Label16.Text = loginform.usernamebox.Text
        TextBox5.Text = ""
        ComboBox1.Text = ""
        ComboBox11.Text = "0"
        TextBox1.Text = "0"
        TextBox2.Text = "0"
        TextBox7.Text = "0"
        'panel control
        With servicespanel2
            .Width = 0
            .Height = 0
        End With
        With customerpanel3
            .Width = 0
            .Height = 0
        End With
        With roompanel4
            .Width = 0
            .Height = 0
        End With
        With homepanel_back
            .Width = 0
            .Height = 0
        End With
        With billingpanel5
            .Width = 859
            .Height = 563
        End With
        servicepanelsep.Hide()
        custompanelsep.Hide()
        roompanelsep.Hide()
        billingpanelsep.Show()
        homepanelsep.Hide()
        'end of panel control
    End Sub

    Private Sub ServicesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServicesToolStripMenuItem.Click
        'panel control
        With servicespanel2
            .Width = 859
            .Height = 563
        End With
        With homepanel_back
            .Width = 0
            .Height = 0
        End With
        With customerpanel3
            .Width = 0
            .Height = 0
        End With
        With roompanel4
            .Width = 0
            .Height = 0
        End With
        With billingpanel5
            .Width = 0
            .Height = 0
        End With
        servicepanelsep.Show()
        custompanelsep.Hide()
        roompanelsep.Hide()
        billingpanelsep.Hide()
        homepanelsep.Hide()
        'end of panel control
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        'panel control
        With servicespanel2
            .Width = 0
            .Height = 0
        End With
        With homepanel_back
            .Width = 0
            .Height = 0
        End With
        With customerpanel3
            .Width = 859
            .Height = 563
        End With
        With roompanel4
            .Width = 0
            .Height = 0
        End With
        With billingpanel5
            .Width = 0
            .Height = 0
        End With
        servicepanelsep.Hide()
        custompanelsep.Show()
        roompanelsep.Hide()
        billingpanelsep.Hide()
        homepanelsep.Hide()
        'end of panel control
    End Sub

    Private Sub RoomServicesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomServicesToolStripMenuItem.Click
        'panel control
        With servicespanel2
            .Width = 0
            .Height = 0
        End With
        With homepanel_back
            .Width = 0
            .Height = 0
        End With
        With customerpanel3
            .Width = 0
            .Height = 0
        End With
        With roompanel4
            .Width = 859
            .Height = 563
        End With
        With billingpanel5
            .Width = 0
            .Height = 0
        End With
        servicepanelsep.Hide()
        custompanelsep.Hide()
        roompanelsep.Show()
        billingpanelsep.Hide()
        homepanelsep.Hide()
        'end of panel control
    End Sub

    Private Sub BillingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillingToolStripMenuItem.Click
        'panel control
        With servicespanel2
            .Width = 0
            .Height = 0
        End With
        With homepanel_back
            .Width = 0
            .Height = 0
        End With
        With customerpanel3
            .Width = 0
            .Height = 0
        End With
        With roompanel4
            .Width = 0
            .Height = 0
        End With
        With billingpanel5
            .Width = 859
            .Height = 563
        End With
        servicepanelsep.Hide()
        custompanelsep.Hide()
        roompanelsep.Hide()
        billingpanelsep.Show()
        homepanelsep.Hide()
        'end of panel control
    End Sub

    Private Sub mailsender_Click(sender As Object, e As EventArgs)
        sendMail.ShowDialog()
    End Sub

    Private Sub SignOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignOutToolStripMenuItem.Click
        otherSetting.ShowDialog()
    End Sub

    Private Sub SignOutToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SignOutToolStripMenuItem2.Click
        Application.Restart()
    End Sub

    Private Sub customerAdd_Click(sender As Object, e As EventArgs) Handles customerAdd.Click
        customerInfo.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        servicesInfo.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        manageRoom.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        deleteRoom.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        editRoom.ShowDialog()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        manageRoom.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim search As String = "SELECT * FROM services WHERE name like '%" & TextBox4.Text & "%'"
            cmd = New OleDbCommand(search, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "services")
            datast.Tables(0).DefaultView.Sort = "name"
            bindingsrc = New BindingSource()

            With serviceView
                .DataSource = datast.Tables("services")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim search As String = "SELECT * FROM customers WHERE name like '%" & TextBox3.Text & "%'"
            cmd = New OleDbCommand(search, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "customers")
            datast.Tables(0).DefaultView.Sort = "name"
            bindingsrc = New BindingSource()

            With customerView
                .DataSource = datast.Tables("customers")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'serviceView.Refresh()
        'customerView.Refresh()
        'roomview.Refresh()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Try
            Dim sql31 As String
            sql31 = "select name from customers where roomNo='" & TextBox5.Text & "'"
            cmd = New OleDbCommand(sql31, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "customers")
            ComboBox1.DataSource = datast.Tables(0)
            ComboBox1.ValueMember = "name"
            ComboBox1.DisplayMember = "name"

            Dim sql30 As String
            sql30 = "select price from customers where roomNo='" & TextBox5.Text & "'"
            cmd = New OleDbCommand(sql30, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "customers")
            ComboBox11.DataSource = datast.Tables(0)
            ComboBox11.ValueMember = "price"
            ComboBox11.DisplayMember = "price"

            Dim sql35 As String
            sql35 = "select diff from customers where roomNo='" & TextBox5.Text & "'"
            cmd = New OleDbCommand(sql35, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "customers")
            ComboBox2.DataSource = datast.Tables(0)
            ComboBox2.ValueMember = "diff"
            ComboBox2.DisplayMember = "diff"

            If TextBox5.Text = "" Then
                'Test if the textbox is null, then reset the grid.
                sql = "SELECT * from customers"
                cmd = New OleDbCommand(sql, connection)
                datast = New DataSet
                adapter = New OleDbDataAdapter
                adapter.Fill(datast, "customers")
                Me.ListBox1.DataSource = datast.Tables("customers")
                Me.ListBox1.DisplayMember = "name"
            Else
                adapter = New OleDbDataAdapter("SELECT * from customers where roomNo like '%" & TextBox5.Text & "%'", connection)
                datast = New DataSet
                adapter.Fill(datast, "customers")
                Me.ListBox1.DataSource = datast.Tables("customers")
                Me.ListBox1.DisplayMember = "name"
            End If
        Catch ex As Exception
            ' MsgBox(ex.ToString())
        End Try
    End Sub
    Public cmd1 As OleDb.OleDbCommand
    Private WithEvents pndocument As PrintDocument
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim sql32, sql33 As String
        ComboBox1.Visible = True
        ComboBox2.Visible = True
        ComboBox11.Visible = True
        sql33 = "INSERT INTO recycleCustomer SELECT * FROM customers WHERE roomNo='" & TextBox5.Text & "'"
        sql32 = "DELETE FROM customers WHERE roomNo = '" & TextBox5.Text & "'"
        '   DELETE tbl1
        'OUTPUT deleted.* INTO tbl2
        '   WHERE col = 'foo';

        cmd = New OleDbCommand(sql32, connection)
        cmd1 = New OleDbCommand(sql33, connection)
        Try
            If Not (IsNumeric(TextBox2.Text) AndAlso IsNumeric(TextBox1.Text)) Then
                MsgBox("Please only provide numeric value in here...")
            Else
                Dim totalMoney As Integer
                totalMoney = (Val((ComboBox11.Text) * Val(ComboBox2.Text)) + Val(TextBox1.Text)) - Val(TextBox2.Text)
                TextBox7.Text = totalMoney
                Dim result = cmd.ExecuteNonQuery()
                Dim result1 = cmd1.ExecuteNonQuery()
                If result = 1 Then
                    MsgBox("Your print file is ready.")
                    Label16.Text = loginform.usernamebox.Text
                    TextBox5.Text = ""
                    ComboBox1.Text = ""
                    ComboBox11.Text = "0"
                    ComboBox2.Text = "1"
                    TextBox1.Text = "0"
                    TextBox2.Text = "0"
                    TextBox7.Text = "0"
                    'open printer and other file here...
                    PrintDocument1.Print()

                Else
                    MsgBox("Problem on printing bills. Try again.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        printForm.Show()
        printForm.Hide()
        Dim b As New Bitmap(printForm.Panel1.Width, printForm.Panel1.Height)
        printForm.Panel1.DrawToBitmap(b, printForm.Panel1.ClientRectangle)

        e.Graphics.DrawImage(b, New Point(0, 0))
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        deleteServices.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        sendMail.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem2.Click
        MsgBox("Good Bye...")
        Me.Close()
        connection.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            Dim search As String = "SELECT * FROM rooms WHERE roomNo like '%" & TextBox6.Text & "%'"
            cmd = New OleDbCommand(search, connection)
            adapter = New OleDbDataAdapter(cmd)
            datast = New DataSet()
            adapter.Fill(datast, "rooms")
            datast.Tables(0).DefaultView.Sort = "roomNo"
            bindingsrc = New BindingSource()

            With roomview
                .DataSource = datast.Tables("rooms")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
