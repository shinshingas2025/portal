Namespace ASPNET.StarterKit.Portal

    Public Class WebSiteList
        Inherits System.Web.UI.Page
        'Inherits ASPNET.StarterKit.Portal.PortalModuleControl
        Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList

        Protected linkImage As String = ""
        Protected WithEvents btnSearch As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
        Private moduleId As Integer = 0
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Dim IsEditable As Boolean = False

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

        '****************************************************************
        '
        ' The Page_Load event on this Page is used to obtain the ModuleId
        ' of the image module to edit.
        '
        ' It then uses the ASP.NET configuration system to populate the page's
        ' edit controls with the image details.
        '
        '****************************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Determine ModuleId of Announcements Portal Module
            moduleId = Int32.Parse(Request.Params("Mid"))

            ' Verify that the current user has access to edit this module
            'If PortalSecurity.HasEditPermissions(moduleId) = False Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            'End If

            Dim au As New AuthorityBO

            If Not au.checkAuthorityEdit(Context.User.Identity.Name, moduleId, 7, Me.Page) Then
                ' Response.Redirect("~/Admin/EditAccessDenied.aspx")
                IsEditable = True
            End If
            au = Nothing

            'If IsEditable Then
            '    linkImage = "~/images/edit.gif"
            'Else
            '    linkImage = "~/images/navlink.gif"
            'End If

            If Page.IsPostBack = False Then

                Dim objSite As New SiteDB
                DataList1.DataSource = objSite.GetAllSite.Tables(0)
                DataList1.DataBind()
                ' Store URL Referrer to return to portal
                ViewState("UrlReferrer") = Request.UrlReferrer.ToString()

            End If

        End Sub
        Protected Function ChooseURL(ByVal itemID As String, ByVal modID As String, ByVal URL As String) As String
            If IsEditable Then
                Return "~/DesktopModules/EditWebSiteMgt.aspx?ItemID=" & CStr(itemID) & "&mid=" & modID & "&sid=" & CType(Session("sid"), String)
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

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Searchsite(txtSearch.Text)
        End Sub

        Private Sub Searchsite(ByVal strSearch As String)
            Dim objSite As New SiteDB

            DataList1.DataSource = objSite.SearchSite(strSearch)
            DataList1.DataBind()

            objSite = Nothing
        End Sub


    End Class

End Namespace