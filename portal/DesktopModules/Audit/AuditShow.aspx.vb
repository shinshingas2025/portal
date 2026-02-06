Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class AuditShow
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents Label2 As System.Web.UI.WebControls.Label
		Protected WithEvents Label3 As System.Web.UI.WebControls.Label
		Protected WithEvents Label4 As System.Web.UI.WebControls.Label
		Protected WithEvents Label5 As System.Web.UI.WebControls.Label
		Protected WithEvents Label6 As System.Web.UI.WebControls.Label
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDetail As System.Web.UI.WebControls.Label
		Protected WithEvents LabelUserName As System.Web.UI.WebControls.Label
		Protected WithEvents LabelModuleName As System.Web.UI.WebControls.Label
		Protected WithEvents LabelActionType As System.Web.UI.WebControls.Label
		Protected WithEvents LabelCreatedDate As System.Web.UI.WebControls.Label
		Protected WithEvents LabelSender As System.Web.UI.WebControls.Label
		Protected WithEvents LabelReceiver As System.Web.UI.WebControls.Label
		Protected WithEvents LabelService As System.Web.UI.WebControls.Label
		Protected WithEvents Label8 As System.Web.UI.WebControls.Label
		Protected WithEvents LabelPrimaryKey As System.Web.UI.WebControls.Label
		Protected WithEvents Label9 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected WithEvents Label10 As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolder1 As System.Web.UI.WebControls.PlaceHolder

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
		Private auditID As String = ""
		Protected pageSize As Integer = 10
		Protected totalBulletinIndividualPage As Integer = 0
		Protected currentBulletinIndividualPage As Integer = 0
		Protected totalBulletinCommunityPage As Integer = 0
		Protected currentBulletinCommunityPage As Integer = 0

		Enum ActionType
			all = 0
			insert = 1
			update = 2
			delete = 3
		End Enum
		Enum SequenceType
			before = 1
			after = 2
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

			If Not (Request.Params("auditid") Is Nothing) Then
				auditID = Request.Params("auditid").Trim
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub


		Private Sub PageLoad()
			Dim myAuditDAO As New Portal_AuditDAOExtand
			Dim myAuditDataSet As DataSet
			Dim myAuditID As String = ""
			Dim myModuleID As Integer = 0
			Dim myListItem As ListItem
			Dim myActionID As Integer = 0
			Dim myCreatedDate As Date = Now
			Dim i As Integer = 0

			'initial web control
			LabelUserName.Text = ""
			LabelModuleName.Text = ""
			LabelActionType.Text = ""
			LabelCreatedDate.Text = ""
			LabelSender.Text = ""
			LabelReceiver.Text = ""
			LabelService.Text = ""
			LabelPrimaryKey.Text = ""
			LabelDescription.Text = ""
			PlaceHolder1.Controls.Clear()

			'read total row
			If auditID.Length > 0 Then
				myAuditDataSet = myAuditDAO.GetEntity(auditID)

				If myAuditDataSet.Tables(0).Rows.Count = 1 Then
					LabelUserName.Text = CType(myAuditDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim

					myAuditID = CType(myAuditDataSet.Tables(0).Rows(0).Item("EntityID"), String)

					myModuleID = CType(myAuditDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
					If myModuleID <> 0 Then
						LabelModuleName.Text = myAuditDAO.GetModuleName(myModuleID)
					End If

					myActionID = CType(myAuditDataSet.Tables(0).Rows(0).Item("ActionID"), Integer)
					If myActionID = ActionType.insert Then
						LabelActionType.Text = "新增"
					End If
					If myActionID = ActionType.update Then
						LabelActionType.Text = "修改"
					End If
					If myActionID = ActionType.delete Then
						LabelActionType.Text = "刪除"
					End If

					myCreatedDate = CType(myAuditDataSet.Tables(0).Rows(0).Item("CreatedDate"), Date)
					LabelCreatedDate.Text = myCreatedDate.Year & "/" & myCreatedDate.Month & "/" & myCreatedDate.Day & " " & myCreatedDate.Hour & ":" & myCreatedDate.Minute & ":" & myCreatedDate.Second

					LabelSender.Text = CType(myAuditDataSet.Tables(0).Rows(0).Item("Sender"), String).Trim

					LabelReceiver.Text = CType(myAuditDataSet.Tables(0).Rows(0).Item("Receiver"), String).Trim

					LabelService.Text = CType(myAuditDataSet.Tables(0).Rows(0).Item("Service"), String).Trim

					LabelPrimaryKey.Text = CType(myAuditDataSet.Tables(0).Rows(0).Item("DataKey"), String).Trim

					LabelDescription.Text = CType(myAuditDataSet.Tables(0).Rows(0).Item("Description"), String).Trim

					ReadDetail(myAuditID, myActionID)
				Else
					'exception:audit data is empty or duplicated
				End If
			Else
				'exception:audit id is empty
			End If
		End Sub
		Private Sub ReadDetail(ByVal myAuditID As String, ByVal myActionID As Integer)
			Dim myAuditDetailDAO As New Portal_AuditDetailDAOExtand
			Dim myAuditDetailBeforeDataSet As DataSet
			Dim myAuditDetailAfterDataSet As DataSet
			Dim myColumnName As String = ""
			Dim myColumnValue As String = ""
			Dim myTableControl As Table
			Dim myTableRowControl As TableRow
			Dim myTableHeaderCellControl As TableHeaderCell
			Dim myTableCellControl As TableCell
			Dim mySequenceID As Integer = 0
			Dim i As Integer = 0

			If myAuditID.Trim.Length > 0 Then
				myTableControl = New Table
				myTableControl.GridLines = GridLines.Both
				myAuditDetailBeforeDataSet = myAuditDetailDAO.GetEntitysBySequenceID(auditID, SequenceType.before)
				myAuditDetailAfterDataSet = myAuditDetailDAO.GetEntitysBySequenceID(auditID, SequenceType.after)
				'prepare table header
				myTableRowControl = New TableRow
				myTableHeaderCellControl = New TableHeaderCell
				myTableHeaderCellControl.Text = "記錄時間"
				myTableRowControl.Controls.Add(myTableHeaderCellControl)
				If myActionID = ActionType.insert Then
					If myAuditDetailAfterDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAuditDetailAfterDataSet.Tables(0).Rows.Count - 1
							myColumnName = CType(myAuditDetailAfterDataSet.Tables(0).Rows(i).Item("ColumnName"), String)

							myTableHeaderCellControl = New TableHeaderCell
							myTableHeaderCellControl.Text = myColumnName

							myTableRowControl.Controls.Add(myTableHeaderCellControl)
						Next
					End If
				End If
				If myActionID = ActionType.update Then
					If myAuditDetailAfterDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAuditDetailAfterDataSet.Tables(0).Rows.Count - 1
							myColumnName = CType(myAuditDetailAfterDataSet.Tables(0).Rows(i).Item("ColumnName"), String)

							myTableHeaderCellControl = New TableHeaderCell
							myTableHeaderCellControl.Text = myColumnName

							myTableRowControl.Controls.Add(myTableHeaderCellControl)
						Next
					End If
				End If
				If myActionID = ActionType.delete Then
					If myAuditDetailBeforeDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAuditDetailBeforeDataSet.Tables(0).Rows.Count - 1
							myColumnName = CType(myAuditDetailBeforeDataSet.Tables(0).Rows(i).Item("ColumnName"), String)

							myTableHeaderCellControl = New TableHeaderCell
							myTableHeaderCellControl.Text = myColumnName

							myTableRowControl.Controls.Add(myTableHeaderCellControl)
						Next
					End If
				End If
				myTableControl.Controls.Add(myTableRowControl)
				'prepare data
				If myActionID = ActionType.insert Then
					'before
					myTableRowControl = New TableRow
					myTableCellControl = New TableCell
					myTableCellControl.Text = "執行前"
					myTableRowControl.Controls.Add(myTableCellControl)
					myTableControl.Controls.Add(myTableRowControl)
					'after
					myTableRowControl = New TableRow
					myTableCellControl = New TableCell
					myTableCellControl.Text = "執行後"
					myTableRowControl.Controls.Add(myTableCellControl)
					If myAuditDetailAfterDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAuditDetailAfterDataSet.Tables(0).Rows.Count - 1
							myColumnValue = CType(myAuditDetailAfterDataSet.Tables(0).Rows(i).Item("ColumnValue"), String)

							myTableCellControl = New TableCell
							myTableCellControl.Text = myColumnValue

							myTableRowControl.Controls.Add(myTableCellControl)
						Next
					End If
					myTableControl.Controls.Add(myTableRowControl)
				End If
				If myActionID = ActionType.update Then
					'before
					myTableRowControl = New TableRow
					myTableCellControl = New TableCell
					myTableCellControl.Text = "執行前"
					myTableRowControl.Controls.Add(myTableCellControl)
					If myAuditDetailBeforeDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAuditDetailBeforeDataSet.Tables(0).Rows.Count - 1
							myColumnValue = CType(myAuditDetailBeforeDataSet.Tables(0).Rows(i).Item("ColumnValue"), String)

							myTableCellControl = New TableCell
							myTableCellControl.Text = myColumnValue

							myTableRowControl.Controls.Add(myTableCellControl)
						Next
					End If
					myTableControl.Controls.Add(myTableRowControl)
					'after
					myTableRowControl = New TableRow
					myTableCellControl = New TableCell
					myTableCellControl.Text = "執行後"
					myTableRowControl.Controls.Add(myTableCellControl)
					If myAuditDetailAfterDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAuditDetailAfterDataSet.Tables(0).Rows.Count - 1
							myColumnValue = CType(myAuditDetailAfterDataSet.Tables(0).Rows(i).Item("ColumnValue"), String)

							myTableCellControl = New TableCell
							myTableCellControl.Text = myColumnValue

							myTableRowControl.Controls.Add(myTableCellControl)
						Next
					End If
					myTableControl.Controls.Add(myTableRowControl)
				End If
				If myActionID = ActionType.delete Then
					'before
					myTableRowControl = New TableRow
					myTableCellControl = New TableCell
					myTableCellControl.Text = "執行前"
					myTableRowControl.Controls.Add(myTableCellControl)
					If myAuditDetailBeforeDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAuditDetailBeforeDataSet.Tables(0).Rows.Count - 1
							myColumnValue = CType(myAuditDetailBeforeDataSet.Tables(0).Rows(i).Item("ColumnValue"), String)

							myTableCellControl = New TableCell
							myTableCellControl.Text = myColumnValue

							myTableRowControl.Controls.Add(myTableCellControl)
						Next
					End If
					myTableControl.Controls.Add(myTableRowControl)
					'after
					myTableRowControl = New TableRow
					myTableCellControl = New TableCell
					myTableCellControl.Text = "執行後"
					myTableRowControl.Controls.Add(myTableCellControl)
					If myAuditDetailAfterDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myAuditDetailAfterDataSet.Tables(0).Rows.Count - 1
							myColumnValue = CType(myAuditDetailAfterDataSet.Tables(0).Rows(i).Item("ColumnValue"), String)

							myTableCellControl = New TableCell
							myTableCellControl.Text = myColumnValue

							myTableRowControl.Controls.Add(myTableCellControl)
						Next
					End If
					myTableControl.Controls.Add(myTableRowControl)
				End If

				PlaceHolder1.Controls.Add(myTableControl)
			Else
				'exception:audit id is empty
			End If
		End Sub
		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class
End Namespace