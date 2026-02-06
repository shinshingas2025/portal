Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal


	Public Class ExportUser
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonExportUserTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonExportUserPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderExportUserPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonExportUserPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonExportUserTenPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonExportUser As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents LabelTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label
		Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
		Protected WithEvents RadioButton1 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButton2 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButton3 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents Radiobutton4 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents ButtonQuery As System.Web.UI.WebControls.Button
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
		Protected totalExportUserPage As Integer = 0
		Protected currentExportUserPage As Integer = 0
		Private laborid As Integer = 0
		Dim AuditDAO As New Portal_AuditDAOExtand
		Dim ModuleStatisticDAO As New Portal_ModuleStatisticDAOExtand

		Private APLTBL_TableID As String = "2005120100000001"
		Private APSTBL_TableID As String = "2005120100000003"
		Private O_APSTBL_TableID As String = "2005120100000004"
		Private SCHOOL_ID As String = ""
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

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁()
			'Session("sid") = "9999"
			'If PortalSecurity.IsInRoles("Admins") = False Then
			'    Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If
			Dim rowCount As Integer
			Dim myAPLTBLDAO As New ASPNET.StarterKit.Portal.APLTBLDAOExtand
			Dim mySiteDAO As New Portal_SiteDAOExtand
			Dim mySiteDataSet As DataSet
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

			If Not (Request.Params("laborid") Is Nothing) Then
				laborid = Int32.Parse(Request.Params("laborid"))
			End If

			mySiteDataSet = mySiteDAO.GetEntitys(sid)
			If mySiteDataSet.Tables(0).Rows.Count = 1 Then
				SCHOOL_ID = CType(mySiteDataSet.Tables(0).Rows(0).Item("SchoolCode"), String)
			Else
				'exception:site record is empty or duplicated
			End If

			If Not IsPostBack Then
				'manage Bulletin page 
				rowCount = myAPLTBLDAO.GetTotalRow(SCHOOL_ID)
				If rowCount Mod pageSize = 0 Then
					totalExportUserPage = CType(rowCount \ pageSize, Integer)
				Else
					totalExportUserPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("currentexportuserpage") Is Nothing) Then
					currentExportUserPage = CType(Request.Params("currentexportuserpage"), Integer)
					ViewState("ExportUserCurrentExportUserPage") = currentExportUserPage
				Else
					currentExportUserPage = 1
				End If

				ViewState("ExportUserTotalExportUserPage") = totalExportUserPage
				ViewState("ExportUserCurrentExportUserPage") = currentExportUserPage

				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			Else
				totalExportUserPage = CType(ViewState("ExportUserTotalExportUserPage"), Integer)
				currentExportUserPage = CType(ViewState("ExportUserCurrentExportUserPage"), Integer)
			End If
		End Sub

		Private Sub PageLoad()
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim myExportDataSet As DataSet
			Dim myAPLTBLDataSet As DataSet
			Dim myLaborID As String
			Dim myHyperLink As HyperLink
			Dim myLabel As Label
			Dim myHtmlTable As HtmlTable
			Dim myHtmlTableRow As HtmlTableRow
			Dim myHtmlTableCell As HtmlTableCell
			Dim myEDGR As String = ""
			Dim myGRADU As String = ""
			'Dim myTitle As String = ""
			'Dim myAnnounceUnit As String = ""
			'Dim myDataColumn As DataColumn
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalExportUserPage
			myExportDataSet = myExportDAO.GetEntitys(sid, moduleId)
			If myExportDataSet.Tables(0).Rows.Count = 1 Then
				LabelTitle.Text = CType(myExportDataSet.Tables(0).Rows(0).Item("Title"), String)
				LabelDescription.Text = CType(myExportDataSet.Tables(0).Rows(0).Item("Description"), String)
			Else
				'exception:import record is empty or duplicated
			End If

			'get user options
			myEDGR = DropDownList1.SelectedValue.Trim
			If RadioButton1.Checked Then
				myGRADU = "1"
			End If
			If RadioButton2.Checked Then
				myGRADU = "2"
			End If
			If RadioButton3.Checked Then
				myGRADU = "3"
			End If
			If Radiobutton4.Checked Then
				myGRADU = "4"
			End If

			'myAPLTBLDataSet = myAPLTBLDAO.GetEntitysByRowCount(pageSize * currentExportUserPage)
			myAPLTBLDataSet = myAPLTBLDAO.GetEntitysByRowCount(myEDGR, myGRADU, SCHOOL_ID, pageSize * currentExportUserPage)
			'myDataColumn = New DataColumn("Title")
			'myBulletinMapDataSet.Tables(0).Columns.Add(myDataColumn)
			'myDataColumn = New DataColumn("AnnounceUnit")
			'myBulletinMapDataSet.Tables(0).Columns.Add(myDataColumn)

			LinkButtonExportUserPageDown.Visible = False
			LinkButtonExportUserTenPageDown.Visible = False
			LinkButtonExportUserPageUp.Visible = False
			LinkButtonExportUserTenPageUp.Visible = False

			If myAPLTBLDataSet.Tables(0).Rows.Count > 0 Then

				'page
				If currentExportUserPage > 1 Then
					For i = 0 To currentExportUserPage - 2
						For j = 0 To pageSize - 1
							myAPLTBLDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				If currentExportUserPage < totalExportUserPage Then
					LinkButtonExportUserPageDown.Visible = True
				Else
					LinkButtonExportUserPageDown.Visible = False
				End If
				If currentExportUserPage < totalExportUserPage - 9 Then
					LinkButtonExportUserTenPageDown.Visible = True
				Else
					LinkButtonExportUserTenPageDown.Visible = False
				End If
				If currentExportUserPage > 1 Then
					LinkButtonExportUserPageUp.Visible = True
				Else
					LinkButtonExportUserPageUp.Visible = False
				End If
				If currentExportUserPage > 10 Then
					LinkButtonExportUserTenPageUp.Visible = True
				Else
					LinkButtonExportUserTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentExportUserPage - 4
				highBound = currentExportUserPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalExportUserPage)
				Else
					If highBound > totalExportUserPage Then
						highBound = totalExportUserPage
						lowBound = Max(totalExportUserPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentExportUserPage Then
						myLabel = New Label
						myLabel.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						myHyperLink = New HyperLink
						myHyperLink.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myHyperLink.Text = "[" & CType(i, String) & "]"
						myHyperLink.NavigateUrl = "~/DesktopModules/ImportExport/ExportUser.aspx?mid=" & moduleId & "&sid=" & sid & "&currentexportuserpage=" & CType(i, String) & "&tabindex=" & tabIndex & "&tabid=" & tabId
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderExportUserPageIndex.Controls.Add(myHtmlTable)

				''prepare Bulletin list and user data
				'If myBulletinMapDataSet.Tables(0).Rows.Count > 0 Then
				'	For i = (currentExportUserPage - 1) * pageSize To myBulletinMapDataSet.Tables(0).Rows.Count - 1
				'		myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(i).Item("BulletinID"), String).Trim
				'		If myBulletinID.Length > 0 Then
				'			myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
				'			If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
				'				myTitle = CType(myBulletinDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
				'				myAnnounceUnit = CType(myBulletinDataSet.Tables(0).Rows(0).Item("AnnounceUnit"), String).Trim
				'				myBulletinMapDataSet.Tables(0).Rows(i).Item("Title") = myTitle
				'				myBulletinMapDataSet.Tables(0).Rows(i).Item("AnnounceUnit") = myAnnounceUnit
				'			Else
				'				'exception:Bulletin data is empty or duplicated
				'			End If
				'		Else
				'			'exception:bulletin id is empty
				'		End If
				'	Next
				'End If

			Else
				'exception
			End If
			DataList1.DataSource = myAPLTBLDataSet
			DataList1.DataBind()
		End Sub
		Sub PageReload()
			Dim myAPLTBLDAO As New ASPNET.StarterKit.Portal.APLTBLDAOExtand
			Dim myEDGR As String = ""
			Dim myGRADU As String = ""
			Dim rowCount As Integer

			'get user options
			myEDGR = DropDownList1.SelectedValue.Trim
			If RadioButton1.Checked Then
				myGRADU = "1"
			End If
			If RadioButton2.Checked Then
				myGRADU = "2"
			End If
			If RadioButton3.Checked Then
				myGRADU = "3"
			End If
			If Radiobutton4.Checked Then
				myGRADU = "4"
			End If
			'
			rowCount = myAPLTBLDAO.GetTotalRow(myEDGR, myGRADU, SCHOOL_ID)
			If rowCount Mod pageSize = 0 Then
				totalExportUserPage = CType(rowCount \ pageSize, Integer)
			Else
				totalExportUserPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentExportUserPage = 1

			ViewState("ExportUserTotalExportUserPage") = totalExportUserPage
			ViewState("ExportUserCurrentExportUserPage") = currentExportUserPage

			PageLoad()
		End Sub

		Private Sub LinkButtonExportUserPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonExportUserPageUp.Click
			currentExportUserPage = currentExportUserPage - 1
			If currentExportUserPage < 1 Then
				currentExportUserPage = 1
			End If
			ViewState("ExportUserCurrentExportUserPage") = currentExportUserPage
			PageLoad()
		End Sub

		Private Sub LinkButtonExportUserPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonExportUserPageDown.Click
			currentExportUserPage = currentExportUserPage + 1
			If currentExportUserPage > totalExportUserPage Then
				currentExportUserPage = totalExportUserPage
			End If
			ViewState("ExportUserCurrentExportUserPage") = currentExportUserPage
			PageLoad()
		End Sub

		Private Sub LinkButtonExportUserTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonExportUserTenPageUp.Click
			currentExportUserPage = currentExportUserPage - 10
			If currentExportUserPage < 1 Then
				currentExportUserPage = 1
			End If
			ViewState("ExportUserCurrentExportUserPage") = currentExportUserPage
			PageLoad()
		End Sub

		Private Sub LinkButtonExportUserTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonExportUserTenPageDown.Click
			currentExportUserPage = currentExportUserPage + 10
			If currentExportUserPage > totalExportUserPage Then
				currentExportUserPage = totalExportUserPage
			End If
			ViewState("ExportUserCurrentExportUserPage") = currentExportUserPage
			PageLoad()
		End Sub

		'Private Sub DataList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataList1.SelectedIndexChanged
		'	Dim isView As Boolean
		'	Dim anItem As DataListItem
		'	Dim dk As String
		'	For Each anItem In DataList1.Items
		'		'isView = CType(anItem.FindControl("Button1"), Button).Controls.
		'		If isView Then
		'			dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
		'			Response.Redirect("~/DesktopModules/ImportExport/ExportUser.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&laborid=" & dk)
		'		End If
		'	Next
		'End Sub
		'Protected Sub ShowBulletin(ByVal Sender As Object, ByVal e As DataListCommandEventArgs)
		'	Dim dk As String = ""
		'	dk = CType(DataList1.DataKeys(e.Item.ItemIndex), String)
		'	Response.Redirect("~/DesktopModules/Bulletin/BulletinShow.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&bulletinmapid=" & dk)
		'End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub

		Private Sub ButtonExportUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportUser.Click
			Dim isExport As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			Dim download_path As String = Server.MapPath("/PortalFiles/DownLoadFiles/xml")
			Dim redirect_path As String = "/PortalFiles/DownLoadFiles/xml"
			Dim writer As System.Xml.XmlTextWriter
			Dim identityKey As String = Now.Year & Microsoft.VisualBasic.Right("00" & Now.Month, 2) & Microsoft.VisualBasic.Right("00" & Now.Day, 2) & Microsoft.VisualBasic.Right("00" & Now.Hour, 2) & Microsoft.VisualBasic.Right("00" & Now.Minute, 2) & Microsoft.VisualBasic.Right("00" & Now.Second, 2) & Microsoft.VisualBasic.Right("000" & Now.Millisecond, 3) & Microsoft.VisualBasic.Right("00000" & sid, 5) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(moduleId)), 8)
			Dim physicalFileName As String = download_path & "/" & identityKey & "ExportUser.xml"
			Dim redirectFileName As String = redirect_path & "/" & identityKey & "ExportUser.xml"
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim myAPSTBLDAO As New APSTBLDAOExtand
			Dim myO_APSTBLDAO As New O_APSTBLDAOExtand
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myExportColumnDAO As New Portal_ExportColumnDAOExtand
			Dim myAPLTBLDataSet As DataSet
			Dim myAPSTBLDataSet As DataSet
			Dim myO_APSTBLDataSet As DataSet
			Dim myExportDataSet As DataSet
			Dim myExportColumnDataSet As DataSet
			Dim myExportID As String = ""
			Dim i As Integer = 0
			Dim columnName As String = ""
			'clear old file
			If File.Exists(physicalFileName) Then
				File.Delete(physicalFileName)
				'audit
				AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", physicalFileName, "", Context.User.Identity.Name, Now)
			End If
			'create xml file
			writer = New System.Xml.XmlTextWriter(physicalFileName, System.Text.Encoding.Default)
			writer.Formatting = System.Xml.Formatting.Indented
			'audit
			AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, writer.ToString, "New", physicalFileName, "", Context.User.Identity.Name, Now)
			'header of xml file
			writer.WriteStartDocument()
			'start of root tag
			writer.WriteStartElement("ExportUser", "")

			'read export id
			myExportDataSet = myExportDAO.GetEntitys(sid, moduleId)
			If myExportDataSet.Tables(0).Rows.Count = 1 Then
				myExportID = CType(myExportDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				For Each anItem In DataList1.Items
					isExport = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
					If isExport Then
						dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
						'start of tag:LABOR
						writer.WriteStartElement("LABOR", "")
						writer.WriteAttributeString("LABOR_ID", "", dk)
						'start of tag:APLTBL
						writer.WriteStartElement("APLTBL", "")
						'read apltbl record
						myExportColumnDataSet = myExportColumnDAO.GetEntitysByExportIDAndTableID(myExportID, APLTBL_TableID)
						If myExportColumnDataSet.Tables(0).Rows.Count > 0 Then
							myAPLTBLDataSet = myAPLTBLDAO.GetEntitys(CType(dk, Integer), myExportColumnDataSet)
							If myAPLTBLDataSet.Tables(0).Rows.Count = 1 Then
								For i = 0 To myAPLTBLDataSet.Tables(0).Columns.Count - 1
									columnName = myAPLTBLDataSet.Tables(0).Columns(i).ColumnName
									'start of tag
									writer.WriteStartElement(columnName, "")
									'content of tag
									If myAPLTBLDataSet.Tables(0).Rows(0).Item(columnName) Is DBNull.Value Then
										writer.WriteString("")
									Else
										writer.WriteString(CType(myAPLTBLDataSet.Tables(0).Rows(0).Item(columnName), String))
									End If
									'end of tag
									writer.WriteEndElement()
								Next
							Else
								'exception:apltbl record is empty or duplicated
							End If
						Else
							'no select and do nothing
						End If
						'end of tag:APLTBL
						writer.WriteEndElement()
						'start of tag:APSTBL
						writer.WriteStartElement("APSTBL", "")
						'read apstbl record
						myExportColumnDataSet = myExportColumnDAO.GetEntitysByExportIDAndTableID(myExportID, APSTBL_TableID)
						If myExportColumnDataSet.Tables(0).Rows.Count > 0 Then
							myAPSTBLDataSet = myAPSTBLDAO.GetEntitys(CType(dk, Integer), CType(dk, Integer), myExportColumnDataSet)
							If myAPSTBLDataSet.Tables(0).Rows.Count = 1 Then
								For i = 0 To myAPSTBLDataSet.Tables(0).Columns.Count - 1
									columnName = myAPSTBLDataSet.Tables(0).Columns(i).ColumnName
									'start of tag
									writer.WriteStartElement(columnName, "")
									'content of tag
									If myAPSTBLDataSet.Tables(0).Rows(0).Item(columnName) Is DBNull.Value Then
										writer.WriteString("")
									Else
										writer.WriteString(CType(myAPSTBLDataSet.Tables(0).Rows(0).Item(columnName), String))
									End If
									'end of tag
									writer.WriteEndElement()
								Next
							Else
								'exception:apltbl record is empty or duplicated
							End If
						Else
							'no select and do nothing
						End If
						'end of tag:APSTBL
						writer.WriteEndElement()
						'start of tag:O_APSTBL
						writer.WriteStartElement("O_APSTBL", "")
						'read o_apstbl record
						myExportColumnDataSet = myExportColumnDAO.GetEntitysByExportIDAndTableID(myExportID, O_APSTBL_TableID)
						If myExportColumnDataSet.Tables(0).Rows.Count > 0 Then
							myO_APSTBLDataSet = myO_APSTBLDAO.GetEntitys(CType(dk, Integer), CType(dk, Integer), myExportColumnDataSet)
							If myO_APSTBLDataSet.Tables(0).Rows.Count = 1 Then
								For i = 0 To myO_APSTBLDataSet.Tables(0).Columns.Count - 1
									columnName = myO_APSTBLDataSet.Tables(0).Columns(i).ColumnName
									'start of tag
									writer.WriteStartElement(columnName, "")
									'content of tag
									If myO_APSTBLDataSet.Tables(0).Rows(0).Item(columnName) Is DBNull.Value Then
										writer.WriteString("")
									Else
										writer.WriteString(CType(myO_APSTBLDataSet.Tables(0).Rows(0).Item(columnName), String))
									End If
									'end of tag
									writer.WriteEndElement()
								Next
							Else
								'exception:apltbl record is empty or duplicated
							End If
						Else
							'no select and do nothing
						End If
						'end of tag:O_APSTBL
						writer.WriteEndElement()
						'end of tag:LABOR
						writer.WriteEndElement()
						'statistic
						ModuleStatisticDAO.InsertEntity(sid, moduleId, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, Now)
					End If
				Next
			Else
				If myExportDataSet.Tables(0).Rows.Count > 1 Then
					'exception:export record is duplicated
				Else
					'exception:export record is empty
				End If
			End If

			'end of root tag
			writer.WriteEndElement()
			writer.WriteEndDocument()
			writer.Close()

			Response.Redirect(redirectFileName)
		End Sub

		Private Sub ButtonQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuery.Click
			PageReload()
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