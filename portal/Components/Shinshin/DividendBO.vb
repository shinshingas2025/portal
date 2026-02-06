Imports System.Data.SqlClient
Public Class DividendBO

    Public Function Update(ByVal Ne As Endividend) As Integer

        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE dividend "

        strSQLBody &= ",mon01='" & Ne.mon01 & "'"
        strSQLBody &= ",mon02='" & Ne.mon02 & "'"
        strSQLBody &= ",mon03='" & Ne.mon03 & "'"
        strSQLBody &= ",mon04='" & Ne.mon04 & "'"
        strSQLBody &= ",mon05='" & Ne.mon05 & "'"
        strSQLBody &= ",mon06='" & Ne.mon06 & "'"
        strSQLBody &= ",mon07='" & Ne.mon07 & "'"

        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where year ='" & Ne.year & "' and newno='" & Ne.newno & "'"
        strSQL &= strSQLWhere

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function


    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from dividend where 1=1 "

        If NO <> "" Then
            strSQL &= " and newno='" & NO & "' "

        End If
        strSQL &= " Order by year DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function IndexQuery(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select TOP *,convert(char(10),creatdate,111) as cdate from dividend "
        strSQL &= " Order by newno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function YearQuery(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from dividend where year='" & NO & "'"
        strSQL &= " Order by year DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryShow(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *,convert(char(10),creatdate,111) as cdate from dividend"

        If NO <> "" Then
            strSQL &= " and newno='" & NO & "' "

        End If
        strSQL &= " Order by year DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""

        strSQL = "DELETE dividend where newno = '" & NO & "'"

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function


    Public Function Insert(ByVal Ne As Endividend) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into dividend (year,mon01,mon02,mon03,mon04,mon05,mon06,mon07,creater) values ("
        strSQL &= "'" & Ne.year & "'"
        strSQL &= ",'" & Ne.mon01 & "'"
        strSQL &= ",'" & Ne.mon02 & "'"
        strSQL &= ",'" & Ne.mon03 & "'"
        strSQL &= ",'" & Ne.mon04 & "'"
        strSQL &= ",'" & Ne.mon05 & "'"
        strSQL &= ",'" & Ne.mon06 & "'"
        strSQL &= ",'" & Ne.mon07 & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ")"

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE dividend where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
