Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal

	Public Class OutletList
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents Iframe1 As System.Web.UI.HtmlControls.HtmlGenericControl
		Protected WithEvents TextBoxYear As System.Web.UI.WebControls.TextBox
		Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected WithEvents RegularExpressionValidator3 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
		Private ProcedureName As String = "SP_PORTAL_RPT01"
		Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e5%a0%b1%e8%a1%a8%2f%e7%95%a2%e6%a5%ad%e7%94%9f%e5%87%ba%e8%b7%af%e8%aa%bf%e6%9f%a5%e8%a1%a8&rc:Parameters=false"
		Private IFrameHeight As Integer = 0
		Private IFrameWeight As Integer = 0

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

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
			TextBoxYear.Text = ""
			Me.Iframe1.Attributes("src") = ""
		End Sub
		Private Sub CallProcedure(ByVal myProcedureName As String, ByVal mySchoolCode As String, ByVal myGradYear As Integer)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			myConnection.Open()
			Dim myCommand As New System.Data.OracleClient.OracleCommand(myProcedureName, myConnection)
			myCommand.CommandType = CommandType.StoredProcedure
			System.Data.OracleClient.OracleCommandBuilder.DeriveParameters(myCommand)
			myCommand.Parameters(0).OracleType = OracleClient.OracleType.VarChar
			myCommand.Parameters(0).Size = 6
			myCommand.Parameters(0).Value = mySchoolCode
			myCommand.Parameters(1).OracleType = OracleClient.OracleType.VarChar
			myCommand.Parameters(1).Size = 6
			myCommand.Parameters(1).Value = CType(myGradYear, String)
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			Dim myRandom As Integer = New Random(Now.Second).Next
			Dim mySiteDAO As New Portal_SiteDAOExtand
			Dim mySiteDataSet As DataSet
			Dim mySchoolCode As String = ""
			Dim myYear As Integer = Now.Year
			If sid.Trim.Length > 0 Then
				mySiteDataSet = mySiteDAO.GetEntitys(sid)
				If mySiteDataSet.Tables(0).Rows.Count = 1 Then
					mySchoolCode = CType(mySiteDataSet.Tables(0).Rows(0).Item("SchoolCode"), String)
				Else
					'exception:site record is empty or duplicated
				End If
			Else
				'exception:school id is empty
			End If
			If TextBoxYear.Text.Trim <> "" Then
				myYear = CType(TextBoxYear.Text.Trim, Integer)
			End If
			CallProcedure(ProcedureName, mySchoolCode, myYear)
			Me.Iframe1.Attributes("src") = IFrameSrc & "&Parameter1=" & mySchoolCode & "&Parameter2=" & myRandom & "&Gyear=" & myYear
		End Sub
	End Class
End Namespace