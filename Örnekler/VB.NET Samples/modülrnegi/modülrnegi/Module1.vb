Module Module1
    Sub Main()
        Dim obj1 As New Bina() ' calls parameterless constructor
        Dim obj2 As New Bina(10, 50, 60, 70, "05.06.2015") ' calls parameterized constructor
        Console.WriteLine("1.nesnenin özellikleri yazdırılıyor:")
        obj1.ozellikgoster()
        Console.WriteLine("Hacim=: {0}", obj1.hacimbul())

        Console.WriteLine("2.nesnenin özellikleri yazdırılıyor:")
        obj2.ozellikgoster()
        Console.WriteLine("Hacim=: {0}", obj2.hacimbul())

        Console.ReadKey()

    End Sub
    Public Class Bina
        Dim kat As Integer
        Dim yukseklik As Double
        Dim genislik As Double
        Dim en As Double
        Dim yapilma_tarihi As Date
        Public Sub New()
            kat = 5
            yukseklik = 100
            genislik = 200
            en = 10
            yapilma_tarihi = Date.Today.Date
        End Sub
        Public Sub New(ByVal ilk_kat, ByVal ilk_yukseklik, ByVal ilk_genislik, ByVal ilk_en, ByVal ilk_tarih)
            kat = ilk_kat
            yukseklik = ilk_yukseklik
            genislik = ilk_genislik
            en = ilk_en
            yapilma_tarihi = Date.Parse(ilk_tarih)
            'yapilma_tarihi = ilk_tarih
        End Sub
        Public Function hacimbul() As Double
            Return kat * yukseklik * genislik * en
        End Function
        Public Sub ozellikgoster()
            Console.WriteLine("En: {0}", en)
            Console.WriteLine("Ykseklkik: {0}", yukseklik)
            Console.WriteLine("GEnişlk: {0}", genislik)
            Console.WriteLine("kat sayısı: {0}", kat)
            Console.WriteLine("inşa tarhii: {0}", yapilma_tarihi)
        End Sub
    End Class
End Module