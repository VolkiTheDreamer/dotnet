Imports Healthcare

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Patient As New Healthcare.Patient()
        Patient.FirstName = "Bob"
        MsgBox(Patient.FirstName)
    End Sub
End Class
