Imports System.IO
Public Class ImportALLDomains

    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents linkOK As System.Web.UI.WebControls.LinkButton
    Protected WithEvents chklist As System.Web.UI.WebControls.CheckBoxList

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region
    Dim sid As String
    Dim rootnum As String = "0"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack() Then
            WriteXmlTree()
            Call ShowTree()
        End If
        Me.Panel1.Style("overflow") = "auto"
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
        Do
            Dim conn As New DBConn
            If icount = 1 Then
                strSQL = "Select * from sysDomains where PID in (" & levelNode & ") order by seqno "
            Else
                strSQL = "Select * from sysDomains where PID in (" & levelNode & ") order by seqno "
            End If

            icount = icount + 1

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
                    If levelNode = rootnum Then
                        root = xmlDoc.SelectSingleNode("TREENODES")

                    Else
                        root = xmlDoc.SelectSingleNode("//treenode[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
                    End If

                    xe1 = xmlDoc.CreateElement("treenode") '創建一個<treenode>節點 
                    xe1.SetAttribute("text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String)) '設置該節點屬性  

                    xe1.SetAttribute("id", "N_" & CType(dt.Rows(j).Item("objID"), String))

                    If CType(dt.Rows(j).Item("srcName"), String).ToLower = "joblist" Then
                        xe1.SetAttribute("IMAGEURL", "../images/folder.gif")

                    Else
                        xe1.SetAttribute("IMAGEURL", "../images/fun.jpg")
                    End If
                    xe1.SetAttribute("EXPANDEDIMAGEURL", "../images/folderopen.gif")
                    'xe1.InnerText = "設置文本節點 "
                    root.AppendChild(xe1)

                Next j
            End If
            levelNode = childNode

        Loop Until levelNode = ""
        Dim TreefileTemp As String
        TreefileTemp = GetTempTreeFile()

        viewstate("tree") = TreefileTemp

        xmlDoc.Save(Server.MapPath("/PortalFiles/xml/ImportAllDomains/" & TreefileTemp))
        ' xmlDoc.Save(Server.MapPath("../View/DomainsTree.xml"))
        xmlDoc = Nothing
        root = Nothing
        xe1 = Nothing

        Call ShowTree()


    End Sub

    Private Function GetTempTreeFile() As String
        Dim fn As String
        fn = "AllD_" & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
        Return fn
    End Function
    Private Sub ShowTree()
        Dim fls() As String = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/ImportAllDomains"), "AllD_*.xml")
        Dim treeFile1 As String

        If UBound(fls) < 1 Then
            WriteXmlTree()
            fls = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/ImportAllDomains"), "AllD_*.xml")
        End If
        treeFile1 = (fls(UBound(fls)))
        '  treeFile1 = (fls(0))

        TreeView1.TreeNodeSrc = treeFile1
        ' TreeView1.TreeNodeSrc = Server.MapPath("../View/DomainsTree.xml")  '"aspnetbooksTV.xml"
        TreeView1.DataBind()


    End Sub

    Private Sub linkOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkOK.Click
        QueryNode(TreeView1.SelectedNodeIndex())
    End Sub
    Private Sub QueryNode(ByVal nd As String)
        Dim dm As New Domains
        Dim dn As New DomainsNode

        Dim node As Microsoft.Web.UI.WebControls.TreeNode
        Dim nodeParts() As String
        Dim cnReturn As New DomainsNode

        Dim objID As Int32
        Dim sqlset As String

        node = TreeView1.GetNodeFromIndex(nd)
        nodeParts = node.ID.Split(CType("_", Char))
        objID = Int32.Parse(nodeParts(1))
        Dim cm As New Community
        Dim fa As New FunctionAuthority


        If chklist.Items(0).Selected = True Then
            fa.Ilevel = 7
        End If
        If chklist.Items(1).Selected = True Then
            fa.Dlevel = 7
        End If
        If chklist.Items(2).Selected = True Then
            fa.Ulevel = 7
        End If
        If chklist.Items(3).Selected = True Then
            fa.Qlevel = 7
        End If
        If chklist.Items(4).Selected = True Then
            fa.Clevel = 7
        End If

        fa.CommID = CType(Request.QueryString("UID"), Integer)
        fa.DomainID = objID

        cm.AddMapFunction(CType(Request.QueryString("UID"), Integer), objID)
        cm.UpdateFunctionAuthority(fa)

        Call returnValue()

    End Sub
    Private Sub returnValue(Optional ByVal value As String = "")
        Dim js As String
        js &= "<script>"
        js &= "window.returnValue='" & value & "';"
        js &= "window.close();"
        js &= "</script>"
        Me.RegisterStartupScript("showDialogBox", js)


    End Sub
End Class
