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

    '*******************************************************
    '
    ' The Page_Load event on this page is used to personalize
    ' the welcome message seen by returning ASP.NET Commerce Starter Kit users.
    ' It does this by retrieving a client-side cookie
    ' (persisted on the client in the Login.aspx and
    ' register.aspx pages) and updating a label control.
    '
    '*******************************************************
    Sub Page_Load(ByVal Src As Object, ByVal Args As EventArgs)
        'Dim strsql, strmyid As String
        'Response.Write(Session("LoginID"))
        'Response.End()

        If (Session("LoginID") Is Nothing) Then
            Response.Redirect("login.aspx")
        End If
    End Sub

End Class
