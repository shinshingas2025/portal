Public Class Enifor
    Dim _iforno As Integer
    Dim _iforsubject As String
    Dim _iforcontent As String
    Dim _iforenddate As String
    Dim _creatdate As String
    Dim _creater As String
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

    Public Property iforno() As Integer
        Get
            Return _iforno
        End Get
        Set(ByVal Value As Integer)
            _iforno = Value
        End Set
    End Property

    Public Property iforsubject() As String
        Get
            Return _iforsubject
        End Get
        Set(ByVal Value As String)
            _iforsubject = Value
        End Set
    End Property

    Public Property iforcontent() As String
        Get
            Return _iforcontent
        End Get
        Set(ByVal Value As String)
            _iforcontent = Value
        End Set
    End Property
    Public Property iforenddate() As String
        Get
            Return _iforenddate
        End Get
        Set(ByVal Value As String)
            _iforenddate = Value
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
End Class
