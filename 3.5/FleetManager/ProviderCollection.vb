Imports FleetManager

Public Class ProviderCollection

    Private _ProviderList As New Collections.SortedList

    Public Sub New(ByVal Connection As FMConnection, ByVal ServiceType As Integer)
        Try
            _ProviderList = Connection.GetProviderList(ServiceType)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public ReadOnly Property ProviderList() As Collections.SortedList
        Get
            Return _ProviderList
        End Get
    End Property

End Class
