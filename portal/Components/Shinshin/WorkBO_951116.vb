Imports System.Data.SqlClient
Public Class WorkBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select a.workno,a.workgroup,a.worksubject,a.workwkdate,a.workmember,a.workcontroler,a.workuser,convert(char(10),a.workdate,111) as workdate,b.it_name as wkgrpname,creater,edate,workaddress,sdate,tel,provider,checker,workwktime from workinfor a,item b where a.workgroup = b.no "

        If NO <> "" Then
            strSQL &= " and a.workno='" & NO & "' "

        End If
        strSQL &= " Order by a.workgroup,a.workno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function IndexQuery(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select TOP " & NO & " *,convert(char(10),workdate,111) as workdate from workinfor Where workdate >= getdate()"
        strSQL &= " Order by workno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryShow(Optional ByVal NO As String = "", Optional ByVal GROUP As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *,convert(char(10),workdate,111) as workdate,convert(char(10),createdate,111) as cdate from workinfor Where workdate >= getdate() "

        If NO <> "" Then
            strSQL &= " and workno='" & NO & "' "

        End If
        If GROUP <> "" Then
            strSQL &= " and workgroup='" & GROUP & "' "

        End If
        strSQL &= " Order by workno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enwork) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into workinfor (workgroup,worksubject,workwkdate,workmember,workcontroler,workuser,workdate,creater,sdate,edate,provider,workaddress,tel,checker,workwktime) values ("
        strSQL &= "'" & Ne.workgroup & "'"
        strSQL &= ",'" & Ne.worksubject & "'"
        strSQL &= ",'" & Ne.workwkdate & "'"
        strSQL &= ",'" & Ne.workmember & "'"
        strSQL &= ",'" & Ne.workcontroler & "'"
        strSQL &= ",'" & Ne.workuser & "'"
        strSQL &= ",'" & Ne.workdate & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ",'" & Ne.SDATE & "'"
        strSQL &= ",'" & Ne.EDATE & "'"
        strSQL &= ",'" & Ne.Provider & "'"
        strSQL &= ",'" & Ne.WorkAddress & "'"
        strSQL &= ",'" & Ne.tel & "'"
        strSQL &= ",'" & Ne.checker & "'"
        strSQL &= ",'" & Ne.workwktime & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enwork) As String
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE workinfor "
        If Ne.workgroup <> "" Then
            strSQLBody &= ",workgroup='" & Ne.workgroup & "'"
        End If
        If Ne.worksubject <> "" Then
            strSQLBody &= ",worksubject='" & Ne.worksubject & "'"
        End If
        If Ne.workwkdate <> "" Then
            strSQLBody &= ",workwkdate='" & Ne.workwkdate & "'"
        End If
        If Ne.workmember <> "" Then
            strSQLBody &= ",workmember='" & Ne.workmember & "'"
        End If
        If Ne.workcontroler <> "" Then
            strSQLBody &= ",workcontroler='" & Ne.workcontroler & "'"
        End If
        If Ne.workuser <> "" Then
            strSQLBody &= ",workuser='" & Ne.workuser & "'"
        End If
        If Ne.workdate <> "" Then
            strSQLBody &= ",workdate='" & Ne.workdate & "'"

        End If

        If Ne.workwktime <> "" Then
            strSQLBody &= ",workwktime='" & Ne.workwktime & "'"

        End If




        If CType(Ne.SDATE, String).Trim <> "" Then
            strSQLBody &= ",SDATE='" & Ne.SDATE & "'"
        End If

        If CType(Ne.EDATE, String).Trim <> "" Then
            strSQLBody &= ",eDATE='" & Ne.EDATE & "'"
        End If

        If Ne.Provider <> "" Then
            strSQLBody &= ",Provider='" & Ne.Provider & "'"
        End If

        If Ne.WorkAddress <> "" Then
            strSQLBody &= ",WorkAddress='" & Ne.WorkAddress & "'"
        End If

        If Ne.tel <> "" Then
            strSQLBody &= ",tel='" & Ne.tel & "'"
        End If

        If Ne.checker <> "" Then
            strSQLBody &= ",checker='" & Ne.checker & "'"
        End If




        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where workno ='" & Ne.workno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return strSQL
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE workinfor where workno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE workinfor where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
