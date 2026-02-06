Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal
	Public Class DMSDownloadFolder
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
		Protected WithEvents TextBoxPassword As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents LabelResult As System.Web.UI.WebControls.Label

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
			LabelResult.Text = ""

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
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub

		Private Function GetFileListInVersion(ByVal myDataSet As DataSet) As DataSet
			Dim resultDataSet As New DataSet
			Dim myOriginFolderID As String = ""
			Dim myOriginParentID As String = ""
			Dim myOriginName As String = ""
			Dim myOriginMajorRevision As Integer = 0
			Dim myOriginMinorRevision As Integer = 0
			Dim myOriginVision As Integer = 0
			Dim myTargetFolderID As String = ""
			Dim myTargetParentID As String = ""
			Dim myTargetName As String = ""
			Dim myTargetMajorRevision As Integer = 0
			Dim myTargetMinorRevision As Integer = 0
			Dim myTargetVision As Integer = 0
			Dim myColumnValue As String = ""
			Dim myDataRow As DataRow
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim k As Integer = 0
			Dim bFound As Boolean = False
			If Not (myDataSet Is Nothing) Then
				resultDataSet = myDataSet.Clone()
				If myDataSet.Tables(0).Rows.Count > 0 Then
					For i = 0 To myDataSet.Tables(0).Rows.Count - 1
						myOriginFolderID = CType(myDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myOriginParentID = CType(myDataSet.Tables(0).Rows(i).Item("FolderID"), String)
						myOriginName = CType(myDataSet.Tables(0).Rows(i).Item("Name"), String)
						myOriginMajorRevision = CType(myDataSet.Tables(0).Rows(i).Item("MajorRevision"), Integer)
						myOriginMinorRevision = CType(myDataSet.Tables(0).Rows(i).Item("MinorRevision"), Integer)
						myOriginVision = myOriginMajorRevision * 1000 + myOriginMinorRevision
						bFound = False
						If resultDataSet.Tables(0).Rows.Count > 0 Then
							For j = 0 To resultDataSet.Tables(0).Rows.Count - 1
								myTargetFolderID = CType(resultDataSet.Tables(0).Rows(j).Item("EntityID"), String)
								myTargetParentID = CType(resultDataSet.Tables(0).Rows(j).Item("FolderID"), String)
								myTargetName = CType(resultDataSet.Tables(0).Rows(j).Item("Name"), String)
								myTargetMajorRevision = CType(resultDataSet.Tables(0).Rows(j).Item("MajorRevision"), Integer)
								myTargetMinorRevision = CType(resultDataSet.Tables(0).Rows(j).Item("MinorRevision"), Integer)
								myTargetVision = myTargetMajorRevision * 1000 + myTargetMinorRevision
								If myOriginParentID = myTargetParentID And myOriginName = myTargetName Then
									bFound = True
									'compare version
									If myOriginVision > myTargetVision Then
										'update target record
										For k = 0 To resultDataSet.Tables(0).Columns.Count - 1
											resultDataSet.Tables(0).Rows(j).Item(k) = myDataSet.Tables(0).Rows(i).Item(k)
										Next
									Else
										'do nothing
									End If
									Exit For
								End If
							Next
						End If
						If bFound = False Then
							'insert new record
							resultDataSet.Tables(0).ImportRow(myDataSet.Tables(0).Rows(i))
						End If
					Next
				End If
			End If
			Return resultDataSet
		End Function

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myFolderCount As Integer = 0
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myFileCount As Integer = 0
			Dim myFolderPassword As String
			Dim myDocumentTypeID As String = ""
			Dim myFileName As String = ""
			Dim myFileSize As Integer = 0
			Dim myURL As String = ""
			Dim myName As String = ""
			Dim myMetaData As String = ""
			Dim myMajorRevision As Integer = 0
			Dim myMinorRevision As Integer = 0
			Dim myOwner As Integer = 0
			Dim myPermission As String = ""
			Dim myPassword As String = ""
			Dim myDescription As String = ""
			Dim i As Integer = 0
			Dim myPhysicalFileName As String = ""
			Dim identityKey As String = ""
			Dim myFileID As String = ""
			Dim myDownloadPath As String = "/PortalFiles/DownloadFiles/DMS"
			Dim myWorkDirectory As String = "/PortalFiles/DownloadFiles/DMS/tmp"
			Dim myFileStream As FileStream
			'check target folder id if exist
			If folderID.Trim.Length > 0 Then
				myFolderDataSet = myFolderDAO.GetEntitysByEntityID(folderID)
				If myFolderDataSet.Tables(0).Rows.Count = 1 Then
					'read folder password
					myFolderPassword = CType(myFolderDataSet.Tables(0).Rows(0).Item("Password"), String)
					myName = CType(myFolderDataSet.Tables(0).Rows(0).Item("Name"), String)
					'check if password is match
					If TextBoxPassword.Text.Trim = myFolderPassword.Trim Then
						CopyWorkDirectory(myWorkDirectory, folderID)
						myPhysicalFileName = ZipWorkDirectory(myDownloadPath, myWorkDirectory, myName)
						DeleteWorkDirectory(myWorkDirectory, myName)
						If myPhysicalFileName.Trim.Length > 0 Then
							'download
							myFileStream = New FileStream(myPhysicalFileName, FileMode.Open)
							myFileSize = CType(myFileStream.Length, Integer)
							Context.Response.ContentType = "application/octet-stream"
							Context.Response.AddHeader("Content-Disposition", "attachment; filename=" & HttpUtility.UrlEncode(Path.GetFileName(myPhysicalFileName), System.Text.Encoding.UTF8))
							Context.Response.AddHeader("Content-Length", CType(myFileSize, String))
							Dim myFileBuffer(myFileSize) As Byte
							myFileStream.Read(myFileBuffer, 0, myFileSize)
							myFileStream.Close()
							Context.Response.BinaryWrite(myFileBuffer)
							Context.Response.End()
						End If
					Else
						'password is not correct
						LabelResult.Text = "密碼錯誤!"
					End If
				Else
					'exception:folder record is empty or duplicated
				End If
			Else
				'exception:folder id is empty
			End If
		End Sub
		Private Sub DeleteWorkDirectory(ByVal directoryPath As String, ByVal directoryName As String)
			Dim myDirectoryPath As String = Server.MapPath(directoryPath & "/" & directoryName)
			If Directory.Exists(myDirectoryPath) Then
				Directory.Delete(myDirectoryPath, True)
			End If
		End Sub
		Private Function ZipWorkDirectory(ByVal downloadPath As String, ByVal directoryPath As String, ByVal directoryName As String) As String
			Dim myDownloadPath As String = Server.MapPath(downloadPath)
			Dim myDirectoryPath As String = Server.MapPath(directoryPath & "/" & directoryName)
			Dim myZipPath As String = "C:\\7Zip\\7z.exe"
			Dim myZipCommand As String = "a -t7z"
			Dim myZipFileName As String = myDownloadPath & "/" & directoryName & ".7z"
			Dim myZipArgument As String = "-m0=BCJ2 -m1=LZMA -ms -mmt"
			Dim myCommand As String = "cmd /c " & myZipPath & " " & myZipCommand & " " & myZipFileName & " " & myDirectoryPath & " " & myZipArgument
			'clear old file
			If File.Exists(myZipFileName) Then
				File.Delete(myZipFileName)
			End If
			If Directory.Exists(myDirectoryPath) Then
				Shell(myCommand, AppWinStyle.NormalNoFocus, True)
				Return myZipFileName
			Else
				Return ""
			End If
		End Function
		Private Sub CopyWorkDirectory(ByVal parentDirectoryPath As String, ByVal directoryID As String)
			Dim myWorkDirectory As String = Server.MapPath(parentDirectoryPath)
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myFolderCount As Integer = 0
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myFileCount As Integer = 0
			Dim myFolderID As String = ""
			Dim myFileID As String = ""
			Dim myFolderName As String = ""
			Dim myFileName As String = ""
			Dim myVirtualFileName As String = ""

			Dim i As Integer = 0
			If directoryID.Trim.Length > 0 Then
				myFolderDataSet = myFolderDAO.GetEntitysByEntityID(directoryID)
				If myFolderDataSet.Tables(0).Rows.Count = 1 Then
					myFolderName = CType(myFolderDataSet.Tables(0).Rows(0).Item("Name"), String)
					'clear old directory
					If Directory.Exists(myWorkDirectory & "/" & myFolderName) Then
						Directory.Delete(myWorkDirectory & "/" & myFolderName, True)
					End If
					'create new directory
					Directory.CreateDirectory(myWorkDirectory & "/" & myFolderName)
					'create subdirectory
					myFolderCount = myFolderDAO.GetTotalRowByParentID(directoryID)
					If myFolderCount > 0 Then
						myFolderDataSet = myFolderDAO.GetEntitysByParentID(directoryID)
						For i = 0 To myFolderCount - 1
							myFolderID = CType(myFolderDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							CopyWorkDirectory(parentDirectoryPath & "/" & myFolderName, myFolderID)
						Next
					End If
					'create files
					myFileCount = myFileDAO.GetTotalRowByFolderID(directoryID)
					If myFileCount > 0 Then
						myFileDataSet = GetFileListInVersion(myFileDAO.GetEntitysByFolderID(directoryID))
						For i = 0 To myFileDataSet.Tables(0).Rows.Count - 1
							myFileName = CType(myFileDataSet.Tables(0).Rows(i).Item("FileName"), String)
							If myFileName.Trim.Length > 0 Then
								myVirtualFileName = Path.GetFileName(myFileName).Substring(17)
								If File.Exists(myFileName) Then
									File.Copy(myFileName, myWorkDirectory & "/" & myFolderName & "/" & myVirtualFileName)
								End If
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
	End Class
End Namespace