Public Class Memberhouse
    Dim _mh_no As Integer
    Dim _mh_wm_no As Integer
    Dim _mh_house_no As String
    Dim _mh_ers_flag As String
    Dim _upd_user As String
    Dim _mh_gen_user As String  'add 1120925 
    Dim _mh_gen_dept As String ' add 1121117 

    Public Property mh_no() As Integer
        Get
            Return _mh_no
        End Get
        Set(ByVal Value As Integer)
            _mh_no = Value
        End Set
    End Property


    Public Property mh_wm_no() As Integer
        Get
            Return _mh_wm_no
        End Get
        Set(ByVal Value As Integer)
            _mh_wm_no = Value
        End Set
    End Property
    Public Property mh_house_no() As String
        Get
            Return _mh_house_no
        End Get
        Set(ByVal Value As String)
            _mh_house_no = Value
        End Set
    End Property

    '1120925 推廣人員
    Public Property mh_gen_user() As String
        Get
            Return _mh_gen_user
        End Get
        Set(ByVal Value As String)
            _mh_gen_user = Value
        End Set
    End Property
    '1121117 推廣人員單位
    Public Property mh_gen_dept() As String
        Get
            Return _mh_gen_dept
        End Get
        Set(ByVal Value As String)
            _mh_gen_dept = Value
        End Set
    End Property

    Public Property mh_ers_flag() As String
        Get
            Return _mh_ers_flag
        End Get
        Set(ByVal Value As String)
            _mh_ers_flag = Value
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
