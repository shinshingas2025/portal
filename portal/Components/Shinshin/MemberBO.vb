Imports System.Data.SqlClient
Public Class MemberBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from member where 1=1 "

        If NO <> "" Then
            strSQL &= " and memno='" & NO & "' "

         End If
         strSQL &= "Order by memno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Login(Optional ByVal AT As String = "", Optional ByVal PW As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from member where 1=1 "

        If AT <> "" Then
            strSQL &= " and memaccount='" & AT & "' "

        End If
        If PW <> "" Then
            strSQL &= " and mempasswd='" & PW & "' "

        End If
        strSQL &= "Order by memno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enmember) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into member (memaccount,mempasswd) values ("
        strSQL &= "'" & Ne.memaccount & "'"
        strSQL &= ",'" & Ne.mempasswd & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enmember) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE member "
        If Ne.memaccount <> "" Then
            strSQLBody &= ",memaccount='" & Ne.memaccount & "'"
        End If
        If Ne.mempasswd <> "" Then
            strSQLBody &= ",mempasswd='" & Ne.mempasswd & "'"
        End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where memno ='" & Ne.memno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE member where memno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
