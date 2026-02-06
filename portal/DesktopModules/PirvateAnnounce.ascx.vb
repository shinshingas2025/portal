Namespace ASPNET.StarterKit.Portal

    Public MustInherit Class PirvateAnnounce
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl

        Protected WithEvents t1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents btnMore As System.Web.UI.WebControls.ImageButton
        Protected WithEvents HtmlHolder As System.Web.UI.HtmlControls.HtmlTableCell

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
            Dim [text] As New ASPNET.StarterKit.Portal.HtmlTextDB
            Dim dr As SqlDataReader = [text].GetHtmlText(ModuleId, CType(Session("sid"), String))

            If dr.Read() Then

                ' Dynamically add the file content into the page
                Dim content As String

                content = Server.HtmlDecode(CType(dr("DesktopHtml"), String))

                Dim pic As String
                Dim tbl As String
                tbl = "<Table border=0><tr><TD valign=top> "
                HtmlHolder.Controls.Add(New LiteralControl(tbl))

                If CType(dr.Item("imgpost"), String).Trim = "左" Then
                    If Not IsDBNull(dr("filename")) Then
                        If CType(dr("filename"), String).Trim <> "" Then
                            pic = "<IMG alt='圖片' src='/PortalFiles/UpLoadFiles/Images/" & CType(dr("filename"), String).Trim & "' />"
                            HtmlHolder.Controls.Add(New LiteralControl(pic))
                        End If
                    End If

                    tbl = "</td><td valign=top>"
                    HtmlHolder.Controls.Add(New LiteralControl(tbl))
                    HtmlHolder.Controls.Add(New LiteralControl(content))
                    tbl = "</td></tr></table>"
                    HtmlHolder.Controls.Add(New LiteralControl(tbl))
                Else
                    HtmlHolder.Controls.Add(New LiteralControl(content))
                    tbl = "</td><td valign=top>"
                    HtmlHolder.Controls.Add(New LiteralControl(tbl))
                    If Not IsDBNull(dr("filename")) Then
                        If CType(dr("filename"), String).Trim <> "" Then
                            pic = "<IMG alt='圖片' src='/PortalFiles/UpLoadFiles/Images/" & CType(dr("filename"), String).Trim & "' />"
                            HtmlHolder.Controls.Add(New LiteralControl(pic))
                        End If
                    End If
                    tbl = "</td></tr></table>"
                    HtmlHolder.Controls.Add(New LiteralControl(tbl))
                End If





            End If

            ' Close the datareader
            dr.Close()

        End Sub


    End Class

End Namespace
