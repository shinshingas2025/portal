Public Class Enmsg 
    Dim _msgno As Integer
    Dim _msgsubject As String
    Dim _msgenddate As String
    Dim _creater As String
    Dim _createdate As String
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

    Public Property msgno() As Integer
        Get
            Return _msgno
        End Get
        Set(ByVal Value As Integer)
            _msgno = Value
        End Set
    End Property


    Public Property msgsubject() As String
        Get
            Return _msgsubject
        End Get
        Set(ByVal Value As String)
            _msgsubject = Value
        End Set
    End Property


    Public Property msgenddate() As String
        Get
            Return _msgenddate
        End Get
        Set(ByVal Value As String)
            _msgenddate = Value
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


End Class
