<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class help
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
        Me.helptext = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'helptext
        '
        Me.helptext.BackColor = System.Drawing.SystemColors.Control
        Me.helptext.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.helptext.Location = New System.Drawing.Point(1, 35)
        Me.helptext.Multiline = True
        Me.helptext.Name = "helptext"
        Me.helptext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.helptext.Size = New System.Drawing.Size(426, 443)
        Me.helptext.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Button1.Location = New System.Drawing.Point(1, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(163, 31)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "connect with developer"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 481)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.helptext)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "help"
        Me.Text = "Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents helptext As TextBox
    Friend WithEvents Button1 As Button
End Class
