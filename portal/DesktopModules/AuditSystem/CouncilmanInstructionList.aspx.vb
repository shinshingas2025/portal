Imports System
Imports System.IO
Imports System.Math
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module
	Public Class CouncilmanInstructionList
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonInstructionListTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonInstructionListPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderInstructionListPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonInstructionListPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonInstructionListTenPageDown As System.Web.UI.WebControls.LinkButton

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
		Private Const InstructionAuthorityTarget As String = "CouncilmanInstruction"
		Private Const InstructionMemberAuthorityTarget As String = "CouncilmanInstructionCouncilmanMap"
		Private Const CodeAuthorityTarget As String = "NormalCode"
		Private UtilityObject As New AuditSystemUtility

		Protected pageSize As Integer = 10
		Protected totalInstructionListPage As Integer = 0
		Protected currentInstructionListPage As Integer = 0
		Private returnObjectID As String = ""

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			Dim rowCount As Integer = 0
			Dim i As Integer = 0
			Dim myInstructionDAO As New CouncilmanInstructionDAOExtand
			Dim myInstructionDataSet As DataSet

			If Not (Request.Params("ReturnObjectID") Is Nothing) Then
				returnObjectID = Request.Params("ReturnObjectID")
			End If

			If Not IsPostBack Then
				'manage page
				myInstructionDataSet = myInstructionDAO.GetEntitys()
				myInstructionDataSet = UtilityObject.QueryPermissionFilter(myInstructionDataSet, InstructionAuthorityTarget, Context.User.Identity.Name)
				rowCount = myInstructionDataSet.Tables(0).Rows.Count

				If rowCount Mod pageSize = 0 Then
					totalInstructionListPage = CType(rowCount \ pageSize, Integer)
				Else
					totalInstructionListPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("CurrentInstructionListPage") Is Nothing) Then
					currentInstructionListPage = CType(Request.Params("CurrentInstructionListPage"), Integer)
					ViewState("InstructionListCurrentInstructionListPage") = currentInstructionListPage
				Else
					currentInstructionListPage = 1
				End If

				ViewState("InstructionListTotalInstructionListPage") = totalInstructionListPage
				ViewState("InstructionListCurrentInstructionListPage") = currentInstructionListPage

				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			Else
				totalInstructionListPage = CType(ViewState("InstructionListTotalInstructionListPage"), Integer)
				currentInstructionListPage = CType(ViewState("InstructionListCurrentInstructionListPage"), Integer)
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
			Dim highBound As Integer = totalInstructionListPage
			Dim myInstructionDAO As New CouncilmanInstructionDAOExtand
			Dim myInstructionDataSet As DataSet
			Dim myInstructionID As String = ""
			Dim myCouncilmanDAO As New CouncilmanInstructionCouncilmanMapDAOExtand
			Dim myCouncilmanDataSet As DataSet
			Dim myCouncilmanCount As Integer = 0
			Dim myCouncilmanID As String = ""
			Dim myCouncilmanName As String = ""
			Dim myCouncilmanString As String = ""
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myInstructionDate As Date = New Date(1900, 1, 1)
			Dim myEmptyDate As Date = New Date(1900, 1, 1)

			myInstructionDataSet = myInstructionDAO.GetEntitys()
			myInstructionDataSet = UtilityObject.QueryPermissionFilter(myInstructionDataSet, InstructionAuthorityTarget, Context.User.Identity.Name, pageSize * currentInstructionListPage)

			myDataColumn = New DataColumn("Councilman")
			myInstructionDataSet.Tables(0).Columns.Add(myDataColumn)
			myDataColumn = New DataColumn("InstructionDateString")
			myInstructionDataSet.Tables(0).Columns.Add(myDataColumn)

			LinkButtonInstructionListPageDown.Visible = False
			LinkButtonInstructionListTenPageDown.Visible = False
			LinkButtonInstructionListPageUp.Visible = False
			LinkButtonInstructionListTenPageUp.Visible = False

			If myInstructionDataSet.Tables(0).Rows.Count > 0 Then

				'page
				If currentInstructionListPage > 1 Then
					For i = 0 To currentInstructionListPage - 2
						For j = 0 To pageSize - 1
							myInstructionDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				If currentInstructionListPage < totalInstructionListPage Then
					LinkButtonInstructionListPageDown.Visible = True
				Else
					LinkButtonInstructionListPageDown.Visible = False
				End If
				If currentInstructionListPage < totalInstructionListPage - 9 Then
					LinkButtonInstructionListTenPageDown.Visible = True
				Else
					LinkButtonInstructionListTenPageDown.Visible = False
				End If
				If currentInstructionListPage > 1 Then
					LinkButtonInstructionListPageUp.Visible = True
				Else
					LinkButtonInstructionListPageUp.Visible = False
				End If
				If currentInstructionListPage > 10 Then
					LinkButtonInstructionListTenPageUp.Visible = True
				Else
					LinkButtonInstructionListTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentInstructionListPage - 4
				highBound = currentInstructionListPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalInstructionListPage)
				Else
					If highBound > totalInstructionListPage Then
						highBound = totalInstructionListPage
						lowBound = Max(totalInstructionListPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentInstructionListPage Then
						myLabel = New Label
						myLabel.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						myHyperLink = New HyperLink
						myHyperLink.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myHyperLink.Text = "[" & CType(i, String) & "]"
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/CouncilmanInstructionList.aspx?ReturnObjectID=" & returnObjectID & "&CurrentInstructionListPage=" & CType(i, String)
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderInstructionListPageIndex.Controls.Add(myHtmlTable)

				'prepare instruction data
				If myInstructionDataSet.Tables(0).Rows.Count > 0 Then
					For i = (currentInstructionListPage - 1) * pageSize To myInstructionDataSet.Tables(0).Rows.Count - 1
						myInstructionID = CType(myInstructionDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						'councilman
						myCouncilmanString = ""
						myCouncilmanCount = myCouncilmanDAO.GetTotalRowByCouncilmanInstructionID(myInstructionID)
						If myCouncilmanCount > 0 Then
							myCouncilmanDataSet = myCouncilmanDAO.GetEntitysByCouncilmanInstructionID(myInstructionID)
							For j = 0 To myCouncilmanCount - 1
								myCouncilmanID = CType(myCouncilmanDataSet.Tables(0).Rows(j).Item("CouncilmanID"), String)
								myCouncilmanName = myNormalCodeDAO.GetNameByEntityID(myCouncilmanID)

								If j = 0 Then
									myCouncilmanString = myCouncilmanName
								Else
									myCouncilmanString += " " & myCouncilmanName
								End If
							Next
						End If
						myInstructionDataSet.Tables(0).Rows(i).Item("Councilman") = myCouncilmanString
						'instruction date string
						myInstructionDate = CType(myInstructionDataSet.Tables(0).Rows(i).Item("InstructionDate"), Date)
						If myInstructionDate = myEmptyDate Then
							myInstructionDataSet.Tables(0).Rows(i).Item("InstructionDateString") = ""
						Else
							myInstructionDataSet.Tables(0).Rows(i).Item("InstructionDateString") = myInstructionDate.Year & "/" & myInstructionDate.Month & "/" & myInstructionDate.Day
						End If
					Next
				End If
			Else
				'exception
			End If
			DataList1.DataSource = myInstructionDataSet
			DataList1.DataBind()
		End Sub
		Sub PageReload()
			Dim myInstructionDAO As New CouncilmanInstructionDAOExtand
			Dim myInstructionDataSet As DataSet
			Dim rowCount As Integer

			'
			myInstructionDataSet = myInstructionDAO.GetEntitys()
			myInstructionDataSet = UtilityObject.QueryPermissionFilter(myInstructionDataSet, InstructionAuthorityTarget, Context.User.Identity.Name)
			rowCount = myInstructionDataSet.Tables(0).Rows.Count

			If rowCount Mod pageSize = 0 Then
				totalInstructionListPage = CType(rowCount \ pageSize, Integer)
			Else
				totalInstructionListPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentInstructionListPage = 1

			ViewState("InstructionListTotalInstructionListPage") = totalInstructionListPage
			ViewState("InstructionListCurrentInstructionListPage") = currentInstructionListPage

			PageLoad()
		End Sub

		Private Sub LinkButtonInstructionListPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonInstructionListPageUp.Click
			currentInstructionListPage = currentInstructionListPage - 1
			If currentInstructionListPage < 1 Then
				currentInstructionListPage = 1
			End If
			ViewState("InstructionListCurrentInstructionListPage") = currentInstructionListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonInstructionListPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonInstructionListPageDown.Click
			currentInstructionListPage = currentInstructionListPage + 1
			If currentInstructionListPage > totalInstructionListPage Then
				currentInstructionListPage = totalInstructionListPage
			End If
			ViewState("InstructionListCurrentInstructionListPage") = currentInstructionListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonInstructionListTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonInstructionListTenPageUp.Click
			currentInstructionListPage = currentInstructionListPage - 10
			If currentInstructionListPage < 1 Then
				currentInstructionListPage = 1
			End If
			ViewState("InstructionListCurrentInstructionListPage") = currentInstructionListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonInstructionListTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonInstructionListTenPageDown.Click
			currentInstructionListPage = currentInstructionListPage + 10
			If currentInstructionListPage > totalInstructionListPage Then
				currentInstructionListPage = totalInstructionListPage
			End If
			ViewState("InstructionListCurrentInstructionListPage") = currentInstructionListPage
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
