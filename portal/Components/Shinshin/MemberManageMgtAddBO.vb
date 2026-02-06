Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Odbc
Imports System.Data.OracleClient

Public Class MemberManageMgtAddBO
    '列出用戶歷史交易明細
    Public Function Query(ByVal swm_no As Integer) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL &= "select mh_no,mh_wm_no,mh_house_no,'' as user_name, '' as user_addr,add_user,convert(char(10),add_datetime,111) as add_datetime "
        '1120925 add  
        strSQL &= " , mh_gen_user "
        strSQL &= " from member_house "
        strSQL &= " where 1 = 1 "
        strSQL &= " and mh_wm_no='" & swm_no & "' "
        strSQL &= "Order by mh_house_no "
        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    '1121025 add 
    Public Function QuerymemberHouseHistory(ByVal strHouseNo As String, ByVal strDates As String, ByVal strDateE As String, ByVal strType As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As New DataTable
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString2"))

        strSQL &= " select mh_house_no,add_user,add_datetime  ,mh_gen_user  "
        strSQL &= " , case update_type when 1 then '新增' else '刪除' end cupdate "

        strSQL &= " from member_house_history "
        strSQL &= " where 1 = 1 "

        If strHouseNo <> "" Then
            strSQL &= " and mh_house_no=@houseNo "

        End If

        If strDates <> "" Then
            strSQL &= " and convert(varchar , add_datetime,112)>=@DateS "
        End If

        If strDateE <> "" Then
            strSQL &= " and convert(varchar , add_datetime,112)<=@DateE"
        End If

        If strType <> "" Then
            strSQL &= " and update_type = @stype"
        End If
        '超過一次
        strSQL &= " and mh_house_no in ( select mh_house_no  from member_house_history  where update_type='1' group by mh_house_no  having count(*) >=2  ) "
        strSQL &= " Order by add_datetime "


        Dim myCommand As New SqlCommand(strSQL, con)

        myCommand.Parameters.Clear()

        If strHouseNo <> "" Then
            myCommand.Parameters.Add("@houseNo", SqlDbType.VarChar, 10).Value = strHouseNo
        End If

        If strDates <> "" Then
            myCommand.Parameters.Add("@DateS", SqlDbType.VarChar, 8).Value = strDates
        End If

        If strDateE <> "" Then
            myCommand.Parameters.Add("@DateE", SqlDbType.VarChar, 8).Value = strDateE
        End If

        If strType <> "" Then
            myCommand.Parameters.Add("@sType", SqlDbType.VarChar, 1).Value = strType
        End If


        Dim myAdapter As New SqlDataAdapter(myCommand)

        myAdapter.Fill(dt)
        'dt = conn.ReadDataTable(strSQL)
        con.Close()
        Return dt

    End Function


    '查詢用戶名稱
    Public Function QueryHouseName(ByVal shouse_no As String) As DataSet
        ' Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim strSQL As String

        strSQL &= "select * from HSIN.APPM01 "
        strSQL &= " where am01_house_no='" & shouse_no & "' "

        ' Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myCommand As New OracleCommand(strSQL, myConnection)
        'Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        myConnection.Close()
        Return myDataSet

    End Function
    '1121117 add 
    Public Function getDeptCode(ByVal strEmpNo As String) As String

        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim dr As OracleDataReader
        Dim strSQL As String = ""
        Dim strRtnValues As String = " "


        strSQL = " select pm40_dept_no  from hsin1.pm40file  "
        strSQL += " where substr(pm40_emp_no,1,4)=:empNo "


        myConnection.Open()
        Dim myCommand As New OracleCommand(strSQL, myConnection)

        myCommand.Parameters.AddWithValue(":empNo", strEmpNo)

        dr = myCommand.ExecuteReader

        If dr.HasRows Then
            dr.Read()
            strRtnValues = dr("pm40_dept_no").ToString
        Else
            strRtnValues = " "
        End If
        dr.Close()
        myConnection.Close()

        Return strRtnValues

    End Function

    Public Overridable Function GetCanton(ByVal AT01_code As String) As String
        ' Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim strSQL As String
        'Dim strSQL As String = ""

        strSQL &= "Select * from HSIN.APPT01 where AT01_code='" & AT01_code & "' and AT01_KIND='0' "


        ' Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myCommand As New OracleCommand(strSQL, myConnection)
        'Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        myConnection.Close()
        If myDataSet.Tables(0).Rows.Count > 0 Then
            Return myDataSet.Tables(0).Rows(0).Item("AT01_name")
        End If

    End Function

    Public Overridable Function GetStreet(ByVal AT02_CANTON As String, ByVal AT02_STREET As Integer) As String
        ' Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim strSQL As String = ""

        strSQL &= "Select * from HSIN.APPT02 where AT02_CANTON='" & AT02_CANTON & "'"
        strSQL &= " and AT02_STREET=" & AT02_STREET

        ' Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myCommand As New OracleCommand(strSQL, myConnection)
        'Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        myConnection.Close()
        If myDataSet.Tables(0).Rows.Count > 0 Then
            Return myDataSet.Tables(0).Rows(0).Item("AT02_NAME")
        End If


    End Function

#Region "GetDetailHouseNoIsRepeat　判斷member_house資料表的用戶號碼是否是重覆"
    Public Function GetDetailHouseNoIsRepeat(ByVal HouseNo As String) As Integer
        Dim count As Integer
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "select count(mh_house_no) as countno from member_house where mh_house_no="
        strSQL &= "'" & HouseNo & "'"

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item("countno")
        Else
            Return 0
        End If
        conn.close()

    End Function
#End Region

#Region "Insert　新增member_house資料表的用戶號碼"
    Public Function Insert(ByVal Ne As Memberhouse) As Integer
        Dim result As Integer = 0
        Dim today As Date = Now
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString2"))
        Dim tran As SqlClient.SqlTransaction
        Dim cmd As SqlClient.SqlCommand
        Dim sqlstr As String
        Dim swm_house_list As String
        Dim i As Integer
        Dim dt As New DataTable
        Dim dt1 As New DataTable


        '查詢用戶檔
        sqlstr = "select mh_house_no from member_house where mh_wm_no= '" & Ne.mh_wm_no & "'"
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(sqlstr)
        conn.close()
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                swm_house_list &= "," & dt.Rows(i).Item("mh_house_no")
            Next
            swm_house_list &= "," & Ne.mh_house_no & ","
        Else
            swm_house_list = "," & Ne.mh_house_no & ","
        End If

        '查詢會員檔
        sqlstr = "select * from webmember where wm_no= '" & Ne.mh_wm_no & "'"
        Dim conn1 As New DBConn2
        dt1 = conn1.ReadDataTable(sqlstr)
        conn1.close()

        con.Open()
        cmd = con.CreateCommand()
        cmd.Connection = con
        tran = con.BeginTransaction(IsolationLevel.ReadUncommitted) '交易開始
        cmd.Transaction = tran

        Try
            '新增用戶資料
            'sqlstr = "Insert into member_house (mh_wm_no,mh_house_no,mh_ers_flag,add_user,add_datetime,upd_user,upd_datetime) values ("
            'sqlstr &= "@mh_wm_no,@mh_house_no,@mh_ers_flag,@add_user,@add_datetime,@upd_user,@upd_datetime"
            'modify 1120925  add mh_gen_user  mh_gen_dept 

            sqlstr = "Insert into member_house (mh_wm_no,mh_house_no,mh_ers_flag,add_user,add_datetime,upd_user,upd_datetime,mh_gen_user,mh_gen_dept) values ("
            sqlstr &= "@mh_wm_no,@mh_house_no,@mh_ers_flag,@add_user,@add_datetime,@upd_user,@upd_datetime,@mh_gen_user ,@mh_gen_dept "
            sqlstr &= ")"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@mh_wm_no", SqlDbType.Decimal).Value = Ne.mh_wm_no
            cmd.Parameters.Add("@mh_house_no", SqlDbType.NVarChar, 10).Value = Ne.mh_house_no
            cmd.Parameters.Add("@mh_ers_flag", SqlDbType.NVarChar, 1).Value = Ne.mh_ers_flag
            cmd.Parameters.Add("@add_user", SqlDbType.NVarChar, 50).Value = Ne.upd_user
            cmd.Parameters.Add("@add_datetime", SqlDbType.DateTime, 10).Value = today
            cmd.Parameters.Add("@upd_user", SqlDbType.NVarChar, 50).Value = Ne.upd_user
            cmd.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today
            cmd.Parameters.Add("@mh_gen_user", SqlDbType.VarChar, 4).Value = Ne.mh_gen_user  '1120925 add 
            cmd.Parameters.Add("@mh_gen_Dept", SqlDbType.VarChar, 5).Value = Ne.mh_gen_dept  '1120925 add 
            result = cmd.ExecuteNonQuery()


            '更新會員主檔
            sqlstr = "update webmember set wm_house_list = @wm_house_list where wm_no=@mh_wm_no"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@wm_house_list", SqlDbType.NVarChar, 225).Value = swm_house_list
            cmd.Parameters.Add("@mh_wm_no", SqlDbType.Decimal).Value = Ne.mh_wm_no
            result = cmd.ExecuteNonQuery()

            If dt1.Rows.Count > 0 Then
                '新增歷史檔
                sqlstr = "Insert into webmember_history (wm_no,wm_password,wm_user_name,wm_user_o_name,wm_tel_h,wm_tel_o,wm_tel_o2,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,wm_house_no,add_user,add_datetime,update_type,trans_type,mhis_memo) values ("
                sqlstr &= "@wm_no,@wm_password,@wm_user_name,@wm_user_o_name,@wm_tel_h,@wm_tel_o,@wm_tel_o2,@wm_mobile,@wm_email,@wm_id,@wm_org_flag,@wm_paper_flag,@wm_open_flag,@wm_house_no,@add_user,@add_datetime,@update_type,@trans_type,@mhis_memo"
                sqlstr &= ")"
                cmd.CommandText = sqlstr
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@wm_no", SqlDbType.Decimal).Value = dt1.Rows(0).Item("wm_no")
                cmd.Parameters.Add("@wm_password", SqlDbType.VarChar, 40).Value = dt1.Rows(0).Item("wm_password")
                cmd.Parameters.Add("@wm_user_name", SqlDbType.VarChar, 50).Value = dt1.Rows(0).Item("wm_user_name")
                cmd.Parameters.Add("@wm_user_o_name", SqlDbType.VarChar, 125).Value = dt1.Rows(0).Item("wm_user_o_name")
                cmd.Parameters.Add("@wm_tel_h", SqlDbType.VarChar, 15).Value = dt1.Rows(0).Item("wm_tel_h")
                cmd.Parameters.Add("@wm_tel_o", SqlDbType.VarChar, 15).Value = dt1.Rows(0).Item("wm_tel_o")
                cmd.Parameters.Add("@wm_tel_o2", SqlDbType.VarChar, 5).Value = dt1.Rows(0).Item("wm_tel_o2")
                cmd.Parameters.Add("@wm_mobile", SqlDbType.VarChar, 10).Value = dt1.Rows(0).Item("wm_mobile")
                cmd.Parameters.Add("@wm_email", SqlDbType.VarChar, 50).Value = dt1.Rows(0).Item("wm_email")
                cmd.Parameters.Add("@wm_id", SqlDbType.VarChar, 10).Value = dt1.Rows(0).Item("wm_id")
                cmd.Parameters.Add("@wm_org_flag", SqlDbType.Char, 1).Value = dt1.Rows(0).Item("wm_org_flag")
                cmd.Parameters.Add("@wm_paper_flag", SqlDbType.Char, 1).Value = dt1.Rows(0).Item("wm_paper_flag")
                cmd.Parameters.Add("@wm_open_flag", SqlDbType.Char, 1).Value = dt1.Rows(0).Item("wm_open_flag")
                cmd.Parameters.Add("@wm_house_no", SqlDbType.Char, 10).Value = Ne.mh_house_no
                cmd.Parameters.Add("@add_user", SqlDbType.VarChar, 20).Value = Ne.upd_user
                cmd.Parameters.Add("@add_datetime", SqlDbType.DateTime, 10).Value = today
                cmd.Parameters.Add("@update_type", SqlDbType.Char, 1).Value = "4"
                cmd.Parameters.Add("@trans_type", SqlDbType.Char, 1).Value = "0"
                cmd.Parameters.Add("@mhis_memo", SqlDbType.Char, 255).Value = ""
                result = cmd.ExecuteNonQuery()



                '1120925 add  insert 
                sqlstr = "insert into member_house_history (mh_no,mh_wm_no , mh_house_no , mh_ers_flag , add_user,add_datetime,update_type,mh_gen_user,mh_gen_dept)"
                sqlstr += " select mh_no,mh_wm_no , mh_house_no , mh_ers_flag , add_user,add_datetime,'1' as update_type ,mh_gen_user ,mh_gen_dept "
                sqlstr += " from member_house "
                sqlstr += " where mh_house_no=@HouseNo "

                cmd.CommandText = sqlstr
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@HouseNo", SqlDbType.VarChar, 10).Value = Ne.mh_house_no

                result = cmd.ExecuteNonQuery()
                'add end 1120925 
            End If

            tran.Commit()           '交易結束
            con.Close()
            cmd = Nothing
            con = Nothing
            Return result
        Catch ex As Exception
            tran.Rollback()         '交易恢復
            con.Close()
            cmd = Nothing
            con = Nothing
            'Err.Raise(Err.Description & ":" & sqlstr.ToString)
            Return result
        End Try

    End Function
#End Region


#Region "delete　刪除member_house資料表的用戶號碼"
    Public Function SelectDelete(ByVal smh_no As String, ByVal shouse_no As String, ByVal swm_no As Integer, ByVal smhis_memo As String, ByVal supd_user As String) As Integer
        Dim result As Integer = 0
        Dim today As Date = Now
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString2"))
        Dim tran As SqlClient.SqlTransaction
        Dim cmd As SqlClient.SqlCommand
        Dim sqlstr As String
        Dim swm_house_list As String
        Dim i As Integer
        Dim j As Integer
        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim sdhouse_no() As String

        '查詢刪除後的用戶檔
        sqlstr = "select mh_house_no from member_house where mh_wm_no = " & swm_no & " and mh_no not in (" & smh_no & ")"
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(sqlstr)
        conn.close()
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                swm_house_list &= "," & dt.Rows(i).Item("mh_house_no")
            Next
            swm_house_list = ","
        Else
            swm_house_list = ""
        End If

        '查詢會員檔
        sqlstr = "select * from webmember where wm_no= " & swm_no
        Dim conn1 As New DBConn2
        dt1 = conn1.ReadDataTable(sqlstr)
        conn1.close()

        con.Open()
        cmd = con.CreateCommand()
        cmd.Connection = con
        tran = con.BeginTransaction(IsolationLevel.ReadUncommitted) '交易開始
        cmd.Transaction = tran

        Try
            '刪除用戶資料
            sqlstr = "delete from member_house where mh_wm_no = @mh_wm_no and mh_no in (" & smh_no & ")"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@mh_wm_no", SqlDbType.Decimal).Value = swm_no
            result = cmd.ExecuteNonQuery()


            '更新會員主檔
            sqlstr = "update webmember set wm_house_list = @wm_house_list where wm_no=@mh_wm_no"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@wm_house_list", SqlDbType.NVarChar, 225).Value = swm_house_list
            cmd.Parameters.Add("@mh_wm_no", SqlDbType.Decimal).Value = swm_no
            result = cmd.ExecuteNonQuery()

            If dt1.Rows.Count > 0 Then
                '新增歷史檔
                sdhouse_no = shouse_no.Split(",")
                For j = 0 To sdhouse_no.Length - 1
                    sqlstr = "Insert into webmember_history (wm_no,wm_password,wm_user_name,wm_user_o_name,wm_tel_h,wm_tel_o,wm_tel_o2,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,wm_house_no,add_user,add_datetime,update_type,trans_type,mhis_memo) values ("
                    sqlstr &= "@wm_no,@wm_password,@wm_user_name,@wm_user_o_name,@wm_tel_h,@wm_tel_o,@wm_tel_o2,@wm_mobile,@wm_email,@wm_id,@wm_org_flag,@wm_paper_flag,@wm_open_flag,@wm_house_no,@add_user,@add_datetime,@update_type,@trans_type,@mhis_memo"
                    sqlstr &= ")"
                    cmd.CommandText = sqlstr
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@wm_no", SqlDbType.Decimal).Value = dt1.Rows(0).Item("wm_no")
                    cmd.Parameters.Add("@wm_password", SqlDbType.VarChar, 40).Value = dt1.Rows(0).Item("wm_password")
                    cmd.Parameters.Add("@wm_user_name", SqlDbType.VarChar, 50).Value = "-"
                    cmd.Parameters.Add("@wm_user_o_name", SqlDbType.VarChar, 125).Value = "-"
                    cmd.Parameters.Add("@wm_tel_h", SqlDbType.VarChar, 15).Value = "-"
                    cmd.Parameters.Add("@wm_tel_o", SqlDbType.VarChar, 15).Value = "-"
                    cmd.Parameters.Add("@wm_tel_o2", SqlDbType.VarChar, 5).Value = "-"
                    cmd.Parameters.Add("@wm_mobile", SqlDbType.VarChar, 10).Value = "-"
                    cmd.Parameters.Add("@wm_email", SqlDbType.VarChar, 50).Value = "-"
                    cmd.Parameters.Add("@wm_id", SqlDbType.VarChar, 10).Value = dt1.Rows(0).Item("wm_id")
                    cmd.Parameters.Add("@wm_org_flag", SqlDbType.Char, 1).Value = dt1.Rows(0).Item("wm_org_flag")
                    cmd.Parameters.Add("@wm_paper_flag", SqlDbType.Char, 1).Value = "-"
                    cmd.Parameters.Add("@wm_open_flag", SqlDbType.Char, 1).Value = "-"
                    cmd.Parameters.Add("@wm_house_no", SqlDbType.Char, 10).Value = sdhouse_no(j)
                    cmd.Parameters.Add("@add_user", SqlDbType.VarChar, 20).Value = supd_user
                    cmd.Parameters.Add("@add_datetime", SqlDbType.DateTime, 10).Value = today
                    cmd.Parameters.Add("@update_type", SqlDbType.Char, 1).Value = "5"
                    cmd.Parameters.Add("@trans_type", SqlDbType.Char, 1).Value = "0"
                    cmd.Parameters.Add("@mhis_memo", SqlDbType.Char, 255).Value = smhis_memo
                    result = cmd.ExecuteNonQuery()
                Next
            End If

            tran.Commit()           '交易結束
            con.Close()
            cmd = Nothing
            con = Nothing
            Return result
        Catch ex As Exception
            tran.Rollback()         '交易恢復
            con.Close()
            cmd = Nothing
            con = Nothing
            'Err.Raise(Err.Description & ":" & sqlstr.ToString)
            Return result
        End Try

    End Function
#End Region

End Class
