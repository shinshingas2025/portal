Public Class member_manageMgtAdd
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents inquire As System.Web.UI.WebControls.Button
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdata_ym As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtaction As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lbluser_id As System.Web.UI.WebControls.Label
    Protected WithEvents lbluser_name As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_no As System.Web.UI.WebControls.Label
    Protected WithEvents lbladd_datetime As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_org_flag As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_user_o_name As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_tel_o As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_tel_h As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_mobile As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_email As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_id As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_user_name As System.Web.UI.WebControls.Label
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents lblAddress As System.Web.UI.WebControls.Label
    Protected WithEvents txtHouse_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSelect As System.Web.UI.WebControls.Button
    Protected WithEvents btnReturn As System.Web.UI.WebControls.Button
    Protected WithEvents txtGenUser As System.Web.UI.WebControls.TextBox
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
    Dim objCartDT As DataTable
    Dim userID As String
    Dim flag As Boolean
    Public gorg As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim swm_no As Integer
        Dim se As New MemberManageBO
        Dim dt As New DataTable

        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        '取得使用者登入帳號
        userID = context.User.Identity.Name
        'userID = "cadmin"

        flag = False
        If Not IsPostBack Then
            swm_no = Request("wm_no").Trim
            dt = se.UserQuery("", "", "wm_no", swm_no.ToString.Trim)
            lblwm_no.Text = CType(dt.Rows(0).Item("wm_no"), String)
            gorg = CType(dt.Rows(0).Item("wm_org_flag"), String)
            lblwm_org_flag.Text = CType(dt.Rows(0).Item("wm_org_flag_name"), String) & "用戶"
            If gorg <> 1 Then
                lblwm_user_o_name.Text = CType(dt.Rows(0).Item("wm_user_o_name"), String)
            End If
            lblwm_id.Text = CType(dt.Rows(0).Item("wm_id"), String)
            lblwm_user_name.Text = CType(dt.Rows(0).Item("wm_user_name"), String)
            lblwm_mobile.Text = CType(dt.Rows(0).Item("wm_mobile"), String)
            lblwm_tel_o.Text = CType(dt.Rows(0).Item("wm_tel_o"), String)
            lblwm_tel_h.Text = CType(dt.Rows(0).Item("wm_tel_h"), String)
            lblwm_email.Text = CType(dt.Rows(0).Item("wm_email"), String)
            lbladd_datetime.Text = CType(dt.Rows(0).Item("add_datetime"), String)

            Call showData()
        End If
        objCartDT = CType(Session("Cart"), DataTable)
    End Sub

    '查詢資料(第一次登入時用)
    Sub showData()
        Dim se As New MemberManageMgtAddBO
        Dim dt As DataTable
        Dim i As Integer
        Dim j As Integer
        Dim strAddress As String

        objCartDT = se.Query(lblwm_no.Text)
        If objCartDT.Rows.Count > 0 Then
            For i = 0 To objCartDT.Rows.Count - 1
                dt = se.QueryHouseName(objCartDT.Rows(i).Item("mh_house_no")).Tables(0)
                If dt.Rows.Count > 0 Then
                    For j = 0 To dt.Rows.Count - 1
                        objCartDT.Rows(i).Item("user_name") = dt.Rows(j).Item("am01_name")
                        strAddress = ""
                        strAddress = se.GetCanton(dt.Rows(j).Item("am01_canton")).Trim
                        strAddress &= se.GetStreet(dt.Rows(j).Item("am01_canton"), dt.Rows(j).Item("am01_street")).Trim

                        If dt.Rows(j).Item("am01_section") <> 0 Then
                            strAddress &= dt.Rows(j).Item("am01_section") & "段"
                        End If
                        If dt.Rows(j).Item("am01_lane") <> 0 Then
                            strAddress &= dt.Rows(j).Item("am01_lane") & "巷"
                        End If
                        If dt.Rows(j).Item("am01_alley") <> 0 Then
                            strAddress &= dt.Rows(j).Item("am01_alley") & "弄"
                        End If
                        If CType(dt.Rows(j).Item("am01_number"), String).Trim <> "" Then
                            strAddress &= CType(dt.Rows(j).Item("am01_number"), String).Trim & ""
                        End If
                        'modify 1120607 
                        'If dt.Rows(j).Item("am01_number2") <> 0 Then
                        If dt.Rows(j).Item("am01_number2").ToString <> "" And dt.Rows(j).Item("am01_number2").ToString <> "0" Then
                            strAddress &= dt.Rows(j).Item("am01_dash") & ""
                            strAddress &= dt.Rows(j).Item("am01_number2")
                            strAddress &= "號"
                        Else
                            strAddress &= "號"
                        End If
                        'If dt.Rows(j).Item("am01_sub_no") <> 0 Then
                        If dt.Rows(j).Item("am01_sub_no").ToString <> "" And dt.Rows(j).Item("am01_sub_no").ToString <> "0" Then
                            strAddress &= "之" & dt.Rows(j).Item("am01_sub_no")
                            If CType(dt.Rows(j).Item("am01_floor").ToString, String).Trim <> "" Then
                                strAddress &= ", "
                            End If
                        End If

                        If dt.Rows(j).Item("am01_floor").ToString <> "" Then
                            If Left$(dt.Rows(j).Item("am01_floor").ToString, 1) = "T" Then
                                strAddress &= "頂樓"
                            ElseIf Left$(dt.Rows(j).Item("am01_floor").ToString, 1) = "B" Then
                                strAddress &= "地下" & CType(Right$(dt.Rows(j).Item("am01_floor").ToString, dt.Rows(j).Item("am01_floor").ToString.Length - 1), String).Trim & "樓"
                            Else
                                strAddress &= CType(dt.Rows(j).Item("am01_floor").ToString, String).Trim & "樓"
                            End If

                        End If
                        If dt.Rows(j).Item("am01_room").ToString <> "" Then
                            If CType(dt.Rows(j).Item("am01_room"), String).Trim <> "" Then
                                strAddress &= "之" & CType(dt.Rows(j).Item("am01_room").ToString, String).Trim
                            End If
                        End If

                        objCartDT.Rows(i).Item("user_addr") = strAddress
                    Next
                End If
            Next
        End If

        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub

    Private Sub NavigateToPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim PageInfo As String = CType(sender, Button).CommandName
        Select Case PageInfo
            Case "第一頁"
                dgCart.CurrentPageIndex = 0
            Case "上一頁"
                If (dgCart.CurrentPageIndex > 0) Then
                    dgCart.CurrentPageIndex -= 1
                End If
            Case "下一頁"
                If (dgCart.CurrentPageIndex < (dgCart.PageCount - 1)) Then
                    dgCart.CurrentPageIndex += 1
                End If
            Case "最後一頁"
                dgCart.CurrentPageIndex = (dgCart.PageCount - 1)
        End Select
        Call showData()
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

#Region "新增按鍵"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim se As New MemberManageMgtAddBO
        Dim cn As New Memberhouse
        Dim dt As DataTable
        Dim result As Integer = 0

        txtResult.Text = ""

        If Trim(txtHouse_no.Text) = "" Then
            txtResult.Text = "用戶號碼不能為空白"
            Exit Sub
        End If
        If IsNumeric(txtHouse_no.Text) = False Then
            txtResult.Text = "用戶號碼只能為數字"
            txtHouse_no.Text = ""
            Exit Sub
        End If
        txtHouse_no.Text = Right("0000000" & txtHouse_no.Text.Trim, 7)
        dt = se.QueryHouseName(txtHouse_no.Text.Trim).Tables(0)
        If dt.Rows.Count > 0 Then
            '判斷條件
            If gorg = 1 Then
                If Trim(dt.Rows(0).Item("am01_company_no")) <> "" Then
                    txtResult.Text = "此用戶號碼為營業用戶，不可新增!"
                    txtHouse_no.Text = ""
                    lblName.Text = ""
                    lblAddress.Text = ""
                    Exit Sub
                End If
            End If
            If gorg = 2 Then
                If Trim(dt.Rows(0).Item("am01_company_no")) = "" Then
                    txtResult.Text = "此用戶號碼為個人用戶，不可新增!"
                    txtHouse_no.Text = ""
                    lblName.Text = ""
                    lblAddress.Text = ""
                    Exit Sub
                End If
            End If
            'If (dt.Rows(0).Item("am01_post_type") = "**" Or Trim(dt.Rows(0).Item("am01_post_type")) = "") Or dt.Rows(0).Item("am01_post_stop") > dt.Rows(0).Item("am01_post_start") Then
            '    txtResult.Text = "目前僅提供郵局、銀行代扣繳用戶申請"
            '    txtHouse_no.Text = ""
            '    lblName.Text = ""
            '    lblAddress.Text = ""
            '    Exit Sub
            'End If

            If se.GetDetailHouseNoIsRepeat(txtHouse_no.Text) = 0 Then
                cn.mh_wm_no = lblwm_no.Text.Trim
                cn.mh_house_no = txtHouse_no.Text.Trim
                cn.mh_ers_flag = "N"
                cn.upd_user = Session("UserName").Trim
                cn.mh_gen_user = txtGenUser.Text.Trim  'add 
                cn.mh_gen_dept = se.getDeptCode(txtGenUser.Text.Trim) ' add 1121117 
                result = se.Insert(cn)
                If result = 1 Then
                    txtResult.Text = "新增成功!"
                Else
                    txtResult.Text = "新增失敗,請再試一次!"
                End If

                lblName.Text = ""
                lblAddress.Text = ""
                txtHouse_no.Text = ""
                Call showData()
            Else
                txtResult.Text = "此用戶號碼已存在，無法重覆建檔"
            End If
        End If

    End Sub
#End Region


#Region "查詢按鍵"
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        ReadAddress()
    End Sub
#End Region

#Region "ReadAddress　讀取Informix的姓名,地址"
    Function ReadAddress()
        Dim se As New MemberManageMgtAddBO
        Dim dt As DataTable
        Dim strAddress As String = ""

        txtResult.Text = ""

        '判斷條件
        If Trim(txtHouse_no.Text) = "" Then
            txtResult.Text = "用戶號碼不能為空白"
            Exit Function
        End If
        If IsNumeric(txtHouse_no.Text) = False Then
            txtResult.Text = "用戶號碼只能為數字"
            txtHouse_no.Text = ""
            Exit Function
        End If
        txtHouse_no.Text = Right("0000000" & txtHouse_no.Text.Trim, 7)
        dt = se.QueryHouseName(txtHouse_no.Text.Trim).Tables(0)
        If dt.Rows.Count > 0 Then
            '判斷條件
            If gorg = 1 Then
                If Trim(dt.Rows(0).Item("am01_company_no")) <> "" Then
                    txtResult.Text = "此用戶號碼為營業用戶，不可新增!"
                    txtHouse_no.Text = ""
                    lblName.Text = ""
                    lblAddress.Text = ""
                    Exit Function
                End If
            End If
            If gorg = 2 Then
                If Trim(dt.Rows(0).Item("am01_company_no")) = "" Then
                    txtResult.Text = "此用戶號碼為個人用戶，不可新增!"
                    txtHouse_no.Text = ""
                    lblName.Text = ""
                    lblAddress.Text = ""
                    Exit Function
                End If
            End If
            'If (dt.Rows(0).Item("am01_post_type").ToString = "**" Or Trim(dt.Rows(0).Item("am01_post_type").ToString) = "") Or dt.Rows(0).Item("am01_post_stop").ToString > dt.Rows(0).Item("am01_post_start").ToString Then
            '    txtResult.Text = "目前僅提供郵局、銀行代扣繳用戶申請"
            '    txtHouse_no.Text = ""
            '    lblName.Text = ""
            '    lblAddress.Text = ""
            '    Exit Function
            'End If


            strAddress = se.GetCanton(dt.Rows(0).Item("am01_canton").ToString).Trim
            strAddress &= se.GetStreet(dt.Rows(0).Item("am01_canton").ToString, dt.Rows(0).Item("am01_street")).Trim

            If dt.Rows(0).Item("am01_section") <> 0 Then
                strAddress &= dt.Rows(0).Item("am01_section") & "段"
            End If
            If dt.Rows(0).Item("am01_lane") <> 0 Then
                strAddress &= dt.Rows(0).Item("am01_lane") & "巷"
            End If
            If dt.Rows(0).Item("am01_alley") <> 0 Then
                strAddress &= dt.Rows(0).Item("am01_alley") & "弄"
            End If
            If CType(dt.Rows(0).Item("am01_number").ToString, String).Trim <> "" Then
                strAddress &= CType(dt.Rows(0).Item("am01_number"), String).Trim & ""
            End If
            'If dt.Rows(0).Item("am01_number2") <> 0 Then

            '1120607 
            If dt.Rows(0).Item("am01_number2").ToString <> "" And dt.Rows(0).Item("am01_number2").ToString <> "0" Then
                strAddress &= dt.Rows(0).Item("am01_dash") & ""
                strAddress &= dt.Rows(0).Item("am01_number2")
                strAddress &= "號"
            Else
                strAddress &= "號"
            End If
            'If dt.Rows(0).Item("am01_sub_no") <> 0 Then
            If dt.Rows(0).Item("am01_sub_no").ToString <> "" And dt.Rows(0).Item("am01_sub_no").ToString <> "0" Then
                strAddress &= "之" & dt.Rows(0).Item("am01_sub_no")
                If CType(dt.Rows(0).Item("am01_floor").ToString, String).Trim <> "" Then
                    strAddress &= ", "
                End If
            End If

            If CType(dt.Rows(0).Item("am01_floor").ToString, String).Trim <> "" Then
                If Left$(dt.Rows(0).Item("am01_floor").ToString, 1) = "T" Then
                    strAddress &= "頂樓"
                ElseIf Left$(dt.Rows(0).Item("am01_floor").ToString, 1) = "B" Then
                    strAddress &= "地下" & CType(Right$(dt.Rows(0).Item("am01_floor").ToString, dt.Rows(0).Item("am01_floor").ToString.Length - 1), String).Trim & "樓"
                Else
                    strAddress &= CType(dt.Rows(0).Item("am01_floor").ToString, String).Trim & "樓"
                End If

            End If
            If CType(dt.Rows(0).Item("am01_room").ToString & "", String).Trim <> "" Then
                strAddress &= "之" & CType(dt.Rows(0).Item("am01_room"), String).Trim
            End If

            lblName.Text = dt.Rows(0).Item("am01_post_name").ToString & ""
            lblAddress.Text = strAddress
            btnAdd.Visible = True

        Else
            lblName.Text = ""
            lblAddress.Text = ""
            txtHouse_no.Text = ""
            txtResult.Text = "查無資料"
        End If
    End Function
#End Region

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("member_manage.aspx")
    End Sub
End Class
