Imports System.Data.SqlClient
Public Class ScaleBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from scale where 1=1 "

        If NO <> "" Then
            strSQL &= " and scno='" & NO & "' "

         End If
         strSQL &= "Order by scno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enscale) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into scale (scnumber,sctel,scnotes) values ("
        strSQL &= "'" & Ne.scnumber & "'"
        strSQL &= ",'" & Ne.sctel & "'"
        strSQL &= ",'" & Ne.scnotes & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enscale) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE scale "
        If Ne.scnumber <> "" Then
            strSQLBody &= ",scnumber='" & Ne.scnumber & "'"
        End If
        If Ne.sctel <> "" Then
            strSQLBody &= ",sctel='" & Ne.sctel & "'"
        End If
        If Ne.scnotes <> "" Then
            strSQLBody &= ",scnotes='" & Ne.scnotes & "'"
        End If
        If Ne.createdate <> "" Then
            strSQLBody &= ",createdate='" & Ne.createdate & "'"
        End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where scno ='" & Ne.scno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE scale where scno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
