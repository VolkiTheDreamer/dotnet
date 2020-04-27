Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Label1.Text = "bu bi deneme şlsksdkşf sdfsdkfşlsadkfş sadfdskfldskfsa sdfjs"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Opacity += 0.01
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
            Beep()
        End If
    End Sub
End Class
