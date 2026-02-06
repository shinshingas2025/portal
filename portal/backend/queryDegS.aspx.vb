Public Class queryDegS
    Inherits System.Web.UI.Page
    Dim objCartDT As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If

        If Not IsPostBack Then
            Call GetUser(Context.User.Identity.Name.Trim)
            txtYM.Text = CType(Year(Now) - 1911, String) + Right("00" + CType(Month(Now), String), 2)
        End If
        dgCart.CurrentPageIndex = 0
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtYM.Text = "" Then
            msgbox.Text = "請輸入處理日期!"
            Exit Sub
        Else
            If VolNoS.Text.Trim = "" Or VolNoE.Text.Trim = "" Then
                msgbox.Text = "請輸入冊別!"
                Exit Sub
            End If
        End If


        msgbox.Text = ""
        showData()
    End Sub
    Sub showData()
        Dim se As New QDegDAO

        Dim strYYMM As String = ""
        Dim strVolS As String = ""
        Dim strVolE As String = ""

        strYYMM = txtYM.Text
        strVolS = VolNoS.Text.Trim.ToUpper
        strVolE = VolNoE.Text.Trim.ToUpper
        
        objCartDT = se.QueryDate(strYYMM, strVolS, strVolE)

        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        If objCartDT.Rows.Count > 0 Then
            dgCart.DataBind()
            ShowPageStatus(objCartDT.Rows.Count)
        Else
            dgCart.DataBind()
            msgbox.Text = "查無資料!"
        End If
        'msgbox.Text = objCartDT.Rows.Count & "　查無資料!"
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub
End Class