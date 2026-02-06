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

            If Trim(dt.Rows(i)("update_type")) = "3" Then
                flag_update_type = "5"
            Else
                flag_update_type = Trim(dt.Rows(i)("update_type"))
            End If

            Try
                Select Case flag_update_type
                    Case 1          ' 會員註冊 (不需轉入)
                    Case 2          ' 判別 [update_type 異動別]為 (2) 會員資料修改
                        If (dt.Rows(i)("wm_tel_h") <> "-") Or (dt.Rows(i)("wm_tel_o") <> "-") Or (dt.Rows(i)("wm_tel_o2") <> "-") Or (dt.Rows(i)("wm_mobile") <> "-") Or (dt.Rows(i)("wm_email") <> "-") Then
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
                                If Trim(dt.Rows(i)("wm_tel_h")) <> "-" And Trim(dt.Rows(i)("wm_tel_h")) <> Trim(dtam01.Rows(0)("AM01_ZONE2")) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO2")) Then
                                    ' 更新 APPM01欄位, wm_tel_h <--> AM01_ZONE2 - AM01_TELNO2   (AX17_ZONE2 - AX17_TELNO2 , AX17_TEL2_C = 'V')
                                    tmp_flag_update = ""
                                    If (Trim(dt.Rows(i)("wm_tel_h")) <> "") Then
                                        MisStr01 &= " AM01_ZONE2='" & Left(dt.Rows(i)("wm_tel_h"), 2) & "', AM01_TELNO2='" & Right(dt.Rows(i)("wm_tel_h"), Len(dt.Rows(i)("wm_tel_h")) - 3) & "'"
                                    Else
                                        If (Trim(dtam01.Rows(0)("AM01_ZONE2")) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO2")) <> "-") Then
                                            MisStr01 &= " AM01_ZONE2='', AM01_TELNO2=''"
                                        Else
                                            tmp_flag_update = "N"
                                        End If
                                    End If
                                    If (tmp_flag_update <> "N") Then
                                        MisStr17_1 &= ", AX17_ZONE2 , AX17_TELNO2 , AX17_TEL2_C "
                                        MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_ZONE2") & "' , '" & dtam01.Rows(0)("AM01_TELNO2") & "' , 'V' "
                                    End If
                                    update_flag = "Y"
                                End If
                                If (Trim(dt.Rows(i)("wm_tel_o")) <> "-" And Trim(dt.Rows(i)("wm_tel_o")) <> Trim(dtam01.Rows(0)("AM01_ZONE1")) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO1"))) Or (Trim(dt.Rows(i)("wm_tel_o2")) <> "-" And Trim(dt.Rows(i)("wm_tel_o2")) <> Trim(dtam01.Rows(0)("AM01_EXT1"))) Then
                                    ' 更新 APPM01欄位, wm_tel_o <--> AM01_ZONE1 - AM01_TELNO1  , wm_tel_o2 <--> AM01_EXT1   (AX17_ZONE1 - AX17_TELNO1 # AX17_EXT1 , AX17_TEL1_C = 'V')
                                    ' MisStr01 &= " AM01_ZONE1='" & Left(dt.Rows(i)("wm_tel_o"), 2) & "', AM01_TELNO1='" & Right(dt.Rows(i)("wm_tel_o"), Len(dt.Rows(i)("wm_tel_o")) - 3) & "' , AM01_EXT1='" & dt.Rows(i)("wm_tel_o2") & "'"
                                    tmp_flag_update = ""
                                    If (Trim(dt.Rows(i)("wm_tel_o")) <> "-") Then
                                        If (Trim(dt.Rows(i)("wm_tel_o")) <> "") Then
                                            If MisStr01 <> "" Then
                                                MisStr01 &= ","
                                            End If
                                            MisStr01 &= " AM01_ZONE1='" & Left(dt.Rows(i)("wm_tel_o"), 2) & "', AM01_TELNO1='" & Right(dt.Rows(i)("wm_tel_o"), Len(dt.Rows(i)("wm_tel_o")) - 3) & "'"
                                        Else
                                            If (Trim(dtam01.Rows(0)("AM01_ZONE1")) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO1")) <> "-") Then
                                                If MisStr01 <> "" Then
                                                    MisStr01 &= ","
                                                End If
                                                MisStr01 &= " AM01_ZONE1='', AM01_TELNO1='' "
                                            Else
                                                tmp_flag_update = "N"
                                            End If
                                        End If
                                    End If
                                    If (Trim(dt.Rows(i)("wm_tel_o2")) <> "-") Then
                                        tmp_flag_update = "Y"
                                        If (Trim(dt.Rows(i)("wm_tel_o2")) <> "") Then
                                            If MisStr01 <> "" Then
                                                MisStr01 &= ","
                                            End If
                                            MisStr01 &= " AM01_EXT1='" & dt.Rows(i)("wm_tel_o2") & "'"
                                        Else
                                            If (Trim(dtam01.Rows(0)("AM01_EXT1")) <> "") Then
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
                                        MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_ZONE1") & "' , '" & dtam01.Rows(0)("AM01_TELNO1") & "', '" & dtam01.Rows(0)("AM01_EXT1") & "' , 'V' "
                                    End If
                                    update_flag = "Y"
                                End If
                                If Trim(dt.Rows(i)("wm_mobile")) <> "-" And Trim(dt.Rows(i)("wm_mobile")) <> Trim(dtam01.Rows(0)("AM01_TELNO3")) Then
                                    tmp_flag_update = ""

                                    ' 更新 APPM01欄位, wm_mobile<--> AM01_TELNO3  (AX17_TELNO3 , AX17_TEL3_C = 'V')

                                    If (Trim(dt.Rows(i)("wm_mobile")) <> "") Then
                                        If MisStr01 <> "" Then
                                            MisStr01 &= ","
                                        End If
                                        MisStr01 &= " AM01_TELNO3='" & dt.Rows(i)("wm_mobile") & "'"
                                    Else
                                        If (Trim(dtam01.Rows(0)("AM01_TELNO3")) <> "") Then
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
                                        MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_TELNO3") & "'  , 'V' "
                                    End If
                                    update_flag = "Y"
                                End If
                                If MisStr01 <> "" Then
                                    MisStr01 = "Update Appm01 Set " & MisStr01 & " Where  am01_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                                    Bj.ExecuteCom(MisStr01)           ' update appm01
                                End If

                                str_am01_total_no = Trim(dtam01.Rows(0)("AM01_TOTAL_NO"))
                                ' 第二步 , 以此用戶號碼,讀取 Appm48 , 判別不一樣, 則將appm48資料寫入appx17 , 再update appm48 若無此用戶資料 , 則新增一筆 appm48


                                ' 如果資料存在,則 update , 資料不存在則 insert
                                If dt.Rows(i)("wm_email") <> "-" And dt.Rows(i)("wm_email") <> "" Then

                                    Dim Am48 As New Batch_job
                                    NO01 = Trim(dt.Rows(i)("wm_house_no"))
                                    dtam48 = Am.QueryInformixappm48(NO01)
                                    If dtam48.Rows.Count = 1 Then
                                        ' 檢查 [wm_email 申請人郵寄地址] , 如果值不為 '-' and 不為 '' , 且值與 appm48 不同 , 則把 APPM48 有異動的值新增一筆到 appx17 ,只寫有異動的欄位 , 然後更新 appm48
                                        If dt.Rows(i)("wm_email") <> Trim(dtam48.Rows(0)("AM48_EMAIL")) Then
                                            ' 更新 APPM48 欄位, wm_email <--> am48_email   (AX17_EMAIL , AX17_EMAIL_C = 'V')
                                            MisStr48 = "Update Appm48 Set "
                                            MisStr48 &= " AM48_EMAIL='" & dt.Rows(i)("wm_email") & "'"
                                            MisStr48 &= " Where  am48_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"

                                            MisStr17_1 &= " , AX17_EMAIL , AX17_EMAIL_C "
                                            MisStr17_2 &= ", '" & dtam48.Rows(0)("AM48_EMAIL") & "'  , 'V' "
                                            update_flag = "Y"
                                            Bj.ExecuteCom(MisStr48)           ' update appm48
                                        End If
                                    Else
                                        ' appm48 無此用戶則新增一筆
                                        MisStr48 = "insert into Appm48 (am48_total_no ,am48_house_no , am48_email , am48_user_id,am48_upd_datetime)  "
                                        MisStr48 &= " values (" & str_am01_total_no & "," & Trim(dt.Rows(i)("wm_house_no")) & ",'" & dt.Rows(i)("wm_email") & "','9999',current ) "
                                        Bj.ExecuteCom(MisStr48)           ' insert appm48

                                        MisStr17_1 &= " , AX17_EMAIL , AX17_EMAIL_C "
                                        MisStr17_2 &= ", ''  , 'V' "
                                        update_flag = "Y"
                                    End If
                                End If
                                ' insert appx17 等 am01,am48 更新完再一起做
                                If (update_flag = "Y") Then
                                    MisStr17 = "insert into Appx17 ( ax17_house_no, ax17_input_dt   " & MisStr17_1 & ", ax17_de_user,ax17_user_id,ax17_update_dt,ax17_upd_datetime )  Values (" & Trim(dt.Rows(i)("wm_house_no")) & "," & transDate & MisStr17_2 & " ,'9999','9999'," & transDate & ",current)"
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
                    Case 3           '狀態異動不用轉到MIS
                    Case 4
                        ' 判別 [update_type 異動別]為 (4) 新增用戶號碼
                        ' update 用戶基資料, 同 [update_type 異動別]為 (2) 會員資料修改 的處理
                        If (dt.Rows(i)("wm_tel_h") <> "-") Or (dt.Rows(i)("wm_tel_o") <> "-") Or (dt.Rows(i)("wm_tel_o2") <> "-") Or (dt.Rows(i)("wm_mobile") <> "-") Or (dt.Rows(i)("wm_email") <> "-") Then
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
                                If Trim(dt.Rows(i)("wm_tel_h")) <> "-" And Trim(dt.Rows(i)("wm_tel_h")) <> Trim(dtam01.Rows(0)("AM01_ZONE2")) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO2")) Then
                                    ' 更新 APPM01欄位, wm_tel_h <--> AM01_ZONE2 - AM01_TELNO2   (AX17_ZONE2 - AX17_TELNO2 , AX17_TEL2_C = 'V')
                                    tmp_flag_update = ""
                                    If (Trim(dt.Rows(i)("wm_tel_h")) <> "") Then
                                        MisStr01 &= " AM01_ZONE2='" & Left(dt.Rows(i)("wm_tel_h"), 2) & "', AM01_TELNO2='" & Right(dt.Rows(i)("wm_tel_h"), Len(dt.Rows(i)("wm_tel_h")) - 3) & "'"
                                    Else
                                        If (Trim(dtam01.Rows(0)("AM01_ZONE2")) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO2")) <> "-") Then
                                            MisStr01 &= " AM01_ZONE2='', AM01_TELNO2=''"
                                        Else
                                            tmp_flag_update = "N"
                                        End If
                                    End If
                                    If (tmp_flag_update <> "N") Then
                                        MisStr17_1 &= ", AX17_ZONE2 , AX17_TELNO2 , AX17_TEL2_C "
                                        MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_ZONE2") & "' , '" & dtam01.Rows(0)("AM01_TELNO2") & "' , 'V' "
                                    End If
                                    update_flag = "Y"
                                End If
                                If (Trim(dt.Rows(i)("wm_tel_o")) <> "-" And Trim(dt.Rows(i)("wm_tel_o")) <> Trim(dtam01.Rows(0)("AM01_ZONE1")) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO1"))) Or (Trim(dt.Rows(i)("wm_tel_o2")) <> "-" And Trim(dt.Rows(i)("wm_tel_o2")) <> Trim(dtam01.Rows(0)("AM01_EXT1"))) Then
                                    ' 更新 APPM01欄位, wm_tel_o <--> AM01_ZONE1 - AM01_TELNO1  , wm_tel_o2 <--> AM01_EXT1   (AX17_ZONE1 - AX17_TELNO1 # AX17_EXT1 , AX17_TEL1_C = 'V')
                                    ' MisStr01 &= " AM01_ZONE1='" & Left(dt.Rows(i)("wm_tel_o"), 2) & "', AM01_TELNO1='" & Right(dt.Rows(i)("wm_tel_o"), Len(dt.Rows(i)("wm_tel_o")) - 3) & "' , AM01_EXT1='" & dt.Rows(i)("wm_tel_o2") & "'"
                                    tmp_flag_update = ""
                                    If (Trim(dt.Rows(i)("wm_tel_o")) <> "-") Then
                                        If (Trim(dt.Rows(i)("wm_tel_o")) <> "") Then
                                            If MisStr01 <> "" Then
                                                MisStr01 &= ","
                                            End If
                                            MisStr01 &= " AM01_ZONE1='" & Left(dt.Rows(i)("wm_tel_o"), 2) & "', AM01_TELNO1='" & Right(dt.Rows(i)("wm_tel_o"), Len(dt.Rows(i)("wm_tel_o")) - 3) & "'"
                                        Else
                                            If (Trim(dtam01.Rows(0)("AM01_ZONE1")) & "-" & Trim(dtam01.Rows(0)("AM01_TELNO1")) <> "-") Then
                                                If MisStr01 <> "" Then
                                                    MisStr01 &= ","
                                                End If
                                                MisStr01 &= " AM01_ZONE1='', AM01_TELNO1='' "
                                            Else
                                                tmp_flag_update = "N"
                                            End If
                                        End If
                                    End If
                                    If (Trim(dt.Rows(i)("wm_tel_o2")) <> "-") Then
                                        tmp_flag_update = "Y"
                                        If (Trim(dt.Rows(i)("wm_tel_o2")) <> "") Then
                                            If MisStr01 <> "" Then
                                                MisStr01 &= ","
                                            End If
                                            MisStr01 &= " AM01_EXT1='" & dt.Rows(i)("wm_tel_o2") & "'"
                                        Else
                                            If (Trim(dtam01.Rows(0)("AM01_EXT1")) <> "") Then
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
                                        MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_ZONE1") & "' , '" & dtam01.Rows(0)("AM01_TELNO1") & "', '" & dtam01.Rows(0)("AM01_EXT1") & "' , 'V' "
                                    End If
                                    update_flag = "Y"
                                End If
                                If Trim(dt.Rows(i)("wm_mobile")) <> "-" And Trim(dt.Rows(i)("wm_mobile")) <> Trim(dtam01.Rows(0)("AM01_TELNO3")) Then
                                    tmp_flag_update = ""

                                    ' 更新 APPM01欄位, wm_mobile<--> AM01_TELNO3  (AX17_TELNO3 , AX17_TEL3_C = 'V')

                                    If (Trim(dt.Rows(i)("wm_mobile")) <> "") Then
                                        If MisStr01 <> "" Then
                                            MisStr01 &= ","
                                        End If
                                        MisStr01 &= " AM01_TELNO3='" & dt.Rows(i)("wm_mobile") & "'"
                                    Else
                                        If (Trim(dtam01.Rows(0)("AM01_TELNO3")) <> "") Then
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
                                        MisStr17_2 &= ", '" & dtam01.Rows(0)("AM01_TELNO3") & "'  , 'V' "
                                    End If
                                    update_flag = "Y"
                                End If
                                If MisStr01 <> "" Then
                                    MisStr01 = "Update Appm01 Set " & MisStr01 & " Where  am01_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                                    Bj.ExecuteCom(MisStr01)           ' update appm01
                                End If

                                str_am01_total_no = Trim(dtam01.Rows(0)("AM01_TOTAL_NO"))
                                ' 第二步 , 以此用戶號碼,讀取 Appm48 , 判別不一樣, 則將appm48資料寫入appx17 , 再update appm48 若無此用戶資料 , 則新增一筆 appm48


                                ' 如果資料存在,則 update , 資料不存在則 insert
                                If dt.Rows(i)("wm_email") <> "-" And dt.Rows(i)("wm_email") <> "" Then

                                    Dim Am48 As New Batch_job
                                    NO01 = Trim(dt.Rows(i)("wm_house_no"))
                                    dtam48 = Am.QueryInformixappm48(NO01)
                                    If dtam48.Rows.Count = 1 Then
                                        ' 檢查 [wm_email 申請人郵寄地址] , 如果值不為 '-' and 不為 '' , 且值與 appm48 不同 , 則把 APPM48 有異動的值新增一筆到 appx17 ,只寫有異動的欄位 , 然後更新 appm48
                                        If dt.Rows(i)("wm_email") <> Trim(dtam48.Rows(0)("AM48_EMAIL")) Then
                                            ' 更新 APPM48 欄位, wm_email <--> am48_email   (AX17_EMAIL , AX17_EMAIL_C = 'V')
                                            MisStr48 = "Update Appm48 Set "
                                            MisStr48 &= " AM48_EMAIL='" & dt.Rows(i)("wm_email") & "'"
                                            MisStr48 &= " Where  am48_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"

                                            MisStr17_1 &= " , AX17_EMAIL , AX17_EMAIL_C "
                                            MisStr17_2 &= ", '" & dtam48.Rows(0)("AM48_EMAIL") & "'  , 'V' "
                                            update_flag = "Y"
                                            Bj.ExecuteCom(MisStr48)           ' update appm48
                                        End If
                                    Else
                                        ' appm48 無此用戶則新增一筆
                                        MisStr48 = "insert into Appm48 (am48_total_no ,am48_house_no , am48_email , am48_user_id,am48_upd_datetime)  "
                                        MisStr48 &= " values (" & str_am01_total_no & "," & Trim(dt.Rows(i)("wm_house_no")) & ",'" & dt.Rows(i)("wm_email") & "','9999',current ) "
                                        Bj.ExecuteCom(MisStr48)           ' insert appm48

                                        MisStr17_1 &= " , AX17_EMAIL , AX17_EMAIL_C "
                                        MisStr17_2 &= ", ''  , 'V' "
                                        update_flag = "Y"
                                    End If
                                End If
                                ' insert appx17 等 am01,am48 更新完再一起做
                                If (update_flag = "Y") Then
                                    MisStr17 = "insert into Appx17 ( ax17_house_no, ax17_input_dt   " & MisStr17_1 & ", ax17_de_user,ax17_user_id,ax17_update_dt,ax17_upd_datetime )  Values (" & Trim(dt.Rows(i)("wm_house_no")) & "," & transDate & MisStr17_2 & " ,'9999','9999'," & transDate & ",current)"
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

                        ' 先以用戶號碼 select appm64 , 如果存在則 update , 不存在則 insert
                        ' appm64->[am64_house_no	用戶號碼] , [am64_is_comm	是否為機關] ,[am64_receipt_paper	繳費憑證紙本]
                        '         [am64_receipt_mail	繳費憑證Mail],[am64_bill_paper	帳單紙本],[am64_bill_mail	帳單Mail]
                        '         [am64_user_id	異動人員],[am64_upd_datetime	異動時間]

                        SqlStr = "Select * from appm64 where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                        If Bj.GetMisDataIsRepeat(SqlStr) Then   '有
                            SqlStr = "Update Appm64 Set am64_upd_datetime=current where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
                        Else                                    '無
                            SqlStr = "Insert into Appm64(am64_house_no,am64_is_comm,am64_receipt_paper,am64_receipt_email,am64_bill_paper,am64_bill_email,am64_user_id,am64_upd_datetime) "
                            SqlStr &= " Values(" & dt.Rows(i)("wm_house_no") & ",'" & dt.Rows(i)("wm_org_flag") & "','" & dt.Rows(i)("wm_paper_flag") & "','Y','N','N','9999',current)"   ' & Format(Now, "yyyy/MM/dd HH:mm:ss") & "')"
                        End If
                        Bj.ExecuteCom(SqlStr)

                    Case 5
                        ' 判別 [update_type 異動別]為 (5) 刪除用戶號碼
                        ' 以用戶號碼 select , delete 此筆用戶的 appm64 資料
                        SqlStr = "Delete From appm64 where am64_house_no='" & Trim(dt.Rows(i)("wm_house_no")) & "'"
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

            Catch ex As Exception
                Failure = Failure + 1
                Str_temp_house_no = "000000" & Trim(dt.Rows(i)("wm_house_no"))
                Failure_house_string &= Right(Str_temp_house_no, 7) & " ; "
            End Try
        Next
        Response.Redirect("member_trans_mis_result.aspx?skipCount=" & skipCount & "&skip_house_string=" & skip_house_string & "&Success=" & Success & "&Failure=" & Failure & "&TotalC=" & dt.Rows.Count & "&Failure_house_string=" & Failure_house_string)
    End Sub

End Class
