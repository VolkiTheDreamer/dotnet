Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup

    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

    Public Sub CloseWorkbook()
        Me.Application.ActiveWorkbook.Close(SaveChanges:=False)
    End Sub

    Public Sub CloseWorkbookByName()
        Me.Application.Workbooks("NewWorkbook.xlsx").Close(SaveChanges:=False)
    End Sub

    Public Sub SaveWorkbook()
        Me.Application.ActiveWorkbook.Save()
    End Sub

    Public Sub SaveWorkbookAs()
        Me.Application.ActiveWorkbook.SaveAs("C:\Test\Book1.xml")
    End Sub

    Public Sub SaveWorkbookAsCopy()
        Me.Application.ActiveWorkbook.SaveCopyAs("C\Book1.xlsx")
    End Sub

    Public Sub ProtectWorkbook()
        Dim getPasswordFromUser As String
        getPasswordFromUser = "hello"
        Me.Application.ActiveWorkbook.Unprotect(getPasswordFromUser)
    End Sub

    Public Sub UnProtectWorkbook()
        Dim getPasswordFromUser As String
        getPasswordFromUser = "hello"
        Me.Application.ActiveWorkbook.Protect(getPasswordFromUser)
    End Sub
    Public Sub SetPassword()
        Dim password As String
        Dim confirmPassword As String

        password = Me.Application.InputBox("Enter the new password:").ToString()
        confirmPassword = Me.Application.InputBox("Confirm the password:").ToString()

        If password <> confirmPassword Then
            System.Windows.Forms.MessageBox.Show("The passwords you typed do not match.")
            Me.Application.ActiveWorkbook.Password = ""
        Else
            Me.Application.ActiveWorkbook.Password = password
        End If
    End Sub

    Public Sub ListRecentlyUsedWorkbooks()
        Dim rng As Excel.Range = Me.Application.Range("A1")

        Dim i As Integer
        For i = 1 To Me.Application.RecentFiles.Count
            rng.Offset(i - 1, 0).Value2 = Me.Application.RecentFiles(i).Name
        Next
    End Sub

    Public Sub SendMail()
        Me.Application.ActiveWorkbook.SendMail(Recipients:="someone@example.com", Subject:="July Sales Figures")
    End Sub
    Public Sub AddWorksheet()
        Dim newWorksheet As Excel.Worksheet
        newWorksheet = CType(Me.Application.Worksheets.Add(), Excel.Worksheet)
    End Sub
    Public Sub CopyWorksheet()
        Dim worksheet1 As Excel.Worksheet = CType(Application.ActiveWorkbook.Worksheets(1),  _
        Excel.Worksheet)
        Dim worksheet3 As Excel.Worksheet = CType(Application.ActiveWorkbook.Worksheets(3),  _
        Excel.Worksheet)
        worksheet1.Copy(After:=worksheet3)
    End Sub
    Public Sub ListSheets()
        Dim index As Integer = 0

        Dim rng As Excel.Range = Me.Application.Range("A1")

        For Each displayWorksheet As Excel.Worksheet In Me.Application.Worksheets
            rng.Offset(index, 0).Value2 = displayWorksheet.Name
            index += 1
        Next displayWorksheet
    End Sub
    Public Sub PrintMethods()
        CType(Application.ActiveSheet, Excel.Worksheet).PrintOut _
           (From:=1, To:=1, Copies:=2, Preview:=True)
        CType(Application.ActiveSheet, Excel.Worksheet).PrintPreview()
    End Sub
    Public Sub MoveWorksheets()
        Dim totalSheets As Integer = Application.ActiveWorkbook.Sheets.Count
        CType(Application.ActiveSheet, Excel.Worksheet).Move(After:=Application.Worksheets(totalSheets))
    End Sub
    Public Sub ProtectWorksheets()
        Dim getPasswordFromUser As String
        getPasswordFromUser = "hello"
        CType(Application.ActiveSheet, Excel.Worksheet).Protect(getPasswordFromUser, AllowSorting:=True)
    End Sub
    Public Sub UnProtectWorksheets()
        Dim getPasswordFromUser As String
        getPasswordFromUser = "hello"
        CType(Application.ActiveSheet, Excel.Worksheet).Unprotect(getPasswordFromUser)
    End Sub
    Public Sub DeleteComment()
        Dim dateComment As Excel.Range = Me.Application.Range("A1")
        If Not dateComment.Comment Is Nothing Then
            dateComment.Comment.Delete()
        End If
    End Sub
    Public Sub AddComment()
        Dim dateComment As Excel.Range = Me.Application.Range("A1")
        dateComment.AddComment("Comment added " & DateTime.Now)
    End Sub
    Public Sub ShowOrHideComments(ByVal show As Boolean)
        Dim worksheet As Excel.Worksheet = CType(Application.ActiveSheet, Excel.Worksheet)
        Dim i As Integer
        For i = 1 To worksheet.Comments.Count
            worksheet.Comments(i).Visible = show
        Next
    End Sub
    Public Sub CheckSpelling()
        CType(Application.ActiveSheet, Excel.Worksheet).CheckSpelling()
    End Sub
    Public Sub test()
        Me.Application.ActiveWorkbook.Sheets.FillAcrossSheets( _
    Me.Application.Range("rangeData"), Excel.XlFillWith.xlFillWithAll)
    End Sub
    Public Sub SortNamedRange()
        Dim Fruits As Excel.Range = Me.Application.Range("A1", "B2")
        Fruits.Sort( _
            Key1:=Fruits.Columns(1), Order1:=Excel.XlSortOrder.xlAscending, _
            Key2:=Fruits.Columns(2), Order2:=Excel.XlSortOrder.xlAscending, _
            Orientation:=Excel.XlSortOrientation.xlSortColumns, _
            Header:=Excel.XlYesNoGuess.xlNo, _
            SortMethod:=Excel.XlSortMethod.xlPinYin, _
            DataOption1:=Excel.XlSortDataOption.xlSortNormal, _
            DataOption2:=Excel.XlSortDataOption.xlSortNormal, _
            DataOption3:=Excel.XlSortDataOption.xlSortNormal)
    End Sub
    Public Sub SortListObject()
        Dim fruitList As Excel.ListObject = CType(Application.ActiveSheet,  _
            Excel.Worksheet).ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, _
            Application.Range("A1", "B2"))
        fruitList.Range.Sort( _
        Key1:=fruitList.ListColumns(1).Range, Order1:=Excel.XlSortOrder.xlAscending, _
        Key2:=fruitList.ListColumns(2).Range, Order2:=Excel.XlSortOrder.xlAscending, _
        Orientation:=Excel.XlSortOrientation.xlSortColumns, _
        Header:=Excel.XlYesNoGuess.xlYes)
    End Sub

    Public Sub StoreAndRetrieveDateInRange()
        Dim rng As Excel.Range = Me.Application.Range("A1")
        Dim dt As DateTime = DateTime.Now
        rng.Value2 = dt
        Dim value As Object = rng.Value2

        If Not value Is Nothing Then
            If TypeOf value Is Double Then
                dt = DateTime.FromOADate(CType(value, Double))
            Else
                DateTime.TryParse(CType(value, String), dt)
            End If
        End If
        System.Windows.Forms.MessageBox.Show(dt.ToString())
    End Sub
    Public Sub ApplyStylesToRanges()
        Dim style As Excel.Style = Me.Application.ActiveWorkbook.Styles.Add("NewStyle")

        style.Font.Name = "Verdana"
        style.Font.Size = 12
        style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
        style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray)
        style.Interior.Pattern = Excel.XlPattern.xlPatternSolid
        Dim rangeStyles As Excel.Range = Me.Application.Range("A1")

        rangeStyles.Value2 = "'Style Test"
        rangeStyles.Style = "NewStyle"
        rangeStyles.Columns.AutoFit()
    End Sub

    Public Sub RunExcelCalculations()
        Dim rng As Excel.Range = Me.Application.Range("A1")
        rng.Calculate()
    End Sub
    Public Sub SendValuesToWorksheetCells()
        Dim rng As Excel.Range = Me.Application.Range("A1")
        rng.Value2 = "Hello World"

    End Sub

    Public Sub DisplayCurrentUsersLogonIDInCell()
        Dim user As System.Security.Principal.WindowsIdentity
        user = System.Security.Principal.WindowsIdentity.GetCurrent()
        Dim userID As Excel.Range = Me.Application.Range("A1")

        userID.Value2 = user.Name
    End Sub

End Class
