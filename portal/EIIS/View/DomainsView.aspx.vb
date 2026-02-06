Imports System.IO
Public Class DomainsView
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack() Then

            Call ShowTree()

            Call QueryNode(rootnum)
        End If
    End Sub
    '


    Private Sub ShowTree()
        Dim fls() As String = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/TreeView"), "AllD_*.xml")
        Dim treeFile1 As String

        If UBound(fls) < 1 Then
            WriteXmlTree()
            fls = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/TreeView"), "AllD_*.xml")
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
        xmlDoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><TREENODES></TREENODES>")
        Do
            Dim conn As New DBConn
            strSQL = "Select * from sysDomains where PID in (" & levelNode & ")"
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

        xmlDoc.Save(Server.MapPath("/PortalFiles/xml/TreeView/" & TreefileTemp))
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
        Javascript &= vbCrLf & "Form1." & returnValueobj.ClientID & ".value=window.showModalDialog('iFrame.aspx?url=" & url & "','','" & sfeatures & "');"
        Javascript &= vbCrLf & "</script>"

        Me.RegisterStartupScript("ShowDialog", Javascript)

    End Function
    Private Sub QueryNode(ByVal nd As String)
        Dim dm As New Domains
        Dim dn As New DomainsNode

        Dim node As Microsoft.Web.UI.WebControls.TreeNode
        Dim nodeParts() As String
        Dim cnReturn As New DomainsNode

        Dim objID As Int32

        node = TreeView1.GetNodeFromIndex(nd)
        nodeParts = node.ID.Split(CType("_", Char))
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
        If selsrcName.SelectedValue.ToLower = "function" Then
            btnAdd.Enabled = False
        Else
            btnAdd.Enabled = True
        End If
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


    Private Sub TreeView1_SelectedIndexChange(ByVal sender As Object, ByVal e As Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs) Handles TreeView1.SelectedIndexChange
        Dim _NodeID As String

        _NodeID = e.NewNode


        Call QueryNode(_NodeID)
    End Sub


    Private Sub QueryFunctionList(ByVal objvalue As String)

        Dim gp As New Domains
        Dim dt As New DataTable
        Dim fn As New Functions


        dt = gp.QueryFunctionList(objvalue)
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
        fn = "AllD_" & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
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
        Dim ExeFileName As TextBox
        Dim LogicalFilePath As TextBox
        Dim ExeCMDLine As TextBox
        Dim PaneName As DropDownList
        '       Dim ModuleDefid As TextBox



        Dim funNO As Integer
        funNO = CType(DataGrid1.DataKeys(e.Item.ItemIndex), Integer)
        'functionID = CType(e.Item.Cells(1).Controls(0), TextBox)
        functionID = CType(e.Item.FindControl("txtfunctionID"), TextBox)
        Description = CType(e.Item.FindControl("txtDescription"), TextBox)
        ExeFileName = CType(e.Item.FindControl("txtExeFileName"), TextBox)
        LogicalFilePath = CType(e.Item.FindControl("txtLogicalFilePath"), TextBox)
        ExeCMDLine = CType(e.Item.FindControl("txtExeCMDLine"), TextBox)
        PaneName = CType(e.Item.FindControl("txtPaneName"), DropDownList)
        '     ModuleDefid = CType(e.Item.FindControl("txtExeCMDLine"), TextBox)

        Dim dm As New Domains
        Dim fn As New EIIS.Functions
        fn.FunctionID = functionID.Text.Trim
        fn.Description = Description.Text.Trim
        fn.ExeFileName = ExeFileName.Text.Trim
        fn.LogicalFilePath = LogicalFilePath.Text.Trim
        fn.ExeCMDLine = ExeCMDLine.Text.Trim
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
End Class
