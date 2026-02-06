Imports System.IO
Imports System.Xml

Namespace ASPNET.StarterKit.Portal

	Public MustInherit Class MenuControl
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl
        Protected WithEvents TreeView1 As System.Web.UI.WebControls.TreeView
        Protected WithEvents Iframe1 As System.Web.UI.HtmlControls.HtmlIframe

        Protected WithEvents myXmlDataSource As XmlDataSource
#Region " Web Form Designer Generated Code "

		'This call is required by the Web Form Designer.
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: This method call is required by the Web Form Designer
			'Do not modify it using the code editor.
			InitializeComponent()
		End Sub

#End Region

		'*******************************************************
		'
		' The Page_Load event handler on this User Control is used to
		' obtain a DataSet of announcement information from the Announcements
		' table, and then databind the results to a templated DataList
		' server control.  It uses the ASPNET.StarterKit.PortalAnnouncementsDB()
		' data component to encapsulate all data functionality.
		'
		'*******************************************************


		Dim ggPID As Integer
		Dim rootnum As String
		Dim rootnum1 As String
		Dim sid As String
		Dim UserID As String

		Property Url() As String
			Get
				Return CType(viewstate("Url"), String)
			End Get
			Set(ByVal Value As String)
				viewstate("Url") = Value
			End Set
		End Property

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'Dim au As New AuthorityBO
            '   If Not au.checkAuthorityEdit(Context.User.Identity.Name, ModuleId, 7, Me.Page) Then
            '   Response.Redirect("~/Admin/EditAccessDenied.aspx")
            '  End If
            'au = Nothing
            If Context.User.Identity.Name.Trim = "" Or Context.User.Identity.Name Is Nothing Then
                Exit Sub
            End If
            If Not IsPostBack Then
                mainProcess(Context.User.Identity.Name.Trim)
                ShowTree()

            End If

            

        End Sub


		Private Sub showContext()
			Dim iFrameSrc As String = Url
			Me.Iframe1.Attributes("src") = iFrameSrc
        End Sub

        Private Function GetTempTreeFile() As String

            Dim treeFile1 As String
            Dim fn As String
            Dim i As Integer
            Dim j As String
            Dim max As Integer
            Dim maxNum As String
            max = 0
            Dim fls() As String = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/ModuleUser"), Context.User.Identity.Name & "_" & "*.xml")

            If UBound(fls) < 0 Then
                max = 0
            Else

                For i = 0 To UBound(fls)
                    j = (Left(Right(fls(i), 9), 5))
                    If CType(j, Integer) > max Then
                        max = CType(j, Integer)
                    End If
                Next

                max = max + 1
            End If
            maxNum = Right("00000" & CStr(max), 5)

            fn = Context.User.Identity.Name & "_" & maxNum & ".xml"


            Return fn
        End Function

        Private Sub ShowTree()
            Dim treeFile1 As String
            Dim fn As String
            Dim i As Integer
            Dim j As String
            Dim max As Int64
            max = 0
            Dim fls() As String = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/ModuleUser"), Context.User.Identity.Name & "_" & "*.xml")

            If UBound(fls) < 0 Then
                WriteXmlTree()
            End If
            Dim fls1() As String = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/ModuleUser"), Context.User.Identity.Name & "_" & "*.xml")

            For i = 0 To UBound(fls1)
                j = (Left(Right(fls1(i), 9), 5))
                If CType(j, Int64) > max Then
                    max = CType(j, Integer)
                End If
            Next
            Dim maxNum As String
            max = max
            maxNum = Right("00000" & CStr(max), 5)

            treeFile1 = Server.MapPath("/Portalfiles/xml/ModuleUser/" & Context.User.Identity.Name & "_" & maxNum & ".xml")

            '  treeFile1 = (fls(0))
            ' Dim myxmlDatasrc As New XmlDataSource
            'myxmlDatasrc.DataFile = treeFile1
            TreeView1.Nodes.Clear()
            Dim myXml As New XmlDocument
            Dim rootXmlNode As XmlNode
            myXml.Load(treeFile1)
            rootXmlNode = myXml.GetElementsByTagName("TREENODES")(0)
            Dim currNode As TreeNode
            TreeView1.Nodes.Add(New TreeNode("功能清單", "0_0"))
            currNode = TreeView1.Nodes(0)

            currNode.ImageUrl = "/images/folder.gif"
           
            XmltoTreeView(currNode, myXml, 1)

            'TreeView1.TreeNodeSrc = treeFile1
            ' TreeView1.TreeNodeSrc = Server.MapPath("../View/DomainsTree.xml")  '"aspnetbooksTV.xml"
            TreeView1.DataBind()

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
                    currNode.ImageUrl = "/" & tmpXmlnode.Attributes("EXPANDEDIMAGEURL").Value
                End If
            Else
                currNode.ImageUrl = "/" & tmpXmlnode.Attributes("IMAGEURL").Value
            End If

        End Sub

        'Sub setTreeNodePic(ByRef currNode As TreeNode, ByVal hasChild As Boolean)
        '    If hasChild Then
        '        If currNode.Expanded Then
        '            currNode.ImageUrl = "/images/folderopen.gif"
        '        Else
        '            currNode.ImageUrl = "/images/folder.gif"
        '        End If
        '    Else
        '        currNode.ImageUrl = "/images/user.gif"
        '    End If

        'End Sub

        Private Sub QueryNode(ByVal nd As String)

            'Dim node As Microsoft.Web.UI.WebControls.TreeNode
            Dim node As TreeNode
            Dim nodeParts() As String

            Dim objID As Int32

            node = TreeView1.SelectedNode
            nodeParts = node.Value.Split(CType("_", Char))
            objID = Int32.Parse(nodeParts(1))
            Dim dt As DataTable

            Dim fnn As New FunctionsBO
            dt = fnn.getFunctionByCommunityObjID(objID)

            If dt.Rows.Count > 0 Then
                Url = "../" & CType(dt.Rows(0).Item("LogicalFilePath"), String).Trim & CType(dt.Rows(0).Item("ExeFileName"), String).Trim
                showContext()

            End If




        End Sub

        'Private Sub TreeView1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs) Handles TreeView1.SelectedIndexChange

        '    Dim _NodeID As String

        '    _NodeID = e.NewNode

        '    Call QueryNode(_NodeID)

        'End Sub

        Private Sub mainProcess(ByVal loginid As String)

            Dim strSQL As String = ""
            Dim dt As DataTable
            Dim PID As Integer
            Dim objID As Integer
            objID = getObjIDbyLoginID(loginid)

            UserID = loginid

            strSQL = "Select * from sysCommunity where ObjID= " & objID
            Dim conn As New DBConn
            dt = conn.ReadDataTable(strSQL)

            PID = CType(dt.Rows(0).Item("PID"), Integer)

            Dim strObjID As String = ""
            strObjID = objID & "," & PID
            While PID <> 0

                strSQL = "Select * from sysCommunity where ObjID= " & PID
                dt = conn.ReadDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    PID = CType(dt.Rows(0).Item("PID"), Integer)
                    strObjID &= "," & PID
                Else
                    PID = 0
                End If

            End While
            Dim exeSP As String
            strObjID = strObjID & "," & CType(objID, String)
            exeSP = "EIISgetAuthorityByLoginID_SP '" & UserID & "','" & strObjID & "'"
            conn.ExecuteNonQuery(exeSP)
            conn.close()


            WriteXmlTree()
        End Sub



        Private Function getCurrentXmlfile() As String
            Dim treeFile1 As String

            Dim fls() As String = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/ModuleUser"), Context.User.Identity.Name & "_" & "*.xml")

            If UBound(fls) < 1 Then
                WriteXmlTree()
                fls = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/ModuleUser"), Context.User.Identity.Name & "_" & "*.xml")
            End If

            treeFile1 = (fls(UBound(fls)))
            Return treeFile1
        End Function


        Private Sub WriteXmlTree()

            Dim strSQL As String = ""
            Dim dt As New DataTable
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim levelNode As String = CType(ModuleId, String)
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
            xmlDoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><TREENODES></TREENODES>")

            Dim LeveLCnt As Integer = 1
            Do
                Dim conn As New DBConn
                strSQL = "Select distinct * from vAuthoryFun where  loginID='" & UserID & "' and  PID in (" & levelNode & ")"
                dt = conn.ReadDataTable(strSQL)
                conn.close()
                childNode = ""
                For i = 0 To dt.Rows.Count - 1
                    childNode &= "," & CType(dt.Rows(i).Item("objID"), System.String)
                Next i

                If childNode <> "" Then
                    childNode = Mid(childNode, 2)
                    levelNodes = childNode.Split(CType(",", Char))



                    For j = 0 To UBound(levelNodes)
                        ' Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode(levelNodes(j)) '查找<bookstore>  


                        If levelNode = CType(ModuleId, String) Then
                            root = xmlDoc.SelectSingleNode("TREENODES")

                        Else
                            root = xmlDoc.SelectSingleNode("//treenode" & LeveLCnt - 1 & "[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
                        End If

                        xe1 = xmlDoc.CreateElement("treenode" & LeveLCnt)      '創建一個<treenode>節點 

                        xe1.SetAttribute("text", CType(dt.Rows(j).Item("objName"), String))       '設置該節點屬性  
                        If CType(dt.Rows(j).Item("srcName"), String).ToLower = "groups" Then

                            xe1.SetAttribute("IMAGEURL", "images/folder.gif")


                        Else
                            xe1.SetAttribute("IMAGEURL", "images/User.gif")

                        End If
                        xe1.SetAttribute("EXPANDEDIMAGEURL", "images/folderopen.gif")

                        xe1.SetAttribute("id", "N_" & CType(dt.Rows(j).Item("objID"), String))

                        xe1.SetAttribute("Qlevel", CType(dt.Rows(j).Item("Qlevel"), String))
                        xe1.SetAttribute("Ilevel", CType(dt.Rows(j).Item("Ilevel"), String))
                        xe1.SetAttribute("Ulevel", CType(dt.Rows(j).Item("Ulevel"), String))
                        xe1.SetAttribute("Dlevel", CType(dt.Rows(j).Item("Dlevel"), String))
                        xe1.SetAttribute("Clevel", CType(dt.Rows(j).Item("Clevel"), String))



                        'xe1.InnerText = "設置文本節點 "
                        root.AppendChild(xe1)

                    Next j
                End If
                levelNode = childNode
                LeveLCnt += 1

            Loop Until levelNode = ""

            Dim TreefileTemp As String
            TreefileTemp = GetTempTreeFile()

            viewstate("tree") = TreefileTemp

            xmlDoc.Save(Server.MapPath("/PortalFiles/xml/ModuleUser/" & TreefileTemp))

            root = Nothing
            xe1 = Nothing

            xmlDoc = Nothing


            'Call CopyFile("../View/TreeTemp.xml", "../View/Tree.xml")




        End Sub
        Private Function getObjIDbyLoginID(ByVal loginid As String) As Integer

            Dim strsQL As String
            Dim UID As Integer

            strsQL = "Select * from sysSecurity where loginID='" & loginid & "'"
            Dim conn As New DBConn
            Dim dt As DataTable
            dt = conn.ReadDataTable(strsQL)
            If dt.Rows.Count > 0 Then
                UID = CType(dt.Rows(0).Item("UID"), Integer)
            End If
            conn.close()
            Return UID

        End Function


        Private Sub TreeView1_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TreeView1.SelectedNodeChanged

                Dim _NodeID As String

            _NodeID = TreeView1.SelectedValue


                Call QueryNode(_NodeID)

        End Sub

        
    End Class
End Namespace
