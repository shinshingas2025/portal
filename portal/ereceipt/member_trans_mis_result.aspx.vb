Public Class member_trans_mis_result
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblSuccess As System.Web.UI.WebControls.Label
    Protected WithEvents lblFailure As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalC As System.Web.UI.WebControls.Label
    Protected WithEvents lblskipCount As System.Web.UI.WebControls.Label
    Protected WithEvents lblskip_house_string As System.Web.UI.WebControls.Label
    Protected WithEvents lblFailure_house_string As System.Web.UI.WebControls.Label
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label

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
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        lblSuccess.Text = Request("Success")
        lblFailure.Text = Request("Failure")
        lblTotalC.Text = Request("TotalC")
        lblskipCount.Text = Request("skipCount")
        lblFailure_house_string.Text = Request("Failure_house_string") & " "
        lblskip_house_string.Text = Request("skip_house_string") & " "

    End Sub

End Class
