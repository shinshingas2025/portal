Public Class Enscale 
    Dim _scno As Integer
    Dim _scnumber As String
    Dim _sctel As String
    Dim _scnotes As String
    Dim _createdate As String
    Public Property scno As Integer
        Get
            Return _scno
        End Get
        Set(ByVal Value As Integer)
            _scno = Value
        End Set
    End Property


    Public Property scnumber As String
        Get
            Return _scnumber
        End Get
        Set(ByVal Value As String)
            _scnumber = Value
        End Set
    End Property


    Public Property sctel As String
        Get
            Return _sctel
        End Get
        Set(ByVal Value As String)
            _sctel = Value
        End Set
    End Property


    Public Property scnotes As String
        Get
            Return _scnotes
        End Get
        Set(ByVal Value As String)
            _scnotes = Value
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
