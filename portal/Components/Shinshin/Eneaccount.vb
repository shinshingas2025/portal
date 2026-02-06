Public Class Eneaccount 
    Dim _acno As Integer
    Dim _acnumber As String
    Dim _actel As String
    Dim _acemail As String
    Dim _createdate As String
    Public Property acno As Integer
        Get
            Return _acno
        End Get
        Set(ByVal Value As Integer)
            _acno = Value
        End Set
    End Property


    Public Property acnumber As String
        Get
            Return _acnumber
        End Get
        Set(ByVal Value As String)
            _acnumber = Value
        End Set
    End Property


    Public Property actel As String
        Get
            Return _actel
        End Get
        Set(ByVal Value As String)
            _actel = Value
        End Set
    End Property


    Public Property acemail As String
        Get
            Return _acemail
        End Get
        Set(ByVal Value As String)
            _acemail = Value
        End Set
    End Property


    Public Property createdate As String
        Get
            Return _createdate
        End Get
        Set(ByVal Value As String)
            _createdate = Value
        End Set
    End Property


End Class
