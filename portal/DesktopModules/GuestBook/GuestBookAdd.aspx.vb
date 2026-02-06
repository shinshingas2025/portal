Namespace ASPNET.StarterKit.Portal
	Public Class GuestBookAdd
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
		Protected WithEvents LabelCreatedDate As System.Web.UI.WebControls.Label
		Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonAdd As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxUser As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxEmail As System.Web.UI.WebControls.TextBox
		Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected WithEvents LabelEmail As System.Web.UI.WebControls.Label
		Protected WithEvents CheckBoxEmail As System.Web.UI.WebControls.CheckBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
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
		Protected sid As String = "9999"
		Protected moduleID As Integer = 0
		Protected itemID As Integer = 0
		Protected entityID As String = ""
		Dim AuditDAO As New Portal_AuditDAOExtand
		Dim ModuleStatisticDAO As New Portal_ModuleStatisticDAOExtand
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
			'在這裡放置使用者程式碼以初始化網頁
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If
			If Not (Request.Params("mid") Is Nothing) Then
				moduleID = Int32.Parse(Request.Params("mid"))
			End If
			If Not (Request.Params("ItemID") Is Nothing) Then
				itemID = Int32.Parse(Request.Params("ItemID"))
			End If
			If Not (Request.Params("EntityID") Is Nothing) Then
				entityID = Request.Params("EntityID")
			End If
			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				LoadPage()
				If entityID.Length > 0 Then
					ReadGuestBook()
				End If
			End If

		End Sub
		Private Sub ReadGuestBook()
			Dim events As New ASPNET.StarterKit.Portal.Portal_GuestBookDAOExtand
			Dim myDataReader As System.Data.SqlClient.SqlDataReader
			'Dim title As String
			'Dim description As String
			'Dim createdByUser As String
			'Dim createdDate As Date
			'Dim reply As String
			'Dim replyByUser As String
			'Dim replyDate As Date
			myDataReader = events.GetSingleEntity(entityID)
			While myDataReader.Read
				TextBoxTitle.Text = CStr(myDataReader.Item("Title"))
				TextBoxDescription.Text = CStr(myDataReader.Item("Description"))
				TextBoxUser.Text = CStr(myDataReader.Item("CreatedByUser"))
				TextBoxEmail.Text = CStr(myDataReader.Item("Email"))
				If TextBoxEmail.Text.Trim <> "" Then
					CheckBoxEmail.Checked = True
					LabelEmail.Visible = True
					TextBoxEmail.Visible = True
				Else
					CheckBoxEmail.Checked = False
					LabelEmail.Visible = False
					TextBoxEmail.Visible = False
				End If
				LabelCreatedDate.Text = CStr(myDataReader.Item("CreatedDate"))
			End While
		End Sub

		Private Sub LoadPage()
			'LabelCreatedByUser.Text = Context.User.Identity.Name
			TextBoxUser.Text = ""
			TextBoxTitle.Text = ""
			TextBoxDescription.Text = ""
			LabelCreatedDate.Text = CStr(Now)
			LabelEmail.Visible = False
			TextBoxEmail.Visible = False
		End Sub

		Private Sub RedirectPage()
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			LoadPage()
			If entityID.Length > 0 Then
				ReadGuestBook()
			End If
		End Sub

		Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
			If Page.IsValid = True Then
				Dim events As New ASPNET.StarterKit.Portal.Portal_GuestBookDAOExtand
				Dim eventsDataSet As DataSet
				Dim title As String = TextBoxTitle.Text.Trim
				Dim description As String = TextBoxDescription.Text.Trim
				Dim createdByUser As String = TextBoxUser.Text.Trim
				Dim email As String
				Dim replyByUser As String = Context.User.Identity.Name
				Dim myEventID As String = ""
				Dim myAuditID As String = ""
				'reply = Replace(reply, Chr(13), "<br>")
				If CheckBoxEmail.Checked Then
					email = TextBoxEmail.Text.Trim
				Else
					email = ""
				End If
				If entityID.Length > 0 Then
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.update, Me.ToString, events.ToString, "UpdateEntity", entityID, "", Context.User.Identity.Name, Now)
					'log before action
					eventsDataSet = events.GetEntity(entityID)
					If eventsDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, eventsDataSet)
					End If
					'actual action
					events.UpdateEntity(entityID, sid, moduleID, title, description, email, Now, createdByUser, "", "", Now)
					'log after action
					eventsDataSet = events.GetEntity(entityID)
					If eventsDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, eventsDataSet)
					End If
				Else
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, events.ToString, "InsertEntity", myEventID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					myEventID = events.InsertEntity(sid, moduleID, itemID, title, description, email, createdByUser, "", "")
					'log after action
					eventsDataSet = events.GetEntity(myEventID)
					If eventsDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, eventsDataSet)
					End If
					'statistic
					ModuleStatisticDAO.InsertEntity(sid, moduleID, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, Now)
				End If
				RedirectPage()
			End If
		End Sub

		Private Sub CheckBoxEmail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxEmail.CheckedChanged
			If CheckBoxEmail.Checked Then
				LabelEmail.Visible = True
				TextBoxEmail.Visible = True
			Else
				LabelEmail.Visible = False
				TextBoxEmail.Visible = False
			End If
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