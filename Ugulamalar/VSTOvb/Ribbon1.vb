Imports Microsoft.Office.Tools.Ribbon

Public Class Ribbon1
    'Throughout this article, you'll see many uses of the DirectCast and CType methods. 
    'The reason For this Is that the sample project has its Option Strict setting On—this 
    'means that Visual Basic .NET requires strict type conversions. Many Excel methods And 
    'properties Return Object types Or rely On late binding: For example, the Application.
    'ActiveSheet Property returns an Object, As opposed To a Worksheet, As you might expect. 
    'Therefore, To be As rigorous about conversions As possible, the sample has enabled 
    'Option Strict On, And Handles Each type conversion explicitly. (Without Using Option Strict 
    'In Visual Basic .NET, it's possible that you'll write code that compiles fine, but fails at 
    'run time. That's the point of Option Strict—it makes it much less likely that an invalid 
    ''conversion at run time will cause an exception.) If you're a C# developer reading this document, 
    'you'll likely appreciate this decision.
    Private Sub Ribbon1_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As RibbonControlEventArgs) Handles Button1.Click
        Dim frm1 As New Form1
        frm1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As RibbonControlEventArgs) Handles Button2.Click
        Dim wb As Excel.Workbook = Globals.ThisAddIn.Application.Workbooks.Add()
    End Sub

    Private Sub Button3_Click(sender As Object, e As RibbonControlEventArgs) Handles Button3.Click
        app.Workbooks.Open("E:\OneDrive\Uygulama Geliştirme\web sitelerim\Yeni Efendi\Ornek_dosyalar\CF.xlsx")
        Dim col As Excel.Range = app.Columns("A:A")
        MsgBox(col.Address)
    End Sub

    Private Sub Button4_Click(sender As Object, e As RibbonControlEventArgs) Handles Button4.Click
        'Dim hucre As Excel.Range = CType(app.ActiveCell, Excel.Range)
        'Dim deger As Double = hucre.Value2
        'MsgBox(hucre.Address + " adresindeki hucrenin değeri:" + deger.ToString())
        Try
            Dim hucre As Excel.Range = app.ActiveCell '''activecell yerine selection
            Dim deger As Double = hucre.Value2
            MsgBox(hucre.Address + " adresindeki hucrenin değeri:" + deger.ToString())
        Catch ex As NullReferenceException
            '
        Catch ex As Exception
            '
        End Try
    End Sub
End Class
