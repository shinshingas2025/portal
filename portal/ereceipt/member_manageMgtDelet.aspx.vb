Public Class member_manageMgtDelet
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
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents wm_no As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_no As System.Web.UI.WebControls.Label
    Protected WithEvents txtmhis_memo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnReturn As System.Web.UI.WebControls.Button

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
                        'If dt.Rows(j).Item("am01_number2") <> 0 Then
                        'modify 1120607 
                        If dt.Rows(j).Item("am01_number2").ToString <> "" And dt.Rows(j).Item("am01_number2").ToString <> "0" Then
                            strAddress &= dt.Rows(j).Item("am01_dash") & ""
                            strAddress &= dt.Rows(j).Item("am01_number2")
                            strAddress &= "號"
                        Else
                            strAddress &= "號"
                        End If
                        ' If dt.Rows(j).Item("am01_sub_no") <> 0 Then
                        If dt.Rows(j).Item("am01_sub_no").ToString <> "" And dt.Rows(j).Item("am01_sub_no").ToString <> "0" Then
                            strAddress &= "之" & dt.Rows(j).Item("am01_sub_no")
                            If CType(dt.Rows(j).Item("am01_floor").ToString, String).Trim <> "" Then
                                strAddress &= ", "
                            End If
                        End If

                        If CType(dt.Rows(j).Item("am01_floor").ToString, String).Trim <> "" Then
                            If Left$(dt.Rows(j).Item("am01_floor"), 1) = "T" Then
                                strAddress &= "頂樓"
                            ElseIf Left$(dt.Rows(j).Item("am01_floor"), 1) = "B" Then
                                strAddress &= "地下" & CType(Right$(dt.Rows(j).Item("am01_floor"), dt.Rows(j).Item("am01_floor").length - 1), String).Trim & "樓"
                            Else
                                strAddress &= CType(dt.Rows(j).Item("am01_floor"), String).Trim & "樓"
                            End If

                        End If
                        If dt.Rows(j).Item("am01_room").ToString <> "" Then
                            If CType(dt.Rows(j).Item("am01_room"), String).Trim <> "" Then
                                strAddress &= "之" & CType(dt.Rows(j).Item("am01_room"), String).Trim
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

#Region "刪除按鍵"
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim se As New MemberManageMgtAddBO
        Dim smh_no As String
        Dim shouse_no As String
        Dim swm_no As Integer
        Dim smhis_memo As String
        Dim supd_user As String
        Dim result As Integer = 0
        Dim selChkBxItem As CheckBox
        Dim selMhNo As Label
        Dim selHouseNo As Label
        Dim objDataGridItem As DataGridItem
        Dim checkRSmh_no As String = ""
        Dim checkRShouse_no As String = ""

        txtResult.Text = ""
        '讀取選取

        For Each objDataGridItem In dgCart.Items
            '在DataGrid物件中依序找出所要的Item(itemcheck & mh_house_no)==>自訂的樣板
            selChkBxItem = objDataGridItem.FindControl("itemcheck")
            selMhNo = objDataGridItem.FindControl("mh_no")
            selHouseNo = objDataGridItem.FindControl("mh_house_no")
            '判斷找出來的checkBox是否有被選取並作處理
            If selChkBxItem.Checked = True Then 'CheckBox有被選取
                checkRSmh_no += selMhNo.Text & ","
                checkRShouse_no += selHouseNo.Text & ","
            End If
        Next
        If checkRSmh_no <> "" Then
            smh_no = checkRSmh_no.Substring(0, checkRSmh_no.Length - 1)
            shouse_no = checkRShouse_no.Substring(0, checkRShouse_no.Length - 1)
            swm_no = lblwm_no.Text.Trim
            smhis_memo = txtmhis_memo.Text.Trim
            supd_user = Session("UserName").Trim
        End If

        If smh_no <> "" Then
            result = se.SelectDelete(smh_no, shouse_no, swm_no, smhis_memo, supd_user)
            If result = 1 Then
                txtResult.Text = "刪除成功!"
                txtmhis_memo.Text = ""
            Else
                txtResult.Text = "刪除失敗,請再試一次!"
            End If
            Call showData()
        Else
            txtResult.Text = "請先勾選要取消指派的人!!"
        End If
    End Sub
#End Region


    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("member_manage.aspx")
    End Sub
End Class
