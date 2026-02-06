Imports System
Imports System.Text
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class ScheduleInsert
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
		Protected WithEvents ButtonInsert As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxStartTime As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxEndTime As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxNote As System.Web.UI.WebControls.TextBox

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
		Private inputTitle As String = ""
		Private inputDescription As String = ""
		Private inputNote As String = ""

		Enum ScheduleType
			Person = 1
		End Enum
		Enum EventType
			Normal = 1
		End Enum
		Enum Level
			Normal = 1
		End Enum

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

			If Not (Request.Params("inputTitle") Is Nothing) Then
				inputTitle = Request.Params("inputTitle")
			End If

			If Not (Request.Params("inputDescription") Is Nothing) Then
				inputDescription = Request.Params("inputDescription")
			End If

			If Not (Request.Params("inputNote") Is Nothing) Then
				inputNote = Request.Params("inputNote")
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
			If inputTitle.Trim.Length > 0 Then
				TextBoxTitle.Text = ToANSIString(inputTitle.Trim)
			End If
			If inputDescription.Trim.Length > 0 Then
				TextBoxDescription.Text = ToANSIString(inputDescription.Trim)
			End If
			If inputNote.Trim.Length > 0 Then
				TextBoxNote.Text = ToANSIString(inputNote.Trim)
			End If
		End Sub
		Private Sub InitialWebControl()
			TextBoxStartTime.Text = ""
			TextBoxEndTime.Text = ""
			TextBoxTitle.Text = ""
			TextBoxDescription.Text = ""
			TextBoxNote.Text = ""
		End Sub
		Private Function ToANSIString(ByVal input As String) As String
			Dim result As String
			Dim i As Integer = 0
			Dim myByteArray() As Byte
			Dim myByte As Byte
			Dim byteCount As Integer = 0
			Dim uniDecoder As Decoder = Encoding.Unicode.GetDecoder()
			Dim myCharArray() As Char
			Dim charCount As Integer = 0

			Dim charLen As Integer = 0

			input = input.Trim

			If input.Length > 0 Then
				byteCount = CType(input.Length / 2, Integer)
				myByteArray = New Byte(byteCount - 1) {}
				For i = 0 To byteCount - 1
					myByte = New Byte
					myByte = CType(Val("&H" & input.Substring(i * 2, 2)), Byte)
					myByteArray(i) = myByte
				Next
				charCount = uniDecoder.GetCharCount(myByteArray, 0, byteCount)
				myCharArray = New Char(charCount - 1) {}
				charLen = uniDecoder.GetChars(myByteArray, 0, byteCount, myCharArray, 0)
				result = New String(myCharArray)
			End If
			Return result
		End Function
		Private Sub ButtonInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsert.Click
			Dim myScheduleID As String = ""
			Dim script As String = ""

			myScheduleID = SaveScheduleData("")
			If myScheduleID.Length > 0 Then
				script = "<script>" & vbCrLf
				script += "close();" & vbCrLf
				script += "</script>" & vbCrLf
				Response.Write(script)
			Else
				'exception:insert failure
			End If
		End Sub
		Private Function SaveScheduleData(ByVal myScheduleID As String) As String
			Dim mySecurityDAO As New SecurityDAO
			Dim myScheduleDAO As New ScheduleDAOExtand
			Dim myScheduleDataSet As DataSet
			Dim mySelectDate As Date = New Date(1900, 1, 1)
			Dim mySelectedDateCollection As SelectedDatesCollection
			Dim myStartBound As Date = New Date(2100, 1, 1)
			Dim myEndBound As Date = New Date(1900, 1, 1)
			Dim myStartDate As Date = New Date(1900, 1, 1)
			Dim myEndDate As Date = New Date(1900, 1, 1)
			Dim myUserID As Integer = 0
			Dim myScheduleTypeID As Integer = 0
			Dim myEventTypeID As Integer = 0
			Dim myLevelID As Integer = 0
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myNote As String = ""
			Dim myKeyWord As String = ""
			Dim myStartTime As String = ""
			Dim myEndTime As String = ""

			myUserID = mySecurityDAO.GetUIDByLoginID(context.User.Identity.Name)
			myScheduleTypeID = ScheduleType.Person
			myEventTypeID = EventType.Normal

			mySelectedDateCollection = Calendar1.SelectedDates()
			If mySelectedDateCollection.Count > 0 Then
				For Each mySelectDate In mySelectedDateCollection
					If myStartBound > mySelectDate Then
						myStartBound = mySelectDate
					End If
					If myEndBound < mySelectDate Then
						myEndBound = mySelectDate
					End If
				Next
			Else
				myStartBound = New Date(Now.Year, Now.Month, Now.Day)
				myEndBound = New Date(Now.Year, Now.Month, Now.Day)
			End If

			myStartTime = TextBoxStartTime.Text.Trim
			If myStartTime.Length = 4 Then
				Try
					myStartDate = New Date(myStartBound.Year, myStartBound.Month, myStartBound.Day, CType(myStartTime.Substring(0, 2), Integer), CType(myStartTime.Substring(2, 2), Integer), 0)
				Catch ex As Exception
					'cast failure
					myStartDate = myStartBound
				End Try
			Else
				myStartDate = myStartBound
			End If
			myEndTime = TextBoxEndTime.Text.Trim
			If myEndTime.Length = 4 Then
				Try
					myEndDate = New Date(myEndBound.Year, myEndBound.Month, myEndBound.Day, CType(myEndTime.Substring(0, 2), Integer), CType(myEndTime.Substring(2, 2), Integer), 0)
				Catch ex As Exception
					'cast failure
					myEndDate = New Date(myEndBound.Year, myEndBound.Month, myEndBound.Day, 23, 59, 59)
				End Try
			Else
				myEndDate = New Date(myEndBound.Year, myEndBound.Month, myEndBound.Day, 23, 59, 59)
			End If

			myTitle = TextBoxTitle.Text.Trim
			myDescription = TextBoxDescription.Text.Trim
			myNote = TextBoxNote.Text.Trim

			If myScheduleID.Trim.Length > 0 Then
				'update
				myScheduleDataSet = myScheduleDAO.GetEntitysByEntityID(myScheduleID)
				If myScheduleDataSet.Tables(0).Rows.Count = 1 Then
					myScheduleDAO.UpdateEntity(myScheduleID, myScheduleTypeID, myEventTypeID, myUserID, myStartDate, myEndDate, myLevelID, myTitle, myDescription, myNote, myKeyWord)
				Else
					'exception:schedule record is empty or duplicated
				End If
			Else
				'insert
				myScheduleID = myScheduleDAO.InsertEntity(myScheduleTypeID, myEventTypeID, myUserID, myStartDate, myEndDate, myLevelID, myTitle, myDescription, myNote, myKeyWord)
			End If
			Return myScheduleID
		End Function
	End Class
End Namespace