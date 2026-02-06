Imports System.Data.SqlClient
Public Class vUserInfoBO
    '查詢所有人員資料
    Public Function Query() As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "SELECT distinct PID,groupName FROM vUserInfo"
        '建立連線物件
        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Query(ByVal PID As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from vUserInfo where PID = '" & PID & "'"
        '建立連線物件
        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryUnit(ByVal UID As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from vUserInfo where PID = '" & UID & "'"
        '建立連線物件
        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function


End Class
