Public Class PhoneCall

    Private _PhoneID As Int32 = 0
    Private _InternalNumber As String = ""
    Private _OtherPartyNumber As String = ""
    Private _AccountCode As String = ""
    Private _AuthorisationCode As String = ""
    Private _StartDateTime As Date = Now
    Private _DurationSeconds As Int32 = 0
    Private _ClientID As Int32 = 0                   ' ID of client
    Private _BillID As Int32 = 0
    Private _PersonID As Int32 = 0
    Private _SourceLocationName As String = ""
    Private _DestinationLocationName As String = ""
    Private _CallType As String = ""                ' Local, IDD, STD etc
    Private _Peak As Boolean = False

    Public Property PhoneID() As Int32
        Get
            Return _PhoneID
        End Get
        Set(ByVal value As Int32)
            _PhoneID = value
        End Set
    End Property

    Public Property InternalNumber() As String
        Get
            Return _InternalNumber
        End Get
        Set(ByVal value As String)
            _InternalNumber = value
        End Set
    End Property

    Public Property OtherPartyNumber() As String
        Get
            Return _OtherPartyNumber
        End Get
        Set(ByVal value As String)
            _OtherPartyNumber = value
        End Set
    End Property

    Public Property StartDateTime() As Date
        Get
            Return _StartDateTime
        End Get
        Set(ByVal value As Date)
            _StartDateTime = value
        End Set
    End Property

    Public Property DurationSeconds() As Int32
        Get
            Return _DurationSeconds
        End Get
        Set(ByVal value As Int32)
            _DurationSeconds = value
        End Set
    End Property

    Public Property EndDateTime() As Date
        Get
            Return DateAdd(DateInterval.Second, _DurationSeconds, _StartDateTime)
        End Get
        Set(ByVal value As Date)
            _DurationSeconds = DateDiff(DateInterval.Second, _StartDateTime, value)
        End Set
    End Property

    Public Property AccountCode() As String
        Get
            Return _AccountCode
        End Get
        Set(ByVal value As String)
            _AccountCode = value
        End Set
    End Property

    Public Property AuthorisationCode() As String
        Get
            Return _AuthorisationCode
        End Get
        Set(ByVal value As String)
            _AuthorisationCode = value
        End Set
    End Property

    Public Property ClientID() As Int32
        Get
            Return _ClientID
        End Get
        Set(ByVal value As Int32)
            _ClientID = value
        End Set
    End Property

    Public Property BillID() As Int32
        Get
            Return _BillID
        End Get
        Set(ByVal value As Int32)
            _BillID = value
        End Set
    End Property

    Public Property PersonID() As Int32
        Get
            Return _PersonID
        End Get
        Set(ByVal value As Int32)
            _PersonID = value
        End Set
    End Property

    Public Property SourceLocationName() As String
        Get
            Return _SourceLocationName
        End Get
        Set(ByVal value As String)
            _SourceLocationName = value
        End Set
    End Property

    Public Property DestinationLocationName() As String
        Get
            Return _DestinationLocationName
        End Get
        Set(ByVal value As String)
            _DestinationLocationName = value
        End Set
    End Property

    Public Property CallType() As String
        Get
            Return _CallType
        End Get
        Set(ByVal value As String)
            _CallType = value
        End Set
    End Property

    Public Property Peak() As Boolean
        Get
            Return _Peak
        End Get
        Set(ByVal value As Boolean)
            _Peak = value
        End Set
    End Property

End Class
