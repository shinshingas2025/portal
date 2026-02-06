Imports System.Data.SqlClient
Imports System.Configuration
Public Class WebmemberDotDAO
    '*****20140929_Bacom**********************************************
    Public Function GetPDFCancelPWD(ByVal wm_id As String) As Boolean
        Dim SqlStr As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString1"))

        SqlStr = "select item from webmember_PDF_cancelPWD where wm_id=@wm_id"
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        myCommand.Parameters.Add("@wm_id", SqlDbType.VarChar, 10).Value = wm_id

        myConnection.Open()
        Dim dr As SqlDataReader
        dr = myCommand.ExecuteReader()
        If dr.HasRows Then
            GetPDFCancelPWD = True
        Else
            GetPDFCancelPWD = False
        End If
        dr.Close()
        myConnection.Close()

    End Function
    '*****************************************************************

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
        If (likeContent <> "") Then
            strlike &= "and " & likeSel & " like '%" + likeContent + "%' "
        End If


        If (chkCheckBox1 = "Y") Then    '已啟動、已設定用戶號碼資料
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、已設定用戶號碼'  WHEN '1' THEN '尚未啟動' WHEN '4' THEN '授權碼發送失敗'  WHEN '3' THEN '停權' END OPENFLAG ,"
            strSQL &= " CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG , "
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= " FROM webmember WHERE wm_no IN "
            strSQL &= " (SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  ) "
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= strtype

            If (chkCheckBox2 = "Y") Then
                strSQL &= "  UNION  "
                strSQL &= "SELECT *"
                strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動' WHEN '4' THEN '授權碼發送失敗'  WHEN '3' THEN '停權' END OPENFLAG ,"
                strSQL &= " CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG , "
                strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
                strSQL &= " FROM webmember WHERE wm_no NOT IN"
                strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
                strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
                strSQL &= strlike
                strSQL &= strtype
                strSQL &= " order by add_datetime desc"
            Else
                strSQL &= "  UNION  "
                strSQL &= "SELECT *"
                strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動' WHEN '4' THEN '授權碼發送失敗'  WHEN '3' THEN '停權' END OPENFLAG, "
                strSQL &= " CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG,  "
                strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
                strSQL &= " FROM webmember WHERE wm_no NOT IN"
                strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
                strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
                strSQL &= strlike
                strSQL &= " and  wm_open_flag <>'2' "
                strSQL &= strtype
                strSQL &= " order by add_datetime desc"
            End If
        Else
            strSQL &= "SELECT *"
            strSQL &= ",CASE wm_open_flag WHEN '2' THEN '已啟動、尚未設定用戶號碼'  WHEN '1' THEN '尚未啟動' WHEN '4' THEN '授權碼發送失敗'  WHEN '3' THEN '停權' END OPENFLAG ,"
            strSQL &= " CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG , "
            strSQL &= " wm_tel_oo = (CASE WHEN wm_tel_o2 <> '' THEN wm_tel_o+' # '+wm_tel_o2 Else wm_tel_o END)"
            strSQL &= " FROM webmember WHERE wm_no NOT IN"
            strSQL &= "(SELECT   mh_wm_no  FROM member_house where mh_wm_no =wm_no  )"
            strSQL &= " and  add_datetime Between '" & sendSDATE & "' and '" & sendEDATE & "'"
            strSQL &= strlike
            strSQL &= strtype
            strSQL &= " order by add_datetime desc"
        End If

        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function


    Public Function QueryMemTransDate() As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        'strSQL &= "SELECT *"
        'strSQL &= " ,CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG "
        'strSQL &= " ,CASE update_type WHEN '1' THEN '會員註冊'  WHEN '2' THEN '會員資料修改'  WHEN '3' THEN '狀態改變-停權' WHEN '4' THEN '新增用戶號碼' WHEN '5' THEN '刪除用戶號碼' WHEN '6' THEN '重寄授權碼' WHEN '7' THEN '尚未設定用戶號碼通知' END CHGFLAG "
        'strSQL &= " ,wm_tel_oo = (CASE WHEN (wm_tel_o2 <> '-'  and  wm_tel_o2 <> '')  THEN wm_tel_o+' # '+wm_tel_o2   Else wm_tel_o END) "
        'strSQL &= " FROM webmember_history WHERE trans_type = '0' and (update_type='2' or update_type='3'or update_type='4' or update_type='5') and wm_house_no <> '' order by wm_id,wm_house_no,add_datetime"

        strSQL &= "SELECT a.* "
        strSQL &= " ,CASE wm_org_flag WHEN '1' THEN '個人'  WHEN '2' THEN '營業'  WHEN '3' THEN '機關' END ORGFLAG "
        strSQL &= " ,CASE update_type WHEN '1' THEN '會員註冊'  WHEN '2' THEN '會員資料修改'  WHEN '3' THEN '狀態改變-停權' WHEN '4' THEN '新增用戶號碼' WHEN '5' THEN '刪除用戶號碼' WHEN '6' THEN '重寄授權碼' WHEN '7' THEN '尚未設定用戶號碼通知' END CHGFLAG "
        strSQL &= " ,wm_tel_oo = (CASE WHEN (wm_tel_o2 <> '-'  and  wm_tel_o2 <> '')  THEN wm_tel_o+' # '+wm_tel_o2   Else wm_tel_o END) "
        strSQL &= " ,b.mh_gen_user , b.mh_gen_dept ,convert(varchar(8),a.add_datetime,112 )-19110000 as appDate   "
        strSQL &= " FROM webmember_history a "
        strSQL &= " left join member_house b on b.mh_wm_no = a.wm_no and b.mh_house_no =a.wm_house_no  "
        strSQL &= " WHERE trans_type = '0' and (update_type='2' or update_type='3'or update_type='4' or update_type='5') and wm_house_no <> '' order by add_datetime "


        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function


    Public Function QueryDate98(ByVal status As String, ByVal AppSDATE As String, ByVal AppEDATE As String, ByVal ProSDATE As String, ByVal ProEDATE As String, ByVal VolNo As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable

        'strSQL = "Select SelfReportDot.*, portal.dbo.sysUserInfo.dept,portal.dbo.sysOrg.objID,portal.dbo.sysOrg.objName "
        'strSQL = strSQL + " from SelfReportDot left outer join portal.dbo.sysUserInfo"
        'strSQL = strSQL + " on rtrim(SelfReportDot.Operator)=rtrim(portal.dbo.sysUserInfo.Cname) "
        'strSQL = strSQL + " left outer join portal.dbo.sysOrg"
        'strSQL = strSQL + " on rtrim(portal.dbo.sysUserInfo.dept)=rtrim(portal.dbo.sysOrg.objID)"
        strSQL = "Select SelfReportDot.*,portal.dbo.vuserinfo.groupname,SUBSTRING(SelfReportDot.Vol_no,2,2) as Vol_no2,"
        strSQL = strSQL + "SUBSTRING(SelfReportDot.Vol_no,1,1) as Vol_no1 from SelfReportDot "
        strSQL = strSQL + " left outer join portal.dbo.vuserInfo"
        strSQL = strSQL + " on rtrim(SelfReportDot.operator)=rtrim(portal.dbo.vuserInfo.username)"
        strSQL = strSQL + " where "
        If AppSDATE.Trim <> "" And AppEDATE.Trim <> "" Then
            strSQL &= " SelfReportDot.CreateTime Between '" & AppSDATE & "' and '" & AppEDATE & "'"
        End If
        If ProSDATE.Trim <> "" And ProEDATE.Trim <> "" Then
            strSQL &= " SelfReportDot.ProcessTime  Between '" & ProSDATE & "' and '" & ProEDATE & "'"
        End If
        If status.Trim <> "2" Then
            strSQL &= " and status='" & status & "'"
        End If
        If (VolNo <> "") Then
            strSQL &= " and SUBSTRING(SelfReportDot.Vol_no,2,2) = '" & VolNo & "' "
        End If
        strSQL &= " Order by Vol_no2,Vol_no1"
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function


    Public Function Update(ByVal entityID As String, ByVal status As String, ByVal myoperator As String) As Integer
        Dim strSQL As String

        strSQL = "UPDATE SelfReportDot set ProcessTime=getdate() ,status='" & status & "' ,operator='" & myoperator & "'"

        strSQL &= " Where entityID ='" & entityID & "' "


        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function

    Public Function UpdatebyAccountNO(ByVal AccountNO As String, ByVal status As String) As Integer
        Dim strSQL As String
        Dim dt2 As DataTable

        strSQL = "UPDATE SelfReportDot set ProcessTime=getdate() ,status='" & status & "'"

        strSQL &= " Where AccountNO ='" & AccountNO & "' "


        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        dt2 = conn.ReadDataTable(strSQL)
        conn.close()

    End Function

    Public Function UpdatebyEntityID(ByVal EntityID As String, ByVal status As String, Optional ByVal myoperator As String = "") As Integer
        Dim strSQL As String
        Dim dt2 As DataTable

        strSQL = "UPDATE SelfReportDot "
        If myoperator <> "" Then
            strSQL = strSQL + "set ProcessTime=getdate() "
            strSQL = strSQL + ",operator='" & myoperator & "' "
        Else
            strSQL = strSQL + "set ProcessTime=null "
            strSQL = strSQL + ",operator='' "
        End If
        strSQL = strSQL + ",status='" & status & "'"

        strSQL &= " Where EntityID ='" & EntityID & "' "


        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        dt2 = conn.ReadDataTable(strSQL)
        conn.close()

    End Function


End Class
