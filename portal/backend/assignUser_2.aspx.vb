Public Class assignUser_2
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents groupName As System.Web.UI.WebControls.DropDownList
    Protected WithEvents userName As System.Web.UI.WebControls.DropDownList
    Protected WithEvents confirm As System.Web.UI.WebControls.Button

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
    Dim checkRS As String
    Dim no As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '檢查是否已經LoginID
        '---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        '---------------------------------------------
        checkRS = Session("checkRS")
        no = checkRS
        msgbox.Text = ""
        If Not IsPostBack Then

            Call showData()
        End If
        objCartDT = CType(Session("Cart"), DataTable)
    End Sub

    '查詢資料(第一次登入時用)
    Sub showData()
        Dim se As New vUserInfoBO
        Dim i As Integer = 0

        objCartDT = se.Query()
        groupName.Items.Clear()

        For i = 0 To objCartDT.Rows.Count - 1
            Dim itemlist As New ListItem
            itemlist.Text = CType(objCartDT.Rows(i).Item("GroupName"), String).Trim
            itemlist.Value = CType(objCartDT.Rows(i).Item("PID"), String).Trim
            groupName.Items.Add(itemlist)
        Next


        'Session("cart") = objCartDT
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

            End Try
            Return newDate
        End If
    End Function

    Private Sub confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles confirm.Click
        Dim se As New ContactBO
        Dim UID As String

        If groupName.SelectedValue = "" Or userName.SelectedValue = "" Then
            msgbox.Text = "請選擇欲指派的人員!!"
        Else
            UID = userName.SelectedValue
            se.SelectUpdateU(no, UID)
            Response.Redirect("contactAdmin_2.aspx")
        End If
        
    End Sub

    Private Sub groupName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles groupName.SelectedIndexChanged
        Dim se As New vUserInfoBO
        Dim i As Integer = 0
        Dim PID As String

        PID = groupName.SelectedValue()
        objCartDT = se.Query(PID)
        userName.Items.Clear()

        For i = 0 To objCartDT.Rows.Count - 1
            Dim itemlist As New ListItem
            itemlist.Text = CType(objCartDT.Rows(i).Item("userName"), String).Trim
            itemlist.Value = CType(objCartDT.Rows(i).Item("UID"), String).Trim
            userName.Items.Add(itemlist)
        Next
    End Sub
End Class
