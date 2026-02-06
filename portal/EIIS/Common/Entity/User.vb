Public Class User
    Inherits Community


    Dim _UID As String
    Dim _U_Class As String
    Dim _Cname As String
    Dim _Ename As String
    Dim _Alias1 As String
    Dim _IDNum As String
    Dim _Sex As Int16
    Dim _Addr_ZIP As String
    Dim _Addr_DIV As String
    Dim _Addr_VIL As String
    Dim _Addr_DOOR As String
    Dim _nation As String
    Dim _TelCompany As String
    Dim _TelHome As String
    Dim _TelMobile As String
    Dim _Email As String
    Dim _HomePage As String
    Dim _Company As String
    Dim _Dept As String
    Dim _Title As String
    Dim _mask As Integer

    Public Property TelMobile() As String
        Get
            Return _TelMobile
        End Get
        Set(ByVal Value As String)
            _TelMobile = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property
    Public Property HomePage() As String
        Get
            Return _HomePage
        End Get
        Set(ByVal Value As String)
            _HomePage = Value
        End Set
    End Property
    Public Property Company() As String
        Get
            Return _Company
        End Get
        Set(ByVal Value As String)
            _Company = Value
        End Set
    End Property
    Public Property Dept() As String
        Get
            Return _Dept
        End Get
        Set(ByVal Value As String)
            _Dept = Value
        End Set
    End Property
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            _Title = Value
        End Set
    End Property

    Public Property mask() As Integer
        Get
            Return _mask
        End Get
        Set(ByVal Value As Integer)

            _mask = Value
        End Set
    End Property
    Public Property Alias1() As String
        Get
            Return _Alias1
        End Get
        Set(ByVal Value As String)
            _Alias1 = Value
        End Set
    End Property
    Public Property IDNum() As String
        Get
            Return _IDNum
        End Get
        Set(ByVal Value As String)
            _IDNum = Value
        End Set
    End Property
    Public Property Sex() As Int16
        Get
            Return _Sex
        End Get
        Set(ByVal Value As Int16)
            If CType(Value, Boolean) = True Then
                _Sex = 1
            Else
                _Sex = 0
            End If

        End Set
    End Property
    Public Property Addr_ZIP() As String
        Get
            Return _Addr_ZIP
        End Get
        Set(ByVal Value As String)
            _Addr_ZIP = Value
        End Set
    End Property
    Public Property Addr_DIV() As String
        Get
            Return _Addr_DIV
        End Get
        Set(ByVal Value As String)
            _Addr_DIV = Value
        End Set
    End Property
    Public Property Addr_VIL() As String
        Get
            Return _Addr_VIL
        End Get
        Set(ByVal Value As String)
            _Addr_VIL = Value
        End Set
    End Property
    Public Property Addr_DOOR() As String
        Get
            Return _Addr_DOOR
        End Get
        Set(ByVal Value As String)
            _Addr_DOOR = Value
        End Set
    End Property
    Public Property nation() As String
        Get
            Return _nation
        End Get
        Set(ByVal Value As String)
            _nation = Value
        End Set
    End Property
    Public Property TelCompany() As String
        Get
            Return _TelCompany
        End Get
        Set(ByVal Value As String)
            _TelCompany = Value
        End Set
    End Property
    Public Property TelHome() As String
        Get
            Return _TelHome
        End Get
        Set(ByVal Value As String)
            _TelHome = Value
        End Set
    End Property


    Public Property UID() As String
        Get
            Return _UID
        End Get
        Set(ByVal Value As String)
            _UID = Value
        End Set
    End Property

    Public Property U_Class() As String
        Get
            Return _U_Class
        End Get
        Set(ByVal Value As String)
            _U_Class = Value
        End Set
    End Property

    Public Property Cname() As String
        Get
            Return _Cname
        End Get
        Set(ByVal Value As String)
            _Cname = Value
        End Set
    End Property

    Public Property Ename() As String
        Get
            Return _Ename
        End Get
        Set(ByVal Value As String)
            _Ename = Value
        End Set
    End Property


    Public Function QueryUserInfo(ByVal UID As String) As DataTable
        Dim urBO As New UserInfoBO
        Return (urBO.QueryUserInfo(UID))
    End Function

    Public Function QueryUserInfoNode(ByVal UID As String) As Integer
        Dim urBO As New UserInfoBO
        Dim dt As DataTable
        dt = urBO.QueryUserInfo(UID)
        If dt.Rows.Count > 0 Then
            Cname = CType(dt.Rows(0).Item("Cname"), String)
            U_Class = CType(dt.Rows(0).Item("U_Class"), String)
            Alias1 = CType(dt.Rows(0).Item("Alias"), String)

            Ename = CType(dt.Rows(0).Item("Ename"), String)
            IDNum = CType(dt.Rows(0).Item("IDNum"), String)
            Sex = CType(dt.Rows(0).Item("Sex"), Short)
            Addr_ZIP = CType(dt.Rows(0).Item("Addr_zip"), String)
            Addr_DIV = CType(dt.Rows(0).Item("Addr_div"), String)
            Addr_VIL = CType(dt.Rows(0).Item("Addr_vil"), String)
            Addr_DOOR = CType(dt.Rows(0).Item("Addr_door"), String)
            nation = CType(dt.Rows(0).Item("nation"), String)

            Company = CType(dt.Rows(0).Item("Company"), String)
            TelMobile = CType(dt.Rows(0).Item("Telmobile"), String)
            TelHome = CType(dt.Rows(0).Item("Telhome"), String)
            TelCompany = CType(dt.Rows(0).Item("Telcompany"), String)
            Dept = CType(dt.Rows(0).Item("Dept"), String)
            Title = CType(dt.Rows(0).Item("title"), String)
            mask = CType(dt.Rows(0).Item("mask"), Integer)
            HomePage = CType(dt.Rows(0).Item("Homepage"), String)
            Email = CType(dt.Rows(0).Item("Email"), String)

        End If
        Return 0
    End Function


    Public Function InsertUserInfo(ByVal node As User) As Integer
        Dim urBO As New UserInfoBO


        Return urBO.InsertUserInfo(node)
    End Function


    Public Function UpdateUserInfo(ByVal node As User) As Integer
        Dim urBO As New UserInfoBO


        Return urBO.UpdateUserInfo(node)
    End Function


End Class
