Public Class process_request
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region
    Dim parentId = Request("p")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁

        If parentId = "" Then parentId = 0
        Literal1.Text = GetItems(parentId)
    End Sub



    Function GetItems(ByVal parentId) As String
        Dim strConn, strTable

        'strTable = "TreeViewMenu"
        'strConn = "Provider=MSDASQL;Driver={SQL Server};Server=(local);Database=test;User ID=sa;Password=sa;" 

        strTable = "Menu"
        strConn = "DRIVER={Microsoft Access Driver (*.mdb)};DBQ=" & Server.MapPath("site.mdb")

        Dim tv
        tv = New Treeview
        tv.MenuTable = strTable
        tv.ConnectionString = strConn
        GetItems = (tv.GetChildNodes(parentId))
        tv = Nothing

    End Function






End Class
