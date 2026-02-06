Public Class Encontact 
    Dim _cntno As Integer
    Dim _cntdateno As String
    Dim _cntsubject As String
    Dim _cntname As String
    Dim _cntemail As String
    Dim _cnttel As String
    Dim _createdate As DateTime
    Dim _cntcontent As String
    Dim _creategroup As String
    Dim _workstatus As String
    Dim _operator As String
    Dim _workdate As String
    Dim _lastoperator As String
    Dim _lastworkdate As String
    Dim _endoperator As String
    Dim _endworkdate As String
    Dim _remark As String
    Dim _assignoperator As String
    Dim _assigndate As String

    Public Property operator() As String
        Get
            Return _operator
        End Get
        Set(ByVal Value As String)
            _operator = Value
        End Set
    End Property

    Public Property remark() As String
        Get
            Return _remark
        End Get
        Set(ByVal Value As String)
            _remark = Value
        End Set
    End Property
    Public Property workstatus() As String
        Get
            Return _workstatus
        End Get
        Set(ByVal Value As String)
            _workstatus = Value
        End Set
    End Property
    Public Property workdate() As String
        Get
            Return _workdate
        End Get
        Set(ByVal Value As String)
            _workdate = Value
        End Set
    End Property


    Public Property cntno() As Integer
        Get
            Return _cntno
        End Get
        Set(ByVal Value As Integer)
            _cntno = Value
        End Set
    End Property


    Public Property cntsubject() As String
        Get
            Return _cntsubject
        End Get
        Set(ByVal Value As String)
            _cntsubject = Value
        End Set
    End Property


    Public Property cntcontent() As String
        Get
            Return _cntcontent
        End Get
        Set(ByVal Value As String)
            _cntcontent = Value
        End Set
    End Property


    Public Property cnttel() As String
        Get
            Return _cnttel
        End Get
        Set(ByVal Value As String)
            _cnttel = Value
        End Set
    End Property


    Public Property cntemail() As String
        Get
            Return _cntemail
        End Get
        Set(ByVal Value As String)
            _cntemail = Value
        End Set
    End Property


    Public Property createdate() As DateTime
        Get
            Return _createdate
        End Get
        Set(ByVal Value As DateTime)
            _createdate = Value
        End Set
    End Property

    Public Property cntdateno() As String
        Get
            Return _cntdateno
        End Get
        Set(ByVal Value As String)
            _cntdateno = Value
        End Set
    End Property

    Public Property cntname() As String
        Get
            Return _cntname
        End Get
        Set(ByVal Value As String)
            _cntname = Value
        End Set
    End Property

    Public Property creategroup() As String
        Get
            Return _creategroup
        End Get
        Set(ByVal Value As String)
            _creategroup = Value
        End Set
    End Property


    Public Property lastoperator() As String
        Get
            Return _lastoperator
        End Get
        Set(ByVal Value As String)
            _lastoperator = Value
        End Set
    End Property

    Public Property lastworkdate() As String
        Get
            Return _lastworkdate
        End Get
        Set(ByVal Value As String)
            _lastworkdate = Value
        End Set
    End Property

    Public Property endoperator() As String
        Get
            Return _endoperator
        End Get
        Set(ByVal Value As String)
            _endoperator = Value
        End Set
    End Property

    Public Property endworkdate() As String
        Get
            Return _endworkdate
        End Get
        Set(ByVal Value As String)
            _endworkdate = Value
        End Set
    End Property

    Public Property assignoperator() As String
        Get
            Return _assignoperator
        End Get
        Set(ByVal Value As String)
            _assignoperator = Value
        End Set
    End Property

    Public Property assigndate() As String
        Get
            Return _assigndate
        End Get
        Set(ByVal Value As String)
            _assigndate = Value
        End Set
    End Property


End Class
