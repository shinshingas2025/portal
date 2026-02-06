Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class ResolutionAdminFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonNext As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxName As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonEntityInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonEntityUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonEntityDelete As System.Web.UI.WebControls.Button
		Protected WithEvents TextboxConstitutionDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListDiscussion As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListParent As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListVariationType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListConstitutionInstitution As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListUndertakerInstitution As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxDocumentNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxResolutionNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxContent As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxNote As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxMainUnit As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxForecastDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListAuditState As System.Web.UI.WebControls.DropDownList
		Protected WithEvents CheckBoxFinish As System.Web.UI.WebControls.CheckBox
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonEventSave As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonAuditSave As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonAuditDelete As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonOfficeInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonOfficeUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonOfficeDelete As System.Web.UI.WebControls.Button
		Protected WithEvents DropDownListEventType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListMiddleType As System.Web.UI.WebControls.DropDownList
		Protected WithEvents ListBoxEventOption As System.Web.UI.WebControls.ListBox
		Protected WithEvents ImageButtonEventInsert As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ImageButtonEventDelete As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ListboxEvent As System.Web.UI.WebControls.ListBox
		Protected WithEvents AjaxPanelEvent As MagicAjax.UI.Controls.AjaxPanel
		Protected WithEvents DropDownListAuditOption As System.Web.UI.WebControls.DropDownList
		Protected WithEvents CheckBoxAutoIncrease1 As System.Web.UI.WebControls.CheckBox
		Protected WithEvents TextBoxAuditValue As System.Web.UI.WebControls.TextBox
		Protected WithEvents CheckBoxAutoIncrease2 As System.Web.UI.WebControls.CheckBox
		Protected WithEvents ImageButtonAuditInsert As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ImageButtonAuditDelete As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ListBoxAudit As System.Web.UI.WebControls.ListBox
		Protected WithEvents AjaxpanelAudit As MagicAjax.UI.Controls.AjaxPanel
		Protected WithEvents ButtonOfficeSave As System.Web.UI.WebControls.Button
		Protected WithEvents ListBoxOfficeOption As System.Web.UI.WebControls.ListBox
		Protected WithEvents ImageButtonOfficeInsert As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ImageButtonOfficeDelete As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ListBoxOffice As System.Web.UI.WebControls.ListBox
		Protected WithEvents AjaxpanelOffice As MagicAjax.UI.Controls.AjaxPanel
		Protected WithEvents chkNotify As System.Web.UI.WebControls.CheckBox

		'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
		'請勿刪除或移動它。
		Private designerPlaceholderDeclaration As System.Object

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
			'請勿使用程式碼編輯器進行修改。
			InitializeComponent()
		End Sub

#End Region

		Private Const DefaultPermission As String = "111100100"
		Private Const DefaultPermissionGroup As String = "000000000"
		Private Const ResolutionAuthorityTarget As String = "Resolution"
		Private Const EventAuthorityTarget As String = "EventResolutionMap"
		Private Const AuditMapAuthorityTarget As String = "ResolutionAuditMap"
		Private Const AuditCodeAuthorityTarget As String = "ResolutionAuditCode"
		Private Const RecordAuthorityTarget As String = "MeetingRecord"
		Private Const FormAuthorityTarget As String = "AffairProcessCheckForm"
		Private Const CodeAuthorityTarget As String = "NormalCode"
		Private UtilityObject As New AuditSystemUtility

		Private tabIndex As Integer = 0
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Private resolutionID As String = ""
		Private Const AuditStateCodeGroupID As String = "2006010100000008"
		Private Const EventTypeCodeGroupID As String = "2006010100000028"
		Private Const MeetingRecordTypeCodeGroupID As String = "2006010100000009"
		Private Const DefaultMeetingRecordTypeID As String = "200601010000000900000001"
		Private Const DefaultAuditCodeID As String = "2006010100000001"
		Private Const MeetingRecordEventCodeID As String = "200601010000002800000001"
		Private Const MainOfficeCodeGroupID As String = "2006010100000003"
		Private Const ActionColumnWidth As String = "40"
		Private Const ContentNumberColumnWidth As String = "48"
		Private Const ContentColumnWidth As String = "480"
		Private Const ContentOrderColumnWidth As String = "40"
		Protected Const NormalCodeBGColor As String = "#DEDECA"
		Protected Const FocusCodeBGColor As String = "#FFFF99"

		Enum FINISH
			YES = 1
			NO = 0
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

			If Not (Request.Params("resolutionID") Is Nothing) Then
				resolutionID = Request.Params("resolutionID")
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				InitialWebControl()
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
			If resolutionID.Trim.Length > 0 Then
				FillResolutionData(resolutionID)
			Else
				'exception:resolution id is empty
			End If
		End Sub
		Private Sub FillResolutionData(ByVal myResolutionID As String)
			Dim myResolutionDAO As New ResolutionDAOExtand
			Dim myResolutionDataSet As DataSet
			Dim myResolutionNumber As String = ""
			Dim myContent As String = ""
			Dim myNote As String = ""
			Dim myMainUnit As String = ""
			Dim myForecastDate As Date = New Date(1900, 1, 1)
			Dim myAuditStateID As String = ""
			Dim myFinishID As Integer = 0

			If myResolutionID.Trim.Length > 0 Then
				myResolutionDataSet = myResolutionDAO.GetEntitysByEntityID(myResolutionID)
				myResolutionDataSet = UtilityObject.QueryPermissionFilter(myResolutionDataSet, ResolutionAuthorityTarget, Context.User.Identity.Name)
				If myResolutionDataSet.Tables(0).Rows.Count > 0 Then
					myResolutionNumber = CType(myResolutionDataSet.Tables(0).Rows(0).Item("ResolutionNumber"), String).Trim
					myContent = CType(myResolutionDataSet.Tables(0).Rows(0).Item("Content"), String).Trim
					myNote = CType(myResolutionDataSet.Tables(0).Rows(0).Item("Note"), String).Trim
					myMainUnit = CType(myResolutionDataSet.Tables(0).Rows(0).Item("MainUnit"), String).Trim
					myForecastDate = CType(myResolutionDataSet.Tables(0).Rows(0).Item("ForecastDate"), Date)
					myAuditStateID = CType(myResolutionDataSet.Tables(0).Rows(0).Item("AuditStateID"), String).Trim
					myFinishID = CType(myResolutionDataSet.Tables(0).Rows(0).Item("FinishID"), Integer)

					TextBoxResolutionNumber.Text = myResolutionNumber
					TextBoxContent.Text = myContent
					TextBoxMainUnit.Text = myMainUnit
					TextBoxForecastDate.Text = CType(myForecastDate.Year, String) & "/" & CType(myForecastDate.Month, String) & "/" & CType(myForecastDate.Day, String)
					If TextBoxForecastDate.Text = "1900/1/1" Then
						TextBoxForecastDate.Text = ""
					End If
					Try
						DropDownListAuditState.SelectedValue = myAuditStateID
					Catch ex As Exception
						'no match
					End Try
					If myFinishID = FINISH.YES Then
						CheckBoxFinish.Checked = True
					Else
						CheckBoxFinish.Checked = False
					End If
				End If

				FillEventData(myResolutionID)
				FillAuditData(myResolutionID)
				FillOfficeData(myResolutionID)
			Else
				'exception:resolution id is empty
			End If
		End Sub
		Private Function GetResolutionNumber() As String
			Dim myResolutionNumber As String = ""
			Dim result As String = ""
			Dim today As Date = Now
			Dim myResolutionNumberDAO As New ResolutionDAOExtand

			myResolutionNumber = TextBoxResolutionNumber.Text.Trim
			If CheckBoxAutoIncrease1.Checked = True Then
				myResolutionNumber = Microsoft.VisualBasic.Right("0000" & CStr(today.Year), 4) & Microsoft.VisualBasic.Right("00" & CStr(today.Month), 2) & Microsoft.VisualBasic.Right("00" & CStr(today.Day), 2) & Microsoft.VisualBasic.Right("00" & CStr(today.Hour), 2) & Microsoft.VisualBasic.Right("00" & CStr(today.Minute), 2) & Microsoft.VisualBasic.Right("00" & CStr(today.Second), 2) & "00"
				result = myResolutionNumberDAO.GetMaxResolutionNumber(myResolutionNumber)
			Else
				'return user input
				Return myResolutionNumber
			End If
			Return result
		End Function
		Private Function SaveResolutionData(ByVal myResolutionID As String) As String
			Dim myResolutionDAO As New ResolutionDAOExtand
			Dim myResolutionDataSet As DataSet
			Dim myResolutionNumber As String = ""
			Dim myContent As String = ""
			Dim myNote As String = ""
			Dim myMainUnit As String = ""
			Dim myForecastDate As Date = New Date(1900, 1, 1)
			Dim myAuditStateID As String = ""
			Dim myFinishID As Integer = 0
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myAuthorityBO As New ContextAuthBO

			myResolutionNumber = TextBoxResolutionNumber.Text.Trim
			myContent = TextBoxContent.Text.Trim
			myNote = TextBoxNote.Text.Trim
			myMainUnit = TextBoxMainUnit.Text.Trim
			myAuditStateID = DropDownListAuditState.SelectedValue
			If TextBoxForecastDate.Text.Trim <> "" Then
				tempString = TextBoxForecastDate.Text.Trim
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 3 Then
					myForecastDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				End If
			End If
			If CheckBoxFinish.Checked = True Then
				myFinishID = FINISH.YES
			Else
				myFinishID = FINISH.NO
			End If

			If myResolutionID.Trim.Length > 0 Then
				'update
				myResolutionDataSet = myResolutionDAO.GetEntitysByEntityID(myResolutionID)
				If myResolutionDataSet.Tables(0).Rows.Count = 1 Then
					'get authority
					If myAuthorityBO.CheckPurview(ResolutionAuthorityTarget, myResolutionID, Context.User.Identity.Name, "U") Then
						myResolutionDAO.UpdateEntity(myResolutionID, myResolutionNumber, myContent, myMainUnit, myAuditStateID, myForecastDate, myFinishID, myNote, Context.User.Identity.Name, Now)
					End If
				Else
					'exception:resolution record is empty or duplicated
				End If
			Else
				'insert
				myResolutionNumber = GetResolutionNumber()
				myResolutionID = myResolutionDAO.InsertEntity(0, myResolutionNumber, myContent, myMainUnit, myAuditStateID, myForecastDate, myFinishID, myNote, DefaultPermission, DefaultPermissionGroup, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
			End If
			Return myResolutionID
		End Function
		Private Function DeleteResolutionData(ByVal myResolutionID As String) As Integer
			Dim myResolutionDAO As New ResolutionDAOExtand
			Dim myResolutionDataSet As DataSet
			Dim myAuthorityBO As New ContextAuthBO
			Dim result As Integer = 0

			If myResolutionID.Trim.Length > 0 Then
				myResolutionDataSet = myResolutionDAO.GetEntitysByEntityID(myResolutionID)
				If myResolutionDataSet.Tables(0).Rows.Count = 1 Then
					'get authority
					If myAuthorityBO.CheckPurview(ResolutionAuthorityTarget, myResolutionID, Context.User.Identity.Name, "D") Then
						'event
						DeleteEventData(myResolutionID)
						'audit
						DeleteAuditData(myResolutionID)
						'office
						DeleteOfficeData(myResolutionID)

						result = myResolutionDAO.DeleteEntity(myResolutionID)
					End If
				Else
					'exception:resolution record is empty or duplicated
				End If
			Else
				'exception:resolution id is empty
			End If
			Return result
		End Function
		Private Sub FillEventData(ByVal myResolutionID As String)
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myRecordNumber As Integer = 1
			Dim myRecordTitle As String = ""
			Dim myRecordTypeID As String = ""
			Dim myRecordType As String = ""
			Dim myEventDAO As New EventResolutionMapDAOExtand
			Dim myEventDataSet As DataSet
			Dim myEventCount As Integer = 0
			Dim myEventEntityID As String = ""
			Dim myEventID As String = ""
			Dim myEventValue As String = ""
			Dim i As Integer = 0
			Dim myListItem As ListItem

			If myResolutionID.Trim.Length > 0 Then
				ListboxEvent.Items.Clear()
				myEventDataSet = myEventDAO.GetEntitysByResolutionID(myResolutionID)
				myEventDataSet = UtilityObject.QueryPermissionFilter(myEventDataSet, EventAuthorityTarget, Context.User.Identity.Name)
				myEventCount = myEventDataSet.Tables(0).Rows.Count
				If myEventCount > 0 Then
					For i = 0 To myEventCount - 1
						myEventID = CType(myEventDataSet.Tables(0).Rows(i).Item("EventID"), String).Trim
						myEventValue = CType(myEventDataSet.Tables(0).Rows(i).Item("EventValue"), String).Trim

						If myEventID = MeetingRecordEventCodeID Then
							myRecordDataSet = myRecordDAO.GetEntitysByEntityID(myEventValue)
							If myRecordDataSet.Tables(0).Rows.Count = 1 Then
								myRecordTypeID = CType(myRecordDataSet.Tables(0).Rows(0).Item("TypeID"), String).Trim
								myRecordNumber = CType(myRecordDataSet.Tables(0).Rows(0).Item("MeetingNumber"), Integer)
								myRecordTitle = CType(myRecordDataSet.Tables(0).Rows(0).Item("Title"), String).Trim

								myRecordType = myNormalCodeDAO.GetNameByEntityID(myRecordTypeID)

								myListItem = New ListItem
								myListItem.Value = myEventID & "," & myEventValue
								myListItem.Text = "第" & CType(myRecordNumber, String) & "次" & myRecordType & "：" & myRecordTitle

								ListboxEvent.Items.Add(myListItem)
							Else
								'exception:record is empty or duplicated
							End If
						Else
							'exception:unknown event type
						End If
					Next
				End If
			Else
				'exception:resolution id is empty
			End If
		End Sub
		Private Sub FillAuditData(ByVal myResolutionID As String)
			Dim myAuditMapDAO As New ResolutionAuditMapDAOExtand
			Dim myAuditMapDataSet As DataSet
			Dim myAuditMapCount As Integer = 0
			Dim myAuditMapID As String = ""
			Dim myAuditID As String = ""
			Dim myAuditName As String = ""
			Dim myAuditValue As String = ""
			Dim myAuditCodeDAO As New ResolutionAuditCodeDAOExtand
			Dim i As Integer = 0
			Dim myListItem As ListItem

			If myResolutionID.Trim.Length > 0 Then
				ListBoxAudit.Items.Clear()
				myAuditMapDataSet = myAuditMapDAO.GetEntitysByResolutionID(myResolutionID)
				myAuditMapDataSet = UtilityObject.QueryPermissionFilter(myAuditMapDataSet, AuditMapAuthorityTarget, Context.User.Identity.Name)
				myAuditMapCount = myAuditMapDataSet.Tables(0).Rows.Count
				If myAuditMapCount > 0 Then
					For i = 0 To myAuditMapCount - 1
						myAuditID = CType(myAuditMapDataSet.Tables(0).Rows(i).Item("AuditID"), String).Trim
						myAuditValue = CType(myAuditMapDataSet.Tables(0).Rows(i).Item("AuditValue"), String).Trim

						myAuditName = myAuditCodeDAO.GetNameByEntityID(myAuditID)

						myListItem = New ListItem
						myListItem.Value = myAuditID & "," & myAuditValue
						myListItem.Text = myAuditName & myAuditValue

						ListBoxAudit.Items.Add(myListItem)
					Next
				End If
			Else
				'exception:resolution id is empty
			End If
		End Sub
		Private Sub FillOfficeData(ByVal myResolutionID As String)
			Dim myFormDAO As New AffairProcessCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myFormCount As Integer = 0
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim myOfficeID As String = ""
			Dim myOfficeName As String = ""

			If myResolutionID.Trim.Length > 0 Then
				ListBoxOffice.Items.Clear()
				myFormDataSet = myFormDAO.GetEntitysByResolutionID(myResolutionID)
				myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
				myFormCount = myFormDataSet.Tables(0).Rows.Count
				If myFormCount > 0 Then
					For i = 0 To myFormCount - 1
						myOfficeID = CType(myFormDataSet.Tables(0).Rows(i).Item("GroupID"), String).Trim

						myOfficeName = myNormalCodeDAO.GetNameByEntityID(myOfficeID)

						myListItem = New ListItem
						myListItem.Value = myOfficeID
						myListItem.Text = myOfficeName

						ListBoxOffice.Items.Add(myListItem)
					Next
				End If
			End If
		End Sub
		Private Sub InitialWebControl()
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""

			TextBoxResolutionNumber.Text = ""
			TextBoxContent.Text = ""
			TextBoxNote.Text = ""
			TextBoxMainUnit.Text = ""
			TextBoxForecastDate.Text = ""
			CheckBoxAutoIncrease1.Checked = True
			CheckBoxFinish.Checked = False

			DropDownListAuditState.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(AuditStateCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListAuditState.Items.Add(myListItem)
				Next
			End If

			PrepareEventOption()
			PrepareAuditOption()
			PrepareOfficeOption()
		End Sub
		Private Sub PrepareEventOption()
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myRecordCount As Integer = 0
			Dim myRecordNumber As Integer = 1
			Dim myRecordTitle As String = ""
			Dim myRecordType As String = ""
			Dim myRecordID As String = ""
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""

			'default:MeetingRecordEventCodeID
			DropDownListEventType.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(EventTypeCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListEventType.Items.Add(myListItem)
				Next
			End If
			'default:meeting record type
			DropDownListMiddleType.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(MeetingRecordTypeCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListMiddleType.Items.Add(myListItem)
				Next
			End If
			'default:meeting record list
			ListBoxEventOption.Items.Clear()
			myRecordType = myNormalCodeDAO.GetNameByEntityID(DefaultMeetingRecordTypeID)
			myRecordDataSet = myRecordDAO.GetEntitysByTypeID(DefaultMeetingRecordTypeID)
			myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
			myRecordCount = myRecordDataSet.Tables(0).Rows.Count
			If myRecordCount > 0 Then
				For i = 0 To myRecordCount - 1
					myRecordID = CType(myRecordDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
					myRecordNumber = CType(myRecordDataSet.Tables(0).Rows(i).Item("MeetingNumber"), Integer)
					myRecordTitle = CType(myRecordDataSet.Tables(0).Rows(i).Item("Title"), String).Trim

					myListItem = New ListItem
					myListItem.Value = MeetingRecordEventCodeID & "," & myRecordID
					myListItem.Text = "第" & CType(myRecordNumber, String) & "次" & myRecordType & "：" & myRecordTitle

					ListBoxEventOption.Items.Add(myListItem)
				Next
			End If

		End Sub
		Private Sub PrepareAuditOption()
			Dim myAuditCodeDAO As New ResolutionAuditCodeDAOExtand
			Dim myAuditCodeDataSet As DataSet
			Dim myAuditCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""
			Dim myCodeDescription As String = ""

			DropDownListAuditOption.Items.Clear()
			myAuditCodeDataSet = myAuditCodeDAO.GetEntitys()
			myAuditCodeDataSet = UtilityObject.QueryPermissionFilter(myAuditCodeDataSet, AuditCodeAuthorityTarget, Context.User.Identity.Name)
			myAuditCodeCount = myAuditCodeDataSet.Tables(0).Rows.Count
			If myAuditCodeCount > 0 Then
				For i = 0 To myAuditCodeCount - 1
					myCodeID = CType(myAuditCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
					myCodeName = CType(myAuditCodeDataSet.Tables(0).Rows(i).Item("Name"), String).Trim
					myCodeDescription = CType(myAuditCodeDataSet.Tables(0).Rows(i).Item("Description"), String).Trim

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName & "：" & myCodeDescription

					DropDownListAuditOption.Items.Add(myListItem)
				Next
			End If

			TextBoxAuditValue.Text = GetNextAuditValue(DefaultAuditCodeID)

		End Sub
		Private Sub PrepareOfficeOption()
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""

			'default:meeting record list
			ListBoxOfficeOption.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(MainOfficeCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String).Trim

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					ListBoxOfficeOption.Items.Add(myListItem)
				Next
			End If
		End Sub
		Private Sub ButtonEntityInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEntityInsert.Click
			Dim myResolutionID As String = ""
			myResolutionID = SaveResolutionData(myResolutionID)
			If myResolutionID.Trim.Length > 0 Then
				Response.Redirect("~/DesktopModules/AuditSystem/ResolutionAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&resolutionID=" & myResolutionID)
			Else
				'exception:insert record failure
			End If
		End Sub
		Private Sub ButtonEntityUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEntityUpdate.Click
			Dim myResolutionID As String = ""
			If resolutionID.Trim.Length > 0 Then
				myResolutionID = SaveResolutionData(resolutionID)
				If myResolutionID.Trim.Length > 0 Then
					Response.Redirect("~/DesktopModules/AuditSystem/ResolutionAdminFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&resolutionID=" & myResolutionID)
				Else
					'exception:update record failure
				End If
			Else
				'exception:resolution id is empty
			End If
		End Sub
		Private Sub ButtonEntityDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEntityDelete.Click
			Dim result As Integer = 0
			If resolutionID.Trim.Length > 0 Then
				result = DeleteResolutionData(resolutionID)
				If result = 1 Then
					ButtonReturn_Click(sender, e)
				Else
					'exception:delete record failure
				End If
			Else
				'exception:resolution id is empty
			End If
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect("~/DesktopModules/AuditSystem/ResolutionQueryFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex)
		End Sub

		Protected Sub DropDownListEventType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myRecordCount As Integer = 0
			Dim myRecordNumber As Integer = 1
			Dim myRecordTitle As String = ""
			Dim myRecordType As String = ""
			Dim myRecordID As String = ""
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""
			Dim myEventTypeID As String = ""

			myEventTypeID = DropDownListEventType.SelectedValue
			If myEventTypeID = MeetingRecordEventCodeID Then
				'meeting record event
				DropDownListMiddleType.Items.Clear()
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(MeetingRecordTypeCodeGroupID)
				myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
				myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
				If myNormalCodeCount > 0 Then
					For i = 0 To myNormalCodeCount - 1
						myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

						myListItem = New ListItem
						myListItem.Value = myCodeID
						myListItem.Text = myCodeName

						DropDownListMiddleType.Items.Add(myListItem)
					Next
				End If
				'default:meeting record list
				ListBoxEventOption.Items.Clear()
				myRecordType = myNormalCodeDAO.GetNameByEntityID(DefaultMeetingRecordTypeID)
				myRecordDataSet = myRecordDAO.GetEntitysByTypeID(DefaultMeetingRecordTypeID)
				myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
				myRecordCount = myRecordDataSet.Tables(0).Rows.Count
				If myRecordCount > 0 Then
					For i = 0 To myRecordCount - 1
						myRecordID = CType(myRecordDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
						myRecordNumber = CType(myRecordDataSet.Tables(0).Rows(i).Item("MeetingNumber"), Integer)
						myRecordTitle = CType(myRecordDataSet.Tables(0).Rows(i).Item("Title"), String).Trim

						myListItem = New ListItem
						myListItem.Value = MeetingRecordEventCodeID & "," & myRecordID
						myListItem.Text = "第" & CType(myRecordNumber, String) & "次" & myRecordType & "：" & myRecordTitle

						ListBoxEventOption.Items.Add(myListItem)
					Next
				End If
			Else
				'exception:unknown event type
			End If
		End Sub

		Protected Sub DropDownListMiddleType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim myRecordDAO As New MeetingRecordDAOExtand
			Dim myRecordDataSet As DataSet
			Dim myRecordCount As Integer = 0
			Dim myRecordNumber As Integer = 1
			Dim myRecordTitle As String = ""
			Dim myRecordType As String = ""
			Dim myRecordID As String = ""
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""
			Dim myEventTypeID As String = ""
			Dim myMiddleTypeID As String = ""

			myEventTypeID = DropDownListEventType.SelectedValue
			myMiddleTypeID = DropDownListMiddleType.SelectedValue

			If myEventTypeID = MeetingRecordEventCodeID Then
				'default:meeting record list
				ListBoxEventOption.Items.Clear()
				myRecordType = myNormalCodeDAO.GetNameByEntityID(myMiddleTypeID)
				myRecordDataSet = myRecordDAO.GetEntitysByTypeID(myMiddleTypeID)
				myRecordDataSet = UtilityObject.QueryPermissionFilter(myRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
				myRecordCount = myRecordDataSet.Tables(0).Rows.Count
				If myRecordCount > 0 Then
					For i = 0 To myRecordCount - 1
						myRecordID = CType(myRecordDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
						myRecordNumber = CType(myRecordDataSet.Tables(0).Rows(i).Item("MeetingNumber"), Integer)
						myRecordTitle = CType(myRecordDataSet.Tables(0).Rows(i).Item("Title"), String).Trim

						myListItem = New ListItem
						myListItem.Value = MeetingRecordEventCodeID & "," & myRecordID
						myListItem.Text = "第" & CType(myRecordNumber, String) & "次" & myRecordType & "：" & myRecordTitle

						ListBoxEventOption.Items.Add(myListItem)
					Next
				End If
			Else
				'exception:unknown event type
			End If
		End Sub

		Protected Sub ImageButtonEventInsert_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim myItemValue As String = ""
			Dim myItemText As String = ""
			Dim bFound As Boolean = False

			myListItem = ListBoxEventOption.SelectedItem
			myItemValue = myListItem.Value
			myItemText = myListItem.Text

			For i = 0 To ListboxEvent.Items.Count - 1
				myListItem = ListboxEvent.Items(i)
				If myListItem.Value = myItemValue Then
					bFound = True
					Exit For
				End If
			Next
			If bFound = False Then
				myListItem = New ListItem
				myListItem.Value = myItemValue
				myListItem.Text = myItemText

				ListboxEvent.Items.Add(myListItem)
			End If
		End Sub

		Protected Sub ImageButtonEventDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
			Dim myListItem As ListItem
			myListItem = ListboxEvent.SelectedItem
			ListboxEvent.Items.Remove(myListItem)
		End Sub

		Protected Sub ButtonEventSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			If resolutionID.Trim.Length > 0 Then
				If DeleteEventData(resolutionID) Then
					If SaveEventData(resolutionID) Then
						'
					Else
						'exception:save failure
					End If
				Else
					'exception:delete failure
				End If
			Else
				'exception:resolution id is empty
			End If
		End Sub
		Private Function SaveEventData(ByVal myResolutionID As String) As Boolean
			Dim delimStr As String = ","
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim myItemValue As String = ""
			Dim myEventID As String = ""
			Dim myEventValue As String = ""
			Dim myEventDAO As New EventResolutionMapDAOExtand
			Dim myEntityID As String = ""
			Dim myFunctionResult As Boolean = True

			If myResolutionID.Trim.Length > 0 Then
				For i = 0 To ListboxEvent.Items.Count - 1
					myListItem = ListboxEvent.Items(i)
					If myListItem.Value.Trim <> "" Then
						tempString = myListItem.Value.Trim
						tempArray = tempString.Split(delimiter)
						If tempArray.Length = 2 Then
							myEventID = CType(tempArray(0), String)
							myEventValue = CType(tempArray(1), String)

							myEntityID = myEventDAO.InsertEntity(0, myEventID, myEventValue, myResolutionID, DefaultPermission, DefaultPermissionGroup, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
							If myEntityID.Trim.Length <= 0 Then
								myFunctionResult = False
								Exit For
							End If
						Else
							'exception:parse faulire
							myFunctionResult = False
							Exit For
						End If
					End If
				Next
			Else
				'exception:resolution id is empty
			End If
			Return myFunctionResult
		End Function
		Private Function DeleteEventData(ByVal myResolutionID As String) As Boolean
			Dim myEventDAO As New EventResolutionMapDAOExtand
			Dim myEventDataSet As DataSet
			Dim myEventCount As Integer = 0
			Dim myEventID As String = ""
			Dim i As Integer = 0
			Dim myAuthorityBO As New ContextAuthBO
			Dim myActionResult As Integer = 0
			Dim myFunctionResult As Boolean = True

			If myResolutionID.Trim.Length > 0 Then
				myEventDataSet = myEventDAO.GetEntitysByResolutionID(myResolutionID)
				myEventCount = myEventDataSet.Tables(0).Rows.Count
				If myEventCount > 0 Then
					For i = 0 To myEventCount - 1
						myEventID = CType(myEventDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
						'get authority
						If myAuthorityBO.CheckPurview(EventAuthorityTarget, myEventID, Context.User.Identity.Name, "D") Then
							myActionResult = myEventDAO.DeleteEntity(myEventID)
							If myActionResult = 0 Then
								'delete failure
								myFunctionResult = False
								Exit For
							End If
						End If
					Next
				End If
			End If
			Return myFunctionResult
		End Function
		Private Function GetNextAuditValue(ByVal myAuditID As String) As String
			Dim myAuditMapDAO As New ResolutionAuditMapDAOExtand
			Dim myAuditMapDataSet As DataSet
			Dim myAuditMapCount As Integer = 0
			Dim myAuditMapID As String = ""
			Dim myAuditValue As Integer = 0
			Dim maxAuditValue As Integer = 0
			Dim i As Integer = 0
			Dim result As String = ""

			If myAuditID.Trim.Length > 0 Then
				myAuditMapDataSet = myAuditMapDAO.GetEntitysByAuditID(myAuditID)
				myAuditMapCount = myAuditMapDataSet.Tables(0).Rows.Count
				If myAuditMapCount > 0 Then
					For i = 0 To myAuditMapCount - 1
						Try
							myAuditValue = CType(myAuditMapDataSet.Tables(0).Rows(i).Item("AuditValue"), Integer)
						Catch ex As Exception
							'cast failure
							myAuditValue = 0
						End Try
						If myAuditValue > maxAuditValue Then
							maxAuditValue = myAuditValue
						End If
					Next
				End If
				maxAuditValue = maxAuditValue + 1
				result = CType(maxAuditValue, String)
			Else
				'exception: audit id is empty
			End If
			Return result
		End Function
		Protected Sub DropDownListAuditOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Dim myAuditCodeID As String = ""
			myAuditCodeID = DropDownListAuditOption.SelectedValue
			TextBoxAuditValue.Text = GetNextAuditValue(myAuditCodeID)
		End Sub

		Protected Sub ImageButtonAuditInsert_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
			Dim myAuditCodeID As String = ""
			Dim myAuditCodeDAO As New ResolutionAuditCodeDAOExtand
			Dim myAuditCodeName As String = ""
			Dim myAuditValue As String = ""
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim myItemValue As String = ""
			Dim myItemText As String = ""
			Dim bFound As Boolean = False

			myAuditCodeID = DropDownListAuditOption.SelectedValue
			If CheckBoxAutoIncrease2.Checked = True Then
				myAuditValue = GetNextAuditValue(myAuditCodeID)
			Else
				myAuditValue = TextBoxAuditValue.Text.Trim
			End If
			If (myAuditCodeID.Trim.Length > 0) And (myAuditValue.Trim.Length > 0) Then
				For i = 0 To ListBoxAudit.Items.Count - 1
					myListItem = ListBoxAudit.Items(i)
					If myListItem.Value = myAuditCodeID & "," & myAuditValue Then
						bFound = True
						Exit For
					End If
				Next
				If bFound = False Then
					myListItem = New ListItem
					myAuditCodeName = myAuditCodeDAO.GetNameByEntityID(myAuditCodeID)
					myListItem.Value = myAuditCodeID & "," & myAuditValue
					myListItem.Text = myAuditCodeName & myAuditValue

					ListBoxAudit.Items.Add(myListItem)
				End If
			End If
		End Sub

		Protected Sub ImageButtonAuditDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
			Dim myListItem As ListItem
			myListItem = ListBoxAudit.SelectedItem
			ListBoxAudit.Items.Remove(myListItem)
		End Sub
		Private Function SaveAuditData(ByVal myResolutionID As String) As Boolean
			Dim delimStr As String = ","
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim myItemValue As String = ""
			Dim myAuditID As String = ""
			Dim myAuditValue As String = ""
			Dim myAuditMapDAO As New ResolutionAuditMapDAOExtand
			Dim myAuditMapID As String = ""
			Dim myFunctionResult As Boolean = True

			If myResolutionID.Trim.Length > 0 Then
				For i = 0 To ListBoxAudit.Items.Count - 1
					myListItem = ListBoxAudit.Items(i)
					If myListItem.Value.Trim <> "" Then
						tempString = myListItem.Value.Trim
						tempArray = tempString.Split(delimiter)
						If tempArray.Length = 2 Then
							myAuditID = CType(tempArray(0), String)
							myAuditValue = CType(tempArray(1), String)

							myAuditMapID = myAuditMapDAO.InsertEntity(myResolutionID, 0, myAuditID, myAuditValue, DefaultPermission, DefaultPermissionGroup, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, 1, New Date(1900, 1, 1))
							If myAuditMapID.Trim.Length <= 0 Then
								myFunctionResult = False
								Exit For
							End If
						Else
							'exception:parse faulire
							myFunctionResult = False
							Exit For
						End If
					End If
				Next
			Else
				'exception:resolution id is empty
			End If
			Return myFunctionResult
		End Function
		Private Function DeleteAuditData(ByVal myResolutionID As String) As Boolean
			Dim myFunctionResult As Boolean = True
			Dim myActionResult As Integer = 0
			Dim myAuditMapDAO As New ResolutionAuditMapDAOExtand
			Dim myAuditMapDataSet As DataSet
			Dim myAuditMapCount As Integer = 0
			Dim myAuditMapID As String = ""
			Dim i As Integer = 0
			Dim myAuthorityBO As New ContextAuthBO

			If myResolutionID.Trim.Length > 0 Then
				myAuditMapDataSet = myAuditMapDAO.GetEntitysByResolutionID(myResolutionID)
				myAuditMapCount = myAuditMapDataSet.Tables(0).Rows.Count
				For i = 0 To myAuditMapCount - 1
					myAuditMapID = CType(myAuditMapDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
					'get authority
					If myAuthorityBO.CheckPurview(AuditMapAuthorityTarget, myAuditMapID, Context.User.Identity.Name, "D") Then
						myActionResult = myAuditMapDAO.DeleteEntity(myAuditMapID)
						If myActionResult = 0 Then
							'delete failure
							myFunctionResult = False
							Exit For
						End If
					End If
				Next
			Else
				'exception:resolution id is empty
			End If
			Return myFunctionResult
		End Function
		Protected Sub ButtonAuditSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			If resolutionID.Trim.Length > 0 Then
				If DeleteAuditData(resolutionID) Then
					If SaveAuditData(resolutionID) Then
						'
					Else
						'exception:save failure
					End If
				Else
					'exception:delete failure
				End If
			Else
				'exception:resolution id is empty
			End If
		End Sub

		Protected Sub ImageButtonOfficeInsert_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim myItemValue As String = ""
			Dim myItemText As String = ""
			Dim bFound As Boolean = False

			myListItem = ListBoxOfficeOption.SelectedItem
			myItemValue = myListItem.Value
			myItemText = myListItem.Text

			For i = 0 To ListBoxOffice.Items.Count - 1
				myListItem = ListBoxOffice.Items(i)
				If myListItem.Value = myItemValue Then
					bFound = True
					Exit For
				End If
			Next
			If bFound = False Then
				myListItem = New ListItem
				myListItem.Value = myItemValue
				myListItem.Text = myItemText

				ListBoxOffice.Items.Add(myListItem)
			End If
		End Sub

		Protected Sub ImageButtonOfficeDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
			Dim myListItem As ListItem
			myListItem = ListBoxOffice.SelectedItem
			ListBoxOffice.Items.Remove(myListItem)
		End Sub
		Private Function DeleteOfficeData(ByVal myResolutionID As String) As Boolean
			Dim myFormDAO As New AffairProcessCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myFormID As String = ""
			Dim myFormCount As Integer = 0
			Dim i As Integer = 0
			Dim myFormObject As New AffairProcessCheckFormFrame
			Dim myAuthorityBO As New ContextAuthBO

			If myResolutionID.Trim.Length > 0 Then
				myFormDataSet = myFormDAO.GetEntitysByResolutionID(myResolutionID)
				myFormCount = myFormDataSet.Tables(0).Rows.Count
				If myFormCount > 0 Then
					For i = 0 To myFormCount - 1
						myFormID = CType(myFormDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
						'get authority
						If myAuthorityBO.CheckPurview(FormAuthorityTarget, myFormID, Context.User.Identity.Name, "D") Then
							myFormObject.DeleteFormData(myFormID)
						End If
					Next
				End If
			Else
				'exception:resolution id is empty
				Return False
			End If
			Return True
		End Function
		Private Function SaveOfficeData(ByVal myResolutionID As String) As Boolean
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim myFunctionResult As Boolean = True
			Dim myActionResult As Integer = 0
			Dim myFormDAO As New AffairProcessCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myFormID As String = ""
			Dim myFormCount As Integer = 0
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim myItemValue As String = ""
			Dim bFound As Boolean = False
			Dim myAuthorityBO As New ContextAuthBO
			Dim myFormObject As AffairProcessCheckFormFrame

			If myResolutionID.Trim.Length > 0 Then
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(MainOfficeCodeGroupID)
				myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
				If myNormalCodeCount > 0 Then
					For i = 0 To myNormalCodeCount - 1
						myItemValue = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
						If myItemValue.Length > 0 Then
							bFound = False
							For j = 0 To ListBoxOffice.Items.Count - 1
								myListItem = ListBoxOffice.Items(j)
								If myItemValue = myListItem.Value.Trim Then
									bFound = True
									Exit For
								End If
							Next
							If bFound = True Then
								myFormDataSet = myFormDAO.GetEntitysByGroupIDAndResolutionID(myItemValue, myResolutionID)
								myFormCount = myFormDataSet.Tables(0).Rows.Count
								If myFormCount = 0 Then
									'insert
									myFormID = myFormDAO.InsertEntity(myItemValue, 0, myItemValue, myResolutionID, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, DefaultPermissionGroup, DefaultPermission, 1, New Date(1900, 1, 1))
									If myFormID.Trim.Length <= 0 Then
										myFunctionResult = False
									End If
								End If
							Else
								'delete
								myFormDataSet = myFormDAO.GetEntitysByGroupIDAndResolutionID(myItemValue, myResolutionID)
								myFormCount = myFormDataSet.Tables(0).Rows.Count
								If myFormCount = 1 Then
									myFormID = CType(myFormDataSet.Tables(0).Rows(0).Item("EntityID"), String).Trim
									'get authority
									If myAuthorityBO.CheckPurview(FormAuthorityTarget, myFormID, Context.User.Identity.Name, "D") Then
										myFormObject = New AffairProcessCheckFormFrame
										myFormObject.DeleteFormData(myFormID)
									End If
								End If
							End If
						End If
					Next
				End If
			End If
			Return myFunctionResult
		End Function
		Protected Sub ButtonOfficeSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			If resolutionID.Trim.Length > 0 Then
				SaveOfficeData(resolutionID)
			End If
		End Sub

		Private Sub chkNotify_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNotify.CheckedChanged
			If chkNotify.Checked = True Then

				Session("AlertTitle") = TextBoxContent.Text.Trim
				Session("AlertDeadLine") = TextBoxForecastDate.Text.Trim
				Session("ReEntityID") = TextBoxResolutionNumber.Text.Trim
				PopScheduleAlert()

			End If
		End Sub

		Private Sub PopScheduleAlert()
			Dim Javascript As String
			Dim sfeatures As String
			Dim URL As String
			Dim returnObject As WebControls.TextBox
			Dim returnText As String

			URL = Context.User.Identity.Name.Trim

			sfeatures = "dialogHeight:"

			returnText = CType(ShowDialogBox(returnObject, URL, 600, 350, 0, 0, True), String)


		End Sub

		Private Function ShowDialogBox(ByVal returnValueobj As WebControls.TextBox, ByVal url As String, ByVal width As Integer, ByVal height As Integer, ByVal x As Integer, ByVal y As Integer, Optional ByVal isCenter As Boolean = False) As Boolean

			Dim Javascript As String

			Dim sfeatures As String = ""

			sfeatures &= "dialogHeight:" & height & "px;"

			sfeatures &= "dialogWidth:" & width & "px;"

			If isCenter = False Then
				sfeatures &= "dialogLeft:" & x & "px;"
				sfeatures &= "dialogTop:" & y & "px;"
			End If

			Javascript = vbCrLf & "<script>"
			'	Javascript &= vbCrLf & "Form1." & returnValueobj.ClientID & ".value=window.showModalDialog('../eiis/view/iFrame.aspx?url=" & url & "','','" & sfeatures & "');"
			Javascript &= vbCrLf & "window.showModalDialog('../../eiis/view/iFrame.aspx?url=../../admin/EveryDayScheduleadd.aspx','','" & sfeatures & "');"

			Javascript &= vbCrLf & "</script>"

			Me.RegisterStartupScript("ShowDialog", Javascript)

		End Function
	End Class
End Namespace