Imports System.Data.SqlClient
Public Class ReceiptAdBO

    Public Function Query(Optional ByVal sadno As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select adno,ad_content1,ad_content2,ad_content3,CONVERT(char(10), ad_start_date, 111) as ad_start_date,CONVERT(char(10), ad_end_date, 111) as ad_end_date from Receipt_ad where 1=1 "

        If sadno <> "" Then
            strSQL &= " and adno='" & sadno & "' "

        End If
        strSQL &= " Order by ad_start_date DESC, ad_end_date DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryTOP(Optional ByVal sadno As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select TOP 1 * from Receipt_ad "
        strSQL &= " Order by ad_start_date DESC, ad_end_date DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enreceiptad) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into Receipt_ad (ad_content1,ad_content2,ad_content3,ad_start_date,ad_end_date,add_user,add_datetime,upd_user,upd_datetime) values ("
        strSQL &= "'" & Ne.ad_content1 & "'"
        strSQL &= ",'" & Ne.ad_content2 & "'"
        strSQL &= ",'" & Ne.ad_content3 & "'"
        strSQL &= ",'" & Ne.ad_start_date & "'"
        strSQL &= ",'" & Ne.ad_end_date & "'"
        strSQL &= ",'" & Ne.upd_user & "'"
        strSQL &= ", getdate()"
        strSQL &= ",'" & Ne.upd_user & "'"
        strSQL &= ", getdate()"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enreceiptad) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE Receipt_ad "
        If Ne.ad_content1 <> "" Then
            strSQLBody &= ",ad_content1='" & Ne.ad_content1 & "'"
        End If
        If CType(Ne.ad_content2, String).Trim <> "" Then
            strSQLBody &= ",ad_content2='" & Ne.ad_content2 & "'"
        End If
        If CType(Ne.ad_content3, String).Trim <> "" Then
            strSQLBody &= ",ad_content3='" & Ne.ad_content3 & "'"
        End If
        If CType(Ne.ad_start_date, String).Trim <> "" Then
            strSQLBody &= ",ad_start_date='" & Ne.ad_start_date & "'"
        End If
        If CType(Ne.ad_end_date, String).Trim <> "" Then
            strSQLBody &= ",ad_end_date='" & Ne.ad_end_date & "'"
        End If
        strSQLBody &= ",upd_user='" & Ne.upd_user & "'"
        strSQLBody &= ",upd_datetime= getdate()"
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where adno ='" & Ne.adno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal sadno As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE Receipt_ad where adno = '" & sadno & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE Receipt_ad where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
