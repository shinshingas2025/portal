Imports System.IO
Imports System.Math
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO
Namespace ASPNET.StarterKit.Portal.AuditSystem.Module
	Public Class EventAnserQuery
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents btnOK As System.Web.UI.WebControls.Button
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
		Protected WithEvents btnQuery As System.Web.UI.WebControls.Button
		Protected WithEvents txtYearS As System.Web.UI.WebControls.DropDownList
		Protected WithEvents txtMonthS As System.Web.UI.WebControls.DropDownList
		Protected WithEvents txtDayS As System.Web.UI.WebControls.DropDownList
		Protected WithEvents txtYearE As System.Web.UI.WebControls.DropDownList
		Protected WithEvents txtMonthE As System.Web.UI.WebControls.DropDownList
		Protected WithEvents txtDayE As System.Web.UI.WebControls.DropDownList

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
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Private formID As String = ""
		Private action As String = ""
		Private processID As String = ""
		Private groupID As String = ""

		Private Const PriorityCodeGroupID As String = "2006010100000001"
		Private Const MainOfficeCodeGroupID As String = "2006010100000003"
		Private Const MainBranchCodeGroupID As String = "2006010100000004"
		Private Const MainBranchUndertakerCodeGroupID As String = "2006010100000005"
		Private Const AssistOfficeCodeGroupID As String = "2006010100000006"
		Private Const AssistBranchCodeGroupID As String = "2006010100000007"
		Private Const StateCodeGroupID As String = "2006010100000008"
		Private AffairCodeGroupID As String = ""

		Protected Const ActionWidth As String = "48"
		Protected Const ProcessDateWidth As String = "80"
		Protected Const ProcessStateWidth As String = "300"
		Protected Const NoteWidth As String = "90"
		Protected Const NormalAttributeWidth As String = "32"
		Protected Const NewsAttributeWidth As String = "32"
		Protected Const InstructionAttributeWidth As String = "32"
		Protected Const NormalProcessBGColor As String = "#DEDECA"
		Protected Const FocusProcessBGColor As String = "#FFFF99"
		Protected Const ProcessStateColumnWidth As Integer = 44
		Protected Const NoteColumnWidth As Integer = 8

		Enum AttributeType
			Normal = 1
			NewsRelease = 2
			CouncilmanInstruction = 3
		End Enum

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

			'在這裡放置使用者程式碼以初始化網頁




			'在這裡放置使用者程式碼以初始化網頁()
			'Session("sid") = "9999"
			'If PortalSecurity.IsInRoles("Admins") = False Then
			'    Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If
			' Calculate userid
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
				sid = "2"
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

			If Not (Request.Params("formID") Is Nothing) Then
				formID = Request.Params("formID")
			End If

			If Not (Request.Params("processID") Is Nothing) Then
				processID = Request.Params("processID")
			End If

			'AlterAffairCodeGroup(groupID)

			If Not (Request.Params("action") Is Nothing) Then
				action = Request.Params("action")
			End If

			If Not IsPostBack Then
				Call initComponent()
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				'PageLoad()

			End If

		End Sub

		Private Sub initComponent()
			txtDayS.Items.Clear()
			Dim i As Integer
			For i = 1 To 31
				txtDayS.Items.Add(CStr(i))
				txtDayE.Items.Add(CStr(i))
			Next i

		End Sub


		Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
			queryREC()
		End Sub

		Private Sub queryREC()
			Dim objSPDAO As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EventAnserDAO
			Dim txtDateS As String
			Dim txtDateE As String
			Dim CreatorID As String
			Dim ModifierID As String
			CreatorID = ""
			ModifierID = ""
			txtDateS = CType(CInt(txtYearS.SelectedValue) + 1911, String) & "/" & txtMonthS.SelectedValue & "/" & txtDayS.SelectedValue
			txtDateE = CType(CInt(txtYearE.SelectedValue) + 1911, String) & "/" & txtMonthE.SelectedValue & "/" & txtDayE.SelectedValue
			DataGrid1.DataSource = objSPDAO.GetEntitys(txtDateS, txtDateE)
			DataGrid1.DataBind()
		End Sub


		Private Sub DataGrid1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.DeleteCommand
			Dim EntityID As String
			EntityID = CType(DataGrid1.DataKeys(e.Item.ItemIndex), String)
			Dim objSPDAO As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EventAnserDAO
			objSPDAO.DeleteEntity(EntityID)
			queryREC()

		End Sub

		Private Sub DataGrid1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.EditCommand
			Dim EntityID As String
			EntityID = CType(DataGrid1.DataKeys(e.Item.ItemIndex), String)
			Response.Redirect("EventAnserEdit.aspx?EntityID=" & EntityID)
		End Sub


		Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
			DataGrid1.CurrentPageIndex = e.NewPageIndex
			queryREC()
		End Sub
	End Class
End Namespace
