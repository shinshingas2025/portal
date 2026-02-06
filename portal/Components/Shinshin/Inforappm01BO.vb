Imports System.Data.SqlClient
Public Class Inforappm01BO

    Public Function Query(Optional ByVal NO1 As String = "", Optional ByVal NO2 As String = "", Optional ByVal NO3 As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from inforappm01 where 1=1 "

        If NO1 <> "" Then
            strSQL &= " and am01_house_no='" & NO1 & "' "

        End If
        If NO2 <> "" Then
            strSQL &= " and am01_telno2='" & NO2 & "' "

        End If
        If NO3 <> "" Then
            strSQL &= " and am01_name='" & NO3 & "' "

        End If
        strSQL &= "Order by no DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Eninforappm01) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into inforappm01 (am01_total_no,am01_house_no,am01_name,am01_id_no,am01_canton,am01_street,am01_section,am01_lane,am01_alley,am01_number,am01_dash,am01_number2,am01_sub_no,am01_floor,am01_alt_addr1,am01_alt_addr2,am01_zone1,am01_telno1,am01_ext1,am01_remark1,am01_zone2,am01_telno2,am01_remark2,am01_telno3,am01_remark3,am01_company_no,am01_cno_start,am01_cno_stop,am01_last_appl,am01_usage,am01_post_type,am01_post_name,am01_post_no,am01_post_start,am01_post_end,createdate) values ("
        strSQL &= "'" & Ne.am01_total_no & "'"
        strSQL &= ",'" & Ne.am01_house_no & "'"
        strSQL &= ",'" & Ne.am01_name & "'"
        strSQL &= ",'" & Ne.am01_id_no & "'"
        strSQL &= ",'" & Ne.am01_canton & "'"
        strSQL &= ",'" & Ne.am01_street & "'"
        strSQL &= ",'" & Ne.am01_section & "'"
        strSQL &= ",'" & Ne.am01_lane & "'"
        strSQL &= ",'" & Ne.am01_alley & "'"
        strSQL &= ",'" & Ne.am01_number & "'"
        strSQL &= ",'" & Ne.am01_dash & "'"
        strSQL &= ",'" & Ne.am01_number2 & "'"
        strSQL &= ",'" & Ne.am01_sub_no & "'"
        strSQL &= ",'" & Ne.am01_floor & "'"
        strSQL &= ",'" & Ne.am01_alt_addr1 & "'"
        strSQL &= ",'" & Ne.am01_alt_addr2 & "'"
        strSQL &= ",'" & Ne.am01_zone1 & "'"
        strSQL &= ",'" & Ne.am01_telno1 & "'"
        strSQL &= ",'" & Ne.am01_ext1 & "'"
        strSQL &= ",'" & Ne.am01_remark1 & "'"
        strSQL &= ",'" & Ne.am01_zone2 & "'"
        strSQL &= ",'" & Ne.am01_telno2 & "'"
        strSQL &= ",'" & Ne.am01_remark2 & "'"
        strSQL &= ",'" & Ne.am01_telno3 & "'"
        strSQL &= ",'" & Ne.am01_remark3 & "'"
        strSQL &= ",'" & Ne.am01_company_no & "'"
        strSQL &= ",'" & Ne.am01_cno_start & "'"
        strSQL &= ",'" & Ne.am01_cno_stop & "'"
        strSQL &= ",'" & Ne.am01_last_appl & "'"
        strSQL &= ",'" & Ne.am01_usage & "'"
        strSQL &= ",'" & Ne.am01_post_type & "'"
        strSQL &= ",'" & Ne.am01_post_name & "'"
        strSQL &= ",'" & Ne.am01_post_no & "'"
        strSQL &= ",'" & Ne.am01_post_start & "'"
        strSQL &= ",'" & Ne.am01_post_end & "'"
        strSQL &= ",'" & Ne.createdate & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Eninforappm01) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE inforappm01 "
        If Ne.am01_total_no <> "" Then
            strSQLBody &= ",am01_total_no='" & Ne.am01_total_no & "'"
        End If
        If Ne.am01_house_no <> "" Then
            strSQLBody &= ",am01_house_no='" & Ne.am01_house_no & "'"
        End If
        If Ne.am01_name <> "" Then
            strSQLBody &= ",am01_name='" & Ne.am01_name & "'"
        End If
        If Ne.am01_id_no <> "" Then
            strSQLBody &= ",am01_id_no='" & Ne.am01_id_no & "'"
        End If
        If Ne.am01_canton <> "" Then
            strSQLBody &= ",am01_canton='" & Ne.am01_canton & "'"
        End If
        If Ne.am01_street <> "" Then
            strSQLBody &= ",am01_street='" & Ne.am01_street & "'"
        End If
        If Ne.am01_section <> "" Then
            strSQLBody &= ",am01_section='" & Ne.am01_section & "'"
        End If
        If Ne.am01_lane <> "" Then
            strSQLBody &= ",am01_lane='" & Ne.am01_lane & "'"
        End If
        If Ne.am01_alley <> "" Then
            strSQLBody &= ",am01_alley='" & Ne.am01_alley & "'"
        End If
        If Ne.am01_number <> "" Then
            strSQLBody &= ",am01_number='" & Ne.am01_number & "'"
        End If
        If Ne.am01_dash <> "" Then
            strSQLBody &= ",am01_dash='" & Ne.am01_dash & "'"
        End If
        If Ne.am01_number2 <> "" Then
            strSQLBody &= ",am01_number2='" & Ne.am01_number2 & "'"
        End If
        If Ne.am01_sub_no <> "" Then
            strSQLBody &= ",am01_sub_no='" & Ne.am01_sub_no & "'"
        End If
        If Ne.am01_floor <> "" Then
            strSQLBody &= ",am01_floor='" & Ne.am01_floor & "'"
        End If
        If Ne.am01_alt_addr1 <> "" Then
            strSQLBody &= ",am01_alt_addr1='" & Ne.am01_alt_addr1 & "'"
        End If
        If Ne.am01_alt_addr2 <> "" Then
            strSQLBody &= ",am01_alt_addr2='" & Ne.am01_alt_addr2 & "'"
        End If
        If Ne.am01_zone1 <> "" Then
            strSQLBody &= ",am01_zone1='" & Ne.am01_zone1 & "'"
        End If
        If Ne.am01_telno1 <> "" Then
            strSQLBody &= ",am01_telno1='" & Ne.am01_telno1 & "'"
        End If
        If Ne.am01_ext1 <> "" Then
            strSQLBody &= ",am01_ext1='" & Ne.am01_ext1 & "'"
        End If
        If Ne.am01_remark1 <> "" Then
            strSQLBody &= ",am01_remark1='" & Ne.am01_remark1 & "'"
        End If
        If Ne.am01_zone2 <> "" Then
            strSQLBody &= ",am01_zone2='" & Ne.am01_zone2 & "'"
        End If
        If Ne.am01_telno2 <> "" Then
            strSQLBody &= ",am01_telno2='" & Ne.am01_telno2 & "'"
        End If
        If Ne.am01_remark2 <> "" Then
            strSQLBody &= ",am01_remark2='" & Ne.am01_remark2 & "'"
        End If
        If Ne.am01_telno3 <> "" Then
            strSQLBody &= ",am01_telno3='" & Ne.am01_telno3 & "'"
        End If
        If Ne.am01_remark3 <> "" Then
            strSQLBody &= ",am01_remark3='" & Ne.am01_remark3 & "'"
        End If
        If Ne.am01_company_no <> "" Then
            strSQLBody &= ",am01_company_no='" & Ne.am01_company_no & "'"
        End If
        If Ne.am01_cno_start <> "" Then
            strSQLBody &= ",am01_cno_start='" & Ne.am01_cno_start & "'"
        End If
        If Ne.am01_cno_stop <> "" Then
            strSQLBody &= ",am01_cno_stop='" & Ne.am01_cno_stop & "'"
        End If
        If Ne.am01_last_appl <> "" Then
            strSQLBody &= ",am01_last_appl='" & Ne.am01_last_appl & "'"
        End If
        If Ne.am01_usage <> "" Then
            strSQLBody &= ",am01_usage='" & Ne.am01_usage & "'"
        End If
        If Ne.am01_post_type <> "" Then
            strSQLBody &= ",am01_post_type='" & Ne.am01_post_type & "'"
        End If
        If Ne.am01_post_name <> "" Then
            strSQLBody &= ",am01_post_name='" & Ne.am01_post_name & "'"
        End If
        If Ne.am01_post_no <> "" Then
            strSQLBody &= ",am01_post_no='" & Ne.am01_post_no & "'"
        End If
        If Ne.am01_post_start <> "" Then
            strSQLBody &= ",am01_post_start='" & Ne.am01_post_start & "'"
        End If
        If Ne.am01_post_end <> "" Then
            strSQLBody &= ",am01_post_end='" & Ne.am01_post_end & "'"
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
        strSQL = "DELETE inforappm01 where no = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class
