Partial Class rbExcelent
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim RibbonDialogLauncherImpl1 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
        Dim RibbonDropDownItemImpl1 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl2 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl3 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl4 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl5 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl6 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl7 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl8 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl9 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl10 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl11 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl12 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl13 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl14 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl15 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl16 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl17 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl18 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl19 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl20 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl21 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl22 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl23 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl24 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl25 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl26 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl27 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl28 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDropDownItemImpl29 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Dim RibbonDialogLauncherImpl2 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
        Dim RibbonDialogLauncherImpl3 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
        Me.Tab1 = Me.Factory.CreateRibbonTab
        Me.Group1 = Me.Factory.CreateRibbonGroup
        Me.Separator1 = Me.Factory.CreateRibbonSeparator
        Me.grpMail = Me.Factory.CreateRibbonGroup
        Me.Group2 = Me.Factory.CreateRibbonGroup
        Me.Separator6 = Me.Factory.CreateRibbonSeparator
        Me.DropDown2 = Me.Factory.CreateRibbonDropDown
        Me.DropDown1 = Me.Factory.CreateRibbonDropDown
        Me.DropDown3 = Me.Factory.CreateRibbonDropDown
        Me.Group6 = Me.Factory.CreateRibbonGroup
        Me.Group4 = Me.Factory.CreateRibbonGroup
        Me.Box1 = Me.Factory.CreateRibbonBox
        Me.Separator3 = Me.Factory.CreateRibbonSeparator
        Me.Box2 = Me.Factory.CreateRibbonBox
        Me.grpFrequentFile = Me.Factory.CreateRibbonGroup
        Me.grpWindows = Me.Factory.CreateRibbonGroup
        Me.Box3 = Me.Factory.CreateRibbonBox
        Me.Group3 = Me.Factory.CreateRibbonGroup
        Me.btnStandartBol = Me.Factory.CreateRibbonButton
        Me.btnCokSutunluBol = Me.Factory.CreateRibbonButton
        Me.Button4 = Me.Factory.CreateRibbonButton
        Me.Button8 = Me.Factory.CreateRibbonButton
        Me.btnSayfaBirlestir = Me.Factory.CreateRibbonButton
        Me.Button11 = Me.Factory.CreateRibbonButton
        Me.mnAdetYaz = Me.Factory.CreateRibbonMenu
        Me.btnFiiliYaz = Me.Factory.CreateRibbonButton
        Me.btnNormVarYok = Me.Factory.CreateRibbonButton
        Me.mnWB = Me.Factory.CreateRibbonMenu
        Me.Button1 = Me.Factory.CreateRibbonButton
        Me.Button9 = Me.Factory.CreateRibbonButton
        Me.Button10 = Me.Factory.CreateRibbonButton
        Me.Button14 = Me.Factory.CreateRibbonButton
        Me.Button15 = Me.Factory.CreateRibbonButton
        Me.Button29 = Me.Factory.CreateRibbonButton
        Me.Button30 = Me.Factory.CreateRibbonButton
        Me.Button31 = Me.Factory.CreateRibbonButton
        Me.mnWS = Me.Factory.CreateRibbonMenu
        Me.Button16 = Me.Factory.CreateRibbonButton
        Me.Button17 = Me.Factory.CreateRibbonButton
        Me.Button18 = Me.Factory.CreateRibbonButton
        Me.Button19 = Me.Factory.CreateRibbonButton
        Me.btnPivotOtodoldur = Me.Factory.CreateRibbonButton
        Me.Button2 = Me.Factory.CreateRibbonButton
        Me.Button3 = Me.Factory.CreateRibbonButton
        Me.Button5 = Me.Factory.CreateRibbonButton
        Me.Button6 = Me.Factory.CreateRibbonButton
        Me.Button7 = Me.Factory.CreateRibbonButton
        Me.mnFrequentFile = Me.Factory.CreateRibbonMenu
        Me.btnFreqDosya1 = Me.Factory.CreateRibbonButton
        Me.btnFreqDosya2 = Me.Factory.CreateRibbonButton
        Me.btnFreqDosya3 = Me.Factory.CreateRibbonButton
        Me.btnFreqDosya4 = Me.Factory.CreateRibbonButton
        Me.btnFreqDosya5 = Me.Factory.CreateRibbonButton
        Me.mnuFileFolder = Me.Factory.CreateRibbonMenu
        Me.Button20 = Me.Factory.CreateRibbonButton
        Me.Button21 = Me.Factory.CreateRibbonButton
        Me.Button22 = Me.Factory.CreateRibbonButton
        Me.Button23 = Me.Factory.CreateRibbonButton
        Me.Button24 = Me.Factory.CreateRibbonButton
        Me.mnuDiger = Me.Factory.CreateRibbonMenu
        Me.Button25 = Me.Factory.CreateRibbonButton
        Me.Button26 = Me.Factory.CreateRibbonButton
        Me.Button27 = Me.Factory.CreateRibbonButton
        Me.Button28 = Me.Factory.CreateRibbonButton
        Me.Menu1 = Me.Factory.CreateRibbonMenu
        Me.Button12 = Me.Factory.CreateRibbonButton
        Me.Button13 = Me.Factory.CreateRibbonButton
        Me.Tab1.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.grpMail.SuspendLayout()
        Me.Group2.SuspendLayout()
        Me.Group6.SuspendLayout()
        Me.Group4.SuspendLayout()
        Me.Box1.SuspendLayout()
        Me.Box2.SuspendLayout()
        Me.grpFrequentFile.SuspendLayout()
        Me.grpWindows.SuspendLayout()
        Me.Box3.SuspendLayout()
        Me.Group3.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.Groups.Add(Me.Group1)
        Me.Tab1.Groups.Add(Me.grpMail)
        Me.Tab1.Groups.Add(Me.Group2)
        Me.Tab1.Groups.Add(Me.Group6)
        Me.Tab1.Groups.Add(Me.Group4)
        Me.Tab1.Groups.Add(Me.grpFrequentFile)
        Me.Tab1.Groups.Add(Me.grpWindows)
        Me.Tab1.Groups.Add(Me.Group3)
        Me.Tab1.Label = "Excelent"
        Me.Tab1.Name = "Tab1"
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.btnStandartBol)
        Me.Group1.Items.Add(Me.btnCokSutunluBol)
        Me.Group1.Items.Add(Me.Button4)
        Me.Group1.Items.Add(Me.Separator1)
        Me.Group1.Items.Add(Me.Button8)
        Me.Group1.Items.Add(Me.btnSayfaBirlestir)
        Me.Group1.Label = "Bölme ve Birleştirme"
        Me.Group1.Name = "Group1"
        '
        'Separator1
        '
        Me.Separator1.Name = "Separator1"
        '
        'grpMail
        '
        Me.grpMail.Items.Add(Me.Button11)
        Me.grpMail.Label = "Toplu Mail"
        Me.grpMail.Name = "grpMail"
        '
        'Group2
        '
        Me.Group2.DialogLauncher = RibbonDialogLauncherImpl1
        Me.Group2.Items.Add(Me.mnAdetYaz)
        Me.Group2.Items.Add(Me.Separator6)
        Me.Group2.Items.Add(Me.DropDown2)
        Me.Group2.Items.Add(Me.DropDown1)
        Me.Group2.Items.Add(Me.DropDown3)
        Me.Group2.Label = "Hazır Lookuplar"
        Me.Group2.Name = "Group2"
        '
        'Separator6
        '
        Me.Separator6.Name = "Separator6"
        '
        'DropDown2
        '
        RibbonDropDownItemImpl1.Label = "Sicilden"
        RibbonDropDownItemImpl2.Label = "Ad Soyad"
        RibbonDropDownItemImpl3.Label = "Çalıştığı Birim Kodu"
        RibbonDropDownItemImpl4.Label = "Çalıştığı Birim Adı"
        RibbonDropDownItemImpl5.Label = "Görevi"
        RibbonDropDownItemImpl6.Label = "Bankaya Giriş Tarihi"
        RibbonDropDownItemImpl7.Label = "Birime Giriş Tarihi"
        Me.DropDown2.Items.Add(RibbonDropDownItemImpl1)
        Me.DropDown2.Items.Add(RibbonDropDownItemImpl2)
        Me.DropDown2.Items.Add(RibbonDropDownItemImpl3)
        Me.DropDown2.Items.Add(RibbonDropDownItemImpl4)
        Me.DropDown2.Items.Add(RibbonDropDownItemImpl5)
        Me.DropDown2.Items.Add(RibbonDropDownItemImpl6)
        Me.DropDown2.Items.Add(RibbonDropDownItemImpl7)
        Me.DropDown2.Label = " "
        Me.DropDown2.Name = "DropDown2"
        '
        'DropDown1
        '
        RibbonDropDownItemImpl8.Label = "Şubeden"
        RibbonDropDownItemImpl9.Label = "Şube Adı"
        RibbonDropDownItemImpl10.Label = "Bölge Kodu"
        RibbonDropDownItemImpl11.Label = "Bölge Adı"
        RibbonDropDownItemImpl12.Label = "Açılış Tarihi"
        RibbonDropDownItemImpl13.Label = "Açık/Kapalı"
        RibbonDropDownItemImpl14.Label = "Kapanış Tarihi"
        RibbonDropDownItemImpl15.Label = "Türü"
        RibbonDropDownItemImpl16.Label = "Sınıfı"
        RibbonDropDownItemImpl17.Label = "Tipi"
        RibbonDropDownItemImpl18.Label = "İl Kodu"
        RibbonDropDownItemImpl19.Label = "Müdür Sicili"
        RibbonDropDownItemImpl20.Label = "Müdür Adı"
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl8)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl9)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl10)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl11)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl12)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl13)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl14)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl15)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl16)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl17)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl18)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl19)
        Me.DropDown1.Items.Add(RibbonDropDownItemImpl20)
        Me.DropDown1.Label = " "
        Me.DropDown1.Name = "DropDown1"
        '
        'DropDown3
        '
        RibbonDropDownItemImpl21.Label = "Bölgeden"
        RibbonDropDownItemImpl22.Label = "Bölge Adı"
        RibbonDropDownItemImpl23.Label = "Bölge Müdürü"
        RibbonDropDownItemImpl24.Label = "Bireysel Satış Ekibi"
        RibbonDropDownItemImpl25.Label = "Birebir Satış Ekibi"
        RibbonDropDownItemImpl26.Label = "Bireysel+Birebir Satış Ekibi"
        RibbonDropDownItemImpl27.Label = "Bölge Müdürü+Bireysel+Birebir"
        RibbonDropDownItemImpl28.Label = "KOBİ Satış Ekibi"
        RibbonDropDownItemImpl29.Label = "Ticari Satış Ekibi"
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl21)
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl22)
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl23)
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl24)
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl25)
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl26)
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl27)
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl28)
        Me.DropDown3.Items.Add(RibbonDropDownItemImpl29)
        Me.DropDown3.Label = " "
        Me.DropDown3.Name = "DropDown3"
        '
        'Group6
        '
        Me.Group6.Items.Add(Me.mnWB)
        Me.Group6.Items.Add(Me.mnWS)
        Me.Group6.Label = "Workbook ve Worksheet"
        Me.Group6.Name = "Group6"
        '
        'Group4
        '
        Me.Group4.DialogLauncher = RibbonDialogLauncherImpl2
        Me.Group4.Items.Add(Me.Box1)
        Me.Group4.Items.Add(Me.Separator3)
        Me.Group4.Items.Add(Me.Box2)
        Me.Group4.Label = "Pivot ve Liste İşlemleri"
        Me.Group4.Name = "Group4"
        '
        'Box1
        '
        Me.Box1.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical
        Me.Box1.Items.Add(Me.btnPivotOtodoldur)
        Me.Box1.Items.Add(Me.Button2)
        Me.Box1.Items.Add(Me.Button3)
        Me.Box1.Name = "Box1"
        '
        'Separator3
        '
        Me.Separator3.Name = "Separator3"
        '
        'Box2
        '
        Me.Box2.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical
        Me.Box2.Items.Add(Me.Button5)
        Me.Box2.Items.Add(Me.Button6)
        Me.Box2.Items.Add(Me.Button7)
        Me.Box2.Name = "Box2"
        '
        'grpFrequentFile
        '
        Me.grpFrequentFile.DialogLauncher = RibbonDialogLauncherImpl3
        Me.grpFrequentFile.Items.Add(Me.mnFrequentFile)
        Me.grpFrequentFile.Label = "Sık Kullanım"
        Me.grpFrequentFile.Name = "grpFrequentFile"
        '
        'grpWindows
        '
        Me.grpWindows.Items.Add(Me.Box3)
        Me.grpWindows.Label = "Windows İşlemleri"
        Me.grpWindows.Name = "grpWindows"
        '
        'Box3
        '
        Me.Box3.Items.Add(Me.mnuFileFolder)
        Me.Box3.Items.Add(Me.mnuDiger)
        Me.Box3.Name = "Box3"
        '
        'Group3
        '
        Me.Group3.Items.Add(Me.Menu1)
        Me.Group3.Label = "Yardım"
        Me.Group3.Name = "Group3"
        '
        'btnStandartBol
        '
        Me.btnStandartBol.Label = "Standart Bölme"
        Me.btnStandartBol.Name = "btnStandartBol"
        Me.btnStandartBol.OfficeImageId = "SplitTable"
        Me.btnStandartBol.ScreenTip = "Standart Bölme"
        Me.btnStandartBol.ShowImage = True
        Me.btnStandartBol.SuperTip = "Bir çalışma sayfasındaki datayı A kolonuna göre bölüp, önceden ayarlanmış klasör " & _
    "içine ayrı dosyalar halinde kopyalar"
        '
        'btnCokSutunluBol
        '
        Me.btnCokSutunluBol.Label = "Çok Sütunlu Bölme"
        Me.btnCokSutunluBol.Name = "btnCokSutunluBol"
        Me.btnCokSutunluBol.OfficeImageId = "ColumnsGroup"
        Me.btnCokSutunluBol.ShowImage = True
        Me.btnCokSutunluBol.SuperTip = "Çok süütunlu bölme işlemi yapar"
        '
        'Button4
        '
        Me.Button4.Label = "Çok Sayfalı Bölme"
        Me.Button4.Name = "Button4"
        Me.Button4.OfficeImageId = "PageVersionSplitButton"
        Me.Button4.ShowImage = True
        '
        'Button8
        '
        Me.Button8.Label = "Dosyaları Birlestir"
        Me.Button8.Name = "Button8"
        Me.Button8.OfficeImageId = "ReviewCombineRevisions"
        Me.Button8.ShowImage = True
        '
        'btnSayfaBirlestir
        '
        Me.btnSayfaBirlestir.Label = "Sayfaları Birleştir"
        Me.btnSayfaBirlestir.Name = "btnSayfaBirlestir"
        Me.btnSayfaBirlestir.OfficeImageId = "CompareAndCombine"
        Me.btnSayfaBirlestir.ShowImage = True
        '
        'Button11
        '
        Me.Button11.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.Button11.Label = "Toplu Mail Gönderimi"
        Me.Button11.Name = "Button11"
        Me.Button11.OfficeImageId = "MailMergeStartMailMergeMenu"
        Me.Button11.ShowImage = True
        '
        'mnAdetYaz
        '
        Me.mnAdetYaz.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.mnAdetYaz.Items.Add(Me.btnFiiliYaz)
        Me.mnAdetYaz.Items.Add(Me.btnNormVarYok)
        Me.mnAdetYaz.Label = "Adet Yazdır"
        Me.mnAdetYaz.Name = "mnAdetYaz"
        Me.mnAdetYaz.OfficeImageId = "CoauthorCount"
        Me.mnAdetYaz.ShowImage = True
        '
        'btnFiiliYaz
        '
        Me.btnFiiliYaz.Label = "Fiili Yaz"
        Me.btnFiiliYaz.Name = "btnFiiliYaz"
        Me.btnFiiliYaz.ShowImage = True
        '
        'btnNormVarYok
        '
        Me.btnNormVarYok.Label = "Norm Var/Yok"
        Me.btnNormVarYok.Name = "btnNormVarYok"
        Me.btnNormVarYok.ShowImage = True
        '
        'mnWB
        '
        Me.mnWB.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.mnWB.Items.Add(Me.Button1)
        Me.mnWB.Items.Add(Me.Button9)
        Me.mnWB.Items.Add(Me.Button10)
        Me.mnWB.Items.Add(Me.Button14)
        Me.mnWB.Items.Add(Me.Button15)
        Me.mnWB.Items.Add(Me.Button29)
        Me.mnWB.Items.Add(Me.Button30)
        Me.mnWB.Items.Add(Me.Button31)
        Me.mnWB.Label = "WorkBook"
        Me.mnWB.Name = "mnWB"
        Me.mnWB.OfficeImageId = "SaveWorkbookTask"
        Me.mnWB.ShowImage = True
        '
        'Button1
        '
        Me.Button1.Label = "Button1"
        Me.Button1.Name = "Button1"
        Me.Button1.ShowImage = True
        '
        'Button9
        '
        Me.Button9.Label = "Button9"
        Me.Button9.Name = "Button9"
        Me.Button9.ShowImage = True
        '
        'Button10
        '
        Me.Button10.Label = "Button10"
        Me.Button10.Name = "Button10"
        Me.Button10.ShowImage = True
        '
        'Button14
        '
        Me.Button14.Label = "Button14"
        Me.Button14.Name = "Button14"
        Me.Button14.ShowImage = True
        '
        'Button15
        '
        Me.Button15.Label = "Button15"
        Me.Button15.Name = "Button15"
        Me.Button15.ShowImage = True
        '
        'Button29
        '
        Me.Button29.Label = "Button29"
        Me.Button29.Name = "Button29"
        Me.Button29.ShowImage = True
        '
        'Button30
        '
        Me.Button30.Label = "Button30"
        Me.Button30.Name = "Button30"
        Me.Button30.ShowImage = True
        '
        'Button31
        '
        Me.Button31.Label = "Button31"
        Me.Button31.Name = "Button31"
        Me.Button31.ShowImage = True
        '
        'mnWS
        '
        Me.mnWS.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.mnWS.Items.Add(Me.Button16)
        Me.mnWS.Items.Add(Me.Button17)
        Me.mnWS.Items.Add(Me.Button18)
        Me.mnWS.Items.Add(Me.Button19)
        Me.mnWS.Label = "WorkSheet"
        Me.mnWS.Name = "mnWS"
        Me.mnWS.OfficeImageId = "ExcelSpreadsheetInsert"
        Me.mnWS.ShowImage = True
        '
        'Button16
        '
        Me.Button16.Label = "Button16"
        Me.Button16.Name = "Button16"
        Me.Button16.ShowImage = True
        '
        'Button17
        '
        Me.Button17.Label = "Button17"
        Me.Button17.Name = "Button17"
        Me.Button17.ShowImage = True
        '
        'Button18
        '
        Me.Button18.Label = "Button18"
        Me.Button18.Name = "Button18"
        Me.Button18.ShowImage = True
        '
        'Button19
        '
        Me.Button19.Label = "Button19"
        Me.Button19.Name = "Button19"
        Me.Button19.ShowImage = True
        '
        'btnPivotOtodoldur
        '
        Me.btnPivotOtodoldur.Label = "Pivotta Oto Doldur"
        Me.btnPivotOtodoldur.Name = "btnPivotOtodoldur"
        Me.btnPivotOtodoldur.OfficeImageId = "PivotTableRepeatItemLabels"
        Me.btnPivotOtodoldur.ShowImage = True
        '
        'Button2
        '
        Me.Button2.Label = "Ters Pivot"
        Me.Button2.Name = "Button2"
        Me.Button2.OfficeImageId = "TableSummarizeWithPivot"
        Me.Button2.ShowImage = True
        '
        'Button3
        '
        Me.Button3.Label = "Listeyi Parçala"
        Me.Button3.Name = "Button3"
        Me.Button3.OfficeImageId = "PivotTableMove"
        Me.Button3.ShowImage = True
        '
        'Button5
        '
        Me.Button5.Label = "Listeyi yan yana yaz"
        Me.Button5.Name = "Button5"
        Me.Button5.OfficeImageId = "SharePointListsWorkOffline"
        Me.Button5.ShowImage = True
        '
        'Button6
        '
        Me.Button6.Label = "Listeyi altalta yaz"
        Me.Button6.Name = "Button6"
        Me.Button6.OfficeImageId = "ListToolView"
        Me.Button6.ShowImage = True
        '
        'Button7
        '
        Me.Button7.Label = "Çoklu Rank"
        Me.Button7.Name = "Button7"
        Me.Button7.OfficeImageId = "SortByDate"
        Me.Button7.ShowImage = True
        '
        'mnFrequentFile
        '
        Me.mnFrequentFile.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.mnFrequentFile.Items.Add(Me.btnFreqDosya1)
        Me.mnFrequentFile.Items.Add(Me.btnFreqDosya2)
        Me.mnFrequentFile.Items.Add(Me.btnFreqDosya3)
        Me.mnFrequentFile.Items.Add(Me.btnFreqDosya4)
        Me.mnFrequentFile.Items.Add(Me.btnFreqDosya5)
        Me.mnFrequentFile.Label = "Sık Kullanılan Dosyalar"
        Me.mnFrequentFile.Name = "mnFrequentFile"
        Me.mnFrequentFile.OfficeImageId = "OpenSpecificFile"
        Me.mnFrequentFile.ShowImage = True
        '
        'btnFreqDosya1
        '
        Me.btnFreqDosya1.Label = ""
        Me.btnFreqDosya1.Name = "btnFreqDosya1"
        Me.btnFreqDosya1.ShowImage = True
        '
        'btnFreqDosya2
        '
        Me.btnFreqDosya2.Label = ""
        Me.btnFreqDosya2.Name = "btnFreqDosya2"
        Me.btnFreqDosya2.ShowImage = True
        '
        'btnFreqDosya3
        '
        Me.btnFreqDosya3.Label = ""
        Me.btnFreqDosya3.Name = "btnFreqDosya3"
        Me.btnFreqDosya3.ShowImage = True
        '
        'btnFreqDosya4
        '
        Me.btnFreqDosya4.Label = ""
        Me.btnFreqDosya4.Name = "btnFreqDosya4"
        Me.btnFreqDosya4.ShowImage = True
        '
        'btnFreqDosya5
        '
        Me.btnFreqDosya5.Label = ""
        Me.btnFreqDosya5.Name = "btnFreqDosya5"
        Me.btnFreqDosya5.ShowImage = True
        '
        'mnuFileFolder
        '
        Me.mnuFileFolder.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.mnuFileFolder.Items.Add(Me.Button20)
        Me.mnuFileFolder.Items.Add(Me.Button21)
        Me.mnuFileFolder.Items.Add(Me.Button22)
        Me.mnuFileFolder.Items.Add(Me.Button23)
        Me.mnuFileFolder.Items.Add(Me.Button24)
        Me.mnuFileFolder.Label = "Dosya/Klasör"
        Me.mnuFileFolder.Name = "mnuFileFolder"
        Me.mnuFileFolder.OfficeImageId = "OpenFolder"
        Me.mnuFileFolder.ShowImage = True
        '
        'Button20
        '
        Me.Button20.Label = "Button20"
        Me.Button20.Name = "Button20"
        Me.Button20.ShowImage = True
        '
        'Button21
        '
        Me.Button21.Label = "Button21"
        Me.Button21.Name = "Button21"
        Me.Button21.ShowImage = True
        '
        'Button22
        '
        Me.Button22.Label = "Button22"
        Me.Button22.Name = "Button22"
        Me.Button22.ShowImage = True
        '
        'Button23
        '
        Me.Button23.Label = "Button23"
        Me.Button23.Name = "Button23"
        Me.Button23.ShowImage = True
        '
        'Button24
        '
        Me.Button24.Label = "Button24"
        Me.Button24.Name = "Button24"
        Me.Button24.ShowImage = True
        '
        'mnuDiger
        '
        Me.mnuDiger.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.mnuDiger.Items.Add(Me.Button25)
        Me.mnuDiger.Items.Add(Me.Button26)
        Me.mnuDiger.Items.Add(Me.Button27)
        Me.mnuDiger.Items.Add(Me.Button28)
        Me.mnuDiger.Label = "Diğer"
        Me.mnuDiger.Name = "mnuDiger"
        Me.mnuDiger.OfficeImageId = "PageSettings"
        Me.mnuDiger.ShowImage = True
        '
        'Button25
        '
        Me.Button25.Label = "Button25"
        Me.Button25.Name = "Button25"
        Me.Button25.ShowImage = True
        '
        'Button26
        '
        Me.Button26.Label = "Button26"
        Me.Button26.Name = "Button26"
        Me.Button26.ShowImage = True
        '
        'Button27
        '
        Me.Button27.Label = "Button27"
        Me.Button27.Name = "Button27"
        Me.Button27.ShowImage = True
        '
        'Button28
        '
        Me.Button28.Label = "Button28"
        Me.Button28.Name = "Button28"
        Me.Button28.ShowImage = True
        '
        'Menu1
        '
        Me.Menu1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.Menu1.Items.Add(Me.Button12)
        Me.Menu1.Items.Add(Me.Button13)
        Me.Menu1.Label = "Yardım"
        Me.Menu1.Name = "Menu1"
        Me.Menu1.OfficeImageId = "HelpLaunch"
        Me.Menu1.ShowImage = True
        '
        'Button12
        '
        Me.Button12.Label = "Hakkında"
        Me.Button12.Name = "Button12"
        Me.Button12.ShowImage = True
        '
        'Button13
        '
        Me.Button13.Label = "KullanımKılavuzu"
        Me.Button13.Name = "Button13"
        Me.Button13.ShowImage = True
        '
        'rbExcelent
        '
        Me.Name = "rbExcelent"
        Me.RibbonType = "Microsoft.Excel.Workbook"
        Me.Tabs.Add(Me.Tab1)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.grpMail.ResumeLayout(False)
        Me.grpMail.PerformLayout()
        Me.Group2.ResumeLayout(False)
        Me.Group2.PerformLayout()
        Me.Group6.ResumeLayout(False)
        Me.Group6.PerformLayout()
        Me.Group4.ResumeLayout(False)
        Me.Group4.PerformLayout()
        Me.Box1.ResumeLayout(False)
        Me.Box1.PerformLayout()
        Me.Box2.ResumeLayout(False)
        Me.Box2.PerformLayout()
        Me.grpFrequentFile.ResumeLayout(False)
        Me.grpFrequentFile.PerformLayout()
        Me.grpWindows.ResumeLayout(False)
        Me.grpWindows.PerformLayout()
        Me.Box3.ResumeLayout(False)
        Me.Box3.PerformLayout()
        Me.Group3.ResumeLayout(False)
        Me.Group3.PerformLayout()

    End Sub

    Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnStandartBol As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnCokSutunluBol As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button4 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Group2 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents Group3 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents Group4 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents DropDown1 As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents DropDown2 As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents DropDown3 As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents Box1 As Microsoft.Office.Tools.Ribbon.RibbonBox
    Friend WithEvents btnPivotOtodoldur As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button2 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button3 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Separator3 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents Box2 As Microsoft.Office.Tools.Ribbon.RibbonBox
    Friend WithEvents Button5 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button6 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button7 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents grpFrequentFile As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents mnFrequentFile As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents btnFreqDosya1 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnFreqDosya2 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnFreqDosya3 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnFreqDosya4 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnFreqDosya5 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnSayfaBirlestir As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button8 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents mnAdetYaz As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents btnFiiliYaz As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnNormVarYok As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Separator6 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents grpMail As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents Button11 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents mnWB As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents mnWS As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents mnuFileFolder As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents mnuDiger As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents Group6 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents grpWindows As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents Box3 As Microsoft.Office.Tools.Ribbon.RibbonBox
    Friend WithEvents Separator1 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents Button20 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button21 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button22 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button23 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button24 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button25 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button26 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button27 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button28 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button1 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button9 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button10 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button14 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button15 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button29 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button30 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button31 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button16 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button17 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button18 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button19 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Menu1 As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents Button12 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button13 As Microsoft.Office.Tools.Ribbon.RibbonButton

End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property rbExcelent() As rbExcelent
        Get
            Return Me.GetRibbon(Of rbExcelent)()
        End Get
    End Property
End Class
