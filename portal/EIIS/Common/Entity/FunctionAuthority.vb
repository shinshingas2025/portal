Public Class FunctionAuthority

    Dim _RoleID As Integer = 0
    Dim _CommID As Integer = 0
    Dim _DomainID As Integer = 0
    Dim _Ilevel As Integer = 0
    Dim _Dlevel As Integer = 0
    Dim _Ulevel As Integer = 0
    Dim _Qlevel As Integer = 0
    Dim _Clevel As Integer = 0

    Public Property RoleID() As Integer
        Get
            Return _RoleID

        End Get
        Set(ByVal Value As Integer)
            _RoleID = Value
        End Set
    End Property

    Public Property CommID() As Integer
        Get
            Return _CommID

        End Get
        Set(ByVal Value As Integer)
            _CommID = Value
        End Set
    End Property

    Public Property DomainID() As Integer
        Get
            Return _DomainID
        End Get
        Set(ByVal Value As Integer)
            _DomainID = Value
        End Set
    End Property

    Public Property Ilevel() As Integer
        Get
            Return _Ilevel
        End Get
        Set(ByVal Value As Integer)
            _Ilevel = Value
        End Set
    End Property
    Public Property Dlevel() As Integer
        Get
            Return _Dlevel
        End Get
        Set(ByVal Value As Integer)
            _Dlevel = Value
        End Set
    End Property

    Public Property Ulevel() As Integer
        Get
            Return _Ulevel
        End Get
        Set(ByVal Value As Integer)
            _Ulevel = Value
        End Set
    End Property

    Public Property Qlevel() As Integer
        Get
            Return _Qlevel
        End Get
        Set(ByVal Value As Integer)
            _Qlevel = Value
        End Set
    End Property
    Public Property Clevel() As Integer
        Get
            Return _Clevel
        End Get
        Set(ByVal Value As Integer)
            _Clevel = Value
        End Set
    End Property
End Class
