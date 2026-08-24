#Region " History "

' Please choose from the following Entry types:
' Bugfix
' Enhancement
' Change

' ----------------------------------------------------------------------------------------------------------------------------------------
' Version    Date         Initials    Type          Description
' ----------------------------------------------------------------------------------------------------------------------------------------
' 1.1.0.1    07 Jun 11    DR          Enhancement   Based on .NET 3.5 version 1.0.15.25
'
#End Region

Public Class Definitions

    ''' <summary>
    ''' The default behaviour applies to forms that are multi-use.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum DefaultBehaviour
        LoadOnly = 0
        LoadOrCreate = 1
        FailOnNotExist = 2
        CreateNew = 3
        CreateOrModify = 4
        ModifyOnly = 5
    End Enum

    Public Enum FleetManagerTablePrefix
        Mob = 2
        Fix = 4
    End Enum

    Public Enum FleetManagerDatabaseType
        Control = 0
        Data = 1
    End Enum

    ''' <summary>
    ''' Return the Prefix Name
    ''' </summary>
    ''' <param name="Value">The Prefix Value to convert</param>
    ''' <returns>Prefix Name</returns>
    ''' <remarks></remarks>
    Public Function FleetManagerTablePrefixName(ByVal Value As Int16) As String
        Return [Enum].GetName(GetType(FleetManagerTablePrefix), Value)
    End Function

    Public Structure FleetManagerField
        Dim Name As String
        Dim CADSAttributeName As String
        Dim TypeName As String
    End Structure

    Public Enum FleetManagerObjectType As Integer
        Asset = 1
        Logon = 2
        OrganisationUnit = 3
        Person = 4
        Phone = 5
    End Enum

End Class
