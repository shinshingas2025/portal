Imports System.IO

Namespace ASPNET.StarterKit.Portal

    Public Class DetailHtml2
        Inherits System.Web.UI.Page

        Protected WithEvents cancelButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image
        Protected WithEvents literDetail As System.Web.UI.WebControls.Literal
        Protected WithEvents literdesktop As System.Web.UI.WebControls.Literal
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label

        Private moduleId As Integer = 0

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
        ' of the xml module to edit.
        '
        ' It then uses the ASPNET.StarterKit.PortalHtmlTextDB() data component
        ' to populate the page's edit controls with the text details.
        '
        '****************************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Determine ModuleId of Announcements Portal Module
            moduleId = Int32.Parse(Request.Params("Mid"))

            ' Verify that the current user has access to edit this module
            ' If PortalSecurity.HasEditPermissions(moduleId) = False Then
            ' Response.Redirect("~/Admin/EditAccessDenied.aspx")
            ' End If
            Dim au As New AuthorityBO
            If Not au.checkAuthorityEdit(Context.User.Identity.Name, moduleId, 7, Me.Page) Then
                Response.Redirect("~/Admin/EditAccessDenied.aspx")
            End If
            au = Nothing

            If Page.IsPostBack = False Then

                ' Obtain a single row of text information
                Dim _text As New ASPNET.StarterKit.Portal.HtmlTextDB
                Dim dr As SqlDataReader = _text.GetHtmlText(moduleId, CType(Session("sid"), String))

                If dr.Read() Then

                    literdesktop.Text = Server.HtmlDecode(CType(dr("DesktopHtml"), String))
                    literDetail.Text = Server.HtmlDecode(CType(dr("DetailHtml"), String))
                    Image1.ImageUrl = "/PortalFiles/UpLoadFiles/Images/" & CType(dr("filename"), String)

                Else
                    Image1.ImageUrl = "../images/Example.gif"

                End If

                dr.Close()

                ' Store URL Referrer to return to portal
                ViewState("UrlReferrer") = Request.UrlReferrer.ToString()

            End If

        End Sub




        '****************************************************************
        '
        ' The CancelBtn_Click event handler on this Page is used to cancel
        ' out of the page, and return the user back to the portal home
        ' page.
        '
        '****************************************************************'
        Private Sub CancelBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelButton.Click

            ' Redirect back to the portal home page
            Response.Redirect(CType(ViewState("UrlReferrer"), String))

        End Sub


    End Class

End Namespace