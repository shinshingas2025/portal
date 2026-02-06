Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal


	Public Class DMSLogArchive
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents Button2 As System.Web.UI.WebControls.Button
		Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
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
		Private fileID As String = ""

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

			If Not (Request.Params("fileID") Is Nothing) Then
				fileID = Request.Params("fileID")
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

		Private Function GetFileSize(ByVal myFileSize As Integer) As String
			Dim result As String = ""
			If myFileSize >= 1073741824 Then
				result = CType(Round(myFileSize / 1073741824 * 100) / 100, String) & "GB"
			Else
				If myFileSize >= 1048576 Then
					result = CType(Round(myFileSize / 1048576 * 100) / 100, String) & "MB"
				Else
					If myFileSize >= 1024 Then
						result = CType(Round(myFileSize / 1024 * 100) / 100, String) & "KB"
					Else
						result = myFileSize & "Bytes"
					End If
				End If
			End If
			Return result
		End Function

		Private Sub PagePartLoad()
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myCommunityDAO As New EIIS_CommunityDAOExtand
			Dim myLiteralControl As LiteralControl
			Dim myTableControl As HtmlTable
			Dim myTableRowControl As HtmlTableRow
			Dim myTableCellControl As HtmlTableCell
			Dim myHyperLinkControl As HyperLink
			Dim iFolderCount As Integer = 0
			Dim iFileCount As Integer = 0
			Dim i As Integer = 0
			Dim myParentID As String = ""
			Dim myFolderID As String = ""
			Dim myFileID As String = ""
			Dim myName As String = ""
			Dim myFileName As String = ""
			Dim myFileSize As Integer = 0
			Dim myMajorRevision As Integer = 0
			Dim myMinorRevision As Integer = 0
			Dim myPermissionName As String = ""
			Dim myPermissionID As String = ""
			Dim myOwnerID As Integer = 0
			Dim myModifiedDate As Date = Now

			myTableControl = New HtmlTable
			myTableControl.CellPadding = 0
			myTableControl.CellSpacing = 0
			myTableControl.Border = 1

			If fileID.Trim.Length > 0 Then
				'file
				myFileDataSet = myFileDAO.GetEntitysByEntityID(fileID)
				If myFileDataSet.Tables(0).Rows.Count = 1 Then
					myFolderID = CType(myFileDataSet.Tables(0).Rows(0).Item("FolderID"), String)
					myName = CType(myFileDataSet.Tables(0).Rows(0).Item("Name"), String)
					iFileCount = myFileDAO.GetTotalRowByFolderIDAndName(myFolderID, myName)
					If iFileCount > 0 Then
						myFileDataSet = myFileDAO.GetEntitysByFolderIDAndName(myFolderID, myName)
						For i = 0 To iFileCount - 1
							myFileID = CType(myFileDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							myFolderID = CType(myFileDataSet.Tables(0).Rows(i).Item("FolderID"), String)
							myName = CType(myFileDataSet.Tables(0).Rows(i).Item("Name"), String)
							myMajorRevision = CType(myFileDataSet.Tables(0).Rows(i).Item("MajorRevision"), Integer)
							myMinorRevision = CType(myFileDataSet.Tables(0).Rows(i).Item("MinorRevision"), Integer)
							myFileName = CType(myFileDataSet.Tables(0).Rows(i).Item("FileName"), String)
							myFileSize = CType(myFileDataSet.Tables(0).Rows(i).Item("FileSize"), Integer)
							myOwnerID = CType(myFileDataSet.Tables(0).Rows(i).Item("GroupID"), Integer)
							myModifiedDate = CType(myFileDataSet.Tables(0).Rows(i).Item("ModifiedDate"), Date)

							myTableRowControl = New HtmlTableRow
							'icon
							myTableCellControl = New HtmlTableCell
							myTableCellControl.InnerHtml = "<IMG src='/PortalFiles/DMS/icon_filetype/file.gif' >"
							myTableRowControl.Controls.Add(myTableCellControl)
							'name
							myTableCellControl = New HtmlTableCell
							myTableCellControl.InnerHtml = "<a href='DMSViewArchive.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&folderID=" & myFolderID & "&fileID=" & myFileID & "'>" & myName & "</a>"
							myTableRowControl.Controls.Add(myTableCellControl)
							'version
							myTableCellControl = New HtmlTableCell
							myTableCellControl.InnerText = myMajorRevision & "." & myMinorRevision
							myTableRowControl.Controls.Add(myTableCellControl)
							'file size
							myTableCellControl = New HtmlTableCell
							myTableCellControl.InnerText = GetFileSize(myFileSize)
							myTableRowControl.Controls.Add(myTableCellControl)
							'file owner
							myTableCellControl = New HtmlTableCell
							myTableCellControl.InnerText = myCommunityDAO.GetObjNameByObjID(myOwnerID)
							myTableRowControl.Controls.Add(myTableCellControl)
							'file modified date
							myTableCellControl = New HtmlTableCell
							myTableCellControl.InnerText = CType(myModifiedDate, String)
							myTableRowControl.Controls.Add(myTableCellControl)
							'file action
							myTableCellControl = New HtmlTableCell
							'delete
							myHyperLinkControl = New HyperLink
							myHyperLinkControl.NavigateUrl = "DMSDeleteArchive.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&fileID=" & myFileID
							myHyperLinkControl.ImageUrl = "/PortalFiles/DMS/ui_misc/delete.gif"
							myTableCellControl.Controls.Add(myHyperLinkControl)
							'modify property
							myHyperLinkControl = New HyperLink
							myHyperLinkControl.NavigateUrl = "DMSModifyArchive.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&fileID=" & myFileID
							myHyperLinkControl.ImageUrl = "/PortalFiles/DMS/icon_action/edit.gif"
							myTableCellControl.Controls.Add(myHyperLinkControl)
							'copy
							myHyperLinkControl = New HyperLink
							myHyperLinkControl.NavigateUrl = "DMSCopyArchiveMenu.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&folderID=" & myFolderID & "&fileID=" & myFileID
							myHyperLinkControl.ImageUrl = "/PortalFiles/DMS/icon_action/copy.gif"
							myTableCellControl.Controls.Add(myHyperLinkControl)
							'move
							myHyperLinkControl = New HyperLink
							myHyperLinkControl.NavigateUrl = "DMSMoveArchiveMenu.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&folderID=" & myFolderID & "&fileID=" & myFileID
							myHyperLinkControl.ImageUrl = "/PortalFiles/DMS/icon_action/move.gif"
							myTableCellControl.Controls.Add(myHyperLinkControl)
							'update
							myHyperLinkControl = New HyperLink
							myHyperLinkControl.NavigateUrl = "DMSUpdateArchive.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&fileID=" & myFileID
							myHyperLinkControl.ImageUrl = "/PortalFiles/DMS/icon_action/update.gif"
							myTableCellControl.Controls.Add(myHyperLinkControl)
							'download
							myHyperLinkControl = New HyperLink
							myHyperLinkControl.NavigateUrl = "DMSDownloadArchive.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&folderID=" & myFolderID & "&fileID=" & myFileID
							myHyperLinkControl.ImageUrl = "/PortalFiles/DMS/icon_action/zip.gif"
							myTableCellControl.Controls.Add(myHyperLinkControl)

							myTableRowControl.Controls.Add(myTableCellControl)

							myTableControl.Controls.Add(myTableRowControl)
						Next
					End If
				Else
					'exception:file record is empty or duplicated
				End If
			End If

			PlaceHolder1.Controls.Add(myTableControl)
		End Sub
		Private Sub PageLoad()
			PagePartLoad()
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class
End Namespace