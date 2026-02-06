Public Class Endownload2 
    Dim _dwno As Integer
    Dim _dwgrp As String
    Dim _dwname As String
    Dim _dwfile As String
    Dim _creater As String
    Dim _createdate As String
    Public Property dwno As Integer
        Get
            Return _dwno
        End Get
        Set(ByVal Value As Integer)
            _dwno = Value
        End Set
    End Property


    Public Property dwgrp As String
        Get
            Return _dwgrp
        End Get
        Set(ByVal Value As String)
            _dwgrp = Value
        End Set
    End Property


    Public Property dwname As String
        Get
            Return _dwname
        End Get
        Set(ByVal Value As String)
            _dwname = Value
        End Set
    End Property


    Public Property dwfile As String
        Get
            Return _dwfile
        End Get
        Set(ByVal Value As String)
            _dwfile = Value
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
