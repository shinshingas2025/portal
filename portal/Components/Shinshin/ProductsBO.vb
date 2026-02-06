Imports System.Data.SqlClient
Public Class ProductsBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select a.pdno,a.pdgrp,a.pdname,a.pdintor,a.pdcontent,a.pdimages,a.pdcompany,a.pdcompanyinfor,a.pdcompanylink,b.it_name as pdgrpname ,a.account from products a,item b where a.pdgrp = b.no "

        If NO <> "" Then
            strSQL &= " and pdno='" & NO & "' "

         End If
        strSQL &= "Order by a.pdgrp,a.pdno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryGrp(Optional ByVal GRP As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select a.pdno,a.pdgrp,a.pdname,a.pdintor,a.pdcontent,a.pdimages,a.pdcompany,a.pdcompanyinfor,a.pdcompanylink,b.it_name as pdgrpname,a.account  from products a,item b where a.pdgrp = b.no "

        If GRP <> "" Then
            strSQL &= " and a.pdgrp = '" & GRP & "' "

        End If
        strSQL &= "Order by a.pdgrp,a.pdno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enproducts) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into products (pdgrp,pdname,pdintor,pdcontent,pdimages,pdcompany,pdcompanyinfor,pdcompanylink,creater,pdAccount) values ("
        strSQL &= "'" & Ne.pdgrp & "'"
        strSQL &= ",'" & Ne.pdname & "'"
        strSQL &= ",'" & Ne.pdintor & "'"
        strSQL &= ",'" & Ne.pdcontent & "'"
        strSQL &= ",'" & Ne.pdimages & "'"
        strSQL &= ",'" & Ne.pdcompany & "'"
        strSQL &= ",'" & Ne.pdcompanyinfor & "'"
        strSQL &= ",'" & Ne.pdcompanylink & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ",'" & Ne.pdAccount & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enproducts) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE products "
        If Ne.pdgrp <> "" Then
            strSQLBody &= ",pdgrp='" & Ne.pdgrp & "'"
        End If
        If Ne.pdname <> "" Then
            strSQLBody &= ",pdname='" & Ne.pdname & "'"
        End If
        If Ne.pdintor <> "" Then
            strSQLBody &= ",pdintor='" & Ne.pdintor & "'"
        End If
        If Ne.pdcontent <> "" Then
            strSQLBody &= ",pdcontent='" & Ne.pdcontent & "'"
        End If
        If Ne.pdimages <> "" Then
            strSQLBody &= ",pdimages='" & Ne.pdimages & "'"
        End If
        If Ne.pdcompany <> "" Then
            strSQLBody &= ",pdcompany='" & Ne.pdcompany & "'"
        End If
        If Ne.pdcompanyinfor <> "" Then
            strSQLBody &= ",pdcompanyinfor='" & Ne.pdcompanyinfor & "'"
        End If
        If Ne.pdcompanylink <> "" Then
            strSQLBody &= ",pdcompanylink='" & Ne.pdcompanylink & "'"
        End If
        If Ne.pdAccount <> "" Then
            strSQLBody &= ",Account='" & Ne.pdAccount & "'"
        End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If

        strSQLWhere = " Where pdno ='" & Ne.pdno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE products where pdno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE products where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
