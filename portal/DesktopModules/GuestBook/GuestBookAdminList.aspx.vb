Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class GuestBookAdminList
		Inherits System.Web.UI.Page
		Protected WithEvents myDataGrid As System.Web.UI.WebControls.DataGrid
		Protected moduleId As Integer = 0
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected sid As String = "9999"
		Protected tabid As Integer = 0
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected tabindex As Integer = 0

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
		Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

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
				moduleId = Int32.Parse(Request.Params("mid"))
			End If
			If Not (Request.Params("tabid") Is Nothing) Then
				tabid = Int32.Parse(Request.Params("tabid"))
			End If

			If Not (Request.Params("tabindex") Is Nothing) Then
				tabindex = Int32.Parse(Request.Params("tabindex"))
			End If
			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub

		Sub PageChanged(ByVal Sender As Object, ByVal e As DataGridPageChangedEventArgs)
			myDataGrid.CurrentPageIndex = e.NewPageIndex
			PageLoad()
		End Sub

		Sub PageLoad()
			Dim events As New ASPNET.StarterKit.Portal.Portal_GuestBookDAOExtand
			myDataGrid.DataSource = events.GetEntitys(sid, moduleId)
			myDataGrid.DataBind()
		End Sub

		Private Sub myDataGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myDataGrid.SelectedIndexChanged
			Dim dg As DataGridItem
			dg = myDataGrid.SelectedItem
			Dim dk As String
			dk = CType(myDataGrid.DataKeys(dg.ItemIndex), String)
			Response.Redirect("~/DesktopModules/GuestBook/GuestBookReview.aspx?sid=" & sid & "&mid=" & moduleId & "&EntityID=" & dk & "&tabid=" & tabid & "&tabindex=" & tabindex)
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class

End Namespace