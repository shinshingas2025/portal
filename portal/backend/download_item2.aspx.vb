Imports System.IO

Public Class download_item2
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents txtdbdwgrp As System.Web.UI.WebControls.Label
    Protected WithEvents txtdbfile As System.Web.UI.WebControls.Label
    Protected WithEvents txtdwgrp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtname As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtfile As System.Web.UI.WebControls.FileUpload
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtfile As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtdbfaqgrp As System.Web.UI.WebControls.Label


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
        Dim wk As New Download2BO
        Dim dt As New DataTable
        Dim urldwno As String
        ''---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If

        '1111104 add 
        If (Session("sid") Is Nothing) Then
            Response.Redirect("../Default.aspx")
        End If
        '1111104 add end 
    '---------------------------------------------
        urldwno = Request("dwno")
        If urldwno Is Nothing Then
            objCartDT = CType(Session("Cart"), DataTable)
            If Not IsPostBack Then
                With Me.txtdwgrp
                    .DataSource = it.GetSelectStr("txtdwgrp", "SHARE")
                    .DataTextField = "it_name"
                    .DataValueField = "no"
                    .DataBind()
                End With
                'txtdbdwgrp.Text = ""
                Call showData()
            End If
        Else
            With Me.txtdwgrp
                Dim LI As New ListItem("")
                .DataSource = it.GetSelectStr("txtdwgrp", "SHARE")
                .DataTextField = "it_name"
                .DataValueField = "no"
                .DataBind()
                .Items.Insert(0, LI)
            End With
            dt = wk.Query(urldwno)
            txtdbdwgrp.Text = "目前項目:" & it.GetNameStr2(CType(dt.Rows(0).Item("dwgrp"), String), "SHARE") & "(若無需修改項目則可不選擇)<br>"
            txtname.Text = CType(dt.Rows(0).Item("dwname"), String)
            txtdbfile.Text = "目前檔案:" & CType(dt.Rows(0).Item("dwfile"), String)
            Call showData()
        End If
    End Sub

    Sub showData()
        Dim se As New Download2BO
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New Download2BO
        Dim dwno As String
        dwno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        'sc.Delete(dwno)
        '1080823 add
        sc.Delete(dwno, Server.MapPath("../../UpFile2/"))
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
        Dim cm As New Download2BO
        Dim cn As New Endownload2
        Dim data() As String
        Dim file As HttpPostedFile = txtfile.PostedFile
        Dim url_dwfile As String

        '---------------- >檔案上傳 Start
        If file.ContentLength <> 0 Then
            txtResult.Text = "Size:" & file.ContentLength
            txtResult.Text &= "<br>Format:" & file.ContentType
            txtResult.Text &= "<br>Name:" & file.FileName

            Dim FileSplit() As String = Split(file.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_dwfile = Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            file.SaveAs(Server.MapPath("../../UpFile2/" & url_dwfile))
            '----------------------------------------------------------------
            cn.dwgrp = txtdwgrp.SelectedValue.ToString
            cn.dwname = txtname.Text
            If cn.dwname.Length = 0 Then cn.dwname = " "
            cn.dwfile = url_dwfile.Trim
            cn.creater = CType(Session("LoginID"), String)
            cm.Insert(cn)
            txtResult.Text = "新增成功!"
            txtname.Text = ""

        Else
            txtResult.Text = "檔案上傳失敗,請重新上傳!!"
        End If
        '---------------- >檔案上傳 End
        'txtquestion.Text = ""
        'txtanswer.Text = ""
        Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim cn As New Endownload2
        Dim sc As New Download2BO
        Dim test As String
        Dim data() As String
        Dim file As HttpPostedFile = txtfile.PostedFile
        Dim url_dwfile As String

        If file.ContentLength <> 0 Then
            'txtResult.Text = "Size:" & File.ContentLength
            'txtResult.Text &= "<br>Format:" & File.ContentType
            'txtResult.Text &= "<br>Name:" & File.FileName

            Dim FileSplit() As String = Split(file.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_dwfile = Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            file.SaveAs(Server.MapPath("../../UpFile2/" & url_dwfile))
            '----------------------------------------------------------------
        End If

        cn.dwno = CType(Request("dwno"), Integer)
        cn.dwgrp = Request("txtdwgrp").ToString
        cn.dwname = Request("txtname").ToString
        If cn.dwname.Length = 0 Then cn.dwname = " "
        cn.dwfile = url_dwfile

        test = CType(sc.Update(cn), String)

        txtResult.Text = "修改成功!"

        Response.Redirect("download_item2.aspx")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("download_item2.aspx")
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

End Class
