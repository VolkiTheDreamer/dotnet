' Copyright © Microsoft Corporation. All Rights Reserved. 
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System.Data.Services
Imports System.Linq
Imports System.ServiceModel.Web

Public Class Northwind
    ' TODO: replace [[class name]] with your data class name
    Inherits DataService(Of NorthwindEntities)

    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As IDataServiceConfiguration)
        ' TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
        ' Examples:
        config.SetEntitySetAccessRule("*", EntitySetRights.AllRead)

    End Sub

End Class
