
Public Class CommunityNode
    Private _objID As Integer = -999
    Private _PID As Integer = -999
    Private _SEQNO As String
    Private _state As String
    Private _objName As String
    Private _objValue As String
    Private _srcName As String
    Public Property srcName() As String

        Get
            Return _srcName
        End Get
        Set(ByVal Value As String)
            _srcName = Value
        End Set

    End Property

    Public Property objID() As Integer

        Get
            Return _objID
        End Get
        Set(ByVal Value As Integer)
            _objID = Value
        End Set

    End Property

    Public Property PID() As Integer
        Get
            Return _PID
        End Get
        Set(ByVal Value As Integer)
            _PID = Value
        End Set
    End Property

    Public Property SEQNO() As String
        Get
            Return _SEQNO
        End Get
        Set(ByVal Value As String)
            _SEQNO = Value
        End Set
    End Property


    Public Property state() As String
        Get
            Return _state
        End Get
        Set(ByVal Value As String)
            _state = Value
        End Set
    End Property


    Public Property objName() As String
        Get
            Return _objName
        End Get
        Set(ByVal Value As String)
            _objName = Value
        End Set
    End Property


    Public Property objValue() As String
        Get
            Return _objValue
        End Get
        Set(ByVal Value As String)
            _objValue = Value
        End Set
    End Property

    Public Sub Clear()
        _objID = 0
        _PID = 0
        _SEQNO = ""
        _state = ""
        _objName = ""
        _objValue = ""
        _srcName = ""
    End Sub

End Class
