Imports System.IO
Public Class AddAllContextViewSetting
	Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

	'此為 Web Form 設計工具所需的呼叫。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label
	Protected WithEvents numberid As System.Web.UI.WebControls.Label
	Protected WithEvents deptName As System.Web.UI.WebControls.TextBox
	Protected WithEvents depttel As System.Web.UI.WebControls.TextBox
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label
	Protected WithEvents Label2 As System.Web.UI.WebControls.Label
	Protected WithEvents Label3 As System.Web.UI.WebControls.Label
	Protected WithEvents btnOK As System.Web.UI.WebControls.Button
	Protected WithEvents Label4 As System.Web.UI.WebControls.Label
	Protected WithEvents Manager As System.Web.UI.WebControls.TextBox

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
	Dim PID As String = "0"
	Dim ObjID As String = ""

	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'在這裡放置使用者程式碼以初始化網頁
		sid = CType(Session("sid"), String)
		moduleId = Int32.Parse(Request.Params("Mid"))
		PID = Request.Params("PID")
		ObjID = Request.Params("ObjID")
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
		Dim objDeptEntity As New DeptExtendOrgEntity
		objDeptEntity.objID = ""
		objDeptEntity.objName = deptName.Text.Trim
		objDeptEntity.objValue = ""
		objDeptEntity.PID = PID
		objDeptEntity.SEQNO = "1"
		objDeptEntity.srcName = "sysDept"
		objDeptEntity.state = "1"
		objDeptEntity.Manager = Manager.Text.Trim
		objDeptEntity.Depttel = depttel.Text.Trim
		objDeptEntity.DeptName = deptName.Text.Trim
		objDeptEntity.DeptID = ""
		objDeptEntity.Creater = ""

		Dim objDept As New OrgBO
		Dim flag As Boolean
		flag = objDept.AddDept(objDeptEntity)

		Response.Redirect(CType(ViewState("UrlReferrer"), String))

	End Sub
End Class