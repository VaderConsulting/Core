#Region " History "

' Please choose from the following Entry types:
' Bugfix
' Enhancement
' Change

' ----------------------------------------------------------------------------------------------------------------------------------------
' Version    Date         Initials    Type          Description
' ----------------------------------------------------------------------------------------------------------------------------------------
' 1.0.0.0    24 May 11    DR          Enhancement   Original release
'
#End Region

Public Class Options

#Region " Private variables "

    Private _NoSubjectIsException As Boolean = False
    Private _AttachmentNotFoundIsException As Boolean = True
    Private _AttachmentCouldNotBeAddedIsException As Boolean = True
    Private _EmptyAddresseesIsException As Boolean = False
    Private _SendFailureIsException As Boolean = False

#End Region

#Region " Public Properties"

    Public Property NoSubjectIsException() As Boolean
        Get
            Return _NoSubjectIsException
        End Get
        Set(ByVal Value As Boolean)
            _NoSubjectIsException = Value
        End Set
    End Property

    Public Property AttachmentNotFoundIsException() As Boolean
        Get
            Return _AttachmentNotFoundIsException
        End Get
        Set(ByVal Value As Boolean)
            _AttachmentNotFoundIsException = Value
        End Set
    End Property

    Public Property AttachmentCouldNotBeAddedIsException() As Boolean
        Get
            Return _AttachmentCouldNotBeAddedIsException
        End Get
        Set(ByVal Value As Boolean)
            _AttachmentCouldNotBeAddedIsException = Value
        End Set
    End Property

    Public Property EmptyAddresseesIsException() As Boolean
        Get
            Return _EmptyAddresseesIsException
        End Get
        Set(ByVal Value As Boolean)
            _EmptyAddresseesIsException = Value
        End Set
    End Property

    Public Property SendFailureIsException() As Boolean
        Get
            Return _SendFailureIsException
        End Get
        Set(ByVal Value As Boolean)
            _SendFailureIsException = Value
        End Set
    End Property

#End Region

#Region " Constructors"

    Public Sub New()

    End Sub

#End Region

End Class
