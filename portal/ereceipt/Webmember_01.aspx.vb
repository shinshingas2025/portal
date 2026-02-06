
Public Class Webmember_01
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents ApplyEDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ApplySDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox2 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox3 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox4 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox5 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Checkbox6 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox7 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox8 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents s_button As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents CompareValidator2 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator

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
    Dim ReportServer As String = Configration.ReportServerURL
    Dim flag As Boolean

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
            'ApplySDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            'ApplyEDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
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
        Dim sDateStart As String = ""
        Dim sDateEnd As String = ""
        Dim likeSel As String
        Dim likeContent As String
        Dim chkCheckBox1 As String = "Y"
        Dim chkCheckBox2 As String = "Y"
        Dim chkCheckBox3 As String = "Y"
        Dim chkCheckBox4 As String = "Y"
        Dim chkCheckBox5 As String = "Y"
        Dim chkCheckBox6 As String = "Y"
        Dim chkCheckBox7 As String = "Y"
        Dim chkCheckBox8 As String = "Y"
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
        '        ApplySDATE.Text = ""
        '    End If
        '    'tmpAppSDATE = Left(tmpAppSDATE, 4) + "/" + Mid(tmpAppSDATE, 5, 2) + "/" + CType(Right(tmpAppSDATE, 2), String) + " 00:00:00"
        'Else
        '    tmpAppSDATE = "1900/01/01 00:00:00"
        'End If

        'If (ApplyEDATE.Text.Trim <> "") Then
        '    tmpAppEDATE = (Val(ApplyEDATE.Text.Trim)).ToString
        '    If tmpAppEDATE.Length = 6 Then
        '        tmpAppEDATE1 = (Val(Left(tmpAppEDATE, 2)) + 1911).ToString + Mid(tmpAppEDATE, 3, 2) + CType(Right(tmpAppEDATE, 2), String)
        '        tmpAppEDATE = (Val(Left(tmpAppEDATE, 2)) + 1911).ToString + "/" + Mid(tmpAppEDATE, 3, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"
        '    ElseIf tmpAppEDATE.Length = 7 Then
        '        tmpAppEDATE1 = (Val(Left(tmpAppEDATE, 3)) + 1911).ToString + Mid(tmpAppEDATE, 4, 2) + CType(Right(tmpAppEDATE, 2), String)
        '        tmpAppEDATE = (Val(Left(tmpAppEDATE, 3)) + 1911).ToString + "/" + Mid(tmpAppEDATE, 4, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"
        '    Else
        '        tmpAppEDATE = "2099/12/31 23:59:59"
        '        ApplyEDATE.Text = ""
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

        If CheckBox1.Checked = False Then
            chkCheckBox1 = "N"
        End If
        If Checkbox2.Checked = False Then
            chkCheckBox2 = "N"
        End If
        If Checkbox3.Checked = False Then
            chkCheckBox3 = "N"
        End If
        If Checkbox4.Checked = False Then
            chkCheckBox4 = "N"
        End If
        If Checkbox5.Checked = False Then
            chkCheckBox5 = "N"
        End If
        If Checkbox6.Checked = False Then
            chkCheckBox6 = "N"
        End If
        If Checkbox7.Checked = False Then
            chkCheckBox7 = "N"
        End If
        If Checkbox8.Checked = False Then
            chkCheckBox8 = "N"
        End If


        '全文檢索內容
        likeSel = Me.likeSelect.SelectedValue
        likeContent = Me.likeContent.Text.Trim

        If CheckDataAll() <> 0 Then

            objCartDT = se.QueryMemDate(sDateStart, sDateEnd, chkCheckBox1, chkCheckBox2, chkCheckBox3, chkCheckBox4, chkCheckBox5, chkCheckBox6, chkCheckBox7, chkCheckBox8, likeSel, likeContent)

            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            ShowPageStatus(objCartDT.Rows.Count)

        'Button1.Visible = True
        'Button2.Visible = True

            If objCartDT.Rows.Count > 0 Then
                '    If CheckBox1.Checked = True Or Checkbox2.Checked = True Or (CheckBox1.Checked = True And Checkbox2.Checked = True) Then
                '        If Checkbox3.Checked = True Or Checkbox4.Checked = True Or Checkbox5.Checked = True Then
                '            Button2.Visible = True
                '        Else
                '            Button2.Visible = False
                '        End If
                '    Else
                '        If Checkbox3.Checked = True Or Checkbox4.Checked = True Then
                '            Button2.Visible = True
                '        Else
                '            Button2.Visible = False
                '        End If
                '    End If
                '    If CheckBox1.Checked = True Then
                '        If Checkbox2.Checked = True Or Checkbox3.Checked = True Or Checkbox4.Checked = True Or Checkbox5.Checked = True Then
                '            'If Checkbox5.Checked = True Then
                '            '    Button1.Visible = False
                '            'Else
                '                Button1.Visible = True
                '            'End If
                '        Else
                '            Button1.Visible = False
                '        End If
                '    Else
                '        If Checkbox3.Checked = True Or Checkbox4.Checked = True Then
                '            Button1.Visible = False
                '        Else
                '            If Checkbox5.Checked = True Then
                '                Button1.Visible = False
                '            Else
                '                Button1.Visible = True
                '            End If

                '        End If
                '    End If
                'Else
                '    Button1.Visible = False
                '    Button2.Visible = False
                'End If

                'If Checkbox3.Checked = True Or Checkbox4.Checked = True Then
                '    If (CheckBox1.Checked = True And Checkbox2.Checked = True And Checkbox5.Checked = True) Then
                '        Button1.Visible = True
                '        Button2.Visible = True
                '    Else
                '        Button1.Visible = False
                '        Button2.Visible = True
                '    End If
                'Else
                '    If Checkbox5.Checked = True Then
                '        Button1.Visible = False
                '        Button2.Visible = False
                '    Else
                '        Button1.Visible = True
                '        Button2.Visible = True
                '    End If
                'End If

                If CheckBox1.Checked = True Or Checkbox5.Checked = True Then
                    Button1.Visible = False
                    Button2.Visible = False
                End If
                If Checkbox2.Checked = True Then
                    Button1.Visible = True
                    Button2.Visible = False
                End If
                If Checkbox3.Checked = True Or Checkbox4.Checked = True Then
                    Button1.Visible = False
                    Button2.Visible = True
                End If

                Dim objDataGridItem As DataGridItem
                Dim start_button As LinkButton
                Dim stop_button As LinkButton
                Dim nonstart_button As LinkButton
                Dim Flag As Label
                Dim OPENFLAG As Label
                Dim wmno As String

                For Each objDataGridItem In dgCart.Items
                    Flag = objDataGridItem.FindControl("FLAG")
                    OPENFLAG = objDataGridItem.FindControl("OPENFLAG")
                    start_button = objDataGridItem.FindControl("start_button")
                    stop_button = objDataGridItem.FindControl("stop_button")
                    nonstart_button = objDataGridItem.FindControl("nonstart_button")
                    objDataGridItem.FindControl("wmno")


                    If Flag.Text = "1" Or Flag.Text = "4" Or Flag.Text = "3" Then
                        start_button.Enabled = True
                        start_button.Text = "啟動"
                    Else
                        start_button.Enabled = False
                        start_button.Text = "－"
                    End If

                    If Flag.Text = "3" Then
                        stop_button.Enabled = False
                        stop_button.Text = "－"
                    Else
                        stop_button.Enabled = True
                        stop_button.Text = "停權"
                    End If

                    If Flag.Text = "2" And OPENFLAG.Text = "已啟動、尚未設定用戶號碼" Then
                        nonstart_button.Enabled = True
                        nonstart_button.Text = "未啟動"
                    Else
                        nonstart_button.Enabled = False
                        nonstart_button.Text = "－"
                    End If

                Next

            End If
        Else
            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            Message.Text = ""
        End If


        'If CheckBox1.Checked = False Then
        '    chkCheckBox1 = "N"
        'End If
        'If Checkbox2.Checked = False Then
        '    chkCheckBox2 = "N"
        'End If
        'If Checkbox3.Checked = False Then
        '    chkCheckBox3 = "N"
        'End If
        'If Checkbox4.Checked = False Then
        '    chkCheckBox4 = "N"
        'End If
        'If Checkbox5.Checked = False Then
        '    chkCheckBox5 = "N"
        'End If
        'If Checkbox6.Checked = False Then
        '    chkCheckBox6 = "N"
        'End If
        'If Checkbox7.Checked = False Then
        '    chkCheckBox7 = "N"
        'End If
        'If Checkbox8.Checked = False Then
        '    chkCheckBox8 = "N"
        'End If


        ''全文檢索內容
        'likeSel = Me.likeSelect.SelectedValue
        'likeContent = Me.likeContent.Text.Trim

        'objCartDT = se.QueryMemDate(sendSDATE, sendEDATE, chkCheckBox1, chkCheckBox2, chkCheckBox3, chkCheckBox4, chkCheckBox5, chkCheckBox6, chkCheckBox7, chkCheckBox8, likeSel, likeContent)

        'dgCart.DataSource = objCartDT
        'dgCart.DataBind()
        'ShowPageStatus(objCartDT.Rows.Count)

        ''Button1.Visible = True
        ''Button2.Visible = True

        'If objCartDT.Rows.Count > 0 Then
        '    If CheckBox1.Checked = True Or Checkbox2.Checked = True Or (CheckBox1.Checked = True And Checkbox2.Checked = True) Then
        '        If Checkbox3.Checked = True Or Checkbox4.Checked = True Or Checkbox5.Checked = True Then
        '            Button2.Visible = True
        '        Else
        '            Button2.Visible = False
        '        End If
        '    Else
        '        Button1.Visible = True
        '    End If
        '    If CheckBox1.Checked = True Then
        '        If Checkbox2.Checked = True Or Checkbox3.Checked = True Or Checkbox4.Checked = True Or Checkbox5.Checked = True Then
        '            Button1.Visible = True
        '        Else
        '            Button1.Visible = False
        '        End If
        '    Else
        '        Button1.Visible = True
        '    End If
        'Else
        '    Button1.Visible = False
        '    Button2.Visible = False
        'End If


        ''For i = 0 To objCartDT.Rows.Count - 1


        ''Next
        'Dim objDataGridItem As DataGridItem
        'Dim start_button As LinkButton
        'Dim stop_button As LinkButton
        'Dim nonstart_button As LinkButton
        'Dim Flag As Label
        'Dim OPENFLAG As Label
        'Dim wmno As String

        'For Each objDataGridItem In dgCart.Items
        '    Flag = objDataGridItem.FindControl("FLAG")
        '    OPENFLAG = objDataGridItem.FindControl("OPENFLAG")
        '    start_button = objDataGridItem.FindControl("start_button")
        '    stop_button = objDataGridItem.FindControl("stop_button")
        '    nonstart_button = objDataGridItem.FindControl("nonstart_button")
        '    objDataGridItem.FindControl("wmno")

        '    If Flag.Text = "1" Or Flag.Text = "4" Or Flag.Text = "3" Then
        '        start_button.Enabled = True
        '        start_button.Text = "啟動"
        '    Else
        '        start_button.Enabled = False
        '        start_button.Text = "－"
        '    End If

        '    If Flag.Text = "3" Then
        '        stop_button.Enabled = False
        '        stop_button.Text = "－"
        '    Else
        '        stop_button.Enabled = True
        '        stop_button.Text = "停權"
        '    End If

        '    If Flag.Text = "2" And OPENFLAG.Text = "已啟動、尚未設定用戶號碼" Then
        '        nonstart_button.Enabled = True
        '        nonstart_button.Text = "未啟動"
        '    Else
        '        nonstart_button.Enabled = False
        '        nonstart_button.Text = "－"
        '    End If

        'Next

    End Sub

    Sub dgCart_Edit(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        dgCart.EditItemIndex = e.Item.ItemIndex

        'dgCart.DataSource = objCartDT
        'dgCart.DataBind()
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '查詢結果
        dgCart.CurrentPageIndex = 0
        msgbox.Text = ""
        showData()
    End Sub


    'Sub dgCart_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
    Private Sub dgCart_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.ItemCommand

        Dim wmno As String

        'wmno = dgCart.DataKeys(e.Item.ItemIndex).ToString()
        'wmno = dgCart.DataKeys(e.CommandArgument)
        wmno = e.Item.Cells(0).Text()

        If e.CommandName = "start" Then
            Response.Redirect("startmember_01.aspx?wm_no=" & wmno)
        ElseIf e.CommandName = "stop" Then
            Response.Redirect("startmember_04.aspx?wm_no=" & wmno)
        ElseIf e.CommandName = "nonstart" Then
            Response.Redirect("startmember_05.aspx?wm_no=" & wmno)
        End If
    End Sub

    'Private Sub dgCart_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.EditCommand
    '    Dim wmno As Integer
    '    '取得選取的資料ID
    '    wmno = CType(dgCart.DataKeys(e.Item.ItemIndex), Integer)

    '    If e.CommandName = "start" Then
    '        Response.Redirect("startmember_01.aspx?wm_no=" & wmno)
    '    ElseIf e.CommandName = "stop" Then
    '        Response.Redirect("startmember_04.aspx?wm_no=" & wmno)
    '    ElseIf e.CommandName = "nonstart" Then
    '        Response.Redirect("startmember_05.aspx?wm_no=" & wmno)
    '    End If
    'End Sub

    Private Function selectCheckBox() As String
        Dim selChkBxItem As CheckBox
        Dim selID As Label
        Dim objDataGridItem As DataGridItem
        Dim checkRS As String

        For Each objDataGridItem In dgCart.Items
            '在DataGrid物件中依序找出所要的Item(itemcheck & cntno)==>自訂的樣板
            selChkBxItem = objDataGridItem.FindControl("itemcheck")
            selID = objDataGridItem.FindControl("no")
            '判斷找出來的checkBox是否有被選取並作處理
            If selChkBxItem.Checked = True Then 'CheckBox有被選取
                checkRS += "" & selID.Text & ","
            End If
        Next
        If checkRS <> "" Then
            checkRS = checkRS.Substring(0, checkRS.Length - 1)
            Session("checkRS") = checkRS
        End If

        Return checkRS
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim objDao As New RECENTDAO
        'Dim se As New WebmemberBO
        'Dim sWmOpenCode As String
        'Dim MailMessage As New System.Web.Mail.MailMessage
        'Dim Body As String
        Dim no As String
        'Dim wmnos As String()
        'Dim wmno As String
        'Dim i As Integer
        'Dim dt As New DataTable

        no = selectCheckBox()

        Dim selChkBxItem As CheckBox
        Dim objDataGridItem As DataGridItem
        Dim i As Integer
        Dim si As String

        For Each objDataGridItem In dgCart.Items
            '在DataGrid物件中依序找出所要的Item(itemcheck & cntno)==>自訂的樣板
            selChkBxItem = objDataGridItem.FindControl("itemcheck")

            '判斷找出來的checkBox是否有被選取並作處理
            If selChkBxItem.Checked = True Then 'CheckBox有被選取
                i += 1
            End If
        Next

        If no <> "" Then
            si = CStr(i)
            Response.Redirect("startmember_03.aspx?no=" & no & "&i=" & si)
            Call showData()
        Else
            msgbox.Text = "請先勾選要指派的人!!"
        End If

        '        If i > 0 Then
        '            wmnos = no.Split(",")

        '            For Each wmno In wmnos
        '                dt = se.Query2(wmno)
        '                If dt.Rows.Count > 0 Then
        '                    Try
        '                        sWmOpenCode = objDao.GetWmOpenCode(Trim(wmno)).ToString
        '                        If sWmOpenCode.Length > 0 Then
        '                            Dim DataA(2) As String '= Split(sWmOpenCode, " ")
        '                            DataA(0) = Trim(Right(sWmOpenCode, 12))
        '                            DataA(1) = Trim(Left(sWmOpenCode, Len(sWmOpenCode) - 15))
        '                            SMTPCodeAdd()
        '                            MailMessage.BodyFormat = MailFormat.Html
        '                            MailMessage.From = "ebill@shinshingas.com.tw" ' "camilleliao@rpti3.com.tw"
        '                            MailMessage.To = wmno
        '                            MailMessage.Subject = "欣欣天然氣-會員註冊授權碼"

        '                            Body = "親愛的客戶" & DataA(1) & "，您好！<br/><br/>"
        '                            Body = Body & "感謝您成為欣欣天然氣網站的會員．<br/><br/>"
        '                            Body = Body & "<font color=blue size=4>請點選下面紅字確認您的電子信箱，以啟動您的會員資格．</font><br/><br/>"
        '                            'Body = Body & "如果點選下面的連結無法正常運作，您可以自行輸入或複製這個網址到您的瀏覽器．<br/><br/>"
        '                            Body = Body & "<a  href=""https://www.shinshingas.com.tw/Activity.aspx?WmOpenCode=" & DataA(0) & """><font color=red size=7>點我啟動會員資格</font></a><br/><br/>"
        '                            Body = Body & "<font color=#588994 size=4>若您無法開啟連結，請複製下方的授權碼，至欣欣天然氣網站（ <a href=""https://www.shinshingas.com.tw/"">https://www.shinshingas.com.tw/</a>) </font><br/> <br/>"
        '                            Body = Body & "點選『電子繳費憑證服務』，選擇『會員登入』頁中之『啟動會員資格』，<br/>"
        '                            Body = Body & "貼上授權碼，即可啟動完成．<br/><br/>"
        '                            Body = Body & "授權碼：" & DataA(0) & "<br/><br/><br/><br/>"
        '                            Body = Body & "謝謝！<br/>"
        '                            Body = Body & "欣欣天然氣公司股份有限公司．<br/>"
        '#If 0 Then

        '                Body = "<h1>親愛的客戶！歡迎您</h1><p><br/><br/>" ' "<html><body><h1>WELCOME</h1><p>"
        '                Body &= "您註冊的身份別是：" & IIf(DataA(3) = "1", "個人用戶", IIf(DataA(3) = "2", "營業用戶", "機關用戶")) & "<br>"
        '                Body &= "您註冊的身份證號碼是：" & DataA(2) & "<br>"
        '                Body &= "您註冊的密碼是：" & DataA(1) & "<br><hr>"
        '                Body &= "請按以下超連結登入以完成註冊程續： <BR><BR><BR>"
        '                Body = Body & "<a  href=""http://localhost/shinshin/Activity.aspx?WmOpenCode=" & DataA(0) & """><font color=red size=6>點我確認會員認證成功</font></a><br/><br/>"
        '                Body = Body & "授權碼：" & DataA(0) & "<br/><br/><br/><br/>"
        '#End If
        '                            MailMessage.Body = Body



        '                            If SendEmail("msa.hinet.net", 25, True, "ebill", "22325804", MailMessage) = True Then       '"smtp.rpti3.com.tw"
        '                                Message.Text = "授權碼己重新寄至您所申請的郵件信箱!"
        '                                Response.Redirect("recent_sucess.aspx")
        '                            Else
        '                                Message.Text = Err.Number.ToString & " " & Err.Description.ToString & "<br>由於預設的email信箱錯誤, 因此信件無法寄出, 請重新申請!"
        '                            End If

        '                        Else
        '                            Message.Text = "請再次確認您輸入的資料!"
        '                        End If
        '                    Catch ex As Exception
        '                        Message.Text = "失敗" & ex.StackTrace
        '                    End Try
        '                End If
        '            Next
        '        Else
        '            Message.Text = "未勾選人員資料"
        '        End If

        '        'If no <> "" Then
        '        '    se.SelectUpdateD(no)
        '        '    Call showData()
        '        'End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim objDao As New RECENTDAO
        'Dim se As New WebmemberBO
        'Dim sWmOpenCode As String
        'Dim MailMessage As New System.Web.Mail.MailMessage
        'Dim Body As String
        Dim no As String
        'Dim wmnos As String()
        'Dim wmno As String
        'Dim i As Integer
        'Dim dt As New DataTable

        no = selectCheckBox()

        Dim selChkBxItem As CheckBox
        Dim objDataGridItem As DataGridItem
        Dim i As Integer
        Dim si As String

        For Each objDataGridItem In dgCart.Items
            '在DataGrid物件中依序找出所要的Item(itemcheck & cntno)==>自訂的樣板
            selChkBxItem = objDataGridItem.FindControl("itemcheck")

            '判斷找出來的checkBox是否有被選取並作處理
            If selChkBxItem.Checked = True Then 'CheckBox有被選取
                i += 1
            End If
        Next

        If no <> "" Then
            si = CStr(i)
            Response.Redirect("startmember_02.aspx?no=" & no & "&i=" & si)
            Call showData()
        Else
            msgbox.Text = "請先勾選要指派的人!!"
        End If

        'i = Len(no)

        'If i > 0 Then
        '    wmnos = no.Split(",")

        '    For Each wmno In wmnos
        '        dt = se.Query1(wmno)
        '        If dt.Rows.Count > 0 Then
        '            Try
        '                sWmOpenCode = objDao.GetWmOpenCode(Trim(wmno)).ToString
        '                If sWmOpenCode.Length > 0 Then
        '                    Dim DataA(2) As String '= Split(sWmOpenCode, " ")
        '                    DataA(0) = Trim(Right(sWmOpenCode, 12))
        '                    DataA(1) = Trim(Left(sWmOpenCode, Len(sWmOpenCode) - 15))
        '                    SMTPCodeAdd()
        '                    MailMessage.BodyFormat = MailFormat.Html
        '                    MailMessage.From = "ebill@shinshingas.com.tw" ' "camilleliao@rpti3.com.tw"
        '                    MailMessage.To = wmno
        '                    MailMessage.Subject = "提醒欣欣天然氣電子繳費憑證會員"
        '                    Body = "親愛的客戶" & DataA(1) & "，您好！<br/><br/><br/>"
        '                    Body = Body & "１.您尚未設定本公司氣費『用戶號碼』．<br/>"
        '                    Body = Body & "請至『會員專區』頁之『用戶申請／取消電子繳費憑證』中，新增您的用戶號碼；<br/>"
        '                    Body = Body & "如您不知用戶號碼，請查詢前期氣費繳費憑證．<br/><br/><br/><br/>"
        '                    Body = Body & "謝謝！<br/>"
        '                    Body = Body & "欣欣天然氣公司股份有限公司．<br/>"

        '                    MailMessage.Body = Body

        '                    If SendEmail("msa.hinet.net", 25, True, "ebill", "22325804", MailMessage) = True Then       '"smtp.rpti3.com.tw"
        '                        Message.Text = "未設用戶號碼己寄至所申請的郵件信箱!"
        '                        Response.Redirect("recent_sucess.aspx")
        '                    Else
        '                        Message.Text = Err.Number.ToString & " " & Err.Description.ToString & "<br>由於預設的email信箱錯誤, 因此信件無法寄出, 請重新申請!"
        '                    End If

        '                Else
        '                    Message.Text = "請再次確認您輸入的資料!"
        '                End If
        '            Catch ex As Exception
        '                Message.Text = "失敗" & ex.StackTrace
        '            End Try
        '        End If
        '    Next
        'Else
        '    Message.Text = "未勾選人員資料"
        'End If

        ''If no <> "" Then
        ''    se.SelectUpdateD(no)
        ''    Call showData()
        ''End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Checkbox2.Checked = False
            Checkbox3.Checked = False
            Checkbox4.Checked = False
            Checkbox5.Checked = False

            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            Message.Text = ""
            Button1.Visible = False
            Button2.Visible = False

        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkbox2.CheckedChanged
        If Checkbox2.Checked = True Then
            CheckBox1.Checked = False
            Checkbox3.Checked = False
            Checkbox4.Checked = False
            Checkbox5.Checked = False

            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            Message.Text = ""
            Button1.Visible = False
            Button2.Visible = False

        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkbox3.CheckedChanged
        If Checkbox3.Checked = True Then
            CheckBox1.Checked = False
            Checkbox2.Checked = False
            Checkbox4.Checked = False
            Checkbox5.Checked = False

            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            Message.Text = ""
            Button1.Visible = False
            Button2.Visible = False

        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkbox4.CheckedChanged
        If Checkbox4.Checked = True Then
            CheckBox1.Checked = False
            Checkbox2.Checked = False
            Checkbox3.Checked = False
            Checkbox5.Checked = False

            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            Message.Text = ""
            Button1.Visible = False
            Button2.Visible = False

        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkbox5.CheckedChanged
        If Checkbox5.Checked = True Then
            CheckBox1.Checked = False
            Checkbox2.Checked = False
            Checkbox3.Checked = False
            Checkbox4.Checked = False

            dgCart.DataSource = objCartDT
            dgCart.DataBind()
            Message.Text = ""
            Button1.Visible = False
            Button2.Visible = False

        End If
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
        'If Trim(Right(likeContent.Text, 1)) = "'" Then
        '    msgbox.Text = "身分證號碼(統一編號)格式錯誤"
        '    Return ReMsg
        'Else
        '    ReMsg = 1
        'End If
        'Else
        'ReMsg = 1
        'End If

        Return ReMsg
    End Function
#End Region
End Class
