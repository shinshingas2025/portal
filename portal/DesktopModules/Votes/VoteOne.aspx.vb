Imports System.IO
Namespace ASPNET.StarterKit.Portal


	Public Class VoteOne
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents VoteSubject As System.Web.UI.WebControls.Label
		Protected WithEvents VoteDescription As System.Web.UI.WebControls.Label
		Protected WithEvents OptionControl As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ResultLabel As System.Web.UI.WebControls.Label
		Protected WithEvents VoteLinkButton As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
		Protected WithEvents ResultLinkButton As System.Web.UI.WebControls.LinkButton
		Protected WithEvents ReturnLinkButton As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Label4 As System.Web.UI.WebControls.Label
		Protected WithEvents VoteDateLabel As System.Web.UI.WebControls.Label

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
		Private questionID As String = ""
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
		Enum SelectMode
			SingleSelect = 1
			MultipleSelect = 2
		End Enum
		Enum ShowMode
			Vertical = 1
			Horizontal = 2
		End Enum
		Enum AnswerType
			RadioButton = 1
			CheckBox = 2
			TextBox = 3
			DateTime = 4
			ListBox = 5
		End Enum

		Protected mySelectMode As Integer
		Protected myQuestionDataSet As DataSet
		Protected myAnswerDataSet As DataSet

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

			If Not (Request.Params("questionid") Is Nothing) Then
				questionID = Request.Params("questionid")
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
			End If

			LoadPage()

		End Sub
		Private Sub LoadPage()
			Dim myQuestion As New ASPNET.StarterKit.Portal.Portal_QuestionDAOExtand
			Dim myAnswer As New ASPNET.StarterKit.Portal.Portal_AnswerDAOExtand
			Dim AnswerTypeColumn As New DataColumn("AnswerType")

			Dim intLoopIndex As Integer
			mySelectMode = 0
			ResultLabel.Text = ""
			VoteDateLabel.Text = ""

			'select question data
			If questionID.Length > 0 Then
				myQuestionDataSet = myQuestion.GetEntitys(questionID)
			Else
				'exception
			End If
			'check if myQuestionDataSet Is Nothing 
			Try
				VoteSubject.Text = CType(myQuestionDataSet.Tables(0).Rows(0).Item("QuestionAlias"), String)
				VoteDescription.Text = CType(myQuestionDataSet.Tables(0).Rows(0).Item("QuestionText"), String)
				questionID = CType(myQuestionDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				mySelectMode = CType(myQuestionDataSet.Tables(0).Rows(0).Item("SelectModeID"), Integer)
				VoteDateLabel.Text = CType(CType(myQuestionDataSet.Tables(0).Rows(0).Item("EnableDate"), Date), String) & "～" & CType(CType(myQuestionDataSet.Tables(0).Rows(0).Item("DisableDate"), Date), String)
			Catch ex As IndexOutOfRangeException
				VoteSubject.Text = ""
				VoteDescription.Text = ""
			End Try

			'select answer options
			myAnswerDataSet = myAnswer.GetEntitys(questionID)
			If Not (myAnswerDataSet Is Nothing) Then
				'single mode
				If mySelectMode = SelectMode.SingleSelect Then
					For intLoopIndex = 0 To myAnswerDataSet.Tables(0).Rows.Count - 1
						'radio button
						If CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("AnswerTypeID"), Integer) = AnswerType.RadioButton Then
							Dim myRadioButton As New System.Web.UI.WebControls.RadioButton
							myRadioButton.ID = CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("EntityID"), String)
							myRadioButton.Text = CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("AnswerText"), String)
							myRadioButton.GroupName = questionID
							myradiobutton.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
							OptionControl.Controls.Add(myRadioButton)
							OptionControl.Controls.Add(New System.Web.UI.LiteralControl("<" & "br" & ">"))
						Else
							'unknown answer type
						End If
					Next
				Else
					'multiple mode
					If mySelectMode = SelectMode.MultipleSelect Then
						For intLoopIndex = 0 To myAnswerDataSet.Tables(0).Rows.Count - 1
							'radio button
							If CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("AnswerTypeID"), Integer) = AnswerType.RadioButton Then
								Dim myRadioButton As New System.Web.UI.WebControls.RadioButton
								myRadioButton.ID = CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("EntityID"), String)
								myRadioButton.Text = CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("AnswerText"), String)
								OptionControl.Controls.Add(myRadioButton)
								OptionControl.Controls.Add(New System.Web.UI.LiteralControl("<" & "br" & ">"))
							Else
								'unknown answer type
							End If
						Next
					Else
						'unknown select mode
					End If
				End If
			End If
		End Sub

		Private Sub VoteLinkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoteLinkButton.Click
			Dim myQAMap As New ASPNET.StarterKit.Portal.Portal_QAMapDAOExtand
			Dim myQAMapDataSet As DataSet
			Dim myAuditID As String = ""
			Dim intLoopIndex As Integer
			Dim dk As String = ""
			If (Not (myAnswerDataSet Is Nothing)) And (Not (CheckSession(questionID))) Then
				For intLoopIndex = 0 To myAnswerDataSet.Tables(0).Rows.Count - 1
					Dim myAnswerID As String = ""
					myAnswerID = CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("EntityID"), String)
					'radio button
					If CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("AnswerTypeID"), Integer) = AnswerType.RadioButton Then
						Dim myRadioButton As New System.Web.UI.WebControls.RadioButton
						myRadioButton = CType(OptionControl.FindControl(myAnswerID), System.Web.UI.WebControls.RadioButton)
						If Not (myRadioButton Is Nothing) Then
							If myRadioButton.Checked = True Then
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myQAMap.ToString, "InsertEntity", dk, "", Context.User.Identity.Name, Now)
								'log before action
								'none
								'actual action
								dk = myQAMap.InsertEntity(CType(Session("sid"), String), moduleId, 0, questionID, myAnswerID, Context.User.Identity.Name, Now)
								'log after action
								myQAMapDataSet = myQAMap.GetEntity(dk)
								If myQAMapDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myQAMapDataSet)
								End If
								'statistic
								ModuleStatisticDAO.InsertEntity(sid, moduleId, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, Now)
								'mark session
								MarkSession(questionID)

								myRadioButton.Checked = False
							End If
						End If
					Else
						'unknown answer type
					End If
				Next
				ResultLabel.Text = "感謝您的投票!!"
			Else
				If CheckSession(questionID) Then
					ResultLabel.Text = "您已完成本項投票!!"
				End If
			End If
		End Sub

		Private Sub ResultLinkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResultLinkButton.Click
			Response.Redirect("~/DesktopModules/Votes/VotesResult.aspx?moduleid=" & moduleId & "&questionid=" & questionID & "&tabindex=" & tabIndex & "&tabid=" & tabId & "&sid=" & sid)
		End Sub
		Private Function CheckSession(ByVal questionID As String) As Boolean
			Dim result As Boolean = False
			Dim myVoteFlag As String = ""
			If Not (Session("VoteFlag" & questionID) Is Nothing) Then
				myVoteFlag = CType(Session("VoteFlag" & questionID), String)
				If myVoteFlag.Trim = "A" Then
					result = True
				Else
					result = False
				End If
			End If
			Return result
		End Function
		Private Sub MarkSession(ByVal questionID As String)
			Session("VoteFlag" & questionID) = "A"
		End Sub

		Private Sub ReturnLinkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnLinkButton.Click
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