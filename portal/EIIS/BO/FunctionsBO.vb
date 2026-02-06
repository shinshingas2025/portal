Public Class FunctionsBO

    Public Function UpdateFunctionOrder(ByVal lstItem As WebControls.ListBox) As Integer
        Dim it As New ListItem
        Dim i As Integer
        Dim strSQL As String = ""

        For i = 0 To lstItem.Items.Count - 1
            strSQL &= "Update sysDomains set SEQNO=" & i & " Where objValue='" & lstItem.Items(i).Value & "';"
        Next
        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 1
    End Function

    Public Function Query(ByVal objNode As Functions) As DataTable
        Dim strSQL As String = ""
        Dim dt As New DataTable

        strSQL = "Select * from  vFunctionMaster  Where funno=" & objNode.funNo & " order by PaneName,seqno "

        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        'Dim i As Integer
        'Dim node As New Functions

        'For i = 0 To dt.Rows.Count - 1
        '    node.APID = dt.Rows(i).Item("objID")
        '    node.Description = dt.Rows(i).Item("objName")
        '    node.ExeCMDLine = dt.Rows(i).Item("objName")
        '    node.ExeFileName = dt.Rows(i).Item("objName")
        '    node.FunctionID = dt.Rows(i).Item("objName")
        '    node.funNo = dt.Rows(i).Item("objName")
        '    node.JobID = dt.Rows(i).Item("objName")
        '    node.LogicalFilePath = dt.Rows(i).Item("objName")
        '    node.state = dt.Rows(i).Item("objName")

        'Next i

        Return dt

    End Function


    Public Function Update(ByVal fn As EIIS.Functions) As Integer
        Dim strSQL As String = ""
        Dim strWhere As String = ""

        strSQL = "Update  sysFunctionMaster set "

        If Not fn.FunctionID Is Nothing Then
            strWhere &= ",FunctionID='" & fn.FunctionID.Trim & "'"
        End If
        If Not fn.Description Is Nothing Then
            strWhere &= ",Description='" & fn.Description.Trim & "'"
        End If
        If Not fn.ExeFileName Is Nothing Then
            If fn.ExeFileName.Trim.Length > 0 Then
                strWhere &= ",ExeFileName='" & fn.ExeFileName.Trim & "'"
            End If
        End If
        If Not fn.LogicalFilePath Is Nothing Then
            If fn.LogicalFilePath.Trim.Length > 0 Then
                strWhere &= ",LogicalFilePath='" & fn.LogicalFilePath.Trim & "'"
            End If
        End If
        If Not fn.ExeCMDLine Is Nothing Then
            strWhere &= ",ExeCMDLine='" & fn.ExeCMDLine.Trim & "'"
        End If
        If Not fn.PaneName Is Nothing Then
            strWhere &= ",PaneName='" & fn.PaneName.Trim & "'"
        End If

        strWhere = Mid(strWhere, 2)

        strSQL = strSQL & strWhere & " where funno = " & fn.funNo

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function


    Public Function QueryList(ByVal objvalue As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As New DataTable

        strSQL = "SELECT sysFunctionMaster.*,sysDomains.objID,sysDomains.seqno  FROM sysDomains INNER JOIN sysFunctionMaster ON "
        strSQL &= "sysDomains.objValue = sysFunctionMaster.funNo  Where PID =" & objvalue & " order by PaneName,seqno"

        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        'Dim i As Integer
        'Dim node As New Functions

        'For i = 0 To dt.Rows.Count - 1
        '    node.APID = dt.Rows(i).Item("objID")
        '    node.Description = dt.Rows(i).Item("objName")
        '    node.ExeCMDLine = dt.Rows(i).Item("objName")
        '    node.ExeFileName = dt.Rows(i).Item("objName")
        '    node.FunctionID = dt.Rows(i).Item("objName")
        '    node.funNo = dt.Rows(i).Item("objName")
        '    node.JobID = dt.Rows(i).Item("objName")
        '    node.LogicalFilePath = dt.Rows(i).Item("objName")
        '    node.state = dt.Rows(i).Item("objName")

        'Next i

        Return dt

    End Function


    Public Function getFunctionByCommunityObjID(ByVal objid As Integer) As DataTable

        Dim strSQL As String = ""
        Dim dt As New DataTable

        strSQL = " SELECT B.objID, A.funNo, A.JobID, A.FunctionID, A.Description, "
        strSQL &= "A.ExeFileName, A.LogicalFilePath, A.ExeCMDLine, A.state, A.APID "
        strSQL &= " FROM dbo.sysFunctionMaster A INNER JOIN  dbo.sysDomains B ON A.funNo = B.objValue "
        strSQL &= " Where B.objid=" & objid

        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()


        Return dt


    End Function

    Public Function DeletefunctionMaster(ByVal node As DomainsNode) As Integer
        Dim strSQL As String = ""

        strSQL = "delete sysFunctionMaster where funno= " & node.objValue


        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
End Class
