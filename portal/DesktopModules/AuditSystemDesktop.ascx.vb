Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO
Imports ASPNET.StarterKit.Portal.AuditSystem.Control

Namespace ASPNET.StarterKit.Portal

	Public Class AuditSystemDesktop
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl

		Protected tabIndex As Integer = 0
		Protected tabId As Integer = 1
		Protected WithEvents PlaceHolderWorkDesktop As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents AjaxPanelPlace As MagicAjax.UI.Controls.AjaxPanel
		Protected WithEvents LinkButtonTest As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton5 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton6 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton7 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton8 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton9 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton14 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton15 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton2 As System.Web.UI.WebControls.LinkButton
		Protected WithEvents Linkbutton3 As System.Web.UI.WebControls.LinkButton
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
				InitialWebControl()
				LoadPage()
			End If
		End Sub
		Private Sub LoadPage()
		End Sub
		Private Sub InitialWebControl()
			'Dim myLiteralControl As LiteralControl
			Dim myImage As System.Web.UI.WebControls.Image

			PlaceHolderWorkDesktop.Controls.Clear()

			'myLiteralControl = New LiteralControl
			'myLiteralControl.Text = "初始畫面"
			myImage = New System.Web.UI.WebControls.Image
			myImage.ImageUrl = "~/images/WorkDesktopFG.gif"
			PlaceHolderWorkDesktop.Controls.Add(myImage)
		End Sub
		Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Dim myMenuControl As WebControl
			Dim myParentID As String = ""

			myMenuControl = CType(sender, WebControl)
			If Not (myMenuControl Is Nothing) Then
				myParentID = myMenuControl.Attributes("WorkID").Trim
				FillWorkDesktop(myParentID)
			Else
				'exception:menu control is null
			End If
		End Sub
		Private Sub FillWorkDesktop(ByVal myParentID As String)
			Dim myWorkDAO As New ControlDefinitionDAOExtand
			Dim myWorkDataSet As DataSet
			Dim myWorkCount As Integer = 0
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim myWorkControl As UserControl
			Dim myDesktopSourceFile As String = ""
			Dim myMaxRowPosition As Integer = 0
			Dim myMaxColumnPosition As Integer = 0
			Dim myRowPosition As Integer = 0
			Dim myColumnPosition As Integer = 0
			Dim myTable As HtmlTable
			Dim myTableRow As HtmlTableRow
			Dim myTableCell As HtmlTableCell

			If myParentID.Length > 0 Then
				PlaceHolderWorkDesktop.Controls.Clear()

				myTable = New HtmlTable
				myTable.Width = "100%"
				myTable.CellPadding = 0
				myTable.CellSpacing = 0
				myTable.Border = 0

				myWorkCount = myWorkDAO.GetTotalRowByParentID(myParentID)
				If myWorkCount > 0 Then
					myWorkDataSet = myWorkDAO.GetEntitysByParentID(myParentID)
					'get max row and column
					For i = 0 To myWorkCount - 1
						myRowPosition = CType(myWorkDataSet.Tables(0).Rows(i).Item("RowPosition"), Integer)
						myColumnPosition = CType(myWorkDataSet.Tables(0).Rows(i).Item("COlumnPosition"), Integer)

						If myRowPosition > myMaxRowPosition Then
							myMaxRowPosition = myRowPosition
						End If
						If myColumnPosition > myMaxColumnPosition Then
							myMaxColumnPosition = myColumnPosition
						End If
					Next
					'initial make-up table
					If myMaxRowPosition > 0 Then
						For i = 0 To myMaxRowPosition - 1
							myTableRow = New HtmlTableRow

							If myMaxColumnPosition > 0 Then
								For j = 0 To myMaxColumnPosition - 1
									myTableCell = New HtmlTableCell
									myTableRow.Cells.Add(myTableCell)
								Next
							End If

							myTable.Controls.Add(myTableRow)
						Next
					End If
					'prepare user control
					For i = 0 To myWorkCount - 1
						myRowPosition = CType(myWorkDataSet.Tables(0).Rows(i).Item("RowPosition"), Integer)
						myColumnPosition = CType(myWorkDataSet.Tables(0).Rows(i).Item("COlumnPosition"), Integer)
						myDesktopSourceFile = CType(myWorkDataSet.Tables(0).Rows(i).Item("DesktopSourceFile"), String).Trim
						Try
							myWorkControl = CType(Page.LoadControl(myDesktopSourceFile), UserControl)
						Catch ex As Exception
							'exception:load work control failure
						End Try
						If Not (myWorkControl Is Nothing) Then
							If myRowPosition > 0 And myColumnPosition > 0 Then
								myTable.Rows(myRowPosition - 1).Cells(myColumnPosition - 1).Controls.Add(myWorkControl)
							Else
								'row or column position out of bound
							End If
						Else
							'exception:work control is null
						End If
					Next
				End If
				PlaceHolderWorkDesktop.Controls.Add(myTable)
			Else
				'exception:parent id is empty
			End If
		End Sub
	End Class
End Namespace