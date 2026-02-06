Imports System.Data.SqlClient
Public Class IforBO

    Public Function Update(ByVal Ne As Enifor) As Integer

        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE information "
        If Ne.iforsubject <> "" Then
            strSQLBody &= ",iforsubject='" & Ne.iforsubject & "'"
        End If
        If Ne.iforcontent <> "" Then
            strSQLBody &= ",iforcontent='" & Ne.iforcontent & "'"
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
        strSQLWhere = " Where iforno ='" & Ne.iforno & "' "
        strSQL &= strSQLWhere

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function


    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select iforno,iforsubject,replace(iforcontent,char(13),'<BR>') iforcontent,convert(char(10),iforenddate,111) as iforenddate,createdate,rtrim(convert(char,year(sdate)))+'/'+right('00'+rtrim(convert(char,month(sdate))),2)+'/'+right('00'+rtrim(convert(char,day(sdate))),2) as sdate,rtrim(convert(char,year(edate)))+'/'+right('00'+rtrim(convert(char,month(edate))),2)+'/'+right('00'+rtrim(convert(char,day(edate))),2) as edate,provider,creater from information where 1=1 "

        If NO <> "" Then
            strSQL &= " and iforno='" & NO & "' "

        End If
        strSQL &= " Order by iforno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function IndexQuery(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select TOP " & NO & " iforno,iforsubject,iforcontent,convert(char(10),iforenddate,111) as iforenddate,createdate from information Where iforenddate >= getdate() "

        strSQL &= " Order by iforno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryShow(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *,convert(char(10),createdate,111) as cdate from information where iforenddate >= getdate() "

        If NO <> "" Then
            strSQL &= " and iforno='" & NO & "' "

        End If
        strSQL &= " Order by iforno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""

        strSQL = "DELETE information where iforno = '" & NO & "'"

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function


    Public Function Insert(ByVal Ne As Enifor) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into information (iforsubject,iforcontent,iforenddate,creater,sdate,edate,provider) values ("
        strSQL &= "'" & Ne.iforsubject & "'"
        strSQL &= ",'" & Ne.iforcontent & "'"
        strSQL &= ",'" & Ne.iforenddate & "'"
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
        strSQL = "DELETE information where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
