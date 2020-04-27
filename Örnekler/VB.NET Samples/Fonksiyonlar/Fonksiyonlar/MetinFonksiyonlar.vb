Option Explicit On
Option Compare Text
Option Strict Off
Imports Excel = Microsoft.Office.Interop.Excel
Imports OFC = Microsoft.Office.Interop
Imports System
Imports System.Runtime.InteropServices
Imports WIN32 = Microsoft.Win32
<ClassInterface(ClassInterfaceType.AutoDual), ComVisible(True)> _
Public Class MetinFonksiyonlar
    Public Function superconcat(Hucre_grubu As Excel.Range, isaret As String)
        Dim x As String
        Dim k As Excel.Range
        x = ""
        For Each k In Hucre_grubu
            If CStr(k.Value2) <> "" Then
                x = x & k.Value & isaret
            End If
        Next k

        superconcat = Mid(x, 1, Len(x) - 1)
    End Function


    <ComRegisterFunctionAttribute()> _
    Public Shared Sub RegisterFunction(ByVal type As Type)
        WIN32.Registry.ClassesRoot.CreateSubKey(GetSubkeyName(type))
    End Sub

    <ComUnregisterFunctionAttribute()> _
    Public Shared Sub UnregisterFunction(ByVal type As Type)
        WIN32.Registry.ClassesRoot.DeleteSubKey(GetSubkeyName(type), False)
    End Sub

    Private Shared Function GetSubkeyName(ByVal type As Type) As String
        Dim S As New System.Text.StringBuilder()
        S.Append("CLSID\{")
        S.Append(type.GUID.ToString().ToUpper())
        S.Append("}\Programmable")
        Return S.ToString()
    End Function
End Class

