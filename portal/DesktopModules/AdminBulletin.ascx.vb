Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class AdminBulletin
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl
		Protected tabIndex As Integer = 0
		Protected tabId As Integer = 1
		Protected sid As String = ""
		Protected AdminPortalID As String = ConfigurationSettings.AppSettings("AdminPortalID")
		Enum BulletinType
			community = 1
			individual = 2
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
			End If
			LoadPage()
		End Sub
		Private Sub LoadPage()
			Dim myBulletinMapDAO As New ASPNET.StarterKit.Portal.Portal_BulletinMapDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myDataColumn As DataColumn
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinDataSet As DataSet
			Dim i As Integer = 0
			Dim rowCount As Integer = 0
			Dim myBulletinID As String = ""
			Dim myTitle As String = ""
			Dim myAnnounceUnit As String = ""
			If AdminPortalID.Trim.Length > 0 Then
				'get bulletin map data
				myBulletinMapDataSet = myBulletinMapDAO.GetEntitysBySchoolIDAndTypeID(AdminPortalID, BulletinType.community, 6)
				myDataList.DataSource = myBulletinMapDataSet
				myDataList.DataBind()
			Else
				'exception:admin portal id is empty
			End If
		End Sub
	End Class
End Namespace