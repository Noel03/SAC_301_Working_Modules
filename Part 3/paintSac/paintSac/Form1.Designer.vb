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
        Me.btnPen = New System.Windows.Forms.RadioButton()
        Me.btnRectangle = New System.Windows.Forms.RadioButton()
        Me.picCanvas = New System.Windows.Forms.PictureBox()
        Me.btnClear = New System.Windows.Forms.RadioButton()
        CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPen
        '
        Me.btnPen.AutoSize = True
        Me.btnPen.Location = New System.Drawing.Point(12, 12)
        Me.btnPen.Name = "btnPen"
        Me.btnPen.Size = New System.Drawing.Size(45, 17)
        Me.btnPen.TabIndex = 0
        Me.btnPen.TabStop = True
        Me.btnPen.Text = "Line"
        Me.btnPen.UseVisualStyleBackColor = True
        '
        'btnRectangle
        '
        Me.btnRectangle.AutoSize = True
        Me.btnRectangle.Location = New System.Drawing.Point(73, 12)
        Me.btnRectangle.Name = "btnRectangle"
        Me.btnRectangle.Size = New System.Drawing.Size(74, 17)
        Me.btnRectangle.TabIndex = 1
        Me.btnRectangle.TabStop = True
        Me.btnRectangle.Text = "Rectangle"
        Me.btnRectangle.UseVisualStyleBackColor = True
        '
        'picCanvas
        '
        Me.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picCanvas.Location = New System.Drawing.Point(12, 35)
        Me.picCanvas.Name = "picCanvas"
        Me.picCanvas.Size = New System.Drawing.Size(776, 403)
        Me.picCanvas.TabIndex = 2
        Me.picCanvas.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.AutoSize = True
        Me.btnClear.Location = New System.Drawing.Point(154, 13)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(49, 17)
        Me.btnClear.TabIndex = 3
        Me.btnClear.TabStop = True
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.picCanvas)
        Me.Controls.Add(Me.btnRectangle)
        Me.Controls.Add(Me.btnPen)
        Me.Name = "Form1"
        Me.Text = "Paint"
        CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPen As RadioButton
    Friend WithEvents btnRectangle As RadioButton
    Friend WithEvents picCanvas As PictureBox
    Friend WithEvents btnClear As RadioButton
End Class
