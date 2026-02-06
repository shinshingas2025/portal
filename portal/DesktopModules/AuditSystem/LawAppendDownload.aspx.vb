Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class LawAppendDownload
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

		Private tabIndex As Integer = 0
		Private sid As String = ""
		Private moduleId As Integer = 0
		Private tabId As Integer = 0
		Private appendID As String = ""

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

			If Not (Request.Params("AppendID") Is Nothing) Then
				appendID = Request.Params("appendID")
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
		Private Sub PageLoad()
			Dim myAppendDAO As New LawAppendDAOExtand
			Dim myAppendDataSet As DataSet
			Dim myAppendID As String = ""
			Dim myAppendDownloadName As String = ""
			Dim myAppendFileName As String = ""
			Dim myAppendFileSize As Integer = 0
			Dim myAppendFileStream As FileStream

			If appendID.Trim.Length > 0 Then
				myAppendDataSet = myAppendDAO.GetEntitysByEntityID(appendID)
				If myAppendDataSet.Tables(0).Rows.Count = 1 Then
					myAppendFileName = CType(myAppendDataSet.Tables(0).Rows(0).Item("FileName"), String).Trim

					If myAppendFileName.Length > 0 Then
						myAppendDownloadName = Path.GetFileName(myAppendFileName).Substring(17)
						If File.Exists(myAppendFileName) Then
							myAppendFileStream = New FileStream(myAppendFileName, FileMode.Open)
							myAppendFileSize = CType(myAppendFileStream.Length, Integer)
							Context.Response.ContentType = "application/octet-stream"
							Context.Response.AddHeader("Content-Disposition", "attachment; filename=" & HttpUtility.UrlEncode(myAppendDownloadName, System.Text.Encoding.UTF8))
							Context.Response.AddHeader("Content-Length", CType(myAppendFileSize, String))
							Dim myFileBuffer(myAppendFileSize) As Byte
							myAppendFileStream.Read(myFileBuffer, 0, myAppendFileSize)
							myAppendFileStream.Close()
							Context.Response.BinaryWrite(myFileBuffer)
							Context.Response.End()
						End If
					End If
				Else
					'exception:append record is empty or duplicated
				End If
			Else
				'exception:append id is empty
			End If
		End Sub
	End Class
End Namespace