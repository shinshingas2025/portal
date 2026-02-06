Public Class EveryDayScheduleADD
	Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

	'此為 Web Form 設計工具所需的呼叫。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label
	Protected WithEvents Label2 As System.Web.UI.WebControls.Label
	Protected WithEvents btnOK As System.Web.UI.WebControls.Button
	Protected WithEvents txtDeadline As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtNotify As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
	Protected WithEvents Label3 As System.Web.UI.WebControls.Label
	Protected WithEvents Label4 As System.Web.UI.WebControls.Label
	Protected WithEvents txtReentityID As System.Web.UI.WebControls.Label

	'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
	'請勿刪除或移動它。
	Private designerPlaceholderDeclaration As System.Object

	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
		'請勿使用程式碼編輯器進行修改。
		InitializeComponent()
	End Sub

#End Region
	Dim AlertTitle As String
	Dim AlertDeadLine As String
	Dim ReEntityID As String
	Dim title As String
	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'在這裡放置使用者程式碼以初始化網頁


		If Not IsPostBack Then
			txtTitle.Text = CType(Session("AlertTitle"), String)
			txtDeadline.Text = CType(Session("AlertDeadLine"), String)
			txtReEntityID.text = CType(Session("ReEntityID"), String)

		End If


	End Sub


	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
		Dim ED As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EveryDayScheduleDAO


		ED.InsertEntity(1, 1, 2, ED.GetUIDbyUserID(Context.User.Identity.Name.Trim), CType(txtDeadline.Text.Trim, Date), CType(txtDeadline.Text.Trim, Date), 0, txtTitle.Text.Trim, "", "", txtReentityID.Text.Trim, Context.User.Identity.Name.Trim, Now(), Context.User.Identity.Name.Trim, Now(), "111111111", "", 0, Now(), CType(txtNotify.Text.Trim, Integer))
		Dim js As String
		js &= "<script>"
		js &= "window.close();"
		js &= "</script>"
		Me.RegisterStartupScript("showDialogBox", js)
	End Sub

End Class
