Imports System.IO

Namespace ASPNET.StarterKit.Portal

    Public Class EditHtml2
        Inherits System.Web.UI.Page

        Protected WithEvents DesktopText As System.Web.UI.WebControls.TextBox
        Protected WithEvents updateButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cancelButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image
        Protected WithEvents file1 As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents Button1 As System.Web.UI.WebControls.Button
        Protected WithEvents lblFileName As System.Web.UI.WebControls.Label
        Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
        Protected WithEvents rblImgPost As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents DetailText As System.Web.UI.WebControls.TextBox

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

                    DesktopText.Text = Server.HtmlDecode(CType(dr("DesktopHtml"), String))
                    DetailText.Text = Server.HtmlDecode(CType(dr("DetailHtml"), String))
                    'MobileSummary.Text = Server.HtmlDecode(CType(dr("MobileSummary"), String))
                    'MobileDetails.Text = Server.HtmlDecode(CType(dr("MobileDetails"), String))
                    'Image1.ImageUrl = "" & CType(dr("moduleid"), String) & "-" & CType(dr("sid"), String) & ".gif"
                    Image1.ImageUrl = "/PortalFiles/UpLoadFiles/Images/" & CType(dr("filename"), String)

                    lblFileName.Text = CType(dr("filename"), String)
                    rblImgPost.SelectedValue = CType(dr("imgpost"), String)
                Else
                    Image1.ImageUrl = "../images/Example.gif"
                    DesktopText.Text = ""
                    'MobileSummary.Text = "Todo: Add Content..."
                    'MobileDetails.Text = "Todo: Add Content..."

                End If

                dr.Close()

                ' Store URL Referrer to return to portal
                ViewState("UrlReferrer") = Request.UrlReferrer.ToString()

            End If

        End Sub


        '****************************************************************
        '
        ' The UpdateBtn_Click event handler on this Page is used to save
        ' the text changes to the database.
        '
        '****************************************************************

        Private Sub updateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateButton.Click

            ' Create an instance of the HtmlTextDB component
            Dim _text As New ASPNET.StarterKit.Portal.HtmlTextDB

            ' Update the text within the HtmlText table
            '_text.UpdateHtmlText(moduleId, Server.HtmlEncode(DesktopText.Text), Server.HtmlEncode(MobileSummary.Text), Server.HtmlEncode(MobileDetails.Text), CType(Session("sid"), String))
            _text.UpdateHtmlText(moduleId, Server.HtmlEncode(DesktopText.Text), Server.HtmlEncode(DetailText.Text), "", "", CType(Session("sid"), String), rblImgPost.SelectedValue, lblFileName.Text.Trim)

            ' Redirect back to the portal home page
            Response.Redirect(CType(ViewState("UrlReferrer"), String))

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

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim FilePath As String
            Dim FileName As String

            FileName = PhotoUpload(CType(file1.PostedFile, HttpPostedFile), getUploadFileName, "/PortalFiles/UpLoadFiles/Images")
            If FileName <> "" Then
                Me.Image1.ImageUrl = "/PortalFiles/UpLoadFiles/Images/" & FileName
                lblFileName.Text = FileName
            End If

        End Sub

        Private Function getUploadFileName() As String
            Dim FileName As String
            FileName = CType(Year(Now()), String) & Right("0" & CType(Month(Now()), String), 2) & Right("0" & CType(Day(Now()), String), 2)
            FileName &= Right("0" & CType(Hour(Now()), String), 2) & Right("0" & CType(Minute(Now()), String), 2) & Right("0" & CType(Second(Now()), String), 2)
            FileName &= "_" & CType(Session.SessionID, String)
            Return FileName
        End Function

        'UploadFile = PostedFile
        'DM_FileName 要存的檔名
        'FilePath 要存的路徑
        Public Function PhotoUpload(ByVal UploadFile As HttpPostedFile, ByVal DM_FileName As String, ByVal FilePath As String) As String
            Dim UFileNamen As String
            Dim SaveFileName As String = ""
            Dim mypage As UI.Page = New UI.Page
            Dim Fe_Array() As String = {".PNG", ".JPG", ".GIF"}
            Dim For_I As Integer
            Dim Fe_State As Boolean
            If UploadFile.ContentLength <> Nothing Then
                Dim UFilePath As String = UploadFile.FileName
                UFileNamen = Path.GetFileName(UFilePath)
                Dim UFileExtension As String = Path.GetExtension(UFileNamen)
                UFileExtension = UFileExtension.ToUpper()
                Fe_State = False
                For For_I = 0 To Fe_Array.Length - 1
                    If (Fe_Array(For_I) = UFileExtension) Then
                        Fe_State = True
                        Exit For
                    End If
                Next

                If Fe_State Then
                    SaveFileName = DM_FileName & UFileExtension
                    FilePath = mypage.Server.MapPath(FilePath)
                    UploadFile.SaveAs(FilePath & "\" & SaveFileName)
                    FilePath = SaveFileName
                Else
                    FilePath = ""
                End If
            Else
                FilePath = ""
            End If
            ' Return FilePath
            Return SaveFileName
        End Function


        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            lblFileName.Text = ""
            Me.Image1.ImageUrl = "/PortalFiles/UpLoadFiles/Images/Example.gif"
        End Sub



    End Class

End Namespace