Imports System.Data.SqlClient
Public Class HotnewsBO

    Public Function Update(ByVal Ne As Enhotnews) As Integer

        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE hotnews "
        If Ne.newsubject <> "" Then
            strSQLBody &= ",new_subject='" & Ne.newsubject & "'"
        End If
        If Ne.newcontent <> "" Then
            strSQLBody &= ",new_content='" & Ne.newcontent & "'"
        End If

        If CType(Ne.SDATE, String).Trim <> "" Then
            strSQLBody &= ",SDATE='" & Ne.SDATE & "'"
        End If

        If CType(Ne.EDATE, String).Trim <> "" Then
            strSQLBody &= ",EDATE='" & Ne.EDATE & "'"
        End If

        If Ne.Provider <> "" Then
            strSQLBody &= ",Provider='" & Ne.Provider & "'"
        End If


        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where newno ='" & Ne.newno & "' "
        strSQL &= strSQLWhere

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function


    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select replace(new_content,char(13),'<BR>') new_content ,* from hotnews where 1=1 "

        If NO <> "" Then
            strSQL &= " and newno='" & NO & "' "

        End If
        strSQL &= " Order by newno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function IndexQuery(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select TOP " & NO & " *,convert(char(10),creatdate,111) as cdate from hotnews where new_act = '1' "
        strSQL &= " Order by newno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryShow(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *,convert(char(10),creatdate,111) as cdate from hotnews where new_act = '1' "

        If NO <> "" Then
            strSQL &= " and newno='" & NO & "' "

        End If
        strSQL &= " Order by newno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""

        strSQL = "DELETE hotnews where newno = '" & NO & "'"

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function


    Public Function Insert(ByVal Ne As Enhotnews) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into hotnews (new_subject,new_content,new_link,creater,sdate,edate,provider) values ("
        strSQL &= "'" & Ne.newsubject & "'"
        strSQL &= ",'" & Ne.newcontent & "'"
        strSQL &= ",'" & Ne.newlink & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ",'" & Ne.SDATE & "'"
        strSQL &= ",'" & Ne.EDATE & "'"
        strSQL &= ",'" & Ne.Provider & "'"
        strSQL &= ")"

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE hotnews where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
