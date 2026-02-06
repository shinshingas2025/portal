Public Class replace_apply
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents provider As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents RadioButtonList5 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RadioButtonList4 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RadioButtonList3 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RadioButtonList2 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Radiobuttonlist7 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RadioButtonList1 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtquestion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdbfaqgrp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtanswer As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfaqgrp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txttype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txt_type As System.Web.UI.WebControls.TextBox
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents txtdbtype As System.Web.UI.WebControls.Label
    Protected WithEvents revisetime As System.Web.UI.WebControls.Label
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button

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
        Dim wk As New FaqBO
        Dim dt As New DataTable
        Dim urlfaqno As String
        '---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        '---------------------------------------------
        If Not IsPostBack Then
            'Call GetDept()
            With Me.txttype
                .DataSource = it.GetSelectStr("txttype", "FAQ_TYPE")
                .DataTextField = "it_name"
                .DataValueField = "no"
                .DataBind()
            End With
            txtdbtype.Text = ""
            Call showData()
        End If
        urlfaqno = Request("faqno")
        If urlfaqno Is Nothing Then
            Call GetUser(context.User.Identity.Name.Trim)
            objCartDT = CType(Session("Cart"), DataTable)
            If Not IsPostBack Then
                With Me.txtfaqgrp
                    .DataSource = it.GetSelectStr("txtfaqgrp", "FAQ")
                    .DataTextField = "it_name"
                    .DataValueField = "no"
                    .DataBind()
                End With
                txtdbfaqgrp.Text = ""
                Call showData()
            End If
        Else
            With Me.txtfaqgrp
                Dim LI As New ListItem("")
                .DataSource = it.GetSelectStr("txtfaqgrp", "FAQ")
                .DataTextField = "it_name"
                .DataValueField = "no"
                .DataBind()
                .Items.Insert(0, LI)
            End With
            dt = wk.Query(urlfaqno)
            txtdbfaqgrp.Text = "目前項目:" & it.GetNameStr(CType(dt.Rows(0).Item("faqgrp"), String), "FAQ") & "(若無需修改項目則可不選擇)<br>"

            With Me.txttype
                Dim LI As New ListItem("")
                .DataSource = it.GetSelectStr("txttype", "FAQ_TYPE")
                .DataTextField = "it_name"
                .DataValueField = "no"
                .DataBind()
                .Items.Insert(0, LI)
            End With
            dt = wk.Query(urlfaqno)
            txtdbtype.Text = "目前項目:" & it.GetNameStr(CType(dt.Rows(0).Item("type"), String), "FAQ_TYPE") & "(若無需修改項目則可不選擇)<br>"

            txtquestion.Text = CType(dt.Rows(0).Item("faqquestion"), String)
            txtanswer.Text = CType(dt.Rows(0).Item("faqanswer"), String)
            viewstate("Creater") = CType(dt.Rows(0).Item("creater"), String)
            'provider.SelectedValue = CType(dt.Rows(0).Item("provider"), String).Trim
            revisetime.Text = CType(dt.Rows(0).Item("revisetime"), String).Trim
            Call GetUser(viewstate("Creater"))
            Call showData()
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
            'If dt.Rows.Count > 0 Then
            '    createGroup.Text = dt.Rows(0).Item("objname")
            'End If
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
    Sub showData()
        Dim se As New FaqBO
        objCartDT = se.Query("3133")
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New FaqBO
        Dim faqno As String
        faqno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        sc.Delete(faqno)
        '        txtResult.Text = "刪除成功!"
        Call showData()

    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cm As New FaqBO
        Dim cn As New Enfaq
        cn.faqgrp = txtfaqgrp.SelectedValue.ToString
        cn.faqquestion = txtquestion.Text.Trim
        cn.faqanswer = txtanswer.Text.Trim
        cn.creater = context.User.Identity.Name
        cn.Provider = provider.SelectedValue
        cm.Insert(cn)

        'txtResult.Text = "新增成功!"

        txtquestion.Text = ""
        txtanswer.Text = ""

        Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cn As New Enfaq
        Dim sc As New FaqBO
        Dim test As String

        cn.faqno = CType(Request("faqno"), Integer)
        cn.faqgrp = Request("txtfaqgrp").ToString
        cn.faqquestion = Request("txtquestion").ToString
        cn.faqanswer = Request("txtanswer").ToString
        cn.Provider = Request("Provider").ToString

        test = CType(sc.Update(cn), String)

        '        txtResult.Text = "修改成功!"

        Response.Redirect("faq_item.aspx")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("faq_item.aspx")
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Sub RadioButtonList5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Textbox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtquestion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
