Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Control
	Public Class LawVariationReport
		Inherits System.Web.UI.UserControl

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

		Protected tabIndex As Integer = 0
		Protected sid As String = ""
		Protected moduleId As Integer = 0
		Protected tabId As Integer = 0

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'在這裡放置使用者程式碼以初始化網頁
			If Not (Request.Params("sid") Is Nothing) Then
				sid = Request.Params("sid")
			End If

			If Not (Request.Params("tabid") Is Nothing) Then
				tabId = Int32.Parse(Request.Params("tabid"))
			End If

			If Not (Request.Params("tabindex") Is Nothing) Then
				tabIndex = Int32.Parse(Request.Params("tabindex"))
			End If

			moduleId = GetModuleID(sender)
		End Sub
		Private Function GetModuleID(ByVal mySender As System.Object) As Integer
			Dim myControl As UserControl
			Dim myModuleControl As ASPNET.StarterKit.Portal.PortalModuleControl
			Dim myModuleID As Integer = 0

			If Not (mySender Is Nothing) Then
				Try
					myControl = CType(mySender, UserControl)
					If Not (myControl Is Nothing) Then
						Try
							myModuleControl = CType(myControl.NamingContainer, PortalModuleControl)
							If Not (myModuleControl Is Nothing) Then
								myModuleID = myModuleControl.ModuleId
							Else
								'exception:my module control is null
							End If
						Catch ex As Exception
							'exception:case failure
						End Try
					Else
						'exception:my control is null
					End If
				Catch ex As Exception
					'exception:cast failure
				End Try
			Else
				'exception:sender object is null
			End If
			Return myModuleID
		End Function
	End Class
End Namespace
