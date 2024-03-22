Public Class Form1
    Private Sub btnHost_Click(sender As Object, e As EventArgs) Handles btnHost.Click
        Host.Show()
        Me.Close()
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        board.Show()
        Me.Close()
    End Sub

    Private Sub btnBoth_Click(sender As Object, e As EventArgs) Handles btnBoth.Click
        Host.Show()
        board.Show()
        Me.Close()
    End Sub
End Class
