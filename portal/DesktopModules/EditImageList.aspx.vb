Imports System.IO

Namespace ASPNET.StarterKit.Portal

    Public Class EditImageList
        Inherits System.Web.UI.Page

        Protected WithEvents updateButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cancelButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents file1 As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents Button1 As System.Web.UI.WebControls.Button
        Protected WithEvents lblFileName As System.Web.UI.WebControls.Label
        Protected WithEvents OrderNO As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Url As System.Web.UI.WebControls.TextBox

        Private moduleId As Integer = 0
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image
        Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Private itemId As Integer = 0


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
            'If PortalSecurity.HasEditPermissions(moduleId) = False Then
            Dim au As New AuthorityBO

            If Not au.checkAuthorityEdit(Context.User.Identity.Name, moduleId, 7, Me.Page) Then
                Response.Redirect("~/Admin/EditAccessDenied.aspx")
            End If
            au = Nothing

            If Not (Request.Params("ItemId") Is Nothing) Then
                itemId = Int32.Parse(Request.Params("ItemId"))
            End If

            Me.Image1.ImageUrl = "/PortalFiles/UpLoadFiles/Images/Example.gif"

            If Page.IsPostBack = False Then

                If itemId <> 0 Then
                    ' Obtain a single row of text information
                    Dim objImageList As New ASPNET.StarterKit.Portal.ImageListDB
                    Dim dr As SqlDataReader = objImageList.GetSingleImage(itemId)

                    dr.Read()

                    Url.Text = CType(dr("url"), String)
                    If CType(dr("ImageName"), String) <> "" Then
                        Image1.ImageUrl = "/PortalFiles/UpLoadFiles/Images/" & CType(dr("ImageName"), String)
                    End If
                    lblFileName.Text = CType(dr("ImageName"), String)
                    OrderNO.SelectedValue = CType(dr("orderNo"), String)
                    dr.Close()



                End If

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
            Dim objImageList As New ASPNET.StarterKit.Portal.ImageListDB

            ' Update the text within the HtmlText table
            '_text.UpdateHtmlText(moduleId, Server.HtmlEncode(DesktopText.Text), Server.HtmlEncode(MobileSummary.Text), Server.HtmlEncode(MobileDetails.Text), CType(Session("sid"), String))

            If itemId = 0 Then

                ' Add the link within the Links table
                'links.AddLink(moduleId, itemId, Context.User.Identity.Name, TitleField.Text, UrlField.Text, MobileUrlField.Text, Int32.Parse(ViewOrderField.Text), DescriptionField.Text, CType(Session("sid"), String))
                objImageList.AddImage(moduleId, Context.User.Identity.Name, "/Portalfiles/UpLoadFiles/Images/", lblFileName.Text, Url.Text, Int32.Parse(OrderNO.SelectedValue), CType(Session("sid"), String))

            Else

                objImageList.UpdateImage(CType(OrderNO.SelectedValue, Integer), itemId, Context.User.Identity.Name, "/PortalFiles/UpLoadFiles/Images/", lblFileName.Text, Url.Text.Trim)
                

            End If


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
            Me.Image1.ImageUrl = Server.MapPath("/PortalFiles/UpLoadFiles/Images/Example.gif")
            Dim objImage As New ImageListDB
            objImage.DeleteImage(itemId)
            Response.Redirect(CType(ViewState("UrlReferrer"), String))

        End Sub



    End Class

End Namespace