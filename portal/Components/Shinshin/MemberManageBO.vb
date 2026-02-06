Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Odbc

Public Class MemberManageBO
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
    Public Function UserQuery(ByVal sDateStart As String, ByVal sDateEnd As String, ByVal slikeSelect As String, ByVal slikeContent As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        strSQL &= "select wm_no,wm_user_o_name,wm_org_flag,wm_org_flag_name=(case when wm_org_flag = '1' then '個人' when wm_org_flag = '2' then '公司' when wm_org_flag = '3' then '機關' else '' end),wm_id,wm_user_name,wm_mobile,wm_tel_o = (case when wm_tel_o2 <> '' then wm_tel_o + ' #' + wm_tel_o2 else wm_tel_o end),wm_tel_h,wm_email, CONVERT(char(10), add_datetime, 111) as add_datetime"
        strSQL &= " from webmember "
        strSQL &= " where wm_open_flag = '2' "
        If sDateStart <> "" And sDateEnd <> "" Then
            strSQL &= " and convert(char(10),add_datetime,111) between '" & sDateStart & "' and '" & sDateEnd & "'"
        End If
        If slikeSelect = "id" And slikeContent <> "" Then
            strSQL &= " and wm_id like '%" & slikeContent & "%'"
        End If
        If slikeSelect = "email" And slikeContent <> "" Then
            strSQL &= " and wm_email like '%" & slikeContent & "%'"
        End If
        If slikeSelect = "user_name" And slikeContent <> "" Then
            strSQL &= " and wm_user_name like '%" & slikeContent & "%'"
        End If
        If slikeSelect = "mobile" And slikeContent <> "" Then
            strSQL &= " and wm_mobile like '%" & slikeContent & "%'"
        End If
        If slikeSelect = "house_no" And slikeContent <> "" Then
            strSQL &= " and wm_house_list like '%," & Right("0000000" & slikeContent, 7) & ",%'"
        End If
        If slikeSelect = "wm_no" And slikeContent <> "" Then
            strSQL &= " and wm_no = '" & slikeContent & "'"
        End If
        strSQL &= " Order by add_datetime desc"

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    '查詢用戶名稱
    Public Function QueryHouseName(ByVal shouse_no As String) As DataSet
        Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim strSQL As String

        strSQL &= "select am01_name "
        strSQL &= " from APPM01 "
        strSQL &= " where 1 = 1 "
        strSQL &= " and am01_house_no='" & shouse_no & "' "

        Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet

    End Function




End Class
