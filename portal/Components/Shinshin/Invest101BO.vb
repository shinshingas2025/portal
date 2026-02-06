Imports System.Data.SqlClient
Public Class Invest101BO

    Public Function Query(Optional ByVal NO As String = "", Optional ByVal GRPNO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * "
        strSQL &= ",invname1+'<br>'+invfile1+'<br>'+invaname1+'<br>'+invafile1 as filename1 "
        strSQL &= ",invname2+'<br>'+invfile2+'<br>'+invaname2+'<br>'+invafile2 as filename2 "
        strSQL &= ",invname3+'<br>'+invfile3+'<br>'+invaname3+'<br>'+invafile3 as filename3 "
        strSQL &= ",invname4+'<br>'+invfile4+'<br>'+invaname4+'<br>'+invafile4 as filename4 "
        strSQL &= "from invest_101 where 1=1 "

        If NO <> "" Then
            strSQL &= " and invno='" & NO & "' "
        End If

        If GRPNO <> "" Then
            strSQL &= " and invgrp='" & GRPNO & "' "
        End If

        strSQL &= "Order by invno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Eninvest101) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into invest_101 (fyear,invgrp,invname1,invfile1,invname2,invfile2,invname3,invfile3,invname4,invfile4,invaname1,invafile1,invaname2,invafile2,invaname3,invafile3,invaname4,invafile4,creater) values ("
        strSQL &= "'" & Ne.fyear & "',"
        strSQL &= "'" & Ne.invgrp & "',"
        strSQL &= "'" & Ne.invname1 & "',"
        strSQL &= "'" & Ne.invfile1 & "',"
        strSQL &= "'" & Ne.invname2 & "',"
        strSQL &= "'" & Ne.invfile2 & "',"
        strSQL &= "'" & Ne.invname3 & "',"
        strSQL &= "'" & Ne.invfile3 & "',"
        strSQL &= "'" & Ne.invname4 & "',"
        strSQL &= "'" & Ne.invfile4 & "',"
        strSQL &= "'" & Ne.invaname1 & "',"
        strSQL &= "'" & Ne.invafile1 & "',"
        strSQL &= "'" & Ne.invaname2 & "',"
        strSQL &= "'" & Ne.invafile2 & "',"
        strSQL &= "'" & Ne.invaname3 & "',"
        strSQL &= "'" & Ne.invafile3 & "',"
        strSQL &= "'" & Ne.invaname4 & "',"
        strSQL &= "'" & Ne.invafile4 & "',"
        strSQL &= "'" & Ne.creater & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Eninvest101) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE invest_101 "

        If Ne.fyear > 0 Then
            strSQLBody &= ",fyear=" & Val(Ne.fyear) & ""
        End If

        If Ne.invgrp > 0 Then
            strSQLBody &= ",invgrp='" & Val(Ne.invgrp) & "'"
        End If
        strSQLBody &= ",invname1='" & Ne.invname1 & "'"
        strSQLBody &= ",invname2='" & Ne.invname2 & "'"
        strSQLBody &= ",invname3='" & Ne.invname3 & "'"
        strSQLBody &= ",invname4='" & Ne.invname4 & "'"
        strSQLBody &= ",invaname1='" & Ne.invaname1 & "'"
        strSQLBody &= ",invaname2='" & Ne.invaname2 & "'"
        strSQLBody &= ",invaname3='" & Ne.invaname3 & "'"
        strSQLBody &= ",invaname4='" & Ne.invaname4 & "'"

        If Ne.invfile1 <> "" Then
            strSQLBody &= ",invfile1='" & Ne.invfile1 & "'"
        End If
        If Ne.invfile2 <> "" Then
            strSQLBody &= ",invfile2='" & Ne.invfile2 & "'"
        End If
        If Ne.invfile3 <> "" Then
            strSQLBody &= ",invfile3='" & Ne.invfile3 & "'"
        End If
        If Ne.invfile4 <> "" Then
            strSQLBody &= ",invfile4='" & Ne.invfile4 & "'"
        End If

        If Ne.invafile1 <> "" Then
            strSQLBody &= ",invafile1='" & Ne.invafile1 & "'"
        End If
        If Ne.invafile2 <> "" Then
            strSQLBody &= ",invafile2='" & Ne.invafile2 & "'"
        End If
        If Ne.invafile3 <> "" Then
            strSQLBody &= ",invafile3='" & Ne.invafile3 & "'"
        End If
        If Ne.invafile4 <> "" Then
            strSQLBody &= ",invafile4='" & Ne.invafile4 & "'"
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
        strSQLWhere = " Where invno ='" & Ne.invno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE invest_101 where invno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE invest_101 where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function YearQuery(Optional ByVal NO As Integer = 0) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from invest_101 where fyear='" & NO & "'"
        strSQL &= " Order by fyear DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        Return dt
    End Function

End Class
