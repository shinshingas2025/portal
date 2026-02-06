Namespace ASPNET.StarterKit.Portal
    Public Class UserInfo
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl

#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label

        '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
        '請勿刪除或移動它。
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
            '請勿使用程式碼編輯器進行修改。
            InitializeComponent()
        End Sub

#End Region
        Private tabIndex As Integer = 0
        Private tabId As Integer = 0
        Private sid As String = ""

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '在這裡放置使用者程式碼以初始化網頁
            ' Verify that the current user has access to access this page
            '    If PortalSecurity.IsInRoles("Admins") = False And PortalSecurity.IsInRoles("s" & CType(Session("sid"), String)) = False Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            '    End If

            '判斷權限,因為編輯個人資料需放於首頁,故把它註解設定為不檢查(恩立b我寫的)
            'Dim au As New AuthorityBO
            'If Not au.checkAuthorityEdit(Context.User.Identity.Name, ModuleId, 7, Me.Page) Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            'End If
            'au = Nothing

            If Not (Request.Params("tabid") Is Nothing) Then
                tabId = Int32.Parse(Request.Params("tabid"))
            End If
            If Not (Request.Params("tabindex") Is Nothing) Then
                tabIndex = Int32.Parse(Request.Params("tabindex"))
            End If
            If Not (Request.Params("sid") Is Nothing) Then
                sid = CType(Request.Params("sid"), String)
            End If
        End Sub

        Private Sub linkSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("~/Admin/TemplateSelect.aspx?tabindex=" & tabIndex & "&tabid=" & tabId & "&sid=" & sid)

        End Sub
    End Class
End Namespace
