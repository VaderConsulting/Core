Imports System.Text

Public Class Computer

#Region " Private Variables "

#End Region

#Region " Computer Constructors "

    Shared Sub New()

    End Sub

#End Region

#Region " Computer Properties "

    Public Shared ReadOnly Property Name() As String
        Get
            Return Environment.MachineName
        End Get
    End Property

#End Region

    Public Class FileSystem
        Private Declare Auto Function GetLongPathName Lib "kernel32.dll" (ByVal lpszShortPath As String, ByVal lpszLongPath As StringBuilder, ByVal cchBuffer As Integer) As Integer

        Friend Shared Function GetLongPathName(ByVal ShortPathName As String) As String
            Dim LongNameBuffer As New StringBuilder(256)
            Dim BufferSize As Integer = LongNameBuffer.Capacity

            GetLongPathName(ShortPathName, LongNameBuffer, BufferSize)

            Return LongNameBuffer.ToString()
        End Function

#Region " FileSystem Constructors "

        Shared Sub New()

        End Sub

#End Region

        Public Class SpecialDirectories

#Region " SpecialDirectories Constructors "

            'Public Sub New()
            '    Initialise()
            'End Sub

            Shared Sub New()
                SharedInitialise()
            End Sub

#End Region

            Private Shared Sub SharedInitialise()
                '_AllUsersApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)

                ' The GetEnvironmentVariable() Method just returns a string, which can be the Short Path to the Folder.
                ' This will still work as a Path, however it is not the same result as .Net 2.0+
                ' To fix this issue, any time we use the GetEnvironmentVariable method, 
                ' retrieve the Full path using a Kernel call (wrapped in the GetLongPathName() method)

                _AllUsersApplicationData = FileSystem.GetLongPathName(Environment.GetEnvironmentVariable("PROGRAMDATA"))
                If _AllUsersApplicationData.Length > 0 Then _AllUsersApplicationData &= "\" & My.Application.Info.CompanyName & "\" & My.Application.Info.AssemblyName & "\" & My.Application.Info.Version.ToString

                _CurrentUserApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                If _CurrentUserApplicationData.Length > 0 Then _CurrentUserApplicationData &= "\" & My.Application.Info.CompanyName & "\" & My.Application.Info.AssemblyName & "\" & My.Application.Info.Version.ToString

                _Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                _MyMusic = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
                _MyPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

                ' Note:  The following will always return the 32 bit path (because WOW64 translates it)
                _ProgramFiles = FileSystem.GetLongPathName(Environment.GetEnvironmentVariable("PROGRAMFILES"))

                _Programs = Environment.GetFolderPath(Environment.SpecialFolder.Programs)
                _Temp = FileSystem.GetLongPathName(Environment.GetEnvironmentVariable("TEMP"))
            End Sub

#Region " Private Variables "

            Private Shared _AllUsersApplicationData As String = ""
            Private Shared _CurrentUserApplicationData As String = ""
            Private Shared _Desktop As String = ""
            Private Shared _MyDocuments As String = ""
            Private Shared _MyMusic As String = ""
            Private Shared _MyPictures As String = ""
            Private Shared _ProgramFiles As String = ""
            Private Shared _Programs As String = ""
            Private Shared _Temp As String = ""

#End Region

#Region "Properties "

            Public Shared ReadOnly Property AllUsersApplicationData() As String
                Get
                    Return _AllUsersApplicationData
                End Get
            End Property

            Public Shared ReadOnly Property CurrentUserApplicationData() As String
                Get
                    Return _CurrentUserApplicationData
                End Get
            End Property

            Public Shared ReadOnly Property Desktop() As String
                Get
                    Return _Desktop
                End Get
            End Property

            Public Shared ReadOnly Property MyDocuments() As String
                Get
                    Return _MyDocuments
                End Get
            End Property

            Public Shared ReadOnly Property MyMusic() As String
                Get
                    Return _MyMusic
                End Get
            End Property

            Public Shared ReadOnly Property MyPictures() As String
                Get
                    Return _MyPictures
                End Get
            End Property

            Public Shared ReadOnly Property ProgramFiles() As String
                Get
                    Return _ProgramFiles
                End Get
            End Property

            Public Shared ReadOnly Property Programs() As String
                Get
                    Return _Programs
                End Get
            End Property

            Public Shared ReadOnly Property Temp() As String
                Get
                    Return _Temp
                End Get
            End Property

#End Region

        End Class

    End Class

    Public Class Info

#Region " Info Properties "

        Public Shared ReadOnly Property OSFullName() As String
            Get
                Dim KeyName As String = "SOFTWARE\Microsoft\Windows NT\CurrentVersion\"
                Dim rkProductName As Microsoft.Win32.RegistryKey

                rkProductName = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyName)

                'rkSubKey.OpenSubKey(KeyName)

                Return rkProductName.GetValue("ProductName")
            End Get
        End Property

#End Region

    End Class

End Class
