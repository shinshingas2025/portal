Public Class _Default
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtLoginID As System.Web.UI.WebControls.TextBox
    Protected WithEvents linkOK As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblerror As System.Web.UI.WebControls.Label

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
    End Sub

    Private Sub linkOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkOK.Click
        Dim se As New Security
        Dim at As New Account
        at.LoginID = txtLoginID.Text.Trim
        at.Password = txtPassword.Text.Trim
        Dim i As Integer = se.CheckAccount(at)

        Select Case i
            Case 0
            Case -1
                lblerror.Text = "無此帳號!"
            Case -999
                lblerror.Text = "密碼錯誤!"
        End Select

        If i < 0 Then
            Exit Sub
        Else
            Session("LoginID") = txtLoginID.Text.Trim
            Session("Password") = txtPassword.Text.Trim
            Response.Redirect("AuthorityTreeView.aspx")

        End If

    End Sub
End Class
