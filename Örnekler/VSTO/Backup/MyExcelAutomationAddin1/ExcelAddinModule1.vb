Imports System.Runtime.InteropServices

'Add-in Express Excel Add-in Module
<GuidAttribute("1EFBC71A-25C4-4EE7-869A-76B6ADE6497B"), _
ProgIdAttribute("MyExcelAutomationAddin1.ExcelAddinModule1"), ClassInterface(ClassInterfaceType.AutoDual)> _
Public Class ExcelAddinModule1
    Inherits AddinExpress.MSO.ADXExcelAddinModule

#Region " Add-in Express automatic code "

    <ComRegisterFunctionAttribute()> _
    Public Shared Sub AddinRegister(ByVal t As Type)
        AddinExpress.MSO.ADXExcelAddinModule.ADXExcelAddinRegister(t)
    End Sub

    <ComUnregisterFunctionAttribute()> _
    Public Shared Sub AddinUnregister(ByVal t As Type)
        AddinExpress.MSO.ADXExcelAddinModule.ADXExcelAddinUnregister(t)
    End Sub

#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Public Function MyFunc(ByVal Range As Object) As Object
        MyFunc = CType(Range, Excel.Range).Value * 1000
    End Function
End Class
