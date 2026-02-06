Public Class product_item
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents txtname As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdbfile As System.Web.UI.WebControls.Label
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents txtfile As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtdbpdgrp As System.Web.UI.WebControls.Label
    Protected WithEvents txtpdgrp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtcontent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcompany As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcompanyinfor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcompanylink As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtintor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAccount As System.Web.UI.WebControls.TextBox
    Protected WithEvents AccountText As System.Web.UI.WebControls.TextBox

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
        Dim wk As New ProductsBO
        Dim dt As New DataTable
        Dim urlpdno As String
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
        urlpdno = Request("pdno")
        If urlpdno Is Nothing Then
            objCartDT = CType(Session("Cart"), DataTable)
            If Not IsPostBack Then
                With Me.txtpdgrp
                    .DataSource = it.GetSelectStr("txtpdgrp", "PD")
                    .DataTextField = "it_name"
                    .DataValueField = "no"
                    .DataBind()
                End With
                'txtdbpdgrp.Text = ""
                Call showData()
            End If
        Else
            With Me.txtpdgrp
                Dim LI As New ListItem("")
                .DataSource = it.GetSelectStr("txtpdgrp", "PD")
                .DataTextField = "it_name"
                .DataValueField = "no"
                .DataBind()
                .Items.Insert(0, LI)
            End With
            dt = wk.Query(urlpdno)
            txtdbpdgrp.Text = "目前項目:" & it.GetNameStr(CType(dt.Rows(0).Item("pdgrp"), String), "PD") & "(若無需修改項目則可不選擇)<br>"
            txtname.Text = CType(dt.Rows(0).Item("pdname"), String)
            txtintor.Text = CType(dt.Rows(0).Item("pdintor"), String)
            txtcontent.Text = CType(dt.Rows(0).Item("pdcontent"), String)
            txtcompany.Text = CType(dt.Rows(0).Item("pdcompany"), String)
            txtcompanyinfor.Text = CType(dt.Rows(0).Item("pdcompanyinfor"), String)
            txtcompanylink.Text = CType(dt.Rows(0).Item("pdcompanylink"), String)
            txtdbfile.Text = "目前檔案:" & CType(dt.Rows(0).Item("pdimages"), String)
            AccountText.Text = CType(dt.Rows(0).Item("account"), String)
            Call showData()
        End If
    End Sub

    Sub showData()
        Dim se As New ProductsBO
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New ProductsBO
        Dim pdno As String
        pdno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        sc.Delete(pdno)
        txtResult.Text = "刪除成功!"
        Call showData()

    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim cm As New ProductsBO
        Dim cn As New Enproducts
        Dim data() As String
        Dim file As HttpPostedFile = txtfile.PostedFile
        Dim url_pdfile As String

        '---------------- >檔案上傳 Start
        If file.ContentLength <> 0 Then
            txtResult.Text = "Size:" & file.ContentLength
            txtResult.Text &= "<br>Format:" & file.ContentType
            txtResult.Text &= "<br>Name:" & file.FileName

            Dim FileSplit() As String = Split(file.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_pdfile = Today.Year & Today.Month & Today.Day & FileName
            file.SaveAs(Server.MapPath("../UpImage/" & url_pdfile))
            '----------------------------------------------------------------
            cn.pdgrp = txtpdgrp.SelectedValue.ToString
            cn.pdname = txtname.Text.Trim
            cn.pdintor = txtintor.Text.Trim
            cn.pdcontent = txtcontent.Text.Trim
            cn.pdcompany = txtcompany.Text.Trim
            cn.pdcompanyinfor = txtcompanyinfor.Text.Trim
            cn.pdcompanylink = txtcompanylink.Text.Trim
            cn.pdimages = url_pdfile.Trim
            cn.creater = Session("LoginID")
            cm.Insert(cn)
            txtResult.Text = "新增成功!"
            txtname.Text = ""
            cn.pdAccount = AccountText.Text.Trim

        Else
            txtResult.Text = "檔案上傳失敗,請重新上傳!!"
        End If
        '---------------- >檔案上傳 End
        'txtquestion.Text = ""
        'txtanswer.Text = ""
        Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim cn As New Enproducts
        Dim sc As New ProductsBO
        Dim test As String
        Dim data() As String
        Dim file As HttpPostedFile = txtfile.PostedFile
        Dim url_pdfile As String

        If file.ContentLength <> 0 Then
            'txtResult.Text = "Size:" & File.ContentLength
            'txtResult.Text &= "<br>Format:" & File.ContentType
            'txtResult.Text &= "<br>Name:" & File.FileName

            Dim FileSplit() As String = Split(file.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_pdfile = Today.Year & Today.Month & Today.Day & FileName
            file.SaveAs(Server.MapPath("../UpImage/" & url_pdfile))
            '----------------------------------------------------------------
        End If

        cn.pdno = Request("pdno").ToString
        cn.pdgrp = Request("txtpdgrp").ToString
        cn.pdname = Request("txtname").ToString

        cn.pdintor = Request("txtintor").ToString
        cn.pdcontent = Request("txtcontent").ToString()
        cn.pdcompany = Request("txtcompany").ToString()
        cn.pdcompanyinfor = Request("txtcompanyinfor").ToString()
        cn.pdcompanylink = Request("txtcompanylink").ToString()
        cn.pdimages = url_pdfile
        cn.pdAccount = Request("AccountText").ToString()

        test = sc.Update(cn)

        txtResult.Text = "修改成功!"

        Response.Redirect("product_item.aspx")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("product_item.aspx")
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub


End Class
