Namespace ASPNET.StarterKit.Portal

    Public Class IFrameModule
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl
        Protected WithEvents Iframe1 As System.Web.UI.HtmlControls.HtmlGenericControl



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
        ' The Page_Load event handler on this User Control uses
        ' the Portal configuration system to obtain image details.
        ' It then sets these properties on an <asp:Image> server control.
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objIframe As New Portal_iframe
            Dim dt As DataTable
            dt = objIframe.Getiframe(ModuleId).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim iFrameSrc As String = CType(dt.Rows(0).Item("url"), String)
                Dim iFrameHeight As Integer = CType(dt.Rows(0).Item("FrameHeight"), Integer)
                Dim iFrameWidth As Integer = CType(dt.Rows(0).Item("FrameWidth"), Integer)

                objIframe = Nothing
                ' Set Image Source, Width and Height Properties
                If Not (iFrameSrc Is Nothing) And iFrameSrc <> "" Then
                    Me.Iframe1.Attributes("src") = iFrameSrc
                End If

                If iFrameWidth = 0 Then

                    Me.Iframe1.Attributes("Width") = "100%"
                Else

                    Me.Iframe1.Attributes("Width") = CType(iFrameWidth, String)
                End If

                If iFrameHeight = 0 Then
                    Me.Iframe1.Attributes("Height") = "100%"
                Else
                    Me.Iframe1.Attributes("Height") = CType(iFrameHeight, String)
                End If
            End If
        End Sub



    End Class

End Namespace