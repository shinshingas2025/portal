Namespace ASPNET.StarterKit.Portal
	Public Class SubscriptionUserEdit
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents RadioButtonMale As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonFemale As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation1 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation2 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation3 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation4 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation5 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation6 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation7 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation8 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonEducation9 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonSalary1 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonSalary2 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonSalary3 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonSalary4 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents RadioButtonSalary5 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents TextBoxName As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxEmail As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxBirthday As System.Web.UI.WebControls.TextBox
		Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
		Protected WithEvents LinkButtonCalendar As System.Web.UI.WebControls.LinkButton
		Protected WithEvents RegularExpressionValidatorEmail As System.Web.UI.WebControls.RegularExpressionValidator
		Protected WithEvents DropDownListCountry As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListJob As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListTitle As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DropDownListInformation As System.Web.UI.WebControls.DropDownList
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents RequiredFieldValidatorEmail As System.Web.UI.WebControls.RequiredFieldValidator
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
		Protected sid As String = "9999"
		Protected moduleID As Integer = 0
		Protected itemID As Integer = 0
		Protected entityID As String = ""
		Protected subscriptionUserID As String = ""

		Protected CountryCodeGroupID As String = "2005111400000001"
		Protected JobCodeGroupID As String = "2005111400000002"
		Protected TitleCodeGroupID As String = "2005111400000003"
		Protected InformationCodeGroupID As String = "2005111400000004"
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

		Enum Sex
			Male = 1
			Female = 2
		End Enum
		Enum Education
			Elementary = 1
			Secondary = 2
			Professional = 3
			High = 4
			College = 5
			University = 6
			Master = 7
			Academic = 8
			Other = 9
		End Enum
		Enum Salary
			Degree1 = 1
			Degree2 = 2
			Degree3 = 3
			Degree4 = 4
			Degree5 = 5
		End Enum
		Enum SubscriptionState
			Disable = 0
			Enable = 1
			History = 2
		End Enum
		Enum SubscriptionUserType
			Subscription = 1
			School = 2
		End Enum
		Enum DeliverMark
			Enable = 0
			Disable = 1
		End Enum

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If
			If Not (Request.Params("mid") Is Nothing) Then
				moduleID = Int32.Parse(Request.Params("mid"))
			End If
			If Not (Request.Params("ItemID") Is Nothing) Then
				itemID = Int32.Parse(Request.Params("ItemID"))
			End If
			If Not (Request.Params("EntityID") Is Nothing) Then
				entityID = Request.Params("EntityID")
			End If
			If Not (Request.Params("subscriptionuserid") Is Nothing) Then
				subscriptionUserID = Request.Params("subscriptionuserid")
			End If
			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				LoadPage()
			End If

		End Sub

		Private Sub LoadPage()
			Dim myCountryDataSet As DataSet
			Dim myJobDataSet As DataSet
			Dim myTitleDataSet As DataSet
			Dim myInformationDataSet As DataSet
			Dim myCode As New Portal_CodeNormalDAOExtand
			Dim mySubscriptionUserDAO As New Portal_SubscriptionUserDAOExtand
			Dim mySubscriptionUserDataSet As DataSet
			Dim myBirthday As Date = Now
			Dim mySex As Integer = 0
			Dim myEducation As Integer = 0
			Dim mySalary As Integer = 0
			Dim myJob As Integer = 0
			Dim myTitle As Integer = 0
			Dim myInformation As Integer = 0
			Dim myCountry As Integer = 0
			Dim myListItem As ListItem

			myCountryDataSet = myCode.GetEntitys(CountryCodeGroupID)
			DropDownListCountry.DataSource = myCountryDataSet
			DropDownListCountry.DataTextField = "Name"
			DropDownListCountry.DataValueField = "ItemID"
			DropDownListCountry.DataBind()

			myJobDataSet = myCode.GetEntitys(JobCodeGroupID)
			DropDownListJob.DataSource = myJobDataSet
			DropDownListJob.DataTextField = "Name"
			DropDownListJob.DataValueField = "ItemID"
			DropDownListJob.DataBind()

			myTitleDataSet = myCode.GetEntitys(TitleCodeGroupID)
			DropDownListTitle.DataSource = myTitleDataSet
			DropDownListTitle.DataTextField = "Name"
			DropDownListTitle.DataValueField = "ItemID"
			DropDownListTitle.DataBind()

			myInformationDataSet = myCode.GetEntitys(InformationCodeGroupID)
			DropDownListInformation.DataSource = myInformationDataSet
			DropDownListInformation.DataTextField = "Name"
			DropDownListInformation.DataValueField = "ItemID"
			DropDownListInformation.DataBind()

			TextBoxName.Text = ""
			TextBoxEmail.Text = ""
			TextBoxBirthday.Text = ""
			Calendar1.TodaysDate = Now.AddYears(-22)
			If subscriptionUserID.Trim.Length > 0 Then
				mySubscriptionUserDataSet = mySubscriptionUserDAO.GetEntitys(subscriptionUserID)
				If mySubscriptionUserDataSet.Tables(0).Rows.Count = 1 Then
					TextBoxName.Text = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Name"), String).Trim
					TextBoxEmail.Text = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Email"), String).Trim

					myBirthday = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Birthday"), Date)
					TextBoxBirthday.Text = CType(myBirthday, String)
					Calendar1.TodaysDate = myBirthday
					Calendar1.SelectedDate = myBirthday

					mySex = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Sex"), Integer)
					If mySex = Sex.Male Then
						RadioButtonMale.Checked = True
					Else
						RadioButtonMale.Checked = False
					End If
					If mySex = Sex.Female Then
						RadioButtonFemale.Checked = True
					Else
						RadioButtonFemale.Checked = False
					End If

					myEducation = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Education"), Integer)
					If myEducation = Education.Elementary Then
						RadioButtonEducation1.Checked = True
					Else
						RadioButtonEducation1.Checked = False
					End If
					If myEducation = Education.Secondary Then
						RadioButtonEducation2.Checked = True
					Else
						RadioButtonEducation2.Checked = False
					End If
					If myEducation = Education.Professional Then
						RadioButtonEducation3.Checked = True
					Else
						RadioButtonEducation3.Checked = False
					End If
					If myEducation = Education.High Then
						RadioButtonEducation4.Checked = True
					Else
						RadioButtonEducation4.Checked = False
					End If
					If myEducation = Education.College Then
						RadioButtonEducation5.Checked = True
					Else
						RadioButtonEducation5.Checked = False
					End If
					If myEducation = Education.University Then
						RadioButtonEducation6.Checked = True
					Else
						RadioButtonEducation6.Checked = False
					End If
					If myEducation = Education.Master Then
						RadioButtonEducation7.Checked = True
					Else
						RadioButtonEducation7.Checked = False
					End If
					If myEducation = Education.Academic Then
						RadioButtonEducation8.Checked = True
					Else
						RadioButtonEducation8.Checked = False
					End If
					If myEducation = Education.Other Then
						RadioButtonEducation9.Checked = True
					Else
						RadioButtonEducation9.Checked = False
					End If

					mySalary = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Salary"), Integer)
					If mySalary = Salary.Degree1 Then
						RadioButtonSalary1.Checked = True
					Else
						RadioButtonSalary1.Checked = False
					End If
					If mySalary = Salary.Degree2 Then
						RadioButtonSalary2.Checked = True
					Else
						RadioButtonSalary2.Checked = False
					End If
					If mySalary = Salary.Degree3 Then
						RadioButtonSalary3.Checked = True
					Else
						RadioButtonSalary3.Checked = False
					End If
					If mySalary = Salary.Degree4 Then
						RadioButtonSalary4.Checked = True
					Else
						RadioButtonSalary4.Checked = False
					End If
					If mySalary = Salary.Degree5 Then
						RadioButtonSalary5.Checked = True
					Else
						RadioButtonSalary5.Checked = False
					End If

					myJob = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Job"), Integer)
					myListItem = DropDownListJob.Items.FindByValue(CType(myJob, String))
					If Not (myListItem Is Nothing) Then
						myListItem.Selected = True
					Else
						myListItem.Selected = False
					End If

					myTitle = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Title"), Integer)
					myListItem = DropDownListTitle.Items.FindByValue(CType(myTitle, String))
					If Not (myListItem Is Nothing) Then
						myListItem.Selected = True
					Else
						myListItem.Selected = False
					End If

					myInformation = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Information"), Integer)
					myListItem = DropDownListInformation.Items.FindByValue(CType(myInformation, String))
					If Not (myListItem Is Nothing) Then
						myListItem.Selected = True
					Else
						myListItem.Selected = False
					End If

					myCountry = CType(mySubscriptionUserDataSet.Tables(0).Rows(0).Item("Country"), Integer)
					myListItem = DropDownListCountry.Items.FindByValue(CType(myCountry, String))
					If Not (myListItem Is Nothing) Then
						myListItem.Selected = True
					Else
						myListItem.Selected = False
					End If
				Else
					'exception:subscription user record is empty or duplicated
				End If
			Else
				'exception:no subscription user id
			End If

		End Sub

		Private Sub RedirectPage()
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub

		Private Sub LinkButtonCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButtonCalendar.Click
			Calendar1.Visible = True
		End Sub

		Private Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
			TextBoxBirthday.Text = Calendar1.SelectedDate.Year & "/" & Microsoft.VisualBasic.Right("00" & Calendar1.SelectedDate.Month, 2) & "/" & Microsoft.VisualBasic.Right("00" & Calendar1.SelectedDate.Day, 2)
			Calendar1.Visible = False
		End Sub

		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			LoadPage()
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			If Page.IsValid Then
				SavePage()
			End If
			RedirectPage()
		End Sub
		Private Sub SavePage()
			Dim myUserDAO As New Portal_SubscriptionUserDAOExtand
			Dim mySubscriptionUserDataSet As DataSet
			Dim myName As String = ""
			Dim myEmail As String = ""
			Dim mySex As Integer = 0
			Dim myEducation As Integer = 0
			Dim mySalary As Integer = 0
			Dim myBirthday As Date = Now
			Dim myCountry As Integer = 0
			Dim myJob As Integer = 0
			Dim myTitle As Integer = 0
			Dim myInformation As Integer = 0
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim i As Integer
			Dim delimStr As String = "/-:. "
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim myUserID As String = ""
			Dim mySubscriptionID As String = ""
			Dim myAuditID As String = ""

			myName = TextBoxName.Text.Trim
			myEmail = TextBoxEmail.Text.Trim
			'
			If RadioButtonEducation1.Checked Then
				myEducation = Education.Elementary
			End If
			If RadioButtonEducation2.Checked Then
				myEducation = Education.Secondary
			End If
			If RadioButtonEducation3.Checked Then
				myEducation = Education.Professional
			End If
			If RadioButtonEducation4.Checked Then
				myEducation = Education.High
			End If
			If RadioButtonEducation5.Checked Then
				myEducation = Education.College
			End If
			If RadioButtonEducation6.Checked Then
				myEducation = Education.University
			End If
			If RadioButtonEducation7.Checked Then
				myEducation = Education.Master
			End If
			If RadioButtonEducation8.Checked Then
				myEducation = Education.Academic
			End If
			If RadioButtonEducation9.Checked Then
				myEducation = Education.Other
			End If
			'
			If RadioButtonFemale.Checked Then
				mySex = Sex.Female
			End If
			If RadioButtonMale.Checked Then
				mySex = Sex.Male
			End If
			If RadioButtonSalary1.Checked Then
				mySalary = Salary.Degree1
			End If
			If RadioButtonSalary2.Checked Then
				mySalary = Salary.Degree2
			End If
			If RadioButtonSalary3.Checked Then
				mySalary = Salary.Degree3
			End If
			If RadioButtonSalary4.Checked Then
				mySalary = Salary.Degree4
			End If
			If RadioButtonSalary5.Checked Then
				mySalary = Salary.Degree5
			End If
			'
			If TextBoxBirthday.Text.Trim <> "" Then
				tempString = TextBoxBirthday.Text.Trim
				tempArray = tempString.Split(delimiter)
				If tempArray.Length = 3 Then
					myBirthday = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
				End If
			End If
			'
			myCountry = CType(DropDownListCountry.SelectedValue, Integer)
			myJob = CType(DropDownListJob.SelectedValue, Integer)
			myTitle = CType(DropDownListTitle.SelectedValue, Integer)
			myInformation = CType(DropDownListInformation.SelectedValue, Integer)

			'update user data
			If subscriptionUserID.Trim.Length > 0 Then
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.update, Me.ToString, myUserDAO.ToString, "UpdateEntity", subscriptionUserID, "", Context.User.Identity.Name, Now)
				'log before action
				mySubscriptionUserDataSet = myUserDAO.GetEntitys(subscriptionUserID)
				If mySubscriptionUserDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.before, mySubscriptionUserDataSet)
				End If
				'actual action
				myUserDAO.UpdateEntity(subscriptionUserID, myName, myEmail, mySex, myEducation, mySalary, myBirthday, myCountry, myJob, myTitle, myInformation)
				'log after action
				mySubscriptionUserDataSet = myUserDAO.GetEntitys(subscriptionUserID)
				If mySubscriptionUserDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, mySubscriptionUserDataSet)
				End If
			Else
				'exception:no subscription user id
			End If
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