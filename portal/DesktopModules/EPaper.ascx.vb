Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class EPaper
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl
		Enum SubscriptionState
			Disable = 0
			Enable = 1
			History = 2
		End Enum

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
		Protected WithEvents myDataList As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonSubscription As System.Web.UI.WebControls.LinkButton

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
			'If Not Page.IsPostBack Then
			Dim events As New ASPNET.StarterKit.Portal.Portal_SubscriptionDAOExtand
			myDataList.DataSource = events.GetEntitys(CType(Session("sid"), String), ModuleId, SubscriptionState.Enable, 3)
			myDataList.DataBind()
			'End If
		End Sub



        Private Sub LinkButtonSubscription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonSubscription.Click
            Response.Redirect("~/DesktopModules/EPaper/SubscriptionRegister.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & ModuleId)
        End Sub
    End Class
End Namespace