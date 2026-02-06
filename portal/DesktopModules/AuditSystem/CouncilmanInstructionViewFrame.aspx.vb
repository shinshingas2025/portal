Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class CouncilmanInstructionViewFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents LabelTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelInstruction As System.Web.UI.WebControls.Label
		Protected WithEvents LabelNote As System.Web.UI.WebControls.Label
		Protected WithEvents LabelInstructionDate As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolderCouncilman As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LabelCouncilman As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonNext As System.Web.UI.WebControls.Button

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
		Private instructionID As String = ""

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

			If Not (Request.Params("instructionID") Is Nothing) Then
				instructionID = Request.Params("instructionID")
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				InitialWebControl()
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
			Dim myInstructionDAO As New CouncilmanInstructionDAOExtand
			Dim myInstructiondataSet As DataSet
			Dim myTitle As String = ""
			Dim myInstruction As String = ""
			Dim myNote As String = ""
			Dim myInstructionDate As Date = New Date(1900, 1, 1)
			Dim myCouncilmanDAO As New CouncilmanInstructionCouncilmanMapDAOExtand
			Dim myCouncilmanDataSet As DataSet
			Dim myCouncilmanCount As Integer = 0
			Dim myCouncilmanID As String = ""
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myHtmlAnchor As HtmlAnchor
			Dim myLiteral As LiteralControl
			Dim i As Integer = 0

			If instructionID.Trim.Length > 0 Then
				myInstructiondataSet = myInstructionDAO.GetEntitysByEntityID(instructionID)
				If myInstructiondataSet.Tables(0).Rows.Count = 1 Then
					myTitle = CType(myInstructiondataSet.Tables(0).Rows(0).Item("Title"), String).Trim
					myInstruction = CType(myInstructiondataSet.Tables(0).Rows(0).Item("Instruction"), String).Trim
					myNote = CType(myInstructiondataSet.Tables(0).Rows(0).Item("Note"), String).Trim
					myInstructionDate = CType(myInstructiondataSet.Tables(0).Rows(0).Item("InstructionDate"), Date)

					LabelTitle.Text = myTitle
					LabelInstruction.Text = myInstruction
					LabelNote.Text = myNote
					LabelInstructionDate.Text = myInstructionDate.Year & "/" & myInstructionDate.Month & "/" & myInstructionDate.Day
					If LabelInstructionDate.Text = "1900/1/1" Then
						LabelInstructionDate.Text = ""
					End If

					myCouncilmanCount = myCouncilmanDAO.GetTotalRowByCouncilmanInstructionID(instructionID)
					If myCouncilmanCount > 0 Then
						myCouncilmanDataSet = myCouncilmanDAO.GetEntitysByCouncilmanInstructionID(instructionID)
						For i = 0 To myCouncilmanCount - 1
							myCouncilmanID = CType(myCouncilmanDataSet.Tables(0).Rows(i).Item("CouncilmanID"), String)

							If i = 0 Then
								LabelCouncilman.Text = myNormalCodeDAO.GetNameByEntityID(myCouncilmanID)
							Else
								LabelCouncilman.Text += "　" & myNormalCodeDAO.GetNameByEntityID(myCouncilmanID)
							End If
						Next
					End If

				Else
					'exception:instruction record is empty or duplicated
				End If
			Else
				'exception:instruction id is empty
			End If
		End Sub
		Private Sub InitialWebControl()
			LabelTitle.Text = "'"
			LabelInstruction.Text = "'"
			LabelNote.Text = ""
			LabelInstructionDate.Text = ""
			LabelCouncilman.Text = ""
		End Sub

		Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
			Dim myInstructionDAO As New CouncilmanInstructionDAOExtand
			Dim myInstructionDataSet As DataSet
			Dim i As Integer = 0
			Dim myItemID As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False

			If instructionID.Trim.Length > 0 Then
				myPreviousID = instructionID
				myInstructionDataSet = myInstructionDAO.GetEntitysByEntityID(instructionID)
				If myInstructionDataSet.Tables(0).Rows.Count = 1 Then
					myItemID = CType(myInstructionDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)

					myInstructionDataSet = myInstructionDAO.GetItemID()
					If myInstructionDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myInstructionDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myInstructionDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							Else
								'save previous id
								myPreviousID = CType(myInstructionDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							End If
						Next
						If bFound = True Then
							Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myPreviousID)
						End If
					End If
				Else
					'exception:instruction record is empty or duplicated
				End If
			Else
				'exception:instruction id is empty
			End If
		End Sub

		Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
			Dim myInstructionDAO As New CouncilmanInstructionDAOExtand
			Dim myInstructionDataSet As DataSet
			Dim i As Integer = 0
			Dim myItemID As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False

			If instructionID.Trim.Length > 0 Then
				myNextID = instructionID
				myInstructionDataSet = myInstructionDAO.GetEntitysByEntityID(instructionID)
				If myInstructionDataSet.Tables(0).Rows.Count = 1 Then
					myItemID = CType(myInstructionDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
					myInstructionDataSet = myInstructionDAO.GetItemID()
					If myInstructionDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myInstructionDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myInstructionDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							End If
						Next
						If bFound = True Then
							'save next id
							If i + 1 < myInstructionDataSet.Tables(0).Rows.Count Then
								myNextID = CType(myInstructionDataSet.Tables(0).Rows(i + 1).Item("EntityID"), String)
							Else
								myNextID = CType(myInstructionDataSet.Tables(0).Rows(myInstructionDataSet.Tables(0).Rows.Count - 1).Item("EntityID"), String)
							End If
							Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myNextID)
						End If
					End If
				Else
					'exception:news record is empty or duplicated
				End If
			Else
				'exception:news id is empty
			End If
		End Sub
	End Class
End Namespace