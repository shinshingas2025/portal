Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Odbc

Public Class MemberTransLogBO

    '查詢用戶歷史交易明細
    Public Function UserQuery(ByVal sDateStart As String, ByVal sDateEnd As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL &= "select * from house_no_clean "
        strSQL &= " where 1 = 1 "
        If sDateStart <> "" And sDateEnd <> "" Then
            strSQL &= " and CONVERT(char(10), hnc_del_datetime, 111) between '" & sDateStart & "' and '" & sDateEnd & "'"
        End If
        strSQL &= " Order by hnc_del_datetime desc"

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function



End Class
