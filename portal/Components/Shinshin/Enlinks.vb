Public Class Enlinks 
    Dim _lkno As Integer
    Dim _lkgrp As String
    Dim _lkname As String
    Dim _lkurl As String
    Dim _creater As String
    Dim _createdate As String
    Public Property lkno As Integer
        Get
            Return _lkno
        End Get
        Set(ByVal Value As Integer)
            _lkno = Value
        End Set
    End Property


    Public Property lkgrp As String
        Get
            Return _lkgrp
        End Get
        Set(ByVal Value As String)
            _lkgrp = Value
        End Set
    End Property


    Public Property lkname As String
        Get
            Return _lkname
        End Get
        Set(ByVal Value As String)
            _lkname = Value
        End Set
    End Property


    Public Property lkurl As String
        Get
            Return _lkurl
        End Get
        Set(ByVal Value As String)
            _lkurl = Value
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


    Public Property createdate As String
        Get
            Return _createdate
        End Get
        Set(ByVal Value As String)
            _createdate = Value
        End Set
    End Property


End Class
