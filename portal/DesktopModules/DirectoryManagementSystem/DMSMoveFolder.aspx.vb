Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal
	Public Class DMSMoveFolder
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
		Protected WithEvents Label8 As System.Web.UI.WebControls.Label
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
		Private targetFolderID As String = ""

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If

			If Not (Request.Params("folderID") Is Nothing) Then
				folderID = Request.Params("folderID")
			End If

			If Not (Request.Params("targetFolderID") Is Nothing) Then
				targetFolderID = Request.Params("targetFolderID")
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
			Label8.Text = ""
			LabelResult.Text = ""

			'show folder link
			If folderID.Trim.Length > 0 And targetFolderID.Trim.Length > 0 Then
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
			'show directory link
			If targetFolderID.Trim.Length > 0 Then
				myName = GetDirectoryName(targetFolderID)
				Label8.Text = myName
			Else
				'exception:target file id is empty
			End If

		End Sub

		Private Function GetDirectoryName(ByVal myFolderID As String) As String
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myName As String = ""
			Dim myParentID As String = ""
			If myFolderID.Length > 0 Then
				If myFolderID <> "0" Then
					myFolderDataSet = myFolderDAO.GetEntitysByEntityID(myFolderID)
					If myFolderDataSet.Tables(0).Rows.Count = 1 Then
						myParentID = CType(myFolderDataSet.Tables(0).Rows(0).Item("ParentID"), String)
						If myParentID.Trim.Length > 0 Then
							myName = GetDirectoryName(myParentID) & "/" & CType(myFolderDataSet.Tables(0).Rows(0).Item("Name"), String)
						Else
							myName = CType(myFolderDataSet.Tables(0).Rows(0).Item("Name"), String)
						End If
					Else
						'exception:folder record is empty or duplicated
					End If
				End If
			Else
				'exception:folder is is empty
			End If
			Return myName
		End Function

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub

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
			'check target folder id if exist
			If targetFolderID.Trim.Length > 0 Then
				myFolderDataSet = myFolderDAO.GetEntitysByEntityID(targetFolderID)
				If myFolderDataSet.Tables(0).Rows.Count = 1 Then
					'read folder password
					myFolderPassword = CType(myFolderDataSet.Tables(0).Rows(0).Item("Password"), String)
					'check if password is match
					If TextBoxPassword.Text.Trim = myFolderPassword.Trim Then
						If folderID.Trim.Length > 0 Then
							myFolderDataSet = myFolderDAO.GetEntitysByEntityID(folderID)
							'check if folder record is exist
							If myFolderDataSet.Tables(0).Rows.Count = 1 Then
								myName = CType(myFolderDataSet.Tables(0).Rows(0).Item("Name"), String)
								myDescription = CType(myFolderDataSet.Tables(0).Rows(0).Item("Description"), String)
								myPermission = CType(myFolderDataSet.Tables(0).Rows(0).Item("Permission"), String)
								myPassword = CType(myFolderDataSet.Tables(0).Rows(0).Item("Password"), String)
								myOwner = CType(myFolderDataSet.Tables(0).Rows(0).Item("GroupID"), Integer)

								myFolderCount = myFolderDAO.GetTotalRowByParentIDAndName(targetFolderID, myName)
								'check if copy duplicated
								If myFolderCount = 0 Then
									myFolderDAO.UpdateEntity(folderID, myName, targetFolderID, myDescription, myPermission, myPassword, 0, Now, myOwner)
								Else
									'name duplicated
									LabelResult.Text = "目錄名稱重複!"
								End If
							Else
								'exception:file record is empty or duplicated
							End If
						Else
							'exception:file id or folder id is empty
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