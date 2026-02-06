Public Class Enstop 
    Dim _spno As Integer
    Dim _spsubject As String
    Dim _spcontent As String
    Dim _spenddate As String
    Dim _creater As String
    Dim _createdate As String
    Dim _SDATE As Date
    Dim _EDATE As Date
    Dim _Provider As String
    Dim _stoprange As String
    Dim _stopSdate As Date
    Dim _stopStime As String
    Dim _stopEdate As Date
    Dim _stopEtime As String
    Dim _AnswerUnit As String
    Dim _AnswerTel As String
    Dim _modifier As String
    Dim _modifydate As String


    Public Property stoprange() As String
        Get
            Return _stoprange
        End Get
        Set(ByVal Value As String)
            _stoprange = Value
        End Set
    End Property

    Public Property AnswerUnit() As String
        Get
            Return _AnswerUnit
        End Get
        Set(ByVal Value As String)
            _AnswerUnit = Value
        End Set
    End Property

    Public Property AnswerTel() As String
        Get
            Return _AnswerTel
        End Get
        Set(ByVal Value As String)
            _AnswerTel = Value
        End Set
    End Property

    Public Property stopStime() As String
        Get
            Return _stopStime
        End Get
        Set(ByVal Value As String)
            _stopStime = Value
        End Set
    End Property

    Public Property stopEtime() As String
        Get
            Return _stopEtime
        End Get
        Set(ByVal Value As String)
            _stopEtime = Value
        End Set
    End Property



    Public Property stopEdate() As Date
        Get
            Return _stopEdate
        End Get
        Set(ByVal Value As Date)
            _stopEdate = Value
        End Set
    End Property

    Public Property stopSdate() As Date
        Get
            Return _stopSdate
        End Get
        Set(ByVal Value As Date)
            _stopSdate = Value
        End Set
    End Property

    Public Property Provider() As String
        Get
            Return _Provider
        End Get
        Set(ByVal Value As String)
            _Provider = Value
        End Set
    End Property


    Public Property SDATE() As Date
        Get
            Return _SDATE
        End Get
        Set(ByVal Value As Date)
            _SDATE = Value
        End Set
    End Property

    Public Property EDATE() As Date
        Get
            Return _EDATE
        End Get
        Set(ByVal Value As Date)
            _EDATE = Value
        End Set
    End Property

    Public Property spno() As Integer
        Get
            Return _spno
        End Get
        Set(ByVal Value As Integer)
            _spno = Value
        End Set
    End Property


    Public Property spsubject() As String
        Get
            Return _spsubject
        End Get
        Set(ByVal Value As String)
            _spsubject = Value
        End Set
    End Property


    Public Property spcontent() As String
        Get
            Return _spcontent
        End Get
        Set(ByVal Value As String)
            _spcontent = Value
        End Set
    End Property


    Public Property spenddate() As String
        Get
            Return _spenddate
        End Get
        Set(ByVal Value As String)
            _spenddate = Value
        End Set
    End Property


    Public Property creater() As String
        Get
            Return _creater
        End Get
        Set(ByVal Value As String)
            _creater = Value
        End Set
    End Property


    Public Property createdate() As String
        Get
            Return _createdate
        End Get
        Set(ByVal Value As String)
            _createdate = Value
        End Set
    End Property

    Public Property modifier() As String
        Get
            Return _modifier
        End Get
        Set(ByVal Value As String)
            _modifier = Value
        End Set
    End Property


    Public Property modifydate() As String
        Get
            Return _modifydate
        End Get
        Set(ByVal Value As String)
            _modifydate = Value
        End Set
    End Property

End Class
