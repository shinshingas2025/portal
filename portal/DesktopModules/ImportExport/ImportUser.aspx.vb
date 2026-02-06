Imports System.IO
Imports System.Math
Namespace ASPNET.StarterKit.Portal

	Public Class ImportUser
		Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

		'此為 Web Form 設計工具所需的呼叫。
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub
		Protected WithEvents Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents UploadFileName As System.Web.UI.HtmlControls.HtmlInputFile
		Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
		Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
		Protected WithEvents LabelLog As System.Web.UI.WebControls.Label
		Protected WithEvents TextBoxLog As System.Web.UI.WebControls.TextBox
		Protected WithEvents LabelTitle As System.Web.UI.WebControls.Label
		Protected WithEvents LabelDescription As System.Web.UI.WebControls.Label
		Protected WithEvents ButtonReturn As System.Web.UI.WebControls.Button

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
		Protected pageSize As Integer = 10
		Protected totalBulletinIndividualPage As Integer = 0
		Protected currentBulletinIndividualPage As Integer = 0
		Protected totalBulletinCommunityPage As Integer = 0
		Protected currentBulletinCommunityPage As Integer = 0
		Private APLTBL_TableID As String = "2005120100000001"
		Private APSTBL_TableID As String = "2005120100000003"
		Private O_APSTBL_TableID As String = "2005120100000004"
		Dim AuditDAO As New Portal_AuditDAOExtand
		Dim ModuleStatisticDAO As New Portal_ModuleStatisticDAOExtand
		Dim AuditDetailDAO As New Portal_AuditDetailDAOExtand

		Enum SequenceType
			before = 1
			after = 2
		End Enum

		Enum LevelType
			debug = 1
			info = 2
		End Enum

		Enum ActionType
			insert = 1
			update = 2
			delete = 3
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

			If Not IsPostBack Then
				If Not (Request.UrlReferrer Is Nothing) Then
					ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
				End If
				PageLoad()
			End If
		End Sub

		Private Sub PageLoad()
			Dim myImportDAO As New Portal_ImportDAOExtand
			Dim myImportDataSet As DataSet
			LabelLog.Visible = False
			TextBoxLog.Visible = False
			TextBoxLog.Text = ""
			myImportDataSet = myImportDAO.GetEntitys(sid, moduleId)
			If myImportDataSet.Tables(0).Rows.Count = 1 Then
				LabelTitle.Text = CType(myImportDataSet.Tables(0).Rows(0).Item("Title"), String)
				LabelDescription.Text = CType(myImportDataSet.Tables(0).Rows(0).Item("Description"), String)
			Else
				'exception:import record is empty or duplicated
			End If
		End Sub

		Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
			Dim myAPLTBLDAO As New APLTBLDAOExtand
			Dim myAPSTBLDAO As New APSTBLDAOExtand
			Dim myO_APSTBLDAO As New O_APSTBLDAOExtand
			Dim myImportDAO As New Portal_ImportDAOExtand
			Dim myImportColumnDAO As New Portal_ImportColumnDAOExtand
			Dim myAPLTBLDataSet As DataSet
			Dim myAPSTBLDataSet As DataSet
			Dim myO_APSTBLDataSet As DataSet
			Dim myImportDataSet As DataSet
			Dim myImportColumnDataSet As DataSet
			Dim up_path As String = Server.MapPath("/PortalFiles/UpLoadFiles/csv")
			Dim log_path As String = Server.MapPath("/PortalFiles/UpLoadFiles/logs")
			Dim myfile As HttpPostedFile = UploadFileName.PostedFile
			Dim writer As StreamWriter
			Dim identityKey As String = Now.Year & Microsoft.VisualBasic.Right("00" & Now.Month, 2) & Microsoft.VisualBasic.Right("00" & Now.Day, 2) & Microsoft.VisualBasic.Right("00" & Now.Hour, 2) & Microsoft.VisualBasic.Right("00" & Now.Minute, 2) & Microsoft.VisualBasic.Right("00" & Now.Second, 2) & Microsoft.VisualBasic.Right("000" & Now.Millisecond, 3) & Microsoft.VisualBasic.Right("00000" & sid, 5) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(moduleId)), 8)
			Dim physicalFileName As String = up_path & "/" & identityKey & Path.GetFileName(myfile.FileName)
			Dim logFileName As String = log_path & "/" & identityKey & Path.GetFileName(myfile.FileName)
			Dim reader As StreamReader
			Dim delimStr As String = ","
			Dim delimiter As Char() = delimStr.ToCharArray()
			Dim tempString As String = ""
			Dim tempArray As String() = Nothing
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim column As Integer = 0
			Dim newID As Integer = 0
			Dim myImportID As String = ""
			Dim myDataColumn As DataColumn
			Dim myAuditID As String = ""
			'clear old file
			If File.Exists(physicalFileName) Then
				File.Delete(physicalFileName)
				'audit
				AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", physicalFileName, "", Context.User.Identity.Name, Now)
			End If
			If File.Exists(logFileName) Then
				File.Delete(logFileName)
				'audit
				AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, "System.IO.File", "Delete", logFileName, "", Context.User.Identity.Name, Now)
			End If
			'save import file
			myfile.SaveAs(physicalFileName)
			'audit
			AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myfile.ToString, "SaveAs", physicalFileName, "", Context.User.Identity.Name, Now)

			'read upload data and write log
			reader = File.OpenText(physicalFileName)
			writer = File.CreateText(logFileName)
			'audit
			AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, "System.IO.File", "CreateText", logFileName, "", Context.User.Identity.Name, Now)

			'read import data
			myImportDataSet = myImportDAO.GetEntitys(sid, moduleId)
			If myImportDataSet.Tables(0).Rows.Count = 1 Then
				myImportID = CType(myImportDataSet.Tables(0).Rows(0).Item("EntityID"), String)
				'read import column data
				myImportColumnDataSet = myImportColumnDAO.GetEntitysByImportID(myImportID)
				If myImportColumnDataSet.Tables(0).Rows.Count > 0 Then
					'combine input data
					myDataColumn = New DataColumn("ColumnData")
					myImportColumnDataSet.Tables(0).Columns.Add(myDataColumn)

					i = 0
					While reader.Peek <> -1
						tempString = reader.ReadLine
						i = i + 1
						column = 1
						If tempString.Trim <> "" Then
							tempArray = tempString.Split(delimiter)
							'For i = 0 To tempArray.Length - 1

							'Next
							'If tempArray.Length = 3 Then
							'	myDeliverDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
							'End If
							If tempArray.Length = myImportColumnDataSet.Tables(0).Rows.Count Then
								'new pk
								newID = myAPLTBLDAO.GetMaxLaborID
								If myAPSTBLDAO.GetMaxLaborID > newID Then
									newID = myAPSTBLDAO.GetMaxLaborID
								End If
								If myAPSTBLDAO.GetMaxJobID > newID Then
									newID = myAPSTBLDAO.GetMaxJobID
								End If
								If myO_APSTBLDAO.GetMaxLaborID > newID Then
									newID = myO_APSTBLDAO.GetMaxLaborID
								End If
								If myO_APSTBLDAO.GetMaxJobID > newID Then
									newID = myO_APSTBLDAO.GetMaxJobID
								End If
								newID = newID + 1

								'new record data
								For j = 0 To myImportColumnDataSet.Tables(0).Rows.Count - 1
									myImportColumnDataSet.Tables(0).Rows(j).Item("ColumnData") = CType(tempArray(j), String)
								Next
								Try
									'audit
									myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myAPLTBLDAO.ToString, "InsertEntity", CType(newID, String), "", Context.User.Identity.Name, Now)
									'log before action
									'none
									'actual action
									myAPLTBLDAO.InsertEntity(newID, myImportColumnDataSet)
									'log after action
									myAPLTBLDataSet = myAPLTBLDAO.GetEntitys(newID)
									If myAPLTBLDAtaSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.after, myAPLTBLDataSet)
									End If

									'audit
									myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myAPSTBLDAO.ToString, "InsertEntity", CType(newID, String), "", Context.User.Identity.Name, Now)
									'log before action
									'none
									'actual action
									myAPSTBLDAO.InsertEntity(newID, myImportColumnDataSet)
									'log after action
									myAPSTBLDataSet = myAPSTBLDAO.GetEntitys(newID, newID)
									If myAPSTBLDataSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.after, myAPSTBLDataSet)
									End If

									'audit
									myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.insert, Me.ToString, myO_APSTBLDAO.ToString, "InsertEntity", CType(newID, String), "", Context.User.Identity.Name, Now)
									'log before action
									'none
									'actual action
									myO_APSTBLDAO.InsertEntity(newID, myImportColumnDataSet)
									'log after action
									myO_APSTBLDataSet = myO_APSTBLDAO.GetEntitys(newID, newID)
									If myO_APSTBLDataSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.after, myO_APSTBLDataSet)
									End If
									'statistic
									ModuleStatisticDAO.InsertEntity(sid, moduleId, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, Now)
								Catch ex As Exception
									'transaction rollback
									'audit
									myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myAPLTBLDAO.ToString, "DeleteEntity", CType(newID, String), "", Context.User.Identity.Name, Now)
									'log before action
									myAPLTBLDataSet = myAPLTBLDAO.GetEntitys(newID)
									If myAPLTBLDataSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.before, myAPLTBLDataSet)
									End If
									'actual action
									myAPLTBLDAO.DeleteEntity(newID)
									'log after action
									myAPLTBLDataSet = myAPLTBLDAO.GetEntitys(newID)
									If myAPLTBLDataSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.after, myAPLTBLDataSet)
									End If

									'audit
									myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myAPSTBLDAO.ToString, "DeleteEntity", CType(newID, String), "", Context.User.Identity.Name, Now)
									'log before action
									myAPSTBLDataSet = myAPSTBLDAO.GetEntitys(newID, newID)
									If myAPSTBLDataSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.before, myAPSTBLDataSet)
									End If
									'actual action
									myAPSTBLDAO.DeleteEntity(newID, newID)
									'log after action
									myAPSTBLDataSet = myAPSTBLDAO.GetEntitys(newID, newID)
									If myAPSTBLDataSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.after, myAPSTBLDataSet)
									End If

									'audit
									myAuditID = AuditDAO.InsertEntity(sid, moduleId, 0, LevelType.info, ActionType.delete, Me.ToString, myO_APSTBLDAO.ToString, "DeleteEntity", CType(newID, String), "", Context.User.Identity.Name, Now)
									'log before action
									myO_APSTBLDataSet = myO_APSTBLDAO.GetEntitys(newID, newID)
									If myO_APSTBLDataSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.before, myO_APSTBLDataSet)
									End If
									'actual action
									myO_APSTBLDAO.DeleteEntity(newID, newID)
									'log after action
									myO_APSTBLDataSet = myO_APSTBLDAO.GetEntitys(newID, newID)
									If myO_APSTBLDataSet.Tables(0).Rows.Count = 1 Then
										AuditDetail(myAuditID, SequenceType.after, myO_APSTBLDataSet)
									End If
									'log
									writer.WriteLine("Record " & CType(i, String) & ex.Message())
								End Try
							Else
								'exception:unknown import format
								writer.WriteLine("Record " & CType(i, String) & " " & "Unknown import format! file column number =" & tempArray.Length & " and import column number=" & myImportColumnDataSet.Tables(0).Rows.Count)
							End If
						End If
					End While
				Else
					'import column is empty and do nothing
				End If
			Else
				If myImportDataSet.Tables(0).Rows.Count > 1 Then
					'exception:import record is duplicated
				Else
					'exception:import record is empty
				End If
			End If
			writer.Close()
			reader.Close()
			'prepare log control
			If File.Exists(logFileName) Then
				LabelLog.Visible = True
				TextBoxLog.Visible = True
				reader = File.OpenText(logFileName)
				TextBoxLog.Text = ""
				While reader.Peek <> -1
					tempString = reader.ReadLine().Trim
					If tempString.Length > 0 Then
						TextBoxLog.Text = TextBoxLog.Text + tempString + Chr(10) + Chr(13)
					End If
				End While
				reader.Close()
			End If
		End Sub
		Private Function GetInteger(ByVal inStr As String) As Integer
			Dim result As Integer = 0
			If inStr.Trim <> "" Then
				result = CType(inStr, Integer)
			End If
			Return result
		End Function
		Private Function GetDate(ByVal inStr As String) As Date
			Dim dateDelimStr As String = "/: -"
			Dim dateDelimiter As Char() = dateDelimStr.ToCharArray()
			Dim dateTempArray As String() = Nothing
			Dim result As Date = Nothing
			If inStr.Trim <> "" Then
				dateTempArray = inStr.Split(dateDelimiter)
				If dateTempArray.Length = 6 Then
					result = New Date(CType(dateTempArray(0), Integer), CType(dateTempArray(1), Integer), CType(dateTempArray(2), Integer), CType(dateTempArray(3), Integer), CType(dateTempArray(4), Integer), CType(dateTempArray(5), Integer))
				Else
					If dateTempArray.Length = 3 Then
						result = New Date(CType(dateTempArray(0), Integer), CType(dateTempArray(1), Integer), CType(dateTempArray(2), Integer))
					Else
						'exception: unknown date format
						Throw New Exception("Exception:Unknown datetime format:'" & inStr & "'")
					End If
				End If
			End If
			Return result
		End Function
		Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
			PageLoad()
		End Sub

		Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
			Response.Redirect(CType(ViewState("UrlReferrer"), String))
		End Sub
		Private Sub AuditDetail(ByVal myAuditID As String, ByVal mySequenceType As Integer, ByVal myDataSet As DataSet)
			Dim myColumnName As String = ""
			Dim myColumnValue As String = ""
			Dim i As Integer = 0
			If myAuditID.Trim.Length > 0 Then
				If Not (myDataSet Is Nothing) Then
					If myDataSet.Tables(0).Rows.Count = 1 Then
						For i = 0 To myDataSet.Tables(0).Columns.Count - 1
							myColumnName = myDataSet.Tables(0).Columns(i).ColumnName
							myColumnValue = CType(myDataSet.Tables(0).Rows(0).Item(myColumnName), String)
							AuditDetailDAO.InsertEntity(myAuditID, 0, mySequenceType, myColumnName, myColumnValue)
						Next
					Else
						'exception:audit target is empty or duplicated
					End If
				End If
			End If
		End Sub
	End Class
End Namespace