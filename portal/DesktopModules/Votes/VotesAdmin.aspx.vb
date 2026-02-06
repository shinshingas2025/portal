Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class VotesAdmin
		Inherits System.Web.UI.Page
		Protected moduleId As Integer = 0
		Protected sid As String = "9999"
		Protected tabId As Integer = 0
		Protected tabIndex As Integer = 0
		Protected WithEvents myDataList As System.Web.UI.WebControls.DataList
		Protected questionID As String = ""
		Protected WithEvents LinkButtonPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents ButtonDelete As System.Web.UI.WebControls.Button
		Protected totalPage As Integer = 0
		Protected currentPage As Integer = 0
		Protected WithEvents ButtonAdd As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonModify As System.Web.UI.WebControls.Button
		Protected pageSize As Integer = 10
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
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

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

		'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
		'請勿刪除或移動它。
		Private designerPlaceholderDeclaration As System.Object

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
			'請勿使用程式碼編輯器進行修改。
			InitializeComponent()
		End Sub

#End Region

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim rowCount As Integer
			Dim myQuestion As New ASPNET.StarterKit.Portal.Portal_QuestionDAOExtand

			If Not (Request.Params("tabid") Is Nothing) Then
				tabId = Int32.Parse(Request.Params("tabid"))
			End If
			If Not (Request.Params("tabindex") Is Nothing) Then
				tabIndex = Int32.Parse(Request.Params("tabindex"))
			End If
			If Not (Request.Params("sid") Is Nothing) Then
				sid = CType(Request.Params("sid"), String)
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
			End If

			If Not (Request.Params("questionid") Is Nothing) Then
				questionID = Request.Params("questionid")
			End If

			If Not Page.IsPostBack Then
				rowCount = myQuestion.GetTotalRow(sid, moduleId)
				If rowCount Mod pageSize = 0 Then
					totalPage = CType(rowCount \ pageSize, Integer)
				Else
					totalPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				currentPage = 1

				ViewState("VotesAdminTotalPage") = totalPage
				ViewState("VotesAdminCurrentPage") = 1
				PageLoad()
			Else
				totalPage = CType(ViewState("VotesAdminTotalPage"), Integer)
				currentPage = CType(ViewState("VotesAdminCurrentPage"), Integer)
			End If
			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
			End If
		End Sub

		Sub PageReload()
			Dim myQuestion As New ASPNET.StarterKit.Portal.Portal_QuestionDAOExtand
			Dim rowCount As Integer
			rowCount = myQuestion.GetTotalRow(sid, moduleId)
			If rowCount Mod pageSize = 0 Then
				totalPage = CType(rowCount \ pageSize, Integer)
			Else
				totalPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentPage = 1

			ViewState("VotesAdminTotalPage") = totalPage
			ViewState("VotesAdminCurrentPage") = currentPage
			PageLoad()
		End Sub
		Sub PageLoad()
			Dim i As Integer
			Dim j As Integer
			Dim myDataSet As DataSet
			Dim myQuestion As New ASPNET.StarterKit.Portal.Portal_QuestionDAOExtand
			myDataSet = myQuestion.GetEntitys(sid, moduleId, pageSize * currentPage)

			If currentPage > 1 Then
				For i = 0 To currentPage - 2
					For j = 0 To pageSize - 1
						myDataSet.Tables(0).Rows(i * pageSize + j).Delete()
					Next
				Next
			End If

			If currentPage < totalPage Then
				LinkButtonPageDown.Visible = True
			Else
				LinkButtonPageDown.Visible = False
			End If

			If currentPage > 1 Then
				LinkButtonPageUp.Visible = True
			Else
				LinkButtonPageUp.Visible = False
			End If

			myDataList.DataSource = myDataSet
			myDataList.DataBind()

		End Sub

		Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
			Dim isDeleted As Boolean
			Dim anItem As DataListItem
			Dim myQuestion As New Portal_QuestionDAOExtand
			Dim myQuestionDataSet As DataSet
			Dim myAnswer As New Portal_AnswerDAOExtand
			Dim myAnswerDataSet As DataSet
			Dim myAnswerPartDataSet As DataSet
			Dim myQAMap As New Portal_QAMapDAOExtand
			Dim myQAMapDataSet As DataSet
			Dim myQAMapPartDataSet As DataSet
			Dim dk As String
			Dim myAuditID As String = ""
			Dim myAnswerID As String = ""
			Dim myQAMapID As String = ""
			Dim i As Integer = 0
			For Each anItem In myDataList.Items
				isDeleted = CType(anItem.FindControl("Delete"), CheckBox).Checked
				If isDeleted Then
					dk = CType(myDataList.DataKeys(anItem.ItemIndex), String)
					myQAMapDataSet = myQAMap.GetEntitys(dk)
					If myQAMapDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myQAMapDataSet.Tables(0).Rows.Count - 1
							myQAMapID = CType(myQAMapDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myQAMap.ToString, "DeleteEntity", myQAMapID, "", Context.User.Identity.Name, Now)
							'log before action
							myQAMapPartDataSet = myQAMap.GetEntity(myQAMapID)
							If myQAMapPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.before, myQAMapPartDataSet)
							End If
							'actual action
							myQAMap.DeleteEntity(myQAMapID)
							'log after action
							myQAMapPartDataSet = myQAMap.GetEntity(myQAMapID)
							If myQAMapPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, myQAMapPartDataSet)
							End If
						Next
					End If
					myAnswerDataSet = myAnswer.GetEntitys(dk)
					If myAnswerDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAnswerDataSet.Tables(0).Rows.Count - 1
							myAnswerID = CType(myAnswerDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myAnswer.ToString, "DeleteEntity", myAnswerID, "", Context.User.Identity.Name, Now)
							'log before action
							myAnswerPartDataSet = myAnswer.GetEntity(myAnswerID)
							If myAnswerPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.before, myAnswerPartDataSet)
							End If
							'actual action
							myAnswer.DeleteEntity(myAnswerID)
							'log after action
							myAnswerPartDataSet = myAnswer.GetEntity(myAnswerID)
							If myAnswerPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, myAnswerPartDataSet)
							End If
						Next
					End If
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myQuestion.ToString, "DeleteEntity", dk, "", Context.User.Identity.Name, Now)
					'log before action
					myQuestionDataSet = myQuestion.GetEntitys(dk)
					If myQuestionDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, myQuestionDataSet)
					End If
					'actual action
					myQuestion.DeleteEntity(dk)
					'log after action
					myQuestionDataSet = myQuestion.GetEntitys(dk)
					If myQuestionDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, myQuestionDataSet)
					End If
				End If
			Next
			PageReload()
		End Sub

		Private Sub LinkButtonPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonPageUp.Click
			currentPage = currentPage - 1
			If currentPage < 1 Then
				currentPage = 1
			End If
			ViewState("VotesAdminCurrentPage") = currentPage
			PageLoad()

		End Sub

		Private Sub LinkButtonPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonPageDown.Click
			currentPage = currentPage + 1
			If currentPage > totalPage Then
				currentPage = totalPage
			End If
			ViewState("VotesAdminCurrentPage") = currentPage
			PageLoad()

		End Sub

		Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
			Response.Redirect("~/DesktopModules/Votes/VotesAdd.aspx?mid=" & moduleId & "&sid=" & sid & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub ButtonModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonModify.Click
			Dim isModify As Boolean
			Dim anItem As DataListItem
			Dim myQuestion As New Portal_QuestionDAOExtand
			Dim dk As String
			For Each anItem In myDataList.Items
				isModify = CType(anItem.FindControl("Delete"), CheckBox).Checked
				If isModify Then
					dk = CType(myDataList.DataKeys(anItem.ItemIndex), String)
					Response.Redirect("~/DesktopModules/Votes/VotesEdit.aspx?mid=" & moduleId & "&sid=" & sid & "&questionid=" & dk & "&tabindex=" & tabIndex)
				End If
			Next
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