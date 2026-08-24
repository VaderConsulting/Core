Public Class Computer

#Region " Computer Constructors "

    Shared Sub New()

    End Sub

#End Region

    Public Class FileSystem

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
                _AllUsersApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                _CurrentUserApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                _Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                _MyMusic = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
                _MyPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                _ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                _Programs = Environment.GetFolderPath(Environment.SpecialFolder.Programs)
                _Temp = Environment.GetEnvironmentVariable("TEMP")
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

End Class
