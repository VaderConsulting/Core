Public Class ClientCollection

    'Private _Database As FMDatabase
    Private _ClientList As New Collections.SortedList
    'Private _Client As Client

    Public Sub New(ByVal Connection As FMConnection, ByVal ServiceType As Integer)
        Try
            _ClientList = Connection.GetClientList()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public ReadOnly Property ClientList() As Collections.SortedList
        Get
            Return _ClientList
        End Get
    End Property

End Class
