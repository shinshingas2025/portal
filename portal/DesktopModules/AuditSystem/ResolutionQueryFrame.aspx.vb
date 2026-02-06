Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class ResolutionQueryFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxName As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextboxConstitutionDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListDiscussion As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListParent As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListVariationType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListConstitutionInstitution As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListUndertakerInstitution As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxDocumentNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListQueryColumn As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxQuery As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonQuery As System.Web.UI.WebControls.Button
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList

		'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
		'請勿刪除或移動它。
		Private designerPlaceholderDeclaration As System.Object

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
			'請勿使用程式碼編輯器進行修改。
			InitializeComponent()
		End Sub

#End Region

		Private Const DefaultPermission As String = "111100100"
		Private Const DefaultPermissionGroup As String = "000000000"
		Private Const ResolutionAuthorityTarget As String = "Resolution"
		Private Const CodeAuthorityTarget As String = "NormalCode"
		Private UtilityObject As New AuditSystemUtility

		Private tabIndex As Integer = 0
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Private Const ActionColumnWidth As String = "40"
		Private Const ContentNumberColumnWidth As String = "48"
		Private Const ContentColumnWidth As String = "480"
		Private Const ContentOrderColumnWidth As String = "40"
		Protected Const NormalCodeBGColor As String = "#DEDECA"
		Protected Const FocusCodeBGColor As String = "#FFFF99"

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁()
			'Session("sid") = "9999"
			'If PortalSecurity.IsInRoles("Admins") = False Then
			'    Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If
			' Calculate userid
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If

			If Not (Request.Params("tabid") Is Nothing) Then
				tabId = Int32.Parse(Request.Params("tabid"))
			End If

			If Not (Request.Params("tabindex") Is Nothing) Then
				tabIndex = Int32.Parse(Request.Params("tabindex"))
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				InitialWebControl()
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
		End Sub
		Private Sub InitialWebControl()
			'Dim myNormalCodeDAO As New NormalCodeDAOExtand
			'Dim myNormalCodeDataSet As DataSet
			'Dim myNormalCodeCount As Integer = 0
			'Dim i As Integer = 0
			'Dim myListItem As ListItem
			'Dim myCodeName As String = ""
			'Dim myCodeID As String = ""

		End Sub

		Private Sub ButtonQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuery.Click
			Dim myResolutionDAO As New ResolutionDAOExtand
			Dim myResolutionDataSet As DataSet
			Dim myQueryColumn As String = ""
			Dim myQuery As String = ""

			myQueryColumn = DropDownListQueryColumn.SelectedValue

			If TextBoxQuery.Text.Trim.Length > 0 Then
				myQuery = TextBoxQuery.Text.Trim
				If myQueryColumn = "ResolutionNumber" Then
					myResolutionDataSet = myResolutionDAO.QueryByResolutionNumber(myQuery)
				Else
					If myQueryColumn = "Content" Then
						myResolutionDataSet = myResolutionDAO.QueryByContent(myQuery)
					Else
						'exception:unknown column
					End If
				End If
			Else
				myResolutionDataSet = myResolutionDAO.GetEntitys()
			End If

			If Not (myResolutionDataSet Is Nothing) Then
				myResolutionDataSet = UtilityObject.QueryPermissionFilter(myResolutionDataSet, ResolutionAuthorityTarget, Context.User.Identity.Name)
				DataList1.DataSource = myResolutionDataSet
				DataList1.DataBind()
			End If
		End Sub
		Protected Sub LinkButtonSelect_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
			Dim dk As String = ""
			dk = CType(DataList1.DataKeys(e.Item.ItemIndex), String)
			Response.Redirect("~/DesktopModules/AuditSystem/ResolutionAdminFrame.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&resolutionID=" & dk & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub
	End Class
End Namespace