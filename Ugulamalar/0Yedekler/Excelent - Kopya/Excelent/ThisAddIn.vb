Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        '        RegisterComserver()

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
