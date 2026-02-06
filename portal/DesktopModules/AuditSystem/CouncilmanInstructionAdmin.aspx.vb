Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class CouncilmanInstructionAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonNext As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents PlaceHolderCouncilman As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents TextBoxInstruction As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxNote As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextboxInstructionDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonCouncilmanAction As System.Web.UI.WebControls.Button
		Protected WithEvents DropDownListCouncilman As System.Web.UI.WebControls.DropDownList
		Protected WithEvents ButtonInstructionInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonInstructionUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonInstructionDelete As System.Web.UI.WebControls.Button

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
		Private mapID As String = ""
		Private action As String = ""
		Private Const CouncilmanCodeGroupID As String = "200601010000000E"
		Private Const ActionColumnWidth As String = "40"
		Private Const CouncilmanColumnWidth As String = "240"
		Protected Const NormalCodeBGColor As String = "#DEDECA"
		Protected Const FocusCodeBGColor As String = "#FFFF99"

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

			If Not (Request.Params("mapID") Is Nothing) Then
				mapID = Request.Params("mapID")
			End If

			If Not (Request.Params("action") Is Nothing) Then
				action = Request.Params("action")
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
			Dim myInstructionDataSet As DataSet
			Dim myInstructionID As String = ""

			If instructionID.Trim.Length > 0 Then
				myInstructionDataSet = myInstructionDAO.GetEntitysByEntityID(instructionID)
			Else
				myInstructionDataSet = myInstructionDAO.GetEntitys(1)
				If myInstructionDataSet.Tables(0).Rows.Count = 1 Then
					myInstructionID = CType(myInstructionDataSet.Tables(0).Rows(0).Item("EntityID"), String)
					Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myInstructionID)
				End If
			End If
			FillInstructionData(myInstructionDataSet)
		End Sub

		Private Sub FillInstructionData(ByVal myInstructionDataSet As DataSet)
			Dim myInstructionID As String = ""
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myInstruction As String = ""
			Dim myNote As String = ""
			Dim myInstructionDate As Date = New Date(1900, 1, 1)

			If Not (myInstructionDataSet Is Nothing) Then
				If myInstructionDataSet.Tables(0).Rows.Count = 1 Then
					myInstructionID = CType(myInstructionDataSet.Tables(0).Rows(0).Item("EntityID"), String)
					myTitle = CType(myInstructionDataSet.Tables(0).Rows(0).Item("Title"), String)
					myDescription = CType(myInstructionDataSet.Tables(0).Rows(0).Item("Description"), String)
					myInstruction = CType(myInstructionDataSet.Tables(0).Rows(0).Item("Instruction"), String)
					myNote = CType(myInstructionDataSet.Tables(0).Rows(0).Item("Note"), String)
					myInstructionDate = CType(myInstructionDataSet.Tables(0).Rows(0).Item("InstructionDate"), Date)

					TextBoxTitle.Text = myTitle
					TextBoxDescription.Text = myDescription
					TextBoxInstruction.Text = myInstruction
					TextBoxNote.Text = myNote
					TextboxInstructionDate.Text = myInstructionDate.Year & "/" & myInstructionDate.Month & "/" & myInstructionDate.Day
					If TextboxInstructionDate.Text = "1900/1/1" Then
						TextboxInstructionDate.Text = ""
					End If
					'councilman
					If myInstructionID.Trim.Length > 0 Then
						FillCouncilmanData(myInstructionID)
					Else
						'exception:instruction id is empty
					End If
				Else
					'exception:instruction dataset is empty or duplicated
				End If
			End If
		End Sub

		Private Sub FillCouncilmanData(ByVal myInstructionID As String)
			Dim myCouncilmanDAO As New CouncilmanInstructionCouncilmanMapDAOExtand
			Dim myCouncilmanDataSet As DataSet
			Dim myCouncilmanCount As Integer = 0
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myTable As HtmlTable
			Dim myTableRow As HtmlTableRow
			Dim myTableCell As HtmlTableCell
			Dim myHyperLink As HyperLink
			Dim myLiterial As LiteralControl
			Dim myImage As HtmlImage
			Dim myMapID As String = ""
			Dim myCouncilmanID As String = ""
			Dim myContent As String = ""
			Dim myContentOrder As Integer = 0
			Dim i As Integer = 0

			If myInstructionID.Trim.Length > 0 Then

				PlaceHolderCouncilman.Controls.Clear()

				myTable = New HtmlTable
				myTable.CellPadding = 0
				myTable.CellSpacing = 0
				myTable.Border = 1
				'prepare councilman header
				myTableRow = New HtmlTableRow
				myTableRow.BgColor = NormalCodeBGColor
				'action column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = ActionColumnWidth
				myTableRow.Cells.Add(myTableCell)
				'councilman column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = CouncilmanColumnWidth
				myTableCell.InnerText = "委員"
				myTableRow.Cells.Add(myTableCell)

				myTable.Rows.Add(myTableRow)

				myCouncilmanCount = myCouncilmanDAO.GetTotalRowByCouncilmanInstructionID(myInstructionID)
				If myCouncilmanCount > 0 Then
					myCouncilmanDataSet = myCouncilmanDAO.GetEntitysByCouncilmanInstructionID(myInstructionID)
					For i = 0 To myCouncilmanCount - 1
						myMapID = CType(myCouncilmanDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myTableRow = New HtmlTableRow
						If myMapID = mapID Then
							myTableRow.BgColor = FocusCodeBGColor
						Else
							myTableRow.BgColor = NormalCodeBGColor
						End If

						'insert icon
						myTableCell = New HtmlTableCell
						myTableCell.Width = ActionColumnWidth
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myInstructionID & "&mapID=" & myMapID & "&action=update"
						myHyperLink.ImageUrl = "~/images/edit.gif"
						myHyperLink.Text = "修改"
						myTableCell.Controls.Add(myHyperLink)
						'br
						myLiterial = New LiteralControl
						myLiterial.Text = "<BR>"
						myTableCell.Controls.Add(myLiterial)
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myInstructionID & "&mapID=" & myMapID & "&action=delete"
						myHyperLink.ImageUrl = "~/images/delete.gif"
						myHyperLink.Text = "刪除"
						myTableCell.Controls.Add(myHyperLink)

						myTableRow.Cells.Add(myTableCell)

						'councilman
						myCouncilmanID = CType(myCouncilmanDataSet.Tables(0).Rows(i).Item("CouncilmanID"), String)
						myTableCell = New HtmlTableCell
						myTableCell.Width = CouncilmanColumnWidth
						myTableCell.InnerHtml = myNormalCodeDAO.GetNameByEntityID(myCouncilmanID)
						myTableRow.Cells.Add(myTableCell)

						myTable.Rows.Add(myTableRow)
					Next
				Else
					'new councilman
				End If
				PlaceHolderCouncilman.Controls.Add(myTable)

				'update councilman
				If mapID.Trim.Length > 0 Then
					myCouncilmanDataSet = myCouncilmanDAO.GetEntitysByEntityID(mapID)
					If myCouncilmanDataSet.Tables(0).Rows.Count = 1 Then
						myCouncilmanID = CType(myCouncilmanDataSet.Tables(0).Rows(0).Item("CouncilmanID"), String)
					Else
						'exception:councilman record is empty or duplicated
					End If

					If action.Trim.Length > 0 Then
						If action.Trim = "update" Then
							ButtonCouncilmanAction.Text = "修改"
							Try
								DropDownListCouncilman.SelectedValue = myCouncilmanID
							Catch ex As Exception
								'exception:no match
							End Try
						Else
							If action.Trim = "delete" Then
								ButtonCouncilmanAction.Text = "刪除"
								Try
									DropDownListCouncilman.SelectedValue = myCouncilmanID
								Catch ex As Exception
									'exception:no match
								End Try
							Else
								'exception:unknown action
							End If
						End If
					Else
						'exception:no action
					End If
				End If
				ButtonCouncilmanAction.Visible = True
				DropDownListCouncilman.Visible = True
			Else
				'exception:instruction id is empty
			End If
		End Sub

		Private Sub InitialWebControl()
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""

			TextBoxTitle.Text = ""
			TextBoxDescription.Text = ""
			TextBoxInstruction.Text = ""
			TextBoxNote.Text = ""
			TextboxInstructionDate.Text = ""

			DropDownListCouncilman.Items.Clear()
			myNormalCodeCount = myNormalCodeDAO.GetTotalRowByGroupID(CouncilmanCodeGroupID)
			If myNormalCodeCount > 0 Then
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(CouncilmanCodeGroupID)
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListCouncilman.Items.Add(myListItem)
				Next
			End If
			DropDownListCouncilman.Visible = False

			ButtonCouncilmanAction.Text = "新增"
			ButtonCouncilmanAction.Visible = False
		End Sub
		Private Function SaveInstructionData(ByVal myInstructionID As String) As String
			Dim myInstructionDAO As New CouncilmanInstructionDAOExtand
			Dim myInstructionDataSet As DataSet
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myInstruction As String = ""
			Dim myNote As String = ""
			Dim myInstructionDate As Date = New Date(1900, 1, 1)

			myTitle = TextBoxTitle.Text.Trim
			myDescription = TextBoxDescription.Text.Trim
			myInstruction = TextBoxInstruction.Text.Trim
			myNote = TextBoxNote.Text.Trim
			If TextboxInstructionDate.Text.Trim <> "" Then
				tempString = TextboxInstructionDate.Text.Trim
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 3 Then
					myInstructionDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				End If
			End If

			If myInstructionID.Trim.Length > 0 Then
				myInstructionDataSet = myInstructionDAO.GetEntitysByEntityID(myInstructionID)
				If myInstructionDataSet.Tables(0).Rows.Count = 1 Then
					'update instruction record
					myInstructionDAO.UpdateEntity(myInstructionID, myTitle, myDescription, myInstruction, myNote, myInstructionDate)
				Else
					'exception:news record is empty or duplicated
				End If
			Else
				'insert new data
				myInstructionID = myInstructionDAO.InsertEntity(myTitle, myDescription, myInstruction, myNote, myInstructionDate)
			End If
			Return myInstructionID
		End Function
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
					'read total entity id and item id
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
							Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myPreviousID)
						End If
					End If
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
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
					'read total entityid and itemid in group
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
							Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myNextID)
						End If
					End If
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub

		Private Sub ButtonInstructionInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInstructionInsert.Click
			Dim myInstructionID As String = ""
			myInstructionID = SaveInstructionData("")
			If myInstructionID.Trim.Length > 0 Then
				Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myInstructionID)
			Else
				'exception:insert failure
				PageLoad()
			End If
		End Sub

		Private Sub ButtonInstructionUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInstructionUpdate.Click
			If instructionID.Trim.Length > 0 Then
				SaveInstructionData(instructionID)
				Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & instructionID)
			Else
				'exception:form id is empty
			End If
		End Sub
		Private Sub DeleteCouncilman(ByVal myInstructionID As String)
			Dim myCouncilmanDAO As New CouncilmanInstructionCouncilmanMapDAOExtand
			Dim myCouncilmanDataSet As DataSet
			Dim myCouncilmanCount As Integer = 0
			Dim myMapID As String = ""
			Dim i As Integer = 0

			If myInstructionID.Trim.Length > 0 Then
				myCouncilmanCount = myCouncilmanDAO.GetTotalRowByCouncilmanInstructionID(myInstructionID)
				If myCouncilmanCount > 0 Then
					myCouncilmanDataSet = myCouncilmanDAO.GetEntitysByCouncilmanInstructionID(myInstructionID)
					For i = 0 To myCouncilmanCount - 1
						myMapID = CType(myCouncilmanDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myCouncilmanDAO.DeleteEntity(myMapID)
					Next
				End If
			Else
				'exception:news id is empty
			End If
		End Sub
		Private Sub DeleteInstructionData(ByVal myInstructionID As String)
			Dim myInstructionDAO As New CouncilmanInstructionDAOExtand
			Dim myInstructionDataSet As DataSet

			If myInstructionID.Trim.Length > 0 Then
				myInstructionDataSet = myInstructionDAO.GetEntitysByEntityID(myInstructionID)
				If myInstructionDataSet.Tables(0).Rows.Count = 1 Then
					'delete councilman
					DeleteCouncilman(myInstructionID)
					'delete news
					myInstructionDAO.DeleteEntity(myInstructionID)
				Else
					'exception:news record is empty or duplicated
				End If
			Else
				'exception:news id is empty
			End If
		End Sub
		Private Sub ButtonInstructionDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInstructionDelete.Click
			If instructionID.Trim.Length > 0 Then
				DeleteInstructionData(instructionID)

				instructionID = ""
				Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex)
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonCouncilmanAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCouncilmanAction.Click
			Dim myCouncilmanDAO As New CouncilmanInstructionCouncilmanMapDAOExtand
			Dim myCouncilmanDataSet As DataSet
			Dim myMapID As String = ""
			Dim myCouncilmanID As String = ""

			If instructionID.Trim.Length > 0 Then
				myCouncilmanID = DropDownListCouncilman.SelectedValue

				If mapID.Trim.Length > 0 Then
					If action.Trim.Length > 0 Then
						If action.Trim = "update" Then
							'update councilman
							myCouncilmanDataSet = myCouncilmanDAO.GetEntitysByEntityID(mapID)
							If myCouncilmanDataSet.Tables(0).Rows.Count = 1 Then
								'actual action
								myCouncilmanDAO.UpdateEntity(mapID, instructionID, 1, myCouncilmanID)
								Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & instructionID)
							Else
								'exception:councilman record is empty or duplicated
							End If
						Else
							If action.Trim = "delete" Then
								'delete content
								myCouncilmanDataSet = myCouncilmanDAO.GetEntitysByEntityID(mapID)
								If myCouncilmanDataSet.Tables(0).Rows.Count = 1 Then
									'actual action
									myCouncilmanDAO.DeleteEntity(mapID)
									Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & instructionID)
								Else
									'exception:councilman record is empty or duplicated
								End If
							Else
								'exception:unknown action
							End If
						End If
					Else
						'exception:no action
					End If
				Else
					'insert new councilman
					myCouncilmanDAO.InsertEntity(instructionID, 1, myCouncilmanID)
					Response.Redirect("~/DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & instructionID)
				End If
			Else
				'exception:news id is empty
			End If
		End Sub
	End Class
End Namespace