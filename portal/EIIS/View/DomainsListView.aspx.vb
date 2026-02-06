Imports System.IO
Public Class DomainsListView

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack() Then

            Call ShowTree()
        End If
        Me.Panel1.Style("overflow") = "auto"
    End Sub

    Private Sub ShowTree()

        Dim treefile1 As String

        Dim fls() As String = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/TreeView"), "D*.xml")


        treefile1 = (fls(UBound(fls)))
        '  treeFile1 = (fls(0))

        TreeView1.TreeNodeSrc = treefile1 ' Server.MapPath("../xml/TreeView/" & treeFile)   '"aspnetbooksTV.xml"


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
