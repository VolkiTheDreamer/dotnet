Public Class Form1

    Dim FirstNumber As Long
    Dim Operation As String
    
    Private Sub n1_Click(sender As Object, e As EventArgs) Handles n1.Click
        LCD.Text = LCD.Text & "1"
    End Sub

    Private Sub n2_Click(sender As Object, e As EventArgs) Handles n2.Click
        LCD.Text = LCD.Text & "2"
    End Sub

    Private Sub n3_Click(sender As Object, e As EventArgs) Handles n3.Click
        LCD.Text = LCD.Text & "3"
    End Sub

    Private Sub n4_Click(sender As Object, e As EventArgs) Handles n4.Click
        LCD.Text = LCD.Text & "4"
    End Sub

    Private Sub n5_Click(sender As Object, e As EventArgs) Handles n5.Click
        LCD.Text = LCD.Text & "5"
    End Sub

    Private Sub n6_Click(sender As Object, e As EventArgs) Handles n6.Click
        LCD.Text = LCD.Text & "6"
    End Sub

    Private Sub n7_Click(sender As Object, e As EventArgs) Handles n7.Click
        LCD.Text = LCD.Text & "7"
    End Sub

    Private Sub n8_Click(sender As Object, e As EventArgs) Handles n8.Click
        LCD.Text = LCD.Text & "8"
    End Sub

    Private Sub n9_Click(sender As Object, e As EventArgs) Handles n9.Click
        LCD.Text = LCD.Text & "9"
    End Sub

    Private Sub n0_Click(sender As Object, e As EventArgs) Handles n0.Click
        LCD.Text = LCD.Text & "0"
    End Sub

    Private Sub bClr_Click(sender As Object, e As EventArgs) Handles bClr.Click
        LCD.Text = ""
    End Sub

    Private Sub btop_Click(sender As Object, e As EventArgs) Handles btop.Click
     
        FirstNumber = LCD.Text
        LCD.Text = ""
        Operation = "+"
    End Sub

    Private Sub bcik_Click(sender As Object, e As EventArgs) Handles bcik.Click
    
        FirstNumber = LCD.Text
        LCD.Text = ""
        Operation = "-"
    End Sub

    Private Sub bcarp_Click(sender As Object, e As EventArgs) Handles bcarp.Click

        FirstNumber = LCD.Text
        LCD.Text = ""
        Operation = "*"
    End Sub

    Private Sub bbol_Click(sender As Object, e As EventArgs) Handles bbol.Click


        FirstNumber = LCD.Text
        LCD.Text = ""
        Operation = "/"
    End Sub

    Private Sub besit_Click(sender As Object, e As EventArgs) Handles besit.Click

        Dim SecondNumber As Long
        Dim Result As Long

        SecondNumber = LCD.Text

        If Operation = "+" Then
            Result = FirstNumber + SecondNumber
        ElseIf Operation = "-" Then
            Result = FirstNumber - SecondNumber
        ElseIf Operation = "*" Then
            Result = FirstNumber * SecondNumber
        ElseIf Operation = "/" Then
            Result = FirstNumber / SecondNumber
        End If
        FirstNumber = Result
        LCD.Text = Result
    End Sub
End Class
