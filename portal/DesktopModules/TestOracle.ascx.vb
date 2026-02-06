Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal

	Public Class TestOracle
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl

		Private tabIndex As Integer = 0
		Private tabId As Integer = 1
		Protected WithEvents LabelResult As System.Web.UI.WebControls.Label
		Private sid As String = ""

#Region " Web Form Designer Generated Code "

		'This call is required by the Web Form Designer.
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: This method call is required by the Web Form Designer
			'Do not modify it using the code editor.
			InitializeComponent()
		End Sub

#End Region

		'*******************************************************
		'
		' The Page_Load event handler on this User Control is used to
		' obtain a DataReader of event information from the Events
		' table, and then databind the results to a templated DataList
		' server control.  It uses the ASPNET.StarterKit.PortalEventDB()
		' data component to encapsulate all data functionality.
		'
		'*******************************************************'

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

			' Obtain the list of events from the Events table
			' and bind to the DataList Control
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
			End If
			LoadPage()

		End Sub
		Private Sub LoadPage()
			LabelResult.Text = CType(GetTotalRow(""), String)
		End Sub
		Public Overloads Function GetTotalRow(ByVal schoolCode As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			myConnection.Open()
			Dim myCommand As New System.Data.OracleClient.OracleCommand("MYPROC", myConnection)
			myCommand.CommandType = CommandType.StoredProcedure
			System.Data.OracleClient.OracleCommandBuilder.DeriveParameters(myCommand)
			myCommand.Parameters(0).OracleType = OracleClient.OracleType.VarChar
			myCommand.Parameters(0).Value = "MyName"
			myCommand.Parameters(1).OracleType = OracleClient.OracleType.Number
			myCommand.ExecuteNonQuery()
			valResult = CType(myCommand.Parameters(1).Value, Integer)
			myConnection.Close()

			Return valResult
		End Function
	End Class
End Namespace