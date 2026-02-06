Imports System
Imports System.IO
Imports System.text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail
Namespace ASPNET.StarterKit.Portal
	Public Class SubscriptionAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents SubscriptionPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents SubscriptionPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents SubscriptionInsert As System.Web.UI.WebControls.Button
		Protected WithEvents SubscriptionUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents SubscriptionDelete As System.Web.UI.WebControls.Button
		Protected WithEvents DataList2 As System.Web.UI.WebControls.DataList
		Protected WithEvents EPaperPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents EPaperPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents EPaperInsert As System.Web.UI.WebControls.Button
		Protected WithEvents EPaperUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents EPaperDelete As System.Web.UI.WebControls.Button
		Protected WithEvents DataList3 As System.Web.UI.WebControls.DataList
		Protected WithEvents EDeliverManagerPageUp As System.Web.UI.WebControls.LinkButton
		Protected WithEvents EDeliverManagerPageDown As System.Web.UI.WebControls.LinkButton
		Protected WithEvents EDeliverManagerInsert As System.Web.UI.WebControls.Button
		Protected WithEvents EDeliverManagerUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents EDeliverManagerDelete As System.Web.UI.WebControls.Button
		Protected WithEvents SubscriptionSelect As System.Web.UI.WebControls.Button
		Protected WithEvents EPaperSelect As System.Web.UI.WebControls.Button
		Protected WithEvents ListBoxSubscription As System.Web.UI.WebControls.ListBox
		Protected WithEvents ListBoxEPaper As System.Web.UI.WebControls.ListBox
		Protected WithEvents ImageButtonSubscriptionDelete As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ImageButtonEPaperDelete As System.Web.UI.WebControls.ImageButton
		Protected WithEvents EDeliverManagerOK As System.Web.UI.WebControls.Button
		Protected WithEvents SubscriptionListEdit As System.Web.UI.WebControls.Button
		Protected WithEvents EDeliverManagerSend As System.Web.UI.WebControls.Button
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents SubscriptionListImport As System.Web.UI.WebControls.Button
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
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
		Protected sid As String = "9999"
		Protected moduleID As Integer = 0
		Protected itemID As Integer = 0
		Protected subscriptionID As String = ""
		Protected tabId As Integer = 0
		Protected tabIndex As Integer = 0
		Protected totalSubscriptionPage As Integer = 0
		Protected currentSubscriptionPage As Integer = 0
		Protected totalEPaperPage As Integer = 0
		Protected currentEPaperPage As Integer = 0
		Protected totalEDeliverManagerPage As Integer = 0
		Protected currentEDeliverManagerPage As Integer = 0
		Protected pageSize As Integer = 10

		Protected CountryCodeGroupID As String = "2005111400000001"
		Protected JobCodeGroupID As String = "2005111400000002"
		Protected TitleCodeGroupID As String = "2005111400000003"
		Protected InformationCodeGroupID As String = "2005111400000004"
		Protected adminEmail As String = "faustime@hotmail.com"
		Dim AuditDAO As New Portal_AuditDAOExtand
		Dim ModuleStatisticDAO As New Portal_ModuleStatisticDAOExtand
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
			'在這裡放置使用者程式碼以初始化網頁
			Dim rowCount As Integer
			Dim mySubscriptionDAO As New ASPNET.StarterKit.Portal.Portal_SubscriptionDAOExtand
			Dim myEPaperDAO As New ASPNET.StarterKit.Portal.Portal_EPaperDAOExtand
			Dim myEDeliverManagerDAO As New ASPNET.StarterKit.Portal.Portal_EPaperDeliverManagerDAOExtand

			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If
			If Not (Request.Params("mid") Is Nothing) Then
				moduleID = Int32.Parse(Request.Params("mid"))
			End If
			If Not (Request.Params("ItemID") Is Nothing) Then
				itemID = Int32.Parse(Request.Params("ItemID"))
			End If
			If Not (Request.Params("tabid") Is Nothing) Then
				tabId = Int32.Parse(Request.Params("tabid"))
			End If
			If Not (Request.Params("tabindex") Is Nothing) Then
				tabIndex = Int32.Parse(Request.Params("tabindex"))
			End If
			If Not (Request.Params("SubscriptionID") Is Nothing) Then
				subscriptionID = Request.Params("SubscriptionID")
			End If

			If Not Page.IsPostBack Then
				'manage subscription page 
				rowCount = mySubscriptionDAO.GetTotalRow(sid, moduleID)
				If rowCount Mod pageSize = 0 Then
					totalSubscriptionPage = CType(rowCount \ pageSize, Integer)
				Else
					totalSubscriptionPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				currentSubscriptionPage = 1

				ViewState("SubscriptionAdminTotalSubscriptionPage") = totalSubscriptionPage
				ViewState("SubscriptionAdminCurrentSubscriptionPage") = 1
				'manage epaper page
				rowCount = myEPaperDAO.GetTotalRow(sid, moduleID)
				If rowCount Mod pageSize = 0 Then
					totalEPaperPage = CType(rowCount \ pageSize, Integer)
				Else
					totalEPaperPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				currentEPaperPage = 1

				ViewState("SubscriptionAdminTotalEPaperPage") = totalEPaperPage
				ViewState("SubscriptionAdminCurrentEPaperPage") = 1
				'manage epaper deliver manager
				rowCount = myEDeliverManagerDAO.GetTotalRow(sid, moduleID)
				If rowCount Mod pageSize = 0 Then
					totalEDeliverManagerPage = CType(rowCount \ pageSize, Integer)
				Else
					totalEDeliverManagerPage = CType(rowCount \ pageSize + 1, Integer)
				End If
				currentEDeliverManagerPage = 1

				ViewState("SubscriptionAdminTotalEDeliverManagerPage") = totalEDeliverManagerPage
				ViewState("SubscriptionAdminCurrentEDeliverManagerPage") = 1
			Else
				totalSubscriptionPage = CType(ViewState("SubscriptionAdminTotalSubscriptionPage"), Integer)
				currentSubscriptionPage = CType(ViewState("SubscriptionAdminCurrentSubscriptionPage"), Integer)
				totalEPaperPage = CType(ViewState("SubscriptionAdminTotalEPaperPage"), Integer)
				currentEPaperPage = CType(ViewState("SubscriptionAdminCurrentEPaperPage"), Integer)
				totalEDeliverManagerPage = CType(ViewState("SubscriptionAdminTotalEDeliverManagerPage"), Integer)
				currentEDeliverManagerPage = CType(ViewState("SubscriptionAdminCurrentEDeliverManagerPage"), Integer)
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				LoadPage()
			End If

		End Sub

		Private Sub LoadPage()
			Dim i As Integer
			Dim j As Integer
			Dim myDataSet As DataSet
			Dim mySubscriptionDataSet As DataSet
			Dim mySubscriptionDAO As New ASPNET.StarterKit.Portal.Portal_SubscriptionDAOExtand
			Dim myEPaperDataSet As DataSet
			Dim myEPaperDAO As New ASPNET.StarterKit.Portal.Portal_EPaperDAOExtand
			Dim myEDeliverManagerDataSet As DataSet
			Dim myEDeliverManagerDAO As New ASPNET.StarterKit.Portal.Portal_EPaperDeliverManagerDAOExtand
			Dim mySubscriptionID As String = ""
			Dim myEPaperID As String = ""
			mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(sid, moduleID, pageSize * currentSubscriptionPage)
			myEPaperDataSet = myEPaperDAO.GetEntitys(sid, moduleID, pageSize * currentEPaperPage)
			myEDeliverManagerDataSet = myEDeliverManagerDAO.GetEntitys(sid, moduleID, pageSize * currentEDeliverManagerPage)

			'manage subscription datalist
			If currentSubscriptionPage > 1 Then
				For i = 0 To currentSubscriptionPage - 2
					For j = 0 To pageSize - 1
						mySubscriptionDataSet.Tables(0).Rows(i * pageSize + j).Delete()
					Next
				Next
			End If

			If currentSubscriptionPage < totalSubscriptionPage Then
				SubscriptionPageDown.Visible = True
			Else
				SubscriptionPageDown.Visible = False
			End If

			If currentSubscriptionPage > 1 Then
				SubscriptionPageUp.Visible = True
			Else
				SubscriptionPageUp.Visible = False
			End If

			DataList1.DataSource = mySubscriptionDataSet
			DataList1.DataBind()

			'manage epaper datalist
			If currentEPaperPage > 1 Then
				For i = 0 To currentEPaperPage - 2
					For j = 0 To pageSize - 1
						myEPaperDataSet.Tables(0).Rows(i * pageSize + j).Delete()
					Next
				Next
			End If

			If currentEPaperPage < totalEPaperPage Then
				EPaperPageDown.Visible = True
			Else
				EPaperPageDown.Visible = False
			End If

			If currentEPaperPage > 1 Then
				EPaperPageUp.Visible = True
			Else
				EPaperPageUp.Visible = False
			End If

			DataList2.DataSource = myEPaperDataSet
			DataList2.DataBind()

			'manage epaper deliver manager datalist
			If currentEDeliverManagerPage > 1 Then
				For i = 0 To currentEDeliverManagerPage - 2
					For j = 0 To pageSize - 1
						myEDeliverManagerDataSet.Tables(0).Rows(i * pageSize + j).Delete()
					Next
				Next
			End If
			'prepare title and description
			Dim myTitle As New DataColumn("Title")
			Dim mySubscriptionTitle As New DataColumn("SubscriptionTitle")
			Dim myEPaperTitle As New DataColumn("EPaperTitle")
			myEDeliverManagerDataSet.Tables(0).Columns.Add(myTitle)
			myEDeliverManagerDataSet.Tables(0).Columns.Add(mySubscriptionTitle)
			myEDeliverManagerDataSet.Tables(0).Columns.Add(myEPaperTitle)
			For i = (currentEDeliverManagerPage - 1) * pageSize To myEDeliverManagerDataSet.Tables(0).Rows.Count - 1
				myEDeliverManagerDataSet.Tables(0).Rows(i).Item("Title") = CType(i + 1, String)
				mySubscriptionID = CType(myEDeliverManagerDataSet.Tables(0).Rows(i).Item("SubscriptionID"), String).Trim
				myEPaperID = CType(myEDeliverManagerDataSet.Tables(0).Rows(i).Item("EPaperID"), String).Trim
				'setup subscription title
				If mySubscriptionID.Length > 0 Then
					myDataSet = mySubscriptionDAO.GetEntitys(mySubscriptionID)
					If myDataSet.Tables(0).Rows.Count = 1 Then
						myEDeliverManagerDataSet.Tables(0).Rows(i).Item("SubscriptionTitle") = CType(myDataSet.Tables(0).Rows(0).Item("Title"), String)
					Else
						'exception
					End If
				Else
					'exception
				End If
				'setup epaper title
				If myEPaperID.Length > 0 Then
					myDataSet = myEPaperDAO.GetEntitys(myEPaperID)
					If myDataSet.Tables(0).Rows.Count = 1 Then
						myEDeliverManagerDataSet.Tables(0).Rows(i).Item("EPaperTitle") = CType(myDataSet.Tables(0).Rows(0).Item("Title"), String)
					Else
						'exception
					End If
				Else
					'exception
				End If
			Next

			If currentEDeliverManagerPage < totalEDeliverManagerPage Then
				EDeliverManagerPageDown.Visible = True
			Else
				EDeliverManagerPageDown.Visible = False
			End If

			If currentEDeliverManagerPage > 1 Then
				EDeliverManagerPageUp.Visible = True
			Else
				EDeliverManagerPageUp.Visible = False
			End If

			DataList3.DataSource = myEDeliverManagerDataSet
			DataList3.DataBind()

		End Sub

		Private Sub RedirectPage()
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub SubscriptionPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionPageUp.Click
			currentSubscriptionPage = currentSubscriptionPage - 1
			If currentSubscriptionPage < 1 Then
				currentSubscriptionPage = 1
			End If
			ViewState("SubscriptionAdminCurrentSubscriptionPage") = currentSubscriptionPage
			LoadPage()
		End Sub

		Private Sub SubscriptionPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionPageDown.Click
			currentSubscriptionPage = currentSubscriptionPage + 1
			If currentSubscriptionPage > totalSubscriptionPage Then
				currentSubscriptionPage = totalSubscriptionPage
			End If
			ViewState("SubscriptionAdminCurrentSubscriptionPage") = currentSubscriptionPage
			LoadPage()
		End Sub

		Private Sub EPaperPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPaperPageUp.Click
			currentEPaperPage = currentEPaperPage - 1
			If currentEPaperPage < 1 Then
				currentEPaperPage = 1
			End If
			ViewState("SubscriptionAdminCurrentEPaperPage") = currentEPaperPage
			LoadPage()
		End Sub

		Private Sub EPaperPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPaperPageDown.Click
			currentEPaperPage = currentEPaperPage + 1
			If currentEPaperPage > totalEPaperPage Then
				currentEPaperPage = totalEPaperPage
			End If
			ViewState("SubscriptionAdminCurrentEPaperPage") = currentEPaperPage
			LoadPage()
		End Sub

		Private Sub SubscriptionInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionInsert.Click
			Dim isImport As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			For Each anItem In DataList1.Items
				isImport = CType(anItem.FindControl("Edit1"), CheckBox).Checked
				If isImport Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					Response.Redirect("~/DesktopModules/EPaper/SubscriptionAdd.aspx?mid=" & moduleID & "&sid=" & sid & "&subscriptionid=" & dk & "&tabid=" & tabId & "&tabindex=" & tabIndex)
				End If
			Next
			Response.Redirect("~/DesktopModules/EPaper/SubscriptionAdd.aspx?mid=" & moduleID & "&sid=" & sid & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub EPaperInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPaperInsert.Click
			Response.Redirect("~/DesktopModules/EPaper/EPaperAdd.aspx?mid=" & moduleID & "&sid=" & sid & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub SubscriptionUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionUpdate.Click
			Dim isModify As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			For Each anItem In DataList1.Items
				isModify = CType(anItem.FindControl("Edit1"), CheckBox).Checked
				If isModify Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					Response.Redirect("~/DesktopModules/EPaper/SubscriptionEdit.aspx?mid=" & moduleID & "&sid=" & sid & "&subscriptionid=" & dk & "&tabindex=" & tabIndex & "&tabid=" & tabId)
				End If
			Next
		End Sub

		Private Sub EPaperUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPaperUpdate.Click
			Dim isModify As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			For Each anItem In DataList2.Items
				isModify = CType(anItem.FindControl("Edit2"), CheckBox).Checked
				If isModify Then
					dk = CType(DataList2.DataKeys(anItem.ItemIndex), String)
					Response.Redirect("~/DesktopModules/EPaper/EPaperEdit.aspx?mid=" & moduleID & "&sid=" & sid & "&epaperid=" & dk & "&tabindex=" & tabIndex & "&tabid=" & tabId)
				End If
			Next
		End Sub

		Private Sub SubscriptionDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionDelete.Click
			Dim isDeleted As Boolean
			Dim anItem As DataListItem
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim mySubscriptionListDAO As New Portal_SubscriptionListDAOExtand
			Dim myEPaperDeliverManagerDAO As New Portal_EPaperDeliverManagerDAOExtand
			Dim mySubscriptionListDataSet As DataSet
			Dim mySubscriptionListPartDataSet As DataSet
			Dim mySubscriptionDataSet As DataSet
			Dim myEPaperDeliverManagerDataSet As DataSet
			Dim myEPaperDeliverManagerPartDataSet As DataSet
			Dim dk As String
			Dim myAuditID As String = ""
			Dim mySubscriptionListID As String = ""
			Dim myEPaperDeliverManagerID As String = ""
			Dim i As Integer = 0
			For Each anItem In DataList1.Items
				isDeleted = CType(anItem.FindControl("Edit1"), CheckBox).Checked
				If isDeleted Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					mySubscriptionListDataSet = mySubscriptionListDAO.GetEntitys(dk)
					If mySubscriptionListDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To mySubscriptionListDataSet.Tables(0).Rows.Count - 1
							mySubscriptionListID = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, mySubscriptionListDAO.ToString, "DeleteEntity", mySubscriptionListID, "", Context.User.Identity.Name, Now)
							'log before action
							mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
							If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.before, mySubscriptionListPartDataSet)
							End If
							'actual action
							mySubscriptionListDAO.DeleteEntity(mySubscriptionListID)
							'log after action
							mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
							If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, mySubscriptionListPartDataSet)
							End If
						Next
					End If
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, mySubscriptionDAO.ToString, "DeleteEntity", dk, "", Context.User.Identity.Name, Now)
					'log before action
					mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(dk)
					If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, mySubscriptionDataSet)
					End If
					'actual action
					mySubscriptionDAO.DeleteEntity(dk)
					'log after action
					mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(dk)
					If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, mySubscriptionDataSet)
					End If
					myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitysBySubscriptionID(dk)
					If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myEPaperDeliverManagerDataSet.Tables(0).Rows.Count - 1
							myEPaperDeliverManagerID = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, myEPaperDeliverManagerDAO.ToString, "DeleteEntity", myEPaperDeliverManagerID, "", Context.User.Identity.Name, Now)
							'log before action
							myEPaperDeliverManagerPartDataSet = myEPaperDeliverManagerDAO.GetEntitys(myEPaperDeliverManagerID)
							If myEPaperDeliverManagerPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.before, myEPaperDeliverManagerPartDataSet)
							End If
							'actual action
							myEPaperDeliverManagerDAO.DeleteEntity(myEPaperDeliverManagerID)
							'log after action
							myEPaperDeliverManagerPartDataSet = myEPaperDeliverManagerDAO.GetEntitys(myEPaperDeliverManagerID)
							If myEPaperDeliverManagerPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, myEPaperDeliverManagerPartDataSet)
							End If
						Next
					End If
				End If
			Next
			PageReload()
		End Sub
		Sub PageReload()
			Dim mySubscriptionDAO As New ASPNET.StarterKit.Portal.Portal_SubscriptionDAOExtand
			Dim myEPaperDAO As New ASPNET.StarterKit.Portal.Portal_EPaperDAOExtand
			Dim myEDeliverManagerDAO As New ASPNET.StarterKit.Portal.Portal_EPaperDeliverManagerDAOExtand
			Dim rowCount As Integer

			'
			rowCount = mySubscriptionDAO.GetTotalRow(sid, moduleID)
			If rowCount Mod pageSize = 0 Then
				totalSubscriptionPage = CType(rowCount \ pageSize, Integer)
			Else
				totalSubscriptionPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentSubscriptionPage = 1

			ViewState("SubscriptionAdminTotalSubscriptionPage") = totalSubscriptionPage
			ViewState("SubscriptionAdminCurrentSubscriptionPage") = currentSubscriptionPage

			'
			rowCount = myEPaperDAO.GetTotalRow(sid, moduleID)
			If rowCount Mod pageSize = 0 Then
				totalEPaperPage = CType(rowCount \ pageSize, Integer)
			Else
				totalEPaperPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentEPaperPage = 1

			ViewState("SubscriptionAdminTotalEPaperPage") = totalEPaperPage
			ViewState("SubscriptionAdminCurrentEPaperPage") = currentEPaperPage

			'
			rowCount = myEDeliverManagerDAO.GetTotalRow(sid, moduleID)
			If rowCount Mod pageSize = 0 Then
				totalEDeliverManagerPage = CType(rowCount \ pageSize, Integer)
			Else
				totalEDeliverManagerPage = CType(rowCount \ pageSize + 1, Integer)
			End If
			currentEDeliverManagerPage = 1

			ViewState("SubscriptionAdminTotalEDeliverManagerPage") = totalEDeliverManagerPage
			ViewState("SubscriptionAdminCurrentEDeliverManagerPage") = currentEDeliverManagerPage

			LoadPage()
		End Sub

		Private Sub EPaperDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPaperDelete.Click
			Dim isDeleted As Boolean
			Dim anItem As DataListItem
			Dim myContentFilePath As String = Request.PhysicalApplicationPath + "DesktopModules\EPaper\ContentFile\"
			Dim myTemplateFilePath As String = Request.PhysicalApplicationPath + "DesktopModules\EPaper\TemplateFile\"
			Dim myCSSFilePath As String = Request.PhysicalApplicationPath + "DesktopModules\EPaper\CSSFile\"
			Dim myEPaperDAO As New Portal_EPaperDAOExtand
			Dim myEPaperDataSet As DataSet
			Dim myEPaperDeliverManagerDataSet As DataSet
			Dim myEPaperDeliverManagerPartDataSet As DataSet
			Dim myEPaperDeliverManagerDAO As New Portal_EPaperDeliverManagerDAOExtand
			Dim dk As String
			Dim myContentFileName As String = ""
			Dim myTemplateFileName As String = ""
			Dim myCSSFileName As String = ""
			Dim myAuditID As String = ""
			Dim myEPaperDeliverManagerID As String = ""
			Dim i As Integer = 0
			For Each anItem In DataList2.Items
				isDeleted = CType(anItem.FindControl("Edit2"), CheckBox).Checked
				If isDeleted Then
					dk = CType(DataList2.DataKeys(anItem.ItemIndex), String)
					myEPaperDataSet = myEPaperDAO.GetEntitys(dk)
					If myEPaperDataSet.Tables(0).Rows.Count = 1 Then
						myContentFileName = CType(myEPaperDataSet.Tables(0).Rows(0).Item("ContentFile"), String)
						myTemplateFileName = CType(myEPaperDataSet.Tables(0).Rows(0).Item("TemplateFile"), String)
						myCSSFileName = CType(myEPaperDataSet.Tables(0).Rows(0).Item("CSSFile"), String)
					Else
						'exception:epaper record is empty or duplicated
					End If

					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, myEPaperDAO.ToString, "DeleteEntity", dk, "", Context.User.Identity.Name, Now)
					'log before action
					myEPaperDataSet = myEPaperDAO.GetEntitys(dk)
					If myEPaperDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, myEPaperDataSet)
					End If
					'actual action
					myEPaperDAO.DeleteEntity(dk)
					'log after action
					myEPaperDataSet = myEPaperDAO.GetEntitys(dk)
					If myEPaperDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, myEPaperDataSet)
					End If
					myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitysBySubscriptionID(dk)
					If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myEPaperDeliverManagerDataSet.Tables(0).Rows.Count - 1
							myEPaperDeliverManagerID = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, myEPaperDeliverManagerDAO.ToString, "DeleteEntity", myEPaperDeliverManagerID, "", Context.User.Identity.Name, Now)
							'log before action
							myEPaperDeliverManagerPartDataSet = myEPaperDeliverManagerDAO.GetEntitys(myEPaperDeliverManagerID)
							If myEPaperDeliverManagerPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.before, myEPaperDeliverManagerPartDataSet)
							End If
							'actual action
							myEPaperDeliverManagerDAO.DeleteEntity(myEPaperDeliverManagerID)
							'log after action
							myEPaperDeliverManagerPartDataSet = myEPaperDeliverManagerDAO.GetEntitys(myEPaperDeliverManagerID)
							If myEPaperDeliverManagerPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, myEPaperDeliverManagerPartDataSet)
							End If
						Next
					End If

					Try
						File.Delete(myContentFilePath + myContentFileName)
						'audit
						AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myContentFilePath + myContentFileName, "", Context.User.Identity.Name, Now)
					Catch ex As Exception
						'exception:delete content file failure
					End Try
					Try
						File.Delete(myTemplateFilePath + myTemplateFileName)
						'audit
						AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myTemplateFilePath + myTemplateFileName, "", Context.User.Identity.Name, Now)
					Catch ex As Exception
						'exception:delete template file failure
					End Try
					Try
						File.Delete(myCSSFilePath + myCSSFileName)
						'audit
						AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myCSSFilePath + myCSSFileName, "", Context.User.Identity.Name, Now)
					Catch ex As Exception
						'exception:delete css file failure
					End Try
				End If
			Next
			PageReload()
		End Sub

		Private Sub EDeliverManagerPageUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDeliverManagerPageUp.Click
			currentEDeliverManagerPage = currentEDeliverManagerPage - 1
			If currentEDeliverManagerPage < 1 Then
				currentEDeliverManagerPage = 1
			End If
			ViewState("SubscriptionAdminCurrentEDeliverManagerPage") = currentEDeliverManagerPage
			LoadPage()
		End Sub

		Private Sub EDeliverManagerPageDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDeliverManagerPageDown.Click
			currentEDeliverManagerPage = currentEDeliverManagerPage + 1
			If currentEDeliverManagerPage > totalEDeliverManagerPage Then
				currentEDeliverManagerPage = totalEDeliverManagerPage
			End If
			ViewState("SubscriptionAdminCurrentEDeliverManagerPage") = currentEDeliverManagerPage
			LoadPage()
		End Sub

		Private Sub SubscriptionSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionSelect.Click
			Dim isSelect As Boolean
			Dim anItem As DataListItem
			Dim anOption As ListItem
			Dim mySubscriptionTitle As String
			Dim dk As String
			'only one subscription id
			ListBoxSubscription.Items.Clear()
			For Each anItem In DataList1.Items
				isSelect = CType(anItem.FindControl("Edit1"), CheckBox).Checked
				If isSelect Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					mySubscriptionTitle = CType(anItem.FindControl("Edit1"), CheckBox).Text
					anOption = New ListItem
					anOption.Value = dk
					anOption.Text = mySubscriptionTitle
					ListBoxSubscription.Items.Add(anOption)
				End If
			Next
		End Sub

		Private Sub EPaperSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPaperSelect.Click
			Dim isSelect As Boolean
			Dim anItem As DataListItem
			Dim anOption As ListItem
			Dim myEPaperTitle As String
			Dim dk As String
			For Each anItem In DataList2.Items
				isSelect = CType(anItem.FindControl("Edit2"), CheckBox).Checked
				If isSelect Then
					dk = CType(DataList2.DataKeys(anItem.ItemIndex), String)
					myEPaperTitle = CType(anItem.FindControl("Edit2"), CheckBox).Text
					anOption = New ListItem
					anOption.Value = dk
					anOption.Text = myEPaperTitle
					'search if duplicated
					If ListBoxEPaper.Items.FindByValue(dk) Is Nothing Then
						ListBoxEPaper.Items.Add(anOption)
					End If
				End If
			Next
		End Sub

		'Private Sub LinkButtonCalendarSwitch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		'	Calendar1.Visible = True
		'	LinkButtonCalendarSwitch.Visible = False
		'	TextBoxDeliverDate.Visible = False
		'End Sub

		'Private Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		'	Calendar1.Visible = False
		'	LinkButtonCalendarSwitch.Visible = True
		'	TextBoxDeliverDate.Visible = True
		'	TextBoxDeliverDate.Text = CType(Calendar1.SelectedDate, String)
		'End Sub

		Private Sub EDeliverManagerInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDeliverManagerInsert.Click
			Dim myEPaperDeliverManagerDAO As New Portal_EPaperDeliverManagerDAOExtand
			Dim myEPaperDeliverManagerDataSet As DataSet
			Dim anOption As ListItem
			Dim mySubscriptionID As String = ""
			Dim myEPaperID As String = ""
			Dim myDeliverDate As Date = Now
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myDeliverMark As Integer = 0
			Dim dk As String = ""
			Dim myAuditID As String = ""
			'get subscription id
			For Each anOption In ListBoxSubscription.Items
				'only one subscription id
				mySubscriptionID = anOption.Value.Trim
				Exit For
			Next
			ListBoxSubscription.Items.Clear()
			If mySubscriptionID.Length > 0 Then
				''get deliver date
				'If TextBoxDeliverDate.Text.Trim <> "" Then
				'	tempString = TextBoxDeliverDate.Text.Trim
				'	tempArray = tempString.Split(delimiter)
				'	If tempArray.Length = 3 Then
				'		myDeliverDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				'	End If
				'	TextBoxDeliverDate.Text = ""
				'End If
				''get deliver mark
				'If RadioButtonDeliverEnable.Checked = True Then
				'	myDeliverMark = DeliverMark.Enable
				'End If
				'If RadioButtonDeliverDisable.Checked = True Then
				'	myDeliverMark = DeliverMark.Disable
				'End If
				'get epaper id
				For Each anOption In ListBoxEPaper.Items
					myEPaperID = anOption.Value.Trim
					If myEPaperID.Length > 0 Then
						'insert new record in EPaperDeliverManager
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, myEPaperDeliverManagerDAO.ToString, "InsertEntity", dk, "", Context.User.Identity.Name, Now)
						'log before action
						'none
						'actual action
						dk = myEPaperDeliverManagerDAO.InsertEntity(sid, moduleID, 0, myEPaperID, mySubscriptionID, myDeliverDate, myDeliverMark, Context.User.Identity.Name, Now)
						'log after action
						myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(dk)
						If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myEPaperDeliverManagerDataSet)
						End If
					Else
						'exception
					End If
				Next
				ListBoxEPaper.Items.Clear()
			Else
				'exception
			End If
			PageReload()
		End Sub

		Private Sub ImageButtonSubscriptionDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSubscriptionDelete.Click
			Dim isSelect As Boolean
			Dim anOption As ListItem
			For Each anOption In ListBoxSubscription.Items
				isSelect = anOption.Selected
				If isSelect Then
					ListBoxSubscription.Items.Remove(anOption)
					Exit For
				End If
			Next
		End Sub

		Private Sub ImageButtonEPaperDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonEPaperDelete.Click
			Dim isSelect As Boolean
			Dim anOption As ListItem
			For Each anOption In ListBoxEPaper.Items
				isSelect = anOption.Selected
				If isSelect Then
					ListBoxEPaper.Items.Remove(anOption)
					Exit For
				End If
			Next
		End Sub

		Private Sub EDeliverManagerDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDeliverManagerDelete.Click
			Dim isDeleted As Boolean
			Dim anItem As DataListItem
			Dim myEPaperDeliverManagerDAO As New Portal_EPaperDeliverManagerDAOExtand
			Dim myEPaperDeliverManagerDataSet As DataSet
			Dim dk As String
			Dim myAuditID As String = ""
			For Each anItem In DataList3.Items
				isDeleted = CType(anItem.FindControl("Edit3"), CheckBox).Checked
				If isDeleted Then
					dk = CType(DataList3.DataKeys(anItem.ItemIndex), String)
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, myEPaperDeliverManagerDAO.ToString, "DeleteEntity", dk, "", Context.User.Identity.Name, Now)
					'log before action
					myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(dk)
					If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, myEPaperDeliverManagerDataSet)
					End If
					'actual action
					myEPaperDeliverManagerDAO.DeleteEntity(dk)
					'log after action
					myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(dk)
					If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, myEPaperDeliverManagerDataSet)
					End If
				End If
			Next
			PageReload()
		End Sub

		Private Sub EDeliverManagerUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDeliverManagerUpdate.Click
			Dim isModify As Boolean
			Dim anItem As DataListItem
			Dim anOption As ListItem
			Dim dk As String = ""
			Dim myEPaperDeliverManagerDAO As New Portal_EPaperDeliverManagerDAOExtand
			Dim myEPaperDeliverManagerDataSet As DataSet
			Dim myEPaperDAO As New Portal_EPaperDAOExtand
			Dim myEPaperDataSet As DataSet
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim mySubscriptionDataSet As DataSet
			Dim mySubscriptionID As String = ""
			Dim mySubscriptionTitle As String = ""
			Dim myEPaperID As String = ""
			Dim myEPaperTitle As String = ""
			Dim myDeliverDate As Date = Now
			Dim myDeliverMark As Integer = 0
			ListBoxSubscription.Items.Clear()
			ListBoxEPaper.Items.Clear()
			'TextBoxDeliverDate.Text = ""
			For Each anItem In DataList3.Items
				isModify = CType(anItem.FindControl("Edit3"), CheckBox).Checked
				If isModify Then
					dk = CType(DataList3.DataKeys(anItem.ItemIndex), String)
					myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(dk)
					If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count = 1 Then
						mySubscriptionID = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(0).Item("SubscriptionID"), String)
						myEPaperID = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(0).Item("EPaperID"), String)
						myDeliverDate = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(0).Item("DeliverDate"), Date)
						myDeliverMark = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(0).Item("DeliverMark"), Integer)

						'setup control content
						'Subscription part
						mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(mySubscriptionID)
						If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
							mySubscriptionTitle = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("Title"), String)
						Else
							'exception
						End If
						anOption = New ListItem
						anOption.Value = mySubscriptionID
						anOption.Text = mySubscriptionTitle
						ListBoxSubscription.Items.Add(anOption)

						'EPaper part
						myEPaperDataSet = myEPaperDAO.GetEntitys(myEPaperID)
						If myEPaperDataSet.Tables(0).Rows.Count = 1 Then
							myEPaperTitle = CType(myEPaperDataSet.Tables(0).Rows(0).Item("Title"), String)
						Else
							'exception
						End If
						anOption = New ListItem
						anOption.Value = myEPaperID
						anOption.Text = myEPaperTitle
						ListBoxEPaper.Items.Add(anOption)

						''DeliverDate
						'TextBoxDeliverDate.Text = CType(myDeliverDate, String)

						''DeliverMark
						'If myDeliverMark = DeliverMark.Enable Then
						'	RadioButtonDeliverEnable.Checked = True
						'End If
						'If myDeliverMark = DeliverMark.Disable Then
						'	RadioButtonDeliverDisable.Checked = True
						'End If

						''Calendar part
						'Calendar1.SelectedDate = myDeliverDate
					Else
						'exception
					End If
					EDeliverManagerOK.Visible = True
					EDeliverManagerUpdate.Visible = False
				End If
			Next
		End Sub

		Private Sub EDeliverManagerOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDeliverManagerOK.Click
			Dim isModify As Boolean
			Dim anItem As DataListItem
			Dim dk As String = ""
			Dim myEPaperDeliverManagerDAO As New Portal_EPaperDeliverManagerDAOExtand
			Dim myEPaperDeliverManagerID As String = ""
			Dim myEPaperDelivermanagerDataSet As DataSet
			Dim mySubscriptionID As String = ""
			Dim myEPaperID As String = ""
			Dim myDeliverDate As Date = Now
			Dim myDeliverMark As Integer = 0
			Dim anOption As ListItem
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myAuditID As String = ""

			'get entity id
			For Each anItem In DataList3.Items
				isModify = CType(anItem.FindControl("Edit3"), CheckBox).Checked
				If isModify Then
					dk = CType(DataList3.DataKeys(anItem.ItemIndex), String).Trim
				End If
			Next
			If dk.Length > 0 Then
				'delete origin record
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.delete, Me.ToString, myEPaperDeliverManagerDAO.ToString, "DeleteEntity", dk, "", Context.User.Identity.Name, Now)
				'log before action
				myEPaperDelivermanagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(dk)
				If myEPaperDelivermanagerDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, myEPaperDelivermanagerDataSet)
				End If
				'actual action
				myEPaperDeliverManagerDAO.DeleteEntity(dk)
				'log after action
				myEPaperDelivermanagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(dk)
				If myEPaperDelivermanagerDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myEPaperDelivermanagerDataSet)
				End If
				'get subscription id
				For Each anOption In ListBoxSubscription.Items
					'only one subscription id
					mySubscriptionID = anOption.Value.Trim
					Exit For
				Next
				ListBoxSubscription.Items.Clear()
				If mySubscriptionID.Length > 0 Then
					''get deliver date
					'If TextBoxDeliverDate.Text.Trim <> "" Then
					'	tempString = TextBoxDeliverDate.Text.Trim
					'	tempArray = tempString.Split(delimiter)
					'	If tempArray.Length = 3 Then
					'		myDeliverDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
					'	End If
					'	TextBoxDeliverDate.Text = ""
					'End If
					''get deliver mark
					'If RadioButtonDeliverEnable.Checked = True Then
					'	myDeliverMark = DeliverMark.Enable
					'End If
					'If RadioButtonDeliverDisable.Checked = True Then
					'	myDeliverMark = DeliverMark.Disable
					'End If
					'get epaper id
					For Each anOption In ListBoxEPaper.Items
						myEPaperID = anOption.Value.Trim
						If myEPaperID.Length > 0 Then
							'insert new record in EPaperDeliverManager
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, myEPaperDeliverManagerDAO.ToString, "InsertEntity", myEPaperDeliverManagerID, "", Context.User.Identity.Name, Now)
							'log before action
							'none
							'actual action
							myEPaperDeliverManagerID = myEPaperDeliverManagerDAO.InsertEntity(sid, moduleID, 0, myEPaperID, mySubscriptionID, myDeliverDate, myDeliverMark, Context.User.Identity.Name, Now)
							'log after action
							myEPaperDelivermanagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(myEPaperDeliverManagerID)
							If myEPaperDelivermanagerDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, myEPaperDelivermanagerDataSet)
							End If
						Else
							'exception
						End If
					Next
					ListBoxEPaper.Items.Clear()
				Else
					'exception
				End If
				EDeliverManagerOK.Visible = False
				EDeliverManagerUpdate.Visible = True
				PageReload()
			Else
				'exception
			End If
		End Sub

		Private Sub SubscriptionListEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionListEdit.Click
			Dim isEdit As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			For Each anItem In DataList1.Items
				isEdit = CType(anItem.FindControl("Edit1"), CheckBox).Checked
				If isEdit Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					Response.Redirect("~/DesktopModules/EPaper/SubscriptionListAdmin.aspx?mid=" & moduleID & "&sid=" & sid & "&subscriptionid=" & dk & "&tabindex=" & tabIndex)
				End If
			Next
		End Sub

		Private Sub EDeliverManagerSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDeliverManagerSend.Click
			Dim isSelected As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			For Each anItem In DataList3.Items
				isSelected = CType(anItem.FindControl("Edit3"), CheckBox).Checked
				If isSelected Then
					dk = CType(DataList3.DataKeys(anItem.ItemIndex), String)
					DeliverEPaper(dk)
				End If
			Next
		End Sub
		Private Sub DeliverEPaper(ByVal deliverID As String)
			Dim myEPaperDeliverManagerDAO As New Portal_EPaperDeliverManagerDAOExtand
			Dim myEPaperDAO As New Portal_EPaperDAOExtand
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim mySubscriptionListDAO As New Portal_SubscriptionListDAOExtand
			Dim mySubscriptionUserDAO As New Portal_SubscriptionUserDAOExtand
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim myEPaperDeliverManagerDataSet As DataSet
			Dim myEPaperDeliverManagerPartDataSet As DataSet
			Dim myEPaperDataSet As DataSet
			Dim mySubscriptionDataSet As DataSet
			Dim mySubscriptionListDataSet As DataSet
			Dim mySubscriptionListPartDataSet As DataSet
			Dim mySubscriptionUserDataSet As DataSet
			Dim myAPLTBLDataSet As DataSet
			Dim myEPaperID As String = ""
			Dim mySubscriptionID As String = ""
			Dim mySubscriptionListID As String = ""
			Dim myEPaperDeliverManagerID As String = ""
			Dim myContentFile As String = ""
			Dim mySubscriptionTitle As String = ""
			Dim myUserType As Integer = 0
			Dim myUserID As String = ""
			Dim myEmail As String = ""
			Dim i As Integer = 0
			Dim myAuditID As String = ""

			myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(deliverID)
			If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count = 1 Then
				myEPaperID = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(0).Item("EPaperID"), String)
				mySubscriptionID = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(0).Item("SubscriptionID"), String)

				myEPaperDataSet = myEPaperDAO.GetEntitys(myEPaperID)
				If myEPaperDataSet.Tables(0).Rows.Count = 1 Then
					myContentFile = CType(myEPaperDataSet.Tables(0).Rows(0).Item("ContentFile"), String)
				Else
					'exception:epaper record is empty or duplicated
				End If

				mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(mySubscriptionID)
				If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
					mySubscriptionTitle = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("Title"), String)
				Else
					'exception:subscription record is empty or duplicated
				End If

				mySubscriptionListDataSet = mySubscriptionListDAO.GetEntitys(mySubscriptionID)
				If mySubscriptionListDataSet.Tables(0).Rows.Count > 0 Then
					For i = 0 To mySubscriptionListDataSet.Tables(0).Rows.Count - 1
						myUserType = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("UserType"), Integer)
						myUserID = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("UserID"), String)

						If myUserType = SubscriptionUserType.Subscription Then
							mySubscriptionUserDataSet = mySubscriptionUserDAO.GetEntitys(myUserID)
							If mySubscriptionUserDataSet.Tables(0).Rows.Count = 1 Then
								myEmail = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Email"), String)
								If (myEmail.Trim.Length > 0) And (myContentFile.Trim.Length > 0) Then
									If SendMail(mySubscriptionTitle, myEmail, myContentFile) Then
										'update subscription list deliver mark
										mySubscriptionListID = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("EntityID"), String)
										'audit
										myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.update, Me.ToString, mySubscriptionListDAO.ToString, "UpdateEntity", mySubscriptionListID, "", Context.User.Identity.Name, Now)
										'log before action
										mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
										If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.before, mySubscriptionListPartDataSet)
										End If
										'actual action
										mySubscriptionListDAO.UpdateEntity(mySubscriptionListID, DeliverMark.Disable)
										'log after action
										mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
										If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.after, mySubscriptionListPartDataSet)
										End If
										'statistic
										ModuleStatisticDAO.InsertEntity(sid, moduleID, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, Now)
									End If
								End If
							Else
								'exception:subscription user record is empty or duplicated
							End If
						Else
							If myUserType = SubscriptionUserType.School Then
								myAPLTBLDataSet = myAPLTBLDAO.GetEntitys(CType(myUserID, Integer))
								If myAPLTBLDataSet.Tables(0).Rows.Count = 1 Then
									myEmail = CType(myAPLTBLDataSet.Tables(0).Rows(0).Item("E_MAIL"), String)
									If (myEmail.Trim.Length > 0) And (myContentFile.Trim.Length > 0) Then
										If SendMail(mySubscriptionTitle, myEmail, myContentFile) Then
											'update subscription list deliver mark
											mySubscriptionListID = CType(mySubscriptionListDataSet.Tables(0).Rows(i).Item("EntityID"), String)
											'audit
											myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.update, Me.ToString, mySubscriptionListDAO.ToString, "UpdateEntity", mySubscriptionListID, "", Context.User.Identity.Name, Now)
											'log before action
											mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
											If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
												AuditDetail(myAuditID, SequenceType.before, mySubscriptionListPartDataSet)
											End If
											'actual action
											mySubscriptionListDAO.UpdateEntity(mySubscriptionListID, DeliverMark.Disable)
											'log after action
											mySubscriptionListPartDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
											If mySubscriptionListPartDataSet.Tables(0).Rows.Count = 1 Then
												AuditDetail(myAuditID, SequenceType.after, mySubscriptionListPartDataSet)
											End If
											'statistic
											ModuleStatisticDAO.InsertEntity(sid, moduleID, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, Now)
										End If
									End If
								Else
									'exception:apltbl record is empty or duplicated
								End If
							Else
								'exception:unknown user type
							End If
						End If
					Next
				End If
				'update epaper deliver mansger deliver mark
				myEPaperDeliverManagerID = CType(myEPaperDeliverManagerDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.update, Me.ToString, myEPaperDeliverManagerDAO.ToString, "UpdateEntity", myEPaperDeliverManagerID, "", Context.User.Identity.Name, Now)
				'log before action
				myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(myEPaperDeliverManagerID)
				If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, myEPaperDeliverManagerDataSet)
				End If
				'actual action
				myEPaperDeliverManagerDAO.UpdateEntity(myEPaperDeliverManagerID, DeliverMark.Disable)
				'log after action
				myEPaperDeliverManagerDataSet = myEPaperDeliverManagerDAO.GetEntitys(myEPaperDeliverManagerID)
				If myEPaperDeliverManagerDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myEPaperDeliverManagerDataSet)
				End If
			Else
				'exception:epaper deliver manager record is empty
			End If
		End Sub
		Private Function SendMail(ByVal subscriptionTitle As String, ByVal email As String, ByVal contentFileName As String) As Boolean
			Dim myMailMessage As New MailMessage
			Dim messageBody As String = ""
			Dim myPath As String = Request.PhysicalApplicationPath + "DesktopModules\EPaper\ContentFile\"
			myMailMessage.From = adminEmail
			myMailMessage.To = email
			myMailMessage.Subject = subscriptionTitle
			myMailMessage.Priority = MailPriority.Normal
			myMailMessage.BodyFormat = MailFormat.Html
			'load content file
			'exam if file exists
			If File.Exists(myPath + contentFileName) Then
				' Open the stream and read it back.
				Dim sr As StreamReader = File.OpenText(myPath + contentFileName)
				Do While sr.Peek() >= 0
					messageBody = messageBody + sr.ReadLine()
				Loop
				sr.Close()
			Else
				'exception
				Return False
			End If
			myMailMessage.Body = messageBody
			SmtpMail.Send(myMailMessage)
			'audit
			AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, "System.Web.Mail.SmtpMail", "Send", myPath + contentFileName, "", Context.User.Identity.Name, Now)
		End Function

		Private Sub SubscriptionListImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionListImport.Click
			Dim isImport As Boolean
			Dim anItem As DataListItem
			Dim dk As String
			For Each anItem In DataList1.Items
				isImport = CType(anItem.FindControl("Edit1"), CheckBox).Checked
				If isImport Then
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					Response.Redirect("~/DesktopModules/EPaper/SubscriptionListImport.aspx?sid=" & sid & "&mid=" & moduleID & "&subscriptionid=" & dk & "&tabid=" & tabId & "&tabindex=" & tabIndex)
				End If
			Next
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