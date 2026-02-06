Imports System.Data.SqlClient
Public Class ContactBO
    '一般查詢(沒比對登入者帳號)
    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        'strSQL = "Select *,convert(char(10),createdate,111) as cntdate from contact where 1=1 "
        'strSQL = "Select *,isnull(workdate,'') workdate1 from contact where 1=1 "
        'strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN 0 THEN '未指派' WHEN 1 THEN '處理中' WHEN 2 THEN '已處理' WHEN 3 THEN '已辦結' END as status from contact where 1=1 "
        strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN '0' THEN '未指派' WHEN '1' THEN '處理中' WHEN '2' THEN '已處理' WHEN '3' THEN '已辦結' END as status from contact as A left join portal.dbo.vUserInfo as B on A.assignoperator = B.UID "
        If NO <> "" Then
            strSQL &= " and cntno='" & NO & "' "

        End If
        strSQL &= "Order by createdate DESC "
        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    '依照不同的登入user查詢資料
    'userId         : user登入帳號
    'startDate      : 起始日期
    'endDate        : 結束日期 
    'status         : 處理狀態
    'num            : 判斷是"反映日期(num = 0)"或"處理日期(num = 1)"查詢用 
    'likeSel        : 全文檢索條件
    'likecontent    : 全文檢索內容
    'identity  : 判斷使用者身份(admin、user)
    Public Function UserQuery(ByVal userId As String, ByVal startDate As String, ByVal endDate As String, ByVal status As String, ByVal num As Integer, ByVal likeSel As String, ByVal likecontent As String, ByVal identity As String) As DataTable
        Dim strSQL As String = ""
        Dim strWhere As String = "where"
        Dim dt As DataTable
        'strSQL = "Select *,convert(char(10),createdate,111) as cntdate from contact where 1=1 "
        'strSQL = "Select *,isnull(workdate,'') workdate1 from contact where 1=1 "
        'strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN 0 THEN '未指派' WHEN 1 THEN '處理中' WHEN 2 THEN '已處理' WHEN 3 THEN '已辦結' END as status from contact where 1=1 and assignoperator = '" & userId & "'"
        '有過濾登入者
        'strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN 0 THEN '未指派' WHEN 1 THEN '處理中' WHEN 2 THEN '已處理' WHEN 3 THEN '已辦結' END as status from contact as A left join portal.dbo.vUserInfo as B on A.assignoperator = B.UID A.assignoperator ='" & userId & "'"
        '沒有過濾登入者
        strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN '0' THEN '未指派' WHEN '1' THEN '處理中' WHEN '2' THEN '已處理' WHEN '3' THEN '已辦結' END as status from contact as A left join portal.dbo.vUserInfo as B on A.assignoperator = B.UID  "

        '判斷查詢日期條件
        If num = 0 Then
            strSQL &= strWhere & " createdate >='" & startDate & "' and createdate <='" & endDate & "'"
            strWhere = ""
        ElseIf num = 1 Then
            strSQL &= strWhere & " workdate >='" & startDate & "' and createdate <='" & endDate & "'"
            strWhere = ""
        End If
        '判斷處理狀態
        If status <> "9" Then  '9==>查全部狀態
            'strSQL &= " and workstatus ='" & status & "'"
            strSQL &= "and workstatus ='" & status & "'"
        End If
        '判斷登入者身分
        If strWhere.Trim <> "" Then
            If identity.Trim.Equals("user") Then
                strSQL &= strWhere & " A.assignoperator ='" & userId & "'"
            End If
        Else
            If identity.Trim.Equals("user") Then
                strSQL &= "and A.assignoperator ='" & userId & "'"
            End If
        End If

        '判斷全文檢索搜尋
        If likecontent.Trim <> "" Then
            likecontent = likecontent.Trim.Replace("'", "")
            likecontent = likecontent.Trim.Replace("-", "")
            strSQL &= "and " & likeSel & " like '%" & likecontent & "%' "
        End If

        strSQL &= "Order by createdate DESC "
        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Encontact) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into contact (cntsubject,cntcontent,cnttel,cntemail) values ("
        strSQL &= "'" & Ne.cntsubject & "'"
        strSQL &= ",'" & Ne.cntcontent & "'"
        strSQL &= ",'" & Ne.cnttel & "'"
        strSQL &= ",'" & Ne.cntemail & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Encontact) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE contact "
        '主旨
        'If Ne.cntsubject <> "" Then
        '    strSQLBody &= ",cntsubject='" & Ne.cntsubject & "'"
        'End If
        '內容
        'If Ne.cntcontent <> "" Then
        '    strSQLBody &= ",cntcontent='" & Ne.cntcontent & "'"
        'End If
        '電話
        'If Ne.cnttel <> "" Then
        '    strSQLBody &= ",cnttel='" & Ne.cnttel & "'"
        'End If
        'E-mail
        'If Ne.cntemail <> "" Then
        '    strSQLBody &= ",cntemail='" & Ne.cntemail & "'"
        'End If
        'If Ne.createdate <> "" Then
        '    strSQLBody &= ",createdate='" & Ne.createdate & "'"
        'End If        
        '處理狀態
        If Ne.workstatus <> "" Then
            strSQLBody &= ",workstatus='" & Ne.workstatus & "'"
        End If
        '初次處理人員
        If Ne.operator <> "" Then
            strSQLBody &= ",operator='" & Ne.operator & "'"
        End If
        '初次處理時間
        If Ne.workdate <> "" Then
            strSQLBody &= ",workdate='" & Ne.workdate & "'"
        End If
        '最後處理人員
        If Ne.lastoperator <> "" Then
            strSQLBody &= ",lastoperator='" & Ne.lastoperator & "'"
        End If
        '最後處理時間
        'If Ne.lastworkdate.ToString.Trim <> "" Then
        '    strSQLBody &= ",lastworkdate='" & Ne.lastworkdate & "'"
        'End If
        If Ne.lastworkdate <> "" Then
            strSQLBody &= ",lastworkdate='" & Ne.lastworkdate & "'"
        End If
        '結案處理人員
        If Ne.endoperator <> "" Then
            strSQLBody &= ",endoperator='" & Ne.endoperator & "'"
        End If
        '結案處理時間
        'If Ne.endworkdate.ToString.Trim <> "" Then
        '    strSQLBody &= ",endworkdate='" & Ne.endworkdate & "'"
        'End If
        If Ne.endworkdate <> "" Then
            strSQLBody &= ",endworkdate='" & Ne.endworkdate & "'"
        End If
        '處理情形
        If Ne.remark.Trim <> "" Then
            strSQLBody &= ",remark='" & Ne.remark & "'"
        End If


        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where cntno ='" & Ne.cntno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
    '取消指派
    Public Function SelectUpdateD(ByVal no As String) As Integer
        Dim strSQL As String = ""
        strSQL = " UPDATE contact set assignoperator = '',workstatus = '0' Where cntno in(" & no & ") "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
    '指派
    Public Function SelectUpdateU(ByVal no As String, ByVal name As String) As Integer
        Dim strSQL As String = ""
        strSQL = " UPDATE contact set assignoperator = '" & name & "',assigndate = getdate(),workstatus = '1' Where cntno in(" & no & ") "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function CloseCase(ByVal no As String, ByVal status As String) As Integer
        Dim strSQL As String = ""
        Dim workstatus As String
        If status.Equals("U") Then
            workstatus = "3"    '已結案
        ElseIf status.Equals("C") Then
            workstatus = "2"    '取消結案
        End If
        strSQL = " UPDATE contact set assignoperator = '',workstatus = '" & workstatus & "' Where cntno in(" & no & ") "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE contact where cntno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE contact where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
End Class
