Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class ProcessAttributeCheckViewFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents LabelProcessDate As System.Web.UI.WebControls.Label
		Protected WithEvents LabelProcessState As System.Web.UI.WebControls.Label
		Protected WithEvents LabelNote As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolderAttribute As System.Web.UI.WebControls.PlaceHolder
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

		Private Const DefaultPermission As String = "111100100"
		Private Const DefaultPermissionGroup As String = "000000000"
		Private Const ProcessAuthorityTarget As String = "AffairProcessMap"
		Private Const AttributeAuthorityTarget As String = "ProcessAttributeMap"
		Private Const AttributeCodeAuthorityTarget As String = "ProcessAttributeCode"
		Private UtilityObject As New AuditSystemUtility

		Private tabIndex As Integer = 0
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Private processID As String = ""
		Private Const AttributeColumnNumber As Integer = 10
		Protected Const NormalAttributeWidth As String = "32"
		Protected Const NewsAttributeWidth As String = "32"
		Protected Const InstructionAttributeWidth As String = "32"
		Protected Const NormalAttributeHeight As String = "32"
		Protected Const NewsAttributeHeight As String = "32"
		Protected Const InstructionAttributeHeight As String = "32"
		Protected Const NormalProcessBGColor As String = "#DEDECA"

		Enum AttributeType
			Normal = 1
			NewsRelease = 2
			CouncilmanInstruction = 3
			Law = 4
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

			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
			End If

			If Not (Request.Params("processID") Is Nothing) Then
				processID = Request.Params("processID")
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
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myNote As String = ""
			Dim myProcessState As String = ""
			Dim myProcessDate As Date = New Date(1900, 1, 1)
			Dim i As Integer = 0

			If processID.Trim.Length > 0 Then
				myProcessDataSet = myProcessDAO.GetEntitysByEntityID(processID)
				If myProcessDataSet.Tables(0).Rows.Count = 1 Then
					myProcessState = CType(myProcessDataSet.Tables(0).Rows(0).Item("ProcessState"), String).Trim
					myNote = CType(myProcessDataSet.Tables(0).Rows(0).Item("Note"), String).Trim
					myProcessDate = CType(myProcessDataSet.Tables(0).Rows(0).Item("ProcessDate"), Date)

					LabelProcessState.Text = myProcessState
					LabelNote.Text = myNote
					LabelProcessDate.Text = myProcessDate.Year & "/" & myProcessDate.Month & "/" & myProcessDate.Day
					If LabelProcessDate.Text = "1900/1/1" Then
						LabelProcessDate.Text = ""
					End If

					'prepare attribute
					FillAttributeData(processID)
				Else
					'exception:process record is empty or duplicated
				End If
			Else
				'exception:process id is empty
			End If
		End Sub
		Private Sub FillAttributeData(ByVal myProcessID As String)
			Dim myAttributeCodeDAO As New ProcessAttributeCodeDAOExtand
			Dim myAttributeCodeDataSet As DataSet
			Dim myAttributeCodeCount As Integer = 0
			Dim myAttributeMapDAO As New ProcessAttributeMapDAOExtand
			Dim myAttributeMapDataSet As DataSet
			Dim myAttributeMapCount As Integer = 0
			Dim myOutlineTable As HtmlTable
			Dim myOutlineTableRow As HtmlTableRow
			Dim myOutlineTableCell As HtmlTableCell
			Dim myDetailTable As HtmlTable
			Dim myDetailTableRow As HtmlTableRow
			Dim myDetailTableCell As HtmlTableCell
			Dim myHyperLink As HyperLink
			Dim myLiterial As LiteralControl
			Dim myImage As HtmlImage
			Dim myName As String = ""
			Dim myAttributeID As String = ""
			Dim myAttributeValue As String = ""
			Dim myAttributeType As Integer = 0
			Dim i As Integer = 0
			Dim j As Integer = 0

			If myProcessID.Trim.Length > 0 Then
				PlaceHolderAttribute.Controls.Clear()
				myOutlineTable = New HtmlTable
				myOutlineTable.CellPadding = 0
				myOutlineTable.CellSpacing = 0
				myOutlineTable.Border = 0
				myOutlineTableRow = New HtmlTableRow

				myAttributeCodeDataSet = myAttributeCodeDAO.GetEntitys()
				myAttributeCodeDataSet = UtilityObject.QueryPermissionFilter(myAttributeCodeDataSet, AttributeCodeAuthorityTarget, Context.User.Identity.Name)
				myAttributeCodeCount = myAttributeCodeDataSet.Tables(0).Rows.Count

				If myAttributeCodeCount > 0 Then
					For i = 0 To myAttributeCodeCount - 1
						myOutlineTableCell = New HtmlTableCell
						myOutlineTableCell.Align = "center"

						myName = CType(myAttributeCodeDataSet.Tables(0).Rows(i).Item("Name"), String)
						myAttributeType = CType(myAttributeCodeDataSet.Tables(0).Rows(i).Item("TypeID"), Integer)
						myAttributeID = CType(myAttributeCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						If myAttributeType = AttributeType.Normal Then
							'normal attribute
							myOutlineTableCell.Width = NormalAttributeWidth

							myDetailTable = New HtmlTable
							myDetailTable.CellPadding = 0
							myDetailTable.CellSpacing = 0
							myDetailTable.Border = 1
							'attribute header
							myDetailTableRow = New HtmlTableRow
							myDetailTableCell = New HtmlTableCell
							myDetailTableCell.BgColor = NormalProcessBGColor
							myDetailTableCell.Align = "center"
							myDetailTableCell.Width = NormalAttributeWidth
							myDetailTableCell.InnerHtml = myName
							myDetailTableRow.Cells.Add(myDetailTableCell)
							myDetailTable.Controls.Add(myDetailTableRow)
							'attribute value
							myDetailTableRow = New HtmlTableRow
							myDetailTableCell = New HtmlTableCell
							myDetailTableCell.BgColor = NormalProcessBGColor
							myDetailTableCell.Align = "center"
							myDetailTableCell.Height = NormalAttributeHeight
							myDetailTableCell.Width = NormalAttributeWidth
							myImage = New HtmlImage

							myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessIDAndAttributeID(myProcessID, myAttributeID)
							myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
							myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count

							If myAttributeMapCount > 0 Then
								myAttributeValue = CType(myAttributeMapDataSet.Tables(0).Rows(0).Item("AttributeValue"), String)
								If myAttributeValue.Trim = "1" Then
									myImage.Alt = "Checked"
									myImage.Src = "~/images/checked.gif"
								Else
									myImage.Alt = "Unchecked"
									myImage.Src = "~/images/unchecked.gif"
								End If
							Else
								myImage.Alt = "Unchecked"
								myImage.Src = "~/images/unchecked.gif"
							End If
							myDetailTableCell.Controls.Add(myImage)
							myDetailTableRow.Cells.Add(myDetailTableCell)
							myDetailTable.Controls.Add(myDetailTableRow)
							myOutlineTableCell.Controls.Add(myDetailTable)
						Else
							If myAttributeType = AttributeType.NewsRelease Then
								'news release attribute
								myOutlineTableCell.Width = NewsAttributeWidth

								myDetailTable = New HtmlTable
								myDetailTable.CellPadding = 0
								myDetailTable.CellSpacing = 0
								myDetailTable.Border = 1
								'attribute header
								myDetailTableRow = New HtmlTableRow
								myDetailTableCell = New HtmlTableCell
								myDetailTableCell.BgColor = NormalProcessBGColor
								myDetailTableCell.Align = "center"
								myDetailTableCell.Width = NewsAttributeWidth
								myDetailTableCell.InnerHtml = myName
								myDetailTableRow.Cells.Add(myDetailTableCell)
								myDetailTable.Controls.Add(myDetailTableRow)
								'attribute value
								myDetailTableRow = New HtmlTableRow
								myDetailTableCell = New HtmlTableCell
								myDetailTableCell.BgColor = NormalProcessBGColor
								myDetailTableCell.Align = "center"
								myDetailTableCell.Height = NewsAttributeHeight
								myDetailTableCell.Width = NewsAttributeWidth

								myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessIDAndAttributeID(myProcessID, myAttributeID)
								myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
								myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count

								If myAttributeMapCount > 0 Then
									myAttributeValue = CType(myAttributeMapDataSet.Tables(0).Rows(0).Item("AttributeValue"), String)
									If myAttributeValue.Trim.Length > 0 Then
										'insert link
										myHyperLink = New HyperLink
										myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/NewsReleaseViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&newsID=" & myAttributeValue
										myHyperLink.ImageUrl = "~/images/link.gif"
										myHyperLink.Text = "新聞稿"
										myDetailTableCell.Controls.Add(myHyperLink)
									End If
								End If
								myDetailTableRow.Cells.Add(myDetailTableCell)
								myDetailTable.Controls.Add(myDetailTableRow)
								myOutlineTableCell.Controls.Add(myDetailTable)
							Else
								If myAttributeType = AttributeType.CouncilmanInstruction Then
									'councilman instruction attribute
									myOutlineTableCell.Width = InstructionAttributeWidth

									myDetailTable = New HtmlTable
									myDetailTable.CellPadding = 0
									myDetailTable.CellSpacing = 0
									myDetailTable.Border = 1
									'attribute header
									myDetailTableRow = New HtmlTableRow
									myDetailTableCell = New HtmlTableCell
									myDetailTableCell.BgColor = NormalProcessBGColor
									myDetailTableCell.Align = "center"
									myDetailTableCell.Width = InstructionAttributeWidth
									myDetailTableCell.InnerHtml = myName
									myDetailTableRow.Cells.Add(myDetailTableCell)
									myDetailTable.Controls.Add(myDetailTableRow)
									'attribute value
									myDetailTableRow = New HtmlTableRow
									myDetailTableCell = New HtmlTableCell
									myDetailTableCell.BgColor = NormalProcessBGColor
									myDetailTableCell.Align = "center"
									myDetailTableCell.Height = InstructionAttributeHeight
									myDetailTableCell.Width = InstructionAttributeWidth

									myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessIDAndAttributeID(myProcessID, myAttributeID)
									myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
									myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count

									If myAttributeMapCount > 0 Then
										myAttributeValue = CType(myAttributeMapDataSet.Tables(0).Rows(0).Item("AttributeValue"), String)
										If myAttributeValue.Trim.Length > 0 Then
											'insert link
											myHyperLink = New HyperLink
											myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/CouncilmanInstructionViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&instructionID=" & myAttributeValue
											myHyperLink.ImageUrl = "~/images/link.gif"
											myHyperLink.Text = "委員交辦"
											myDetailTableCell.Controls.Add(myHyperLink)
										End If
									End If
									myDetailTableRow.Cells.Add(myDetailTableCell)
									myDetailTable.Controls.Add(myDetailTableRow)
									myOutlineTableCell.Controls.Add(myDetailTable)
								Else
									If myAttributeType = AttributeType.Law Then
										'law attribute
										myOutlineTableCell.Width = InstructionAttributeWidth

										myDetailTable = New HtmlTable
										myDetailTable.CellPadding = 0
										myDetailTable.CellSpacing = 0
										myDetailTable.Border = 1
										'attribute header
										myDetailTableRow = New HtmlTableRow
										myDetailTableCell = New HtmlTableCell
										myDetailTableCell.BgColor = NormalProcessBGColor
										myDetailTableCell.Align = "center"
										myDetailTableCell.Width = InstructionAttributeWidth
										myDetailTableCell.InnerHtml = myName
										myDetailTableRow.Cells.Add(myDetailTableCell)
										myDetailTable.Controls.Add(myDetailTableRow)
										'attribute value
										myDetailTableRow = New HtmlTableRow
										myDetailTableCell = New HtmlTableCell
										myDetailTableCell.BgColor = NormalProcessBGColor
										myDetailTableCell.Align = "center"
										myDetailTableCell.Height = InstructionAttributeHeight
										myDetailTableCell.Width = InstructionAttributeWidth

										myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessIDAndAttributeID(myProcessID, myAttributeID)
										myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
										myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count

										If myAttributeMapCount > 0 Then
											myAttributeValue = CType(myAttributeMapDataSet.Tables(0).Rows(0).Item("AttributeValue"), String)
											If myAttributeValue.Trim.Length > 0 Then
												'insert link
												myHyperLink = New HyperLink
												myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/LawViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&lawID=" & myAttributeValue
												myHyperLink.ImageUrl = "~/images/link.gif"
												myHyperLink.Text = "法規"
												myDetailTableCell.Controls.Add(myHyperLink)
											End If
										End If
										myDetailTableRow.Cells.Add(myDetailTableCell)
										myDetailTable.Controls.Add(myDetailTableRow)
										myOutlineTableCell.Controls.Add(myDetailTable)
									Else
										'exception:unknown attribute type
									End If
								End If
							End If
						End If
						myOutlineTableRow.Cells.Add(myOutlineTableCell)

						'new row
						If i Mod AttributeColumnNumber = AttributeColumnNumber - 1 Then
							myOutlineTable.Controls.Add(myOutlineTableRow)
							myOutlineTableRow = New HtmlTableRow
						End If
					Next
				End If
				myOutlineTable.Controls.Add(myOutlineTableRow)
				PlaceHolderAttribute.Controls.Add(myOutlineTable)
			End If
		End Sub
		Private Sub InitialWebControl()
			LabelProcessDate.Text = ""
			LabelProcessState.Text = ""
			LabelNote.Text = ""
		End Sub

		Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myFormID As String = ""
			Dim i As Integer = 0
			Dim myItemID As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False

			If processID.Trim.Length > 0 Then
				myPreviousID = processID
				myProcessDataSet = myProcessDAO.GetEntitysByEntityID(processID)
				If myProcessDataSet.Tables(0).Rows.Count = 1 Then
					myFormID = CType(myProcessDataSet.Tables(0).Rows(0).Item("FormID"), String)
					myItemID = CType(myProcessDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)

					myProcessDataSet = myProcessDAO.GetItemIDByFormID(myFormID)
					myProcessDataSet = UtilityObject.QueryPermissionFilter(myProcessDataSet, ProcessAuthorityTarget, Context.User.Identity.Name)
					If myProcessDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myProcessDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myProcessDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							Else
								'save previous id
								myPreviousID = CType(myProcessDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							End If
						Next
						If bFound = True Then
							Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&processID=" & myPreviousID)
						End If
					End If
				Else
					'exception:form record is empty or duplicated
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myFormID As String = ""
			Dim i As Integer = 0
			Dim myItemID As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False

			If processID.Trim.Length > 0 Then
				myNextID = processID
				myProcessDataSet = myProcessDAO.GetEntitysByEntityID(processID)
				If myProcessDataSet.Tables(0).Rows.Count = 1 Then
					myFormID = CType(myProcessDataSet.Tables(0).Rows(0).Item("FormID"), String)
					myItemID = CType(myProcessDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
					myProcessDataSet = myProcessDAO.GetItemIDByFormID(myFormID)
					myProcessDataSet = UtilityObject.QueryPermissionFilter(myProcessDataSet, ProcessAuthorityTarget, Context.User.Identity.Name)
					If myProcessDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myProcessDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myProcessDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							End If
						Next
						If bFound = True Then
							'save next id
							If i + 1 < myProcessDataSet.Tables(0).Rows.Count Then
								myNextID = CType(myProcessDataSet.Tables(0).Rows(i + 1).Item("EntityID"), String)
							Else
								myNextID = CType(myProcessDataSet.Tables(0).Rows(myProcessDataSet.Tables(0).Rows.Count - 1).Item("EntityID"), String)
							End If
							Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&processID=" & myNextID)
						End If
					End If
				Else
					'exception:form record is empty or duplicated
				End If
			Else
				'exception:form id is empty
			End If
		End Sub
	End Class
End Namespace