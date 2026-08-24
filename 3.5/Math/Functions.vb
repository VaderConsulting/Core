#Region " History "

' Please choose from the following Entry types:
' Bugfix
' Enhancement
' Change

' ----------------------------------------------------------------------------------------------------------------------------------------
' Version       Date         Initials  Type          Description
' ----------------------------------------------------------------------------------------------------------------------------------------
' 1.0.0719.x    19 Jul 11    DR        Enhancement   Initital release
'
'
#End Region

Public Class Functions

#Region " Public Methods "

    Public Shared Function ErlangsSupportable(ByVal BlockingValue As Double, ByVal TrunkCount As Int32) As Double
        Dim Result As Double = 1
        Dim ErlangValue As Double = 0.01

        'If TrunkCount < 1 Or TrunkCount > 180 Then
        '    Throw New OverflowException("Trunk Count must be between 1 and 180")
        'ElseIf BlockingValue < 0.001 Or BlockingValue > 0.999 Then
        '    Throw New OverflowException("Blocking value must be between 0.001 and 0.999")
        'Else
        '    While ErlangB(ErlangValue, TrunkCount) < BlockingValue
        '        ErlangValue += 0.01
        '    End While
        '    Result = ErlangValue
        'End If

        If TrunkCount < 1 Then
            Throw New OverflowException("Trunk Count must be greater than or equal to 1")
        ElseIf BlockingValue < 0.001 Then
            Throw New OverflowException("Blocking value must be greater than or equal to 0.001")
        Else
            While ErlangB(ErlangValue, TrunkCount) < BlockingValue
                ErlangValue += 0.01
            End While
            Result = ErlangValue
        End If


        Return Result
    End Function

    Public Shared Function TrunksRequired(ByVal ErlangValue As Double, ByVal BlockingValue As Double) As Int32
        Dim Result As Int32 = 0
        Dim LineCount As Int32 = 1

        'If ErlangValue < 0.1 Or ErlangValue > 180 Then
        '    Throw New OverflowException("Busy Hour Traffic must be between 0.1 and 180")
        'ElseIf BlockingValue < 0.001 Or BlockingValue > 0.999 Then
        '    Throw New OverflowException("Blocking value must be between 0.001 and 0.999")
        'Else
        '    While ErlangB(ErlangValue, LineCount) > BlockingValue
        '        LineCount += 1
        '    End While
        '    Result = LineCount
        'End If

        If ErlangValue < 0.1 Then
            Throw New OverflowException("Busy Hour Traffic must be greater than or equal to 0.1")
        ElseIf BlockingValue < 0.001 Then
            Throw New OverflowException("Blocking value must be greater than or equal to 0.001")
        Else
            While ErlangB(ErlangValue, LineCount) > BlockingValue
                LineCount += 1
            End While
            Result = LineCount
        End If


        Return Result
    End Function

    Public Shared Function ActualGradeOfService(ByVal ErlangValue As Double, ByVal TrunkCount As Int32) As Double
        Dim Result As Double = 0.0

        'If ErlangValue < 0.1 Or ErlangValue > 180 Then
        '    Throw New OverflowException("Busy Hour Traffic must be between 0.1 and 180")
        'ElseIf TrunkCount < 1 Or TrunkCount > 180 Then
        '    Throw New OverflowException("Trunk Count must be between 1 and 180")
        'Else
        '    Result = ErlangB(ErlangValue, TrunkCount)
        'End If

        If ErlangValue < 0.1 Then
            Throw New OverflowException("Busy Hour Traffic must be greater than or equal to 0.1")
        ElseIf TrunkCount < 1 Then
            Throw New OverflowException("Trunk Count must be greater than or equal to 1")
        Else
            Result = ErlangB(ErlangValue, TrunkCount)
        End If


        Return Result
    End Function

#End Region

#Region " Private Methods "

    Private Shared Function ErlangB(ByVal ErlangValue As Double, ByVal TrunkCount As Int32) As Double
        Dim ProbabilityOfBocking As Double = 1.0
        Dim Result As Double = 1.0
        Dim Counter As Int32 = 0

        If ErlangValue > 0 Then
            ProbabilityOfBocking = (ErlangValue + 1) / ErlangValue
            Counter = 2
            While Counter <> (TrunkCount + 1)
                ProbabilityOfBocking = Counter / ErlangValue * ProbabilityOfBocking + 1
                If ProbabilityOfBocking > 10000 Then
                    Result = 0
                    Exit While
                End If
                Counter += 1
            End While
            Result = 1 / ProbabilityOfBocking
        Else
            Throw New OverflowException("Busy Hour Traffic must be > 0")
        End If

        Return Result

    End Function

#End Region

End Class
