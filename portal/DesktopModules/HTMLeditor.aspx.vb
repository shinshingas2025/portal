Imports System.Data.SqlClient

Namespace ASPNET.StarterKit.Portal
    Public Class HTMLeditor
        Inherits System.Web.UI.Page

        Protected WithEvents DesktopText As System.Web.UI.WebControls.TextBox
        Protected WithEvents MobileSummary As System.Web.UI.WebControls.TextBox
        Protected WithEvents MobileDetails As System.Web.UI.WebControls.TextBox
        Protected WithEvents updateButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cancelButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Editor As System.Web.UI.HtmlControls.HtmlGenericControl

        Private moduleId As Integer = 0

#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

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
            ' Determine ModuleId of Announcements Portal Module
            moduleId = Int32.Parse(Request.Params("Mid"))

            ' Verify that the current user has access to edit this module
            If PortalSecurity.HasEditPermissions(moduleId) = False Then
                Response.Redirect("~/Admin/EditAccessDenied.aspx")
            End If

            If Page.IsPostBack = False Then

                ' Obtain a single row of text information
                Dim _text As New ASPNET.StarterKit.Portal.HtmlTextDB
                Dim dr As SqlDataReader = _text.GetHtmlText(moduleId, CType(Session("sid"), String))

                If dr.Read() Then

                    DesktopText.Text = Server.HtmlDecode(CType(dr("DesktopHtml"), String))
                    'MobileSummary.Text = Server.HtmlDecode(CType(dr("MobileSummary"), String))
                    'MobileDetails.Text = Server.HtmlDecode(CType(dr("MobileDetails"), String))

                Else

                    DesktopText.Text = "Todo: Add Content..."
                    'MobileSummary.Text = "Todo: Add Content..."
                    'MobileDetails.Text = "Todo: Add Content..."

                End If

                dr.Close()

                ' Store URL Referrer to return to portal
                ViewState("UrlReferrer") = Request.UrlReferrer.ToString()

            End If

        End Sub

    End Class
End Namespace