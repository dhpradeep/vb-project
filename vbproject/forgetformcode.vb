Imports System.Text
Public Class forgetformcode
    Public Property val As String
    Private Sub forgetformcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LinkLabel1.Hide()
        Label2.Hide()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (forgetformcodebox.Text = "") Then
            MsgBox("Please provide your code..")
        ElseIf (forgetformcodebox.Text = Label2.Text)
            MsgBox("Code correct.")
            forgetformcodebox.Text = ""
            Me.Hide()
            changepassword.Show()
        Else
            MsgBox("Sorry your provide code is incorrect.")
            forgetformcodebox.Text = ""
            LinkLabel1.Show()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        forgetform.Show()
    End Sub

End Class