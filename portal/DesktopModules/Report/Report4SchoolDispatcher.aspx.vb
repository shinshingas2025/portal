Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Report4SchoolDispatcher
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub

		'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
		'請勿刪除或移動它。
		Private designerPlaceholderDeclaration As System.Object

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
			'請勿使用程式碼編輯器進行修改。
			InitializeComponent()
		End Sub

#End Region
		Private ReportID As String = ""
		Private SchoolID As String = ""

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			If Not (Request.Params("sid") Is Nothing) Then
				SchoolID = CType(Request.Params("sid"), String)
			End If
			If Not (Request.Params("ReportID") Is Nothing) Then
				ReportID = CType(Request.Params("ReportID"), String)
			End If
			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
			End If
			If ReportID.Trim.Length > 0 Then
				LoadPage()
			Else
				'exception:report id is empty
			End If
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
		Private Sub LoadPage()
			Dim myReportSchoolDAO As New Portal_ReportSchoolDAOExtand
			Dim mySiteDAO As New Portal_SiteDAOExtand
			Dim myReportSchoolDataSet As DataSet
			Dim mySiteDataSet As DataSet
			Dim myReportName As String = ""
			Dim myProcedureName As String = ""
			Dim mySchoolCode As String = ""
			myReportSchoolDataSet = myReportSchoolDAO.GetEntityByEntityID(ReportID)
			If myReportSchoolDataSet.Tables(0).Rows.Count = 1 Then
				myReportName = CType(myReportSchoolDataSet.Tables(0).Rows(0).Item("ReportName"), String)
				myProcedureName = CType(myReportSchoolDataSet.Tables(0).Rows(0).Item("ProcedureName"), String)
				If myProcedureName.Trim.Length > 0 Then
					If SchoolID.Trim.Length > 0 Then
						mySiteDataSet = mySiteDAO.GetEntitys(SchoolID)
						If mySiteDataSet.Tables(0).Rows.Count = 1 Then
							mySchoolCode = CType(mySiteDataSet.Tables(0).Rows(0).Item("SchoolCode"), String)
							CallProcedure(myProcedureName, mySchoolCode)
						Else
							'exception: site record is empty or duplicated
						End If
					Else
						'exception:school id is empty
					End If
				End If
				If myReportName.Trim.Length > 0 Then
					Response.Redirect(myReportName)
				End If
			Else
				'exception:report normal record is empty or duplicated
			End If
		End Sub
		Private Sub CallProcedure(ByVal myProcedureName As String, ByVal mySchoolCode As String)
			Dim myGradYear As String = ""
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			myConnection.Open()
			Dim myCommand As New System.Data.OracleClient.OracleCommand(myProcedureName, myConnection)
			myCommand.CommandType = CommandType.StoredProcedure
			System.Data.OracleClient.OracleCommandBuilder.DeriveParameters(myCommand)
			myCommand.Parameters(0).OracleType = OracleClient.OracleType.VarChar
			myCommand.Parameters(0).Size = 6
			myCommand.Parameters(0).Value = mySchoolCode
			myGradYear = CType(Now.Year, String)
			myCommand.Parameters(1).OracleType = OracleClient.OracleType.VarChar
			myCommand.Parameters(1).Size = 6
			myCommand.Parameters(1).Value = myGradYear
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace