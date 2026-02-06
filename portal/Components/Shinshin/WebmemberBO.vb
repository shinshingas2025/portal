Imports System.Data.SqlClient
Public Class WebmemberBO
    Public Function QueryMemDate1(ByVal sendSDATE As String, ByVal sendEDATE As String, ByVal likeSel As String, ByVal likeContent As String, ByVal likeFlag As String) As DataTable
        Dim strSQL As String = ""
        Dim strtype As String = " "
        Dim strlike As String = " "
        Dim dt As DataTable

        '過濾勾選的身份別 CheckBox6 個人用戶 CheckBox7 營業用戶 CheckBox8 機關用戶
        strtype &= " and wm_org_flag IN ('1','2','3') "

        '過濾狀態   CheckBox3尚未啟動  CheckBox4授權碼發送失敗  CheckBox5停權
        If (likeFlag = "0") Then
            strtype &= " and wm_open_flag IN ('1','2','3','4') "
        Else
            strtype &= " and wm_open_flag IN ('A'"
            If (likeFlag = "1") Or (likeFlag = "2") Then
                strtype &= ",'2'"
            End If
            If (likeFlag = "3") Then
                strtype &= ",'1'"
            End If
            If (likeFlag = "4") Then
                strtype &= ",'4'"       '授權碼發送失敗
            End If
            If (likeFlag = "5") Then
                strtype &= ",'3'"
            End If
            strtype &= ") "
        End If

        If (likeContent <> "") Then
            strlike &= "and " & likeSel & " like '%" + likeContent + "%' "
        End If
        'Dim Content() As String

        'Content = likeContent.Split("'")

        'If (likeContent <> "") Then
        '    strlike &= "and " & likeSel & " like '%" + Content(0) + "%' "
        'End If

        'If (likeFlag = "1") Then    '已啟動、已設定用戶號碼資料
        '    strSQL &= "SELECT *"
        '    strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、已設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
        '    strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        '    strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
        '    strSQL &= " FROM webmember WHERE wm_no IN "
        '    strSQL &= " (SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
        '    strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
        '    strSQL &= strlike
        '    strSQL &= " and  wm_open_flag ='2' "
        '    strSQL &= strtype

        'ElseIf (likeFlag = "2") Then
        '    strSQL &= "SELECT *"
        '    strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG, "
        '    strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        '    strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
        '    strSQL &= " FROM webmember WHERE wm_no NOT IN"
        '    strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
        '    strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
        '    strSQL &= strlike
        '    strSQL &= " and  wm_open_flag ='2' "
        '    strSQL &= strtype

        'ElseIf (likeFlag = "0") Then
        '    strSQL &= "SELECT *"
        '    strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、已設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
        '    strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        '    strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
        '    strSQL &= " FROM webmember WHERE wm_no IN "
        '    strSQL &= " (SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
        '    strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
        '    strSQL &= strlike
        '    strSQL &= strtype
        '    strSQL &= "  UNION  "
        '    strSQL &= "SELECT *"
        '    strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
        '    strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        '    strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
        '    strSQL &= " FROM webmember WHERE wm_no NOT IN"
        '    strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
        '    strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
        '    strSQL &= strlike
        '    strSQL &= strtype

        'Else
        '    strSQL &= "SELECT *"
        '    strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
        '    strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        '    strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG "
        '    strSQL &= " FROM webmember WHERE wm_no NOT IN"
        '    strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
        '    strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
        '    strSQL &= strlike
        '    strSQL &= strtype

        'End If

        If (likeFlag = "1") Then    '已啟動、已設定用戶號碼資料
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、已設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
            strSQL &= " FROM webmember WHERE wm_no IN "
            strSQL &= " (SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= strtype
            strSQL &= "  UNION  "
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG, "
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
            strSQL &= " FROM webmember WHERE wm_no NOT IN"
            strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= " and  wm_open_flag <>'2' "
            strSQL &= strtype
            'ElseIf (likeFlag = "2") Then
            '    strSQL &= "SELECT *"
            '    strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG, "
            '    strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            '    strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
            '    strSQL &= " FROM webmember WHERE wm_no NOT IN"
            '    strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
            '    strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            '    strSQL &= strlike
            '    strSQL &= " and  wm_open_flag ='2' "
            '    strSQL &= strtype
        ElseIf (likeFlag = "0") Then    '全部
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、已設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
            strSQL &= " FROM webmember WHERE wm_no IN "
            strSQL &= " (SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= strtype
            strSQL &= "  UNION  "
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
            strSQL &= " FROM webmember WHERE wm_no NOT IN"
            strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= strtype
        Else
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG "
            strSQL &= " FROM webmember WHERE wm_no NOT IN"
            strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= strtype
        End If

        If strSQL <> "" Then
            strSQL &= " Order by add_datetime desc "
        End If

        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryMemDate(ByVal sendSDATE As String, ByVal sendEDATE As String, ByVal chkCheckBox1 As String, ByVal chkCheckBox2 As String, ByVal chkCheckBox3 As String, ByVal chkCheckBox4 As String, ByVal chkCheckBox5 As String, ByVal chkCheckBox6 As String, ByVal chkCheckBox7 As String, ByVal chkCheckBox8 As String, ByVal likeSel As String, ByVal likeContent As String) As DataTable
        Dim strSQL As String = ""
        Dim strtype As String = " "
        Dim strlike As String = " "
        Dim dt As DataTable

        '過濾勾選的身份別 CheckBox6 個人用戶 CheckBox7 營業用戶 CheckBox8 機關用戶
        If ((chkCheckBox6 = "N") And (chkCheckBox7 = "N") And (chkCheckBox8 = "N")) Then
            strtype &= " and wm_org_flag NOT IN ('1','2','3') "
        Else
            strtype &= " and wm_org_flag IN ('A'"
            If (chkCheckBox6 = "Y") Then
                strtype &= ",'1'"
            End If
            If (chkCheckBox7 = "Y") Then
                strtype &= ", '2'"
            End If
            If (chkCheckBox8 = "Y") Then
                strtype &= ",'3'"
            End If
            strtype &= ") "
        End If
        '過濾狀態   CheckBox3尚未啟動  CheckBox4授權碼發送失敗  CheckBox5停權
        If ((chkCheckBox1 = "N") And (chkCheckBox2 = "N") And (chkCheckBox3 = "N") And (chkCheckBox4 = "N") And (chkCheckBox5 = "N")) Then
            strtype &= " and wm_open_flag NOT IN ('1','2','3','4') "
        Else
            strtype &= " and wm_open_flag IN ('A'"
            If (chkCheckBox1 = "Y") Or (chkCheckBox2 = "Y") Then
                strtype &= ",'2'"
            End If
            If (chkCheckBox3 = "Y") Then
                strtype &= ",'1'"
            End If
            If (chkCheckBox4 = "Y") Then
                strtype &= ",'4'"       '授權碼發送失敗
            End If
            If (chkCheckBox5 = "Y") Then
                strtype &= ",'3'"
            End If
            strtype &= ") "
        End If
        'Dim Content() As String

        'Content = likeContent.Split("'")

        'If (likeContent <> "") Then
        '    strlike &= "and " & likeSel & " like '%" + Content(0) + "%' "
        'End If

        If (likeContent <> "") Then
            strlike &= "and " & likeSel & " like '%" + likeContent + "%' "
        End If

        If (chkCheckBox1 = "Y") Then    '已啟動、已設定用戶號碼資料
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、已設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
            strSQL &= " FROM webmember WHERE wm_no IN "
            strSQL &= " (SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= strtype
            If (chkCheckBox2 = "Y") Then
                strSQL &= "  UNION  "
                strSQL &= "SELECT *"
                strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
                strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
                strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
                strSQL &= " FROM webmember WHERE wm_no NOT IN"
                strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
                strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
                strSQL &= strlike
                strSQL &= strtype
            Else
                strSQL &= "  UNION  "
                strSQL &= "SELECT *"
                strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG, "
                strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
                strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
                strSQL &= " FROM webmember WHERE wm_no NOT IN"
                strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
                strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
                strSQL &= strlike
                strSQL &= " and  wm_open_flag <>'2' "
                strSQL &= strtype
            End If
        Else
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG "
            strSQL &= " FROM webmember WHERE wm_no NOT IN"
            strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= strtype
        End If

        If strSQL <> "" Then
            strSQL &= " Order by add_datetime desc "
        End If

        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function mail(ByVal email As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        strSQL &= "SELECT *"
        strSQL &= " FROM webmember "

        strSQL &= "where wm_email ='" & email & "'"

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function house_Query(ByVal NO As Integer) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        strSQL &= " SELECT *,mh_house_no "
        strSQL &= " FROM webmember a left join member_house b on a.wm_no = b.mh_wm_no "

        strSQL &= "where a.wm_no =" & NO & " "

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function house_Query1(ByVal NO As Integer) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        strSQL &= " SELECT *,CASE wm_open_flag WHEN '2' THEN '已啟動'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG,  "
        strSQL &= " CASE update_type WHEN '1' THEN '會員註冊' WHEN '2' THEN '會員資料修改' WHEN '3' THEN '會員狀態改變' WHEN '4' THEN '新增用戶號碼' WHEN '5' THEN '刪除用戶號碼' END UPDTYPE "
        strSQL &= " FROM webmember_history "

        strSQL &= "where wm_no =" & NO & " "
        strSQL &= "Order by add_datetime DESC,wm_no DESC,wm_house_no DESC "

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function house_Query2(ByVal NO As Integer) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        strSQL &= " SELECT Distinct b.wm_no,b.wm_open_flag,b.add_user,b.wm_user_name,b.wm_mobile,b.add_datetime, "
        strSQL &= " CASE WHEN (b.wm_tel_o2 <> '' and b.wm_tel_o2 <> '-') THEN b.wm_tel_o+' # '+ b.wm_tel_o2 Else b.wm_tel_o END wm_tel_oo,b.wm_tel_h, "
        strSQL &= " b.wm_email,b.mhis_memo,CASE b.wm_open_flag WHEN '2' THEN '已啟動'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG,  "
        strSQL &= " CASE b.update_type WHEN '1' THEN '會員註冊' WHEN '2' THEN '會員資料修改' WHEN '3' THEN '會員狀態改變' WHEN '4' THEN '新增用戶號碼' WHEN '5' THEN '刪除用戶號碼' WHEN '6' THEN '重寄授權碼' WHEN '7' THEN '尚未設定用戶號碼通知' END UPDTYPE "
        strSQL &= " FROM webmember a left outer join webmember_history b on a.wm_no = b.wm_no "
        strSQL &= " WHERE b.wm_no =" & NO
        strSQL &= "   and (b.update_type <> '4') and (b.update_type <> '5') and (b.update_type < '8') "
        strSQL &= " Order by b.add_datetime DESC,b.wm_no DESC "

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Query2(ByVal ID As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        strSQL &= "SELECT *"
        strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
        strSQL &= " wm_tel_o = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
        strSQL &= " FROM webmember WHERE wm_no NOT IN"
        strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
        If ID <> "" Then
            strSQL &= " and wm_open_flag in ('1','4') and wm_no in (" & ID & ")"
        End If

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    '一般查詢(沒比對登入者帳號)
    Public Function Query(Optional ByVal ID As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        'strSQL = "Select *,convert(char(10),createdate,111) as cntdate from contact where 1=1 "
        'strSQL = "Select *,isnull(workdate,'') workdate1 from contact where 1=1 "
        'strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN 0 THEN '未指派' WHEN 1 THEN '處理中' WHEN 2 THEN '已處理' WHEN 3 THEN '已辦結' END as status from contact where 1=1 "
        strSQL &= "SELECT *"
        strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、已設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
        strSQL &= " wm_tel_o = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG "
        strSQL &= ", CONVERT(char(10), add_datetime, 111) as add_datetime2 "
        strSQL &= ", CONVERT(char(10), upd_datetime, 111) as upd_datetime2 "
        strSQL &= " FROM webmember WHERE wm_no IN "
        strSQL &= " (SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
        If ID <> "" Then
            strSQL &= "and wm_no =" & ID & " "
        End If
        strSQL &= "  UNION  "
        strSQL &= "SELECT *"
        strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
        strSQL &= " wm_tel_o = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG "
        strSQL &= ", CONVERT(char(10), add_datetime, 111) as add_datetime2 "
        strSQL &= ", CONVERT(char(10), upd_datetime, 111) as upd_datetime2 "
        strSQL &= " FROM webmember WHERE wm_no NOT IN"
        strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
        If ID <> "" Then
            strSQL &= "and wm_no =" & ID & " "
        End If

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Query1(ByVal ID As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        strSQL &= "SELECT *"
        strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動'  WHEN '3' THEN '停權' WHEN '4' THEN '授權碼發送失敗' END OPENFLAG ,"
        strSQL &= " wm_tel_o = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
        strSQL &= ", CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG  "
        strSQL &= " FROM webmember WHERE wm_no NOT IN"
        strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
        If ID <> "" Then
            strSQL &= "and wm_no in (" & ID & ")"
        End If

        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    '依照不同的登入user查詢資料
    'userId         : user登入帳號
    'startDate      : 起始日期
    'endDate        : 結束日期 
    'status         : 處理狀態
    'num            : 判斷是"反映日期(num = 0)"或"處理日期(num = 1)"查詢用 
    'likeSel        : 全文檢索條件
    'likecontent    : 全文檢索內容
    'identity  : 判斷使用者身份(admin、user)
    Public Function UserQuery(ByVal userId As String, ByVal startDate As String, ByVal endDate As String, ByVal status As String, ByVal num As Integer, ByVal likeSel As String, ByVal likecontent As String, ByVal identity As String) As DataTable
        Dim strSQL As String = ""
        Dim strWhere As String = "where"
        Dim dt As DataTable
        'strSQL = "Select *,convert(char(10),createdate,111) as cntdate from contact where 1=1 "
        'strSQL = "Select *,isnull(workdate,'') workdate1 from contact where 1=1 "
        'strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN 0 THEN '未指派' WHEN 1 THEN '處理中' WHEN 2 THEN '已處理' WHEN 3 THEN '已辦結' END as status from contact where 1=1 and assignoperator = '" & userId & "'"
        '有過濾登入者
        'strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN 0 THEN '未指派' WHEN 1 THEN '處理中' WHEN 2 THEN '已處理' WHEN 3 THEN '已辦結' END as status from contact as A left join portal.dbo.vUserInfo as B on A.assignoperator = B.UID A.assignoperator ='" & userId & "'"
        '沒有過濾登入者
        strSQL = "Select *,isnull(workdate,'') workdate1 ,CASE workstatus WHEN '0' THEN '未指派' WHEN '1' THEN '處理中' WHEN '2' THEN '已處理' WHEN '3' THEN '已辦結' END as status from contact as A left join portal.dbo.vUserInfo as B on A.assignoperator = B.UID  "

        '判斷查詢日期條件
        If num = 0 Then
            strSQL &= strWhere & " createdate >='" & startDate & "' and createdate <='" & endDate & "'"
            strWhere = ""
        ElseIf num = 1 Then
            strSQL &= strWhere & " workdate >='" & startDate & "' and createdate <='" & endDate & "'"
            strWhere = ""
        End If
        '判斷處理狀態
        If status <> "9" Then  '9==>查全部狀態
            'strSQL &= " and workstatus ='" & status & "'"
            strSQL &= "and workstatus ='" & status & "'"
        End If
        '判斷登入者身分
        If strWhere.Trim <> "" Then
            If identity.Trim.Equals("user") Then
                strSQL &= strWhere & " A.assignoperator ='" & userId & "'"
            End If
        Else
            If identity.Trim.Equals("user") Then
                strSQL &= "and A.assignoperator ='" & userId & "'"
            End If
        End If

        '判斷全文檢索搜尋
        If likecontent.Trim <> "" Then
            likecontent = likecontent.Trim.Replace("'", "")
            likecontent = likecontent.Trim.Replace("-", "")
            strSQL &= "and " & likeSel & " like '%" & likecontent & "%' "
        End If

        strSQL &= "Order by createdate DESC "
        '建立連線物件
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert_history(ByVal Ne As Enhistory) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into Webmember_history (wm_no,wm_password,wm_user_name,wm_user_o_name,wm_tel_h,wm_tel_o,wm_tel_o2,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,add_user,add_datetime,update_type,wm_house_no,trans_type,mhis_memo) values ("
        strSQL &= "" & Ne.no & ""
        strSQL &= ",'" & Ne.password & "'"
        strSQL &= ",'" & Ne.username & "'"
        strSQL &= ",'" & Ne.useroname & "'"
        strSQL &= ",'" & Ne.telh & "'"
        strSQL &= ",'" & Ne.telo & "'"
        strSQL &= ",'" & Ne.telo2 & "'"
        strSQL &= ",'" & Ne.mobile & "'"
        strSQL &= ",'" & Ne.email & "'"
        strSQL &= ",'" & Ne.id & "'"
        strSQL &= ",'" & Ne.orgflag & "'"
        strSQL &= ",'" & Ne.paperflag & "'"
        strSQL &= ",'" & Ne.openflag & "'"
        strSQL &= ",'" & Ne.adduser & "'"
        strSQL &= ", '" & Ne.adddate1 & "'"
        strSQL &= ",'" & Ne.updatetype & "'"
        strSQL &= ",'" & Ne.houseno & "'"
        strSQL &= ",'" & Ne.transtype & "'"
        strSQL &= ",'" & Ne.mhismemo & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function


    Public Function webmember_history_house(ByVal Ne As Enhistory) As Integer
        Dim strSQL As String = ""
        strSQL = "insert into webmember_history_house select wm_no, wm_house_list, '" & Ne.adddate1 & "' from webmember where wm_no = " & Ne.no

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Insert(ByVal Ne As Encontact) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into contact (cntsubject,cntcontent,cnttel,cntemail) values ("
        strSQL &= "'" & Ne.cntsubject & "'"
        strSQL &= ",'" & Ne.cntcontent & "'"
        strSQL &= ",'" & Ne.cnttel & "'"
        strSQL &= ",'" & Ne.cntemail & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete_history(ByVal No As String) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "DELETE webmember_history "
        strSQL = strSQLHead
        strSQLWhere = " Where wm_no =" & No & ""
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete_member(ByVal No As String) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "DELETE member_house "
        strSQL = strSQLHead
        strSQLWhere = " Where mh_wm_no =" & No & ""
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enhistory) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE webmember "
        strSQLBody &= ",wm_house_list=''"
        If Ne.openflag <> "" Then
            strSQLBody &= ",wm_open_flag='" & Ne.openflag & "'"
        End If
        '1121117 add if openflog =3 , set mail=''
        If Ne.openflag = "3" Then
            strSQLBody &= ", wm_email =' ' "
        End If
        strSQLBody &= ",upd_datetime='" & Ne.adddate1 & "'"

        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where wm_no =" & Ne.no & ""
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update_member(ByVal Ne As Enhistory) As Integer
        Dim strSQL As String = ""
        Dim strSQLCHI As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE webmember "
        strSQLCHI = " UPDATE   member set  "
        '主旨
        'If Ne.cntsubject <> "" Then
        '    strSQLBody &= ",cntsubject='" & Ne.cntsubject & "'"
        'End If
        '內容
        'If Ne.cntcontent <> "" Then
        '    strSQLBody &= ",cntcontent='" & Ne.cntcontent & "'"
        'End If
        '電話
        'If Ne.cnttel <> "" Then
        '    strSQLBody &= ",cnttel='" & Ne.cnttel & "'"
        'End If
        'E-mail
        'If Ne.cntemail <> "" Then
        '    strSQLBody &= ",cntemail='" & Ne.cntemail & "'"
        'End If
        'If Ne.createdate <> "" Then
        '    strSQLBody &= ",createdate='" & Ne.createdate & "'"
        'End If        
        '公司名稱
        strSQLBody &= ",wm_user_o_name='" & Ne.useroname & "'"
        '用戶姓名
        strSQLBody &= ",wm_user_name='" & Ne.username & "'"
        strSQLCHI &= " Mbr_name ='" & Ne.username & "'"
        '聯絡電話(辦)
        strSQLBody &= ",wm_tel_o='" & Ne.telo & "'"
        '聯絡電話(分機)
        strSQLBody &= ",wm_tel_o2='" & Ne.telo2 & "'"
        '聯絡電話(家)
        strSQLBody &= ",wm_tel_h='" & Ne.telh & "'"
        '行動電話
        strSQLBody &= ",wm_mobile='" & Ne.mobile & "'"

        strSQLBody &= ",upd_user='" & Ne.adduser & "'"
        'If Ne.adddatetime.ToString.Trim <> "" Then
        '    strSQLBody &= ",upd_datetime=" & Ne.adddatetime & ""
        'End If
        strSQLBody &= ",upd_datetime='" & Ne.adddate1 & "'"


        '最後處理時間
        'If Ne.lastworkdate.ToString.Trim <> "" Then
        '    strSQLBody &= ",lastworkdate='" & Ne.lastworkdate & "'"
        'End If
        '電子信箱
        If Ne.email <> "" Then
            strSQLBody &= ",wm_email='" & Ne.email & "'"
            strSQLCHI &= ", mbr_email='" & Ne.email & "'"
        End If
        '是否令寄紙本繳費憑證
        If Ne.paperflag <> "" Then
            strSQLBody &= ",wm_paper_flag='" & Ne.paperflag & "'"
        End If
        '結案處理時間
        'If Ne.endworkdate.ToString.Trim <> "" Then
        '    strSQLBody &= ",endworkdate='" & Ne.endworkdate & "'"
        'End If 

        If Ne.openflag <> "" Then
            strSQLBody &= ",wm_open_flag='" & Ne.openflag & "'"
        End If


        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where wm_no =" & Ne.no & ""
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()


        '     strSQLCHI &= "  WHere mbr_account ='" & Ne.id & "'"

        strSQLCHI &= "  WHere  mbr_account ='" & Ne.id & "'"
        Dim conn3 As New DBConn3
        conn3.ExecuteNonQuery(strSQLCHI)
        conn3.close()

        Return 0
    End Function
    '取消指派
    Public Function SelectUpdateD(ByVal no As String) As Integer
        Dim strSQL As String = ""
        strSQL = " UPDATE contact set assignoperator = '',workstatus = '0' Where cntno in(" & no & ") "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
    '指派
    Public Function SelectUpdateU(ByVal no As String, ByVal name As String) As Integer
        Dim strSQL As String = ""
        strSQL = " UPDATE contact set assignoperator = '" & name & "',assigndate = getdate(),workstatus = '1' Where cntno in(" & no & ") "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function CloseCase(ByVal no As String, ByVal status As String, ByVal userID As String) As Integer
        Dim strSQL As String = ""
        Dim workstatus As String
        Dim endoperator As String
        Dim endworkdate As String

        If status.Equals("U") Then
            workstatus = "3"    '更改狀態為"已結案"
            endoperator = userID
            endworkdate = "'" & Format(Now(), "yyyy/MM/dd hh:mm:ss") & "'"
        ElseIf status.Equals("C") Then
            workstatus = "2"    '更改狀態為"已處理"
            endoperator = ""
            endworkdate = "null"
        End If

        strSQL = " UPDATE contact set endoperator = '" & endoperator & "',endworkdate = " & endworkdate & ",workstatus = '" & workstatus & "' Where cntno in(" & no & ") "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
    '判斷承辦人是否已經填寫回覆內容
    Public Function CheckCloseCase(ByVal no As String) As Boolean
        Dim strSQL As String = ""

        strSQL = " SELECT * FROM contact Where cntno = " + no + " and remark <> '' "
        Dim conn As New DBConn2
        Dim dataRead As SqlDataReader

        dataRead = conn.ExecuteReader(strSQL)


        If dataRead.HasRows() Then
            conn.close()
            Return True
        Else
            conn.close()
            Return False
        End If

    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE contact where cntno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE contact where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function
End Class
