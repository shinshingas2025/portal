
Imports System.IO
Namespace ASPNET.StarterKit.Portal

    Public Class EditWebSiteMgt
        Inherits System.Web.UI.Page

        Protected WithEvents updateButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cancelButton As System.Web.UI.WebControls.LinkButton

        Private itemId As Integer = 0
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
        Protected WithEvents dlarea As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSchool As System.Web.UI.WebControls.DropDownList
        Protected WithEvents dlDN As System.Web.UI.WebControls.DropDownList
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
        ' The Page_Load event on this Page is used to obtain the
        ' ItemId of the link to edit.
        '
        ' It then uses the ASPNET.StarterKit.PortalLinkDB() data component
        ' to populate the page's edit controls with the links details.
        '
        '****************************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Determine ModuleId of Links Portal Module
            moduleId = Int32.Parse(Request.Params("Mid"))

            ' Verify that the current user has access to edit this module
            'If PortalSecurity.HasEditPermissions(moduleId) = False Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            'End If

            Dim au As New AuthorityBO
            If Not au.checkAuthorityEdit(Context.User.Identity.Name, moduleId, 7, Me.Page) Then
                Response.Redirect("~/Admin/EditAccessDenied.aspx")
            End If
            au = Nothing


            ' Determine ItemId of Link to Update
            If Not (Request.Params("ItemId") Is Nothing) Then
                itemId = Int32.Parse(Request.Params("ItemId"))
            End If



            ' If the page is being requested the first time, determine if an
            ' link itemId value is specified, and if so populate page
            ' contents with the link details

            If Page.IsPostBack = False Then
                fillArea()
                ' Store URL Referrer to return to portal
                ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
                fillSchoolCode()
            End If



        End Sub


        Private Sub fillSchoolCode()
            Dim objSiteDB As New SiteDB
            Dim dt As DataTable
            Dim i As Integer
            dt = objSiteDB.GetSchoolCodeByArea(dlarea.SelectedValue.Trim).Tables(0)
            txtSchool.Items.Clear()
            dlDN.Items.Clear()

            For i = 0 To dt.Rows.Count - 1
                Dim it As New ListItem
                it.Text = CType(dt.Rows(i).Item("SchoolName"), String)
                it.Value = CType(dt.Rows(i).Item("SchoolCode"), String)
                txtSchool.Items.Add(it)
                dlDN.Items.Add(CType(dt.Rows(i).Item("SchoolDN"), String))
            Next

        End Sub

        Private Sub fillArea()
            Dim objSiteDB As New SiteDB

            Dim dt As DataTable
            Dim i As Integer
            dt = objSiteDB.GetAllSchoolAreaCode.Tables(0)
            For i = 0 To dt.Rows.Count - 1
                Dim it As New ListItem
                it.Text = CType(dt.Rows(i).Item("SchoolAreaName"), String)
                it.Value = CType(dt.Rows(i).Item("SchoolAreaCode"), String)
                dlarea.Items.Add(it)
            Next
        End Sub

        '****************************************************************
        '
        ' The UpdateBtn_Click event handler on this Page is used to either
        ' create or update a link.  It  uses the ASPNET.StarterKit.PortalLinkDB()
        ' data component to encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub UpdateBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles updateButton.Click

            Dim objSiteDB As New SiteDB
            Dim sid As String
            '在節點新增站台
            sid = CType(objSiteDB.AddSite(txtSchool.SelectedItem.Text.Trim, txtSchool.SelectedValue.Trim, dlDN.SelectedValue.Trim), String)

            Dim dr As Directory
            Dim pathDir As String = Server.MapPath("/PortalFiles/WebImage/") & sid
            dr.CreateDirectory(pathDir)
            CopyFile("017", sid)


            ' Redirect back to the portal home page
            Response.Redirect(CStr(ViewState("UrlReferrer")))

            objSiteDB = Nothing


        End Sub

        Private Function CopyFile(ByVal tmpNO As String, ByVal sid As String) As Boolean
            Dim fs As File
            Dim sourceFile As String
            Dim DestFile As String
            Dim i As Integer


            For i = 1 To 19
                'sourceFile = "/WebTemplate/" & "01" & "/000" & i & ".gif"
                Select Case i
                    Case 1, 2, 3, 4, 5, 6, 7, 8
                        sourceFile = "/WebTemplate/" & tmpNO & "_000" & i & ".gif"
                        DestFile = "/PortalFiles/WebImage/" & sid & "/" & sid & "_000" & CType(i, String) & ".gif"
                    Case 9, 10, 11
                        sourceFile = "/WebTemplate/" & tmpNO & "_Btn0" & CType(i - 8, String) & ".gif"
                        DestFile = "/PortalFiles/WebImage/" & sid & "/" & sid & "_Btn0" & CType(i - 8, String) & ".gif"

                    Case 12, 13, 14, 15, 16, 17, 18, 19
                        sourceFile = "/WebTemplate/" & tmpNO & "_Div0" & CType(i - 11, String) & ".gif"
                        DestFile = "/PortalFiles/WebImage/" & sid & "/" & sid & "_Div0" & CType(i - 11, String) & ".gif"


                End Select

                ' sourceFile = "C:\Program Files\ASP.NET Starter Kits\ASP.NET Portal (VBVS)\PortalVBVS\Template\qlt2112.gif"
                If fs.Exists(Server.MapPath(sourceFile)) Then
                    fs.Copy(Server.MapPath(sourceFile), Server.MapPath(DestFile), True)
                Else
                    lblmsg.Text = "'" & Server.MapPath(sourceFile) & "' 檔案不存在!"
                    Exit Function
                End If

            Next i

            sourceFile = "/WebTemplate/" & tmpNO & ".css"
            DestFile = "/PortalFiles/css/" & sid & ".css"
            If fs.Exists(Server.MapPath(sourceFile)) Then
                fs.Copy(Server.MapPath(sourceFile), Server.MapPath(DestFile), True)
            Else
                lblmsg.Text = "'" & Server.MapPath(sourceFile) & "' 檔案不存在!"
                Exit Function
            End If

            sourceFile = "/PortalFiles/xml/Template.xml"
            DestFile = "/PortalFiles/xml/" & sid & ".xml"
            If fs.Exists(Server.MapPath(sourceFile)) Then
                fs.Copy(Server.MapPath(sourceFile), Server.MapPath(DestFile), True)
            Else
                lblmsg.Text = "'" & Server.MapPath(sourceFile) & "' 檔案不存在!"
                Exit Function
            End If

            Return True
            fs = Nothing
        End Function



        Private Sub CancelBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelButton.Click

            ' Redirect back to the portal home page
            Response.Redirect(CStr(ViewState("UrlReferrer")))

        End Sub



        Private Sub dlarea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dlarea.SelectedIndexChanged
            fillSchoolCode()
        End Sub


        Private Sub txtSchool_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSchool.SelectedIndexChanged
            dlDN.SelectedIndex = txtSchool.SelectedIndex
        End Sub

        Private Sub dlDN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dlDN.SelectedIndexChanged
            txtSchool.SelectedIndex = dlDN.SelectedIndex
        End Sub
    End Class

End Namespace