Imports System.Data.SqlClient
Public Class ReceiptNoticeBO

    Public Function Query(Optional ByVal snotice_line As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from Receipt_notice where 1=1 "

        If snotice_line <> "" Then
            strSQL &= " and notice_line='" & snotice_line & "' "
        End If
        strSQL &= " Order by noticeno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryTOP(Optional ByVal snoticeno As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        strSQL = "Select TOP 1 * from Receipt_notice "
        strSQL &= " Order by noticeno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enreceiptnotice) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into Receipt_notice (notice_content,notice_line,add_user,add_datetime,upd_user,upd_datetime) values ("
        If Ne.notice_line = "1" Then
            strSQL &= "'" & Ne.notice_content1 & "'"
        End If
        If Ne.notice_line = "2" Then
            strSQL &= "'" & Ne.notice_content2 & "'"
        End If
        If Ne.notice_line = "3" Then
            strSQL &= "'" & Ne.notice_content3 & "'"
        End If
        If Ne.notice_line = "4" Then
            strSQL &= "'" & Ne.notice_content4 & "'"
        End If
        If Ne.notice_line = "5" Then
            strSQL &= "'" & Ne.notice_content5 & "'"
        End If
        If Ne.notice_line = "6" Then
            strSQL &= "'" & Ne.notice_content6 & "'"
        End If
        strSQL &= ",'" & Ne.notice_line & "'"
        strSQL &= ",'" & Ne.upd_user & "'"
        strSQL &= ",getdate()"
        strSQL &= ",'" & Ne.upd_user & "'"
        strSQL &= ",getdate()"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enreceiptnotice) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE Receipt_notice "
        If Ne.notice_line = "1" Then
            strSQLBody &= ",notice_content='" & Ne.notice_content1 & "'"
        End If
        If Ne.notice_line = "2" Then
            strSQLBody &= ",notice_content='" & Ne.notice_content2 & "'"
        End If
        If Ne.notice_line = "3" Then
            strSQLBody &= ",notice_content='" & Ne.notice_content3 & "'"
        End If
        If Ne.notice_line = "4" Then
            strSQLBody &= ",notice_content='" & Ne.notice_content4 & "'"
        End If
        If Ne.notice_line = "5" Then
            strSQLBody &= ",notice_content='" & Ne.notice_content5 & "'"
        End If
        If Ne.notice_line = "6" Then
            strSQLBody &= ",notice_content='" & Ne.notice_content6 & "'"
        End If
        strSQLBody &= ",upd_user='" & Ne.upd_user & "'"
        strSQLBody &= ",upd_datetime= getdate()"
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where notice_line ='" & Ne.notice_line & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal snoticeno As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE Receipt_notice where noticeno = '" & snoticeno & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE Receipt_notice where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
