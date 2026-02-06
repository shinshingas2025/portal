Imports System.IO
Imports System.Xml

Public Class EditAllWebFormSetting
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
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents selsrcName As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnTreeRefresh As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents newType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lstLeftPane As System.Web.UI.WebControls.ListBox
    Protected WithEvents lstCenterPane As System.Web.UI.WebControls.ListBox
    Protected WithEvents lstRightPane As System.Web.UI.WebControls.ListBox
    Protected WithEvents LPaneRight As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LPaneUp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LPaneDown As System.Web.UI.WebControls.ImageButton
    Protected WithEvents CPaneUp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents CPaneRight As System.Web.UI.WebControls.ImageButton
    Protected WithEvents CPaneLeft As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RPaneDown As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RPaneUp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RPaneLeft As System.Web.UI.WebControls.ImageButton
    Protected WithEvents CPaneDown As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label

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
        Dim fls() As String = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/Admin"), "D_" & "*.xml")
        Dim treeFile1 As String

        If UBound(fls) < 1 Then
            WriteXmlTree()
            fls = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/Admin"), "D_" & "*.xml")
        End If
        treeFile1 = (fls(UBound(fls)))
        '  treeFile1 = (fls(0))

        TreeView1.Nodes.Clear()
        Dim myXml As New XmlDocument
        Dim rootXmlNode As XmlNode
        myXml.Load(treeFile1)
        rootXmlNode = myXml.GetElementsByTagName("treenode2")(0)
        Dim currNode As TreeNode
        TreeView1.Nodes.Add(New TreeNode(rootXmlNode.Attributes("text").Value, rootXmlNode.Attributes("id").Value))
        currNode = TreeView1.Nodes(0)
        setTreeNodePic(currNode, rootXmlNode)
        XmltoTreeView(currNode, myXml, 3)

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

        Do
            Dim conn As New DBConn
            If icount = 1 Then
                strSQL = "Select * from sysDomains where PID in (" & levelNode & ")   order by seqno "
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
                        root = xmlDoc.SelectSingleNode("//treenode" & LeveLCnt - 1 & "[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
                    End If

                    xe1 = xmlDoc.CreateElement("treenode" & LeveLCnt) '創建一個<treenode>節點 
                    xe1.SetAttribute("text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String)) '設置該節點屬性  

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
        Dim TreefileTemp As String
        TreefileTemp = GetTempTreeFile()

        viewstate("tree") = TreefileTemp

        xmlDoc.Save(Server.MapPath("/PortalFiles/xml/Admin/" & TreefileTemp))
        ' xmlDoc.Save(Server.MapPath("../View/DomainsTree.xml"))
        xmlDoc = Nothing
        root = Nothing
        xe1 = Nothing

        Call ShowTree()


    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim Javascript As String
        Dim sfeatures As String
        Dim URL As String
        Dim returnObject As String = Me.txtState.ClientID

        Select Case newType.SelectedValue.ToLower
            Case "joblist"
                URL = "JoblistView.aspx"
                sfeatures = "dialogHeight:"
                txtState.Text = CType(ShowDialogBox(txtState, URL, 350, 250, 0, 0, True), String)
            Case "function"
                URL = "FunctionView.aspx"
                txtState.Text = CType(ShowDialogBox(txtState, URL, 550, 520, 0, 0, True), String)
        End Select




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
        Dim dm As New Domains
        Dim dn As New DomainsNode

        Dim node As TreeNode
        Dim nodeParts() As String
        Dim cnReturn As New DomainsNode

        Dim objID As Int32

        'node = TreeView1.SelectedNode
        nodeParts = nd.Split(CType("_", Char))
        objID = Int32.Parse(nodeParts(1))
        dn.objID = objID

        cnReturn = dm.QueryNode(dn)


        txtobjID.Text = CType(cnReturn.objID, String)
        Session("DomainNodePID") = cnReturn.objID
        If cnReturn.objValue = "" Then cnReturn.objValue = CType(0, String)
        Session("DomainNodeValue") = cnReturn.objValue

        txtObjName.Text = cnReturn.objName
        txtObjValue.Text = cnReturn.objValue
        txtSeqno.Text = cnReturn.SEQNO
        txtState.Text = cnReturn.state
        txtPID.Text = CType(cnReturn.PID, String)
        selsrcName.SelectedValue = cnReturn.srcName
        If txtObjValue.Text.Trim <> "" And txtObjValue.Text.Trim <> "0" Then
            Call QueryFunctionDetail(txtObjValue.Text)
        Else
            Call QueryFunctionList(txtobjID.Text)
        End If

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
		'    If selsrcName.SelectedValue.ToLower = "function" Then
		'btnAdd.Enabled = False
		'    Else
		'        btnAdd.Enabled = True
		'    End If
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim cm As New Domains
        Dim cn As New DomainsNode
        cn.objName = CType(txtObjName.Text.Trim, String)
        cn.objValue = CType(txtObjValue.Text.Trim, String)
        cn.SEQNO = CType(txtSeqno.Text.Trim, String)
        cn.state = CType(txtState.Text.Trim, String)
        cn.PID = CType(txtPID.Text.Trim, Integer)
        cn.objID = CType(txtobjID.Text.Trim, Integer)

        cm.UpdateNode(cn)
        Call WriteXmlTree()
        cm = Nothing
        cn = Nothing

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim dm As New Domains
        Dim FunNO As String

        Dim node As New DomainsNode
        node.objID = CType(Session("DomainNodePID"), Integer)
        node.objValue = CType(Session("DomainNodeValue"), String)

        dm.DeleteNode(node)

        ' QueryFunctionDetail(Session("DomainNodeValue"))
        Call WriteXmlTree()

    End Sub


    Private Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TreeView1.SelectedNodeChanged
        Dim _NodeID As String

        _NodeID = TreeView1.SelectedValue


        Call QueryNode(_NodeID)
    End Sub


    Private Sub QueryFunctionList(ByVal objvalue As String)

        Dim gp As New Domains
        Dim dt As New DataTable
        Dim fn As New Functions
        Dim i As Integer

        lstLeftPane.Items.Clear()
        lstCenterPane.Items.Clear()
        lstRightPane.Items.Clear()

        dt = gp.QueryFunctionList(objvalue)

        For i = 0 To dt.Rows.Count - 1
            Dim objlistitem As New ListItem

            objlistitem.Text = CType(dt.Rows(i).Item("FunctionID"), String)
            objlistitem.Value = CType(dt.Rows(i).Item("funno"), String)


            Select Case Mid(CType(dt.Rows(i).Item("PaneName"), String), 1, 1)

                Case "0"

                    lstLeftPane.Items.Add(objlistitem)


                Case "1"
                    lstCenterPane.Items.Add(objlistitem)

                Case "2"
                    lstRightPane.Items.Add(objlistitem)

            End Select




        Next



        DataGrid1.DataSource = dt
        DataGrid1.DataBind()

        gp = Nothing
        dt = Nothing
        fn = Nothing

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
        fn = "D_" & sid & "_" & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
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

    Private Sub DataGrid1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.EditCommand


        DataGrid1.EditItemIndex = e.Item.ItemIndex
        'Dim PaneName As DropDownList
        'PaneName = CType(e.Item.FindControl("txtPaneName"), DropDownList)

        'Dim pitem As New ListItem
        'pitem.Text = "左"
        'pitem.Value = "1"
        'PaneName.Items.Add(pitem)
        'pitem.Text = "中"
        'pitem.Value = "2"
        'PaneName.Items.Add(pitem)
        'pitem.Text = "右"
        'pitem.Value = "3"
        'PaneName.Items.Add(pitem)

        If txtObjValue.Text.Trim <> "" And txtObjValue.Text.Trim <> "0" Then

            Call QueryFunctionDetail(e.Item.Cells(0).Text)
        Else
            Call QueryFunctionList(txtobjID.Text)
        End If



    End Sub



    Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        DataGrid1.EditItemIndex = -1
        If txtObjValue.Text.Trim <> "" And txtObjValue.Text.Trim <> "0" Then

            Call QueryFunctionDetail(e.Item.Cells(0).Text)
        Else
            Call QueryFunctionList(txtobjID.Text)
        End If

    End Sub


    Private Sub DataGrid1_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
        Dim functionID As TextBox
        Dim Description As TextBox
        'Dim ExeFileName As TextBox
        'Dim LogicalFilePath As TextBox
        'Dim ExeCMDLine As TextBox
        Dim PaneName As DropDownList
        '       Dim ModuleDefid As TextBox



        Dim funNO As Integer
        funNO = CType(DataGrid1.DataKeys(e.Item.ItemIndex), Integer)
        'functionID = CType(e.Item.Cells(1).Controls(0), TextBox)
        functionID = CType(e.Item.FindControl("txtfunctionID"), TextBox)
        Description = CType(e.Item.FindControl("txtDescription"), TextBox)
        'ExeFileName = CType(e.Item.FindControl("txtExeFileName"), TextBox)
        'LogicalFilePath = CType(e.Item.FindControl("txtLogicalFilePath"), TextBox)
        'ExeCMDLine = CType(e.Item.FindControl("txtExeCMDLine"), TextBox)
        PaneName = CType(e.Item.FindControl("txtPaneName"), DropDownList)
        '     ModuleDefid = CType(e.Item.FindControl("txtExeCMDLine"), TextBox)

        Dim dm As New Domains
        Dim fn As New EIIS.Functions
        fn.FunctionID = functionID.Text.Trim
        fn.Description = Description.Text.Trim
        fn.ExeFileName = "" 'ExeFileName.Text.Trim
        fn.LogicalFilePath = "" ' LogicalFilePath.Text.Trim
        fn.ExeCMDLine = "" 'ExeCMDLine.Text.Trim
        fn.PaneName = PaneName.SelectedValue
        fn.funNo = funNO

        dm.UpdateFunctionMaster(fn)


        DataGrid1.EditItemIndex = -1
        If txtObjValue.Text.Trim <> "" And txtObjValue.Text.Trim <> "0" Then

            Call QueryFunctionDetail(e.Item.Cells(0).Text)
        Else
            Call QueryFunctionList(txtobjID.Text)
        End If

    End Sub

    Private Sub LPaneRight_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LPaneRight.Click
        If lstLeftPane.SelectedIndex = -1 Then Exit Sub

        Dim objFunctionBO As New FunctionsBO
        Dim objFunction As New EIIS.Functions
        objFunction.funNo = CType(lstLeftPane.SelectedValue, Integer)
        objFunction.PaneName = "1-contentPane"
        objFunctionBO.Update(objFunction)



        Dim objlistitem As New ListItem
        objlistitem.Text = lstLeftPane.SelectedItem.Text
        objlistitem.Value = lstLeftPane.SelectedItem.Value

        lstCenterPane.Items.Add(objlistitem)

        lstLeftPane.Items.Remove(lstLeftPane.SelectedItem)

    End Sub

    Private Sub CPaneLeft_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CPaneLeft.Click
        If lstCenterPane.SelectedIndex = -1 Then Exit Sub

        Dim objFunctionBO As New FunctionsBO
        Dim objFunction As New EIIS.Functions
        objFunction.funNo = CType(lstCenterPane.SelectedValue, Integer)
        objFunction.PaneName = "0-leftPane"
        objFunctionBO.Update(objFunction)


        Dim objlistitem As New ListItem
        objlistitem.Text = lstCenterPane.SelectedItem.Text
        objlistitem.Value = lstCenterPane.SelectedItem.Value

        lstLeftPane.Items.Add(objlistitem)
        lstCenterPane.Items.Remove(lstCenterPane.SelectedItem)
    End Sub

    Private Sub CPaneRight_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CPaneRight.Click
        If lstCenterPane.SelectedIndex = -1 Then Exit Sub

        Dim objFunctionBO As New FunctionsBO
        Dim objFunction As New EIIS.Functions
        objFunction.funNo = CType(lstCenterPane.SelectedValue, Integer)
        objFunction.PaneName = "2-rightPane"
        objFunctionBO.Update(objFunction)

        Dim objlistitem As New ListItem
        objlistitem.Text = lstCenterPane.SelectedItem.Text
        objlistitem.Value = lstCenterPane.SelectedItem.Value

        lstRightPane.Items.Add(objlistitem)

        lstCenterPane.Items.Remove(lstCenterPane.SelectedItem)
    End Sub

    Private Sub RPaneLeft_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles RPaneLeft.Click
        If lstRightPane.SelectedIndex = -1 Then Exit Sub

        Dim objFunctionBO As New FunctionsBO
        Dim objFunction As New EIIS.Functions
        objFunction.funNo = CType(lstRightPane.SelectedValue, Integer)
        objFunction.PaneName = "1-contentPane"
        objFunctionBO.Update(objFunction)



        Dim objlistitem As New ListItem
        objlistitem.Text = lstRightPane.SelectedItem.Text
        objlistitem.Value = lstRightPane.SelectedItem.Value

        lstCenterPane.Items.Add(objlistitem)

        lstRightPane.Items.Remove(lstRightPane.SelectedItem)
    End Sub

    Private Sub txtState_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtState.TextChanged
        Call WriteXmlTree()
    End Sub



    Private Sub UpOrderItem(ByVal lstItem As WebControls.ListBox)
        If lstItem.SelectedIndex = -1 Then
            Exit Sub
        End If
        Dim maxIndex As Integer
        Dim minIndex As Integer

        minIndex = 0
        maxIndex = lstItem.Items.Count - 1

        If lstItem.SelectedIndex = minIndex Then
            Exit Sub
        End If

        Dim it As New ListItem
        it.Text = lstItem.SelectedItem.Text
        it.Value = lstItem.SelectedValue

        lstItem.Items.Insert(lstItem.SelectedIndex - 1, it)
        lstItem.Items.RemoveAt(lstItem.SelectedIndex)

    End Sub

    Private Sub downOrderItem(ByVal lstItem As WebControls.ListBox)
        If lstItem.SelectedIndex = -1 Then
            Exit Sub
        End If
        Dim maxIndex As Integer
        Dim minIndex As Integer

        minIndex = 0
        maxIndex = lstItem.Items.Count - 1

        If maxIndex = lstItem.SelectedIndex Then
            Exit Sub
        End If


        Dim it As New ListItem
        it.Text = lstItem.SelectedItem.Text
        it.Value = lstItem.SelectedValue

        lstItem.Items.Insert(lstItem.SelectedIndex + 2, it)
        lstItem.Items.RemoveAt(lstItem.SelectedIndex)

    End Sub

    Private Sub CPaneUp_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CPaneUp.Click
        UpOrderItem(lstCenterPane)
        UpdateItemOrder(lstCenterPane)
    End Sub

    Private Sub RPaneUp_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles RPaneUp.Click
        UpOrderItem(lstRightPane)
        UpdateItemOrder(lstRightPane)
    End Sub

    Private Sub CPaneDown_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CPaneDown.Click
        downOrderItem(lstCenterPane)
        UpdateItemOrder(lstCenterPane)
    End Sub

    Private Sub LPaneDown_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LPaneDown.Click
        downOrderItem(lstLeftPane)
        UpdateItemOrder(lstLeftPane)
    End Sub

    Private Sub LPaneUp_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LPaneUp.Click
        UpOrderItem(lstLeftPane)
        UpdateItemOrder(lstLeftPane)
    End Sub

    Private Sub RPaneDown_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles RPaneDown.Click
        downOrderItem(lstRightPane)
        UpdateItemOrder(lstRightPane)
    End Sub


    Private Sub UpdateItemOrder(ByVal lstItem As WebControls.ListBox)
        Dim objFunctionBO As New FunctionsBO
        objFunctionBO.UpdateFunctionOrder(lstItem)

    End Sub


End Class