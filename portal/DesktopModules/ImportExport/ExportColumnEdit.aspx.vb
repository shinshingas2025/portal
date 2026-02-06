Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class ExportColumnEdit
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents Label4 As System.Web.UI.WebControls.Label
		Protected WithEvents Label6 As System.Web.UI.WebControls.Label
		Protected WithEvents Label8 As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents RadioButtonOrderByHand As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonAutoOrder As System.Web.UI.WebControls.RadioButton
		Protected WithEvents LabelResult As System.Web.UI.WebControls.Label
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
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myExportDataSet As DataSet
			Dim myExportColumnDAO As New Portal_ExportColumnDAOExtand
			Dim myExportColumnDataSet As DataSet
			Dim myDropDownList As DropDownList
			Dim myCheckBox As CheckBox
			Dim myExportID As String = ""
			Dim myExportOrder As Integer = 0
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim j As Integer = 0
			'prepare control data
			'export
			myExportDataSet = myExportDAO.GetEntitys(sid, moduleId)
			If myExportDataSet.Tables(0).Rows.Count = 1 Then
				myExportID = CType(myExportDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				TextBoxTitle.Text = CType(myExportDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
				TextBoxDescription.Text = CType(myExportDataSet.Tables(0).Rows(0).Item("Description"), String).Trim
				'read table column data
				myExportColumnDataSet = myExportColumnDAO.GetEntitysByExportID(myExportID)
				DataList1.DataSource = myExportColumnDataSet
				DataList1.DataBind()
				'prepqre dropdownlist option
				If myExportColumnDataSet.Tables(0).Rows.Count > 0 Then
					For i = 0 To myExportColumnDataSet.Tables(0).Rows.Count - 1
						myExportOrder = CType(myExportColumnDataSet.Tables(0).Rows(i).Item("ExportOrder"), Integer)
						myDropDownList = CType(DataList1.Controls(i).FindControl("DropDownList1"), DropDownList)
						myCheckBox = CType(DataList1.Controls(i).FindControl("CheckBox1"), CheckBox)
						'rebuild options
						If Not (myDropDownList Is Nothing) Then
							myDropDownList.Items.Clear()
							For j = 0 To myExportColumnDataSet.Tables(0).Rows.Count - 1
								myListItem = New ListItem
								myListItem.Value = CType(j + 1, String)
								myListItem.Text = CType(j + 1, String)
								myDropDownList.Items.Add(myListItem)
							Next
							myDropDownList.SelectedValue = CType(myExportOrder, String)
						Else
							'exception:no dropdownlist control
						End If
						myCheckBox.Checked = True
					Next
				End If
			Else
				If myExportDataSet.Tables(0).Rows.Count = 0 Then
					TextBoxTitle.Text = ""
					TextBoxDescription.Text = ""
				Else
					'exception:import record is duplicated
				End If
			End If

			RadioButtonOrderByHand.Checked = True
			RadioButtonAutoOrder.Checked = False
			LabelResult.Text = ""
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myExportColumnDAO As New Portal_ExportColumnDAOExtand
			Dim myExportDataSet As DataSet
			Dim myExportColumnDataSet As DataSet
			Dim isCheck As Boolean
			Dim anItem As DataListItem
			Dim myExportOrder As Integer = 0
			Dim myExportID As String = ""
			Dim dk As String
			Dim myCount As Integer = 0
			Dim myAuditID As String = ""
			'get import id
			myExportDataSet = myExportDAO.GetEntitys(sid, moduleId)
			If myExportDataSet.Tables(0).Rows.Count = 1 Then
				'check column order
				If RadioButtonOrderByHand.Checked = True Then
					If CheckOrder() = False Then
						'excepton:wrong column order
						LabelResult.Text = "排序錯誤!!"
						Return
					End If
				End If
				myExportID = CType(myExportDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				'update import column
				For Each anItem In DataList1.Items
					dk = CType(DataList1.DataKeys(anItem.ItemIndex), String)
					isCheck = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
					myExportOrder = CType(CType(anItem.FindControl("DropDownList1"), DropDownList).SelectedValue, Integer)
					If isCheck Then
						myCount = myCount + 1
						'update column order
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myExportColumnDAO.ToString, "UpdateEntity", dk, "", Context.User.Identity.Name, Now)
						'log before action
						myExportColumnDataSet = myExportColumnDAO.GetEntity(dk)
						If myExportColumnDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.before, myExportColumnDataSet)
						End If
						'actual action
						If RadioButtonAutoOrder.Checked = True Then
							myExportColumnDAO.UpdateEntity(dk, myCount)
						Else
							myExportColumnDAO.UpdateEntity(dk, myExportOrder)
						End If
						'log after action
						myExportColumnDataSet = myExportColumnDAO.GetEntity(dk)
						If myExportColumnDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myExportColumnDataSet)
						End If
					Else
						'delete import column
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myExportColumnDAO.ToString, "DeleteEntity", dk, "", Context.User.Identity.Name, Now)
						'log before action
						myExportColumnDataSet = myExportColumnDAO.GetEntity(dk)
						If myExportColumnDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.before, myExportColumnDataSet)
						End If
						'actual action
						myExportColumnDAO.DeleteEntity(dk)
						'log after action
						myExportColumnDataSet = myExportColumnDAO.GetEntity(dk)
						If myExportColumnDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myExportColumnDataSet)
						End If
					End If
				Next
			Else
				If myExportDataSet.Tables(0).Rows.Count > 0 Then
					'exception:import data is duplicated
				Else
					'exception:import data is empty
				End If
			End If
			PageLoad()
		End Sub
		Private Function CheckOrder() As Boolean
			Dim isCheck As Boolean
			Dim anItem As DataListItem
			Dim myExportOrder As Integer = 0
			Dim myCount As Integer = 0
			Dim myArrayList As New ArrayList
			Dim myOrderList As ArrayList
			Dim i As Integer = 0
			For Each anItem In DataList1.Items
				isCheck = CType(anItem.FindControl("CheckBox1"), CheckBox).Checked
				myExportOrder = CType(CType(anItem.FindControl("DropDownList1"), DropDownList).SelectedValue, Integer)
				If isCheck Then
					myArrayList.Add(myExportOrder - 1)
				End If
			Next
			'initial object
			myOrderList = New ArrayList
			For i = 0 To myArrayList.Count - 1
				myOrderList.Add(0)
			Next
			Try
				For i = 0 To myArrayList.Count - 1
					myOrderList.Item(CType(myArrayList.Item(i), Integer)) = 1
				Next
				For i = 0 To myOrderList.Count - 1
					If CType(myOrderList.Item(i), Integer) <> 1 Then
						Throw New Exception
					End If
				Next
			Catch ex As Exception
				Return False
			End Try
			Return True
		End Function

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