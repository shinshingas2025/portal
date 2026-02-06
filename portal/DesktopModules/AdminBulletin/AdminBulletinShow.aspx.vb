Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class AdminBulletinShow
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents LabelBulletinType As System.Web.UI.WebControls.Label
		Protected WithEvents LabelTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label
		Protected WithEvents LabelAnnounceUnit As System.Web.UI.WebControls.Label
		Protected WithEvents LabelEnableDate As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDisableDate As System.Web.UI.WebControls.Label
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents Label2 As System.Web.UI.WebControls.Label
		Protected WithEvents Label3 As System.Web.UI.WebControls.Label
		Protected WithEvents Label4 As System.Web.UI.WebControls.Label
		Protected WithEvents Label5 As System.Web.UI.WebControls.Label
		Protected WithEvents Label6 As System.Web.UI.WebControls.Label
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents Label12 As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolder1 As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents Label13 As System.Web.UI.WebControls.Label
		Protected WithEvents Placeholder2 As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents Label14 As System.Web.UI.WebControls.Label
		Protected WithEvents Placeholder3 As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button
		Protected WithEvents Label8 As System.Web.UI.WebControls.Label
		Protected WithEvents HyperLinkAffiliatedURL As System.Web.UI.WebControls.HyperLink

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
		Private bulletinMapID As String = ""
		Protected pageSize As Integer = 10
		Protected totalBulletinIndividualPage As Integer = 0
		Protected currentBulletinIndividualPage As Integer = 0
		Protected totalBulletinCommunityPage As Integer = 0
		Protected currentBulletinCommunityPage As Integer = 0

		Enum BulletinType
			community = 1
			individual = 2
		End Enum

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

			If Not (Request.Params("bulletinmapid") Is Nothing) Then
				bulletinMapID = Request.Params("bulletinmapid").Trim
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub


		Private Sub PageLoad()
			Dim myBulletinMapDAO As New Portal_BulletinMapDAOExtand
			Dim myBulletinDAO As New Portal_BulletinDAOExtand
			Dim myBulletinAppendDAO As New Portal_BulletinAppendDAOExtand
			Dim myBulletinMapDataSet As DataSet
			Dim myBulletinDataSet As DataSet
			Dim myBulletinAppendDataSet As DataSet
			Dim myBulletinID As String = ""
			Dim rowCount As Integer = 0
			Dim myTypeID As Integer = 0
			Dim myListItem As ListItem
			Dim myDisplayOrder As Integer = 0
			Dim myTitle As String = ""
			Dim myDescription As String = ""
			Dim myAnnounceUnit As String = ""
			Dim myEnableDate As Date = Now
			Dim myDisableDate As Date = Now
			Dim myAffiliatedURL As String = ""
			Dim myBulletinUser As String = ""
			Dim myBulletinMapUser As String = ""
			Dim myBulletinModuleID As Integer = 0
			Dim myBulletinMapModuleID As Integer = 0
			Dim myHyperLinkControl As HyperLink
			Dim i As Integer = 0
			Dim download_path As String = "/PortalFiles/UpLoadFiles/BulletinAppend"
			Dim myFileName As String = ""
			Dim myPhysicalFileName As String = ""

			'initial web control
			'initial object
			LabelTitle.Text = ""
			LabelDescription.Text = ""
			LabelAnnounceUnit.Text = ""
			LabelEnableDate.Text = ""
			LabelDisableDate.Text = ""
			HyperLinkAffiliatedURL.NavigateUrl = ""
			'
			If bulletinMapID.Length > 0 Then
				myBulletinMapDataSet = myBulletinMapDAO.GetEntity(bulletinMapID)
				If myBulletinMapDataSet.Tables(0).Rows.Count = 1 Then
					myBulletinMapUser = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
					myBulletinMapModuleID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
					myDisplayOrder = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("DisplayOrder"), Integer)
					myListItem = New ListItem(CType(myDisplayOrder, String), CType(myDisplayOrder, String))

					myBulletinID = CType(myBulletinMapDataSet.Tables(0).Rows(0).Item("BulletinID"), String).Trim
					If myBulletinID.Length > 0 Then
						myBulletinDataSet = myBulletinDAO.GetEntity(myBulletinID)
						If myBulletinDataSet.Tables(0).Rows.Count = 1 Then
							myBulletinUser = CType(myBulletinDataSet.Tables(0).Rows(0).Item("CreatedByUser"), String).Trim
							myBulletinModuleID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("ModuleID"), Integer)
							myTypeID = CType(myBulletinDataSet.Tables(0).Rows(0).Item("TypeID"), Integer)
							myTitle = CType(myBulletinDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
							myDescription = CType(myBulletinDataSet.Tables(0).Rows(0).Item("Description"), String).Trim
							myAnnounceUnit = CType(myBulletinDataSet.Tables(0).Rows(0).Item("AnnounceUnit"), String).Trim
							myEnableDate = CType(myBulletinDataSet.Tables(0).Rows(0).Item("EnableDate"), Date)
							myDisableDate = CType(myBulletinDataSet.Tables(0).Rows(0).Item("DisableDate"), Date)
							myAffiliatedURL = CType(myBulletinDataSet.Tables(0).Rows(0).Item("AffiliatedURL"), String)

							If myTypeID = BulletinType.individual Then
								LabelBulletinType.Text = "私有訊息"
							Else
								If myTypeID = BulletinType.community Then
									LabelBulletinType.Text = "公眾訊息"
								Else
									'exception:unknown bulletin type
								End If
							End If
							LabelTitle.Text = myTitle
							LabelDescription.Text = myDescription
							LabelAnnounceUnit.Text = myAnnounceUnit
							LabelEnableDate.Text = myEnableDate.Year & "/" & myEnableDate.Month & "/" & myEnableDate.Day
							LabelDisableDate.Text = myDisableDate.Year & "/" & myDisableDate.Month & "/" & myDisableDate.Day
							HyperLinkAffiliatedURL.NavigateUrl = myAffiliatedURL
						Else
							'exceptiob:bulletin record is empty or duplicated
						End If
						'prepare append file
						myBulletinAppendDataSet = myBulletinAppendDAO.GetEntitys(myBulletinID)
						If myBulletinAppendDataSet.Tables(0).Rows.Count > 0 Then
							myFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(0).Item("Name"), String)
							myPhysicalFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(0).Item("FileName"), String)

							myHyperLinkControl = New HyperLink
							myHyperLinkControl.Text = myFileName
							myHyperLinkControl.NavigateUrl = download_path & "/" & Path.GetFileName(myPhysicalFileName)

							PlaceHolder1.Controls.Add(myHyperLinkControl)
						End If
						If myBulletinAppendDataSet.Tables(0).Rows.Count > 1 Then
							myFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(1).Item("Name"), String)
							myPhysicalFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(1).Item("FileName"), String)

							myHyperLinkControl = New HyperLink
							myHyperLinkControl.Text = myFileName
							myHyperLinkControl.NavigateUrl = download_path & "/" & Path.GetFileName(myPhysicalFileName)

							Placeholder2.Controls.Add(myHyperLinkControl)
						End If
						If myBulletinAppendDataSet.Tables(0).Rows.Count > 2 Then
							myFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(2).Item("Name"), String)
							myPhysicalFileName = CType(myBulletinAppendDataSet.Tables(0).Rows(2).Item("FileName"), String)

							myHyperLinkControl = New HyperLink
							myHyperLinkControl.Text = myFileName
							myHyperLinkControl.NavigateUrl = download_path & "/" & Path.GetFileName(myPhysicalFileName)

							Placeholder3.Controls.Add(myHyperLinkControl)
						End If
					Else
						'exception:bulletin id is empty
					End If
				Else
					'exception:bulletin map is empty or duplicated
				End If
			Else
			End If
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
	End Class
End Namespace