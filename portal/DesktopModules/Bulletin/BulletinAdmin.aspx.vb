Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal


	Public Class BulletinAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonBulletinAdminTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonBulletinAdminPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderBulletinAdminPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonBulletinAdminPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonBulletinAdminTenPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents ButtonBulletinAdminUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonBulletinAdminDelete As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonBulletinAdminInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonIImportExport As System.Web.UI.WebControls.Button
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
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
		Protected pageSize As Integer = 10
		Protected totalBulletinAdminPage As Integer = 0
		Protected currentBulletinAdminPage As Integer = 0
		Dim AuditDAO As New Portal_AuditDAOExtand
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
			Dim myBulletinMapDAO As New ASPNET.StarterKit.Portal.Portal_BulletinMapDAOExtand
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

			If Not IsPostBack Then
				'manage Bulletin page 
				rowCount = myBulletinMapDAO.GetTotalRow(sid, moduleId)
				If rowCount Mod pageSize = 0 Then
					totalBulletinAdminPage = CType(rowCount \ pageSize, Integer)
				Else
					totalBulletinAdminPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("currentbulletinadminpage") Is Nothing) Then
					currentBulletinAdminPage = CType(Request.Params("currentbulletinadminpage"), Integer)
					ViewState("BulletinAdminCurrentBulletinAdminPage") = currentBulletinAdminPage
				Else
					currentBulletinAdminPage = 1
				End If

				ViewState("BulletinAdminTotalBulletinAdminPage") = totalBulletinAdminPage
				ViewState("BulletinAdminCurrentBulletinAdminPage") = currentBulletinAdminPage

				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			Else
				totalBulletinAdminPage = CType(ViewState("BulletinAdminTotalBulletinAdminPage"), Integer)
				currentBulletinAdminPage = CType(ViewState("BulletinAdminCurrentBulletinAdminPage"), Integer)
			End If
		End Sub

		Private Sub PageLoad()
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinDataSet As DataSet
			Dim myBulletinMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myDataColumn As DataColumn
			Dim myHyperLink As HyperLink
			Dim myLabel As Label
			Dim myHtmlTable As HtmlTable
			Dim myHtmlTableRow As HtmlTableRow
			Dim myHtmlTableCell As HtmlTableCell
			Dim myTypeID As Integer = 0
			Dim myBulletinID As String = ""
			Dim myTitle As String = ""
			Dim myAnnounceUnit As String = ""
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalBulletinAdminPage
			myBulletinMapDataSet = myBulletinMapDAO.GetEntitys(sid, moduleId, pageSize * currentBulletinAdminPage)
			myDataColumn = New DataColumn("Type")
			myBulletinMapDataSet.Tables(0).Columns.Add(myDataColumn)
			'myDataColumn = New DataColumn("Title")
			'myBulletinMapDataSet.Tables(0).Columns.Add(myDataColumn)
			'myDataColumn = New DataColumn("AnnounceUnit")
			'myBulletinMapDataSet.Tables(0).Columns.Add(myDataColumn)

			LinkButtonBulletinAdminPageDown.Visible = False
			LinkButtonBulletinAdminTenPageDown.Visible = False
			LinkButtonBulletinAdminPageUp.Visible = False
			LinkButtonBulletinAdminTenPageUp.Visible = False

			If myBulletinMapDataSet.Tables(0).Rows.Count > 0 Then

				'page
				If currentBulletinAdminPage > 1 Then
					For i = 0 To currentBulletinAdminPage - 2
						For j = 0 To pageSize - 1
							myBulletinMapDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				If currentBulletinAdminPage < totalBulletinAdminPage Then
					LinkButtonBulletinAdminPageDown.Visible = True
				Else
					LinkButtonBulletinAdminPageDown.Visible = False
				End If
				If currentBulletinAdminPage < totalBulletinAdminPage - 9 Then
					LinkButtonBulletinAdminTenPageDown.Visible = True
				Else
					LinkButtonBulletinAdminTenPageDown.Visible = False
				End If
				If currentBulletinAdminPage > 1 Then
					LinkButtonBulletinAdminPageUp.Visible = True
				Else
					LinkButtonBulletinAdminPageUp.Visible = False
				End If
				If currentBulletinAdminPage > 10 Then
					LinkButtonBulletinAdminTenPageUp.Visible = True
				Else
					LinkButtonBulletinAdminTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentBulletinAdminPage - 4
				highBound = currentBulletinAdminPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalBulletinAdminPage)
				Else
					If highBound > totalBulletinAdminPage Then
						highBound = totalBulletinAdminPage
						lowBound = Max(totalBulletinAdminPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentBulletinAdminPage Then
						myLabel = New Label
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						myHyperLink = New HyperLink
						myHyperLink.Text = CType(i, String)
						myHyperLink.NavigateUrl = "~/DesktopModules/Bulletin/BulletinAdmin.aspx?mid=" & moduleId & "&sid=" & sid & "&currentbulletinadminpage=" & CType(i, String) & "&tabindex=" & tabIndex & "&tabid=" & tabId
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderBulletinAdminPageIndex.Controls.Add(myHtmlTable)

				'prepare Bulletin list and user data
				If myBulletinMapDataSet.Tables(0).Rows.Count > 0 Then
					For i = (currentBulletinAdminPage - 1) * pageSize To myBulletinMapDataSet.Tables(0).Rows.Count - 1
						myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(i).Item("BulletinID"), String).Trim
						myTypeID = CType(myBulletinMapDataSet.Tables(0).Rows(i).Item("TypeID"), Integer)
						If myTypeID = BulletinType.individual Then
							myBulletinMapDataSet.Tables(0).Rows(i).Item("Type") = "私有訊息"
						Else
							If myTypeID = BulletinType.community Then
								myBulletinMapDataSet.Tables(0).Rows(i).Item("Type") = "公眾訊息"
							Else
								'exception:unknown bulletin type
								myBulletinMapDataSet.Tables(0).Rows(i).Item("Type") = ""
							End If
						End If
						'If myBulletinID.Length > 0 Then
						'	myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
						'	If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
						'		myTypeID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("TypeID"), Integer)
						'		myTitle = CType(myBulletinDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
						'		myAnnounceUnit = CType(myBulletinDataSet.Tables(0).Rows(0).Item("AnnounceUnit"), String).Trim
						'		myBulletinMapDataSet.Tables(0).Rows(i).Item("Title") = myTitle
						'		myBulletinMapDataSet.Tables(0).Rows(i).Item("AnnounceUnit") = myAnnounceUnit
						'		If myTypeID = BulletinType.individual Then
						'			myBulletinMapDataSet.Tables(0).Rows(i).Item("Type") = "私有訊息"
						'		Else
						'			If myTypeID = BulletinType.community Then
						'				myBulletinMapDataSet.Tables(0).Rows(i).Item("Type") = "公眾訊息"
						'			Else
						'				'exception:unknown bulletin type
						'				myBulletinMapDataSet.Tables(0).Rows(i).Item("Type") = ""
						'			End If
						'		End If
						'	Else
						'		'exception:Bulletin data is empty or duplicated
						'	End If
						'Else
						'	'exception:bulletin id is empty
						'End If
					Next
				End If
			Else
				'exception
			End If
			DataList1.DataSource = myBulletinMapDataSet
			DataList1.DataBind()
		End Sub
		Sub PageReload()
			Dim myBulletinMapDAO As New ASPNET.StarterKit.Portal.Portal_BulletinMapDAOExtand
			Dim rowCount As Integer

			'
			rowCount = myBulletinMapDAO.GetTotalRow(sid, moduleId)
			If rowCount Mod pageSize = 0 Then
				totalBulletinAdminPage = CType(rowCount \ pageSize, Integer)
			Else
				totalBulletinAdminPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentBulletinAdminPage = 1

			ViewState("BulletinAdminTotalBulletinAdminPage") = totalBulletinAdminPage
			ViewState("BulletinAdminCurrentBulletinAdminPage") = currentBulletinAdminPage

			PageLoad()
		End Sub

		Private Sub LinkButtonBulletinAdminPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinAdminPageUp.Click
			currentBulletinAdminPage = currentBulletinAdminPage - 1
			If currentBulletinAdminPage < 1 Then
				currentBulletinAdminPage = 1
			End If
			ViewState("BulletinAdminCurrentBulletinAdminPage") = currentBulletinAdminPage
			PageLoad()
		End Sub

		Private Sub LinkButtonBulletinAdminPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinAdminPageDown.Click
			currentBulletinAdminPage = currentBulletinAdminPage + 1
			If currentBulletinAdminPage > totalBulletinAdminPage Then
				currentBulletinAdminPage = totalBulletinAdminPage
			End If
			ViewState("BulletinAdminCurrentBulletinAdminPage") = currentBulletinAdminPage
			PageLoad()
		End Sub

		Private Sub LinkButtonBulletinAdminTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinAdminTenPageUp.Click
			currentBulletinAdminPage = currentBulletinAdminPage - 10
			If currentBulletinAdminPage < 1 Then
				currentBulletinAdminPage = 1
			End If
			ViewState("BulletinAdminCurrentBulletinAdminPage") = currentBulletinAdminPage
			PageLoad()
		End Sub

		Private Sub LinkButtonBulletinAdminTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinAdminTenPageDown.Click
			currentBulletinAdminPage = currentBulletinAdminPage + 10
			If currentBulletinAdminPage > totalBulletinAdminPage Then
				currentBulletinAdminPage = totalBulletinAdminPage
			End If
			ViewState("BulletinAdminCurrentBulletinAdminPage") = currentBulletinAdminPage
			PageLoad()
		End Sub
		Private Sub ButtonBulletinAdminInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBulletinAdminInsert.Click
			Response.Redirect("~/DesktopModules/Bulletin/BulletinUpdate.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub ButtonBulletinAdminUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBulletinAdminUpdate.Click
			Dim isEdit As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			For Each anItem In DataList1.Items
				isEdit = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
				If isEdit Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					Response.Redirect("~/DesktopModules/Bulletin/BulletinUpdate.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&bulletinmapid=" & dk & "&tabid=" & tabId & "&tabindex=" & tabIndex)
				End If
			Next
		End Sub

		Private Sub ButtonBulletinAdminDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBulletinAdminDelete.Click
			Dim myBulletinID As String = ""
			Dim myTypeID As Integer = 0
			Dim isDelete As Boolean
			Dim myBulletinMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinAppendDAO As New Portal_BulletinAppendDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myBulletinDataSet As DataSet
			Dim myBulletinPartDataSet As DataSet
			Dim myBulletinAppendDataSet As DataSet
			Dim myBulletinAppendPartDataSet As DataSet
			Dim myBulletinMapPartDataSet As DataSet
			Dim myBulletinModuleID As Integer = 0
			Dim myBulletinMapModuleID As Integer = 0
			Dim anItem As DataListItem
			Dim dk As String
			Dim i As Integer = 0
			Dim up_path As String = Server.MapPath("/PortalFiles/UpLoadFiles/BulletinAppend")
			Dim myPhysicalFileName As String = ""
			Dim myAuditID As String = ""
			Dim myBulletinMapID As String = ""
			Dim myBulletinAppendID As String = ""
			For Each anItem In DataList1.Items
				isDelete = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
				If isDelete Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					'delete record in bulletin map
					myBulletinMapDataSet = myBulletinMapDAO.GetEntity(dk)
					If myBulletinMapDataSet.Tables(0).Rows.Count = 1 Then
						myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("BulletinID"), String)
						myBulletinMapModuleID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myBulletinMapDAO.ToString, "DeleteEntity", dk, "", Context.User.Identity.Name, Now)
						'log before action
						AuditDetail(myAuditID, SequenceType.before, myBulletinMapDataSet)
						'actual action
						myBulletinMapDAO.DeleteEntity(dk)
						'log after action
						myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(dk)
						If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myBulletinMapPartDataSet)
						End If
						'delete record in bulletin
						myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
						If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
							'check ownership
							myBulletinModuleID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
							If myBulletinMapModuleID = myBulletinModuleID Then
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myBulletinDAO.ToString, "DeleteEntity", myBulletinID, "", Context.User.Identity.Name, Now)
								'log before action
								AuditDetail(myAuditID, SequenceType.before, myBulletinDataSet)
								'actual action
								myBulletinDAO.DeleteEntity(myBulletinID)
								'log after action
								myBulletinPartDataSet = myBulletinDAO.GetEntity(myBulletinID)
								If myBulletinPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinPartDataSet)
								End If
								'delete foreign key in bulletin map
								myTypeID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("TypeID"), Integer)
								If myTypeID = BulletinType.community Then
									myBulletinMapDataSet = myBulletinMapDAO.GetEntityByBulletinID(myBulletinID)
									If myBulletinMapDataSet.Tables(0).Rows.Count > 0 Then
										For i = 0 To myBulletinMapDataSet.Tables(0).Rows.Count - 1
											myBulletinMapID = CType(myBulletinMapDataSet.Tables(0).Rows(i).Item("EntityID"), String)
											myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(myBulletinMapID)
											'audit
											myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myBulletinMapDAO.ToString, "DeleteEntity", myBulletinMapID, "", Context.User.Identity.Name, Now)
											'log before action
											AuditDetail(myAuditID, SequenceType.before, myBulletinMapPartDataSet)
											'actual action
											myBulletinMapDAO.DeleteEntity(myBulletinMapID)
											'log after action
											myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(myBulletinMapID)
											If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
												AuditDetail(myAuditID, SequenceType.after, myBulletinMapPartDataSet)
											End If
										Next
									End If
								End If
								'delete append record
								myBulletinAppendDataSet = myBulletinAppendDAO.GetEntitys(myBulletinID)
								If myBulletinAppendDataSet.Tables(0).Rows.Count > 0 Then
									For i = 0 To myBulletinAppendDataSet.Tables(0).Rows.Count - 1
										myBulletinAppendID = CType(myBulletinAppendDataSet.Tables(0).Rows(i).Item("EntityID"), String)
										myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
										'audit
										myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myBulletinAppendDAO.ToString, "DeleteEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
										'log before action
										AuditDetail(myAuditID, SequenceType.before, myBulletinAppendPartDataSet)
										'actual action
										myBulletinAppendDAO.DeleteEntity(myBulletinAppendID)
										'log after action
										myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
										If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
										End If
									Next
								End If
								'delete append file
								For i = 0 To myBulletinAppendDataSet.Tables(0).Rows.Count - 1
									myPhysicalFileName = up_path & "/" & Path.GetFileName(CType(myBulletinAppendDataSet.Tables(0).Rows(i).Item("FileName"), String))
									'clear old file
									If File.Exists(myPhysicalFileName) Then
										File.Delete(myPhysicalFileName)
										'audit
										AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myPhysicalFileName, "", Context.User.Identity.Name, Now)
									End If
								Next
							End If
						Else
							'exception:bulletin record is empty or duplicated
						End If
					Else
						'exception:bulletin map record is empty or duplicated
					End If
				End If
			Next
			PageReload()
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
		Private Sub ButtonIImportExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonIImportExport.Click
			Response.Redirect("~/DesktopModules/Bulletin/BulletinImportExport.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class
End Namespace