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
        Me.Btn_Load = New System.Windows.Forms.Button()
        Me.Pbx_Image = New System.Windows.Forms.PictureBox()
        Me.Btn_Gray = New System.Windows.Forms.Button()
        CType(Me.Pbx_Image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Load
        '
        Me.Btn_Load.Location = New System.Drawing.Point(12, 12)
        Me.Btn_Load.Name = "Btn_Load"
        Me.Btn_Load.Size = New System.Drawing.Size(41, 21)
        Me.Btn_Load.TabIndex = 0
        Me.Btn_Load.Text = "Load"
        Me.Btn_Load.UseVisualStyleBackColor = True
        '
        'Pbx_Image
        '
        Me.Pbx_Image.Location = New System.Drawing.Point(12, 39)
        Me.Pbx_Image.Name = "Pbx_Image"
        Me.Pbx_Image.Size = New System.Drawing.Size(600, 600)
        Me.Pbx_Image.TabIndex = 1
        Me.Pbx_Image.TabStop = False
        '
        'Btn_Gray
        '
        Me.Btn_Gray.Location = New System.Drawing.Point(59, 12)
        Me.Btn_Gray.Name = "Btn_Gray"
        Me.Btn_Gray.Size = New System.Drawing.Size(41, 21)
        Me.Btn_Gray.TabIndex = 2
        Me.Btn_Gray.Text = "Gray"
        Me.Btn_Gray.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(623, 649)
        Me.Controls.Add(Me.Btn_Gray)
        Me.Controls.Add(Me.Pbx_Image)
        Me.Controls.Add(Me.Btn_Load)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Pbx_Image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Load As System.Windows.Forms.Button
    Friend WithEvents Pbx_Image As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_Gray As System.Windows.Forms.Button

End Class
