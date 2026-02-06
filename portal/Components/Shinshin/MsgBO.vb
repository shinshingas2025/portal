Imports System.Data.SqlClient
Public Class MsgBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *,convert(char(10),msgenddate,111) as msgenddate from message where 1=1 "

        If NO <> "" Then
            strSQL &= " and msgno='" & NO & "' "

        End If
        strSQL &= " Order by msgno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryTOP(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        'strSQL = "Select TOP 1 * from message where msgenddate > getdate() "
        strSQL = "Select TOP 1 * from message "
        strSQL &= " Order by msgno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enmsg) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into message (msgsubject,SDATE,EDATE,Provider,creater) values ("
        strSQL &= "'" & Ne.msgsubject & "'"
        strSQL &= ",'" & Ne.SDATE & "'"
        strSQL &= ",'" & Ne.EDATE & "'"
        strSQL &= ",'" & Ne.Provider & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enmsg) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE message "
        If Ne.msgsubject <> "" Then
            strSQLBody &= ",msgsubject='" & Ne.msgsubject & "'"
        End If
        If CType(Ne.SDATE, String).Trim <> "" Then
            strSQLBody &= ",SDATE='" & Ne.SDATE & "'"
        End If
        If CType(Ne.EDATE, String).Trim <> "" Then
            strSQLBody &= ",EDATE='" & Ne.EDATE & "'"
        End If
        If Ne.creater <> "" Then
            strSQLBody &= ",creater='" & Ne.creater & "'"
        End If

        If Ne.Provider <> "" Then
            strSQLBody &= ",Provider='" & Ne.Provider & "'"
        End If

        If Ne.createdate <> "" Then
            strSQLBody &= ",createdate='" & Ne.createdate & "'"
        End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where msgno ='" & Ne.msgno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE message where msgno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE message where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
