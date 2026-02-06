Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class GuestBook
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl
		Protected WithEvents myDataList As System.Web.UI.WebControls.DataList
		Protected mid As Integer = 0
		Protected sid As String = "9999"
		Protected tabid As Integer = 0
		Protected WithEvents LinkButtonAdd As System.Web.UI.WebControls.LinkButton
		Protected tabindex As Integer = 0

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents GuestBookSubject As System.Web.UI.WebControls.Label

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
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				mid = Int32.Parse(Request.Params("mid"))
			End If

			If Not (Request.Params("tabid") Is Nothing) Then
				tabid = Int32.Parse(Request.Params("tabid"))
			End If

			If Not (Request.Params("tabindex") Is Nothing) Then
				tabindex = Int32.Parse(Request.Params("tabindex"))
			End If

			Dim events As New ASPNET.StarterKit.Portal.Portal_GuestBookDAOExtand
			myDataList.DataSource = events.GetEntitys(CType(Session("sid"), String), ModuleId, 6)
			myDataList.DataBind()
		End Sub

		Private Sub LinkButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonAdd.Click
			Response.Redirect("~/DesktopModules/GuestBook/GuestBookAdd.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & ModuleId & "&tabid=" & tabid & "&tabindex=" & tabindex)
		End Sub
	End Class
End Namespace