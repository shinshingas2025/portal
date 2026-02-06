Imports System.Data.SqlClient
Public Class StopBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select  convert(char(10),stopSDATE,111)  + ' ' + stopStime as stopSDATETime ,  convert(char(10),stopEDATE,111)  + ' ' + stopEtime as stopEDATETime ,* from stopinfor where 1=1 "

        If NO <> "" Then
            strSQL &= " and spno='" & NO & "' "

        End If
        strSQL &= " Order by spno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function IndexQuery(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select TOP " & NO & " *,convert(char(10),createdate,111) as cdate from stopinfor where spenddate >= getdate()"
        strSQL &= " Order by spno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryShow(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *,convert(char(10),createdate,111) as cdate from stopinfor where spenddate >= getdate()"

        If NO <> "" Then
            strSQL &= " and spno='" & NO & "' "

        End If
        strSQL &= " Order by spno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function


    Public Function Insert(ByVal Ne As Enstop) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into stopinfor (stoprange,stopSDATE,stopSTIME,stopEDATE,stopETime,AnswerUnit,AnswerTel,spcontent,Provider,SDATE,EDATE,creater) values ("
        strSQL &= "'" & Ne.stoprange & "'"
        strSQL &= ",'" & Ne.stopSdate & "'"
        strSQL &= ",'" & Ne.stopStime & "'"
        strSQL &= ",'" & Ne.stopEdate & "'"
        strSQL &= ",'" & Ne.stopEtime & "'"
        strSQL &= ",'" & Ne.AnswerUnit & "'"
        strSQL &= ",'" & Ne.AnswerTel & "'"
        strSQL &= ",'" & Ne.spcontent & "'"
        strSQL &= ",'" & Ne.Provider & "'"
        strSQL &= ",'" & Ne.SDATE & "'"
        strSQL &= ",'" & Ne.EDATE & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enstop) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE stopinfor "
        If Ne.stoprange <> "" Then
            strSQLBody &= ",stoprange='" & Ne.stoprange & "'"
        End If
        If CType(Ne.stopSdate, String).Trim <> "" Then
            strSQLBody &= ",stopSdate='" & Ne.stopSdate & "'"
        End If
        If Ne.stopStime <> "" Then
            strSQLBody &= ",stopStime='" & Ne.stopStime & "'"
        End If

        If CType(Ne.stopEdate, String).Trim <> "" Then
            strSQLBody &= ",stopEdate='" & Ne.stopEdate & "'"
        End If
        If Ne.stopEtime <> "" Then
            strSQLBody &= ",stopEtime='" & Ne.stopEtime & "'"
        End If

        If Ne.AnswerUnit <> "" Then
            strSQLBody &= ",AnswerUnit='" & Ne.AnswerUnit & "'"
        End If

        If Ne.AnswerTel <> "" Then
            strSQLBody &= ",AnswerTel='" & Ne.AnswerTel & "'"
        End If

        If Ne.spcontent <> "" Then
            strSQLBody &= ",spcontent='" & Ne.spcontent & "'"
        End If

        If Ne.Provider <> "" Then
            strSQLBody &= ",Provider='" & Ne.Provider & "'"
        End If

        If CType(Ne.SDATE, String).Trim <> "" Then
            strSQLBody &= ",SDATE='" & Ne.SDATE & "'"
        End If
        If CType(Ne.EDATE, String).Trim <> "" Then
            strSQLBody &= ",EDATE='" & Ne.EDATE & "'"
        End If


        'If Ne.creater <> "" Then
        '    strSQLBody &= ",creater='" & Ne.creater & "'"
        'End If

        If Ne.modifier <> "" Then
            strSQLBody &= ",modifier='" & Ne.modifier & "'"
        End If
        If Ne.modifydate <> "" Then
            strSQLBody &= ",modifydate='" & Ne.modifydate & "'"
        End If

        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where spno ='" & Ne.spno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE stopinfor where spno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE stopinfor where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
End Class
