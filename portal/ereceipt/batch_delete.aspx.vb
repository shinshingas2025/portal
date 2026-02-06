Public Class batch_delete
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents txtrb_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents inquire As System.Web.UI.WebControls.Button

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region
    Dim objDR As DataRow
    Dim objCartDT As DataTable
    Dim userID As String
    Dim flag As Boolean
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        '取得使用者登入帳號
        userID = context.User.Identity.Name
        'userID = "cadmin"
        flag = False
        If Not IsPostBack Then

            'Call showData()
        End If
        objCartDT = CType(Session("Cart"), DataTable)
    End Sub



    Private Sub inquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inquire.Click
        Dim se As New BatchDeleteBO
        Dim rb_no As String = ""
        Dim result As Integer = 0

        msgbox.Text = ""

        rb_no = txtrb_no.Text.ToString.Trim

        If rb_no.Length = 0 Then
            msgbox.Text = "請輸入交易序號"
            Exit Sub
        Else
            result = se.BatchDelete(rb_no)
            If result = 0 Then
                msgbox.Text = "無可刪除資料!"
            ElseIf result > 0 Then
                msgbox.Text = "刪除成功!"
            Else
                msgbox.Text = "刪除失敗,請再試一次!"
            End If
        End If
    End Sub



End Class
