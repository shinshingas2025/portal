Public Class login
    Inherits System.Web.UI.Page
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents useridRequired As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents useridValid As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents userpwRequired As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblerror As System.Web.UI.WebControls.Label
    Protected WithEvents txtLoginID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents PersistentCookie As System.Web.UI.WebControls.CheckBox

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents loginbutton As System.Web.UI.WebControls.Button

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
        If (Session("LoginID") Is Nothing) Then
        Else
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Private Sub loginbutton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loginbutton.Click
        Dim se As New Security
        Dim at As New Account
        at.userid = txtLoginID.Text.Trim
        at.userpw = txtPassword.Text.Trim
        Dim i As Integer = se.CheckAccount(at)

        Select Case i
            Case 0
            Case -1
                lblerror.Text = "無此帳號"
            Case -999
                lblerror.Text = "密碼錯誤"
            Case -998
                lblerror.Text = "帳號停用,請洽系統管理者"
        End Select

        If i < 0 Then
            Exit Sub
        Else
            Dim usergroup As String = se.GetGroup(at)
            Session("LoginID") = txtLoginID.Text.Trim
            Session("Password") = txtPassword.Text.Trim
            Session("Usergrp") = usergroup
            Response.Redirect("Default.aspx")

        End If


    End Sub

End Class
