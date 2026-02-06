Public Class GroupsBO
    Public Function Query(ByVal GroupID As Integer) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from sysGroups where GroupID = " & GroupID
        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function


    Public Function Insert(ByVal node As Groups) As Integer
        Dim strSQL As String = ""
        strSQL &= "INSERT INTO sysGroups (GroupName,Description,state) values("
        strSQL &= "'" & node.GroupName.Trim & "',"
        strSQL &= "'" & node.Description.Trim & "',"
        strSQL &= "'" & node.state.Trim & "'"
        strSQL &= ");"
        strSQL &= "INSERT INTO sysCommunity (objName,objValue,srcName,PID,SEQNO,state) values ("
        strSQL &= "'" & node.GroupName.Trim & "',"
        strSQL &= "@@identity,"
        strSQL &= "'Groups',"
        strSQL &= "" & node.PID & ","
        strSQL &= "'" & node.SEQNO.Trim & "',"
        strSQL &= "'" & node.state.Trim & "'"
        strSQL &= ")"

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function
End Class
