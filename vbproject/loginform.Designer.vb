<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(loginform))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.forgetpassword = New System.Windows.Forms.LinkLabel()
        Me.login = New System.Windows.Forms.Button()
        Me.changePassChar = New System.Windows.Forms.CheckBox()
        Me.passwordbox = New System.Windows.Forms.TextBox()
        Me.usernamebox = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.forgetpassword)
        Me.Panel1.Controls.Add(Me.login)
        Me.Panel1.Controls.Add(Me.changePassChar)
        Me.Panel1.Controls.Add(Me.passwordbox)
        Me.Panel1.Controls.Add(Me.usernamebox)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 407)
        Me.Panel1.TabIndex = 0
        '
        'forgetpassword
        '
        Me.forgetpassword.AutoSize = True
        Me.forgetpassword.BackColor = System.Drawing.Color.Transparent
        Me.forgetpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.forgetpassword.ForeColor = System.Drawing.Color.White
        Me.forgetpassword.LinkColor = System.Drawing.SystemColors.ActiveCaption
        Me.forgetpassword.Location = New System.Drawing.Point(213, 227)
        Me.forgetpassword.Name = "forgetpassword"
        Me.forgetpassword.Size = New System.Drawing.Size(153, 22)
        Me.forgetpassword.TabIndex = 4
        Me.forgetpassword.TabStop = True
        Me.forgetpassword.Text = "? forget password"
        '
        'login
        '
        Me.login.BackgroundImage = CType(resources.GetObject("login.BackgroundImage"), System.Drawing.Image)
        Me.login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.login.Location = New System.Drawing.Point(175, 261)
        Me.login.Name = "login"
        Me.login.Size = New System.Drawing.Size(385, 45)
        Me.login.TabIndex = 3
        Me.login.UseVisualStyleBackColor = True
        '
        'changePassChar
        '
        Me.changePassChar.AutoSize = True
        Me.changePassChar.BackColor = System.Drawing.Color.Transparent
        Me.changePassChar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changePassChar.ForeColor = System.Drawing.Color.White
        Me.changePassChar.Location = New System.Drawing.Point(417, 225)
        Me.changePassChar.Name = "changePassChar"
        Me.changePassChar.Size = New System.Drawing.Size(137, 24)
        Me.changePassChar.TabIndex = 2
        Me.changePassChar.Text = "show password"
        Me.changePassChar.UseVisualStyleBackColor = False
        '
        'passwordbox
        '
        Me.passwordbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordbox.Location = New System.Drawing.Point(217, 179)
        Me.passwordbox.Name = "passwordbox"
        Me.passwordbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordbox.Size = New System.Drawing.Size(337, 30)
        Me.passwordbox.TabIndex = 1
        '
        'usernamebox
        '
        Me.usernamebox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usernamebox.Location = New System.Drawing.Point(217, 133)
        Me.usernamebox.Name = "usernamebox"
        Me.usernamebox.Size = New System.Drawing.Size(337, 30)
        Me.usernamebox.TabIndex = 0
        '
        'loginform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(732, 405)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "loginform"
        Me.Text = "loginform"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents usernamebox As TextBox
    Friend WithEvents passwordbox As TextBox
    Friend WithEvents login As Button
    Friend WithEvents changePassChar As CheckBox
    Friend WithEvents forgetpassword As LinkLabel
End Class
