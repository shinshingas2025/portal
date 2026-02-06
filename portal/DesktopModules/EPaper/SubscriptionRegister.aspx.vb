Namespace ASPNET.StarterKit.Portal
	Public Class SubscriptionRegister
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
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents Label9 As System.Web.UI.WebControls.Label
        Protected WithEvents Label10 As System.Web.UI.WebControls.Label
        Protected WithEvents Label11 As System.Web.UI.WebControls.Label
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
		Protected subscriptionID As String = ""

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
			If Not (Request.Params("subscriptionid") Is Nothing) Then
				subscriptionID = Request.Params("subscriptionid")
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
			TextBoxName.Text = ""
			TextBoxEmail.Text = ""
			TextBoxBirthday.Text = ""
			Calendar1.TodaysDate = Now.AddYears(-22)

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
			Dim mySubscriptionDAO As New Portal_SubscriptionDAOExtand
			Dim mySubscriptionListDAO As New Portal_SubscriptionListDAOExtand
			Dim mySubscriptionDataSet As DataSet
			Dim mySubscriptionUserDataSet As DataSet
			Dim mySubscriptionListDataSet As DataSet
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
			Dim mySubscriptionListID As String = ""
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

			'insert new user
			'audit
			myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, myUserDAO.ToString, "InsertEntity", myUserID, "", Context.User.Identity.Name, Now)
			'log before action
			'none
			'actual action
			myUserID = myUserDAO.InsertEntity(sid, moduleID, 0, myName, myEmail, mySex, myEducation, mySalary, myBirthday, myCountry, myJob, myTitle, myInformation, Context.User.Identity.Name, Now)
			'log after action
			mySubscriptionUserDataSet = myUserDAO.GetEntitys(myUserID)
			If mySubscriptionUserDataSet.Tables(0).Rows.Count = 1 Then
				AuditDetail(myAuditID, SequenceType.after, mySubscriptionUserDataSet)
			End If

			'get subscription id
			If subscriptionID.Length > 0 Then
				'audit
				myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, mySubscriptionListDAO.ToString, "InsertEntity", mySubscriptionListID, "", Context.User.Identity.Name, Now)
				'log before action
				'none
				'actual action
				mySubscriptionListID = mySubscriptionListDAO.InsertEntity(subscriptionID, 0, SubscriptionUserType.Subscription, myUserID, DeliverMark.Enable, Context.User.Identity.Name, Now)
				'log after action
				mySubscriptionListDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
				If mySubscriptionListDataSet.Tables(0).Rows.Count = 1 Then
					AuditDetail(myAuditID, SequenceType.after, mySubscriptionListDataSet)
				End If
			Else
				mySubscriptionDataSet = mySubscriptionDAO.GetEntitys(sid, moduleID, SubscriptionState.Enable, 1)
				If mySubscriptionDataSet.Tables(0).Rows.Count = 1 Then
					mySubscriptionID = CType(mySubscriptionDataSet.Tables(0).Rows(0).Item("EntityID"), String)
					'insert new subscription list and enable deliver mark
					'audit
					myAuditID = AuditDAO.InsertEntity(sid, moduleID, 0, LevelType.info, ActionType.insert, Me.ToString, mySubscriptionListDAO.ToString, "InsertEntity", mySubscriptionListID, "", Context.User.Identity.Name, Now)
					'log before action
					'none
					'actual action
					mySubscriptionListID = mySubscriptionListDAO.InsertEntity(mySubscriptionID, 0, SubscriptionUserType.Subscription, myUserID, DeliverMark.Enable, Context.User.Identity.Name, Now)
					'log after action
					mySubscriptionListDataSet = mySubscriptionListDAO.GetEntity(mySubscriptionListID)
					If mySubscriptionListDataSet.Tables(0).Rows.Count = 1 Then
						AuditDetail(myAuditID, SequenceType.after, mySubscriptionListDataSet)
					End If
				Else
					'exception
				End If
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