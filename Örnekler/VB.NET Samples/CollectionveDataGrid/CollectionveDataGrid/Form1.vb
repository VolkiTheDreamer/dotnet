Public Class Form1
    Dim Names As New Collection
    Dim Tels As New Collection
    Sub AddContact(ByVal CName As String, ByVal CTEL As String)
        Names.Add(CName)
        Tels.Add(CTEL)
    End Sub
    ' display the names in the grid
    Sub ViewContacts(ByVal DGV As DataGridView)
        DGV.Rows.Clear()
        Dim I As Integer
        For I = 1 To Names.Count
            DGV.Rows.Add(Names(I), Tels(I))
        Next
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        Dim N As String
        Dim T As String
        N = InputBox("Enter the name of the contact:")
        If N = "" Then
            Exit Sub
        End If
        T = InputBox("Enter the tel number:")
        If T = "" Then
            Exit Sub
        End If
        AddContact(N, T)
        ViewContacts(DataGridView1)
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        Dim N As String
        Dim T As String
        N = InputBox("Enter the name you are searching for:")
        If N = "" Then
            Exit Sub
        End If
        T = GetTelForName(N)
        If T = "" Then
            MsgBox("Name not found")
        Else
            MsgBox("the tel number is:" & T)
        End If
    End Sub

    Function GetTelForName(ByVal Name As String) As String
        Dim I As Integer
        For I = 1 To Names.Count
            If Names(I) = Name Then
                Return Tels(I)
            End If
        Next
        Return ""
    End Function
End Class
