Public Class AuthorityTreeView
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents IFRAME1 As System.Web.UI.HtmlControls.HtmlGenericControl

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Dim LoginID As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Session("iurl") Is Nothing Then Session("iurl") = "../view/Welcome.aspx"
        Me.IFRAME1.Attributes("src") = CType(Session("iurl"), String)  '"CommunityView.aspx"
        If Not IsPostBack() Then

            LoginID = CType(Session("LoginID"), String)
            Call GetAuthorTree(LoginID)

            'Call ShowTree()
        End If



    End Sub

    Private Sub QueryNode(ByVal nd As String)
        Dim cm As New Community
        Dim cn As New CommunityNode
        Dim cns As CommunityNodeCollection
        Dim node As Microsoft.Web.UI.WebControls.TreeNode
        Dim nodeParts() As String
        Dim cnReturn As New CommunityNode

        Dim objID As Int32

        node = TreeView1.GetNodeFromIndex(nd)

        nodeParts = node.ID.Split(CType("_", Char))
        objID = Int32.Parse(nodeParts(1))

        Dim dm As New Domains
        Dim fn As New Functions
        Dim dt1 As DataTable
        dt1 = dm.GetFunctionMapDataByCommunityObjID(objID)
        Dim url As String
        If dt1.Rows.Count > 0 Then
            url = "../" & Trim(CType(dt1.Rows(0).Item("LogicalFilePath"), String) & Trim(CType(dt1.Rows(0).Item("ExeFileName"), String)))
        End If
        Session("iurl") = url

        Me.IFRAME1.Attributes("src") = CType(Session("iurl"), String)
        ' Me.IFRAME1.Attributes("name") = Me.IFRAME1.ID

    End Sub

    Private Sub ShowTree()

        TreeView1.TreeNodeSrc = Server.MapPath("/PortalFiles/View/" & LoginID & ".xml")  '"aspnetbooksTV.xml"
        TreeView1.DataBind()

    End Sub


    Private Sub GetAuthorTree(ByVal LoginID As String)
        Dim se As New Security


        WriteXmlTree(LoginID, se.ProcessingAuthorityData(LoginID))

    End Sub

    Private Sub WriteXmlTree(ByVal LoginID As String, ByVal UID As Integer)

        Dim strSQL As String = ""
        Dim dt As New DataTable
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim levelNode As String = "0"
        Dim childNode As String = ""
        Dim levelNodes() As String

        Dim LoginIDTable As String

        LoginIDTable = LoginID & "_tmp"

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
        Do
            Dim conn As New DBConn
            strSQL = "Select * from " & LoginIDTable & " where PID in (" & levelNode & ")"
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
                    If levelNode = "0" Then
                        root = xmlDoc.SelectSingleNode("TREENODES")

                    Else
                        root = xmlDoc.SelectSingleNode("//treenode[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
                    End If

                    xe1 = xmlDoc.CreateElement("treenode") '創建一個<treenode>節點 
                    xe1.SetAttribute("text", CType(dt.Rows(j).Item("objName"), String))  '設置該節點屬性  
                    'xe1.SetAttribute("text", dt.Rows(j).Item("objid") & " " & dt.Rows(j).Item("objName")) '設置該節點屬性  

                    xe1.SetAttribute("id", "N_" & CType(dt.Rows(j).Item("objid"), String))
                    'xe1.InnerText = "設置文本節點 "
                    root.AppendChild(xe1)

                Next j
            End If
            levelNode = childNode

        Loop Until levelNode = ""

        xmlDoc.Save(Server.MapPath("/PortalFiles/View/" & LoginID & ".xml"))
        xmlDoc = Nothing
        root = Nothing
        xe1 = Nothing

        Call ShowTree()


    End Sub

    Private Sub TreeView1_SelectedIndexChange(ByVal sender As Object, ByVal e As Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs) Handles TreeView1.SelectedIndexChange
        Dim _NodeID As String

        _NodeID = e.NewNode


        Call QueryNode(_NodeID)
    End Sub
End Class
