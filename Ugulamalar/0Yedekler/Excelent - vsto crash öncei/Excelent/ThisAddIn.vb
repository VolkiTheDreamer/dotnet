Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        '        RegisterComserver()
        If System.DateTime.Today > CDate("31.12.2016") Then
            MsgBox("Excelent add-inin süresi dolmuş, lütfen yeni versiyon için www.excelinefendisi.com adresine gidin. Excelent'ı artık kullanmak istemiyorsanız, diğer Programlarda olduğu gibi Program Ekle/Kaldır menüsünden kaldırabilirsiniz.")
            Globals.Ribbons.rbExcelent.Dispose()
        End If

    End Sub
    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub
    Private Sub RegisterComserver()
        Try
            Dim strAddinName As String = "Excelent.Fonksiyonlar"

            app.AddIns.Add(Filename:=strAddinName)
            app.AddIns(strAddinName).Installed = True

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class
