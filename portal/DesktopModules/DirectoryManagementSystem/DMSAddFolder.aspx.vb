Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class DMSAddFolder
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents LabelDetail As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxName As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxPassword As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxPasswordConfirm As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents DropDownListOwner As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListPermission As System.Web.UI.WebControls.DropDownList
		Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator

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
		Private parentID As String = "0"

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
			If Not (Request.Params("parentID") Is Nothing) Then
				parentID = Request.Params("parentID")
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
			Dim myCommunityDAO As New EIIS_CommunityDAOExtand
			Dim myCommunityDataSet As DataSet
			Dim myCommunityCount As Integer = 0
			Dim myListItem As ListItem
			Dim myObjID As Integer = 0
			Dim myObjName As String = ""
			Dim i As Integer = 0

			'initial web control
			TextBoxName.Text = ""
			TextBoxPassword.Text = ""
			TextBoxPasswordConfirm.Text = ""
			TextBoxDescription.Text = ""
			DropDownListOwner.Controls.Clear()

			myCommunityCount = myCommunityDAO.GetTotalRow
			If myCommunityCount > 0 Then
				myCommunityDataSet = myCommunityDAO.GetEntitys
				For i = 0 To myCommunityCount - 1
					myObjID = CType(myCommunityDataSet.Tables(0).Rows(i).Item("objID"), Integer)
					myObjName = CType(myCommunityDataSet.Tables(0).Rows(i).Item("objName"), String)

					myListItem = New ListItem
					myListItem.Value = CType(myObjID, String)
					myListItem.Text = myListItem.Value & " " & myObjName

					DropDownListOwner.Items.Add(myListItem)
				Next
			End If
		End Sub
		Private Sub PageSave()
			Dim myFolderDAO As New DMS_FolderDAOExtand
			Dim myFolderCount As Integer = 0
			Dim myName As String = ""
			Dim myOwner As Integer = 0
			Dim myPermission As String = ""
			Dim myPassword As String = ""
			Dim myDescription As String = ""

			If parentID.Trim.Length > 0 Then
				myName = TextBoxName.Text.Trim
				myOwner = CType(DropDownListOwner.SelectedValue, Integer)
				myPermission = DropDownListPermission.SelectedValue
				myPassword = TextBoxPassword.Text.Trim
				myDescription = TextBoxDescription.Text.Trim

				'check if duplicated
				myFolderCount = myFolderDAO.GetTotalRowByParentIDAndName(parentID, myName)
				If myFolderCount > 0 Then
					'exception:folder is exist
				Else
					myFolderDAO.InsertEntity(0, myName, parentID, myDescription, myPermission, myPassword, 0, 0, Now, Now, myOwner)
				End If
			Else
				'exception:parent id is empty
			End If
		End Sub
		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			PageSave()
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub
	End Class
End Namespace