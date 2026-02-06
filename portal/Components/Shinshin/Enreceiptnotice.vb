Public Class Enreceiptnotice
    Dim _noticeno As Integer
    Dim _notice_content1 As String
    Dim _notice_content2 As String
    Dim _notice_content3 As String
    Dim _notice_content4 As String
    Dim _notice_content5 As String
    Dim _notice_content6 As String
    Dim _notice_line As Integer
    Dim _upd_user As String

    Public Property noticeno() As Integer
        Get
            Return _noticeno
        End Get
        Set(ByVal Value As Integer)
            _noticeno = Value
        End Set
    End Property

    Public Property notice_content1() As String
        Get
            Return _notice_content1
        End Get
        Set(ByVal Value As String)
            _notice_content1 = Value
        End Set
    End Property

    Public Property notice_content2() As String
        Get
            Return _notice_content2
        End Get
        Set(ByVal Value As String)
            _notice_content2 = Value
        End Set
    End Property

    Public Property notice_content3() As String
        Get
            Return _notice_content3
        End Get
        Set(ByVal Value As String)
            _notice_content3 = Value
        End Set
    End Property

    Public Property notice_content4() As String
        Get
            Return _notice_content4
        End Get
        Set(ByVal Value As String)
            _notice_content4 = Value
        End Set
    End Property

    Public Property notice_content5() As String
        Get
            Return _notice_content5
        End Get
        Set(ByVal Value As String)
            _notice_content5 = Value
        End Set
    End Property

    Public Property notice_content6() As String
        Get
            Return _notice_content6
        End Get
        Set(ByVal Value As String)
            _notice_content6 = Value
        End Set
    End Property

    Public Property notice_line() As Integer
        Get
            Return _notice_line
        End Get
        Set(ByVal Value As Integer)
            _notice_line = Value
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
