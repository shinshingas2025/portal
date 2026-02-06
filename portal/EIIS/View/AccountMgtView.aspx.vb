Public Class AccountMgtView
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents txtPassword1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLoginID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label

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

        txtLoginID.Text = Request.Params("objValue")

        If Not IsPostBack Then
            txtStartDate.Text = Convert.ToString(Year(Now())) & "/" & Month(Now()) & "/" & Day(Now())
            txtEndDate.Text = Convert.ToString(Year(Now())) & "/" & "12" & "/" & "31"
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim cm As New Security
        Dim cn As New Account
        If txtPassword1.Text.Trim <> txtPassword2.Text.Trim Then
            txtResult.Text = "請再次確確密碼是否正確!"
            Exit Sub
        Else
            If cm.Query(txtLoginID.Text.Trim).Rows.Count > 0 Then
                txtResult.Text = "帳號重覆!"
                Exit Sub
            Else

            End If

        End If
        Dim ps As New ASPNET.StarterKit.Portal.PortalSecurity
        cn.LoginID = txtLoginID.Text.Trim
        cn.Password = ps.Encrypt(txtPassword1.Text.Trim)
        cn.UID = CType(Session("CommunityNodePID"), Integer)
        cn.StartDate = CType(txtStartDate.Text.Trim, Date)
        cn.EndDate = CType(txtEndDate.Text.Trim, Date)

        cm.Insert(cn)

        '  txtResult.Text = "新增成功!"

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
End Class
