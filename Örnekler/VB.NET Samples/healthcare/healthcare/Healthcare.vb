Public Class Patient
    Dim msFirstname As String

    Public Property FirstName() As String
        Get
            Return msFirstName
        End Get
        Set(ByVal Value As String)
            msFirstName = Value
        End Set
    End Property

End Class
