Imports System.IO
Namespace ASPNET.StarterKit.Portal


	Public Class SubscriptionEdit
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents RadioButtonDisable As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEnable As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonHistory As System.Web.UI.WebControls.RadioButton
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected WithEvents LabelEnable As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button

		'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
		'請勿刪除或移動它。
		Private designerPlaceholderDeclaration As System.Object

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
			'請勿使用程式碼編輯器進行修改。
			InitializeComponent()
		End Sub

#End Region


		Private tabIndex As Integer = 0
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Private subscriptionID As String = ""
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
		Enum SubscriptionState
			Disable = 0
			Enable = 1
			History = 2
		End Enum

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁()
			'Session("sid") = "9999"
			'If PortalSecurity.IsInRoles("Admins") = False Then
			'    Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If

			' Calculate userid
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If


			If Not (Request.Params("tabid") Is Nothing) Then
				tabId = Int32.Parse(Request.Params("tabid"))
			End If

			If Not (Request.Params("tabindex") Is Nothing) Then
				tabIndex = Int32.Parse(Request.Params("tabindex"))
			End If

			If Not (Request.Params("subscriptionid") Is Nothing) Then
				subscriptionID = Request.Params("subscriptionid")
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub

		Private Sub PageLoad()
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim mySubscriptionDataSet As DataSet
			Dim choice As Integer
			If subscriptionID.Length > 0 Then
				mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionID)
			Else
				'exception
			End If

			If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
				TextBoxTitle.Text = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("Title"), String)
				TextBoxDescription.Text = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("Description"), String)
				choice = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("State"), Integer)
				If choice = SubscriptionState.Disable Then
					RadioButtonDisable.Checked = True
				End If
				If choice = SubscriptionState.Enable Then
					RadioButtonEnable.Checked = True
				End If
				If choice = SubscriptionState.History Then
					RadioButtonHistory.Checked = True
				End If
			Else
				'exception
			End If
		End Sub

		Private Sub SaveForm()
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim mySubscriptionDataSet As DataSet
			Dim myState As Integer = SubscriptionState.Disable
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim user As String = ""
			Dim myAuditID As String = ""
			'check select mode
			If RadioButtonDisable.Checked = True Then
				myState = SubscriptionState.Disable
			End If
			If RadioButtonEnable.Checked = True Then
				myState = SubscriptionState.Enable
			End If
			If RadioButtonHistory.Checked = True Then
				myState = SubscriptionState.History
			End If
			'setup user
			user = Context.User.Identity.Name
			'
			myTitle = TextBoxTitle.Text.Trim
			myDescription = TextBoxDescription.Text.Trim
			'save form
			If subscriptionID.Trim.Length > 0 Then
				'check number of enable subscription
				If myState = SubscriptionState.Enable Then
					mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(sid, moduleId, SubscriptionState.Enable, 1)
					'implement state limit
					If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
						LabelEnable.Text = "(同時只能有一筆電子報紀錄上線!)"
						LabelEnable.Visible = True
					Else
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, mySubscriptionDAO.ToString, "UpdateEntity", subscriptionID, "", Context.User.Identity.Name, Now)
						'log before action
						mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionID)
						If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.before, mySubscriptionDataSet)
						End If
						'actual action
						mySubscriptionDAO.UpdateEntity(subscriptionID, myState, myTitle, myDescription)
						'log after action
						mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionID)
						If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, mySubscriptionDataSet)
						End If
						Response.Redirect(CType(ViewState("UrlReferrer"), String))
					End If
				Else
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, mySubscriptionDAO.ToString, "UpdateEntity", subscriptionID, "", Context.User.Identity.Name, Now)
					'log before action
					mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionID)
					If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, mySubscriptionDataSet)
					End If
					'actual action
					mySubscriptionDAO.UpdateEntity(subscriptionID, myState, myTitle, myDescription)
					'log after action
					mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionID)
					If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, mySubscriptionDataSet)
					End If
					Response.Redirect(CType(ViewState("UrlReferrer"), String))
				End If
			End If
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			If Page.IsValid Then
				SaveForm()
			End If
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
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