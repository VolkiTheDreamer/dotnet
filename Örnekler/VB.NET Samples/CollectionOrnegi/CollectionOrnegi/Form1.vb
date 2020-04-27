Public Class Form1
    Dim MyCollection As New Collection
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' this method clears all the elements in the collection
        MyCollection.Clear()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' read a name
        Dim Name As String
        Name = InputBox("enter a name")
        ' add the name into the list
        MyCollection.Add(Name)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("the number of items is:" & MyCollection.Count)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' clear old content
        ListBox1.Items.Clear()
        ' insert the items into the list box
        Dim I As Integer
        For I = 1 To MyCollection.Count
            ListBox1.Items.Add(MyCollection(I))
        Next
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ' get element position
        Dim I As Integer
        I = InputBox("enter the element number you want to remove:")
        MyCollection.Remove(I)
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ' get element position
        Dim I As Integer
        Dim N As String
        I = InputBox("enter the element number:")
        N = InputBox("enter the new name:")
        MyCollection.Add(N, , , I)
        MyCollection.Remove(I)

    End Sub
End Class
