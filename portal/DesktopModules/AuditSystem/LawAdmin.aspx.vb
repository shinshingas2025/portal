Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class LawAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxContent As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonNext As System.Web.UI.WebControls.Button
		Protected WithEvents PlaceHolderContent As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ButtonContentAction As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxContentNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents PlaceholderAppend As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents TextBoxContentOrder As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextboxAppendName As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextboxAppendDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxAppendOrder As System.Web.UI.WebControls.TextBox
		Protected WithEvents AppendFile As System.Web.UI.HtmlControls.HtmlInputFile
		Protected WithEvents ButtonAppendAction As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxName As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonEntityInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonEntityUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonEntityDelete As System.Web.UI.WebControls.Button
		Protected WithEvents TextboxConstitutionDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListDiscussion As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListParent As System.Web.UI.WebControls.DropDownList
		Protected WithEvents ButtonParent As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonChild As System.Web.UI.WebControls.Button
		Protected WithEvents DropDownListConstitutionInstitution As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListUndertakerInstitution As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxDocumentNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListVariationType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListType As System.Web.UI.WebControls.DropDownList

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
		Private parentID As String = ""
		Private lawID As String = ""
		Private contentID As String = ""
		Private appendID As String = ""
		Private action As String = ""
		Private Const DiscussionCodeGroupID As String = "2006010100000024"
		Private Const ActionColumnWidth As String = "40"
		Private Const ContentNumberColumnWidth As String = "48"
		Private Const ContentColumnWidth As String = "720"
		Private Const ContentOrderColumnWidth As String = "40"
		Private Const AppendNameColumnWidth As String = "160"
		Private Const AppendDescriptionColumnWidth As String = "280"
		Private Const AppendFileColumnWidth As String = "320"
		Private Const AppendOrderColumnWidth As String = "40"
		Protected Const NormalCodeBGColor As String = "#DEDECA"
		Protected Const FocusCodeBGColor As String = "#FFFF99"
		Protected Const VariationTypeCodeGroupID As String = "2006010100000025"
		Protected Const ConstitutionInstitutionCodeGroupID As String = "2006010100000026"
		Protected Const UndertakerInstitutionCodeGroupID As String = "2006010100000003"
		Protected Const TypeCodeGroupID As String = "2006010100000027"

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

			If Not (Request.Params("parentID") Is Nothing) Then
				parentID = Request.Params("parentID")
			Else
				parentID = ""
			End If

			If Not (Request.Params("lawID") Is Nothing) Then
				lawID = Request.Params("lawID")
			End If

			If Not (Request.Params("contentID") Is Nothing) Then
				contentID = Request.Params("contentID")
			End If

			If Not (Request.Params("appendID") Is Nothing) Then
				appendID = Request.Params("appendID")
			End If

			If Not (Request.Params("action") Is Nothing) Then
				action = Request.Params("action")
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				InitialWebControl()
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet
			Dim myLawCount As Integer = 0
			Dim myLawID As String = ""
			Dim myParentID As String = ""

			If lawID.Trim.Length > 0 Then
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
			Else
				If parentID.Trim.Length > 0 Then
					myLawDataSet = myLawDAO.GetEntitysByParentID(parentID, 1)
					If myLawDataSet.Tables(0).Rows.Count = 1 Then
						myLawID = CType(myLawDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myLawID)
					End If
				Else
					'no parent id
					myLawDataSet = myLawDAO.GetEntitys(1)
					If myLawDataSet.Tables(0).Rows.Count = 1 Then
						myLawID = CType(myLawDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String)
						Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & myParentID & "&lawID=" & myLawID)
					End If
				End If
			End If
			FillLawData(myLawDataSet)
		End Sub
		Private Sub FillLawData(ByVal myLawDataSet As DataSet)
			Dim myLawID As String = ""
			Dim myParentID As String = ""
			Dim myName As String = ""
			Dim myDiscussionID As String = ""
			Dim myConstitutionDate As Date = New Date(1900, 1, 1)
			Dim myVariationTypeID As String = ""
			Dim myConstitutionInstitutionID As String = ""
			Dim myUndertakerInstitutionID As String = ""
			Dim myDocumentNumber As String = ""
			Dim myTypeID As String = ""

			If Not (myLawDataSet Is Nothing) Then
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					myLawID = CType(myLawDataSet.Tables(0).Rows(0).Item("EntityID"), String).Trim
					myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String).Trim
					myName = CType(myLawDataSet.Tables(0).Rows(0).Item("Name"), String).Trim
					myDiscussionID = CType(myLawDataSet.Tables(0).Rows(0).Item("DiscussionID"), String).Trim
					myConstitutionDate = CType(myLawDataSet.Tables(0).Rows(0).Item("ConstitutionDate"), Date)
					myVariationTypeID = CType(myLawDataSet.Tables(0).Rows(0).Item("VariationTypeID"), String).Trim
					myConstitutionInstitutionID = CType(myLawDataSet.Tables(0).Rows(0).Item("ConstitutionInstitutionID"), String).Trim
					myUndertakerInstitutionID = CType(myLawDataSet.Tables(0).Rows(0).Item("UndertakerinstitutionID"), String).Trim
					myDocumentNumber = CType(myLawDataSet.Tables(0).Rows(0).Item("DocumentNumber"), String).Trim
					myTypeID = CType(myLawDataSet.Tables(0).Rows(0).Item("TypeID"), String).Trim

					TextBoxName.Text = myName
					TextboxConstitutionDate.Text = myConstitutionDate.Year & "/" & myConstitutionDate.Month & "/" & myConstitutionDate.Day
					If TextboxConstitutionDate.Text = "1900/1/1" Then
						TextboxConstitutionDate.Text = ""
					End If
					Try
						DropDownListDiscussion.SelectedValue = myDiscussionID
					Catch ex As Exception
						'no match
					End Try
					Try
						DropDownListParent.SelectedValue = myParentID
					Catch ex As Exception
						'no match
					End Try
					TextBoxDocumentNumber.Text = myDocumentNumber
					Try
						DropDownListVariationType.SelectedValue = myVariationTypeID
					Catch ex As Exception
						'no match
					End Try
					Try
						DropDownListConstitutionInstitution.SelectedValue = myConstitutionInstitutionID
					Catch ex As Exception
						'no match
					End Try
					Try
						DropDownListUndertakerInstitution.SelectedValue = myUndertakerInstitutionID
					Catch ex As Exception
						'no match
					End Try
					Try
						DropDownListType.SelectedValue = myTypeID
					Catch ex As Exception
						'no match
					End Try

					'content and append
					If myLawID.Trim.Length > 0 Then
						FillContentData(myLawID)
						FillAppendData(myLawID)
					Else
						'exception:news id is empty
					End If
				Else
					'exception:law record is empty or duplicated
				End If
			End If
		End Sub
		Private Sub FillContentData(ByVal myLawID As String)
			Dim myContentDAO As New LawContentDAOExtand
			Dim myContentDataSet As DataSet
			Dim myContentCount As Integer = 0
			Dim myTable As HtmlTable
			Dim myTableRow As HtmlTableRow
			Dim myTableCell As HtmlTableCell
			Dim myHyperLink As HyperLink
			Dim myLiterial As LiteralControl
			Dim myImage As HtmlImage
			Dim myContentID As String = ""
			Dim myContentNumber As String = ""
			Dim myContent As String = ""
			Dim myContentOrder As Integer = 0
			Dim i As Integer = 0

			If myLawID.Trim.Length > 0 Then

				PlaceHolderContent.Controls.Clear()

				myTable = New HtmlTable
				myTable.CellPadding = 0
				myTable.CellSpacing = 0
				myTable.Border = 1
				'prepare content header
				myTableRow = New HtmlTableRow
				myTableRow.BgColor = NormalCodeBGColor
				'action column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = ActionColumnWidth
				myTableRow.Cells.Add(myTableCell)
				'content number column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = ContentNumberColumnWidth
				myTableCell.InnerText = "段落"
				myTableRow.Cells.Add(myTableCell)
				'content column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = ContentColumnWidth
				myTableCell.InnerText = "內文"
				myTableRow.Cells.Add(myTableCell)
				'content display order column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = ContentOrderColumnWidth
				myTableCell.InnerText = "順序"
				myTableRow.Cells.Add(myTableCell)

				myTable.Rows.Add(myTableRow)

				myContentCount = myContentDAO.GetTotalRowByLawID(myLawID)
				If myContentCount > 0 Then
					myContentDataSet = myContentDAO.GetEntitysByLawID(myLawID)
					For i = 0 To myContentCount - 1
						myContentID = CType(myContentDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myTableRow = New HtmlTableRow
						If myContentID = contentID Then
							myTableRow.BgColor = FocusCodeBGColor
						Else
							myTableRow.BgColor = NormalCodeBGColor
						End If

						'insert icon
						myTableCell = New HtmlTableCell
						myTableCell.Width = ActionColumnWidth
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myLawID & "&contentID=" & myContentID & "&action=update"
						myHyperLink.ImageUrl = "~/images/edit.gif"
						myHyperLink.Text = "修改"
						myTableCell.Controls.Add(myHyperLink)
						'br
						myLiterial = New LiteralControl
						myLiterial.Text = "<BR>"
						myTableCell.Controls.Add(myLiterial)
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myLawID & "&contentID=" & myContentID & "&action=delete"
						myHyperLink.ImageUrl = "~/images/delete.gif"
						myHyperLink.Text = "刪除"
						myTableCell.Controls.Add(myHyperLink)

						myTableRow.Cells.Add(myTableCell)

						'content number
						myContentNumber = CType(myContentDataSet.Tables(0).Rows(i).Item("ContentNumber"), String)
						myTableCell = New HtmlTableCell
						myTableCell.Width = ContentNumberColumnWidth
						myTableCell.InnerHtml = myContentNumber
						myTableRow.Cells.Add(myTableCell)

						'content
						myContent = CType(myContentDataSet.Tables(0).Rows(i).Item("Content"), String)
						myTableCell = New HtmlTableCell
						myTableCell.Width = ContentColumnWidth
						myTableCell.InnerHtml = myContent
						myTableRow.Cells.Add(myTableCell)

						'content order
						myContentOrder = CType(myContentDataSet.Tables(0).Rows(i).Item("DisplayOrder"), Integer)
						myTableCell = New HtmlTableCell
						myTableCell.Width = ContentOrderColumnWidth
						myTableCell.InnerHtml = CType(myContentOrder, String)
						myTableRow.Cells.Add(myTableCell)

						myTable.Rows.Add(myTableRow)
					Next
				Else
					'new content
				End If
				PlaceHolderContent.Controls.Add(myTable)

				'update content
				If contentID.Trim.Length > 0 Then
					myContentDataSet = myContentDAO.GetEntitysByEntityID(contentID)
					If myContentDataSet.Tables(0).Rows.Count = 1 Then
						myContentNumber = CType(myContentDataSet.Tables(0).Rows(0).Item("ContentNumber"), String)
						myContent = CType(myContentDataSet.Tables(0).Rows(0).Item("Content"), String)
						myContentOrder = CType(myContentDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)
					Else
						'exception:content record is empty or duplicated
					End If

					If action.Trim.Length > 0 Then
						If action.Trim = "update" Then
							ButtonContentAction.Text = "修改"
							TextBoxContentNumber.Text = myContentNumber
							TextBoxContent.Text = myContent
							TextBoxContentOrder.Text = CType(myContentOrder, String)
						Else
							If action.Trim = "delete" Then
								ButtonContentAction.Text = "刪除"
								TextBoxContentNumber.Text = myContentNumber
								TextBoxContent.Text = myContent
								TextBoxContentOrder.Text = CType(myContentOrder, String)
							Else
								'exception:unknown action
							End If
						End If
					Else
						'exception:no action
					End If
				End If
				ButtonContentAction.Visible = True
				TextBoxContentNumber.Visible = True
				TextBoxContent.Visible = True
				TextBoxContentOrder.Visible = True
			Else
				'exception:news id is empty
			End If
		End Sub

		Private Sub FillAppendData(ByVal myLawID As String)
			Dim myAppendDAO As New LawAppendDAOExtand
			Dim myAppendDataSet As DataSet
			Dim myAppendCount As Integer = 0
			Dim myTable As HtmlTable
			Dim myTableRow As HtmlTableRow
			Dim myTableCell As HtmlTableCell
			Dim myHyperLink As HyperLink
			Dim myLiterial As LiteralControl
			Dim myImage As HtmlImage
			Dim myAppendID As String = ""
			Dim myAppendName As String = ""
			Dim myAppendDescription As String = ""
			Dim myAppendFile As String = ""
			Dim myAppendOrder As Integer = 0
			Dim i As Integer = 0

			If myLawID.Trim.Length > 0 Then

				PlaceholderAppend.Controls.Clear()

				myTable = New HtmlTable
				myTable.CellPadding = 0
				myTable.CellSpacing = 0
				myTable.Border = 1
				'prepare append header
				myTableRow = New HtmlTableRow
				myTableRow.BgColor = NormalCodeBGColor
				'action column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = ActionColumnWidth
				myTableRow.Cells.Add(myTableCell)
				'append name column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = AppendNameColumnWidth
				myTableCell.InnerText = "名稱"
				myTableRow.Cells.Add(myTableCell)
				'append description column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = AppendDescriptionColumnWidth
				myTableCell.InnerText = "描述"
				myTableRow.Cells.Add(myTableCell)
				'append file column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = AppendFileColumnWidth
				myTableCell.InnerText = "檔名"
				myTableRow.Cells.Add(myTableCell)
				'append display order column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = AppendOrderColumnWidth
				myTableCell.InnerText = "順序"
				myTableRow.Cells.Add(myTableCell)

				myTable.Rows.Add(myTableRow)

				myAppendCount = myAppendDAO.GetTotalRowByLawID(myLawID)
				If myAppendCount > 0 Then
					myAppendDataSet = myAppendDAO.GetEntitysByLawID(myLawID)
					For i = 0 To myAppendCount - 1
						myAppendID = CType(myAppendDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myTableRow = New HtmlTableRow
						If myAppendID = appendID Then
							myTableRow.BgColor = FocusCodeBGColor
						Else
							myTableRow.BgColor = NormalCodeBGColor
						End If

						'insert icon
						myTableCell = New HtmlTableCell
						myTableCell.Width = ActionColumnWidth
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myLawID & "&appendID=" & myAppendID & "&action=update"
						myHyperLink.ImageUrl = "~/images/edit.gif"
						myHyperLink.Text = "修改"
						myTableCell.Controls.Add(myHyperLink)
						'br
						myLiterial = New LiteralControl
						myLiterial.Text = "<BR>"
						myTableCell.Controls.Add(myLiterial)
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myLawID & "&appendID=" & myAppendID & "&action=delete"
						myHyperLink.ImageUrl = "~/images/delete.gif"
						myHyperLink.Text = "刪除"
						myTableCell.Controls.Add(myHyperLink)

						myTableRow.Cells.Add(myTableCell)

						'append name
						myAppendName = CType(myAppendDataSet.Tables(0).Rows(i).Item("Name"), String)
						myTableCell = New HtmlTableCell
						myTableCell.Width = AppendNameColumnWidth
						myTableCell.InnerHtml = myAppendName
						myTableRow.Cells.Add(myTableCell)

						'append description
						myAppendDescription = CType(myAppendDataSet.Tables(0).Rows(i).Item("Description"), String)
						myTableCell = New HtmlTableCell
						myTableCell.Width = AppendDescriptionColumnWidth
						myTableCell.InnerHtml = myAppendDescription
						myTableRow.Cells.Add(myTableCell)

						'append file
						myAppendFile = CType(myAppendDataSet.Tables(0).Rows(i).Item("FileName"), String)
						myTableCell = New HtmlTableCell
						myTableCell.Width = AppendFileColumnWidth
						myTableCell.InnerHtml = Path.GetFileName(myAppendFile).Substring(17)
						myTableRow.Cells.Add(myTableCell)

						'append order
						myAppendOrder = CType(myAppendDataSet.Tables(0).Rows(i).Item("DisplayOrder"), Integer)
						myTableCell = New HtmlTableCell
						myTableCell.Width = AppendOrderColumnWidth
						myTableCell.InnerHtml = CType(myAppendOrder, String)
						myTableRow.Cells.Add(myTableCell)

						myTable.Rows.Add(myTableRow)
					Next
				Else
					'new content
				End If
				PlaceholderAppend.Controls.Add(myTable)

				'update content
				If appendID.Trim.Length > 0 Then
					myAppendDataSet = myAppendDAO.GetEntitysByEntityID(appendID)
					If myAppendDataSet.Tables(0).Rows.Count = 1 Then
						myAppendName = CType(myAppendDataSet.Tables(0).Rows(0).Item("Name"), String)
						myAppendDescription = CType(myAppendDataSet.Tables(0).Rows(0).Item("Description"), String)
						myAppendFile = CType(myAppendDataSet.Tables(0).Rows(0).Item("FileName"), String)
						myAppendOrder = CType(myAppendDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)
					Else
						'exception:content record is empty or duplicated
					End If

					If action.Trim.Length > 0 Then
						If action.Trim = "update" Then
							ButtonAppendAction.Text = "修改"
							TextboxAppendName.Text = myAppendName
							TextboxAppendDescription.Text = myAppendDescription
							TextBoxAppendOrder.Text = CType(myAppendOrder, String)
						Else
							If action.Trim = "delete" Then
								ButtonAppendAction.Text = "刪除"
								TextboxAppendName.Text = myAppendName
								TextboxAppendDescription.Text = myAppendDescription
								TextBoxAppendOrder.Text = CType(myAppendOrder, String)
							Else
								'exception:unknown action
							End If
						End If
					Else
						'exception:no action
					End If
				End If
				ButtonAppendAction.Visible = True
				TextboxAppendName.Visible = True
				TextboxAppendDescription.Visible = True
				AppendFile.Visible = True
				TextBoxAppendOrder.Visible = True
			Else
				'exception:news id is empty
			End If
		End Sub
		Private Sub InitialWebControl()
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet
			Dim myLawCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""

			DropDownListDiscussion.Items.Clear()
			myNormalCodeCount = myNormalCodeDAO.GetTotalRowByGroupID(DiscussionCodeGroupID)
			If myNormalCodeCount > 0 Then
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(DiscussionCodeGroupID)
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListDiscussion.Items.Add(myListItem)
				Next
			End If

			TextBoxName.Text = ""
			TextboxConstitutionDate.Text = ""
			TextBoxDocumentNumber.Text = ""

			DropDownListParent.Items.Clear()
			myLawCount = myLawDAO.GetTotalRow
			If myLawCount > 0 Then
				myLawDataSet = myLawDAO.GetEntitys
				For i = 0 To myLawCount - 1
					myCodeID = CType(myLawDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myLawDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListParent.Items.Add(myListItem)
				Next
			End If

			DropDownListVariationType.Items.Clear()
			myNormalCodeCount = myNormalCodeDAO.GetTotalRowByGroupID(VariationTypeCodeGroupID)
			If myNormalCodeCount > 0 Then
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(VariationTypeCodeGroupID)
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListVariationType.Items.Add(myListItem)
				Next
			End If

			DropDownListConstitutionInstitution.Items.Clear()
			myNormalCodeCount = myNormalCodeDAO.GetTotalRowByGroupID(ConstitutionInstitutionCodeGroupID)
			If myNormalCodeCount > 0 Then
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(ConstitutionInstitutionCodeGroupID)
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListConstitutionInstitution.Items.Add(myListItem)
				Next
			End If

			DropDownListUndertakerInstitution.Items.Clear()
			myNormalCodeCount = myNormalCodeDAO.GetTotalRowByGroupID(UndertakerInstitutionCodeGroupID)
			If myNormalCodeCount > 0 Then
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(UndertakerInstitutionCodeGroupID)
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListUndertakerInstitution.Items.Add(myListItem)
				Next
			End If

			DropDownListType.Items.Clear()
			myNormalCodeCount = myNormalCodeDAO.GetTotalRowByGroupID(TypeCodeGroupID)
			If myNormalCodeCount > 0 Then
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(UndertakerInstitutionCodeGroupID)

				If myNormalCodeCount > 0 Then
					For i = 0 To myNormalCodeCount - 1
						myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

						myListItem = New ListItem
						myListItem.Value = myCodeID
						myListItem.Text = myCodeName

						DropDownListType.Items.Add(myListItem)
					Next
				End If
			End If

			ButtonContentAction.Text = "新增"
			ButtonContentAction.Visible = False

			TextBoxContentNumber.Text = ""
			TextBoxContentNumber.Visible = False

			TextBoxContent.Text = ""
			TextBoxContent.Visible = False

			TextBoxContentOrder.Text = ""
			TextBoxContentOrder.Visible = False

			ButtonAppendAction.Text = "新增"
			ButtonAppendAction.Visible = False

			TextboxAppendName.Text = ""
			TextboxAppendName.Visible = False

			TextboxAppendDescription.Text = ""
			TextboxAppendDescription.Visible = False

			AppendFile.Visible = False

			TextBoxAppendOrder.Text = ""
			TextBoxAppendOrder.Visible = False
		End Sub
		Private Function SaveLawData(ByVal myLawID As String) As String
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myParentID As String = ""
			Dim myName As String = ""
			Dim myDiscussionID As String = ""
			Dim myConstitutionDate As Date = New Date(1900, 1, 1)
			Dim myVariationTypeID As String = ""
			Dim myConstitutionInstitutionID As String = ""
			Dim myUndertakerInstitutionID As String = ""
			Dim myDocumentNumber As String = ""
			Dim myTypeID As String = ""

			myParentID = DropDownListParent.SelectedValue
			myName = TextBoxName.Text.Trim
			myDiscussionID = DropDownListDiscussion.SelectedValue
			If TextboxConstitutionDate.Text.Trim <> "" Then
				tempString = TextboxConstitutionDate.Text.Trim
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 3 Then
					myConstitutionDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				End If
			End If
			myDocumentNumber = TextBoxDocumentNumber.Text.Trim
			myVariationTypeID = DropDownListVariationType.SelectedValue
			myConstitutionInstitutionID = DropDownListConstitutionInstitution.SelectedValue
			myUndertakerInstitutionID = DropDownListUndertakerInstitution.SelectedValue
			myTypeID = DropDownListType.SelectedValue

			If myLawID.Trim.Length > 0 Then
				myLawDataSet = myLawDAO.GetEntitysByEntityID(myLawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					'update law record
					myLawDAO.UpdateEntity(myLawID, myName, myDiscussionID, myConstitutionDate, myParentID, myVariationTypeID, myConstitutionInstitutionID, myUndertakerInstitutionID, myDocumentNumber, myTypeID)
				Else
					'exception:law record is empty or duplicated
				End If
			Else
				'insert law data
				myLawID = myLawDAO.InsertEntity(myName, myDiscussionID, myConstitutionDate, myParentID, myVariationTypeID, myConstitutionInstitutionID, myUndertakerInstitutionID, myDocumentNumber, myTypeID)
			End If
			Return myLawID
		End Function
		Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim i As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False

			If lawID.Trim.Length > 0 Then
				myPreviousID = lawID
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					'read total entity id
					myLawDataSet = myLawDAO.GetEntityIDByParentID(parentID)
					If myLawDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myLawDataSet.Tables(0).Rows.Count - 1
							If lawID = CType(myLawDataSet.Tables(0).Rows(i).Item("EntityID"), String) Then
								bFound = True
								Exit For
							Else
								'save previous id
								myPreviousID = CType(myLawDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							End If
						Next
						If bFound = True Then
							Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myPreviousID)
						End If
					End If
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub

		Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim i As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False

			If lawID.Trim.Length > 0 Then
				myNextID = lawID
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					'read total entity id
					myLawDataSet = myLawDAO.GetEntityIDByParentID(parentID)
					If myLawDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myLawDataSet.Tables(0).Rows.Count - 1
							If lawID = CType(myLawDataSet.Tables(0).Rows(i).Item("EntityID"), String) Then
								bFound = True
								Exit For
							End If
						Next
						If bFound = True Then
							'save next id
							If i + 1 < myLawDataSet.Tables(0).Rows.Count Then
								myNextID = CType(myLawDataSet.Tables(0).Rows(i + 1).Item("EntityID"), String)
							Else
								myNextID = CType(myLawDataSet.Tables(0).Rows(myLawDataSet.Tables(0).Rows.Count - 1).Item("EntityID"), String)
							End If
							Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myNextID)
						End If
					End If
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub

		Private Sub ButtonEntityInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEntityInsert.Click
			Dim myLawID As String = ""
			myLawID = SaveLawData("")
			If myLawID.Trim.Length > 0 Then
				Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myLawID)
			Else
				'exception:insert failure
				PageLoad()
			End If
		End Sub

		Private Sub ButtonEntityUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEntityUpdate.Click
			If lawID.Trim.Length > 0 Then
				SaveLawData(lawID)
				Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & lawID)
			Else
				'exception:law id is empty
			End If
		End Sub
		Private Sub DeleteContent(ByVal myLawID As String)
			Dim myContentDAO As New NewsReleaseContentDAOExtand
			Dim myContentDataSet As DataSet
			Dim myContentCount As Integer = 0
			Dim myContentID As String = ""
			Dim i As Integer = 0

			If myLawID.Trim.Length > 0 Then
				myContentCount = myContentDAO.GetTotalRowByNewsReleaseID(myLawID)
				If myContentCount > 0 Then
					myContentDataSet = myContentDAO.GetEntitysByNewsReleaseID(myLawID)
					For i = 0 To myContentCount - 1
						myContentID = CType(myContentDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myContentDAO.DeleteEntity(myContentID)
					Next
				End If
			Else
				'exception:news id is empty
			End If
		End Sub
		Private Sub DeleteAppend(ByVal myLawID As String)
			Dim myAppendDAO As New NewsReleaseAppendDAOExtand
			Dim myAppendDataSet As DataSet
			Dim myAppendCount As Integer = 0
			Dim myAppendID As String = ""
			Dim myAppendFile As String = ""
			Dim i As Integer = 0

			If myLawID.Trim.Length > 0 Then
				myAppendCount = myAppendDAO.GetTotalRowByNewsReleaseID(myLawID)
				If myAppendCount > 0 Then
					myAppendDataSet = myAppendDAO.GetEntitysByNewsReleaseID(myLawID)
					For i = 0 To myAppendCount - 1
						myAppendID = CType(myAppendDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myAppendFile = CType(myAppendDataSet.Tables(0).Rows(i).Item("FileName"), String)
						'delete append file
						If File.Exists(myAppendFile) Then
							File.Delete(myAppendFile)
						Else
							'exception:append file is not exist
						End If
						myAppendDAO.DeleteEntity(myAppendID)
					Next
				End If
			Else
				'exception:news id is empty
			End If
		End Sub
		Private Sub DeleteLawData(ByVal myLawID As String)
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet

			If myLawID.Trim.Length > 0 Then
				myLawDataSet = myLawDAO.GetEntitysByEntityID(myLawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					'delete content
					DeleteContent(myLawID)
					'delete append
					DeleteAppend(myLawID)
					'delete law
					myLawDAO.DeleteEntity(myLawID)
				Else
					'exception:law record is empty or duplicated
				End If
			Else
				'exception:law id is empty
			End If
		End Sub
		Private Sub ButtonEntityDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEntityDelete.Click
			If lawID.Trim.Length > 0 Then
				DeleteLawData(lawID)

				lawID = ""
				Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID)
			Else
				'exception:law id is empty
			End If
		End Sub
		Private Sub ButtonContentAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContentAction.Click
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet
			Dim myContentDAO As New LawContentDAOExtand
			Dim myContentDataSet As DataSet
			Dim myContentID As String = ""
			Dim myContentNumber As String = ""
			Dim myContent As String = ""
			Dim myContentOrder As Integer = 1

			If lawID.Trim.Length > 0 Then
				myContentNumber = TextBoxContentNumber.Text.Trim
				myContent = TextBoxContent.Text.Trim
				myContentOrder = CType(TextBoxContentOrder.Text.Trim, Integer)

				If contentID.Trim.Length > 0 Then
					If action.Trim.Length > 0 Then
						If action.Trim = "update" Then
							'update content
							myContentDataSet = myContentDAO.GetEntitysByEntityID(contentID)
							If myContentDataSet.Tables(0).Rows.Count = 1 Then
								'actual action
								myContentDAO.UpdateEntity(contentID, lawID, myContentNumber, myContent, myContentOrder)
								Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & lawID)
							Else
								'exception:content record is empty or duplicated
							End If
						Else
							If action.Trim = "delete" Then
								'delete content
								myContentDataSet = myContentDAO.GetEntitysByEntityID(contentID)
								If myContentDataSet.Tables(0).Rows.Count = 1 Then
									'actual action
									myContentDAO.DeleteEntity(contentID)
									Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & lawID)
								Else
									'exception:content record is empty or duplicated
								End If
							Else
								'exception:unknown action
							End If
						End If
					Else
						'exception:no action
					End If
				Else
					'insert new content
					myContentDAO.InsertEntity(lawID, myContentNumber, myContent, myContentOrder)
					Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & lawID)
				End If
			Else
				'exception:law id is empty
			End If
		End Sub
		Private Sub ButtonAppendAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAppendAction.Click
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet
			Dim myAppendDAO As New LawAppendDAOExtand
			Dim myAppendDataSet As DataSet
			Dim myAppendID As String = ""
			Dim myAppendName As String = ""
			Dim myAppendDescription As String = ""
			Dim myAppendFile As HttpPostedFile = AppendFile.PostedFile
			Dim myAppendOrder As Integer = 1
			Dim myPhysicalFileName As String = ""
			Dim myOldFileName As String = ""
			Dim identityKey As String = Now.Year & Microsoft.VisualBasic.Right("00" & Now.Month, 2) & Microsoft.VisualBasic.Right("00" & Now.Day, 2) & Microsoft.VisualBasic.Right("00" & Now.Hour, 2) & Microsoft.VisualBasic.Right("00" & Now.Minute, 2) & Microsoft.VisualBasic.Right("00" & Now.Second, 2) & Microsoft.VisualBasic.Right("000" & Now.Millisecond, 3)
			Dim myFileSize As Integer = 0

			If lawID.Trim.Length > 0 Then
				myAppendName = TextboxAppendName.Text.Trim
				myAppendDescription = TextboxAppendDescription.Text.Trim
				myAppendOrder = CType(TextBoxAppendOrder.Text.Trim, Integer)
				If Not (myAppendFile Is Nothing) Then
					myPhysicalFileName = Server.MapPath("/PortalFiles/UpLoadFiles/AuditSystem/LawAppend") & "/" & identityKey & Path.GetFileName(myAppendFile.FileName)
				End If

				If appendID.Trim.Length > 0 Then
					If action.Trim.Length > 0 Then
						If action.Trim = "update" Then
							'update append
							myAppendDataSet = myAppendDAO.GetEntitysByEntityID(appendID)
							If myAppendDataSet.Tables(0).Rows.Count = 1 Then
								'update append file
								myOldFileName = CType(myAppendDataSet.Tables(0).Rows(0).Item("FileName"), String)
								If File.Exists(myOldFileName) Then
									File.Delete(myOldFileName)
								End If
								If File.Exists(myPhysicalFileName) Then
									File.Delete(myPhysicalFileName)
								End If
								If Not (myAppendFile Is Nothing) Then
									myAppendFile.SaveAs(myPhysicalFileName)
									myFileSize = myAppendFile.ContentLength
								End If
								'actual action
								myAppendDAO.UpdateEntity(appendID, lawID, myAppendName, myAppendDescription, myPhysicalFileName, myFileSize, myAppendOrder)
								Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & lawID)
							Else
								'exception:append record is empty or duplicated
							End If
						Else
							If action.Trim = "delete" Then
								'delete append
								If myAppendDataSet.Tables(0).Rows.Count = 1 Then
									'delete append file
									myOldFileName = CType(myAppendDataSet.Tables(0).Rows(0).Item("FileName"), String)
									If File.Exists(myOldFileName) Then
										File.Delete(myOldFileName)
									End If
									'actual action
									myAppendDAO.DeleteEntity(appendID)
									Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & lawID)
								Else
									'exception:append record is empty or duplicated
								End If
							Else
								'exception:unknown action
							End If
						End If
					Else
						'exception:no action
					End If
				Else
					'insert new append
					If File.Exists(myPhysicalFileName) Then
						File.Delete(myPhysicalFileName)
					End If
					If Not (myAppendFile Is Nothing) Then
						myAppendFile.SaveAs(myPhysicalFileName)
						myFileSize = myAppendFile.ContentLength
					End If
					'actual action
					myAppendDAO.InsertEntity(lawID, myAppendName, myAppendDescription, myPhysicalFileName, myFileSize, myAppendOrder)
					Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & lawID)
				End If
			Else
				'exception:news id is empty
			End If
		End Sub

		Private Sub ButtonParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParent.Click
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim i As Integer = 0
			Dim myParentID As String = ""
			Dim myPreviousID As String = ""

			If lawID.Trim.Length > 0 Then
				myPreviousID = lawID
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String)
					'read parent record
					myLawDataSet = myLawDAO.GetEntitysByEntityID(myParentID)
					If myLawDataSet.Tables(0).Rows.Count = 1 Then
						myPreviousID = CType(myLawDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String)
					Else
						'top of tree
						myPreviousID = "2006010100000001"
						myParentID = "0"
					End If
					Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & myParentID & "&lawID=" & myPreviousID)
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub

		Private Sub ButtonChild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonChild.Click
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim i As Integer = 0
			Dim myParentID As String = ""
			Dim myNextID As String = ""

			If lawID.Trim.Length > 0 Then
				myNextID = lawID
				myParentID = parentID
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					'read one of child
					myLawDataSet = myLawDAO.GetEntitysByParentID(lawID, 1)
					If myLawDataSet.Tables(0).Rows.Count = 1 Then
						myNextID = CType(myLawDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String)
					End If
					Response.Redirect("~/DesktopModules/AuditSystem/LawAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & myParentID & "&lawID=" & myNextID)
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub
	End Class
End Namespace