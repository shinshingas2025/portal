Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class BulletinImportExport
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonBulletinIndividualTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonBulletinIndividualPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderBulletinIndividualPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonBulletinIndividualPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonBulletinIndividualTenPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents DataList2 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonBulletinCommunityTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonBulletinCommunityPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderBulletinCommunityPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonBulletinCommunityPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonBulletinCommunityTenPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents ImageButtonExport As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ImageButtonImport As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button

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
		Private bulletinMapID As String = ""
		Protected pageSize As Integer = 10
		Protected totalBulletinIndividualPage As Integer = 0
		Protected currentBulletinIndividualPage As Integer = 0
		Protected totalBulletinCommunityPage As Integer = 0
		Protected currentBulletinCommunityPage As Integer = 0
		Dim AuditDAO As New Portal_AuditDAOExtand
		Dim ModuleStatisticDAO As New Portal_ModuleStatisticDAOExtand
		Dim AuditDetailDAO As New Portal_AuditDetailDAOExtand

		Enum SequenceType
			before = 1
			after = 2
		End Enum

		Enum BulletinType
			community = 1
			individual = 2
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

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁()
			'Session("sid") = "9999"
			'If PortalSecurity.IsInRoles("Admins") = False Then
			'    Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If
			Dim rowCount As Integer
			Dim myBulletinIndividualMapDAO As New ASPNET.StarterKit.Portal.Portal_BulletinMapDAOExtand
			Dim myBulletinCommunityMapDAO As New ASPNET.StarterKit.Portal.Portal_BulletinMapDAOExtand
			Dim i As Integer = 0

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

			If Not (Request.Params("bulletinmapid") Is Nothing) Then
				bulletinMapID = Request.Params("bulletinmapid").Trim
			End If

			If Not IsPostBack Then
				'manage Bulletin individual page 
				rowCount = myBulletinIndividualMapDAO.GetTotalRow(sid, moduleId)
				If rowCount Mod pageSize = 0 Then
					totalBulletinIndividualPage = CType(rowCount \ pageSize, Integer)
				Else
					totalBulletinIndividualPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("currentbulletinindividualpage") Is Nothing) Then
					currentBulletinIndividualPage = CType(Request.Params("currentbulletinindividualpage"), Integer)
					ViewState("BulletinImportExportCurrentBulletinIndividualPage") = currentBulletinIndividualPage
				Else
					currentBulletinIndividualPage = 1
				End If

				ViewState("BulletinImportExportTotalBulletinIndividualPage") = totalBulletinIndividualPage
				ViewState("BulletinImportExportCurrentBulletinIndividualPage") = currentBulletinIndividualPage

				'manage Bulletin community page 
				rowCount = myBulletinCommunityMapDAO.GetTotalCommunityRow(moduleId)
				If rowCount Mod pageSize = 0 Then
					totalBulletinCommunityPage = CType(rowCount \ pageSize, Integer)
				Else
					totalBulletinCommunityPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("currentbulletincommunitypage") Is Nothing) Then
					currentBulletinCommunityPage = CType(Request.Params("currentbulletincommunitypage"), Integer)
					ViewState("BulletinImportExportCurrentBulletinCommunityPage") = currentBulletinCommunityPage
				Else
					currentBulletinCommunityPage = 1
				End If

				ViewState("BulletinImportExportTotalBulletinCommunityPage") = totalBulletinCommunityPage
				ViewState("BulletinImportExportCurrentBulletinCommunityPage") = currentBulletinCommunityPage

				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				IndividualPageLoad()
				CommunityPageLoad()
			Else
				'
				totalBulletinIndividualPage = CType(ViewState("BulletinImportExportTotalBulletinIndividualPage"), Integer)
				currentBulletinIndividualPage = CType(ViewState("BulletinImportExportCurrentBulletinIndividualPage"), Integer)
				'
				totalBulletinCommunityPage = CType(ViewState("BulletinImportExportTotalBulletinCommunityPage"), Integer)
				currentBulletinCommunityPage = CType(ViewState("BulletinImportExportCurrentBulletinCommunityPage"), Integer)
			End If
		End Sub

		Private Sub IndividualPageLoad()
			Dim myBulletinIndividualMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinIndividualMapDataSet As DataSet
			Dim myHyperLink As HyperLink
			Dim myLabel As Label
			Dim myHtmlTable As HtmlTable
			Dim myHtmlTableRow As HtmlTableRow
			Dim myHtmlTableCell As HtmlTableCell
			Dim myTypeID As Integer = 0
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim myDataColumn As DataColumn
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalBulletinIndividualPage
			myBulletinIndividualMapDataSet = myBulletinIndividualMapDAO.GetEntitys(sid, moduleId, pageSize * currentBulletinIndividualPage)
			'prepare type column
			myDataColumn = New DataColumn("Type")
			myBulletinIndividualMapDataSet.Tables(0).Columns.Add(myDataColumn)

			LinkButtonBulletinIndividualPageDown.Visible = False
			LinkButtonBulletinIndividualTenPageDown.Visible = False
			LinkButtonBulletinIndividualPageUp.Visible = False
			LinkButtonBulletinIndividualTenPageUp.Visible = False

			If myBulletinIndividualMapDataSet.Tables(0).Rows.Count > 0 Then

				'page
				If currentBulletinIndividualPage > 1 Then
					For i = 0 To currentBulletinIndividualPage - 2
						For j = 0 To pageSize - 1
							myBulletinIndividualMapDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				For i = (currentBulletinIndividualPage - 1) * pageSize To myBulletinIndividualMapDataSet.Tables(0).Rows.Count - 1
					myTypeID = CType(myBulletinIndividualMapDataSet.Tables(0).Rows(i).Item("TypeID"), Integer)
					If myTypeID = BulletinType.individual Then
						myBulletinIndividualMapDataSet.Tables(0).Rows(i).Item("Type") = "私有訊息"
					Else
						If myTypeID = BulletinType.community Then
							myBulletinIndividualMapDataSet.Tables(0).Rows(i).Item("Type") = "公有訊息"
						Else
							'exception:unknown bulletin type
							myBulletinIndividualMapDataSet.Tables(0).Rows(i).Item("Type") = ""
						End If
					End If
				Next

				If currentBulletinIndividualPage < totalBulletinIndividualPage Then
					LinkButtonBulletinIndividualPageDown.Visible = True
				Else
					LinkButtonBulletinIndividualPageDown.Visible = False
				End If
				If currentBulletinIndividualPage < totalBulletinIndividualPage - 9 Then
					LinkButtonBulletinIndividualTenPageDown.Visible = True
				Else
					LinkButtonBulletinIndividualTenPageDown.Visible = False
				End If
				If currentBulletinIndividualPage > 1 Then
					LinkButtonBulletinIndividualPageUp.Visible = True
				Else
					LinkButtonBulletinIndividualPageUp.Visible = False
				End If
				If currentBulletinIndividualPage > 10 Then
					LinkButtonBulletinIndividualTenPageUp.Visible = True
				Else
					LinkButtonBulletinIndividualTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentBulletinIndividualPage - 4
				highBound = currentBulletinIndividualPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalBulletinIndividualPage)
				Else
					If highBound > totalBulletinIndividualPage Then
						highBound = totalBulletinIndividualPage
						lowBound = Max(totalBulletinIndividualPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentBulletinIndividualPage Then
						myLabel = New Label
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						myHyperLink = New HyperLink
						myHyperLink.Text = CType(i, String)
						myHyperLink.NavigateUrl = "~/DesktopModules/Bulletin/BulletinImportExport.aspx?mid=" & moduleId & "&sid=" & sid & "&currentbulletinindividualpage=" & CType(i, String) & "&currentbulletincommunitypage=" & currentBulletinCommunityPage & "&tabindex=" & tabIndex & "&tabid=" & tabId
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderBulletinIndividualPageIndex.Controls.Clear()
				PlaceHolderBulletinIndividualPageIndex.Controls.Add(myHtmlTable)

			Else
				'exception
			End If
			DataList1.DataSource = myBulletinIndividualMapDataSet
			DataList1.DataBind()
		End Sub
		Private Sub CommunityPageLoad()
			Dim myBulletinCommunityMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinCommunityMapDataSet As DataSet
			Dim myHyperLink As HyperLink
			Dim myLabel As Label
			Dim myHtmlTable As HtmlTable
			Dim myHtmlTableRow As HtmlTableRow
			Dim myHtmlTableCell As HtmlTableCell
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalBulletinCommunityPage
			myBulletinCommunityMapDataSet = myBulletinCommunityMapDAO.GetCommunityEntitys(moduleId, pageSize * currentBulletinCommunityPage)

			LinkButtonBulletinCommunityPageDown.Visible = False
			LinkButtonBulletinCommunityTenPageDown.Visible = False
			LinkButtonBulletinCommunityPageUp.Visible = False
			LinkButtonBulletinCommunityTenPageUp.Visible = False

			If myBulletinCommunityMapDataSet.Tables(0).Rows.Count > 0 Then

				'page
				If currentBulletinCommunityPage > 1 Then
					For i = 0 To currentBulletinCommunityPage - 2
						For j = 0 To pageSize - 1
							myBulletinCommunityMapDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				If currentBulletinCommunityPage < totalBulletinCommunityPage Then
					LinkButtonBulletinCommunityPageDown.Visible = True
				Else
					LinkButtonBulletinCommunityPageDown.Visible = False
				End If
				If currentBulletinCommunityPage < totalBulletinCommunityPage - 9 Then
					LinkButtonBulletinCommunityTenPageDown.Visible = True
				Else
					LinkButtonBulletinCommunityTenPageDown.Visible = False
				End If
				If currentBulletinCommunityPage > 1 Then
					LinkButtonBulletinCommunityPageUp.Visible = True
				Else
					LinkButtonBulletinCommunityPageUp.Visible = False
				End If
				If currentBulletinCommunityPage > 10 Then
					LinkButtonBulletinCommunityTenPageUp.Visible = True
				Else
					LinkButtonBulletinCommunityTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentBulletinCommunityPage - 4
				highBound = currentBulletinCommunityPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalBulletinCommunityPage)
				Else
					If highBound > totalBulletinCommunityPage Then
						highBound = totalBulletinCommunityPage
						lowBound = Max(totalBulletinCommunityPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentBulletinCommunityPage Then
						myLabel = New Label
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						myHyperLink = New HyperLink
						myHyperLink.Text = CType(i, String)
						myHyperLink.NavigateUrl = "~/DesktopModules/Bulletin/BulletinImportExport.aspx?mid=" & moduleId & "&sid=" & sid & "&currentbulletinindividualpage=" & currentBulletinIndividualPage & "&currentbulletincommunitypage=" & CType(i, String) & "&tabindex=" & tabIndex & "&tabid=" & tabId
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderBulletinCommunityPageIndex.Controls.Clear()
				PlaceHolderBulletinCommunityPageIndex.Controls.Add(myHtmlTable)

			Else
				'exception
			End If
			DataList2.DataSource = myBulletinCommunityMapDataSet
			DataList2.DataBind()
		End Sub
		Sub IndividualPageReload()
			Dim myBulletinIndividualMapDAO As New ASPNET.StarterKit.Portal.Portal_BulletinMapDAOExtand
			Dim rowCount As Integer

			'
			rowCount = myBulletinIndividualMapDAO.GetTotalRow(sid, moduleId)
			If rowCount Mod pageSize = 0 Then
				totalBulletinIndividualPage = CType(rowCount \ pageSize, Integer)
			Else
				totalBulletinIndividualPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentBulletinIndividualPage = 1

			ViewState("BulletinImportExportTotalBulletinIndividualPage") = totalBulletinIndividualPage
			ViewState("BulletinImportExportCurrentBulletinIndividualPage") = currentBulletinIndividualPage

			IndividualPageLoad()
			CommunityPageLoad()
		End Sub
		Sub CommunityPageReload()
			Dim myBulletinCommunityMapDAO As New ASPNET.StarterKit.Portal.Portal_BulletinMapDAOExtand
			Dim rowCount As Integer

			'
			rowCount = myBulletinCommunityMapDAO.GetTotalCommunityRow(moduleId)
			If rowCount Mod pageSize = 0 Then
				totalBulletinCommunityPage = CType(rowCount \ pageSize, Integer)
			Else
				totalBulletinCommunityPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentBulletinCommunityPage = 1

			ViewState("BulletinImportExportTotalBulletinCommunityPage") = totalBulletinCommunityPage
			ViewState("BulletinImportExportCurrentBulletinCommunityPage") = currentBulletinCommunityPage

			IndividualPageLoad()
			CommunityPageLoad()
		End Sub

		Private Sub LinkButtonBulletinIndividualPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinIndividualPageUp.Click
			currentBulletinIndividualPage = currentBulletinIndividualPage - 1
			If currentBulletinIndividualPage < 1 Then
				currentBulletinIndividualPage = 1
			End If
			ViewState("BulletinImportExportCurrentBulletinIndividualPage") = currentBulletinIndividualPage
			IndividualPageLoad()
			CommunityPageLoad()
		End Sub

		Private Sub LinkButtonBulletinIndividualPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinIndividualPageDown.Click
			currentBulletinIndividualPage = currentBulletinIndividualPage + 1
			If currentBulletinIndividualPage > totalBulletinIndividualPage Then
				currentBulletinIndividualPage = totalBulletinIndividualPage
			End If
			ViewState("BulletinImportExportCurrentBulletinIndividualPage") = currentBulletinIndividualPage
			IndividualPageLoad()
			CommunityPageLoad()
		End Sub

		Private Sub LinkButtonBulletinIndividualTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinIndividualTenPageUp.Click
			currentBulletinIndividualPage = currentBulletinIndividualPage - 10
			If currentBulletinIndividualPage < 1 Then
				currentBulletinIndividualPage = 1
			End If
			ViewState("BulletinImportExportCurrentBulletinIndividualPage") = currentBulletinIndividualPage
			IndividualPageLoad()
			CommunityPageLoad()
		End Sub

		Private Sub LinkButtonBulletinIndividualTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinIndividualTenPageDown.Click
			currentBulletinIndividualPage = currentBulletinIndividualPage + 10
			If currentBulletinIndividualPage > totalBulletinIndividualPage Then
				currentBulletinIndividualPage = totalBulletinIndividualPage
			End If
			ViewState("BulletinImportExportCurrentBulletinIndividualPage") = currentBulletinIndividualPage
			IndividualPageLoad()
			CommunityPageLoad()
		End Sub
		Private Sub LinkButtonBulletinCommunityPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinCommunityPageUp.Click
			currentBulletinCommunityPage = currentBulletinCommunityPage - 1
			If currentBulletinCommunityPage < 1 Then
				currentBulletinCommunityPage = 1
			End If
			ViewState("BulletinImportExportCurrentBulletinCommunityPage") = currentBulletinCommunityPage
			IndividualPageLoad()
			CommunityPageLoad()
		End Sub

		Private Sub LinkButtonBulletinCommunityPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinCommunityPageDown.Click
			currentBulletinCommunityPage = currentBulletinCommunityPage + 1
			If currentBulletinCommunityPage > totalBulletinCommunityPage Then
				currentBulletinCommunityPage = totalBulletinCommunityPage
			End If
			ViewState("BulletinImportExportCurrentBulletinCommunityPage") = currentBulletinCommunityPage
			IndividualPageLoad()
			CommunityPageLoad()
		End Sub

		Private Sub LinkButtonBulletinCommunityTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinCommunityTenPageUp.Click
			currentBulletinCommunityPage = currentBulletinCommunityPage - 10
			If currentBulletinCommunityPage < 1 Then
				currentBulletinCommunityPage = 1
			End If
			ViewState("BulletinImportExportCurrentBulletinCommunityPage") = currentBulletinCommunityPage
			IndividualPageLoad()
			CommunityPageLoad()
		End Sub

		Private Sub LinkButtonBulletinCommunityTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinCommunityTenPageDown.Click
			currentBulletinCommunityPage = currentBulletinCommunityPage + 10
			If currentBulletinCommunityPage > totalBulletinCommunityPage Then
				currentBulletinCommunityPage = totalBulletinCommunityPage
			End If
			ViewState("BulletinImportExportCurrentBulletinCommunityPage") = currentBulletinCommunityPage
			IndividualPageLoad()
			CommunityPageLoad()
		End Sub

		Private Sub ImageButtonExport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click
			Dim myBulletinID As String = ""
			Dim isExport As Boolean
			Dim myBulletinMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myBulletinDataSet As DataSet
			Dim myBulletinPartDataSet As DataSet
			Dim myTypeID As Integer = 0
			Dim anItem As DataListItem
			Dim dk As String
			Dim myAuditID As String = ""
			For Each anItem In DataList1.Items
				isExport = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
				If isExport Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					If dk.Trim.Length > 0 Then
						myBulletinMapDataSet = myBulletinMapDAO.GetEntity(dk)
						If myBulletinMapDataSet.Tables(0).Rows.Count = 1 Then
							myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("BulletinID"), String).Trim
							If myBulletinID.Length > 0 Then
								'check if it is individual record
								myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
								If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
									myTypeID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("TypeID"), Integer)
									If myTypeID = BulletinType.individual Then
										'audit
										myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myBulletinDAO.ToString, "UpdateEntity", myBulletinID, "", Context.User.Identity.Name, Now)
										'log before action
										AuditDetail(myAuditID, SequenceType.before, myBulletinDataSet)
										'actual action
										'export individual bulletin to community
										myBulletinDAO.UpdateEntity(myBulletinID, BulletinType.community)
										'log after action
										myBulletinPartDataSet = myBulletinDAO.GetEntity(myBulletinID)
										If myBulletinPartDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.after, myBulletinPartDataSet)
										End If
										'statistic
										ModuleStatisticDAO.InsertEntity(sid, moduleId, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, Now)
									Else
										'do nothing
									End If
								Else
									'exception:bulletin record is empty or duplicated
								End If
							Else
								'exception:bulletin is empty
							End If
						Else
							'exception:bulletin map is empty or duplicated
						End If
					Else
						'exception:bulletin map is is empty
					End If
				End If
			Next
			IndividualPageReload()
			CommunityPageReload()
		End Sub

		Private Sub ImageButtonImport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonImport.Click
			Dim myBulletinID As String = ""
			Dim myBulletinMapID As String = ""
			Dim myBulletinMapTempID As String = ""
			Dim isImport As Boolean
			Dim myBulletinMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myBulletinMapPartDataSet As DataSet
			Dim myBulletinMapTempDataSet As DataSet
			Dim myBulletinDataSet As DataSet
			Dim myBulletinPartDataSet As DataSet
			Dim anItem As DataListItem
			Dim dk As String = ""
			Dim myBulletinUser As String = ""
			Dim myBulletinMapUser As String = ""
			Dim myTypeID As Integer = 0
			Dim myItemID As Integer = 0
			Dim myDisplayOrder As Integer = 0
			Dim myCreatedDate As Date = Now
			Dim myBulletinModuleID As Integer = 0
			Dim myBulletinMapModuleID As Integer = 0
			Dim myAuditID As String = ""
			Dim i As Integer = 0
			For Each anItem In DataList2.Items
				isImport = CType(anItem.FindControl("CheckBox2"), CheckBox).Checked
				If isImport Then
					dk = CType(DataList2.DataKeys(anItem.ItemIndex), String)
					If dk.Trim.Length > 0 Then
						'read bulletin map data
						myBulletinMapDataSet = myBulletinMapDAO.GetEntity(dk)
						If myBulletinMapDataSet.Tables(0).Rows.Count = 1 Then
							myItemID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
							myDisplayOrder = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)
							myCreatedDate = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("CreatedDate"), Date)
							myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("BulletinID"), String).Trim
							myBulletinMapUser = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
							myBulletinMapModuleID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
							If myBulletinID.Length > 0 Then
								'read bulletin data
								myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
								If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
									myTypeID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("TypeID"), Integer)
									myBulletinUser = CType(myBulletinDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
									myBulletinModuleID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
									'check ownership
									'If myBulletinModuleID = myBulletinMapModuleID Then
									If myBulletinModuleID = moduleId Then
										'audit
										myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myBulletinDAO.ToString, "UpdateEntity", myBulletinID, "", context.User.Identity.Name, Now)
										'log before action
										AuditDetail(myAuditID, SequenceType.before, myBulletinDataSet)
										'actual action
										myBulletinDAO.UpdateEntity(myBulletinID, BulletinType.individual)
										'log after action
										myBulletinPartDataSet = myBulletinDAO.GetEntity(myBulletinID)
										If myBulletinPartDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.after, myBulletinPartDataSet)
										End If
										'delete old bulletin map and insert new bulletin map
										myBulletinMapTempDataSet = myBulletinMapDAO.GetEntityByBulletinID(myBulletinID)
										If myBulletinMapTempDataSet.Tables(0).Rows.Count > 0 Then
											For i = 0 To myBulletinMapTempDataSet.Tables(0).Rows.Count - 1
												myBulletinMapTempID = CType(myBulletinMapTempDataSet.Tables(0).Rows(i).Item("EntityID"), String)
												'audit
												myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myBulletinMapDAO.ToString, "DeleteEntity", myBulletinMapTempID, "", Context.User.Identity.Name, Now)
												'log before audit
												myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(myBulletinMapTempID)
												AuditDetail(myAuditID, SequenceType.before, myBulletinMapPartDataSet)
												'actual action
												myBulletinMapDAO.DeleteEntity(myBulletinMapTempID)
												'log after audit
												myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(myBulletinMapTempID)
												If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
													AuditDetail(myAuditID, SequenceType.after, myBulletinMapPartDataSet)
												End If
											Next
										End If
										'audit
										myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinMapDAO.ToString, "InsertEntity", dk, "", Context.User.Identity.Name, Now)
										'log before action
										myBulletinMapTempDataSet = myBulletinMapDAO.GetEntity(dk)
										If myBulletinMapTempDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.before, myBulletinMapTempDataSet)
										End If
										'actual action
										myBulletinMapDAO.InsertEntity(dk, sid, moduleId, myItemID, myBulletinID, myDisplayOrder, myBulletinMapUser, myCreatedDate)
										'log after action
										myBulletinMapTempDataSet = myBulletinMapDAO.GetEntity(dk)
										If myBulletinMapTempDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.after, myBulletinMapTempDataSet)
										End If
									Else
										'check if duplicated
										myBulletinMapDataSet = myBulletinMapDAO.GetEntitysByModuleIDAndBulletinID(moduleId, myBulletinID)
										If myBulletinMapDataSet.Tables(0).Rows.Count = 0 Then
											'audit
											myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinMapDAO.ToString, "InsertEntity", myBulletinMapID, "", Context.User.Identity.Name, Now)
											'log before action
											'none
											'insert new bulletin map
											myBulletinMapID = myBulletinMapDAO.InsertEntity(sid, moduleId, 0, myBulletinID, 1, Context.User.Identity.Name, Now)
											'log after action
											myBulletinMapTempDataSet = myBulletinMapDAO.GetEntity(myBulletinMapID)
											If myBulletinMapTempDataSet.Tables(0).Rows.Count = 1 Then
												AuditDetail(myAuditID, SequenceType.after, myBulletinMapTempDataSet)
											End If
											'statistic
											ModuleStatisticDAO.InsertEntity(sid, moduleId, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, Now)
										Else
											'exception:bulletin map is duplicated
										End If
									End If
								Else
									'exception:bulletin is empty or duplicated
								End If
							Else
								'exception:bulletin id is empty
							End If
						Else
							'exception:bulletin map is empty or duplicated
						End If
					Else
						'exception:bulletin map id is empty
					End If
				End If
			Next

			For Each anItem In DataList1.Items
				isImport = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
				If isImport Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					If dk.Trim.Length > 0 Then
						'read bulletin map data
						myBulletinMapDataSet = myBulletinMapDAO.GetEntity(dk)
						If myBulletinMapDataSet.Tables(0).Rows.Count = 1 Then
							myItemID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
							myDisplayOrder = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)
							myCreatedDate = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("CreatedDate"), Date)
							myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("BulletinID"), String).Trim
							myBulletinMapUser = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
							myBulletinMapModuleID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
							If myBulletinID.Length > 0 Then
								'read bulletin data
								myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
								If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
									myTypeID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("TypeID"), Integer)
									myBulletinUser = CType(myBulletinDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
									myBulletinModuleID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
									'check ownership
									'If myBulletinModuleID = myBulletinMapModuleID Then
									If myBulletinModuleID = moduleId Then
										'audit
										myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myBulletinDAO.ToString, "UpdateEntity", myBulletinID, "", context.User.Identity.Name, Now)
										'log before action
										AuditDetail(myAuditID, SequenceType.before, myBulletinDataSet)
										'actual action
										myBulletinDAO.UpdateEntity(myBulletinID, BulletinType.individual)
										'log after action
										myBulletinPartDataSet = myBulletinDAO.GetEntity(myBulletinID)
										If myBulletinPartDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.after, myBulletinPartDataSet)
										End If
										'delete old bulletin map and insert new bulletin map
										myBulletinMapTempDataSet = myBulletinMapDAO.GetEntityByBulletinID(myBulletinID)
										If myBulletinMapTempDataSet.Tables(0).Rows.Count > 0 Then
											For i = 0 To myBulletinMapTempDataSet.Tables(0).Rows.Count - 1
												myBulletinMapTempID = CType(myBulletinMapTempDataSet.Tables(0).Rows(i).Item("EntityID"), String)
												'audit
												myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myBulletinMapDAO.ToString, "DeleteEntity", myBulletinMapTempID, "", Context.User.Identity.Name, Now)
												'log before action
												myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(myBulletinMapTempID)
												If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
													AuditDetail(myAuditID, SequenceType.before, myBulletinMapPartDataSet)
												End If
												'actual action
												myBulletinMapDAO.DeleteEntity(myBulletinMapTempID)
												'log after action
												myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(myBulletinMapTempID)
												If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
													AuditDetail(myAuditID, SequenceType.after, myBulletinMapPartDataSet)
												End If
											Next
										End If
										'audit
										myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinMapDAO.ToString, "InsertEntity", dk, "", Context.User.Identity.Name, Now)
										'log before action
										myBulletinMapTempDataSet = myBulletinMapDAO.GetEntity(dk)
										If myBulletinMapTempDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.before, myBulletinMapTempDataSet)
										End If
										'actual action
										myBulletinMapDAO.InsertEntity(dk, sid, moduleId, myItemID, myBulletinID, myDisplayOrder, myBulletinMapUser, myCreatedDate)
										'log after action
										myBulletinMapTempDataSet = myBulletinMapDAO.GetEntity(dk)
										If myBulletinMapTempDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.after, myBulletinMapTempDataSet)
										End If
									Else
										'exception:bulletin module id is not equal to module id
									End If
								Else
									'exception:bulletin is empty or duplicated
								End If
							Else
								'exception:bulletin id is empty
							End If
						Else
							'exception:bulletin map is empty or duplicated
						End If
					Else
						'exception:bulletin map id is empty
					End If
				End If
			Next
			IndividualPageReload()
			CommunityPageReload()
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