Public Class Enmember 
    Dim _memno As Integer
    Dim _memaccount As String
    Dim _mempasswd As String
    Public Property memno As Integer
        Get
            Return _memno
        End Get
        Set(ByVal Value As Integer)
            _memno = Value
        End Set
    End Property


    Public Property memaccount As String
        Get
            Return _memaccount
        End Get
        Set(ByVal Value As String)
            _memaccount = Value
        End Set
    End Property


    Public Property mempasswd As String
        Get
            Return _mempasswd
        End Get
        Set(ByVal Value As String)
            _mempasswd = Value
        End Set
    End Property


End Class
