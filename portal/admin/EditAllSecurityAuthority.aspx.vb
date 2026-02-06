'Imports System.Xml.Xpath

Imports Microsoft.Web.UI.WebControls.TreeNode
Imports System.IO
Namespace EIIS
    Public Class EditAllSecurityAuthority

        Inherits System.Web.UI.Page



#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
        Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
        Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
        Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
        Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtState As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSeqno As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtObjValue As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtObjName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtsrcName As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtobjID As System.Web.UI.WebControls.Label
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
        Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
        Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
        Protected WithEvents newType As System.Web.UI.WebControls.DropDownList
        Protected WithEvents FunRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents addfunction As System.Web.UI.WebControls.Button
        Protected WithEvents btnTreeRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents LoginRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents AddLiginID As System.Web.UI.WebControls.Button
        Protected WithEvents Button1 As System.Web.UI.WebControls.Button
        Protected WithEvents Button2 As System.Web.UI.WebControls.Button
        Protected WithEvents Button3 As System.Web.UI.WebControls.Button
        Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents errmsg As System.Web.UI.WebControls.Label

        '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
        '請勿刪除或移動它。
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
            '請勿使用程式碼編輯器進行修改。
            InitializeComponent()
        End Sub

#End Region

        Dim ggPID As Integer
        Dim moduleId As Integer = 0
        'Dim rootnum As String
        'Dim rootnum1 As String
        Dim sid As String

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim treeFile As String
            sid = CType(Session("sid"), String)
            moduleId = Int32.Parse(Request.Params("Mid"))
            Dim au As New AuthorityBO
            If Not au.checkAuthorityEdit(Context.User.Identity.Name, moduleId, 7, Me.Page) Then
                Response.Redirect("~/Admin/EditAccessDenied.aspx")
            End If
            au = Nothing
            Dim objsecuritydb As New SecurityDB
            Me.btnDelete.Attributes("onclick") = "if (window.confirm('您確認要刪除目前所選擇的項目嗎?')!=true) {event.returnValue=false;}"
            '   rootnum = CType(objsecuritydb.GetPidByUserID(Context.User.Identity.Name), String)
            '  rootnum1 = CType(objsecuritydb.GetUpidByUserID(Context.User.Identity.Name), String)
            objsecuritydb = Nothing
            errmsg.Text = ""
            If Not IsPostBack Then
                '在這裡放置使用者程式碼以初始化網頁

                Call ShowTree(treeFile)
                Call QueryNode(CType(0, String))

            End If

            Me.Panel1.Style("overflow") = "auto"

        End Sub

        Private Function GetTempTreeFile() As String
            Dim fn As String
            fn = "All_" & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
            Return fn
        End Function

        Private Sub ShowTree(ByVal treeFile As String)
            Dim treeFile1 As String

            Dim fls() As String = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/admin"), "All_" & "*.xml")

            If UBound(fls) < 1 Then
                WriteXmlTree()
                fls = Directory.GetFiles(Server.MapPath("/Portalfiles/xml/admin"), "All_" & "*.xml")
            End If
            treeFile1 = (fls(UBound(fls)))

            '  treeFile1 = (fls(0))

            TreeView1.TreeNodeSrc = treeFile1   ' Server.MapPath("../xml/TreeView/" & treeFile)   '"aspnetbooksTV.xml"

            TreeView1.DataBind()

            '  Call ShowAddnewButton()


        End Sub


        Private Sub ShowAddnewButton()

            If txtsrcName.SelectedValue = "UserInfo" Then
                btnAdd.Enabled = False
                AddLiginID.Enabled = True
            Else
                btnAdd.Enabled = True
                AddLiginID.Enabled = False
            End If
        End Sub


        Private Sub WriteXmlTree()

            Dim strSQL As String = ""
            Dim dt As New DataTable
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim levelNode As String = "0"
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
            'Dim nsmgr As System.Xml.XmlNamespaceManager = New System.Xml.XmlNamespaceManager(xmlDoc.NameTable)
            'nsmgr.AddNamespace("bk", "urn:samples")



            xmlDoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><TREENODES></TREENODES>")

            Do
                Dim conn As New DBConn
                If icount = 1 Then
                    strSQL = "Select * from sysCommunity where  PID in (" & levelNode & ")  order by seqno "
                Else
                    strSQL = "Select * from sysCommunity where PID in (" & levelNode & ")  order by seqno "
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
                        If levelNode = "0" Then
                            root = xmlDoc.SelectSingleNode("TREENODES")

                        Else
                            root = xmlDoc.SelectSingleNode("//treenode[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
                        End If

                        xe1 = xmlDoc.CreateElement("treenode")  '創建一個<treenode>節點 

                        xe1.SetAttribute("text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String)) '設置該節點屬性  
                        If CType(dt.Rows(j).Item("srcName"), String).ToLower = "groups" Then
                            xe1.SetAttribute("IMAGEURL", "../eiis/images/folder.gif")

                        Else
                            xe1.SetAttribute("IMAGEURL", "../eiis/images/User.gif")
                        End If
                        xe1.SetAttribute("EXPANDEDIMAGEURL", "../eiis/images/folderopen.gif")
                        xe1.SetAttribute("id", "N_" & CType(dt.Rows(j).Item("objID"), String))

                        'xe1.InnerText = "設置文本節點 "
                        root.AppendChild(xe1)

                    Next j
                End If
                levelNode = childNode

            Loop Until levelNode = ""

            Dim TreefileTemp As String
            TreefileTemp = GetTempTreeFile()

            viewstate("tree") = TreefileTemp

            xmlDoc.Save(Server.MapPath("/PortalFiles/xml/admin/" & TreefileTemp))

            root = Nothing
            xe1 = Nothing

            xmlDoc = Nothing


            'Call CopyFile("../View/TreeTemp.xml", "../View/Tree.xml")


            Call ShowTree(TreefileTemp)


        End Sub

        Private Sub CopyFile(ByVal FileS As String, ByVal FileD As String)
            Dim fs As File

            fs.Copy(Server.MapPath(FileS), Server.MapPath(FileD), True)

        End Sub


        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            'Dim cm As New Community
            'Dim cn As New CommunityNode
            'cn.objName = txtObjName.Text.Trim
            'cn.objValue = txtObjValue.Text.Trim
            'cn.SEQNO = txtSeqno.Text.Trim
            'cn.state = txtState.Text.Trim
            'cn.PID = txtobjID.Text.Trim


            'cm.InsertNode(cn)
            'Call WriteXmlTree()

            Dim Javascript As String
            Dim sfeatures As String
            Dim URL As String
            Dim returnObject As String = Me.txtState.ClientID
            Select Case newType.SelectedValue.ToLower
                Case "groups"
                    URL = "GroupsView.aspx"
                    sfeatures = "dialogHeight:"
                    txtState.Text = CType(ShowDialogBox(txtState, URL, 350, 250, 0, 0, True), String)
                Case "userinfo"
                    URL = "UserInfoView.aspx"
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
            cn.objID = objID

            cns = cm.QueryNode(cn)
            cnReturn = cns.Item(0)

            txtobjID.Text = CType(cnReturn.objID, String)
            txtObjName.Text = cnReturn.objName
            txtObjValue.Text = cnReturn.objValue
            txtSeqno.Text = cnReturn.SEQNO
            txtState.Text = cnReturn.state
            txtPID.Text = CType(cnReturn.PID, String)
            txtsrcName.SelectedValue = cnReturn.srcName
            Session("CommunityNodePID") = txtobjID.Text  'txtPID.Text

            Call ShowNodeAllInformation(objID)


            Select Case txtsrcName.SelectedValue.ToLower

                Case "groups"
                    Call QueryGroups(txtObjValue.Text)
                    DataGrid3.Visible = False
                    DataGrid2.Visible = True
                    DataGrid1.Visible = False
                Case "userinfo"

                    Call QueryUserInfo(txtObjValue.Text)
                    DataGrid2.Visible = False
                    DataGrid3.Visible = True
                    DataGrid1.Visible = True
            End Select


        End Sub



        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            Dim cm As New Community
            Dim cn As New CommunityNode
            cn.objName = txtObjName.Text.Trim
            cn.objValue = txtObjValue.Text.Trim
            cn.SEQNO = txtSeqno.Text.Trim
            cn.state = txtState.Text.Trim
            cn.PID = CType(txtPID.Text.Trim, Integer)
            cn.objID = CType(txtobjID.Text.Trim, Integer)

            cm.UpdateNode(cn)

            Call WriteXmlTree()

        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

            If txtObjValue.Text.Trim.ToLower = "cadmin" Or txtPID.Text.Trim = "1" Or txtobjID.Text.Trim = "1" Or txtObjValue.Text.Trim.ToLower = "guest" Then
                errmsg.Text = "該項目無法刪除!"
                Exit Sub
            End If

            Dim cm As New Community


            Dim cn As New CommunityNode

            cn.objID = CType(txtobjID.Text.Trim, Integer)


            cm.DeleteNode(cn)

            Call WriteXmlTree()


        End Sub


        Private Sub TreeView1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs) Handles TreeView1.SelectedIndexChange

            Dim _NodeID As String

            _NodeID = e.NewNode

            Call QueryNode(_NodeID)

        End Sub

        Private Sub ShowNodeAllInformation(ByVal _NodeID As Integer)

            Call QuerySecurity(_NodeID)

            Call QueryMapingInfo((_NodeID))

            Call ShowAddnewButton()

        End Sub

        Private Sub QuerySecurity(ByVal _NodeID As Integer)

            Dim sc As New Security

            Dim dt As New DataTable

            dt = sc.QueryUID(CType(_NodeID, String))

            DataGrid1.DataSource = dt

            DataGrid1.DataBind()

        End Sub


        Private Sub QueryGroups(ByVal groupid As String)

            Dim gp As New Groups

            Dim dt As New DataTable

            dt = gp.QueryGroup(CType(groupid, Integer))

            DataGrid2.DataSource = dt

            DataGrid2.DataBind()

        End Sub

        Private Sub QueryUserInfo(ByVal UID As String)

            Dim ur As New User

            Dim dt As New DataTable

            dt = ur.QueryUserInfo(UID)

            DataGrid3.DataSource = dt

            DataGrid3.DataBind()

        End Sub

        Private Sub QueryMapingInfo(ByVal objid As Integer)

            Dim ur As New Domains

            Dim dt As New DataTable

            dt = ur.GetMapDataByCommunityObjID(objid)

            DataGrid4.DataSource = dt

            DataGrid4.DataBind()

        End Sub

        Private Sub DataGrid4_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)

            DataGrid4.CurrentPageIndex = e.NewPageIndex

            Dim ur As New Domains

            DataGrid4.DataSource = ur.GetMapDataByCommunityObjID(CType(txtobjID.Text, Integer))

            DataGrid4.DataBind()

            ur = Nothing

        End Sub



        Sub Functoin_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

            Dim cm As New Community

            Dim roleid As String

            roleid = Trim(CType(DataGrid4.DataKeys(e.Item.ItemIndex), String))

            cm.DeleteMapFunction(CType(roleid, Integer))

            Call QueryMapingInfo(CType(txtobjID.Text, Integer))


        End Sub

        Private Sub FunRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FunRefresh.Click
            QueryMapingInfo(CType(txtobjID.Text, Integer))
        End Sub

        Private Sub addfunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addfunction.Click
            txtState.Text = CType(ShowDialogBox(txtState, "ImportAllDomains.aspx?UID=" & txtobjID.Text.Trim, 400, 520, 0, 0, True), String)
        End Sub

        Private Sub btnTreeRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTreeRefresh.Click
            Call WriteXmlTree()
        End Sub

        Private Sub LoginRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginRefresh.Click
            QuerySecurity(CType(txtobjID.Text, Integer))
            QueryUserInfo((CType(txtObjValue.Text, String)))

        End Sub

        Private Sub AddLiginID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddLiginID.Click
            txtState.Text = CType(ShowDialogBox(txtState, "AccountMgtView.aspx?objValue=" & txtObjValue.Text.Trim, 350, 270, 0, 0, True), String)
        End Sub

        Private Sub DataGrid3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid3.SelectedIndexChanged
            Dim datagriditem As datagriditem
            datagriditem = DataGrid3.SelectedItem()
            Dim UserID As String
            UserID = datagriditem.Cells(1).Text.Trim
            txtState.Text = CType(ShowDialogBox(txtState, "UserInfoView.aspx?UserID=" & UserID, 600, 530, 0, 0, True), String)
        End Sub

        Private Sub DataGrid4_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid4.EditCommand
            DataGrid4.EditItemIndex = e.Item.ItemIndex
            QueryMapingInfo(CType(txtobjID.Text, Integer))
        End Sub

        Private Sub DataGrid4_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid4.CancelCommand
            DataGrid4.EditItemIndex = -1
            QueryMapingInfo(CType(txtobjID.Text, Integer))
        End Sub

        Private Sub DataGrid4_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid4.UpdateCommand
            Dim Ilevel As CheckBox
            Dim Dlevel As CheckBox
            Dim Ulevel As CheckBox
            Dim Qlevel As CheckBox
            Dim Clevel As CheckBox



            Dim RoleID As Integer
            RoleID = CType(DataGrid4.DataKeys(e.Item.ItemIndex), Integer)
            Dim fa As New FunctionAuthority

            'functionID = CType(e.Item.Cells(1).Controls(0), TextBox)
            Ilevel = CType(e.Item.FindControl("chkIlevel"), CheckBox)
            Dlevel = CType(e.Item.FindControl("chkDlevel"), CheckBox)
            Ulevel = CType(e.Item.FindControl("chkUlevel"), CheckBox)
            Qlevel = CType(e.Item.FindControl("chkQlevel"), CheckBox)
            Clevel = CType(e.Item.FindControl("chkClevel"), CheckBox)

            Dim cm As New Community
            If Ilevel.Checked = True Then
                fa.Ilevel = 7
            End If
            If Dlevel.Checked = True Then
                fa.Dlevel = 7
            End If
            If Qlevel.Checked = True Then
                fa.Qlevel = 7
            End If
            If Ulevel.Checked = True Then
                fa.Ulevel = 7
            End If
            If Clevel.Checked = True Then
                fa.Clevel = 7
            End If

            fa.RoleID = RoleID


            cm.UpdateFunctionAuthority(fa)

            DataGrid4.EditItemIndex = -1
            QueryMapingInfo(CType(txtobjID.Text, Integer))
        End Sub


        Private Sub DataGrid1_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
            Dim chkstate As CheckBox
            Dim txtStartDate As TextBox
            Dim txtEndDate As TextBox
            Dim txtPassword As TextBox
            Dim se As New Security
            Dim at As New Account

            Dim ps As New ASPNET.StarterKit.Portal.PortalSecurity

            Dim AccountID As String
            AccountID = CType(DataGrid1.DataKeys(e.Item.ItemIndex), String)
            at.LoginID = AccountID
            chkstate = CType(e.Item.FindControl("chkstate"), CheckBox)
            txtStartDate = CType(e.Item.FindControl("txtStartDate"), TextBox)
            txtEndDate = CType(e.Item.FindControl("txtEndDate"), TextBox)
            txtPassword = CType(e.Item.FindControl("txtPassword"), TextBox)

            at.StartDate = CType(txtStartDate.Text.Trim, Date)
            at.EndDate = CType(txtEndDate.Text.Trim, Date)
            If CType(se.Query(AccountID).Rows(0).Item("Password"), String).Trim <> CType(txtPassword.Text.Trim, String) Then
                at.Password = ps.Encrypt(CType(txtPassword.Text.Trim, String))
            End If

            If chkstate.Checked = True Then
                at.state = "1"
            Else
                at.state = "0"
            End If

            se.UpdateaAccount(at)
            DataGrid1.EditItemIndex = -1
            QuerySecurity(CType(txtobjID.Text, Integer))
        End Sub

        Private Sub DataGrid1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.EditCommand
            DataGrid1.EditItemIndex = e.Item.ItemIndex
            QuerySecurity(CType(txtobjID.Text, Integer))
        End Sub

        Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
            DataGrid1.EditItemIndex = -1
            QuerySecurity(CType(txtobjID.Text, Integer))
        End Sub
    End Class
End Namespace