'Joshua Makuch
'RCET0265
'Spring 2023
'Etch-A-Sketch
'https://github.com/JoshuaMakuch/EtchASketch.git

Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports Microsoft.VisualBasic.Devices

Public Class EtchASketchForm
    Dim draw As Boolean
    Dim g As Graphics = Me.CreateGraphics
    Dim myPen As Pen = New Pen(Color.Black)
    Dim bmp As Bitmap
    Dim mouX As Integer
    Dim mouY As Integer

    'On Form Load
    Private Sub EtchASketchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Populate picture box image property
        bmp = New Bitmap(PBDrawing.Width, PBDrawing.Height) 'Sets the bitmap to be the size of the picture box
        PBDrawing.Image = bmp
    End Sub

    'THIS IS THE MAIN DRAWING CODE

    'When the user presses down their mouse INSIDE the picture box
    Private Sub PBDrawing_MouseDown(sender As Object, e As MouseEventArgs) Handles PBDrawing.MouseDown
        'Only if left click is pressed
        If e.Button = Windows.Forms.MouseButtons.Left Then
            draw = True
            'Sets initial mouse coordinates
            mouX = e.X
            mouY = e.Y
        End If
    End Sub

    'When the user moves their mouse and the mouse is pressed down INSIDE the picture box
    Private Sub PBDrawing_MouseMove(sender As Object, e As MouseEventArgs) Handles PBDrawing.MouseMove
        If draw Then
            Using g As Graphics = Graphics.FromImage(PBDrawing.Image)
                g.DrawLine(myPen, mouX, mouY, e.X, e.Y)
                'Pulls mouse coordinates to ensure a line is created no matter how fast the user moves
                mouX = e.X
                mouY = e.Y
            End Using
            PBDrawing.Refresh()
        End If
    End Sub

    'When the user lets go of their mouse
    Private Sub PBDrawing_MouseUp(sender As Object, e As MouseEventArgs) Handles PBDrawing.MouseUp
        draw = False
    End Sub



    'Exit Button
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem1.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    'Sets the color of the drawn line, Color Button
    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click, SelectColorToolStripMenuItem1.Click, SelectColorToolStripMenuItem.Click
        'Opens a window dialog to be able to change the color as desired
        Dim myDialog As New ColorDialog()
        If (myDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            myPen.Color = myDialog.Color
        End If

    End Sub
    'Clear Button
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click, ClearToolStripMenuItem1.Click
        bmp = New Bitmap(PBDrawing.Width, PBDrawing.Height) 'Sets the bitmap to be the size of the picture box
        PBDrawing.Image = bmp
    End Sub
    'About Button
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click, AboutToolStripMenuItem.Click
        MessageBox.Show("This program is a code based Etch-A-Sketch made by Joshua Makuch.
The select color button allows you to change the color of the pen you're writing with.
The clear button clears the Etch-A-Sketch.
The select waveform button draws a sine, cosine, and cotangent figure and clears the Etch-A-Sketch.
Finally, the exit button closes the program.", "About", MessageBoxButtons.OK)
    End Sub
    'Draw Waveform Button
    Private Sub DrawWaveformButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformButton.Click

    End Sub



    'MAKE SURE TO BIND THE KEYS TO THEIR APPROPRIATE EFFECTS


End Class
