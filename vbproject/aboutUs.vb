Public Class aboutUs
    Private Sub aboutUs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aboutustext.Text = "Point of sale is a open source management system"
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        aboutustext.Text = "Eversoft Team would like to acknowledge the following contributors:

Programming:
---------------
pradip dhakal
gmail:dhpradeep25@gmail.com
github: github.com/dhradeep

Designing:
--------------
pradeep poudel

helping hands:
------------
raju lamsal

Networking:
---------------
Oscar Pun
Prabhu Gurung
"
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        aboutustext.Text = "                                      Point Of Sale                       
                          Version 1.0.1, October 2017             "
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        aboutustext.Text = "All credits goes to EVERSOFT team.
@icon - flatfont.com
@font - fontawesome.com"
    End Sub
    Private Sub NavigateWebURL(ByVal URL As String, Optional browser As String = "default")

        If Not (browser = "default") Then
            Try
                '// try set browser if there was an error (browser not installed)
                Process.Start(browser, URL)
            Catch ex As Exception
                '// use default browser
                Process.Start(URL)
            End Try

        Else
            '// use default browser
            Process.Start(URL)

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NavigateWebURL("https://www.facebook.com/groupofinnovative", "default")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NavigateWebURL("https://twitter.com/wannachngeworld", "default")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NavigateWebURL("https://www.instagram.com/dklpradeep/", "default")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NavigateWebURL("https://www.linkedin.com/in/pradip-dhakal-670655133/", "default")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        NavigateWebURL("mailto:dhpradeep25@gmail.com", "default")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        NavigateWebURL("https://github.com/dhpradeep", "default")
    End Sub
End Class