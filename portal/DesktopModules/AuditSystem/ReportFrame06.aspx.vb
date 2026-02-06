Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class ReportFrame06
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents Iframe1 As System.Web.UI.HtmlControls.HtmlGenericControl
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents Label2 As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxStartDate As System.Web.UI.WebControls.TextBox
		Protected WithEvents TextBoxEndDate As System.Web.UI.WebControls.TextBox

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
		'Private ProcedureName As String = ""
		Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e5%a0%b1%e8%a1%a8%2f%e6%b3%95%e8%a6%8f%e5%91%bd%e4%bb%a4%e7%95%b0%e5%8b%95%e7%9b%ae%e9%8c%84&rc:Parameters=false"
		Private IFrameHeight As Integer = 0
		Private IFrameWeight As Integer = 0
		Private Const MainOfficeCodeGroupID As String = "2006010100000003"
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
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myNormalCodeDataSet As DataSet
			Dim myNormalCodeCount As Integer = 0
			Dim i As Integer = 0
			Dim myListItem As ListItem
			Dim myCodeName As String = ""
			Dim myCodeID As String = ""

			TextBoxStartDate.Text = ""
			TextBoxEndDate.Text = ""
			'DropDownListGroup.Items.Clear()
			myNormalCodeCount = myNormalCodeDAO.GetTotalRowByGroupID(MainOfficeCodeGroupID)
			If myNormalCodeCount > 0 Then
				myNormalCodeDataSet = myNormalCodeDAO.GetEntitysByGroupID(MainOfficeCodeGroupID)
				For i = 0 To myNormalCodeCount - 1
					myCodeID = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("EntityID"), String)
					myCodeName = CType(myNormalCodeDataSet.Tables(0).Rows(i).Item("Name"), String)

					myListItem = New ListItem
					myListItem.Value = myCodeID
					myListItem.Text = myCodeName

					'DropDownListGroup.Items.Add(myListItem)
				Next
			End If

			Me.Iframe1.Attributes("src") = ""
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			Dim myStartDate As String = ""
			Dim myEndDate As String = ""
			Dim myRandom As Integer = New Random(Now.Second).Next
			Dim myGroupID As String = ""

			If TextBoxStartDate.Text.Trim <> "" Then
				myStartDate = TextBoxStartDate.Text.Trim
			End If

			If TextBoxEndDate.Text.Trim <> "" Then
				myEndDate = TextBoxEndDate.Text.Trim
			End If

			'myGroupID = DropDownListGroup.SelectedValue

			Me.Iframe1.Attributes("src") = IFrameSrc & "&StartDate=" & myStartDate & "&EndDate=" & myEndDate & "&MyRandomArg=" & myRandom
		End Sub
	End Class
End Namespace