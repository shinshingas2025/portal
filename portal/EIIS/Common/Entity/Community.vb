Public Class Community
    Inherits CommunityNode

    Dim _ParentNode As CommunityNodeCollection
    Dim _ChildNode As CommunityNodeCollection



    Public Property ParentNodes() As CommunityNodeCollection
        Get
            Return _ParentNode
        End Get
        Set(ByVal Value As CommunityNodeCollection)
            _ParentNode = Value
        End Set
    End Property

    Public Property ChildNodes() As CommunityNodeCollection
        Get
            Return _ChildNode
        End Get
        Set(ByVal Value As CommunityNodeCollection)
            _ChildNode = Value
        End Set
    End Property

    Public Sub getRelationNodes(ByVal objID As Integer)

        Dim objCommBO As New CommunityBO
        Dim objCommNode As New CommunityNode
        Dim objCommCol As New CommunityNodeCollection
        objCommNode.PID = objID
        objCommCol = objCommBO.Query(objCommNode)
        _ChildNode = objCommCol
        objCommNode.Clear()
        objCommNode.objID = objID
        objCommCol = objCommBO.Query(objCommNode)
        _ParentNode = objCommCol


    End Sub

    Public Sub InsertNode(ByVal node As CommunityNode)
        Dim objCommBO As New CommunityBO

        objCommBO.Insert(node)




    End Sub

    Public Sub DeleteMapFunction(ByVal Roleid As Integer)
        Dim objCommBO As New CommunityBO

        objCommBO.DeleteMapFunction(Roleid)


    End Sub

    Public Sub AddMapFunction(ByVal commid As Integer, ByVal domainid As Integer)
        Dim objCommBO As New CommunityBO

        objCommBO.AddMapFunction(commid, domainid)

    End Sub

    Public Function UpdateFunctionAuthority(ByVal fa As FunctionAuthority) As Integer
        Dim objcommBo As New CommunityBO
        objcommBo.UpdateFunctionAuthority(fa)
    End Function

    Public Sub UpdateNode(ByVal node As CommunityNode)
        Dim objCommBO As New CommunityBO

        objCommBO.Update(node)

    End Sub

    Public Sub DeleteNode(ByVal node As CommunityNode)
        Dim objCommBO As New CommunityBO

        objCommBO.Delete(node)

    End Sub


    Public Function QueryNode(ByVal cn As CommunityNode) As CommunityNodeCollection
        Dim objCommBO As New CommunityBO
        Return objCommBO.Query(cn)
    End Function

End Class
