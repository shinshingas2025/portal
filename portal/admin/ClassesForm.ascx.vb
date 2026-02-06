Namespace ASPNET.StarterKit.Portal

	Public MustInherit Class ClassesForm
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl

		Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents btnMore As System.Web.UI.WebControls.ImageButton
		Protected linkImage As String = ""
#Region " Web Form Designer Generated Code "

		'This call is required by the Web Form Designer.
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: This method call is required by the Web Form Designer
			'Do not modify it using the code editor.
			InitializeComponent()
		End Sub

#End Region

		'*******************************************************
		'
		' The Page_Load event handler on this User Control is
		' used to render a block of HTML or text to the page.  
		' The text/HTML to render is stored in the HtmlText 
		' database table.  This method uses the ASPNET.StarterKit.PortalHtmlTextDB()
		' data component to encapsulate all data functionality.
		'
		'*******************************************************

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

			' Obtain the selected item from the HtmlText table
			If Not IsPostBack Then
				GetClasses()
			End If

		End Sub

		Private Sub GetClasses()
			Dim Cl As New ASPNET.StarterKit.Portal.AuditSystem.DAO.ClassesDAO

			DataList1.DataSource = Cl.GetEntitys(0).Tables(0)
			DataList1.DataBind()


		End Sub

		Protected Function ChooseURL(ByVal EntityID As String, ByVal modID As String, ByVal URL As String) As String
			If IsEditable Then
				Return "~/admin/SignUpForm.aspx?EntityID=" & CStr(EntityID) & "&mid=" & modID & "&sid=" & CType(Session("sid"), String)
			Else
				Return URL
			End If
		End Function

		Protected Function ChooseTarget() As String
			If IsEditable Then
				Return "_self"
			Else
				Return "_new"
			End If
		End Function

		Protected Function ChooseTip(ByVal desc As String) As String
			If IsEditable Then
				Return "Edit"
			Else
				Return desc
			End If
		End Function


	End Class

End Namespace
