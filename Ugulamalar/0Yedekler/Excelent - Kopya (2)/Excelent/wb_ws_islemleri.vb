Module wb_ws_islemleri
#Region "ws_islem"
    Sub ws_print_names()
        'test edilmedi
        For i As Integer = 1 To CType(app.Sheets, Excel.Sheets).Count - 1
            CType(app.Cells(i, 1), Excel.Range).Value = CType(app.Sheets(i + 1), Excel.Worksheet).Name
        Next i

    End Sub
    Sub ws_sort_alfabetik()

    End Sub
    Sub ws_tumunu_protect()

    End Sub
    Sub ws_tumunu_unprotect()

    End Sub
    Sub ilki_disi_hide()
        For i = 1 To app.Sheets.Count
            app.Sheets(i).Visible = True
        Next i
        app.Sheets(1).Select()

    End Sub
    Sub tümsayfalarunhide()
        For i = 1 To app.Sheets.Count
            app.Sheets(i).Visible = True
        Next i
        app.Sheets(1).Select()

    End Sub
#End Region
#Region "wb_islem"
    Sub wb_tumunu_saveet()
        For Each wb In app.Workbooks
            wb.save()
        Next wb
    End Sub
    Sub wb_tumunu_kapat()
        Dim s As MsgBoxResult
        s = MsgBox("KAydetmeden kapıycam, tamam mı?", vbYesNo)
        If s = MsgBoxResult.No Then Exit Sub

        For Each wb In app.Workbooks
            wb.close()
        Next wb


        'Dim wb As Workbook

        'cevap = MsgBox("Kapatırken save edeyim mi", vbYesNoCancel)
        'If cevap = vbYes Then
        '    a = True
        'ElseIf cevap = vbNo Then
        '    a = False
        'Else
        '    Exit Sub
        'End If


        'For Each wb In Application.Workbooks
        '    Workbooks(wb.Name).Activate()
        '    If Windows(wb.Name).Visible = True Then
        '        If InStr(ActiveWorkbook.Name, ".") = 0 Then
        '            wb.SaveAs(Filename:=Application.DefaultFilePath & "\" & wb.Name & ".xlsx", _
        '                FileFormat:=Application.DefaultSaveFormat, CreateBackup:=False)
        '            ActiveWindow.Close()
        '        Else
        '            wb.Close(SaveChanges:=a)
        '        End If
        '    End If
        'Next wb
    End Sub
    Sub wb_tumunu_saveet_vekapat()
        For Each wb In app.Workbooks
            wb.close(savechanges:=True)
        Next wb
    End Sub
    Sub wb_tumunu_printal()
        For i = 1 To app.Workbooks.Count
            app.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
            app.ActiveWorkbook.Close()
        Next i
    End Sub
    Sub wb_tumunu_refreshall()
       
    End Sub
    Sub wb_conn_sifre_degistir()
        Dim wb As Workbook
        Dim cn As Excel.WorkbookConnection
        Dim eski As String
        Dim yeni As String
        Dim dosyalar As String
        Dim done As Boolean
        Dim dizi As Object

        Try
            eski = InputBox("Eski şifreyi girin")
            If eski = "" Then Exit Sub
            yeni = InputBox("Yeni şifreyi girin")
            If yeni = "" Then Exit Sub


            dosyalar = ""
            done = False
            For Each wb In app.Workbooks
                If app.Windows(wb.Name).Visible = True Then
                    If wb.Connections.Count > 0 Then
                        For Each cn In wb.Connections
                            If InStr(cn.ODBCConnection.Connection, eski) > 0 Then
                                cn.ODBCConnection.Connection = Replace(cn.ODBCConnection.Connection, eski, yeni)
                                done = True
                            End If
                        Next cn
                        If done = True Then dosyalar = wb.Name & ";" & dosyalar
                    End If
                End If
            Next wb

            dizi = Split(dosyalar, ";")
            MsgBox("ODBC bağlantısı olan dosyalardaki şifre değişim işlemi yapıldı." & vbCrLf & "Değişim işlemi olan dosyalar yeni bir workbook içine yazılacak.. ")
            app.Workbooks.Add()

            app.Range("a1").Select()
            For i = 0 To UBound(dizi) - 1
                app.Cells(i + 1, 1).Value2 = dizi(i)
            Next i

            MsgBox("Şimdi tüm wb'ları save et düğmesin çalıştır")

            Exit Sub

        Catch e As Exception
            MsgBox("Bir hata oluştu, örneğin protectli bir dosyada şifre değiştirmeye çalışıyor olabilirsiniz")
            MsgBox(e.HResult)
        End Try
    End Sub
    Sub pdf_yap()

        '        answer = MsgBox("'C' diskinizde 'pdfyap' isminde bir klaösürünüz var mı?", vbYesNo)
        '        If answer = 6 Then
        '            GoTo ilerle
        '        Else
        '            MsgBox("O ZAMAN O KLASÖRÜ YARATIP TEKRAR ÇALIŞTIR ")
        '            Exit Sub
        '        End If

        'ilerle:

        '        clsm = InputBox("çalışmamın başlığı ne olsun?")

        '        kactane = InputBox("kaç dosya için")

        'basadon:
        '        tip = InputBox("aktif sayfa için 1, tüm dosya için 2 girin")

        '        If tip <> 1 And tip <> 2 Then
        '            MsgBox("sadece 1 veya 2 girin")
        '            GoTo basadon
        '        End If

        '        For i = 1 To kactane

        '            Select Case ActiveWorkbook.FileFormat
        '                Case "-4143", "-4158", 6, 56 'normal xls, txt, csv veya Excel2007deki 97-2003 xls'i mi
        '                    isim = Left(ActiveWorkbook.Name, Len(ActiveWorkbook.Name) - 4)
        '                Case 50, 51, 52 'xlsx, xlsb veya xlsm ise
        '                    isim = Left(ActiveWorkbook.Name, Len(ActiveWorkbook.Name) - 5)
        '                Case Else
        '                    MsgBox("Bu dosya formatı bu makronun çalışması için uygun değil. xls, xlsx, xlsb, xlsm, txt veya csv dosyalarıyla çalışmalısınız")
        '                    Exit Sub
        '            End Select


        '            If tip = 1 Then
        '                ActiveSheet.ExportAsFixedFormat(Type:=xlTypePDF, Filename:= _
        '                    "C:\pdfyap\" & isim & " - " & clsm & ".pdf" _
        '                    , Quality:=xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas _
        '                    :=False, OpenAfterPublish:=False) 'buraya kopyalanacak path yazılır
        '                ActiveWindow.Close()


        '            Else 'yani 2yse, 2 dışındakileri başta eledim
        '                ActiveWorkbook.ExportAsFixedFormat(Type:=xlTypePDF, Filename:= _
        '                    "C:\pdfyap\" & isim & " - " & clsm & ".pdf" _
        '                    , Quality:=xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas _
        '                    :=False, OpenAfterPublish:=False) 'buraya kopyalanacak path yazılır
        '                ActiveWindow.Close()
        '            End If

        '        Next i
    End Sub
#End Region
End Module
