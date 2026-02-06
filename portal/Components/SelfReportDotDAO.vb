Public Class SelfReportDotDAO
    Public Function QueryDate(ByVal status As String, ByVal AppSDATE As String, ByVal AppEDATE As String, ByVal ProSDATE As String, ByVal ProEDATE As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from SelfReportDot where status='" & status & "'"
        If AppSDATE.Trim <> "" And AppEDATE.Trim <> "" Then
            strSQL &= " and  CreateTime Between '" & AppSDATE & "' and '" & AppEDATE & "'"
        End If
        If ProSDATE.Trim <> "" And ProEDATE.Trim <> "" Then
            strSQL &= " and  ProcessTime  Between '" & ProSDATE & "' and '" & ProEDATE & "'"
        End If

        strSQL &= " Order by EntityID DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Update(ByVal entityID As String, ByVal status As String, ByVal operator As String) As Integer
        Dim strSQL As String

        strSQL = "UPDATE SelfReportDot set ProcessTime=getdate() ,status='" & status & "' ,operator='" & operator & "'"

        strSQL &= " Where entityID ='" & entityID & "' "


        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function
End Class
