Imports System.IO
Namespace ASPNET.StarterKit.Portal


	Public Class VotesAdd
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents txtQuestion As System.Web.UI.WebControls.TextBox
		Protected WithEvents listAnswers As System.Web.UI.WebControls.ListBox
		Protected WithEvents txtAnswer As System.Web.UI.WebControls.TextBox
		Protected WithEvents imageRight As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ImageLeft As System.Web.UI.WebControls.ImageButton
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents RadioButtonSingle As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonMultiple As System.Web.UI.WebControls.RadioButton
		Protected WithEvents TextBoxQuestionAlias As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
		Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
		Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
		Protected WithEvents LinkButton2 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Calendar2 As System.Web.UI.WebControls.Calendar
		Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected WithEvents RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
		Protected WithEvents ReturnLinkButton As System.Web.UI.WebControls.LinkButton
		Protected WithEvents OKLinkbutton As System.Web.UI.WebControls.LinkButton

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
		End Sub

		Private Sub SaveQuestion()
			Dim myAnswer As New Portal_AnswerDAOExtand
			Dim myAnswerDataSet As DataSet
			Dim myQuestion As New Portal_QuestionDAOExtand
			Dim myQuestionDataSet As DataSet
			Dim i As Integer
			Dim mySelectMode As Integer = SelectMode.SingleSelect
			Dim myEnableDate As Date
			Dim myDisableDate As Date
			Dim user As String = ""
			Dim myAnswerID As String = ""
			Dim myAuditID As String = ""
			'check select mode
			If RadioButtonMultiple.Checked = True Then
				mySelectMode = SelectMode.MultipleSelect
			End If
			'setup enable date and disable date
			If TextBox1.Text.Trim <> "" Then
				myEnableDate = New Date(CType(TextBox1.Text.Trim.Substring(0, 4), Integer), CType(TextBox1.Text.Trim.Substring(5, 2), Integer), CType(TextBox1.Text.Trim.Substring(8, 2), Integer))
			Else
				myEnableDate = Now
			End If
			If TextBox2.Text.Trim <> "" Then
				myDisableDate = New Date(CType(TextBox2.Text.Trim.Substring(0, 4), Integer), CType(TextBox2.Text.Trim.Substring(5, 2), Integer), CType(TextBox2.Text.Trim.Substring(8, 2), Integer))
			Else
				myDisableDate = myEnableDate.AddYears(1)
			End If
			'setup user
			user = Context.User.Identity.Name
			'save question
			'audit
			myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myQuestion.ToString, "InsertEntity", questionID, "", Context.User.Identity.Name, Now)
			'log before action
			'none
			'actual action
			questionID = myQuestion.InsertEntity(sid, moduleId, 0, "", mySelectMode, ShowMode.Horizontal, 0, 0, 1, TextBoxQuestionAlias.Text.Trim, txtQuestion.Text.Trim, myEnableDate, myDisableDate, user, Now)
			'lof after action
			myQuestionDataSet = myQuestion.GetEntitys(questionID)
			If myQuestionDataSet.Tables(0).Rows.Count = 1 Then
				AuditDetail(myAuditID, SequenceType.after, myQuestionDataSet)
			End If
			'statistic
			ModuleStatisticDAO.InsertEntity(sid, moduleId, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, Now)
			'save answer
			For i = 0 To listAnswers.Items.Count - 1
				Dim litem As New ListItem
				litem = listAnswers.Items(i)

				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myAnswer.ToString, "InsertEntity", myAnswerID, "", Context.User.Identity.Name, Now)
				'log before action
				'none
				'actual action
				myAnswerID = myAnswer.InsertEntity(questionID, 0, AnswerType.RadioButton, i + 1, 0, litem.Text.Trim, litem.Text.Trim, "", user, Now)
				'log after action
				myAnswerDataSet = myAnswer.GetEntity(myAnswerID)
				If myAnswerDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myAnswerDataSet)
				End If
				litem = Nothing
			Next i

		End Sub


		Private Sub imageRight_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imageRight.Click
			If txtAnswer.Text.Trim <> "" Then
				listAnswers.Items.Add(txtAnswer.Text)
			End If
		End Sub

		Private Sub ImageLeft_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageLeft.Click
			Dim si As New ListItem
			si = listAnswers.SelectedItem
			If Not si Is Nothing Then
				listAnswers.Items.Remove(si)
			End If
		End Sub

		Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
			Calendar1.Visible = True
			LinkButton1.Visible = False
		End Sub

		Private Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
			Calendar2.Visible = True
			LinkButton2.Visible = False
		End Sub

		Private Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
			TextBox1.Text = Calendar1.SelectedDate.Year & "/" & Microsoft.VisualBasic.Right("00" & Calendar1.SelectedDate.Month, 2) & "/" & Microsoft.VisualBasic.Right("00" & Calendar1.SelectedDate.Day, 2)
			Calendar1.Visible = False
			LinkButton1.Visible = True
		End Sub

		Private Sub Calendar2_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
			TextBox2.Text = Calendar2.SelectedDate.Year & "/" & Microsoft.VisualBasic.Right("00" & Calendar2.SelectedDate.Month, 2) & "/" & Microsoft.VisualBasic.Right("00" & Calendar2.SelectedDate.Day, 2)
			Calendar2.Visible = False
			LinkButton2.Visible = True
		End Sub

		Private Sub ReturnLinkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnLinkButton.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
		Private Sub OKLinkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKLinkbutton.Click
			If Page.IsValid Then
				SaveQuestion()

				Response.Redirect(CType(ViewState("UrlReferrer"), String))
			End If
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