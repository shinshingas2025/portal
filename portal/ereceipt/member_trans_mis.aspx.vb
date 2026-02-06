Public Class member_trans_mis
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents status As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents ProcessEDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents ProcessSDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents ProcessDateO As System.Web.UI.WebControls.RadioButton
    Protected WithEvents ApplyEDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ApplySDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents applydateO As System.Web.UI.WebControls.RadioButton
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region
    Dim objDR As DataRow

    Dim AppEDATE, AppSDATE, ProSdate, ProEdate, sendSDATE, sendEDATE As String
    Dim ReportServer As String = Configration.ReportServerURL

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        ' objCartDT = CType(Session("Cart"), DataTable)
        If Not IsPostBack Then
            ' Call GetUser(context.User.Identity.Name.Trim)
            msgbox.Text = ""
            showData()
        End If

    End Sub

    Private Sub GetUser(ByVal user As String)
        Dim objUser As New UserInfoBO
        Dim objDeptBO As New OrgBO
        Dim objDept As New DeptExtendOrgEntity
        Dim dt As New DataTable
        dt = objUser.QueryUserInfo(user)
        If dt.Rows.Count > 0 Then
            objDept.DeptID = dt.Rows(0).Item("Dept")
            Creater.Text = dt.Rows(0).Item("Cname")
            dt = objDeptBO.QueryDept(objDept)
            If dt.Rows.Count > 0 Then
                createGroup.Text = dt.Rows(0).Item("objname")
            End If
        End If

    End Sub

    Sub showData()
        Dim se As New WebmemberDotDAO
        Dim objCartDT As DataTable
        objCartDT = se.QueryMemTransDate()
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim Bj As New Batch_job
        Dim objCartDT As DataTable
        Dim SqlStr As String
        Dim dt As DataTable
        Dim Flag As Integer
        Dim SubStr As String = ""
        Dim strMsg As String = ""
        Dim MisCount As Integer = 0
        Dim Success As Integer = 0
        Dim Failure As Integer = 0
        Dim Failure_house_string As String = ""
        Dim skip_house_string As String = ""
        Dim skipCount As Integer = 0
        Dim Str_temp_house_no As String = ""


        msgbox.Text = ""
        '取得尚未處理的資料,逐筆處理
        Dim se As New WebmemberDotDAO
        Dim now_dt, transDate As String
        Dim flag_update_type As String = ""
        now_dt = DateTime.Now.ToString("yyyyMMdd")
        transDate = Left(now_dt, 4) - 1911 & Mid(now_dt, 5, 2) & Right(now_dt, 2)   ' 更新日期
        
        dt = se.QueryMemTransDate()        ' 查到的資料寫到 datatable

        For i = 0 To dt.Rows.Count - 1     ' objCartDT.Rows.Count - 1

            'If Trim(dt.Rows(i)("update_type")) = "3" Then
            '    flag_update_type = "5"
            'Else
            '    flag_update_type = Trim(dt.Rows(i)("update_type"))
            'End If

            'Try
            Select Case Trim(dt.Rows(i)("update_type"))
                Case 1          ' 會員註冊 (不需轉入)
                Case 2          ' 判別 [update_type 異動別]為 (2) 會員資料修改
                    'wm_paper_flag 1110406 add 
                    'If (dt.Rows(i)("wm_tel_h").ToString <> "-") Or (dt.Rows(i)("wm_tel_o").ToString <> "-") Or (dt.Rows(i)("wm_tel_o2").ToString <> "-") Or (dt.Rows(i)("wm_mobile").ToString <> "-") Or (dt.Rows(i)("wm_email").ToString <> "-") Then
                    If (dt.Rows(i)("wm_tel_h").ToString <> "-") Or (dt.Rows(i)("wm_tel_o").ToString <> "-") Or (dt.Rows(i)("wm_tel_o2").ToString <> "-") Or (dt.Rows(i)("wm_mobile").ToString <> "-") Or (dt.Rows(i)("wm_email").ToString <> "-") Or (dt.Rows(i)("wm_paper_flag").ToString <> "-") Then
                        '　會員資料修改
                        Dim dtam01 As DataTable             'update appm01
                        Dim dsam01 As DataSet
                        Dim dtam48 As DataTable             'update appm48
                        Dim dtax17 As DataTable             'insert appx17
                        Dim MisStr01 As String              '組成更新appm01的sql語法
                        Dim MisStr17 As String              '組成新增appx17的sql語法
                        Dim MisStr17_1 As String            '組成新增appx17的sql語法
                        Dim MisStr17_2 As String            '組成新增appx17的sql語法
                        Dim MisStr48 As String              '組成更新appm48的sql語法
                        Dim NO01 As String
                        Dim update_flag As String = "N"
                        Dim tmp_flag_update As String = ""
                        Dim str_am01_total_no As String     '記錄am01_total_no
                        Dim Code2AM64 As Boolean = False   '1110407 add 

                        ' 第一步 , 以此用戶號碼,讀取 Appm01 , 判別不一樣則將appm01資料寫入appx17 , 再update appm01
                        Dim Am As New Batch_job
                        NO01 = Trim(dt.Rows(i)("wm_house_no"))
                        dtam01 = Am.QueryInformixappm01(NO01)
                        ' 檢查 [ wm_tel_h 連絡電話(家) ] , [wm_tel_o 連絡電話(辦)] , [wm_tel_o2 連絡電話(辦)-分機] , [wm_mobile 申請人手機]
                        ' 如果值不為 '-' and 不為 '' , 且值與 appm01 不同 , 則把 APPM01 有異動的值新增一筆到 appx17 ,只寫有異動的欄位 , 然後更新 appm01
                        ' dtam01 = Bj.GetMisData(SqlStr)
                        If dtam01.Rows.Count = 1 Then
                            MisStr01 = ""
                            MisStr17_1 = ""
                            MisStr17_2 = ""
                            If Trim(dt.Rows(i)("wm_tel_h").ToString) <> "-" And Trim(dt.Rows(i)("wm_tel_h").ToString) <> Trim(dtam01.Rows(0)("AM01_ZONE2").ToString) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO2").ToString) Then
                                ' 更新 APPM01欄位, wm_tel_h <--> AM01_ZONE2 - AM01_TELNO2   (AX17_ZONE2 - AX17_TELNO2 , AX17_TEL2_C = 'V')
                                tmp_flag_update = ""
                                If (Trim(dt.Rows(i)("wm_tel_h").ToString) <> "") Then
                                    MisStr01 &= " AM01_ZONE2='" & Left(dt.Rows(i)("wm_tel_h"), 2) & "', AM01_TELNO2='" & Right(dt.Rows(i)("wm_tel_h").ToString, Len(dt.Rows(i)("wm_tel_h").ToString) - 3) & "'"
                                Else
                                    If (Trim(dtam01.Rows(0)("AM01_ZONE2").ToString) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO2").ToString) <> "-") Then
                                        MisStr01 &= " AM01_ZONE2='', AM01_TELNO2=''"
                                    Else
                                        tmp_flag_update = "N"
                                    End If
                                End If
                                If (tmp_flag_update <> "N") Then
                                    MisStr17_1 &= ", AX17_ZONE2 , AX17_TELNO2 , AX17_TEL2_C "
                                    MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_ZONE2").ToString & "' , '" & dtam01.Rows(0)("AM01_TELNO2").ToString & "' , 'V' "
                                End If
                                '1140324 相關電話取消更正MIS
                                'update_flag = "Y"
                            End If
                            If (Trim(dt.Rows(i)("wm_tel_o").ToString) <> "-" And Trim(dt.Rows(i)("wm_tel_o").ToString) <> Trim(dtam01.Rows(0)("AM01_ZONE1").ToString) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO1").ToString)) Or (Trim(dt.Rows(i)("wm_tel_o2").ToString) <> "-" And Trim(dt.Rows(i)("wm_tel_o2").ToString) <> Trim(dtam01.Rows(0)("AM01_EXT1").ToString)) Then
                                ' 更新 APPM01欄位, wm_tel_o <--> AM01_ZONE1 - AM01_TELNO1  , wm_tel_o2 <--> AM01_EXT1   (AX17_ZONE1 - AX17_TELNO1 # AX17_EXT1 , AX17_TEL1_C = 'V')
                                ' MisStr01 &= " AM01_ZONE1='" & Left(dt.Rows(i)("wm_tel_o"), 2) & "', AM01_TELNO1='" & Right(dt.Rows(i)("wm_tel_o"), Len(dt.Rows(i)("wm_tel_o")) - 3) & "' , AM01_EXT1='" & dt.Rows(i)("wm_tel_o2") & "'"
                                tmp_flag_update = ""
                                If (Trim(dt.Rows(i)("wm_tel_o").ToString) <> "-") Then
                                    If (Trim(dt.Rows(i)("wm_tel_o").ToString) <> "") Then
                                        If MisStr01 <> "" Then
                                            MisStr01 &= ","
                                        End If
                                        MisStr01 &= " AM01_ZONE1='" & Left(dt.Rows(i)("wm_tel_o"), 2) & "', AM01_TELNO1='" & Right(dt.Rows(i)("wm_tel_o"), Len(dt.Rows(i)("wm_tel_o")) - 3) & "'"
                                    Else
                                        If (Trim(dtam01.Rows(0)("AM01_ZONE1").ToString) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO1").ToString) <> "-") Then
                                            If MisStr01 <> "" Then
                                                MisStr01 &= ","
                                            End If
                                            MisStr01 &= " AM01_ZONE1='', AM01_TELNO1='' "
                                        Else
                                            tmp_flag_update = "N"
                                        End If
                                    End If
                                End If
                                If (Trim(dt.Rows(i)("wm_tel_o2").ToString) <> "-") Then
                                    tmp_flag_update = "Y"
                                    If (Trim(dt.Rows(i)("wm_tel_o2").ToString) <> "") Then
                                        If MisStr01 <> "" Then
                                            MisStr01 &= ","
                                        End If
                                        MisStr01 &= " AM01_EXT1='" & dt.Rows(i)("wm_tel_o2").ToString & "'"
                                    Else
                                        If (Trim(dtam01.Rows(0)("AM01_EXT1").ToString) <> "") Then
                                            If MisStr01 <> "" Then
                                                MisStr01 &= ","
                                            End If
                                            MisStr01 &= " AM01_EXT1='' "
                                        Else
                                            tmp_flag_update = "N"
                                        End If
                                    End If
                                End If
                                If (tmp_flag_update <> "N") Then
                                    MisStr17_1 &= ", AX17_ZONE1 , AX17_TELNO1 , AX17_EXT1 , AX17_TEL1_C "
                                    MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_ZONE1").ToString & "' , '" & dtam01.Rows(0)("AM01_TELNO1").ToString & "', '" & dtam01.Rows(0)("AM01_EXT1").ToString & "' , 'V' "
                                End If
                                '1140324 相關電話取消更正MIS
                                'update_flag = "Y"
                            End If
                            If Trim(dt.Rows(i)("wm_mobile").ToString) <> "-" And Trim(dt.Rows(i)("wm_mobile").ToString) <> Trim(dtam01.Rows(0)("AM01_TELNO3").ToString) Then
                                tmp_flag_update = ""

                                ' 更新 APPM01欄位, wm_mobile<--> AM01_TELNO3  (AX17_TELNO3 , AX17_TEL3_C = 'V')

                                If (Trim(dt.Rows(i)("wm_mobile").ToString) <> "") Then
                                    If MisStr01 <> "" Then
                                        MisStr01 &= ","
                                    End If
                                    MisStr01 &= " AM01_TELNO3='" & dt.Rows(i)("wm_mobile").ToString & "'"
                                Else
                                    If (Trim(dtam01.Rows(0)("AM01_TELNO3").ToString) <> "") Then
                                        If MisStr01 <> "" Then
                                            MisStr01 &= ","
                                        End If
                                        MisStr01 &= " AM01_TELNO3 ='' "
                                    Else
                                        tmp_flag_update = "N"
                                    End If
                                End If
                                If (tmp_flag_update <> "N") Then
                                    MisStr17_1 &= " , AX17_TELNO3 , AX17_TEL3_C "
                                    MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_TELNO3").ToString & "'  , 'V' "
                                End If
                                '1140324 相關電話取消更正MIS
                                'update_flag = "Y"
                            End If
                            If MisStr01 <> "" Then
                                MisStr01 = "Update HSIN.Appm01 Set " & MisStr01 & " Where  am01_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                                '1140324 相關電話取消更正MIS
                                ' Bj.ExecuteCom(MisStr01)           ' update appm01
                            End If

                            str_am01_total_no = Trim(dtam01.Rows(0)("AM01_TOTAL_NO"))
                            ' 第二步 , 以此用戶號碼,讀取 Appm48 , 判別不一樣, 則將appm48資料寫入appx17 , 再update appm48 若無此用戶資料 , 則新增一筆 appm48


                            ' 如果資料存在,則 update , 資料不存在則 insert
                            If dt.Rows(i)("wm_email").ToString <> "-" And dt.Rows(i)("wm_email").ToString <> "" Then

                                Dim Am48 As New Batch_job
                                NO01 = Trim(dt.Rows(i)("wm_house_no"))
                                dtam48 = Am.QueryInformixappm48(NO01)
                                If dtam48.Rows.Count = 1 Then
                                    ' 檢查 [wm_email 申請人郵寄地址] , 如果值不為 '-' and 不為 '' , 且值與 appm48 不同 , 則把 APPM48 有異動的值新增一筆到 appx17 ,只寫有異動的欄位 , 然後更新 appm48
                                    If dt.Rows(i)("wm_email") <> Trim(dtam48.Rows(0)("AM48_EMAIL").ToString) Then
                                        ' 更新 APPM48 欄位, wm_email <--> am48_email   (AX17_EMAIL , AX17_EMAIL_C = 'V')
                                        MisStr48 = " Update HSIN.Appm48 Set "
                                        MisStr48 &= " AM48_EMAIL='" & dt.Rows(i)("wm_email") & "' , am48_owner_comp='1' "
                                        '1110801 add 
                                        MisStr48 &= " , am48_user_id='9999', am48_upd_datetime=sysdate "

                                        MisStr48 &= " Where  am48_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"

                                        MisStr17_1 = " , AX17_EMAIL , AX17_EMAIL_C "
                                        MisStr17_2 = ", '" & dtam48.Rows(0)("AM48_EMAIL") & "'  , 'V' "
                                        update_flag = "Y"
                                        Bj.ExecuteCom(MisStr48)           ' update appm48
                                    End If
                                Else
                                    ' appm48 無此用戶則新增一筆
                                    MisStr48 = "insert into HSIN.Appm48 (am48_total_no ,am48_house_no , am48_email , am48_user_id,am48_upd_datetime,am48_owner_comp)  "
                                    MisStr48 &= " values (" & str_am01_total_no & "," & Trim(dt.Rows(i)("wm_house_no")) & ",'" & dt.Rows(i)("wm_email") & "','9999',sysdate,'1' ) "
                                    Bj.ExecuteCom(MisStr48)           ' insert appm48

                                    MisStr17_1 = " , AX17_EMAIL , AX17_EMAIL_C "
                                    MisStr17_2 = ", ''  , 'V' "
                                    update_flag = "Y"
                                End If


                                '1110801 add 
                                SqlStr = "Select * from HSIN.appm64 where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no").ToString) & "'"
                                strMsg = dt.Rows(i)("wm_house_no").ToString
                                If Bj.GetMisDataIsRepeat(SqlStr) Then   '有
                                    'SqlStr = "Update HSIN.Appm64 Set am64_upd_datetime=sysdate , am64_owner_comp='1'   where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                                    SqlStr = " Update HSIN.Appm64 Set am64_email='" & dt.Rows(i)("wm_email") & "' , am64_upd_datetime=sysdate  where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                                    Bj.ExecuteCom(SqlStr)
                                    update_flag = "Y"

                                End If
                            End If

                            '1110406 add 
                            If dt.Rows(i)("wm_paper_flag").ToString <> "-" Then
                                SqlStr = "Select * from HSIN.appm64 where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no").ToString) & "'"
                                strMsg = dt.Rows(i)("wm_house_no").ToString
                                If Bj.GetMisDataIsRepeat(SqlStr) Then   '有
                                    'SqlStr = "Update HSIN.Appm64 Set am64_upd_datetime=sysdate , am64_owner_comp='1'   where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                                    SqlStr = "Update HSIN.Appm64 Set am64_upd_datetime=sysdate , am64_owner_comp='1' ,  am64_receipt_paper ='" & Trim(dt.Rows(i)("wm_paper_flag")) & "' where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                                    Bj.ExecuteCom(SqlStr)
                                    'update_flag = "Y"
                                    Code2AM64 = True

                                    strMsg = strMsg & " 1110406 "
                                    If update_flag <> "Y" Then
                                        Success = Success + 1
                                    End If
                                End If

                            End If
                            '1110406 add end 

                            ' insert appx17 等 am01,am48 更新完再一起做
                            If (update_flag = "Y") Then
                                'sysdate
                                'MisStr17 = "insert into HSIN.Appx17 ( ax17_house_no, ax17_input_dt   " & MisStr17_1 & ", ax17_de_user,ax17_user_id,ax17_update_dt,ax17_upd_datetime ,ax17_owner_comp)  Values (" & Trim(dt.Rows(i)("wm_house_no")) & "," & transDate & MisStr17_2 & " ,'9999','9999'," & transDate & ",current,'1' )"
                                MisStr17 = "insert into HSIN.Appx17 ( ax17_house_no, ax17_input_dt   " & MisStr17_1 & ", ax17_de_user,ax17_user_id,ax17_update_dt,ax17_upd_datetime ,ax17_owner_comp)  Values (" & Trim(dt.Rows(i)("wm_house_no")) & "," & transDate & MisStr17_2 & " ,'9999','9999'," & transDate & ",sysdate,'1' )"

                                '1140324 相關電話取消更正MIS (但Email 需寫入)
                                Bj.ExecuteCom(MisStr17)

                                'Response.Write(MisStr17)
                                Success = Success + 1
                            Else
                                '1110407 modify 
                                If Not Code2AM64 Then
                                    skipCount = skipCount + 1       '基本資料無異動
                                    Str_temp_house_no = "000000" & Trim(dt.Rows(i)("wm_house_no"))
                                    skip_house_string &= Right(Str_temp_house_no, 7) & " ; "
                                End If

                            End If
                        End If
                    Else
                        skipCount = skipCount + 1       '基本資料無異動
                        Str_temp_house_no = "000000" & Trim(dt.Rows(i)("wm_house_no"))
                        skip_house_string &= Right(Str_temp_house_no, 7) & " ; "
                    End If
                    '*******1030120 mark case 3 (停權) 轉到跟5相同處理
                    'Case 3           '狀態異動不用轉到MIS
                Case 4
                    ' 判別 [update_type 異動別]為 (4) 新增用戶號碼
                    ' update 用戶基資料, 同 [update_type 異動別]為 (2) 會員資料修改 的處理
                    If (dt.Rows(i)("wm_tel_h").ToString <> "-") Or (dt.Rows(i)("wm_tel_o").ToString <> "-") Or (dt.Rows(i)("wm_tel_o2").ToString <> "-") Or (dt.Rows(i)("wm_mobile").ToString <> "-") Or (dt.Rows(i)("wm_email").ToString <> "-") Then
                        '　會員資料修改
                        Dim dtam01 As DataTable             'update appm01
                        Dim dsam01 As DataSet
                        Dim dtam48 As DataTable             'update appm48
                        Dim dtax17 As DataTable             'insert appx17
                        Dim MisStr01 As String              '組成更新appm01的sql語法
                        Dim MisStr17 As String              '組成新增appx17的sql語法
                        Dim MisStr17_1 As String            '組成新增appx17的sql語法
                        Dim MisStr17_2 As String            '組成新增appx17的sql語法
                        Dim MisStr48 As String              '組成更新appm48的sql語法

                        Dim NO01 As String
                        Dim update_flag As String = "N"
                        Dim tmp_flag_update As String = ""
                        Dim str_am01_total_no As String     '記錄am01_total_no

                        ' 第一步 , 以此用戶號碼,讀取 Appm01 , 判別不一樣則將appm01資料寫入appx17 , 再update appm01
                        Dim Am As New Batch_job
                        NO01 = Trim(dt.Rows(i)("wm_house_no"))
                        dtam01 = Am.QueryInformixappm01(NO01)
                        ' 檢查 [ wm_tel_h 連絡電話(家) ] , [wm_tel_o 連絡電話(辦)] , [wm_tel_o2 連絡電話(辦)-分機] , [wm_mobile 申請人手機]
                        ' 如果值不為 '-' and 不為 '' , 且值與 appm01 不同 , 則把 APPM01 有異動的值新增一筆到 appx17 ,只寫有異動的欄位 , 然後更新 appm01
                        ' dtam01 = Bj.GetMisData(SqlStr)
                        If dtam01.Rows.Count = 1 Then
                            MisStr01 = ""
                            MisStr17_1 = ""
                            MisStr17_2 = ""
                            If Trim(dt.Rows(i)("wm_tel_h").ToString) <> "-" And Trim(dt.Rows(i)("wm_tel_h").ToString) <> Trim(dtam01.Rows(0)("AM01_ZONE2").ToString) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO2").ToString) Then
                                ' 更新 APPM01欄位, wm_tel_h <--> AM01_ZONE2 - AM01_TELNO2   (AX17_ZONE2 - AX17_TELNO2 , AX17_TEL2_C = 'V')
                                tmp_flag_update = ""
                                If (Trim(dt.Rows(i)("wm_tel_h").ToString) <> "") Then
                                    MisStr01 &= " AM01_ZONE2='" & Left(dt.Rows(i)("wm_tel_h").ToString, 2) & "', AM01_TELNO2='" & Right(dt.Rows(i)("wm_tel_h").ToString, Len(dt.Rows(i)("wm_tel_h").ToString) - 3) & "'"
                                Else
                                    If (Trim(dtam01.Rows(0)("AM01_ZONE2").ToString) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO2").ToString) <> "-") Then
                                        MisStr01 &= " AM01_ZONE2='', AM01_TELNO2=''"
                                    Else
                                        tmp_flag_update = "N"
                                    End If
                                End If
                                If (tmp_flag_update <> "N") Then
                                    MisStr17_1 &= ", AX17_ZONE2 , AX17_TELNO2 , AX17_TEL2_C "
                                    MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_ZONE2").ToString & "' , '" & dtam01.Rows(0)("AM01_TELNO2").ToString & "' , 'V' "
                                End If
                                '1140324 相關電話取消更正MIS
                                'update_flag = "Y"
                            End If
                            If (Trim(dt.Rows(i)("wm_tel_o").ToString) <> "-" And Trim(dt.Rows(i)("wm_tel_o").ToString) <> Trim(dtam01.Rows(0)("AM01_ZONE1").ToString) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO1").ToString)) Or (Trim(dt.Rows(i)("wm_tel_o2").ToString) <> "-" And Trim(dt.Rows(i)("wm_tel_o2")) <> Trim(dtam01.Rows(0)("AM01_EXT1").ToString)) Then
                                ' 更新 APPM01欄位, wm_tel_o <--> AM01_ZONE1 - AM01_TELNO1  , wm_tel_o2 <--> AM01_EXT1   (AX17_ZONE1 - AX17_TELNO1 # AX17_EXT1 , AX17_TEL1_C = 'V')
                                ' MisStr01 &= " AM01_ZONE1='" & Left(dt.Rows(i)("wm_tel_o"), 2) & "', AM01_TELNO1='" & Right(dt.Rows(i)("wm_tel_o"), Len(dt.Rows(i)("wm_tel_o")) - 3) & "' , AM01_EXT1='" & dt.Rows(i)("wm_tel_o2") & "'"
                                tmp_flag_update = ""
                                If (Trim(dt.Rows(i)("wm_tel_o").ToString) <> "-") Then
                                    If (Trim(dt.Rows(i)("wm_tel_o").ToString) <> "") Then
                                        If MisStr01 <> "" Then
                                            MisStr01 &= ","
                                        End If
                                        MisStr01 &= " AM01_ZONE1='" & Left(dt.Rows(i)("wm_tel_o"), 2) & "', AM01_TELNO1='" & Right(dt.Rows(i)("wm_tel_o"), Len(dt.Rows(i)("wm_tel_o")) - 3) & "'"
                                    Else
                                        If (Trim(dtam01.Rows(0)("AM01_ZONE1").ToString) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO1").ToString) <> "-") Then
                                            If MisStr01 <> "" Then
                                                MisStr01 &= ","
                                            End If
                                            MisStr01 &= " AM01_ZONE1='', AM01_TELNO1='' "
                                        Else
                                            tmp_flag_update = "N"
                                        End If
                                    End If
                                End If
                                If (Trim(dt.Rows(i)("wm_tel_o2").ToString) <> "-") Then
                                    tmp_flag_update = "Y"
                                    If (Trim(dt.Rows(i)("wm_tel_o2").ToString) <> "") Then
                                        If MisStr01 <> "" Then
                                            MisStr01 &= ","
                                        End If
                                        MisStr01 &= " AM01_EXT1='" & dt.Rows(i)("wm_tel_o2").ToString & "'"
                                    Else
                                        If (Trim(dtam01.Rows(0)("AM01_EXT1").ToString) <> "") Then
                                            If MisStr01 <> "" Then
                                                MisStr01 &= ","
                                            End If
                                            MisStr01 &= " AM01_EXT1='' "
                                        Else
                                            tmp_flag_update = "N"
                                        End If
                                    End If
                                End If
                                If (tmp_flag_update <> "N") Then
                                    MisStr17_1 &= ", AX17_ZONE1 , AX17_TELNO1 , AX17_EXT1 , AX17_TEL1_C "
                                    MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_ZONE1").ToString & "' , '" & dtam01.Rows(0)("AM01_TELNO1").ToString & "', '" & dtam01.Rows(0)("AM01_EXT1").ToString & "' , 'V' "
                                End If
                                '1140324 相關電話取消更正MIS
                                'update_flag = "Y"
                            End If
                            If Trim(dt.Rows(i)("wm_mobile").ToString) <> "-" And Trim(dt.Rows(i)("wm_mobile").ToString) <> Trim(dtam01.Rows(0)("AM01_TELNO3").ToString) Then
                                tmp_flag_update = ""

                                ' 更新 APPM01欄位, wm_mobile<--> AM01_TELNO3  (AX17_TELNO3 , AX17_TEL3_C = 'V')

                                If (Trim(dt.Rows(i)("wm_mobile").ToString) <> "") Then
                                    If MisStr01 <> "" Then
                                        MisStr01 &= ","
                                    End If
                                    MisStr01 &= " AM01_TELNO3='" & dt.Rows(i)("wm_mobile").ToString & "'"
                                Else
                                    If (Trim(dtam01.Rows(0)("AM01_TELNO3").ToString) <> "") Then
                                        If MisStr01 <> "" Then
                                            MisStr01 &= ","
                                        End If
                                        MisStr01 &= " AM01_TELNO3 ='' "
                                    Else
                                        tmp_flag_update = "N"
                                    End If
                                End If
                                If (tmp_flag_update <> "N") Then
                                    MisStr17_1 &= " , AX17_TELNO3 , AX17_TEL3_C "
                                    MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_TELNO3").ToString & "'  , 'V' "
                                End If
                                '1140324 相關電話取消更正MIS
                                'update_flag = "Y"
                            End If
                            If MisStr01 <> "" Then
                                MisStr01 = "Update HSIN.Appm01 Set " & MisStr01 & " Where  am01_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                                '1140324 相關電話取消更正MIS
                                'Bj.ExecuteCom(MisStr01)           ' update appm01
                            End If

                            str_am01_total_no = Trim(dtam01.Rows(0)("AM01_TOTAL_NO").ToString)
                            ' 第二步 , 以此用戶號碼,讀取 Appm48 , 判別不一樣, 則將appm48資料寫入appx17 , 再update appm48 若無此用戶資料 , 則新增一筆 appm48


                            ' 如果資料存在,則 update , 資料不存在則 insert
                            If dt.Rows(i)("wm_email").ToString <> "-" And dt.Rows(i)("wm_email").ToString <> "" Then

                                Dim Am48 As New Batch_job
                                NO01 = Trim(dt.Rows(i)("wm_house_no"))
                                dtam48 = Am.QueryInformixappm48(NO01)
                                If dtam48.Rows.Count = 1 Then
                                    ' 檢查 [wm_email 申請人郵寄地址] , 如果值不為 '-' and 不為 '' , 且值與 appm48 不同 , 則把 APPM48 有異動的值新增一筆到 appx17 ,只寫有異動的欄位 , 然後更新 appm48
                                    If dt.Rows(i)("wm_email").ToString <> Trim(dtam48.Rows(0)("AM48_EMAIL").ToString) Then
                                        ' 更新 APPM48 欄位, wm_email <--> am48_email   (AX17_EMAIL , AX17_EMAIL_C = 'V')
                                        MisStr48 = " Update HSIN.Appm48 Set "
                                        MisStr48 &= " AM48_EMAIL='" & dt.Rows(i)("wm_email") & "' , am48_owner_comp ='1' "
                                        MisStr48 &= " Where  am48_house_no='" & Trim(dt.Rows(i)("wm_house_no").ToString) & "'"

                                        MisStr17_1 = " , AX17_EMAIL , AX17_EMAIL_C "
                                        MisStr17_2 = ", '" & dtam48.Rows(0)("AM48_EMAIL") & "'  , 'V' "
                                        update_flag = "Y"
                                        Bj.ExecuteCom(MisStr48)           ' update appm48
                                    End If
                                Else
                                    ' appm48 無此用戶則新增一筆
                                    MisStr48 = "insert into HSIN.Appm48 (am48_total_no ,am48_house_no , am48_email , am48_user_id,am48_upd_datetime,am48_owner_comp)  "
                                    MisStr48 &= " values (" & str_am01_total_no & "," & Trim(dt.Rows(i)("wm_house_no")) & ",'" & dt.Rows(i)("wm_email") & "','9999',sysdate,'1' ) "
                                    Bj.ExecuteCom(MisStr48)           ' insert appm48

                                    'modfiy 1080107  1080110
                                    MisStr17_1 = " , AX17_EMAIL , AX17_EMAIL_C "
                                    MisStr17_2 = ", ''  , 'V' "
                                    update_flag = "Y"
                                End If
                            End If
                            ' insert appx17 等 am01,am48 更新完再一起做
                            If (update_flag = "Y") Then
                                MisStr17 = "insert into HSIN.Appx17 ( ax17_house_no, ax17_input_dt   " & MisStr17_1 & ", ax17_de_user,ax17_user_id,ax17_update_dt,ax17_upd_datetime ,ax17_owner_comp)  Values (" & Trim(dt.Rows(i)("wm_house_no")) & "," & transDate & MisStr17_2 & " ,'9999','9999'," & transDate & ",sysdate,'1')"
                                '1140324 相關電話取消更正MIS(如Email 需寫入)
                                Bj.ExecuteCom(MisStr17)
                                Success = Success + 1
                          
                            Else
                                skipCount = skipCount + 1       '基本資料無異動
                                Str_temp_house_no = "000000" & Trim(dt.Rows(i)("wm_house_no"))
                                skip_house_string &= Right(Str_temp_house_no, 7) & " ; "
                            End If
                        End If
                    Else
                        skipCount = skipCount + 1       '基本資料無異動
                        Str_temp_house_no = "000000" & Trim(dt.Rows(i)("wm_house_no"))
                        skip_house_string &= Right(Str_temp_house_no, 7) & " ; "
                    End If

                    '
                    ' 先以用戶號碼 select appm64 , 如果存在則 update , 不存在則 insert
                    ' appm64->[am64_house_no	用戶號碼] , [am64_is_comm	是否為機關] ,[am64_receipt_paper	繳費憑證紙本]
                    '         [am64_receipt_mail	繳費憑證Mail],[am64_bill_paper	帳單紙本],[am64_bill_mail	帳單Mail]
                    '         [am64_user_id	異動人員],[am64_upd_datetime	異動時間]
                    '1101220 增加 電子會員電子信箱 (am64_email ) 及電子會員帳號 (am64_account)
                    SqlStr = "Select * from HSIN.appm64 where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no").ToString) & "'"
                    strMsg = dt.Rows(i)("wm_house_no").ToString
                    If Bj.GetMisDataIsRepeat(SqlStr) Then   '有
                        'SqlStr = " Update HSIN.Appm64 Set am64_upd_datetime=sysdate  , AM64_OWNER_COMP ='1' where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no").ToString) & "'"
                        SqlStr = "Update HSIN.Appm64 Set am64_upd_datetime=sysdate , am64_owner_comp='1' ,   am64_email ='" & Trim(dt.Rows(i)("wm_email")) & "' , am64_account='" & Trim(dt.Rows(i)("wm_id")) & "'  where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                        strMsg = strMsg & " appm64 has"
                    Else                                    '無
                        'SqlStr = "Insert into HSIN.Appm64(am64_house_no,am64_is_comm,am64_receipt_paper,am64_receipt_email,am64_bill_paper,am64_bill_email,am64_user_id,am64_upd_datetime,AM64_OWNER_COMP) "
                        'SqlStr &= " Values(" & dt.Rows(i)("wm_house_no").ToString & ",'" & dt.Rows(i)("wm_org_flag") & "','" & dt.Rows(i)("wm_paper_flag").ToString & "','Y','N','N','9999',sysdate,'1')"   ' & Format(Now, "yyyy/MM/dd HH:mm:ss") & "')"
                        SqlStr = "Insert into HSIN.Appm64(am64_house_no,am64_is_comm,am64_receipt_paper,am64_receipt_email,am64_bill_paper,am64_bill_email,am64_user_id,am64_upd_datetime,am64_owner_comp,am64_email,am64_account) "
                        SqlStr &= " Values(" & dt.Rows(i)("wm_house_no") & ",'" & dt.Rows(i)("wm_org_flag") & "','" & dt.Rows(i)("wm_paper_flag") & "','Y','N','N','9999',sysdate,'1','" & Trim(dt.Rows(i)("wm_email")) & "','" & Trim(dt.Rows(i)("wm_id")) & "')"
                        strMsg = strMsg & " no "
                    End If

                    Bj.ExecuteCom(SqlStr)

                    '1121211
                    Dim MisStr28 As String              'rcpm28
                    Dim strRM28_ZONE() As String, strRM28_ZONE1 As String, strRM28_TELNO1 As String, strRM28_EXT1 As String ' 公司電話

                    Dim strRM28_ZONE2S() As String, strRM28_ZONE2 As String, strRM28_TELNO2 As String

                    Dim RM28_COMPANY_NO As String
                    Dim strCHKCode As String ' 1130205 add 
                    Dim RM28_COMP As String = "1"  ' 1130227 add 

                    Dim rm28Data, dtsaft03 As DataTable ' 1130206 add  , 1130227 add 

                    strRM28_ZONE = Trim(dt.Rows(i)("wm_tel_o").ToString).Split("-")
                    If Trim(dt.Rows(i)("wm_tel_o").ToString) <> "" Then
                        strRM28_ZONE1 = strRM28_ZONE(0)
                        strRM28_TELNO1 = strRM28_ZONE(1)
                    Else
                        strRM28_ZONE1 = ""
                        strRM28_TELNO1 = ""
                    End If
                    If Trim(dt.Rows(i)("wm_org_flag").ToString) = "2" Then
                        RM28_COMPANY_NO = Trim(dt.Rows(i)("wm_id").ToString)
                    Else

                        RM28_COMPANY_NO = ""
                    End If
                    strRM28_EXT1 = Trim(dt.Rows(i)("wm_tel_o2").ToString)

                    strRM28_ZONE2S = Trim(dt.Rows(i)("wm_tel_h").ToString).Split("-")
                    If Trim(dt.Rows(i)("wm_tel_h").ToString) <> "" Then
                        strRM28_ZONE2 = strRM28_ZONE2S(0)
                        strRM28_TELNO2 = strRM28_ZONE2S(1)
                    Else
                        strRM28_ZONE2 = ""
                        strRM28_TELNO2 = ""

                    End If

                    '1130205 add  RM28_CHK_CODE 判別
                    strCHKCode = "0"


                    If dt.Rows(i)("add_user").ToString = "9999" Then
                        strCHKCode = "9"
                    End If

                    strMsg = ""

                    '1130227 add querysaft03
                    If dt.Rows(i)("mh_gen_user").ToString <> "" Then
                        dtsaft03 = Bj.Querysaft03(dt.Rows(i)("mh_gen_user").ToString)
                        If dtsaft03.Rows.Count >= 1 Then
                            RM28_COMP = dtsaft03.Rows(0)("comp").ToString
                        Else
                            RM28_COMP = "1"
                        End If

                        dtsaft03 = Nothing
                    End If


                    '1130206 新增判斷，如同一天以最後一筆資料為主

                    rm28Data = Bj.QueryRM28(CInt(dt.Rows(i)("wm_house_no").ToString), CInt(Trim(dt.Rows(i)("appDate").ToString)))

                    If rm28Data.Rows.Count >= 1 Then
                        MisStr28 = " update  HSIN.RCPM28 set RM28_COMPANY='" & Trim(dt.Rows(i)("wm_user_o_name").ToString) & "'  "
                        MisStr28 &= " ,  RM28_COMPANY_NO ='" & RM28_COMPANY_NO & "'"
                        MisStr28 &= " ,  RM28_NAME ='" & Trim(dt.Rows(i)("wm_user_name").ToString) & "'"
                        MisStr28 &= " ,  RM28_EMAIL ='" & Trim(dt.Rows(i)("wm_email").ToString) & "'"
                        MisStr28 &= " ,  RM28_ZONE1 ='" & strRM28_ZONE1 & "'"
                        MisStr28 &= " ,  RM28_TELNO1 ='" & strRM28_TELNO1 & "'"
                        MisStr28 &= " ,  RM28_EXT1 ='" & strRM28_EXT1 & "'"
                        MisStr28 &= " ,  RM28_ZONE2 ='" & strRM28_ZONE2 & "'"
                        MisStr28 &= " ,  RM28_TELNO3 ='" & Trim(dt.Rows(i)("wm_mobile").ToString) & "'"

                        'MisStr28 &= " ,  RM28_GEN_DEPT ='" & Trim(dt.Rows(i)("mh_gen_dept").ToString) & "'"
                        'MisStr28 &= " ,  RM28_GEN_USER ='" & Trim(dt.Rows(i)("mh_gen_user").ToString) & "'"
                        '1130823 add 
                        If Trim(dt.Rows(i)("mh_gen_user").ToString) <> "0000" And Trim(dt.Rows(i)("mh_gen_user").ToString) <> "" Then
                            MisStr28 &= " ,  RM28_GEN_DEPT ='" & Trim(dt.Rows(i)("mh_gen_dept").ToString) & "'"
                            MisStr28 &= " ,  RM28_GEN_USER ='" & Trim(dt.Rows(i)("mh_gen_user").ToString) & "'"
                        Else
                            MisStr28 &= " ,  RM28_GEN_DEPT = null "
                            MisStr28 &= " ,  RM28_GEN_USER = null"
                        End If
                        MisStr28 &= " ,   RM28_COMP ='" & RM28_COMP & "'"
                        MisStr28 &= " ,  RM28_UPD_DATETIME = sysdate "
                        MisStr28 &= " Where RM28_HOUSE_NO ='" & Trim(dt.Rows(i)("wm_house_no").ToString) & "'  "
                        MisStr28 &= " and  RM28_APPL_DATE ='" & Trim(dt.Rows(i)("appDate").ToString) & "'  "
                        MisStr28 &= " and  RM28_SOURCE ='5'  "
                    Else
                        ''寫入RCPM28
                        MisStr28 = " Insert into  HSIN.RCPM28  (RM28_SEQ ,RM28_HOUSE_NO,RM28_TYPE,RM28_ID,"
                        MisStr28 &= " RM28_COMPANY,RM28_COMPANY_NO,RM28_NAME,RM28_EMAIL,"
                        MisStr28 &= " RM28_ZONE1,RM28_TELNO1,RM28_EXT1,RM28_ZONE2,RM28_TELNO2,"
                        MisStr28 &= " RM28_TELNO3,RM28_APPL_DATE,RM28_COMP,RM28_GEN_DEPT,RM28_GEN_USER,"
                        MisStr28 &= " RM28_SOURCE,RM28_USER_ID,RM28_UPD_DATETIME,RM28_OWNER_COMP,RM28_CHK_DATE,RM28_CHK_CODE)"
                        MisStr28 &= " values (  ft_uctt04('RCPM28', 'RM28_SEQ') , "
                        MisStr28 &= "'" & Trim(dt.Rows(i)("wm_house_no").ToString) & "','" & Trim(dt.Rows(i)("wm_org_flag")) & "','" & Trim(dt.Rows(i)("wm_id")) & "'"
                        MisStr28 &= ", '" & Trim(dt.Rows(i)("wm_user_o_name").ToString) & "','" & RM28_COMPANY_NO & "', '" & Trim(dt.Rows(i)("wm_user_name").ToString) & "' , '" & Trim(dt.Rows(i)("wm_email").ToString) & "'"
                        MisStr28 &= " , '" & strRM28_ZONE1 & "','" & strRM28_TELNO1 & "','" & strRM28_EXT1 & "','" & strRM28_ZONE2 & "','" & strRM28_TELNO2 & "'"
                        'MisStr28 &= " ,'" & Trim(dt.Rows(i)("wm_mobile").ToString) & "','" & Trim(dt.Rows(i)("appDate").ToString) & "','1','" & Trim(dt.Rows(i)("mh_gen_dept").ToString) & "','" & Trim(dt.Rows(i)("mh_gen_user").ToString) & "'"
                        'MisStr28 &= " ,'" & Trim(dt.Rows(i)("wm_mobile").ToString) & "','" & Trim(dt.Rows(i)("appDate").ToString) & "','" & RM28_COMP & "','" & Trim(dt.Rows(i)("mh_gen_dept").ToString) & "','" & Trim(dt.Rows(i)("mh_gen_user").ToString) & "'"
                        '1130823
                        MisStr28 &= " ,'" & Trim(dt.Rows(i)("wm_mobile").ToString) & "','" & Trim(dt.Rows(i)("appDate").ToString) & "','" & RM28_COMP & "','" & Trim(dt.Rows(i)("mh_gen_dept").ToString) '
                        If Trim(dt.Rows(i)("mh_gen_user").ToString) <> "0000" And Trim(dt.Rows(i)("mh_gen_user").ToString) <> "" Then
                            MisStr28 &= "','" & Trim(dt.Rows(i)("mh_gen_user").ToString) & "'"
                        Else
                            MisStr28 &= "',null"
                        End If
                        'MisStr28 &= " ,'5','9999',sysdate ,'1','" & transDate & "','0'"
                        MisStr28 &= " ,'5','9999',sysdate ,'1' ,'" & transDate & "','" & strCHKCode & "'"
                        MisStr28 &= ")"
                    End If
                    

                    Bj.ExecuteCom(MisStr28)
                    rm28Data.Dispose()
                    'strMsg = strMsg
                   
                    '*******1030120 mark case 3 (停權) 轉到跟5相同處理
                Case 3, 5
                    ' 判別 [update_type 異動別]為 (5) 刪除用戶號碼
                    ' 以用戶號碼 select , delete 此筆用戶的 appm64 資料
                    SqlStr = "Delete From HSIN.appm64 where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                    Bj.ExecuteCom(SqlStr)

                    Success = Success + 1

                    ' 將此會員記錄檔的 trans_type 改為 '1' 表示已更新完畢

                Case 6           '重寄授權碼不用到MIS
                Case 7           '發送未設用戶號碼通知不用轉到MIS
            End Select

            Select Case Trim(dt.Rows(i)("update_type"))
                Case 2, 3, 4, 5
                    SqlStr = "Update webmember_history Set trans_type='1' where mhis_no=" & dt.Rows(i)("mhis_no")
                    Bj.Insert(SqlStr)
                    ' 將此筆的trans_flag 改為 '1' 已轉入MIS
            End Select

            'Catch ex As Exception
            '    Failure = Failure + 1
            '    Str_temp_house_no = "000000" & Trim(dt.Rows(i)("wm_house_no"))
            '    Failure_house_string &= Right(Str_temp_house_no, 7) & " ; "



            'End Try
        Next
        Response.Redirect("member_trans_mis_result.aspx?skipCount=" & skipCount & "&skip_house_string=" & skip_house_string & "&Success=" & Success & "&Failure=" & Failure & "&TotalC=" & dt.Rows.Count & "&Failure_house_string=" & Failure_house_string)
    End Sub

End Class
