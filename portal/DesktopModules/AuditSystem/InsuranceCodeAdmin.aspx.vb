Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class InsuranceCodeAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents DropDownListCode As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxName As System.Web.UI.WebControls.TextBox
		Protected WithEvents LabelResult As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxDisplayOrder As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonDelete As System.Web.UI.WebControls.Button

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
		Private codeID As String = ""

		Enum CodeState
			Enable = 0
			Disable = 1
		End Enum

		Enum AttributeCodeType
			Checkbox = 1
			Textbox = 2
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

			If Not (Request.Params("codeID") Is Nothing) Then
				codeID = Request.Params("codeID")
			Else
				codeID = "2006010100000001"
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
			Dim myCodeDAO As New PolicyInsuranceCodeDAOExtand
			Dim myCodeDataSet As DataSet

			InitialWebControl()

			If codeID.Trim.Length > 0 Then
				myCodeDataSet = myCodeDAO.GetEntitysByEntityID(codeID)

			Else
				'new code group
				myCodeDataSet = myCodeDAO.GetEntitys(1)
			End If

			FillCodeData(myCodeDataSet)
		End Sub
		Private Sub FillCodeData(ByVal myDataSet As DataSet)
			Dim myName As String = ""
			Dim myDisplayOrder As Integer = 0
			Dim myDescription As String = ""
			Dim myCodeID As String = ""

			If (Not (myDataSet Is Nothing)) Then
				If myDataSet.Tables(0).Rows.Count = 1 Then
					myCodeID = CType(myDataSet.Tables(0).Rows(0).Item("EntityID"), String)
					myName = CType(myDataSet.Tables(0).Rows(0).Item("Name"), String)
					myDisplayOrder = CType(myDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)
					myDescription = CType(myDataSet.Tables(0).Rows(0).Item("Description"), String)

					Try
						DropDownListCode.SelectedValue = myCodeID
					Catch ex As Exception
						'exception:no match
					End Try
					TextBoxName.Text = myName
					TextBoxDisplayOrder.Text = CType(myDisplayOrder, String)
					TextBoxDescription.Text = myDescription
				Else
					'exception:code group record is empty or duplicated
				End If
			Else
				'exception:code group record is null
			End If
		End Sub
		Private Sub InitialWebControl()
			Dim myCodeDAO As New PolicyInsuranceCodeDAOExtand
			Dim myCodeDataSet As DataSet
			Dim myCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myItem As ListItem
			Dim myName As String = ""
			Dim myID As String = ""

			TextBoxName.Text = ""
			TextBoxDisplayOrder.Text = ""
			TextBoxDescription.Text = ""
			LabelResult.Text = ""
			DropDownListCode.Items.Clear()

			myCodeCount = myCodeDAO.GetTotalRow()
			If myCodeCount > 0 Then
				myCodeDataSet = myCodeDAO.GetEntitys()
				For i = 0 To myCodeCount - 1
					myID = CType(myCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myName = CType(myCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myItem = New ListItem
					myItem.Value = myID
					myItem.Text = myName
					DropDownListCode.Items.Add(myItem)
				Next
			End If
		End Sub

		Private Sub DropDownListCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownListCode.SelectedIndexChanged
			Response.Redirect("~/DesktopModules/AuditSystem/InsuranceCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeID=" & DropDownListCode.SelectedValue)
		End Sub

		Private Function SaveCodeData(ByVal myCodeID As String) As String
			Dim myName As String = ""
			Dim myDisplayOrder As Integer = 0
			Dim myDescription As String = ""
			Dim myCodeCount As Integer = 0
			Dim myCodeDAO As New PolicyInsuranceCodeDAOExtand

			If TextBoxName.Text.Trim <> "" Then
				myName = TextBoxName.Text.Trim
			End If
			If TextBoxDisplayOrder.Text.Trim <> "" Then
				myDisplayOrder = CType(TextBoxDisplayOrder.Text.Trim, Integer)
			End If
			If TextBoxDescription.Text.Trim <> "" Then
				myDescription = TextBoxDescription.Text.Trim
			End If
			If myCodeID.Trim.Length > 0 Then
				'update
				myCodeDAO.UpdateEntity(myCodeID, myName, myDescription, myDisplayOrder)
			Else
				'insert
				If myName.Trim.Length > 0 Then
					myCodeCount = myCodeDAO.GetTotalRowByName(myName)
					If myCodeCount = 0 Then
						myCodeID = myCodeDAO.InsertEntity(AttributeCodeType.Checkbox, myName, myDescription, myDisplayOrder)
					Else
						'exception:name is exist
						LabelResult.Text = "名稱重複!"
						myCodeID = ""
					End If
				Else
					'exception:name is empty
					LabelResult.Text = "名稱空白!"
					myCodeID = ""
				End If
			End If
			Return myCodeID
		End Function

		Private Sub ButtonInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsert.Click
			Dim myCodeID As String = ""
			myCodeID = SaveCodeData("")
			If myCodeID.Trim.Length > 0 Then
				Response.Redirect("~/DesktopModules/AuditSystem/InsuranceCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeID=" & myCodeID)
			Else
				'exception:insert failure
			End If
		End Sub

		Private Sub ButtonUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click
			Dim myCodeID As String = ""
			If codeID.Trim.Length > 0 Then
				myCodeID = SaveCodeData(codeID)
				If myCodeID.Trim.Length > 0 Then
					Response.Redirect("~/DesktopModules/AuditSystem/InsuranceCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeID=" & myCodeID)
				Else
					'exception:update failure
				End If
			Else
				'exception:code group id is empty
			End If
		End Sub

		Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
			Dim myCodeDAO As New PolicyInsuranceCodeDAOExtand
			If codeID.Trim.Length > 0 Then
				myCodeDAO.UpdateEntity(codeID, CodeState.Disable, Now)
			Else
				'exception:code group id is empty
			End If
		End Sub
	End Class
End Namespace