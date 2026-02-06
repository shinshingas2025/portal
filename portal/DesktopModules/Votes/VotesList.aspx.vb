Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class VotesList
		Inherits System.Web.UI.Page
		Protected WithEvents myDataGrid As System.Web.UI.WebControls.DataGrid
		Protected moduleId As Integer = 0
		Protected sid As String = "9999"
		Protected tabId As Integer = 0
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected tabIndex As Integer = 0

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
			If Not (Request.Params("tabid") Is Nothing) Then
				tabId = Int32.Parse(Request.Params("tabid"))
			End If
			If Not (Request.Params("tabindex") Is Nothing) Then
				tabIndex = Int32.Parse(Request.Params("tabindex"))
			End If
			If Not (Request.Params("sid") Is Nothing) Then
				sid = CType(Request.Params("sid"), String)
			End If
			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
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
			moduleId = Int32.Parse(Request.Params("Mid"))
			sid = Request.Params("sid")
			Dim events As New ASPNET.StarterKit.Portal.Portal_QuestionDAOExtand
			myDataGrid.DataSource = events.GetEntitys(sid, moduleId, Now)
			myDataGrid.DataBind()
		End Sub

		Private Sub myDataGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myDataGrid.SelectedIndexChanged
			Dim dg As DataGridItem
			dg = myDataGrid.SelectedItem
			Dim dk As String
			dk = CType(myDataGrid.DataKeys(dg.ItemIndex), String)
			Response.Redirect("~/DesktopModules/Votes/VoteOne.aspx?mid=" & moduleId & "&sid=" & sid & "&questionid=" & dk & "&tabindex=" & tabIndex & "&tabid=" & tabId)
		End Sub

		Public Sub myDataGrid_EditedIndexChanged(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles myDataGrid.EditCommand
			Dim dg As DataGridItem
			Dim dk As String
			dg = CType(myDataGrid.Items(e.Item.ItemIndex), DataGridItem)
			dk = CType(myDataGrid.DataKeys(dg.ItemIndex), String)
			Response.Redirect("~/DesktopModules/Votes/VotesResult.aspx?mid=" & moduleId & "&sid=" & sid & "&questionid=" & dk & "&tabindex=" & tabIndex & "&tabid=" & tabId)
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class


End Namespace