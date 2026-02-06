Namespace ASPNET.StarterKit.Portal


	Public Class VotesResult
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
		Protected WithEvents linkBack As System.Web.UI.WebControls.LinkButton
		Protected WithEvents lblQuestion As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
			End If

			If Not (Request.Params("questionid") Is Nothing) Then
				questionID = Request.Params("questionid")
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
			End If

			GetResult()
		End Sub


		Private Sub GetResult()
			Dim myQuestion As New ASPNET.StarterKit.Portal.Portal_QuestionDAOExtand
			Dim myQAMap As New ASPNET.StarterKit.Portal.Portal_QAMapDAOExtand
			Dim myAnswer As New ASPNET.StarterKit.Portal.Portal_AnswerDAOExtand
			Dim myAnswerHashtable As New Hashtable
			Dim myResultHashtable As New Hashtable
			Dim intLoopIndex As Integer
			Dim myAnswerID As String = ""
			Dim myAnswerText As String = ""
			Dim myAnswerOrder As Integer = 1
			Dim myResult As Integer = 0
			Dim HtmlBody As String = ""
			Dim txtBody As New Literal
			Dim myQAMapDataSet As DataSet
			Dim myAnswerDataSet As DataSet
			Dim myQuestionDataSet As DataSet
			If questionID.Length > 0 Then
				myQuestionDataSet = myQuestion.GetEntitys(questionID)
				myAnswerDataSet = myAnswer.GetEntitys(questionID)
				myQAMapDataSet = myQAMap.GetEntitys(questionID)
			Else
				'get new record
				'exception
				'myQuestionDataSet = myQuestion.GetEntitys(CType(Session("sid"), String), moduleId, 1)
			End If
			'check if dataset is null
			If (Not (myQAMapDataSet Is Nothing)) And (Not (myAnswerDataSet Is Nothing)) And (Not (myQuestionDataSet Is Nothing)) Then
				lblQuestion.Text = CType(myQuestionDataSet.Tables(0).Rows(0).Item("QuestionAlias"), String)
				'calculate total
				For intLoopIndex = 0 To myQAMapDataSet.Tables(0).Rows.Count - 1
					myAnswerID = CType(myQAMapDataSet.Tables(0).Rows(intLoopIndex).Item("AnswerID"), String)
					If myResultHashtable.ContainsKey(myAnswerID) Then
						myResultHashtable.Item(myAnswerID) = CType(myResultHashtable.Item(myAnswerID), Integer) + 1
					Else
						myResultHashtable.Add(myAnswerID, 1)
					End If
				Next
				'read answer text and order
				Dim myAnswerOrderArray(myAnswerDataSet.Tables(0).Rows.Count) As String
				For intLoopIndex = 0 To myAnswerDataSet.Tables(0).Rows.Count - 1
					myAnswerID = CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("EntityID"), String)
					myAnswerText = CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("AnswerText"), String)
					myAnswerOrder = CType(myAnswerDataSet.Tables(0).Rows(intLoopIndex).Item("DisplayOrder"), Integer)
					myAnswerHashtable.Item(myAnswerID) = myAnswerText
					myAnswerOrderArray(myAnswerOrder - 1) = myAnswerID
				Next

				'html code
				HtmlBody = "<TABLE align=center id=""Table1"" cellSpacing=""2"" cellPadding=""2""  border=""0"" class=TTable1>"
				'result
				HtmlBody &= "<TR>"
				For intLoopIndex = 0 To myAnswerDataSet.Tables(0).Rows.Count - 1
					If myAnswerOrderArray(intLoopIndex).Length > 0 Then
						myResult = CType(myResultHashtable.Item(myAnswerOrderArray(intLoopIndex)), Integer)
						HtmlBody &= "<TD class=""SubSubHead"" valign=""bottom"" align=""center"">"
						HtmlBody &= "<v:rect fillcolor='lime' style='width:20;color:navy;height:" & CType((myResult / myQAMapDataSet.Tables(0).Rows.Count) * 200, String) & "'>"
						HtmlBody &= myResult
						HtmlBody &= "<v:Extrusion backdepth='16pt' on='true'/>"
						HtmlBody &= "</v:rect>"
						HtmlBody &= "</TD>"
					End If
				Next
				HtmlBody &= "</TR>"
				'answer
				HtmlBody &= "<TR>"
				For intLoopIndex = 0 To myAnswerDataSet.Tables(0).Rows.Count - 1
					If myAnswerOrderArray(intLoopIndex).Length > 0 Then
						HtmlBody &= "<TD class=""subhead"" align=""center"">"
						HtmlBody &= CType(myAnswerHashtable.Item(myAnswerOrderArray(intLoopIndex)), String)
						HtmlBody &= "</TD>"
					End If
				Next
				HtmlBody &= "</TR>"
				'percentage
				HtmlBody &= "<TR>"
				For intLoopIndex = 0 To myAnswerDataSet.Tables(0).Rows.Count - 1
					If myAnswerOrderArray(intLoopIndex).Length > 0 Then
						myResult = CType(myResultHashtable.Item(myAnswerOrderArray(intLoopIndex)), Integer)
						HtmlBody &= "<TD class=""SubSubHead"" align=""center"">"
						Dim calcResult As Double = 0
						If myQAMapDataSet.Tables(0).Rows.Count = 0 Then
							calcResult = 0
						Else
							calcResult = (myResult / myQAMapDataSet.Tables(0).Rows.Count) * 100
						End If
						HtmlBody &= Microsoft.VisualBasic.Left(CType(calcResult, String), 5) & "%"
						HtmlBody &= "</TD>"
					End If
				Next
				HtmlBody &= "</TR></TABLE>"

				txtBody.Text = HtmlBody
				Panel1.Controls.Add(txtBody)
			Else
				'exception
			End If

		End Sub

		Private Sub linkBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkBack.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class

End Namespace