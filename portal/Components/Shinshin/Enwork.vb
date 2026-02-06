Public Class Enwork 
    Dim _workno As Integer
    Dim _workgroup As String
    Dim _worksubject As String
    Dim _workwkdate As String
    Dim _workwktime As String

    Dim _workwkdateend As String
    Dim _workwktimeend As String

    Dim _workmember As String
    Dim _workcontroler As String
    Dim _workuser As String
    Dim _workdate As String
    Dim _creater As String
    Dim _createdate As String
    Dim _SDATE As Date
    Dim _EDATE As Date
    Dim _Provider As String
    Dim _WorkAddress As String
    Dim _checker As String
    Dim _tel As String
    Dim _modifier As String
    Dim _modifydate As String


    Public Property workwktime() As String
        Get
            Return _workwktime
        End Get
        Set(ByVal Value As String)
            _workwktime = Value
        End Set
    End Property

    Public Property checker() As String
        Get
            Return _checker
        End Get
        Set(ByVal Value As String)
            _checker = Value
        End Set
    End Property
    Public Property tel() As String
        Get
            Return _tel
        End Get
        Set(ByVal Value As String)
            _tel = Value
        End Set
    End Property

    Public Property WorkAddress() As String
        Get
            Return _WorkAddress
        End Get
        Set(ByVal Value As String)
            _WorkAddress = Value
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
    Public Property workno() As Integer
        Get
            Return _workno
        End Get
        Set(ByVal Value As Integer)
            _workno = Value
        End Set
    End Property


    Public Property workgroup() As String
        Get
            Return _workgroup
        End Get
        Set(ByVal Value As String)
            _workgroup = Value
        End Set
    End Property


    Public Property worksubject() As String
        Get
            Return _worksubject
        End Get
        Set(ByVal Value As String)
            _worksubject = Value
        End Set
    End Property


    Public Property workwkdate() As String
        Get
            Return _workwkdate
        End Get
        Set(ByVal Value As String)
            _workwkdate = Value
        End Set
    End Property


    Public Property workmember() As String
        Get
            Return _workmember
        End Get
        Set(ByVal Value As String)
            _workmember = Value
        End Set
    End Property


    Public Property workcontroler() As String
        Get
            Return _workcontroler
        End Get
        Set(ByVal Value As String)
            _workcontroler = Value
        End Set
    End Property


    Public Property workuser() As String
        Get
            Return _workuser
        End Get
        Set(ByVal Value As String)
            _workuser = Value
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


    Public Property workwktimeend() As String
        Get
            Return _workwktimeend
        End Get
        Set(ByVal Value As String)
            _workwktimeend = Value
        End Set
    End Property

    Public Property workwkdateend() As String
        Get
            Return _workwkdateend
        End Get
        Set(ByVal Value As String)
            _workwkdateend = Value
        End Set
    End Property
End Class
