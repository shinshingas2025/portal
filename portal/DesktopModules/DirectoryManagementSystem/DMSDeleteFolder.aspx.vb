Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class DMSDeleteFolder
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents LabelDetail As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxPassword As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents LabelName As System.Web.UI.WebControls.Label
		Protected WithEvents LabelOwner As System.Web.UI.WebControls.Label
		Protected WithEvents LabelPermission As System.Web.UI.WebControls.Label
		Protected WithEvents LabelResult As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label

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
		Private folderID As String = ""

		Enum ActionType
			all = 0
			insert = 1
			update = 2
			delete = 3
		End Enum
		Enum SequenceType
			before = 1
			after = 2
		End Enum

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁()
			'Session("sid") = "9999"
			'If PortalSecurity.IsInRoles("Admins") = False Then
			'    Response.Redirect("~/Admin/EditAccessDenied.aspx")
			'End If
			' Calculate userid
			If Not (Request.Params("folderID") Is Nothing) Then
				folderID = Request.Params("folderID")
			End If

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
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myCommunityDAO As New EIIS_CommunityDAOExtand
			Dim myCommunityDataSet As DataSet
			Dim myCommunityCount As Integer = 0
			Dim myListItem As ListItem
			Dim myObjID As Integer = 0
			Dim myObjName As String = ""
			Dim i As Integer = 0
			Dim myName As String = ""
			Dim myPermission As String = ""
			Dim myPassword As String = ""
			Dim myDescription As String = ""

			If folderID.Trim.Length > 0 Then
				'initial web control
				TextBoxPassword.Text = ""
				LabelResult.Text = ""

				myFolderDataSet = myFolderDAO.GetEntitysByEntityID(folderID)
				If myFolderDataSet.Tables(0).Rows.Count = 1 Then
					myName = CType(myFolderDataSet.Tables(0).Rows(0).Item("Name"), String)
					myObjID = CType(myFolderDataSet.Tables(0).Rows(0).Item("GroupID"), Integer)
					myObjName = myCommunityDAO.GetObjNameByObjID(myObjID)
					myPermission = CType(myFolderDataSet.Tables(0).Rows(0).Item("Permission"), String)
					myPassword = CType(myFolderDataSet.Tables(0).Rows(0).Item("Password"), String)
					myDescription = CType(myFolderDataSet.Tables(0).Rows(0).Item("Description"), String)

					LabelName.Text = myName
					LabelOwner.Text = myObjName
					LabelPermission.Text = "權限模式" & myPermission
					LabelDescription.Text = myDescription
				Else
					'exception:folder record is empty or duplicated
				End If
			Else
				'exception:folder is empty
			End If
		End Sub
		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			PageAction()
		End Sub
		Private Sub PageAction()
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myFolderCount As Integer = 0
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myFileCount As Integer = 0
			Dim i As Integer = 0
			Dim myFolderID As String = ""
			Dim myFileID As String = ""

			If folderID.Trim.Length > 0 Then
				If DeleteFolder(folderID, TextBoxPassword.Text.Trim) = False Then
					LabelResult.Text = "密碼錯誤!"
				Else
					Response.Redirect(CType(ViewState("UrlReferrer"), String))
				End If
			Else
				'exception:folder id is empty
			End If
		End Sub
		Private Function DeleteFolder(ByVal folderID As String, ByVal password As String) As Boolean
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderDataSet As DataSet
			Dim myFolderCount As Integer = 0
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myFileCount As Integer = 0
			Dim i As Integer = 0
			Dim myFolderID As String = ""
			Dim myFileID As String = ""
			Dim myPassword As String = ""
			Dim result As Boolean = True
			If folderID.Trim.Length > 0 Then
				'delete folder
				myFolderCount = myFolderDAO.GetTotalRowByParentID(folderID)
				If myFolderCount > 0 Then
					myFolderDataSet = myFolderDAO.GetEntitysByParentID(folderID)
					For i = 0 To myFolderCount - 1
						myFolderID = CType(myFolderDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						If DeleteFolder(myFolderID, password) = False Then
							'delete folder failure and return false
							result = False
						End If
					Next
				End If
				'delete file
				myFileCount = myFileDAO.GetTotalRowByFolderID(folderID)
				If myFileCount > 0 Then
					myFileDataSet = myFileDAO.GetEntitysByFolderID(folderID)
					For i = 0 To myFileCount - 1
						myFileID = CType(myFileDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						If DeleteFile(myFileID, password) = False Then
							'delete file failure ans return false
							result = False
						End If
					Next
				End If
				'delete myself
				If result = True Then
					myFolderDataSet = myFolderDAO.GetEntitysByEntityID(folderID)
					If myFolderDataSet.Tables(0).Rows.Count = 1 Then
						myPassword = CType(myFolderDataSet.Tables(0).Rows(0).Item("Password"), String)
						If myPassword = password Then
							myFolderDAO.DeleteEntity(folderID)
						Else
							'password is not correct
							result = False
						End If
					Else
						'exception:folder record is empty or duplicated
					End If
				Else
					'delete member failure ans return false
				End If
			Else
				'exception:folder id is empty
			End If
			Return result
		End Function
		Private Function DeleteFile(ByVal fileID As String, ByVal password As String) As Boolean
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myFilePartDataSet As DataSet
			Dim myFilePartCount As Integer = 0
			Dim myPassword As String = ""
			Dim myDocumentTypeID As String = ""
			Dim myFolderID As String = ""
			Dim myName As String = ""
			Dim i As Integer = 0
			Dim myFileID As String = ""
			Dim myFileName As String = ""
			Dim result As Boolean = True
			If fileID.Trim.Length > 0 Then
				myFileDataSet = myFileDAO.GetEntitysByEntityID(fileID)
				If myFileDataSet.Tables(0).Rows.Count = 1 Then
					myPassword = CType(myFileDataSet.Tables(0).Rows(0).Item("Password"), String)
					myDocumentTypeID = CType(myFileDataSet.Tables(0).Rows(0).Item("DocumentTypeID"), String)
					myFolderID = CType(myFileDataSet.Tables(0).Rows(0).Item("FolderID"), String)
					myName = CType(myFileDataSet.Tables(0).Rows(0).Item("Name"), String)

					If myPassword.Trim = password.Trim Then
						If myDocumentTypeID = "2006010200000001" Then
							'default document type:normal upload file
							'delete file
							myFilePartCount = myFileDAO.GetTotalRowByFolderIDAndName(myFolderID, myName)
							If myFilePartCount > 0 Then
								myFilePartDataSet = myFileDAO.GetEntitysByFolderIDAndName(myFolderID, myName)
								For i = 0 To myFilePartCount - 1
									myFileID = CType(myFilePartDataSet.Tables(0).Rows(i).Item("EntityID"), String)
									myFileName = CType(myFilePartDataSet.Tables(0).Rows(i).Item("FileName"), String)
									'actual action
									myFileDAO.DeleteEntity(myFileID)
									'delete upload file
									Try
										File.Delete(myFileName)
									Catch ex As Exception
										'exception:delete upload file failure
									End Try
								Next
							End If
						End If
					Else
						'password is not correct!
						result = False
					End If
				Else
					'exception:file record is empty or duplicated
				End If
			Else
				'exception:file id is empty
			End If
			Return result
		End Function
		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub
	End Class
End Namespace