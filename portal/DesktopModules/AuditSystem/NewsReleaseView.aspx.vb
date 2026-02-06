Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class NewsReleaseView
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents LabelTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelOpening As System.Web.UI.WebControls.Label
		Protected WithEvents LabelContent As System.Web.UI.WebControls.Label
		Protected WithEvents LabelEnding As System.Web.UI.WebControls.Label
		Protected WithEvents LabelReleaseUnit As System.Web.UI.WebControls.Label
		Protected WithEvents LabelLiaisoner As System.Web.UI.WebControls.Label
		Protected WithEvents LabelNewsDate As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolderAppend As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ButtonPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonNext As System.Web.UI.WebControls.Button

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
		Private newsID As String = ""

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

			If Not (Request.Params("newsID") Is Nothing) Then
				newsID = Request.Params("newsID")
			End If

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				InitialWebControl()
				PageLoad()
			End If
		End Sub
		Private Sub PageLoad()
			Dim myNewsDAO As New NewsReleaseDAOExtand
			Dim myNewsDataSet As DataSet
			Dim myTitle As String = ""
			Dim myOpening As String = ""
			Dim myEnding As String = ""
			Dim myReleaseUnitID As String = ""
			Dim myLiaisonerID As String = ""
			Dim myNewsDate As Date = New Date(1900, 1, 1)
			Dim myContentDAO As New NewsReleaseContentDAOExtand
			Dim myContentDataSet As DataSet
			Dim myContentCount As Integer = 0
			Dim myContentNumber As String = ""
			Dim myContent As String = ""
			Dim myAppendDAO As New NewsReleaseAppendDAOExtand
			Dim myAppendDataSet As DataSet
			Dim myAppendCount As Integer = 0
			Dim myAppendID As String = ""
			Dim myAppendName As String = ""
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myHtmlAnchor As HtmlAnchor
			Dim myLiteral As LiteralControl
			Dim i As Integer = 0

			If newsID.Trim.Length > 0 Then
				myNewsDataSet = myNewsDAO.GetEntitysByEntityID(newsID)
				If myNewsDataSet.Tables(0).Rows.Count = 1 Then
					myTitle = CType(myNewsDataSet.Tables(0).Rows(0).Item("Title"), String).Trim
					myOpening = CType(myNewsDataSet.Tables(0).Rows(0).Item("Opening"), String).Trim
					myEnding = CType(myNewsDataSet.Tables(0).Rows(0).Item("Ending"), String).Trim
					myReleaseUnitID = CType(myNewsDataSet.Tables(0).Rows(0).Item("ReleaseUnitID"), String).Trim
					myLiaisonerID = CType(myNewsDataSet.Tables(0).Rows(0).Item("LiaisonerID"), String).Trim
					myNewsDate = CType(myNewsDataSet.Tables(0).Rows(0).Item("NewsDate"), Date)

					LabelTitle.Text = myTitle
					LabelOpening.Text = myOpening
					LabelEnding.Text = myEnding
					LabelReleaseUnit.Text = myNormalCodeDAO.GetNameByEntityID(myReleaseUnitID)
					LabelLiaisoner.Text = myNormalCodeDAO.GetNameByEntityID(myLiaisonerID)
					LabelNewsDate.Text = myNewsDate.Year & "/" & myNewsDate.Month & "/" & myNewsDate.Day
					If LabelNewsDate.Text = "1900/1/1" Then
						LabelNewsDate.Text = ""
					End If

					myContentCount = myContentDAO.GetTotalRowByNewsReleaseID(newsID)
					If myContentCount > 0 Then
						myContentDataSet = myContentDAO.GetEntitysByNewsReleaseID(newsID)
						For i = 0 To myContentCount - 1
							myContentNumber = CType(myContentDataSet.Tables(0).Rows(i).Item("ContentNumber"), String)
							myContent = CType(myContentDataSet.Tables(0).Rows(i).Item("Content"), String)

							If i = 0 Then
								LabelContent.Text = myContentNumber & "　" & myContent
							Else
								LabelContent.Text += "<br>" & myContentNumber & "　" & myContent
							End If
						Next
					End If

					myAppendCount = myAppendDAO.GetTotalRowByNewsReleaseID(newsID)
					If myAppendCount > 0 Then
						myAppendDataSet = myAppendDAO.GetEntitysByNewsReleaseID(newsID)
						For i = 0 To myAppendCount - 1
							myAppendID = CType(myAppendDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
							myAppendName = CType(myAppendDataSet.Tables(0).Rows(i).Item("Name"), String).Trim

							myHtmlAnchor = New HtmlAnchor
							myHtmlAnchor.HRef = "NewsReleaseAppendDownload.aspx?AppendID=" & myAppendID
							myHtmlAnchor.InnerText = myAppendName

							If i = 0 Then
								PlaceHolderAppend.Controls.Add(myHtmlAnchor)
							Else
								myLiteral = New LiteralControl
								myLiteral.Text = "<br>"

								PlaceHolderAppend.Controls.Add(myLiteral)
								PlaceHolderAppend.Controls.Add(myHtmlAnchor)
							End If
						Next
					End If
				Else
					'exception:news record is empty or duplicated
				End If
			Else
				'exception:news id is empty
			End If
		End Sub
		Private Sub InitialWebControl()
			LabelTitle.Text = "'"
			LabelOpening.Text = "'"
			LabelEnding.Text = ""
			LabelContent.Text = ""
			LabelReleaseUnit.Text = ""
			LabelLiaisoner.Text = ""
			LabelNewsDate.Text = ""
			PlaceHolderAppend.Controls.Clear()
		End Sub

		Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
			Dim myNewsDAO As New NewsReleaseDAOExtand
			Dim myNewsDataSet As DataSet
			Dim myCategorizationID As String = ""
			Dim i As Integer = 0
			Dim myItemID As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False

			If newsID.Trim.Length > 0 Then
				myPreviousID = newsID
				myNewsDataSet = myNewsDAO.GetEntitysByEntityID(newsID)
				If myNewsDataSet.Tables(0).Rows.Count = 1 Then
					myCategorizationID = CType(myNewsDataSet.Tables(0).Rows(0).Item("CategorizationID"), String)
					myItemID = CType(myNewsDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)

					myNewsDataSet = myNewsDAO.GetItemIDByCategorizationID(myCategorizationID)
					If myNewsDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myNewsDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myNewsDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							Else
								'save previous id
								myPreviousID = CType(myNewsDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							End If
						Next
						If bFound = True Then
							Response.Redirect("~/DesktopModules/AuditSystem/NewsReleaseView.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&newsID=" & myPreviousID)
						End If
					End If
				Else
					'exception:news record is empty or duplicated
				End If
			Else
				'exception:news id is empty
			End If
		End Sub

		Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
			Dim myNewsDAO As New NewsReleaseDAOExtand
			Dim myNewsDataSet As DataSet
			Dim myCategorizationID As String = ""
			Dim i As Integer = 0
			Dim myItemID As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False

			If newsID.Trim.Length > 0 Then
				myNextID = newsID
				myNewsDataSet = myNewsDAO.GetEntitysByEntityID(newsID)
				If myNewsDataSet.Tables(0).Rows.Count = 1 Then
					myCategorizationID = CType(myNewsDataSet.Tables(0).Rows(0).Item("CategorizationID"), String)
					myItemID = CType(myNewsDataSet.Tables(0).Rows(0).Item("ItemID"), Integer)
					myNewsDataSet = myNewsDAO.GetItemIDByCategorizationID(myCategorizationID)
					If myNewsDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myNewsDataSet.Tables(0).Rows.Count - 1
							If myItemID = CType(myNewsDataSet.Tables(0).Rows(i).Item("ItemID"), Integer) Then
								bFound = True
								Exit For
							End If
						Next
						If bFound = True Then
							'save next id
							If i + 1 < myNewsDataSet.Tables(0).Rows.Count Then
								myNextID = CType(myNewsDataSet.Tables(0).Rows(i + 1).Item("EntityID"), String)
							Else
								myNextID = CType(myNewsDataSet.Tables(0).Rows(myNewsDataSet.Tables(0).Rows.Count - 1).Item("EntityID"), String)
							End If
							Response.Redirect("~/DesktopModules/AuditSystem/NewsReleaseView.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&newsID=" & myNextID)
						End If
					End If
				Else
					'exception:news record is empty or duplicated
				End If
			Else
				'exception:news id is empty
			End If
		End Sub
	End Class
End Namespace