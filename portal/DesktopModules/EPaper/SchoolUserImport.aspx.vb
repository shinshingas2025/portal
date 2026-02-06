Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal


	Public Class SchoolUserImport
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents LinkButtonImportUserTenPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonImportUserPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents PlaceHolderImportUserPageIndex As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents LinkButtonImportUserPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonImportUserTenPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents LabelTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label
		Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
		Protected WithEvents RadioButton1 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButton2 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButton3 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents Radiobutton4 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents ButtonQuery As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonImportUser As System.Web.UI.WebControls.Button
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
		Private subscriptionid As String = ""
		Protected pageSize As Integer = 10
		Protected totalImportUserPage As Integer = 0
		Protected currentImportUserPage As Integer = 0
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

		Enum SubscriptionUserType
			Subscription = 1
			School = 2
		End Enum

		Enum DeliverMark
			Enable = 0
			Disable = 1
		End Enum

		Enum NetType
			OK = 1
			NO = 2
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

			If Not (Request.Params("subscriptionid") Is Nothing) Then
				subscriptionid = Request.Params("subscriptionid")
			End If

			mySiteDataSet = mySiteDAO.GetEntitys(sid)
			If mySiteDataSet.Tables(0).Rows.Count = 1 Then
				SCHOOL_ID = CType(mySiteDataSet.Tables(0).Rows(0).Item("SchoolCode"), String)
			Else
				'exception:site record is empty or duplicated
			End If

			If Not IsPostBack Then
				'manage Bulletin page 
				rowCount = myAPLTBLDAO.GetTotalRowBySchoolCodeAndNet(SCHOOL_ID, CType(NetType.OK, String))
				If rowCount Mod pageSize = 0 Then
					totalImportUserPage = CType(rowCount \ pageSize, Integer)
				Else
					totalImportUserPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				If Not (Request.Params("currentimportuserpage") Is Nothing) Then
					currentImportUserPage = CType(Request.Params("currentimportuserpage"), Integer)
					ViewState("ImportUserCurrentImportUserPage") = currentImportUserPage
				Else
					currentImportUserPage = 1
				End If

				ViewState("ImportUserTotalImportUserPage") = totalImportUserPage
				ViewState("ImportUserCurrentImportUserPage") = currentImportUserPage

				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			Else
				totalImportUserPage = CType(ViewState("ImportUserTotalImportUserPage"), Integer)
				currentImportUserPage = CType(ViewState("ImportUserCurrentImportUserPage"), Integer)
			End If
		End Sub

		Private Sub PageLoad()
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim myImportDAO As New Portal_ImportDAOExtand
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim mySubscriptionDataSet As DataSet
			Dim myImportDataSet As DataSet
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
			Dim highBound As Integer = totalImportUserPage
			If subscriptionid.Trim.Length > 0 Then
				mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(subscriptionid)
				If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
					LabelTitle.Text = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("Title"), String)
					LabelDescription.Text = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("Description"), String)
				Else
					'exception:import record is empty or duplicated
				End If
			Else
				'exception:subscription id is empty
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

			myAPLTBLDataSet = myAPLTBLDAO.GetEntitysBySchoolCodeAndNetAndRowCount(myEDGR, myGRADU, SCHOOL_ID, CType(NetType.OK, String), pageSize * currentImportUserPage)

			LinkButtonImportUserPageDown.Visible = False
			LinkButtonImportUserTenPageDown.Visible = False
			LinkButtonImportUserPageUp.Visible = False
			LinkButtonImportUserTenPageUp.Visible = False

			If myAPLTBLDataSet.Tables(0).Rows.Count > 0 Then

				'page
				If currentImportUserPage > 1 Then
					For i = 0 To currentImportUserPage - 2
						For j = 0 To pageSize - 1
							myAPLTBLDataSet.Tables(0).Rows(i * pageSize + j).Delete()
						Next
					Next
				End If

				If currentImportUserPage < totalImportUserPage Then
					LinkButtonImportUserPageDown.Visible = True
				Else
					LinkButtonImportUserPageDown.Visible = False
				End If
				If currentImportUserPage < totalImportUserPage - 9 Then
					LinkButtonImportUserTenPageDown.Visible = True
				Else
					LinkButtonImportUserTenPageDown.Visible = False
				End If
				If currentImportUserPage > 1 Then
					LinkButtonImportUserPageUp.Visible = True
				Else
					LinkButtonImportUserPageUp.Visible = False
				End If
				If currentImportUserPage > 10 Then
					LinkButtonImportUserTenPageUp.Visible = True
				Else
					LinkButtonImportUserTenPageUp.Visible = False
				End If
				'prepare page index
				lowBound = currentImportUserPage - 4
				highBound = currentImportUserPage + 5
				If lowBound < 1 Then
					lowBound = 1
					highBound = Min(10, totalImportUserPage)
				Else
					If highBound > totalImportUserPage Then
						highBound = totalImportUserPage
						lowBound = Max(totalImportUserPage - 9, 1)
					End If
				End If
				myHtmlTable = New HtmlTable
				myHtmlTableRow = New HtmlTableRow
				For i = lowBound To highBound
					myHtmlTableCell = New HtmlTableCell
					myHtmlTableCell.Width = "10%"
					If i = currentImportUserPage Then
						myLabel = New Label
						myLabel.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myLabel.Text = CType(i, String)
						myHtmlTableCell.Controls.Add(myLabel)
					Else
						myHyperLink = New HyperLink
						myHyperLink.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
						myHyperLink.Text = "[" & CType(i, String) & "]"
						myHyperLink.NavigateUrl = "~/DesktopModules/EPaper/SchoolUserImport.aspx?mid=" & moduleId & "&sid=" & sid & "&currentimportuserpage=" & CType(i, String) & "&tabindex=" & tabIndex & "&subscriptionid=" & subscriptionid & "&tabid=" & tabId
						myHtmlTableCell.Controls.Add(myHyperLink)
					End If
					myHtmlTableRow.Controls.Add(myHtmlTableCell)
				Next
				myHtmlTable.Controls.Add(myHtmlTableRow)
				PlaceHolderImportUserPageIndex.Controls.Add(myHtmlTable)

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
			rowCount = myAPLTBLDAO.GetTotalRowBySchoolCodeAndNet(myEDGR, myGRADU, SCHOOL_ID, CType(NetType.OK, String))
			If rowCount Mod pageSize = 0 Then
				totalImportUserPage = CType(rowCount \ pageSize, Integer)
			Else
				totalImportUserPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentImportUserPage = 1

			ViewState("ImportUserTotalImportUserPage") = totalImportUserPage
			ViewState("ImportUserCurrentImportUserPage") = currentImportUserPage

			PageLoad()
		End Sub

		Private Sub LinkButtonImportUserPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonImportUserPageUp.Click
			currentImportUserPage = currentImportUserPage - 1
			If currentImportUserPage < 1 Then
				currentImportUserPage = 1
			End If
			ViewState("ImportUserCurrentImportUserPage") = currentImportUserPage
			PageLoad()
		End Sub

		Private Sub LinkButtonImportUserPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonImportUserPageDown.Click
			currentImportUserPage = currentImportUserPage + 1
			If currentImportUserPage > totalImportUserPage Then
				currentImportUserPage = totalImportUserPage
			End If
			ViewState("ImportUserCurrentImportUserPage") = currentImportUserPage
			PageLoad()
		End Sub

		Private Sub LinkButtonImportUserTenPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonImportUserTenPageUp.Click
			currentImportUserPage = currentImportUserPage - 10
			If currentImportUserPage < 1 Then
				currentImportUserPage = 1
			End If
			ViewState("ImportUserCurrentImportUserPage") = currentImportUserPage
			PageLoad()
		End Sub

		Private Sub LinkButtonImportUserTenPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonImportUserTenPageDown.Click
			currentImportUserPage = currentImportUserPage + 10
			If currentImportUserPage > totalImportUserPage Then
				currentImportUserPage = totalImportUserPage
			End If
			ViewState("ImportUserCurrentImportUserPage") = currentImportUserPage
			PageLoad()
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub

		Private Sub ButtonImportUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImportUser.Click
			Dim isImport As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim myAPSTBLDAO As New APSTBLDAOExtand
			Dim myO_APSTBLDAO As New O_APSTBLDAOExtand
			Dim mySubscriptionListDAO As New Portal_SubscriptionListDAOExtand
			Dim mySubscriptionListDataSet As DataSet
			Dim myAPLTBLDataSet As DataSet
			Dim myAPSTBLDataSet As DataSet
			Dim myO_APSTBLDataSet As DataSet
			Dim mySubscriptionListID As String = ""
			Dim i As Integer = 0
			Dim columnName As String = ""
			Dim myAuditID As String = ""

			'check subscription id
			If subscriptionid.Trim.Length > 0 Then
				For Each anItem In DataList1.Items
					isImport = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
					If isImport Then
						dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)

						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, mySubscriptionListDAO.ToString, "InsertEntity", mySubscriptionListID, "", Context.User.Identity.Name, Now)
						'log before action
						'none
						'actual action
						mySubscriptionListID = mySubscriptionListDAO.InsertEntity(subscriptionid, 0, SubscriptionUserType.School, dk, DeliverMark.Enable, Context.User.Identity.Name, Now)
						'log after action
						mySubscriptionListDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
						If mySubscriptionListDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, mySubscriptionListDataSet)
						End If
					End If
				Next

			Else
				'exception:subscription id is empty
			End If

			PageLoad()
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