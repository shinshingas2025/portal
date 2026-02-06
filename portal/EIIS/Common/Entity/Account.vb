Public Class Account

    Dim _LoginID As String = ""
    Dim _Password As String = ""
    Dim _UID As Integer
    Dim _roleLevel As String = ""
    Dim _ErrorCnt As Integer
    Dim _logintype As String = ""
    Dim _memo As String = ""
    Dim _state As String = ""
    Dim _startdate As DateTime
    Dim _EndDate As DateTime


    Public Property LoginID() As String
        Get
            Return _LoginID
        End Get
        Set(ByVal Value As String)
            _LoginID = Value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property


    Public Property UID() As Integer
        Get
            Return _UID
        End Get
        Set(ByVal Value As Integer)
            _UID = Value
        End Set
    End Property

    Public Property roleLevel() As String
        Get
            Return _roleLevel
        End Get
        Set(ByVal Value As String)
            _roleLevel = Value
        End Set
    End Property
    Public Property ErrorCnt() As Integer
        Get
            Return _ErrorCnt
        End Get
        Set(ByVal Value As Integer)
            _ErrorCnt = Value
        End Set
    End Property

    Public Property logintype() As String
        Get
            Return _logintype
        End Get
        Set(ByVal Value As String)
            _logintype = Value
        End Set
    End Property
    Public Property memo() As String
        Get
            Return _memo
        End Get
        Set(ByVal Value As String)
            _memo = Value
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

    Public Property StartDate() As DateTime
        Get
            Return _startdate
        End Get
        Set(ByVal Value As DateTime)
            _startdate = Value
        End Set
    End Property

    Public Property EndDate() As DateTime
        Get
            Return _EndDate
        End Get
        Set(ByVal Value As DateTime)
            _EndDate = Value
        End Set
    End Property
End Class
