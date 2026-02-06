Namespace ASPNET.StarterKit.Portal

    Public Class CDefault
        Inherits System.Web.UI.Page

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


            If Request.Browser("IsMobileDevice") = "true" Then

                'Response.Redirect("MobileDefault.aspx")
                Response.Redirect("DesktopDefault.aspx?sid=2")
            Else
                If Request.Params("sid") = "" Then

                    Response.Redirect("DesktopDefault.aspx?sid=2")
                Else
                    Response.Redirect("DesktopDefault.aspx?sid=" & Request.Params("sid"))
                End If
            End If

        End Sub

    End Class

End Namespace