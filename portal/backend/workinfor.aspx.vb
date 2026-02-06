Public Class workinfor
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents txtsubject As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwkdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmember As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcontroler As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents txtdbworkgrp As System.Web.UI.WebControls.Label
    Protected WithEvents txtworkgrp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents workaddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwktime As System.Web.UI.WebControls.TextBox
    Protected WithEvents checker As System.Web.UI.WebControls.TextBox
    Protected WithEvents tel As System.Web.UI.WebControls.TextBox
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents SDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents EDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents provider As System.Web.UI.WebControls.DropDownList
    Protected WithEvents modifierGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Modifier As System.Web.UI.WebControls.Label
    Protected WithEvents txtwkdateend As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwktimeend As System.Web.UI.WebControls.TextBox

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網
        Dim it As New item
        Dim wk As New WorkBO
        Dim dt As New DataTable
        Dim urlworkno As String
        If Not IsPostBack Then
            Call GetDept()


        End If

        urlworkno = Request("workno")
        If urlworkno Is Nothing Then
            'Call GetUser(context.User.Identity.Name.Trim)
            objCartDT = CType(Session("Cart"), DataTable)
            If Not IsPostBack Then
                With Me.txtworkgrp
                    .DataSource = it.GetSelectStr("txtworkgroup", "WORK")
                    .DataTextField = "it_name"
                    .DataValueField = "no"
                    .DataBind()
                End With
                txtdbworkgrp.Text = ""
                Call showData()
            End If
        Else

            If Not IsPostBack Then
                With Me.txtworkgrp
                    Dim LI As New ListItem("")
                    .DataSource = it.GetSelectStr("txtworkgroup", "WORK")
                    .DataTextField = "it_name"
                    .DataValueField = "no"
                    .DataBind()
                    .Items.Insert(0, LI)
                End With
                dt = wk.Query(urlworkno)
                txtdbworkgrp.Text = "目前項目:" & it.GetNameStr(CType(dt.Rows(0).Item("workgroup"), String), "WORK") & "(若無需修改項目則可不選擇)<br>"
                txtsubject.Text = CType(dt.Rows(0).Item("worksubject"), String)
                txtwkdate.Text = CType(Year(CType(dt.Rows(0).Item("workwkdate"), Date)), String) & "/" & Right("0" & CType(Month(CType(dt.Rows(0).Item("workwkdate"), Date)), String), 2) & "/" & Right("0" & CType(Day(CType(dt.Rows(0).Item("workwkdate"), Date)), String), 2)
                txtwktime.Text = CType(dt.Rows(0).Item("workwktime"), String)

                If dt.Rows(0).Item("workwkdateend") <> "" Then
                    txtwkdateend.Text = CType(Year(CType(dt.Rows(0).Item("workwkdateend"), Date)), String) & "/" & Right("0" & CType(Month(CType(dt.Rows(0).Item("workwkdateend"), Date)), String), 2) & "/" & Right("0" & CType(Day(CType(dt.Rows(0).Item("workwkdateend"), Date)), String), 2)
                End If
                If dt.Rows(0).Item("workwktimeend") <> "" Then
                    txtwktimeend.Text = CType(dt.Rows(0).Item("workwktimeend"), String)
                End If

                txtmember.Text = CType(dt.Rows(0).Item("workmember"), String)
                workaddress.Text = CType(dt.Rows(0).Item("workaddress"), String)
                txtcontroler.Text = CType(dt.Rows(0).Item("workcontroler"), String)
                tel.Text = CType(dt.Rows(0).Item("tel"), String)
                checker.Text = CType(dt.Rows(0).Item("checker"), String)
                SDATE.Text = CType(Year(CType(dt.Rows(0).Item("sdate"), Date)), String) & "/" & Right("0" & CType(Month(CType(dt.Rows(0).Item("sdate"), Date)), String), 2) & "/" & Right("0" & CType(Day(CType(dt.Rows(0).Item("sdate"), Date)), String), 2)
                EDATE.Text = CType(Year(CType(dt.Rows(0).Item("EDATE"), Date)), String) & "/" & Right("0" & CType(Month(CType(dt.Rows(0).Item("EDATE"), Date)), String), 2) & "/" & Right("0" & CType(Day(CType(dt.Rows(0).Item("EDATE"), Date)), String), 2)
                viewstate("Creater") = CType(dt.Rows(0).Item("creater"), String)
                provider.SelectedValue = CType(dt.Rows(0).Item("provider"), String).Trim
                viewstate("modifier") = dt.Rows(0).Item("modifier")
                If Not IsDBNull(viewstate("Creater")) Then
                    Call GetUserDep(viewstate("Creater"), 1)
                End If
                If Not IsDBNull(viewstate("modifier")) Then
                    Call GetUserDep(viewstate("Creater"), 2)
                End If
                'Call GetUser(viewstate("Creater"))
            End If
            'Call showData()
            End If
    End Sub
    Private Function checkFields() As Boolean
        txtResult.Text = ""
        If IsDate(SDATE.Text) = False Or IsDate(EDATE.Text) = False Then
            txtResult.Text = "上下架日期格式不正確!"
            Return False
        End If

        If CType(SDATE.Text, Date) > CType(EDATE.Text, Date) Then
            txtResult.Text = "起始日不可大於終止日!"
            Return False
        End If

        Return True

    End Function
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

    Private Sub GetDept()
        Dim objDO As New DeptDAO
        Dim dt As DataTable
        dt = objDO.GetDeptList.Tables(0)
        Dim i As Integer
        provider.Items.Clear()

        Dim objlistItem1 As New ListItem
        objlistItem1.Text = ""
        objlistItem1.Value = ""
        provider.Items.Add(objlistItem1)

        For i = 0 To dt.Rows.Count - 1
            Dim objlistItem As New ListItem
            objlistItem.Text = CType(dt.Rows(i).Item("DeptName"), String)
            objlistItem.Value = CType(dt.Rows(i).Item("DeptID"), String)
            provider.Items.Add(objlistItem)


        Next i


    End Sub

    Private Sub GetUserDep(ByVal user As String, ByVal num As Integer)
        Dim objUser As New UserInfoBO
        'Dim objDeptBO As New OrgBO
        Dim objvUserInfoBO As New vUserInfoBO
        Dim objDept As New DeptExtendOrgEntity
        Dim dt As New DataTable
        '顯示處理人員名稱
        dt = objUser.QueryUserInfo(user)
        If dt.Rows.Count > 0 Then
            objDept.DeptID = dt.Rows(0).Item("Dept")
            Select Case num
                Case 1
                    Creater.Text = dt.Rows(0).Item("Cname")
                Case 2
                    Modifier.Text = dt.Rows(0).Item("Cname")
            End Select

            '顯示執行單位
            'dt = objDeptBO.QueryDept(objDept)
            dt = objvUserInfoBO.QueryUnit(user)
            If dt.Rows.Count > 0 Then
                '從"組織結構"讀取單位名稱                
                'createGroup.Text = dt.Rows(0).Item("objname")


                '從"帳號管理"讀取單位名稱
                Select Case num
                    Case 1
                        createGroup.Text = dt.Rows(0).Item("GroupName")
                    Case 2
                        modifierGroup.Text = dt.Rows(0).Item("GroupName")
                End Select
            End If
        End If

    End Sub

    Sub dgCart_Update(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim txtsubject As TextBox
        Dim txtcontent As TextBox
        Dim txtenddate As TextBox
        Dim workno As String
        Dim ac As New Enwork

        Dim sc As New WorkBO

        workno = dgCart.DataKeys(e.Item.ItemIndex).ToString()
        txtsubject = CType(e.Item.Cells(0).Controls(0), TextBox)
        txtcontent = CType(e.Item.Cells(1).Controls(0), TextBox)
        txtenddate = CType(e.Item.Cells(2).Controls(0), TextBox)

        For Each objDR In objCartDT.Rows
            If Trim(CType(objDR("workno"), String)) = workno.Trim Then
                ac.worksubject = txtsubject.Text.Trim
                ' ac.iforcontent = txtcontent.Text.Trim
                ac.workdate = txtenddate.Text
                ac.workno = workno
                sc.Update(ac)
                Exit For
            End If
        Next

        dgCart.EditItemIndex = -1
        Call showData()

    End Sub

    Sub showData()
        Dim se As New WorkBO
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New WorkBO
        Dim workno As String
        workno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        sc.Delete(workno)
        txtResult.Text = "刪除成功!"
        Call showData()

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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If checkFields() = False Then
            Exit Sub
        End If
        Dim cm As New WorkBO
        Dim cn As New Enwork
        cn.workgroup = txtworkgrp.SelectedValue.ToString
        cn.worksubject = txtsubject.Text.Trim
        cn.workwkdate = txtwkdate.Text.Trim
        cn.workmember = txtmember.Text.Trim
        cn.workcontroler = txtcontroler.Text.Trim
        cn.workwktime = txtwktime.Text.Trim
        cn.WorkAddress = workaddress.Text.Trim
        cn.tel = tel.Text.Trim
        cn.SDATE = SDATE.Text.Trim
        cn.EDATE = EDATE.Text.Trim
        cn.checker = checker.Text.Trim
        cn.Provider = provider.SelectedValue

        cn.workwkdateend = txtwkdateend.Text.Trim
        cn.workwktimeend = txtwktimeend.Text.Trim

        'cn.creater = context.User.Identity.Name.Trim
        If Creater.Text = "" Then
            cn.creater = context.User.Identity.Name.Trim
        End If

        cm.Insert(cn)

        txtResult.Text = "新增成功!"

        txtsubject.Text = ""
        txtwkdate.Text = ""
        txtmember.Text = ""
        txtcontroler.Text = ""
        workaddress.Text = ""
        SDATE.Text = ""
        EDATE.Text = ""


        Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If checkFields() = False Then
            Exit Sub
        End If

        Dim cn As New Enwork
        Dim sc As New WorkBO
        Dim test As String

        cn.workno = Request("workno").ToString
        cn.workgroup = Request("txtworkgrp").ToString
        cn.worksubject = Request("txtsubject").ToString
        cn.workwkdate = Request("txtwkdate").ToString
        cn.workwktime = Request("txtwktime").Trim

        cn.workwkdateend = Request("txtwkdateend").ToString
        cn.workwktimeend = Request("txtwktimeend").Trim

        cn.workmember = Request("txtmember").ToString
        cn.workcontroler = Request("txtcontroler").ToString
        cn.tel = Request("tel").ToString
        cn.WorkAddress = Request("WorkAddress").ToString
        cn.checker = Request("checker").ToString
        cn.SDATE = Request("SDATE").ToString
        cn.EDATE = Request("EDATE").ToString

        If Creater.Text <> "" Then
            cn.modifier = context.User.Identity.Name.Trim
            cn.modifydate = Format(Now(), "yyyy/MM/dd hh:mm:ss")
        End If
        'cn.workdate = Request("txtenddate").ToString

        test = sc.Update(cn)

        txtResult.Text = "修改成功!"

        Response.Redirect("workinfor.aspx")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("workinfor.aspx")
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub
End Class
