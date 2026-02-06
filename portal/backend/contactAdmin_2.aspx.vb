Public Class contactAdmin_2
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
    Protected WithEvents cnttype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents inquire As System.Web.UI.WebControls.Button
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents assign As System.Web.UI.WebControls.Button
    Protected WithEvents noAssign As System.Web.UI.WebControls.Button
    Protected WithEvents closeCase As System.Web.UI.WebControls.Button
    Protected WithEvents noClose As System.Web.UI.WebControls.Button

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
        '    Response.Redirect("Default.aspx")
        'End If
        '---------------------------------------------
        flag = False
        If Not IsPostBack Then
            '取得使用者登入帳號
            userID = context.User.Identity.Name
            Call showData()
            'Session("userID") = userID
        End If
        objCartDT = CType(Session("Cart"), DataTable)
        Session("checkRS") = ""
        'Session("accessStatus") = ""
    End Sub

    '查詢資料(第一次登入時用)
    Sub showData()
        Dim se As New ContactBO
        objCartDT = se.Query_2
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
        objCartDT = se.UserQuery(userID, startDate, endDate, status, cnttype, num, likeSel, likeContent, "admin")
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
        Response.Redirect("contactMgt.aspx?cntno=" & cntno)

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
        'Me.refDateStart.Text = ""
        'Me.refDateEnd.Text = ""
        'Me.dealDateStart.Text = ""
        'Me.dealDateEnd.Text = ""
    End Sub
    '指派
    Private Sub assign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assign.Click
        Dim no As String

        msgbox.Text = ""
        no = selectCheckBox()
        If no <> "" Then
            Response.Redirect("assignUser_2.aspx?no=" & no)
            Call showData()
        Else
            msgbox.Text = "請先勾選要指派的人!!"
        End If

    End Sub
    '取消指派
    Private Sub noAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles noAssign.Click
        Dim se As New ContactBO
        Dim no As String

        msgbox.Text = ""
        no = selectCheckBox()

        If no <> "" Then
            se.SelectUpdateD(no)
            Call showData()
        Else
            msgbox.Text = "請先勾選要取消指派的人!!"
        End If

    End Sub

    Private Function selectCheckBox() As String
        Dim selChkBxItem As CheckBox
        Dim selID As Label
        Dim objDataGridItem As DataGridItem
        Dim checkRS As String

        For Each objDataGridItem In dgCart.Items
            '在DataGrid物件中依序找出所要的Item(itemcheck & cntno)==>自訂的樣板
            selChkBxItem = objDataGridItem.FindControl("itemcheck")
            selID = objDataGridItem.FindControl("cntno")
            '判斷找出來的checkBox是否有被選取並作處理
            If selChkBxItem.Checked = True Then 'CheckBox有被選取
                checkRS += selID.Text & ","
            End If
        Next
        If checkRS <> "" Then
            checkRS = checkRS.Substring(0, checkRS.Length - 1)
            Session("checkRS") = checkRS
        End If

        Return checkRS
    End Function
    '已辦結
    Private Sub closeCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeCase.Click
        Dim se As New ContactBO
        Dim no As String

        msgbox.Text = ""
        no = selectCheckBox()

        If no <> "" Then
            '判斷是否填寫回覆資料
            If se.CheckCloseCase(no) Then
                se.CloseCase(no, "U", userID)
                Call showData()
            Else
                msgbox.Text = "回覆內容尚未填寫，無法變更狀態!!"
            End If
        Else
            msgbox.Text = "請先勾選案件!!"
        End If

    End Sub
    '取消辦結
    Private Sub noClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles noClose.Click
        Dim se As New ContactBO
        Dim no As String

        msgbox.Text = ""
        no = selectCheckBox()

        If no <> "" Then
            se.CloseCase(no, "C", userID)
            Call showData()
        Else
            msgbox.Text = "請先勾選案件!!"
        End If

    End Sub
    '檢視意見反映內容

End Class
