Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data.OracleClient
Public Class Batch_job
    Public Overridable Function GetMisData(ByVal SqlStr As String) As DataTable
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString")) ' OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet.Tables(0)
    End Function


#Region "ExecuteCom　判斷member_house資料表的用戶號碼是否是重覆"
    Public Function ExecuteCom(ByVal SqlStr As String)
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("oracleConnectionString"))

        myConnection.Open()
        ' Dim myCommand As New OdbcCommand(SqlStr, myConnection)
        Dim myCommand As New OracleCommand(SqlStr, myConnection)
        myCommand.ExecuteNonQuery()
        myConnection.Close()

    End Function

    Public Function GetMisDataIsRepeat(ByVal SqlStr As String) As Integer
        Dim count As String
        Dim Flag As Integer
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim selectSQL As String
        'Dim myCommand As New OdbcCommand(SqlStr, myConnection)
        Dim myCommand As New OracleCommand(SqlStr, myConnection)
        myConnection.Open()
        'Dim myReader As OdbcDataReader
        Dim myReader As OracleDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
#If 1 Then
        Flag = myReader.HasRows
#Else
        While myReader.Read()
            Try
                count = CStr(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                count = -1
            End Try
        End While
#End If
        myReader.Close()
        Return Flag
    End Function
#End Region

    Public Function QueryInformixappm01(ByVal HOUSE_NO As String) As DataTable
        ' Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim i As Integer
        Dim da As SqlDataAdapter
        Dim dt As New DataTable

        Dim SqlStr As String = "select * from HSIN.appm01 where AM01_HOUSE_NO = :HouseNO "

        myConnection.Open()
        ' Dim myCommand As New OdbcCommand(SqlStr, myConnection)
        Dim myCommand As New OracleCommand(SqlStr, myConnection)
        myCommand.Parameters.Add(":HouseNO", HOUSE_NO)
        ' Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet

        Try
            myAdapter.Fill(myDataSet)
        Catch ex As Exception
            Err.Raise(-1, "db.ReadDataTable", Err.Description & ":" & SqlStr)
        End Try
        myConnection.Close()
        Return myDataSet.Tables(0)

    End Function
    '1130227 add Query saft03 
    Public Function Querysaft03(ByVal strGenUser As String) As DataTable

        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))

        Dim dt As New DataTable

        Dim SqlStr As String
        SqlStr = " Select case when FT03_ABOD_DATE in ('1','2') then  '3'   "
        SqlStr &= " when  FT03_ABOD_DATE =21 then '2' when  FT03_ABOD_DATE =31 then '4'  "
        SqlStr &= " when  FT03_ABOD_DATE =31 then '4'  "
        SqlStr &= " Else '1' "
        SqlStr &= " end comp "
        SqlStr &= " from HSIN.saft03   where ft03_work_id = :GenUser  "

        myConnection.Open()

        Dim myCommand As New OracleCommand(SqlStr, myConnection)

        myCommand.Parameters.Add(":GenUser", strGenUser)

        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet

        Try
            myAdapter.Fill(myDataSet)
        Catch ex As Exception
            Err.Raise(-1, "db.ReadDataTable", Err.Description & ":" & SqlStr)
        End Try
        myConnection.Close()
        Return myDataSet.Tables(0)

    End Function

    '1130206 add 
    Public Function QueryRM28(ByVal intHouseNo As Integer, ByVal intAppDtae As Integer) As DataTable

        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim i As Integer
        Dim da As SqlDataAdapter
        Dim dt As New DataTable

        Dim SqlStr As String = "select * from HSIN.rcpm28 where rm28_house_no = :HouseNO and rm28_appl_date=:irm28_appl_date and RM28_SOURCE='5' "

        myConnection.Open()

        Dim myCommand As New OracleCommand(SqlStr, myConnection)
        myCommand.Parameters.Add(":HouseNO", intHouseNo)
        myCommand.Parameters.Add(":irm28_appl_date", intAppDtae)

        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet

        Try
            myAdapter.Fill(myDataSet)
        Catch ex As Exception
            Err.Raise(-1, "db.ReadDataTable", Err.Description & ":" & SqlStr)
        End Try
        myConnection.Close()
        Return myDataSet.Tables(0)

    End Function


    Public Function QueryInformixappm48(ByVal HOUSE_NO As String) As DataTable
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim i As Integer
        Dim da As SqlDataAdapter
        Dim dt As New DataTable

        Dim SqlStr As String = "select * from HSIN.appm48 where AM48_HOUSE_NO =:HouseNO "
        myConnection.Open()
        'Dim myCommand As New OdbcCommand(SqlStr, myConnection)
        Dim myCommand As New OracleCommand(SqlStr, myConnection)
        myCommand.Parameters.Add(":HouseNO", HOUSE_NO)
        'Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet

        Try
            myAdapter.Fill(myDataSet)
        Catch ex As Exception
            Err.Raise(-1, "db.ReadDataTable", Err.Description & ":" & SqlStr)
        End Try
        myConnection.Close()
        Return myDataSet.Tables(0)

    End Function

    Public Overridable Function GetMisWmemHistory(ByVal wmNo As String, ByVal user_Id As String) As DataTable
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString")) ' OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim strSQL As String = ""
        strSQL = " SELECT * from webmember_history Where trans_type='0'"
        Dim myCommand As New SqlCommand(strSQL, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet.Tables(0)
    End Function

    Public Function UpdateInformixappm01(ByVal TableName As String, ByVal DataValues() As String)
        ' Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim i As Integer
        Dim SqlStr As String = "Update " & TableName & " set "


        myConnection.Open()
        ' Dim myCommand As New OdbcCommand(SqlStr, myConnection)
        Dim myCommand As New OracleCommand(SqlStr, myConnection)
        myCommand.ExecuteNonQuery()
        myConnection.Close()
    End Function
    Public Function InsertInformixam6465(ByVal TableName As String, ByVal DataValues() As String)
        ' Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim i As Integer
        Dim SqlStr As String = "Insert into HSIN." & TableName & " (am64_house_no,am64_is_comm,am64_receipt_paper,am64_receipt_email,"
        SqlStr &= "am64_bill_paper,am64_bill_email,am64_user_id,am64_upd_datetime,"
        SqlStr &= "am65_send_no,am65_set_date,am64_set_paper,am65_set_email,am65_succ_paper,am65_succ_email,"
        SqlStr &= "am65_fail_paper,am65_fail_email,am65_send_id,am65_send_datetime,am65_user_id,am65_upd_datetime) Values("
        For i = 0 To 19
            If i = 0 Or i = 9 Or i = 10 Or i = 11 Or i = 12 Or i = 13 Or i = 14 Or i = 15 Then
            Else
                SqlStr &= "'"
            End If
            SqlStr &= DataValues(i)
            If i = 0 Or i = 9 Or i = 10 Or i = 11 Or i = 12 Or i = 13 Or i = 14 Or i = 15 Then
            Else
                SqlStr &= "'"
            End If
            If i <> 19 Then
                SqlStr &= ","
            End If
        Next
        SqlStr &= ")"
        myConnection.Open()
        'Dim myCommand As New OdbcCommand(SqlStr, myConnection)
        Dim myCommand As New OracleCommand(SqlStr, myConnection)
        myCommand.ExecuteNonQuery()
        myConnection.Close()
    End Function



    Public Function Search(Optional ByVal RbNo As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *,  CONVERT(character, rb_start_datetime, 120) AS StartDate, "
        strSQL = strSQL & "case rb_end_datetime when '1900/1/1' then '  ' else CONVERT(character, rb_end_datetime, 120) end AS EndDate , "
        strSQL = strSQL & " CASE rb_status WHEN '1' THEN '產生檔案中' WHEN '2' THEN '發送mail中' WHEN '3' THEN '執行完成' END rbstatus from Receipt_batch "

        If RbNo <> "" Then
            strSQL &= " Where rb_no='" & RbNo & "'"

        End If
        strSQL &= " Order by rb_no DESC"
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function ReadEReceiptData(ByVal Str As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(Str)
        conn.close()
        Return dt
    End Function

    Public Function Insert(ByVal Str) As Integer
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(Str)
        conn.close()
        Return 0
    End Function

    Public Overridable Function InsertSearchDataLog(ByVal DataValue() As String, ByVal Rul_no As Integer) As Integer
        Dim result As Integer = 0
        Dim SqlStr As String
        Dim conn As New DBConn2
        Dim today As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
        SqlStr = " Insert into Receipt_user_log(rul_wm_no,rul_house_no,rul_data_ym,rul_action,rul_status,rul_email,add_user,add_datetime,upd_rul_no)"
        SqlStr = SqlStr & " Values(" & DataValue(0) & ",'" & DataValue(1) & "','" & DataValue(2) & "','" & DataValue(3) & "','" & DataValue(4) & "','" & DataValue(5) & "','" & DataValue(6) & "','" & today & "'," & Rul_no & " )"

        'SqlStr = " Insert into Receipt_user_log(rul_wm_no,rul_house_no,rul_data_ym,rul_action,rul_run_datetime,rul_status,add_user,add_datetime,upd_user,upd_datetime)"
        'SqlStr = SqlStr & " Values(" & DataValue(0) & ",'" & DataValue(1) & "','" & DataValue(2) & "','" & DataValue(3) & "','" & DataValue(4) & "','" & DataValue(5) & "','" & DataValue(6) & "','" & today & "','" & DataValue(7) & "','" & today & "' )"
        conn.ExecuteNonQuery(SqlStr)
        conn.close()
        Return 0
    End Function
    Public Function UpdateUserLog(ByVal rul_No As Integer, ByVal UName As String)
        Dim strSql As String = ""
        Dim conn As New DBConn2
        strSql = "Update Receipt_user_log Set rul_status='2',add_user='" & UName & "' Where rul_no=" & rul_No
        conn.ExecuteNonQuery(strSql)
        conn.close()
        Return 0
    End Function
#If 1 Then

#Region "Search_Receipt_Batch_Log_From_BatchNo  用批次序號及狀態欄讀取批次明細的資料"
    Public Function Search_Receipt_Batch_Log_From_BatchNo(ByVal BatchNo As String, ByVal Status As String)
        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim dt1 As New DataTable
        'strSQL = "Select rl_03 as HouseNo,rl_01 as ReceiptDate,rl_22 as Email from Receipt_batch_log Where rl_rb_no='" & BatchNo & "' and rl_status='" & Status & "'"
        strSQL = "Select a.rl_03 as HouseNo,a.rl_01 as ReceiptDate,rl_22 as Email,rl_04 as UserName,c.wm_email as SendEmail, rl_wmno as WmNo, a.rl_rb_no as RbNo,c.wm_id as WmId "
        strSQL = strSQL & "  from Receipt_batch_log a  left  join webmember c on a.rl_wmno=c.wm_no "
        strSQL = strSQL & " Where a.rl_rb_no='" & BatchNo & "' and a.rl_status='" & Status & "'"
        strSQL = strSQL & " order by a.rl_03"
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        Return dt
    End Function
#End Region

#Region "Search_Receipt_Batch_From_BatchNo  用批次序號讀取批次主檔的資料"
    Public Function Search_Receipt_Batch_From_BatchNo(ByVal BatchNo As String)
        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim dt1 As New DataTable
        strSQL = "Select * from Receipt_batch Where rb_no='" & BatchNo & "'"

        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        Return dt
    End Function
#End Region

#If 1 Then
#Region "Search_Receipt_batch  用啟始及結止時間讀取批次主檔的資料"
    Public Function Search_Receipt_batch(ByVal StartDate As String, ByVal EndDate As String, ByVal HouseNo As String, ByVal ReceiptDate As String)
        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim dt1 As New DataTable
        Dim Flag As Integer = 0
        strSQL = "Select distinct Receipt_batch.*,CASE rb_status WHEN '1' THEN '產生檔案中'  WHEN '2' THEN '發送mail中'  WHEN '3' THEN '執行完成' END RStatus, "
        strSQL &= " case rb_end_datetime when '1900/1/1' then '  ' else CONVERT(character, rb_end_datetime, 120) end AS EndDate "
        strSQL &= " from Receipt_batch inner join receipt_batch_log on rb_no=rl_rb_no "
        strSQL &= " Where 1 = 1"
        strSQL &= " And (CONVERT(char(10), rb_start_datetime, 111) between '" & StartDate & "' And '" & EndDate & "' "
        strSQL &= " or CONVERT(char(10), rb_end_datetime, 111) between '" & StartDate & "' And '" & EndDate & "' )"
        If HouseNo <> "" Then
            strSQL &= " And rl_03='" & Right("0000000" & Trim(HouseNo), 7) & "' "
        End If
        If ReceiptDate <> "" Then
            strSQL &= " And rl_01='" & ReceiptDate & "' "
        End If

        strSQL &= " order by rb_no DESC "

        'If StartDate <> "" Or EndDate <> "" Then
        '    If StartDate = "" Then
        '        StartDate = "1911-01-01 00:00:00"
        '    Else
        '        StartDate = Left(StartDate, 3) + 1911 & "-" & Mid(StartDate, 4, 2) & "-" & Right(StartDate, 2) & " 00:00:00"
        '    End If
        '    If EndDate = "" Then
        '        EndDate = "2199-12-31 23:59:59"
        '    Else
        '        EndDate = Left(EndDate, 3) + 1911 & "-" & Mid(EndDate, 4, 2) & "-" & Right(EndDate, 2) & " 23:59:59"
        '    End If
        '    strSQL &= " rb_start_datetime >='" & StartDate & "' And rb_end_datetime <='" & EndDate & "' "
        '    Flag = 1
        'End If
        'If HouseNo <> "" Then
        '    If Flag = 1 Then
        '        strSQL = strSQL & " And "
        '    End If
        '    strSQL &= " rl_03='" & HouseNo & "' "
        '    Flag = 1
        'End If
        'If ReceiptDate <> "" Then
        '    If Flag = 1 Then
        '        strSQL = strSQL & " And "
        '    End If
        '    strSQL &= " rl_01='" & ReceiptDate & "' "
        'End If
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        Return dt
    End Function
#End Region
#Else
#Region "Search_Receipt_batch  用啟始及結止時間讀取批次主檔的資料"
    Public Function Search_Receipt_batch(ByVal StartDate As String, ByVal EndDate As String, ByVal HouseNo As String, ByVal ReceiptDate As String)
        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim dt1 As New DataTable
        Dim Flag As Integer = 0
        strSQL = "Select * from Receipt_batch "

        If StartDate <> "" Or EndDate <> "" Then
            If StartDate = "" Then
                StartDate = "1911-01-01 00:00:00"
            Else
                StartDate = Left(StartDate, 3) + 1911 & "-" & Mid(StartDate, 4, 2) & "-" & Right(StartDate, 2) & " 00:00:00"
            End If
            If EndDate = "" Then
                EndDate = "2199-12-31 23:59:59"
            Else
                EndDate = Left(EndDate, 3) + 1911 & "-" & Mid(EndDate, 4, 2) & "-" & Right(EndDate, 2) & " 23:59:59"
            End If
            strSQL &= " where rb_start_datetime >='" & StartDate & "' And rb_end_datetime <='" & EndDate & "' "
        End If



        If HouseNo <> "" Then
            If Flag = 1 Then
                strSQL = strSQL & " And "
            End If
            Flag = 1
        End If
        If ReceiptDate <> "" Then
            If Flag = 1 Then
                strSQL = strSQL & " And "
            End If

        End If
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        Return dt
    End Function
#End Region
#End If



    Public Function Search_UserLog(ByVal StartDate As String, ByVal EndDate As String, ByVal KeyWord As String, ByVal KeyWordInt As String, ByVal ActionInt As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim dt1 As New DataTable
        Dim i As Integer
        strSQL = "SELECT d.ActionDate AS ActionDate, d.UName as UName, d.rul_house_no AS rul_house_no, "
        strSQL = strSQL & "d.[Action] AS [Action], d.rul_data_ym AS rul_data_ym, d.wm_id AS wm_id, "
        strSQL = strSQL & "d.rul_email AS rul_email, d.wm_mobile AS wm_mobile, d.wm_no AS wm_no, "
        strSQL = strSQL & "d.Action1 AS Action1, MAX(Receipt_batch_log.rl_04) AS wm_user_name,d.rul_action,d.rul_no FROM "

        strSQL = strSQL & "(SELECT CONVERT(character, a.add_datetime, 120) AS ActionDate, "
        strSQL = strSQL & "a.rul_house_no,"
        strSQL = strSQL & "c.wm_user_name as UName,"
        strSQL = strSQL & "CASE a.rul_action WHEN '1' THEN '下載' WHEN '2' THEN '補寄電子檔' WHEN '3' THEN '補寄紙本' END Action, "
        strSQL = strSQL & " a.rul_data_ym, "
        strSQL = strSQL & "c.wm_id, "
        strSQL = strSQL & "c.wm_email, "
        strSQL = strSQL & "c.wm_mobile ,"
        strSQL = strSQL & "c.wm_no ,"
        strSQL = strSQL & "CASE a.rul_action WHEN '3' THEN CASE a.rul_Status WHEN '1' THEN '補寄紙本' WHEN '2' THEN '紙本已印' END  END Action1, "
        strSQL = strSQL & "a.rul_action,a.rul_no,a.rul_email "
        strSQL = strSQL & " FROM Receipt_user_log a INNER JOIN member_house b ON a.rul_house_no = b.mh_house_no INNER JOIN"
        strSQL = strSQL & " webmember c ON b.mh_wm_no = c.wm_no ) d INNER JOIN "
        strSQL = strSQL & " Receipt_batch_log ON d.rul_house_no = Receipt_batch_log.rl_03 "

        strSQL = strSQL & " GROUP BY  Receipt_batch_log.rl_03, d.rul_house_no, d.ActionDate, UName, "
        strSQL = strSQL & " d.[Action], d.rul_data_ym, d.wm_id, d.rul_email, d.wm_mobile, d.wm_no,d.Action1,d.rul_action,d.rul_no "

        'strSQL = "SELECT CONVERT(character, a.rul_run_datetime, 120) AS ActionDate, a.rul_house_no,d.rl_04 as wm_user_name,CASE a.rul_action WHEN '1' THEN '下載' WHEN '2' THEN '補寄電子檔' WHEN '3' THEN '補寄紙本' END Action, "
        'strSQL = strSQL & " d.rl_01 as rul_data_ym, c.wm_id, c.wm_email, c.wm_mobile ,CASE a.rul_action WHEN '3' THEN '補寄紙本'  END Action1 "
        'strSQL = strSQL & " FROM Receipt_user_log a INNER JOIN member_house b ON a.rul_house_no = b.mh_house_no INNER JOIN"
        'strSQL = strSQL & " webmember c ON b.mh_wm_no = c.wm_no "
        'strSQL = strSQL & " join Receipt_batch_log d on d.rl_03=a.rul_house_no "

        'modify 1061026 
        If StartDate = "" Then
            StartDate = "1911-01-01 00:00:00"
        Else
            StartDate = Left(StartDate, 3) + 1911 & "-" & Mid(StartDate, 4, 2) & "-" & Right(StartDate, 2) & " 00:00:00"
        End If
        If EndDate = "" Then
            EndDate = "2199-12-31 23:59:59"
        Else
            EndDate = Left(EndDate, 3) + 1911 & "-" & Mid(EndDate, 4, 2) & "-" & Right(EndDate, 2) & " 23:59:59"
        End If

        If Trim(KeyWord) <> "" Or ActionInt <> "0" Or StartDate <> "" Or EndDate <> "" Then
            strSQL = strSQL & " having "
        End If
        'If StartDate <> "" Or EndDate <> "" Then
        '    If StartDate = "" Then
        '        StartDate = "1911-01-01 00:00:00"
        '    Else
        '        StartDate = Left(StartDate, 3) + 1911 & "-" & Mid(StartDate, 4, 2) & "-" & Right(StartDate, 2) & " 00:00:00"
        '    End If
        '    If EndDate = "" Then
        '        EndDate = " 2199-12-31 23:59:59"
        '    Else
        '        EndDate = Left(EndDate, 3) + 1911 & "-" & Mid(EndDate, 4, 2) & "-" & Right(EndDate, 2) & " 23:59:59"
        '    End If
        '    strSQL &= " ActionDate >='" & StartDate & "' And ActionDate <='" & EndDate & "' "
        'End If


       
        ' 1081216 取消  註解 If StartDate <> "" Or EndDate <> "" Then
        If StartDate <> "" Or EndDate <> "" Then
            strSQL &= " ActionDate >='" & StartDate & "' And ActionDate <='" & EndDate & "' "
        End If
        '1081216 


        If ActionInt <> "0" Then
            If StartDate <> "" Or EndDate <> "" Then
                strSQL &= " And "
            End If
            strSQL &= " rul_action='" & ActionInt & "' "
        End If
        If Trim(KeyWord) <> "" Then
            If ActionInt <> "0" Or StartDate <> "" Or EndDate <> "" Then
                strSQL &= " And "
            End If
            Select Case Val(KeyWordInt)
                Case 0                  '身份證號碼(統一編號)
                    strSQL &= " wm_id='" & KeyWord & "' "
                Case 1                  '電子信箱
                    strSQL &= " rul_email='" & KeyWord & "' "
                Case 2                  '申請人姓名(承辦人姓名)
                    'strSQL &= " wm_user_name='" & KeyWord & "' "
                    strSQL &= " Max(Receipt_batch_log.rl_04)='" & KeyWord & "' "

                Case 3                  '行動電話
                    strSQL &= " wm_mobile='" & KeyWord & "' "
                Case 4                  '用戶號碼
                    strSQL &= " rul_house_no='" & Right("0000000" & Trim(KeyWord), 7) & "' "
                    'strSQL &= " wm_no='" & Right("0000000" & Trim(KeyWord), 7) & "' "
            End Select
        End If
        strSQL &= " Order by ActionDate DESC "

        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
#If 0 Then
        For i = 0 To dt.Rows.Count - 1
            dt1 = ReadEReceiptData("Select Top 1 rl_04,rl_01,rl_19 from Receipt_batch_log where rl_03='" & dt.Rows(i)(1) & "'")
            If dt1.Rows.Count > 0 Then
                dt.Rows(i)(2) = dt1.Rows(0)(0)
                dt.Rows(i)(4) = dt1.Rows(0)(1)
                dt.Rows(i)(5) = dt1.Rows(0)(2)
            End If
        Next
#End If
        Return dt
    End Function
#Else


    Public Function Search_UserLog(ByVal StartDate As String, ByVal EndDate As String, ByVal KeyWord As String, ByVal KeyWordInt As String, ByVal ActionInt As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim dt1 As New DataTable
        Dim i As Integer
        strSQL = "SELECT CONVERT(character, a.add_datetime, 120) AS ActionDate, "
        strSQL = strSQL & "a.rul_house_no,"
        strSQL = strSQL & "c.wm_user_name,"
        strSQL = strSQL & "CASE a.rul_action WHEN '1' THEN '下載' WHEN '2' THEN '補寄電子檔' WHEN '3' THEN '補寄紙本' END Action, "
        strSQL = strSQL & " a.rul_data_ym, "
        strSQL = strSQL & "c.wm_id, "
        strSQL = strSQL & "c.wm_email, "
        strSQL = strSQL & "c.wm_mobile ,"
        strSQL = strSQL & "c.wm_no ,"
        strSQL = strSQL & "CASE a.rul_action WHEN '3' THEN '補寄紙本'  END Action1 "

        strSQL = strSQL & " FROM Receipt_user_log a INNER JOIN member_house b ON a.rul_house_no = b.mh_house_no INNER JOIN"
        strSQL = strSQL & " webmember c ON b.mh_wm_no = c.wm_no "

        'strSQL = "SELECT CONVERT(character, a.rul_run_datetime, 120) AS ActionDate, a.rul_house_no,d.rl_04 as wm_user_name,CASE a.rul_action WHEN '1' THEN '下載' WHEN '2' THEN '補寄電子檔' WHEN '3' THEN '補寄紙本' END Action, "
        'strSQL = strSQL & " d.rl_01 as rul_data_ym, c.wm_id, c.wm_email, c.wm_mobile ,CASE a.rul_action WHEN '3' THEN '補寄紙本'  END Action1 "
        'strSQL = strSQL & " FROM Receipt_user_log a INNER JOIN member_house b ON a.rul_house_no = b.mh_house_no INNER JOIN"
        'strSQL = strSQL & " webmember c ON b.mh_wm_no = c.wm_no "
        'strSQL = strSQL & " join Receipt_batch_log d on d.rl_03=a.rul_house_no "
        If Trim(KeyWord) <> "" Or ActionInt <> "0" Or StartDate <> "" Or EndDate <> "" Then
            strSQL = strSQL & " Where "
        End If
        If StartDate <> "" Or EndDate <> "" Then
            If StartDate = "" Then
                StartDate = "1911-01-01 00:00:00"
            Else
                StartDate = Left(StartDate, 3)+1911 & "-" & Mid(StartDate, 4, 2) & "-" & Right(StartDate, 2) & " 00:00:00"
            End If
            If EndDate = "" Then
                EndDate = "2199-12-31 23:59:59"
            Else
                EndDate = Left(EndDate, 3)+1911 & "-" & Mid(EndDate, 4, 2) & "-" & Right(EndDate, 2) & " 23:59:59"
            End If
            strSQL &= " a.add_datetime >='" & StartDate & "' And a.add_datetime <='" & EndDate & "' "
        End If
        If ActionInt <> "0" Then
            If StartDate <> "" Or EndDate <> "" Then
                strSQL &= " And "
            End If
            strSQL &= " a.rul_action='" & ActionInt & "' "
        End If
        If Trim(KeyWord) <> "" Then
            If ActionInt <> "0" Or StartDate <> "" Or EndDate <> "" Then
                strSQL &= " And "
            End If
            Select Case Val(KeyWordInt)
                Case 0                  '身份證號碼(統一編號)
                    strSQL &= " c.wm_id='" & KeyWord & "' "
                Case 1                  '電子信箱
                    strSQL &= " c.wm_email='" & KeyWord & "' "
                Case 2                  '申請人姓名(承辦人姓名)
                    strSQL &= " c.wm_user_name='" & KeyWord & "' "
                Case 3                  '行動電話
                    strSQL &= " c.wm_mobile='" & KeyWord & "' "
                Case 4                  '用戶號碼
                    strSQL &= " a.rul_house_no='" & KeyWord & "' "
            End Select
        End If
        strSQL &= " Order by ActionDate "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        For i = 0 To dt.Rows.Count - 1
            dt1 = ReadEReceiptData("Select Top 1 rl_04,rl_01,rl_19 from Receipt_batch_log where rl_03='" & dt.Rows(i)(1) & "'")
            If dt1.Rows.Count > 0 Then
                dt.Rows(i)(2) = dt1.Rows(0)(0)
                dt.Rows(i)(4) = dt1.Rows(0)(1)
                dt.Rows(i)(5) = dt1.Rows(0)(2)
            End If
        Next
        Return dt
    End Function
#End If
End Class
