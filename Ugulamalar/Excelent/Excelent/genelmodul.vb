﻿Module genelmodul
    Public app As Excel.Application = Globals.ThisAddIn.Application
    'BİLGİ:modül seviysineki variableler tüm sublarda geçerli olur, public de yaparsan tüm namespace içinde yani bu çalışmad her yerde kullanılır
    Sub app_aksiyon(ap As Excel.Application, ByVal giriscikis As String)
        If giriscikis = "Giriş" Then
            ap.DisplayAlerts = False
            ap.ScreenUpdating = False
            'ap.Calculation = Excel.XlCalculation.xlCalculationManual 'bazı modüllerde vlookup falan gibi açık olması lazım
            ap.StatusBar = "İşlem yapılıyor. Lütfen Bekleyiniz..."
        Else
            ap.DisplayAlerts = True
            ap.ScreenUpdating = True
            'ap.Calculation = Excel.XlCalculation.xlCalculationAutomatic
            ap.StatusBar = ""
        End If
    End Sub
    Function DosyaExtension(ap As Excel.Application, wb As Excel.Workbook) As String
        If CDbl(ap.Version) < 12 Then 'excel 2003 veya önceisyse
            DosyaExtension = "xls"
        Else
            Select Case wb.FileFormat
                Case Excel.XlFileFormat.xlExcel8 ' xlexcel8=56 olur ki, 2007 ve sorasındaki enumlardır, 
                    'xlworkbooknormal=-4143 ise 2003 ve öncesinden anlaılıdır, ama biz zaten versiyon
                    'ile onu ele aldık, o yüzden gerek kalmadı
                    'xlexcel8 ile xls dosyasıı olup olmadıgna bakıyoruz
                    DosyaExtension = Right(wb.Name, 3)
                Case Else
                    'Case 50(xlExcel12), 51(xlOpenXMLWorkbook), 52(xlOpenXMLWorkbookMacroEnabled)
                    'sırayla xlsb, xlsx veya xlsm ise
                    DosyaExtension = Right(wb.Name, 4) 'niye direkt xlsx demiyoruz, çünkü xlsm veya xlsb de olabilr
            End Select
        End If
    End Function
    ' Function RangetoHTML(rng As Range)
    '    ' Changed by Ron de Bruin 28-Oct-2006
    '    ' Working in Office 2000-2013
    '    Dim fso As Object
    '    Dim ts As Object
    '    Dim TempFile As String
    '    Dim TempWB As Workbook

    '    TempFile = Environ$("temp") & "/" & Format(Now, "dd-mm-yy h-mm-ss") & ".htm"

    '    'Copy the range and create a new workbook to past the data in
    '    rng.Copy()
    '    TempWB = Workbooks.Add(1)
    '    With TempWB.Sheets(1)
    '        .Cells(1).PasteSpecial Paste:=8
    '        .Cells(1).PasteSpecial(xlPasteValues, , False, False)
    '        .Cells(1).PasteSpecial(xlPasteFormats, , False, False)
    '        .Cells(1).Select()
    '        Application.CutCopyMode = False
    '        On Error Resume Next
    '        .DrawingObjects.Visible = True
    '        .DrawingObjects.Delete()
    '        On Error GoTo 0
    '    End With

    '    'Publish the sheet to a htm file
    '    With TempWB.PublishObjects.Add( _
    '         SourceType:=xlSourceRange, _
    '         Filename:=TempFile, _
    '         Sheet:=TempWB.Sheets(1).Name, _
    '         Source:=TempWB.Sheets(1).UsedRange.Address, _
    '         HtmlType:=xlHtmlStatic)
    '        .Publish(True)
    '    End With

    '    'Read all data from the htm file into RangetoHTML
    '    fso = CreateObject("Scripting.FileSystemObject")
    '    ts = fso.GetFile(TempFile).OpenAsTextStream(1, -2)
    '    RangetoHTML = ts.ReadAll
    '    ts.Close()
    '    RangetoHTML = Replace(RangetoHTML, "align=center x:publishsource=", _
    '                          "align=left x:publishsource=")

    '    'Close TempWB
    '    TempWB.Close savechanges:=False

    '    'Delete the htm file we used in this function
    '    Kill TempFile

    '    ts = Nothing
    '    fso = Nothing
    '    TempWB = Nothing
    'End Function
End Module
