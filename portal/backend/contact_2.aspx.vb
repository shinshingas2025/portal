Public Class contact_2
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents refDate As System.Web.UI.WebControls.RadioButton
    Protected WithEvents refDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents refDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents dealDate As System.Web.UI.WebControls.RadioButton
    Protected WithEvents dealDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents dealDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents dealStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents inquire As System.Web.UI.WebControls.Button
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents cnttype As System.Web.UI.WebControls.DropDownList

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
        '檢查是否已經LoginID
        '---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        '---------------------------------------------
        '取得使用者登入帳號
        userID = context.User.Identity.Name
        'userID = "cadmin"

        flag = False
        If Not IsPostBack Then

            Call showData()
        End If
        objCartDT = CType(Session("Cart"), DataTable)
    End Sub

    '查詢資料(第一次登入時用)
    Sub showData()
        Dim se As New ContactBO
        'objCartDT = se.Query
        objCartDT = se.UserQuery(userID, "", "", "9", "2", 9, "", "", "user")
        '測試用
        'objCartDT = se.UserQuery(userID, "", "", "9", 9, "", "", "admin")
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub

    '查詢資料(使用條件查詢時用)
    'startDate : 起始日期
    'endDate   : 結束日期 
    'status    : 處理狀態
    'num       : 判斷是"反映日期(num = 0)"或"處理日期(num = 1)"查詢用 
    Sub showSelectData(ByVal startDate As String, ByVal endDate As String, ByVal status As String, ByVal cnttype As String, ByVal num As Integer, ByVal likeSel As String, ByVal likeContent As String)
        Dim se As New ContactBO
        objCartDT = se.UserQuery(userID, startDate, endDate, status, cnttype, num, likeSel, likeContent, "user")
        'objCartDT = se.UserQuery(userID, startDate, endDate, status, num, likeSel, likeContent, "admin")
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
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

    Private Sub dgCart_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.EditCommand
        Dim cntno As Integer
        '取得選取的資料ID
        cntno = CType(dgCart.DataKeys(e.Item.ItemIndex), Integer)
        Response.Redirect("contactMgt_2.aspx?cntno=" & cntno)

    End Sub
    Private Function getDate(ByVal dt As String) As String
        Dim temp As Date
        Dim newDate As String
        'Dim y As String
        ' Dim m As String
        'Dim d As String
        If dt <> "" Then

            'y = Left(dt, 4)
            'm = Mid(dt, 5, 2)
            'd = Right(dt, 2)
            'newDate = y & "\" & m & "\" & d
            Try
                newDate = dt.Substring(0, 4) & "/" & dt.Substring(4, 2) & "/" & dt.Substring(6, 2)
                temp = CDate(newDate)
            Catch ex As Exception
                msgbox.Text = "日期格式錯誤!!"
                flag = True
            End Try
            Return newDate
        End If
    End Function

    Private Sub inquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inquire.Click
        Dim startDate As String
        Dim endDate As String
        Dim status As String
        Dim scnttype As String
        Dim num As Integer
        Dim likeSel As String
        Dim likeContent As String

        msgbox.Text = ""
        '判斷是"反映日期(num = 0)"或"處理日期(num = 1)"查詢
        If Me.refDate.Checked = True Then    'num = 0
            num = 0
            startDate = refDateStart.Text
            endDate = refDateEnd.Text
        ElseIf dealDate.Checked = True Then  'num = 1
            num = 1
            startDate = Me.dealDateStart.Text
            endDate = Me.dealDateEnd.Text
        End If
        '全文檢索內容
        likeSel = Me.likeSelect.SelectedValue
        likeContent = Me.likeContent.Text.Trim

        If (refDateStart.Text = "" Or refDateEnd.Text = "") And (dealDateStart.Text = "" Or dealDateEnd.Text = "") Then
            msgbox.Text = "請輸查詢日期!!"
        Else
            startDate = getDate(startDate) & " 00:00:00"
            endDate = getDate(endDate) & " 23:59:59"
            status = dealStatus.SelectedValue
            scnttype = cnttype.SelectedValue
            If Not flag Then
                Call showSelectData(startDate, endDate, status, scnttype, num, likeSel, likeContent)
            End If
        End If
        'Me.dealDateStart.Text = ""
        'Me.dealDateEnd.Text = ""
        'Me.refDateStart.Text = ""
        'Me.refDateEnd.Text = ""
        'Me.likeContent.Text = ""
    End Sub

    Private Sub dgCart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCart.SelectedIndexChanged

    End Sub
End Class
