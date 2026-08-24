Public Class User

    Public Shared ReadOnly Property Name()
        Get
            Return Environment.UserName
        End Get
    End Property

End Class
