
Public Class EditClasses
	Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

	'此為 Web Form 設計工具所需的呼叫。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
	Protected WithEvents txtResult As System.Web.UI.WebControls.Label
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label
	Protected WithEvents Label2 As System.Web.UI.WebControls.Label
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label
	Protected WithEvents ClassTitle As System.Web.UI.WebControls.TextBox
	Protected WithEvents StartDate As System.Web.UI.WebControls.TextBox
	Protected WithEvents EndDate As System.Web.UI.WebControls.TextBox

	'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
	'請勿刪除或移動它。
	Private designerPlaceholderDeclaration As System.Object

	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
		'請勿使用程式碼編輯器進行修改。
		InitializeComponent()
	End Sub

#End Region
	Dim oldPassword As String
	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'在這裡放置使用者程式碼以初始化網頁

		If Not IsPostBack Then

		End If

	End Sub
	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim objEC As New ASPNET.StarterKit.Portal.AuditSystem.DAO.ClassesDAO

		objEC.InsertEntity(0, 0, ClassTitle.Text.Trim, CType(StartDate.Text.Trim, Date), CType(EndDate.Text.Trim, Date), 0, "", Context.User.Identity.Name.Trim, Now(), Context.User.Identity.Name.Trim, Now(), "111111111", "", 0, Now())

		txtResult.Text = "新增成功!"

		'    Call returnValue("True")

	End Sub

	Private Sub returnValue(Optional ByVal value As String = "")
		Dim js As String
		js &= "<script>"
		js &= "window.close();"
		js &= "</script>"
		Me.RegisterStartupScript("showDialogBox", js)

	End Sub
End Class
