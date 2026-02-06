Public Class Enproducts 
    Dim _pdno As Integer
    Dim _pdgrp As String
    Dim _pdname As String
    Dim _pdintor As String
    Dim _pdcontent As String
    Dim _pdimages As String
    Dim _pdcompany As String
    Dim _pdcompanyinfor As String
    Dim _pdcompanylink As String
    Dim _creater As String
    Dim _createdate As String
    Dim _pdAccount As String

    Public Property pdno As Integer
        Get
            Return _pdno
        End Get
        Set(ByVal Value As Integer)
            _pdno = Value
        End Set
    End Property


    Public Property pdgrp As String
        Get
            Return _pdgrp
        End Get
        Set(ByVal Value As String)
            _pdgrp = Value
        End Set
    End Property


    Public Property pdname As String
        Get
            Return _pdname
        End Get
        Set(ByVal Value As String)
            _pdname = Value
        End Set
    End Property


    Public Property pdintor As String
        Get
            Return _pdintor
        End Get
        Set(ByVal Value As String)
            _pdintor = Value
        End Set
    End Property


    Public Property pdcontent As String
        Get
            Return _pdcontent
        End Get
        Set(ByVal Value As String)
            _pdcontent = Value
        End Set
    End Property


    Public Property pdimages As String
        Get
            Return _pdimages
        End Get
        Set(ByVal Value As String)
            _pdimages = Value
        End Set
    End Property


    Public Property pdcompany As String
        Get
            Return _pdcompany
        End Get
        Set(ByVal Value As String)
            _pdcompany = Value
        End Set
    End Property


    Public Property pdcompanyinfor As String
        Get
            Return _pdcompanyinfor
        End Get
        Set(ByVal Value As String)
            _pdcompanyinfor = Value
        End Set
    End Property


    Public Property pdcompanylink As String
        Get
            Return _pdcompanylink
        End Get
        Set(ByVal Value As String)
            _pdcompanylink = Value
        End Set
    End Property


    Public Property creater As String
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

    Public Property pdAccount() As String
        Get
            Return _pdAccount
        End Get
        Set(ByVal Value As String)
            _pdAccount = Value
        End Set
    End Property
End Class
