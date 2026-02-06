Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports System.Messaging

Namespace ASPNET.StarterKit.Portal

	Public Class MsgReceiver
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl

		Protected tabIndex As Integer = 0
		Protected tabId As Integer = 1
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected sid As String = ""
		Private Const QUEUE_NAME As String = ".\private$\Orders"

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
		End Sub
		Private Sub LoadPage()
			Label1.Text = ""

			Dim msqQ As MessageQueue
			Dim myMessage As Message
			Try
				' Get a MessageQueue object for the queue
				msqQ = GetMessageQueue(QUEUE_NAME)
				' Send the message to the queue
				myMessage = msqQ.Receive(New TimeSpan(0, 0, 10))

				Dim targetTypes(0) As Type
				targetTypes(0) = GetType(String)
				myMessage.Formatter = New XmlMessageFormatter(targetTypes)
				Label1.Text = CType(myMessage.Body, String)
			Catch e As Exception
				' Handle the error 
			End Try
		End Sub
		Private Function GetMessageQueue(ByVal queueName As String) As MessageQueue
			Dim msgQ As MessageQueue
			'Create the queue if it does not already exist
			If Not MessageQueue.Exists(queueName) Then
				Try
					'Create the message queue and the MessageQueue object
					msgQ = MessageQueue.Create(queueName)
				Catch CreateException As Exception
					'Error could occur creating queue if the code does
					'not have sufficient permissions to create queues.
					Throw New Exception("Error Creating Queue", CreateException)
				End Try
			Else
				Try
					msgQ = New MessageQueue(queueName)
				Catch GetException As Exception
					Throw New Exception("Error Getting Queue", GetException)
				End Try
			End If
			Return msgQ
		End Function
	End Class
End Namespace