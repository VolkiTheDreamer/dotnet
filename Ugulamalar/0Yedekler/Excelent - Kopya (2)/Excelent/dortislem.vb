﻿Module dortislem
    Sub carp(carpan As Integer)

        'Dim secim As Excel.Range = app.Selection
        'Dim ilkdeger As Object = secim.Value2
        'Try
        '    Select Case galleryiitem
        '        Case item1
        '            carpan = 1000000
        '        Case item2
        '            carpan = 1000
        '        Case Else
        '            carpan = CInt(app.InputBox("Kaçla çarpılacak?"))
        '    End Select

        '    For Each h As Excel.Range In app.Selection
        '        If IsNumeric(h.Value) Then h.Value2 = Val(h.Value2) * carpan 'h.value2yi val ile sayıya çevircez ünkü value2 obje döndürüyor
        '    Next h

        '    If MsgBox("İstenmeyen bir sonuç olduysa undo yapılsın mı?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        secim.Value2 = ilkdeger
        '    End If
        'Catch e As Exception
        '    If Not IsNumeric(carpan) Then
        '        MsgBox("Çarpan olarak sayısal bir değer girin lütfen")
        '    Else
        '        MsgBox(e.Message)
        '    End If

        'End Try

    End Sub
End Module
