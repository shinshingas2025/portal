Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class BulletinUpdate
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents DropDownListDisplayOrder As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxAnnounceUnit As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxEnableDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents CalendarEnableDate As System.Web.UI.WebControls.Calendar
		Protected WithEvents TextboxDisableDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents CalendarDisableDate As System.Web.UI.WebControls.Calendar
		Protected WithEvents LinkButtonEnableDate As System.Web.UI.WebControls.LinkButton
		Protected WithEvents LinkButtonDisableDate As System.Web.UI.WebControls.LinkButton
		Protected WithEvents RadioButtonTypeIndividual As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonTypeCommunity As System.Web.UI.WebControls.RadioButton
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected WithEvents RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
		Protected WithEvents Label9 As System.Web.UI.WebControls.Label
		Protected WithEvents UploadFileName As System.Web.UI.HtmlControls.HtmlInputFile
		Protected WithEvents Label10 As System.Web.UI.WebControls.Label
		Protected WithEvents Label11 As System.Web.UI.WebControls.Label
		Protected WithEvents UploadFile1 As System.Web.UI.HtmlControls.HtmlInputFile
		Protected WithEvents UploadFile2 As System.Web.UI.HtmlControls.HtmlInputFile
		Protected WithEvents UploadFile3 As System.Web.UI.HtmlControls.HtmlInputFile
		Protected WithEvents Label12 As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolder1 As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents Label13 As System.Web.UI.WebControls.Label
		Protected WithEvents Placeholder2 As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents Label14 As System.Web.UI.WebControls.Label
		Protected WithEvents Placeholder3 As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected WithEvents Label19 As System.Web.UI.WebControls.Label
		Protected WithEvents TextboxAffiliatedURL As System.Web.UI.WebControls.TextBox

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
		Private bulletinMapID As String = ""
		Protected pageSize As Integer = 10
		Protected totalBulletinIndividualPage As Integer = 0
		Protected currentBulletinIndividualPage As Integer = 0
		Protected totalBulletinCommunityPage As Integer = 0
		Protected currentBulletinCommunityPage As Integer = 0
		Dim AuditDAO As New Portal_AuditDAOExtand
		Protected uploadFileCount As Integer = 0
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

		Enum BulletinType
			community = 1
			individual = 2
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

			If Not (Request.Params("bulletinmapid") Is Nothing) Then
				bulletinMapID = Request.Params("bulletinmapid").Trim
			End If


            If Not IsPostBack Then
                If Not (Request.UrlReferrer Is Nothing) Then
                    ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
                End If


                UpdatePageLoad()
            End If
		End Sub

		Private Sub UpdatePageSave()
			Dim myBulletinMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinAppendDAO As New Portal_BulletinAppendDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myBulletinMapPartDataSet As DataSet
			Dim myBulletinMapTempDataSet As DataSet
			Dim myBulletinDataSet As DataSet
			Dim myBulletinPartDataSet As DataSet
			Dim myBulletinAppendDataSet As DataSet
			Dim myBulletinAppendPartDataSet As DataSet
			Dim myBulletinID As String = ""
			Dim myBulletinMapPartID As String = ""
			Dim rowCount As Integer = 0
			Dim myItemID As Integer = 0
			Dim myTypeID As Integer = BulletinType.individual
			Dim myOldTypeID As Integer = 0
			Dim myListItem As ListItem
			Dim myDisplayOrder As Integer = 0
			Dim myTitle As String = ""
			Dim myCreatedDate As Date = Now
			Dim myDescription As String = ""
			Dim myAnnounceUnit As String = ""
			Dim myEnableDate As Date = Now
			Dim myDisableDate As Date = Now
			Dim myAffiliatedURL As String = ""
			Dim i As Integer = 0
			Dim dk As String = ""
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myBulletinUser As String = ""
			Dim myBulletinMapUser As String = ""
			Dim myBulletinModuleID As Integer = 0
			Dim myBulletinMapModuleID As Integer = 0
			Dim myBulletinAppendID As String = ""
			Dim up_path As String = Server.MapPath("/PortalFiles/UpLoadFiles/BulletinAppend")
			Dim identityKey As String = Now.Year & Microsoft.VisualBasic.Right("00" & Now.Month, 2) & Microsoft.VisualBasic.Right("00" & Now.Day, 2) & Microsoft.VisualBasic.Right("00" & Now.Hour, 2) & Microsoft.VisualBasic.Right("00" & Now.Minute, 2) & Microsoft.VisualBasic.Right("00" & Now.Second, 2) & Microsoft.VisualBasic.Right("000" & Now.Millisecond, 3) & Microsoft.VisualBasic.Right("00000" & sid, 5) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(moduleId)), 8)
			Dim myUploadFileName1 As String = ""
			Dim myUploadFileName2 As String = ""
			Dim myUploadFileName3 As String = ""
			Dim myPhysicalFileName As String = ""
			Dim oldPhysicalFileName As String = ""
			Dim myPhysicalFileName1 As String = ""
			Dim myPhysicalFileName2 As String = ""
			Dim myPhysicalFileName3 As String = ""
			Dim myFile1 As HttpPostedFile = UploadFile1.PostedFile
			Dim myFile2 As HttpPostedFile = UploadFile2.PostedFile
			Dim myFile3 As HttpPostedFile = UploadFile3.PostedFile
			Dim writer As StreamWriter
			Dim myAuditID As String = ""

			If RadioButtonTypeCommunity.Checked Then
				myTypeID = BulletinType.community
			End If
			myDisplayOrder = CType(DropDownListDisplayOrder.SelectedValue, Integer)
			myTitle = TextBoxTitle.Text.Trim
			myDescription = TextBoxDescription.Text.Trim
			myAnnounceUnit = TextBoxAnnounceUnit.Text.Trim
			If TextBoxEnableDate.Text.Trim <> "" Then
				tempString = TextBoxEnableDate.Text.Trim
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 3 Then
					myEnableDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				End If
			End If
			If TextboxDisableDate.Text.Trim <> "" Then
				tempString = TextboxDisableDate.Text.Trim
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 3 Then
					myDisableDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				End If
			End If
			If TextboxAffiliatedURL.Text.Trim <> "" Then
				myAffiliatedURL = TextboxAffiliatedURL.Text.Trim
			End If
			'read upload file 1 2 3
			If Not (myFile1 Is Nothing) Then
				myUploadFileName1 = myFile1.FileName
				If myUploadFileName1.Trim.Length > 0 Then
					myPhysicalFileName1 = up_path & "/" & identityKey & Path.GetFileName(myUploadFileName1)
					'clear old file
					If File.Exists(myPhysicalFileName1) Then
						File.Delete(myPhysicalFileName1)
						'audit
						AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myPhysicalFileName1, "", Context.User.Identity.Name, Now)
					End If
					'save import file
					myFile1.SaveAs(myPhysicalFileName1)
					'audit
					AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myFile1.ToString, "SaveAs", myPhysicalFileName1, "", Context.User.Identity.Name, Now)
				End If
			End If
			If Not (myFile2 Is Nothing) Then
				myUploadFileName2 = myFile2.FileName
				If myUploadFileName2.Trim.Length > 0 Then
					myPhysicalFileName2 = up_path & "/" & identityKey & Path.GetFileName(myUploadFileName2)
					'clear old file
					If File.Exists(myPhysicalFileName2) Then
						File.Delete(myPhysicalFileName2)
						'audit
						AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myPhysicalFileName2, "", Context.User.Identity.Name, Now)
					End If
					'save import file
					myFile2.SaveAs(myPhysicalFileName2)
					'audit
					AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myFile2.ToString, "SaveAs", myPhysicalFileName2, "", Context.User.Identity.Name, Now)
				End If
			End If
			If Not (myFile3 Is Nothing) Then
				myUploadFileName3 = myFile3.FileName
				If myUploadFileName3.Trim.Length > 0 Then
					myPhysicalFileName3 = up_path & "/" & identityKey & Path.GetFileName(myUploadFileName3)
					'clear old file
					If File.Exists(myPhysicalFileName3) Then
						File.Delete(myPhysicalFileName3)
						'audit
						AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myPhysicalFileName3, "", Context.User.Identity.Name, Now)
					End If
					'save import file
					myFile3.SaveAs(myPhysicalFileName3)
					'audit
					AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myFile3.ToString, "SaveAs", myPhysicalFileName3, "", Context.User.Identity.Name, Now)
				End If
			End If

			If bulletinMapID.Length > 0 Then
				'update
				myBulletinMapDataSet = myBulletinMapDAO.GetEntity(bulletinMapID)
				If myBulletinMapDataSet.Tables(0).Rows.Count = 1 Then
					'keep bulletin map record
					myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("BulletinID"), String).Trim
					myBulletinMapUser = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
					myBulletinMapModuleID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
					myItemID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
					myCreatedDate = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("CreatedDate"), Date)
					If myBulletinID.Length > 0 Then
						myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
						If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
							myOldTypeID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("TypeID"), Integer)
							myBulletinUser = CType(myBulletinDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
							myBulletinModuleID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
							'audit
							myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myBulletinDAO.ToString, "UpdateEntity", myBulletinID, "", Context.User.Identity.Name, Now)
							'log before action
							AuditDetail(myAuditID, SequenceType.before, myBulletinDataSet)
							'actual action
							'update bulletin
							myBulletinDAO.UpdateEntity(myBulletinID, myTypeID, myTitle, myDescription, "", myEnableDate, myDisableDate, myAnnounceUnit, myAffiliatedURL)
							'log after action
							myBulletinPartDataSet = myBulletinDAO.GetEntity(myBulletinID)
							If myBulletinPartDataSet.Tables(0).Rows.Count = 1 Then
								AuditDetail(myAuditID, SequenceType.after, myBulletinPartDataSet)
							End If

							'check ownership and bulletin type
							If ((myBulletinMapModuleID = myBulletinModuleID) And (myTypeID = BulletinType.individual) And (myOldTypeID = BulletinType.community)) Then
								myBulletinMapPartDataSet = myBulletinMapDAO.GetEntityByBulletinID(myBulletinID)
								'delete old bulletin map record
								If myBulletinMapPartDataSet.Tables(0).Rows.Count > 0 Then
									For i = 0 To myBulletinMapPartDataSet.Tables(0).Rows.Count - 1
										myBulletinMapPartID = CType(myBulletinMapPartDataSet.Tables(0).Rows(i).Item("EntityID"), String)
										'audit
										myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myBulletinMapDAO.ToString, "DeleteEntity", myBulletinMapPartID, "", Context.User.Identity.Name, Now)
										'log before action
										myBulletinMapTempDataSet = myBulletinMapDAO.GetEntity(myBulletinMapPartID)
										If myBulletinMapTempDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.before, myBulletinMapTempDataSet)
										End If
										'actual action
										myBulletinMapDAO.DeleteEntity(myBulletinMapPartID)
										'log after action
										myBulletinMapTempDataSet = myBulletinMapDAO.GetEntity(myBulletinMapPartID)
										If myBulletinMapTempDataSet.Tables(0).Rows.Count = 1 Then
											AuditDetail(myAuditID, SequenceType.after, myBulletinMapTempDataSet)
										End If
									Next
								End If
								'insert new bulletin map
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinMapDAO.ToString, "InsertEntity", bulletinMapID, "", Context.User.Identity.Name, Now)
								'log before action
								myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(bulletinMapID)
								If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.before, myBulletinMapPartDataSet)
								End If
								'actual action
								myBulletinMapDAO.InsertEntity(bulletinMapID, sid, moduleId, myItemID, myBulletinID, myDisplayOrder, myBulletinMapUser, myCreatedDate)
								'log after action
								myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(bulletinMapID)
								If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinMapPartDataSet)
								End If
							Else
								'update bulletin map
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myBulletinMapDAO.ToString, "UpdateEntity", bulletinMapID, "", Context.User.Identity.Name, Now)
								'log before action
								myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(bulletinMapID)
								If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.before, myBulletinMapPartDataSet)
								End If
								'actual action
								myBulletinMapDAO.UpdateEntity(bulletinMapID, myDisplayOrder)
								'log after action
								myBulletinMapPartDataSet = myBulletinMapDAO.GetEntity(bulletinMapID)
								If myBulletinMapPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinMapPartDataSet)
								End If
							End If
						Else
							'exception:bulletin record is empty or duplicated
						End If
						'update append file
						'delete old file
						'If myBulletinAppendDataSet.Tables(0).Rows.Count > 0 Then
						'	For i = 0 To myBulletinAppendDataSet.Tables(0).Rows.Count - 1
						'		myPhysicalFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(i).Item("FileName"), String)
						'		myBulletinAppendID = CType(myBulletinAppendDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						'		If myPhysicalFileName.Trim.Length > 0 Then
						'			If File.Exists(myPhysicalFileName) Then
						'				File.Delete(myPhysicalFileName)
						'				'audit
						'				AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", myPhysicalFileName, "", Context.User.Identity.Name, Now)
						'			End If
						'		End If
						'		'delete append record
						'		myBulletinAppendDAO.DeleteEntity(myBulletinAppendID)
						'		'audit
						'		AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myBulletinAppendDAO.ToString, "DeleteEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
						'	Next
						'End If
						'save append record
						myBulletinAppendDataSet = myBulletinAppendDAO.GetEntitys(myBulletinID)
						'insert bulletin append file 1
						If myUploadFileName1.Trim.Length > 0 Then
							If myBulletinAppendDataSet.Tables(0).Rows.Count > 0 Then
								myBulletinAppendID = CType(myBulletinAppendDataSet.Tables(0).Rows(0).Item("EntityID"), String)
								oldPhysicalFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(0).Item("FileName"), String)
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myBulletinAppendDAO.ToString, "UpdateEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
								'log before action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.before, myBulletinAppendPartDataSet)
								End If
								'actual action
								myBulletinAppendDAO.UpdateEntity(myBulletinAppendID, Path.GetFileName(myUploadFileName1), "", myPhysicalFileName1)
								'log after action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
								End If
								If File.Exists(oldPhysicalFileName) Then
									File.Delete(oldPhysicalFileName)
									'audit
									AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", oldPhysicalFileName, "", Context.User.Identity.Name, Now)
								End If
							Else
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinAppendDAO.ToString, "InsertEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
								'log before action
								'none
								'actual action
								myBulletinAppendID = myBulletinAppendDAO.InsertEntity(myBulletinID, 0, Path.GetFileName(myUploadFileName1), "", myPhysicalFileName1, Context.User.Identity.Name, Now)
								'log after action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
								End If
							End If
						End If
						'insert bulletin append file 2
						If myUploadFileName2.Trim.Length > 0 Then
							If myBulletinAppendDataSet.Tables(0).Rows.Count > 1 Then
								myBulletinAppendID = CType(myBulletinAppendDataSet.Tables(0).Rows(1).Item("EntityID"), String)
								oldPhysicalFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(1).Item("FileName"), String)
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myBulletinAppendDAO.ToString, "UpdateEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
								'log before action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.before, myBulletinAppendPartDataSet)
								End If
								'actual action
								myBulletinAppendDAO.UpdateEntity(myBulletinAppendID, Path.GetFileName(myUploadFileName2), "", myPhysicalFileName1)
								'log after action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
								End If
								If File.Exists(oldPhysicalFileName) Then
									File.Delete(oldPhysicalFileName)
									'audit
									AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", oldPhysicalFileName, "", Context.User.Identity.Name, Now)
								End If
							Else
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinAppendDAO.ToString, "InsertEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
								'log before action
								'none
								'actual action
								myBulletinAppendID = myBulletinAppendDAO.InsertEntity(myBulletinID, 0, Path.GetFileName(myUploadFileName2), "", myPhysicalFileName2, Context.User.Identity.Name, Now)
								'log after action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
								End If
							End If
						End If
						'insert bulletin append file 3
						If myUploadFileName3.Trim.Length > 0 Then
							If myBulletinAppendDataSet.Tables(0).Rows.Count > 1 Then
								myBulletinAppendID = CType(myBulletinAppendDataSet.Tables(0).Rows(2).Item("EntityID"), String)
								oldPhysicalFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(2).Item("FileName"), String)
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.update, Me.ToString, myBulletinAppendDAO.ToString, "UpdateEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
								'log before action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.before, myBulletinAppendPartDataSet)
								End If
								'actual action
								myBulletinAppendDAO.UpdateEntity(myBulletinAppendID, Path.GetFileName(myUploadFileName3), "", myPhysicalFileName1)
								'log after action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
								End If
								If File.Exists(oldPhysicalFileName) Then
									File.Delete(oldPhysicalFileName)
									'audit
									AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", oldPhysicalFileName, "", Context.User.Identity.Name, Now)
								End If
							Else
								'audit
								myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinAppendDAO.ToString, "InsertEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
								'log before action
								'none
								'actual action
								myBulletinAppendID = myBulletinAppendDAO.InsertEntity(myBulletinID, 0, Path.GetFileName(myUploadFileName3), "", myPhysicalFileName3, Context.User.Identity.Name, Now)
								'log after action
								myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
								If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
									AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
								End If
							End If
						End If
					Else
						'exception:bulletin id is empty
					End If
				Else
					'exception:bulletin map is empty or duplicated
				End If
			Else
				'insert bulletin
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinDAO.ToString, "InsertEntity", myBulletinID, "", Context.User.Identity.Name, Now)
				'log before action
				'none
				'actual action
				myBulletinID = myBulletinDAO.InsertEntity(sid, moduleId, 0, myTypeID, myTitle, myDescription, "", myEnableDate, myDisableDate, myAnnounceUnit, Context.User.Identity.Name, Now, myAffiliatedURL)
				'log after action
				myBulletinPartDataSet = myBulletinDAO.GetEntity(myBulletinID)
				If myBulletinPartDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, myBulletinPartDataSet)
				End If
				If myBulletinID.Length > 0 Then
					'insert bulletin map
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinMapDAO.ToString, "InsertEntity", dk, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					dk = myBulletinMapDAO.InsertEntity(sid, moduleId, 0, myBulletinID, myDisplayOrder, Context.User.Identity.Name, Now)
					'log after action
					myBulletinMapDataSet = myBulletinMapDAO.GetEntity(dk)
					If myBulletinMapDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, myBulletinMapDataSet)
					End If
					'insert bulletin append file 1
					If myPhysicalFileName1.Trim.Length > 0 Then
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinAppendDAO.ToString, "InsertEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
						'log before action
						'none
						'actual action
						myBulletinAppendID = myBulletinAppendDAO.InsertEntity(myBulletinID, 0, Path.GetFileName(myUploadFileName1), "", myPhysicalFileName1, Context.User.Identity.Name, Now)
						'log after action
						myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
						If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
						End If
					End If
					'insert bulletin append file 2
					If myPhysicalFileName2.Trim.Length > 0 Then
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinAppendDAO.ToString, "InsertEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
						'log before action
						'none
						'actual action
						myBulletinAppendID = myBulletinAppendDAO.InsertEntity(myBulletinID, 0, Path.GetFileName(myUploadFileName2), "", myPhysicalFileName2, Context.User.Identity.Name, Now)
						'log after action
						myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
						If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
						End If
					End If
					'insert bulletin append file 3
					If myPhysicalFileName3.Trim.Length > 0 Then
						'audit
						myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myBulletinAppendDAO.ToString, "InsertEntity", myBulletinAppendID, "", Context.User.Identity.Name, Now)
						'log before action
						'none
						'actual action
						myBulletinAppendID = myBulletinAppendDAO.InsertEntity(myBulletinID, 0, Path.GetFileName(myUploadFileName3), "", myPhysicalFileName3, Context.User.Identity.Name, Now)
						'log after action
						myBulletinAppendPartDataSet = myBulletinAppendDAO.GetEntity(myBulletinAppendID)
						If myBulletinAppendPartDataSet.Tables(0).Rows.Count = 1 Then
							AuditDetail(myAuditID, SequenceType.after, myBulletinAppendPartDataSet)
						End If
					End If
				Else
					'exception:bulletin insert error
				End If
			End If
		End Sub

		Private Sub UpdatePageLoad()
			Dim myBulletinMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinAppendDAO As New Portal_BulletinAppendDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myBulletinDataSet As DataSet
			Dim myBulletinAppendDataSet As DataSet
			Dim myBulletinID As String = ""
			Dim rowCount As Integer = 0
			Dim myTypeID As Integer = 0
			Dim myListItem As ListItem
			Dim myDisplayOrder As Integer = 0
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myAnnounceUnit As String = ""
			Dim myEnableDate As Date = Now
			Dim myDisableDate As Date = Now
			Dim myAffiliatedURL As String = ""
			Dim myBulletinUser As String = ""
			Dim myBulletinMapUser As String = ""
			Dim myBulletinModuleID As Integer = 0
			Dim myBulletinMapModuleID As Integer = 0
			Dim i As Integer = 0

			'initial web control
			'read total row
			myBulletinMapDataSet = myBulletinMapDAO.GetEntitys(sid, moduleId)
			rowCount = myBulletinMapDataSet.Tables(0).Rows.Count + 1
			'initial object
			RadioButtonTypeIndividual.Checked = True
			RadioButtonTypeCommunity.Checked = False
			DropDownListDisplayOrder.Items.Clear()
			For i = 0 To rowCount - 1
				myListItem = New ListItem(CType(i + 1, String), CType(i + 1, String))
				DropDownListDisplayOrder.Items.Add(myListItem)
			Next
			DropDownListDisplayOrder.SelectedIndex = 0
			TextBoxTitle.Text = ""
            TextBoxDescription.Text = ""

            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            TextBoxAnnounceUnit.Text = _portalSettings.PortalName

			TextBoxEnableDate.Text = ""
			LinkButtonEnableDate.Visible = True
			CalendarEnableDate.Visible = False
			CalendarEnableDate.SelectedDate = Now
			TextboxDisableDate.Text = ""
			LinkButtonDisableDate.Visible = True
			CalendarDisableDate.SelectedDate = Now
			TextboxAffiliatedURL.Text = ""
			'
			If bulletinMapID.Length > 0 Then
				myBulletinMapDataSet = myBulletinMapDAO.GetEntity(bulletinMapID)
				If myBulletinMapDataSet.Tables(0).Rows.Count = 1 Then
					myBulletinMapUser = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
					myBulletinMapModuleID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
					myDisplayOrder = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)
					myListItem = New ListItem(CType(myDisplayOrder, String), CType(myDisplayOrder, String))
					'add my display order option
					If DropDownListDisplayOrder.Items.Contains(myListItem) Then
						DropDownListDisplayOrder.Items.Add(myListItem)
					End If
					DropDownListDisplayOrder.SelectedValue = CType(myDisplayOrder, String)

					myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("BulletinID"), String).Trim
					If myBulletinID.Length > 0 Then
						myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
						If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
							myBulletinUser = CType(myBulletinDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
							myBulletinModuleID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
							myTypeID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("TypeID"), Integer)
							myTitle = CType(myBulletinDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
							myDescription = CType(myBulletinDataSet.Tables(0).Rows(0).Item("Description"), String).Trim
							myAnnounceUnit = CType(myBulletinDataSet.Tables(0).Rows(0).Item("AnnounceUnit"), String).Trim
							myEnableDate = CType(myBulletinDataSet.Tables(0).Rows(0).Item("EnableDate"), Date)
							myDisableDate = CType(myBulletinDataSet.Tables(0).Rows(0).Item("DisableDate"), Date)
							myAffiliatedURL = CType(myBulletinDataSet.Tables(0).Rows(0).Item("AffiliatedURL"), String)

							If myTypeID = BulletinType.individual Then
								RadioButtonTypeIndividual.Checked = True
								RadioButtonTypeCommunity.Checked = False
							Else
								If myTypeID = BulletinType.community Then
									RadioButtonTypeIndividual.Checked = False
									RadioButtonTypeCommunity.Checked = True
								Else
									'exception:unknown bulletin type
								End If
							End If
							TextBoxTitle.Text = myTitle
							TextBoxDescription.Text = myDescription
							TextBoxAnnounceUnit.Text = myAnnounceUnit
							TextBoxEnableDate.Text = myEnableDate.Year & "/" & myEnableDate.Month & "/" & myEnableDate.Day
							CalendarEnableDate.SelectedDate = myEnableDate
							TextboxDisableDate.Text = myDisableDate.Year & "/" & myDisableDate.Month & "/" & myDisableDate.Day
							CalendarDisableDate.SelectedDate = myDisableDate
							TextboxAffiliatedURL.Text = myAffiliatedURL

							'check ownership
							If myBulletinModuleID <> myBulletinMapModuleID Then
								RadioButtonTypeIndividual.Enabled = False
								RadioButtonTypeCommunity.Enabled = False
								TextBoxTitle.Enabled = False
								TextBoxDescription.Enabled = False
								TextBoxAnnounceUnit.Enabled = False
								TextBoxEnableDate.Enabled = False
								LinkButtonEnableDate.Enabled = False
								TextboxDisableDate.Enabled = False
								LinkButtonDisableDate.Enabled = False
								TextboxAffiliatedURL.Enabled = False
								UploadFile1.Visible = False
								UploadFile2.Visible = False
								UploadFile3.Visible = False
							End If
						Else
							'exceptiob:bulletin record is empty or duplicated
						End If
					Else
						'exception:bulletin id is empty
					End If
				Else
					'exception:bulletin map is empty or duplicated
				End If
			Else
			End If
		End Sub

		Private Sub LinkButtonEnableDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonEnableDate.Click
			LinkButtonEnableDate.Visible = False
			CalendarEnableDate.Visible = True
		End Sub

		Private Sub LinkButtonDisableDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonDisableDate.Click
			LinkButtonDisableDate.Visible = False
			CalendarDisableDate.Visible = True
		End Sub

		Private Sub CalendarEnableDate_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalendarEnableDate.SelectionChanged
			TextBoxEnableDate.Text = CalendarEnableDate.SelectedDate.Year & "/" & Microsoft.VisualBasic.Right("00" & CalendarEnableDate.SelectedDate.Month, 2) & "/" & Microsoft.VisualBasic.Right("00" & CalendarEnableDate.SelectedDate.Day, 2)
			LinkButtonEnableDate.Visible = True
			CalendarEnableDate.Visible = False
		End Sub

		Private Sub CalendarDisableDate_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalendarDisableDate.SelectionChanged
			TextboxDisableDate.Text = CalendarDisableDate.SelectedDate.Year & "/" & Microsoft.VisualBasic.Right("00" & CalendarDisableDate.SelectedDate.Month, 2) & "/" & Microsoft.VisualBasic.Right("00" & CalendarDisableDate.SelectedDate.Day, 2)
			LinkButtonDisableDate.Visible = True
			CalendarDisableDate.Visible = False
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			UpdatePageLoad()
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			UpdatePageSave()
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