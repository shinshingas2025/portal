Imports System.Configuration
Public Class member_01
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnPrint As System.Web.UI.WebControls.Button
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
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
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents txtDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDateEnd As System.Web.UI.WebControls.TextBox

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

    Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%9c%83%e5%93%a1%e8%a8%bb%e5%86%8a%e8%b3%87%e6%96%99%e5%8f%8a%e7%8b%80%e6%85%8b%e6%9f%a5%e8%a9%a2%e8%a1%a8&rc:Parameters=false"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        If (Session("sid") Is Nothing) Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        ' objCartDT = CType(Session("Cart"), DataTable)
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

    Sub showData()
        Dim se As New WebmemberDotDAO
        Dim tmpAppEDATE As String
        Dim tmpAppSDATE As String
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
        'CheckBox1.Checked 選擇已啟動、已設定用戶號碼資料
        'CheckBox2.Checked 選擇已啟動、尚未設定用戶號碼資料
        'CheckBox3.Checked 選擇尚未啟動資料
        'CheckBox4.Checked 選擇授權碼發送失敗資料
        'CheckBox5.Checked 選擇停權資料
        'CheckBox6.Checked 選擇個人用戶
        'CheckBox7.Checked 選擇營業用戶
        'CheckBox8.Checked 選擇機關用戶

        msgbox.Text = ""
        sDateStart = getDate(txtDateStart.Text.ToString.Trim, "1911/01/01")
        sDateEnd = getDate(txtDateEnd.Text.ToString.Trim, "2999/12/31")

        If (getDefaulVal(txtDateStart.Text.ToString.Trim, 0) > getDefaulVal(txtDateEnd.Text.ToString.Trim, 9991231)) Then
            msgbox.Text = "起始日不可大於終止日!!"
        End If

        If msgbox.Text <> "" Then
            Exit Sub
        End If

        sendSDATE = sDateStart & " 00:00:00"
        sendEDATE = sDateEnd & " 23:59:59"

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

        objCartDT = se.QueryMemDate(sendSDATE, sendEDATE, chkCheckBox1, chkCheckBox2, chkCheckBox3, chkCheckBox4, chkCheckBox5, chkCheckBox6, chkCheckBox7, chkCheckBox8, likeSel, likeContent)

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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '查詢結果
        msgbox.Text = ""
        dgCart.CurrentPageIndex = 0
        showData()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim ReportString As String = ""
        Dim sDateStart As String = ""
        Dim sDateEnd As String = ""
        Dim tmpAppEDATE As String
        Dim tmpAppSDATE As String
        Dim likeSel As String
        Dim likeContent As String
        Dim status1 As String = "0"
        Dim status2 As String = "0"
        Dim status3 As String = "0"
        Dim status4 As String = "0"
        Dim status5 As String = "0"
        Dim status6 As String = "0"
        Dim status7 As String = "0"
        Dim status8 As String = "0"

        msgbox.Text = ""
        sDateStart = getDate(txtDateStart.Text.ToString.Trim, "1911/01/01")
        sDateEnd = getDate(txtDateEnd.Text.ToString.Trim, "9999/12/31")
        If (getDefaulVal(txtDateStart.Text.ToString.Trim, 0) > getDefaulVal(txtDateEnd.Text.ToString.Trim, 9991231)) Then
            msgbox.Text = "起始日不可大於終止日!!"
        End If

        If msgbox.Text <> "" Then
            Exit Sub
        End If

        showData()
        Dim tot_cnt As Integer
        tot_cnt = objCartDT.Rows.Count

        If (sDateStart <> "") Then
            tmpAppSDATE = sDateStart
            tmpAppSDATE = Left(tmpAppSDATE, 4) + "-" + Mid(tmpAppSDATE, 6, 2) + "-" + CType(Right(tmpAppSDATE, 2), String)
        Else
            tmpAppSDATE = "1900-01-01"
        End If

        If (sDateEnd <> "") Then
            tmpAppEDATE = sDateEnd
            tmpAppEDATE = Left(tmpAppEDATE, 4) + "-" + Mid(tmpAppEDATE, 6, 2) + "-" + CType(Right(tmpAppEDATE, 2), String)
        Else
            tmpAppEDATE = "2099-12-31"
        End If

        sendSDATE = tmpAppSDATE
        sendEDATE = tmpAppEDATE

        If CheckBox1.Checked = True Then
            status1 = "1"
        End If
        If Checkbox2.Checked = True Then
            status2 = "2"
        End If
        If Checkbox3.Checked = True Then
            status3 = "3"
        End If
        If Checkbox4.Checked = True Then
            status4 = "4"
        End If
        If Checkbox5.Checked = True Then
            status5 = "5"
        End If
        If Checkbox6.Checked = True Then
            status6 = "1"
        End If
        If Checkbox7.Checked = True Then
            status7 = "2"
        End If
        If Checkbox8.Checked = True Then
            status8 = "3"
        End If

        '全文檢索內容
        likeSel = Me.likeSelect.SelectedValue
        likeContent = Me.likeContent.Text.Trim

        Dim like_wm_id As String = "%"              ' like 身份證號碼(統一編號)
        Dim like_wm_email As String = "%"           ' like 電子信箱
        Dim like_wm_user_name As String = "%"       ' like 申請人姓名(承辦人姓名)
        Dim like_wm_mobile As String = "%"          ' like 行動電話

        If likeContent <> "" Then
            If likeSel = "wm_id" Then
                like_wm_id = likeContent
            End If
            If likeSel = "wm_email" Then
                like_wm_email = likeContent
            End If
            If likeSel = "wm_user_name" Then
                like_wm_user_name = likeContent
            End If
            If likeSel = "wm_mobile" Then
                like_wm_mobile = likeContent
            End If
        End If

        '列印報表
        ReportString = "&myStartDate=" & sendSDATE & "&myEndDate=" & sendEDATE & "&status1=" & status1 & "&status2=" & status2 & "&status3=" & status3
        ReportString = ReportString & "&status4=" & status4 & "&status5=" & status5 & "&status6=" & status6 & "&status7=" & status7 & "&status8=" & status8
        ReportString = ReportString & "&lid=%25" & like_wm_id & "%25&lemail=%25" & like_wm_email & "%25&luname=%25" & like_wm_user_name & "%25&lmobile=%25" & like_wm_mobile & "%25"
        ReportString = ReportString & "&totcnt=" & Trim(tot_cnt)
        Response.Redirect(IFrameSrc & ReportString)

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

End Class
