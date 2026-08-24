<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnEmail = New System.Windows.Forms.Button()
        Me.btnStatusEmail = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnEmail
        '
        Me.btnEmail.Location = New System.Drawing.Point(12, 12)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(75, 23)
        Me.btnEmail.TabIndex = 0
        Me.btnEmail.Text = "Email"
        Me.btnEmail.UseVisualStyleBackColor = True
        '
        'btnStatusEmail
        '
        Me.btnStatusEmail.Location = New System.Drawing.Point(93, 12)
        Me.btnStatusEmail.Name = "btnStatusEmail"
        Me.btnStatusEmail.Size = New System.Drawing.Size(75, 23)
        Me.btnStatusEmail.TabIndex = 1
        Me.btnStatusEmail.Text = "Status Email"
        Me.btnStatusEmail.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(284, 374)
        Me.Controls.Add(Me.btnStatusEmail)
        Me.Controls.Add(Me.btnEmail)
        Me.Name = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEmail As System.Windows.Forms.Button
    Friend WithEvents btnStatusEmail As System.Windows.Forms.Button

End Class
