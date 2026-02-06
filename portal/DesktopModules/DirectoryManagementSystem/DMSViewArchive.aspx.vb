Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class DMSViewArchive
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents LabelDetail As System.Web.UI.WebControls.Label
		Protected WithEvents DropDownListMetaKeyWord As System.Web.UI.WebControls.DropDownList
		Protected WithEvents LabelDocumentType As System.Web.UI.WebControls.Label
		Protected WithEvents LabelURL As System.Web.UI.WebControls.Label
		Protected WithEvents LabelName As System.Web.UI.WebControls.Label
		Protected WithEvents LabelMetaData As System.Web.UI.WebControls.Label
		Protected WithEvents LabelMajorRevision As System.Web.UI.WebControls.Label
		Protected WithEvents LabelMinorRevision As System.Web.UI.WebControls.Label
		Protected WithEvents LabelOwner As System.Web.UI.WebControls.Label
		Protected WithEvents LabelPermission As System.Web.UI.WebControls.Label
		Protected WithEvents LabelPassword As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button

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
		Private folderID As String = "0"
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

			If Not (Request.Params("folderID") Is Nothing) Then
				folderID = Request.Params("folderID").Trim
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
			Dim myOwnerID As Integer = 0
			Dim myOwnerName As String = ""
			Dim myPermissionID As String = ""
			Dim myPermissionName As String = ""
			Dim myPassword As String = ""
			Dim myDescription As String = ""

			'initial web control
			LabelDocumentType.Text = ""
			LabelURL.Text = ""
			LabelName.Text = ""
			LabelMetaData.Text = ""
			LabelMajorRevision.Text = ""
			LabelMinorRevision.Text = ""
			LabelOwner.Text = ""
			LabelPermission.Text = ""
			LabelPassword.Text = ""
			LabelDescription.Text = ""
			'
			If fileID.Trim.Length > 0 Then
				myFileDataSet = myFileDAO.GetEntitysByEntityID(fileID)
				If myFileDataSet.Tables(0).Rows.Count = 1 Then
					myDocumentTypeID = CType(myFileDataSet.Tables(0).Rows(0).Item("DocumentTypeID"), String)
					myURL = CType(myFileDataSet.Tables(0).Rows(0).Item("URL"), String)
					myName = CType(myFileDataSet.Tables(0).Rows(0).Item("Name"), String)
					myMetaData = CType(myFileDataSet.Tables(0).Rows(0).Item("MetaData"), String)
					myMajorRevision = CType(myFileDataSet.Tables(0).Rows(0).Item("MajorRevision"), Integer)
					myMinorRevision = CType(myFileDataSet.Tables(0).Rows(0).Item("MinorRevision"), Integer)
					myOwnerID = CType(myFileDataSet.Tables(0).Rows(0).Item("GroupID"), Integer)
					myPermissionID = CType(myFileDataSet.Tables(0).Rows(0).Item("Permission"), String)
					myPassword = CType(myFileDataSet.Tables(0).Rows(0).Item("Password"), String)
					myDescription = CType(myFileDataSet.Tables(0).Rows(0).Item("Description"), String)

					myDocumentTypeName = myDocumentTypeDAO.GetNameByEntityID(myDocumentTypeID)
					myOwnerName = myCommunityDAO.GetObjNameByObjID(myOwnerID)
					myPermissionName = "權限模式" & myPermissionID

					LabelDocumentType.Text = myDocumentTypeName
					LabelURL.Text = myURL
					LabelName.Text = myName
					LabelMetaData.Text = myMetaData
					LabelMajorRevision.Text = CType(myMajorRevision, String)
					LabelMinorRevision.Text = CType(myMinorRevision, String)
					LabelOwner.Text = myOwnerName
					LabelPermission.Text = myPermissionName
					LabelPassword.Text = myPassword
					LabelDescription.Text = myDescription
				Else
					'file record is empty or duplicated
				End If
			End If
		End Sub
		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class
End Namespace