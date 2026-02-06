Public Class send_detail_tmp
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txttype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtdbtype As System.Web.UI.WebControls.Label
    Protected WithEvents txtfaqgrp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtdbfaqgrp As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid

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
        Dim wk As New InvestBO
        Dim dt As New DataTable
        Dim urlinvno As String
        '---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        '---------------------------------------------
        urlinvno = Request("invno")
        If urlinvno Is Nothing Then
            objCartDT = CType(Session("Cart"), DataTable)
            If Not IsPostBack Then
                Call showData()
            End If
        Else
            dt = wk.Query(urlinvno, "")
            'txtname.Text = CType(dt.Rows(0).Item("invname"), String)
            ''txtdbfile.Text = "目前檔案:" & CType(dt.Rows(0).Item("invfile"), String)
            Call showData()
        End If
    End Sub

    Sub showData()
        Dim se As New InvestBO
        objCartDT = se.Query("", "1")
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New InvestBO
        Dim invno As String
        invno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        sc.Delete(invno)
        txtResult.Text = "刪除成功!"
        Call showData()

    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        'Message.Text = _
        '"共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        '"總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        '"目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Public Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim cm As New InvestBO
        'Dim cn As New Eninvest
        'Dim data() As String
        'Dim file As HttpPostedFile = txtfile.PostedFile
        'Dim url_invfile As String

        ''---------------- >檔案上傳 Start
        'If file.ContentLength <> 0 Then
        '    Dim FileSplit() As String = Split(file.FileName, "\")
        '    Dim FileName As String = FileSplit(FileSplit.Length - 1)
        '    '上傳之檔案名稱
        '    url_invfile = "Inv01_" & Today.Year & Today.Month & Today.Day & FileName
        '    file.SaveAs(Server.MapPath("../UpFile/" & url_invfile))
        '    '----------------------------------------------------------------
        '    cn.invfile = url_invfile.Trim
        'Else
        '    cn.invfile = "NULL"
        'End If

        ''cn.invname = txtname.Text.Trim
        'cn.invgrp = "1"  '財務資訊
        'cn.creater = Session("LoginID")
        'cm.Insert(cn)
        'txtResult.Text = "新增成功!"
        ''txtname.Text = ""
        'Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim cn As New Eninvest
        'Dim sc As New InvestBO
        'Dim data() As String
        'Dim file As HttpPostedFile = txtfile.PostedFile
        'Dim url_invfile As String

        'If file.ContentLength <> 0 Then
        '    Dim FileSplit() As String = Split(file.FileName, "\")
        '    Dim FileName As String = FileSplit(FileSplit.Length - 1)
        '    '上傳之檔案名稱
        '    url_invfile = "Inv01_" & Today.Year & Today.Month & Today.Day & FileName
        '    file.SaveAs(Server.MapPath("../UpFile/" & url_invfile))
        '    '----------------------------------------------------------------
        '    cn.invfile = url_invfile
        'End If
        'cn.invno = Request("invno").ToString
        'cn.invname = Request("txtname").ToString
        'sc.Update(cn)
        'txtResult.Text = "修改成功!"
        'Response.Redirect("invest_01.aspx")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("invest_01.aspx")
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

End Class
