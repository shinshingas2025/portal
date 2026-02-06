Imports System.IO
Imports System.Math
Imports System.Configuration
Namespace ASPNET.StarterKit.Portal

	Public Class AdminBulletinList
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonBulletinListTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonBulletinListPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderBulletinListPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonBulletinListPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonBulletinListTenPageDown As System.Web.UI.WebControls.LinkButton
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
		Protected totalBulletinListPage As Integer = 0
		Protected currentBulletinListPage As Integer = 0
		Protected AdminPortalID As String = ConfigurationSettings.AppSettings("AdminPortalID")

		Enum BulletinType
			community = 1
			individual = 2
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
				If AdminPortalID.Trim.Length > 0 Then
					rowCount = myBulletinMapDAO.GetTotalRowByGap(AdminPortalID, BulletinType.community)
					If rowCount Mod pageSize = 0 Then
						totalBulletinListPage = CType(rowCount \ pageSize, Integer)
					Else
						totalBulletinListPage = CType(rowCount \ pageSize + 1, Integer)
					End If
					If Not (Request.Params("currentbulletinlistpage") Is Nothing) Then
						currentBulletinListPage = CType(Request.Params("currentbulletinlistpage"), Integer)
						ViewState("BulletinListCurrentBulletinListPage") = currentBulletinListPage
					Else
						currentBulletinListPage = 1
					End If

					ViewState("BulletinListTotalBulletinListPage") = totalBulletinListPage
					ViewState("BulletinListCurrentBulletinListPage") = currentBulletinListPage

					If Not (Request.UrlReferrer Is Nothing) Then
						ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
					End If
					PageLoad()
				End If
			Else
				totalBulletinListPage = CType(ViewState("BulletinListTotalBulletinListPage"), Integer)
				currentBulletinListPage = CType(ViewState("BulletinListCurrentBulletinListPage"), Integer)
			End If
		End Sub

		Private Sub PageLoad()
			Dim myBulletinMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinDataSet As DataSet
			Dim myBulletinID As String
			Dim myHyperLink As HyperLink
			Dim myLabel As Label
			Dim myHtmlTable As HtmlTable
			Dim myHtmlTableRow As HtmlTableRow
			Dim myHtmlTableCell As HtmlTableCell
			Dim myTitle As String = ""
			Dim myAnnounceUnit As String = ""
			Dim myDataColumn As DataColumn
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalBulletinListPage
			If AdminPortalID.Trim.Length > 0 Then
				myBulletinMapDataSet = myBulletinMapDAO.GetEntitysBySchoolIDAndTypeID(AdminPortalID, BulletinType.community, pageSize * currentBulletinListPage)

				LinkButtonBulletinListPageDown.Visible = False
				LinkButtonBulletinListTenPageDown.Visible = False
				LinkButtonBulletinListPageUp.Visible = False
				LinkButtonBulletinListTenPageUp.Visible = False

				If myBulletinMapDataSet.Tables(0).Rows.Count > 0 Then

					'page
					If currentBulletinListPage > 1 Then
						For i = 0 To currentBulletinListPage - 2
							For j = 0 To pageSize - 1
								myBulletinMapDataSet.Tables(0).Rows(i * pageSize + j).Delete()
							Next
						Next
					End If

					If currentBulletinListPage < totalBulletinListPage Then
						LinkButtonBulletinListPageDown.Visible = True
					Else
						LinkButtonBulletinListPageDown.Visible = False
					End If
					If currentBulletinListPage < totalBulletinListPage - 9 Then
						LinkButtonBulletinListTenPageDown.Visible = True
					Else
						LinkButtonBulletinListTenPageDown.Visible = False
					End If
					If currentBulletinListPage > 1 Then
						LinkButtonBulletinListPageUp.Visible = True
					Else
						LinkButtonBulletinListPageUp.Visible = False
					End If
					If currentBulletinListPage > 10 Then
						LinkButtonBulletinListTenPageUp.Visible = True
					Else
						LinkButtonBulletinListTenPageUp.Visible = False
					End If
					'prepare page index
					lowBound = currentBulletinListPage - 4
					highBound = currentBulletinListPage + 5
					If lowBound < 1 Then
						lowBound = 1
						highBound = Min(10, totalBulletinListPage)
					Else
						If highBound > totalBulletinListPage Then
							highBound = totalBulletinListPage
							lowBound = Max(totalBulletinListPage - 9, 1)
						End If
					End If
					myHtmlTable = New HtmlTable
					myHtmlTableRow = New HtmlTableRow
					For i = lowBound To highBound
						myHtmlTableCell = New HtmlTableCell
						myHtmlTableCell.Width = "10%"
						If i = currentBulletinListPage Then
							myLabel = New Label
							myLabel.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
							myLabel.Text = CType(i, String)
							myHtmlTableCell.Controls.Add(myLabel)
						Else
							myHyperLink = New HyperLink
							myHyperLink.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
							myHyperLink.Text = "[" & CType(i, String) & "]"
							myHyperLink.NavigateUrl = "~/DesktopModules/AdminBulletin/AdminBulletinList.aspx?mid=" & moduleId & "&sid=" & sid & "&currentBulletinlistpage=" & CType(i, String) & "&tabindex=" & tabIndex & "&tabid=" & tabId
							myHtmlTableCell.Controls.Add(myHyperLink)
						End If
						myHtmlTableRow.Controls.Add(myHtmlTableCell)
					Next
					myHtmlTable.Controls.Add(myHtmlTableRow)
					PlaceHolderBulletinListPageIndex.Controls.Add(myHtmlTable)
				Else
					'exception
				End If
				DataList1.DataSource = myBulletinMapDataSet
				DataList1.DataBind()
			Else
				'exception:admin portal id is empty
			End If
		End Sub
		Sub PageReload()
			Dim myBulletinMapDAO As New ASPNET.StarterKit.Portal.Portal_BulletinMapDAOExtand
			Dim rowCount As Integer

			'
			rowCount = myBulletinMapDAO.GetTotalRowBySchoolIDAndTypeID(AdminPortalID, BulletinType.community)
			If rowCount Mod pageSize = 0 Then
				totalBulletinListPage = CType(rowCount \ pageSize, Integer)
			Else
				totalBulletinListPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentBulletinListPage = 1

			ViewState("BulletinListTotalBulletinListPage") = totalBulletinListPage
			ViewState("BulletinListCurrentBulletinListPage") = currentBulletinListPage

			PageLoad()
		End Sub

		Private Sub LinkButtonBulletinListPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinListPageUp.Click
			currentBulletinListPage = currentBulletinListPage - 1
			If currentBulletinListPage < 1 Then
				currentBulletinListPage = 1
			End If
			ViewState("BulletinListCurrentBulletinListPage") = currentBulletinListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonBulletinListPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinListPageDown.Click
			currentBulletinListPage = currentBulletinListPage + 1
			If currentBulletinListPage > totalBulletinListPage Then
				currentBulletinListPage = totalBulletinListPage
			End If
			ViewState("BulletinListCurrentBulletinListPage") = currentBulletinListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonBulletinListTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinListTenPageUp.Click
			currentBulletinListPage = currentBulletinListPage - 10
			If currentBulletinListPage < 1 Then
				currentBulletinListPage = 1
			End If
			ViewState("BulletinListCurrentBulletinListPage") = currentBulletinListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonBulletinListTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonBulletinListTenPageDown.Click
			currentBulletinListPage = currentBulletinListPage + 10
			If currentBulletinListPage > totalBulletinListPage Then
				currentBulletinListPage = totalBulletinListPage
			End If
			ViewState("BulletinListCurrentBulletinListPage") = currentBulletinListPage
			PageLoad()
		End Sub

		Protected Sub ShowBulletin(ByVal Sender As Object, ByVal e As DataListCommandEventArgs)
			Dim dk As String = ""
			dk = CType(DataList1.DataKeys(e.Item.ItemIndex), String)
			Response.Redirect("~/DesktopModules/AdminBulletin/AdminBulletinShow.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&bulletinmapid=" & dk & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class
End Namespace