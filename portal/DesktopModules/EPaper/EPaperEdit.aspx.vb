Imports System.IO
Imports System.text
Namespace ASPNET.StarterKit.Portal


	Public Class EPaperEdit
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents LabelEnable As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
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
		Private epaperID As String = ""
		Protected myTemplateFile As String = ""
		Protected myCSSFile As String = ""
		Protected myContentFile As String = ""
		Dim AuditDAO As New Portal_AuditDAOExtand
		Dim AuditDetailDAO As New Portal_AuditDetailDAOExtand

		Enum SequenceType
			before = 1
			after = 2
		End Enum

		Enum LevelType
			debug = 1
			info = 2
		End Enum

		Enum ActionType
			insert = 1
			update = 2
			delete = 3
		End Enum

		Enum SubscriptionState
			Disable = 0
			Enable = 1
			History = 2
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

			If Not (Request.Params("epaperid") Is Nothing) Then
				epaperID = Request.Params("epaperid")
			End If

			If Not (Request.Params("mid") Is Nothing) Then
				moduleId = Int32.Parse(Request.Params("mid"))
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				LoadPage()
			End If
		End Sub
		Private Sub LoadPage()
			Dim myEPaperDAO As New Portal_EPaperDAOExtand
			Dim myDataSet As DataSet
			Dim myPath As String = Request.PhysicalApplicationPath + "DesktopModules\EPaper\ContentFile\"
			Dim myFileName As String = ""
			If epaperID.Length > 0 Then
				myDataSet = myEPaperDAO.GetEntitys(epaperID)
			Else
				'exception
			End If

			If myDataSet.Tables(0).Rows.Count = 1 Then
				TextBoxTitle.Text = CType(myDataSet.Tables(0).Rows(0).Item("Title"), String)
				TextBoxDescription.Text = CType(myDataSet.Tables(0).Rows(0).Item("Description"), String)
				myTemplateFile = CType(myDataSet.Tables(0).Rows(0).Item("TemplateFile"), String)
				myCSSFile = CType(myDataSet.Tables(0).Rows(0).Item("CSSFile"), String)
				myFileName = CType(myDataSet.Tables(0).Rows(0).Item("ContentFile"), String)
				'load content file
				'exam if file exists
				If File.Exists(myPath + myFileName) Then
					' Open the stream and read it back.
					Dim sr As StreamReader = File.OpenText(myPath + myFileName)
					Do While sr.Peek() >= 0
						myContentFile = myContentFile + sr.ReadLine()
					Loop
					sr.Close()
				Else
					'exception
				End If
			Else
				'exception
			End If

		End Sub
		Private Sub SaveForm()
			Dim myEPaperDAO As New Portal_EPaperDAOExtand
			Dim myEPaperDataSet As DataSet
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim user As String = ""
			Dim myPath As String = Request.PhysicalApplicationPath + "DesktopModules\EPaper\ContentFile\"
			Dim myFileName As String = ""
			Dim myContentFile As String = ""
			Dim myAuditID As String = ""
			'setup user
			user = Context.User.Identity.Name
			'
			myTitle = TextBoxTitle.Text.Trim
			myDescription = TextBoxDescription.Text.Trim
			myContentFile = Request.Params("ContentFile").Trim
			'update epaper
			If epaperID.Length > 0 Then
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myEPaperDAO.ToString, "UpdateEntity", epaperID, "", Context.User.Identity.Name, Now)
				'log before action
				myEPaperDataSet = myEPaperDAO.GetEntitys(epaperID)
				If myEPaperDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, myEPaperDataSet)
				End If
				'actual action
				myEPaperDAO.UpdateEntity(epaperID, myTitle, myDescription)
				'log after action
				myEPaperDataSet = myEPaperDAO.GetEntitys(epaperID)
				If myEPaperDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myEPaperDataSet)
				End If
				myEPaperDataSet = myEPaperDAO.GetEntitys(epaperID)
				If myEPaperDataSet.Tables(0).Rows.Count = 1 Then
					myFileName = CType(myEPaperDataSet.Tables(0).Rows(0).Item("ContentFile"), String)
				Else
					'exception
				End If

				'save content file
				'exam if file exists
				If File.Exists(myPath + myFileName) Then
					File.Delete(myPath + myFileName)
					'audit
					AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myPath + myFileName, "", Context.User.Identity.Name, Now)
				End If

				'create file
				Dim fs As FileStream = File.Create(myPath + myFileName, 1024)
				'audit
				AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, "System.IO.File", "Create", myPath + myFileName, "", Context.User.Identity.Name, Now)
				Dim info As Byte() = New UTF8Encoding(True).GetBytes(myContentFile)

				' Add some information to the file.
				fs.Write(info, 0, info.Length)
				fs.Close()
			Else
				'exception
			End If
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			If Page.IsValid Then
				SaveForm()
				Response.Redirect(CType(ViewState("UrlReferrer"), String))
			End If
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
		Private Sub AuditDetail(ByVal myAuditID As String, ByVal mySequenceType As Integer, ByVal myDataSet As DataSet)
			Dim myColumnName As String = ""
			Dim myColumnValue As String = ""
			Dim i As Integer = 0
			If myAuditID.Trim.Length > 0 Then
				If Not (myDataSet Is Nothing) Then
					If myDataSet.Tables(0).Rows.Count = 1 Then
						For i = 0 To myDataSet.Tables(0).Columns.Count - 1
							myColumnName = myDataSet.Tables(0).Columns(i).ColumnName
							myColumnValue = CType(myDataSet.Tables(0).Rows(0).Item(myColumnName), String)
							AuditDetailDAO.InsertEntity(myAuditID, 0, mySequenceType, myColumnName, myColumnValue)
						Next
					Else
						'exception:audit target is empty or duplicated
					End If
				End If
			End If
		End Sub
	End Class

End Namespace