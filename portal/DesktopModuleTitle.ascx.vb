Namespace ASPNET.StarterKit.Portal

    Public MustInherit Class DesktopModuleTitle
        Inherits System.Web.UI.UserControl

        Protected ModuleTitle As System.Web.UI.WebControls.Label

        Public EditText As [String] = Nothing
        Public EditUrl As [String] = Nothing
        Protected WithEvents table1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents editTr As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents Editbutton As System.Web.UI.WebControls.ImageButton
        Public EditTarget As [String] = Nothing
        Public EditShow As Boolean = True

        Dim ModuleId As Integer
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
            ModuleId = portalModule.ModuleId
            ' Display Modular Title Text and Edit Buttons
            ModuleTitle.Text = portalModule.ModuleConfiguration.ModuleTitle
            'table1.Rows(1).Visible = False
            ' Display the Edit button if the parent portalmodule has configured the PortalModuleTitle User Control
            ' to display it -- and the current client has edit access permissions

            Dim au As New AuthorityBO

            If _portalSettings.AlwaysShowEditButton = True Or (au.checkAuthorityEdit(Context.User.Identity.Name, portalModule.ModuleId, 7, Me.Page)) Then
                'If _portalSettings.AlwaysShowEditButton = True Or (PortalSecurity.IsInRoles(portalModule.ModuleConfiguration.AuthorizedEditRoles) And Not (EditText Is Nothing)) Then
                Editbutton.Visible = True
                Editbutton.ImageUrl = "/PortalFiles/WebImage/" & Request.Params("sid") & "/" & Request.Params("sid") & "_0006.gif"

            Else
                Editbutton.Visible = False
                ' EditButton.Text = EditText
                ' Editbutton.n = 
                'EditButton.Target = EditTarget
                '   table1.Rows(1).Visible = True

            End If
            If EditShow = False Then
                Editbutton.Visible = False
                Exit Sub
            End If
        End Sub

        Private Sub Editbutton_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Editbutton.Click
            Dim tabid As Integer = 1
            Dim tabindex As Integer = 0
            If Not (Request.Params("tabid") Is Nothing) Then
                tabId = Int32.Parse(Request.Params("tabid"))
            End If
            If Not (Request.Params("tabindex") Is Nothing) Then
                tabIndex = Int32.Parse(Request.Params("tabindex"))
            End If
            Response.Redirect(EditUrl + "?tabid=" & tabid & "&tabindex=" & tabindex & "&mid=" + ModuleId.ToString + "&sid=" + CType(Session("sid"), String))
        End Sub
    End Class

End Namespace