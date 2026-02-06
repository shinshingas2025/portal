Namespace EIIS
    Public Class DomainsBO

        Public Function Query(ByVal objNode As DomainsNode) As DomainsNode

            Dim strSQL As String = ""
            Dim dt As New DataTable

            strSQL = "Select * from  sysDomains  Where objID=" & objNode.objID

            Dim conn As New DBConn
            dt = conn.ReadDataTable(strSQL)
            conn.close()
            Dim i As Integer
            Dim node As New DomainsNode
            For i = 0 To dt.Rows.Count - 1
                node.objID = CType(dt.Rows(i).Item("objID"), Integer)
                node.objName = CType(dt.Rows(i).Item("objName"), String)
                node.objValue = CType(dt.Rows(i).Item("objValue"), String)
                node.PID = CType(dt.Rows(i).Item("PID"), Integer)
                node.SEQNO = CType(dt.Rows(i).Item("SEQNO"), String)
                node.state = CType(dt.Rows(i).Item("state"), String)
                node.srcName = CType(dt.Rows(i).Item("srcName"), String)
            Next i

            Return node
        End Function
        Public Function InsertFunction(ByVal node As EIIS.Functions) As Integer

            Dim strSQL As String = ""

            strSQL &= "INSERT INTO sysFunctionMaster  (FunctionID,Description,ExeFileName,LogicalFilePath,PaneName,ModuleDefid,ExeCMDLine) values ("
            strSQL &= "'" & node.FunctionID.Trim & "',"
            strSQL &= "'" & node.Description.Trim & "',"
            strSQL &= "'" & node.ExeFileName & "',"
            strSQL &= "'" & node.LogicalFilePath.Trim & "',"
            strSQL &= "'" & node.PaneName.Trim & "',"
            strSQL &= "" & node.ModuleDefid & ","
            strSQL &= "'" & node.ExeCMDLine.Trim & "'"
            strSQL &= ");"
            strSQL &= "INSERT INTO sysDomains  (objName,objValue,PID,SEQNO,state,datatype,srcName) values ("
            strSQL &= "'" & node.objName.Trim & "',"
            strSQL &= "@@identity,"
            strSQL &= "" & node.PID & ","
            strSQL &= "" & node.SEQNO.Trim & ","
            strSQL &= "'" & node.state.Trim & "',"
            strSQL &= "'" & node.DataType.Trim & "',"
            strSQL &= "'" & node.srcName.Trim & "'"
            strSQL &= ");"



            Dim conn As New DBConn
            conn.ExecuteNonQuery(strSQL)
            conn.close()

            Return 0

        End Function

        Public Function Insert(ByVal node As DomainsNode) As Integer

            Dim strSQL As String = ""

            strSQL = "INSERT INTO sysDomains  (objName,objValue,PID,SEQNO,state,datatype,srcName) values ("
            strSQL &= "'" & node.objName.Trim & "',"
            strSQL &= "'" & node.objValue.Trim & "',"
            strSQL &= "'" & node.PID & "',"
            strSQL &= "'" & node.SEQNO.Trim & "',"
            strSQL &= "'" & node.state.Trim & "',"
            strSQL &= "'" & node.DataType.Trim & "',"
            strSQL &= "'" & node.srcName.Trim & "'"
            strSQL &= ")"

            Dim conn As New DBConn
            conn.ExecuteNonQuery(strSQL)
            conn.close()

            Return 0

        End Function

        Public Function Update(ByVal node As DomainsNode) As Integer


            Dim strSQL As String = ""

            strSQL = "UPDATE sysDomains set "
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

        Public Function Delete(ByVal node As DomainsNode) As Integer


            Dim strSQL As String = ""

            strSQL = "DELETE sysDomains  Where objID=" & node.objID

            Dim conn As New DBConn
            conn.ExecuteNonQuery(strSQL)
            conn.close()

            Return 0
        End Function


        Public Function GetMapDataByCommunityObjID(ByVal objID As Integer) As DataTable
            Dim strSQL As String = ""
            Dim dt As DataTable
            strSQL = " SELECT B.RoleID,B.CommID, B.DomainID, A.objName, A.objValue, A.srcName ,B.Ilevel,B.Dlevel,B.Ulevel,B.Qlevel,B.Clevel"
            strSQL &= " FROM dbo.sysDomains A INNER JOIN"
            strSQL &= " dbo.sysRoles B INNER JOIN"
            strSQL &= "  dbo.sysCommunity C ON B.CommID = C.objID ON A.objID = B.DomainID"
            strSQL &= " Where commID=" & objID
            Dim conn As New DBConn
            dt = conn.ReadDataTable(strSQL)
            conn.close()
            Return dt


        End Function

    End Class

End Namespace
