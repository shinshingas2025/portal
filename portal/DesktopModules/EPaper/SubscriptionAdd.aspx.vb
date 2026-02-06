Imports System.IO
Namespace ASPNET.StarterKit.Portal


	Public Class SubscriptionAdd
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
		Protected WithEvents LabelEnable As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
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
		Enum SubscriptionState
			Disable = 0
			Enable = 1
			History = 2
		End Enum
		Enum DeliverMark
			Enable = 0
			Disable = 1
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
			End If
		End Sub

		Private Sub SaveForm()
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim mySubscriptionDataSet As DataSet
			Dim mySubscriptionPartDataSet As DataSet
			Dim mySubscriptionListDAO As New Portal_SubscriptionListDAOExtand
			Dim mySubscriptionListDataSet As DataSet
			Dim mySubscriptionListPartDataSet As DataSet
			Dim mySubscriptionID As String = ""
			Dim oldSubscriptionID As String = ""
			Dim mySubscriptionListID As String = ""
			Dim myState As Integer = SubscriptionState.Disable
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myUserType As Integer = 0
			Dim myUserID As String = ""
			Dim user As String = ""
			Dim i As Integer = 0
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
			'check number of enable subscription
			If myState = SubscriptionState.Enable Then
				mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(sid, moduleId, SubscriptionState.Enable, 1)
				'implement state limit
				If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
					LabelEnable.Text = "(同時只能有一筆電子報紀錄上線!)"
					LabelEnable.Visible = True
				Else
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, mySubscriptionDAO.ToString, "InsertEntity", mySubscriptionID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					mySubscriptionID = mySubscriptionDAO.InsertEntity(sid, moduleId, 0, myState, myTitle, myDescription, user, Now)
					'log after action
					mySubscriptionPartDataSet = mySubscriptionDAO.GetEntitys(mySubscriptionID)
					If mySubscriptionPartDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, mySubscriptionPartDataSet)
					End If
					'statistic
					ModuleStatisticDAO.InsertEntity(sid, moduleId, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, Now)
					'import subscription list
					If subscriptionID.Length > 0 Then
						mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionID)

					Else
						mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(sid, moduleId, 1)
					End If
					If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
						oldSubscriptionID = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						mySubscriptionListDataSet = mySubscriptionListDAO.GetEntitys(oldSubscriptionID)
						If mySubscriptionListDataSet.Tables(0).Rows.Count > 0 Then
							For i = 0 To mySubscriptionListDataSet.Tables(0).Rows.Count - 1
								myUserType = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("UserType"), Integer)
								myUserID = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("UserID"), String)
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, mySubscriptionListDAO.ToString, "InsertEntity", mySubscriptionID, "", Context.User.Identity.Name, Now)
								'log before action
								'none
								'actual action
								mySubscriptionListID = mySubscriptionListDAO.InsertEntity(mySubscriptionID, 0, myUserType, myUserID, DeliverMark.Enable, user, Now)
								'log after action
								mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
								If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, mySubscriptionListPartDataSet)
								End If
							Next
						End If
					Else
						'no data
					End If
					Response.Redirect(CType(ViewState("UrlReferrer"), String))
				End If
			Else
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, mySubscriptionDAO.ToString, "InsertEntity", mySubscriptionID, "", Context.User.Identity.Name, Now)
				'log before action
				'none
				'actual action
				mySubscriptionID = mySubscriptionDAO.InsertEntity(sid, moduleId, 0, myState, myTitle, myDescription, user, Now)
				'log after action
				mySubscriptionPartDataSet = mySubscriptionDAO.GetEntitys(mySubscriptionID)
				If mySubscriptionPartDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, mySubscriptionPartDataSet)
				End If
				'statistic
				ModuleStatisticDAO.InsertEntity(sid, moduleId, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, Now)
				'import subscription list
				If subscriptionID.Length > 0 Then
					mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionID)
				Else
					mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(sid, moduleId, 1)
				End If
				If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
					oldSubscriptionID = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("EntityID"), String)
					mySubscriptionListDataSet = mySubscriptionListDAO.GetEntitys(oldSubscriptionID)
					If mySubscriptionListDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To mySubscriptionListDataSet.Tables(0).Rows.Count - 1
							myUserType = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("UserType"), Integer)
							myUserID = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("UserID"), String)
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, mySubscriptionListDAO.ToString, "InsertEntity", mySubscriptionID, "", Context.User.Identity.Name, Now)
							'log before action
							'none
							'actual action
							mySubscriptionListID = mySubscriptionListDAO.InsertEntity(mySubscriptionID, 0, myUserType, myUserID, DeliverMark.Enable, user, Now)
							'log after action
							mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
							If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, mySubscriptionListPartDataSet)
							End If
						Next
					End If
				Else
					'no data
				End If
				Response.Redirect(CType(ViewState("UrlReferrer"), String))
			End If
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			If Page.IsValid Then
				SaveForm()
			End If
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			TextBoxTitle.Text = ""
			TextBoxDescription.Text = ""
			RadioButtonDisable.Checked = True
			RadioButtonEnable.Checked = False
			RadioButtonHistory.Checked = False
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