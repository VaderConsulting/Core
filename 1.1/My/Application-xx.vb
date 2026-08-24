Public Class Application

    Public Class Info

#Region " Private variables "

        Private Shared _AssemblyInfo As System.Reflection.Assembly = Nothing
        Private Shared _Title As String = "My"
        Private Shared _Description As String = "My Namespace replacement for .NET 1.1"
        Private Shared _CompanyName As String = "Vader Consulting"
        Private Shared _Copyright As String = "Copyright © Vader Consulting Ltd 2012"
        Private Shared _Trademark As String = ""
        Private Shared _Version As Version = New Version(1, 0, 0, 0)
        Private Shared _AssemblyName As String = ""
        Private Shared _ProductName As String = "My Namespace"
        Private Shared _DirectoryPath As String = ""

#End Region

#Region " Constructors "

        Shared Sub New()
            Dim TempTitle As String = ""
            Dim TempDescription As String = ""
            Dim TempCompanyName As String = ""
            Dim TempProductName As String = ""
            Dim TempCopyright As String = ""
            Dim TempTrademark As String = ""
            Dim TempVersion As Version = New Version(1, 0, 0, 0)
            Dim TempAssemblyName As String = ""
            Dim TempDirectoryPath As String = ""

            _AssemblyInfo = System.Reflection.Assembly.GetEntryAssembly

            Try
                TempTitle = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyTitleAttribute), False)(0).Title
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

            Try
                TempDescription = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyDescriptionAttribute), False)(0).Description
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

            Try
                TempCompanyName = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyCompanyAttribute), False)(0).Company
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

            Try
                TempProductName = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyProductAttribute), False)(0).Product
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

            Try
                TempCopyright = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyCopyrightAttribute), False)(0).Copyright
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

            Try
                TempTrademark = _AssemblyInfo.GetCustomAttributes(GetType(Reflection.AssemblyTrademarkAttribute), False)(0).Trademark
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

            Try
                TempVersion = _AssemblyInfo.GetName.Version
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

            Try
                TempAssemblyName = _AssemblyInfo.GetName.Name
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

            Try
                TempDirectoryPath = _AssemblyInfo.Location
            Catch ex As Exception
                ' Could not use as this Attribute is not set
            End Try

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
