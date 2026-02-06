Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal
	Public Class ScheduleDesktop
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl
		Protected tabIndex As Integer = 0
		Protected tabId As Integer = 1
		Protected WithEvents DataListResult As System.Web.UI.WebControls.DataList
		Protected sid As String = ""
		Enum ScheduleType
			Person = 1
		End Enum
		Enum EventType
			Normal = 1
		End Enum
		Enum Level
			Normal = 1
		End Enum

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents myDataList As System.Web.UI.WebControls.DataList

		'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
		'請勿刪除或移動它。
		Private designerPlaceholderDeclaration As System.Object

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
			'請勿使用程式碼編輯器進行修改。
			InitializeComponent()
		End Sub

#End Region

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If Not (Request.Params("tabid") Is Nothing) Then
				tabId = Int32.Parse(Request.Params("tabid"))
			End If
			If Not (Request.Params("tabindex") Is Nothing) Then
				tabIndex = Int32.Parse(Request.Params("tabindex"))
			End If
			If Not (Request.Params("sid") Is Nothing) Then
				sid = CType(Request.Params("sid"), String)
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				LoadPage()
			End If
		End Sub
		Private Sub LoadPage()
			Dim mySecurityDAO As New SecurityDAO
			Dim myScheduleDAO As New ScheduleDAOExtand
			Dim myScheduleDataSet As DataSet
			Dim myScheduleID As String = ""
			Dim myStartDate As Date
			Dim myEndDate As Date
			Dim myStartBound As Date
			Dim myEndBound As Date
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myNote As String = ""
			Dim myUserID As Integer = 0
			Dim myDataColumn As DataColumn
			Dim myStartDateString As String = ""
			Dim myEndDateString As String = ""
			Dim i As Integer = 0

			myUserID = mySecurityDAO.GetUIDByLoginID(Context.User.Identity.Name)
			myStartBound = New Date(Now.Year, Now.Month, Now.Day, 0, 0, 0)
			myEndBound = New Date(Now.Year, Now.Month, Now.Day, 23, 59, 59)

			myScheduleDataSet = myScheduleDAO.GetEntitysByScheduleTypeIDAndEventTypeIDAndUserID(ScheduleType.Person, EventType.Normal, myUserID, myStartBound, myEndBound)

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
	End Class
End Namespace