Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class ImportExportAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label2 As System.Web.UI.WebControls.Label
		Protected WithEvents Label3 As System.Web.UI.WebControls.Label
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents Label5 As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxImportTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxImportDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxExportTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxExportDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonImportInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonImportUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonImportDelete As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonImportColumnEdit As System.Web.UI.WebControls.Button
		Protected WithEvents Label4 As System.Web.UI.WebControls.Label
		Protected WithEvents Label6 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonExportInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonExportUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonExportDelete As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonExportColumnEdit As System.Web.UI.WebControls.Button
		Protected WithEvents Label8 As System.Web.UI.WebControls.Label
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
		Enum TableGroup
			user = 1
		End Enum

		Private APLTBLID As String = "2005120100000001"
		Private APSTBLID As String = "2005120100000003"
		Private O_APSTBLID As String = "2005120100000004"

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
				PageLoad()
			End If
		End Sub


		Private Sub PageLoad()
			Dim myImportDAO As New Portal_ImportDAOExtand
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myImportDataSet As DataSet
			Dim myExportDataSet As DataSet
			Dim i As Integer = 0
			'prepare control data
			'import
			myImportDataSet = myImportDAO.GetEntitys(sid, moduleId)
			If myImportDataSet.Tables(0).Rows.Count = 1 Then
				TextBoxImportTitle.Text = CType(myImportDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
				TextBoxImportDescription.Text = CType(myImportDataSet.Tables(0).Rows(0).Item("Description"), String).Trim
			Else
				If myImportDataSet.Tables(0).Rows.Count = 0 Then
					TextBoxImportTitle.Text = ""
					TextBoxImportDescription.Text = ""
				Else
					'exception:import record is duplicated
				End If
			End If
			'export
			myExportDataSet = myExportDAO.GetEntitys(sid, moduleId)
			If myExportDataSet.Tables(0).Rows.Count = 1 Then
				TextBoxExportTitle.Text = CType(myExportDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
				TextBoxExportDescription.Text = CType(myExportDataSet.Tables(0).Rows(0).Item("Description"), String).Trim
			Else
				If myExportDataSet.Tables(0).Rows.Count = 0 Then
					TextBoxExportTitle.Text = ""
					TextBoxExportDescription.Text = ""
				Else
					'exception:export record is duplicated
				End If
			End If
		End Sub

		Private Sub ButtonImportInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImportInsert.Click
			Dim myImportDAO As New Portal_ImportDAOExtand
			Dim myImportDataSet As DataSet
			Dim myTableColumnDAO As New Oracle_TableColumnDAOExtand
			Dim myTableColumnDataSet As DataSet
			Dim myTableColumnPartDataSet As DataSet
			Dim myImportColumnDAO As New Portal_ImportColumnDAOExtand
			Dim myImportColumnDataSet As DataSet
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myImportID As String = ""
			Dim myTableColumnID As String = ""
			Dim myImportColumnID As String = ""
			Dim myImportOrder As Integer = 0
			Dim myImportPrimaryKey As Integer = 0
			Dim i As Integer = 0
			Dim offset As Integer = 0
			Dim myAuditID As String = ""

			myTitle = TextBoxImportTitle.Text.Trim
			myDescription = TextBoxImportDescription.Text.Trim

			myImportDataSet = myImportDAO.GetEntitys(sid, moduleId)
			If myImportDataSet.Tables(0).Rows.Count = 0 Then
				'insert new import record
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myImportDAO.ToString, "InsertEntity", myImportID, "", Context.User.Identity.Name, Now)
				'log before action
				'none
				'actual action
				myImportID = myImportDAO.InsertEntity(sid, moduleId, 0, TableGroup.user, myTitle, myDescription, "", Context.User.Identity.Name, Now)
				'log after action
				myImportDataSet = myImportDAO.GetEntity(myImportID)
				If myImportDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, myImportDataSet)
				End If
				'insert default import column record
				'APLTBL
				myTableColumnDataSet = myTableColumnDAO.GetEntitys(APLTBLID)
				For i = 1 To myTableColumnDataSet.Tables(0).Rows.Count - 1
					myTableColumnID = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					'myImportOrder = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("ColumnOrder"), Integer)
					myImportOrder = i
					myImportPrimaryKey = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("ColumnPrimaryKey"), Integer)

					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myImportColumnDAO.ToString, "InsertEntity", myImportColumnID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					myImportColumnID = myImportColumnDAO.InsertEntity(myImportID, myTableColumnID, 0, myImportOrder, myImportPrimaryKey, Context.User.Identity.Name, Now)
					'log after action
					myImportColumnDataSet = myImportColumnDAO.GetEntity(myImportColumnID)
					If myImportColumnDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, myImportColumnDataSet)
					End If
				Next
				offset = myTableColumnDataSet.Tables(0).Rows.Count - 1
				'APSTBL
				myTableColumnDataSet = myTableColumnDAO.GetEntitys(APSTBLID)
				For i = 2 To myTableColumnDataSet.Tables(0).Rows.Count - 1
					myTableColumnID = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					'myImportOrder = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("ColumnOrder"), Integer) + myTableColumnDataSet.Tables(0).Rows.Count - 1
					myImportOrder = i - 1 + offset
					myImportPrimaryKey = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("ColumnPrimaryKey"), Integer)

					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myImportColumnDAO.ToString, "InsertEntity", myImportColumnID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					myImportColumnID = myImportColumnDAO.InsertEntity(myImportID, myTableColumnID, 0, myImportOrder, myImportPrimaryKey, Context.User.Identity.Name, Now)
					'log after action
					myImportColumnDataSet = myImportColumnDAO.GetEntity(myImportColumnID)
					If myImportColumnDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, myImportColumnDataSet)
					End If
				Next
				offset = offset + myTableColumnDataSet.Tables(0).Rows.Count - 2
				'O_APSTBL
				myTableColumnDataSet = myTableColumnDAO.GetEntitys(O_APSTBLID)
				For i = 2 To myTableColumnDataSet.Tables(0).Rows.Count - 1
					myTableColumnID = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					'myImportOrder = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("ColumnOrder"), Integer) + myTableColumnDataSet.Tables(0).Rows.Count + myTableColumnDataSet.Tables(0).Rows.Count - 3
					myImportOrder = i - 1 + offset
					myImportPrimaryKey = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("ColumnPrimaryKey"), Integer)

					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myImportColumnDAO.ToString, "InsertEntity", myImportColumnID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					myImportColumnID = myImportColumnDAO.InsertEntity(myImportID, myTableColumnID, 0, myImportOrder, myImportPrimaryKey, Context.User.Identity.Name, Now)
					'log after action
					myImportColumnDataSet = myImportColumnDAO.GetEntity(myImportColumnID)
					If myImportColumnDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.before, myImportColumnDataSet)
					End If
				Next
			Else
				'exception:import record is not empty
			End If
			PageLoad()
		End Sub

		Private Sub ButtonImportDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImportDelete.Click
			Dim myImportDAO As New Portal_ImportDAOExtand
			Dim myImportDataSet As DataSet
			Dim myImportColumnDAO As New Portal_ImportColumnDAOExtand
			Dim myImportColumnDataSet As DataSet
			Dim myImportColumnPartDataSet As DataSet
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myImportID As String = ""
			Dim myImportColumnID As String = ""
			Dim myImportOrder As Integer = 0
			Dim myImportPrimaryKey As Integer = 0
			Dim i As Integer = 0
			Dim myAuditID As String = ""

			myImportDataSet = myImportDAO.GetEntitys(sid, moduleId)
			If myImportDataSet.Tables(0).Rows.Count = 1 Then
				'delete import record
				myImportID = CType(myImportDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myImportDAO.ToString, "DeleteEntity", myImportID, "", Context.User.Identity.Name, Now)
				'log before action
				myImportDataSet = myImportDAO.GetEntity(myImportID)
				If myImportDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, myImportDataSet)
				End If
				'actual action
				myImportDAO.DeleteEntity(myImportID)
				'log after action
				myImportDataSet = myImportDAO.GetEntity(myImportID)
				If myImportDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myImportDataSet)
				End If
				'delete import column record
				myImportColumnDataSet = myImportColumnDAO.GetEntityByImportID(myImportID)
				If myImportColumnDataSet.Tables(0).Rows.Count > 0 Then
					For i = 0 To myImportColumnDataSet.Tables(0).Rows.Count - 1
						myImportColumnID = CType(myImportColumnDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myImportColumnDAO.ToString, "DeleteEntity", myImportColumnID, "", Context.User.Identity.Name, Now)
						'log before action
						myImportColumnPartDataSet = myImportColumnDAO.GetEntity(myImportColumnID)
						If myImportColumnPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.before, myImportColumnPartDataSet)
						End If
						'actual action
						myImportColumnDAO.DeleteEntity(myImportColumnID)
						'log after action
						myImportColumnPartDataSet = myImportColumnDAO.GetEntity(myImportColumnID)
						If myImportColumnPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myImportColumnPartDataSet)
						End If
					Next
				End If
			Else
				If myImportDataSet.Tables(0).Rows.Count > 1 Then
					'exception:import record is duplicated
				Else
					'exception:import record is empty
				End If
			End If
			PageLoad()
		End Sub

		Private Sub ButtonImportUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImportUpdate.Click
			Dim myImportDAO As New Portal_ImportDAOExtand
			Dim myImportDataSet As DataSet
			Dim myImportPartDataSet As DataSet
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myImportID As String = ""
			Dim myAuditID As String = ""

			myTitle = TextBoxImportTitle.Text.Trim
			myDescription = TextBoxImportDescription.Text.Trim

			myImportDataSet = myImportDAO.GetEntitys(sid, moduleId)
			If myImportDataSet.Tables(0).Rows.Count = 1 Then
				'insert new import record
				myImportID = CType(myImportDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myImportDAO.ToString, "UpdateEntity", myImportID, "", Context.User.Identity.Name, Now)
				'log before action
				myImportPartDataSet = myImportDAO.GetEntity(myImportID)
				If myImportPartDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, myImportPartDataSet)
				End If
				'actual action
				myImportDAO.UpdateEntity(myImportID, myTitle, myDescription)
				'log after action
				myImportPartDataSet = myImportDAO.GetEntity(myImportID)
				If myImportPartDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myImportPartDataSet)
				End If
			Else
				If myImportDataSet.Tables(0).Rows.Count > 1 Then
					'exception:import record is duplicated
				Else
					'exception:import record id empty
				End If
			End If
			PageLoad()
		End Sub

		Private Sub ButtonExportInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportInsert.Click
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myExportDataSet As DataSet
			Dim myTableColumnDAO As New Oracle_TableColumnDAOExtand
			Dim myTableColumnDataSet As DataSet
			Dim myExportColumnDAO As New Portal_ExportColumnDAOExtand
			Dim myExportColumnDataSet As DataSet
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myExportID As String = ""
			Dim myTableColumnID As String = ""
			Dim myExportColumnID As String = ""
			Dim myExportOrder As Integer = 0
			Dim i As Integer = 0
			Dim offset As Integer = 0
			Dim myAuditID As String = ""

			myTitle = TextBoxExportTitle.Text.Trim
			myDescription = TextBoxExportDescription.Text.Trim

			myExportDataSet = myExportDAO.GetEntitys(sid, moduleId)
			If myExportDataSet.Tables(0).Rows.Count = 0 Then
				'insert new export record
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myExportDAO.ToString, "InsertEntity", myExportID, "", Context.User.Identity.Name, Now)
				'log before action
				'none
				'actual action
				myExportID = myExportDAO.InsertEntity(sid, moduleId, 0, TableGroup.user, myTitle, myDescription, Context.User.Identity.Name, Now)
				'log after action
				myExportDataSet = myExportDAO.GetEntity(myExportID)
				If myExportDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myExportDataSet)
				End If
				'insert default export column record
				'APLTBL
				myTableColumnDataSet = myTableColumnDAO.GetEntitys(APLTBLID)
				For i = 1 To myTableColumnDataSet.Tables(0).Rows.Count - 1
					myTableColumnID = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myExportOrder = i

					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myExportColumnDAO.ToString, "InsertEntity", myExportColumnID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					myExportColumnID = myExportColumnDAO.InsertEntity(myExportID, myTableColumnID, 0, myExportOrder, Context.User.Identity.Name, Now)
					'log after action
					myExportColumnDataSet = myExportColumnDAO.GetEntity(myExportColumnID)
					If myExportColumnDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, myExportColumnDataSet)
					End If
				Next
				offset = myTableColumnDataSet.Tables(0).Rows.Count - 1
				'APSTBL
				myTableColumnDataSet = myTableColumnDAO.GetEntitys(APSTBLID)
				For i = 2 To myTableColumnDataSet.Tables(0).Rows.Count - 1
					myTableColumnID = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myExportOrder = i - 1 + offset

					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myExportColumnDAO.ToString, "InsertEntity", myExportColumnID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					myExportColumnID = myExportColumnDAO.InsertEntity(myExportID, myTableColumnID, 0, myExportOrder, Context.User.Identity.Name, Now)
					'log after action
					myExportColumnDataSet = myExportColumnDAO.GetEntity(myExportColumnID)
					If myExportColumnDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, myExportColumnDataSet)
					End If
				Next
				offset = offset + myTableColumnDataSet.Tables(0).Rows.Count - 2
				'O_APSTBL
				myTableColumnDataSet = myTableColumnDAO.GetEntitys(O_APSTBLID)
				For i = 2 To myTableColumnDataSet.Tables(0).Rows.Count - 1
					myTableColumnID = CType(myTableColumnDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myExportOrder = i - 1 + offset

					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myExportColumnDAO.ToString, "InsertEntity", myExportColumnID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					myExportColumnID = myExportColumnDAO.InsertEntity(myExportID, myTableColumnID, 0, myExportOrder, Context.User.Identity.Name, Now)
					'log after action
					myExportColumnDataSet = myExportColumnDAO.GetEntity(myExportColumnID)
					If myExportColumnDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, myExportColumnDataSet)
					End If
				Next
			Else
				'exception:export record is not empty
			End If
			PageLoad()
		End Sub

		Private Sub ButtonExportUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportUpdate.Click
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myExportDataSet As DataSet
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myExportID As String = ""
			Dim myAuditID As String = ""

			myTitle = TextBoxExportTitle.Text.Trim
			myDescription = TextBoxExportDescription.Text.Trim

			myExportDataSet = myExportDAO.GetEntitys(sid, moduleId)
			If myExportDataSet.Tables(0).Rows.Count = 1 Then
				'insert new export record
				myExportID = CType(myExportDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myExportDAO.ToString, "UpdateEntity", myExportID, "", Context.User.Identity.Name, Now)
				'log before action
				myExportDataSet = myExportDAO.GetEntity(myExportID)
				If myExportDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, myExportDataSet)
				End If
				'actual action
				myExportDAO.UpdateEntity(myExportID, myTitle, myDescription)
				'log after action
				myExportDataSet = myExportDAO.GetEntity(myExportID)
				If myExportDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myExportDataSet)
				End If
			Else
				If myExportDataSet.Tables(0).Rows.Count > 1 Then
					'exception:export record is duplicated
				Else
					'exception:export record id empty
				End If
			End If
			PageLoad()
		End Sub

		Private Sub ButtonExportDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportDelete.Click
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myExportDataSet As DataSet
			Dim myExportColumnDAO As New Portal_ExportColumnDAOExtand
			Dim myExportColumnDataSet As DataSet
			Dim myExportColumnPartDataSet As DataSet
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myExportID As String = ""
			Dim myExportColumnID As String = ""
			Dim myExportOrder As Integer = 0
			Dim myExportPrimaryKey As Integer = 0
			Dim i As Integer = 0
			Dim myAuditID As String = ""

			myExportDataSet = myExportDAO.GetEntitys(sid, moduleId)
			If myExportDataSet.Tables(0).Rows.Count = 1 Then
				'delete export record
				myExportID = CType(myExportDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myExportDAO.ToString, "DeleteEntity", myExportID, "", Context.User.Identity.Name, Now)
				'log before action
				myExportDataSet = myExportDAO.GetEntity(myExportID)
				If myExportDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, myExportDataSet)
				End If
				'actual action
				myExportDAO.DeleteEntity(myExportID)
				'log after action
				myExportDataSet = myExportDAO.GetEntity(myExportID)
				If myExportDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myExportDataSet)
				End If
				'delete export column record
				myExportColumnDataSet = myExportColumnDAO.GetEntityByExportID(myExportID)
				If myExportColumnDataSet.Tables(0).Rows.Count > 0 Then
					For i = 0 To myExportColumnDataSet.Tables(0).Rows.Count - 1
						myExportColumnID = CType(myExportColumnDataSet.Tables(0).Rows(i).Item("Entity"), String)
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myExportColumnDAO.ToString, "DeleteEntity", myExportColumnID, "", Context.User.Identity.Name, Now)
						'log before action
						myExportColumnPartDataSet = myExportColumnDAO.GetEntity(myExportColumnID)
						If myExportColumnPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.before, myExportColumnPartDataSet)
						End If
						'actual action
						myExportColumnDAO.DeleteEntity(myExportColumnID)
						'log after action
						myExportColumnPartDataSet = myExportColumnDAO.GetEntity(myExportColumnID)
						If myExportColumnPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myExportColumnPartDataSet)
						End If
					Next
				End If
			Else
				If myExportDataSet.Tables(0).Rows.Count > 1 Then
					'exception:export record is duplicated
				Else
					'exception:export record is empty
				End If
			End If
			PageLoad()
		End Sub

		Private Sub ButtonImportColumnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImportColumnEdit.Click
			Response.Redirect("~/DesktopModules/ImportExport/ImportColumnEdit.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Private Sub ButtonExportColumnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportColumnEdit.Click
			Response.Redirect("~/DesktopModules/ImportExport/ExportColumnEdit.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex)
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