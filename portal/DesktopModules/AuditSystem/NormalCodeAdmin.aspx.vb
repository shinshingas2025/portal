Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class NormalCodeAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents DropDownListCodeGroup As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxGroupName As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxGroupDisplayOrder As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxGroupDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonGroupInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonGroupUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonGroupDelete As System.Web.UI.WebControls.Button
		Protected WithEvents LabelGroupResult As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolderCode As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ButtonCodeAction As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxCodeName As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxCodeDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxCodeDisplayOrder As System.Web.UI.WebControls.TextBox

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
		Private codeGroupID As String = ""
		Private codeID As String = ""
		Private action As String = ""
		Private Const ActionColumnWidth As String = "40"
		Private Const NameColumnWidth As String = "300"
		Private Const DescriptionColumnWidth As String = "500"
		Private Const DisplayOrderColumnWidth As String = "32"
		Protected Const NormalCodeBGColor As String = "#DEDECA"
		Protected Const FocusCodeBGColor As String = "#FFFF99"

		Enum CodeState
			Enable = 0
			Disable = 1
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

			If Not (Request.Params("codeGroupID") Is Nothing) Then
				codeGroupID = Request.Params("codeGroupID")
			Else
				codeGroupID = "2006010100000001"
			End If

			If Not (Request.Params("codeID") Is Nothing) Then
				codeID = Request.Params("codeID")
			End If

			If Not (Request.Params("action") Is Nothing) Then
				action = Request.Params("action")
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
			Dim myCodeGroupDAO As New NormalCodeGroupDAOExtand
			Dim myCodeGroupDataSet As DataSet

			InitialWebControl()

			If codeGroupID.Trim.Length > 0 Then
				myCodeGroupDataSet = myCodeGroupDAO.GetEntitysByEntityID(codeGroupID)

			Else
				'new code group
				myCodeGroupDataSet = myCodeGroupDAO.GetEntitys(1)
			End If

			FillCodeGroupData(myCodeGroupDataSet)

			If codeGroupID.Trim.Length > 0 Then
				FillCodeData(codeGroupID)
			End If
		End Sub
		Private Sub FillCodeData(ByVal myCodeGroupID As String)
			Dim myCodeDAO As New NormalCodeDAOExtand
			Dim myCodeDataSet As DataSet
			Dim myCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myCodeID As String = ""
			Dim myCodeName As String = ""
			Dim myCodeDescription As String = ""
			Dim myCodeDisplayOrder As Integer = 0
			Dim myTable As HtmlTable
			Dim myTableRow As HtmlTableRow
			Dim myTableCell As HtmlTableCell
			Dim myInputText As HtmlInputText
			Dim myHyperLink As HyperLink
			Dim myLiterial As LiteralControl
			Dim myImage As HtmlImage

			If myCodeGroupID.Trim.Length > 0 Then
				myTable = New HtmlTable
				myTable.CellPadding = 0
				myTable.CellSpacing = 0
				myTable.Border = 1

				'table header
				myTableRow = New HtmlTableRow
				myTableRow.BgColor = NormalCodeBGColor
				'action column
				myTableCell = New HtmlTableCell
				myTableCell.Width = ActionColumnWidth
				myTableRow.Cells.Add(myTableCell)
				'code name header
				myTableCell = New HtmlTableCell
				myTableCell.Width = NameColumnWidth
				myTableCell.InnerHtml = "代碼名稱"
				myTableRow.Cells.Add(myTableCell)
				'code description header
				myTableCell = New HtmlTableCell
				myTableCell.Width = DescriptionColumnWidth
				myTableCell.InnerHtml = "描述"
				myTableRow.Cells.Add(myTableCell)
				'code display order header
				myTableCell = New HtmlTableCell
				myTableCell.Width = DisplayOrderColumnWidth
				myTableCell.InnerHtml = "顯示順序"
				myTableRow.Cells.Add(myTableCell)
				myTable.Controls.Add(myTableRow)

				myCodeCount = myCodeDAO.GetTotalRowByGroupID(myCodeGroupID)
				If myCodeCount > 0 Then
					myCodeDataSet = myCodeDAO.GetEntitysByGroupID(myCodeGroupID)
					For i = 0 To myCodeCount - 1
						myCodeID = CType(myCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myCodeName = CType(myCodeDataSet.Tables(0).Rows(i).Item("Name"), String)
						myCodeDescription = CType(myCodeDataSet.Tables(0).Rows(i).Item("Description"), String)
						myCodeDisplayOrder = CType(myCodeDataSet.Tables(0).Rows(i).Item("DisplayOrder"), Integer)

						myTableRow = New HtmlTableRow
						If myCodeID = codeID Then
							myTableRow.BgColor = FocusCodeBGColor
						Else
							myTableRow.BgColor = NormalCodeBGColor
						End If

						'insert icon
						myTableCell = New HtmlTableCell
						myTableCell.Width = ActionColumnWidth
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeGroupID=" & codeGroupID & "&codeID=" & myCodeID & "&action=update"
						myHyperLink.ImageUrl = "~/images/edit.gif"
						myHyperLink.Text = "修改"
						myTableCell.Controls.Add(myHyperLink)
						'br
						myLiterial = New LiteralControl
						myLiterial.Text = "<BR>"
						myTableCell.Controls.Add(myLiterial)
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeGroupID=" & codeGroupID & "&codeID=" & myCodeID & "&action=delete"
						myHyperLink.ImageUrl = "~/images/delete.gif"
						myHyperLink.Text = "刪除"
						myTableCell.Controls.Add(myHyperLink)
						myTableRow.Cells.Add(myTableCell)

						'code name
						myTableCell = New HtmlTableCell
						myTableCell.Width = NameColumnWidth
						myTableCell.InnerHtml = myCodeName
						myTableRow.Cells.Add(myTableCell)

						'code description
						myTableCell = New HtmlTableCell
						myTableCell.Width = DescriptionColumnWidth
						myTableCell.InnerHtml = myCodeDescription
						myTableRow.Cells.Add(myTableCell)

						'code display order
						myTableCell = New HtmlTableCell
						myTableCell.Width = DisplayOrderColumnWidth
						myTableCell.InnerHtml = CType(myCodeDisplayOrder, String)
						myTableRow.Cells.Add(myTableCell)

						myTable.Controls.Add(myTableRow)
					Next
				End If

				'update code
				If codeID.Trim.Length > 0 Then
					myCodeDataSet = myCodeDAO.GetEntitysByEntityID(codeID)
					If myCodeDataSet.Tables(0).Rows.Count = 1 Then
						myCodeID = CType(myCodeDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						myCodeName = CType(myCodeDataSet.Tables(0).Rows(0).Item("Name"), String)
						myCodeDescription = CType(myCodeDataSet.Tables(0).Rows(0).Item("Description"), String)
						myCodeDisplayOrder = CType(myCodeDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)

						If action.Trim.Length > 0 Then
							If action.Trim = "update" Then
								ButtonCodeAction.Text = "修改"
								TextBoxCodeName.Text = myCodeName
								TextBoxCodeDescription.Text = myCodeDescription
								TextBoxCodeDisplayOrder.Text = CType(myCodeDisplayOrder, String)
							Else
								If action.Trim = "delete" Then
									ButtonCodeAction.Text = "刪除"
									TextBoxCodeName.Text = myCodeName
									TextBoxCodeDescription.Text = myCodeDescription
									TextBoxCodeDisplayOrder.Text = CType(myCodeDisplayOrder, String)
								Else
									'exception:unknown action
								End If
							End If
						End If
					Else
						'exception:code record is empty or duplicated
					End If
				End If

				PlaceHolderCode.Controls.Add(myTable)
				PlaceHolderCode.Visible = True
				ButtonCodeAction.Visible = True
				TextBoxCodeName.Visible = True
				TextBoxCodeDescription.Visible = True
				TextBoxCodeDisplayOrder.Visible = True
			Else
				'exception:code group id is empty
			End If
		End Sub
		Private Sub FillCodeGroupData(ByVal myDataSet As DataSet)
			Dim myGroupName As String = ""
			Dim myGroupDisplayOrder As Integer = 0
			Dim myGroupDescription As String = ""
			Dim myGroupID As String = ""

			If (Not (myDataSet Is Nothing)) Then
				If myDataSet.Tables(0).Rows.Count = 1 Then
					myGroupID = CType(myDataSet.Tables(0).Rows(0).Item("EntityID"), String)
					myGroupName = CType(myDataSet.Tables(0).Rows(0).Item("Name"), String)
					myGroupDisplayOrder = CType(myDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)
					myGroupDescription = CType(myDataSet.Tables(0).Rows(0).Item("Description"), String)

					Try
						DropDownListCodeGroup.SelectedValue = myGroupID
					Catch ex As Exception
						'exception:no match
					End Try
					TextBoxGroupName.Text = myGroupName
					TextBoxGroupDisplayOrder.Text = CType(myGroupDisplayOrder, String)
					TextBoxGroupDescription.Text = myGroupDescription
				Else
					'exception:code group record is empty or duplicated
				End If
			Else
				'exception:code group record is null
			End If
		End Sub
		Private Sub InitialWebControl()
			Dim myCodeGroupDAO As New NormalCodeGroupDAOExtand
			Dim myCodeGroupDataSet As DataSet
			Dim myCodeGroupCount As Integer = 0
			Dim i As Integer = 0
			Dim myItem As ListItem
			Dim myGroupName As String = ""
			Dim myGroupID As String = ""

			TextBoxGroupName.Text = ""
			TextBoxGroupDisplayOrder.Text = ""
			TextBoxGroupDescription.Text = ""
			LabelGroupResult.Text = ""
			TextBoxCodeName.Text = ""
			TextBoxCodeDisplayOrder.Text = ""
			TextBoxCodeDescription.Text = ""
			ButtonCodeAction.Text = "新增"
			DropDownListCodeGroup.Items.Clear()
			PlaceHolderCode.Controls.Clear()

			myCodeGroupCount = myCodeGroupDAO.GetTotalRow()
			If myCodeGroupCount > 0 Then
				myCodeGroupDataSet = myCodeGroupDAO.GetEntitys()
				For i = 0 To myCodeGroupCount - 1
					myGroupID = CType(myCodeGroupDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myGroupName = CType(myCodeGroupDataSet.Tables(0).Rows(i).Item("Name"), String)

					myItem = New ListItem
					myItem.Value = myGroupID
					myItem.Text = myGroupName
					DropDownListCodeGroup.Items.Add(myItem)
				Next
			End If

			TextBoxCodeName.Visible = False
			TextBoxCodeDisplayOrder.Visible = False
			TextBoxCodeDescription.Visible = False
			ButtonCodeAction.Visible = False
			PlaceHolderCode.Visible = False
		End Sub

		Private Sub DropDownListCodeGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownListCodeGroup.SelectedIndexChanged
			Response.Redirect("~/DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeGroupID=" & DropDownListCodeGroup.SelectedValue)
		End Sub

		Private Function SaveCodeGroupData(ByVal myCodeGroupID As String) As String
			Dim myGroupName As String = ""
			Dim myGroupDisplayOrder As Integer = 0
			Dim myGroupDescription As String = ""
			Dim myCodeGroupCount As Integer = 0
			Dim myCodeGroupDAO As New NormalCodeGroupDAOExtand

			If TextBoxGroupName.Text.Trim <> "" Then
				myGroupName = TextBoxGroupName.Text.Trim
			End If
			If TextBoxGroupDisplayOrder.Text.Trim <> "" Then
				myGroupDisplayOrder = CType(TextBoxGroupDisplayOrder.Text.Trim, Integer)
			End If
			If TextBoxGroupDescription.Text.Trim <> "" Then
				myGroupDescription = TextBoxGroupDescription.Text.Trim
			End If
			If myCodeGroupID.Trim.Length > 0 Then
				'update
				myCodeGroupDAO.UpdateEntity(myCodeGroupID, myGroupName, myGroupDescription, myGroupDisplayOrder)
			Else
				'insert
				If myGroupName.Trim.Length > 0 Then
					myCodeGroupCount = myCodeGroupDAO.GetTotalRowByName(myGroupName)
					If myCodeGroupCount = 0 Then
						myCodeGroupID = myCodeGroupDAO.InsertEntity(myGroupName, myGroupDescription, myGroupDisplayOrder)
					Else
						'exception:name is exist
						LabelGroupResult.Text = "群組名稱重複!"
						myCodeGroupID = ""
					End If
				Else
					'exception:name is empty
					LabelGroupResult.Text = "群組名稱空白!"
					myCodeGroupID = ""
				End If
			End If
			Return myCodeGroupID
		End Function

		Private Sub ButtonGroupInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGroupInsert.Click
			Dim myCodeGroupID As String = ""
			myCodeGroupID = SaveCodeGroupData("")
			If myCodeGroupID.Trim.Length > 0 Then
				Response.Redirect("~/DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeGroupID=" & myCodeGroupID)
			Else
				'exception:insert failure
			End If
		End Sub

		Private Sub ButtonGroupUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGroupUpdate.Click
			Dim myCodeGroupID As String = ""
			If codeGroupID.Trim.Length > 0 Then
				myCodeGroupID = SaveCodeGroupData(codeGroupID)
				If myCodeGroupID.Trim.Length > 0 Then
					Response.Redirect("~/DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeGroupID=" & myCodeGroupID)
				Else
					'exception:update failure
				End If
			Else
				'exception:code group id is empty
			End If
		End Sub

		Private Sub ButtonGroupDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGroupDelete.Click
			Dim myCodeGroupDAO As New NormalCodeGroupDAOExtand
			If codeGroupID.Trim.Length > 0 Then
				myCodeGroupDAO.UpdateEntity(codeGroupID, CodeState.Disable, Now)
			Else
				'exception:code group id is empty
			End If
		End Sub

		Private Sub ButtonCodeAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCodeAction.Click
			Dim myCodeDAO As New NormalCodeDAOExtand
			Dim myCodeID As String = ""
			Dim myCodeName As String = ""
			Dim myCodeDescription As String = ""
			Dim myCodeDisplayOrder As Integer = 0

			If codeGroupID.Trim.Length > 0 Then
				If TextBoxCodeName.Text.Trim <> "" Then
					myCodeName = TextBoxCodeName.Text.Trim
				End If

				If TextBoxCodeDescription.Text.Trim <> "" Then
					myCodeDescription = TextBoxCodeDescription.Text.Trim
				End If

				If TextBoxCodeDisplayOrder.Text.Trim <> "" Then
					myCodeDisplayOrder = CType(TextBoxCodeDisplayOrder.Text.Trim, Integer)
				End If

				If codeID.Trim.Length > 0 Then
					If action.Trim = "update" Then
						'update
						myCodeDAO.UpdateEntity(codeID, myCodeName, myCodeDescription, myCodeDisplayOrder)
						Response.Redirect("~/DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeGroupID=" & codeGroupID)
					Else
						If action.Trim = "delete" Then
							'delete
							myCodeDAO.UpdateEntity(codeID, CodeState.Disable, Now)
							Response.Redirect("~/DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeGroupID=" & codeGroupID)
						Else
							'exception:unknown action
						End If
					End If
				Else
					'insert
					myCodeDAO.InsertEntity(codeGroupID, myCodeName, myCodeDescription, myCodeDisplayOrder)
					Response.Redirect("~/DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&codeGroupID=" & codeGroupID)
				End If
			Else
				'exception:code group id is empty
			End If
		End Sub
	End Class
End Namespace