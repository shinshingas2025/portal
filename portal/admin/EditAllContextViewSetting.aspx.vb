Imports System.IO
Imports System.Xml


Public Class EditAllContextViewSetting
	Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

	'此為 Web Form 設計工具所需的呼叫。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents TreeView1 As System.Web.UI.WebControls.TreeView
	Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
	Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
	Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
	Protected WithEvents txtState As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtSeqno As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtObjValue As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtObjName As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtPID As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtobjID As System.Web.UI.WebControls.Label
	Protected WithEvents btnTreeRefresh As System.Web.UI.WebControls.Button
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label
	Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label
	Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
	Protected WithEvents addmember As System.Web.UI.WebControls.Button

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
	Dim sid As String
	Dim moduleId As Integer = 0
	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'在這裡放置使用者程式碼以初始化網頁
		sid = CType(Session("sid"), String)
		moduleId = Int32.Parse(Request.Params("Mid"))
		Dim au As New AuthorityBO
		If Not au.checkAuthorityEdit(Context.User.Identity.Name, moduleId, 7, Me.Page) Then
			Response.Redirect("~/Admin/EditAccessDenied.aspx")
		End If
		au = Nothing


		Me.btnDelete.Attributes("onclick") = "if (window.confirm('您確認要刪除目前所選擇的項目嗎?')!=true) {event.returnValue=false;}"
		If Not IsPostBack() Then

			Call ShowTree()

            Call QueryNode(TreeView1.Nodes(0).Value)

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

        TreeView1.Nodes.Clear()
        Dim myXml As New XmlDocument
        Dim rootXmlNode As XmlNode
        myXml.Load(treeFile1)
        rootXmlNode = myXml.GetElementsByTagName("treenode1")(0)
        Dim currNode As TreeNode
        TreeView1.Nodes.Add(New TreeNode(rootXmlNode.Attributes("text").Value, rootXmlNode.Attributes("id").Value))
        currNode = TreeView1.Nodes(0)
        setTreeNodePic(currNode, rootXmlNode)
        XmltoTreeView(currNode, myXml, 2)

        ' TreeView1.TreeNodeSrc = treeFile1 ' Server.MapPath("../xml/TreeView/" & treeFile)   '"aspnetbooksTV.xml"


        TreeView1.DataBind()
        '  Call ShowAddnewButton()


    End Sub

    Sub XmltoTreeView(ByRef currNode As TreeNode, ByRef tmpXml As XmlDocument, ByVal startLevel As Integer)

        Dim tmpCnt As Integer = 0
        Dim currNode2 As TreeNode
        For Each tmpNode1 As XmlNode In tmpXml.GetElementsByTagName("treenode" & startLevel)

            currNode.ChildNodes.Add(New TreeNode(tmpNode1.Attributes("text").Value, tmpNode1.Attributes("id").Value))
            currNode2 = currNode.ChildNodes(tmpCnt)
            If tmpNode1.HasChildNodes Then
                setTreeNodePic(currNode2, tmpNode1)
                Dim secondXML As New XmlDocument
                secondXML.LoadXml("<root>" & tmpNode1.InnerXml & "</root>")

                XmltoTreeView(currNode2, secondXML, startLevel + 1)

            Else
                currNode2.ImageUrl = "/" & tmpNode1.Attributes("IMAGEURL").Value
            End If
            tmpCnt += 1
        Next

    End Sub

    Sub setTreeNodePic(ByRef currNode As TreeNode, ByVal tmpXmlnode As XmlNode)
        If tmpXmlnode.HasChildNodes Then
            If currNode.Expanded Then
                currNode.ImageUrl = "/" & tmpXmlnode.Attributes("EXPANDEDIMAGEURL").Value
            Else
                currNode.ImageUrl = "/" & tmpXmlnode.Attributes("IMAGEURL").Value
            End If
        Else
            currNode.ImageUrl = "/" & tmpXmlnode.Attributes("IMAGEURL").Value
        End If

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
        Dim LeveLCnt As Integer = 1

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
                        root = xmlDoc.SelectSingleNode("//treenode" & LeveLCnt - 1 & "[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
					End If

                    xe1 = xmlDoc.CreateElement("treenode" & LeveLCnt)               '創建一個<treenode>節點 
					xe1.SetAttribute("text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String))				'設置該節點屬性  

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
            LeveLCnt += 1

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


	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Response.Redirect("AddAllContextViewSetting.aspx?sid=" & sid & "&mid=" & moduleId & "&PID=" & txtobjID.Text.Trim)
	End Sub

	Private Function ShowDialogBox(ByVal returnValueobj As WebControls.TextBox, ByVal url As String, ByVal width As Integer, ByVal height As Integer, ByVal x As Integer, ByVal y As Integer, Optional ByVal isCenter As Boolean = False) As Boolean

		Dim Javascript As String

		Dim sfeatures As String = ""

		sfeatures &= "dialogHeight:" & height & "px;"

		sfeatures &= "dialogWidth:" & width & "px;"

		If isCenter = False Then
			sfeatures &= "dialogLeft:" & x & "px;"
			sfeatures &= "dialogTop:" & y & "px;"
		End If

		Javascript = vbCrLf & "<script>"
		Javascript &= vbCrLf & "Form1." & returnValueobj.ClientID & ".value=window.showModalDialog('../eiis/view/iFrame.aspx?url=" & url & "','','" & sfeatures & "');"
		Javascript &= vbCrLf & "</script>"

		Me.RegisterStartupScript("ShowDialog", Javascript)

	End Function
	Private Sub QueryNode(ByVal nd As String)
		Dim dm As New OrgBO
		Dim dn As New DeptExtendOrgEntity

        Dim node As TreeNode
		Dim nodeParts() As String
		Dim cnReturn As DataTable

		Dim objID As Int32

        'node = TreeView1.SelectedNode
        nodeParts = nd.Split(CType("_", Char))
		objID = Int32.Parse(nodeParts(1))
		dn.objID = CType(objID, String)

		cnReturn = dm.QueryDept(dn)


		txtobjID.Text = CType(cnReturn.Rows(0).Item("objID"), String)
		Session("DomainNodePID") = CType(cnReturn.Rows(0).Item("objID"), String)
		If CType(cnReturn.Rows(0).Item("objValue"), String) = "" Then cnReturn.Rows(0).Item("objValue") = CType(0, String)
		Session("DomainNodeValue") = cnReturn.Rows(0).Item("objValue")

		txtObjName.Text = CType(cnReturn.Rows(0).Item("objName"), String)
		txtObjValue.Text = CType(cnReturn.Rows(0).Item("objValue"), String)
		txtSeqno.Text = CType(cnReturn.Rows(0).Item("SEQNO"), String)
		txtState.Text = CType(cnReturn.Rows(0).Item("state"), String)
		txtPID.Text = CType(cnReturn.Rows(0).Item("PID"), String)
		'selsrcName.SelectedValue = CType(cnReturn.Rows(0).Item("srcName"), String)

		Call QueryDeptEmp(txtobjID.Text)


		Call ShowAddnewButton()

		'Select Case txtsrcName.Text.ToLower

		'    Case "groups"
		'        Call QueryGroups(txtObjValue.Text)


		'    Case "userinfo"

		'        Call QueryUserInfo(txtObjValue.Text)
		'End Select
		dm = Nothing
		dn = Nothing
		node = Nothing
		nodeParts = Nothing
		cnReturn = Nothing

	End Sub

	Private Sub ShowAddnewButton()
		'If selsrcName.SelectedValue.ToLower = "function" Then
		'	btnAdd.Enabled = False
		'Else
		'	btnAdd.Enabled = True
		'End If
	End Sub


	Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
		Response.Redirect("AddAllContextViewSetting.aspx?ObjID=" & txtobjID.Text.Trim & "&sid=" & sid & "&mid=" & moduleId & "&PID=" & txtobjID.Text.Trim)

	End Sub

	Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click


		Dim objORGBO As New OrgBO
		Dim flag As Boolean

		flag = objORGBO.DeleteDept(txtobjID.Text.Trim)


		' QueryFunctionDetail(Session("DomainNodeValue"))
		Call WriteXmlTree()

	End Sub


    Private Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TreeView1.SelectedNodeChanged
        Dim _NodeID As String

        _NodeID = TreeView1.SelectedValue


        Call QueryNode(_NodeID)
    End Sub


	Private Sub QueryDeptEmp(ByVal objvalue As String)

		Dim objUI As New UserInfoBO

		Dim dt As New DataTable
		Dim i As Integer


		dt = objUI.GetDeptEmp(objvalue).Tables(0)


		DataGrid1.DataSource = dt
		DataGrid1.DataBind()

		objUI = Nothing
		dt = Nothing


	End Sub


	Private Sub QueryFunctionDetail(ByVal objvalue As String)

		Dim gp As New Domains
		Dim dt As New DataTable
		Dim fn As New Functions
		fn.funNo = CType(objvalue, Integer)

		dt = gp.QueryFunction(fn)
		DataGrid1.DataSource = dt
		DataGrid1.DataBind()
		gp = Nothing
		dt = Nothing
		fn = Nothing
	End Sub

	Private Function GetTempTreeFile() As String
		Dim fn As String
		fn = "CC_" & sid & "_" & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
		Return fn
	End Function

	Private Sub QueryUserInfo(ByVal UID As String)

		Dim ur As New User
		Dim dt As New DataTable
		dt = ur.QueryUserInfo(UID)
		'DataGrid3.DataSource = dt
		'DataGrid3.DataBind()

	End Sub

	Private Sub btnTreeRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTreeRefresh.Click
		Call WriteXmlTree()
	End Sub



	Private Sub txtState_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtState.TextChanged
		Call WriteXmlTree()
	End Sub


	Private Sub UpdateItemOrder(ByVal lstItem As WebControls.ListBox)
		Dim objFunctionBO As New FunctionsBO
		objFunctionBO.UpdateFunctionOrder(lstItem)

	End Sub


	Private Sub addmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addmember.Click
		Response.Redirect("AddOrgMember.aspx?sid=" & sid & "&mid=" & moduleId & "&objid=" & txtobjID.Text.Trim)
	End Sub
End Class