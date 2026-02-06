Namespace ASPNET.StarterKit.Portal

    Public MustInherit Class SiteLogo
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl

        Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents imglogo As System.Web.UI.WebControls.Image
        Protected WithEvents btnMore As System.Web.UI.WebControls.ImageButton

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
            Dim objSiteDB As New ASPNET.StarterKit.Portal.SiteDB
            Dim dt As DataTable = objSiteDB.GetSiteBySid(CType(Session("sid"), Integer)).Tables(0)

            If dt.Rows.Count > 0 Then

                imglogo.ImageUrl = "/PortalFiles/UpLoadFiles/schoollogo/" & CType(dt.Rows(0).Item("imagelogo"), String)
            Else
                imglogo.ImageUrl = "../images/Example.gif"

            End If

            ' Close the datareader
            dt = Nothing

        End Sub


    End Class

End Namespace
