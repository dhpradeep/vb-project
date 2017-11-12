Public Class printForm
    Private Sub printForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label16.Text = homepage.Label16.Text
        Dim regDate As Date = Date.Today()
        Label6.Text = regDate

        Label1.Text = homepage.TextBox5.Text
        Label12.Text = homepage.ComboBox1.Text
        Label3.Text = homepage.ComboBox2.Text
        Label4.Text = homepage.ComboBox11.Text
        Label5.Text = homepage.TextBox1.Text
        Label17.Text = homepage.TextBox2.Text
        Label18.Text = homepage.TextBox7.Text
    End Sub
End Class