Imports EIIS
Imports portal.EIIS

Public Class Domains


    Public Function QueryNode(ByVal node As DomainsNode) As DomainsNode
        Dim objDomainsBO As New DomainsBO

        Return objDomainsBO.Query(node)


    End Function
    Public Sub InsertNode(ByVal node As DomainsNode)
        Dim objDomainsBO As New DomainsBO

        objDomainsBO.Insert(node)

    End Sub

    Public Sub InsertFunction(ByVal node As EIIS.Functions)

        Dim objdomainsBO As New DomainsBO
        objdomainsBO.InsertFunction(node)

    End Sub
    Public Sub UpdateNode(ByVal node As DomainsNode)
        Dim objDomainsBO As New DomainsBO

        objDomainsBO.Update(node)

    End Sub

    Public Sub DeleteNode(ByVal node As DomainsNode)
        Dim objDomainsBO As New DomainsBO
        Dim objFunBO As New FunctionsBO


        objDomainsBO.Delete(node)
        objFunBO.DeletefunctionMaster(node)


    End Sub

    Public Function QueryFunction(ByVal obj As Functions) As DataTable
        Dim objF As New FunctionsBO

        Return objF.Query(obj)

    End Function
    Public Function QueryFunctionList(ByVal obj As String) As DataTable
        Dim objF As New FunctionsBO

        Return objF.QueryList(obj)

    End Function

    Public Function GetMapDataByCommunityObjID(ByVal objID As Integer) As DataTable
        Dim dm As New DomainsBO
        Return dm.GetMapDataByCommunityObjID(objID)

    End Function
    Public Function GetFunctionMapDataByCommunityObjID(ByVal objID As Integer) As DataTable
        Dim dm As New FunctionsBO
        Return dm.getFunctionByCommunityObjID(objID)

    End Function

    Public Function UpdateFunctionMaster(ByVal fn As EIIS.Functions) As Integer
        Dim fnBO As New FunctionsBO
        fnBO.Update(fn)
        Return 0
    End Function

End Class




