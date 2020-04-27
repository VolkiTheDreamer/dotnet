Imports System
Module Module1

    Sub Main()
        Dim nulldeger As String = Nothing
        Dim bosdeger As String = String.Empty
        Dim zerolenth As String = ""
        Dim nullconstant As String = CStr(vbNull)
        Dim nullconstant_str As String = vbNullString
        Try
            Console.WriteLine("isnullorempty olarak sroguluyoruz")
            Console.WriteLine("Dim nulldeger As String = Nothing sonucu:" & String.IsNullOrEmpty(nulldeger))
            Console.WriteLine("Dim bosdeger As String = String.Empty sonucu:" & String.IsNullOrEmpty(bosdeger))
            Console.WriteLine("Dim zerolenth As String = """" sonucu:" & String.IsNullOrEmpty(zerolenth))
            Console.WriteLine("Dim nullconstant As String = CStr(vbNull) sonucu:" & String.IsNullOrEmpty(nullconstant))
            Console.WriteLine("Dim nullconstant_str As String = vbNullString sonucu:" & String.IsNullOrEmpty(nullconstant_str))
            Console.ReadLine()

            Console.WriteLine("birbirlerine eişt mi diye srogulyoruz")
            Console.WriteLine(CStr(IIf(nulldeger = bosdeger, "nulldeger=bosdeger", "nulldeger<>bosdeger")))
            Console.WriteLine(CStr(IIf(nulldeger = zerolenth, "nulldeger=zerolenth", "nulldeger<>zerolenth")))
            Console.WriteLine(CStr(IIf(nulldeger = nullconstant, "nulldeger=nullconstant", "nulldeger<>nullconstant")))
            Console.WriteLine(CStr(IIf(nulldeger = nullconstant_str, "nulldeger=nullconstant_str", "nulldeger<>nullconstant_str")))

            Console.WriteLine(CStr(IIf(bosdeger = zerolenth, "bosdeger=zerolenth", "bosdeger<>zerolenth")))
            Console.WriteLine(CStr(IIf(bosdeger = nullconstant, "bosdeger=nullconstant", "bosdeger<>nullconstant")))
            Console.WriteLine(CStr(IIf(bosdeger = nullconstant_str, "bosdeger=nullconstant_str", "bosdeger<>nullconstant_str")))

            Console.WriteLine(CStr(IIf(zerolenth = nullconstant, "zerolenth=nullconstant", "zerolenth<>nullconstant")))
            Console.WriteLine(CStr(IIf(zerolenth = nullconstant_str, "zerolenth=nullconstant_str", "zerolenth<>nullconstant_str")))

            Console.WriteLine(CStr(IIf(nullconstant = nullconstant_str, "nullconstant=nullconstant_str", "nullconstant<>nullconstant_str")))
            Console.ReadLine()

            Console.WriteLine("isnothing ile sorgulyoruz") ' if xxx=Nothing ile aynıdır
            Console.WriteLine("Dim nulldeger As String = Nothing sonucu:" & IsNothing(nulldeger))
            Console.WriteLine("Dim bosdeger As String = String.Empty sonucu:" & IsNothing(bosdeger))
            Console.WriteLine("Dim zerolenth As String = """" sonucu:" & IsNothing(zerolenth))
            Console.WriteLine("Dim nullconstant As String = CStr(vbNull) sonucu:" & IsNothing(nullconstant))
            Console.WriteLine("Dim nullconstant_str As String = vbNullString sonucu:" & IsNothing(nullconstant_str))
            Console.ReadLine()

            Console.WriteLine("zerolength mi diye sroguluyoruz")
            Console.WriteLine("Dim nulldeger As String = Nothing sonucu:" & CStr(IIf(nulldeger = "", "Evet", "Hayır")))
            Console.WriteLine("Dim bosdeger As String = String.Empty sonucu:" & CStr(IIf(bosdeger = "", "Evet", "Hayır")))
            Console.WriteLine("Dim zerolenth As String = """" sonucu:" & CStr(IIf(zerolenth = "", "Evet", "Hayır")))
            Console.WriteLine("Dim nullconstant As String = CStr(vbNull) sonucu:" & CStr(IIf(nullconstant = "", "Evet", "Hayır")))
            Console.WriteLine("Dim nullconstant_str As String = vbNullString sonucu:" & CStr(IIf(nullconstant_str = "", "Evet", "Hayır")))
            Console.ReadLine()

            Console.WriteLine("karakter sayısını yazdırıoyruuz")
            'Console.WriteLine(nulldeger.Length) 'hata
            Console.WriteLine(bosdeger.Length) '0
            Console.WriteLine(zerolenth.Length) '0
            Console.WriteLine(nullconstant.Length) '1
            'Console.WriteLine(nullconstant_str.Length) 'hata
            Console.ReadKey()

        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Sub

End Module
