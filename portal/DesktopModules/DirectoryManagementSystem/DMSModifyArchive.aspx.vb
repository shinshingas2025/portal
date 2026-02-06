Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class DMSModifyArchive
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents LabelDetail As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected WithEvents DropDownListOwner As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListPermission As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxPassword As System.Web.UI.WebControls.TextBox
		Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
		Protected WithEvents TextBoxPasswordConfirm As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents CheckBoxSaveKeyword As System.Web.UI.WebControls.CheckBox
		Protected WithEvents UploadFile1 As System.Web.UI.HtmlControls.HtmlInputFile
		Protected WithEvents TextboxURL As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextboxMajorRevision As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextboxMinorRevision As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListDocumentType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListMetaKeyWord As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextboxMetaData As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxName As System.Web.UI.WebControls.TextBox
		Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected WithEvents ListBoxMetaKeyWord As System.Web.UI.WebControls.ListBox
		Protected WithEvents TextBoxOldPassword As System.Web.UI.WebControls.TextBox
		Protected WithEvents LabelResult As System.Web.UI.WebControls.Label
		Protected WithEvents LabelVersionResult As System.Web.UI.WebControls.Label

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

			If Not (Request.Params("fileID") Is Nothing) Then
				fileID = Request.Params("fileID").Trim
			End If

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
			Dim myFileCount As Integer = 0
			Dim myCommunityDAO As New EIIS_CommunityDAOExtand
			Dim myCommunityDataSet As DataSet
			Dim myCommunityCount As Integer = 0
			Dim myDocumentTypeDAO As New DMS_DocumentTypeDAOExtand
			Dim myDocumentTypeDataSet As DataSet
			Dim myDocumentTypeCount As Integer = 0
			Dim myMetaKeywordDAO As New DMS_MetaKeywordDAOExtand
			Dim myMetaKeywordDataSet As DataSet
			Dim myMetaKeywordCount As Integer = 0
			Dim myListItem As ListItem
			Dim myObjID As Integer = 0
			Dim myObjName As String = ""
			Dim myDocumentTypeID As String = ""
			Dim myDocumentTypeName As String = ""
			Dim myMetaKeywordID As String = ""
			Dim myMetaKeywordName As String = ""
			Dim i As Integer = 0
			Dim myURL As String = ""
			Dim myName As String = ""
			Dim myMetaData As String = ""
			Dim myMajorRevision As Integer = 0
			Dim myMinorRevision As Integer = 0
			Dim myPermission As String = ""
			Dim myOldPassword As String = ""
			Dim myDescription As String = ""

			If fileID.Trim.Length > 0 Then
				'initial web control
				TextboxURL.Text = ""
				TextBoxName.Text = ""
				TextboxMetaData.Text = ""
				TextboxMajorRevision.Text = ""
				TextboxMinorRevision.Text = ""
				TextBoxPassword.Text = ""
				TextBoxPasswordConfirm.Text = ""
				TextBoxDescription.Text = ""
				DropDownListOwner.Items.Clear()
				DropDownListDocumentType.Items.Clear()
				ListBoxMetaKeyWord.Items.Clear()
				LabelResult.Text = ""
				LabelVersionResult.Text = ""
				CheckBoxSaveKeyword.Checked = False
				'initial owner list
				myCommunityCount = myCommunityDAO.GetTotalRow
				If myCommunityCount > 0 Then
					myCommunityDataSet = myCommunityDAO.GetEntitys()
					For i = 0 To myCommunityCount - 1
						myObjID = CType(myCommunityDataSet.Tables(0).Rows(i).Item("objID"), Integer)
						myObjName = CType(myCommunityDataSet.Tables(0).Rows(i).Item("objName"), String)

						myListItem = New ListItem
						myListItem.Value = CType(myObjID, String)
						myListItem.Text = myListItem.Value & " " & myObjName

						DropDownListOwner.Items.Add(myListItem)
					Next
				End If
				'initial documenttype list
				myDocumentTypeCount = myDocumentTypeDAO.GetTotalRow()
				If myDocumentTypeCount > 0 Then
					myDocumentTypeDataSet = myDocumentTypeDAO.GetEntitys()
					For i = 0 To myDocumentTypeCount - 1
						myDocumentTypeID = CType(myDocumentTypeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myDocumentTypeName = CType(myDocumentTypeDataSet.Tables(0).Rows(i).Item("Name"), String)

						myListItem = New ListItem
						myListItem.Value = myDocumentTypeID
						myListItem.Text = myDocumentTypeName

						DropDownListDocumentType.Items.Add(myListItem)
					Next
				End If
				'initial metakeyword list
				myMetaKeywordCount = myMetaKeywordDAO.GetTotalRow()
				If myMetaKeywordCount > 0 Then
					myMetaKeywordDataSet = myMetaKeywordDAO.GetEntitys()
					For i = 0 To myMetaKeywordCount - 1
						myMetaKeywordID = CType(myMetaKeywordDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myMetaKeywordName = CType(myMetaKeywordDataSet.Tables(0).Rows(i).Item("Keyword"), String)

						myListItem = New ListItem
						myListItem.Value = myMetaKeywordID
						myListItem.Text = myMetaKeywordName

						ListBoxMetaKeyWord.Items.Add(myListItem)
					Next
				End If

				myFileDataSet = myFileDAO.GetEntitysByEntityID(fileID)
				If myFileDataSet.Tables(0).Rows.Count = 1 Then
					myDocumentTypeID = CType(myFileDataSet.Tables(0).Rows(0).Item("DocumentTypeID"), String)
					myURL = CType(myFileDataSet.Tables(0).Rows(0).Item("URL"), String)
					myName = CType(myFileDataSet.Tables(0).Rows(0).Item("Name"), String)
					myMetaData = CType(myFileDataSet.Tables(0).Rows(0).Item("MetaData"), String)
					myMajorRevision = CType(myFileDataSet.Tables(0).Rows(0).Item("MajorRevision"), Integer)
					myMinorRevision = CType(myFileDataSet.Tables(0).Rows(0).Item("MinorRevision"), Integer)
					myObjID = CType(myFileDataSet.Tables(0).Rows(0).Item("GroupID"), Integer)
					myPermission = CType(myFileDataSet.Tables(0).Rows(0).Item("Permission"), String)
					myOldPassword = CType(myFileDataSet.Tables(0).Rows(0).Item("Password"), String)
					myDescription = CType(myFileDataSet.Tables(0).Rows(0).Item("Description"), String)

					Try
						DropDownListDocumentType.SelectedValue = myDocumentTypeID
					Catch ex As ArgumentOutOfRangeException
					End Try
					TextboxURL.Text = myURL
					TextBoxName.Text = myName
					TextboxMetaData.Text = myMetaData
					TextboxMajorRevision.Text = CType(myMajorRevision, String)
					TextboxMinorRevision.Text = CType(myMinorRevision, String)
					Try
						DropDownListOwner.SelectedValue = CType(myObjID, String)
					Catch ex As ArgumentOutOfRangeException
					End Try
					Try
						DropDownListPermission.SelectedValue = myPermission
					Catch ex As ArgumentOutOfRangeException
					End Try
					TextBoxDescription.Text = myDescription
				Else
					'exception:file record is empty or duplicated
				End If
			Else
				'exception:file id is empty
			End If
		End Sub
		Private Sub PageSave()
			Dim myFileDAO As New DMS_FileDAOExtand
			Dim myFileDataSet As DataSet
			Dim myFileCount As Integer = 0
			Dim myFilePartDataSet As DataSet
			Dim myFilePartCount As Integer = 0
			Dim myDocumentType As String = ""
			Dim myFileName As String = ""
			Dim myOldFileName As String = ""
			Dim myFileSize As Integer = 0
			Dim myURL As String = ""
			Dim myMetaData As String = ""
			Dim myMajorRevision As Integer = 0
			Dim myMinorRevision As Integer = 0
			Dim myName As String = ""
			Dim myOwner As Integer = 0
			Dim myPermission As String = ""
			Dim myPassword As String = ""
			Dim myOldPassword As String = ""
			Dim myDescription As String = ""
			Dim myFile As HttpPostedFile = UploadFile1.PostedFile
			Dim myPhysicalFileName As String = ""
			Dim writer As StreamWriter
			Dim identityKey As String = Now.Year & Microsoft.VisualBasic.Right("00" & Now.Month, 2) & Microsoft.VisualBasic.Right("00" & Now.Day, 2) & Microsoft.VisualBasic.Right("00" & Now.Hour, 2) & Microsoft.VisualBasic.Right("00" & Now.Minute, 2) & Microsoft.VisualBasic.Right("00" & Now.Second, 2) & Microsoft.VisualBasic.Right("000" & Now.Millisecond, 3)
			Dim myMetaKeywordDAO As New DMS_MetaKeywordDAOExtand
			Dim myMetaKeywordCount As Integer = 0
			Dim delimStr As String = " "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim i As Integer = 0
			Dim myKeyword As String = ""
			Dim myOldFolderID As String = ""

			If fileID.Trim.Length > 0 Then
				myDocumentType = DropDownListDocumentType.SelectedValue
				myURL = TextboxURL.Text.Trim
				myName = TextBoxName.Text.Trim
				myMetaData = TextboxMetaData.Text.Trim
				Try
					myMajorRevision = CType(TextboxMajorRevision.Text, Integer)
				Catch ex As Exception
					myMajorRevision = 0
				End Try
				Try
					myMinorRevision = CType(TextboxMinorRevision.Text, Integer)
				Catch ex As Exception
					myMinorRevision = 0
				End Try
				myOwner = CType(DropDownListOwner.SelectedValue, Integer)
				myPermission = DropDownListPermission.SelectedValue
				myPassword = TextBoxPassword.Text.Trim
				myDescription = TextBoxDescription.Text.Trim

				myFileDataSet = myFileDAO.GetEntitysByEntityID(fileID)
				If myFileDataSet.Tables(0).Rows.Count = 1 Then
					myOldFileName = CType(myFileDataSet.Tables(0).Rows(0).Item("FileName"), String)
					myOldFolderID = CType(myFileDataSet.Tables(0).Rows(0).Item("FolderID"), String)
					myOldPassword = CType(myFileDataSet.Tables(0).Rows(0).Item("Password"), String)
					'check version
					myFileCount = myFileDAO.GetTotalRowByFolderIDAndNameAndVersion(myOldFolderID, myName, myMajorRevision, myMinorRevision)
					If myFileCount = 0 Then
						'check password
						If myOldPassword.Trim = TextBoxOldPassword.Text.Trim Then
							'clear old file
							If File.Exists(myOldFileName) Then
								File.Delete(myOldFileName)
							End If
							'save upload file
							If Not (myFile Is Nothing) Then
								myFileName = Path.GetFileName(myFile.FileName)
								If myFileName.Trim <> "" Then
									myPhysicalFileName = Server.MapPath("/PortalFiles/UpLoadFiles/DMS") & "/" & identityKey & myFileName
									'clear exist file
									If File.Exists(myPhysicalFileName) Then
										File.Delete(myPhysicalFileName)
									End If
									'save upload file
									myFile.SaveAs(myPhysicalFileName)

									myFileSize = myFile.ContentLength
								End If
							End If
							myFileDAO.UpdateEntity(fileID, myName, myPhysicalFileName, myFileSize, myOldFolderID, myDescription, myMetaData, myPermission, myOwner, myMajorRevision, myMinorRevision, myURL, myPassword, myDocumentType, "", "", 0, Now)
						Else
							'password is not correct
							LabelResult.Text = "密碼錯誤!"
						End If
					Else
						'file duplicated
						LabelVersionResult.Text = "版本數重複!"
					End If
				Else
					'exception:file record is empty or duplicated
				End If
			Else
				'exception:file id is empty
			End If
			If CheckBoxSaveKeyword.Checked Then
				If myMetaData <> "" Then
					tempString = myMetaData
					tempArray = tempString.Split(delimiter)
					For i = 0 To tempArray.Length - 1
						myKeyword = tempArray(i)
						myMetaKeywordCount = myMetaKeywordDAO.GetTotalRowByKeyword(myKeyword)
						If myMetaKeywordCount = 0 Then
							myMetaKeywordDAO.InsertEntity(0, myKeyword)
						Else
							'keyword is exist
						End If
					Next
				End If
			End If
		End Sub
		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			PageSave()
		End Sub

		Protected Sub DropDownListMetaKeyWord_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownListMetaKeyWord.SelectedIndexChanged
			Dim delimStr As String = " "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myKeyword As String = ""
			Dim i As Integer = 0
			Dim bFound As Boolean = False
			Dim anItem As ListItem
			anItem = DropDownListMetaKeyWord.SelectedItem
			TextboxMetaData.Text = TextboxMetaData.Text.Trim
			tempString = TextboxMetaData.Text
			tempArray = tempString.Split(delimiter)
			bFound = False
			For i = 0 To tempArray.Length - 1
				myKeyword = tempArray(i)
				If myKeyword = anItem.Text Then
					bFound = True
				End If
			Next
			If bFound = False Then
				TextboxMetaData.Text = TextboxMetaData.Text & " " & anItem.Text
			End If
		End Sub

		Private Sub ListBoxMetaKeyWord_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxMetaKeyWord.SelectedIndexChanged
			Dim delimStr As String = " "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myKeyword As String = ""
			Dim i As Integer = 0
			Dim bFound As Boolean = False
			Dim anItem As ListItem
			anItem = ListBoxMetaKeyWord.SelectedItem
			TextboxMetaData.Text = TextboxMetaData.Text.Trim
			tempString = TextboxMetaData.Text
			tempArray = tempString.Split(delimiter)
			For i = 0 To tempArray.Length - 1
				myKeyword = tempArray(i)
				If myKeyword = anItem.Text Then
					bFound = True
				End If
			Next
			If bFound = False Then
				TextboxMetaData.Text = LTrim(TextboxMetaData.Text & " " & anItem.Text)
			End If
		End Sub
	End Class
End Namespace