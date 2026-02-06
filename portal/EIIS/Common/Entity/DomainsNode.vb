Imports EIIS
Imports portal.EIIS

Public Class DomainsNode
    Inherits CommunityNode

    Private _typecode As String
    Private _DataType As String

    Public Property typecode() As String

        Get
            Return _typecode
        End Get
        Set(ByVal Value As String)
            _typecode = Value
        End Set

    End Property
    Public Property DataType() As String

        Get
            Return _DataType
        End Get
        Set(ByVal Value As String)
            _DataType = Value
        End Set

    End Property


    Public Function InsertJoblist(ByVal node As DomainsNode) As Integer
        Dim jlBO As New DomainsBO
        Return jlBO.Insert(node)
    End Function
End Class
