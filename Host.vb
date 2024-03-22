Imports System.Diagnostics.Contracts

Public Class Host
    Private possible As New List(Of Integer)
    Private Sub Host_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetGame()
    End Sub
    Private Sub ResetNumbers()
        possible.Clear()
        lblCurrentNum.Text = ""
        For i As Integer = 0 To 4
            Dim startpoint = (15 * i)
            For k As Integer = 1 To 15
                possible.Add(startpoint + k)
            Next
        Next
    End Sub
    Private Sub btnDraw_Click(sender As Object, e As EventArgs) Handles btnDraw.Click
        If possible.Count = 0 Then
            ResetNumbers()
        End If
        Dim rand As New Random
        Dim srand As Integer = rand.Next(0, possible.Count)
        lblCurrentNum.Text = GetLetterWithNum(possible(srand))
        lstPrevious.Items.Insert(0, lblCurrentNum.Text)
        possible.RemoveAt(srand)
    End Sub
    Private Function GetLetterWithNum(num As Integer) As String
        Dim str As String = "?"
        Select Case num
            Case Is <= 15
                str = $"B {num}"
            Case Is <= 30
                str = $"I {num}"
            Case Is <= 45
                str = $"N {num}"
            Case Is <= 60
                str = $"G {num}"
            Case Is <= 75
                str = $"O {num}"
        End Select
        Return str
    End Function
    Private Sub ResetGame()
        ResetNumbers()
        lstPrevious.Items.Clear()
    End Sub

    Private Sub ReturnToMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToMenuToolStripMenuItem.Click
        Form1.Show()
        board.Close()
        Me.Close()
    End Sub

    Private Sub ResetToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        ResetGame()
    End Sub
End Class