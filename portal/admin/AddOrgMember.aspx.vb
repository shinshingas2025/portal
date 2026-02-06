Imports System.IO
Public Class AddOrgMember
	Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

	'此為 Web Form 設計工具所需的呼叫。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label
	Protected WithEvents Label3 As System.Web.UI.WebControls.Label
	Protected WithEvents btnQuery As System.Web.UI.WebControls.Button
	Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
	Protected WithEvents btnOK As System.Web.UI.WebControls.Button
	Protected WithEvents Cname As System.Web.UI.WebControls.TextBox
	Protected WithEvents TelCompany As System.Web.UI.WebControls.TextBox

	'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
	'請勿刪除或移動它。
	Private designerPlaceholderDeclaration As System.Object

	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
		'請勿使用程式碼編輯器進行修改。
		InitializeComponent()
	End Sub

#End Region


	Dim rootnum As String = "0"
	Dim sid As String
	Dim moduleId As Integer = 0
	Dim ObjID As String = "0"
	Dim Dept As String = ""

	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'在這裡放置使用者程式碼以初始化網頁
		sid = CType(Session("sid"), String)
		moduleId = Int32.Parse(Request.Params("Mid"))
		Dept = Request.Params("ObjID")

		Dim au As New AuthorityBO

		If Not au.checkAuthorityEdit(Context.User.Identity.Name, moduleId, 7, Me.Page) Then
			Response.Redirect("~/Admin/EditAccessDenied.aspx")
		End If

		au = Nothing
		If Not IsPostBack() Then
			ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
		End If
	End Sub

	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
		Dim selIndex As Integer

		Dim datagriditem As datagriditem
		datagriditem = DataGrid1.SelectedItem
		Dim UserID As String
		UserID = datagriditem.Cells(1).Text.Trim
		Dim objUserInfoBo As New UserInfoBO
		Dim objuser As New User
		objuser.UID = UserID
		objuser.Dept = Dept
		Dim flag As Boolean
		flag = objUserInfoBo.updateUserDept(objuser)


		Response.Redirect("EditAllContextViewSetting.aspx?sid=" & sid & "&mid=" & moduleId)

	End Sub

	Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
		Dim objUser As New User
		objUser.Cname = Cname.Text.Trim
		objUser.TelCompany = TelCompany.Text.Trim
		Dim dt As DataTable
		Dim objUserInfo As New UserInfoBO
		dt = objUserInfo.SearchUser(objUser)
		DataGrid1.DataSource = dt
		DataGrid1.DataBind()
	End Sub
End Class