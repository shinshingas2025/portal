Public Class user_01
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
    Protected WithEvents ProcessDateO As System.Web.UI.WebControls.RadioButton
    Protected WithEvents ProcessSDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents ProcessEDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents status As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents btnPrint As System.Web.UI.WebControls.Button
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label

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
    Dim AppEDATE, AppSDATE, ProSdate, ProEdate As String

    Dim ReportServer As String = Configration.ReportServerURL

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        ''---------------------------------------------
        'If (Session("LoginID") Is Nothing) Then
        '    Response.Redirect("login.aspx")
        'End If
        '---------------------------------------------
        '1071026 add 
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        'end 1071026 
        'objCartDT = CType(Session("Cart"), DataTable)
        If Not IsPostBack Then
            Call GetUser(context.User.Identity.Name.Trim)

            'ApplySDATE.Text = CType(Year(Now), String) + "/" + CType(Month(Now), String) + "/" + CType(Day(Now), String)
            'ApplyEDATE.Text = CType(Year(Now), String) + "/" + CType(Month(Now), String) + "/" + CType(Day(Now), String)
            'ProcessSDATE.Text = CType(Year(Now), String) + "/" + CType(Month(Now), String) + "/" + CType(Day(Now), String)
            'ProcessEDATE.Text = CType(Year(Now), String) + "/" + CType(Month(Now), String) + "/" + CType(Day(Now), String)

            ApplySDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            ApplyEDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            ProcessSDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            ProcessEDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
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

    Sub showData()
        Dim se As New NewApplyFormBO
        If applydateO.Checked = True Then
            Dim tmpAppEDATE As String = ApplyEDATE.Text.Trim
            AppEDATE = Left(tmpAppEDATE, 4) + "/" + Mid(tmpAppEDATE, 5, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"
            'AppSDATE = ApplySDATE.Text.Trim + " 00:00:00"
            AppSDATE = Left(ApplySDATE.Text.Trim, 4) + "/" + Mid(ApplySDATE.Text.Trim, 5, 2) + "/" + CType(Right(ApplySDATE.Text.Trim, 2), String) + " 00:00:00"

            ProSdate = "1900/01/01"
            ProEdate = "2099/12/31"

            objCartDT = se.QueryDate(status.SelectedValue, AppSDATE, AppEDATE, "", "")
        Else
            AppSDATE = "1900/01/01"
            AppEDATE = "2099/12/31"

            'ProSdate = ProcessSDATE.Text.Trim + " 00:00:00"
            ProSdate = Left(ProcessSDATE.Text.Trim, 4) + "/" + Mid(ProcessSDATE.Text.Trim, 5, 2) + "/" + CType(Right(ProcessSDATE.Text.Trim, 2), String) + " 00:00:00"

            Dim tmpProEdate As String = ProcessEDATE.Text.Trim
            ProEdate = Left(tmpProEdate, 4) + "/" + Mid(tmpProEdate, 5, 2) + "/" + CType(Right(tmpProEdate, 2), String) + " 23:59:59"
            objCartDT = se.QueryDate(status.SelectedValue, "", "", ProSdate, ProEdate)
        End If


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
        Call SearchPorcess()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchPorcess()
    End Sub

    Private Sub SearchPorcess()
        If applydateO.Checked = True Then
            If ApplySDATE.Text.Trim = "" And ApplyEDATE.Text.Trim = "" Then
                msgbox.Text = "請輸入查詢日期!"
                Exit Sub
            ElseIf ApplySDATE.Text.Trim <> "" And ApplyEDATE.Text.Trim = "" Then
                ApplyEDATE.Text = ApplySDATE.Text
            End If
            If ProcessSDATE.Text.Trim = "" And ProcessEDATE.Text.Trim = "" Then
                msgbox.Text = "請輸入查詢日期!"
                Exit Sub
            ElseIf ProcessSDATE.Text.Trim <> "" And ProcessEDATE.Text.Trim = "" Then
                ProcessEDATE.Text = ProcessSDATE.Text
            End If
        End If
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
        Else
            If ProcessSDATE.Text.Trim = "" Or ProcessEDATE.Text.Trim = "" Then
                msgbox.Text = "請輸入查詢日期!"
                Exit Sub
            End If
        End If
        msgbox.Text = ""
        showData()
        'Response.Redirect("http://rpti3-2003/ReportServer?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e4%b8%80%e8%a6%bd%e8%a1%a8&SDATE=" & ApplySDATE.Text.Trim & "&EDATE=" & ApplyEDATE.Text.Trim & "&STATUS=" & status.SelectedValue & "&rs%3aClearSession=true&rs%3aCommand=Render&rs%3aFormat=HTML4.0&rc%3aReplacementRoot=http%3a%2f%2frpti3-2003%2fReports%2fPages%2fReport.aspx%3fServerUrl%3d&rc%3aToolbar=True&rc%3aJavaScript=True&rc%3aLinkTarget=_top&rc%3aArea=Report")
        'Response.Redirect(ReportServer & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e8%a1%a8&AppSDATE=" & AppSDATE & "&AppEDATE=" & AppEDATE & "&ProSDATE=" & ProSdate & "&ProEDATE=" & ProEdate & "&STATUS=" & status.SelectedValue & "&EntityID=%" & "&rc:Parameters=false")
        '1141022 add 
        Dim UrlStr As String
        UrlStr = "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e8%a1%a8&AppSDATE=" & AppSDATE & "&AppEDATE=" & AppEDATE & "&ProSDATE=" & ProSdate & "&ProEDATE=" & ProEdate & "&STATUS=" & status.SelectedValue & "&EntityID=%" & "&rc:Parameters=false"

        Dim liScript As New System.Text.StringBuilder(" ")
        liScript.Append("window.open('" & ReportServer & UrlStr & "', '_blank','height=800,width=900,status=yes,toolbar=no,menubar=no,location=no');" & vbCrLf)
        Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValalue", liScript.ToString(), True)

    End Sub

    Private Sub dgCart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCart.SelectedIndexChanged

        ' Dim ss As String = sender.GetType.ToString()
        Dim entityid As String
        entityid = dgCart.DataKeys(dgCart.SelectedIndex).ToString().Trim
        Dim UrlStr As String
        'UrlStr = "http://rpti3-nz/Reports/Pages/Report.aspx?ItemPath=%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e8%a1%a8&AppSDATE=1900/01/01&AppEDATE=2099/12/31&ProSDATE=1900/01/01&ProEDATE=2099/12/31&STATUS=" & status.SelectedValue & "&EntityID=" & entityid & ""
        UrlStr = "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%96%b0%e7%94%a8%e6%88%b6%e7%94%b3%e8%ab%8b%e8%a1%a8&AppSDATE=1900/01/01&AppEDATE=2099/12/31&ProSDATE=1900/01/01&ProEDATE=2099/12/31&STATUS=" & status.SelectedValue & "&EntityID=" & entityid
        '1141022 remark
        'Response.Redirect(ReportServer & UrlStr & "&rc:Parameters=false")
        '1141022 add  
        Dim liScript As New System.Text.StringBuilder(" ")
        liScript.Append("window.open('" & ReportServer & UrlStr & "&rc:Parameters=false', '_blank','height=800,width=900,status=yes,toolbar=no,menubar=no,location=no');" & vbCrLf)
        Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValalue", liScript.ToString(), True)
    End Sub

    Private Sub btnPrint_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnPrint.Command

    End Sub
    '匯入資料到informix
    Private Sub dgCart_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.ItemCommand
        Dim EntityID As String
        Dim SendID As String
        Dim UpSendID As String
        Dim myUser01BO As New User01BO
        Dim myAPPX01Entity As New APPX01Entity
        Dim myNewApplyBO As New NewApplyFormBO
        Dim myEmployeeID As String
        Dim tmpYear As String  ' cherry add 2010-02-23

        msgbox.Text = ""
        '取得觸發資料行的ID
        Try
            Select Case (CType(e.CommandSource, Button)).CommandName

                Case "send"
                    EntityID = e.Item.Cells(0).Text()
                    '取得SendID
                    'SendID = (Year(Now()) - 1911) & Right("0000" & UpSendID, 5) & "0000"
                    'UpSendID = myUser01BO.getSendID(Year(Now()) - 1911)
                    'modify 1070929 
                    UpSendID = myUser01BO.getSendNewID(Year(Now()) - 1911)
                    tmpYear = Right("0000" & (Year(Now()) - 1911), 3)           ' cherry add 2010-02-23
                    SendID = tmpYear & Right("0000" & UpSendID, 5) & "0000"     ' cherry mod 2010-02-23

                    '取得要匯入informix的資料
                    myAPPX01Entity = myUser01BO.getInAPPX01Entity(EntityID)
                    myEmployeeID = myUser01BO.getEmployeeID(context.User.Identity.Name.Trim)
                    If myEmployeeID <> "" Then
                        myAPPX01Entity.ax01_de_user = myEmployeeID
                        '匯入informix
                        myUser01BO.InsertAPPX01Entity(SendID, myAPPX01Entity)
                        'User01BO.InsertAPPX01Entity("98765432101", myAPPX01Entity)
                        '紀錄匯入時間及SendID
                        myNewApplyBO.Update(EntityID.Trim, SendID.Trim)
                        '更新SendID
                        '1070929 remake 
                        ' myUser01BO.UpdateSendID(UpSendID)
                        'test = CType(e.Item.FindControl("test"), Label).Text
                        Call SearchPorcess()
                    Else
                        msgbox.Text = "查無員工編號，匯入資料失敗，請通知資訊人員!!"
                        Exit Sub
                    End If
                Case Else

            End Select
        Catch ex As System.InvalidCastException
            ex.ToString()
            Exit Sub
        End Try
        

    End Sub
    '處理"匯入informix按鈕"是否顯示
    Public Function getMode(ByVal SendTimeStr As DateTime, ByVal Status As String) As String
        Dim Mode As String

        If SendTimeStr <> "1900/1/1" Or Status.Trim = "1" Then
            Mode = "false"
        Else
            Mode = "true"
        End If

        Return Mode
    End Function
End Class
