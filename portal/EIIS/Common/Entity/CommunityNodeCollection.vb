Public Class CommunityNodeCollection
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As CommunityNode
        Get
            Return CType(List(index), CommunityNode)
        End Get
        Set(ByVal Value As CommunityNode)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal item As CommunityNode) As Integer
        Return List.Add(item)
    End Function

    Public Function IndexOf(ByVal item As CommunityNode) As Integer
        Return List.IndexOf(item)

    End Function
    Public Sub insert(ByVal index As Integer, ByVal item As CommunityNode)
        list.Insert(index, item)

    End Sub
    Public Sub remove(ByVal item As CommunityNode)
        list.Remove(item)
    End Sub
End Class
