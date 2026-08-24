Public Class Application

    Public Class Info

#Region " Private variables "

        Private Shared _AssemblyInfo As System.Reflection.Assembly = Nothing
        Private Shared _Title As String = "My"
        Private Shared _Description As String = "My Namespace replacement for .NET 1.1"
        Private Shared _CompanyName As String = "Stratatel Ltd"
        Private Shared _Copyright As String = "Copyright © Stratatel Ltd 2010"
        Private Shared _Trademark As String = ""
        Private Shared _Version As Version = New Version(1, 0, 0, 0)
        Private Shared _AssemblyName As String = ""
        Private Shared _ProductName As String = "CADS FM"
        Private Shared _DirectoryPath As String = ""

#End Region

#Region " Constructors "

        Shared Sub New()
            _AssemblyInfo = System.Reflection.Assembly.GetExecutingAssembly

            Dim TempTitle As String = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyTitleAttribute), False)(0).Title
            Dim TempDescription As String = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyDescriptionAttribute), False)(0).Description
            Dim TempCompanyName As String = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyCompanyAttribute), False)(0).Company
            Dim TempProductName As String = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyProductAttribute), False)(0).Product
            Dim TempCopyright As String = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyCopyrightAttribute), False)(0).Copyright
            Dim TempTrademark As String = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyTrademarkAttribute), False)(0).Trademark
            Dim TempVersion As Version = _AssemblyInfo.GetName.Version
            Dim TempAssemblyName As String = _AssemblyInfo.GetName.Name
            Dim TempDirectoryPath As String = _AssemblyInfo.Location

            If TempTitle.Trim.Length > 0 Then
                _Title = TempTitle
            End If

            If TempDescription.Trim.Length > 0 Then
                _Description = TempDescription
            End If

            If TempCompanyName.Trim.Length > 0 Then
                _CompanyName = TempCompanyName
            End If

            If TempProductName.Trim.Length > 0 Then
                _ProductName = TempProductName
            End If

            If TempCopyright.Trim.Length > 0 Then
                _Copyright = TempCopyright
            End If

            If TempTrademark.Trim.Length > 0 Then
                _Trademark = TempTrademark
            End If

            If TempVersion.ToString.Trim.Length > 0 Then
                _Version = TempVersion
            End If

            If TempAssemblyName.Trim.Length > 0 Then
                _AssemblyName = TempAssemblyName
            End If

            If TempDirectoryPath.Trim.Length > 0 Then
                _DirectoryPath = TempDirectoryPath
            End If

        End Sub

#End Region

#Region " Properties "

        Public Shared ReadOnly Property AssemblyInfo() As System.Reflection.Assembly
            Get
                Return _AssemblyInfo
            End Get
        End Property

        Public Shared ReadOnly Property Title() As String
            Get
                Return _Title
            End Get
        End Property

        Public Shared ReadOnly Property Description() As String
            Get
                Return _Description
            End Get
        End Property

        Public Shared ReadOnly Property CompanyName() As String
            Get
                Return _CompanyName
            End Get
        End Property

        Public Shared ReadOnly Property Copyright() As String
            Get
                Return _Copyright
            End Get
        End Property

        Public Shared ReadOnly Property Trademark() As String
            Get
                Return _Trademark
            End Get
        End Property

        Public Shared ReadOnly Property Version() As Version
            Get
                Return _Version
            End Get
        End Property

        Public Shared ReadOnly Property AssemblyName() As String
            Get
                Return _AssemblyName
            End Get
        End Property

        Public Shared ReadOnly Property ProductName() As String
            Get
                Return _ProductName
            End Get
        End Property

        Public Shared ReadOnly Property DirectoryPath() As String
            Get
                Return _DirectoryPath
            End Get
        End Property

#End Region

    End Class

End Class
