Public Class Enreceiptad
    Dim _adno As Integer
    Dim _ad_content1 As String
    Dim _ad_content2 As String
    Dim _ad_content3 As String
    Dim _ad_start_date As Date
    Dim _ad_end_date As Date
    Dim _upd_user As String

    Public Property adno() As Integer
        Get
            Return _adno
        End Get
        Set(ByVal Value As Integer)
            _adno = Value
        End Set
    End Property


    Public Property ad_content1() As String
        Get
            Return _ad_content1
        End Get
        Set(ByVal Value As String)
            _ad_content1 = Value
        End Set
    End Property


    Public Property ad_content2() As String
        Get
            Return _ad_content2
        End Get
        Set(ByVal Value As String)
            _ad_content2 = Value
        End Set
    End Property

    Public Property ad_content3() As String
        Get
            Return _ad_content3
        End Get
        Set(ByVal Value As String)
            _ad_content3 = Value
        End Set
    End Property

    Public Property ad_start_date() As Date
        Get
            Return _ad_start_date
        End Get
        Set(ByVal Value As Date)
            _ad_start_date = Value
        End Set
    End Property

    Public Property ad_end_date() As Date
        Get
            Return _ad_end_date
        End Get
        Set(ByVal Value As Date)
            _ad_end_date = Value
        End Set
    End Property

    Public Property upd_user() As String
        Get
            Return _upd_user
        End Get
        Set(ByVal Value As String)
            _upd_user = Value
        End Set
    End Property

End Class
