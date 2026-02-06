Imports System
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class GuestBookView
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ButtonReply As System.Web.UI.WebControls.Button
		Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected WithEvents ButtonDelete As System.Web.UI.WebControls.Button
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents LabelTitle As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents LabelCreatedDate As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents LabelCreatedByUser As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents LabelEmail As System.Web.UI.WebControls.Label
        Protected WithEvents LabelEmailText As System.Web.UI.WebControls.Label
        Protected WithEvents LabelReply As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label



		'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
		'請勿刪除或移動它。
		Private designerPlaceholderDeclaration As System.Object

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
			'請勿使用程式碼編輯器進行修改。
			InitializeComponent()
		End Sub

#End Region
		Protected entityID As String = ""
		Protected sid As String = "9999"
		Protected moduleID As Integer = 0
		Protected itemID As Integer = 0
		Protected tabid As Integer = 0
		Protected tabindex As Integer = 0

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not (Request.Params("EntityID") Is Nothing)) And (Request.Params("sid") Is Nothing) Then
				entityID = Request.Params("EntityID")
				sid = CType(CType(entityID.Substring(8, 5), Integer), String)
				moduleID = CInt(Val("&H" & entityID.Substring(13, 8)))
				Response.Redirect("~/DesktopModules/GuestBook/GuestBookView.aspx?sid=" & sid & "&mid=" & moduleID & "&EntityID=" & entityID)
			End If
			If Not (Request.Params("EntityID") Is Nothing) Then
				entityID = Request.Params("EntityID")
				sid = entityID.Substring(9, 4)
				moduleID = CInt(Val("&H" & entityID.Substring(13, 8)))
				itemID = CInt(Val("&H" & entityID.Substring(21, 8)))
			End If

			'If PortalSecurity.HasEditPermissions(moduleID) = False Then
			'	Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If

			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If


			If Not (Request.Params("tabid") Is Nothing) Then
				tabId = Int32.Parse(Request.Params("tabid"))
			End If

			If Not (Request.Params("tabindex") Is Nothing) Then
				tabIndex = Int32.Parse(Request.Params("tabindex"))
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				moduleID = Int32.Parse(Request.Params("mid"))
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
			End If

			If Not Page.IsPostBack Then
				LoadPage()
			End If

		End Sub

		Private Sub LoadPage()
			Dim myDataReader As System.Data.SqlClient.SqlDataReader
			Dim events As New ASPNET.StarterKit.Portal.Portal_GuestBookDAOExtand
			myDataReader = events.GetSingleEntity(entityID)
			While myDataReader.Read
				LabelTitle.Text = CStr(myDataReader.Item("Title"))
				LabelEmailText.Text = CStr(myDataReader.Item("Email"))
				LabelCreatedByUser.Text = CStr(myDataReader.Item("CreatedByUser"))
				LabelCreatedDate.Text = CStr(myDataReader.Item("CreatedDate"))
				LabelReply.Text = CStr(myDataReader.Item("Reply"))
				If LabelEmailText.Text.Trim <> "" Then
					LabelEmail.Visible = True
					LabelEmailText.Visible = True
				Else
					LabelEmail.Visible = False
					LabelEmailText.Visible = False
				End If
				LabelDescription.Text = showNewLine(showFace(CStr(myDataReader.Item("Description"))))
				LabelReply.Text = showNewLine(showFace(CStr(myDataReader.Item("Reply"))))
			End While
		End Sub
		Private Function showFace(ByVal input As String) As String
			Dim fooPath As String = ""
			Dim barPath As String = ""
			fooPath = "<img src='" + Global.GetApplicationPath(Request) + "/images/emotion/"
			barPath = "'>"
			Return Regex.Replace(input, "\{/(?<face>\w{1,10})\}", fooPath + "${face}.gif" + barPath)
		End Function
		Private Function showNewLine(ByVal input As String) As String
			Return Regex.Replace(input, "\n", "<br>")
		End Function

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class
End Namespace