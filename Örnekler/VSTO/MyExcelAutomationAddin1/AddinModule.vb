Imports System.Runtime.InteropServices
Imports System.ComponentModel

'Add-in Express Add-in Module
<GuidAttribute("58ADE48B-863F-4176-9575-10212273592F"), ProgIdAttribute("MyExcelAutomationAddin1.AddinModule")> _
Public Class AddinModule
    Inherits AddinExpress.MSO.ADXAddinModule

#Region " Component Designer generated code. "
    'Required by designer
    Private components As System.ComponentModel.IContainer

    'Required by designer - do not modify
    'the following method
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        '
        'AddinModule
        '
        Me.AddinName = "MyExcelAutomationAddin1"

        Me.SupportedApps = CType(( _
   AddinExpress.MSO.ADXOfficeHostApp.ohaExcel _
   ), AddinExpress.MSO.ADXOfficeHostApp)
    End Sub

#End Region

#Region " Add-in Express automatic code "

    'Required by Add-in Express - do not modify
    'the methods within this region

    Public Overrides Function GetContainer() As System.ComponentModel.IContainer
        If components Is Nothing Then
            components = New System.ComponentModel.Container
        End If
        GetContainer = components
    End Function

    <ComRegisterFunctionAttribute()> _
    Public Shared Sub AddinRegister(ByVal t As Type)
        AddinExpress.MSO.ADXAddinModule.ADXRegister(t)
    End Sub

    <ComUnregisterFunctionAttribute()> _
    Public Shared Sub AddinUnregister(ByVal t As Type)
        AddinExpress.MSO.ADXAddinModule.ADXUnregister(t)
    End Sub

    Public Overrides Sub UninstallControls()
        MyBase.UninstallControls()
    End Sub

#End Region

    Public Sub New()
        MyBase.New()

        InitializeComponent()
    End Sub

    Public ReadOnly Property ExcelApp() As Excel._Application
        Get
            Return CType(HostApplication, Excel._Application)
        End Get
    End Property

End Class

