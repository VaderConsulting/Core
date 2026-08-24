#Region " History "

' Please choose from the following Entry types:
' Bugfix
' Enhancement
' Change

' ----------------------------------------------------------------------------------------------------------------------------------------
' Version    Date         Initials    Type          Description
' ----------------------------------------------------------------------------------------------------------------------------------------
' 1.0.0.0    24 May 11    DR          Enhancement   Original release
' 1.1.0.1    20 Jun 11    DR          Enhancement   Added StyleSheet Property so the StatusEmail Class can access it
' 1.1.1.2    23 Jun 11    DR          Change        Modified Stylesheet to set BODY color to Black
' 1.1.1.3    07 Jun 11    DR          Change        Added vbCrLf after all styles and </br> tags
' 1.1.1.4    28 Sep 11    DR          Change        New/Possible/Critical classes added to GetStyleSheet()
' 1.1.1.5    29 Sep 11    DR          Change        Added MailServerPort Property
'
#End Region

#Region " Imports "

Imports System.Web.Mail
Imports System.Text
Imports Core
Imports Core.Common

#End Region

Public Class Message : Implements IDisposable

#Region " Structures "

    Enum MailFormat
        HTML = 1
        Text = 2
    End Enum

#End Region

#Region " Private variables "

    Private _RetryMax As Int32 = 3
    Private _AttemptCount As Int32 = 0
    Private _Message As New Web.Mail.MailMessage
    Private _MailServer As String = ""
    Private _MailServerPort As Int32 = 1025
    Private _FromAddress As New Email.Address
    Private _ToAddresses As New Collections.ArrayList
    Private _CCAddresses As New Collections.ArrayList
    Private _BCCAddresses As New Collections.ArrayList
    Private _Attachments As New Collections.Specialized.StringCollection
    Private _MailSubject As String = ""
    Private _MailBody As String = ""
    Private _Format As MailFormat = MailFormat.HTML
    Private _MailOptions As New Options
    Private _StyleSheet As String = ""
    Private _DisposedValue As Boolean ' To detect redundant calls
    Private _InnerException As Exception
    Private _PauseIntervalSeconds As Int32 = 60 ' Interval (in Seconds) to pause before retrying to send
    Private _Common As Singleton
    Private _Reference As String = Guid.NewGuid.ToString

#End Region

#Region " Public Properties "

    Public Property RetryMax() As Int32
        Get
            Return _RetryMax
        End Get
        Set(ByVal Value As Int32)
            _RetryMax = Value
        End Set
    End Property

    Public Property MailServer() As String
        Get
            Return _MailServer
        End Get
        Set(ByVal Value As String)
            _MailServer = Value
        End Set
    End Property

    Public Property MailServerPort() As Int32
        Get
            Return _MailServerPort
        End Get
        Set(ByVal Value As Int32)
            _MailServerPort = Value
        End Set
    End Property

    Public Property FromAddress() As Email.Address
        Get
            Return _FromAddress
        End Get
        Set(ByVal Value As Email.Address)
            _FromAddress = Value
        End Set
    End Property

    Public Property ToAddresses() As Collections.ArrayList
        Get
            Return _ToAddresses
        End Get
        Set(ByVal Value As Collections.ArrayList)
            _ToAddresses = Value
        End Set
    End Property

    Public Property CCAddresses() As Collections.ArrayList
        Get
            Return _CCAddresses
        End Get
        Set(ByVal Value As Collections.ArrayList)
            _CCAddresses = Value
        End Set
    End Property

    Public Property BCCAddresses() As Collections.ArrayList
        Get
            Return _BCCAddresses
        End Get
        Set(ByVal Value As Collections.ArrayList)
            _BCCAddresses = Value
        End Set
    End Property

    Public Property Attachments() As Collections.Specialized.StringCollection
        Get
            Return _Attachments
        End Get
        Set(ByVal Value As Collections.Specialized.StringCollection)
            _Attachments = Value
        End Set
    End Property

    Public Property MailSubject() As String
        Get
            Return _MailSubject
        End Get
        Set(ByVal Value As String)
            _MailSubject = Value
        End Set
    End Property

    Public Property MailBody() As String
        Get
            Return _MailBody
        End Get
        Set(ByVal Value As String)
            _MailBody = Value
        End Set
    End Property

    Public Property Format() As MailFormat
        Get
            Return _Format
        End Get
        Set(ByVal Value As MailFormat)
            _Format = Value
        End Set
    End Property

    Public Property MailOptions() As Options
        Get
            Return _MailOptions
        End Get
        Set(ByVal Value As Options)
            _MailOptions = Value
        End Set
    End Property

    Public Property PauseIntervalSeconds() As Int32
        Get
            Return _PauseIntervalSeconds
        End Get
        Set(ByVal Value As Int32)
            _PauseIntervalSeconds = Value
        End Set
    End Property

    Public ReadOnly Property InnerException() As Exception
        Get
            Return _InnerException
        End Get
    End Property

    Public Property StyleSheet() As String
        Get
            Return _StyleSheet
        End Get
        Set(ByVal Value As String)
            _StyleSheet = Value
        End Set
    End Property

    Public Property Reference() As String
        Get
            Return _Reference
        End Get
        Set(ByVal value As String)
            _Reference = value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
        _Common = Core.Common.Singleton.GetSingleton
        _StyleSheet = GetStyleSheet()
    End Sub

    Public Sub New(ByVal StyleSheet As String)
        _Common = Core.Common.Singleton.GetSingleton
        _StyleSheet = StyleSheet
    End Sub

#End Region

#Region " Public Methods "

    Public Overridable Function Send() As Boolean
        Dim ToAddresses As New StringBuilder '  Will contain a list of semi-colon delimitered To Addresses
        Dim CCAddresses As New StringBuilder '  Will contain a list of semi-colon delimitered CC Addresses
        Dim BCCAddresses As New StringBuilder ' Will contain a list of semi-colon delimitered BCC Addresses
        Dim MailSendResult As Boolean = False
        Dim HTMLPrefixData As String = ""
        Dim HTMLSuffixData As String = ""

        If Not _Message Is Nothing Then ' Check the object has been initialised
            If _MailServer.Trim.Length > 0 Then ' Check the Mail Server has been specified

                _Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", _MailServerPort)

                SmtpMail.SmtpServer = _MailServer

                ' Logging...
                _Common.Logging.WriteInformationEvent("MailServer: " & _MailServer)
                _Common.Logging.WriteInformationEvent("MailServer Port: " & _MailServerPort.ToString)

                If _FromAddress.Value.Length > 0 Then ' Check the From Address has been populated
                    If _ToAddresses.Count > 0 Then ' Get any To Addresses
                        For Each ToAddress As String In _ToAddresses
                            ToAddresses.Append(ToAddress)
                            ToAddresses.Append(";")
                        Next
                    End If

                    If _CCAddresses.Count > 0 Then ' Get any CC Addresses
                        For Each CCAddress As String In _CCAddresses
                            CCAddresses.Append(CCAddress)
                            CCAddresses.Append(";")
                        Next
                    End If

                    If _BCCAddresses.Count > 0 Then ' Get any BCC Addresses
                        For Each BCCAddress As String In _BCCAddresses
                            BCCAddresses.Append(BCCAddress)
                            BCCAddresses.Append(";")
                        Next
                    End If

                    ' Grab both the To Addresses and the CC Addresses and add them to the Email
                    If ToAddresses.Length > 0 Or CCAddresses.Length > 0 Or BCCAddresses.Length > 0 Then
                        _Message.To = ToAddresses.ToString
                        _Message.Cc = CCAddresses.ToString
                        _Message.Bcc = BCCAddresses.ToString

                        ' Logging...
                        _Common.Logging.WriteInformationEvent("ToAddresses: " & ToAddresses.ToString)
                        _Common.Logging.WriteInformationEvent("CCAddresses: " & CCAddresses.ToString)
                        _Common.Logging.WriteInformationEvent("BCCAddresses: " & BCCAddresses.ToString)
                    Else
                        ' Can not send email (No addressees)
                        If _MailOptions.EmptyAddresseesIsException Then ' Raise exception
                            _Common.Logging.WriteErrorEvent("At least one of To, CC or BCC Address must be specified")
                            Throw New ApplicationException("At least one of To, CC or BCC Address must be specified")
                        Else
                            _Common.Logging.WriteWarningEvent("At least one of To, CC or BCC Address must be specified")
                            Return False ' Ignore it
                        End If
                    End If

                    ' Add any attachments
                    For Each AttachmentFilename As String In _Attachments
                        If IO.File.Exists(AttachmentFilename) Then
                            Try
                                Dim Attachment As New MailAttachment(AttachmentFilename)

                                _Message.Attachments.Add(Attachment)
                                Attachment = Nothing
                                _Common.Logging.WriteInformationEvent("File attachment size : " & AttachmentFilename.Length.ToString)
                            Catch ex As Exception
                                If _MailOptions.AttachmentCouldNotBeAddedIsException Then
                                    _InnerException = ex
                                    Throw New ApplicationException("Could not add Attachment")
                                Else
                                    ' Filename not found, but configured to be ignored
                                    _Common.Logging.WriteWarningEvent("Could not add Attachment, but continuing anyway")
                                End If


                            End Try

                        Else
                            If _MailOptions.AttachmentNotFoundIsException Then
                                Throw New ApplicationException("Attachment not found")
                            Else
                                ' Attachment could not be added, but configured to be ignored
                                _Common.Logging.WriteWarningEvent("Attachment not found, but continuing anyway")
                            End If
                        End If
                    Next

                    ' Set the From Address
                    _Message.From = _FromAddress.Value
                    ' Logging...
                    _Common.Logging.WriteDebugEvent("From Address: " & _FromAddress.Value)

                    ' Set the Mail Format
                    _Message.BodyFormat = _Format

                    ' If HTML format...
                    If _Format = MailFormat.HTML Then
                        ' Convert the original Text to HTML
                        _MailBody = GetTextConvertedToHTML(_MailBody)

                        ' Add the HTML Body prefix data
                        _MailBody = GetHTMLPrefixData() & _MailBody

                        ' Add the HTML Body suffix data
                        _MailBody &= GetHTMLSuffixData()
                    End If

                    ' Add the Mail Body
                    _Message.Body = _MailBody.Trim

                    ' Set the Subject
                    If _MailSubject.Trim.Length > 0 Then
                        _Message.Subject = _MailSubject
                        ' Logging...
                        _Common.Logging.WriteDebugEvent("Subject: " & _MailSubject)
                    Else
                        If _MailOptions.NoSubjectIsException Then
                            _Common.Logging.WriteErrorEvent("No Subject specified")
                            Throw New ApplicationException("No Subject specified")
                        Else
                            ' No subject, but this is configured to be ignored
                            _Common.Logging.WriteWarningEvent("No subject specified, but continuing anyway")
                        End If
                    End If

                    ' Attempt to send the email
                    Do
                        _AttemptCount += 1 ' Add 1 to the attempt count

                        Try
                            Web.Mail.SmtpMail.Send(_Message)
                            MailSendResult = True ' If we have gotten this far, the email send attempt was successful
                            Trace.WriteLine("Send successful on attempt " & _AttemptCount.ToString)
                        Catch ex As Exception
                            _InnerException = ex
                            MailSendResult = False
                            Trace.WriteLine("Send failed")
                            _Common.Logging.WriteWarningEvent("Email failed to send on attempt " & _AttemptCount.ToString & ". The exception was: " & _InnerException.ToString)
                            Core.Common.Functions.PauseSeconds2(_PauseIntervalSeconds, True)
                        End Try

                    Loop Until MailSendResult = True Or _AttemptCount = _RetryMax
                    _Message = Nothing
                    _Common.Logging.WriteInformationEvent("Reference: " & _Reference)

                    If MailSendResult Then
                        _InnerException = Nothing
                        _Common.Logging.WriteInformationEvent("Email sent on attempt " & _AttemptCount.ToString)
                        Return True ' Email successfully sent!  :)
                    Else
                        ' Could not send email
                        If _MailOptions.SendFailureIsException Then
                            _Common.Logging.WriteErrorEvent("Failed to send email")
                            Throw New ApplicationException("Failed to send email")
                        Else
                            Return False
                        End If
                    End If
                Else
                    _Common.Logging.WriteErrorEvent("No From Address specified")
                    Throw New ApplicationException("No From Address specified")
                    Return False
                End If
            Else
                _Common.Logging.WriteErrorEvent("No Mail Server specified")
                Throw New ApplicationException("No Mail Server specified")
                Return False
            End If
        Else
            _Common.Logging.WriteErrorEvent("Mail object not initialised")
            Throw New ApplicationException("Mail object not initialised")
            Return False
        End If
    End Function

#Region "IDisposable Support"

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me._DisposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            _Message = Nothing
        End If
        Me._DisposedValue = True
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        GC.SuppressFinalize(Me)
    End Sub

#End Region

#End Region

#Region " Private Methods "

    Private Function GetStylesheet() As String
        Dim Stylesheet As New Text.StringBuilder

        Stylesheet.Append("<style type='text/css'>" & vbCrLf)
        Stylesheet.Append("body { background-color:#EcEcEc; color: #000000; font-size: 11px; font-family:  arial, verdana, helvetica;}" & vbCrLf)
        Stylesheet.Append("table { color: #FFFFFF; font-size: 11px; font-family:  arial, verdana, helvetica;} " & vbCrLf)
        Stylesheet.Append("table td{ color: #000000; font-size: 11px; font-family: arial, verdana, helvetica;}" & vbCrLf)
        Stylesheet.Append("table tr.heading td {  background-color: #464646; color: white; font-weight: bold; font-size: 12px; }" & vbCrLf)
        Stylesheet.Append("table tr.even td{ background-color: #ECECEC; color: #001C9C; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table tr.odd td{ background-color: #767676; color: #001C9C; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table tr.heading td.heading {  background-color: #CDCDCD; color: white; font-weight: bold; font-size: 12px; } " & vbCrLf)
        Stylesheet.Append("table tr.even td.heading { background-color: #666666; color: #001C9C; font-weight: bold; font-size: 12px } " & vbCrLf)
        Stylesheet.Append("table tr.odd td.heading { background-color: #737373; color: #001C9C; font-weight: bold; font-size: 12px } " & vbCrLf)
        Stylesheet.Append("table.stdTable { background-color:#EcEcEc; color: #000000; font-size: 11px; font-family:  arial, verdana, helvetica;} " & vbCrLf)
        Stylesheet.Append("table.stdTable td{ color: #000000; font-size: 11px; font-family: arial, verdana, helvetica;} " & vbCrLf)
        Stylesheet.Append("/* Exceptions*/" & vbCrLf)
        Stylesheet.Append("table.ExceptionTable tr.heading td { background-color:#D55E00; color: #000000; font-size: 11px; font-family:  arial, verdana, helvetica;} " & vbCrLf)
        Stylesheet.Append("/* Mid Green Cells*/" & vbCrLf)
        Stylesheet.Append("table.stdTable tr.heading td {  background-color: #013473; color: white; font-weight: bold; font-size: 12px; } " & vbCrLf)
        Stylesheet.Append("table.stdTable td.heading {  background-color: #013473; color: white; font-weight: bold; font-size: 12px; } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.heading A:link {color:#ddddff; text-decoration: underline} " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.heading A:visited {color: #ddddff; text-decoration: underline} " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.heading A:active {color: #ff0000; text-decoration: underline} " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.heading A:hover {color: #ff0000; text-decoration: underline} " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.trafficrow { BACKGROUND-COLOR: red; color: #000000; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.trafficrow td.trafficbar { BACKGROUND-COLOR: red; color: #000000; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("/* Light Green Cells*/" & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td{ background-color: #EcEcEc; color: #000000; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.odd td{ background-color: #EcEcEc; color: #000000; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.title { background-color: #2F5E8E; color: #ffffff; font-weight: bold; font-size: 11px; } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.title A:link {color:#ddddff; text-decoration: underline} " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.title A:visited {color: #ddddff; text-decoration: underline} " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.title A:active {color: #ff0000; text-decoration: underline} " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.title A:hover {color: #ff0000; text-decoration: underline} " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.odd td.title { background-color: #ECECEC; color: #001C9C; font-weight: bold; font-size: 11px; } " & vbCrLf)
        Stylesheet.Append("/* Greys Cells*/" & vbCrLf)
        Stylesheet.Append("table.stdTable tr.heading td.heading {  background-color: #CDCDCD; color: white; font-weight: bold; font-size: 12px; } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.heading { background-color: #EcEcEc; color: #001C9C; font-weight: bold; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.odd td.heading { background-color: #EcEcEc; color: #001C9C; font-weight: bold; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.grey { background-color: #EcEcEc; color: #001C9C; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.odd td.grey { background-color: #EcEcEc; color: #000000; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("/* White Cells*/" & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.white { BACKGROUND-COLOR: #FFFFFF; color: #000000; font-size: 11px } " & vbCrLf)
        Stylesheet.Append("table.stdTable tr.odd td.white { BACKGROUND-COLOR: #EcEcEc; color: #000000; font-size: 11px } " & vbCrLf)
        Stylesheet.Append(".title { color: #8983b5; font-weight: bold; font-size: 13px; font-family: arial, verdana,   helvetica }" & vbCrLf)
        Stylesheet.Append("/* Asset Importer Status */" & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.New  { BACKGROUND-COLOR: 009900; color: #ffffff; font-size: 11px }" & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.Possible  { BACKGROUND-COLOR: ff6633; color: #ffffff; font-size: 11px }" & vbCrLf)
        Stylesheet.Append("table.stdTable tr.even td.Critical  { BACKGROUND-COLOR: ff0000; color: #ffffff; font-size: 11px }" & vbCrLf)

        Stylesheet.Append("</style>" & vbCrLf)

        Return Stylesheet.ToString
    End Function

    Private Function GetHTMLPrefixData() As String
        Dim HTMLPrefixData As New Text.StringBuilder

        HTMLPrefixData.Append("<html>" & vbCrLf)
        HTMLPrefixData.Append("    <head>" & vbCrLf)
        HTMLPrefixData.Append(_StyleSheet & vbCrLf)
        HTMLPrefixData.Append("    </head>" & vbCrLf)
        HTMLPrefixData.Append("    <body>" & vbCrLf)

        Return HTMLPrefixData.ToString
    End Function

    Private Function GetHTMLSuffixData() As String
        Dim SuffixData As New Text.StringBuilder

        SuffixData.Append("    </body>" & vbCrLf)
        SuffixData.Append("</html>" & vbCrLf)

        Return SuffixData.ToString
    End Function

    Private Function GetTextConvertedToHTML(ByVal OriginalText As String) As String
        Dim ConvertedText As String = OriginalText

        If ConvertedText.IndexOf("<br") = 0 Then
            ConvertedText = ConvertedText.Replace(vbCrLf, "<br/>" & vbCrLf)
        End If

        Return ConvertedText
    End Function

#End Region

End Class
