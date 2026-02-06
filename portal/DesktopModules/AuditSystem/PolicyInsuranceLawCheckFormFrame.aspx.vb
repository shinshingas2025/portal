Imports System
Imports System.Configuration
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class PolicyInsuranceLawCheckFormFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxCause As System.Web.UI.WebControls.TextBox
		Protected WithEvents LabelMeetingDate As System.Web.UI.WebControls.Label
		Protected WithEvents LabelStartTime As System.Web.UI.WebControls.Label
		Protected WithEvents LabelEndTime As System.Web.UI.WebControls.Label
		Protected WithEvents LabelPlace As System.Web.UI.WebControls.Label
		Protected WithEvents LabelChairPerson As System.Web.UI.WebControls.Label
		Protected WithEvents DropDownListManagementInstitution As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxConcern As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDocumentNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListSign As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListDraft As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListMeetingNumber As System.Web.UI.WebControls.DropDownList
		Protected WithEvents PlaceHolderComment As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ButtonFormPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonFormInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonFormUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonFormDelete As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonFormNext As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCommentAction As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxCommentNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxCommentContent As System.Web.UI.WebControls.TextBox
		Protected WithEvents DropDownListLaw As System.Web.UI.WebControls.DropDownList
		Protected WithEvents LabelConstitutionDate As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDiscussion As System.Web.UI.WebControls.Label
		Protected WithEvents LabelLawContent As System.Web.UI.WebControls.Label
		Protected WithEvents LabelParent As System.Web.UI.WebControls.Label
		Protected WithEvents DropDownListInsurance As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListPolicyLawUndertaker As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListPolicyInsuranceUndertaker As System.Web.UI.WebControls.DropDownList
		Protected WithEvents TextBoxProcessDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxForecastDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxOutsideProcessState As System.Web.UI.WebControls.TextBox
		Protected WithEvents ListBoxMember As System.Web.UI.WebControls.ListBox
		Protected WithEvents ListboxMemberList As System.Web.UI.WebControls.ListBox
		Protected WithEvents ImageButtonLeft As System.Web.UI.WebControls.ImageButton
		Protected WithEvents ImageButtonRight As System.Web.UI.WebControls.ImageButton
		Protected WithEvents TextBoxInsideProcessState As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxConcludeDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxConcludeNumber As System.Web.UI.WebControls.TextBox
		Protected WithEvents ButtonInsurancePrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonInsuranceInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonInsuranceUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonInsuranceDelete As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonInsuranceNext As System.Web.UI.WebControls.Button
		Protected WithEvents LabelInsuranceMark As System.Web.UI.WebControls.Label
		Protected WithEvents LabelPolicyInsuranceUndertakerMark As System.Web.UI.WebControls.Label
		Protected WithEvents LabelProcessDateMark As System.Web.UI.WebControls.Label
		Protected WithEvents LabelForecastDateMark As System.Web.UI.WebControls.Label
		Protected WithEvents LabelOutsideProcessStateMark As System.Web.UI.WebControls.Label
		Protected WithEvents LabelMemberMark As System.Web.UI.WebControls.Label
		Protected WithEvents LabelInsideProcessStateMark As System.Web.UI.WebControls.Label
		Protected WithEvents LabelConcludeDateMark As System.Web.UI.WebControls.Label
		Protected WithEvents LabelConcludeNumberMark As System.Web.UI.WebControls.Label
		Protected WithEvents AjaxPanelMeeting As MagicAjax.UI.Controls.AjaxPanel
		Protected WithEvents AjaxpanelLaw As MagicAjax.UI.Controls.AjaxPanel
		Protected WithEvents AjaxpanelMember As MagicAjax.UI.Controls.AjaxPanel
		Protected WithEvents PlaceHolderInsuranceScheduleLink As System.Web.UI.WebControls.PlaceHolder

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
		Private Const FormAuthorityTarget As String = "PolicyLawCheckForm"
		Private Const FormCommentAuthorityTarget As String = "PolicyLawComment"
		Private Const LawAuthorityTarget As String = "Law"
		Private Const InsuranceAuthorityTarget As String = "PolicyInsuranceMap"
		Private Const InsuranceMemberAuthorityTarget As String = "PolicyInsuranceMemberMap"
		Private Const InsuranceCodeAuthorityTarget As String = "PolicyInsuranceCode"
		Private Const RecordAuthorityTarget As String = "MeetingRecord"
		Private Const CodeAuthorityTarget As String = "NormalCode"
		Private UtilityObject As New AuditSystemUtility

		Private tabIndex As Integer = 0
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Private formID As String = ""
		Private commentID As String = ""
		Private commentAction As String = ""
		Private insuranceID As String = ""

		Private Const PolicyMeetingRecordTypeID As String = "200601010000000900000011"
		Private Const ManagementInstitutionCodeGroupID As String = "2006010100000021"
		Private Const PolicyLawUndertakerCodeGroupID As String = "200601010000000C"
		Private Const SignCodeGroupID As String = "2006010100000022"
		Private Const DraftCodeGroupID As String = "2006010100000023"
		Private Const PolicyInsuranceUndertakerCodeGroupID As String = "200601010000000C"
		Private Const MemberCodeGroupID As String = "200601010000000C"
		Private Const OtherPlaceCodeID As String = "200601010000000A00000010"
		Private Const NormalCodeBGColor As String = "#DEDECA"
		Private Const FocusCodeBGColor As String = "#FFFF99"
		Private Const ActionColumnWidth As String = "40"
		Private Const NumberColumnWidth As String = "80"
		Private Const ContentColumnWidth As String = "360"

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

			If Not (Request.Params("formID") Is Nothing) Then
				formID = Request.Params("formID")
			End If

			If Not (Request.Params("commentID") Is Nothing) Then
				commentID = Request.Params("commentID")
			End If

			If Not (Request.Params("insuranceID") Is Nothing) Then
				insuranceID = Request.Params("insuranceID")
			End If

			If Not (Request.Params("commentAction") Is Nothing) Then
				commentAction = Request.Params("commentAction")
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
			Dim myFormDAO As New PolicyLawCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myFormID As String = ""
			Dim myFormCount As Integer = 0

			If formID.Trim.Length > 0 Then
				myFormDataSet = myFormDAO.GetEntitysByEntityID(formID)
			Else
				myFormDataSet = myFormDAO.GetEntitys()
				myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name, 1)
				myFormCount = myFormDataSet.Tables(0).Rows.Count
				If myFormCount > 0 Then
					If myFormDataSet.Tables(0).Rows.Count = 1 Then
						myFormID = CType(myFormDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & myFormID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
					End If
				End If
			End If
			If Not (myFormDataSet Is Nothing) Then
				FillFormData(myFormDataSet)
			End If
		End Sub
		Private Sub FillFormData(ByVal myFormDataSet As DataSet)
			Dim myCause As String = ""
			Dim myMeetingRecordID As String = ""
			Dim myLawID As String = ""
			Dim myManagementInstitutionID As String = ""
			Dim myUndertakerID As String = ""
			Dim myDocumentNumber As String = ""
			Dim mySignID As String = ""
			Dim myConcern As String = ""
			Dim myDraftID As String = ""
			Dim myMeetingRecordDAO As New MeetingRecordDAOExtand
			Dim myMeetingRecordDataSet As DataSet
			Dim myMeetingDate As Date = New Date(1900, 1, 1)
			Dim myStartTime As String = ""
			Dim myEndTime As String = ""
			Dim myPlaceID As String = ""
			Dim myPlaceName As String = ""
			Dim myChairPersonID As String = ""
			Dim myChairPersonName As String = ""
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeName As String = ""
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet
			Dim myConstitutionDate As Date = New Date(1900, 1, 1)
			Dim myDiscussionID As String = ""
			Dim myDiscussionName As String = ""
			Dim myLawContentDAO As New LawContentDAOExtand
			Dim myLawContentDataSet As DataSet
			Dim myLawContentCount As Integer = 0
			Dim myLawContentID As String = ""
			Dim myLawContentNumber As String = ""
			Dim myLawContent As String = ""
			Dim myParentID As String = ""
			Dim myParentName As String = ""
			Dim myFormID As String = ""
			Dim i As Integer = 0

			If myFormDataSet.Tables(0).Rows.Count = 1 Then
				myFormID = CType(myFormDataSet.Tables(0).Rows(0).Item("EntityID"), String).Trim
				myCause = CType(myFormDataSet.Tables(0).Rows(0).Item("Cause"), String).Trim
				myMeetingRecordID = CType(myFormDataSet.Tables(0).Rows(0).Item("MeetingRecordID"), String).Trim
				myLawID = CType(myFormDataSet.Tables(0).Rows(0).Item("LawID"), String).Trim
				myManagementInstitutionID = CType(myFormDataSet.Tables(0).Rows(0).Item("ManagementInstitutionID"), String).Trim
				myUndertakerID = CType(myFormDataSet.Tables(0).Rows(0).Item("UndertakerID"), String).Trim
				myDocumentNumber = CType(myFormDataSet.Tables(0).Rows(0).Item("DocumentNumber"), String).Trim
				mySignID = CType(myFormDataSet.Tables(0).Rows(0).Item("SignID"), String).Trim
				myConcern = CType(myFormDataSet.Tables(0).Rows(0).Item("Concern"), String).Trim
				myDraftID = CType(myFormDataSet.Tables(0).Rows(0).Item("DraftID"), String).Trim

				TextBoxCause.Text = myCause
				TextBoxConcern.Text = myConcern
				TextBoxDocumentNumber.Text = myDocumentNumber

				Try
					DropDownListManagementInstitution.SelectedValue = myManagementInstitutionID
				Catch ex As Exception
					'exception:no match
				End Try
				Try
					DropDownListPolicyLawUndertaker.SelectedValue = myUndertakerID
				Catch ex As Exception
					'exception:no match
				End Try
				Try
					DropDownListSign.SelectedValue = mySignID
				Catch ex As Exception
					'exception:no match
				End Try
				Try
					DropDownListDraft.SelectedValue = myDraftID
				Catch ex As Exception
					'exception:no match
				End Try
				Try
					DropDownListMeetingNumber.SelectedValue = myMeetingRecordID
				Catch ex As Exception
					'exception:no match
				End Try
				Try
					DropDownListLaw.SelectedValue = myLawID
				Catch ex As Exception
					'exception:no match
				End Try

				'meeting record
				If myMeetingRecordID.Length > 0 Then
					myMeetingRecordDataSet = myMeetingRecordDAO.GetEntitysByEntityID(myMeetingRecordID)
					If myMeetingRecordDataSet.Tables(0).Rows.Count = 1 Then
						myMeetingDate = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("MeetingDate"), Date)
						myStartTime = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("StartTime"), String).Trim
						myEndTime = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("EndTime"), String).Trim
						myPlaceID = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("PlaceID"), String).Trim
						myChairPersonID = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("ChairPersonID"), String).Trim

						If myPlaceID = OtherPlaceCodeID Then
							myPlaceName = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("PlaceName"), String).Trim
						Else
							myPlaceName = myNormalCodeDAO.GetNameByEntityID(myPlaceID)
						End If

						myChairPersonName = myNormalCodeDAO.GetNameByEntityID(myChairPersonID)

						Try
							DropDownListMeetingNumber.SelectedValue = myMeetingRecordID
						Catch ex As Exception
							'exception:no match
						End Try

						LabelMeetingDate.Text = myMeetingDate.Year & "/" & myMeetingDate.Month & "/" & myMeetingDate.Day
						If LabelMeetingDate.Text = "1900/1/1" Then
							LabelMeetingDate.Text = ""
						End If
						LabelStartTime.Text = myStartTime
						LabelEndTime.Text = myEndTime
						LabelPlace.Text = myPlaceName
						LabelChairPerson.Text = myChairPersonName
					Else
						'exception:meeting record is empty or duplicated
					End If
				End If

				'law
				If myLawID.Length > 0 Then
					myLawDataSet = myLawDAO.GetEntitysByEntityID(myLawID)
					If myLawDataSet.Tables(0).Rows.Count = 1 Then
						myConstitutionDate = CType(myLawDataSet.Tables(0).Rows(0).Item("ConstitutionDate"), Date)
						myDiscussionID = CType(myLawDataSet.Tables(0).Rows(0).Item("DiscussionID"), String).Trim
						myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String).Trim

						LabelConstitutionDate.Text = myConstitutionDate.Year & "/" & myConstitutionDate.Month & "/" & myConstitutionDate.Day
						If LabelConstitutionDate.Text = "1900/1/1" Then
							LabelConstitutionDate.Text = ""
						End If

						myDiscussionName = myNormalCodeDAO.GetNameByEntityID(myDiscussionID).Trim
						LabelDiscussion.Text = myDiscussionName

						myLawContentCount = myLawContentDAO.GetTotalRowByLawID(myLawID)
						If myLawContentCount > 0 Then
							myLawContentDataSet = myLawContentDAO.GetEntitysByLawID(myLawID)
							LabelLawContent.Text = ""
							For i = 0 To myLawContentCount - 1
								myLawContentNumber = CType(myLawContentDataSet.Tables(0).Rows(i).Item("ContentNumber"), String).Trim
								myLawContent = CType(myLawContentDataSet.Tables(0).Rows(i).Item("Content"), String).Trim

								LabelLawContent.Text = LabelLawContent.Text & myLawContentNumber & " " & myLawContent & "<br>"
							Next
						End If

						myParentName = ""
						If myParentID.Length > 0 Then
							myLawDataSet = myLawDAO.GetEntitysByEntityID(myParentID)
							If myLawDataSet.Tables(0).Rows.Count = 1 Then
								myParentName = CType(myLawDataSet.Tables(0).Rows(0).Item("Name"), String).Trim
							End If
						End If
						LabelParent.Text = myParentName
					Else
						'exception:law record is empty or duplicated
					End If
				End If
				If myFormID.Trim.Length > 0 Then
					formID = myFormID.Trim
					FillCommentData(myFormID)
					FillInsuranceData(myFormID)
				Else
					'exception:form id is empty
				End If
			Else
				'exception:form record is empty
			End If
		End Sub
		Private Sub FillInsuranceData(ByVal myFormID As String)
			Dim myInsuranceMapDAO As New PolicyInsuranceMapDAOExtand
			Dim myInsuranceMapDataSet As DataSet
			Dim myInsuranceMapID As String = ""
			Dim myInsuranceID As String = ""
			Dim myProcessDate As Date = New Date(1900, 1, 1)
			Dim myForecastDate As Date = New Date(1900, 1, 1)
			Dim myOutsideProcessState As String = ""
			Dim myInsideProcessState As String = ""
			Dim myUndertakerID As String = ""
			Dim myConcludeDate As Date = New Date(1900, 1, 1)
			Dim myConcludeNumber As String = ""
			Dim myMemberMapDAO As New PolicyInsuranceMemberMapDAOExtand
			Dim myMemberMapDataSet As DataSet
			Dim myMemberMapCount As Integer = 0
			Dim myMemberMapID As String = ""
			Dim myMemberID As String = ""
			Dim myMemberName As String = ""
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim i As Integer = 0
			Dim myListItem As ListItem

			If myFormID.Trim.Length > 0 Then
				If insuranceID.Trim.Length > 0 Then
					myInsuranceMapDataSet = myInsuranceMapDAO.GetEntitysByEntityID(insuranceID)
				Else
					myInsuranceMapDataSet = myInsuranceMapDAO.GetEntitysByPolicyLawID(myFormID)
					myInsuranceMapDataSet = UtilityObject.QueryPermissionFilter(myInsuranceMapDataSet, InsuranceAuthorityTarget, Context.User.Identity.Name, 1)
					If myInsuranceMapDataSet.Tables(0).Rows.Count = 1 Then
						myInsuranceMapID = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & myFormID & "&commentID=" & commentID & "&insuranceID=" & myInsuranceMapID)
					End If
				End If
				If myInsuranceMapDataSet.Tables(0).Rows.Count = 1 Then
					myInsuranceMapID = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("EntityID"), String).Trim
					myInsuranceID = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("InsuranceID"), String).Trim
					myProcessDate = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("ProcessDate"), Date)
					myForecastDate = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("ForecastDate"), Date)
					myOutsideProcessState = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("OutsideProcessState"), String).Trim
					myInsideProcessState = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("InsideProcessState"), String).Trim
					myUndertakerID = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("UndertakerID"), String).Trim
					myConcludeDate = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("ConcludeDate"), Date)
					myConcludeNumber = CType(myInsuranceMapDataSet.Tables(0).Rows(0).Item("ConcludeNumber"), String).Trim

					insuranceID = myInsuranceMapID

					Try
						DropDownListInsurance.SelectedValue = myInsuranceID
					Catch ex As Exception
						'exception:no match
					End Try

					Try
						DropDownListPolicyInsuranceUndertaker.SelectedValue = myUndertakerID
					Catch ex As Exception
						'exception:no match
					End Try

					TextBoxProcessDate.Text = myProcessDate.Year & "/" & myProcessDate.Month & "/" & myProcessDate.Day
					If TextBoxProcessDate.Text = "1900/1/1" Then
						TextBoxProcessDate.Text = ""
					End If

					TextBoxForecastDate.Text = myForecastDate.Year & "/" & myForecastDate.Month & "/" & myForecastDate.Day
					If TextBoxForecastDate.Text = "1900/1/1" Then
						TextBoxForecastDate.Text = ""
					End If

					TextBoxOutsideProcessState.Text = myOutsideProcessState

					TextBoxInsideProcessState.Text = myInsideProcessState

					TextBoxConcludeDate.Text = myConcludeDate.Year & "/" & myConcludeDate.Month & "/" & myConcludeDate.Day
					If TextBoxConcludeDate.Text = "1900/1/1" Then
						TextBoxConcludeDate.Text = ""
					End If

					TextBoxConcludeNumber.Text = myConcludeNumber

					ListBoxMember.Items.Clear()
					myMemberMapDataSet = myMemberMapDAO.GetEntitysByPolicyInsuranceID(myInsuranceMapID)
					myMemberMapDataSet = UtilityObject.QueryPermissionFilter(myMemberMapDataSet, InsuranceMemberAuthorityTarget, Context.User.Identity.Name)
					myMemberMapCount = myMemberMapDataSet.Tables(0).Rows.Count
					If myMemberMapCount > 0 Then
						For i = 0 To myMemberMapCount - 1
							myMemberID = CType(myMemberMapDataSet.Tables(0).Rows(i).Item("MemberID"), String).Trim
							myMemberName = myNormalCodeDAO.GetNameByEntityID(myMemberID).Trim

							myListItem = New ListItem
							myListItem.Value = myMemberID
							myListItem.Text = myMemberName

							ListBoxMember.Items.Add(myListItem)
						Next
					End If
				Else
					'exception:insurance map record is empty or duplicated
				End If

				'prepare schedule link
				FillScheduleLink(myFormID)

				LabelInsuranceMark.Visible = True
				LabelPolicyInsuranceUndertakerMark.Visible = True
				LabelProcessDateMark.Visible = True
				LabelForecastDateMark.Visible = True
				LabelOutsideProcessStateMark.Visible = True
				LabelInsideProcessStateMark.Visible = True
				LabelConcludeDateMark.Visible = True
				LabelConcludeNumberMark.Visible = True
				LabelMemberMark.Visible = True

				DropDownListInsurance.Visible = True
				DropDownListPolicyInsuranceUndertaker.Visible = True
				TextBoxProcessDate.Visible = True
				TextBoxForecastDate.Visible = True
				TextBoxOutsideProcessState.Visible = True
				TextBoxInsideProcessState.Visible = True
				TextBoxConcludeDate.Visible = True
				TextBoxConcludeNumber.Visible = True
				ListBoxMember.Visible = True
				ListboxMemberList.Visible = True

				ImageButtonLeft.Visible = True
				ImageButtonRight.Visible = True
				ButtonInsurancePrevious.Visible = True
				ButtonInsuranceNext.Visible = True
				ButtonInsuranceInsert.Visible = True
				ButtonInsuranceUpdate.Visible = True
				ButtonInsuranceDelete.Visible = True
			Else
				'exception:form id is empty
			End If
		End Sub
		Private Sub FillScheduleLink(ByVal myFormID As String)
			Dim myFormDAO As New PolicyLawCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myCause As String = ""
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myNote As String = ""
			Dim myAnchor As HtmlAnchor

			If myFormID.Trim.Length > 0 Then
				myFormDataSet = myFormDAO.GetEntitysByEntityID(myFormID)
				If myFormDataSet.Tables(0).Rows.Count = 1 Then
					myCause = CType(myFormDataSet.Tables(0).Rows(0).Item("Cause"), String).Trim

					PlaceHolderInsuranceScheduleLink.Visible = False

					myTitle = myCause
					myDescription = "應配合開辦險種"
					myNote = ""

					myAnchor = New HtmlAnchor
					myAnchor.Attributes("Class") = "scriptLink"
					myAnchor.InnerHtml = "<img src='/PortalFiles/WebImage/AuditSystem/link.gif' alt='行事曆' />"
					myAnchor.Attributes("OnClick") = "window.open('ScheduleInsert.aspx?inputTitle=" & ToUnicodeString(myTitle) & "&inputDescription=" & ToUnicodeString(myDescription) & "&inputNote=" & ToUnicodeString(myNote) & "','','height=328,width=800,status=no,toolbar=no,menubar=no,location=no','')"

					PlaceHolderInsuranceScheduleLink.Controls.Add(myAnchor)
					PlaceHolderInsuranceScheduleLink.Visible = True
				Else
					'exception:form record is empty or duplicated
				End If
			Else
				'exception:form id is empty
			End If
		End Sub
		Private Function ToUnicodeString(ByVal input As String) As String
			Dim myCharArray() As Char
			Dim myByte As Byte
			Dim result As String = ""
			Dim i As Integer = 0
			Dim uniEncoder As Encoder = Encoding.Unicode.GetEncoder()
			Dim byteCount As Integer = 0
			Dim myByteArray() As Byte
			Dim bytesEncodedCount As Integer = 0

			If input.Trim.Length > 0 Then
				myCharArray = input.ToCharArray()
				byteCount = uniEncoder.GetByteCount(myCharArray, 0, myCharArray.Length, True)
				myByteArray = New Byte(byteCount - 1) {}

				bytesEncodedCount = uniEncoder.GetBytes(myCharArray, 0, myCharArray.Length, myByteArray, 0, True)

				For i = 0 To bytesEncodedCount - 1
					myByte = New Byte
					myByte = myByteArray(i)
					result = result & Microsoft.VisualBasic.Right("00" & CType(Hex(Val(myByte)), String), 2)
				Next
			Else
				'exception:input string is empty
			End If
			Return result
		End Function
		Private Sub FillCommentData(ByVal myFormID As String)
			Dim myCommentDAO As New PolicyLawCommentDAOExtand
			Dim myCommentDataSet As DataSet
			Dim myCommentCount As Integer = 0
			Dim myCommentID As String = ""
			Dim myCommentNumber As String = ""
			Dim myCommentContent As String = ""
			Dim myDisplayOrder As Integer = 0
			Dim myTable As HtmlTable
			Dim myTableRow As HtmlTableRow
			Dim myTableCell As HtmlTableCell
			Dim myHyperLink As HyperLink
			Dim myLiterial As LiteralControl
			Dim myImage As HtmlImage
			Dim i As Integer = 0

			If myFormID.Trim.Length > 0 Then
				PlaceHolderComment.Controls.Clear()

				myTable = New HtmlTable
				myTable.CellPadding = 0
				myTable.CellSpacing = 0
				myTable.Border = 1
				'prepare header
				myTableRow = New HtmlTableRow
				myTableRow.BgColor = NormalCodeBGColor
				'action column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = ActionColumnWidth
				myTableRow.Cells.Add(myTableCell)
				'resolution number column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = NumberColumnWidth
				myTableCell.InnerText = "編號"
				myTableRow.Cells.Add(myTableCell)
				'resolution content column header
				myTableCell = New HtmlTableCell
				myTableCell.Width = ContentColumnWidth
				myTableCell.InnerText = "決議事項或與會意見"
				myTableRow.Cells.Add(myTableCell)

				myTable.Rows.Add(myTableRow)

				myCommentDataSet = myCommentDAO.GetEntitysByPolicyLawID(myFormID)
				myCommentDataSet = UtilityObject.QueryPermissionFilter(myCommentDataSet, FormCommentAuthorityTarget, Context.User.Identity.Name)
				myCommentCount = myCommentDataSet.Tables(0).Rows.Count
				If myCommentCount > 0 Then
					For i = 0 To myCommentCount - 1
						myCommentID = CType(myCommentDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						myTableRow = New HtmlTableRow
						If (myCommentID = commentID) And (commentAction.Trim.Length > 0) Then
							myTableRow.BgColor = FocusCodeBGColor
						Else
							myTableRow.BgColor = NormalCodeBGColor
						End If

						'insert icon
						myTableCell = New HtmlTableCell
						myTableCell.Width = ActionColumnWidth
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & myFormID & "&commentID=" & myCommentID & "&insuranceID=" & insuranceID & "&commentAction=update"
						myHyperLink.ImageUrl = "~/images/edit.gif"
						myHyperLink.Text = "修改"
						myTableCell.Controls.Add(myHyperLink)
						'br
						myLiterial = New LiteralControl
						myLiterial.Text = "<BR>"
						myTableCell.Controls.Add(myLiterial)
						'insert link
						myHyperLink = New HyperLink
						myHyperLink.NavigateUrl = "~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & myFormID & "&commentID=" & myCommentID & "&insuranceID=" & insuranceID & "&commentAction=delete"
						myHyperLink.ImageUrl = "~/images/delete.gif"
						myHyperLink.Text = "刪除"
						myTableCell.Controls.Add(myHyperLink)

						myTableRow.Cells.Add(myTableCell)

						'number
						myCommentNumber = CType(myCommentDataSet.Tables(0).Rows(i).Item("CommentNumber"), String).Trim
						myTableCell = New HtmlTableCell
						myTableCell.Width = NumberColumnWidth
						If myCommentNumber.Length > 8 Then
							myTableCell.InnerHtml = myCommentNumber.Substring(0, 8) & "<BR>" & myCommentNumber.Substring(8)
						Else
							myTableCell.InnerHtml = myCommentNumber
						End If
						myTableRow.Cells.Add(myTableCell)

						'comment
						myCommentContent = CType(myCommentDataSet.Tables(0).Rows(i).Item("Comment"), String)
						myTableCell = New HtmlTableCell
						myTableCell.Width = ContentColumnWidth
						myTableCell.InnerHtml = myCommentContent
						myTableRow.Cells.Add(myTableCell)

						myTable.Rows.Add(myTableRow)
					Next
				Else
					'new comment
				End If
				PlaceHolderComment.Controls.Add(myTable)

				'update/delete
				If commentID.Trim.Length > 0 Then
					myCommentDataSet = myCommentDAO.GetEntitysByEntityID(commentID)
					If myCommentDataSet.Tables(0).Rows.Count = 1 Then
						myCommentNumber = CType(myCommentDataSet.Tables(0).Rows(0).Item("CommentNumber"), String).Trim
						myCommentContent = CType(myCommentDataSet.Tables(0).Rows(0).Item("Comment"), String).Trim
					Else
						'exception:comment record is empty or duplicated
					End If
					If commentAction.Trim.Length > 0 Then
						If commentAction.Trim = "update" Then
							'update
							ButtonCommentAction.Text = "修改"
							TextBoxCommentNumber.Text = myCommentNumber
							TextBoxCommentContent.Text = myCommentContent
						Else
							If commentAction.Trim = "delete" Then
								'delete
								ButtonCommentAction.Text = "刪除"
								TextBoxCommentNumber.Text = myCommentNumber
								TextBoxCommentContent.Text = myCommentContent
							Else
								'exception:unknown action
							End If
						End If
					Else
						'exception:no action
					End If
				End If
				PlaceHolderComment.Visible = True
				ButtonCommentAction.Visible = True
				TextBoxCommentNumber.Visible = True
				TextBoxCommentContent.Visible = True
			Else
				'exception:form id is empty
			End If
		End Sub
		Private Sub InitialWebControl()
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim myMeetingRecordDAO As New MeetingRecordDAOExtand
			Dim myMeetingRecordDataSet As DataSet
			Dim myMeetingRecordCount As Integer = 0
			Dim myMeetingRecordID As String = ""
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet
			Dim myLawCount As Integer = 0
			Dim myInsuranceCodeDAO As New PolicyInsuranceCodeDAOExtand
			Dim myInsuranceCodeDataSet As DataSet
			Dim myInsuranceCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""
			Dim myMeetingNumber As Integer = 1
			Dim myLawID As String = ""
			Dim myLawName As String = ""
			Dim myInsuranceID As String = ""
			Dim myInsuranceName As String = ""

			'policy
			TextBoxCause.Text = ""
			TextBoxConcern.Text = ""
			TextBoxDocumentNumber.Text = ""

			LabelMeetingDate.Text = ""
			LabelStartTime.Text = ""
			LabelEndTime.Text = ""
			LabelPlace.Text = ""
			LabelChairPerson.Text = ""
			LabelConstitutionDate.Text = ""
			LabelDiscussion.Text = ""
			LabelLawContent.Text = ""
			LabelParent.Text = ""

			DropDownListMeetingNumber.Items.Clear()
			myMeetingRecordDataSet = myMeetingRecordDAO.GetEntitysByTypeID(PolicyMeetingRecordTypeID)
			myMeetingRecordDataSet = UtilityObject.QueryPermissionFilter(myMeetingRecordDataSet, RecordAuthorityTarget, Context.User.Identity.Name)
			myMeetingRecordCount = myMeetingRecordDataSet.Tables(0).Rows.Count
			If myMeetingRecordCount > 0 Then
				For i = 0 To myMeetingRecordCount - 1
					myMeetingNumber = CType(myMeetingRecordDataSet.Tables(0).Rows(i).Item("MeetingNumber"), Integer)
					myMeetingRecordID = CType(myMeetingRecordDataSet.Tables(0).Rows(i).Item("EntityID"), String)

					myListItem = New ListItem
					myListItem.Value = myMeetingRecordID
					myListItem.Text = CType(myMeetingNumber, String)

					DropDownListMeetingNumber.Items.Add(myListItem)
				Next
			End If

			DropDownListManagementInstitution.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(ManagementInstitutionCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListManagementInstitution.Items.Add(myListItem)
				Next
			End If

			DropDownListPolicyLawUndertaker.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(PolicyLawUndertakerCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListPolicyLawUndertaker.Items.Add(myListItem)
				Next
			End If

			DropDownListSign.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(SignCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListSign.Items.Add(myListItem)
				Next
			End If

			DropDownListDraft.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(DraftCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListDraft.Items.Add(myListItem)
				Next
			End If

			DropDownListLaw.Items.Clear()
			myLawDataSet = myLawDAO.GetEntitys()
			myLawDataSet = UtilityObject.QueryPermissionFilter(myLawDataSet, LawAuthorityTarget, Context.User.Identity.Name)
			myLawCount = myLawDataSet.Tables(0).Rows.Count
			If myLawCount > 0 Then
				For i = 0 To myLawCount - 1
					myLawID = CType(myLawDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myLawName = CType(myLawDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myLawID
					myListItem.Text = myLawName

					DropDownListLaw.Items.Add(myListItem)
				Next
			End If

			'comment
			TextBoxCommentNumber.Text = ""
			TextBoxCommentNumber.Visible = False
			TextBoxCommentContent.Text = ""
			TextBoxCommentContent.Visible = False

			ButtonCommentAction.Text = "新增"
			ButtonCommentAction.Visible = False

			PlaceHolderComment.Controls.Clear()
			PlaceHolderComment.Visible = False

			'insurance
			TextBoxProcessDate.Text = ""
			TextBoxProcessDate.Visible = False
			TextBoxForecastDate.Text = ""
			TextBoxForecastDate.Visible = False
			TextBoxOutsideProcessState.Text = ""
			TextBoxOutsideProcessState.Visible = False
			TextBoxInsideProcessState.Text = ""
			TextBoxInsideProcessState.Visible = False
			TextBoxConcludeDate.Text = ""
			TextBoxConcludeDate.Visible = False
			TextBoxConcludeNumber.Text = ""
			TextBoxConcludeNumber.Visible = False

			LabelInsuranceMark.Visible = False
			LabelPolicyInsuranceUndertakerMark.Visible = False
			LabelProcessDateMark.Visible = False
			LabelForecastDateMark.Visible = False
			LabelOutsideProcessStateMark.Visible = False
			LabelMemberMark.Visible = False
			LabelInsideProcessStateMark.Visible = False
			LabelConcludeDateMark.Visible = False
			LabelConcludeNumberMark.Visible = False

			ImageButtonLeft.Visible = False
			ImageButtonRight.Visible = False

			ButtonInsurancePrevious.Visible = False
			ButtonInsuranceNext.Visible = False
			ButtonInsuranceInsert.Visible = False
			ButtonInsuranceUpdate.Visible = False
			ButtonInsuranceDelete.Visible = False

			ListBoxMember.Items.Clear()
			ListBoxMember.Visible = False

			ListboxMemberList.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(MemberCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					ListboxMemberList.Items.Add(myListItem)
				Next
			End If
			ListboxMemberList.Visible = False

			DropDownListInsurance.Items.Clear()
			myInsuranceCodeDataSet = myInsuranceCodeDAO.GetEntitys()
			myInsuranceCodeDataSet = UtilityObject.QueryPermissionFilter(myInsuranceCodeDataSet, InsuranceCodeAuthorityTarget, Context.User.Identity.Name)
			myInsuranceCodeCount = myInsuranceCodeDataSet.Tables(0).Rows.Count
			If myInsuranceCodeCount > 0 Then
				For i = 0 To myInsuranceCodeCount - 1
					myInsuranceID = CType(myInsuranceCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myInsuranceName = CType(myInsuranceCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myInsuranceID
					myListItem.Text = myInsuranceName

					DropDownListInsurance.Items.Add(myListItem)
				Next
			End If
			DropDownListInsurance.Visible = False

			DropDownListPolicyInsuranceUndertaker.Items.Clear()
			myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(PolicyInsuranceUndertakerCodeGroupID)
			myNormalCodeDataSet = UtilityObject.QueryPermissionFilter(myNormalCodeDataSet, CodeAuthorityTarget, Context.User.Identity.Name)
			myNormalCodeCount = myNormalCodeDataSet.Tables(0).Rows.Count
			If myNormalCodeCount > 0 Then
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					DropDownListPolicyInsuranceUndertaker.Items.Add(myListItem)
				Next
			End If
			DropDownListPolicyInsuranceUndertaker.Visible = False

			PlaceHolderInsuranceScheduleLink.Visible = False
		End Sub
		Private Function SaveFormData(ByVal myFormID As String) As String
			Dim myFormDAO As New PolicyLawCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myMeetingRecordDAO As New MeetingRecordDAOExtand
			Dim myMeetingRecordDataSet As DataSet
			Dim myMeetingRecordID As String = ""
			Dim myCause As String = ""
			Dim myConcern As String = ""
			Dim myManagementInstitutionID As String = ""
			Dim myUndertakerID As String = ""
			Dim myDocumentNumber As String = ""
			Dim mySignID As String = ""
			Dim myDraftID As String = ""
			Dim myLawID As String = ""
			Dim myAuthorityBO As New ContextAuthBO

			myCause = TextBoxCause.Text.Trim
			myConcern = TextBoxConcern.Text.Trim
			myManagementInstitutionID = DropDownListManagementInstitution.SelectedValue
			myUndertakerID = DropDownListPolicyLawUndertaker.SelectedValue
			myDocumentNumber = TextBoxDocumentNumber.Text.Trim
			mySignID = DropDownListSign.SelectedValue
			myDraftID = DropDownListDraft.SelectedValue
			myLawID = DropDownListLaw.SelectedValue
			myMeetingRecordID = DropDownListMeetingNumber.SelectedValue

			If myFormID.Trim.Length > 0 Then
				'update
				myFormDataSet = myFormDAO.GetEntitysByEntityID(myFormID)
				If myFormDataSet.Tables(0).Rows.Count = 1 Then
					'get authority
					If myAuthorityBO.CheckPurview(FormAuthorityTarget, myFormID, Context.User.Identity.Name, "U") Then
						myFormDAO.UpdateEntity(myFormID, myMeetingRecordID, myLawID, myCause, myManagementInstitutionID, myUndertakerID, myDocumentNumber, mySignID, myConcern, myDraftID, Context.User.Identity.Name, Now)
					End If
				Else
					'exception:form record is empty or duplicated
				End If
			Else
				'insert new data
				myFormID = myFormDAO.InsertEntity(0, myMeetingRecordID, myLawID, myCause, myManagementInstitutionID, myUndertakerID, myDocumentNumber, mySignID, myConcern, myDraftID, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, DefaultPermission, DefaultPermissionGroup, 1, New Date(1900, 1, 1))
			End If
			Return myFormID
		End Function
		Private Sub DeleteFormData(ByVal myFormID As String)
			Dim myFormDAO As New PolicyLawCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myInsuranceMapDAO As New PolicyInsuranceMapDAOExtand
			Dim myInsuranceMapDataSet As DataSet
			Dim myInsuranceMapID As String = ""
			Dim myInsuranceMapCount As Integer = 0
			Dim i As Integer = 0

			If myFormID.Trim.Length > 0 Then
				myFormDataSet = myFormDAO.GetEntitysByEntityID(myFormID)
				If myFormDataSet.Tables(0).Rows.Count = 1 Then
					'delete comment
					DeleteCommentData(myFormID)
					'delete insurance map
					myInsuranceMapCount = myInsuranceMapDAO.GetTotalRowByPolicyLawID(myFormID)
					If myInsuranceMapCount > 0 Then
						myInsuranceMapDataSet = myInsuranceMapDAO.GetEntitysByPolicyLawID(myFormID)
						For i = 0 To myInsuranceMapCount - 1
							myInsuranceMapID = CType(myInsuranceMapDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							DeleteInsuranceMapData(myInsuranceMapID)
						Next
					End If
				Else
					'exception:form record is empty or duplicated
				End If
			Else
				'exception:form id is empty
			End If
		End Sub
		Private Sub DeleteCommentData(ByVal myFormID As String)
			Dim myCommentDAO As New PolicyLawCommentDAOExtand
			Dim myCommentDataSet As DataSet
			Dim myCommentID As String = ""
			Dim myCommentCount As Integer = 0
			Dim i As Integer = 0
			Dim myAuthorityBO As New ContextAuthBO

			If myFormID.Trim.Length > 0 Then
				myCommentCount = myCommentDAO.GetTotalRowByPolicyLawID(myFormID)
				If myCommentCount > 0 Then
					myCommentDataSet = myCommentDAO.GetEntitysByPolicyLawID(myFormID)
					For i = 0 To myCommentCount - 1
						myCommentID = CType(myCommentDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						'get authority
						If myAuthorityBO.CheckPurview(FormCommentAuthorityTarget, myCommentID, Context.User.Identity.Name, "D") Then
							'actual action
							myCommentDAO.DeleteEntity(myCommentID)
						End If
					Next
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonFormInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFormInsert.Click
			Dim myFormID As String = ""
			myFormID = SaveFormData("")
			If myFormID.Trim.Length > 0 Then
				Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & myFormID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonFormUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFormUpdate.Click
			If formID.Trim.Length > 0 Then
				SaveFormData(formID)
				Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonFormDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFormDelete.Click
			If formID.Trim.Length > 0 Then
				DeleteFormData(formID)

				formID = ""
				Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonFormPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFormPrevious.Click
			Dim myFormDAO As New PolicyLawCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myItemID As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False
			Dim i As Integer = 0

			If formID.Trim.Length > 0 Then
				myPreviousID = formID
				myFormDataSet = myFormDAO.GetEntitysByEntityID(formID)
				If myFormDataSet.Tables(0).Rows.Count = 1 Then
					myItemID = CType(myFormDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)

					myFormDataSet = myFormDAO.GetItemID()
					myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
					If myFormDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myFormDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myFormDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							Else
								'save previous id
								myPreviousID = CType(myFormDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							End If
						Next
						If bFound = True Then
							Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & myPreviousID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
						End If
					End If
				Else
					'exception:form record is empty or duplicated
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonFormNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFormNext.Click
			Dim myFormDAO As New PolicyLawCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myItemID As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False
			Dim i As Integer = 0

			If formID.Trim.Length > 0 Then
				myNextID = formID
				myFormDataSet = myFormDAO.GetEntitysByEntityID(formID)
				If myFormDataSet.Tables(0).Rows.Count = 1 Then
					myItemID = CType(myFormDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)

					myFormDataSet = myFormDAO.GetItemID()
					myFormDataSet = UtilityObject.QueryPermissionFilter(myFormDataSet, FormAuthorityTarget, Context.User.Identity.Name)
					If myFormDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myFormDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myFormDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							End If
						Next
					End If
					If bFound = True Then
						'save next id
						If i + 1 < myFormDataSet.Tables(0).Rows.Count Then
							myNextID = CType(myFormDataSet.Tables(0).Rows(i + 1).Item("EntityID"), String)
						Else
							myNextID = CType(myFormDataSet.Tables(0).Rows(myFormDataSet.Tables(0).Rows.Count - 1).Item("EntityID"), String)
						End If
						Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & myNextID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
					End If
				Else
					'exception:form record is empty or duplicated
				End If
			Else
				'exception form id is empty
			End If
		End Sub

		Private Sub ButtonCommentAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCommentAction.Click
			Dim myCommentDAO As New PolicyLawCommentDAOExtand
			Dim myCommentDataSet As DataSet
			Dim myCommentNumber As String = ""
			Dim myComment As String = ""
			Dim myFormDAO As New PolicyLawCheckFormDAOExtand
			Dim myFormDataSet As DataSet
			Dim myAuthorityBO As New ContextAuthBO

			If formID.Trim.Length > 0 Then
				myFormDataSet = myFormDAO.GetEntitysByEntityID(formID)
				If myFormDataSet.Tables(0).Rows.Count = 1 Then
					'read data from input form
					myCommentNumber = TextBoxCommentNumber.Text.Trim
					myComment = TextBoxCommentContent.Text.Trim

					If commentID.Trim.Length > 0 Then
						If commentAction.Trim.Length > 0 Then
							If commentAction.Trim = "update" Then
								'get authority
								If myAuthorityBO.CheckPurview(FormCommentAuthorityTarget, commentID, Context.User.Identity.Name, "U") Then
									'update
									myCommentDAO.UpdateEntity(commentID, formID, myCommentNumber, myComment, 1, Context.User.Identity.Name, Now)
									Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
								Else
									PageLoad()
								End If
							Else
								If commentAction.Trim = "delete" Then
									'get authority
									If myAuthorityBO.CheckPurview(FormCommentAuthorityTarget, commentID, Context.User.Identity.Name, "D") Then
										'delete
										myCommentDAO.DeleteEntity(commentID)
										Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
									Else
										PageLoad()
									End If
								Else
									'exception:unknown action
								End If
								End If
						Else
							'exception:no action
						End If
					Else
						'insert
						myCommentDAO.InsertEntity(formID, 0, myCommentNumber, myComment, 1, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, DefaultPermission, DefaultPermissionGroup, 1, New Date(1900, 1, 1))
						Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
					End If
				Else
					'exception:form record is empty or duplicated
				End If
			Else
				'exception:form id is empty
			End If
		End Sub
		Private Function SaveInsuranceMapData(ByVal myInsuranceMapID As String) As String
			Dim myInsuranceMapDAO As New PolicyInsuranceMapDAOExtand
			Dim myInsuranceMapDataSet As DataSet
			Dim myInsuranceID As String = ""
			Dim myProcessDate As Date = New Date(1900, 1, 1)
			Dim myForecastdate As Date = New Date(1900, 1, 1)
			Dim myOutsideProcessState As String = ""
			Dim myInsideProcessState As String = ""
			Dim myUndertakerID As String = ""
			Dim myConcludeDate As Date = New Date(1900, 1, 1)
			Dim myConcludeNumber As String = ""
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim myAuthorityBO As New ContextAuthBO

			If formID.Trim.Length > 0 Then
				myInsuranceID = DropDownListInsurance.SelectedValue
				myOutsideProcessState = TextBoxOutsideProcessState.Text.Trim
				myInsideProcessState = TextBoxInsideProcessState.Text.Trim
				myUndertakerID = DropDownListPolicyInsuranceUndertaker.SelectedValue
				myConcludeNumber = TextBoxConcludeNumber.Text.Trim
				If TextBoxProcessDate.Text.Trim <> "" Then
					tempString = TextBoxProcessDate.Text.Trim
					tempArray = tempString.Split(delimiter)
					If tempArray.Length = 3 Then
						myProcessDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
					End If
				End If
				If TextBoxForecastDate.Text.Trim <> "" Then
					tempString = TextBoxForecastDate.Text.Trim
					tempArray = tempString.Split(delimiter)
					If tempArray.Length = 3 Then
						myForecastdate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
					End If
				End If
				If TextBoxConcludeDate.Text.Trim <> "" Then
					tempString = TextBoxConcludeDate.Text.Trim
					tempArray = tempString.Split(delimiter)
					If tempArray.Length = 3 Then
						myConcludeDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
					End If
				End If

				If myInsuranceMapID.Trim.Length > 0 Then
					'update
					myInsuranceMapDataSet = myInsuranceMapDAO.GetEntitysByEntityID(myInsuranceMapID)
					If myInsuranceMapDataSet.Tables(0).Rows.Count = 1 Then
						'get authority
						If myAuthorityBO.CheckPurview(InsuranceAuthorityTarget, myInsuranceMapID, Context.User.Identity.Name, "U") Then
							myInsuranceMapDAO.UpdateEntity(myInsuranceMapID, formID, myInsuranceID, myProcessDate, myForecastdate, myOutsideProcessState, myInsideProcessState, myUndertakerID, myConcludeDate, myConcludeNumber, Context.User.Identity.Name, Now)
							'update member
							DeleteInsuranceMemberData(myInsuranceMapID)
							SaveInsuranceMemberData(myInsuranceMapID)
						Else
							PageLoad()
						End If
					Else
						'exception:insurance map record is empty or duplicated
					End If
				Else
					'insert
					myInsuranceMapID = myInsuranceMapDAO.InsertEntity(formID, 0, myInsuranceID, myProcessDate, myForecastdate, myOutsideProcessState, myInsideProcessState, myUndertakerID, myConcludeDate, myConcludeNumber, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, DefaultPermission, DefaultPermissionGroup, 1, New Date(1900, 1, 1))
					'insert member
					SaveInsuranceMemberData(myInsuranceMapID)
				End If
			Else
				'exception:form id is empty
			End If
			Return myInsuranceMapID
		End Function
		Private Function DeleteInsuranceMapData(ByVal myInsuranceMapID As String) As String
			Dim myInsuranceMapDAO As New PolicyInsuranceMapDAOExtand
			Dim myInsuranceMapDataSet As DataSet
			Dim myAuthorityBO As New ContextAuthBO

			If myInsuranceMapID.Trim.Length > 0 Then
				myInsuranceMapDataSet = myInsuranceMapDAO.GetEntitysByEntityID(myInsuranceMapID)
				If myInsuranceMapDataSet.Tables(0).Rows.Count = 1 Then
					'get authority
					If myAuthorityBO.CheckPurview(InsuranceAuthorityTarget, myInsuranceMapID, Context.User.Identity.Name, "D") Then
						'delete member
						DeleteInsuranceMemberData(myInsuranceMapID)
						myInsuranceMapDAO.DeleteEntity(myInsuranceMapID)
					Else
						PageLoad()
					End If
				Else
					'exception:insurance map record is empty or duplicated
				End If
			Else
				'exception:insurance map id is empty
			End If
		End Function
		Private Sub SaveInsuranceMemberData(ByVal myInsuranceMapID As String)
			Dim myMemberMapDAO As New PolicyInsuranceMemberMapDAOExtand
			Dim myMemberID As String = ""
			Dim i As Integer = 0
			Dim myListItem As ListItem

			If myInsuranceMapID.Trim.Length > 0 Then
				For i = 0 To ListBoxMember.Items.Count - 1
					myListItem = ListBoxMember.Items(i)

					If myListItem.Value.Trim.Length > 0 Then
						myMemberID = myListItem.Value.Trim

						myMemberMapDAO.InsertEntity(myInsuranceMapID, 0, myMemberID, 1, Context.User.Identity.Name, Now, Context.User.Identity.Name, Now, DefaultPermission, DefaultPermissionGroup, 1, New Date(1900, 1, 1))
					End If
				Next
			Else
				'exception:insurance map id is empty
			End If
		End Sub
		Private Sub DeleteInsuranceMemberData(ByVal myInsuranceMapID As String)
			Dim myMemberMapDAO As New PolicyInsuranceMemberMapDAOExtand
			Dim myMemberMapDataSet As DataSet
			Dim myMemberMapID As String = ""
			Dim myMemberMapCount As Integer = 0
			Dim i As Integer = 0
			Dim myAuthorityBO As New ContextAuthBO

			If myInsuranceMapID.Trim.Length > 0 Then
				myMemberMapCount = myMemberMapDAO.GetTotalRowByPolicyInsuranceID(myInsuranceMapID)
				If myMemberMapCount > 0 Then
					myMemberMapDataSet = myMemberMapDAO.GetEntitysByPolicyInsuranceID(myInsuranceMapID)
					For i = 0 To myMemberMapCount - 1
						myMemberMapID = CType(myMemberMapDataSet.Tables(0).Rows(i).Item("EntityID"), String)
						'get authority
						If myAuthorityBO.CheckPurview(InsuranceMemberAuthorityTarget, myMemberMapID, Context.User.Identity.Name, "D") Then
							myMemberMapDAO.DeleteEntity(myMemberMapID)
						End If
					Next
				End If
			Else
				'exception:insurance map id is empty
			End If
		End Sub
		Private Sub ButtonInsuranceInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsuranceInsert.Click
			Dim myInsureanceMapID As String = ""
			If formID.Trim.Length > 0 Then
				myInsureanceMapID = SaveInsuranceMapData("")
				If myInsureanceMapID.Trim.Length > 0 Then
					Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & myInsureanceMapID)
				Else
					'insert failure
					PageLoad()
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonInsuranceUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsuranceUpdate.Click
			If formID.Trim.Length > 0 Then
				If insuranceID.Trim.Length > 0 Then
					SaveInsuranceMapData(insuranceID)
					Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
				Else
					'insurance map id is empty
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonInsuranceDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsuranceDelete.Click
			If formID.Trim.Length > 0 Then
				If insuranceID.Trim.Length > 0 Then
					DeleteInsuranceMemberData(insuranceID)

					insuranceID = ""
					Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & insuranceID)
				Else
					'exception:insurance map id is empty
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonInsurancePrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsurancePrevious.Click
			Dim myInsuranceMapDAO As New PolicyInsuranceMapDAOExtand
			Dim myInsuranceMapDataSet As DataSet
			Dim i As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False

			If formID.Trim.Length > 0 Then
				If insuranceID.Trim.Length > 0 Then
					myPreviousID = insuranceID
					myInsuranceMapDataSet = myInsuranceMapDAO.GetEntitysByEntityID(insuranceID)
					If myInsuranceMapDataSet.Tables(0).Rows.Count = 1 Then
						myInsuranceMapDataSet = myInsuranceMapDAO.GetEntityIDByPolicyLawID(formID)
						myInsuranceMapDataSet = UtilityObject.QueryPermissionFilter(myInsuranceMapDataSet, InsuranceAuthorityTarget, Context.User.Identity.Name)
						If myInsuranceMapDataSet.Tables(0).Rows.Count > 0 Then
							For i = 0 To myInsuranceMapDataSet.Tables(0).Rows.Count - 1
								If insuranceID = CType(myInsuranceMapDataSet.Tables(0).Rows(i).Item("EntityID"), String) Then
									bFound = True
									Exit For
								Else
									'save previous id
									myPreviousID = CType(myInsuranceMapDataSet.Tables(0).Rows(i).Item("EntityID"), String)
								End If
							Next
							If bFound = True Then
								Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & myPreviousID)
							End If
						End If
					Else
						'exception:insurance map record is empty or duplicated
					End If
				Else
					'exception:insurance map id is empty
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Private Sub ButtonInsuranceNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsuranceNext.Click
			Dim myInsuranceMapDAO As New PolicyInsuranceMapDAOExtand
			Dim myInsuranceMapDataSet As DataSet
			Dim i As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False

			If formID.Trim.Length > 0 Then
				If insuranceID.Trim.Length > 0 Then
					myNextID = insuranceID
					myInsuranceMapDataSet = myInsuranceMapDAO.GetEntitysByEntityID(insuranceID)
					If myInsuranceMapDataSet.Tables(0).Rows.Count = 1 Then
						myInsuranceMapDataSet = myInsuranceMapDAO.GetEntityIDByPolicyLawID(formID)
						myInsuranceMapDataSet = UtilityObject.QueryPermissionFilter(myInsuranceMapDataSet, InsuranceAuthorityTarget, Context.User.Identity.Name)
						If myInsuranceMapDataSet.Tables(0).Rows.Count > 0 Then
							For i = 0 To myInsuranceMapDataSet.Tables(0).Rows.Count - 1
								If insuranceID = CType(myInsuranceMapDataSet.Tables(0).Rows(i).Item("EntityID"), String) Then
									bFound = True
									Exit For
								End If
							Next
							If bFound = True Then
								'save next id
								If i + 1 < myInsuranceMapDataSet.Tables(0).Rows.Count Then
									myNextID = CType(myInsuranceMapDataSet.Tables(0).Rows(i + 1).Item("EntityID"), String)
								Else
									myNextID = CType(myInsuranceMapDataSet.Tables(0).Rows(myInsuranceMapDataSet.Tables(0).Rows.Count - 1).Item("EntityID"), String)
								End If
								Response.Redirect("~/DesktopModules/AuditSystem/PolicyInsuranceLawCheckFormFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&formID=" & formID & "&commentID=" & commentID & "&insuranceID=" & myNextID)
							End If
						End If
					Else
						'exception:insurance map record is empty or duplicated
					End If
				Else
					'exception:insurance map id is empty
				End If
			Else
				'exception:form id is empty
			End If
		End Sub

		Protected Sub DropDownListMeetingNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Dim myMeetingRecordDAO As New MeetingRecordDAOExtand
			Dim myMeetingRecordDataSet As DataSet
			Dim myMeetingRecordID As String = ""
			Dim myMeetingDate As Date = New Date(1900, 1, 1)
			Dim myStartTime As String = ""
			Dim myEndTime As String = ""
			Dim myPlaceID As String = ""
			Dim myPlaceName As String = ""
			Dim myChairPersonID As String = ""
			Dim myChairPersonName As String = ""
			Dim myNormalCodeDAO As New NormalCodeDAOExtand

			myMeetingRecordID = DropDownListMeetingNumber.SelectedValue

			If myMeetingRecordID.Trim.Length > 0 Then
				myMeetingRecordDataSet = myMeetingRecordDAO.GetEntitysByEntityID(myMeetingRecordID)
				If myMeetingRecordDataSet.Tables(0).Rows.Count = 1 Then
					myMeetingDate = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("MeetingDate"), Date)
					myStartTime = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("StartTime"), String).Trim
					myEndTime = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("EndTime"), String).Trim
					myPlaceID = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("PlaceID"), String).Trim
					myChairPersonID = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("ChairPersonID"), String).Trim

					If myPlaceID = OtherPlaceCodeID Then
						myPlaceName = CType(myMeetingRecordDataSet.Tables(0).Rows(0).Item("PlaceName"), String).Trim
					Else
						myPlaceName = myNormalCodeDAO.GetNameByEntityID(myPlaceID)
					End If
					myChairPersonName = myNormalCodeDAO.GetNameByEntityID(myChairPersonID)

					LabelMeetingDate.Text = myMeetingDate.Year & "/" & myMeetingDate.Month & "/" & myMeetingDate.Day
					If LabelMeetingDate.Text = "1900/1/1" Then
						LabelMeetingDate.Text = ""
					End If
					LabelStartTime.Text = myStartTime
					LabelEndTime.Text = myEndTime
					LabelPlace.Text = myPlaceName
					LabelChairPerson.Text = myChairPersonName
				Else
					'exception:meeting record is empty or duplicated
				End If
			Else
				'exception:meeting record is empty
			End If
		End Sub

		Protected Sub DropDownListLaw_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Dim myLawID As String = ""
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim myConstitutionDate As Date = New Date(1900, 1, 1)
			Dim myDiscussionID As String = ""
			Dim myParentID As String = ""
			Dim myDiscussionName As String = ""
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myLawContentCount As Integer = 0
			Dim myLawContentDAO As New LawContentDAOExtand
			Dim myLawContentDataSet As DataSet
			Dim myLawContentNumber As String = ""
			Dim mylawContent As String = ""
			Dim myParentName As String = ""
			Dim i As Integer = 0

			myLawID = DropDownListLaw.SelectedValue

			If myLawID.Length > 0 Then
				myLawDataSet = myLawDAO.GetEntitysByEntityID(myLawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					myConstitutionDate = CType(myLawDataSet.Tables(0).Rows(0).Item("ConstitutionDate"), Date)
					myDiscussionID = CType(myLawDataSet.Tables(0).Rows(0).Item("DiscussionID"), String).Trim
					myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String).Trim

					LabelConstitutionDate.Text = myConstitutionDate.Year & "/" & myConstitutionDate.Month & "/" & myConstitutionDate.Day
					If LabelConstitutionDate.Text = "1900/1/1" Then
						LabelConstitutionDate.Text = ""
					End If

					myDiscussionName = myNormalCodeDAO.GetNameByEntityID(myDiscussionID).Trim
					LabelDiscussion.Text = myDiscussionName

					myLawContentCount = myLawContentDAO.GetTotalRowByLawID(myLawID)
					If myLawContentCount > 0 Then
						myLawContentDataSet = myLawContentDAO.GetEntitysByLawID(myLawID)
						LabelLawContent.Text = ""
						For i = 0 To myLawContentCount - 1
							myLawContentNumber = CType(myLawContentDataSet.Tables(0).Rows(i).Item("ContentNumber"), String).Trim
							mylawContent = CType(myLawContentDataSet.Tables(0).Rows(i).Item("Content"), String).Trim

							LabelLawContent.Text = LabelLawContent.Text & myLawContentNumber & " " & mylawContent & "<br>"
						Next
					End If

					myParentName = ""
					If myParentID.Length > 0 Then
						myLawDataSet = myLawDAO.GetEntitysByEntityID(myParentID)
						If myLawDataSet.Tables(0).Rows.Count = 1 Then
							myParentName = CType(myLawDataSet.Tables(0).Rows(0).Item("Name"), String).Trim
						End If
					End If
					LabelParent.Text = myParentName
				Else
					'exception:law record is empty or duplicated
				End If
			End If
		End Sub

		Protected Sub ImageButtonLeft_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
			Dim myListItem As ListItem
			Dim i As Integer = 0
			Dim myItemValue As String = ""
			Dim myItemText As String = ""
			Dim bFound As Boolean = False

			myListItem = ListboxMemberList.SelectedItem
			myItemValue = myListItem.Value
			myItemText = myListItem.Text

			For i = 0 To ListBoxMember.Items.Count - 1
				myListItem = ListBoxMember.Items(i)
				If myListItem.Value = myItemValue Then
					bFound = True
					Exit For
				End If
			Next
			If bFound = False Then
				myListItem = New ListItem
				myListItem.Value = myItemValue
				myListItem.Text = myItemText

				ListBoxMember.Items.Add(myListItem)
			End If
		End Sub

		Protected Sub ImageButtonRight_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
			Dim myListItem As ListItem

			myListItem = ListBoxMember.SelectedItem

			ListBoxMember.Items.Remove(myListItem)
		End Sub
	End Class
End Namespace