Public Class wmember_01
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents applydateO As System.Web.UI.WebControls.RadioButton
    Protected WithEvents ApplySDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ApplyEDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents status As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents btnPrint As System.Web.UI.WebControls.Button
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents btn As System.Web.UI.WebControls.Button
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents likeFlag As System.Web.UI.WebControls.Label
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnreturn As System.Web.UI.WebControls.Button

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
    Dim AppEDATE, AppSDATE, ProSdate, ProEdate, sendSDATE, sendEDATE As String
    Dim flag As Boolean

    Dim ReportServer As String = Configration.ReportServerURL

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        'objCartDT = CType(Session("Cart"), DataTable)
        If Not IsPostBack Then
            Call GetUser(context.User.Identity.Name.Trim)

            'ApplySDATE.Text = CType(Year(Now), String) + "/" + CType(Month(Now), String) + "/" + CType(Day(Now), String)
            'ApplyEDATE.Text = CType(Year(Now), String) + "/" + CType(Month(Now), String) + "/" + CType(Day(Now), String)
            'ProcessSDATE.Text = CType(Year(Now), String) + "/" + CType(Month(Now), String) + "/" + CType(Day(Now), String)
            'ProcessEDATE.Text = CType(Year(Now), String) + "/" + CType(Month(Now), String) + "/" + CType(Day(Now), String)

            'ApplySDATE.Text = Right("00" + ((CInt(CType(Year(Now), String)) - 1911).ToString), 3) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            'ApplyEDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            'ApplyEDATE.Text = (CInt(CType(Year(Now), String)) - 1911).ToString + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            'ApplyEDATE.Text = Right("00" + ((CInt(CType(Year(Now), String)) - 1911).ToString), 3) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)

        End If


    End Sub
    Private Sub GetUser(ByVal user As String)
        Dim objUser As New UserInfoBO
        Dim objDeptBO As New OrgBO
        Dim objDept As New DeptExtendOrgEntity
        Dim dt As New DataTable
        dt = objUser.QueryUserInfo(user)
        If dt.Rows.Count > 0 Then
            objDept.DeptID = dt.Rows(0).Item("Dept")
            Creater.Text = dt.Rows(0).Item("Cname")
            dt = objDeptBO.QueryDept(objDept)
            If dt.Rows.Count > 0 Then
                createGroup.Text = dt.Rows(0).Item("objname")
            End If
        End If

    End Sub

    'Sub showData()
    '    Dim se As New NewApplyFormBO
    '    If applydateO.Checked = True Then
    '        Dim tmpAppEDATE As String = ApplyEDATE.Text.Trim
    '        AppEDATE = Left(tmpAppEDATE, 4) + "/" + Mid(tmpAppEDATE, 5, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"
    '        'AppSDATE = ApplySDATE.Text.Trim + " 00:00:00"
    '        AppSDATE = Left(ApplySDATE.Text.Trim, 4) + "/" + Mid(ApplySDATE.Text.Trim, 5, 2) + "/" + CType(Right(ApplySDATE.Text.Trim, 2), String) + " 00:00:00"

    '        ProSdate = "1900/01/01"
    '        ProEdate = "2099/12/31"

    '        objCartDT = se.QueryDate(status.SelectedValue, AppSDATE, AppEDATE, "", "")
    '    Else
    '        AppSDATE = "1900/01/01"
    '        AppEDATE = "2099/12/31"

    '        objCartDT = se.QueryDate(status.SelectedValue, "", "", ProSdate, ProEdate)
    '    End If


    '    dgCart.DataSource = objCartDT
    '    dgCart.DataBind()
    '    ShowPageStatus(objCartDT.Rows.Count)
    'End Sub

    'Private Function getDate(ByVal dt As String) As String
    '    Dim temp As Date
    '    Dim newDate As String
    '    'Dim y As String
    '    ' Dim m As String
    '    'Dim d As String
    '    If dt <> "" Then

    '        'y = Left(dt, 4)
    '        'm = Mid(dt, 5, 2)
    '        'd = Right(dt, 2)
    '        'newDate = y & "\" & m & "\" & d
    '        Try
    '            newDate = dt.Substring(0, 4) & "/" & dt.Substring(4, 2) & "/" & dt.Substring(6, 2)
    '            temp = CDate(newDate)
    '        Catch ex As Exception
    '            msgbox.Text = "日期格式錯誤!!"
    '            flag = True
    '        End Try
    '        Return newDate
    '    End If
    'End Function

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

    Private Function getDefaulVal(ByVal dt As String, ByVal defaultdate As String) As String
        Dim temp As Date
        Dim newVal As String

        If dt <> "" Then
            newVal = dt
        Else
            newVal = defaultdate
        End If
        Return newVal
    End Function

    Sub showData()
        Dim se As New WebmemberBO
        'Dim tmpAppEDATE As String
        'Dim tmpAppSDATE As String
        'Dim tmpAppEDATE1 As String
        'Dim tmpAppSDATE1 As String
        Dim sDateStart As String = ""
        Dim sDateEnd As String = ""
        Dim likeSel As String
        Dim likeContent As String
        Dim likeFlag As String
        Dim i As Integer
        'CheckBox1.Checked 選擇已啟動、已設定用戶號碼資料
        'CheckBox2.Checked 選擇已啟動、尚未設定用戶號碼資料
        'CheckBox3.Checked 選擇尚未啟動資料
        'CheckBox4.Checked 選擇授權碼發送失敗資料
        'CheckBox5.Checked 選擇停權資料
        'CheckBox6.Checked 選擇個人用戶
        'CheckBox7.Checked 選擇營業用戶
        'CheckBox8.Checked 選擇機關用戶

        'If (ApplySDATE.Text.Trim <> "") Then
        '    tmpAppSDATE = (Val(ApplySDATE.Text.Trim)).ToString
        '    If tmpAppSDATE.Length = 6 Then
        '        tmpAppSDATE1 = (Val(Left(tmpAppSDATE, 2)) + 1911).ToString + Mid(tmpAppSDATE, 3, 2) + CType(Right(tmpAppSDATE, 2), String)
        '        tmpAppSDATE = (Val(Left(tmpAppSDATE, 2)) + 1911).ToString + "/" + Mid(tmpAppSDATE, 3, 2) + "/" + CType(Right(tmpAppSDATE, 2), String) + " 00:00:00"
        '    ElseIf tmpAppSDATE.Length = 7 Then
        '        tmpAppSDATE1 = (Val(Left(tmpAppSDATE, 3)) + 1911).ToString + Mid(tmpAppSDATE, 4, 2) + CType(Right(tmpAppSDATE, 2), String)
        '        tmpAppSDATE = (Val(Left(tmpAppSDATE, 3)) + 1911).ToString + "/" + Mid(tmpAppSDATE, 4, 2) + "/" + CType(Right(tmpAppSDATE, 2), String) + " 00:00:00"
        '    Else
        '        tmpAppSDATE = "1900/01/01 00:00:00"
        '    End If
        '    'tmpAppSDATE = Left(tmpAppSDATE, 4) + "/" + Mid(tmpAppSDATE, 5, 2) + "/" + CType(Right(tmpAppSDATE, 2), String) + " 00:00:00"
        'Else
        '    tmpAppSDATE = "1900/01/01 00:00:00"
        'End If

        'If (ApplySDATE.Text.Trim <> "") Then
        '    tmpAppEDATE = (Val(ApplyEDATE.Text.Trim)).ToString
        '    If tmpAppEDATE.Length = 6 Then
        '        tmpAppEDATE1 = (Val(Left(tmpAppEDATE, 2)) + 1911).ToString + Mid(tmpAppEDATE, 3, 2) + CType(Right(tmpAppEDATE, 2), String)
        '        tmpAppEDATE = (Val(Left(tmpAppEDATE, 2)) + 1911).ToString + "/" + Mid(tmpAppEDATE, 3, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"
        '    ElseIf tmpAppEDATE.Length = 7 Then
        '        tmpAppEDATE1 = (Val(Left(tmpAppEDATE, 3)) + 1911).ToString + Mid(tmpAppEDATE, 4, 2) + CType(Right(tmpAppEDATE, 2), String)
        '        tmpAppEDATE = (Val(Left(tmpAppEDATE, 3)) + 1911).ToString + "/" + Mid(tmpAppEDATE, 4, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"
        '    Else
        '        tmpAppEDATE = "2099/12/31 23:59:59"
        '    End If
        '    'tmpAppEDATE = Left(tmpAppEDATE, 4) + "/" + Mid(tmpAppEDATE, 5, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"
        'Else
        '    tmpAppEDATE = "2099/12/31 23:59:59"
        'End If

        'sendSDATE = tmpAppSDATE
        'sendEDATE = tmpAppEDATE

        'Dim startDate As String
        'Dim endDate As String

        'If tmpAppSDATE1 <> "" Then
        '    startDate = getDate(tmpAppSDATE1)
        'End If
        'If tmpAppEDATE1 <> "" Then
        '    endDate = getDate(tmpAppEDATE1)
        'End If

        'If msgbox.Text <> "日期格式錯誤!!" Then

        '    If (DateTime.Compare(CDate(tmpAppSDATE), CDate(tmpAppEDATE)) > 0) Then
        '        msgbox.Text = "日期區間錯誤!!"
        '    Else

        sDateStart = getDate(ApplySDATE.Text.ToString.Trim, "1911/01/01")
        sDateEnd = getDate(ApplyEDATE.Text.ToString.Trim, "9999/12/31")
        If (getDefaulVal(ApplySDATE.Text.ToString.Trim, 0) > getDefaulVal(ApplyEDATE.Text.ToString.Trim, 9991231)) Then
            msgbox.Text = "起始日不可大於終止日!!"
        End If

        If msgbox.Text <> "" Then
            Exit Sub
        Else
            sDateStart = sDateStart + " 00:00:00"
            sDateEnd = sDateEnd + " 23:59:59"
        End If

        '全文檢索內容
        likeSel = Me.likeSelect.SelectedValue
        likeContent = Me.likeContent.Text.Trim
        'likeFlag = Me.likeFlag.Text.Trim

        If CheckDataAll() <> 0 Then
            objCartDT = se.QueryMemDate1(sDateStart, sDateEnd, likeSel, likeContent, status.SelectedValue)

            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            ShowPageStatus(objCartDT.Rows.Count)
        Else
            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            Message.Text = ""
        End If


        '    End If
        'End If

    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call SearchPorcess()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        dgCart.CurrentPageIndex = 0
        SearchPorcess()
    End Sub

    Private Sub SearchPorcess()
        'If applydateO.Checked = True Then
        '    If ApplySDATE.Text.Trim = "" And ApplyEDATE.Text.Trim = "" Then
        '        msgbox.Text = "請輸入查詢日期!"
        '        Exit Sub
        '    ElseIf ApplySDATE.Text.Trim <> "" And ApplyEDATE.Text.Trim = "" Then
        '        ApplyEDATE.Text = ApplySDATE.Text
        '    End If

        'End If
        msgbox.Text = ""
        showData()

    End Sub

    Private Sub dgCart_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.EditCommand

        dgCart.EditItemIndex = e.Item.ItemIndex
        SearchPorcess()
    End Sub

    Private Sub dgCart_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.CancelCommand
        dgCart.EditItemIndex = -1
        SearchPorcess()
    End Sub

    Private Sub dgCart_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.UpdateCommand
        Dim status As CheckBox

        Dim EntityID As String
        Dim na As New NewApplyFormBO



        EntityID = dgCart.DataKeys(e.Item.ItemIndex).ToString().Trim

        status = CType(e.Item.FindControl("txtstatus"), CheckBox)

        Dim nflag As String
        If status.Checked = True Then
            nflag = "1"
        Else
            nflag = "0"

        End If

        na.Update(EntityID, nflag, Creater.Text.Trim)




        dgCart.EditItemIndex = -1
        Call SearchPorcess()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If applydateO.Checked = True Then
            If ApplySDATE.Text.Trim = "" Or ApplyEDATE.Text.Trim = "" Then
                msgbox.Text = "請輸入查詢日期!"
                Exit Sub
            End If

        End If
        msgbox.Text = ""
        showData()
        'Response.Redirect("http://rpti3-2003/ReportServer?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e4%b8%80%e8%a6%bd%e8%a1%a8&SDATE=" & ApplySDATE.Text.Trim & "&EDATE=" & ApplyEDATE.Text.Trim & "&STATUS=" & status.SelectedValue & "&rs%3aClearSession=true&rs%3aCommand=Render&rs%3aFormat=HTML4.0&rc%3aReplacementRoot=http%3a%2f%2frpti3-2003%2fReports%2fPages%2fReport.aspx%3fServerUrl%3d&rc%3aToolbar=True&rc%3aJavaScript=True&rc%3aLinkTarget=_top&rc%3aArea=Report")
        Response.Redirect(ReportServer & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e8%a1%a8&AppSDATE=" & AppSDATE & "&AppEDATE=" & AppEDATE & "&ProSDATE=" & ProSdate & "&ProEDATE=" & ProEdate & "&STATUS=" & status.SelectedValue & "&EntityID=%" & "&rc:Parameters=false")
    End Sub

    Private Sub dgCart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCart.SelectedIndexChanged

        ' Dim ss As String = sender.GetType.ToString()
        Dim entityid As String
        entityid = dgCart.DataKeys(dgCart.SelectedIndex).ToString().Trim
        Dim UrlStr As String
        'UrlStr = "http://rpti3-nz/Reports/Pages/Report.aspx?ItemPath=%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e8%a1%a8&AppSDATE=1900/01/01&AppEDATE=2099/12/31&ProSDATE=1900/01/01&ProEDATE=2099/12/31&STATUS=" & status.SelectedValue & "&EntityID=" & entityid & ""
        UrlStr = "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e8%a1%a8&AppSDATE=1900/01/01&AppEDATE=2099/12/31&ProSDATE=1900/01/01&ProEDATE=2099/12/31&STATUS=" & status.SelectedValue & "&EntityID=" & entityid
        Response.Redirect(ReportServer & UrlStr & "&rc:Parameters=false")
    End Sub

    Private Sub dgCart_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.ItemCommand
        Dim wmno As String
        Dim wm_orgflag As String

        msgbox.Text = ""
        '取得觸發資料行的ID
        Try
            'Select Case (CType(e.CommandSource, Button)).CommandName
            Select Case e.CommandName

                Case "detail"
                    'wm_orgflag = e.Item.Cells(0).Text()
                    'wmno = e.Item.Cells(1).Text()
                    wm_orgflag = e.Item.Cells(10).Text()
                    wmno = e.Item.Cells(11).Text()
                    If wm_orgflag = "1" Then
                        Response.Redirect("wmemberView_01.aspx?wm_no=" & wmno)
                    Else
                        Response.Redirect("wmemberView_02.aspx?wm_no=" & wmno)
                    End If

                Case Else

            End Select
        Catch ex As System.InvalidCastException
            ex.ToString()
            Exit Sub
        End Try


    End Sub

#Region "CheckDataAll　檢查輸入的值是否符合要求"
    Function CheckDataAll() As Integer
        Dim ReMsg As Integer = 0

        'If Trim(Me.likeSelect.SelectedValue) = "wm_id" Then
        If InStr(1, likeContent.Text, "'") >= 1 Then
            msgbox.Text = "格式錯誤"
            Return ReMsg
        Else
            ReMsg = 1
        End If
        'Else
        'ReMsg = 1
        'End If

        Return ReMsg
    End Function
#End Region

End Class
