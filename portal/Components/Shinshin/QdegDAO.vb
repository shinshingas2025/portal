Imports System.Data
Imports System.Data.OracleClient

Public Class QDegDAO
    Public Function QueryDate(ByVal cYYMM As String, ByVal volNoS As String, ByVal volNoE As String) As DataTable
        Dim strSQL As String = ""

        Dim myConnection As New OracleConnection(Configration.OracleConnectionString)


        strSQL = " select fa_app_03(HM08_EMP_NO) clip_name, ft_uctt02('APPT01_6', ax33_kind)  kind,"
        strSQL += "ft_make_date(ax33_input_dt) input_dt, AM01_VOL_NO, AX33_HOUSE_NO, "
        strSQL += "fa_app_02(AM01_CANTON, AM01_STREET, AM01_SECTION, AM01_LANE, AM01_ALLEY, AM01_NUMBER,"
        strSQL += " AM01_DASH, AM01_NUMBER2, AM01_SUB_NO, AM01_FLOOR, AM01_ROOM, '', '', 2) address,"
        strSQL += "  AX33_NOTE, AX33_CALL_TEL || decode(NVL(trim(AX33_CALL_EXT), '@'), '@', '', '-') || trim(AX33_CALL_EXT) tel , "
        strSQL += "  AX33_MTR_POINT, AX33_FILE_SEQ, fa_app_03(AX33_USER_ID) input_name,"
        strSQL += " AX33_CHK, AX33_USE, AX33_CLIP_YYMM, (select count(*) from hsin.appx11 where ax11_house_no = ax33_house_no and ax11_owner_comp = ax33_owner_comp) ax11_cnt¡@"
        strSQL += " from  hsin.appm01, hsin.appx33, hsin.htpm08 "
        strSQL += " where ax33_house_no > 0"
        strSQL += " and ax33_house_no = am01_house_no"
        strSQL += " and am01_vol_no = hm08_vol_no(+)"
        strSQL += " and hm08_Owner_comp(+) = f_shin_comp"
        strSQL += " and ax33_owner_comp = am01_owner_comp"
        strSQL += " and NVL(HM08_STOP_FLAG, '@') = '@'"
        strSQL += " and ax33_owner_comp = f_shin_comp"
        strSQL += " and ax33_clip_yymm =:ax33_clip_yymm"
        'strSQL += " and ax33_clip_yymm ='10708'"
        'strSQL += "  and substr(am01_vol_no,2,2) between :volS and :volE"
        strSQL += "  and am01_vol_no  between :volS and :volE"
        strSQL += " order by HM08_EMP_NO, am01_vol_no, am01_alt_addr2"

        Dim myCommand As New OracleCommand(strSQL, myConnection)

        myCommand.Parameters.Add(":ax33_clip_yymm", cYYMM)
        myCommand.Parameters.Add(":volS", volNoS)
        myCommand.Parameters.Add(":volE", volNoE)


        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        da = New OracleDataAdapter(myCommand)
        da.Fill(dt)

        Return dt

    End Function





End Class
