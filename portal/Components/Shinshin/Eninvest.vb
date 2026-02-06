Public Class Eninvest 
    Dim _invno As Integer
    Dim _invgrp As String
    Dim _invname As String
    Dim _invfile As String
    Dim _creater As String
    Dim _createdate As String
    Public Property invno As Integer
        Get
            Return _invno
        End Get
        Set(ByVal Value As Integer)
            _invno = Value
        End Set
    End Property


    Public Property invgrp As String
        Get
            Return _invgrp
        End Get
        Set(ByVal Value As String)
            _invgrp = Value
        End Set
    End Property


    Public Property invname As String
        Get
            Return _invname
        End Get
        Set(ByVal Value As String)
            _invname = Value
        End Set
    End Property


    Public Property invfile As String
        Get
            Return _invfile
        End Get
        Set(ByVal Value As String)
            _invfile = Value
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
