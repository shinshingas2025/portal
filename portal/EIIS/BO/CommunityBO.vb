Public Class CommunityBO
    Public Function Query(ByVal objNode As CommunityNode) As CommunityNodeCollection

        Dim dt As New DataTable
        Dim strSQL As String = ""
        Dim i As Integer

        strSQL = "Select * From sysCommunity where "
        If objNode.objID > -1 Then
            strSQL = strSQL & " objID= " & objNode.objID
        End If

        If objNode.PID > -1 Then
            strSQL = strSQL & " PID= " & objNode.PID
        End If

        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Dim node As New CommunityNode
        Dim nodes As New CommunityNodeCollection

        For i = 0 To dt.Rows.Count - 1

            node.objID = CType(dt.Rows(i).Item("objID"), Integer)
            node.objName = CType(dt.Rows(i).Item("objName"), String)
            node.objValue = CType(dt.Rows(i).Item("objValue"), String)
            node.PID = CType(dt.Rows(i).Item("PID"), Integer)
            node.SEQNO = CType(dt.Rows(i).Item("SEQNO"), String)
            node.state = CType(dt.Rows(i).Item("state"), String)
            node.srcName = CType(dt.Rows(i).Item("srcName"), String)

            nodes.Add(node)

        Next

        Return nodes

    End Function


    Public Function Insert(ByVal node As CommunityNode) As Integer

        Dim strSQL As String = ""

        strSQL = "INSERT INTO sysCommunity (objName,objValue,PID,SEQNO,state) values ("
        strSQL &= "'" & node.objName.Trim & "',"
        strSQL &= "'" & node.objValue.Trim & "',"
        strSQL &= "'" & node.PID & "',"
        strSQL &= "'" & node.SEQNO.Trim & "',"
        strSQL &= "'" & node.state.Trim & "'"
        strSQL &= ")"

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function

    Public Function Update(ByVal node As CommunityNode) As Integer


        Dim strSQL As String = ""

        strSQL = "UPDATE sysCommunity set "
        strSQL &= "objName='" & node.objName.Trim & "',"
        strSQL &= "objValue='" & node.objValue.Trim & "',"
        strSQL &= "PID=" & node.PID & ","
        strSQL &= "SEQNO='" & node.SEQNO.Trim & "',"
        strSQL &= "state='" & node.state.Trim & "'"
        strSQL &= " Where objID=" & node.objID

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function

    Public Function Delete(ByVal node As CommunityNode) As Integer


        Dim strSQL As String = ""


        strSQL = "Delete sysUserInfo where UID in (Select ObjValue from sysCommunity  Where objID=" & node.objID & ");"
        strSQL &= "DELETE sysCommunity  Where objID=" & node.objID & ";"
        strSQL &= "DELETE sysSecurity  Where UID=" & node.objID
        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function

    Public Function DeleteMapFunction(ByVal RoleID As Integer) As Integer


        Dim strSQL As String = ""

        strSQL = "DELETE sysRoles  Where RoleID=" & RoleID

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function

    Public Function AddMapFunction(ByVal CommID As Integer, ByVal DomainID As Integer) As Integer
        Dim strSQL As String = ""

        strSQL = "INSERT INTO sysRoles (Commid,DomainID) values (" & CommID & "," & DomainID & ")"

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function

    Public Function UpdateFunctionAuthority(ByVal fa As FunctionAuthority) As Integer
        Dim strSQL As String = ""

        strSQL = " UPDATE  sysRoles set "
        strSQL &= " Ilevel=" & fa.Ilevel & ","
        strSQL &= " Dlevel=" & fa.Dlevel & ","
        strSQL &= " Ulevel=" & fa.Ulevel & ","
        strSQL &= " Qlevel=" & fa.Qlevel & ","
        strSQL &= " Clevel=" & fa.Clevel

        If fa.RoleID = 0 Then
            strSQL &= " Where Commid=" & fa.CommID & " and " & " DomainID=" & CType(fa.DomainID, Integer)
        Else
            strSQL &= " Where RoleID=" & fa.RoleID
        End If

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

    End Function

End Class
