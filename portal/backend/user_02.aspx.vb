Public Class user_02
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents btnPrint As System.Web.UI.WebControls.Button
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
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
    Protected WithEvents OKbtn As System.Web.UI.WebControls.Button
    Protected WithEvents YETbtn As System.Web.UI.WebControls.Button

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
    Dim AppEDATE, AppSDATE, ProSdate, ProEdate, sendSDATE, sendEDATE As String
    Dim ReportServer As String = Configration.ReportServerURL

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        'add 1071026
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        ' objCartDT = CType(Session("Cart"), DataTable)
        If Not IsPostBack Then
            Call GetUser(context.User.Identity.Name.Trim)
            ApplySDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            ApplyEDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            ProcessSDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            ProcessEDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
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
        Dim se As New SelfReportDotDAO

        If applydateO.Checked = True Then
            ProSdate = "1900/01/01"
            ProEdate = "2099/12/31"
            Dim tmpAppEDATE As String = ApplyEDATE.Text.Trim
            Dim tmpAppSDATE As String = ApplySDATE.Text.Trim
            'AppEDATE = Left(tmpAppEDATE, 4) + "/" + Mid(tmpAppEDATE, 5, 2) + "/" + CType(CType(Right(tmpAppEDATE, 2), Integer), String)
            'AppSDATE = Left(tmpAppSDATE, 4) + "/" + Mid(tmpAppSDATE, 5, 2) + "/" + CType(CType(Right(tmpAppSDATE, 2), Integer), String) 'ApplySDATE.Text.Trim
            AppSDATE = Left(tmpAppSDATE, 4) + "/" + Mid(tmpAppSDATE, 5, 2) + "/" + CType(Right(tmpAppSDATE, 2), String) + " 00:00:00"
            AppEDATE = Left(tmpAppEDATE, 4) + "/" + Mid(tmpAppEDATE, 5, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"

            sendSDATE = AppSDATE
            sendEDATE = AppEDATE

            objCartDT = se.QueryDate(status.SelectedValue, AppSDATE, AppEDATE, "", "")
        Else
            AppSDATE = "1900/01/01"
            AppEDATE = "2099/12/31"
            ProSdate = ProcessSDATE.Text.Trim

            Dim tmpProEdate As String = ProcessEDATE.Text.Trim
            Dim tmpProSdate As String = ProcessSDATE.Text.Trim
            'ProEdate = Left(tmpProEdate, 4) + "/" + Mid(tmpProEdate, 5, 2) + "/" + CType(CType(Right(tmpProEdate, 2), Integer), String)
            'ProEdate = Left(tmpProSdate, 4) + "/" + Mid(tmpProSdate, 5, 2) + "/" + CType(CType(Right(tmpProSdate, 2), Integer), String)
            ProSdate = Left(tmpProSdate, 4) + "/" + Mid(tmpProSdate, 5, 2) + "/" + CType(Right(tmpProSdate, 2), String) + " 00:00:00"
            ProEdate = Left(tmpProEdate, 4) + "/" + Mid(tmpProEdate, 5, 2) + "/" + CType(Right(tmpProEdate, 2), String) + " 23:59:59"

            sendSDATE = ProSdate
            sendEDATE = ProEdate
            
            objCartDT = se.QueryDate(status.SelectedValue, "", "", ProSdate, ProEdate)
        End If

        ' Session("cart") = objCartDT
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If applydateO.Checked = True Then
            If ApplySDATE.Text.Trim = "" Or ApplyEDATE.Text.Trim = "" Then
                msgbox.Text = "請輸入申請日期!"
                Exit Sub
                'ElseIf ApplySDATE.Text.Trim <> "" And ApplyEDATE.Text.Trim = "" Then
                '    ApplyEDATE.Text = ApplySDATE.Text
            End If
        Else
            If ProcessSDATE.Text.Trim = "" Or ProcessEDATE.Text.Trim = "" Then
                msgbox.Text = "請輸入處理日期!"
                Exit Sub
                'ElseIf ProcessSDATE.Text.Trim <> "" And ProcessEDATE.Text.Trim = "" Then
                '    ProcessEDATE.Text = ProcessSDATE.Text
            End If
        End If

        msgbox.Text = ""
        dgCart.CurrentPageIndex = 0
        showData()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If applydateO.Checked = True Then
            If ApplySDATE.Text.Trim = "" Or ApplyEDATE.Text.Trim = "" Then
                msgbox.Text = "請輸入申請日期!"
                Exit Sub
            End If
        Else
            If ProcessSDATE.Text.Trim = "" Or ProcessEDATE.Text.Trim = "" Then
                msgbox.Text = "請輸入處理日期!"
                Exit Sub
            End If
        End If
        showData()
        msgbox.Text = ""

        If applydateO.Checked = True Then
            'Response.Redirect(ReportServer & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e8%87%aa%e5%a0%b1%e5%ba%a6%e6%95%b8%e4%b8%80%e8%a6%bd%e8%a1%a8&sendSDATE=" & sendSDATE & "&sendEDATE=" & sendEDATE & "&selectDate=" & "CreateTime" & "&STATUS =" & status.SelectedValue & "&rc:Parameters=false")
            Response.Redirect(ReportServer & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e8%87%aa%e5%a0%b1%e5%ba%a6%e6%95%b8%e4%b8%80%e8%a6%bd%e8%a1%a8&sendSDATE=" & sendSDATE & "&sendEDATE=" & sendEDATE & "&STATUS=" & status.SelectedValue & "&rc:Parameters=false")
        Else
            'Response.Redirect(ReportServer & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e8%87%aa%e5%a0%b1%e5%ba%a6%e6%95%b8%e4%b8%80%e8%a6%bd%e8%a1%a8&sendSDATE=" & sendSDATE & "&sendEDATE=" & sendEDATE & "&selectDate=" & "ProcessTime" & "&STATUS =" & status.SelectedValue & "&rc:Parameters=false")
            Response.Redirect(ReportServer & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e8%87%aa%e5%a0%b1%e5%ba%a6%e6%95%b8%e4%b8%80%e8%a6%bd%e8%a1%a82&sendSDATE=" & sendSDATE & "&sendEDATE=" & sendEDATE & "&STATUS=" & status.SelectedValue & "&rc:Parameters=false")
        End If

        'Response.Redirect(ReportServer & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e8%87%aa%e5%a0%b1%e5%ba%a6%e6%95%b8%e4%b8%80%e8%a6%bd%e8%a1%a8&AppSDATE=" & AppSDATE & "&AppEDATE=" & AppEDATE & "&ProSDATE=" & ProSdate & "&ProEDATE=" & ProEdate & "&STATUS=" & status.SelectedValue & "&rc:Parameters=false")

    End Sub

    Private Sub dgCart_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.EditCommand
        Me.YETbtn.Enabled = False
        Me.OKbtn.Enabled = False
        dgCart.EditItemIndex = e.Item.ItemIndex
        showData()
    End Sub

    Private Sub dgCart_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.CancelCommand
        Me.YETbtn.Enabled = True
        Me.OKbtn.Enabled = True
        dgCart.EditItemIndex = -1
        showData()
    End Sub

    Private Sub dgCart_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.UpdateCommand
        Dim status As CheckBox

        Dim EntityID As String
        Dim na As New SelfReportDotDAO

        EntityID = dgCart.DataKeys(e.Item.ItemIndex).ToString().Trim

        status = CType(e.Item.FindControl("txtstatus"), CheckBox)

        Dim nflag As String
        If status.Checked = True Then
            nflag = "1"
        Else
            nflag = "0"
        End If

        na.Update(EntityID, nflag, Creater.Text.Trim)

        dgCart.EditItemIndex = -1
        Call showData()
    End Sub

    Private Sub OKbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKbtn.Click
        Dim PageNum As Integer
        Dim PageTotalNum As Integer

        Dim i As Integer


        Dim selChkBxItem As CheckBox
        Dim selID As Label

        Dim objDataGridItem As DataGridItem
        For Each objDataGridItem In dgCart.Items
            selChkBxItem = objDataGridItem.FindControl("itemcheck")
            'selID = objDataGridItem.FindControl("AccountNo")
            selID = objDataGridItem.FindControl("EntityID")
            If selChkBxItem.Checked = True Then
                Dim sd As New SelfReportDotDAO

                Dim selID_content As String
                Dim selChkBxItem_content As String
                selID_content = selID.Text
                selChkBxItem_content = "1"

                sd.UpdatebyEntityID(selID_content, selChkBxItem_content, Creater.Text.Trim)

            End If
        Next
        showData()

    End Sub

    Private Sub YETbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YETbtn.Click
        Dim PageNum As Integer
        Dim PageTotalNum As Integer

        Dim i As Integer


        Dim selChkBxItem As CheckBox
        Dim selID As Label

        Dim objDataGridItem As DataGridItem
        For Each objDataGridItem In dgCart.Items
            selChkBxItem = objDataGridItem.FindControl("itemcheck")
            'selID = objDataGridItem.FindControl("AccountNo")
            selID = objDataGridItem.FindControl("EntityID")
            If selChkBxItem.Checked = False Then
                Dim sd As New SelfReportDotDAO

                Dim selID_content As String
                Dim selChkBxItem_content As String
                selID_content = selID.Text
                selChkBxItem_content = "0"

                sd.UpdatebyEntityID(selID_content, selChkBxItem_content)

            End If
        Next
        showData()
    End Sub
End Class
