Imports System.Data.SqlClient
Public Class LinksBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from links where 1=1 "

        If NO <> "" Then
            strSQL &= " and lkno='" & NO & "' "

         End If
         strSQL &= "Order by lkno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enlinks) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into links (lkgrp,lkname,lkurl,creater,createdate) values ("
        strSQL &= "'" & Ne.lkgrp & "'"
        strSQL &= ",'" & Ne.lkname & "'"
        strSQL &= ",'" & Ne.lkurl & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ",'" & Ne.createdate & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enlinks) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE links "
        If Ne.lkgrp <> "" Then
            strSQLBody &= ",lkgrp='" & Ne.lkgrp & "'"
        End If
        If Ne.lkname <> "" Then
            strSQLBody &= ",lkname='" & Ne.lkname & "'"
        End If
        If Ne.lkurl <> "" Then
            strSQLBody &= ",lkurl='" & Ne.lkurl & "'"
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
        strSQLWhere = " Where lkno ='" & Ne.lkno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE links where lkno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
