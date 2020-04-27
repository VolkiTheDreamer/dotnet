Imports Microsoft.Office.Tools.Ribbon
Public Class rbExcelent
#Region "Bölmeler"
    Private Sub btnStandartBol_Click(sender As Object, e As RibbonControlEventArgs) Handles btnStandartBol.Click
        Standart_Bol()
    End Sub
    Private Sub Button4_Click(sender As Object, e As RibbonControlEventArgs) Handles Button4.Click
        coksayfali_bolme()
    End Sub
    Private Sub btnCokSutunluBol_Click(sender As Object, e As RibbonControlEventArgs) Handles btnCokSutunluBol.Click
        cok_kolonlu_bolme()
    End Sub
#End Region
#Region "lookuplar"
    Private Sub btnFiiliYaz_Click(sender As Object, e As RibbonControlEventArgs) Handles btnFiiliYaz.Click
        Call fiiliyaz()
    End Sub
    Private Sub btnNormVarYok_Click(sender As Object, e As RibbonControlEventArgs) Handles btnNormVarYok.Click
        Call normyaz()
    End Sub
    Private Sub DropDown1_SelectionChanged(sender As Object, e As RibbonControlEventArgs) Handles DropDown1.SelectionChanged

        Select Case DropDown1.SelectedItem.Label
            Case "Şube Adı"
                Call subekodundansubeselbilgiyaz(2)
            Case "Bölge Kodu"
                Call subekodundansubeselbilgiyaz(3)
            Case "Bölge Adı"
                Call subekodundansubeselbilgiyaz(4)
            Case "Açılış Tarihi"
                Call subekodundansubeselbilgiyaz(7)
            Case "Açık/Kapalı"
                Call subekodundansubeselbilgiyaz(5)
            Case "Kapanış Tarihi"
                Call subekodundansubeselbilgiyaz(11)
            Case "Tipi"
                Call subekodundansubeselbilgiyaz(6)
            Case "Sınıfı"
                Call subekodundansubeselbilgiyaz(10)
            Case "Türü"
                Call subekodundansubeselbilgiyaz(8)
            Case "İl kodu"
                Call subekodundansubeselbilgiyaz(12)
            Case "Müdür Sicili"
                Call subekodundanpersonelbilgiyaz(3)
            Case "Müdür Adı"
                Call subekodundanpersonelbilgiyaz(4)
            Case Else
                'afafas
        End Select
        DropDown1.SelectedItemIndex = -1

    End Sub
    Private Sub DropDown2_SelectionChanged(sender As Object, e As RibbonControlEventArgs) Handles DropDown2.SelectionChanged
        Select Case DropDown2.SelectedItem.Label
            Case "Ad Soyad"
                Call sicildenyaz(5)
            Case "Çalıştığı Birim Kodu"
                Call sicildenyaz(2)
            Case "Çalıştığı Birim Adı"
                Call sicildenyaz(3)
            Case "Görevi"
                Call sicildenyaz(7)
            Case "Bankaya Giriş Tarihi"
                Call sicildenyaz(10)
            Case "Birime Giriş Tarihi"
                Call sicildenyaz(11)
            Case Else
                'afafas
        End Select
        DropDown2.SelectedItemIndex = -1
    End Sub
    Private Sub DropDown3_SelectionChanged(sender As Object, e As RibbonControlEventArgs) Handles DropDown3.SelectionChanged
        'Bölge Adı
        Select Case DropDown3.SelectedItem.Label
            Case "Bölge Adı"
                Call bolgekodundanyaz(2)
            Case "Bölge Müdürü"
                Call bolgekodundanyaz(4)
            Case "Bireysel+Birebir Satış Ekibi"
                Call bolgekodundanyaz(3)
            Case "Bölge Müdürü+Bireysel+Birebir"
                Call bolgekodundanyaz(5)
            Case "Bireysel Satış Ekibi"
                Call bolgekodundanyaz(6)
            Case "Birebir Satış Ekibi"
                Call bolgekodundanyaz(7)
            Case "KOBİ Satış Ekibi"
                Call bolgekodundanyaz(8)
            Case Else
                Call bolgekodundanyaz(9)
        End Select

        DropDown3.SelectedItemIndex = -1

    End Sub
#End Region
#Region "caseler"
    Private Sub btnCaseBuyuk_Click(sender As Object, e As RibbonControlEventArgs)
        Secilenlerin_tumharfini_buyukyap()
    End Sub
    Private Sub btnCaseKucuk_Click(sender As Object, e As RibbonControlEventArgs)
        Secilenlerin_tumharfini_kucukyap()
    End Sub
    Private Sub btnCaseProper_Click(sender As Object, e As RibbonControlEventArgs)
        Secilenlerin_ilkharfini_buyukyap()
    End Sub
#End Region

    Private Sub Button7_Click(sender As Object, e As RibbonControlEventArgs) Handles Button7.Click
        coklu_rank()
    End Sub

    Private Sub grpFrequentFile_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpFrequentFile.DialogLauncherClick
        Dim fff As New frmFrequentFile 'fff=form frequent file'n kıslatması
        fff.ShowDialog()
        Me.btnFreqDosya1.Label = fff.txtDosya1KisaAd.Text
        Me.btnFreqDosya2.Label = fff.txtDosya2KisaAd.Text
        Me.btnFreqDosya3.Label = fff.txtDosya3KisaAd.Text
        Me.btnFreqDosya4.Label = fff.txtDosya4KisaAd.Text
        Me.btnFreqDosya5.Label = fff.txtDosya5KisaAd.Text
        'MsgBox("buna tıklandıgında bi form açılsın ve, user burya istediği dosyaları ekesin ve my.settings ayarı olsun.")
        'text boxlar olsun, yeni düğme ekle butonu olsun, tıklayınca yeni textbox eklenin forma, menüye de label eklensin.
        'textbox ve labeller dizi olsun, birbirleriyle dizi ndeksiyle eşleşsinler
        'my setting ayarı olsun
    End Sub
    Dim btnFreq() As RibbonButton
    Private Sub rbExcelent_Load(sender As Object, e As Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs) Handles MyBase.Load
        'Dim fff2 As New frmFrequentFile
        'formlardan(whic is a class) farklı olarak ribbon bir interface oldugu için class gibi dizileştirilkren new kullanılmaz
        btnFreq = {btnFreqDosya1, btnFreqDosya2, btnFreqDosya3, btnFreqDosya4, btnFreqDosya5}

        With My.Settings
            If .btnFrequentFile Is Nothing Then .btnFrequentFile = New System.Collections.Specialized.StringCollection
            For i = 0 To btnFreq.Length - 1
                If .btnFrequentFile.Count <= i Then .btnFrequentFile.Add("")
                btnFreq(i).Label = .btnFrequentFile(i)
            Next
        End With

    End Sub

    Private Sub rbExcelent_Close(sender As Object, e As EventArgs) Handles MyBase.Close

        For i = 0 To btnFreq.Length - 1
            My.Settings.btnFrequentFile(i) = btnFreq(i).Label
        Next
        My.Settings.Save()
    End Sub

    Private Sub Group2_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles Group2.DialogLauncherClick
        Dim fsp As New frmSubelerPersonel 'fff=form frequent file'n kıslatması
        fsp.ShowDialog()

    End Sub

    Private Sub btnSayfaBirlestir_Click(sender As Object, e As RibbonControlEventArgs) Handles btnSayfaBirlestir.Click
        Call sheetleri_birlestir()
    End Sub

    Private Sub Button8_Click(sender As Object, e As RibbonControlEventArgs) Handles Button8.Click
        Call wb_birlestir()
    End Sub

    Private Sub Button5_Click(sender As Object, e As RibbonControlEventArgs) Handles Button5.Click
        yanyanayaz()
    End Sub

    Private Sub btnPivotOtodoldur_Click(sender As Object, e As RibbonControlEventArgs) Handles btnPivotOtodoldur.Click
        pivottaotofill()
    End Sub

    Private Sub Button11_Click(sender As Object, e As RibbonControlEventArgs) Handles Button11.Click
        batchmailgonder()
    End Sub

    Private Sub Button12_Click(sender As Object, e As RibbonControlEventArgs)
        app.ActiveCell.FormulaR1C1 = "=superconcat()"
        fonksiyonSihirbaz()
    End Sub
    Sub fonksiyonSihirbaz()
        app.ActiveCell.FunctionWizard()
    End Sub
 
    Private Sub Button1_Click(sender As Object, e As RibbonControlEventArgs)

    End Sub

    Private Sub Button9_Click(sender As Object, e As RibbonControlEventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As RibbonControlEventArgs) Handles Button6.Click
        listeyi_ayrıayrı_altaltayaz()
    End Sub

    Private Sub Button3_Click(sender As Object, e As RibbonControlEventArgs) Handles Button3.Click
        MsgBox("Yapım aşamasında, bir soraki update ile gelecek.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As RibbonControlEventArgs) Handles Button2.Click
        ters_pivot()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As RibbonControlEventArgs)
        'sheetbirleştirme2
        'MsgBox("farklı workbooklardaki sayfaları tek workbookta birleştiri, aynı isimli olmaması lazım")
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As RibbonControlEventArgs)

    End Sub

    Private Sub Button12_Click_1(sender As Object, e As RibbonControlEventArgs) Handles Button12.Click
        Dim fr As New frmAbout
        fr.ShowDialog()
    End Sub

    Private Sub Button13_Click(sender As Object, e As RibbonControlEventArgs) Handles Button13.Click
        'daha sonra direkt açsın.
        MsgBox("Internet sitemizden kılavuzu indirebilirsiniz.")
    End Sub
End Class
