Imports System
Imports System.IO
Imports System.Math
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module
	Public Class DatabaseQueryFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents LinkButtonEntitysListTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonEntitysListPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderEntitysListPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonEntitysListPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonEntitysListTenPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents PlaceHolderEntitysList As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents DropDownListQueryColumn As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxQueryString As System.Web.UI.WebControls.TextBox

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
		Private Const ProcessAuthorityTarget As String = "AffairProcessMap"
		Private Const CodeAuthorityTarget As String = "NormalCode"
		Private UtilityObject As New AuditSystemUtility

		Private tabIndex As Integer = 0
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Protected pageSize As Integer = 4
		Protected totalEntitysListPage As Integer = 0
		Protected currentEntitysListPage As Integer = 0
		Protected queryString As String = ""
		Protected queryColumn As String = "ResolutionContent"
		Private Const MeetingTypeNameHeaderColumnWidth As String = "96"
		Private Const MeetingTypeNameColumnWidth As String = "120"
		Private Const MeetingNumberHeaderColumnWidth As String = "32"
		Private Const MeetingNumberColumnWidth As String = "48"
		Private Const MeetingDateHeaderColumnWidth As String = "64"
		Private Const MeetingDateColumnWidth As String = "96"
		Private Const MeetingTitleHeaderColumnWidth As String = "64"
		Private Const MeetingTitleColumnWidth As String = "200"
		Private Const ResolutionNumberHeaderColumnWidth As String = "64"
		Private Const ResolutionNumberColumnWidth As String = "96"
		Private ResolutionContentColumnWidth As String = CStr(CInt(MeetingTypeNameHeaderColumnWidth) + CInt(MeetingTypeNameColumnWidth) + CInt(MeetingNumberHeaderColumnWidth) + CInt(MeetingNumberColumnWidth) + CInt(MeetingDateHeaderColumnWidth) + CInt(MeetingDateColumnWidth) + CInt(MeetingTitleHeaderColumnWidth) + CInt(MeetingTitleColumnWidth) + CInt(ResolutionNumberHeaderColumnWidth) + CInt(ResolutionNumberColumnWidth))
		Private MainOfficeNameHeaderColumnWidth As String = CStr(CInt(MeetingTypeNameHeaderColumnWidth) + CInt(MeetingTypeNameColumnWidth))
		Private MainOfficeNameColumnWidth As String = CStr(CInt(MeetingNumberHeaderColumnWidth) + CInt(MeetingNumberColumnWidth) + CInt(MeetingDateHeaderColumnWidth) + CInt(MeetingDateColumnWidth))
		Private ProcessDateHeaderColumnWidth As String = CStr(CInt(MeetingTitleHeaderColumnWidth) + CInt(MeetingTitleColumnWidth))
		Private ProcessDateColumnWidth As String = CStr(CInt(ResolutionNumberHeaderColumnWidth) + CInt(ResolutionNumberColumnWidth))
		Private Const LinkColumnWidth As String = "32"


		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			Dim rowCount As Integer = 0
			Dim i As Integer = 0
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myFormDAO As New AffairProcessCheckFormDAOExtand
			Dim myFormDataSet As DataSet

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

			If Not (Request.Params("QueryString") Is Nothing) Then
				queryString = Request.Params("QueryString")
			End If

			If Not (Request.Params("QueryColumn") Is Nothing) Then
				queryColumn = Request.Params("QueryColumn")
			End If

			If Not IsPostBack Then
				'manage page
				If queryColumn = "ResolutionContent" Then
					myRecordDataSet = myRecordDAO.GetEntitysByQueryString(queryString)
					myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
					rowCount = myRecordDataSet.Tables(0).Rows.Count
				Else
					If queryColumn = "ProcessState" Then
						myFormDataSet = myFormDAO.GetEntitysByQueryStringInAssociation(queryString)
						myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
						rowCount = rowCount + myFormDataSet.Tables(0).Rows.Count
						myFormDataSet = myFormDAO.GetEntitysByQueryStringInCouncil(queryString)
						myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
						rowCount = rowCount + myFormDataSet.Tables(0).Rows.Count
						myFormDataSet = myFormDAO.GetEntitysByQueryStringInBureau(queryString)
						myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
						rowCount = rowCount + myFormDataSet.Tables(0).Rows.Count
						myFormDataSet = myFormDAO.GetEntitysByQueryStringInSection(queryString)
						myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
						rowCount = rowCount + myFormDataSet.Tables(0).Rows.Count
					Else
						'exception:unknown query column
					End If
				End If
				If rowCount Mod pageSize = 0 Then
					totalEntitysListPage = CType(rowCount \ pageSize, Integer)
				Else
					totalEntitysListPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("CurrentEntitysListPage") Is Nothing) Then
					currentEntitysListPage = CType(Request.Params("CurrentEntitysListPage"), Integer)
					ViewState("EntitysListCurrentEntitysListPage") = currentEntitysListPage
				Else
					currentEntitysListPage = 1
				End If

				ViewState("EntitysListTotalEntitysListPage") = totalEntitysListPage
				ViewState("EntitysListCurrentEntitysListPage") = currentEntitysListPage

				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			Else
				totalEntitysListPage = CType(ViewState("EntitysListTotalEntitysListPage"), Integer)
				currentEntitysListPage = CType(ViewState("EntitysListCurrentEntitysListPage"), Integer)
			End If
		End Sub
		Private Sub PageLoad()
			Dim myHyperLink As HyperLink
			Dim myLabel As Label
			Dim myIndexHtmlTable As HtmlTable
			Dim myIndexHtmlTableRow As HtmlTableRow
			Dim myIndexHtmlTableCell As HtmlTableCell
			Dim myQueryHtmlTable As HtmlTable
			Dim myQueryHtmlTableRow As HtmlTableRow
			Dim myQueryHtmlTableCell As HtmlTableCell
			Dim myDetailHtmlTable As HtmlTable
			Dim myDetailHtmlTableRow As HtmlTableRow
			Dim myDetailHtmlTableCell As HtmlTableCell
			Dim myDataColumn As DataColumn
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalEntitysListPage
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myFormDAO As New AffairProcessCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myFormCount As Integer = 0
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myEntitysDate As Date = New Date(1900, 1, 1)
			Dim myEmptyDate As Date = New Date(1900, 1, 1)
			Dim myMeetingTypeName As String = ""
			Dim myMeetingTypeID As String = ""
			Dim myMeetingNumber As Integer = 1
			Dim myMeetingDate As Date = New Date(1900, 1, 1)
			Dim myTitle As String = ""
			Dim myResolutionNumber As String = ""
			Dim myResolutionContent As String = ""
			Dim myMainOfficeName As String = ""
			Dim myEntityID As String = ""
			Dim myGroupID As String = ""
			Dim myProcessDate As Date = New Date(1900, 1, 1)
			Dim myProcessState As String = ""

			If queryColumn = "ResolutionContent" Then
				myRecordDataSet = myRecordDAO.GetEntitysByQueryString(queryString)
				myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name, pageSize * currentEntitysListPage)
			Else
				If queryColumn = "ProcessState" Then
					myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDAO.GetEntitysByQueryStringInAssociation(queryString), FormAuthorityTarget, Context.User.Identity.Name)
					myFormDataSet.Merge(UtilityObject.QueryPermissionFilter(myFormDAO.GetEntitysByQueryStringInCouncil(queryString), FormAuthorityTarget, Context.User.Identity.Name))
					myFormDataSet.Merge(UtilityObject.QueryPermissionFilter(myFormDAO.GetEntitysByQueryStringInBureau(queryString), FormAuthorityTarget, Context.User.Identity.Name))
					myFormDataSet.Merge(UtilityObject.QueryPermissionFilter(myFormDAO.GetEntitysByQueryStringInSection(queryString), FormAuthorityTarget, Context.User.Identity.Name))

					myFormDataSet = SubDataSet(myFormDataSet, 0, pageSize * currentEntitysListPage)
				Else
					'exception:unknown query column
				End If
			End If
			'myDataColumn = New DataColumn("CategorizationName")
			'myEntitysDataSet.Tables(0).Columns.Add(myDataColumn)
			'myDataColumn = New DataColumn("EntitysDateString")
			'myEntitysDataSet.Tables(0).Columns.Add(myDataColumn)

			LinkButtonEntitysListPageDown.Visible = False
			LinkButtonEntitysListTenPageDown.Visible = False
			LinkButtonEntitysListPageUp.Visible = False
			LinkButtonEntitysListTenPageUp.Visible = False

			PlaceHolderEntitysListPageIndex.Controls.Clear()
			PlaceHolderEntitysList.Controls.Clear()

			myIndexHtmlTable = New HtmlTable
			myQueryHtmlTable = New HtmlTable
			myQueryHtmlTable.Width = "100%"
			myQueryHtmlTable.CellPadding = 1
			myQueryHtmlTable.CellSpacing = 1
			myQueryHtmlTable.Border = 0

			If queryColumn = "ResolutionContent" Then
				If myRecordDataSet.Tables(0).Rows.Count > 0 Then

					'page
					'If currentEntitysListPage > 1 Then
					'	For i = 0 To currentEntitysListPage - 2
					'		For j = 0 To pageSize - 1
					'			myRecordDataSet.Tables(0).Rows(i * pageSize + j).Delete()
					'		Next
					'	Next
					'End If

					If currentEntitysListPage < totalEntitysListPage Then
						LinkButtonEntitysListPageDown.Visible = True
					Else
						LinkButtonEntitysListPageDown.Visible = False
					End If
					If currentEntitysListPage < totalEntitysListPage - 9 Then
						LinkButtonEntitysListTenPageDown.Visible = True
					Else
						LinkButtonEntitysListTenPageDown.Visible = False
					End If
					If currentEntitysListPage > 1 Then
						LinkButtonEntitysListPageUp.Visible = True
					Else
						LinkButtonEntitysListPageUp.Visible = False
					End If
					If currentEntitysListPage > 10 Then
						LinkButtonEntitysListTenPageUp.Visible = True
					Else
						LinkButtonEntitysListTenPageUp.Visible = False
					End If
					'prepare page index
					lowBound = currentEntitysListPage - 4
					highBound = currentEntitysListPage + 5
					If lowBound < 1 Then
						lowBound = 1
						highBound = Min(10, totalEntitysListPage)
					Else
						If highBound > totalEntitysListPage Then
							highBound = totalEntitysListPage
							lowBound = Max(totalEntitysListPage - 9, 1)
						End If
					End If

					myIndexHtmlTableRow = New HtmlTableRow
					For i = lowBound To highBound
						myIndexHtmlTableCell = New HtmlTableCell
						myIndexHtmlTableCell.Width = "10%"
						If i = currentEntitysListPage Then
							myLabel = New Label
							myLabel.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
							myLabel.Text = CType(i, String)
							myIndexHtmlTableCell.Controls.Add(myLabel)
						Else
							myHyperLink = New HyperLink
							myHyperLink.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
							myHyperLink.Text = "[" & CType(i, String) & "]"
							myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/DatabaseQueryFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&QueryColumn=" & queryColumn & "&QueryString=" & queryString & "&CurrentEntitysListPage=" & CType(i, String)
							myIndexHtmlTableCell.Controls.Add(myHyperLink)
						End If
						myIndexHtmlTableRow.Controls.Add(myIndexHtmlTableCell)
					Next
					myIndexHtmlTable.Controls.Add(myIndexHtmlTableRow)

					If myRecordDataSet.Tables(0).Rows.Count > 0 Then
						For i = (currentEntitysListPage - 1) * pageSize To myRecordDataSet.Tables(0).Rows.Count - 1
							myQueryHtmlTableRow = New HtmlTableRow

							myQueryHtmlTableCell = New HtmlTableCell

							myDetailHtmlTable = New HtmlTable
							myDetailHtmlTable.Align = "left"
							myDetailHtmlTable.CellPadding = 0
							myDetailHtmlTable.CellSpacing = 0
							myDetailHtmlTable.Border = 1

							myDetailHtmlTableRow = New HtmlTableRow
							'meeting type name header
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promoHeader"
							myDetailHtmlTableCell.Width = MeetingTypeNameHeaderColumnWidth
							myDetailHtmlTableCell.InnerHtml = "會議記錄類別"
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'meeting type name
							myMeetingTypeName = CType(myRecordDataSet.Tables(0).Rows(i).Item("MeetingTypeName"), String)
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promo"
							myDetailHtmlTableCell.Width = MeetingTypeNameColumnWidth
							myDetailHtmlTableCell.InnerHtml = myMeetingTypeName
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'meeting number header
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promoHeader"
							myDetailHtmlTableCell.Width = MeetingNumberHeaderColumnWidth
							myDetailHtmlTableCell.InnerHtml = "會次"
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'meeting number
							myMeetingNumber = CType(myRecordDataSet.Tables(0).Rows(i).Item("MeetingNumber"), Integer)
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promo"
							myDetailHtmlTableCell.Width = MeetingNumberColumnWidth
							myDetailHtmlTableCell.InnerHtml = CType(myMeetingNumber, String)
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'meeting date header
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promoHeader"
							myDetailHtmlTableCell.Width = MeetingDateHeaderColumnWidth
							myDetailHtmlTableCell.InnerHtml = "會議時間"
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'meeting date
							myMeetingDate = CType(myRecordDataSet.Tables(0).Rows(i).Item("MeetingDate"), Date)
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promo"
							myDetailHtmlTableCell.Width = MeetingDateColumnWidth
							myDetailHtmlTableCell.InnerHtml = myMeetingDate.Year & "/" & myMeetingDate.Month & "/" & myMeetingDate.Day
							If myDetailHtmlTableCell.InnerHtml = "1900/1/1" Then
								myDetailHtmlTableCell.InnerHtml = ""
							End If
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'title header
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promoHeader"
							myDetailHtmlTableCell.Width = MeetingTitleHeaderColumnWidth
							myDetailHtmlTableCell.InnerHtml = "會議主題"
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)
							'title
							myTitle = CType(myRecordDataSet.Tables(0).Rows(i).Item("Title"), String)
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promo"
							myDetailHtmlTableCell.Width = MeetingTitleColumnWidth
							myDetailHtmlTableCell.InnerHtml = myTitle
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'resolution number header
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promoHeader"
							myDetailHtmlTableCell.Width = ResolutionNumberHeaderColumnWidth
							myDetailHtmlTableCell.InnerHtml = "決議編號"
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'resolution number
							myResolutionNumber = CType(myRecordDataSet.Tables(0).Rows(i).Item("ResolutionNumber"), String)
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promo"
							myDetailHtmlTableCell.Width = ResolutionNumberColumnWidth
							myDetailHtmlTableCell.InnerHtml = myResolutionNumber
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							'link
							myEntityID = CType(myRecordDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							myMeetingTypeID = CType(myRecordDataSet.Tables(0).Rows(i).Item("MeetingTypeID"), String)
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Align = "center"
							myDetailHtmlTableCell.RowSpan = 3
							myDetailHtmlTableCell.Width = LinkColumnWidth
							myHyperLink = New HyperLink
							myHyperLink.Text = "會議記錄連結"
							myHyperLink.ImageUrl = "~/images/link.gif"
							myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/MeetingRecordAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&typeID=" & myMeetingTypeID & "&recordID=" & myEntityID
							myDetailHtmlTableCell.Controls.Add(myHyperLink)
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

							myDetailHtmlTableRow = New HtmlTableRow
							'resolution content header
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promoHeader"
							myDetailHtmlTableCell.ColSpan = 10
							myDetailHtmlTableCell.InnerHtml = "決議內容"
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

							myDetailHtmlTableRow = New HtmlTableRow
							'resolution content
							myDetailHtmlTableCell = New HtmlTableCell
							myDetailHtmlTableCell.Attributes("class") = "promo"
							myDetailHtmlTableCell.ColSpan = 10
							myDetailHtmlTableCell.Width = ResolutionContentColumnWidth
							myResolutionContent = CType(myRecordDataSet.Tables(0).Rows(i).Item("ResolutionContent"), String)
							myDetailHtmlTableCell.InnerHtml = myResolutionContent
							myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
							myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

							myQueryHtmlTableCell.Controls.Add(myDetailHtmlTable)

							myQueryHtmlTableRow.Cells.Add(myQueryHtmlTableCell)

							myQueryHtmlTable.Controls.Add(myQueryHtmlTableRow)
						Next
					End If

				Else
					'exception
				End If
			Else
				If queryColumn = "ProcessState" Then
					If myFormDataSet.Tables(0).Rows.Count > 0 Then

						'page
						'If currentEntitysListPage > 1 Then
						'	For i = 0 To currentEntitysListPage - 2
						'		For j = 0 To pageSize - 1
						'			myFormDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						'		Next
						'	Next
						'End If

						If currentEntitysListPage < totalEntitysListPage Then
							LinkButtonEntitysListPageDown.Visible = True
						Else
							LinkButtonEntitysListPageDown.Visible = False
						End If
						If currentEntitysListPage < totalEntitysListPage - 9 Then
							LinkButtonEntitysListTenPageDown.Visible = True
						Else
							LinkButtonEntitysListTenPageDown.Visible = False
						End If
						If currentEntitysListPage > 1 Then
							LinkButtonEntitysListPageUp.Visible = True
						Else
							LinkButtonEntitysListPageUp.Visible = False
						End If
						If currentEntitysListPage > 10 Then
							LinkButtonEntitysListTenPageUp.Visible = True
						Else
							LinkButtonEntitysListTenPageUp.Visible = False
						End If
						'prepare page index
						lowBound = currentEntitysListPage - 4
						highBound = currentEntitysListPage + 5
						If lowBound < 1 Then
							lowBound = 1
							highBound = Min(10, totalEntitysListPage)
						Else
							If highBound > totalEntitysListPage Then
								highBound = totalEntitysListPage
								lowBound = Max(totalEntitysListPage - 9, 1)
							End If
						End If

						myIndexHtmlTableRow = New HtmlTableRow
						For i = lowBound To highBound
							myIndexHtmlTableCell = New HtmlTableCell
							myIndexHtmlTableCell.Width = "10%"
							If i = currentEntitysListPage Then
								myLabel = New Label
								myLabel.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
								myLabel.Text = CType(i, String)
								myIndexHtmlTableCell.Controls.Add(myLabel)
							Else
								myHyperLink = New HyperLink
								myHyperLink.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
								myHyperLink.Text = "[" & CType(i, String) & "]"
								myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/DatabaseQueryFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&QueryColumn=" & queryColumn & "&QueryString=" & queryString & "&CurrentEntitysListPage=" & CType(i, String)
								myIndexHtmlTableCell.Controls.Add(myHyperLink)
							End If
							myIndexHtmlTableRow.Controls.Add(myIndexHtmlTableCell)
						Next
						myIndexHtmlTable.Controls.Add(myIndexHtmlTableRow)

						If myFormDataSet.Tables(0).Rows.Count > 0 Then
							For i = (currentEntitysListPage - 1) * pageSize To myFormDataSet.Tables(0).Rows.Count - 1
								myQueryHtmlTableRow = New HtmlTableRow

								myQueryHtmlTableCell = New HtmlTableCell

								myDetailHtmlTable = New HtmlTable
								myDetailHtmlTable.Align = "left"
								myDetailHtmlTable.CellPadding = 0
								myDetailHtmlTable.CellSpacing = 0
								myDetailHtmlTable.Border = 1

								myDetailHtmlTableRow = New HtmlTableRow
								'meeting type name header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.Width = MeetingTypeNameHeaderColumnWidth
								myDetailHtmlTableCell.InnerHtml = "會議記錄類別"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'meeting type name
								myMeetingTypeName = CType(myFormDataSet.Tables(0).Rows(i).Item("MeetingTypeName"), String)
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.Width = MeetingTypeNameColumnWidth
								myDetailHtmlTableCell.InnerHtml = myMeetingTypeName
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'meeting number header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.Width = MeetingNumberHeaderColumnWidth
								myDetailHtmlTableCell.InnerHtml = "會次"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'meeting number
								myMeetingNumber = CType(myFormDataSet.Tables(0).Rows(i).Item("MeetingNumber"), Integer)
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.Width = MeetingNumberColumnWidth
								myDetailHtmlTableCell.InnerHtml = CType(myMeetingNumber, String)
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'meeting date header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.Width = MeetingDateHeaderColumnWidth
								myDetailHtmlTableCell.InnerHtml = "會議時間"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'meeting date
								myMeetingDate = CType(myFormDataSet.Tables(0).Rows(i).Item("MeetingDate"), Date)
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.Width = MeetingDateColumnWidth
								myDetailHtmlTableCell.InnerHtml = myMeetingDate.Year & "/" & myMeetingDate.Month & "/" & myMeetingDate.Day
								If myDetailHtmlTableCell.InnerHtml = "1900/1/1" Then
									myDetailHtmlTableCell.InnerHtml = ""
								End If
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'title header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.Width = MeetingTitleHeaderColumnWidth
								myDetailHtmlTableCell.InnerHtml = "會議主題"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)
								'title
								myTitle = CType(myFormDataSet.Tables(0).Rows(i).Item("Title"), String)
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.Width = MeetingTitleColumnWidth
								myDetailHtmlTableCell.InnerHtml = myTitle
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'resolution number header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.Width = ResolutionNumberHeaderColumnWidth
								myDetailHtmlTableCell.InnerHtml = "決議編號"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'resolution number
								myResolutionNumber = CType(myFormDataSet.Tables(0).Rows(i).Item("ResolutionNumber"), String)
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.Width = ResolutionNumberColumnWidth
								myDetailHtmlTableCell.InnerHtml = myResolutionNumber
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'link
								myEntityID = CType(myFormDataSet.Tables(0).Rows(i).Item("EntityID"), String)
								myGroupID = CType(myFormDataSet.Tables(0).Rows(i).Item("GroupID"), String)
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Align = "center"
								myDetailHtmlTableCell.RowSpan = 6
								myDetailHtmlTableCell.Width = LinkColumnWidth
								myHyperLink = New HyperLink
								myHyperLink.Text = "辦理情形連結"
								myHyperLink.ImageUrl = "~/images/link.gif"
								myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/AffairProcessCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&groupID=" & myGroupID & "&formID=" & myEntityID
								myDetailHtmlTableCell.Controls.Add(myHyperLink)
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

								myDetailHtmlTableRow = New HtmlTableRow
								'resolution content header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.ColSpan = 10
								myDetailHtmlTableCell.InnerHtml = "決議內容"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

								myDetailHtmlTableRow = New HtmlTableRow
								'resolution content
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.ColSpan = 10
								myDetailHtmlTableCell.Width = ResolutionContentColumnWidth
								myResolutionContent = CType(myFormDataSet.Tables(0).Rows(i).Item("ResolutionContent"), String)
								myDetailHtmlTableCell.InnerHtml = myResolutionContent
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

								myDetailHtmlTableRow = New HtmlTableRow
								'main office name header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.Width = MainOfficeNameHeaderColumnWidth
								myDetailHtmlTableCell.ColSpan = 2
								myDetailHtmlTableCell.InnerHtml = "主辦組室"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'main office name
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.ColSpan = 4
								myDetailHtmlTableCell.Width = MainOfficeNameColumnWidth
								myMainOfficeName = CType(myFormDataSet.Tables(0).Rows(i).Item("MainOfficeName"), String)
								myDetailHtmlTableCell.InnerHtml = myMainOfficeName
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'process date header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.Width = ProcessDateHeaderColumnWidth
								myDetailHtmlTableCell.ColSpan = 2
								myDetailHtmlTableCell.InnerHtml = "處理日期"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								'process date
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.ColSpan = 2
								myDetailHtmlTableCell.Width = ProcessDateColumnWidth
								myProcessDate = CType(myFormDataSet.Tables(0).Rows(i).Item("ProcessDate"), Date)
								myDetailHtmlTableCell.InnerHtml = myProcessDate.Year & "/" & myProcessDate.Month & "/" & myProcessDate.Day
								If myDetailHtmlTableCell.InnerHtml = "1900/1/1" Then
									myDetailHtmlTableCell.InnerHtml = ""
								End If
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

								myDetailHtmlTableRow = New HtmlTableRow
								'process state header
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promoHeader"
								myDetailHtmlTableCell.ColSpan = 10
								myDetailHtmlTableCell.InnerHtml = "處理情形"
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

								myDetailHtmlTableRow = New HtmlTableRow
								'process state
								myDetailHtmlTableCell = New HtmlTableCell
								myDetailHtmlTableCell.Attributes("class") = "promo"
								myDetailHtmlTableCell.ColSpan = 10
								myDetailHtmlTableCell.Width = ResolutionContentColumnWidth
								myProcessState = CType(myFormDataSet.Tables(0).Rows(i).Item("ProcessState"), String)
								myDetailHtmlTableCell.InnerHtml = myProcessState
								myDetailHtmlTableRow.Cells.Add(myDetailHtmlTableCell)
								myDetailHtmlTable.Controls.Add(myDetailHtmlTableRow)

								myQueryHtmlTableCell.Controls.Add(myDetailHtmlTable)

								myQueryHtmlTableRow.Cells.Add(myQueryHtmlTableCell)

								myQueryHtmlTable.Controls.Add(myQueryHtmlTableRow)
							Next
						End If

					Else
						'exception
					End If
				Else
					'exception:unknown query column
				End If
			End If

			PlaceHolderEntitysList.Controls.Add(myQueryHtmlTable)
			PlaceHolderEntitysListPageIndex.Controls.Add(myIndexHtmlTable)

			Try
				DropDownListQueryColumn.SelectedValue = queryColumn
			Catch ex As Exception
				'exception:no match
			End Try
			TextBoxQueryString.Text = queryString
		End Sub
		Private Function SubDataSet(ByVal myInputDataSet As DataSet, ByVal begin As Integer, ByVal length As Integer) As DataSet
			Dim myOutputDataSet As DataSet = New DataSet
			Dim myInputCount As Integer = 0
			Dim myObjectArray() As Object
			Dim i As Integer = 0

			If (Not (myInputDataSet Is Nothing)) And begin >= 0 And length > 0 Then
				myOutputDataSet = myInputDataSet.Clone
				myInputCount = myInputDataSet.Tables(0).Rows.Count
				If myInputCount > begin + length - 1 Then
					For i = begin To begin + length - 1
						myObjectArray = myInputDataSet.Tables(0).Rows(i).ItemArray()
						myOutputDataSet.Tables(0).Rows.Add(myObjectArray)
					Next
				Else
					If myInputCount > begin Then
						For i = begin To myInputCount - 1
							myObjectArray = myInputDataSet.Tables(0).Rows(i).ItemArray()
							myOutputDataSet.Tables(0).Rows.Add(myObjectArray)
						Next
					Else
						'exception:index out of bound
					End If
				End If
			Else
				'exception:input dataset is nothing
			End If
			Return myOutputDataSet
		End Function
		Sub PageReload()
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myFormDAO As New AffairProcessCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim rowCount As Integer

			If queryColumn = "ResolutionContent" Then
				myRecordDataSet = myRecordDAO.GetEntitysByQueryString(queryString)
				myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
				rowCount = myRecordDataSet.Tables(0).Rows.Count
			Else
				If queryColumn = "ProcessState" Then
					myFormDataSet = myFormDAO.GetEntitysByQueryStringInAssociation(queryString)
					myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
					rowCount = rowCount + myFormDataSet.Tables(0).Rows.Count
					myFormDataSet = myFormDAO.GetEntitysByQueryStringInCouncil(queryString)
					myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
					rowCount = rowCount + myFormDataSet.Tables(0).Rows.Count
					myFormDataSet = myFormDAO.GetEntitysByQueryStringInBureau(queryString)
					myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
					rowCount = rowCount + myFormDataSet.Tables(0).Rows.Count
					myFormDataSet = myFormDAO.GetEntitysByQueryStringInSection(queryString)
					myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
					rowCount = rowCount + myFormDataSet.Tables(0).Rows.Count
				Else
					'exception:unknown query column
				End If
			End If
			If rowCount Mod pageSize = 0 Then
				totalEntitysListPage = CType(rowCount \ pageSize, Integer)
			Else
				totalEntitysListPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentEntitysListPage = 1

			ViewState("EntitysListTotalEntitysListPage") = totalEntitysListPage
			ViewState("EntitysListCurrentEntitysListPage") = currentEntitysListPage

			PageLoad()
		End Sub

		Private Sub LinkButtonEntitysListPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonEntitysListPageUp.Click
			currentEntitysListPage = currentEntitysListPage - 1
			If currentEntitysListPage < 1 Then
				currentEntitysListPage = 1
			End If
			ViewState("EntitysListCurrentEntitysListPage") = currentEntitysListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonEntitysListPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonEntitysListPageDown.Click
			currentEntitysListPage = currentEntitysListPage + 1
			If currentEntitysListPage > totalEntitysListPage Then
				currentEntitysListPage = totalEntitysListPage
			End If
			ViewState("EntitysListCurrentEntitysListPage") = currentEntitysListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonEntitysListTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonEntitysListTenPageUp.Click
			currentEntitysListPage = currentEntitysListPage - pageSize
			If currentEntitysListPage < 1 Then
				currentEntitysListPage = 1
			End If
			ViewState("EntitysListCurrentEntitysListPage") = currentEntitysListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonEntitysListTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonEntitysListTenPageDown.Click
			currentEntitysListPage = currentEntitysListPage + pageSize
			If currentEntitysListPage > totalEntitysListPage Then
				currentEntitysListPage = totalEntitysListPage
			End If
			ViewState("EntitysListCurrentEntitysListPage") = currentEntitysListPage
			PageLoad()
		End Sub
		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			Dim myQueryString As String = ""
			Dim myQueryColumn As String = ""
			myQueryColumn = DropDownListQueryColumn.SelectedValue
			myQueryString = TextBoxQueryString.Text.Trim
			Response.Redirect("~/DesktopModules/AuditSystem/DatabaseQueryFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&QueryColumn=" & myQueryColumn & "&QueryString=" & myQueryString)
		End Sub
	End Class
End Namespace
