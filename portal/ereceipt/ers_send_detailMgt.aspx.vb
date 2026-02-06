Public Class ers_send_detailMgt
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents inquire As System.Web.UI.WebControls.Button
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdata_ym As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtaction As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lbluser_id As System.Web.UI.WebControls.Label
    Protected WithEvents lbluser_name As System.Web.UI.WebControls.Label
    Protected WithEvents lblhouse_no As System.Web.UI.WebControls.Label
    Protected WithEvents lblhouse_name As System.Web.UI.WebControls.Label
    Protected WithEvents lblwm_no As System.Web.UI.WebControls.Label

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
    Dim userID As String
    Dim flag As Boolean
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim swm_no As Integer
        Dim suser_id As String
        Dim suser_name As String
        Dim shouse_no As String
        Dim se As New ErsSendDetailBO
        Dim dtHousesName As DataTable
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        '取得使用者登入帳號
        userID = context.User.Identity.Name
        'userID = "cadmin"

        flag = False
        If Not IsPostBack Then
            swm_no = Request("wm_no").Trim
            suser_id = Request("user_id").Trim
            suser_name = Request("user_name").Trim
            shouse_no = Request("house_no").Trim
            lblwm_no.Text = swm_no
            lbluser_id.Text = suser_id
            lbluser_name.Text = suser_name
            lblhouse_no.Text = shouse_no

            dtHousesName = se.QueryHouseName(shouse_no).Tables(0)
            If dtHousesName.Rows.Count > 0 Then
                lblhouse_name.Text = dtHousesName.Rows(0).Item("am01_name")
            End If

            Call showData()
        End If
        objCartDT = CType(Session("Cart"), DataTable)
    End Sub

    Sub showData()
        Dim se As New ErsSendDetailBO

        objCartDT = se.Query(lblwm_no.Text, lblhouse_no.Text)

        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
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

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("ers_send_detail.aspx")
    End Sub
End Class
