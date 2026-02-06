Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
'Imports System.Data.OracleClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal

	Public Class ImportExport
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl

		Protected tabIndex As Integer = 0
		Protected tabId As Integer = 1
		Protected WithEvents LabelImportTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelExportTitle As System.Web.UI.WebControls.Label
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents Label2 As System.Web.UI.WebControls.Label
		Protected sid As String = ""

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
				LoadPage()
			End If
			'DataGrid1.DataSource = ConnectToOracle()
			'DataGrid1.DataBind()
			'InsertToOracle()
			'DeleteToOracle()
		End Sub
		Private Sub LoadPage()
			Dim myImportDAO As New Portal_ImportDAOExtand
			Dim myExportDAO As New Portal_ExportDAOExtand
			Dim myImportDataSet As DataSet
			Dim myExportDataSet As DataSet
			myImportDataSet = myImportDAO.GetEntitys(sid, ModuleId)
			If myImportDataSet.Tables(0).Rows.Count = 1 Then
				LabelImportTitle.Text = CType(myImportDataSet.Tables(0).Rows(0).Item("Title"), String)
			Else
				'exception:import record is empty or duplicated
			End If
			myExportDataSet = myExportDAO.GetEntitys(sid, ModuleId)
			If myExportDataSet.Tables(0).Rows.Count = 1 Then
				LabelExportTitle.Text = CType(myExportDataSet.Tables(0).Rows(0).Item("Title"), String)
			Else
				'exception:import record is empty or duplicated
			End If
		End Sub
		Public Function ConnectToOracle() As DataSet
			'user id=cla01;data source=toy;password=cla01
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim myDataSet As New DataSet
			myDataSet = myAPLTBLDAO.GetEntitys(1)
			Return myDataSet
		End Function
		Public Sub InsertToOracle()
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim myrand As Integer = Now.Second + 100
			myAPLTBLDAO.InsertEntity(myrand, "7", "7", Now, "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", "7", Now, "7", "7", "7", "7", "7", Now, "7", "7", "7", Now, "7", Now, "7", "7", "7", Now, Now)
		End Sub
		Private Sub DeleteToOracle()
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			myAPLTBLDAO.DeleteEntity(58)
		End Sub

	End Class
End Namespace