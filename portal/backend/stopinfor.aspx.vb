Public Class stopinfor
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents provider As System.Web.UI.WebControls.DropDownList
    Protected WithEvents stoprange As System.Web.UI.WebControls.TextBox
    Protected WithEvents spcontent As System.Web.UI.WebControls.TextBox
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents answertel As System.Web.UI.WebControls.TextBox
    Protected WithEvents answerunit As System.Web.UI.WebControls.TextBox
    Protected WithEvents stopedate As System.Web.UI.WebControls.TextBox
    Protected WithEvents stopSdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents stopstime As System.Web.UI.WebControls.TextBox
    Protected WithEvents stopetime As System.Web.UI.WebControls.TextBox
    Protected WithEvents SDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents EDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents modifierGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Modifier As System.Web.UI.WebControls.Label

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
        Dim wk As New StopBO
        Dim dt As New DataTable
        Dim urlspno As String

        If Not IsPostBack Then
            Call GetDept()

        End If
        '---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        '---------------------------------------------
        'objCartDT = CType(Session("Cart"), DataTable)
        'If Not IsPostBack Then
        'Call showData()
        'End If

        urlspno = Request("spno")
        If urlspno Is Nothing Then

            objCartDT = CType(Session("Cart"), DataTable)
            If Not IsPostBack Then
                Call showData()
                'Call GetUser(context.User.Identity.Name.Trim)
            End If
        Else
            dt = wk.Query(urlspno)
            stoprange.Text = CType(dt.Rows(0).Item("stoprange"), String)
            stopSdate.Text = CType(dt.Rows(0).Item("stopSdate"), String)
            stopstime.Text = CType(dt.Rows(0).Item("stopstime"), String)
            stopedate.Text = CType(dt.Rows(0).Item("stopedate"), String)
            stopetime.Text = CType(dt.Rows(0).Item("stopetime"), String)
            answerunit.Text = CType(dt.Rows(0).Item("answerunit"), String)
            answertel.Text = CType(dt.Rows(0).Item("answertel"), String)
            spcontent.Text = CType(dt.Rows(0).Item("spcontent"), String)
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

    Sub dgCart_Edit(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        dgCart.EditItemIndex = e.Item.ItemIndex

        dgCart.DataSource = objCartDT
        dgCart.DataBind()
    End Sub

    Sub dgCart_Cancel(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        dgCart.EditItemIndex = -1

        dgCart.DataSource = objCartDT
        dgCart.DataBind()
    End Sub

    Sub dgCart_Update(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        If checkFields() = False Then
            Exit Sub
        End If
        Dim txtsubject As TextBox
        Dim txtcontent As TextBox
        Dim txtenddate As TextBox
        Dim spno As String
        Dim ac As New Enstop

        Dim sc As New StopBO

        spno = dgCart.DataKeys(e.Item.ItemIndex).ToString()
        txtsubject = CType(e.Item.Cells(0).Controls(0), TextBox)
        txtcontent = CType(e.Item.Cells(1).Controls(0), TextBox)
        txtenddate = CType(e.Item.Cells(2).Controls(0), TextBox)

        For Each objDR In objCartDT.Rows
            If Trim(CType(objDR("spno"), String)) = spno.Trim Then
                ac.spsubject = txtsubject.Text.Trim
                ac.spcontent = txtcontent.Text.Trim
                ac.spenddate = txtenddate.Text
                ac.spno = spno
                sc.Update(ac)
                Exit For
            End If
        Next

        dgCart.EditItemIndex = -1
        Call showData()

    End Sub

    Sub showData()
        Dim se As New StopBO
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New StopBO
        Dim spno As String
        spno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        sc.Delete(spno)
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
        Dim cm As New StopBO
        Dim cn As New Enstop

        cn.stoprange = stoprange.Text.Trim
        cn.stopSdate = stopSdate.Text.Trim
        cn.stopStime = stopstime.Text.Trim
        cn.stopEdate = stopedate.Text.Trim
        cn.stopEtime = stopetime.Text.Trim
        cn.AnswerUnit = answerunit.Text.Trim
        cn.AnswerTel = answertel.Text.Trim
        cn.spcontent = spcontent.Text.Trim
        cn.Provider = provider.SelectedValue
        cn.SDATE = SDATE.Text.Trim
        cn.EDATE = EDATE.Text.Trim


        'cn.creater = context.User.Identity.Name.Trim
        If Creater.Text = "" Then
            cn.creater = context.User.Identity.Name.Trim
        End If

        cm.Insert(cn)

        txtResult.Text = "新增成功!"
        stoprange.Text = ""
        stopSdate.Text = ""
        stopstime.Text = ""
        stopedate.Text = ""
        stopetime.Text = ""
        answerunit.Text = ""
        answertel.Text = ""
        spcontent.Text = ""
        Creater.Text = ""
        createGroup.Text = ""
        provider.SelectedValue = ""

        Call showData()
    End Sub

    Private Sub dgCart_PageIndexChanged1(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim cn As New Enstop
        Dim sc As New StopBO
        Dim test As String

        cn.spno = Request("spno").ToString
        cn.stoprange = Request("stoprange").ToString
        cn.stopSdate = Request("stopSdate").ToString
        cn.stopStime = Request("stopStime").ToString
        cn.stopEdate = Request("stopEdate").ToString
        cn.stopEtime = Request("stopEtime").ToString
        cn.AnswerUnit = Request("AnswerUnit").ToString
        cn.AnswerTel = Request("AnswerTel").ToString
        cn.spcontent = Request("spcontent").ToString
        cn.Provider = Request("Provider").ToString
        cn.SDATE = Request("SDATE").ToString
        cn.EDATE = Request("EDATE").ToString

        If Creater.Text <> "" Then
            cn.modifier = context.User.Identity.Name.Trim
            cn.modifydate = Format(Now(), "yyyy/MM/dd hh:mm:ss")
        End If

        test = sc.Update(cn)

        txtResult.Text = "修改成功!"

        Response.Redirect("stopinfor.aspx")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("stopinfor.aspx")
    End Sub

End Class
