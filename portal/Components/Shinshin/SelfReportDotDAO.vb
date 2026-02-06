Public Class SelfReportDotDAO
    Public Function QueryDate(ByVal status As String, ByVal AppSDATE As String, ByVal AppEDATE As String, ByVal ProSDATE As String, ByVal ProEDATE As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        'strSQL = "Select SelfReportDot.*, portal.dbo.sysUserInfo.dept,portal.dbo.sysOrg.objID,portal.dbo.sysOrg.objName "
        'strSQL = strSQL + " from SelfReportDot left outer join portal.dbo.sysUserInfo"
        'strSQL = strSQL + " on rtrim(SelfReportDot.Operator)=rtrim(portal.dbo.sysUserInfo.Cname) "
        'strSQL = strSQL + " left outer join portal.dbo.sysOrg"
        'strSQL = strSQL + " on rtrim(portal.dbo.sysUserInfo.dept)=rtrim(portal.dbo.sysOrg.objID)"
        strSQL = "Select SelfReportDot.*,portal.dbo.vuserinfo.groupname,SUBSTRING(SelfReportDot.Vol_no,1,1) as Vol_no1,SUBSTRING(SelfReportDot.Vol_no,2,2) as Vol_no2 from SelfReportDot"
        strSQL = strSQL + " left outer join portal.dbo.vuserInfo"
        strSQL = strSQL + " on rtrim(SelfReportDot.operator)=rtrim(portal.dbo.vuserInfo.username)"
        strSQL = strSQL + " where status='" & status & "'"
        If AppSDATE.Trim <> "" And AppEDATE.Trim <> "" Then
            strSQL &= " and  SelfReportDot.CreateTime Between '" & AppSDATE & "' and '" & AppEDATE & "'"
        End If
        If ProSDATE.Trim <> "" And ProEDATE.Trim <> "" Then
            strSQL &= " and  SelfReportDot.ProcessTime  Between '" & ProSDATE & "' and '" & ProEDATE & "'"
        End If

        strSQL &= " Order by  Vol_no2,Vol_no1,EntityID DESC"
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryDate98(ByVal status As String, ByVal AppSDATE As String, ByVal AppEDATE As String, ByVal ProSDATE As String, ByVal ProEDATE As String, ByVal VolNo As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        'strSQL = "Select SelfReportDot.*, portal.dbo.sysUserInfo.dept,portal.dbo.sysOrg.objID,portal.dbo.sysOrg.objName "
        'strSQL = strSQL + " from SelfReportDot left outer join portal.dbo.sysUserInfo"
        'strSQL = strSQL + " on rtrim(SelfReportDot.Operator)=rtrim(portal.dbo.sysUserInfo.Cname) "
        'strSQL = strSQL + " left outer join portal.dbo.sysOrg"
        'strSQL = strSQL + " on rtrim(portal.dbo.sysUserInfo.dept)=rtrim(portal.dbo.sysOrg.objID)"
        strSQL = "Select SelfReportDot.*,portal.dbo.vuserinfo.groupname,SUBSTRING(SelfReportDot.Vol_no,2,2) as Vol_no2,"
        strSQL = strSQL + "SUBSTRING(SelfReportDot.Vol_no,1,1) as Vol_no1 from SelfReportDot "
        strSQL = strSQL + " left outer join portal.dbo.vuserInfo"
        strSQL = strSQL + " on rtrim(SelfReportDot.operator)=rtrim(portal.dbo.vuserInfo.username)"
        strSQL = strSQL + " where "
        If AppSDATE.Trim <> "" And AppEDATE.Trim <> "" Then
            strSQL &= " SelfReportDot.CreateTime Between '" & AppSDATE & "' and '" & AppEDATE & "'"
        End If
        If ProSDATE.Trim <> "" And ProEDATE.Trim <> "" Then
            strSQL &= " SelfReportDot.ProcessTime  Between '" & ProSDATE & "' and '" & ProEDATE & "'"
        End If
        If status.Trim <> "2" Then
            strSQL &= " and status='" & status & "'"
        End If
        If (VolNo <> "") Then
            strSQL &= " and SUBSTRING(SelfReportDot.Vol_no,2,2) = '" & VolNo & "' "
        End If
        strSQL &= " Order by Vol_no2,Vol_no1"
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function


    Public Function Update(ByVal entityID As String, ByVal status As String, ByVal myoperator As String) As Integer
        Dim strSQL As String

        strSQL = "UPDATE SelfReportDot set ProcessTime=getdate() ,status='" & status & "' ,operator='" & myoperator & "'"

        strSQL &= " Where entityID ='" & entityID & "' "


        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function

    Public Function UpdatebyAccountNO(ByVal AccountNO As String, ByVal status As String) As Integer
        Dim strSQL As String
        Dim dt2 As DataTable

        strSQL = "UPDATE SelfReportDot set ProcessTime=getdate() ,status='" & status & "'"

        strSQL &= " Where AccountNO ='" & AccountNO & "' "


        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        dt2 = conn.ReadDataTable(strSQL)
        conn.close()

    End Function

    Public Function UpdatebyEntityID(ByVal EntityID As String, ByVal status As String, Optional ByVal myoperator As String = "") As Integer
        Dim strSQL As String
        Dim dt2 As DataTable

        strSQL = "UPDATE SelfReportDot "
        If myoperator <> "" Then
            strSQL = strSQL + "set ProcessTime=getdate() "
            strSQL = strSQL + ",operator='" & myoperator & "' "
        Else
            strSQL = strSQL + "set ProcessTime=null "
            strSQL = strSQL + ",operator='' "
        End If
        strSQL = strSQL + ",status='" & status & "'"

        strSQL &= " Where EntityID ='" & EntityID & "' "


        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        dt2 = conn.ReadDataTable(strSQL)
        conn.close()

    End Function


End Class
