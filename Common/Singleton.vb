Public Class Singleton


#Region " Private Shared "

    Private Shared _Logging As Core.Logging.Functions
    Private Shared _ThisInstance As Singleton
    Private Shared _DebugMode As Boolean = False
    Private Shared _ProgramDataPath As String = ""
    'Private Shared _RunningInsideWebPage As Boolean = False

#End Region

#Region " Private "

    Private _UserDataPath As String = ""

#End Region

#Region " Constructors "

    Protected Sub New()
        Try
            _Logging = New Logging.Functions
            ' The following line creates a folder with the version number of the application under the _ProgramDataPath
            ' This is not desired, however it doesn't affect the program
            _ProgramDataPath = IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), My.Application.Info.CompanyName & "\" & My.Application.Info.ProductName)
            _UserDataPath = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Shared Properties "

    Public Shared Property DebugMode() As Boolean
        Get
            Return _DebugMode
        End Get
        Set(ByVal value As Boolean)
            _DebugMode = value
            _Logging.DebugMode = value
        End Set
    End Property

    Public Shared Property ProgramDataPath() As String
        Get
            Return _ProgramDataPath
        End Get
        Set(ByVal value As String)
            _ProgramDataPath = value
        End Set
    End Property

#End Region

#Region " Properties "

    Public Property UserDataPath() As String
        Get
            Return _UserDataPath
        End Get
        Set(ByVal value As String)
            _UserDataPath = value
        End Set
    End Property

    Public ReadOnly Property Logging() As Logging.Functions
        Get
            Return _Logging
        End Get
    End Property

#End Region

#Region " Public methods "

    <STAThread()> Public Shared Function GetSingleton() As Singleton
        '
        ' initialize object if it hasn't already been done
        '
        Try
            If _ThisInstance Is Nothing Then
                _ThisInstance = New Singleton
                _Logging.WriteInformationEvent("--------------------Common layer startup-----------------------")
            End If
        Catch
        End Try

        '
        ' return the initialized instance
        '

        Return _ThisInstance
    End Function

#End Region

    Protected Overrides Sub Finalize()
        If Not IsNothing(_Logging) Then
            _Logging.WriteInformationEvent("--------------------Common layer shutdown-----------------------")
        End If
        MyBase.Finalize()
    End Sub

End Class
