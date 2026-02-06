Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module

	Public Class LawViewFrame
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label7 As System.Web.UI.WebControls.Label
		Protected WithEvents LabelName As System.Web.UI.WebControls.Label
		Protected WithEvents LabelContent As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDiscussion As System.Web.UI.WebControls.Label
		Protected WithEvents LabelConstitutionDate As System.Web.UI.WebControls.Label
		Protected WithEvents PlaceHolderAppend As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents ButtonPrevious As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonNext As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonParent As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonChild As System.Web.UI.WebControls.Button

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
		Private lawID As String = ""
		Private parentID As String = ""

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

			If Not (Request.Params("lawID") Is Nothing) Then
				lawID = Request.Params("lawID")
			End If

			If Not (Request.Params("parentID") Is Nothing) Then
				parentID = Request.Params("parentID")
			Else
				parentID = ""
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
			Dim myLawDAO As New LawDAOExtand
			Dim myLawDataSet As DataSet
			Dim myParentID As String = ""
			Dim myName As String = ""
			Dim myDiscussionID As String = ""
			Dim myConstitutionDate As Date = New Date(1900, 1, 1)
			Dim myContentDAO As New LawContentDAOExtand
			Dim myContentDataSet As DataSet
			Dim myContentCount As Integer = 0
			Dim myContentNumber As String = ""
			Dim myContent As String = ""
			Dim myAppendDAO As New LawAppendDAOExtand
			Dim myAppendDataSet As DataSet
			Dim myAppendCount As Integer = 0
			Dim myAppendID As String = ""
			Dim myAppendName As String = ""
			Dim myNormalCodeDAO As New NormalCodeDAOExtand
			Dim myHtmlAnchor As HtmlAnchor
			Dim myLiteral As LiteralControl
			Dim i As Integer = 0

			If lawID.Trim.Length > 0 Then
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					myName = CType(myLawDataSet.Tables(0).Rows(0).Item("Name"), String).Trim
					myDiscussionID = CType(myLawDataSet.Tables(0).Rows(0).Item("DiscussionID"), String).Trim
					myConstitutionDate = CType(myLawDataSet.Tables(0).Rows(0).Item("ConstitutionDate"), Date)
					myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String).Trim
					'update parent id
					If myParentID.Length > 0 Then
						parentID = myParentID
					End If

					LabelName.Text = myName
					LabelDiscussion.Text = myNormalCodeDAO.GetNameByEntityID(myDiscussionID)
					LabelConstitutionDate.Text = myConstitutionDate.Year & "/" & myConstitutionDate.Month & "/" & myConstitutionDate.Day
					If LabelConstitutionDate.Text = "1900/1/1" Then
						LabelConstitutionDate.Text = ""
					End If

					myContentCount = myContentDAO.GetTotalRowByLawID(lawID)
					If myContentCount > 0 Then
						myContentDataSet = myContentDAO.GetEntitysByLawID(lawID)
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

					myAppendCount = myAppendDAO.GetTotalRowByLawID(lawID)
					If myAppendCount > 0 Then
						myAppendDataSet = myAppendDAO.GetEntitysByLawID(lawID)
						For i = 0 To myAppendCount - 1
							myAppendID = CType(myAppendDataSet.Tables(0).Rows(i).Item("EntityID"), String).Trim
							myAppendName = CType(myAppendDataSet.Tables(0).Rows(i).Item("Name"), String).Trim

							myHtmlAnchor = New HtmlAnchor
							myHtmlAnchor.HRef = "LawAppendDownload.aspx?AppendID=" & myAppendID
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
					'exception:law record is empty or duplicated
				End If
			Else
				'exception:law id is empty
			End If
		End Sub
		Private Sub InitialWebControl()
			LabelName.Text = "'"
			LabelContent.Text = ""
			LabelDiscussion.Text = ""
			LabelConstitutionDate.Text = ""
			PlaceHolderAppend.Controls.Clear()
		End Sub

		Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim i As Integer = 0
			Dim myPreviousID As String = ""
			Dim bFound As Boolean = False

			If lawID.Trim.Length > 0 Then
				myPreviousID = lawID
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					'read total entity id
					myLawDataSet = myLawDAO.GetEntityIDByParentID(parentID)
					If myLawDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myLawDataSet.Tables(0).Rows.Count - 1
							If lawID = CType(myLawDataSet.Tables(0).Rows(i).Item("EntityID"), String) Then
								bFound = True
								Exit For
							Else
								'save previous id
								myPreviousID = CType(myLawDataSet.Tables(0).Rows(i).Item("EntityID"), String)
							End If
						Next
						If bFound = True Then
							Response.Redirect("~/DesktopModules/AuditSystem/LawViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myPreviousID)
						End If
					End If
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub

		Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim i As Integer = 0
			Dim myNextID As String = ""
			Dim bFound As Boolean = False

			If lawID.Trim.Length > 0 Then
				myNextID = lawID
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					'read total entity id
					myLawDataSet = myLawDAO.GetEntityIDByParentID(parentID)
					If myLawDataSet.Tables(0).Rows.Count > 0 Then
						For i = 0 To myLawDataSet.Tables(0).Rows.Count - 1
							If lawID = CType(myLawDataSet.Tables(0).Rows(i).Item("EntityID"), String) Then
								bFound = True
								Exit For
							End If
						Next
						If bFound = True Then
							'save next id
							If i + 1 < myLawDataSet.Tables(0).Rows.Count Then
								myNextID = CType(myLawDataSet.Tables(0).Rows(i + 1).Item("EntityID"), String)
							Else
								myNextID = CType(myLawDataSet.Tables(0).Rows(myLawDataSet.Tables(0).Rows.Count - 1).Item("EntityID"), String)
							End If
							Response.Redirect("~/DesktopModules/AuditSystem/LawViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & parentID & "&lawID=" & myNextID)
						End If
					End If
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub

		Private Sub ButtonParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParent.Click
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim i As Integer = 0
			Dim myParentID As String = ""
			Dim myPreviousID As String = ""

			If lawID.Trim.Length > 0 Then
				myPreviousID = lawID
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String)
					'read parent record
					myLawDataSet = myLawDAO.GetEntitysByEntityID(myParentID)
					If myLawDataSet.Tables(0).Rows.Count = 1 Then
						myPreviousID = CType(myLawDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String)
					Else
						'top of tree
						myPreviousID = "2006010100000001"
						myParentID = "0"
					End If
					Response.Redirect("~/DesktopModules/AuditSystem/LawViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & myParentID & "&lawID=" & myPreviousID)
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub

		Private Sub ButtonChild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonChild.Click
			Dim myLawDataSet As DataSet
			Dim myLawDAO As New LawDAOExtand
			Dim i As Integer = 0
			Dim myParentID As String = ""
			Dim myNextID As String = ""

			If lawID.Trim.Length > 0 Then
				myNextID = lawID
				myParentID = parentID
				myLawDataSet = myLawDAO.GetEntitysByEntityID(lawID)
				If myLawDataSet.Tables(0).Rows.Count = 1 Then
					'read one of child
					myLawDataSet = myLawDAO.GetEntitysByParentID(lawID, 1)
					If myLawDataSet.Tables(0).Rows.Count = 1 Then
						myNextID = CType(myLawDataSet.Tables(0).Rows(0).Item("EntityID"), String)
						myParentID = CType(myLawDataSet.Tables(0).Rows(0).Item("ParentID"), String)
					End If
					Response.Redirect("~/DesktopModules/AuditSystem/LawViewFrame.aspx?sid=" & sid & "&mid=" & moduleId & "&tabid=" & tabId & "&tabindex=" & tabIndex & "&parentID=" & myParentID & "&lawID=" & myNextID)
				Else
					'exception:record is empty or duplicated
				End If
			Else
				'exception:id is empty
			End If
		End Sub
	End Class
End Namespace