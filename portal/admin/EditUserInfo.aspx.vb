Public Class EditUserInfo
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents selU_Class As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCname As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEname As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAlias As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIDNum As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAddr_div As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtnation As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAddr_vil As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAddr_zip As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAddr_door As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelmobile As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCompany As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelcompany As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHomepage As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelhome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txttitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDept As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmask As System.Web.UI.WebControls.TextBox
    Protected WithEvents selSex As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents txtSeqno As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUID As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblUID As System.Web.UI.WebControls.Label
    Protected WithEvents lblSeqno As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents btneditpassword As System.Web.UI.WebControls.Button
    Protected WithEvents txtState As System.Web.UI.WebControls.Label

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Dim tabid As Integer = 0
    Dim moduleid As Integer = 0
    Dim sid As Integer = 2
    Dim tabindex As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        Dim UserID As String

        UserID = Context.User.Identity.Name


        If Not (Request.Params("tabid") Is Nothing) Then
            tabId = Int32.Parse(Request.Params("tabid"))
        End If

        If Not (Request.Params("tabindex") Is Nothing) Then
            tabindex = Int32.Parse(Request.Params("tabindex"))
        End If
        If Not (Request.Params("mid") Is Nothing) Then
            moduleid = Int32.Parse(Request.Params("mid"))
        End If
        If Not (Request.Params("sid") Is Nothing) Then
            sid = Int32.Parse(Request.Params("sid"))
        End If
        If UserID Is Nothing Then
            lblUID.Visible = False
        Else
            lblUID.Text = UserID
            txtUID.Visible = False
            lblSeqno.Visible = False
            txtSeqno.Visible = False
            If Not IsPostBack Then
                setOldValue(UserID)

            End If
        End If
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        UpdateUserInfo()

    End Sub

    Private Sub UpdateUserInfo()
        Dim node As New User
        node = CollectData()
        node.UID = lblUID.Text.Trim
        node.UpdateUserInfo(node)


        Call returnValue("True")
    End Sub

    Private Sub setOldValue(ByVal UserID As String)
        Dim node As New User
        node.QueryUserInfoNode(UserID)


        txtCname.Text = node.Cname
        selU_Class.SelectedValue = node.U_Class
        txtAlias.Text = node.Alias1
        txtEname.Text = node.Ename
        txtIDNum.Text = node.IDNum
        selSex.SelectedValue = CType(node.Sex, String)
        txtAddr_zip.Text = node.Addr_ZIP
        txtAddr_div.Text = node.Addr_DIV
        txtAddr_vil.Text = node.Addr_VIL
        txtAddr_door.Text = node.Addr_DOOR
        txtnation.Text = node.nation
        txtCompany.Text = node.Company
        txtTelmobile.Text = node.TelMobile
        txtTelhome.Text = node.TelHome
        txtTelcompany.Text = node.TelCompany
        txtDept.Text = node.Dept
        txttitle.Text = node.Title
        txtmask.Text = CType(node.mask, String)
        txtHomepage.Text = node.HomePage
        txtEmail.Text = node.Email
        txtSeqno.Text = node.SEQNO



    End Sub


    Private Function CollectData() As User
        Dim node As New User
        ' node.state =  txtstate.Text.Trim

        node.PID = CType(Session("CommunityNodePID"), Integer)
        node.SEQNO = txtSeqno.Text.Trim
        node.UID = txtUID.Text
        node.Cname = txtCname.Text.Trim
        node.U_Class = selU_Class.SelectedValue
        node.Alias1 = txtAlias.Text.Trim
        node.Ename = txtEname.Text.Trim
        node.IDNum = txtIDNum.Text.Trim
        node.Sex = CType(selSex.SelectedValue, Short)
        node.Addr_ZIP = txtAddr_zip.Text.Trim
        node.Addr_DIV = txtAddr_div.Text.Trim
        node.Addr_VIL = txtAddr_vil.Text.Trim
        node.Addr_DOOR = txtAddr_door.Text.Trim
        node.nation = txtnation.Text.Trim

        node.Company = txtCompany.Text.Trim
        node.TelMobile = txtTelmobile.Text.Trim
        node.TelHome = txtTelhome.Text.Trim
        node.TelCompany = txtTelcompany.Text.Trim
        node.Dept = txtDept.Text.Trim
        node.Title = txttitle.Text.Trim
        node.mask = CType(txtmask.Text.Trim, Integer)
        node.HomePage = txtHomepage.Text.Trim
        node.Email = txtEmail.Text.Trim

        node.SEQNO = txtSeqno.Text.Trim
        node.state = ""

        Return node

    End Function
    Private Sub InsertUserInfo()
        Dim node As New User
        node = CollectData()
        node.InsertUserInfo(node)

        Call WriteXmlTree()
        Call returnValue("True")


    End Sub
    Private Sub returnValue(Optional ByVal value As String = "")
        Dim js As String
        js &= "<script>"
        js &= "window.returnValue='" & value & "';"
        js &= "window.close();"
        js &= "</script>"
        Me.RegisterStartupScript("showDialogBox", js)


    End Sub

    Private Function GetTempTreeFile() As String
        Dim fn As String
        fn = "A" & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
        Return fn
    End Function

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
        xmlDoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><TREENODES></TREENODES>")
        Do
            Dim conn As New DBConn
            strSQL = "Select * from sysCommunity where PID in (" & levelNode & ")"
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
                    xe1.SetAttribute("text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String)) '設置該節點屬性  

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

        xmlDoc.Save(Server.MapPath("../xml/TreeView/" & TreefileTemp))

        root = Nothing
        xe1 = Nothing

        xmlDoc = Nothing


        'Call CopyFile("../View/TreeTemp.xml", "../View/Tree.xml")






    End Sub

    Private Sub btneditpassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditpassword.Click
        'Dim Javascript As String
        'Dim sfeatures As String
        'Dim URL As String
        'Dim returnObject As String = Me.txtState.ClientID

        'URL = "EditUserPassword.aspx"
        'sfeatures = "dialogHeight:"
        'txtState.Text = CType(ShowDialogBox(txtState, URL, 350, 250, 0, 0, True), String)

        Response.Redirect("EditUserPassword.aspx?tabid=" & tabid & "&tabindex=" & tabindex & "&mid=" & moduleid & "&sid=" & sid)


    End Sub

    'Private Function ShowDialogBox(ByVal returnValueobj As WebControls.Label, ByVal url As String, ByVal width As Integer, ByVal height As Integer, ByVal x As Integer, ByVal y As Integer, Optional ByVal isCenter As Boolean = False) As Boolean

    '    Dim Javascript As String

    '    Dim sfeatures As String = ""

    '    sfeatures &= "dialogHeight:" & height & "px;"

    '    sfeatures &= "dialogWidth:" & width & "px;"

    '    If isCenter = False Then
    '        sfeatures &= "dialogLeft:" & x & "px;"
    '        sfeatures &= "dialogTop:" & y & "px;"
    '    End If

    '    Javascript = vbCrLf & "<script>"
    '    Javascript &= vbCrLf & "Form1." & returnValueobj.ClientID & ".value=window.showModalDialog('../eiis/view/iFrame.aspx?url=" & url & "','','" & sfeatures & "');"
    '    Javascript &= vbCrLf & "</script>"

    '    Me.RegisterStartupScript("ShowDialog", Javascript)

    'End Function
End Class
