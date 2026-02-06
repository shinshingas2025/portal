Public Class Enfaq 
    Dim _faqno As Integer
    Dim _faqgrp As String
    Dim _faqquestion As String
    Dim _faqanswer As String
    Dim _creater As String
    Dim _createdate As String
    Dim _Provider As String
    '1120327 add 
    Dim _faqsort As Integer

    Public Property Provider() As String
        Get
            Return _Provider
        End Get
        Set(ByVal Value As String)
            _Provider = Value
        End Set
    End Property

    Public Property faqno() As Integer
        Get
            Return _faqno
        End Get
        Set(ByVal Value As Integer)
            _faqno = Value
        End Set
    End Property


    Public Property faqsort() As Integer
        Get
            Return _faqsort
        End Get
        Set(ByVal Value As Integer)
            _faqsort = Value
        End Set
    End Property


    Public Property faqgrp() As String
        Get
            Return _faqgrp
        End Get
        Set(ByVal Value As String)
            _faqgrp = Value
        End Set
    End Property


    Public Property faqquestion() As String
        Get
            Return _faqquestion
        End Get
        Set(ByVal Value As String)
            _faqquestion = Value
        End Set
    End Property


    Public Property faqanswer() As String
        Get
            Return _faqanswer
        End Get
        Set(ByVal Value As String)
            _faqanswer = Value
        End Set
    End Property


    Public Property creater() As String
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


End Class
