Public Class AccountView
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents txtLoginID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword2 As System.Web.UI.WebControls.TextBox
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


    Dim objDR As DataRow
    Dim objCartDT As DataTable
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        objCartDT = CType(Session("Cart"), DataTable)
        If Not IsPostBack Then

            Call showData()

        End If
    End Sub

    Sub dgCart_Edit(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        dgCart.EditItemIndex = e.Item.ItemIndex

        dgCart.DataSource = objCartDT
        dgCart.DataBind()
    End Sub

    Sub dgCart_Cancel(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        dgCart.EditItemIndex = -1

        dgCart.DataSource = objCartDT
        dgCart.DataBind()
    End Sub

    Sub dgCart_Update(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim txtPassword As TextBox
        Dim LoginID As String
        Dim ac As New Account
   
        Dim sc As New Security

        LoginID = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        txtPassword = CType(e.Item.FindControl("txtPassword"), TextBox)

        For Each objDR In objCartDT.Rows
            If Trim(CType(objDR("LoginID"), String)) = LoginID.Trim Then
                ac.Password = txtPassword.Text.Trim
                ac.LoginID = LoginID
                sc.UpdateaAccount(ac)

                Exit For
            End If
        Next

  

        dgCart.EditItemIndex = -1
        Call showData()

    End Sub

    Sub showData()
        Dim se As New Security
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New Security
        Dim LoginID As String
        LoginID = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))


        objCartDT.Rows(e.Item.ItemIndex).Delete()
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        sc.Delete(LoginID)
  
        Call showData()


    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        dgCart.DataSource = objCartDT

        DataBind()
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
        cn.LoginID = txtLoginID.Text.Trim
        cn.Password = txtPassword1.Text.Trim


        cm.Insert(cn)

        txtResult.Text = "新增成功!"

        Call showData()



    End Sub

    Private Sub dgCart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCart.SelectedIndexChanged

    End Sub
End Class
