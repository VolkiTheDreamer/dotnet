Module Module1
    Sub Main()
        Dim obj1 As New Bina() ' calls parameterless constructor
        Dim obj2 As New Bina(50, 60, 70,'05.05.2015') ' calls parameterized constructor
    End Sub
    Public Class Bina
        Dim kat As Integer
        Dim yukseklik As Double
        Dim genislik As Double
        Dim en As Double
        Dim yapilma_tarihi As Date

        Public Sub New()
            yukseklik = 100
            genislik = 200
            en = 10
            yapilma_tarihi = Date.Today.Date
        End Sub
        Public Sub New(ByVal ilk_yukseklik, ByVal ilk_genislik, ByVal ilk_en, ByVal ilk_tarih)
            yukseklik = ilk_yukseklik
            genislik = ilk_genislik
            en = ilk_en
            yapilma_tarihi = ilk_tarih
        End Sub
    End Class
End Module