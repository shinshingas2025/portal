Namespace ASPNET.StarterKit.Portal

	Public MustInherit Class DesktopModuleBottom
		Inherits System.Web.UI.UserControl


		Public EditText As [String] = Nothing
		Public EditUrl As [String] = Nothing
		Protected WithEvents table1 As System.Web.UI.HtmlControls.HtmlTable
		Protected WithEvents editTr As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents MoreButton As System.Web.UI.WebControls.ImageButton
        Public EditTarget As [String] = Nothing
        Protected tabid As Integer = 1
        Protected tabindex As Integer = 0
        Dim moduleID As Integer

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

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

			' Obtain PortalSettings from Current Context
			Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

			' Obtain reference to parent portal module
			Dim portalModule As PortalModuleControl = CType(Me.Parent, PortalModuleControl)
            moduleID = portalModule.ModuleId
 

            ' Display Modular Title Text and Edit Buttons
            'ModuleTitle.Text = portalModule.ModuleConfiguration.ModuleTitle
            'table1.Rows(1).Visible = False
            ' Display the Edit button if the parent portalmodule has configured the PortalModuleTitle User Control
            ' to display it -- and the current client has edit access permissions
            'If _portalSettings.AlwaysShowEditButton = True Or (PortalSecurity.IsInRoles(portalModule.ModuleConfiguration.AuthorizedEditRoles) And Not (EditText Is Nothing)) Then

            MoreButton.ImageUrl = "/PortalFiles/WebImage/" & CType(Session("sid"), String) & "/" & CType(Session("sid"), String) & "_0008.gif"

            '   table1.Rows(1).Visible = True

            'End If

        End Sub

        Private Sub MoreButton_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles MoreButton.Click
            If Not (Request.Params("tabid") Is Nothing) Then
                tabid = Int32.Parse(Request.Params("tabid"))
            End If
            If Not (Request.Params("tabindex") Is Nothing) Then
                tabindex = Int32.Parse(Request.Params("tabindex"))
            End If

            Response.Redirect(EditUrl + "?mid=" + moduleID.ToString() + "&sid=" + CType(Session("sid"), String) + "&tabid=" + CType(tabid, String) + "&tabindex=" + CType(tabindex, String))

        End Sub
    End Class

End Namespace