Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal


	Public Class SubscriptionListAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents LabelSubscriptionTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelSubscriptionDescription As System.Web.UI.WebControls.Label
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonSubscriptionListPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonSubscriptionListPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents ButtonSubscriptionListUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonSubscriptionListDelete As System.Web.UI.WebControls.Button
		Protected WithEvents PlaceHolderSubscriptionListPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonSubscriptionListTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonSubscriptionListTenPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents ButtonSubscriptionListInsert As System.Web.UI.WebControls.Button
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
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
		Private subscriptionID As String = ""
		Protected totalSubscriptionListPage As Integer = 0
		Protected currentSubscriptionListPage As Integer = 0
		Protected CountryCodeGroupID As String = "2005111400000001"
		Protected JobCodeGroupID As String = "2005111400000002"
		Protected TitleCodeGroupID As String = "2005111400000003"
		Protected InformationCodeGroupID As String = "2005111400000004"
		Dim AuditDAO As New Portal_AuditDAOExtand
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

		Enum Sex
			Male = 1
			Female = 2
		End Enum
		Enum Education
			Elementary = 1
			Secondary = 2
			Professional = 3
			High = 4
			College = 5
			University = 6
			Master = 7
			Academic = 8
			Other = 9
		End Enum
		Enum Salary
			Degree1 = 1
			Degree2 = 2
			Degree3 = 3
			Degree4 = 4
			Degree5 = 5
		End Enum
		Enum SubscriptionState
			Disable = 0
			Enable = 1
			History = 2
		End Enum
		Enum SubscriptionUserType
			Subscription = 1
			School = 2
		End Enum
		Enum DeliverMark
			Enable = 0
			Disable = 1
		End Enum

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁()
			'Session("sid") = "9999"
			'If PortalSecurity.IsInRoles("Admins") = False Then
			'    Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If
			Dim rowCount As Integer
			Dim mySubscriptionListDAO As New ASPNET.StarterKit.Portal.Portal_SubscriptionListDAOExtand
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

			If Not (Request.Params("subscriptionid") Is Nothing) Then
				subscriptionID = Request.Params("subscriptionid")
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
			End If

			If Not IsPostBack Then
				'manage subscription page 
				rowCount = mySubscriptionListDAO.GetTotalRow(subscriptionID)
				If rowCount Mod pageSize = 0 Then
					totalSubscriptionListPage = CType(rowCount \ pageSize, Integer)
				Else
					totalSubscriptionListPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("currentsubscriptionlistpage") Is Nothing) Then
					currentSubscriptionListPage = CType(Request.Params("currentsubscriptionlistpage"), Integer)
					ViewState("SubscriptionListAdminCurrentSubscriptionListPage") = currentSubscriptionListPage
				Else
					currentSubscriptionListPage = 1
				End If

				ViewState("SubscriptionListAdminTotalSubscriptionListPage") = totalSubscriptionListPage
				ViewState("SubscriptionListAdminCurrentSubscriptionListPage") = currentSubscriptionListPage

				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			Else
				totalSubscriptionListPage = CType(ViewState("SubscriptionListAdminTotalSubscriptionListPage"), Integer)
				currentSubscriptionListPage = CType(ViewState("SubscriptionListAdminCurrentSubscriptionListPage"), Integer)
			End If
		End Sub

		Private Sub PageLoad()
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim mySubscriptionDataSet As DataSet
			Dim mySubscriptionListDAO As New Portal_SubscriptionListDAOExtand
			Dim mySubscriptionListDataSet As DataSet
			Dim mySubscriptionUserDAO As New Portal_SubscriptionUserDAOExtand
			Dim mySubscriptionUserDataSet As DataSet
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim myAPLTBLDataSet As DataSet
			Dim myDataColumn As DataColumn
			Dim myHyperLink As HyperLink
			Dim myLabel As Label
			Dim myHtmlTable As HtmlTable
			Dim myHtmlTableRow As HtmlTableRow
			Dim myHtmlTableCell As HtmlTableCell
			Dim myUserType As Integer = 0
			Dim myUserID As String = ""
			Dim myUserName As String = ""
			Dim myUserEmail As String = ""
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim lowBound As Integer = 1
			Dim highBound As Integer = totalSubscriptionListPage
			If subscriptionID.Length > 0 Then
				mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionID)
			Else
				'exception:subscription id is empty
			End If

			If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
				LabelSubscriptionTitle.Text = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("Title"), String)
				LabelSubscriptionDescription.Text = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("Description"), String)

				'prepare subscription list structure and page
				'structure
				mySubscriptionListDataSet = mySubscriptionListDAO.GetEntitys(subscriptionID, pageSize * currentSubscriptionListPage)
				myDataColumn = New DataColumn("Name")
				mySubscriptionListDataSet.Tables(0).Columns.Add(myDataColumn)
				myDataColumn = New DataColumn("Email")
				mySubscriptionListDataSet.Tables(0).Columns.Add(myDataColumn)
				'page
				If currentSubscriptionListPage > 1 Then
					For i = 0 To currentSubscriptionListPage - 2
						For j = 0 To pageSize - 1
							mySubscriptionListDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				If currentSubscriptionListPage < totalSubscriptionListPage Then
					LinkButtonSubscriptionListPageDown.Visible = True
				Else
					LinkButtonSubscriptionListPageDown.Visible = False
				End If
				If currentSubscriptionListPage < totalSubscriptionListPage - 9 Then
					LinkButtonSubscriptionListTenPageDown.Visible = True
				Else
					LinkButtonSubscriptionListTenPageDown.Visible = False
				End If
				If currentSubscriptionListPage > 1 Then
					LinkButtonSubscriptionListPageUp.Visible = True
				Else
					LinkButtonSubscriptionListPageUp.Visible = False
				End If
				If currentSubscriptionListPage > 10 Then
					LinkButtonSubscriptionListTenPageUp.Visible = True
				Else
					LinkButtonSubscriptionListTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentSubscriptionListPage - 4
				highBound = currentSubscriptionListPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalSubscriptionListPage)
				Else
					If highBound > totalSubscriptionListPage Then
						highBound = totalSubscriptionListPage
						lowBound = Max(totalSubscriptionListPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentSubscriptionListPage Then
						myLabel = New Label
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						myHyperLink = New HyperLink
						myHyperLink.Text = CType(i, String)
						myHyperLink.NavigateUrl = "~/DesktopModules/EPaper/SubscriptionListAdmin.aspx?mid=" & moduleId & "&sid=" & sid & "&subscriptionid=" & subscriptionID & "&currentsubscriptionlistpage=" & CType(i, String) & "&tabindex=" & tabIndex & "&tabid=" & tabId
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderSubscriptionListPageIndex.Controls.Add(myHtmlTable)

				'prepare subscription list and user data
				If mySubscriptionListDataSet.Tables(0).Rows.Count > 0 Then
					For i = (currentSubscriptionListPage - 1) * pageSize To mySubscriptionListDataSet.Tables(0).Rows.Count - 1
						myUserID = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("UserID"), String).Trim
						myUserType = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("UserType"), Integer)
						If myUserID.Length > 0 Then
							If myUserType = SubscriptionUserType.Subscription Then
								mySubscriptionUserDataSet = mySubscriptionUserDAO.GetEntitys(myUserID)
								If mySubscriptionUserDataSet.Tables(0).Rows.Count = 1 Then
									mySubscriptionListDataSet.Tables(0).Rows(i).Item("Name") = mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Name")
									mySubscriptionListDataSet.Tables(0).Rows(i).Item("Email") = mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Email")
								Else
									'exception:subscription user data is empty or duplicated
								End If
							Else
								If myUserType = SubscriptionUserType.School Then
									myAPLTBLDataSet = myAPLTBLDAO.GetEntitys(CType(myUserID, Integer))
									If myAPLTBLDataSet.Tables(0).Rows.Count = 1 Then
										mySubscriptionListDataSet.Tables(0).Rows(i).Item("Name") = myAPLTBLDataSet.Tables(0).Rows(0).Item("NAME")
										mySubscriptionListDataSet.Tables(0).Rows(i).Item("Email") = myAPLTBLDataSet.Tables(0).Rows(0).Item("E_MAIL")
									End If
								Else
									'exception:unknown user type
								End If
							End If
						Else
							'exception:user id is empty
						End If
					Next
				End If
				DataList1.DataSource = mySubscriptionListDataSet
				DataList1.DataBind()
			Else
				'exception
			End If
		End Sub
		Sub PageReload()
			Dim mySubscriptionListDAO As New ASPNET.StarterKit.Portal.Portal_SubscriptionListDAOExtand
			Dim rowCount As Integer

			'
			rowCount = mySubscriptionListDAO.GetTotalRow(subscriptionID)
			If rowCount Mod pageSize = 0 Then
				totalSubscriptionListPage = CType(rowCount \ pageSize, Integer)
			Else
				totalSubscriptionListPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentSubscriptionListPage = 1

			ViewState("SubscriptionListAdminTotalSubscriptionListPage") = totalSubscriptionListPage
			ViewState("SubscriptionListAdminCurrentSubscriptionListPage") = currentSubscriptionListPage

			PageLoad()
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub LinkButtonSubscriptionListPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonSubscriptionListPageUp.Click
			currentSubscriptionListPage = currentSubscriptionListPage - 1
			If currentSubscriptionListPage < 1 Then
				currentSubscriptionListPage = 1
			End If
			ViewState("SubscriptionListAdminCurrentSubscriptionListPage") = currentSubscriptionListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonSubscriptionListPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonSubscriptionListPageDown.Click
			currentSubscriptionListPage = currentSubscriptionListPage + 1
			If currentSubscriptionListPage > totalSubscriptionListPage Then
				currentSubscriptionListPage = totalSubscriptionListPage
			End If
			ViewState("SubscriptionListAdminCurrentSubscriptionListPage") = currentSubscriptionListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonSubscriptionListTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonSubscriptionListTenPageUp.Click
			currentSubscriptionListPage = currentSubscriptionListPage - 10
			If currentSubscriptionListPage < 1 Then
				currentSubscriptionListPage = 1
			End If
			ViewState("SubscriptionListAdminCurrentSubscriptionListPage") = currentSubscriptionListPage
			PageLoad()
		End Sub

		Private Sub LinkButtonSubscriptionListTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonSubscriptionListTenPageDown.Click
			currentSubscriptionListPage = currentSubscriptionListPage + 10
			If currentSubscriptionListPage > totalSubscriptionListPage Then
				currentSubscriptionListPage = totalSubscriptionListPage
			End If
			ViewState("SubscriptionListAdminCurrentSubscriptionListPage") = currentSubscriptionListPage
			PageLoad()
		End Sub

		Private Sub ButtonSubscriptionListInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubscriptionListInsert.Click
			Response.Redirect("~/DesktopModules/EPaper/SubscriptionRegister.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&subscriptionid=" & subscriptionID & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub ButtonSubscriptionListUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubscriptionListUpdate.Click
			Dim isEdit As Boolean
			Dim myUserID As String = ""
			Dim myUserType As Integer = 0
			Dim mySubscriptionListDAO As New Portal_SubscriptionListDAOExtand
			Dim mySubscriptionListDataSet As DataSet
			Dim anItem As DataListItem
			Dim dk As String
			For Each anItem In DataList1.Items
				isEdit = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
				If isEdit Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					mySubscriptionListDataSet = mySubscriptionListDAO.GetEntity(dk)
					If mySubscriptionListDataSet.Tables(0).Rows.Count = 1 Then
						myUserID = CType(mySubscriptionListDataSet.Tables(0).Rows(0).Item("UserID"), String)
						myUserType = CType(mySubscriptionListDataSet.Tables(0).Rows(0).Item("UserType"), Integer)
						If myUserType = SubscriptionUserType.Subscription Then
							Response.Redirect("~/DesktopModules/EPaper/SubscriptionUserEdit.aspx?sid=" & CType(Session("sid"), String) & "&mid=" & moduleId & "&subscriptionuserid=" & myUserID & "&tabid=" & tabId & "&tabindex=" & tabIndex)
						Else
							If myUserType = SubscriptionUserType.School Then
								'do nothing
							Else
								'exception:unknown user type
							End If
						End If
					Else
						'exception;subscription list is empty or duplicated
					End If
				End If
			Next
			PageLoad()
		End Sub

		Private Sub ButtonSubscriptionListDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubscriptionListDelete.Click
			Dim myUserID As String = ""
			Dim myUserType As Integer = 0
			Dim isDelete As Boolean
			Dim mySubscriptionListDAO As New Portal_SubscriptionListDAOExtand
			Dim mySubscriptionUserDAO As New Portal_SubscriptionUserDAOExtand
			Dim mySubscriptionListDataSet As DataSet
			Dim mySubscriptionListPartDataSet As DataSet
			Dim mySubscriptionUserDataSet As DataSet
			Dim anItem As DataListItem
			Dim dk As String
			Dim myAuditID As String = ""
			For Each anItem In DataList1.Items
				isDelete = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
				If isDelete Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					mySubscriptionListDataSet = mySubscriptionListDAO.GetEntity(dk)
					If mySubscriptionListDataSet.Tables(0).Rows.Count = 1 Then
						myUserID = CType(mySubscriptionListDataSet.Tables(0).Rows(0).Item("UserID"), String)
						myUserType = CType(mySubscriptionListDataSet.Tables(0).Rows(0).Item("UserType"), Integer)
						If myUserType = SubscriptionUserType.Subscription Then
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, mySubscriptionUserDAO.ToString, "DeleteEntity", myUserID, "", Context.User.Identity.Name, Now)
							'log before action
							mySubscriptionUserDataSet = mySubscriptionUserDAO.GetEntitys(myUserID)
							If mySubscriptionUserDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.before, mySubscriptionUserDataSet)
							End If
							'actual action
							mySubscriptionUserDAO.DeleteEntity(myUserID)
							'log after action
							mySubscriptionUserDataSet = mySubscriptionUserDAO.GetEntitys(myUserID)
							If mySubscriptionUserDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, mySubscriptionUserDataSet)
							End If
						Else
							If myUserType = SubscriptionUserType.School Then
							Else
								'exception:unknown user type
							End If
						End If
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, mySubscriptionListDAO.ToString, "DeleteEntity", dk, "", Context.User.Identity.Name, Now)
						'log before action
						mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(dk)
						If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.before, mySubscriptionListPartDataSet)
						End If
						'actual action
						mySubscriptionListDAO.DeleteEntity(dk)
						'log after action
						mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(dk)
						If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, mySubscriptionListPartDataSet)
						End If
					Else
						'exception:subscription list record is empty or duplicated
					End If
				End If
			Next
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