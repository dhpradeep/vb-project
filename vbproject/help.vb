Public Class help
    Private Sub help_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        helptext.Text = "Welcome to POS System Help: 
. File, Network, Tools, Setting, Help and Sign Out tools are available in Option Pannel.
. At Home Pannel all fields like Name, Phone, Email, Room Type which available you a different kind of options.
. From Home tool you can add customers data/services and send mail to other persons.
. From Room services you can modify the room data like adding, deleting, updating.
. In settings you can change password/add/modify/delete users
.
.
. For more help click top ('connect with developer') button.

(network feature is not available in here. I will be update this feature soon.)
"
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
        NavigateWebURL("mailto:dhpradeep25@gmail.com", "default")
    End Sub
End Class