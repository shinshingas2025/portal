Public Class contactEdit
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents cntName As System.Web.UI.WebControls.TextBox
    Protected WithEvents cntemail As System.Web.UI.WebControls.TextBox
    Protected WithEvents cntsubject As System.Web.UI.WebControls.TextBox
    Protected WithEvents cnttel As System.Web.UI.WebControls.TextBox
    Protected WithEvents createdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents cntcontent As System.Web.UI.WebControls.TextBox
    Protected WithEvents remark As System.Web.UI.WebControls.TextBox
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents workdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents cntno As System.Web.UI.WebControls.Label
    Protected WithEvents workstatus As System.Web.UI.WebControls.DropDownList

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
        '---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        '---------------------------------------------



        If Not IsPostBack Then
            Dim objcnt As New contact
            Dim objcntBO As New ContactBO
            Dim dt As DataTable

            cntno.Text = Request.Params("cntno").ToString
            dt = objcntBO.Query(CType(cntno.Text, Integer))
            If dt.Rows.Count > 0 Then

                cntsubject.Text = CType(dt.Rows(0).Item("cntsubject"), String)
                cntcontent.Text = CType(dt.Rows(0).Item("cntcontent"), String)
                cnttel.Text = CType(dt.Rows(0).Item("cnttel"), String)
                cntemail.Text = CType(dt.Rows(0).Item("cntemail"), String)
                createdate.Text = CType(dt.Rows(0).Item("createdate"), String)
                cntName.Text = CType(dt.Rows(0).Item("cntName"), String)
                createGroup.Text = CType(dt.Rows(0).Item("WorkUnit"), String)
                Creater.Text = CType(dt.Rows(0).Item("operator"), String)
                workstatus.SelectedValue = CType(dt.Rows(0).Item("workstatus"), String).Trim
                workdate.Text = CType(dt.Rows(0).Item("workdate"), String)
                remark.Text = CType(dt.Rows(0).Item("remark"), String)


            End If


        End If
    End Sub



    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click

    End Sub
End Class
