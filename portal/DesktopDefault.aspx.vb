Namespace ASPNET.StarterKit.Portal

    Public Class DesktopDefault
        Inherits System.Web.UI.Page

        Protected LeftPane As System.Web.UI.HtmlControls.HtmlTableCell
        Protected ContentPane As System.Web.UI.HtmlControls.HtmlTableCell
        Protected RightPane As System.Web.UI.HtmlControls.HtmlTableCell



#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

#End Region

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            '
            ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
            '
            InitializeComponent()

            '*********************************************************************
            '
            ' Page_Init Event Handler
            '
            ' The Page_Init event handler executes at the very beginning of each page
            ' request (immediately before Page_Load).
            '
            ' The Page_Init event handler below determines the tab index of the currently
            ' requested portal view, and then calls the PopulatePortalSection utility
            ' method to dynamically populate the left, center and right hand sections
            ' of the portal tab.
            '
            '*********************************************************************
            ' Obtain PortalSettings from Current Context
            If Request.Params("sid") = "" And Session("sid") Is Nothing Then
                Session("sid") = "2"
            Else
                If Request.Params("sid") <> "" Then
                    Session("sid") = Request.Params("sid")
                End If
            End If

            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' Ensure that the visiting user has access to the current page
            ' If PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AuthorizedRoles) = False And PortalSecurity.IsInRoles("s" & CType(Session("sid"), String)) = False Then
            'Response.Redirect("~/Admin/AccessDenied.aspx")
            'End If

            ' Dynamically inject a signin login module into the top left-hand corner
            ' of the home page if the client is not yet authenticated
            If Request.IsAuthenticated = False And _portalSettings.ActiveTab.TabIndex = 0 Then
                LeftPane.Controls.Add(Page.LoadControl("~/DesktopModules/SignIn.ascx"))
                LeftPane.Visible = True
            End If

            ' Dynamically Populate the Left, Center and Right pane sections of the portal page
            If _portalSettings.ActiveTab.Modules.Count > 0 Then

                ' Loop through each entry in the configuration system for this tab
                Dim _moduleSettings As ModuleSettings
                For Each _moduleSettings In _portalSettings.ActiveTab.Modules

                    Dim parent As Control = Page.FindControl(_moduleSettings.PaneName)

                    ' If no caching is specified, create the user control instance and dynamically
                    ' inject it into the page.  Otherwise, create a cached module instance that
                    ' may or may not optionally inject the module into the tree
                    If _moduleSettings.CacheTime = 0 Then

                        Dim portalModule As PortalModuleControl = CType(Page.LoadControl(_moduleSettings.DesktopSrc), PortalModuleControl)

                        portalModule.PortalId = _portalSettings.PortalId
                        portalModule.ModuleConfiguration = _moduleSettings

                        parent.Controls.Add(portalModule)

                    Else

                        Dim portalModule As New CachedPortalModuleControl

                        portalModule.PortalId = _portalSettings.PortalId
                        portalModule.ModuleConfiguration = _moduleSettings

                        parent.Controls.Add(portalModule)

                    End If

                    ' Dynamically inject separator break between portal modules
                    parent.Controls.Add(New LiteralControl("<" + "br" + ">"))
                    parent.Visible = True

                Next _moduleSettings

            End If


        End Sub



		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'If Context.User.Identity.Name.Trim <> "" And CType(Session("Notify"), Boolean) = False Then
            '	Dim ED As New ASPNET.StarterKit.Portal.AuditSystem.DAO.EveryDayScheduleDAO

            '	If ED.GetAlertEventByDay(Context.User.Identity.Name.Trim).Tables(0).Rows.Count > 0 Then

            '		PopScheduleAlert()
            '	End If
            '	Session("Notify") = True

            'End If
		End Sub




		Private Sub PopScheduleAlert()
			Dim Javascript As String
			Dim sfeatures As String
			Dim URL As String
			Dim returnObject As WebControls.TextBox
			Dim returnText As String

			URL = Context.User.Identity.Name.Trim

			sfeatures = "dialogHeight:"

			returnText = CType(ShowDialogBox(returnObject, URL, 410, 350, 0, 0, True), String)


		End Sub

		Private Function ShowDialogBox(ByVal returnValueobj As WebControls.TextBox, ByVal url As String, ByVal width As Integer, ByVal height As Integer, ByVal x As Integer, ByVal y As Integer, Optional ByVal isCenter As Boolean = False) As Boolean

			Dim Javascript As String

			Dim sfeatures As String = ""

			sfeatures &= "dialogHeight:" & height & "px;"

			sfeatures &= "dialogWidth:" & width & "px;"

			If isCenter = False Then
				sfeatures &= "dialogLeft:" & x & "px;"
				sfeatures &= "dialogTop:" & y & "px;"
			End If

			Javascript = vbCrLf & "<script>"
			'	Javascript &= vbCrLf & "Form1." & returnValueobj.ClientID & ".value=window.showModalDialog('../eiis/view/iFrame.aspx?url=" & url & "','','" & sfeatures & "');"
			Javascript &= vbCrLf & "window.showModalDialog('eiis/view/iFrame.aspx?url=../../admin/EveryDaySchedule.aspx','','" & sfeatures & "');"

			Javascript &= vbCrLf & "</script>"

			Me.RegisterStartupScript("ShowDialog", Javascript)

		End Function
	End Class

End Namespace