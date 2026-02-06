Public Class SignUpForm
	Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

	'此為 Web Form 設計工具所需的呼叫。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label
	Protected WithEvents Label2 As System.Web.UI.WebControls.Label
	Protected WithEvents btnOK As System.Web.UI.WebControls.Button
	Protected WithEvents Label3 As System.Web.UI.WebControls.Label
	Protected WithEvents Label4 As System.Web.UI.WebControls.Label
	Protected WithEvents Label5 As System.Web.UI.WebControls.Label
	Protected WithEvents Label6 As System.Web.UI.WebControls.Label
	Protected WithEvents Label8 As System.Web.UI.WebControls.Label
	Protected WithEvents StudentBirth As System.Web.UI.WebControls.TextBox
	Protected WithEvents ClassType As System.Web.UI.WebControls.TextBox
	Protected WithEvents StudentName As System.Web.UI.WebControls.TextBox
	Protected WithEvents ClassNumber As System.Web.UI.WebControls.TextBox
	Protected WithEvents ClassEmail As System.Web.UI.WebControls.TextBox
	Protected WithEvents Remark As System.Web.UI.WebControls.TextBox
	Protected WithEvents StudentID As System.Web.UI.WebControls.TextBox
	Protected WithEvents Label9 As System.Web.UI.WebControls.Label
	Protected WithEvents lblresult As System.Web.UI.WebControls.Label
	Protected WithEvents ClassTitle As System.Web.UI.WebControls.Label

	'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
	'請勿刪除或移動它。
	Private designerPlaceholderDeclaration As System.Object

	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
		'請勿使用程式碼編輯器進行修改。
		InitializeComponent()
	End Sub

#End Region
	
	Dim itemid As Integer
	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'在這裡放置使用者程式碼以初始化網頁
		itemid = CType(Request.Params("itemid"), Integer)

		If Not IsPostBack Then
		End If
		GetClasses()


	End Sub

	Private Sub GetClasses()
		Dim EC As New ASPNET.StarterKit.Portal.AuditSystem.DAO.ClassesDAO
		Dim dt As DataTable
		dt = EC.GetEntity(itemid).Tables(0)
		If dt.Rows.Count > 0 Then
			ClassTitle.Text = CType(dt.Rows(0).Item("classtitle"), String)
		End If
	End Sub


	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
		Dim EC As New ASPNET.StarterKit.Portal.AuditSystem.DAO.ClassListDAO
		Dim ED As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EveryDayScheduleDAO


		EC.InsertEntity(1, 1, StudentID.Text.Trim, StudentName.Text.Trim, CType(StudentBirth.Text.Trim, Date), ClassType.Text.Trim, CType(ClassNumber.Text.Trim, Integer), ClassEmail.Text.Trim, Remark.Text.Trim, context.User.Identity.Name, Now(), Context.User.Identity.Name.Trim, Now(), "111111111", "", 0, Now())
		lblresult.Text = "報名成功!"
	End Sub

End Class
