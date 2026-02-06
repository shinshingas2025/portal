Namespace EIIS
    Public Class Functions
        Inherits DomainsNode

        Dim _funNo As Integer
        Dim _JobID As String
        Dim _FunctionID As String
        Dim _Description As String
        Dim _APID As String
        Dim _ExeFileName As String
        Dim _LogicalFilePath As String
        Dim _ExeCMDLine As String




        'New Add for Â¾°Vmodule attribute
        Dim _PaneName As String
        Dim _ModuleDefid As Integer

        Public Property ModuleDefid() As Integer
            Get
                Return _ModuleDefid
            End Get
            Set(ByVal Value As Integer)
                _ModuleDefid = Value
            End Set
        End Property


        Public Property PaneName() As String
            Get
                Return _PaneName
            End Get
            Set(ByVal Value As String)
                _PaneName = Value
            End Set
        End Property


        Public Property funNo() As Integer
            Get
                Return _funNo
            End Get
            Set(ByVal Value As Integer)
                _funNo = Value
            End Set
        End Property

        Public Property JobID() As String
            Get
                Return _JobID
            End Get
            Set(ByVal Value As String)
                _JobID = Value
            End Set
        End Property
        Public Property FunctionID() As String
            Get
                Return _FunctionID
            End Get
            Set(ByVal Value As String)
                _FunctionID = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property
        Public Property APID() As String
            Get
                Return _APID
            End Get
            Set(ByVal Value As String)
                _APID = Value
            End Set
        End Property
        Public Property ExeFileName() As String
            Get
                Return _ExeFileName
            End Get
            Set(ByVal Value As String)
                _ExeFileName = Value
            End Set
        End Property
        Public Property LogicalFilePath() As String
            Get
                Return _LogicalFilePath
            End Get
            Set(ByVal Value As String)
                _LogicalFilePath = Value
            End Set
        End Property
        Public Property ExeCMDLine() As String
            Get
                Return _ExeCMDLine
            End Get
            Set(ByVal Value As String)
                _ExeCMDLine = Value
            End Set
        End Property




    End Class
End Namespace