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
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtRepository = New System.Windows.Forms.TextBox()
        Me.btnViewCard = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(300, 50)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(200, 31)
        Me.txtUsername.TabIndex = 0
        '
        'txtRepository
        '
        Me.txtRepository.Location = New System.Drawing.Point(525, 50)
        Me.txtRepository.Name = "txtRepository"
        Me.txtRepository.Size = New System.Drawing.Size(200, 31)
        Me.txtRepository.TabIndex = 1
        '
        'btnViewCard
        '
        Me.btnViewCard.Location = New System.Drawing.Point(750, 48)
        Me.btnViewCard.Name = "btnViewCard"
        Me.btnViewCard.Size = New System.Drawing.Size(100, 43)
        Me.btnViewCard.TabIndex = 2
        Me.btnViewCard.Text = "Load"
        Me.btnViewCard.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "GitHub Repository:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(500, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 31)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "/"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2174, 579)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnViewCard)
        Me.Controls.Add(Me.txtRepository)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Form1"
        Me.Text = "GitHub Punch Card Viewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtRepository As TextBox
    Friend WithEvents btnViewCard As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
