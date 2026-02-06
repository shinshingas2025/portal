Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class ScheduleAdmin
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
		Protected WithEvents Calendar2 As System.Web.UI.WebControls.Calendar
		Protected WithEvents ButtonInsert As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonUpdate As System.Web.UI.WebControls.Button
		Protected WithEvents TextBoxStartTime As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxEndTime As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxTitle As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxDescription As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxQuery As System.Web.UI.WebControls.TextBox
		Protected WithEvents DataListResult As System.Web.UI.WebControls.DataList
		Protected WithEvents ButtonQuery As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonDelete As System.Web.UI.WebControls.Button
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
		Private scheduleID As String = ""

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

			If Not (Request.Params("scheduleID") Is Nothing) Then
				scheduleID = Request.Params("scheduleID")
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
			Dim mySecurityDAO As New SecurityDAO
			Dim myScheduleDAO As New ScheduleDAOExtand
			Dim myScheduleDataSet As DataSet
			Dim myScheduleID As String = ""
			Dim myScheduleCount As Integer = 0
			Dim i As Integer = 0
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
			Dim myStartDateString As String = ""
			Dim myEndDateString As String = ""
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myNote As String = ""
			Dim myKeyWord As String = ""
			Dim myQueryString As String = ""
			Dim myDataColumn As DataColumn

			If scheduleID.Trim.Length > 0 Then
				myScheduleDataSet = myScheduleDAO.GetEntitysByEntityID(scheduleID)
				FillScheduleData(myScheduleDataSet)
			Else
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
					myEndBound = New Date(myEndBound.Year, myEndBound.Month, myEndBound.Day, 23, 59, 59)
				Else
					myStartBound = New Date(Now.Year, Now.Month, Now.Day, 0, 0, 0)
					myEndBound = New Date(Now.Year, Now.Month, Now.Day, 23, 59, 59)
				End If

				myQueryString = TextBoxQuery.Text.Trim
				If myQueryString.Length > 0 Then
					myScheduleDataSet = myScheduleDAO.GetEntitysByScheduleTypeIDAndEventTypeIDAndUserIDAndQueryString(myScheduleTypeID, myEventTypeID, myUserID, myQueryString, myStartBound, myEndBound)
				Else
					myScheduleDataSet = myScheduleDAO.GetEntitysByScheduleTypeIDAndEventTypeIDAndUserID(myScheduleTypeID, myEventTypeID, myUserID, myStartBound, myEndBound)
				End If
			End If

			myDataColumn = New DataColumn("StartDateString")
			myScheduleDataSet.Tables(0).Columns.Add(myDataColumn)
			myDataColumn = New DataColumn("EndDateString")
			myScheduleDataSet.Tables(0).Columns.Add(myDataColumn)

			If myScheduleDataSet.Tables(0).Rows.Count > 0 Then
				For i = 0 To myScheduleDataSet.Tables(0).Rows.Count - 1
					myStartDate = CType(myScheduleDataSet.Tables(0).Rows(i).Item("StartDate"), Date)
					myEndDate = CType(myScheduleDataSet.Tables(0).Rows(i).Item("EndDate"), Date)

					myStartDateString = myStartDate.Year & "/" & myStartDate.Month & "/" & myStartDate.Day & " " & Microsoft.VisualBasic.Right("00" & CType(myStartDate.Hour, String), 2) & ":" & Microsoft.VisualBasic.Right("00" & CType(myStartDate.Minute, String), 2) & ":" & Microsoft.VisualBasic.Right("00" & CType(myStartDate.Second, String), 2)
					If myStartDateString = "1900/1/1 00:00:00" Then
						myStartDateString = ""
					End If
					myEndDateString = myEndDate.Year & "/" & myEndDate.Month & "/" & myEndDate.Day & " " & Microsoft.VisualBasic.Right("00" & CType(myEndDate.Hour, String), 2) & ":" & Microsoft.VisualBasic.Right("00" & CType(myEndDate.Minute, String), 2) & ":" & Microsoft.VisualBasic.Right("00" & CType(myEndDate.Second, String), 2)
					If myEndDateString = "1900/1/1 00:00:00" Then
						myEndDateString = ""
					End If

					myScheduleDataSet.Tables(0).Rows(i).Item("StartDateString") = myStartDateString
					myScheduleDataSet.Tables(0).Rows(i).Item("EndDateString") = myEndDateString
				Next
			End If

			DataListResult.DataSource = myScheduleDataSet
			DataListResult.DataBind()
		End Sub
		Private Sub InitialWebControl()
			TextBoxStartTime.Text = ""
			TextBoxEndTime.Text = ""
			TextBoxTitle.Text = ""
			TextBoxDescription.Text = ""
			TextBoxNote.Text = ""
			TextBoxQuery.Text = ""
		End Sub
		Private Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
			Dim myStartDate As Date
			Dim myEndDate As Date
			Dim myScheduleDAO As ScheduleDAOExtand
			Dim myScheduleDataSet As DataSet

			If scheduleID.Trim.Length > 0 Then
				myScheduleDAO = New ScheduleDAOExtand
				myScheduleDataSet = myScheduleDAO.GetEntitysByEntityID(scheduleID)
				If myScheduleDataSet.Tables(0).Rows.Count = 1 Then
					myStartDate = CType(myScheduleDataSet.Tables(0).Rows(0).Item("StartDate"), Date)
					myEndDate = CType(myScheduleDataSet.Tables(0).Rows(0).Item("EndDate"), Date)

					myStartDate = New Date(myStartDate.Year, myStartDate.Month, myStartDate.Day)
					myEndDate = New Date(myEndDate.Year, myEndDate.Month, myEndDate.Day)

					If (e.Day.Date >= myStartDate) And (e.Day.Date <= myEndDate) Then
						e.Cell.BorderStyle = BorderStyle.Solid
					End If
				Else
					'exception:schedule record is empty or duplicated
				End If
			End If
		End Sub
		Private Sub Calendar2_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar2.DayRender
			Dim myScheduleDAO As New ScheduleDAOExtand
			Dim mySecurityDAO As New SecurityDAO
			Dim myScheduleDataSet As DataSet
			Dim i As Integer
			Dim myScheduleID As String
			Dim myTable As HtmlTable
			Dim myTableRow As HtmlTableRow
			Dim myTableCell As HtmlTableCell
			Dim myLabel As Label
			Dim myHyperLink As HyperLink
			Dim myLiteral As Literal
			Dim myTitle As String
			Dim myStartBound As Date
			Dim myEndBound As Date
			Dim myUserID As Integer

			e.Cell.Controls.Clear()
			e.Cell.VerticalAlign = VerticalAlign.Top

			myTable = New HtmlTable
			myTable.Width = "100%"
			myTable.CellPadding = 1
			myTable.CellSpacing = 1
			myTable.Border = 1
			myTable.BgColor = "#FFFFFF"
			myTable.Style("border-collapse") = "collapse"
			'myTable.Attributes("style") = "border-collapse: collapse"
			'header
			myTableRow = New HtmlTableRow
			myTableRow.BgColor = "#6688DD"
			myTableCell = New HtmlTableCell
			myTableCell.Align = "center"

			myLabel = New Label
			myLabel.Text = CType(e.Day.Date.Day, String)
			myTableCell.Controls.Add(myLabel)

			myTableRow.Cells.Add(myTableCell)
			myTable.Controls.Add(myTableRow)
			'content
			myTableRow = New HtmlTableRow
			myTableCell = New HtmlTableCell

			myStartBound = New Date(e.Day.Date.Year, e.Day.Date.Month, e.Day.Date.Day, 0, 0, 0)
			myEndBound = New Date(e.Day.Date.Year, e.Day.Date.Month, e.Day.Date.Day, 23, 59, 59)
			myUserID = mySecurityDAO.GetUIDByLoginID(Context.User.Identity.Name)

			myScheduleDataSet = myScheduleDAO.GetEntitysByScheduleTypeIDAndEventTypeIDAndUserID(ScheduleType.Person, EventType.Normal, myUserID, myStartBound, myEndBound)
			If myScheduleDataSet.Tables(0).Rows.Count > 0 Then
				For i = 0 To myScheduleDataSet.Tables(0).Rows.Count - 1
					myScheduleID = CType(myScheduleDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myTitle = CType(myScheduleDataSet.Tables(0).Rows(i).Item("Title"), String)

					If i > 0 Then
						myLiteral = New Literal
						myLiteral.Text = "<BR>"

						myTableCell.Controls.Add(myLiteral)
					End If

					myHyperLink = New HyperLink
					myHyperLink.ToolTip = myTitle
					myHyperLink.Text = "●" & Microsoft.VisualBasic.Left(myTitle, 8)
					myHyperLink.NavigateUrl = "ScheduleAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&scheduleID=" & myScheduleID

					myTableCell.Controls.Add(myHyperLink)
				Next
			Else
				myLiteral = New Literal
				myLiteral.Text = "<BR>"

				myTableCell.Controls.Add(myLiteral)
			End If

			myTableRow.Cells.Add(myTableCell)
			myTable.Controls.Add(myTableRow)

			e.Cell.Controls.Add(myTable)
		End Sub

		Private Sub ButtonQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuery.Click
			scheduleID = ""
			PageLoad()
		End Sub

		Private Sub ButtonInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInsert.Click
			Dim myScheduleID As String = ""
			myScheduleID = SaveScheduleData("")
			If myScheduleID.Length > 0 Then
				Response.Redirect("~/DesktopModules/AuditSystem/ScheduleAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&scheduleID=" & myScheduleID)
			Else
				'exception:insert failure
			End If
		End Sub

		Private Sub ButtonUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click
			If scheduleID.Trim.Length > 0 Then
				If SaveScheduleData(scheduleID).Trim.Length > 0 Then
					Response.Redirect("~/DesktopModules/AuditSystem/ScheduleAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&scheduleID=" & scheduleID)
				End If
			Else
				'exception:schedule id is empty
			End If
		End Sub
		Private Sub FillScheduleData(ByVal myScheduleDataSet As DataSet)
			Dim myStartDate As Date = New Date(1900, 1, 1)
			Dim myEndDate As Date = New Date(1900, 1, 1)
			Dim myStartBound As Date = New Date(1900, 1, 1)
			Dim myEndBound As Date = New Date(1900, 1, 1)
			Dim myStartTime As String = ""
			Dim myEndTime As String = ""
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myNote As String = ""

			If Not (myScheduleDataSet Is Nothing) Then
				If myScheduleDataSet.Tables(0).Rows.Count = 1 Then
					myStartDate = CType(myScheduleDataSet.Tables(0).Rows(0).Item("StartDate"), Date)
					myEndDate = CType(myScheduleDataSet.Tables(0).Rows(0).Item("EndDate"), Date)
					myTitle = CType(myScheduleDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
					myDescription = CType(myScheduleDataSet.Tables(0).Rows(0).Item("Description"), String).Trim
					myNote = CType(myScheduleDataSet.Tables(0).Rows(0).Item("Note"), String).Trim

					TextBoxStartTime.Text = Microsoft.VisualBasic.Right("00" & CType(myStartDate.Hour, String), 2) & Microsoft.VisualBasic.Right("00" & CType(myStartDate.Minute, String), 2)
					TextBoxEndTime.Text = Microsoft.VisualBasic.Right("00" & CType(myEndDate.Hour, String), 2) & Microsoft.VisualBasic.Right("00" & CType(myEndDate.Minute, String), 2)
					TextBoxTitle.Text = myTitle
					TextBoxDescription.Text = myDescription
					TextBoxNote.Text = myNote
				Else
					'exception:schedule record is empty or duplicated
				End If
			Else
				'exception:schedule record is null
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

		Private Sub DeleteScheduleData(ByVal myScheduleID As String)
			Dim myScheduleDAO As New ScheduleDAOExtand
			Dim myScheduleDataSet As DataSet

			If myScheduleID.Trim.Length > 0 Then
				myScheduleDataSet = myScheduleDAO.GetEntitysByEntityID(myScheduleID)
				If myScheduleDataSet.Tables(0).Rows.Count = 1 Then
					myScheduleDAO.DeleteEntity(myScheduleID)
				End If
			Else
				'exception:schedule id is empty
			End If
		End Sub
		Protected Sub DataListResult_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataListResult.SelectedIndexChanged
			Dim isCheck As Boolean
			Dim myScheduleID As String = ""
			Dim myDataListItem As DataListItem

			For Each myDataListItem In DataListResult.Items
				isCheck = CType(myDataListItem.FindControl("RadioButton1"), RadioButton).Checked
				If isCheck Then
					myScheduleID = CType(DataListResult.DataKeys(myDataListItem.ItemIndex), String)
					If myScheduleID.Trim.Length > 0 Then
						Response.Redirect("~/DesktopModules/AuditSystem/ScheduleAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&scheduleID=" & myScheduleID)
					Else
						'exception:schedule id is empty
					End If
				End If
			Next
		End Sub

		Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
			If scheduleID.Trim.Length > 0 Then
				DeleteScheduleData(scheduleID)
				Response.Redirect("~/DesktopModules/AuditSystem/ScheduleAdmin.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex)
			Else
				'exception:schedule id is empty
			End If
		End Sub
	End Class
End Namespace