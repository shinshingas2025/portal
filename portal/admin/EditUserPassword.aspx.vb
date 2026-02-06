
Public Class EditUserPassword
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents txtPassword1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtOldPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLoginID As System.Web.UI.WebControls.Label
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
    Dim oldPassword As String
    Dim oldStartDate As String
    Dim oldEndDate As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁

        txtLoginID.Text = Context.User.Identity.Name

        Dim cm As New Security
        Dim dt As DataTable
        dt = cm.Query(txtLoginID.Text.Trim)
        oldPassword = CType(dt.Rows(0).Item("password"), String)
        oldStartDate = CType(dt.Rows(0).Item("StartDate"), String)
        oldEndDate = CType(dt.Rows(0).Item("EndDate"), String)
        dt = Nothing
        cm = Nothing
        If Not IsPostBack Then

        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim cm As New Security
        Dim cn As New Account
        Dim ps As New ASPNET.StarterKit.Portal.PortalSecurity

        If ps.Encrypt(txtOldPassword.Text.Trim) <> oldPassword.Trim Then
            txtResult.Text = "請確認舊密碼是否正確!"
            Exit Sub
        End If
        If txtPassword1.Text.Trim <> txtPassword2.Text.Trim Then
            txtResult.Text = "請再次確認密碼是否正確!"
            Exit Sub
        End If


        cn.LoginID = txtLoginID.Text.Trim
        cn.Password = ps.Encrypt(txtPassword1.Text.Trim)
        cn.StartDate = Format(CType(oldStartDate.Trim, Date), "yyyy/MM/dd") 'CType(oldStartDate.Trim, Date)
        cn.EndDate = Format(CType(oldEndDate.Trim, Date), "yyyy/MM/dd") 'CType(oldEndDate.Trim, Date)

        cm.UpdateaAccount(cn)

        txtResult.Text = "密碼修改成功!"

        '    Call returnValue("True")



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
