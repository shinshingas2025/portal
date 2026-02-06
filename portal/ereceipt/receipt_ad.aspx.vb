Public Class receipt_ad
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Msg As System.Web.UI.WebControls.Label
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents txtad_content1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtad_content2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtad_content3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtad_start_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtad_end_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnReturn As System.Web.UI.WebControls.Button

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
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        Dim it As New item
        Dim wk As New ReceiptAdBO
        Dim dt As New DataTable
        Dim urladno As String

        urladno = Request("adno")
        objCartDT = CType(Session("Cart"), DataTable)
        If Not IsPostBack Then

        End If

        If urladno Is Nothing Then
            Call showData()
            If Not IsPostBack Then
                '下方新增時填寫的欄位，預設帶入最後一筆的文字
                dt = wk.QueryTOP("")
                If dt.Rows.Count > 0 Then
                    txtad_content1.Text = CType(dt.Rows(0).Item("ad_content1"), String)
                    txtad_content2.Text = CType(dt.Rows(0).Item("ad_content2"), String)
                    txtad_content3.Text = CType(dt.Rows(0).Item("ad_content3"), String)
                    txtad_start_date.Text = CType(Year(CType(dt.Rows(0).Item("ad_start_date"), Date)) - 1911, String) & Right("0" & CType(Month(CType(dt.Rows(0).Item("ad_start_date"), Date)), String), 2) & Right("0" & CType(Day(CType(dt.Rows(0).Item("ad_start_date"), Date)), String), 2)
                    txtad_end_date.Text = CType(Year(CType(dt.Rows(0).Item("ad_end_date"), Date)) - 1911, String) & Right("0" & CType(Month(CType(dt.Rows(0).Item("ad_end_date"), Date)), String), 2) & Right("0" & CType(Day(CType(dt.Rows(0).Item("ad_end_date"), Date)), String), 2)
                Else
                    txtad_content1.Text = ""
                    txtad_content2.Text = ""
                    txtad_content3.Text = ""
                    txtad_start_date.Text = ""
                    txtad_end_date.Text = ""
                End If
            End If
        Else
            If Not IsPostBack Then
                dt = wk.Query(urladno)
                txtad_content1.Text = CType(dt.Rows(0).Item("ad_content1"), String)
                txtad_content2.Text = CType(dt.Rows(0).Item("ad_content2"), String)
                txtad_content3.Text = CType(dt.Rows(0).Item("ad_content3"), String)
                txtad_start_date.Text = CType(Year(CType(dt.Rows(0).Item("ad_start_date"), Date)) - 1911, String) & Right("0" & CType(Month(CType(dt.Rows(0).Item("ad_start_date"), Date)), String), 2) & Right("0" & CType(Day(CType(dt.Rows(0).Item("ad_start_date"), Date)), String), 2)
                txtad_end_date.Text = CType(Year(CType(dt.Rows(0).Item("ad_end_date"), Date)) - 1911, String) & Right("0" & CType(Month(CType(dt.Rows(0).Item("ad_end_date"), Date)), String), 2) & Right("0" & CType(Day(CType(dt.Rows(0).Item("ad_end_date"), Date)), String), 2)
            End If
        End If
    End Sub

    Private Function getDate(ByVal dt As String, ByVal defaultdate As String) As String
        Dim temp As Date
        Dim newDate As String

        If dt <> "" Then
            Try
                If dt > 2000000 Then
                    txtResult.Text = "日期格式錯誤!!"
                    Exit Function
                End If
                dt = dt + 19110000
                newDate = dt.Substring(0, 4) & "/" & dt.Substring(4, 2) & "/" & dt.Substring(6, 2)
                temp = CDate(newDate)
            Catch ex As Exception
                txtResult.Text = "日期格式錯誤!!"
                Exit Function
            End Try
        Else
            newDate = defaultdate
        End If
        Return newDate
    End Function

    Private Function getDefaulVal(ByVal dt As String, ByVal defaultdate As String) As String
        Dim temp As Date
        Dim newVal As String

        If dt <> "" Then
            newVal = dt
        Else
            newVal = defaultdate
        End If
        Return newVal
    End Function


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

    Sub showData()
        Dim se As New ReceiptAdBO
        Dim it As New item
        Dim dt As New DataTable

        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New ReceiptAdBO
        Dim adno As String
        adno = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        sc.Delete(adno)
        txtResult.Text = "刪除成功!"
        'Call showData()
        Response.Redirect("receipt_ad.aspx")
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
        'Call showData()
    End Sub


    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Msg.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim cm As New ReceiptAdBO
        Dim cn As New Enreceiptad
        Dim sDateStart As String = ""
        Dim sDateEnd As String = ""
        txtResult.Text = ""
        sDateStart = getDate(txtad_start_date.Text.ToString.Trim, "1911/01/01")
        sDateEnd = getDate(txtad_end_date.Text.ToString.Trim, "9999/12/31")
        If (getDefaulVal(txtad_start_date.Text.ToString.Trim, 0) > getDefaulVal(txtad_end_date.Text.ToString.Trim, 9991231)) Then
            txtResult.Text = "起始日不可大於終止日!"
        End If

        If txtResult.Text <> "" Then
            Exit Sub
        End If
        cn.ad_content1 = txtad_content1.Text.Trim
        cn.ad_content2 = txtad_content2.Text.Trim
        cn.ad_content3 = txtad_content3.Text.Trim
        cn.ad_start_date = sDateStart
        cn.ad_end_date = sDateEnd
        cn.upd_user = Session("UserName").Trim
        cm.Insert(cn)

        txtResult.Text = "新增成功!"

        Call showData()
    End Sub

    Private Sub dgCart_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim sc As New ReceiptAdBO
        Dim cn As New Enreceiptad
        Dim test As String
        Dim sDateStart As String = ""
        Dim sDateEnd As String = ""
        txtResult.Text = ""
        sDateStart = getDate(txtad_start_date.Text.ToString.Trim, "1911/01/01")
        sDateEnd = getDate(txtad_end_date.Text.ToString.Trim, "9999/12/31")
        If (getDefaulVal(txtad_start_date.Text.ToString.Trim, 0) > getDefaulVal(txtad_end_date.Text.ToString.Trim, 9991231)) Then
            txtResult.Text = "起始日不可大於終止日!"
        End If

        If txtResult.Text <> "" Then
            Exit Sub
        End If

        cn.adno = Request("adno").ToString.Trim
        cn.ad_content1 = Request("txtad_content1").ToString.Trim
        cn.ad_content2 = Request("txtad_content2").ToString.Trim
        cn.ad_content3 = Request("txtad_content3").ToString.Trim
        cn.ad_start_date = sDateStart
        cn.ad_end_date = sDateEnd
        cn.upd_user = Session("UserName").Trim
        test = sc.Update(cn)

        txtResult.Text = "修改成功!"

        Response.Redirect("receipt_ad.aspx")
    End Sub

    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("receipt_ad.aspx")
    End Sub

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("receipt_ad.aspx")
    End Sub

End Class
