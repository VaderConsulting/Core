#Region " Imports "

Imports System.Reflection
Imports System.Reflection.Assembly
Imports System.Data.SqlClient
Imports FleetManager.Definitions

#End Region

Public Class OrganisationTree

    Private _ClientID As Int32 = 0
    Private _OrganisationUnits As New Collections.Generic.List(Of OrganisationalUnit)
    Private _Database As FMDatabase
    Private _Connection As FMConnection

    Public Sub New()

    End Sub

    Public Sub New(ByVal ClientID As Int32, ByVal Database As FMDatabase)
        If ClientID > 0 Then
            ' TODO:  Search for this clientID.
            _ClientID = ClientID
            _Database = Database
        Else
            Err.Raise(vbObjectError + 514, GetExecutingAssembly.GetName.Name, "Client ID not specified for FleetManager Connection.")
        End If
    End Sub

#Region " Properties "

    Public Property ClientID() As Integer
        Get
            Return _ClientID
        End Get
        Set(ByVal value As Integer)
            _ClientID = value
        End Set
    End Property

    Public Property OrganisationUnits() As Collections.Generic.List(Of OrganisationalUnit)
        Get
            Return _OrganisationUnits
        End Get
        Set(ByVal value As Collections.Generic.List(Of OrganisationalUnit))
            _OrganisationUnits = value
        End Set
    End Property

#End Region

    Public Sub Initialize(ByVal ClientID As Int32, ByVal Database As FMDatabase)
        If ClientID > 0 Then
            ' TODO:  Search for this clientID.
            _ClientID = ClientID
            _Database = Database
        Else
            Err.Raise(vbObjectError + 514, GetExecutingAssembly.GetName.Name, "Client ID not specified for FleetManager Connection.")
        End If
    End Sub

    Public Sub Fill()
        Dim OrgUnits As Collections.SortedList = _Connection.GetOrganisationUnits()

    End Sub

End Class
