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
        draw = True
        'Sets initial mouse coordinates
        mouX = e.X
        mouY = e.Y
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
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
    'Exit Menu Button
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    'Exit Context Menu Button
    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub
    'Sets the color of the drawn line, Color Button
    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click
        'Opens a window dialog to be able to change the color as desired
        Dim myDialog As New ColorDialog()
        If (myDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            myPen.Color = myDialog.Color
        End If

    End Sub
    'Color Menu Button
    Private Sub SelectColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click
        SelectColorButton_Click(sender, e)
    End Sub
    'Color Context Menu Button
    Private Sub SelectColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem1.Click
        SelectColorButton_Click(sender, e)
    End Sub
    'Clear Button
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        bmp = New Bitmap(PBDrawing.Width, PBDrawing.Height) 'Sets the bitmap to be the size of the picture box
        PBDrawing.Image = bmp
    End Sub
    'Clear Menu Button
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ClearButton_Click(sender, e)
    End Sub
    'Clear Context Menu Button
    Private Sub ClearToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem1.Click
        ClearButton_Click(sender, e)
    End Sub
End Class
