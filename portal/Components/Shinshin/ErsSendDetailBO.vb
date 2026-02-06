Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Odbc
Imports System.Data.OracleClient

Public Class ErsSendDetailBO
    '列出用戶歷史交易明細
    Public Function Query(ByVal swm_no As Integer, ByVal shouse_no As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL &= "select add_datetime, add_user, action = (case when rul_action = '1' then '下載' when rul_action ='2' then '補寄電子檔' when (rul_action = '3' and upd_rul_no = '0') then '補寄紙本(申請)' when (rul_action = '3' and upd_rul_no <> '0') then '補寄紙本(列印)' else '' end), rul_data_ym, rul_email"
        strSQL &= " from Receipt_user_log "
        strSQL &= " where 1 = 1 "
        strSQL &= " and rul_wm_no='" & swm_no & "' "
        strSQL &= " and rul_house_no='" & shouse_no & "' "
        strSQL &= " union all"
        strSQL &= " select b.rb_start_datetime, b.rb_run_user, action = (case when a.rl_status = '1' then '批次發送成功' when a.rl_status = '2' then '批次發送失敗' else '' end), a.rl_01, a.rl_22"
        strSQL &= " from Receipt_batch_log a left join Receipt_batch b on b.rb_no = a.rl_rb_no"
        strSQL &= " where 1 = 1 "
        strSQL &= " and a.rl_wmno='" & swm_no & "' "
        strSQL &= " and a.rl_03='" & shouse_no & "' "
        strSQL &= "Order by add_datetime DESC "
        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    '查詢用戶歷史交易明細
    Public Function UserQuery(ByVal sDateStart As String, ByVal sDateEnd As String, ByVal sdata_ym As String, ByVal saction As String, ByVal slikeSelect As String, ByVal slikeContent As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        If saction <> "0" Then
            strSQL &= "select DISTINCT B.wm_no, B.wm_id as user_id,B.wm_user_name as user_name,A.rul_house_no as house_no from Receipt_user_log A left join webmember B on A.rul_wm_no = B.wm_no  "
            strSQL &= " where 1 = 1 "
            If sDateStart <> "" And sDateEnd <> "" Then
                strSQL &= " and convert(char(10),A.add_datetime,111) between '" & sDateStart & "' and '" & sDateEnd & "'"
            End If
            If sdata_ym <> "" Then
                strSQL &= " and A.rul_data_ym = '" & sdata_ym & "'"
            End If
            If saction <> "9" Then
                strSQL &= " and A.rul_action = '" & saction & "'"
            End If
            If slikeSelect = "id" And slikeContent <> "" Then
                strSQL &= " and B.wm_id like '%" & slikeContent & "%'"
            End If
            If slikeSelect = "email" And slikeContent <> "" Then
                strSQL &= " and B.wm_email like '%" & slikeContent & "%'"
            End If
            If slikeSelect = "user_name" And slikeContent <> "" Then
                strSQL &= " and B.wm_user_name like '%" & slikeContent & "%'"
            End If
            If slikeSelect = "mobile" And slikeContent <> "" Then
                strSQL &= " and B.wm_mobile like '%" & slikeContent & "%'"
            End If
            If slikeSelect = "house_no" And slikeContent <> "" Then
                strSQL &= " and A.rul_house_no like '%" & slikeContent & "%'"
            End If
        End If
        If saction = "9" Then
            strSQL &= " union "
        End If
        If saction = "9" Or saction = "0" Then
            strSQL &= " select DISTINCT B.wm_no, B.wm_id as user_id,B.wm_user_name as user_name,A.rl_03 as house_no from Receipt_batch_log A left join webmember B on A.rl_wmno = B.wm_no"
            strSQL &= " where 1 = 1"
            If sDateStart <> "" And sDateEnd <> "" Then
                strSQL &= " and convert(char(10),A.rl_runtime,111) between '" & sDateStart & "' and '" & sDateEnd & "'"
            End If
            If sdata_ym <> "" Then
                strSQL &= " and A.rl_01 = '" & sdata_ym & "'"
            End If
            If slikeSelect = "id" And slikeContent <> "" Then
                strSQL &= " and B.wm_id like '%" & slikeContent & "%'"
            End If
            If slikeSelect = "email" And slikeContent <> "" Then
                strSQL &= " and B.wm_email like '%" & slikeContent & "%'"
            End If
            If slikeSelect = "user_name" And slikeContent <> "" Then
                strSQL &= " and B.wm_user_name like '%" & slikeContent & "%'"
            End If
            If slikeSelect = "mobile" And slikeContent <> "" Then
                strSQL &= " and B.wm_mobile like '%" & slikeContent & "%'"
            End If
            If slikeSelect = "house_no" And slikeContent <> "" Then
                strSQL &= " and A.rl_03 like '%" & slikeContent & "%'"
            End If
        End If
        strSQL &= " Order by user_id"

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    ''查詢用戶名稱
    'Public Function QueryHouseName(ByVal shouse_no As String) As DataSet
    '    Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
    '    Dim strSQL As String

    '    strSQL &= "select am01_name "
    '    strSQL &= " from APPM01 "
    '    strSQL &= " where 1 = 1 "
    '    strSQL &= " and am01_house_no='" & shouse_no & "' "

    '    Dim myCommand As New OdbcCommand(strSQL, myConnection)
    '    Dim myAdapter As New OdbcDataAdapter(myCommand)
    '    Dim myDataSet As New DataSet
    '    myAdapter.Fill(myDataSet)
    '    Return myDataSet

    'End Function

    '查詢用戶名稱
    '1130206 modify 
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




End Class
