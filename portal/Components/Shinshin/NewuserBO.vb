Imports System.Data.SqlClient
Public Class NewuserBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from newuser where 1=1 "

        If NO <> "" Then
            strSQL &= " and nuno='" & NO & "' "

         End If
         strSQL &= "Order by nuno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Ennewuser) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into newuser (nutype,nuitem,nuname,nuid,nutel,nuemail,nuaddress) values ("
        strSQL &= "'" & Ne.nutype & "'"
        strSQL &= ",'" & Ne.nuitem & "'"
        strSQL &= ",'" & Ne.nuname & "'"
        strSQL &= ",'" & Ne.nuid & "'"
        strSQL &= ",'" & Ne.nutel & "'"
        strSQL &= ",'" & Ne.nuemail & "'"
        strSQL &= ",'" & Ne.nuaddress & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Ennewuser) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE newuser "
        If Ne.nutype <> "" Then
            strSQLBody &= ",nutype='" & Ne.nutype & "'"
        End If
        If Ne.nuitem <> "" Then
            strSQLBody &= ",nuitem='" & Ne.nuitem & "'"
        End If
        If Ne.nuname <> "" Then
            strSQLBody &= ",nuname='" & Ne.nuname & "'"
        End If
        If Ne.nuid <> "" Then
            strSQLBody &= ",nuid='" & Ne.nuid & "'"
        End If
        If Ne.nutel <> "" Then
            strSQLBody &= ",nutel='" & Ne.nutel & "'"
        End If
        If Ne.nuemail <> "" Then
            strSQLBody &= ",nuemail='" & Ne.nuemail & "'"
        End If
        If Ne.nuaddress <> "" Then
            strSQLBody &= ",nuaddress='" & Ne.nuaddress & "'"
        End If
        If Ne.createdate <> "" Then
            strSQLBody &= ",createdate='" & Ne.createdate & "'"
        End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where nuno ='" & Ne.nuno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE newuser where nuno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
