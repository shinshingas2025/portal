Imports System
Imports System.IO
Imports System.Math
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module
	Public Class PolicyMeetingRecordList
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonEntityListTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonEntityListPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderEntityListPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonEntityListPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonEntityListTenPageDown As System.Web.UI.WebControls.LinkButton

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
		Private Const CodeAuthorityTarget As String = "NormalCode"
		Private UtilityObject As New AuditSystemUtility

		Protected pageSize As Integer = 10
		Protected totalEntityListPage As Integer = 0
		Protected currentEntityListPage As Integer = 0
		Private returnObjectID As String = ""

		Private Const PolicyMeetingRecordCodeGroupID As String = "200601010000000900000011"

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			Dim rowCount As Integer = 0
			Dim i As Integer = 0
			Dim myEntityDAO As New MeetingRecordDAOExtand
			Dim myEntityDataSet As DataSet

			If Not (Request.Params("ReturnObjectID") Is Nothing) Then
				returnObjectID = Request.Params("ReturnObjectID")
			End If

			If Not IsPostBack Then
				'manage page
				myEntityDataSet = myEntityDAO.GetEntitysByTypeID(PolicyMeetingRecordCodeGroupID)
				myEntityDataSet = UtilityObject.QueryPermissionFilter(myEntityDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
				rowCount = myEntityDataSet.Tables(0).Rows.Count

				If rowCount Mod pageSize = 0 Then
					totalEntityListPage = CType(rowCount \ pageSize, Integer)
				Else
					totalEntityListPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("CurrentEntityListPage") Is Nothing) Then
					currentEntityListPage = CType(Request.Params("CurrentEntityListPage"), Integer)
					ViewState("EntityListCurrentEntityListPage") = currentEntityListPage
				Else
					currentEntityListPage = 1
				End If

				ViewState("EntityListTotalEntityListPage") = totalEntityListPage
				ViewState("EntityListCurrentEntityListPage") = currentEntityListPage

				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			Else
				totalEntityListPage = CType(ViewState("EntityListTotalEntityListPage"), Integer)
				currentEntityListPage = CType(ViewState("EntityListCurrentEntityListPage"), Integer)
			End If
		End Sub
		Private Sub PageLoad()
			Dim myHyperLink As HyperLink
			Dim myLabel As Label
			Dim myHtmlTable As HtmlTable
			Dim myHtmlTableRow As HtmlTableRow
			Dim myHtmlTableCell As HtmlTableCell
			Dim myDataColumn As DataColumn
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalEntityListPage
			Dim myEntityDAO As New MeetingRecordDAOExtand
			Dim myEntityDataSet As DataSet
			Dim myEntityID As String = ""
			Dim myEntityDate As Date = New Date(1900, 1, 1)
			Dim myEmptyDate As Date = New Date(1900, 1, 1)

			myEntityDataSet = myEntityDAO.GetEntitysByTypeID(PolicyMeetingRecordCodeGroupID)
			myEntityDataSet = UtilityObject.QueryPermissionFilter(myEntityDataSet, RecordAuthorityTarget, Context.User.Identity.Name, pageSize * currentEntityListPage)

			myDataColumn = New DataColumn("MeetingDateString")
			myEntityDataSet.Tables(0).Columns.Add(myDataColumn)

			LinkButtonEntityListPageDown.Visible = False
			LinkButtonEntityListTenPageDown.Visible = False
			LinkButtonEntityListPageUp.Visible = False
			LinkButtonEntityListTenPageUp.Visible = False

			If myEntityDataSet.Tables(0).Rows.Count > 0 Then

				'page
				If currentEntityListPage > 1 Then
					For i = 0 To currentEntityListPage - 2
						For j = 0 To pageSize - 1
							myEntityDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				If currentEntityListPage < totalEntityListPage Then
					LinkButtonEntityListPageDown.Visible = True
				Else
					LinkButtonEntityListPageDown.Visible = False
				End If
				If currentEntityListPage < totalEntityListPage - 9 Then
					LinkButtonEntityListTenPageDown.Visible = True
				Else
					LinkButtonEntityListTenPageDown.Visible = False
				End If
				If currentEntityListPage > 1 Then
					LinkButtonEntityListPageUp.Visible = True
				Else
					LinkButtonEntityListPageUp.Visible = False
				End If
				If currentEntityListPage > 10 Then
					LinkButtonEntityListTenPageUp.Visible = True
				Else
					LinkButtonEntityListTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentEntityListPage - 4
				highBound = currentEntityListPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalEntityListPage)
				Else
					If highBound > totalEntityListPage Then
						highBound = totalEntityListPage
						lowBound = Max(totalEntityListPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentEntityListPage Then
						myLabel = New Label
						myLabel.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						myHyperLink = New HyperLink
						myHyperLink.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myHyperLink.Text = "[" & CType(i, String) & "]"
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/PolityMeetingRecordList.aspx?ReturnObjectID=" & returnObjectID & "&CurrentEntityListPage=" & CType(i, String)
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderEntityListPageIndex.Controls.Add(myHtmlTable)

				'prepare entity data
				If myEntityDataSet.Tables(0).Rows.Count > 0 Then
					For i = (currentEntityListPage - 1) * pageSize To myEntityDataSet.Tables(0).Rows.Count - 1
						myEntityID = CType(myEntityDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						'meeting date string
						myEntityDate = CType(myEntityDataSet.Tables(0).Rows(i).Item("MeetingDate"), Date)
						If myEntityDate = myEmptyDate Then
							myEntityDataSet.Tables(0).Rows(i).Item("MeetingDateString") = ""
						Else
							myEntityDataSet.Tables(0).Rows(i).Item("MeetingDateString") = myEntityDate.Year & "/" & myEntityDate.Month & "/" & myEntityDate.Day
						End If
					Next
				End If
			Else
				'exception
			End If
			DataList1.DataSource = myEntityDataSet
			DataList1.DataBind()
		End Sub
		Sub PageReload()
			Dim myEntityDAO As New MeetingRecordDAOExtand
			Dim myEntityDataSet As DataSet
			Dim rowCount As Integer

			'
			myEntityDataSet = myEntityDAO.GetEntitysByTypeID(PolicyMeetingRecordCodeGroupID)
			myEntityDataSet = UtilityObject.QueryPermissionFilter(myEntityDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
			rowCount = myEntityDataSet.Tables(0).Rows.Count

			If rowCount Mod pageSize = 0 Then
				totalEntityListPage = CType(rowCount \ pageSize, Integer)
			Else
				totalEntityListPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentEntityListPage = 1

			ViewState("EntityListTotalEntityListPage") = totalEntityListPage
			ViewState("EntityListCurrentEntityListPage") = currentEntityListPage

			PageLoad()
		End Sub

		Private Sub LinkButtonEntityListPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonEntityListPageUp.Click
			currentEntityListPage = currentEntityListPage - 1
			If currentEntityListPage < 1 Then
				currentEntityListPage = 1
			End If
			ViewState("EntityListCurrentEntityListPage") = currentEntityListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonEntityListPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			currentEntityListPage = currentEntityListPage + 1
			If currentEntityListPage > totalEntityListPage Then
				currentEntityListPage = totalEntityListPage
			End If
			ViewState("EntityListCurrentEntityListPage") = currentEntityListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonEntityListTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonEntityListTenPageUp.Click
			currentEntityListPage = currentEntityListPage - 10
			If currentEntityListPage < 1 Then
				currentEntityListPage = 1
			End If
			ViewState("EntityListCurrentEntityListPage") = currentEntityListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonEntityListTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			currentEntityListPage = currentEntityListPage + 10
			If currentEntityListPage > totalEntityListPage Then
				currentEntityListPage = totalEntityListPage
			End If
			ViewState("EntityListCurrentEntityListPage") = currentEntityListPage
			PageLoad()
		End Sub

		Protected Sub DataList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataList1.SelectedIndexChanged
			Dim isSelect As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			Dim script As String = ""
			For Each anItem In DataList1.Items
				isSelect = CType(anItem.FindControl("RadioButton1"), RadioButton).Checked
				If isSelect Then
					If returnObjectID.Trim.Length > 0 Then
						dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
						script = "<script>" & vbCrLf
						script += "opener.Form1." & returnObjectID & ".value='" & dk & "';" & vbCrLf
						script += "close();" & vbCrLf
						script += "</script>" & vbCrLf
						Response.Write(script)
					End If
					CType(anItem.FindControl("RadioButton1"), RadioButton).Checked = False
				End If
			Next
			PageLoad()
		End Sub
	End Class
End Namespace
