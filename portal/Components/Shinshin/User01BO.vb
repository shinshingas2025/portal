Public Class User01BO
    '取得要更新的"申請號碼"
    Public Function getSendID(ByVal NowYear As Integer) As String
        Dim SendID As String = ""
        Dim oldSendID As String = ""
        Dim ds As DataSet
        Dim myAPPC02DAO As New APPC02DAO
        'strSQL = "Select * from inforappm17 where 1=1 "
        ds = myAPPC02DAO.GetEntity(NowYear)
        oldSendID = ds.Tables(0).Rows(0).Item("ac02_last_no")
        'SendID = NowYear & Right("0000" & CStr(CInt(oldSendID) + 1), 5) & "0000"
        SendID = CStr(CInt(oldSendID) + 1)
        'Call UpdateSendID(SendID)

        Return SendID
    End Function
    '更新申請號碼
    Public Sub UpdateSendID(ByVal SendID As String)
        Dim myAPPC02DAO As New APPC02DAO

        myAPPC02DAO.UpdateEntity(Year(Now()) - 1911, CInt(SendID))

    End Sub
    'get LastNo
    Public Function getSendNewID(ByVal NowYear As Integer) As String
        Dim objAPPx01 As New APPX01DAO
        getSendNewID = objAPPx01.GetLastNu(NowYear)
    End Function
    '取得insert物件
    Public Function getInAPPX01Entity(ByVal EntityID As String) As APPX01Entity
        Dim myNewApplyBO As New NewApplyFormBO
        Dim myAPPX01Entity As New APPX01Entity
        Dim dt As DataTable

        dt = myNewApplyBO.QueryByEntityID(EntityID)
        Dim aa As Integer = dt.Rows.Count()

        myAPPX01Entity.ax01_house_no = "0"
        myAPPX01Entity.ax01_appl_date = CType(CStr(Year(Now()) - 1911) & CStr(Right("00" & Month(Now()), 2)) & CStr(Right("00" & Day(Now()), 2)), Integer)
        myAPPX01Entity.ax01_name = dt.Rows(0).Item("am01_name")
        myAPPX01Entity.ax01_canton = dt.Rows(0).Item("am01_canton_code")

        If IsDBNull(dt.Rows(0).Item("am01_street_code")) Then
            myAPPX01Entity.ax01_street = "0"
        Else
            myAPPX01Entity.ax01_street = dt.Rows(0).Item("am01_street_code")
        End If
        If IsDBNull(dt.Rows(0).Item("am01_section")) Then
            myAPPX01Entity.ax01_section = "0"
        Else
            myAPPX01Entity.ax01_section = dt.Rows(0).Item("am01_section")
        End If
        If IsDBNull(dt.Rows(0).Item("am01_lane")) Then
            myAPPX01Entity.ax01_lane = "0"
        Else
            myAPPX01Entity.ax01_lane = dt.Rows(0).Item("am01_lane")
        End If
        If IsDBNull(dt.Rows(0).Item("am01_alley")) Then
            myAPPX01Entity.ax01_alley = "0"
        Else
            myAPPX01Entity.ax01_alley = dt.Rows(0).Item("am01_alley")
        End If
        If IsDBNull(dt.Rows(0).Item("am01_number")) Then
            myAPPX01Entity.ax01_number = ""
        Else
            myAPPX01Entity.ax01_number = dt.Rows(0).Item("am01_number").ToString
        End If

        '測試環境沒有的資料------------------------------------
        If IsDBNull(dt.Rows(0).Item("am01_dash")) Then
            myAPPX01Entity.ax01_dash = ""
        Else
            myAPPX01Entity.ax01_dash = Mid(dt.Rows(0).Item("am01_dash").ToString, 1, 1)
        End If
        If IsDBNull(dt.Rows(0).Item("am01_number2")) Then
            myAPPX01Entity.ax01_number2 = "0"
        Else
            myAPPX01Entity.ax01_number2 = dt.Rows(0).Item("am01_number2")
        End If
        '測試環境沒有的資料------------------------------------

        If IsDBNull(dt.Rows(0).Item("am01_sub_no")) Then
            myAPPX01Entity.ax01_sub_no = "0"
        Else
            myAPPX01Entity.ax01_sub_no = dt.Rows(0).Item("am01_sub_no")
        End If
        If IsDBNull(dt.Rows(0).Item("am01_floor")) Then
            myAPPX01Entity.ax01_floor = ""
        Else
            myAPPX01Entity.ax01_floor = dt.Rows(0).Item("am01_floor")
        End If
        If IsDBNull(dt.Rows(0).Item("am01_room")) Then
            myAPPX01Entity.ax01_room = ""
        Else
            myAPPX01Entity.ax01_room = dt.Rows(0).Item("am01_room")
        End If
        myAPPX01Entity.ax01_alt_addr = dt.Rows(0).Item("am01_alt_addr")
        If IsDBNull(dt.Rows(0).Item("am01_zone1")) Then
            myAPPX01Entity.ax01_zone1 = ""
        Else
            myAPPX01Entity.ax01_zone1 = dt.Rows(0).Item("am01_zone1")
        End If
        If IsDBNull(dt.Rows(0).Item("am01_telno1")) Then
            myAPPX01Entity.ax01_telno1 = ""
        Else
            myAPPX01Entity.ax01_telno1 = dt.Rows(0).Item("am01_telno1")
        End If

        '測試環境沒有的資料------------------------------------
        If IsDBNull(dt.Rows(0).Item("am01_ext1")) Then
            myAPPX01Entity.ax01_ext1 = ""
        Else
            myAPPX01Entity.ax01_ext1 = Mid(dt.Rows(0).Item("am01_ext1"), 1, 5)
        End If
        myAPPX01Entity.ax01_remark1 = ""
        '測試環境沒有的資料------------------------------------

        If IsDBNull(dt.Rows(0).Item("am01_zone2")) Then
            myAPPX01Entity.ax01_zone2 = ""
        Else

            myAPPX01Entity.ax01_zone2 = dt.Rows(0).Item("am01_zone2")
        End If
        If IsDBNull(dt.Rows(0).Item("am01_telno2")) Then
            myAPPX01Entity.ax01_telno2 = ""
        Else
            myAPPX01Entity.ax01_telno2 = dt.Rows(0).Item("am01_telno2")
        End If

        '測試環境沒有的資料------------------------------------
        myAPPX01Entity.ax01_remark2 = ""
        If IsDBNull(dt.Rows(0).Item("am01_telno3")) Then
            myAPPX01Entity.ax01_telno3 = ""
        Else
            myAPPX01Entity.ax01_telno3 = Mid(dt.Rows(0).Item("am01_telno3"), 1, 12)
        End If
        myAPPX01Entity.ax01_remark3 = ""
        '測試環境沒有的資料------------------------------------

        myAPPX01Entity.ax01_appl_kind = dt.Rows(0).Item("Appl_Kind_Code")
        myAPPX01Entity.ax01_usage = dt.Rows(0).Item("Appl_Usage_Code")
        'myAPPX01Entity.ax01_appl_kind = "9"
        'myAPPX01Entity.ax01_usage = "7"

        myAPPX01Entity.ax01_case_dis = "1"
        myAPPX01Entity.ax01_extend = ""

        '測試環境沒有的資料------------------------------------
        If IsDBNull(dt.Rows(0).Item("am01_name")) Then
            myAPPX01Entity.ax01_post_name = ""
        Else
            myAPPX01Entity.ax01_post_name = Mid(dt.Rows(0).Item("am01_name").ToString, 1, 20)
        End If
        '測試環境沒有的資料------------------------------------

        myAPPX01Entity.ax01_appl_cnt = "1"
        myAPPX01Entity.ax01_gen_user = "Y001"
        myAPPX01Entity.ax01_dsgn_rno = ""
        myAPPX01Entity.ax01_send_dsgn = myAPPX01Entity.ax01_appl_date
        myAPPX01Entity.ax01_not_dsgn_cd = ""

        'myAPPX01Entity.ax01_de_user = dt.Rows(0).Item("Operator")

        myAPPX01Entity.ax01_de_date = myAPPX01Entity.ax01_appl_date
        myAPPX01Entity.ax01_print_date = "0"
        myAPPX01Entity.ax01_user_id = ""
        myAPPX01Entity.ax01_upd_datetime = Format(Now(), "yyyy-MM-dd H:mm:ss.fff").ToString
        'myAPPX01Entity.ax01_upd_datetime = "2006-11-01 22:13:00.000"

        '測試環境沒有的資料------------------------------------
        myAPPX01Entity.ax01_ald_mark = "N"
        myAPPX01Entity.ax01_esv_mark = ""
        myAPPX01Entity.ax01_esv_yorn = ""
        If IsDBNull(dt.Rows(0).Item("am01_id_no")) Then
            myAPPX01Entity.ax01_id_no = ""
        Else
            myAPPX01Entity.ax01_id_no = Mid(dt.Rows(0).Item("am01_id_no"), 1, 10)
        End If
        myAPPX01Entity.ax01_company_no = ""
        '測試環境沒有的資料------------------------------------


        Return myAPPX01Entity

    End Function
    'Insert
    Public Function InsertAPPX01Entity(ByVal SendID As String, ByVal APPX01Entity As APPX01Entity) As Integer
        Dim myAPPX01DAO As New APPX01DAO

        APPX01Entity.ax01_appl_no = SendID
        myAPPX01DAO.InsertEntity(APPX01Entity)

        Return 0
    End Function
    '取得員工編號
    Public Function getEmployeeID(ByVal UID As String) As String
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *  from vUserMapSecurity where UID = '" & UID & "'"

        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt.Rows(0).Item("Alias")
    End Function

End Class
