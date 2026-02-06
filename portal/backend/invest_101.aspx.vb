Public Class invest_101
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents invno As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfile1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtfile2 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtfile3 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtfile4 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents atxtfile1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents atxtfile2 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents atxtfile3 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents atxtfile4 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtdbfile1 As System.Web.UI.WebControls.Label
    Protected WithEvents atxtdbfile1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtdbfile2 As System.Web.UI.WebControls.Label
    Protected WithEvents atxtdbfile2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtdbfile3 As System.Web.UI.WebControls.Label
    Protected WithEvents atxtdbfile3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtdbfile4 As System.Web.UI.WebControls.Label
    Protected WithEvents atxtdbfile4 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents fyear As System.Web.UI.WebControls.TextBox

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
        Dim wk As New Invest101BO
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
            If Not IsPostBack Then
                dt = wk.Query(urlinvno, "")
                fyear.Text = CType(dt.Rows(0).Item("fyear"), Integer)
                Textbox1.Text = CType(dt.Rows(0).Item("invname1"), String)
                txtdbfile1.Text = CType(dt.Rows(0).Item("invfile1"), String)
                Textbox2.Text = CType(dt.Rows(0).Item("invaname1"), String)
                atxtdbfile1.Text = CType(dt.Rows(0).Item("invafile1"), String)

                Textbox3.Text = CType(dt.Rows(0).Item("invname2"), String)
                txtdbfile2.Text = CType(dt.Rows(0).Item("invfile2"), String)
                Textbox4.Text = CType(dt.Rows(0).Item("invaname2"), String)
                atxtdbfile2.Text = CType(dt.Rows(0).Item("invafile2"), String)

                Textbox5.Text = CType(dt.Rows(0).Item("invname3"), String)
                txtdbfile3.Text = CType(dt.Rows(0).Item("invfile3"), String)
                Textbox6.Text = CType(dt.Rows(0).Item("invaname3"), String)
                atxtdbfile3.Text = CType(dt.Rows(0).Item("invafile3"), String)

                Textbox7.Text = CType(dt.Rows(0).Item("invname4"), String)
                txtdbfile4.Text = CType(dt.Rows(0).Item("invfile4"), String)
                Textbox8.Text = CType(dt.Rows(0).Item("invaname4"), String)
                atxtdbfile4.Text = CType(dt.Rows(0).Item("invafile4"), String)

                Call showData()
            End If
        End If
    End Sub

    Private Function checkFields() As Boolean
        txtResult.Text = ""
        '檢查年度,民國年
        If CType(fyear.Text, String) = "" Then
            txtResult.Text = "年度資料不可空白!"
            Return False
        End If

        Return True

    End Function

    Sub showData()
        Dim se As New Invest101BO
        objCartDT = se.Query("", "101")
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
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

    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New Invest101BO
        Dim invno As String
        invno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        sc.Delete(invno)
        txtResult.Text = "刪除成功!"
        Call showData()

    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Public Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If checkFields() = False Then
            Exit Sub
        End If

        Dim cm As New Invest101BO
        Dim cn As New Eninvest101
        Dim dtYY As DataTable
        Dim data() As String
        Dim file1 As HttpPostedFile = txtfile1.PostedFile
        Dim file2 As HttpPostedFile = txtfile2.PostedFile
        Dim file3 As HttpPostedFile = txtfile3.PostedFile
        Dim file4 As HttpPostedFile = txtfile4.PostedFile
        Dim afile1 As HttpPostedFile = atxtfile1.PostedFile
        Dim afile2 As HttpPostedFile = atxtfile2.PostedFile
        Dim afile3 As HttpPostedFile = atxtfile3.PostedFile
        Dim afile4 As HttpPostedFile = atxtfile4.PostedFile
        Dim url_invfile As String

        cn.fyear = CType(fyear.Text.Trim, Integer)
        dtYY = cm.YearQuery(cn.fyear)

        If dtYY.Rows.Count <= 0 Then

            '---------------- >檔案上傳 Start
            If file1.ContentLength <> 0 Then
                Dim FileSplit() As String = Split(file1.FileName, "\")
                Dim FileName As String = FileSplit(FileSplit.Length - 1)
                '上傳之檔案名稱
                url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
                file1.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
                '----------------------------------------------------------------
                cn.invfile1 = url_invfile.Trim
            End If

            If file2.ContentLength <> 0 Then
                Dim FileSplit() As String = Split(file2.FileName, "\")
                Dim FileName As String = FileSplit(FileSplit.Length - 1)
                '上傳之檔案名稱
                url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
                file2.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
                '----------------------------------------------------------------
                cn.invfile2 = url_invfile.Trim
            End If

            If file3.ContentLength <> 0 Then
                Dim FileSplit() As String = Split(file3.FileName, "\")
                Dim FileName As String = FileSplit(FileSplit.Length - 1)
                '上傳之檔案名稱
                url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
                file3.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
                '----------------------------------------------------------------
                cn.invfile3 = url_invfile.Trim
            End If

            If file4.ContentLength <> 0 Then
                Dim FileSplit() As String = Split(file4.FileName, "\")
                Dim FileName As String = FileSplit(FileSplit.Length - 1)
                '上傳之檔案名稱
                url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
                file4.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
                '----------------------------------------------------------------
                cn.invfile4 = url_invfile.Trim
            End If

            If afile1.ContentLength <> 0 Then
                Dim FileSplit() As String = Split(afile1.FileName, "\")
                Dim FileName As String = FileSplit(FileSplit.Length - 1)
                '上傳之檔案名稱
                url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
                afile1.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
                '----------------------------------------------------------------
                cn.invafile1 = url_invfile.Trim
            End If

            If afile2.ContentLength <> 0 Then
                Dim FileSplit() As String = Split(afile2.FileName, "\")
                Dim FileName As String = FileSplit(FileSplit.Length - 1)
                '上傳之檔案名稱
                url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
                afile2.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
                '----------------------------------------------------------------
                cn.invafile2 = url_invfile.Trim
            End If

            If afile3.ContentLength <> 0 Then
                Dim FileSplit() As String = Split(afile3.FileName, "\")
                Dim FileName As String = FileSplit(FileSplit.Length - 1)
                '上傳之檔案名稱
                url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
                afile3.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
                '----------------------------------------------------------------
                cn.invafile3 = url_invfile.Trim
            End If

            If afile4.ContentLength <> 0 Then
                Dim FileSplit() As String = Split(afile4.FileName, "\")
                Dim FileName As String = FileSplit(FileSplit.Length - 1)
                '上傳之檔案名稱
                url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
                afile4.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
                '----------------------------------------------------------------
                cn.invafile4 = url_invfile.Trim
            End If
            cn.invname1 = Textbox1.Text.Trim
            cn.invname2 = Textbox3.Text.Trim
            cn.invname3 = Textbox5.Text.Trim
            cn.invname4 = Textbox7.Text.Trim
            cn.invaname1 = Textbox2.Text.Trim
            cn.invaname2 = Textbox4.Text.Trim
            cn.invaname3 = Textbox6.Text.Trim
            cn.invaname4 = Textbox8.Text.Trim

            cn.invgrp = "101"  '財務資訊
            cn.creater = Session("LoginID")
            cm.Insert(cn)
            txtResult.Text = "新增成功!"
            fyear.Text = ""
            Textbox1.Text = ""
            Textbox2.Text = ""
            Textbox3.Text = ""
            Textbox4.Text = ""
            Textbox5.Text = ""
            Textbox6.Text = ""
            Textbox7.Text = ""
            Textbox8.Text = ""
        Else
            txtResult.Text = "年度不可重覆!"
        End If

        Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim cn As New Eninvest101
        Dim sc As New Invest101BO
        Dim data() As String
        Dim file1 As HttpPostedFile = txtfile1.PostedFile
        Dim file2 As HttpPostedFile = txtfile2.PostedFile
        Dim file3 As HttpPostedFile = txtfile3.PostedFile
        Dim file4 As HttpPostedFile = txtfile4.PostedFile
        Dim afile1 As HttpPostedFile = atxtfile1.PostedFile
        Dim afile2 As HttpPostedFile = atxtfile2.PostedFile
        Dim afile3 As HttpPostedFile = atxtfile3.PostedFile
        Dim afile4 As HttpPostedFile = atxtfile4.PostedFile
        Dim url_invfile As String
        Dim fyear As TextBox

        '---------------- >檔案上傳 Start
        If file1.ContentLength <> 0 Then
            Dim FileSplit() As String = Split(file1.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            file1.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
            '----------------------------------------------------------------
            cn.invfile1 = url_invfile.Trim
        End If

        If file2.ContentLength <> 0 Then
            Dim FileSplit() As String = Split(file2.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            file2.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
            '----------------------------------------------------------------
            cn.invfile2 = url_invfile.Trim
        End If

        If file3.ContentLength <> 0 Then
            Dim FileSplit() As String = Split(file3.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            file3.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
            '----------------------------------------------------------------
            cn.invfile3 = url_invfile.Trim
        End If

        If file4.ContentLength <> 0 Then
            Dim FileSplit() As String = Split(file4.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            file4.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
            '----------------------------------------------------------------
            cn.invfile4 = url_invfile.Trim
        End If

        If afile1.ContentLength <> 0 Then
            Dim FileSplit() As String = Split(afile1.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            afile1.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
            '----------------------------------------------------------------
            cn.invafile1 = url_invfile.Trim
        End If

        If afile2.ContentLength <> 0 Then
            Dim FileSplit() As String = Split(afile2.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            afile2.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
            '----------------------------------------------------------------
            cn.invafile2 = url_invfile.Trim
        End If

        If afile3.ContentLength <> 0 Then
            Dim FileSplit() As String = Split(afile3.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            afile3.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
            '----------------------------------------------------------------
            cn.invafile3 = url_invfile.Trim
        End If

        If afile4.ContentLength <> 0 Then
            Dim FileSplit() As String = Split(afile4.FileName, "\")
            Dim FileName As String = FileSplit(FileSplit.Length - 1)
            '上傳之檔案名稱
            url_invfile = "Inv101_" & Today.Year & Right("000" & Today.Month, 2) & Right("000" & Today.Day, 2) & FileName
            afile4.SaveAs(Server.MapPath("../../UpFile/inv101/" & url_invfile))
            '----------------------------------------------------------------
            cn.invafile4 = url_invfile.Trim
        End If
        cn.invno = Request("invno").ToString
        cn.invname1 = Request("Textbox1").ToString
        cn.invname2 = Request("Textbox3").ToString
        cn.invname3 = Request("Textbox5").ToString
        cn.invname4 = Request("Textbox7").ToString
        cn.invaname1 = Request("Textbox2").ToString
        cn.invaname2 = Request("Textbox4").ToString
        cn.invaname3 = Request("Textbox6").ToString
        cn.invaname4 = Request("Textbox8").ToString
        cn.fyear = CType(Request("fyear"), Integer)
        sc.Update(cn)
        txtResult.Text = "修改成功!"
        Response.Redirect("invest_101.aspx")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("invest_01.aspx")
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

End Class
