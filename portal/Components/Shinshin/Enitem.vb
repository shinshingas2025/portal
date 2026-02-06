Public Class Enitem 
    Dim _no As Integer
    Dim _it_parentno As String
    Dim _it_type As String
    Dim _it_name As String
    Dim _it_note1 As String
    Dim _it_note2 As String
    Dim _it_order As String
    Dim _it_act As Integer
    Public Property no As Integer
        Get
            Return _no
        End Get
        Set(ByVal Value As Integer)
            _no = Value
        End Set
    End Property


    Public Property it_parentno() As String
        Get
            Return _it_parentno
        End Get
        Set(ByVal Value As String)
            _it_parentno = Value
        End Set
    End Property


    Public Property it_type() As String
        Get
            Return _it_type
        End Get
        Set(ByVal Value As String)
            _it_type = Value
        End Set
    End Property


    Public Property it_name() As String
        Get
            Return _it_name
        End Get
        Set(ByVal Value As String)
            _it_name = Value
        End Set
    End Property


    Public Property it_note1() As String
        Get
            Return _it_note1
        End Get
        Set(ByVal Value As String)
            _it_note1 = Value
        End Set
    End Property


    Public Property it_note2() As String
        Get
            Return _it_note2
        End Get
        Set(ByVal Value As String)
            _it_note2 = Value
        End Set
    End Property


    Public Property it_order() As String
        Get
            Return _it_order
        End Get
        Set(ByVal Value As String)
            _it_order = Value
        End Set
    End Property


    Public Property it_act() As Integer
        Get
            Return _it_act
        End Get
        Set(ByVal Value As Integer)
            _it_act = Value
        End Set
    End Property


End Class
