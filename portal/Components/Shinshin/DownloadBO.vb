Imports System.Data.SqlClient
Public Class DownloadBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select a.dwno,a.dwgrp,a.dwname,a.dwfile,b.it_name as dwgrpname from download a,item b where a.dwgrp = b.no "

        If NO <> "" Then
            strSQL &= " and a.dwno='" & NO & "' "

         End If
        strSQL &= "Order by a.dwgrp,a.dwno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryGrp(Optional ByVal GRP As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select a.dwno,a.dwgrp,a.dwname,a.dwfile,b.it_name as dwgrpname from download a,item b where a.dwgrp = b.no "

        If GRP <> "" Then
            strSQL &= " and a.dwgrp = '" & GRP & "' "

        End If
        strSQL &= "Order by a.dwgrp,a.dwno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Endownload) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into download (dwgrp,dwname,dwfile,creater) values ("
        strSQL &= "'" & Ne.dwgrp & "'"
        strSQL &= ",'" & Ne.dwname & "'"
        strSQL &= ",'" & Ne.dwfile & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Endownload) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE download "
        If Ne.dwgrp <> "" Then
            strSQLBody &= ",dwgrp='" & Ne.dwgrp & "'"
        End If
        If Ne.dwname <> "" Then
            strSQLBody &= ",dwname='" & Ne.dwname & "'"
        End If
        If Ne.dwfile <> "" Then
            strSQLBody &= ",dwfile='" & Ne.dwfile & "'"
        End If
        If Ne.creater <> "" Then
            strSQLBody &= ",creater='" & Ne.creater & "'"
        End If
        If Ne.createdate <> "" Then
            strSQLBody &= ",createdate='" & Ne.createdate & "'"
        End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where dwno ='" & Ne.dwno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE download where dwno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE download where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
