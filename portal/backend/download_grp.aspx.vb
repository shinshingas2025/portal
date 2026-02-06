Public Class download_grp
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtname As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtorder As System.Web.UI.WebControls.TextBox

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
        '---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        '1111104 add 
        If (Session("sid") Is Nothing) Then
            Response.Redirect("../Default.aspx")
        End If
        '1111104 add end 
        '---------------------------------------------
        '在這裡放置使用者程式碼以初始化網
        Dim it As New item
        Dim wk As New ItemBO
        Dim dt As New DataTable
        Dim urlmsgno As String

        urlmsgno = Request("no")
        If urlmsgno Is Nothing Then
            objCartDT = CType(Session("Cart"), DataTable)
            If Not IsPostBack Then
                Call showData()
            End If
        Else
            dt = wk.Query("DOWN", urlmsgno)
            txtname.Text = CType(dt.Rows(0).Item("it_name"), String)
            txtorder.Text = CType(dt.Rows(0).Item("it_order"), String)
            'Call showData()
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
        Dim name As TextBox
        Dim order As TextBox
        Dim itno As String
        Dim ac As New Enitem

        Dim sc As New ItemBO

        itno = dgCart.DataKeys(e.Item.ItemIndex).ToString()
        name = CType(e.Item.Cells(0).Controls(0), TextBox)
        order = CType(e.Item.Cells(1).Controls(0), TextBox)

        For Each objDR In objCartDT.Rows
            If Trim(CType(objDR("no"), String)) = itno.Trim Then
                ac.it_name = name.Text.Trim
                ac.it_order = order.Text.Trim
                ac.no = CType(itno, Integer)
                sc.Update(ac)
                Exit For
            End If
        Next

        dgCart.EditItemIndex = -1
        Call showData()

    End Sub

    Sub showData()
        Dim se As New ItemBO
        objCartDT = se.Query("DOWN")
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New ItemBO
        Dim userid As String
        userid = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        ' objCartDT.Rows(e.Item.ItemIndex).Delete()
        'Session("cart") = objCartDT
        'dgCart.DataSource = objCartDT
        sc.Delete(userid)
        txtResult.Text = "刪除成功!"
        Call showData()

    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim cm As New ItemBO
        Dim cn As New Enitem
        cn.it_type = Request("ittype").ToString
        cn.it_name = txtname.Text.Trim
        cn.it_order = txtorder.Text.Trim
        cm.Insert(cn)

        txtResult.Text = "新增成功!"
        txtname.Text = ""
        txtorder.Text = ""
        Call showData()

    End Sub

    Private Sub dgCart_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim cn As New Enitem
        Dim sc As New ItemBO
        Dim test As String

        cn.no = CType(Request("no"), Integer)
        cn.it_name = Request("txtname").ToString
        cn.it_order = Request("txtorder").ToString

        test = CType(sc.Update(cn), String)

        txtResult.Text = "修改成功!"

        Response.Redirect("download_grp.aspx")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("faq_grp.aspx")
    End Sub

End Class
