Public Class Enhotnews
    Dim _newno As Integer
    Dim _newsubject As String
    Dim _newcontent As String
    Dim _newlink As String
    Dim _creatdate As String
    Dim _creater As String
    Dim _newact As Integer
    Dim _SDATE As Date
    Dim _EDATE As Date
    Dim _Provider As String

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

    Public Property newno() As Integer
        Get
            Return _newno
        End Get
        Set(ByVal Value As Integer)
            _newno = Value
        End Set
    End Property



    Public Property newsubject() As String
        Get
            Return _newsubject
        End Get
        Set(ByVal Value As String)
            _newsubject = Value
        End Set
    End Property

    Public Property newcontent() As String
        Get
            Return _newcontent
        End Get
        Set(ByVal Value As String)
            _newcontent = Value
        End Set
    End Property
    Public Property newlink() As String
        Get
            Return _newlink
        End Get
        Set(ByVal Value As String)
            _newlink = Value
        End Set
    End Property


    Public Property creatdate() As String
        Get
            Return _creatdate
        End Get
        Set(ByVal Value As String)
            _creatdate = Value
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
    Public Property newact() As Integer
        Get
            Return _newact
        End Get
        Set(ByVal Value As Integer)
            newact = Value
        End Set
    End Property
End Class
