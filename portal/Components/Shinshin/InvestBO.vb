Imports System.Data.SqlClient
Public Class InvestBO

    Public Function Query(Optional ByVal NO As String = "", Optional ByVal GRPNO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from invest where 1=1 "

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

    Public Function Insert(ByVal Ne As Eninvest) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into invest (invgrp,invname,invfile,creater) values ("
        strSQL &= "'" & Ne.invgrp & "'"
        strSQL &= ",'" & Ne.invname & "'"
        strSQL &= ",'" & Ne.invfile & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Eninvest) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE invest "
        If Ne.invgrp <> "" Then
            strSQLBody &= ",invgrp='" & Ne.invgrp & "'"
        End If
        If Ne.invname <> "" Then
            strSQLBody &= ",invname='" & Ne.invname & "'"
        End If
        If Ne.invfile <> "" Then
            strSQLBody &= ",invfile='" & Ne.invfile & "'"
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

    Public Function Delete(ByVal NO As String, Optional webpath As String = "") As Integer
        Dim strSQL As String = ""
        strSQL = "select invfile from invest where invno = '" & NO & "'"
        Dim conn As New DBConn2

        If webpath <> "" Then
            '刪除實體檔案
            Dim dr As SqlDataReader = conn.ExecuteReader(strSQL)
            If dr.Read Then
                Dim deletefile As String = dr("invfile") & ""
                If System.IO.File.Exists(webpath & "/" & deletefile) Then

                    System.IO.File.Delete(webpath & "/" & deletefile)
                End If
            End If
            dr.Close()
        End If



        strSQL = "DELETE invest where invno = '" & NO & "'"

        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE invest where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
End Class
