Public Class Result

#Region " Enums "

    Public Enum ReturnType As Integer
        Success = 0
        Exception = 1
        Dataset = 2
        NameValueCollection = 3
        [Boolean] = 4
        [String] = 5
        [Int32] = 6
        [Double] = 7
        String_URL = 8
        String_JavaScript = 9
    End Enum

#End Region

#Region " Private variables "

    Private _Success As Boolean = False
    Private _Result As Object = Nothing
    Private _ResultType As ReturnType = ReturnType.Success

#End Region

#Region " Public Properties"

    Public Property Success() As Boolean
        Get
            Return _Success
        End Get
        Set(ByVal Value As Boolean)
            _Success = Value
        End Set
    End Property

    Public Property Result() As Object
        Get
            Return _Result
        End Get
        Set(ByVal Value As Object)
            _Result = Value
        End Set
    End Property

    Public Property ResultType() As ReturnType
        Get
            Return _ResultType
        End Get
        Set(ByVal Value As ReturnType)
            _ResultType = Value
        End Set
    End Property

#End Region

#Region " Constructors"

    Public Sub New()

    End Sub

#End Region

End Class
