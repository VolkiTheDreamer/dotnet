Public Class Personel
    Public Name As String
    Public Sicil As Integer


    Friend Sub BilgileriGetir()
        Dim localdegisken As Integer
        Debug.Print(Name + Sicil.ToString())
    End Sub
End Class
Public Class Test
    Sub Olustur()
        Dim p As New Personel()
        p.Name = "volkan"
        p.Sicil = 123
        p.BilgileriGetir()
    End Sub


End Class
