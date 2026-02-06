Imports System.Configuration
Public Class member_house_log
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents txtDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents inquire As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

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
    Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2fMemberTransLog&rc:Parameters=false"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        '取得使用者登入帳號
        userID = Context.User.Identity.Name
        'userID = "cadmin"

        flag = False
        If Not IsPostBack Then


        End If
        objCartDT = CType(Session("Cart"), DataTable)
    End Sub

    Private Sub NavigateToPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim PageInfo As String = CType(sender, Button).CommandName
        Select Case PageInfo
            Case "第一頁"
                dgCart.CurrentPageIndex = 0
            Case "上一頁"
                If (dgCart.CurrentPageIndex > 0) Then
                    dgCart.CurrentPageIndex -= 1
                End If
            Case "下一頁"
                If (dgCart.CurrentPageIndex < (dgCart.PageCount - 1)) Then
                    dgCart.CurrentPageIndex += 1
                End If
            Case "最後一頁"
                dgCart.CurrentPageIndex = (dgCart.PageCount - 1)
        End Select
        Call showData()
    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Function getDate(ByVal dt As String, ByVal defaultdate As String) As String
        Dim temp As Date
        Dim newDate As String

        If dt <> "" Then
            Try
                dt = dt + 19110000
                newDate = dt.Substring(0, 4) & "/" & dt.Substring(4, 2) & "/" & dt.Substring(6, 2)
                temp = CDate(newDate)
            Catch ex As Exception
                msgbox.Text = "日期格式錯誤!!"
                Exit Function
            End Try
        Else
            newDate = defaultdate
        End If
        Return newDate
    End Function

    Private Sub inquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inquire.Click
        dgCart.CurrentPageIndex = 0
        Call showData()
    End Sub

    Sub showData()
        Dim se As New MemberTransLogBO
        Dim sDateStart As String = ""
        Dim sDateEnd As String = ""

        msgbox.Text = ""
        sDateStart = getDate(txtDateStart.Text.ToString.Trim, "1911/01/01")
        sDateEnd = getDate(txtDateEnd.Text.ToString.Trim, "9999/12/31")
        If msgbox.Text <> "" Then
            Exit Sub
        End If

        objCartDT = se.UserQuery(sDateStart, sDateEnd)

        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    ' Dim sDateStart As String = ""
    'Dim sDateEnd As String = ""

    'msgbox.Text = ""
    'sDateStart = getDate(txtDateStart.Text.ToString.Trim, "1911/01/01")
    'sDateEnd = getDate(txtDateEnd.Text.ToString.Trim, "9999/12/31")
    'If msgbox.Text <> "" Then
    '    Exit Sub
    'End If


    'Response.Redirect(IFrameSrc & "&myStartDate=" & sDateStart & "&myEndDate=" & sDateEnd)

    'End Sub

End Class
