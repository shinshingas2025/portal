Public Class Groups
    Inherits Community
    Dim _GroupID As Integer
    Dim _GroupName As String
    Dim _Description As String

    Public Property GroupID() As Integer
        Get
            Return _GroupID
        End Get
        Set(ByVal Value As Integer)
            _GroupID = Value

        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return _GroupName
        End Get
        Set(ByVal Value As String)
            _GroupName = Value
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


    Public Function QueryGroup(ByVal gpid As Integer) As DataTable
        Dim gpBO As New GroupsBO
        Return (gpBO.Query(gpid))
    End Function

    Public Function InsertGroup(ByVal node As Groups) As Integer

        Dim gpBO As New GroupsBO
        Return gpBO.Insert(node)

    End Function




End Class
