' Copyright © Microsoft Corporation. All Rights Reserved. 
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports NorthwindEmployees.NorthwindServiceReference

<Microsoft.VisualBasic.ComClassAttribute()> <System.Runtime.InteropServices.ComVisibleAttribute(True)> Public Class ThisWorkbook
    Private ServiceURI As Uri = New Uri("http://localhost:50283/Northwind.svc/")
    Private Sub ThisWorkbook_Startup() Handles Me.Startup
        Me.Application.CalculateFull()
    End Sub

    Public Function getFirstName(ByVal id As Integer) As String
        Dim ctx As New NorthwindEntities(ServiceURI)
        Dim firstName = "<Invalid Employee ID>"

        Try
            Dim emp = (From e In ctx.Employees Where e.EmployeeID = id).Single()
            firstName = emp.FirstName
        Catch ex As InvalidOperationException
            'Employee ID doesn't exist
        End Try
        Return firstName

    End Function

    Public Function getLastName(ByVal id As Integer) As String
        Dim ctx As New NorthwindEntities(ServiceURI)
        Dim lastName = "<Invalid Employee ID>"

        Try
            Dim emp = (From e In ctx.Employees Where e.EmployeeID = id).Single()
            lastName = emp.LastName
        Catch ex As InvalidOperationException
            'Employee ID doesn't exist
        End Try
        Return lastName

    End Function

    Public Function getNotes(ByVal id As Integer) As String
        Dim ctx As New NorthwindEntities(ServiceURI)
        Dim notes = "<Invalid Employee ID>"

        Try
            Dim emp = (From e In ctx.Employees Where e.EmployeeID = id).Single()
            notes = emp.Notes
        Catch ex As InvalidOperationException
            'Employee ID doesn't exist
        End Try
        Return notes

    End Function
    Private Sub ThisWorkbook_Shutdown() Handles Me.Shutdown

    End Sub

End Class
