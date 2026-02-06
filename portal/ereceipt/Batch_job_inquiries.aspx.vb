Public Class Batch_job_inquiries
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgBJ As System.Web.UI.WebControls.DataGrid

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '判斷登入
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        Dim bj As New Batch_job
        Dim dt As New DataTable
        dt = bj.Search("")
        dgBJ.DataSource = dt
        dgBJ.DataBind()
    End Sub

    Private Sub dgBJ_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgBJ.PageIndexChanged
        dgBJ.CurrentPageIndex = e.NewPageIndex
        dgBJ.DataBind()
    End Sub
End Class
