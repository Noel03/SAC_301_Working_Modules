Public Class Form1
    Dim mMouseDown As Boolean
    Dim X1, Y1 As Integer
    Dim oPen As Pen
    Dim g As Graphics
    Dim boolLine As Boolean
    '----------------------------------------------------------
    'Form1_Load
    '   Loads the form and declares the graphics to the canvas
    '----------------------------------------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oPen = New Pen(Color.Black) 'Makes the pen black
        g = Me.picCanvas.CreateGraphics 'Sets up the graphics
    End Sub
    '-----------------------------------------------------
    'MouseDownEvent
    '   When the mouse is pressed it starts to draw a line
    '   or rectangle
    '-----------------------------------------------------
    Private Sub MouseDownEvent(s As Object, e As MouseEventArgs) Handles picCanvas.MouseDown
        If e.Button = MouseButtons.Left Then 'If user presses left click then
            If boolLine = True Then 'If the boolTest is true
                mMouseDown = True 'Sets mMouseDown as true
                X1 = e.X 'Current position is now the previous
                Y1 = e.Y
                g.DrawLine(oPen, X1, Y1, e.X, e.Y) 'Draws from previous to current position
            End If
            If boolLine = False Then 'If the boolTest is false
                g.DrawRectangle(oPen, X1, Y1, e.X - X1, e.Y - Y1) 'Draws from previous to current position
                X1 = e.X 'Current position is now the previous
                Y1 = e.Y
            End If
        End If
    End Sub
    '-----------------------------------------------------
    'MouseMoveEvent
    '   When the mouse is moved and mouse is pressed it
    '   draws a line or rectangle
    '-----------------------------------------------------
    Private Sub MouseMoveEvent(s As Object, e As MouseEventArgs) Handles picCanvas.MouseMove
        If mMouseDown Then 'If mMouseDown is true
            If boolLine = True Then 'If the boolTest is true
                g.DrawLine(oPen, X1, Y1, e.X, e.Y) 'Draws from previous to current position
                X1 = e.X 'Current position is now the previous
                Y1 = e.Y
                If boolLine = False Then 'If the boolTest is false


                    g.DrawRectangle(oPen, X1, Y1, e.X - X1, e.Y - Y1) 'Draws from previous to current position
                    X1 = e.X 'Current position is now the previous
                    Y1 = e.Y
                End If
            End If
        End If
    End Sub
    '---------------------------------------------------------
    'MouseUPEvent
    '   When the mouse not pressed it sets mMouseDown as false
    '---------------------------------------------------------
    Private Sub MouseUpEvent(s As Object, e As MouseEventArgs) Handles picCanvas.MouseUp
        mMouseDown = False
    End Sub
    '---------------------------------------------------------
    'BtnPen_CheckedChanged
    '   When click it sets boolLine as True to be used in
    '   the other subroutines
    '---------------------------------------------------------
    Private Sub BtnPen_CheckedChanged(sender As Object, e As EventArgs) Handles btnPen.CheckedChanged
        boolLine = True

    End Sub
    '---------------------------------------------------------
    'BtnRectangle_CheckedChanged
    '   When click it sets boolLine as False to be used in
    '   the other subroutines
    '---------------------------------------------------------
    Private Sub BtnRectangle_CheckedChanged(sender As Object, e As EventArgs) Handles btnRectangle.CheckedChanged
        boolLine = False
    End Sub
    '---------------------------------------------------------
    'BtnClear_CheckedChanged
    '   When click it sets clears everything
    '---------------------------------------------------------
    Private Sub BtnClear_CheckedChanged(sender As Object, e As EventArgs) Handles btnClear.CheckedChanged
        g.Clear(Color.White)
    End Sub


End Class
