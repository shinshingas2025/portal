Imports System.Data.SqlClient
Public Class EaccountBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from eaccount where 1=1 "

        If NO <> "" Then
            strSQL &= " and acno='" & NO & "' "

         End If
         strSQL &= "Order by acno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Eneaccount) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into eaccount (acnumber,actel,acemail) values ("
        strSQL &= "'" & Ne.acnumber & "'"
        strSQL &= ",'" & Ne.actel & "'"
        strSQL &= ",'" & Ne.acemail & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Eneaccount) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE eaccount "
        If Ne.acnumber <> "" Then
            strSQLBody &= ",acnumber='" & Ne.acnumber & "'"
        End If
        If Ne.actel <> "" Then
            strSQLBody &= ",actel='" & Ne.actel & "'"
        End If
        If Ne.acemail <> "" Then
            strSQLBody &= ",acemail='" & Ne.acemail & "'"
        End If
        If Ne.createdate <> "" Then
            strSQLBody &= ",createdate='" & Ne.createdate & "'"
        End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where acno ='" & Ne.acno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE eaccount where acno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
