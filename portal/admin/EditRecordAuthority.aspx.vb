Imports System.IO
Public Class EditRecordAuthority
	Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

	'此為 Web Form 設計工具所需的呼叫。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents Label2 As System.Web.UI.WebControls.Label
	Protected WithEvents Label3 As System.Web.UI.WebControls.Label
	Protected WithEvents Label4 As System.Web.UI.WebControls.Label
	Protected WithEvents CQ As System.Web.UI.WebControls.CheckBox
	Protected WithEvents GQ As System.Web.UI.WebControls.CheckBox
	Protected WithEvents GU As System.Web.UI.WebControls.CheckBox
	Protected WithEvents GD As System.Web.UI.WebControls.CheckBox
	Protected WithEvents OQ As System.Web.UI.WebControls.CheckBox
	Protected WithEvents OU As System.Web.UI.WebControls.CheckBox
	Protected WithEvents OD As System.Web.UI.WebControls.CheckBox
	Protected WithEvents CU As System.Web.UI.WebControls.CheckBox
	Protected WithEvents CD As System.Web.UI.WebControls.CheckBox
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label
	Protected WithEvents Label5 As System.Web.UI.WebControls.Label
	Protected WithEvents Label6 As System.Web.UI.WebControls.Label
	Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
	Protected WithEvents btnADD As System.Web.UI.WebControls.Button
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label
	Protected WithEvents Label8 As System.Web.UI.WebControls.Label
	Protected WithEvents Label9 As System.Web.UI.WebControls.Label
	Protected WithEvents btnOK As System.Web.UI.WebControls.Button
	Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
	Protected WithEvents Label10 As System.Web.UI.WebControls.Label
	Protected WithEvents Label11 As System.Web.UI.WebControls.Label
	Protected WithEvents NQuery As System.Web.UI.WebControls.CheckBox
	Protected WithEvents NUpdate As System.Web.UI.WebControls.CheckBox
	Protected WithEvents NDelete As System.Web.UI.WebControls.CheckBox

	'注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
	'請勿刪除或移動它。
	Private designerPlaceholderDeclaration As System.Object

	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
		'請勿使用程式碼編輯器進行修改。
		InitializeComponent()
	End Sub

#End Region
	Dim rootnum As String = "0"
	Dim sid As String = "2"
	Dim moduleId As Integer = 0
	Dim ObjID As String = ""
	Dim RecID As String = ""
	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'在這裡放置使用者程式碼以初始化網頁

		'	sid = CType(Session("sid"), String)
		'		moduleId = Int32.Parse(Request.Params("Mid"))
		'ObjID = Request.Params("ObjID")
		'RecID = Request.Params("RecID")

		ObjID = "MeetingRecord"

		RecID = "20060101000000090000000300000001"

		If Not IsPostBack() Then

			Call ShowTree()
			Call ShowGenAuthority()
			ShowSpecAuthority(ObjID, RecID)
		End If
	End Sub

	Private Sub ShowTree()
		Dim fls() As String = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/CTXT"), "CC_" & "*.xml")
		Dim treeFile1 As String

		If UBound(fls) < 1 Then
			WriteXmlTree()
			fls = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/CTXT"), "CC_" & "*.xml")
		End If
		treeFile1 = (fls(UBound(fls)))
		'  treeFile1 = (fls(0))

		TreeView1.TreeNodeSrc = treeFile1
		' TreeView1.TreeNodeSrc = Server.MapPath("../View/DomainsTree.xml")  '"aspnetbooksTV.xml"
		TreeView1.DataBind()

	End Sub

	Private Sub WriteXmlTree()

		Dim strSQL As String = ""
		Dim dt As New DataTable
		Dim i As Integer = 0
		Dim j As Integer = 0
		Dim levelNode As String = rootnum
		Dim childNode As String = ""
		Dim levelNodes() As String

		'Dim doc As New System.Xml.XPath.XPathDocument(Server.MapPath("../xml/aspnetbooksTV.xml"))

		'Dim nav As System.Xml.XPath.XPathNavigator
		'Dim nav2 As System.Xml.XPath.XPathNavigator
		'Dim expr As System.Xml.XPath.XPathExpression
		'Dim iterator As System.Xml.XPath.XPathNodeIterator

		'nav = doc.CreateNavigator()

		'expr = nav.Compile("//treenode[@id='5']")

		'iterator = nav.Select(expr)
		'ListBox1.Items.Clear()
		'While iterator.MoveNext
		'    nav2 = iterator.Current.Clone
		'    i = iterator.CurrentPosition()
		'    ListBox1.Items.Add(nav2.Value)

		'End While
		'Exit Sub

		Dim xmlDoc As New System.Xml.XmlDocument
		Dim xmlchild As System.Xml.XmlElement
		Dim root As System.Xml.XmlNode
		Dim xe1 As System.Xml.XmlElement
		Dim icount As Integer = 1
		xmlDoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><TREENODES></TREENODES>")
		Dim conn As New DBConn
		Do

			If icount = 1 Then
				strSQL = "Select * from sysOrg where PID in (" & levelNode & ")   order by seqno "
			Else
				strSQL = "Select * from sysOrg where PID in (" & levelNode & ") order by seqno "
			End If

			icount = icount + 1

			dt = conn.ReadDataTable(strSQL)

			childNode = ""
			For i = 0 To dt.Rows.Count - 1
				childNode &= "," & CType(dt.Rows(i).Item("objID"), System.String)
			Next i

			If childNode <> "" Then
				childNode = Mid(childNode, 2)
				levelNodes = childNode.Split(CType(",", Char))

				For j = 0 To UBound(levelNodes)
					' Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode(levelNodes(j)) '查找<bookstore>  
					If levelNode = rootnum Then
						root = xmlDoc.SelectSingleNode("TREENODES")

					Else
						root = xmlDoc.SelectSingleNode("//treenode[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
					End If

					xe1 = xmlDoc.CreateElement("treenode")					'創建一個<treenode>節點 
					xe1.SetAttribute("text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String))					'設置該節點屬性  

					xe1.SetAttribute("id", "N_" & CType(dt.Rows(j).Item("objID"), String))

					If CType(dt.Rows(j).Item("srcName"), String).ToLower = "joblist" Then
						xe1.SetAttribute("IMAGEURL", "../eiis/images/folder.gif")

					Else
						xe1.SetAttribute("IMAGEURL", "../eiis/images/fun.jpg")
					End If
					xe1.SetAttribute("EXPANDEDIMAGEURL", "../eiis/images/folderopen.gif")
					'xe1.InnerText = "設置文本節點 "
					root.AppendChild(xe1)

				Next j
			End If
			levelNode = childNode

		Loop Until levelNode = ""
		conn.close()
		Dim TreefileTemp As String
		TreefileTemp = GetTempTreeFile()

		viewstate("tree") = TreefileTemp

		xmlDoc.Save(Server.MapPath("/PortalFiles/xml/CTXT/" & TreefileTemp))
		' xmlDoc.Save(Server.MapPath("../View/DomainsTree.xml"))
		xmlDoc = Nothing
		root = Nothing
		xe1 = Nothing

		Call ShowTree()


	End Sub
	Private Function GetTempTreeFile() As String
		Dim fn As String
		fn = "CC_" & sid & "_" & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
		Return fn
	End Function

	Private Sub ShowSpecAuthority(ByVal ObjID As String, ByVal RecID As String)
		Dim sa As New ContextAuthBO
		Dim dt As DataTable
		dt = sa.QueryRecSpecAuthList(ObjID, RecID)

		DataGrid1.DataSource = dt
		DataGrid1.DataBind()

	End Sub

	Private Sub ShowGenAuthority()
		Dim sa As New ContextAuthBO
		Dim dt As DataTable
		Dim AuthTmp As String
		dt = sa.QueryRecGenAuthority(ObjID, RecID)

		If dt.Rows.Count > 0 Then
			AuthTmp = CType(dt.Rows(0).Item("Permission"), String)
			If Mid(AuthTmp, 1, 1) = "1" Then
				CQ.Checked = True
			Else
				CQ.Checked = False
			End If
			If Mid(AuthTmp, 2, 1) = "1" Then
				CU.Checked = True
			Else
				CU.Checked = False
			End If
			If Mid(AuthTmp, 3, 1) = "1" Then
				CD.Checked = True
			Else
				CD.Checked = False
			End If
			If Mid(AuthTmp, 4, 1) = "1" Then
				GQ.Checked = True
			Else
				GQ.Checked = False
			End If
			If Mid(AuthTmp, 5, 1) = "1" Then
				GU.Checked = True
			Else
				GU.Checked = False
			End If
			If Mid(AuthTmp, 6, 1) = "1" Then
				GD.Checked = True
			Else
				GD.Checked = False
			End If
			If Mid(AuthTmp, 7, 1) = "1" Then
				OQ.Checked = True
			Else
				OQ.Checked = False
			End If
			If Mid(AuthTmp, 8, 1) = "1" Then
				OU.Checked = True
			Else
				OU.Checked = False
			End If
			If Mid(AuthTmp, 9, 1) = "1" Then
				OD.Checked = True
			Else
				OD.Checked = False
			End If

		End If

	End Sub


	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
		Dim ca As New ContextAuthBO
		Dim flag As Boolean
		Dim Permission As String
		Permission = collectAu
		flag = ca.UpdatePermission(ObjID, RecID, permission)
	End Sub
	Private Function collectAu() As String
		Dim Permission As String = ""
		If CQ.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		If CU.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		If CD.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		If GQ.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		If GU.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		If GD.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		If OQ.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		If OU.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		If OD.Checked = True Then
			Permission &= "1"
		Else
			Permission &= "0"
		End If
		Return Permission
	End Function

	Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
		Dim authid As String
		Dim authmask As String
		If NQuery.Checked = True Then
			authmask &= "1"
		Else
			authmask &= "0"
		End If
		If NUpdate.Checked = True Then
			authmask &= "1"
		Else
			authmask &= "0"
		End If
		If NDelete.Checked = True Then
			authmask &= "1"
		Else
			authmask &= "0"
		End If

		authid = QueryNode(TreeView1.SelectedNodeIndex())
		Dim ca As New ContextAuthBO
		Dim flag As Boolean
		flag = ca.AddRecSpecAuthority(ObjID, RecID, "G", authid, authmask)

		ShowSpecAuthority(ObjID, RecID)

	End Sub
	Private Function QueryNode(ByVal nd As String) As String
		Dim dm As New Domains
		Dim dn As New DomainsNode

		Dim node As Microsoft.Web.UI.WebControls.TreeNode
		Dim nodeParts() As String
		Dim cnReturn As New DomainsNode

		Dim objID As String
		Dim sqlset As String

		node = TreeView1.GetNodeFromIndex(nd)
		nodeParts = node.ID.Split(CType("_", Char))
		objID = nodeParts(1)
		Return objID

	End Function

	Private Sub DataGrid1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.DeleteCommand
		Dim itemid As Integer
		itemid = CType(DataGrid1.DataKeys(e.Item.ItemIndex), Integer)
		Dim ca As New ContextAuthBO
		Dim flag As Boolean
		flag = ca.DeleteSpecAuthority(itemid)
		ShowSpecAuthority(ObjID, RecID)
	End Sub
End Class
