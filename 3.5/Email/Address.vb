#Region " History "

' Please choose from the following Entry types:
' Bugfix
' Enhancement
' Change

' ----------------------------------------------------------------------------------------------------------------------------------------
' Version    Date         Initials    Type          Description
' ----------------------------------------------------------------------------------------------------------------------------------------
' 1.0.0.0    25 May 11    DR          Enhancement   Original release
'
#End Region

#Region " Imports "

Imports Core.Common

#End Region

Public Class Address

#Region " Private variables "

    Private _Value As String = ""

#End Region

#Region " Public Properties"

    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal Value As String)
            _Value = Value
        End Set
    End Property

#End Region

#Region " Constructors"

    Public Sub New()

    End Sub

    Public Sub New(ByVal ValueToSet As String)
        SetEmailAddress(ValueToSet, False)
    End Sub

    Public Sub New(ByVal ValueToSet As String, ByVal AllowInvalidAddresses As Boolean)
        SetEmailAddress(ValueToSet, AllowInvalidAddresses)
    End Sub

#End Region

#Region " Public Methods "

#End Region

    Public Sub SetEmailAddress(ByVal ValueToSet As String, ByVal AllowInvalidAddresses As Boolean)
        If AllowInvalidAddresses Then
            _Value = ValueToSet
        Else
            If Common.Functions.IsValidEmailAddress(ValueToSet) Then
                _Value = ValueToSet
            Else
                Throw New ApplicationException("Incorrectly formatted Email Address")
            End If
        End If
    End Sub

End Class
