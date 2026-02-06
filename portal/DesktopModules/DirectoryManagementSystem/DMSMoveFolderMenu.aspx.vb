Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal
	Public Class DMSMoveFolderMenu
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolder1 As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents Button2 As System.Web.UI.WebControls.Button
		Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
		Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox

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
		Protected folderID As String = ""
		Private DirectoryTable As HtmlTable

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If

			If Not (Request.Params("folderID") Is Nothing) Then
				folderID = Request.Params("folderID")
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

			'If Not (Request.Params("iCurrentPage") Is Nothing) Then
			'	iCurrentPage = Int32.Parse(Request.Params("iCurrentPage"))
			'End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub

		Private Sub PageLoad()
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myName As String = ""

			HyperLink1.Text = ""
			HyperLink1.NavigateUrl = ""

			'show folder link
			If folderID.Trim.Length > 0 Then
				myFolderDataSet = myFolderDAO.GetEntitysByEntityID(folderID)
				If myFolderDataSet.Tables(0).Rows.Count = 1 Then
					myName = CType(myFolderDataSet.Tables(0).Rows(0).Item("Name"), String)
					HyperLink1.Text = myName
					HyperLink1.NavigateUrl = "DMSBrowse.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & folderID
				Else
					'exception:file record is empty
				End If
			Else
				'exception:file id is empty
			End If

			'directory tree
			DirectoryTable = New HtmlTable
			DirectoryTable.CellPadding = 0
			DirectoryTable.CellSpacing = 0
			DirectoryTable.Border = 0
			DirectoryTable.Width = "100%"

			ShowDirectory("2006010100000001", 0)

			PlaceHolder1.Controls.Add(DirectoryTable)
		End Sub

		Private Sub ShowDirectory(ByVal directoryID As String, ByVal depth As Integer)
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myFolderCount As Integer = 0
			Dim myFolderPartDataSet As DataSet
			Dim myFolderPartCount As Integer
			Dim myName As String = ""
			Dim myFolderID As String = ""
			Dim myFolderPartID As String = ""
			Dim i As Integer = 0
			Dim myLiteralControl As LiteralControl
			Dim myTableRowControl As HtmlTableRow
			Dim myTableCellControl As HtmlTableCell
			Dim myHyperLinkControl As HyperLink
			Dim myImageControl As HtmlImage
			Dim myUncleConut As Integer = 0
			Dim myParentID As String = ""
			Dim mySerialNumber As Integer = 0

			If directoryID.Length > 0 Then
				myFolderDataSet = myFolderDAO.GetEntitysByEntityID(directoryID)
				If myFolderDataSet.Tables(0).Rows.Count = 1 Then
					'show myself
					myTableRowControl = New HtmlTableRow
					myTableRowControl.Height = "16"

					myName = CType(myFolderDataSet.Tables(0).Rows(0).Item("Name"), String)
					myTableCellControl = New HtmlTableCell
					'depth
					If depth > 0 Then
						'blank
						myImageControl = New HtmlImage
						myImageControl.Src = "/PortalFiles/DMS/ui_misc/blank.gif"
						myImageControl.Height = 16
						myImageControl.Width = 16 * (depth - 1)
						myTableCellControl.Controls.Add(myImageControl)
						'link
						myImageControl = New HtmlImage
						myImageControl.Src = "/PortalFiles/DMS/ui_misc/link_final.gif"
						myTableCellControl.Controls.Add(myImageControl)
					End If
					'icon
					myHyperLinkControl = New HyperLink
					If directoryID = folderID Then
						myHyperLinkControl.NavigateUrl = ""
					Else
						myHyperLinkControl.NavigateUrl = "DMSMoveFolder.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&folderID=" & folderID & "&targetFolderID=" & directoryID
					End If
					myHyperLinkControl.ImageUrl = "/PortalFiles/DMS/icon_filetype/folder_closed.gif"
					myTableCellControl.Controls.Add(myHyperLinkControl)
					'name
					myLiteralControl = New LiteralControl
					myLiteralControl.Text = myName
					myTableCellControl.Controls.Add(myLiteralControl)

					myTableRowControl.Controls.Add(myTableCellControl)

					DirectoryTable.Controls.Add(myTableRowControl)

					'show subdirectory
					myFolderPartCount = myFolderDAO.GetTotalRowByParentID(directoryID)
					If myFolderPartCount > 0 Then
						myFolderPartDataSet = myFolderDAO.GetEntitysByParentID(directoryID)
						For i = 0 To myFolderPartCount - 1
							myFolderPartID = CType(myFolderPartDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							If i = myFolderPartCount - 1 Then
								ShowDirectory(myFolderPartID, depth + 1)
							Else
								ShowDirectory(myFolderPartID, depth + 1)
							End If
						Next
					End If
				Else
					'exception:folder record is empty or duplicated
				End If
			Else
				'exception:directory id is empty
			End If
		End Sub
		Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class
End Namespace