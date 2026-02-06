Imports System.Data.SqlClient
Public Class admin
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtusergrp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtuserid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtuserpw As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtname As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtemail As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Message As System.Web.UI.WebControls.Label

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

        objCartDT = CType(Session("Cart"), DataTable)
        If Not IsPostBack Then
            Dim LI As New ListItem("請選擇")
            With Me.txtusergrp
                .DataSource = it.GetSelectStr("txtusergrp", "ADM")
                .DataTextField = "it_name"
                .DataValueField = "no"
                .DataBind()
                .Items.Insert(0, LI)
            End With
            Call showData()
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
        Dim userpw As TextBox
        Dim name As TextBox
        Dim email As TextBox
        Dim userno As String
        Dim ac As New Account

        Dim sc As New Security
        ' userno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        'userpw = CType(e.Item.FindControl("txtuserpw"), TextBox)
        'name = CType(e.Item.FindControl("txtname"), TextBox)
        'email = CType(e.Item.FindControl("txtemail"), TextBox)
        userno = dgCart.DataKeys(e.Item.ItemIndex).ToString()
        userpw = CType(e.Item.Cells(2).Controls(0), TextBox)
        name = CType(e.Item.Cells(3).Controls(0), TextBox)
        email = CType(e.Item.Cells(4).Controls(0), TextBox)

        For Each objDR In objCartDT.Rows
            If Trim(CType(objDR("userno"), String)) = userno.Trim Then
                ac.userpw = userpw.Text.Trim
                ac.name = name.Text.Trim
                ac.email = email.Text.Trim
                ac.userno = userno
                sc.UpdateaAccount(ac)

                Exit For
            End If
        Next

        dgCart.EditItemIndex = -1
        Call showData()

    End Sub

    Sub showData()
        Dim se As New Security
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New Security
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
        Dim cm As New Security
        Dim cn As New Account

        If cm.Query(txtuserid.Text.Trim).Rows.Count > 0 Then
            txtResult.Text = "帳號重覆!"
            Exit Sub
        Else

        End If
        cn.usergrp = txtusergrp.SelectedValue.ToString
        cn.userid = txtuserid.Text.Trim
        cn.userpw = txtuserpw.Text.Trim
        cn.name = txtname.Text.Trim
        cn.email = txtemail.Text.Trim

        cm.Insert(cn)

        txtResult.Text = "新增成功!"
        txtuserid.Text = ""
        txtuserpw.Text = ""
        txtname.Text = ""
        txtemail.Text = ""
        Call showData()

    End Sub

    Private Sub dgCart_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub
End Class
