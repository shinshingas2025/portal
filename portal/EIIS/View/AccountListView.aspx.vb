Public Class AccountListView
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Dim objCartDT As DataTable
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        objCartDT = CType(Session("Cartlist"), DataTable)
        If Not IsPostBack Then
            showData()
        End If
    End Sub
    Sub showData(Optional ByVal LoginID As String = "")

        Dim se As New Security
        objCartDT = se.Query(LoginID)
        Session("Cartlist") = objCartDT
        DataGrid1.DataSource = objCartDT
        DataGrid1.DataBind()

    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged

        DataGrid1.CurrentPageIndex = e.NewPageIndex

        DataGrid1.DataSource = objCartDT

        DataBind()
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged

        Dim datagriditem As DataGridItem
        datagriditem = DataGrid1.SelectedItem()
        Dim LoginID As String
        LoginID = datagriditem.Cells(1).Text.Trim

        Dim se As New Security '
        Dim at As New Account
        at.LoginID = LoginID
        at.UID = CType(Request.QueryString("UID"), Integer)

        se.MapCommunity(at)
        Call returnValue()

    End Sub
    Private Sub returnValue(Optional ByVal value As String = "")
        Dim js As String
        js &= "<script>"
        js &= "window.returnValue='" & value & "';"
        js &= "window.close();"
        js &= "</script>"
        Me.RegisterStartupScript("showDialogBox", js)


    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        showData(txtSearch.Text.Trim)
    End Sub
End Class
