Public Class EveryDaySchedule
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label

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
		'在這裡放置使用者程式碼以初始化網頁


		If Not IsPostBack Then
			GetREC()
		End If


	End Sub
	Private Sub GetREC()
		Dim ED As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EveryDayScheduleDAO

		DataGrid1.DataSource = ED.GetAlertEventByDay(Context.User.Identity.Name.Trim)

		DataGrid1.DataBind()
	End Sub

	Private Sub DataGrid1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.DeleteCommand
		Dim ED As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EveryDayScheduleDAO
		Dim EntityID As String
		EntityID = CType(DataGrid1.DataKeys(e.Item.ItemIndex), String)
		ED.DeleteAlertEventByDay(EntityID)
		GetREC()

	End Sub
End Class
