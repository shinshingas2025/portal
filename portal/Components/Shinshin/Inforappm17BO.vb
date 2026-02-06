Imports System.Data.SqlClient
Public Class Inforappm17BO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from inforappm17 where 1=1 "

        If NO <> "" Then
            strSQL &= " and am17_house_no='" & NO & "' "

         End If
         strSQL &= "Order by no DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryTel(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from inforappm17 where am17_house_no in (SELECT am01_house_no FROM inforappm01 WHERE am01_telno1 = '" & NO & "')"

        strSQL &= "Order by no DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryName(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from inforappm17 where am17_house_no in (SELECT am01_house_no FROM inforappm01 WHERE am01_name = '" & NO & "')"

        strSQL &= "Order by no DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Eninforappm17) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into inforappm17 (am17_house_no,am17_input_dt,am17_reason_cd,am17_amount,am17_yymm_start,am17_yymm_stop,am17_de_user,am17_user_id,am17_upd_datetime,createdate) values ("
        strSQL &= "'" & Ne.am17_house_no & "'"
        strSQL &= ",'" & Ne.am17_input_dt & "'"
        strSQL &= ",'" & Ne.am17_reason_cd & "'"
        strSQL &= ",'" & Ne.am17_amount & "'"
        strSQL &= ",'" & Ne.am17_yymm_start & "'"
        strSQL &= ",'" & Ne.am17_yymm_stop & "'"
        strSQL &= ",'" & Ne.am17_de_user & "'"
        strSQL &= ",'" & Ne.am17_user_id & "'"
        strSQL &= ",'" & Ne.am17_upd_datetime & "'"
        strSQL &= ",'" & Ne.createdate & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Eninforappm17) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE inforappm17 "
        If Ne.am17_house_no <> "" Then
            strSQLBody &= ",am17_house_no='" & Ne.am17_house_no & "'"
        End If
        If Ne.am17_input_dt <> "" Then
            strSQLBody &= ",am17_input_dt='" & Ne.am17_input_dt & "'"
        End If
        If Ne.am17_reason_cd <> "" Then
            strSQLBody &= ",am17_reason_cd='" & Ne.am17_reason_cd & "'"
        End If
        If Ne.am17_amount <> "" Then
            strSQLBody &= ",am17_amount='" & Ne.am17_amount & "'"
        End If
        If Ne.am17_yymm_start <> "" Then
            strSQLBody &= ",am17_yymm_start='" & Ne.am17_yymm_start & "'"
        End If
        If Ne.am17_yymm_stop <> "" Then
            strSQLBody &= ",am17_yymm_stop='" & Ne.am17_yymm_stop & "'"
        End If
        If Ne.am17_de_user <> "" Then
            strSQLBody &= ",am17_de_user='" & Ne.am17_de_user & "'"
        End If
        If Ne.am17_user_id <> "" Then
            strSQLBody &= ",am17_user_id='" & Ne.am17_user_id & "'"
        End If
        If Ne.am17_upd_datetime <> "" Then
            strSQLBody &= ",am17_upd_datetime='" & Ne.am17_upd_datetime & "'"
        End If
        If Ne.createdate <> "" Then
            strSQLBody &= ",createdate='" & Ne.createdate & "'"
        End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where no ='" & Ne.no & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE inforappm17 where no = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
