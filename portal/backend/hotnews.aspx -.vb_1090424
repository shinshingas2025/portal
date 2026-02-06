Public Class hotnews
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents txtsubject As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcontent As System.Web.UI.WebControls.TextBox
    Protected WithEvents SDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents EDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents provider As System.Web.UI.WebControls.DropDownList

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
        Dim wk As New HotnewsBO
        Dim dt As New DataTable
        Dim urlnewno As String

        '---------------------------------------------
        '  If (Session("LoginID") Is Nothing) Then
        '  Response.Redirect("login.aspx")
        '  End If
        '---------------------------------------------
        urlnewno = Request("newno")

        objCartDT = CType(Session("Cart"), DataTable)
        'If Not IsPostBack Then
        'Call showData()
        'Else       
        If Not IsPostBack Then
            Call GetDept()
        End If
        If urlnewno Is Nothing Then
            Call showData()
            Call GetUser(context.User.Identity.Name.Trim)
        Else
            If Not IsPostBack Then
                dt = wk.Query(urlnewno)
                txtsubject.Text = CType(dt.Rows(0).Item("new_subject"), String)
                txtcontent.Text = Replace(CType(dt.Rows(0).Item("new_content"), String), "<BR>", Chr(13))
                SDATE.Text = CType(Year(CType(dt.Rows(0).Item("sdate"), Date)), String) & "/" & Right("0" & CType(Month(CType(dt.Rows(0).Item("sdate"), Date)), String), 2) & "/" & Right("0" & CType(Day(CType(dt.Rows(0).Item("sdate"), Date)), String), 2)
                EDATE.Text = CType(Year(CType(dt.Rows(0).Item("EDATE"), Date)), String) & "/" & Right("0" & CType(Month(CType(dt.Rows(0).Item("EDATE"), Date)), String), 2) & "/" & Right("0" & CType(Day(CType(dt.Rows(0).Item("EDATE"), Date)), String), 2)
                viewstate("Creater") = CType(dt.Rows(0).Item("creater"), String)
                provider.SelectedValue = CType(dt.Rows(0).Item("provider"), String).Trim
                Call GetUser(viewstate("Creater"))
            End If

        End If

        'End If



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


        Dim subject As TextBox
        Dim content As TextBox
        Dim newno As String
        Dim ac As New Enhotnews

        Dim sc As New HotnewsBO

        newno = dgCart.DataKeys(e.Item.ItemIndex).ToString()
        subject = CType(e.Item.Cells(0).Controls(0), TextBox)
        content = CType(e.Item.Cells(1).Controls(0), TextBox)

        For Each objDR In objCartDT.Rows
            If Trim(CType(objDR("newno"), String)) = newno.Trim Then
                ac.newsubject = subject.Text.Trim
                ac.newcontent = content.Text.Trim
                ac.newno = CType(newno, Integer)
                sc.Update(ac)
                Exit For
            End If
        Next

        dgCart.EditItemIndex = -1
        Call showData()

    End Sub

    Sub showData()
        Dim se As New HotnewsBO
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New HotnewsBO
        Dim userid As String
        userid = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        ' objCartDT.Rows(e.Item.ItemIndex).Delete()
        'Session("cart") = objCartDT
        'dgCart.DataSource = objCartDT
        sc.Delete(userid)
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
        'dgCart.DataSource = objCartDT
        'dgCart.DataBind()
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
        Dim cm As New HotnewsBO
        Dim cn As New Enhotnews
        cn.newsubject = txtsubject.Text.Trim
        cn.newcontent = txtcontent.Text.Trim

        'cn.newlink = txtlink.Text.Trim
        cn.creater = context.User.Identity.Name.Trim
        cn.SDATE = CType(SDATE.Text.Trim, Date)
        cn.EDATE = CType(SDATE.Text.Trim, Date)
        cn.Provider = provider.SelectedValue
        cm.Insert(cn)

        txtResult.Text = "新增成功!"
        txtsubject.Text = ""
        txtcontent.Text = ""
        Call showData()

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click

        If checkFields() = False Then
            Exit Sub
        End If
        Dim cn As New Enhotnews
        Dim sc As New HotnewsBO
        Dim test As String

        cn.newno = CType(Request("newno").ToString, Integer)
        cn.newsubject = Request("txtsubject").ToString
        cn.newcontent = Request("txtcontent").ToString

        cn.SDATE = Request("SDATE").ToString
        cn.EDATE = Request("EDATE").ToString
        cn.Provider = Request("provider").ToString

        test = CType(sc.Update(cn), String)

        txtResult.Text = "修改成功!"

        Response.Redirect("hotnews.aspx")
    End Sub

    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("hotnews.aspx")
    End Sub

    Private Sub dgCart_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub


End Class

