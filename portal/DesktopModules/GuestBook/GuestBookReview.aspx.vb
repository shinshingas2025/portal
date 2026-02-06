Imports System
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class GuestBookReview
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
		Protected WithEvents LabelTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label
		Protected WithEvents LabelCreatedByUser As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxReply As System.Web.UI.WebControls.TextBox
		Protected WithEvents LabelCreatedDate As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReply As System.Web.UI.WebControls.Button
		Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected WithEvents ButtonDelete As System.Web.UI.WebControls.Button
		Protected WithEvents LabelEmail As System.Web.UI.WebControls.Label
		Protected WithEvents LabelEmailText As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label



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
		Protected adminEmail As String = ""
		Protected tabid As Integer = 0
		Protected tabindex As Integer = 0
		Dim AuditDAO As New Portal_AuditDAOExtand
		Dim AuditDetailDAO As New Portal_AuditDetailDAOExtand

		Enum SequenceType
			before = 1
			after = 2
		End Enum

		Enum LevelType
			debug = 1
			info = 2
		End Enum

		Enum ActionType
			insert = 1
			update = 2
			delete = 3
		End Enum

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If Not (Request.Params("EntityID") Is Nothing) Then
				entityID = Request.Params("EntityID")
				sid = CType(CType(entityID.Substring(8, 5), Integer), String)
				moduleID = CInt(Val("&H" & entityID.Substring(13, 8)))
				itemID = CInt(Val("&H" & entityID.Substring(21, 8)))
			End If

			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				moduleID = Int32.Parse(Request.Params("mid"))
			End If

			If Not (Request.Params("tabid") Is Nothing) Then
				tabid = Int32.Parse(Request.Params("tabid"))
			End If

			If Not (Request.Params("tabindex") Is Nothing) Then
				tabindex = Int32.Parse(Request.Params("tabindex"))
			End If
			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				LoadPage()
			End If
			'If PortalSecurity.HasEditPermissions(moduleID) = False Then
			'	Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If
		End Sub

		Private Sub ButtonReply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReply.Click
			If Page.IsValid = True Then
				Dim events As New ASPNET.StarterKit.Portal.Portal_GuestBookDAOExtand
				Dim eventsDataSet As DataSet
				Dim title As String = LabelTitle.Text
				Dim description As String = LabelDescription.Text
				Dim createdByUser As String = LabelCreatedByUser.Text
				Dim email As String = LabelEmailText.Text
				Dim reply As String = TextBoxReply.Text
				Dim replyByUser As String = Context.User.Identity.Name
				Dim myAuditID As String = ""
				If entityID.Trim.Length > 0 Then
					'get administrator email address
					adminEmail = ConfigurationSettings.AppSettings("AdminEmail")

					'reply = Replace(reply, Chr(13), "<br>")
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.update, Me.ToString, events.ToString, "UpdateEntity", entityID, "", Context.User.Identity.Name, Now)
					'log before action
					eventsDataSet = events.GetEntity(entityID)
					If eventsDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, eventsDataSet)
					End If
					'actual action
					events.UpdateEntity(entityID, reply, replyByUser)
					'log after action
					eventsDataSet = events.GetEntity(entityID)
					If eventsDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, eventsDataSet)
					End If
					If email.Trim <> "" Then
						SendMail()
					End If
					RedirectPage()
				End If
			End If
		End Sub
		Private Sub SendMail()
			Dim myMailMessage As New MailMessage
			Dim messageBody As String = ""
			myMailMessage.From = adminEmail
			myMailMessage.To = LabelEmailText.Text.Trim
			myMailMessage.Subject = "Reply:" + LabelTitle.Text.Trim
			myMailMessage.Priority = MailPriority.Normal
			myMailMessage.BodyFormat = MailFormat.Text
			messageBody = "您的留言如下:" + Chr(13) + Chr(10) + "--------------------" + Chr(13) + Chr(10)
			messageBody = messageBody + LabelDescription.Text.Trim + Chr(13) + Chr(10)
			messageBody = messageBody + "--------------------" + Chr(13) + Chr(10)
			messageBody = messageBody + "回覆如下:" + Chr(13) + Chr(10)
			messageBody = messageBody + "--------------------" + Chr(13) + Chr(10)
			messageBody = messageBody + TextBoxReply.Text.Trim + Chr(13) + Chr(10)
			messageBody = messageBody + "         " + Context.User.Identity.Name + Chr(13) + Chr(10)
			myMailMessage.Body = messageBody
			SmtpMail.Send(myMailMessage)
			'audit
			AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, "System.Web.Mail.SmtpMail", "Send", myMailMessage.To, "", Context.User.Identity.Name, Now)
		End Sub
		Private Sub LoadPage()
			Dim myDataReader As System.Data.SqlClient.SqlDataReader
			Dim events As New ASPNET.StarterKit.Portal.Portal_GuestBookDAOExtand
			Dim descriptionText As String = ""
			myDataReader = events.GetSingleEntity(entityID)
			While myDataReader.Read
				LabelTitle.Text = CStr(myDataReader.Item("Title"))
				LabelEmailText.Text = CStr(myDataReader.Item("Email"))
				descriptionText = CStr(myDataReader.Item("Description"))
				LabelCreatedByUser.Text = CStr(myDataReader.Item("CreatedByUser"))
				LabelCreatedDate.Text = CStr(myDataReader.Item("CreatedDate"))
				TextBoxReply.Text = CStr(myDataReader.Item("Reply"))
				If LabelEmailText.Text.Trim <> "" Then
					LabelEmail.Visible = True
					LabelEmailText.Visible = True
				Else
					LabelEmail.Visible = False
					LabelEmailText.Visible = False
				End If
				LabelDescription.Text = showNewLine(showFace(descriptionText))
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

		Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
			Dim events As New ASPNET.StarterKit.Portal.Portal_GuestBookDAOExtand
			Dim eventsDataSet As DataSet
			Dim myAuditID As String = ""
			If entityID.Trim.Length > 0 Then
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, events.ToString, "DeleteEntity", entityID, "", Context.User.Identity.Name, Now)
				'log before action
				eventsDataSet = events.GetEntity(entityID)
				If eventsDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, eventsDataSet)
				End If
				'actual action
				events.DeleteEntity(entityID)
				'log after action
				eventsDataSet = events.GetEntity(entityID)
				If eventsDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, eventsDataSet)
				End If
				RedirectPage()
			End If
		End Sub
		Private Sub RedirectPage()
			Response.Redirect("~/DesktopModules/GuestBook/GuestBookList.aspx?sid=" & sid & "&mid=" & moduleID & "&tabid=" & tabid & "&tabindex=" & tabindex)
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
		Private Sub AuditDetail(ByVal myAuditID As String, ByVal mySequenceType As Integer, ByVal myDataSet As DataSet)
			Dim myColumnName As String = ""
			Dim myColumnValue As String = ""
			Dim i As Integer = 0
			If myAuditID.Trim.Length > 0 Then
				If Not (myDataSet Is Nothing) Then
					If myDataSet.Tables(0).Rows.Count = 1 Then
						For i = 0 To myDataSet.Tables(0).Columns.Count - 1
							myColumnName = myDataSet.Tables(0).Columns(i).ColumnName
							myColumnValue = CType(myDataSet.Tables(0).Rows(0).Item(myColumnName), String)
							AuditDetailDAO.InsertEntity(myAuditID, 0, mySequenceType, myColumnName, myColumnValue)
						Next
					Else
						'exception:audit target is empty or duplicated
					End If
				End If
			End If
		End Sub
	End Class
End Namespace