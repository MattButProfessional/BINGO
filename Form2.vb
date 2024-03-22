Imports System.IO

Public Class board
    Private Sub board_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetBoard()
        BingoTop()
    End Sub
    Private Sub ResetBoard()
        pnlBoard.Controls.Clear()
        Dim btnWidth As Integer = pnlBoard.Width / 5
        Dim btnHeight As Integer = pnlBoard.Height / 5
        Dim rand As New Random()
        For i As Integer = 0 To 4
            Dim startpoint = (15 * i)
            Dim possible As New List(Of Integer)
            For k As Integer = 1 To 15
                possible.Add(startpoint + k)
            Next
            For j As Integer = 0 To 4
                Dim index As Integer = rand.Next(0, possible.Count)
                Dim btn As New Button With {
                    .Text = possible(index).ToString,
                    .Font = New Font("Segoe UI", 40, FontStyle.Regular),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(btnWidth * i, btnHeight * j),
                    .Width = btnWidth,
                    .Height = btnHeight
                }
                If i = 2 AndAlso j = 2 Then
                    btn.Text = "Free space"
                    btn.Font = New Font("Segoe UI", 10, FontStyle.Regular)
                    btn.BackColor = Color.Yellow
                Else
                    AddHandler btn.Click, AddressOf HandleButtonClick
                End If
                pnlBoard.Controls.Add(btn)
                possible.RemoveAt(index)
            Next
        Next
    End Sub
    Sub HandleButtonClick(sender As Button, e As EventArgs)
        If sender.BackColor = Color.Yellow Then
            sender.BackColor = Color.White
        Else
            sender.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub BingoTop()
        Dim letters() As String = {"B", "I", "N", "G", "O"}
        Dim lblWidth As Integer = pnlTop.Width / 5
        Dim lblHeight As Integer = pnlTop.Height
        For i As Integer = 0 To 4
            Dim lbl As New Label With {
                .Text = letters(i),
                .Font = New Font("Segoe UI", 40, FontStyle.Regular),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Location = New Point(lblWidth * i, 0),
                .Width = lblWidth,
                .Height = lblHeight
                }
            pnlTop.Controls.Add(lbl)
        Next
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        ResetBoard()
    End Sub

    Private Sub ReturnToMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToMenuToolStripMenuItem.Click
        Form1.Show()
        Host.Close()
        Me.Close()
    End Sub
End Class