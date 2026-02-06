Public Class receipt_notice
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtnotice_content1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtnotice_content2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtnotice_content3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtnotice_content4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtnotice_content5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents txtnotice_content6 As System.Web.UI.WebControls.TextBox

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
        '在這裡放置使用者程式碼以初始化網
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        Dim it As New item
        Dim wk As New ReceiptNoticeBO
        Dim dt As New DataTable
        Dim sIsAdd As String = "Y"
        Dim smsg As String = ""

        objCartDT = CType(Session("Cart"), DataTable)
        smsg = Request("smsg")
        If Not IsPostBack Then
            If smsg = "as" Then
                txtResult.Text = "新增成功!"
            ElseIf smsg = "us" Then
                txtResult.Text = "修改成功!"
            Else
                txtResult.Text = ""
            End If
            dt = wk.Query("1")
            If dt.Rows.Count > 0 Then
                txtnotice_content1.Text = CType(dt.Rows(0).Item("notice_content"), String)
                sIsAdd = "N"
            Else
                txtnotice_content1.Text = ""
            End If
            dt = wk.Query("2")
            If dt.Rows.Count > 0 Then
                txtnotice_content2.Text = CType(dt.Rows(0).Item("notice_content"), String)
                sIsAdd = "N"
            Else
                txtnotice_content2.Text = ""
            End If
            dt = wk.Query("3")
            If dt.Rows.Count > 0 Then
                txtnotice_content3.Text = CType(dt.Rows(0).Item("notice_content"), String)
                sIsAdd = "N"
            Else
                txtnotice_content3.Text = ""
            End If
            dt = wk.Query("4")
            If dt.Rows.Count > 0 Then
                txtnotice_content4.Text = CType(dt.Rows(0).Item("notice_content"), String)
                sIsAdd = "N"
            Else
                txtnotice_content4.Text = ""
            End If
            dt = wk.Query("5")
            If dt.Rows.Count > 0 Then
                txtnotice_content5.Text = CType(dt.Rows(0).Item("notice_content"), String)
                sIsAdd = "N"
            Else
                txtnotice_content5.Text = ""
            End If
            dt = wk.Query("6")
            If dt.Rows.Count > 0 Then
                txtnotice_content6.Text = CType(dt.Rows(0).Item("notice_content"), String)
                sIsAdd = "N"
            Else
                txtnotice_content6.Text = ""
            End If

            If sIsAdd = "Y" Then
                btnAdd.Visible = True
                btnupdate.Visible = False
            Else
                btnAdd.Visible = False
                btnupdate.Visible = True
            End If
        End If
    End Sub

    Private Function checkFields() As Boolean
        txtResult.Text = ""

        Return True

    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If checkFields() = False Then
            Exit Sub
        End If
        Dim cm As New ReceiptNoticeBO
        Dim cn As New Enreceiptnotice

        cn.notice_content1 = txtnotice_content1.Text.Trim
        cn.notice_line = "1"
        cn.upd_user = Session("UserName").Trim
        cm.Insert(cn)

        cn.notice_content2 = txtnotice_content2.Text.Trim
        cn.notice_line = "2"
        cn.upd_user = Session("UserName").Trim
        cm.Insert(cn)

        cn.notice_content3 = txtnotice_content3.Text.Trim
        cn.notice_line = "3"
        cn.upd_user = Session("UserName").Trim
        cm.Insert(cn)

        cn.notice_content4 = txtnotice_content4.Text.Trim
        cn.notice_line = "4"
        cn.upd_user = Session("UserName").Trim
        cm.Insert(cn)

        cn.notice_content5 = txtnotice_content5.Text.Trim
        cn.notice_line = "5"
        cn.upd_user = Session("UserName").Trim
        cm.Insert(cn)

        cn.notice_content6 = txtnotice_content6.Text.Trim
        cn.notice_line = "6"
        cn.upd_user = Session("UserName").Trim
        cm.Insert(cn)

        txtResult.Text = "新增成功!"

        Response.Redirect("receipt_notice.aspx?smsg=as")
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If checkFields() = False Then
            Exit Sub
        End If
        Dim cn As New Enreceiptnotice
        Dim sc As New ReceiptNoticeBO
        Dim test As String


        cn.notice_content1 = txtnotice_content1.Text.Trim
        cn.notice_line = "1"
        cn.upd_user = Session("UserName").Trim
        test = sc.Update(cn)

        cn.notice_content2 = txtnotice_content2.Text.Trim
        cn.notice_line = "2"
        cn.upd_user = Session("UserName").Trim
        test = sc.Update(cn)

        cn.notice_content3 = txtnotice_content3.Text.Trim
        cn.notice_line = "3"
        cn.upd_user = Session("UserName").Trim
        test = sc.Update(cn)

        cn.notice_content4 = txtnotice_content4.Text.Trim
        cn.notice_line = "4"
        cn.upd_user = Session("UserName").Trim
        test = sc.Update(cn)

        cn.notice_content5 = txtnotice_content5.Text.Trim
        cn.notice_line = "5"
        cn.upd_user = Session("UserName").Trim
        test = sc.Update(cn)

        cn.notice_content6 = txtnotice_content6.Text.Trim
        cn.notice_line = "6"
        cn.upd_user = Session("UserName").Trim
        test = sc.Update(cn)

        txtResult.Text = "修改成功!"

        Response.Redirect("receipt_notice.aspx?smsg=us")
    End Sub
    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("receipt_notice.aspx")
    End Sub

End Class
