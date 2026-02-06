Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class AuditList
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonAuditListTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonAuditListPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderAuditListPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonAuditListPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonAuditListTenPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxUserName As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxStartTime As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxEndTime As System.Web.UI.WebControls.TextBox
		Protected WithEvents RadioButtonDelete As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonUpdate As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonInsert As System.Web.UI.WebControls.RadioButton
		Protected WithEvents DropDownListModule As System.Web.UI.WebControls.DropDownList
		Protected WithEvents ButtonQuery As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents RadioButtonAll As System.Web.UI.WebControls.RadioButton
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
		Protected totalAuditListPage As Integer = 0
		Protected currentAuditListPage As Integer = 0
		Private queryUserName As String = ""
		Private queryLevelID As Integer = 0
		Private queryActionID As Integer = 0
		Private queryModuleID As Integer = 0
		Private querySchoolID As String = ""
		Private queryStartTime As Date = New Date(1900, 1, 1)
		Private queryEndTime As Date = New Date(2100, 1, 1)


		Enum LevelType
			debug = 1
			info = 2
		End Enum

		Enum ActionType
			all = 0
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
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageInit()
				''manage Audit page 
				'myAuditDataSet = myAuditDAO.GetEntitys(sid, moduleId)

				'rowCount = myAuditDataSet.Tables(0).Rows.Count
				'If rowCount Mod pageSize = 0 Then
				'	totalAuditListPage = CType(rowCount \ pageSize, Integer)
				'Else
				'	totalAuditListPage = CType(rowCount \ pageSize + 1, Integer)
				'End If

				If Not (Request.Params("currentauditlistpage") Is Nothing) Then
					ParseArgument()

					PageLoad()
				Else
					currentAuditListPage = 1
				End If
			Else
				totalAuditListPage = CType(ViewState("AuditListTotalAuditListPage"), Integer)
				currentAuditListPage = CType(ViewState("AuditListCurrentAuditListPage"), Integer)
			End If
		End Sub

		Private Sub ParseArgument()
			Dim delimStr As String = "/-:. _"
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing

			If Not (Request.Params("currentauditlistpage") Is Nothing) Then
				currentAuditListPage = CType(Request.Params("currentauditlistpage"), Integer)
				ViewState("AuditListCurrentAuditListPage") = currentAuditListPage
			End If
			If Not (Request.Params("totalauditlistpage") Is Nothing) Then
				totalAuditListPage = CType(Request.Params("totalauditlistpage"), Integer)
				ViewState("AuditListTotalAuditListPage") = totalAuditListPage
			End If
			If Not (Request.Params("queryusername") Is Nothing) Then
				queryUserName = Request.Params("queryusername").Trim
			End If
			If Not (Request.Params("querylevelid") Is Nothing) Then
				queryLevelID = CType(Request.Params("querylevelid"), Integer)
			End If
			If Not (Request.Params("queryactionid") Is Nothing) Then
				queryActionID = CType(Request.Params("queryactionid"), Integer)
			End If
			If Not (Request.Params("querymoduleid") Is Nothing) Then
				queryModuleID = CType(Request.Params("querymoduleid"), Integer)
			End If
			If Not (Request.Params("queryschoolid") Is Nothing) Then
				querySchoolID = Request.Params("queryschoolid").Trim
			End If
			If Not (Request.Params("querystarttime") Is Nothing) Then
				tempString = Request.Params("querystarttime").Trim
				If tempString <> "" Then
					tempArray = tempString.Split(delimiter)
					If tempArray.Length = 6 Then
						queryStartTime = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer), CType(tempArray(3), Integer), CType(tempArray(4), Integer), CType(tempArray(5), Integer))
					Else
						'exception:start time format error
					End If
				End If
			End If
			If Not (Request.Params("queryendtime") Is Nothing) Then
				tempString = Request.Params("queryendtime").Trim
				If tempString <> "" Then
					tempArray = tempString.Split(delimiter)
					If tempArray.Length = 6 Then
						queryEndTime = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer), CType(tempArray(3), Integer), CType(tempArray(4), Integer), CType(tempArray(5), Integer))
					Else
						'exception:start time format error
					End If
				End If
			End If

			PageInit()

			TextBoxUserName.Text = queryUserName
			If queryActionID = ActionType.insert Then
				RadioButtonInsert.Checked = True
			Else
				RadioButtonInsert.Checked = False
			End If
			If queryActionID = ActionType.update Then
				RadioButtonUpdate.Checked = True
			Else
				RadioButtonUpdate.Checked = False
			End If
			If queryActionID = ActionType.delete Then
				RadioButtonDelete.Checked = True
			Else
				RadioButtonDelete.Checked = False
			End If
			If queryActionID = ActionType.all Then
				RadioButtonAll.Checked = True
			Else
				RadioButtonAll.Checked = False
			End If

			If queryModuleID <> 0 Then
				DropDownListModule.SelectedValue = CType(queryModuleID, String)
			End If

			If queryStartTime.ToString <> New Date(1900, 1, 1).ToString Then
				TextBoxStartTime.Text = queryStartTime.Year & "/" & queryStartTime.Month & "/" & queryStartTime.Day & " " & queryStartTime.Hour & ":" & queryStartTime.Minute & ":" & queryStartTime.Second
			End If
			If queryEndTime.ToString <> New Date(2100, 1, 1).ToString Then
				TextBoxEndTime.Text = queryEndTime.Year & "/" & queryEndTime.Month & "/" & queryEndTime.Day & " " & queryEndTime.Hour & ":" & queryEndTime.Minute & ":" & queryEndTime.Second
			End If
		End Sub

		Private Sub PageInit()
			Dim doc As New System.Xml.XPath.XPathDocument(getCurrentXmlfile(Context.User.Identity.Name))
			Dim myAuditDAO As New Portal_AuditDAOExtand
			Dim myAuditDataSet As DataSet
			Dim nav As System.Xml.XPath.XPathNavigator
			Dim nav2 As System.Xml.XPath.XPathNavigator
			Dim expr As System.Xml.XPath.XPathExpression
			Dim iterator As System.Xml.XPath.XPathNodeIterator
			Dim searchString As String = ""
			Dim delimStr As String = "/-:. _"
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myModuleID As Integer = 0
			Dim myModuleName As String = ""
			Dim myListItem As ListItem

			TextBoxUserName.Text = ""
			RadioButtonInsert.Checked = False
			RadioButtonUpdate.Checked = False
			RadioButtonDelete.Checked = False
			DropDownListModule.Items.Clear()
			TextBoxStartTime.Text = ""
			TextBoxEndTime.Text = ""
			LinkButtonAuditListTenPageUp.Visible = False
			LinkButtonAuditListPageUp.Visible = False
			LinkButtonAuditListPageDown.Visible = False
			LinkButtonAuditListTenPageDown.Visible = False
			PlaceHolderAuditListPageIndex.Controls.Clear()

			'initial module list
			'default option
			myListItem = New ListItem
			myListItem.Value = "0"
			myListItem.Text = "全部模組"
			DropDownListModule.Items.Add(myListItem)

			nav = doc.CreateNavigator()
			'searchString = "//treenode[@id='N_2']"
			searchString = "//treenode/treenode/treenode/treenode"
			expr = nav.Compile(searchString)
			iterator = nav.Select(expr)
			If iterator.Count > 0 Then
				While iterator.MoveNext
					nav2 = iterator.Current.Clone
					myListItem = New ListItem
					'get module id
					tempString = nav2.GetAttribute("id", "").Trim
					If tempString <> "" Then
						tempArray = tempString.Split(delimiter)
						If tempArray.Length = 2 Then
							myModuleID = CType(tempArray(1), Integer)
							myListItem.Value = CType(myModuleID, String)
						Else
							'exception:treenode id format error
						End If
					End If
					'get module name
					tempString = nav2.GetAttribute("text", "").Trim
					'If tempString <> "" Then
					'	tempArray = tempString.Split(delimiter)
					'	If tempArray.Length = 2 Then
					'		myModuleName = CType(tempArray(1), String)
					'		myListItem.Text = myModuleName
					'	Else
					'		'exception:treenode id format error
					'	End If
					'End If
					myListItem.Text = tempString

					DropDownListModule.Items.Add(myListItem)

				End While
			End If

			'myAuditDataSet = myAuditDAO.GetEntitys(sid, moduleId)

			'DataList1.DataSource = myAuditDataSet
			'DataList1.DataBind()
		End Sub

		Private Function getCurrentXmlfile(ByVal userID As String) As String
			Dim treeFile1 As String

			Dim fls() As String = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/User"), userID & "*.xml")

			If UBound(fls) < 1 Then
				'exception:no domain xml file
			End If

			treeFile1 = (fls(UBound(fls)))
			Return treeFile1
		End Function


		Private Sub PageLoad()
			Dim myAuditDAO As New Portal_AuditDAOExtand
			Dim myAuditDataSet As DataSet
			Dim myHyperLink As HyperLink
			'Dim myHyperLinkControl As System.Web.UI.HtmlControls.HtmlAnchor
			Dim myLabel As Label
			Dim myHtmlTable As HtmlTable
			Dim myHtmlTableRow As HtmlTableRow
			Dim myHtmlTableCell As HtmlTableCell
			Dim myDataColumn As DataColumn
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalAuditListPage
			Dim myUserName As String = ""
			Dim myLevelID As Integer = LevelType.info
			Dim myActionType As Integer = ActionType.all
			Dim myLevelType As Integer = LevelType.info
			Dim myStartTime As Date = New Date(1900, 1, 1)
			Dim myEndTime As Date = New Date(2100, 1, 1)
			Dim delimStr As String = "/-:. _"
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myListItem As ListItem
			Dim myModuleID As Integer = 0
			Dim myModuleName As String = ""
			Dim myActionName As String = ""

			myUserName = TextBoxUserName.Text.Trim
			queryUserName = myUserName
			If RadioButtonInsert.Checked Then
				myActionType = ActionType.insert
			End If
			If RadioButtonUpdate.Checked Then
				myActionType = ActionType.update
			End If
			If RadioButtonDelete.Checked Then
				myActionType = ActionType.delete
			End If
			If RadioButtonAll.Checked Then
				myActionType = ActionType.all
			End If
			queryActionID = myActionType
			queryLevelID = myLevelType
			tempString = TextBoxStartTime.Text.Trim
			If tempString <> "" Then
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 6 Then
					myStartTime = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer), CType(tempArray(3), Integer), CType(tempArray(4), Integer), CType(tempArray(5), Integer))
				Else
					'exception:start time format error
				End If
			End If
			queryStartTime = myStartTime
			tempString = TextBoxEndTime.Text.Trim
			If tempString <> "" Then
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 6 Then
					myEndTime = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer), CType(tempArray(3), Integer), CType(tempArray(4), Integer), CType(tempArray(5), Integer))
				Else
					'exception:start time format error
				End If
			End If
			queryEndTime = myEndTime
			myListItem = DropDownListModule.SelectedItem
			myModuleID = CType(myListItem.Value, Integer)
			queryModuleID = myModuleID

			'initial Audit page 
			myAuditDataSet = myAuditDAO.GetEntitys("", myModuleID, myLevelID, myActionType, myUserName, myStartTime, myEndTime, pageSize * currentAuditListPage)
			myDataColumn = New DataColumn("ModuleName")
			myAuditDataSet.Tables(0).Columns.Add(myDataColumn)
			myDataColumn = New DataColumn("ActionName")
			myAuditDataSet.Tables(0).Columns.Add(myDataColumn)

			LinkButtonAuditListPageDown.Visible = False
			LinkButtonAuditListTenPageDown.Visible = False
			LinkButtonAuditListPageUp.Visible = False
			LinkButtonAuditListTenPageUp.Visible = False

			If myAuditDataSet.Tables(0).Rows.Count > 0 Then

				'page
				If currentAuditListPage > 1 Then
					For i = 0 To currentAuditListPage - 2
						For j = 0 To pageSize - 1
							myAuditDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				If currentAuditListPage < totalAuditListPage Then
					LinkButtonAuditListPageDown.Visible = True
				Else
					LinkButtonAuditListPageDown.Visible = False
				End If
				If currentAuditListPage < totalAuditListPage - 9 Then
					LinkButtonAuditListTenPageDown.Visible = True
				Else
					LinkButtonAuditListTenPageDown.Visible = False
				End If
				If currentAuditListPage > 1 Then
					LinkButtonAuditListPageUp.Visible = True
				Else
					LinkButtonAuditListPageUp.Visible = False
				End If
				If currentAuditListPage > 10 Then
					LinkButtonAuditListTenPageUp.Visible = True
				Else
					LinkButtonAuditListTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentAuditListPage - 4
				highBound = currentAuditListPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalAuditListPage)
				Else
					If highBound > totalAuditListPage Then
						highBound = totalAuditListPage
						lowBound = Max(totalAuditListPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentAuditListPage Then
						myLabel = New Label
						myLabel.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						'myHyperLinkControl = New System.Web.UI.HtmlControls.HtmlAnchor
						'myHyperLinkControl.InnerText = "[" & CType(i, String) & "]"
						'myHyperLinkControl.HRef = "~/DesktopModules/Audit/AuditList.aspx?mid=" & moduleId & "&sid=" & sid & "&currentauditlistpage=" & CType(i, String) & "&totalauditlistpage=" & totalAuditListPage & "&tabindex=" & tabIndex
						myHyperLink = New HyperLink
						myHyperLink.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myHyperLink.Text = "[" & CType(i, String) & "]"
						myHyperLink.NavigateUrl = "~/DesktopModules/Audit/AuditList.aspx?mid=" & moduleId & "&sid=" & sid & "&currentauditlistpage=" & CType(i, String) & "&totalauditlistpage=" & totalAuditListPage & "&tabindex=" & tabIndex & "&tabid=" & tabId
						myHyperLink.NavigateUrl = myHyperLink.NavigateUrl & "&queryusername=" & queryUserName
						myHyperLink.NavigateUrl = myHyperLink.NavigateUrl & "&querylevelid=" & queryLevelID
						myHyperLink.NavigateUrl = myHyperLink.NavigateUrl & "&queryactionid=" & queryActionID
						myHyperLink.NavigateUrl = myHyperLink.NavigateUrl & "&querymoduleid=" & queryModuleID
						myHyperLink.NavigateUrl = myHyperLink.NavigateUrl & "&queryschoolid=" & querySchoolID
						myHyperLink.NavigateUrl = myHyperLink.NavigateUrl & "&querystarttime=" & queryStartTime.Year & "/" & queryStartTime.Month & "/" & queryStartTime.Day & "/" & queryStartTime.Hour & "/" & queryStartTime.Minute & "/" & queryStartTime.Second
						myHyperLink.NavigateUrl = myHyperLink.NavigateUrl & "&queryendtime=" & queryEndTime.Year & "/" & queryEndTime.Month & "/" & queryEndTime.Day & "/" & queryEndTime.Hour & "/" & queryEndTime.Minute & "/" & queryEndTime.Second
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderAuditListPageIndex.Controls.Add(myHtmlTable)

				'prepare Audit list and user data
				If myAuditDataSet.Tables(0).Rows.Count > 0 Then
					For i = (currentAuditListPage - 1) * pageSize To myAuditDataSet.Tables(0).Rows.Count - 1
						myModuleID = CType(myAuditDataSet.Tables(0).Rows(i).Item("ModuleID"), Integer)
						myActionType = CType(myAuditDataSet.Tables(0).Rows(i).Item("ActionID"), Integer)

						If myModuleID <> 0 Then
							myModuleName = myAuditDAO.GetModuleName(myModuleID)
						Else
							myModuleName = ""
						End If

						myActionName = ""
						If myActionType = ActionType.insert Then
							myActionName = "新增"
						End If
						If myActionType = ActionType.update Then
							myActionName = "修改"
						End If
						If myActionType = ActionType.delete Then
							myActionName = "刪除"
						End If

						myAuditDataSet.Tables(0).Rows(i).Item("ModuleName") = myModuleName
						myAuditDataSet.Tables(0).Rows(i).Item("ActionName") = myActionName
					Next
				End If

			Else
				'exception
			End If
			DataList1.DataSource = myAuditDataSet
			DataList1.DataBind()
		End Sub
		Sub PageReload()
			Dim myAuditDAO As New ASPNET.StarterKit.Portal.Portal_AuditDAOExtand
			Dim rowCount As Integer

			'
			rowCount = myAuditDAO.GetTotalRow(sid, moduleId)
			If rowCount Mod pageSize = 0 Then
				totalAuditListPage = CType(rowCount \ pageSize, Integer)
			Else
				totalAuditListPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentAuditListPage = 1

			ViewState("AuditListTotalAuditListPage") = totalAuditListPage
			ViewState("AuditListCurrentAuditListPage") = currentAuditListPage

			PageLoad()
		End Sub

		Private Sub LinkButtonAuditListPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonAuditListPageUp.Click
			currentAuditListPage = currentAuditListPage - 1
			If currentAuditListPage < 1 Then
				currentAuditListPage = 1
			End If
			ViewState("AuditListCurrentAuditListPage") = currentAuditListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonAuditListPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonAuditListPageDown.Click
			currentAuditListPage = currentAuditListPage + 1
			If currentAuditListPage > totalAuditListPage Then
				currentAuditListPage = totalAuditListPage
			End If
			ViewState("AuditListCurrentAuditListPage") = currentAuditListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonAuditListTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonAuditListTenPageUp.Click
			currentAuditListPage = currentAuditListPage - 10
			If currentAuditListPage < 1 Then
				currentAuditListPage = 1
			End If
			ViewState("AuditListCurrentAuditListPage") = currentAuditListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonAuditListTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonAuditListTenPageDown.Click
			currentAuditListPage = currentAuditListPage + 10
			If currentAuditListPage > totalAuditListPage Then
				currentAuditListPage = totalAuditListPage
			End If
			ViewState("AuditListCurrentAuditListPage") = currentAuditListPage
			PageLoad()
		End Sub

		Protected Sub ShowAudit(ByVal Sender As Object, ByVal e As DataListCommandEventArgs)
			Dim dk As String = ""
			dk = CType(DataList1.DataKeys(e.Item.ItemIndex), String)
			Response.Redirect("~/DesktopModules/Audit/AuditShow.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&auditid=" & dk & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub ButtonQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuery.Click
			Dim myAuditDAO As New Portal_AuditDAOExtand
			Dim myAuditDataSet As DataSet
			Dim myUserName As String = ""
			Dim myActionType As Integer = 0
			Dim myLevelType As Integer = LevelType.info
			Dim myStartTime As Date = New Date(1900, 1, 1)
			Dim myEndTime As Date = New Date(2100, 1, 1)
			Dim myListItem As ListItem
			Dim myModuleID As Integer = 0
			Dim i As Integer = 0
			Dim delimStr As String = "/-:. _"
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim rowCount As Integer = 0

			myUserName = TextBoxUserName.Text.Trim
			queryUserName = myUserName
			If RadioButtonInsert.Checked = True Then
				myActionType = ActionType.insert
			End If
			If RadioButtonUpdate.Checked Then
				myActionType = ActionType.update
			End If
			If RadioButtonDelete.Checked Then
				myActionType = ActionType.delete
			End If
			If RadioButtonAll.Checked Then
				myActionType = ActionType.all
			End If
			queryActionID = myActionType
			If DropDownListModule.Items.Count > 0 Then
				myListItem = DropDownListModule.SelectedItem
				If Not (myListItem Is Nothing) Then
					myModuleID = CType(myListItem.Value, Integer)
				End If
			End If
			queryModuleID = myModuleID
			tempString = TextBoxStartTime.Text.Trim
			If tempString <> "" Then
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 6 Then
					myStartTime = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer), CType(tempArray(3), Integer), CType(tempArray(4), Integer), CType(tempArray(5), Integer))
				Else
					'exception:start time format error
				End If
			End If
			queryStartTime = myStartTime
			tempString = TextBoxEndTime.Text.Trim
			If tempString <> "" Then
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 6 Then
					myEndTime = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer), CType(tempArray(3), Integer), CType(tempArray(4), Integer), CType(tempArray(5), Integer))
				Else
					'exception:start time format error
				End If
			End If
			queryEndTime = myEndTime

			queryLevelID = LevelType.info

			'initial Audit page 
			myAuditDataSet = myAuditDAO.GetEntitys("", queryModuleID, queryLevelID, queryActionID, queryUserName, queryStartTime, queryEndTime)

			rowCount = myAuditDataSet.Tables(0).Rows.Count
			If rowCount Mod pageSize = 0 Then
				totalAuditListPage = CType(rowCount \ pageSize, Integer)
			Else
				totalAuditListPage = CType(rowCount \ pageSize + 1, Integer)
			End If

			currentAuditListPage = 1

			ViewState("AuditListTotalAuditListPage") = totalAuditListPage
			ViewState("AuditListCurrentAuditListPage") = currentAuditListPage

			ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
			PageLoad()

		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageInit()
		End Sub
	End Class
End Namespace