Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class MeetingRecordAdminFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents DropDownListType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxMeetingDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxStartTime As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxEndTime As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListPlace As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxPresentPerson As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxObserver As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListChairPerson As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListScribe As System.Web.UI.WebControls.DropDownList
		Protected WithEvents LabelResult As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxMeetingNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonNext As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonRecordInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonRecordUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonRecordDelete As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxPlaceName As System.Web.UI.WebControls.TextBox
		Protected WithEvents AjaxPanelPlace As MagicAjax.UI.Controls.AjaxPanel

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
		Private Const RecordAuthorityTarget As String = "MeetingRecord"
		Private Const ResolutionAuthorityTarget As String = "MeetingRecordResolution"
		Private Const FormAuthorityTarget As String = "AffairProcessCheckForm"
		Private Const CodeAuthorityTarget As String = "NormalCode"
		Private UtilityObject As New AuditSystemUtility

		Private tabIndex As Integer = 0
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Private typeID As String = ""
		Private recordID As String = ""
		Private resolutionID As String = ""
		Private MainOfficeID As String = ""
		Private AffairCodeGroupID As String = ""
		Private action As String = ""
		Private Const MainOfficeCodeGroupID As String = "2006010100000003"
		Private Const AssistOfficeCodeGroupID As String = "2006010100000006"
		Private Const TypeCodeGroupID As String = "2006010100000009"
		Private Const PlaceCodeGroupID As String = "200601010000000A"
		Private Const SketchCodeGroupID As String = "200601010000000B"
		Private Const PresentCodeGroupID As String = "200601010000000C"
		Private Const ActionColumnWidth As String = "40"
		Private Const NumberColumnWidth As String = "64"
		Private Const ContentColumnWidth As String = "240"
		Private Const MainOfficeColumnWidth As String = "64"
		Private Const AffairColumnWidth As String = "120"
		Private Const AssistOfficeColumnWidth As String = "64"
		Private Const SketchColumnWidth As String = "80"
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

			If Not (Request.Params("typeID") Is Nothing) Then
				typeID = Request.Params("typeID")
				'Else
				'typeID = "200601010000000900000001"
			End If

			If Not (Request.Params("recordID") Is Nothing) Then
				recordID = Request.Params("recordID")
			End If

			If Not (Request.Params("resolutionID") Is Nothing) Then
				resolutionID = Request.Params("resolutionID")
			End If

			If Not (Request.Params("action") Is Nothing) Then
				action = Request.Params("action")
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				MainOfficeID = "200601010000000300000001"
				AffairCodeGroupID = "2006010100000011"
				InitialWebControl()
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myRecordID As String = ""

			If recordID.Trim.Length > 0 Then
				myRecordDataSet = myRecordDAO.GetEntitysByEntityID(recordID)
			Else
				If typeID.Trim.Length > 0 Then
					myRecordDataSet = myRecordDAO.GetEntitysByTypeID(typeID)
					myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name, 1)

					If myRecordDataSet.Tables(0).Rows.Count = 1 Then
						myRecordID = CType(myRecordDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & myRecordID)
					End If
				Else
					'exception:type id is empty
				End If
			End If
			FillRecordData(myRecordDataSet)
		End Sub
		Private Sub AlterMainOfficeIDAndAffairCodeGroupID(ByVal myMainOfficeID As String)
			If myMainOfficeID.Trim.Length > 0 Then
				MainOfficeID = myMainOfficeID
			Else
				'exception:main office is empty
			End If
			If MainOfficeID = "200601010000000300000001" Then
				AffairCodeGroupID = "2006010100000011"
			Else
				If MainOfficeID = "200601010000000300000002" Then
					AffairCodeGroupID = "2006010100000012"
				Else
					If MainOfficeID = "200601010000000300000003" Then
						AffairCodeGroupID = "2006010100000013"
					Else
						If MainOfficeID = "200601010000000300000004" Then
							AffairCodeGroupID = "2006010100000014"
						Else
							If MainOfficeID = "200601010000000300000005" Then
								AffairCodeGroupID = "2006010100000015"
							Else
								If MainOfficeID = "200601010000000300000006" Then
									AffairCodeGroupID = "2006010100000016"
								Else
									If MainOfficeID = "200601010000000300000007" Then
										AffairCodeGroupID = "2006010100000017"
									Else
										If MainOfficeID = "200601010000000300000008" Then
											AffairCodeGroupID = "2006010100000018"
										Else
											'exception:unknown group
											MainOfficeID = "200601010000000300000001"
											AffairCodeGroupID = "2006010100000011"
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub
		Private Sub FillRecordData(ByVal myRecordDataSet As DataSet)
			Dim myRecordID As String = ""
			Dim myMeetingNumber As Integer = 0
			Dim myTypeID As String = ""
			Dim myMeetingDate As Date
			Dim myStartTime As String = ""
			Dim myEndTime As String = ""
			Dim myPlaceID As String = ""
			Dim myPresentPerson As String = ""
			Dim myObserver As String = ""
			Dim myChairPersonID As String = ""
			Dim myScribeID As String = ""
			Dim myTitle As String = ""
			Dim myPlaceName As String = ""

			If Not (myRecordDataSet Is Nothing) Then
				If myRecordDataSet.Tables(0).Rows.Count = 1 Then
					myRecordID = CType(myRecordDataSet.Tables(0).Rows(0).Item("EntityID"), String)
					myMeetingNumber = CType(myRecordDataSet.Tables(0).Rows(0).Item("MeetingNumber"), Integer)
					myTypeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("TypeID"), String)
					myMeetingDate = CType(myRecordDataSet.Tables(0).Rows(0).Item("MeetingDate"), Date)
					myStartTime = CType(myRecordDataSet.Tables(0).Rows(0).Item("StartTime"), String)
					myEndTime = CType(myRecordDataSet.Tables(0).Rows(0).Item("EndTime"), String)
					myPlaceID = CType(myRecordDataSet.Tables(0).Rows(0).Item("PlaceID"), String)
					myPresentPerson = CType(myRecordDataSet.Tables(0).Rows(0).Item("PresentPerson"), String)
					myObserver = CType(myRecordDataSet.Tables(0).Rows(0).Item("Observer"), String)
					myChairPersonID = CType(myRecordDataSet.Tables(0).Rows(0).Item("ChairPersonID"), String)
					myScribeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("ScribeID"), String)
					myTitle = CType(myRecordDataSet.Tables(0).Rows(0).Item("Title"), String)
					myPlaceName = CType(myRecordDataSet.Tables(0).Rows(0).Item("PlaceName"), String)

					Try
						DropDownListType.SelectedValue = myTypeID
					Catch ex As Exception
						'exception:no match
					End Try
					Try
						DropDownListPlace.SelectedValue = myPlaceID
					Catch ex As Exception
						'exception:no match
					End Try
					Try
						DropDownListChairPerson.SelectedValue = myChairPersonID
					Catch ex As Exception
						'exception:no match
					End Try
					Try
						DropDownListScribe.SelectedValue = myScribeID
					Catch ex As Exception
						'exception:no match
					End Try

					TextBoxMeetingNumber.Text = CType(myMeetingNumber, String)
					TextBoxStartTime.Text = myStartTime
					TextBoxEndTime.Text = myEndTime
					TextBoxPresentPerson.Text = myPresentPerson
					TextBoxObserver.Text = myObserver
					TextBoxMeetingDate.Text = myMeetingDate.Year & "/" & myMeetingDate.Month & "/" & myMeetingDate.Day
					If TextBoxMeetingDate.Text = "1900/1/1" Then
						TextBoxMeetingDate.Text = ""
					End If
					TextBoxTitle.Text = myTitle

					If myPlaceID = "200601010000000A00000010" Then
						TextBoxPlaceName.Text = myPlaceName
						TextBoxPlaceName.Visible = True
					End If

					'''resolution
					''If myRecordID.Trim.Length > 0 Then
					''	FillResolutionData(myRecordID)
					''Else
					''	'exception:record id is empty
					''End If
				Else
					'exception:record dataset is empty or duplicated
				End If
			End If
		End Sub
		''Private Sub FillResolutionData(ByVal myRecordID As String)
		''	Dim myRecordDAO As New MeetingRecordDAOExtand
		''	Dim myRecordDataSet As DataSet
		''	Dim myNormalCodeDAO As New NormalCodeDAOExtand
		''	Dim myResolutionDAO As New MeetingRecordResolutionDAOExtand
		''	Dim myResolutionDataSet As DataSet
		''	Dim myResolutionCount As Integer = 0
		''	Dim myTable As HtmlTable
		''	Dim myTableRow As HtmlTableRow
		''	Dim myTableCell As HtmlTableCell
		''	Dim myHyperLink As HyperLink
		''	Dim myLiterial As LiteralControl
		''	Dim myImage As HtmlImage
		''	Dim myResolutionID As String = ""
		''	Dim myNumber As String = ""
		''	Dim myContent As String = ""
		''	Dim myMainOfficeID As String = ""
		''	Dim myAssistOfficeID As String = ""
		''	Dim mySketchID As String = ""
		''	Dim myAffairID As String = ""
		''	Dim myMeetingNumber As Integer = 1
		''	Dim myTypeID As String = ""
		''	Dim i As Integer = 0

		''	If myRecordID.Trim.Length > 0 Then
		''		myRecordDataSet = myRecordDAO.GetEntitysByEntityID(myRecordID)
		''		If myRecordDataSet.Tables(0).Rows.Count = 1 Then
		''			myMeetingNumber = CType(myRecordDataSet.Tables(0).Rows(0).Item("MeetingNumber"), Integer)
		''			myTypeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("TypeID"), String)

		''			PlaceHolderResolution.Controls.Clear()

		''			myTable = New HtmlTable
		''			myTable.CellPadding = 0
		''			myTable.CellSpacing = 0
		''			myTable.Border = 1
		''			'prepare resolution header
		''			myTableRow = New HtmlTableRow
		''			myTableRow.BgColor = NormalCodeBGColor
		''			'action column header
		''			myTableCell = New HtmlTableCell
		''			myTableCell.Width = ActionColumnWidth
		''			myTableRow.Cells.Add(myTableCell)
		''			'resolution number column header
		''			myTableCell = New HtmlTableCell
		''			myTableCell.Width = NumberColumnWidth
		''			myTableCell.InnerText = "編號"
		''			myTableRow.Cells.Add(myTableCell)
		''			'resolution content column header
		''			myTableCell = New HtmlTableCell
		''			myTableCell.Width = ContentColumnWidth
		''			myTableCell.InnerText = "決議事項"
		''			myTableRow.Cells.Add(myTableCell)
		''			'resolution main office column header
		''			myTableCell = New HtmlTableCell
		''			myTableCell.Width = MainOfficeColumnWidth
		''			myTableCell.InnerText = "主辦"
		''			myTableRow.Cells.Add(myTableCell)
		''			'resolution affair column header
		''			myTableCell = New HtmlTableCell
		''			myTableCell.Width = AffairColumnWidth
		''			myTableCell.InnerText = "應辦事項"
		''			myTableRow.Cells.Add(myTableCell)
		''			'resolution assist office column header
		''			myTableCell = New HtmlTableCell
		''			myTableCell.Width = AssistOfficeColumnWidth
		''			myTableCell.InnerText = "協辦"
		''			myTableRow.Cells.Add(myTableCell)
		''			'resolution sketch column header
		''			myTableCell = New HtmlTableCell
		''			myTableCell.Width = SketchColumnWidth
		''			myTableCell.InnerText = "擬辦"
		''			myTableRow.Cells.Add(myTableCell)

		''			myTable.Rows.Add(myTableRow)

		''			myResolutionDataSet = myResolutionDAO.GetEntitysByMeetingRecordID(myRecordID)
		''			myResolutionDataSet = UtilityObject.QueryPermissionFilter(myResolutionDataSet, ResolutionAuthorityTarget, Context.User.Identity.Name)
		''			myResolutionCount = myResolutionDataSet.Tables(0).Rows.Count

		''			If myResolutionCount > 0 Then
		''				For i = 0 To myResolutionCount - 1
		''					myResolutionID = CType(myResolutionDataSet.Tables(0).Rows(i).Item("EntityID"), String)
		''					myTableRow = New HtmlTableRow
		''					If myResolutionID = resolutionID Then
		''						myTableRow.BgColor = FocusCodeBGColor
		''					Else
		''						myTableRow.BgColor = NormalCodeBGColor
		''					End If

		''					'insert icon
		''					myTableCell = New HtmlTableCell
		''					myTableCell.Width = ActionColumnWidth
		''					'insert link
		''					myHyperLink = New HyperLink
		''					myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & myRecordID & "&resolutionID=" & myResolutionID & "&action=update"
		''					myHyperLink.ImageUrl = "~/images/edit.gif"
		''					myHyperLink.Text = "修改"
		''					myTableCell.Controls.Add(myHyperLink)
		''					'br
		''					myLiterial = New LiteralControl
		''					myLiterial.Text = "<BR>"
		''					myTableCell.Controls.Add(myLiterial)
		''					'insert link
		''					myHyperLink = New HyperLink
		''					myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & myRecordID & "&resolutionID=" & myResolutionID & "&action=delete"
		''					myHyperLink.ImageUrl = "~/images/delete.gif"
		''					myHyperLink.Text = "刪除"
		''					myTableCell.Controls.Add(myHyperLink)

		''					myTableRow.Cells.Add(myTableCell)

		''					'resolution number
		''					myNumber = CType(myResolutionDataSet.Tables(0).Rows(i).Item("ResolutionNumber"), String).Trim
		''					myTableCell = New HtmlTableCell
		''					myTableCell.Width = NumberColumnWidth
		''					If myNumber.Length > 8 Then
		''						myTableCell.InnerHtml = myNumber.Substring(0, 8) & "<BR>" & myNumber.Substring(8)
		''					Else
		''						myTableCell.InnerHtml = myNumber
		''					End If
		''					myTableRow.Cells.Add(myTableCell)

		''					'resolution content
		''					myContent = CType(myResolutionDataSet.Tables(0).Rows(i).Item("Content"), String)
		''					myTableCell = New HtmlTableCell
		''					myTableCell.Width = ContentColumnWidth
		''					myTableCell.InnerHtml = myContent
		''					myTableRow.Cells.Add(myTableCell)

		''					'resolution main office
		''					myMainOfficeID = CType(myResolutionDataSet.Tables(0).Rows(i).Item("MainOfficeID"), String)
		''					myTableCell = New HtmlTableCell
		''					myTableCell.Width = MainOfficeColumnWidth
		''					myTableCell.InnerHtml = myNormalCodeDAO.GetNameByEntityID(myMainOfficeID)
		''					myTableRow.Cells.Add(myTableCell)

		''					'resolution affair
		''					myAffairID = GetAffairID(myTypeID, myMeetingNumber, myNumber)
		''					myTableCell = New HtmlTableCell
		''					myTableCell.Width = AffairColumnWidth
		''					myTableCell.InnerHtml = myNormalCodeDAO.GetNameByEntityID(myAffairID)
		''					myTableRow.Cells.Add(myTableCell)

		''					'resolution assist office
		''					myAssistOfficeID = CType(myResolutionDataSet.Tables(0).Rows(i).Item("AssistOfficeID"), String)
		''					myTableCell = New HtmlTableCell
		''					myTableCell.Width = AssistOfficeColumnWidth
		''					myTableCell.InnerHtml = myNormalCodeDAO.GetNameByEntityID(myAssistOfficeID)
		''					myTableRow.Cells.Add(myTableCell)

		''					'resolution sketch
		''					mySketchID = CType(myResolutionDataSet.Tables(0).Rows(i).Item("SketchID"), String)
		''					myTableCell = New HtmlTableCell
		''					myTableCell.Width = SketchColumnWidth
		''					myTableCell.InnerHtml = myNormalCodeDAO.GetNameByEntityID(mySketchID)
		''					myTableRow.Cells.Add(myTableCell)

		''					myTable.Rows.Add(myTableRow)
		''				Next
		''			Else
		''				'new resolution
		''			End If
		''			PlaceHolderResolution.Controls.Add(myTable)

		''			'update resolution
		''			If resolutionID.Trim.Length > 0 Then
		''				myResolutionDataSet = myResolutionDAO.GetEntitysByEntityID(resolutionID)
		''				If myResolutionDataSet.Tables(0).Rows.Count = 1 Then
		''					myNumber = CType(myResolutionDataSet.Tables(0).Rows(0).Item("ResolutionNumber"), String)
		''					myContent = CType(myResolutionDataSet.Tables(0).Rows(0).Item("Content"), String)
		''					myMainOfficeID = CType(myResolutionDataSet.Tables(0).Rows(0).Item("MainOfficeID"), String)
		''					myAffairID = GetAffairID(myTypeID, myMeetingNumber, myNumber)
		''					myAssistOfficeID = CType(myResolutionDataSet.Tables(0).Rows(0).Item("AssistOfficeID"), String)
		''					mySketchID = CType(myResolutionDataSet.Tables(0).Rows(0).Item("SketchID"), String)
		''				Else
		''					'exception:resolution record is empty or duplicated
		''				End If
		''				If action.Trim.Length > 0 Then
		''					If action.Trim = "update" Then
		''						ButtonResolutionAction.Text = "修改"
		''						TextBoxResolutionNumber.Text = myNumber
		''						TextBoxContent.Text = myContent
		''						Try
		''							DropDownListMainOffice.SelectedValue = myMainOfficeID
		''						Catch ex As Exception
		''							'exception:no match
		''						End Try
		''						AlterMainOfficeIDAndAffairCodeGroupID(myMainOfficeID)
		''						InitialDropDownListAffair()
		''						Try
		''							DropDownListAffair.SelectedValue = myAffairID
		''						Catch ex As Exception
		''							'exception:no match
		''						End Try
		''						Try
		''							DropDownListAssistOffice.SelectedValue = myAssistOfficeID
		''						Catch ex As Exception
		''							'exception:no match
		''						End Try
		''						Try
		''							DropDownListSketch.SelectedValue = mySketchID
		''						Catch ex As Exception
		''							'exception:no match
		''						End Try
		''					Else
		''						If action.Trim = "delete" Then
		''							ButtonResolutionAction.Text = "刪除"
		''							TextBoxResolutionNumber.Text = myNumber
		''							TextBoxContent.Text = myContent
		''							Try
		''								DropDownListMainOffice.SelectedValue = myMainOfficeID
		''							Catch ex As Exception
		''								'exception:no match
		''							End Try
		''							AlterMainOfficeIDAndAffairCodeGroupID(myMainOfficeID)
		''							InitialDropDownListAffair()
		''							Try
		''								DropDownListAffair.SelectedValue = myAffairID
		''							Catch ex As Exception
		''								'exception:no match
		''							End Try
		''							Try
		''								DropDownListAssistOffice.SelectedValue = myAssistOfficeID
		''							Catch ex As Exception
		''								'exception:no match
		''							End Try
		''							Try
		''								DropDownListSketch.SelectedValue = mySketchID
		''							Catch ex As Exception
		''								'exception:no match
		''							End Try
		''						Else
		''							'exception:unknown action
		''						End If
		''					End If
		''				Else
		''					'exception:no action
		''				End If
		''			End If
		''			ButtonResolutionAction.Visible = True
		''			TextBoxResolutionNumber.Visible = True
		''			TextBoxContent.Visible = True
		''			DropDownListMainOffice.Visible = True
		''			DropDownListAffair.Visible = True
		''			DropDownListAssistOffice.Visible = True
		''			DropDownListSketch.Visible = True
		''		Else
		''			'exception:meeting record is empty or duplicated
		''		End If
		''	Else
		''		'exception:record id is empty
		''	End If
		''End Sub
		''Private Function GetAffairProcessCheckFormDataSet(ByVal myTypeID As String, ByVal myMeetingNumber As Integer, ByVal myResolutionNumber As String) As DataSet
		''	Dim myFormDAO As New AffairProcessCheckFormDAOExtand
		''	Dim myFormDataSet As DataSet
		''	Dim myFormCount As Integer = 0
		''	If (myTypeID.Trim.Length > 0) And (myMeetingNumber <> 0) And (myResolutionNumber.Trim.Length > 0) Then
		''		If myTypeID.Trim = "200601010000000900000002" Then
		''			'AssociationMeeting
		''			myFormCount = myFormDAO.GetTotalRowByAssociationNumberAndAssociationMeetingNumber(myResolutionNumber, myMeetingNumber)
		''			If myFormCount = 1 Then
		''				myFormDataSet = myFormDAO.GetEntitysByAssociationNumberAndAssociationMeetingNumber(myResolutionNumber, myMeetingNumber)
		''			Else
		''				'exception:form record is empty or duplicated
		''			End If
		''		Else
		''			If myTypeID.Trim = "200601010000000900000003" Then
		''				'CouncilMeeting
		''				myFormCount = myFormDAO.GetTotalRowByCouncilNumberAndCouncilMeetingNumber(myResolutionNumber, myMeetingNumber)
		''				If myFormCount = 1 Then
		''					myFormDataSet = myFormDAO.GetEntitysByCouncilNumberAndCouncilMeetingNumber(myResolutionNumber, myMeetingNumber)
		''				Else
		''					'exception:form record is empty or duplicated
		''				End If
		''			Else
		''				If myTypeID.Trim = "200601010000000900000004" Then
		''					'BureauMeeting
		''					myFormCount = myFormDAO.GetTotalRowByBureauNumberAndBureauMeetingNumber(myResolutionNumber, myMeetingNumber)
		''					If myFormCount = 1 Then
		''						myFormDataSet = myFormDAO.GetEntitysByBureauNumberAndBureauMeetingNumber(myResolutionNumber, myMeetingNumber)
		''					Else
		''						'exception:form record is empty or duplicated
		''					End If
		''				Else
		''					If myTypeID.Trim = "200601010000000900000005" Then
		''						'SectionMeeting
		''						myFormCount = myFormDAO.GetTotalRowBySectionNumberAndSectionMeetingNumber(myResolutionNumber, myMeetingNumber)
		''						If myFormCount = 1 Then
		''							myFormDataSet = myFormDAO.GetEntitysBySectionNumberAndSectionMeetingNumber(myResolutionNumber, myMeetingNumber)
		''						Else
		''							'exception:form record is empty or duplicated
		''						End If
		''					Else
		''						'exception:unknown type id
		''					End If
		''				End If
		''			End If
		''		End If
		''	Else
		''		'exception:type id is empty or meeting number = 0 or resolution number is empty
		''	End If
		''	Return myFormDataSet
		''End Function
		''Private Function GetAffairID(ByVal myTypeID As String, ByVal myMeetingNumber As Integer, ByVal myResolutionNumber As String) As String
		''	Dim myFormDataSet As DataSet
		''	Dim myAffairID As String = ""
		''	If (myTypeID.Trim.Length > 0) And (myMeetingNumber <> 0) And (myResolutionNumber.Trim.Length > 0) Then
		''		myFormDataSet = GetAffairProcessCheckFormDataSet(myTypeID, myMeetingNumber, myResolutionNumber)
		''		If Not (myFormDataSet Is Nothing) Then
		''			myAffairID = CType(myFormDataSet.Tables(0).Rows(0).Item("AffairID"), String)
		''		End If
		''	Else
		''		'exception:type id is empty or meeting number = 0 or resolution number is empty
		''	End If
		''	Return myAffairID
		''End Function
		Private Sub InitialWebControl()
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""

			LabelResult.Text = ""
			TextBoxMeetingNumber.Text = ""
			TextBoxMeetingDate.Text = ""
			TextBoxStartTime.Text = ""
			TextBoxEndTime.Text = ""
			TextBoxPresentPerson.Text = ""
			TextBoxObserver.Text = ""
			TextBoxTitle.Text = ""
			TextBoxPlaceName.Text = ""

			TextBoxPlaceName.Visible = False

			''ButtonResolutionAction.Text = "新增"
			''ButtonResolutionAction.Visible = False
			''TextBoxContent.Text = ""
			''TextBoxContent.Visible = False

			DropDownListType.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(TypeCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListType.Items.Add(myListItem)
				Next
			End If

			Try
				DropDownListType.SelectedValue = typeID
			Catch ex As Exception
				'exception:no match
			End Try

			DropDownListPlace.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(PlaceCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListPlace.Items.Add(myListItem)
				Next
			End If

			DropDownListChairPerson.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(PresentCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListChairPerson.Items.Add(myListItem)
				Next
			End If

			DropDownListScribe.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(PresentCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListScribe.Items.Add(myListItem)
				Next
			End If

			''TextBoxResolutionNumber.Text = "自動產生"
			''TextBoxResolutionNumber.Visible = False

			''DropDownListMainOffice.Items.Clear()
			''myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(MainOfficeCodeGroupID)
			''myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			''myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			''If myNormalCodeCount > 0 Then
			''	For i = 0 To myNormalCodeCount - 1
			''		myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
			''		myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

			''		myListItem = New ListItem
			''		myListItem.Value = myCodeID
			''		myListItem.Text = myCodeName

			''		DropDownListMainOffice.Items.Add(myListItem)
			''	Next
			''End If

			''Try
			''	DropDownListMainOffice.SelectedValue = MainOfficeID
			''Catch ex As Exception
			''	'exception:no match
			''End Try
			''DropDownListMainOffice.Visible = False

			''InitialDropDownListAffair()
			''DropDownListAffair.Visible = False

			''DropDownListAssistOffice.Items.Clear()
			''myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(AssistOfficeCodeGroupID)
			''myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			''myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			''If myNormalCodeCount > 0 Then
			''	For i = 0 To myNormalCodeCount - 1
			''		myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
			''		myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

			''		myListItem = New ListItem
			''		myListItem.Value = myCodeID
			''		myListItem.Text = myCodeName

			''		DropDownListAssistOffice.Items.Add(myListItem)
			''	Next
			''End If
			''DropDownListAssistOffice.Visible = False

			''DropDownListSketch.Items.Clear()
			''myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(SketchCodeGroupID)
			''myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			''myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			''If myNormalCodeCount > 0 Then
			''	For i = 0 To myNormalCodeCount - 1
			''		myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
			''		myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

			''		myListItem = New ListItem
			''		myListItem.Value = myCodeID
			''		myListItem.Text = myCodeName

			''		DropDownListSketch.Items.Add(myListItem)
			''	Next
			''End If
			''DropDownListSketch.Visible = False
		End Sub
		Private Sub InitialDropDownListAffair()
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""

			''DropDownListAffair.Items.Clear()
			''myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(AffairCodeGroupID)
			''myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			''myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			''If myNormalCodeCount > 0 Then
			''	For i = 0 To myNormalCodeCount - 1
			''		myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
			''		myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

			''		myListItem = New ListItem
			''		myListItem.Value = myCodeID
			''		myListItem.Text = myCodeName

			''		DropDownListAffair.Items.Add(myListItem)
			''	Next
			''End If
		End Sub
		Private Function SaveRecordData(ByVal myRecordID As String) As String
			Dim myResolutionDAO As New MeetingRecordResolutionDAOExtand
			Dim myResolutionDataSet As DataSet
			Dim myResolutionCount As Integer = 0
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myFormDAO As New AffairProcessCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myFormID As String = ""
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myMeetingNumber As Integer = 1
			Dim myTypeID As String = ""
			Dim myMeetingDate As Date = New Date(1900, 1, 1)
			Dim myStartTime As String = ""
			Dim myEndTime As String = ""
			Dim myPlaceID As String = ""
			Dim myPresentPerson As String = ""
			Dim myObserver As String = ""
			Dim myChairPersonID As String = ""
			Dim myScribeID As String = ""
			Dim myNumber As String = ""
			Dim myOldTypeID As String = ""
			Dim myOldMeetingNumber As Integer = 1
			Dim myAffairID As String = ""
			Dim myMainOfficeID As String = ""
			Dim myAssistOfficeID As String = ""
			Dim myTitle As String = ""
			Dim myPlaceName As String = ""
			Dim i As Integer = 0
			Dim myAuthorityBO As New ContextAuthBO

			Try
				myMeetingNumber = CType(TextBoxMeetingNumber.Text.Trim, Integer)
			Catch ex As Exception
				'exception:cast failure
			End Try
			myTypeID = DropDownListType.SelectedValue
			If TextBoxMeetingDate.Text.Trim <> "" Then
				tempString = TextBoxMeetingDate.Text.Trim
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 3 Then
					myMeetingDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				End If
			End If
			myStartTime = TextBoxStartTime.Text.Trim
			myEndTime = TextBoxEndTime.Text.Trim
			myPlaceID = DropDownListPlace.SelectedValue
			myPresentPerson = TextBoxPresentPerson.Text.Trim
			myObserver = TextBoxObserver.Text.Trim
			myChairPersonID = DropDownListChairPerson.SelectedValue
			myScribeID = DropDownListScribe.SelectedValue
			myTitle = TextBoxTitle.Text.Trim
			If myPlaceID = "200601010000000A00000010" Then
				myPlaceName = TextBoxPlaceName.Text.Trim
			End If

			If myRecordID.Trim.Length > 0 Then
				myRecordDataSet = myRecordDAO.GetEntitysByEntityID(myRecordID)
				If myRecordDataSet.Tables(0).Rows.Count = 1 Then
					'''read origin meeting number and type
					''myOldMeetingNumber = CType(myRecordDataSet.Tables(0).Rows(0).Item("MeetingNumber"), Integer)
					''myOldTypeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("TypeID"), String)
					'''update affairprocesscheckform
					''myResolutionCount = myResolutionDAO.GetTotalRowByMeetingRecordID(myRecordID)
					''If myResolutionCount > 0 Then
					''	myResolutionDataSet = myResolutionDAO.GetEntitysByMeetingRecordID(myRecordID)
					''	For i = 0 To myResolutionCount - 1
					''		'read resolution number
					''		myNumber = CType(myResolutionDataSet.Tables(0).Rows(i).Item("ResolutionNumber"), String).Trim
					''		If myNumber.Length > 0 Then
					''			myFormDataSet = GetAffairProcessCheckFormDataSet(myOldTypeID, myOldMeetingNumber, myNumber)
					''			If Not (myFormDataSet Is Nothing) Then
					''				'read affairprocesscheckform
					''				myFormID = CType(myFormDataSet.Tables(0).Rows(0).Item("EntityID"), String)
					''				myAffairID = CType(myFormDataSet.Tables(0).Rows(0).Item("AffairID"), String)
					''				myMainOfficeID = CType(myFormDataSet.Tables(0).Rows(0).Item("MainOfficeID"), String)
					''				myAssistOfficeID = CType(myFormDataSet.Tables(0).Rows(0).Item("AssistOfficeID"), String)
					''				'get authority
					''				If myAuthorityBO.CheckPurview(FormAuthorityTarget, myFormID, Context.User.Identity.Name, "U") Then
					''					'actual action
					''					'myFormDAO.UpdateEntityByTypeID(myTypeID, myFormID, myAffairID, myMainOfficeID, myAssistOfficeID, myNumber, myMeetingNumber, myMeetingDate, Context.User.Identity.Name, Now)
					''				End If
					''			Else
					''				'exception:form record is empty or duplicated
					''			End If
					''		Else
					''			'exception:resolution number is empty
					''		End If
					''	Next
					''End If
					'get authority
					If myAuthorityBO.CheckPurview(RecordAuthorityTarget, myRecordID, Context.User.Identity.Name, "U") Then
						'update meeting record
						myRecordDAO.UpdateEntity(myRecordID, myTypeID, myMeetingNumber, myMeetingDate, myStartTime, myEndTime, myPlaceID, myPresentPerson, myObserver, myChairPersonID, myScribeID, myTitle, myPlaceName, Context.User.Identity.Name, Now)
					End If
				Else
					'exception:meeting record is empty or duplicated
				End If
			Else
				'insert new data
				'check meeting number
				If typeID.Trim.Length > 0 Then
					If myRecordDAO.GetTotalRowByTypeIDAndMeetingNumber(typeID, myMeetingNumber) = 0 Then
						myRecordID = myRecordDAO.InsertEntity(typeID, 0, DefaultPermission, DefaultPermissionGroup, myMeetingNumber, myMeetingDate, myStartTime, myEndTime, myPlaceID, myPresentPerson, myObserver, myChairPersonID, myScribeID, myTitle, myPlaceName, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
					Else
						'exception:meeting number is exist
						LabelResult.Text = "會議次數重複!"
					End If
				Else
					'exception:type id is empty
				End If
			End If
			Return myRecordID
		End Function
		Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
			Dim myRecordDataSet As DataSet
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim i As Integer = 0
			Dim myTypeID As String = ""
			Dim myItemID As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False

			If recordID.Trim.Length > 0 Then
				myPreviousID = recordID
				myRecordDataSet = myRecordDAO.GetEntitysByEntityID(recordID)
				If myRecordDataSet.Tables(0).Rows.Count = 1 Then
					myTypeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("TypeID"), String)
					myItemID = CType(myRecordDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
					'read total entityid and itemid in group
					myRecordDataSet = myRecordDAO.GetItemIDByTypeID(myTypeID)
					myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
					If myRecordDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myRecordDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myRecordDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							Else
								'save previous id
								myPreviousID = CType(myRecordDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							End If
						Next
						If bFound = True Then
							Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & myPreviousID)
						End If
					End If
				Else
					'exception:resolution record is empty or duplicated
				End If
			Else
				'exception:record id is empty
			End If
		End Sub

		Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
			Dim myRecordDataSet As DataSet
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim i As Integer = 0
			Dim myTypeID As String = ""
			Dim myItemID As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False

			If recordID.Trim.Length > 0 Then
				myNextID = recordID
				myRecordDataSet = myRecordDAO.GetEntitysByEntityID(recordID)
				If myRecordDataSet.Tables(0).Rows.Count = 1 Then
					myTypeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("TypeID"), String)
					myItemID = CType(myRecordDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
					'read total entityid and itemid in group
					myRecordDataSet = myRecordDAO.GetItemIDByTypeID(myTypeID)
					myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
					If myRecordDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myRecordDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myRecordDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							End If
						Next
						If bFound = True Then
							'save next id
							If i + 1 < myRecordDataSet.Tables(0).Rows.Count Then
								myNextID = CType(myRecordDataSet.Tables(0).Rows(i + 1).Item("EntityID"), String)
							Else
								myNextID = CType(myRecordDataSet.Tables(0).Rows(myRecordDataSet.Tables(0).Rows.Count - 1).Item("EntityID"), String)
							End If
							Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & myNextID)
						End If
					End If
				Else
					'exception:resolution record is empty or duplicated
				End If
			Else
				'exception:record id is empty
			End If
		End Sub

		Private Sub ButtonRecordInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecordInsert.Click
			Dim myRecordID As String = ""
			myRecordID = SaveRecordData("")
			If myRecordID.Trim.Length > 0 Then
				Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & myRecordID)
			Else
				'exception:insert failure
				PageLoad()
			End If
		End Sub

		Private Sub ButtonRecordUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecordUpdate.Click
			If recordID.Trim.Length > 0 Then
				SaveRecordData(recordID)
				Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & recordID)
			Else
				'exception:form id is empty
			End If
		End Sub

		''Private Sub DeleteResolution(ByVal myRecordID As String)
		''	Dim myResolutionDAO As New MeetingRecordResolutionDAOExtand
		''	Dim myResolutionDataSet As DataSet
		''	Dim myResolutionCount As Integer = 0
		''	Dim myResolutionID As String = ""
		''	Dim myRecordDAO As New MeetingRecordDAOExtand
		''	Dim myRecordDataSet As DataSet
		''	Dim myFormDataSet As DataSet
		''	Dim myFormID As String = ""
		''	Dim myFormClass As New AffairProcessCheckForm
		''	Dim myTypeID As String = ""
		''	Dim myMeetingNumber As Integer = 1
		''	Dim myNumber As String = ""
		''	Dim i As Integer = 0
		''	Dim myAuthorityBO As New ContextAuthBO

		''	If myRecordID.Trim.Length > 0 Then
		''		myRecordDataSet = myRecordDAO.GetEntitysByEntityID(myRecordID)
		''		If myRecordDataSet.Tables(0).Rows.Count = 1 Then
		''			'read meeting number and type
		''			myMeetingNumber = CType(myRecordDataSet.Tables(0).Rows(0).Item("MeetingNumber"), Integer)
		''			myTypeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("TypeID"), String)

		''			myResolutionCount = myResolutionDAO.GetTotalRowByMeetingRecordID(myRecordID)
		''			If myResolutionCount > 0 Then
		''				myResolutionDataSet = myResolutionDAO.GetEntitysByMeetingRecordID(myRecordID)
		''				For i = 0 To myResolutionCount - 1
		''					myResolutionID = CType(myResolutionDataSet.Tables(0).Rows(i).Item("EntityID"), String)
		''					myNumber = CType(myResolutionDataSet.Tables(0).Rows(i).Item("ResolutionNumber"), String)
		''					'get affairprocesscheckform pk
		''					myFormDataSet = GetAffairProcessCheckFormDataSet(myTypeID, myMeetingNumber, myNumber)
		''					If Not (myFormDataSet Is Nothing) Then
		''						myFormID = CType(myFormDataSet.Tables(0).Rows(0).Item("EntityID"), String)
		''						'get authority
		''						If myAuthorityBO.CheckPurview(FormAuthorityTarget, myFormID, Context.User.Identity.Name, "D") Then
		''							'delete affairprocesscheckform
		''							myFormClass.DeleteFormData(myFormID)
		''						End If
		''					Else
		''						'exception:form record is empty or duplicated
		''					End If
		''					'get authority
		''					If myAuthorityBO.CheckPurview(ResolutionAuthorityTarget, myResolutionID, Context.User.Identity.Name, "D") Then
		''						'delete resolution
		''						myResolutionDAO.DeleteEntity(myResolutionID)
		''					End If
		''				Next
		''			End If
		''		Else
		''			'exception:meeting record is empty or duplicated
		''		End If
		''	Else
		''		'exception:record id is empty
		''	End If
		''End Sub
		Private Sub DeleteRecordData(ByVal myRecordID As String)
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myAuthorityBO As New ContextAuthBO

			If myRecordID.Trim.Length > 0 Then
				myRecordDataSet = myRecordDAO.GetEntitysByEntityID(myRecordID)
				If myRecordDataSet.Tables(0).Rows.Count = 1 Then
					'''delete resolution
					''DeleteResolution(myRecordID)
					'get authority
					If myAuthorityBO.CheckPurview(RecordAuthorityTarget, myRecordID, Context.User.Identity.Name, "D") Then
						myRecordDAO.DeleteEntity(myRecordID)
					End If
				Else
					'exception:meeting record is empty or duplicated
				End If
			Else
				'exception:record id is empty
			End If
		End Sub

		Private Sub ButtonRecordDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecordDelete.Click
			If recordID.Trim.Length > 0 Then
				DeleteRecordData(recordID)

				recordID = ""
				Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID)
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub DropDownListType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownListType.SelectedIndexChanged
			Dim myTypeID As String = ""
			myTypeID = DropDownListType.SelectedValue
			Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & myTypeID)
		End Sub

		''Private Sub ButtonResolutionAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		''	Dim myResolutionDAO As New MeetingRecordResolutionDAOExtand
		''	Dim myResolutionDataSet As DataSet
		''	Dim myRecordDAO As New MeetingRecordDAOExtand
		''	Dim myRecordDataSet As DataSet
		''	Dim myFormDataSet As DataSet
		''	Dim myFormDAO As New AffairProcessCheckFormDAOExtand
		''	Dim myFormClass As New AffairProcessCheckForm
		''	Dim myNumber As String = ""
		''	Dim myOldNumber As String = ""
		''	Dim myContent As String = ""
		''	Dim myMainOfficeID As String = ""
		''	Dim myAssistOfficeID As String = ""
		''	Dim mySketchID As String = ""
		''	Dim myResolutionID As String = ""
		''	Dim myAffairID As String = ""
		''	Dim myMeetingNumber As Integer = 1
		''	Dim myMeetingDate As Date
		''	Dim myTypeID As String = ""
		''	Dim myFormID As String = ""
		''	Dim myAuthorityBO As New ContextAuthBO

		''	If recordID.Trim.Length > 0 Then
		''		myRecordDataSet = myRecordDAO.GetEntitysByEntityID(recordID)
		''		If myRecordDataSet.Tables(0).Rows.Count = 1 Then
		''			myTypeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("TypeID"), String)
		''			myMeetingNumber = CType(myRecordDataSet.Tables(0).Rows(0).Item("MeetingNumber"), Integer)
		''			myMeetingDate = CType(myRecordDataSet.Tables(0).Rows(0).Item("MeetingDate"), Date)

		''			'read data from input form
		''			myNumber = TextBoxResolutionNumber.Text.Trim
		''			myContent = TextBoxContent.Text.Trim
		''			myMainOfficeID = DropDownListMainOffice.SelectedValue
		''			myAffairID = DropDownListAffair.SelectedValue
		''			myAssistOfficeID = DropDownListAssistOffice.SelectedValue
		''			mySketchID = DropDownListSketch.SelectedValue

		''			If resolutionID.Trim.Length > 0 Then
		''				If action.Trim.Length > 0 Then
		''					If action.Trim = "update" Then
		''						'read origin resolution number
		''						myResolutionDataSet = myResolutionDAO.GetEntitysByEntityID(resolutionID)
		''						If myResolutionDataSet.Tables(0).Rows.Count = 1 Then
		''							myOldNumber = CType(myResolutionDataSet.Tables(0).Rows(0).Item("ResolutionNumber"), String)
		''							'read pk from affairprocesscheckform
		''							myFormDataSet = GetAffairProcessCheckFormDataSet(myTypeID, myMeetingNumber, myOldNumber)
		''							If Not (myFormDataSet Is Nothing) Then
		''								myFormID = CType(myFormDataSet.Tables(0).Rows(0).Item("EntityID"), String)
		''								'get authority
		''								If myAuthorityBO.CheckPurview(FormAuthorityTarget, myFormID, Context.User.Identity.Name, "U") Then
		''									'update affairprocesscheckform
		''									'myFormDAO.UpdateEntityByTypeID(myTypeID, myFormID, myAffairID, myMainOfficeID, myAssistOfficeID, myNumber, myMeetingNumber, myMeetingDate, Context.User.Identity.Name, Now)
		''								Else
		''									'exception:no permission
		''									PageLoad()
		''								End If
		''								'get authority
		''								If myAuthorityBO.CheckPurview(ResolutionAuthorityTarget, resolutionID, Context.User.Identity.Name, "U") Then
		''									'update resolution
		''									myResolutionDAO.UpdateEntity(resolutionID, recordID, myNumber, myContent, myMainOfficeID, myAssistOfficeID, mySketchID, Context.User.Identity.Name, Now)
		''									Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & recordID)
		''								Else
		''									'exception:no permission
		''									PageLoad()
		''								End If
		''							Else
		''								'exception:form record is empty
		''							End If
		''						Else
		''							'exception:resolution record is empty or duplicated
		''						End If
		''					Else
		''						If action.Trim = "delete" Then
		''							'read origin resolution number
		''							myResolutionDataSet = myResolutionDAO.GetEntitysByEntityID(resolutionID)
		''							If myResolutionDataSet.Tables(0).Rows.Count = 1 Then
		''								myOldNumber = CType(myResolutionDataSet.Tables(0).Rows(0).Item("ResolutionNumber"), String)
		''								'read pk from affairprocesscheckform
		''								myFormDataSet = GetAffairProcessCheckFormDataSet(myTypeID, myMeetingNumber, myOldNumber)
		''								If Not (myFormDataSet Is Nothing) Then
		''									myFormID = CType(myFormDataSet.Tables(0).Rows(0).Item("EntityID"), String)
		''									'get authority
		''									If myAuthorityBO.CheckPurview(FormAuthorityTarget, myFormID, Context.User.Identity.Name, "D") Then
		''										'delete affairprocesscheckform
		''										myFormClass.DeleteFormData(myFormID)
		''									Else
		''										'exception:no permission
		''										PageLoad()
		''									End If
		''									'get authority
		''									If myAuthorityBO.CheckPurview(ResolutionAuthorityTarget, resolutionID, Context.User.Identity.Name, "D") Then
		''										'delete resolution
		''										myResolutionDAO.DeleteEntity(resolutionID)
		''										Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & recordID)
		''									Else
		''										'exception:no permission
		''										PageLoad()
		''									End If
		''								Else
		''									'exception:form record is empty
		''								End If
		''							Else
		''								'exception:resolution record is empty or duplicated
		''							End If
		''						Else
		''							'exception:unknown action
		''						End If
		''					End If
		''				Else
		''					'exception:no action
		''				End If
		''			Else
		''				'get new resolution number
		''				myNumber = GetResolutionNumber()
		''				If myNumber.Trim.Length > 0 Then
		''					'insert affairprocesscheckform
		''					'myFormDAO.InsertEntityByTypeID(myTypeID, myAffairID, myMainOfficeID, myAssistOfficeID, myNumber, myMeetingNumber, myMeetingDate, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, DefaultPermissionGroup, DefaultPermission, 1, New Date(1900, 1, 1))
		''					'insert resolution
		''					myResolutionID = myResolutionDAO.InsertEntity(recordID, 0, DefaultPermission, DefaultPermissionGroup, myNumber, myContent, myMainOfficeID, myAssistOfficeID, mySketchID, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
		''					Response.Redirect("~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & typeID & "&recordID=" & recordID)
		''				Else
		''					'exception:resolution number is empty
		''				End If
		''			End If
		''		Else
		''			'exception:meeting record is empty or duplicated
		''		End If
		''	Else
		''		'exception record id is empty
		''	End If
		''End Sub

		''Private Function GetResolutionNumber() As String
		''	Dim myResolutionNumber As String = ""
		''	Dim myMeetingType As String = ""
		''	Dim myMeetingNumber As Integer = 0
		''	Dim myMeetingNumberString As String = ""
		''	Dim result As String = ""
		''	Dim today As Date = Now
		''	Dim myResolutionNumberDAO As New MeetingRecordResolutionDAOExtand

		''	myResolutionNumber = TextBoxResolutionNumber.Text.Trim
		''	If myResolutionNumber = "自動產生" Then
		''		Try
		''			myMeetingType = DropDownListType.SelectedValue.Substring(22, 2)
		''			myMeetingNumber = CType(TextBoxMeetingNumber.Text.Trim, Integer)
		''			myMeetingNumberString = Microsoft.VisualBasic.Right("0000" & CStr(myMeetingNumber), 4)
		''		Catch ex As Exception
		''			'cast failure
		''			Return result
		''		End Try
		''		myResolutionNumber = Microsoft.VisualBasic.Right("0000" & CStr(today.Year), 4) & Microsoft.VisualBasic.Right("00" & CStr(today.Month), 2) & Microsoft.VisualBasic.Right("00" & CStr(today.Day), 2)
		''		myResolutionNumber = myResolutionNumber & myMeetingType & myMeetingNumberString & "00"
		''		result = myResolutionNumberDAO.GetMaxResolutionNumber(myResolutionNumber)
		''	Else
		''		'return user input
		''		Return myResolutionNumber
		''	End If
		''	Return result
		''End Function
		''Protected Sub DropDownListMainOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		''	Dim myNormalCodeDAO As New NormalCodeDAOExtand
		''	Dim myNormalCodeDataSet As DataSet
		''	Dim myNormalCodeCount As Integer = 0
		''	Dim i As Integer = 0
		''	Dim myListItem As ListItem
		''	Dim myCodeName As String = ""
		''	Dim myCodeID As String = ""

		''	MainOfficeID = DropDownListMainOffice.SelectedValue

		''	If MainOfficeID = "200601010000000300000001" Then
		''		AffairCodeGroupID = "2006010100000011"
		''	Else
		''		If MainOfficeID = "200601010000000300000002" Then
		''			AffairCodeGroupID = "2006010100000012"
		''		Else
		''			If MainOfficeID = "200601010000000300000003" Then
		''				AffairCodeGroupID = "2006010100000013"
		''			Else
		''				If MainOfficeID = "200601010000000300000004" Then
		''					AffairCodeGroupID = "2006010100000014"
		''				Else
		''					If MainOfficeID = "200601010000000300000005" Then
		''						AffairCodeGroupID = "2006010100000015"
		''					Else
		''						If MainOfficeID = "200601010000000300000006" Then
		''							AffairCodeGroupID = "2006010100000016"
		''						Else
		''							If MainOfficeID = "200601010000000300000007" Then
		''								AffairCodeGroupID = "2006010100000017"
		''							Else
		''								If MainOfficeID = "200601010000000300000008" Then
		''									AffairCodeGroupID = "2006010100000018"
		''								Else
		''									'exception:unknown group
		''								End If
		''							End If
		''						End If
		''					End If
		''				End If
		''			End If
		''		End If
		''	End If

		''	'PageLoad()

		''	DropDownListMainOffice.SelectedValue = MainOfficeID

		''	DropDownListAffair.Items.Clear()
		''	myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(AffairCodeGroupID)
		''	myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
		''	myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
		''	If myNormalCodeCount > 0 Then
		''		For i = 0 To myNormalCodeCount - 1
		''			myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
		''			myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

		''			myListItem = New ListItem
		''			myListItem.Value = myCodeID
		''			myListItem.Text = myCodeName

		''			DropDownListAffair.Items.Add(myListItem)
		''		Next
		''	End If
		''End Sub

		Protected Sub DropDownListPlace_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownListPlace.SelectedIndexChanged
			Dim myPlaceID As String = ""
			myPlaceID = DropDownListPlace.SelectedValue

			'PageLoad()

			DropDownListPlace.SelectedValue = myPlaceID

			If myPlaceID = "200601010000000A00000010" Then
				TextBoxPlaceName.Visible = True
			Else
				TextBoxPlaceName.Visible = False
			End If
		End Sub
	End Class
End Namespace