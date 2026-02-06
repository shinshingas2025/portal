Imports System.IO
Imports System.Math
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO
Namespace ASPNET.StarterKit.Portal.AuditSystem.Module
	Public Class EventAnserEdit
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents Label2 As System.Web.UI.WebControls.Label
		Protected WithEvents Label4 As System.Web.UI.WebControls.Label
		Protected WithEvents Label6 As System.Web.UI.WebControls.Label
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents txtYear As System.Web.UI.WebControls.DropDownList
		Protected WithEvents txtMonth As System.Web.UI.WebControls.DropDownList
		Protected WithEvents txtDay As System.Web.UI.WebControls.DropDownList
		Protected WithEvents btnOK As System.Web.UI.WebControls.Button
		Protected WithEvents EntityID As System.Web.UI.WebControls.Label
		Protected WithEvents Newspaper As System.Web.UI.WebControls.TextBox
		Protected WithEvents Version As System.Web.UI.WebControls.TextBox
		Protected WithEvents aaa As System.Web.UI.WebControls.Label
		Protected WithEvents Point As System.Web.UI.WebControls.TextBox
		Protected WithEvents Remark As System.Web.UI.WebControls.TextBox
		Protected WithEvents Subject As System.Web.UI.WebControls.TextBox
		Protected WithEvents Label5 As System.Web.UI.WebControls.Label
		Protected WithEvents Answer As System.Web.UI.WebControls.TextBox
		Protected WithEvents Label3 As System.Web.UI.WebControls.Label
		Protected WithEvents Recorder As System.Web.UI.WebControls.TextBox
		Protected WithEvents Label8 As System.Web.UI.WebControls.Label
		Protected WithEvents btnBackup As System.Web.UI.WebControls.Button
		Protected WithEvents lblResult As System.Web.UI.WebControls.Label

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
			Call initComponent()

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
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				'PageLoad()

			End If

			If Not (Request.Params("EntityID") Is Nothing) Then
				EntityID.Text = Request.Params("EntityID")
				If Not IsPostBack Then
					Queryrec(EntityID.Text)
				End If
			Else
				EntityID.Text = "自動給號"
			End If

		End Sub

		Private Sub initComponent()
			txtDay.Items.Clear()
			Dim i As Integer
			For i = 1 To 31
				txtDay.Items.Add(CStr(i))
			Next i

		End Sub

		Private Sub Queryrec(ByVal EntityID As String)
			Dim objSPDAO As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EventAnserDAO
			Dim dt As DataTable
			dt = objSPDAO.GetEntity(EntityID).Tables(0)
			Dim strDate As String
			txtYear.SelectedValue = CType(Year(CType(dt.Rows(0).Item("AnnDate"), Date)) - 1911, String)
			txtMonth.SelectedValue = CType(Month(CType(dt.Rows(0).Item("AnnDate"), Date)), String)
			txtDay.SelectedValue = CType(Day(CType(dt.Rows(0).Item("AnnDate"), Date)), String)
			Newspaper.Text = CType(dt.Rows(0).Item("Newspaper"), String)
			Version.Text = CType(dt.Rows(0).Item("Version"), String)
			Recorder.Text = CType(dt.Rows(0).Item("Recorder"), String)
			Subject.Text = CType(dt.Rows(0).Item("Subject"), String)
			Point.Text = CType(dt.Rows(0).Item("Point"), String)
			Answer.Text = CType(dt.Rows(0).Item("Answer"), String)
			Remark.Text = CType(dt.Rows(0).Item("Remark"), String)
		End Sub
		Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
			Dim objSPDAO As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EventAnserDAO
			Dim ED As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EveryDayScheduleDAO
			Dim txtDate As String
			Dim CreatorID As String
			Dim ModifierID As String
			CreatorID = Context.User.Identity.Name.Trim
			ModifierID = Context.User.Identity.Name.Trim
			txtDate = CType(CInt(txtYear.SelectedValue) + 1911, String) & "/" & txtMonth.SelectedValue & "/" & txtDay.SelectedValue

			If EntityID.Text = "自動給號" Then
				objSPDAO.InsertEntity(1, Context.User.Identity.Name, Now(), Context.User.Identity.Name, Now(), "111111111", "", 0, CType("1911/1/1", Date), Newspaper.Text.Trim, Version.Text.Trim, Recorder.Text.Trim, CType(txtDate, Date), Subject.Text.Trim, Point.Text.Trim, Answer.Text.Trim, Remark.Text.Trim)
				lblResult.Text = "新增成功"
			Else
				objSPDAO.UpdateEntity(EntityID.Text, Context.User.Identity.Name, Now(), Context.User.Identity.Name, Now(), "111111111", "", 0, CType("1911/1/1", Date), Newspaper.Text.Trim, Version.Text.Trim, Recorder.Text.Trim, CType(txtDate, Date), Subject.Text.Trim, Point.Text.Trim, Answer.Text.Trim, Remark.Text.Trim)
				lblResult.Text = "更新成功"
			End If


		End Sub




		Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
			Response.Redirect("EventAnserQuery.aspx")
		End Sub
	End Class
End Namespace
