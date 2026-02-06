Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal
	Public Class DMSDownloadArchive
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
		Protected fileID As String = ""
		Protected folderID As String = ""

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If

			If Not (Request.Params("fileID") Is Nothing) Then
				fileID = Request.Params("fileID")
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
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myName As String = ""

			HyperLink1.Text = ""
			HyperLink1.NavigateUrl = ""
			LabelResult.Text = ""

			'show file link
			If fileID.Trim.Length > 0 And folderID.Trim.Length > 0 Then
				myFileDataSet = myFileDAO.GetEntitysByEntityID(fileID)
				If myFileDataSet.Tables(0).Rows.Count = 1 Then
					myName = CType(myFileDataSet.Tables(0).Rows(0).Item("Name"), String)
					HyperLink1.Text = myName
					HyperLink1.NavigateUrl = "DMSViewArchive.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&folderID=" & folderID & "&fileID=" & fileID
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

		Private Sub DeleteWorkFile(ByVal filePath As String, ByVal fileName As String)
			Dim myFilePath As String = Server.MapPath(filePath & "/" & fileName)
			If File.Exists(myFilePath) Then
				File.Delete(myFilePath)
			End If
		End Sub

		Private Function ZipWorkFile(ByVal downloadPath As String, ByVal filePath As String, ByVal fileName As String) As String
			Dim myDownloadPath As String = Server.MapPath(downloadPath)
			Dim myFilePath As String = Server.MapPath(filePath & "/" & fileName)
			Dim myZipPath As String = "C:\\7Zip\\7z.exe"
			Dim myZipCommand As String = "a -t7z"
			Dim myZipFileName As String = myDownloadPath & "/" & Path.GetFileNameWithoutExtension(fileName) & ".7z"
			Dim myZipArgument As String = "-m0=BCJ2 -m1=LZMA -ms -mmt"
			Dim myCommand As String = "cmd /c " & myZipPath & " " & myZipCommand & " " & myZipFileName & " " & myFilePath & " " & myZipArgument
			'clear old file
			If File.Exists(myZipFileName) Then
				File.Delete(myZipFileName)
			End If
			If File.Exists(myFilePath) Then
				Shell(myCommand, AppWinStyle.NormalNoFocus, True)
				Return myZipFileName
			Else
				Return ""
			End If
		End Function

		Private Sub CopyWorkFile(ByVal workDirectoryPath As String, ByVal fileID As String)
			Dim myWorkDirectory As String = Server.MapPath(workDirectoryPath)
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myFileName As String = ""
			Dim myVirtualFileName As String = ""

			If fileID.Trim.Length > 0 Then
				myFileDataSet = myFileDAO.GetEntitysByEntityID(fileID)
				If myFileDataSet.Tables(0).Rows.Count = 1 Then
					myFileName = CType(myFileDataSet.Tables(0).Rows(0).Item("FileName"), String)
					myVirtualFileName = myWorkDirectory & "/" & Path.GetFileName(myFileName).Substring(17)
					'clear old file
					If File.Exists(myVirtualFileName) Then
						File.Delete(myVirtualFileName)
					End If
					If File.Exists(myFileName) Then
						File.Copy(myFileName, myVirtualFileName)
					End If
				Else
					'exception:file record is empty or duplicated
				End If
			Else
				'exception:file id is empty
			End If
		End Sub
		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
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
			Dim myFileStream As FileStream
			Dim myDownloadPath As String = "/PortalFiles/DownloadFiles/DMS"
			Dim myWorkDirectory As String = "/PortalFiles/DownloadFiles/DMS/tmp"
			'check target file id if exist
			If fileID.Trim.Length > 0 Then
				myFileDataSet = myFileDAO.GetEntitysByEntityID(fileID)
				If myFileDataSet.Tables(0).Rows.Count = 1 Then
					'read file password
					myPassword = CType(myFileDataSet.Tables(0).Rows(0).Item("Password"), String)
					myFileName = CType(myFileDataSet.Tables(0).Rows(0).Item("FileName"), String)
					'check if password is match and filename is not empty
					If TextBoxPassword.Text.Trim = myPassword.Trim Then
						'check if filename is empty
						If myFileName.Trim.Length > 0 Then
							'check if file exist
							If File.Exists(myFileName) Then
								CopyWorkFile(myWorkDirectory, fileID)
								myPhysicalFileName = ZipWorkFile(myDownloadPath, myWorkDirectory, Path.GetFileName(myFileName).Substring(17))
								DeleteWorkFile(myWorkDirectory, Path.GetFileName(myFileName).Substring(17))
								If myPhysicalFileName.Trim.Length > 0 Then
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
								'file is not exist
								LabelResult.Text = "檔案遺失!"
							End If
						Else
							'filename is empty
							LabelResult.Text = "無檔案資料!"
						End If
					Else
						'password is not correct
						LabelResult.Text = "密碼錯誤!"
					End If
				Else
					'exception:folder record is empty or duplicated
				End If
			Else
				'exception:target folder id is empty
			End If
		End Sub
	End Class
End Namespace