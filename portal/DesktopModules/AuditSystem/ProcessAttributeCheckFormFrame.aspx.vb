Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class ProcessAttributeCheckFormFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolderAttribute As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ButtonPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonNext As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxProcessDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxProcessState As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxNote As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonDelete As System.Web.UI.WebControls.Button

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
		Private formID As String = ""
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

			If Not (Request.Params("formID") Is Nothing) Then
				formID = Request.Params("formID")
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
			Dim myProcessID As String = ""
			Dim i As Integer = 0

			If processID.Trim.Length > 0 Then
				myProcessDataSet = myProcessDAO.GetEntitysByEntityID(processID)
			Else
				If formID.Trim.Length > 0 Then
					myProcessDataSet = myProcessDAO.GetEntitysByFormID(formID)
					myProcessDataSet = UtilityObject.QueryPermissionFilter(myProcessDataSet, ProcessAuthorityTarget, Context.User.Identity.Name, 1)

					If myProcessDataSet.Tables(0).Rows.Count = 1 Then
						myProcessID = CType(myProcessDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						If myProcessID.Trim.Length > 0 Then
							processID = myProcessID
						Else
							'exception:process id is empty
						End If
					End If
				Else
					'exception:form id and process id is empty
				End If
			End If
			If Not (myProcessDataSet Is Nothing) Then
				FillProcessData(myProcessDataSet)
			End If
		End Sub
		Private Sub FillProcessData(ByVal myProcessDataSet As DataSet)
			Dim myNote As String = ""
			Dim myProcessState As String = ""
			Dim myProcessDate As Date = New Date(1900, 1, 1)
			Dim myProcessID As String = ""

			If Not (myProcessDataSet Is Nothing) Then
				If myProcessDataSet.Tables(0).Rows.Count = 1 Then
					myProcessID = CType(myProcessDataSet.Tables(0).Rows(0).Item("EntityID"), String).Trim
					myProcessState = CType(myProcessDataSet.Tables(0).Rows(0).Item("ProcessState"), String).Trim
					myNote = CType(myProcessDataSet.Tables(0).Rows(0).Item("Note"), String).Trim
					myProcessDate = CType(myProcessDataSet.Tables(0).Rows(0).Item("ProcessDate"), Date)

					TextBoxProcessState.Text = myProcessState
					TextBoxNote.Text = myNote
					TextBoxProcessDate.Text = myProcessDate.Year & "/" & myProcessDate.Month & "/" & myProcessDate.Day
					If TextBoxProcessDate.Text = "1900/1/1" Then
						TextBoxProcessDate.Text = ""
					End If

					If myProcessID.Trim.Length > 0 Then
						FillAttributeData(myProcessID)
					Else
						'exception:process id is empty
					End If
				Else
					'exception:process record is empty or duplicated
				End If
			End If
		End Sub
		Private Sub FillAttributeData(ByVal myProcessID As String)
			Dim myAttributeCodeDAO As New ProcessAttributeCodeDAOExtand
			Dim myAttributeCodeDataSet As DataSet
			Dim myAttributeCodeCount As Integer = 0
			Dim myAttributeMapDAO As New ProcessAttributeMapDAOExtand
			Dim myAttributeMapDataSet As DataSet
			Dim myAttributeMapCount As Integer = 0
			Dim myAttributeID As String = ""
			Dim myAttributeValue As String = ""
			Dim myAttributeType As Integer = 0
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim myCheckBox As CheckBox
			Dim myTextBox As TextBox

			If myProcessID.Trim.Length > 0 Then
				myAttributeCodeDataSet = myAttributeCodeDAO.GetEntitys()
				myAttributeCodeDataSet = UtilityObject.QueryPermissionFilter(myAttributeCodeDataSet, AttributeCodeAuthorityTarget, Context.User.Identity.Name)
				myAttributeCodeCount = myAttributeCodeDataSet.Tables(0).Rows.Count

				If myAttributeCodeCount > 0 Then
					For i = 0 To myAttributeCodeCount - 1
						myAttributeID = CType(myAttributeCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myAttributeType = CType(myAttributeCodeDataSet.Tables(0).Rows(i).Item("TypeID"), Integer)
						If myAttributeType = AttributeType.Normal Then
							'normal attribute
							myCheckBox = CType(PlaceHolderAttribute.FindControl("Attribute" & myAttributeID), CheckBox)
							If Not (myCheckBox Is Nothing) Then
								myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessIDAndAttributeID(myProcessID, myAttributeID)
								myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
								myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count
								If myAttributeMapCount > 0 Then
									myAttributeValue = CType(myAttributeMapDataSet.Tables(0).Rows(0).Item("AttributeValue"), String)
									If myAttributeValue.Trim = "1" Then
										myCheckBox.Checked = True
									Else
										myCheckBox.Checked = False
									End If
								End If
							Else
								'exception:checkbox control not found
							End If
						Else
							If myAttributeType = AttributeType.NewsRelease Then
								'news release attribute
								myTextBox = CType(PlaceHolderAttribute.FindControl("Attribute" & myAttributeID), TextBox)
								If Not (myTextBox Is Nothing) Then
									myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessIDAndAttributeID(myProcessID, myAttributeID)
									myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
									myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count
									If myAttributeMapCount > 0 Then
										myAttributeValue = CType(myAttributeMapDataSet.Tables(0).Rows(0).Item("AttributeValue"), String)
										If myAttributeValue.Trim.Length > 0 Then
											myTextBox.Text = myAttributeValue.Trim
										Else
											myTextBox.Text = ""
										End If
									End If
								Else
									'exception:textbox control not found
								End If
							Else
								If myAttributeType = AttributeType.CouncilmanInstruction Then
									'councilman instruction attribute
									myTextBox = CType(PlaceHolderAttribute.FindControl("Attribute" & myAttributeID), TextBox)
									If Not (myTextBox Is Nothing) Then
										myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessIDAndAttributeID(myProcessID, myAttributeID)
										myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
										myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count
										If myAttributeMapCount > 0 Then
											myAttributeValue = CType(myAttributeMapDataSet.Tables(0).Rows(0).Item("AttributeValue"), String)
											If myAttributeValue.Trim.Length > 0 Then
												myTextBox.Text = myAttributeValue.Trim
											Else
												myTextBox.Text = ""
											End If
										End If
									Else
										'exception:textbox control not found
									End If
								Else
									If myAttributeType = AttributeType.Law Then
										'councilman instruction attribute
										myTextBox = CType(PlaceHolderAttribute.FindControl("Attribute" & myAttributeID), TextBox)
										If Not (myTextBox Is Nothing) Then
											myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessIDAndAttributeID(myProcessID, myAttributeID)
											myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
											myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count
											If myAttributeMapCount > 0 Then
												myAttributeValue = CType(myAttributeMapDataSet.Tables(0).Rows(0).Item("AttributeValue"), String)
												If myAttributeValue.Trim.Length > 0 Then
													myTextBox.Text = myAttributeValue.Trim
												Else
													myTextBox.Text = ""
												End If
											End If
										Else
											'exception:textbox control not found
										End If
									Else
										'exception:unknown attribute type
									End If
								End If
							End If
						End If
					Next
				End If
			Else
				'exception:process id is empty
			End If
		End Sub
		Private Function SaveProcessData(ByVal myProcessID As String) As String
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myProcessDate As Date = New Date(1900, 1, 1)
			Dim myProcessState As String = ""
			Dim myNote As String = ""
			Dim myAuthorityBO As New ContextAuthBO

			If TextBoxProcessDate.Text.Trim <> "" Then
				tempString = TextBoxProcessDate.Text.Trim
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 3 Then
					myProcessDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				End If
			End If
			myProcessState = TextBoxProcessState.Text.Trim
			myNote = TextBoxNote.Text.Trim

			If formID.Trim.Length > 0 Then
				If myProcessID.Trim.Length > 0 Then
					'get authority
					If myAuthorityBO.CheckPurview(ProcessAuthorityTarget, myProcessID, Context.User.Identity.Name, "U") Then
						'update
						myProcessDAO.UpdateEntity(myProcessID, myProcessDate, myProcessState, myNote, Context.User.Identity.Name, Now)
					End If
				Else
					'insert
					myProcessID = myProcessDAO.InsertEntity(formID, 0, DefaultPermission, DefaultPermission, myProcessDate, myProcessState, myNote, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
				End If
			Else
				'exception:form id is empty
			End If
			Return myProcessID
		End Function
		Private Sub DeleteProcessData(ByVal myProcessID As String)
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myAuthorityBO As New ContextAuthBO

			If myProcessID.Trim.Length > 0 Then
				myProcessDataSet = myProcessDAO.GetEntitysByEntityID(myProcessID)
				If myProcessDataSet.Tables(0).Rows.Count = 1 Then
					DeleteAttributeData(myProcessID)
					'get authority
					If myAuthorityBO.CheckPurview(ProcessAuthorityTarget, myProcessID, Context.User.Identity.Name, "D") Then
						myProcessDAO.DeleteEntity(myProcessID)
					End If
				Else
					'exception:process record is empty or duplicated
				End If
			Else
				'exception:process id is empty
			End If
		End Sub
		Private Sub SaveAttributeData(ByVal myProcessID As String)
			Dim myAttributeMapDAO As New ProcessAttributeMapDAOExtand
			Dim myAttributeCodeDAO As New ProcessAttributeCodeDAOExtand
			Dim myAttributeCodeDataSet As DataSet
			Dim myAttributeCodeCount As Integer = 0
			Dim myAttributeCodeID As String = ""
			Dim myAttributeCodeType As Integer = 0
			Dim i As Integer = 0

			If myProcessID.Trim.Length > 0 Then
				myAttributeCodeDataSet = myAttributeCodeDAO.GetEntitys
				myAttributeCodeDataSet = UtilityObject.QueryPermissionFilter(myAttributeCodeDataSet, AttributeCodeAuthorityTarget, Context.User.Identity.Name)
				myAttributeCodeCount = myAttributeCodeDataSet.Tables(0).Rows.Count
				If myAttributeCodeCount > 0 Then
					For i = 0 To myAttributeCodeCount - 1
						myAttributeCodeID = CType(myAttributeCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myAttributeCodeType = CType(myAttributeCodeDataSet.Tables(0).Rows(i).Item("TypeID"), Integer)
						If myAttributeCodeType = AttributeType.Normal Then
							'normal attribute
							If Not (Request.Params("Attribute" & myAttributeCodeID) Is Nothing) Then
								If Request.Params("Attribute" & myAttributeCodeID) = "on" Then
									myAttributeMapDAO.InsertEntity(myProcessID, 0, DefaultPermissionGroup, DefaultPermission, myAttributeCodeID, "1", Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
									'alter display order
									myAttributeCodeDAO.IncreaseDisplayOrder(myAttributeCodeID, 1)
								End If
							End If
						Else
							If myAttributeCodeType = AttributeType.NewsRelease Then
								'news release attribute
								If Not (Request.Params("Attribute" & myAttributeCodeID) Is Nothing) Then
									If Request.Params("Attribute" & myAttributeCodeID).Trim.Length > 0 Then
										myAttributeMapDAO.InsertEntity(myProcessID, 0, DefaultPermissionGroup, DefaultPermission, myAttributeCodeID, Request.Params("Attribute" & myAttributeCodeID).Trim, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
										'alter display order
										myAttributeCodeDAO.IncreaseDisplayOrder(myAttributeCodeID, 1)
									End If
								End If
							Else
								If myAttributeCodeType = AttributeType.CouncilmanInstruction Then
									'councilman instruction attribute
									If Not (Request.Params("Attribute" & myAttributeCodeID) Is Nothing) Then
										If Request.Params("Attribute" & myAttributeCodeID).Trim.Length > 0 Then
											myAttributeMapDAO.InsertEntity(myProcessID, 0, DefaultPermissionGroup, DefaultPermission, myAttributeCodeID, Request.Params("Attribute" & myAttributeCodeID).Trim, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
											'alter display order
											myAttributeCodeDAO.IncreaseDisplayOrder(myAttributeCodeID, 1)
										End If
									End If
								Else
									If myAttributeCodeType = AttributeType.Law Then
										'law attribute
										If Not (Request.Params("Attribute" & myAttributeCodeID) Is Nothing) Then
											If Request.Params("Attribute" & myAttributeCodeID).Trim.Length > 0 Then
												myAttributeMapDAO.InsertEntity(myProcessID, 0, DefaultPermissionGroup, DefaultPermission, myAttributeCodeID, Request.Params("Attribute" & myAttributeCodeID).Trim, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
												'alter display order
												myAttributeCodeDAO.IncreaseDisplayOrder(myAttributeCodeID, 1)
											End If
										End If
									Else
										'exception:unknown attribute type
									End If
								End If
							End If
						End If
					Next
				End If
			Else
				'exception:process id is empty
			End If
		End Sub
		Private Sub DeleteAttributeData(ByVal myProcessID As String)
			Dim myAttributeCodeDAO As New ProcessAttributeCodeDAOExtand
			Dim myAttributeMapDAO As New ProcessAttributeMapDAOExtand
			Dim myAttributeMapDataSet As DataSet
			Dim myAttributeMapCount As Integer = 0
			Dim i As Integer = 0
			Dim myAttributeID As String = ""
			Dim myAttributeCodeID As String = ""
			Dim myAuthorityBO As New ContextAuthBO

			If myProcessID.Trim.Length > 0 Then
				myAttributeMapDataSet = myAttributeMapDAO.GetEntitysByProcessID(myProcessID)
				'myAttributeMapDataSet = UtilityObject.QueryPermissionFilter(myAttributeMapDataSet, AttributeAuthorityTarget, Context.User.Identity.Name)
				myAttributeMapCount = myAttributeMapDataSet.Tables(0).Rows.Count
				If myAttributeMapCount > 0 Then
					For i = 0 To myAttributeMapCount - 1
						myAttributeID = CType(myAttributeMapDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myAttributeCodeID = CType(myAttributeMapDataSet.Tables(0).Rows(i).Item("AttributeID"), String)
						'get authority
						If myAuthorityBO.CheckPurview(AttributeAuthorityTarget, myAttributeID, Context.User.Identity.Name, "D") Then
							myAttributeMapDAO.DeleteEntity(myAttributeID)
							'alter display order
							myAttributeCodeDAO.DecreaseDisplayOrder(myAttributeCodeID, 1)
						End If
					Next
				End If
			Else
				'exception:process id is empty
			End If
		End Sub
		Private Sub InitialWebControl()
			Dim myAttributeCodeDAO As New ProcessAttributeCodeDAOExtand
			Dim myAttributeCodeDataSet As DataSet
			Dim myAttributeCodeCount As Integer = 0
			Dim myOutlineTable As HtmlTable
			Dim myOutlineTableRow As HtmlTableRow
			Dim myOutlineTableCell As HtmlTableCell
			Dim myDetailTable As HtmlTable
			Dim myDetailTableRow As HtmlTableRow
			Dim myDetailTableCell As HtmlTableCell
			Dim myLiterial As LiteralControl
			Dim myName As String = ""
			Dim myAttributeID As String = ""
			Dim myAttributeValue As String = ""
			Dim myAttributeType As Integer = 0
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim myCheckBox As CheckBox
			Dim myTextBox As TextBox

			TextBoxProcessDate.Text = ""
			TextBoxProcessState.Text = ""
			TextBoxNote.Text = ""

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
						'attribute checkbox
						myDetailTableRow = New HtmlTableRow
						myDetailTableCell = New HtmlTableCell
						myDetailTableCell.BgColor = NormalProcessBGColor
						myDetailTableCell.Align = "center"
						myDetailTableCell.Height = NormalAttributeHeight
						myDetailTableCell.Width = NormalAttributeWidth
						myCheckBox = New CheckBox
						myCheckBox.ID = "Attribute" & myAttributeID
						myDetailTableCell.Controls.Add(myCheckBox)
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
							'attribute textbox
							myDetailTableRow = New HtmlTableRow
							myDetailTableCell = New HtmlTableCell
							myDetailTableCell.BgColor = NormalProcessBGColor
							myDetailTableCell.Align = "center"
							myDetailTableCell.Height = NewsAttributeHeight
							myDetailTableCell.Width = NewsAttributeWidth
							myTextBox = New TextBox
							myTextBox.Width = Unit.Pixel(CType(NewsAttributeWidth, Integer) - 4)
							myTextBox.ID = "Attribute" & myAttributeID
							myTextBox.Attributes("OnClick") = "window.open('NewsReleaseList.aspx?ReturnObjectID=" & myTextBox.ClientID & "','','height=328,width=800,status=no,toolbar=no,menubar=no,location=no','')"
							myDetailTableCell.Controls.Add(myTextBox)
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
								'attribute textbox
								myDetailTableRow = New HtmlTableRow
								myDetailTableCell = New HtmlTableCell
								myDetailTableCell.BgColor = NormalProcessBGColor
								myDetailTableCell.Align = "center"
								myDetailTableCell.Height = InstructionAttributeHeight
								myDetailTableCell.Width = InstructionAttributeWidth
								myTextBox = New TextBox
								myTextBox.Width = Unit.Pixel(CType(NewsAttributeWidth, Integer) - 4)
								myTextBox.ID = "Attribute" & myAttributeID
								myTextBox.Attributes("OnClick") = "window.open('CouncilmanInstructionList.aspx?ReturnObjectID=" & myTextBox.ClientID & "','','height=328,width=800,status=no,toolbar=no,menubar=no,location=no','')"
								myDetailTableCell.Controls.Add(myTextBox)
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
									'attribute textbox
									myDetailTableRow = New HtmlTableRow
									myDetailTableCell = New HtmlTableCell
									myDetailTableCell.BgColor = NormalProcessBGColor
									myDetailTableCell.Align = "center"
									myDetailTableCell.Height = InstructionAttributeHeight
									myDetailTableCell.Width = InstructionAttributeWidth
									myTextBox = New TextBox
									myTextBox.Width = Unit.Pixel(CType(NewsAttributeWidth, Integer) - 4)
									myTextBox.ID = "Attribute" & myAttributeID
									myTextBox.Attributes("OnClick") = "window.open('LawList.aspx?ReturnObjectID=" & myTextBox.ClientID & "','','height=328,width=800,status=no,toolbar=no,menubar=no,location=no','')"
									myDetailTableCell.Controls.Add(myTextBox)
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
		End Sub

		Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myProcessID As String = ""
			Dim i As Integer = 0
			Dim myItemID As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False

			If formID.Trim.Length > 0 Then
				If processID.Trim.Length > 0 Then
					myPreviousID = processID
					myProcessDataSet = myProcessDAO.GetEntitysByEntityID(processID)
					If myProcessDataSet.Tables(0).Rows.Count = 1 Then
						myItemID = CType(myProcessDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)

						myProcessDataSet = myProcessDAO.GetItemIDByFormID(formID)
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
								Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&processID=" & myPreviousID)
							End If
						End If
					Else
						'exception:form record is empty or duplicated
					End If
				Else
					'new process
					myProcessDataSet = myProcessDAO.GetEntitysByFormID(formID)
					myProcessDataSet = UtilityObject.QueryPermissionFilter(myProcessDataSet, ProcessAuthorityTarget, Context.User.Identity.Name, 1)
					If myProcessDataSet.Tables(0).Rows.Count = 1 Then
						myProcessID = CType(myProcessDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						If myProcessID.Trim.Length > 0 Then
							Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&processID=" & myProcessID)
						Else
							'exception:process id is empty
						End If
					Else
						InitialWebControl()
					End If
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myProcessID As String = ""
			Dim i As Integer = 0
			Dim myItemID As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False

			If formID.Trim.Length > 0 Then
				If processID.Trim.Length > 0 Then
					myNextID = processID
					myProcessDataSet = myProcessDAO.GetEntitysByEntityID(processID)
					If myProcessDataSet.Tables(0).Rows.Count = 1 Then
						myItemID = CType(myProcessDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
						myProcessDataSet = myProcessDAO.GetItemIDByFormID(formID)
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
								Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&processID=" & myNextID)
							End If
						End If
					Else
						'exception:form record is empty or duplicated
					End If
				Else
					'new process
					myProcessDataSet = myProcessDAO.GetEntitysByFormID(formID)
					myProcessDataSet = UtilityObject.QueryPermissionFilter(myProcessDataSet, ProcessAuthorityTarget, Context.User.Identity.Name, 1)
					If myProcessDataSet.Tables(0).Rows.Count = 1 Then
						myProcessID = CType(myProcessDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						If myProcessID.Trim.Length > 0 Then
							Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&processID=" & myProcessID)
						Else
							'exception:process id is empty
						End If
					Else
						InitialWebControl()
					End If
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsert.Click
			Dim myProcessID As String = ""

			If formID.Trim.Length > 0 Then
				myProcessID = SaveProcessData("")
				If myProcessID.Trim.Length > 0 Then
					SaveAttributeData(myProcessID)
					Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&processID=" & myProcessID)
				Else
					'exception:insert failure
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myProcessID As String = ""

			If formID.Trim.Length > 0 Then
				If processID.Trim.Length > 0 Then
					processID = SaveProcessData(processID)
					If processID.Trim.Length > 0 Then
						DeleteAttributeData(processID)
						SaveAttributeData(processID)
						Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&processID=" & processID)
					Else
						'exception:update failure
					End If
				Else
					'new process
					myProcessDataSet = myProcessDAO.GetEntitysByFormID(formID)
					myProcessDataSet = UtilityObject.QueryPermissionFilter(myProcessDataSet, ProcessAuthorityTarget, Context.User.Identity.Name, 1)
					If myProcessDataSet.Tables(0).Rows.Count = 1 Then
						myProcessID = CType(myProcessDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						If myProcessID.Trim.Length > 0 Then
							Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&processID=" & myProcessID)
						Else
							'exception:process id is empty
						End If
					Else
						InitialWebControl()
					End If
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
			Dim myProcessDAO As New AffairProcessMapDAOExtand
			Dim myProcessDataSet As DataSet
			Dim myProcessID As String = ""

			If formID.Trim.Length > 0 Then
				If processID.Trim.Length > 0 Then
					DeleteProcessData(processID)
					Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID)
				Else
					'new process
					myProcessDataSet = myProcessDAO.GetEntitysByFormID(formID)
					myProcessDataSet = UtilityObject.QueryPermissionFilter(myProcessDataSet, ProcessAuthorityTarget, Context.User.Identity.Name, 1)
					If myProcessDataSet.Tables(0).Rows.Count = 1 Then
						myProcessID = CType(myProcessDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						If myProcessID.Trim.Length > 0 Then
							Response.Redirect("~/DesktopModules/AuditSystem/ProcessAttributeCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&processID=" & myProcessID)
						Else
							'exception:process id is empty
						End If
					Else
						InitialWebControl()
					End If
				End If
			Else
				'exception:form id is empty
			End If
		End Sub
	End Class
End Namespace