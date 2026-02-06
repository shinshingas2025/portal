Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data.OracleClient
'modify 106.09.26

Public Class APPX01DAO
    '2014-03-26 Yeh Begin
    Public Overridable Function GetAM67(ByVal vol_no As String, ByVal yymm As Integer, ByVal type As String) As DataSet
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim strSQL As String = ""
        strSQL = "Select * from HSIN.APPM67 "
        'strSQL = strSQL & " where am67_vol_no =@vol_no and am67_yymm =@yymm  and am67_type @type "
        strSQL = strSQL & " where am67_vol_no ='" & vol_no & "' and am67_yymm =" & yymm & " and am67_type = '" & type & "'"
        strSQL = strSQL & " order by am67_vol_no,am67_yymm,am67_org_yymm,am67_mark,am67_type,am67_seq"
        ' Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myCommand As New OracleCommand(strSQL, myConnection)
        'myCommand.Parameters.Add("@vol_no", SqlDbType.Char, 1).Value = vol_no
        'myCommand.Parameters.Add("@yymm", SqlDbType.SmallInt, 5).Value = yymm
        'myCommand.Parameters.Add("@type", SqlDbType.Char, 1).Value = type
        ' Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet
    End Function

    Public Overridable Function GetAM68(ByVal yymm As Integer, ByVal house_no As String) As DataSet
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim strSQL As String = ""
        strSQL = "Select * from HSIN.APPM68 "
        strSQL = strSQL & " where am68_yymm =" & yymm & " and am68_house_no = '" & house_no & "'"
        'Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myCommand As New OracleCommand(strSQL, myConnection)
        'Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet
    End Function
    Public Overridable Function GetAM66(ByVal yymm As Integer) As DataSet
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim strSQL As String = ""
        strSQL = "Select * from HSIN.APPM66 "
        strSQL = strSQL & " where am66_adj_date <=" & yymm & " order by am66_adj_date DESC "
        'Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myCommand As New OracleCommand(strSQL, myConnection)
        'Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet
    End Function

    '2014-03-26 Yeh End
    Public Sub InsertEntity(ByVal APPX01_Entity As APPX01Entity)
        'Dim entityID As String
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))

        'Dim myCommand As New OdbcCommand("insert into appx01 (ax01_appl_no,ax01_house_no,ax01_appl_date,ax01_name,ax01_canton,ax01_street,ax01_section,ax01_lane,ax01_alley,ax01_number,ax01_sub_no,ax01_floor,ax01_room,ax01_alt_addr,ax01_zone1,ax01_telno1,ax01_zone2,ax01_telno2,ax01_appl_kind,ax01_usage,ax01_case_dis,ax01_extend,ax01_appl_cnt,ax01_gen_user,ax01_dsgn_rno,ax01_send_dsgn,ax01_not_dsgn_cd,ax01_de_user,ax01_de_date,ax01_print_date,ax01_user_id,ax01_upd_datetime) values (@ax01_appl_no,@ax01_house_no,@ax01_appl_date,@ax01_name,@ax01_canton,@ax01_street,@ax01_section,@ax01_lane,@ax01_alley,@ax01_number,@ax01_sub_no,@ax01_floor,@ax01_room,@ax01_alt_addr,@ax01_zone1,@ax01_telno1,@ax01_zone2,@ax01_telno2,@ax01_appl_kind,@ax01_usage,@ax01_case_dis,@ax01_extend,@ax01_appl_cnt,@ax01_gen_user,@ax01_dsgn_rno,@ax01_send_dsgn,@ax01_not_dsgn_cd,@ax01_de_user,@ax01_de_date,@ax01_print_date,@ax01_user_id,@ax01_upd_datetime)", myConnection)
        Dim InsSQL As String
        'strSQL = "insert into appx01 (ax01_appl_no,ax01_house_no,ax01_appl_date,ax01_name,ax01_canton,ax01_street,ax01_section,ax01_lane,ax01_alley,ax01_number,ax01_sub_no,ax01_floor,ax01_room,ax01_alt_addr,ax01_zone1,ax01_telno1,ax01_zone2,ax01_telno2,ax01_appl_kind,ax01_usage,ax01_case_dis,ax01_extend,ax01_appl_cnt,ax01_gen_user,ax01_dsgn_rno,ax01_send_dsgn,ax01_not_dsgn_cd,ax01_de_user,ax01_de_date,ax01_print_date,ax01_user_id,ax01_upd_datetime) values ("
        'strSQL += APPX01_Entity.ax01_appl_no ,@ax01_house_no,@ax01_appl_date,@ax01_name,@ax01_canton,@ax01_street,@ax01_section,@ax01_lane,@ax01_alley,@ax01_number,@ax01_sub_no,@ax01_floor,@ax01_room,@ax01_alt_addr,@ax01_zone1,@ax01_telno1,@ax01_zone2,@ax01_telno2,@ax01_appl_kind,@ax01_usage,@ax01_case_dis,@ax01_extend,@ax01_appl_cnt,@ax01_gen_user,@ax01_dsgn_rno,@ax01_send_dsgn,@ax01_not_dsgn_cd,@ax01_de_user,@ax01_de_date,@ax01_print_date,@ax01_user_id,@ax01_upd_datetime)", myConnection)

        Dim today As Date = Now
        InsSQL = "Insert Into HSIN.appx01 ("
        InsSQL = InsSQL & "ax01_appl_no,"
        InsSQL = InsSQL & "ax01_house_no,"
        InsSQL = InsSQL & "ax01_appl_date,"
        InsSQL = InsSQL & "ax01_name,"
        InsSQL = InsSQL & "ax01_canton,"
        InsSQL = InsSQL & "ax01_street,"
        InsSQL = InsSQL & "ax01_section,"
        InsSQL = InsSQL & "ax01_lane,"
        InsSQL = InsSQL & "ax01_alley,"
        InsSQL = InsSQL & "ax01_number,"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "ax01_dash,"
        InsSQL = InsSQL & "ax01_number2,"
        '測試環境沒有的資料------------------------------------

        InsSQL = InsSQL & "ax01_sub_no,"
        InsSQL = InsSQL & "ax01_floor,"
        InsSQL = InsSQL & "ax01_room,"
        InsSQL = InsSQL & "ax01_alt_addr,"
        InsSQL = InsSQL & "ax01_zone1,"
        InsSQL = InsSQL & "ax01_telno1,"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "ax01_ext1,"
        InsSQL = InsSQL & "ax01_remark1,"
        '測試環境沒有的資料------------------------------------

        InsSQL = InsSQL & "ax01_zone2,"
        InsSQL = InsSQL & "ax01_telno2,"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "ax01_remark2,"
        InsSQL = InsSQL & "ax01_telno3,"
        InsSQL = InsSQL & "ax01_remark3,"
        '測試環境沒有的資料------------------------------------

        InsSQL = InsSQL & "ax01_appl_kind,"
        InsSQL = InsSQL & "ax01_usage,"
        InsSQL = InsSQL & "ax01_case_dis,"
        InsSQL = InsSQL & "ax01_extend,"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "ax01_post_name,"
        '測試環境沒有的資料------------------------------------

        InsSQL = InsSQL & "ax01_appl_cnt,"
        InsSQL = InsSQL & "ax01_gen_user,"
        InsSQL = InsSQL & "ax01_dsgn_rno,"
        InsSQL = InsSQL & "ax01_send_dsgn,"
        InsSQL = InsSQL & "ax01_not_dsgn_cd,"
        InsSQL = InsSQL & "ax01_de_user,"
        InsSQL = InsSQL & "ax01_de_date,"
        InsSQL = InsSQL & "ax01_print_date,"
        InsSQL = InsSQL & "ax01_user_id,"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "ax01_ald_mark,"
        InsSQL = InsSQL & "ax01_esv_mark,"
        InsSQL = InsSQL & "ax01_esv_yorn,"
        InsSQL = InsSQL & "ax01_id_no,"
        InsSQL = InsSQL & "ax01_company_no,"
        '測試環境沒有的資料------------------------------------

        InsSQL = InsSQL & "ax01_upd_datetime"

        InsSQL = InsSQL & ") values ("


        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_appl_no.Trim & "',"
        InsSQL = InsSQL & APPX01_Entity.ax01_house_no.Trim & ","
        InsSQL = InsSQL & APPX01_Entity.ax01_appl_date.Trim & ","
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_name.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_canton.Trim & "',"
        If APPX01_Entity.ax01_street.Trim = "" Then
            InsSQL = InsSQL & " null " & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_street.Trim & ","
        End If

        If APPX01_Entity.ax01_section.Trim = "" Then
            InsSQL = InsSQL & " null " & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_section.Trim & ","
        End If

        If APPX01_Entity.ax01_lane.Trim = "" Then
            InsSQL = InsSQL & " null " & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_lane.Trim & ","
        End If

        If APPX01_Entity.ax01_alley.Trim = "" Then
            InsSQL = InsSQL & " null " & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_alley.Trim & ","
        End If
        'InsSQL = InsSQL & APPX01_Entity.ax01_section.Trim & ","
        'InsSQL = InsSQL & APPX01_Entity.ax01_lane.Trim & ","
        'InsSQL = InsSQL & APPX01_Entity.ax01_alley.Trim & ","

        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_number.Trim & "',"

        '測試環境沒有的資料------------------------------------
        If APPX01_Entity.ax01_dash.Trim = "" Then
            InsSQL = InsSQL & " null " & ","
        Else
            InsSQL = InsSQL & "'" & APPX01_Entity.ax01_dash.Trim & "',"
        End If

        If APPX01_Entity.ax01_number2.Trim = "" Then
            InsSQL = InsSQL & " null " & ","
        Else
            InsSQL = InsSQL & "" & APPX01_Entity.ax01_number2 & ","
        End If


        '測試環境沒有的資料------------------------------------

        If APPX01_Entity.ax01_sub_no.Trim = "" Then
            InsSQL = InsSQL & " null" & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_sub_no.Trim & ","
        End If
        'InsSQL = InsSQL & APPX01_Entity.ax01_sub_no.Trim & ","

        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_floor.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_room.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_alt_addr.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_zone1.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_telno1.Trim & "',"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_ext1 & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_remark1 & "',"
        '測試環境沒有的資料------------------------------------

        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_zone2.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_telno2.Trim & "',"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_remark2 & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_telno3 & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_remark3 & "',"
        '測試環境沒有的資料------------------------------------

        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_appl_kind.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_usage.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_case_dis.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_extend.Trim & "',"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_post_name & "',"
        '測試環境沒有的資料------------------------------------

        If APPX01_Entity.ax01_appl_cnt.Trim = "" Then
            InsSQL = InsSQL & "null" & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_appl_cnt.Trim & ","
        End If
        'InsSQL = InsSQL & APPX01_Entity.ax01_appl_cnt.Trim & ","

        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_gen_user.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_dsgn_rno.Trim & "',"

        If APPX01_Entity.ax01_send_dsgn.Trim = "" Then
            InsSQL = InsSQL & "null" & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_send_dsgn.Trim & ","
        End If
        'InsSQL = InsSQL & APPX01_Entity.ax01_send_dsgn.Trim & ","

        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_not_dsgn_cd.Trim & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_de_user.Trim & "',"

        If APPX01_Entity.ax01_de_date.Trim = "" Then
            InsSQL = InsSQL & "null" & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_de_date.Trim & ","
        End If
        If APPX01_Entity.ax01_print_date.Trim = "" Then
            InsSQL = InsSQL & "null" & ","
        Else
            InsSQL = InsSQL & APPX01_Entity.ax01_print_date.Trim & ","
        End If
        'InsSQL = InsSQL & APPX01_Entity.ax01_de_date.Trim & ","
        'InsSQL = InsSQL & APPX01_Entity.ax01_print_date.Trim & ","

        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_user_id.Trim & "',"

        '測試環境沒有的資料------------------------------------
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_ald_mark & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_esv_mark & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_esv_yorn & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_id_no & "',"
        InsSQL = InsSQL & "'" & APPX01_Entity.ax01_company_no & "',"
        '測試環境沒有的資料------------------------------------

        'InsSQL = InsSQL & "" & APPX01_Entity.ax01_upd_datetime & " "
        'modify 1070929 
        InsSQL = InsSQL & " sysDate "
        InsSQL = InsSQL & " ) "
        'entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000000", 8)
        'entityID = GetMaxEntityID(entityID)
        'myCommand.Parameters.Add("@ax01_appl_no", SqlDbType.Char, 11).Value = APPX01_Entity.ax01_appl_no
        'myCommand.Parameters.Add("@ax01_house_no", SqlDbType.Int).Value = APPX01_Entity.ax01_house_no
        'myCommand.Parameters.Add("@ax01_appl_date", SqlDbType.Int).Value = APPX01_Entity.ax01_appl_date
        'myCommand.Parameters.Add("@ax01_name", SqlDbType.Char, 40).Value = APPX01_Entity.ax01_name
        'myCommand.Parameters.Add("@ax01_canton", SqlDbType.Char, 1).Value = APPX01_Entity.ax01_canton
        'myCommand.Parameters.Add("@ax01_street", SqlDbType.Int).Value = APPX01_Entity.ax01_street
        'myCommand.Parameters.Add("@ax01_section", SqlDbType.Int).Value = APPX01_Entity.ax01_section
        'myCommand.Parameters.Add("@ax01_lane", SqlDbType.Int).Value = APPX01_Entity.ax01_lane
        'myCommand.Parameters.Add("@ax01_alley", SqlDbType.Int).Value = APPX01_Entity.ax01_alley
        'myCommand.Parameters.Add("@ax01_number", SqlDbType.Char, 4).Value = APPX01_Entity.ax01_number
        'myCommand.Parameters.Add("@ax01_sub_no", SqlDbType.Int).Value = APPX01_Entity.ax01_sub_no
        'myCommand.Parameters.Add("@ax01_floor", SqlDbType.Char, 2).Value = APPX01_Entity.ax01_floor
        'myCommand.Parameters.Add("@ax01_room", SqlDbType.Char, 4).Value = APPX01_Entity.ax01_room
        'myCommand.Parameters.Add("@ax01_alt_addr", SqlDbType.Char, 30).Value = APPX01_Entity.ax01_alt_addr
        'myCommand.Parameters.Add("@ax01_zone1", SqlDbType.Char, 3).Value = APPX01_Entity.ax01_zone1
        'myCommand.Parameters.Add("@ax01_telno1", SqlDbType.Char, 10).Value = APPX01_Entity.ax01_telno1
        'myCommand.Parameters.Add("@ax01_zone2", SqlDbType.Char, 3).Value = APPX01_Entity.ax01_zone2
        'myCommand.Parameters.Add("@ax01_telno2", SqlDbType.Char, 10).Value = APPX01_Entity.ax01_telno2
        'myCommand.Parameters.Add("@ax01_appl_kind", SqlDbType.Char, 1).Value = APPX01_Entity.ax01_appl_kind
        'myCommand.Parameters.Add("@ax01_usage", SqlDbType.Char, 1).Value = APPX01_Entity.ax01_usage
        'myCommand.Parameters.Add("@ax01_case_dis", SqlDbType.Char, 1).Value = APPX01_Entity.ax01_case_dis
        'myCommand.Parameters.Add("@ax01_extend", SqlDbType.Char, 6).Value = APPX01_Entity.ax01_extend
        'myCommand.Parameters.Add("@ax01_appl_cnt", SqlDbType.Int).Value = APPX01_Entity.ax01_appl_cnt
        'myCommand.Parameters.Add("@ax01_gen_user", SqlDbType.Char, 4).Value = APPX01_Entity.ax01_gen_user
        'myCommand.Parameters.Add("@ax01_dsgn_rno", SqlDbType.Char, 9).Value = APPX01_Entity.ax01_dsgn_rno
        'myCommand.Parameters.Add("@ax01_send_dsgn", SqlDbType.Int).Value = APPX01_Entity.ax01_send_dsgn
        'myCommand.Parameters.Add("@ax01_not_dsgn_cd", SqlDbType.Char, 1).Value = APPX01_Entity.ax01_not_dsgn_cd
        'myCommand.Parameters.Add("@ax01_de_user", SqlDbType.Char, 4).Value = APPX01_Entity.ax01_de_user
        'myCommand.Parameters.Add("@ax01_de_date", SqlDbType.Int).Value = APPX01_Entity.ax01_de_date
        'myCommand.Parameters.Add("@ax01_print_date", SqlDbType.Int).Value = APPX01_Entity.ax01_print_date
        'myCommand.Parameters.Add("@ax01_user_id", SqlDbType.Char, 4).Value = APPX01_Entity.ax01_user_id
        'myCommand.Parameters.Add("@ax01_upd_datetime", SqlDbType.Int.DateTime).Value = APPX01_Entity.ax01_upd_datetime

        myConnection.Open()
        'Dim myCommand As New OdbcCommand(InsSQL, myConnection)       
        Dim myCommand As New OracleCommand(InsSQL, myConnection)
        myCommand.ExecuteNonQuery()
        myConnection.Close()
        'Return entityID
    End Sub
    ' add 1070929  
    Public Function GetLastNu(ByVal ac02_year As Integer) As String
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim strSQL As String = ""
        Dim rtnValue As String = ""
        'strSQL = "select * from appc02 where ac02_year=" & ac02_year
        strSQL = " select  max(substr(ax01_appl_no,5,4)) +1  lastNu  from  HSIN.appx01  Where   ax01_appl_date >=:ac02_year "
        'strSQL = "select * from appc02 where ac02_year=@ac02_year"
        'Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myCommand As New OracleCommand(strSQL, myConnection)
        myCommand.Parameters.Add(":ac02_year", ac02_year & "0101")
        'Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myDataReader As OracleDataReader
        myConnection.Open()
        myDataReader = myCommand.ExecuteReader
        If myDataReader.HasRows AndAlso myDataReader.Read Then
            rtnValue = myDataReader("lastNu").ToString
        End If
        myConnection.Close()
        myDataReader.Close()
        Return rtnValue
    End Function
End Class
